using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieExplorer.Core.Communication;
using Newtonsoft.Json;

namespace MovieExplorer.Data.Trailer
{
    public class TrailerRepository
    {
        private const string API_URI = "http://www.theimdbapi.org/api/find/movie";
        private readonly HttpClient _httpClient;

        public TrailerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FilmTrailerResponse> FindByTitle(string title, string year)
        {
            var response = new FilmTrailerResponse();

            try
            {
                var findByTitleResponse =
                    await _httpClient.GetAsync($"{API_URI}?title={title}&year={year}").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.Trailers = await Task.Run(() => JsonConvert.DeserializeObject<List<FilmTrailerData>>(content));
            }
            catch (Exception exception)
            {
                response.AddError(new Error
                {
                    Code = ErrorCodes.CouldNotGetData,
                    UserMessage = "Something went wrong while trying to find the film trailer. Please try again later.",
                    TechnicalMessage = $"The following exception was thrown {exception.Message}"
                });
            }

            return response;
        }
    }
}