using PR28_Konevskii.Classes;
using PR28_Konevskii.Pages.pcclub;
using System.Windows.Controls;

namespace PR28_Konevskii.Items.pcclub
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        pcclublContext PcClub;
        Main main;
        public Item(pcclublContext PcClub , Main main)
        {
            InitializeComponent();
            name.Text = PcClub.name;
            adres.Text = PcClub.adress;
            timeStart.Text = PcClub.time_start.ToString("HH:mm");
            timeEnd.Text = PcClub.time_end.ToString("HH:mm");
            this.PcClub = PcClub;
            this.main = main;
        }

        private void EditRecord(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.pcclub.Add(PcClub));

        private void DeleteRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            PcClub.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
