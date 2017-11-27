using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MovieExplorer.Data.Film;
using MovieExplorer.Services.Film;
using MovieExplorer.ViewModels;

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

            ProgressRing.IsActive = true;
            ProgressRing.Visibility = Visibility.Collapsed;
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleProgressRing(true);
            var findFilmByTitleResponse = _filmService.FindByTitle(Query.Text);
            ToggleProgressRing(false);
            FilmResults.ItemsSource = findFilmByTitleResponse.Films;
        }

        private void FilmLayout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ToggleProgressRing(bool visible)
        {
            if (visible)
            {
                ProgressRing.Visibility = Visibility.Visible;
                FilmResults.ItemsSource = new List<FilmModel>();
            }
            else
            {
                ProgressRing.Visibility = Visibility.Collapsed;
            }
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
