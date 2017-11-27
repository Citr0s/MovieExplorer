using System;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Animations;
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
            await PosterBackground.Blur(duration: 10, delay: 0, value: 3).StartAsync();

            Poster.Source = new BitmapImage(new Uri(filmDetails.Poster));
            Title.Text = filmDetails.Title;
            Rating.Text = filmDetails.Ratings;
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
