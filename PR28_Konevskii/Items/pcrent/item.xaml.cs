using PR28_Konevskii.Classes;
using PR28_Konevskii.Pages.pcrent;
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

namespace PR28_Konevskii.Items.pcrent
{
    /// <summary>
    /// Логика взаимодействия для item.xaml
    /// </summary>
    public partial class item : UserControl
    {
        public item()
        {
            InitializeComponent();
        }

        public item(pcrentContext items, Main main)
        {
        }
    }
}
