using Application.Dto.ResultDto;
using Domain.Entitties.UserEntity;
using MediatR;

namespace Application.Features.Commands.Account.LoginFeature
{
    public class LoginRequest:IRequest<ResultDto<User>>
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
