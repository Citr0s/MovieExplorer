using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Film;
using MovieExplorer.ViewModels;

namespace MovieExplorer
{
    public sealed partial class FilmDetails
    {
        private readonly FilmService _filmService;

        public FilmDetails()
        {
            InitializeComponent();

            _filmService = new FilmService(new FilmRepository(new HttpClient()));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadFilmDetails((FilmModel)e.Parameter);
        }

        private void LoadFilmDetails(FilmModel film)
        {
            _filmService.FindDetails(film.ImdbIdentifier);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
