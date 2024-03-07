using Application.Dto.ResultDto;
using Domain.Entitties.UserEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.userToken.FindRefreshTokenFeature
{
    public class FindRefreshTokenRequest:IRequest<ResultDto<UserToken>>
    {
        public string RefreshToken {  get; set; }
    }
}
