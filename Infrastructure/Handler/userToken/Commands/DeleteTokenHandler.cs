using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.userToken.DeleteTokenFeature;
using Application.Features.Queries.userToken.FindRefreshTokenFeature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.userToken.Commands
{
    public class DeleteTokenHandler : IRequestHandler<DeleteTokenRequest, ResultDto>
    {
        private readonly IDatabaseContext _context;
        private readonly IMediator _mediator;

        public DeleteTokenHandler(IDatabaseContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultDto> Handle(DeleteTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var RefreshToken=await _mediator.Send(new FindRefreshTokenRequest { RefreshToken = request.RefreshToken });

                if (!RefreshToken.IsSuccess)
                    return new ResultDto(false, "Not Found");

                _context.UserTokens.Remove(RefreshToken.Data);
                _context.SaveChanges();
                return new ResultDto(true, "Ok");
            }
            catch (Exception ex)
            {
                return new ResultDto(false, "Error");
            }
           
        }
    }
}
