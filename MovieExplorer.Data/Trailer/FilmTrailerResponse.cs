using System.Collections.Generic;
using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Trailer
{
    public class FilmTrailerResponse : CommunicationResponse
    {
        public FilmTrailerResponse()
        {
            Trailers = new List<FilmTrailerData>();
        }

        public List<FilmTrailerData> Trailers { get; set; }
    }
}