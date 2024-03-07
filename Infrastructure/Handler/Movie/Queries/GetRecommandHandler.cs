using Application.Context;
using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Application.Features.Queries.Movie.GetRecommandFeature;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handler.Movie.Queries
{
    public class GetRecommandHandler : IRequestHandler<GetRecommandRequest, ResultDto<List<GetAllMovieDto>>>
    {
        private readonly IDatabaseContext _context;

        public GetRecommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        async Task<ResultDto<List<GetAllMovieDto>>> IRequestHandler<GetRecommandRequest, ResultDto<List<GetAllMovieDto>>>.Handle(GetRecommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var GenreList = await _context.Users.Where(p => p.Id == request.UserId).Select(p => p.Recommand).FirstOrDefaultAsync();

                if (GenreList != null)
                {
                    var Genre = GenreList[GenreList.Count - 1];

                    var MovieList = _context.Movies.Where(p => p.GenreId == Genre).Select(p => new GetAllMovieDto
                    {
                        Title = p.Title,
                        Year = p.Year,
                        Genre = p.Genre.Name,
                        UserRate = p.UserRatingId != null ? p.UserRating.UserRate : null,
                        Review = p.ReviewId != null ? p.Review.ReviewsCount : null,
                        Actors = p.Actors.Select(c => c.Name).ToList(),
                        Directors = p.Directors.Select(p => p.Name).ToList(),
                    }).ToList();

                    return new ResultDto<List<GetAllMovieDto>>(MovieList, true, "Ok");
                }
                return new ResultDto<List<GetAllMovieDto>>(null, false, "Error");

            }
            catch (Exception ex)
            {
                return new ResultDto<List<GetAllMovieDto>>(null, false, ex.Message);    
            }
        }
    }
}
