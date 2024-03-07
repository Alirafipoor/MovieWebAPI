using Application.Dto.ResultDto;
using Application.Dto.Token;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Token.CreateRefreshTokenDeature
{
    public class CreateRefreshTokenRequest:IRequest<ResultDto<string>>
    {

    }
}
