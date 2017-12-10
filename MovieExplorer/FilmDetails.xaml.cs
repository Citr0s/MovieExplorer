using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.Data.Film;
using MovieExplorer.Data.Trailer;
using MovieExplorer.Services.Film;
using MovieExplorer.Services.Trailer;
using MovieExplorer.ViewModels;

namespace MovieExplorer
{
    public sealed partial class FilmDetails
    {
        private readonly FilmService _filmService;
        private readonly TrailerService _trailerService;

        public FilmDetails()
        {
            InitializeComponent();

            _filmService = new FilmService(new FilmRepository(new HttpClient()));
            _trailerService = new TrailerService(new TrailerRepository(new HttpClient()));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadFilmDetails((FilmModel)e.Parameter);
        }

        private async void LoadFilmDetails(FilmModel film)
        {
            var filmDetailsResponse = await _filmService.FindDetails(film.Identifier);
            var filmDetails = filmDetailsResponse.FilmDetails;

            PosterBackground.Source = new BitmapImage(new Uri(filmDetails.Poster));
            Poster.Source = new BitmapImage(new Uri(filmDetails.Poster));
            Title.Text = filmDetails.Title;
            Rating.Text = filmDetails.Ratings;
            Genre.Text = filmDetails.Genre;
            Released.Text = filmDetails.Released;

            ToggleProgressRing();

            var filmTrailer = await _trailerService.FindTrailerFor(filmDetails.Title, filmDetails.Year);

            if (filmTrailer.Trailer != null)
            {
                Trailer.Source = new Uri(filmTrailer.Trailer);
                Trailer.Visibility = Visibility;
            }
            else
            {
                NoTrailer.Visibility = Visibility.Visible;
            }

            ToggleProgressRing();
        }

        private void ToggleProgressRing()
        {
            TrailerSearchRing.IsActive = !TrailerSearchRing.IsActive;
            TrailerSearchRing.Visibility = TrailerSearchRing.IsActive ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
