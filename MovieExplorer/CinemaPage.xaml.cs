using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MovieExplorer.Data.Cinema;
using MovieExplorer.Helpers;
using MovieExplorer.Services.Cinema;

namespace MovieExplorer
{
    public sealed partial class CinemaPage
    {
        private readonly CinemaService _cinemaService;

        public CinemaPage()
        {
            InitializeComponent();
            _cinemaService = new CinemaService(new CinemaRepository(new HttpClient()));
        }

        private async void Load(object sender, RoutedEventArgs routedEventArgs)
        {
            var nearbyCinemasResponse = await _cinemaService.GetNearbyCinemas();

            if (nearbyCinemasResponse.HasError)
            {
                Feedback.Text = nearbyCinemasResponse.Error.UserMessage;
                Feedback.Visibility = Visibility.Visible;
                NearbyCinemas.ItemsSource = new List<CinemaInfo>();
                return;
            }

            Feedback.Visibility = Visibility.Collapsed;
            NearbyCinemas.ItemsSource = nearbyCinemasResponse.Cinemas;
        }

        private void NearbyCinemas_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ParentFrameHelper.Navigate(this, typeof(CinemaDetails), (CinemaInfo) e.ClickedItem);
        }
    }
}