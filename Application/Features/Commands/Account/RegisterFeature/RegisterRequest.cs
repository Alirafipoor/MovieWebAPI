using Application.Dto.ResultDto;
using Domain.Entitties.UserEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Account.RegisterFeature
{
    public class RegisterRequest:IRequest<ResultDto<User>>
    {
        public string PhoneNumber { get; set; }
    }
}
