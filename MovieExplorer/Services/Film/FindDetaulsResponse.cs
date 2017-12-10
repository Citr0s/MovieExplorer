using MovieExplorer.Core.Communication;
using MovieExplorer.Data.Trailer;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FindDetaulsResponse : CommunicationResponse
    {
        public FilmModel FilmDetails { get; set; }
        public TrailerInfo Trailer { get; set; }
    }
}