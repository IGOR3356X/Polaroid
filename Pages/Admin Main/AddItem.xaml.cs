using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }
        private void LoadDataFromDatabase()
        {
            string connectionString = "Data Source=DESKTOP-CCP78NP\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Замените на ваше строку подключения
            string query = "SELECT DISTINCT ItemName FROM Items";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int index = 0;
                        while (reader.Read())
                        {
                            string itemName = reader.GetString(0);
                            Label label = FindName("label" + (index + 1)) as Label;
                            if (label != null)
                            {
                                label.Content = itemName;
                                index++;
                            }
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
