using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.Data.Cinema;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Cinema;
using MovieExplorer.Services.Film;

namespace MovieExplorer
{
    public sealed partial class CinemaDetails
    {
        private readonly CinemaService _cinemaService;
        private FilmService _filmService;

        public CinemaDetails()
        {
            InitializeComponent();
            _cinemaService = new CinemaService(new CinemaRepository(new HttpClient()));
            _filmService = new FilmService(new FilmRepository(new HttpClient()));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadCinemaShowings((CinemaInfo)e.Parameter);
        }

        private async void LoadCinemaShowings(CinemaInfo cinema)
        {
            CinamaName.Text = cinema.Name;

            var cinemaShowingsResponse = await _cinemaService.GetTimesByCinema(cinema.Identifier);

            foreach (var listing in cinemaShowingsResponse.Listings)
            {
                var film = await _filmService.FindByTitle(listing.Title);
                listing.Thumbnail = film.Films.FirstOrDefault()?.Poster;
            }

            CinemaListings.ItemsSource = cinemaShowingsResponse.Listings;
        }
    }
}
