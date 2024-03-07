using Application.Context;
using Application.Dto.ResultDto;
using Application.Dto.Token;
using Application.Features.Commands.Token.CreateRefreshTokenDeature;
using Application.Features.Commands.Token.CreateTokenFeature;
using Application.Features.Commands.Token.GenerateTokenAndRefreshTokenFeature;
using Domain.Entitties.UserEntity;
using MediatR;
using WebApi.Bugeto.Models.Helpers;

namespace Infrastructure.Handler.Token.Commands
{
    public class GenrateTokenAndRefreshtokenHandler : IRequestHandler<GenrateTokenAndRefreshtokenRequest, ResultDto<GenrateToken>>
    {
        private readonly IDatabaseContext _context;
        private readonly IMediator _mediator;

        public GenrateTokenAndRefreshtokenHandler(IDatabaseContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultDto<GenrateToken>> Handle(GenrateTokenAndRefreshtokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Token=await _mediator.Send(new CreateTokenRequest { User=request.User });
                var RefreshToken = await _mediator.Send(new CreateRefreshTokenRequest());

                if (!Token.IsSuccess || !RefreshToken.IsSuccess)
                    return new ResultDto<GenrateToken>(null, false, "Error");


                UserToken userToken = new UserToken()
                {
                    UserId = request.User.Id,
                    TokenHash = Token.Data.Token,
                    TokenExp = Token.Data.Exp,
                    RefreshToken = RefreshToken.Data,
                    RefreshTokenExp = DateTime.Now.AddDays(30)
                };

                _context.UserTokens.Add(userToken);
                _context.SaveChanges();

                GenrateToken genrateToken = new GenrateToken()
                {
                    Token = Token.Data.Token,
                    RefreshToken = RefreshToken.Data
                };

                 return new ResultDto<GenrateToken>(genrateToken, true, "Ok");
                
                 
            }
            catch (Exception ex)
            {
                return new ResultDto<GenrateToken>(null,false , ex.Message);
            }
        }
    }
}
