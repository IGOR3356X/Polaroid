using Polaroid.ContentObjects;
using Polaroid.DataBase;
using Polaroid.Pages.GlavPage;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

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
            Cmb_Category.ItemsSource = new CategoryID[]
            {
                new CategoryID {Category = "Камеры"},
                new CategoryID {Category = "Принтеры"},
                new CategoryID {Category = "Экшн камеры"},
                new CategoryID {Category = "Фотоаксессуары"},
                new CategoryID {Category = "Солнцезащитные очки"}
            };
            Cmb_Shop.ItemsSource = new ShopID[]
            {
                new ShopID {Shop = "Варшавское ш., д. 26, строение 12"},
                new ShopID {Shop = "ул. Савушкина, д. 24"},
                new ShopID {Shop = "ул. Бажова, д. 89"},
            };
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Navigating.nav.GoBack();
        }

        public class CategoryID
        {
            public string Category { get; set; } = "";
            public override string ToString() => $"{Category}";
        }

        public class ShopID
        {
            public string Shop { get; set; } = "";
            public override string ToString() => $"{Shop}";
        }

        private void Cmb_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_Category.SelectedItem is CategoryID category)
            {
                ID_Category.Text = category.Category;
            }
        }
        private void Cmb_Shop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_Shop.SelectedItem is ShopID shop)
            {
                ID_Shop.Text = shop.Shop;
            }
        }

        private void Btn_Testos_Click(object sender, RoutedEventArgs e)
        {
            switch (ID_Category.Text)
            {
                case "Камеры":
                    if (ID_Shop.Text == "Варшавское ш., д. 26, строение 12")
                    {
                        TxbCategoryID.Text = "1";
                        TxbShopID.Text = "2";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Савушкина, д. 24")
                    {
                        TxbCategoryID.Text = "1";
                        TxbShopID.Text = "3";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Бажова, д. 89")
                    {
                        TxbCategoryID.Text = "1";
                        TxbShopID.Text = "4";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    break;
                case "Принтеры":
                    if (ID_Shop.Text == "Варшавское ш., д. 26, строение 12")
                    {
                        TxbCategoryID.Text = "2";
                        TxbShopID.Text = "2";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Савушкина, д. 24")
                    {
                        TxbCategoryID.Text = "2";
                        TxbShopID.Text = "3";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Бажова, д. 89")
                    {
                        TxbCategoryID.Text = "2";
                        TxbShopID.Text = "4";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    break;
                case "Экшн камеры":
                    if (ID_Shop.Text == "Варшавское ш., д. 26, строение 12")
                    {
                        TxbCategoryID.Text = "3";
                        TxbShopID.Text = "2";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Савушкина, д. 24")
                    {
                        TxbCategoryID.Text = "3";
                        TxbShopID.Text = "3";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Бажова, д. 89")
                    {
                        TxbCategoryID.Text = "3";
                        TxbShopID.Text = "4";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    break;
                case "Фотоаксессуары":
                    if (ID_Shop.Text == "Варшавское ш., д. 26, строение 12")
                    {
                        TxbCategoryID.Text = "4";
                        TxbShopID.Text = "2";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Савушкина, д. 24")
                    {
                        TxbCategoryID.Text = "4";
                        TxbShopID.Text = "3";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Бажова, д. 89")
                    {
                        TxbCategoryID.Text = "4";
                        TxbShopID.Text = "4";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    break;
                case "Солнцезащитные очки":
                    if (ID_Shop.Text == "Варшавское ш., д. 26, строение 12")
                    {
                        TxbCategoryID.Text = "5";
                        TxbShopID.Text = "2";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Савушкина, д. 24")
                    {
                        TxbCategoryID.Text = "5";
                        TxbShopID.Text = "3";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    else if (ID_Shop.Text == "ул. Бажова, д. 89")
                    {
                        TxbCategoryID.Text = "5";
                        TxbShopID.Text = "4";

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
                                        if (_ShopID != 0 && _CategoryID != 0 && _Discription != "" && _Price != 0 && _ItemName != "")
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
                    break;
            }
        }
    }
}
