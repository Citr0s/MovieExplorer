using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MovieExplorer.Data.Film;
using MovieExplorer.Helpers;
using MovieExplorer.Services.Film;
using MovieExplorer.Services.Storage;
using MovieExplorer.ViewModels;

namespace MovieExplorer
{
    public sealed partial class HomePage
    {
        private readonly FilmService _filmService;
        private readonly StorageService _storageService;

        public HomePage()
        {
            InitializeComponent();
            _filmService = new FilmService(new FilmRepository(new HttpClient()));
            _storageService = new StorageService();

            FilmModel = new FilmModel();

            var savedFilms = _storageService.GetFromStorage();
            PreviousSearches.ItemsSource = savedFilms;

            var shouldDisplayPreviousSearches = savedFilms.Count == 0;
            ClearStorage.Visibility = shouldDisplayPreviousSearches ? Visibility.Collapsed : Visibility.Visible;
            PreviousSearchHeading.Visibility =
                shouldDisplayPreviousSearches ? Visibility.Collapsed : Visibility.Visible;
        }

        public FilmModel FilmModel { get; set; }

        private void FilmLayout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var filmModel = (FilmModel) e.ClickedItem;
            _storageService.AddToStorage(filmModel);
            ParentFrameHelper.Navigate(this, typeof(FilmDetails), filmModel.Identifier);
        }

        private async void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleProgressRing();
            var findFilmByTitleResponse = await _filmService.FindByTitle(Query.Text);

            if (findFilmByTitleResponse.HasError)
            {
                ToggleProgressRing();
                Feedback.Text = findFilmByTitleResponse.Error.UserMessage;
                Feedback.Visibility = Visibility.Visible;
                FilmResults.ItemsSource = new List<FilmModel>();
                return;
            }

            Feedback.Visibility = Visibility.Collapsed;
            FilmResults.ItemsSource = findFilmByTitleResponse.Films;

            ToggleProgressRing();
        }

        private void ToggleProgressRing()
        {
            ProgressRing.IsActive = !ProgressRing.IsActive;
            ProgressRing.Visibility = ProgressRing.IsActive ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ClearStorage_OnClick(object sender, RoutedEventArgs e)
        {
            _storageService.ClearStorage();
            PreviousSearches.ItemsSource = _storageService.GetFromStorage();
            PreviousSearchHeading.Visibility = Visibility.Collapsed;
            ClearStorage.Visibility = Visibility.Collapsed;
        }
    }
}