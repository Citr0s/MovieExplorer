using MovieExplorer.Core.Communication;

namespace MovieExplorer.Data.Film
{
    public class FilmResponse : CommunicationResponse
    {
        public FilmData FilmData { get; set; }
    }
}