using Polaroid.ContentObjects;
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
    }
}
