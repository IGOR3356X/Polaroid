using Polaroid.ContentObjects;
using Polaroid.Pages.About_Us;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.Categories;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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
            LoadDataFromDatabase();
            LoadPriseFromDatabase();
        }

        private void Authorization_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new AUZPage());
        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new CategoriesPage());
        }

        private void Info_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new SUSPage());
        }

        private const string connectionString = "Data Source=V-MGOK-201-27N\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        private void LoadDataFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ItemName FROM Items";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string itemName = reader.GetString(0);

                        TextBlock textBlock = FindName("texblock" + (index + 1)) as TextBlock; // Получение соответствующего textblock-элемента по имени
                        if (textBlock != null)
                        {
                            textBlock.Text = itemName; // Заполнение содержимого textblock-элемента
                            index++;
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadPriseFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Price FROM Items";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        decimal Prise = reader.GetDecimal(0);

                        TextBlock textBlock = FindName("textobloko" + (index + 1)) as TextBlock; // Получение соответствующего textblock-элемента по имени
                        if (textBlock != null)
                        {
                            textBlock.Text = Prise.ToString() + '₽'; // Заполнение содержимого textblock-элемента
                            index++;
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
