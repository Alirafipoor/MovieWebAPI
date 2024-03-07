using Application.Dto.ResultDto;
using Application.Dto.Token;
using Application.Features.Commands.Token.CreateRefreshTokenDeature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Helpers;

namespace Infrastructure.Handler.Token.Commands
{
    public class CreateRefreshTokenHandler : IRequestHandler<CreateRefreshTokenRequest, ResultDto<string>>
    {
        public async Task<ResultDto<string>> Handle(CreateRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                
                var RefreshToken = Guid.NewGuid();

                SecurityHelper securityHelper = new SecurityHelper();

                var RefreshTokenHash = securityHelper.Getsha256Hash(RefreshToken.ToString());
                return await Task.FromResult(new ResultDto<string>(RefreshTokenHash, true, "Ok"));

            }
            catch(Exception ex)
            {
                return new ResultDto<string>(null,false,ex.Message);
            }
        }

       
    }
}
