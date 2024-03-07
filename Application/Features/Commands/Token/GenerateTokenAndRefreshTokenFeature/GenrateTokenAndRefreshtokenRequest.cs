using Application.Dto.ResultDto;
using Application.Dto.Token;
using Domain.Entitties.UserEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Token.GenerateTokenAndRefreshTokenFeature
{
    public class GenrateTokenAndRefreshtokenRequest:IRequest<ResultDto<GenrateToken>>
    {
        public User User { get; set; }  
    }
}
