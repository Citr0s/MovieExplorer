using System;
using System.Net.Http;
using Windows.UI.Xaml.Media.Imaging;
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
        }
    }
}
