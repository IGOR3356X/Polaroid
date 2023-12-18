using Polaroid.ContentObjects;
using Polaroid.DataBase;
using Polaroid.Pages.About_Us;
using Polaroid.Pages.AUZ;
using Polaroid.Pages.Categories;
using Polaroid.Pages.GlavPage;
using System.Windows;
using System.Windows.Controls;

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
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void Register_Btn_Click(object sender, RoutedEventArgs e)
        {
            _Login = TxbLogin.Text;
            _Password = TxbPassword.Text;
            if (int.TryParse(TxbRole.Text, out _RoleID))
            {
                // Валидное целое число получено успешно
                // Используйте переменную roleId для нужных действий
            }
            else
            {
                MessageBox.Show("Введите корректное значение для RoleID");
            }
            if (_Login != null && _Login != "")
            {
                if (_Password != null && _Password != "" && _Login != "")
                {
                    if (_RoleID != 0 && _Password != "" && _Login != "")
                    {
                        var register = new SignIn()
                        {
                            Login = _Login,
                            Password = _Password,
                            RoleID = _RoleID,
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
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
