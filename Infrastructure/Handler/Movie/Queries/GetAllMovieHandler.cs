using Application.Context;
using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Application.Features.Queries.Movie.GetAllMovieFeature;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Movie.Queries
{
    public class GetAllMovieHandler : IRequestHandler<GetAllMovieRequest, ResultDto<List<GetAllMovieDto>>>
    {
        private readonly IDatabaseContext _context;

        public GetAllMovieHandler(IDatabaseContext context)
        {
            _context = context;
        }

        async Task<ResultDto<List<GetAllMovieDto>>> IRequestHandler<GetAllMovieRequest, ResultDto<List<GetAllMovieDto>>>.Handle(GetAllMovieRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Result = await _context.Movies
                    .Include(p => p.Genre)
                    .Include(p => p.Actors)
                    .Include(p => p.Directors)
                    .Include(p => p.Review)
                    .Include(p => p.UserRating)
                    .Select(p => new GetAllMovieDto
                    {
                        Title = p.Title,
                        Year = p.Year,
                        Genre = p.Genre.Name,
                        UserRate = p.UserRatingId != null ? p.UserRating.UserRate : null,
                        Review = p.ReviewId != null ? p.Review.ReviewsCount : null,
                        Actors = p.Actors.Select(c => c.Name).ToList(),
                        Directors = p.Directors.Select(p => p.Name).ToList(),
                    })
                    .AsNoTracking().ToListAsync();
                return new ResultDto<List<GetAllMovieDto>>(Result, true, "Ok");

            }
            catch (Exception ex)
            {
                return new ResultDto<List<GetAllMovieDto>>(null, false, ex.Message);
            }
        }
    }
}
