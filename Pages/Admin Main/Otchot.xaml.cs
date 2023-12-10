using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace Polaroid.Pages.Admin_Main
{
    /// <summary>
    /// Логика взаимодействия для Щесрще.xaml
    /// </summary>
    public partial class Otchot : Page
    {
        public Otchot()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=DESKTOP-CCP78NP\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        
        private void Btn_CreateOtchot_Click(object sender, RoutedEventArgs e)
        {
            DateTime date1 = DateTime.Parse(this.TxbFirstDate.Text);
            DateTime date2 = DateTime.Parse(this.TxbSecondDate.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT s.IDSale, i.ItemName, s.Date,i.Price\r\nFROM Sales s\r\nJOIN Items i ON s.ItemID = i.IDItem\r\nWHERE s.Date >= '{date1}' AND s.Date <= '{date2}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    ObservableCollection<object> data = new ObservableCollection<object>();
                    while (reader.Read())
                    {
                        data.Add(new
                        {
                            ИдПродажи = reader["IDSale"],
                            НазваниеТовара = reader["ItemName"],
                            Дата = reader["Date"],
                            Цена = reader["Price"],
                        });
                    }
                    DgNames.ItemsSource = data;

                    reader.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT s.Date, SUM(i.Price) AS TotalSales\r\nFROM Sales s\r\nJOIN Items i ON s.ItemID = i.IDItem\r\nWHERE s.Date >= '{date1}' AND s.Date <= '{date2}'\r\nGROUP BY s.Date";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    ObservableCollection<object> data = new ObservableCollection<object>();
                    while (reader.Read())
                    {
                        data.Add(new
                        {
                            Дата = reader["Date"],
                            ИтоговаяВыручка = reader["TotalSales"],
                        });
                    }
                    DgPrice.ItemsSource = data;

                    reader.Close();
                }
        }
    }
}
