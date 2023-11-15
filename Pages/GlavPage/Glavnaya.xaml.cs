using Polaroid.ContentObjects;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.Categories;
using Polaroid.Pages.RegisterFolder;
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

namespace Polaroid.Pages.GlavPage
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        public Glavnaya()
        {
            InitializeComponent();
        }

        private void Authorization_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new AUZPage());
        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new CategoriesPage());
        }
    }
}
