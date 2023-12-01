using Polaroid.ContentObjects;
using Polaroid.Pages.AUZ;
using System.Windows;
using System.Windows.Controls;

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
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new AUZPage());
        }
    }
}
