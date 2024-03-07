using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Movie.DeleteMovieFeature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Movie.Commands
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieRequest, ResultDto>
    {
        private readonly IDatabaseContext _context;

        public DeleteMovieHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Handle(DeleteMovieRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Movie = await _context.Movies.FindAsync(request.Id);

                if (Movie == null)
                {
                    return new ResultDto(false, "Not Found Movie");
                }

                _context.Movies.Remove(Movie);
                _context.SaveChanges();
                return new ResultDto(true, "Ok");

            }
            catch (Exception ex)
            {
                return new ResultDto(false, ex.Message);
            }
        }
    }
}
