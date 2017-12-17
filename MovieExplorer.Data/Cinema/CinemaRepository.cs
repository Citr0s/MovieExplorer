using System;
using System.Net.Http;
using System.Threading.Tasks;
using MovieExplorer.Core.Communication;
using Newtonsoft.Json;

namespace MovieExplorer.Data.Cinema
{
    public class CinemaRepository
    {
        private readonly HttpClient _httpClient;
        private string API_URI = "https://api.cinelist.co.uk/";

        public CinemaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CinemaResponse> GetNearbyCinemas(double latitude, double longitude)
        {
            var response = new CinemaResponse();

            try
            {
                var findByTitleResponse = await _httpClient.GetAsync($"{API_URI}search/cinemas/coordinates/{latitude}/{longitude}").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.Cinemas = await Task.Run(() => JsonConvert.DeserializeObject<CinemaData>(content));

                if (response.Cinemas.Cinemas == null)
                    throw new Exception("No cinemas found!");
            }
            catch (Exception exception)
            {
                response.AddError(new Error
                {
                    Code = ErrorCodes.CouldNotGetData,
                    UserMessage = "Something went wrong while trying to find nearby cinemas. Please try again later.",
                    TechnicalMessage = $"The following exception was thrown {exception.Message}"
                });
            }

            return response;
        }
        
        public async Task<CinemaShowingsResponse> GetShowingsByCinema(string identifier)
        {
            var response = new CinemaShowingsResponse();

            try
            {
                var findByTitleResponse = await _httpClient.GetAsync($"{API_URI}get/times/cinema/{identifier}").ConfigureAwait(false);
                var content = await findByTitleResponse.Content.ReadAsStringAsync();
                response.CinemaListing = await Task.Run(() => JsonConvert.DeserializeObject<CinemaListing>(content));
            }
            catch (Exception exception)
            {
                response.AddError(new Error
                {
                    Code = ErrorCodes.CouldNotGetData,
                    UserMessage = "Something went wrong while trying to find nearby cinemas. Please try again later.",
                    TechnicalMessage = $"The following exception was thrown {exception.Message}"
                });
            }

            return response;
        }
    }
}