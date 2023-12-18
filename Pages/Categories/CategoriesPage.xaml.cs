using Polaroid.ContentObjects;
using Polaroid.Pages.About_Us;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.GlavPage;
using System;
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
            SldMinPrice.Minimum = 0;
            SldMinPrice.Maximum = 50000;
            SldMinPrice.ValueChanged += ProgressUpdate;
            SldMaxPrice.Minimum = 0;
            SldMaxPrice.Maximum = 50000;
            SldMaxPrice.ValueChanged += ProgressUpdate1;
            TxbMinPrice.Text = "0";
            TxbMaxPrice.Text = "50000";
        }
        private void Manin_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }

        private const string connectionString = "Data Source=DESKTOP-CCP78NP\\SQLEXPRESS;Initial Catalog=Polaroid;Integrated Security=True"; // Заменить на свою строку подключения
        private void Filter_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Decimal.TryParse(this.TxbMinPrice.Text, out Decimal Price1))
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Вы ввели некорректный формат даты в текстовом поле с 1-ой датой");
                return;
            }
            if (!Decimal.TryParse(this.TxbMaxPrice.Text, out Decimal Price2))
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Вы ввели некорректный формат даты в текстовом поле с 1-ой датой");
                return;
            }
            if ((Camera.IsChecked == true) && (Printers.IsChecked == false) && (ActionCameras.IsChecked == false) && (Photoacsessuars.IsChecked == false) && (Sunglasses.IsChecked == false))
            // Только камеры 
            {
                if ((Vse.IsChecked == true))
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and CategoryID = 1";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and CategoryID = 1";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and CategoryID = 1";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and CategoryID = 1";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
            else if ((Printers.IsChecked == true) && (Camera.IsChecked == false) && (ActionCameras.IsChecked == false) && (Photoacsessuars.IsChecked == false) && (Sunglasses.IsChecked == false)) 
            // Только принтеры
            {
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and CategoryID = 2";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and CategoryID = 2";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and CategoryID = 2";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все принтеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and CategoryID = 2";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
            else if ((ActionCameras.IsChecked == true) && (Camera.IsChecked == false) && (Printers.IsChecked == false) && (Photoacsessuars.IsChecked == false) && (Sunglasses.IsChecked == false))
            //Только Экшн-Камеры
            {
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and CategoryID = 3";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and CategoryID = 3";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and CategoryID = 3";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and CategoryID = 3";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
            else if ((Photoacsessuars.IsChecked == true) && (Camera.IsChecked == false) && (Printers.IsChecked == false) && (ActionCameras.IsChecked == false) && (Sunglasses.IsChecked == false)) 
            // Только Фотоаксессуары
            {
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and CategoryID = 4";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and CategoryID = 4";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and CategoryID = 4";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and CategoryID = 4";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
            else if ((Sunglasses.IsChecked == true) && (Camera.IsChecked == false) && (Printers.IsChecked == false) && (ActionCameras.IsChecked == false) && (Photoacsessuars.IsChecked == false)) 
            // Только солнцезащитные очки
            {
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and CategoryID = 5";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and CategoryID = 5";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and CategoryID = 5";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and CategoryID = 5";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
            else if ((Camera.IsChecked == true) & (Printers.IsChecked == true) && (ActionCameras.IsChecked == false) && (Photoacsessuars.IsChecked == false) && (Sunglasses.IsChecked == false))
            {
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё меньше 5000
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and (CategoryID = 1 or CategoryID = 2)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and (CategoryID = 1 or CategoryID = 2)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and (CategoryID = 1 or CategoryID = 2)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and (CategoryID = 1 or CategoryID = 2)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
            }
            else if ((Camera.IsChecked == true) & (Printers.IsChecked == true) & (ActionCameras.IsChecked == true) && (Photoacsessuars.IsChecked == false) && (Sunglasses.IsChecked == false))
            {
                //Камера, принтеры и экшн камеры
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё меньше 5000
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
            }
            else if ((Camera.IsChecked == true) & (Printers.IsChecked == true) & (ActionCameras.IsChecked == true) && (Photoacsessuars.IsChecked == true) && (Sunglasses.IsChecked == false))
            {
                //Камера, принтеры,экшн камеры и фотоаусессуары
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }


            }
            else if ((Camera.IsChecked == true) & (Printers.IsChecked == true) & (ActionCameras.IsChecked == true) & (Photoacsessuars.IsChecked == true) && (Sunglasses.IsChecked == true))
            {
                //Камера, принтеры,экшн камеры,фотоаусессуары и солнцезащитные очки
                if (Vse.IsChecked == true)
                    {
                        //Выводим всё по цене больше 5000 из всех магазов
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4 or CategoryID = 5)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (Moscow.IsChecked == true)
                    {
                        //Выводим все камеры по цене больше 5000 из Москвы
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 2 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4 or CategoryID = 5)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }
                    }
                else if (StPiter.IsChecked == true)
                    {
                        // Выводим все камеры больше 5000 из Ст.Питра
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 3 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4 or CategoryID = 5)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
                else if (Ekaterina.IsChecked == true)
                    {
                        //Выводим все камеры больше 5000 из Екатириенбурга
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = $"SElect IDItem,ItemName,Price ,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID where (Price between {Price1} and {Price2}) and ShopID = 4 and (CategoryID = 1 or CategoryID = 2 or CategoryID = 3 or CategoryID = 4 or CategoryID = 5)";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            ObservableCollection<object> data = new ObservableCollection<object>();
                            while (reader.Read())
                            {
                                data.Add(new
                                {
                                    ИД = reader["IDItem"],
                                    НазваниеТовара = reader["ItemName"],
                                    Цена = reader["Price"],
                                    Категория = reader["Name"],
                                    Адрес = reader["Adress"]
                                });
                            }
                            Viev.ItemsSource = data;

                            reader.Close();
                        }

                    }
            }
        }

        private void TxbTest_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Search = TxbTest_Search.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SElect IDItem,ItemName,Price,Category.Name,Shops.Adress from Items Join Category on Category.IDCategory=Items.CategoryID Join Shops on Shops.IDShop=Items.ShopID Where ItemName Like '%{Search}%'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                ObservableCollection<object> data = new ObservableCollection<object>();
                while (reader.Read())
                {
                    data.Add(new
                    {
                        ИД = reader["IDItem"],
                        НазваниеТовара = reader["ItemName"],
                        Цена = reader["Price"],
                        Категория = reader["Name"],
                        Адрес = reader["Adress"]
                    });
                }
                Viev.ItemsSource = data;

                reader.Close();
            }
        }

        private void ProgressUpdate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxbMinPrice.Text = "" + Math.Round(e.NewValue);
        }
        private void ProgressUpdate1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxbMaxPrice.Text = "" + Math.Round (e.NewValue);
        }
    }
}
