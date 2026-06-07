using PR28_Konevskii.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

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

            if (pcrent != null)
            {
                this.PcRent = pcrent;
                int selectedIndex = AllPcClubs.FindIndex(x => x.id == pcrent.Id_PcClub);
                pcclubs.SelectedIndex = selectedIndex >= 0 ? selectedIndex : pcclubs.Items.Count - 1;
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

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            TimeSpan timeStart;
            TimeSpan rentDuration;

            if (string.IsNullOrWhiteSpace(FIO.Text))
            {
                MessageBox.Show("Необходимо указать ФИО клиента");
                return;
            }
            if (!(pcclubs.SelectedItem is pcclublContext selectedClubs))
            {
                MessageBox.Show("Выберите Пк клуб");
                return;
            }
            if (date.SelectedDate == null)
            {
                MessageBox.Show("Необходимо указать дату начала аренды");
                return;
            }
            if (string.IsNullOrWhiteSpace(time.Text) || !TimeSpan.TryParse(time.Text, out timeStart))
            {
                MessageBox.Show("Необходимо указать время начала аренды");
                return;
            }
            if (!TryParseDuration(time_rent.Text, out rentDuration))
            {
                MessageBox.Show("Необходимо указать продолжительность аренды");
                return;
            }

            DateTime DateAndTimeStart = date.SelectedDate.Value.Date + timeStart;
            DateTime timeRent = DateTime.Today.Add(rentDuration);

            if (PcRent == null)
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
                MainWindow.init.OpenPage(new Pages.pcrent.Main());
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
                MainWindow.init.OpenPage(new Pages.pcrent.Main());
            }
        }

        private static bool TryParseDuration(string text, out TimeSpan duration)
        {
            duration = TimeSpan.Zero;

            if (string.IsNullOrWhiteSpace(text))
                return false;

            string value = text.Trim();

            if (value.Contains(":"))
                return TimeSpan.TryParse(value, out duration)
                    && duration > TimeSpan.Zero
                    && duration < TimeSpan.FromDays(1);

            if (!double.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out double hours)
                && !double.TryParse(value.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out hours))
            {
                return false;
            }

            if (hours <= 0 || hours >= 24)
                return false;

            duration = TimeSpan.FromHours(hours);
            return true;
        }
    }
}
