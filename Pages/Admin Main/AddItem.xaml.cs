using Polaroid.ContentObjects;
using Polaroid.DataBase;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Polaroid.Pages.Admin_Main
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        private string _ItemName;
        private decimal _Price;
        private string _Discription;
        private int _CategoryID;
        private int _ShopID;
        public AddItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _ItemName = TxbItemName.Text;
            Decimal.TryParse(TxbPrice.Text, out _Price);
            _Discription = TxbDiscription.Text;
            int.TryParse(TxbCategoryID.Text, out _CategoryID);
            int.TryParse(TxbShopID.Text, out _ShopID);

            if (_ItemName != null && _ItemName != "")
            {
                if (_Price != 0 && _ItemName != "")
                {
                    if (_Discription != null && _Discription != "" && _Price != 0 && _ItemName != "")
                    {
                        if (_CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
                        {
                            if (_ShopID != 0 && _CategoryID !=0 && _Discription != "" && _Price != 0 && _ItemName != "")
                            {
                                var Item = new Items()
                                {
                                    ItemName = _ItemName,
                                    Price = _Price,
                                    Discription = _Discription,
                                    CategoryID = _CategoryID,
                                    ShopID = _ShopID
                                };
                                Connect.connect.Items.Add(Item);
                                Connect.connect.SaveChanges();
                                MessageBox.Show("Товар успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Введите ID Магазина");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите ID катиегории");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите описание товара");
                    }

                }
                else
                {
                    MessageBox.Show("Введите цену");
                }
            }
            else
            {
                MessageBox.Show("Введите Название товара");
            }
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }
    }
}
