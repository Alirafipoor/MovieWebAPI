using Application.Dto.ResultDto;
using Application.Dto.Token;
using Domain.Entitties.UserEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Token.CreateTokenFeature
{
    public class CreateTokenRequest:IRequest<ResultDto<CreateTokenDto>>
    {
        public User User { get; set; }
    }
}
