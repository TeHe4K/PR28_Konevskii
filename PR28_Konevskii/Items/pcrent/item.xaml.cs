using PR28_Konevskii.Classes;
using PR28_Konevskii.Pages.pcrent;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PR28_Konevskii.Items.pcrent
{
    
    public partial class item : UserControl
    {
        List<pcclublContext> AllClubs = pcclublContext.Select();
        pcrentContext items;
        Main main;
        public item(pcrentContext items, Main main)
        {
            InitializeComponent();
            this.items = items;
            this.main = main;
            var PcClub = AllClubs.Find(x => x.id == items.Id_PcClub);
            PcClubs.Items.Add(PcClub == null ? "" : PcClub.name);
            PcClubs.SelectedIndex = 0;
            FIO.Text = items.FioRent;
            date.Text = items.DateRent.ToString("yyyy-MM-dd");
            time.Text = items.DateRent.ToString("HH:mm");
            Rent_Time.Text = items.TimeRent.ToString("HH:mm");
        }

        private void EditRecord(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.pcrent.Add());

        private void DeleteRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            items.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
