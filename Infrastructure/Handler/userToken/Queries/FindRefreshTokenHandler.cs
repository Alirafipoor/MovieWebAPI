using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Queries.userToken.FindRefreshTokenFeature;
using Domain.Entitties.UserEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Helpers;

namespace Infrastructure.Handler.userToken.Queries
{
    public class FindRefreshTokenHandler : IRequestHandler<FindRefreshTokenRequest, ResultDto<UserToken>>
    {
        private readonly IDatabaseContext _context;

        public FindRefreshTokenHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<UserToken>> Handle(FindRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                

                var RefreshToken=await _context.UserTokens.Include(p=>p.User).SingleOrDefaultAsync(p=>p.RefreshToken==request.RefreshToken);

                if (RefreshToken == null)
                    return new ResultDto<UserToken>(null, false, "Not Found");

                return new ResultDto<UserToken>(RefreshToken, true, "Ok");
            }
            catch (Exception ex)
            {
                return new ResultDto<UserToken>(null,false, ex.Message);
            }
        }
    }
}
