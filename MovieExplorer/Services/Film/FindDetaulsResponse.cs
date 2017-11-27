using MovieExplorer.Core.Communication;
using MovieExplorer.ViewModels;

namespace MovieExplorer.Services.Film
{
    public class FindDetaulsResponse : CommunicationResponse
    {
        public FilmModel FilmDetails { get; set; }
    }
}