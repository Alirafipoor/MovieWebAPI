using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Movie.GetMovieByIdFeature
{
    public class GetMovieByIdRequest : IRequest<ResultDto<GetMovieByIdDto>>
    {
        public int Id { get; set; }
    }
}
