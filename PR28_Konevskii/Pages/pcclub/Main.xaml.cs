using PR28_Konevskii.Classes;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PR28_Konevskii.Pages.pcclub
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<pcclublContext> AllPcClubs = pcclublContext.Select();
        public Main()
        {
            InitializeComponent();
            foreach (pcclublContext items in AllPcClubs)
            {
                parent.Children.Add(new Items.pcclub.Item(items, this));
            }
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.pcclub.Add());
        }
    }
}
