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
            FrmMain.Navigate(new AUZPage());
        }
    }
}
