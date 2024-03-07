using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Account.GetCodeFeature;
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
    public class GetCodeHandler : IRequestHandler<GetCodeRequest, ResultDto<string>>
    {
        private readonly IDatabaseContext _context;

        public GetCodeHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public  Task<ResultDto<string>> Handle(GetCodeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Random random = new Random();
                var Code = random.Next(1000, 9999).ToString();

                SmsCode smsCode = new SmsCode()
                {
                    PhoneNumber = request.PhoneNumber,
                    Code = Code,
                    IsUse = false,
                    InsertTime = DateTime.Now,
                    RequestCount = 0
                };

                _context.SmsCodes.Add(smsCode);
                _context.SaveChanges();

                return Task.FromResult(new ResultDto<string>(Code, true, "Ok"));
            }
            catch (Exception ex)
            {
                return new ResultDto<string>(null ,false, ex.Message);
            }
        }
    }
}
