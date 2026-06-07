using System.Windows;
using System.Windows.Controls;

namespace PR28_Konevskii
{
    
    public partial class MainWindow : Window
    {
        public static MainWindow init;

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(new Pages.pcclub.Main());
        }

        public void OpenPage(Page page) =>
            frame.Navigate(page);

        private void OpenPcClubs(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.pcclub.Main());

        private void OpenPcRent(object sender, RoutedEventArgs e) =>
            OpenPage(new Pages.pcrent.Main());
    }
}
