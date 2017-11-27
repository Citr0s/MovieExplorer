using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Film
{
    public class FilmDetailsResponse : CommunicationResponse
    {
        public FilmDetail FilmDetails { get; set; }
    }
}