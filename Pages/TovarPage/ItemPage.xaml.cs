using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

namespace Polaroid.Pages.TovarPage
{
    /// <summary>
    /// Логика взаимодействия для ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Page
    {
        public ItemPage()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            LoadPriseFromDatabase();
            LoadDiscriptionFromDatabase();

        }
        private const string connectionString = "Data Source=DESKTOP-CCP78NP\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        
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
                        string ItemName = reader.GetString(0);

                        // Получение соответствующего textblock-элемента по имени
                        if (FindName("TxbName" + (index + 1)) is TextBlock textBlock)
                        {
                            textBlock.Text = ItemName; // Заполнение содержимого textblock-элемента
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

                    string query = "SELECT Discription FROM Items";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string ItemName = reader.GetString(0);

                        // Получение соответствующего textblock-элемента по имени
                        if (FindName("TxbDiscription" + (index + 1)) is TextBlock textBlock)
                        {
                            textBlock.Text = ItemName; // Заполнение содержимого textblock-элемента
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

        private void LoadDiscriptionFromDatabase()
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

                        // Получение соответствующего textblock-элемента по имени
                        if (FindName("TxbPrice" + (index + 1)) is TextBlock textBlock)
                        {
                            textBlock.Text = "Цена " + Prise.ToString() + '₽'; // Заполнение содержимого textblock-элемента
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
        private void Btn_Buy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
