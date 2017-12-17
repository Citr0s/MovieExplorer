using System.Net.Http;
using Windows.UI.Xaml.Navigation;
using MovieExplorer.Data.Cinema;
using MovieExplorer.Services.Cinema;

namespace MovieExplorer
{
    public sealed partial class CinemaDetails
    {
        private readonly CinemaService _cinemaService;

        public CinemaDetails()
        {
            InitializeComponent();
            _cinemaService = new CinemaService(new CinemaRepository(new HttpClient()));
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
            CinemaListings.ItemsSource = cinemaShowingsResponse.Listings;
        }
    }
}
