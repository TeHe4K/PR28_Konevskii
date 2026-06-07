using PR28_Konevskii.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR28_Konevskii.Pages.pcclub
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        pcclublContext PcClub;
        public Add(pcclublContext pcClub = null)
        {
            InitializeComponent();

            if(PcClub != null)
            {
                this.PcClub = pcClub;
                name.Text = pcClub.name;
                adres.Text = pcClub.adress;
                timeStart.Text = pcClub.time_start.ToString("HH:mm");
                timeEnd.Text = pcClub.time_end.ToString("HH:mm");
                bthAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            DateTime TimeStart;
            DateTime TimeEnd;
            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if(adres.Text == "")
            {
                MessageBox.Show("Необходимо указать адрес");
                return;
            }
            if(timeStart.Text == "" || DateTime.TryParse(timeStart.Text, out TimeStart)){
                MessageBox.Show("Необходимо указать время начала работы");
                return;
            }
            if (timeEnd.Text == "" || DateTime.TryParse(timeEnd.Text, out TimeEnd )){
                MessageBox.Show("Необходимо указать время окончания работы");
                return;
            }

            if(PcClub == null)
            {
                pcclublContext newPcClub = new pcclublContext(
                    0,
                    name.Text,
                    adres.Text,
                    TimeStart,
                    TimeEnd
                    );
                newPcClub.Add();
                MessageBox.Show("Запись успешно добавлена");
                MainWindow.init.OpenPage(new Pages.pcclub.Main());
            }
            else
            {
                PcClub = new pcclublContext(
                    PcClub.id,
                    name.Text,
                    adres.Text,
                    TimeStart,
                    TimeEnd
                    );
                PcClub.Update();
                MessageBox.Show("Запись успешно обновлена");
                MainWindow.init.OpenPage(new Pages.pcclub.Main());
            }
        }
    }
}
