using Polaroid.ContentObjects;
using Polaroid.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Polaroid.Pages.Admin_Main
{
    /// <summary>
    /// Логика взаимодействия для ItemControl.xaml
    /// </summary>
    public partial class ItemControl : Page
    {
        public ItemControl()
        {
            InitializeComponent();
            LoadDataItems();
        }


        private void AddItem_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new AddItem());
        }


        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
        private void LoadDataItems()
        {
            DgProducts.ItemsSource = Connect.connect.Items.ToList();
        }
        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var Item = (sender as Button).DataContext as Items;

            Connect.connect.Items.Remove(Item);
            Connect.connect.SaveChanges();

            MessageBox.Show("Запись удалена");

            LoadDataItems();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            DgProducts.ItemsSource=Connect.connect.Items.ToList();
            Connect.connect.SaveChanges();
            LoadDataItems();
        }
    }
}
