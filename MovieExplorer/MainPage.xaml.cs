using System.Net.Http;
using Windows.UI.Xaml;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Film;
using Newtonsoft.Json;

namespace MovieExplorer
{
    public sealed partial class MainPage
    {
        private readonly FilmService _filmService;

        public MainPage()
        {
            InitializeComponent();
            _filmService = new FilmService(new FilmRepository(new HttpClient()));
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            var findFilmByTitleResponse = _filmService.FindByTitle(Query.Text);
            MovieData.Text = JsonConvert.SerializeObject(findFilmByTitleResponse.Films);
        }
    }
}
