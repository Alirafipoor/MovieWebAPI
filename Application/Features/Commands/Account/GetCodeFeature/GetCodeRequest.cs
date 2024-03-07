using Application.Dto.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Account.GetCodeFeature
{
    public class GetCodeRequest:IRequest<ResultDto<string>>
    {
        public string PhoneNumber { get; set; }
    }
}
