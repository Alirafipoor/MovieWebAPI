using Application.Dto.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.userToken.DeleteTokenFeature
{
    public class DeleteTokenRequest:IRequest<ResultDto>
    {
        public string RefreshToken { get; set; }
    }
}
