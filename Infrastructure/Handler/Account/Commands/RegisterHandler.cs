using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Account.RegisterFeature;
using Domain.Entitties.UserEntity;
using MediatR;

namespace Infrastructure.Handler.Account.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, ResultDto<User>>
    {
        private readonly IDatabaseContext _context;

        public RegisterHandler(IDatabaseContext context)
        {
            _context = context;
        }


        async Task<ResultDto<User>> IRequestHandler<RegisterRequest, ResultDto<User>>.Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = new User()
                {
                    PhoneNumber = request.PhoneNumber,
                    IsActive = true,

                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return await Task.FromResult(new ResultDto<User>(user,true, "Ok"));
            }
            catch (Exception ex)
            {
                return new ResultDto<User>(null,false, ex.Message);
            }
        }
    }
}
