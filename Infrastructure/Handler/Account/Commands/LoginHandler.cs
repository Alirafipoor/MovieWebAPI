using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Account.LoginFeature;
using Application.Features.Commands.Account.RegisterFeature;
using Domain.Entitties.MovieEnttiy;
using Domain.Entitties.UserEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Account.Commands
{
    public class LoginHandler : IRequestHandler<LoginRequest, ResultDto<User>>
    {
        private readonly IDatabaseContext _context;
        private readonly IMediator _mediator;

        public LoginHandler(IDatabaseContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<ResultDto<User>> IRequestHandler<LoginRequest, ResultDto<User>>.Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var User = await _context.SmsCodes.Where(p => p.PhoneNumber == request.PhoneNumber && p.Code == request.Code).FirstOrDefaultAsync();
                if (User == null)
                {
                    return new ResultDto<User>(null,false, "User Not Found");
                }
                else
                {
                    if (User.IsUse == true)
                    {
                        return new ResultDto<User>(null,false, "User Not Found");
                    }

                    User.IsUse = true;
                    User.RequestCount++;
                    _context.SaveChanges();

                    var FindUser = _context.Users.Where(p => p.PhoneNumber == request.PhoneNumber).FirstOrDefault();

                    if (FindUser != null)
                    {
                        return new ResultDto<User>(FindUser,true, "User Logined");
                    }
                    else
                    {
                        var Result = await _mediator.Send(new RegisterRequest { PhoneNumber = request.PhoneNumber });
                        if (Result.IsSuccess)
                        {
                            return new ResultDto<User>(Result.Data,true, "User Registed");
                        }

                        return new ResultDto<User>(null,false, "Error");
                    }

                }


            }
            catch (Exception ex)
            {
                return new ResultDto<User>(null,false, ex.Message);
            }
        }
    }
}
