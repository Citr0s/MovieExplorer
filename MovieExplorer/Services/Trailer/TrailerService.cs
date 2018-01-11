using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieExplorer.Data.Trailer;

namespace MovieExplorer.Services.Trailer
{
    internal class TrailerService
    {
        private readonly TrailerRepository _trailerRepository;
        private Random _random;

        public TrailerService(TrailerRepository trailerRepository)
        {
            _trailerRepository = trailerRepository;
            _random = new Random();
        }

        public async Task<TrailerResponse> FindTrailerFor(string title, string year)
        {
            var response = new TrailerResponse();

            /*
            var trailerLookupResponse = await _trailerRepository.FindByTitle(title, year);

            if (trailerLookupResponse.Trailers.Count > 0 && trailerLookupResponse.Trailers.First().Trailer.Count > 0)
                response.Trailer = trailerLookupResponse.Trailers.First().Trailer.First().VideoUrl;
            */

            var trailers = new List<string>
            {
                "http://trailers.apple.com/movies/marvel/black-panther/black-panther-trailer-1_h480p.mov",
                "http://trailers.apple.com/movies/universal/jurassic-world-fallen-kingdom/jurassic-world-fallen-kingdom-trailer-1_h480p.mov",
                "http://trailers.apple.com/movies/lucasfilm/star-wars-the-last-jedi/star-wars-the-last-jedi-trailer-1_h480p.mov",
                "http://trailers.apple.com/movies/fox/maze-runner-the-death-cure/maze-runner-the-death-cure-trailer-2_h480p.mov",
                "http://trailers.apple.com/movies/marvel/thor-ragnarok/thor-ragnarok-trailer-1_h480p.mov"
            };

            response.Trailer = trailers[_random.Next(0, 4)];
            return response;
        }
    }
}