using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Account.AddRecommandFeature;
using Domain.Entitties.UserEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Account.Commands
{
    public class AddRecommandHandler : IRequestHandler<AddReCommandRequest, ResultDto>
    {
        private readonly IDatabaseContext _context;

        public AddRecommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Handle(AddReCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                try
                {
                    var User = await _context.Users.FindAsync(request.Id);
                    if (User != null)
                    {
                        User.Recommand.Add(request.GenreId);
                        _context.SaveChanges();
                        return new ResultDto(true, "Ok");
                    }
                    return new ResultDto(false, "Error");
                    
                }
                catch (Exception ex)
                {
                    return new ResultDto(false, ex.Message);
                }

            }
            catch(Exception ex)
            {
                return new ResultDto(false, ex.Message);
            }
        }
    }
}
