using Google.Protobuf.WellKnownTypes;
using PR28_Konevskii.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace PR28_Konevskii.Pages.pcrent
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<pcclublContext> AllPcClubs = pcclublContext.Select();
        pcrentContext PcRent = null;
        public Add(pcrentContext pcrent = null)
        {
            InitializeComponent();
            foreach (var item in AllPcClubs)
                pcclubs.Items.Add(item);

            pcclubs.Items.Add("Выберите");

            if(pcrent != null)
            {
                this.PcRent = pcrent;
                pcclubs.SelectedIndex = AllPcClubs.FindIndex(x => x.id == pcrent.Id_PcClub);
                FIO.Text = pcrent.FioRent;
                date.SelectedDate = pcrent.DateRent.Date;
                time.Text = pcrent.DateRent.ToString("HH:mm");
                time_rent.Text = pcrent.TimeRent.ToString("HH:mm");
                bthAdd.Content = "Изменить";
            }
            else
            {
                pcclubs.SelectedIndex = pcclubs.Items.Count - 1;
            }
            
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime dateStart;
            TimeSpan timeStart;
            DateTime DateAndTimeStart;
            DateTime timeRent;
            if(FIO.Text == "")
            {
                MessageBox.Show("Необходимо указать ФИО клиента");
                return;
            }
            if(!(pcclubs.SelectedItem is pcclublContext selectedClubs))
            {
                MessageBox.Show("Выберите Пк клуб");
                return;
            }
            if (date.Text == "" || DateTime.TryParse(date.Text, out dateStart))
            {
                MessageBox.Show("Необходимо указать дату начала аренды");
                return;
            }
            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeStart))
            {
                MessageBox.Show("Необходимо указать время начала аренды");
                return;
            }
            if (time_rent.Text == "" || DateTime.TryParse(time_rent.Text, out timeRent))
            {
                MessageBox.Show("Необходимо указать продолжительность аренды");
                return;
            }
            DateAndTimeStart = date.SelectedDate.Value.Date + timeStart;
            if(PcRent == null)
            {
                pcrentContext newPcRent = new pcrentContext(
                    0,
                    selectedClubs.id,
                    FIO.Text,
                    DateAndTimeStart,
                    timeRent
                    );
                newPcRent.Add();
                MessageBox.Show("Запись успешно добавлена");
                MainWindow.init.OpenPage(new Pages.pcclub.Main());
            
        }
            else
            {
                PcRent = new pcrentContext(
                    PcRent.Id,
                    selectedClubs.id,
                    FIO.Text,
                    DateAndTimeStart,
                    timeRent
                    );
                PcRent.Update();
                MessageBox.Show("Запись успешно обновлена");
                MainWindow.init.OpenPage(new Pages.pcclub.Main());
            }

        }
    }
}
