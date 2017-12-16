using Windows.UI.Xaml;

namespace MovieExplorer
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Navigate(typeof(HomePage));
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
            ToggleSplitViewPane();
            MainFrame.Navigate(typeof(HomePage));
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleSplitViewPane();
            MainFrame.Navigate(typeof(QuizPage));
        }
    }
}
