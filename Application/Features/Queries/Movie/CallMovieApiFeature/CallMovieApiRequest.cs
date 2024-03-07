using Application.Dto.ResultDto;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Movie.CallMovieApiFeature
{
    public class CallMovieApiRequest : IRequest<ResultDto<JToken>>
    {
        public string Title { get; set; }

    }
}
