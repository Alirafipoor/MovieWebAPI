using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Movie.GetRecommandFeature
{
    public class GetRecommandRequest:IRequest<ResultDto<List<GetAllMovieDto>>>
    {
        public int UserId { get; set; }
    }
}
