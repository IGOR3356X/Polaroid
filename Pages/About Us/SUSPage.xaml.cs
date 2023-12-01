using Polaroid.ContentObjects;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.Categories;
using Polaroid.Pages.GlavPage;
using System.Windows;
using System.Windows.Controls;

namespace Polaroid.Pages.About_Us
{
    /// <summary>
    /// Логика взаимодействия для SUSPage.xaml
    /// </summary>
    public partial class SUSPage : Page
    {
        public SUSPage()
        {
            InitializeComponent();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
