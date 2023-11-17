using Polaroid.ContentObjects;
using Polaroid.Pages.Admin_Main;
using Polaroid.Pages.RegisterFolder;
using Polaroid.Pages.GlavPage;
using Polaroid.Pages.AUZ;
using System;
using System.Collections.Generic;
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
using Polaroid.Pages.Categories;
using Polaroid.Pages.About_Us;

namespace Polaroid.Pages.AUZ
{
    /// <summary>
    /// Логика взаимодействия для AUZPage.xaml
    /// </summary>
    public partial class AUZPage : Page
    {
        public AUZPage()
        {
            InitializeComponent();
        }
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbLogin.Text != null && TxbLogin.Text != "")
                {
                    if (PassBox.Password != null)
                    {
                        var data = Connect.connect.Authorization.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == PassBox.Password);

                        if (data != null)
                        {
                            switch (data.Role.Name) 
                            {
                                case "Admin":
                                    Navigating.nav.Navigate(new AdmMain());
                                    break;

                                case "User":
                                    Navigating.nav.Navigate(new Glavnaya());
                                    break;
                            }

                            MessageBox.Show($"Вы успешно авторизовались как {data.Role.Name}");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка в логине или пароле", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка в обработке данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Register_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new RegisterPage());
        }
        private void Manin_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new Glavnaya());
        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new CategoriesPage());
        }

        private void Authorization_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Info_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.Navigate(new SUSPage());
        }
    }
}
