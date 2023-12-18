using Polaroid.ContentObjects;
using Polaroid.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static Polaroid.Pages.Admin_Main.AddItem;

namespace Polaroid.Pages.Admin_Main
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>

    public partial class UserControl : Page
    {
        string Chislo = "";
        private string _Login;
        private string _Password;
        private int _RoleID;
        public UserControl()
        {
            InitializeComponent();
            LoadFromData();
            CmbRole.ItemsSource = new RoleID[]
            {
                new RoleID {Role = "User"},
                new RoleID {Role = "Admin"}
            };
        }
        public class RoleID
        {
            public string Role { get; set; } = "";
            public override string ToString() => $"{Role}";
        }

        private void Btn_Exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbRole.SelectedItem is RoleID Role)
            {
                 Chislo= Role.Role;
            }
        }

        private void BtnAddUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //MessageBox.Show($"{Chislo}");
            switch (Chislo.ToString())
            {
                case "User":
                    Chislo = "2";
                    int.TryParse(Chislo, out _RoleID);
                    _Login = TxbLogin.Text;
                    _Password = TxbPassword.Text;
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
                                MessageBox.Show("Пользователь успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    break;
                case "Admin":
                    Chislo = "1";
                    int.TryParse(Chislo, out _RoleID);
                    _Login = TxbLogin.Text;
                    _Password = TxbPassword.Text;
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
                                MessageBox.Show("Админ успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    break;
            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var User = (sender as Button).DataContext as SignIn;

            Connect.connect.SignIn.Remove(User);
            Connect.connect.SaveChanges();

            MessageBox.Show("Запись удалена");

            LoadFromData();
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            DgUsers.ItemsSource = Connect.connect.SignIn.ToList();
            Connect.connect.SaveChanges();
            MessageBox.Show("Запись изменена");
            LoadFromData();
        }
        private void LoadFromData()
        {
            DgUsers.ItemsSource = Connect.connect.SignIn.ToList();
        }
    }
}
