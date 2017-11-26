using System.Net.Http;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Film;

namespace MovieExplorer
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            var filmService = new FilmService(new FilmRepository(new HttpClient()));
            var findFilmByTitleResposne = filmService.FindByTitle("transformers");
        }
    }
}
