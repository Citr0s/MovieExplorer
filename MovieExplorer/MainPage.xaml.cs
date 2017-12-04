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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }
    }
}
