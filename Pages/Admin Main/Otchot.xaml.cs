using Polaroid.ContentObjects;
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
        private const string connectionString = "Data Source=DESKTOP-CCP78NP\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        public Otchot()
        {
            InitializeComponent();

        }
        
        private void Btn_CreateOtchot_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(this.TxbFirstDate.Text, out DateTime date1))
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Вы ввели некорректный формат даты в текстовом поле с 1-ой датой");
                return;
            }
            if (!DateTime.TryParse(this.TxbSecondDate.Text, out DateTime date2))
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Вы ввели некорректный формат даты в текстовом поле со 2-ой датой");
                return;
            }
            var TodayDate = DateTime.Today.ToString("yyy-MM-dd"); // Задаём переменной TodayDate сегодняшнюю дату
            string dateText1 = TxbSecondDate.Text;
            string dateText2 = TodayDate.ToString();
            string dateText3 = TxbFirstDate.Text;
            string FirstSale = ("2022-10-10");
            bool Chislo = DateTime.TryParse(dateText1, out DateTime BoolSecondDate);
            bool Chislo2 = DateTime.TryParse(dateText2, out DateTime BoolTodayDate);
            bool Chislo3 = DateTime.TryParse(FirstSale, out DateTime BoolFirstSale);
            bool Chislo4 = DateTime.TryParse(dateText3, out DateTime BoolFirstDate);
            if (Chislo && Chislo2 && Chislo3 && Chislo4)
            {
                if (BoolSecondDate > BoolTodayDate)
                {
                    MessageBox.Show("Мы не можем увидеть будущее");
                }
                else if (BoolFirstDate < BoolFirstSale)
                {
                    MessageBox.Show("Первая прадажа была 2022-10-10");
                }
                else
                {
                    try
                    {
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
                        MessageBox.Show("Успех!");
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так, тут надо обратиться к Ит специалисту");
                    }

                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
