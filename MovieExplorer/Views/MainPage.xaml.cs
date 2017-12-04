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

        private void FilmLayout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(FilmDetails), (FilmModel)e.ClickedItem);
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
