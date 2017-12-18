using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MovieExplorer
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(HomePage));

            SystemNavigationManager.GetForCurrentView().BackRequested += (s, x) =>
            {
                if (MainFrame.CanGoBack)
                {
                    x.Handled = true;
                    MainFrame.GoBack();
                }
            };
        }

        private void ToggleSplitViewPane()
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleSplitViewPane();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SplitView.IsPaneOpen)
                ToggleSplitViewPane();

            MainFrame.Navigate(typeof(HomePage));
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (SplitView.IsPaneOpen)
                ToggleSplitViewPane();

            MainFrame.Navigate(typeof(QuizPage));
        }

        private void CinemaButton_Click(object sender, RoutedEventArgs e)
        {
            if (SplitView.IsPaneOpen)
                ToggleSplitViewPane();

            MainFrame.Navigate(typeof(CinemaPage));
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = ((Frame) sender).CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }
    }
}