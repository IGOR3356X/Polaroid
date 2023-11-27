using Polaroid.ContentObjects;
using Polaroid.Pages.About_Us;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.Categories;
using Polaroid.Pages.GlavPage;
using System.Windows;

namespace Polaroid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Navigating.nav = FrmMain;
            FrmMain.Navigate(new Glavnaya());
        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new CategoriesPage());
        }

        private void Authorization_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new AUZPage());
        }

        private void Info_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new SUSPage());
        }

        private void Manin_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new Glavnaya());
        }
    }
}
