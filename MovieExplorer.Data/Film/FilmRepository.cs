using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieExplorer.Core.Communication;
using Newtonsoft.Json;

namespace MovieExplorer.Data.Film
{
    public class FilmRepository
    {
        private readonly HttpClient _httpClient;
        private const string API_URI = "http://www.theimdbapi.org/api/find/movie";

        public FilmRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FilmResponse> FindByTitle(string title)
        {
            var response = new FilmResponse();

            try
            {
                var findByTitleResponse = await _httpClient.GetAsync($"{API_URI}?title={title}&year=2007").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.FilmData =  await Task.Run(() => JsonConvert.DeserializeObject<List<FilmData>>(content));
            }
            catch (Exception exception)
            {
                response.AddError(new Error
                {
                    Code = ErrorCodes.CouldNotGetData,
                    UserMessage = "Something went wrong while trying to find the film. Please try again later.",
                    TechnicalMessage = $"The following exception was thrown {exception.Message}"
                });
            }

            return response;
        }
    }
}
