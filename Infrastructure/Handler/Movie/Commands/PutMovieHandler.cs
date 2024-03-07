using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Movie.PutMovieFeature;
using AutoMapper;
using MediatR;

namespace Infrastructure.Handler.Movie.Commands
{
    public class PutMovieHandler : IRequestHandler<PutMovieRequest, ResultDto<int>>
    {
        private readonly IDatabaseContext _context;
        


        public PutMovieHandler(IDatabaseContext context)
        {
            _context = context;
            
        }

        public async Task<ResultDto<int>> Handle(PutMovieRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var MovieFind = await _context.Movies.FindAsync(request.PutMovieDto.Id);
                if (MovieFind == null)
                    return new ResultDto<int>(00, false, "Not Found Movie");

                MovieFind.Title= request.PutMovieDto.Title;
                MovieFind.Year= request.PutMovieDto.Year;
                MovieFind.GenreId = request.PutMovieDto.GenreId;
                MovieFind.UserRatingId = request.PutMovieDto.UserRatingId != null ? request.PutMovieDto.UserRatingId :MovieFind.UserRatingId;
                MovieFind.ReviewId=request.PutMovieDto.ReviewId != null ? request.PutMovieDto.ReviewId :MovieFind.ReviewId;

                _context.SaveChanges();

                return new ResultDto<int>(MovieFind.Id, true, "Ok");

            }
            catch (Exception ex)
            {
                return new ResultDto<int>(0, false, ex.Message);
            }

        }
    }
}
