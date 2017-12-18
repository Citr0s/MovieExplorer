using System;
using System.Net.Http;
using System.Threading.Tasks;
using MovieExplorer.Core.Communication;
using Newtonsoft.Json;

namespace MovieExplorer.Data.Film
{
    public class FilmRepository
    {
        private const string API_URI = "http://www.omdbapi.com/?apikey=cf36ab40";
        private readonly HttpClient _httpClient;

        public FilmRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FilmResponse> FindByTitle(string title)
        {
            var response = new FilmResponse();

            try
            {
                var findByTitleResponse = await _httpClient.GetAsync($"{API_URI}&s={title}").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.FilmData = await Task.Run(() => JsonConvert.DeserializeObject<FilmData>(content));
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

        public async Task<FilmDetailsResponse> FindDetails(string imdbIdentifier)
        {
            var response = new FilmDetailsResponse();

            try
            {
                var findByTitleResponse =
                    await _httpClient.GetAsync($"{API_URI}&i={imdbIdentifier}").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.FilmDetails = await Task.Run(() => JsonConvert.DeserializeObject<FilmDetail>(content));
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