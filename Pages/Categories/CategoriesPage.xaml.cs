using Polaroid.ContentObjects;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Polaroid.Pages.Categories
{
    /// <summary>
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }

        private const string connectionString = "Data Source=V-MGOK-201-27N\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        private void Filter_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Camera.IsChecked ?? false)
            {
                if (Bolshe5000.IsChecked ?? false)
                {
                    if (Vse.IsChecked ?? false)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                    }
                    else
                    {
                        //Выводим всё больше 5000
                    }
                }
                else if (Menshe5000.IsChecked ?? false)
                {
                    if (Vse.IsChecked ?? false)
                    {
                        //Выводим всё
                    }
                    else
                    {
                        //Выодим всё меньше 5000 из всех магазов
                    }

                }
                else
                {
                    //Выводим только по камере
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SElect IDItem,ItemName,Price,Discription,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    ObservableCollection<object> data = new ObservableCollection<object>();
                    while (reader.Read())
                    {
                        data.Add(new
                        {
                            IDItem = reader["IDItem"],
                            ItemName = reader["ItemName"],
                            Price = reader["Price"],
                            Discription = reader["Discription"],
                            Name = reader["Name"],
                            Adress = reader["Adress"]
                        });
                    }
                    Viev.ItemsSource = data;

                    reader.Close();
                }
            }
        }
    }
}
