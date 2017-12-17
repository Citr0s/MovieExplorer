using System.Threading.Tasks;
using MovieExplorer.Data.Cinema;
using MovieExplorer.Helpers;

namespace MovieExplorer.Services.Cinema
{
    public class CinemaService
    {
        private readonly CinemaRepository _cinemaRepository;

        public CinemaService(CinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<GetNearbyCinemasResponse> GetNearbyCinemas()
        {
            var response = new GetNearbyCinemasResponse();

            var position = await LocationHelper.GetPosition();
            var nearbyCinemasResponse = await _cinemaRepository.GetNearbyCinemas(position.Coordinate.Latitude, position.Coordinate.Longitude);

            if (nearbyCinemasResponse.HasError)
            {
                response.AddError(nearbyCinemasResponse.Error);
                return response;
            }

            response.Cinemas = CinemaMapper.Map(nearbyCinemasResponse.Cinemas);
            return response;
        }

        public async Task<GetShowingsResponse> GetTimesByCinema(string identifier)
        {
            var response = new GetShowingsResponse();

            var nearbyCinemasResponse = await _cinemaRepository.GetShowingsByCinema(identifier);

            if (nearbyCinemasResponse.HasError)
            {
                response.AddError(nearbyCinemasResponse.Error);
                return response;
            }

            response.Listings = CinemaMapper.MapListings(nearbyCinemasResponse.CinemaListing.Listings);
            return response;
        }
    }
}