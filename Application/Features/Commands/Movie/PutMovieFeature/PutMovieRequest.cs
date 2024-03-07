using Application.Dto.Movie;
using Application.Dto.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Movie.PutMovieFeature
{
    public class PutMovieRequest : IRequest<ResultDto<int>>
    {
        public PutMovieDto PutMovieDto { get; set; }
    }
}
