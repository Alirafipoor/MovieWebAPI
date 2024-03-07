using Application.Dto.ResultDto;
using Application.Features.Queries.Movie.CallMovieApiFeature;
using MediatR;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Infrastructure.Handler.Movie.Queries
{
    public class GetAllMovieApiHandler : IRequestHandler<CallMovieApiRequest, ResultDto<JToken>>
    {
        private readonly IHttpClientFactory clientFactory;

        public GetAllMovieApiHandler(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<ResultDto<JToken>> Handle(CallMovieApiRequest request, CancellationToken cancellationToken)
        {

            try
            {
                using var client = clientFactory.CreateClient();

                HttpResponseMessage response = await client.GetAsync($"https://www.omdbapi.com/?apikey=b572bf8c&t=" + request.Title);

                string resposneContent = await response.Content.ReadAsStringAsync();

                JToken jToken = JToken.Parse(resposneContent);

                return await Task.FromResult(new ResultDto<JToken>(jToken, true, "Ok"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultDto<JToken>("", false, ex.Message));
            }
        }
    }
}
