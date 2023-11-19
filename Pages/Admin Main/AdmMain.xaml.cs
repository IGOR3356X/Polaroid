using Polaroid.ContentObjects;
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

namespace Polaroid.Pages.Admin_Main
{
    /// <summary>
    /// Логика взаимодействия для AdmMain.xaml
    /// </summary>
    public partial class AdmMain : Page
    {
        public AdmMain()
        {
            InitializeComponent();
        }

        private void Item_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new ItemControl());
        }

        private void User_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new UserControl());
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
