using Application.Context;
using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Application.Features.Queries.Movie.GetMovieByIdFeature;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handler.Movie.Queries
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdRequest, ResultDto<GetMovieByIdDto>>
    {
        private readonly IDatabaseContext _context;

        public GetMovieByIdHandler(IDatabaseContext context)
        {
            _context = context;
        }


        async Task<ResultDto<GetMovieByIdDto>> IRequestHandler<GetMovieByIdRequest, ResultDto<GetMovieByIdDto>>.Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                
                var Movie = await _context.Movies
                    .Include(p => p.Genre)
                    .Include(p => p.Actors)
                    .Include(p => p.Directors)
                    .Include(p => p.Review)
                    .Include(p => p.UserRating)
                    .Where(p => p.Id == request.Id).Select(p => new GetMovieByIdDto
                    {
                        Title = p.Title,
                        Year = p.Year,
                        Genre = p.Genre.Name,
                        GenreId= p.GenreId,
                        UserRate =p.UserRatingId !=null ? p.UserRating.UserRate :null,
                        Review =p.ReviewId != null ? p.Review.ReviewsCount : null,
                        Actors = p.Actors.Select(c => c.Name).ToList(),
                        Directors = p.Directors.Select(p => p.Name).ToList(),
                    }).SingleOrDefaultAsync();

                return Movie != null ? new ResultDto<GetMovieByIdDto>(Movie, true, "Ok") : new ResultDto<GetMovieByIdDto>(null, false, "Error");
            }
            catch (Exception ex)
            {
                return new ResultDto<GetMovieByIdDto>(null, false, ex.Message);
            }
        }
    }
}
