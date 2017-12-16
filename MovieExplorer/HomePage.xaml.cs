using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MovieExplorer.Data.Film;
using MovieExplorer.Helpers;
using MovieExplorer.Services.Film;
using MovieExplorer.ViewModels;

namespace MovieExplorer
{
    public sealed partial class HomePage
    {
        public FilmModel FilmModel { get; set; }

        private readonly FilmService _filmService;

        public HomePage()
        {
            InitializeComponent();
            _filmService = new FilmService(new FilmRepository(new HttpClient()));

            FilmModel = new FilmModel();
        }

        private void FilmLayout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ParentFrameHelper.Navigate(this, typeof(FilmDetails), (FilmModel)e.ClickedItem);
        }

        private async void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleProgressRing();
            var findFilmByTitleResponse = await _filmService.FindByTitle(Query.Text);
            FilmResults.ItemsSource = findFilmByTitleResponse.Films;
            ToggleProgressRing();
        }

        private void ToggleProgressRing()
        {
            ProgressRing.IsActive = !ProgressRing.IsActive;
            ProgressRing.Visibility = ProgressRing.IsActive ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}