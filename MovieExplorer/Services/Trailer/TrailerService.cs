using System.Linq;
using System.Threading.Tasks;
using MovieExplorer.Data.Trailer;

namespace MovieExplorer.Services.Trailer
{
    internal class TrailerService
    {
        private readonly TrailerRepository _trailerRepository;

        public TrailerService(TrailerRepository trailerRepository)
        {
            _trailerRepository = trailerRepository;
        }

        public async Task<TrailerResponse> FindTrailerFor(string title, string year)
        {
            var response = new TrailerResponse();

            var trailerLookupResponse = await _trailerRepository.FindByTitle(title, year);

            if (trailerLookupResponse.Trailers.Count > 0 && trailerLookupResponse.Trailers.First().Trailer.Count > 0)
                response.Trailer = trailerLookupResponse.Trailers.First().Trailer.First().VideoUrl;

            return response;
        }
    }
}