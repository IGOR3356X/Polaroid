using Polaroid.ContentObjects;
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

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
