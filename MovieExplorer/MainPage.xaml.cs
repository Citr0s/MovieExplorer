using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Film;
using MovieExplorer.ViewModels;
using Newtonsoft.Json;

namespace MovieExplorer
{
    public sealed partial class MainPage
    {
        public FilmModel FilmModel { get; set; }

        private readonly FilmService _filmService;

        public MainPage()
        {
            InitializeComponent();
            _filmService = new FilmService(new FilmRepository(new HttpClient()));

            FilmModel = new FilmModel();
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            var findFilmByTitleResponse = _filmService.FindByTitle(Query.Text);
            FilmResults.ItemsSource = findFilmByTitleResponse.Films;
        }

        private void FilmLayout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
