using Polaroid.ContentObjects;
using Polaroid.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

namespace Polaroid.Pages.RegisterFolder
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private string _Login;
        private string _Password;
        private int _RoleID;
        private string _First_Name;
        private string _Last_Name;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Manin_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Authorization_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Info_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Register_Btn_Click(object sender, RoutedEventArgs e)
        {
            _Login = TxbLogin.Text;
            _Password = TxbPassword.Text;
            _First_Name = TxbName.Text;
            _Last_Name = TxbSurname.Text;
            if (int.TryParse(TxbRole.Text, out _RoleID))
            {
                // Валидное целое число получено успешно
                // Используйте переменную roleId для нужных действий
            }
            else
            {
                MessageBox.Show("Введите корректное значение для RoleID");
            }

            if (_First_Name != null && _First_Name != "")
            {
                if (_Last_Name != null && _Last_Name != "" && _First_Name != "")
                {
                    if (_Login != null && _Login != "" && _Last_Name != "" && _First_Name != "")
                    {
                        if (_Password != null && _Password != "" && _Login != "" && _Last_Name != "" && _First_Name != "")
                        {
                            if (_RoleID != 0 && _Password != "" && _Login != "" && _Last_Name != "" && _First_Name != "")
                            {
                                var register = new SignIn()
                                {
                                    Login = _Login,
                                    Password = _Password,
                                    RoleID=_RoleID,
                                    First_Name = _First_Name,
                                    Last_Name = _Last_Name,
                                };
                                Connect.connect.SignIn.Add(register);
                                Connect.connect.SaveChanges();
                                MessageBox.Show("Вы успешно зарегестрировались", "Увеомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите логин");
                    }

                }
                else
                {
                    MessageBox.Show("Введите Фамилию");
                }
            }
            else
            {
                MessageBox.Show("Введите имя");
            }
        }
    }
}
