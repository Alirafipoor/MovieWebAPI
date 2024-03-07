using Application.Dto.ResultDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Movie.DeleteMovieFeature
{
    public class DeleteMovieRequest : IRequest<ResultDto>
    {
        public int Id { get; set; }
    }
}
