using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace Polaroid.Pages.Testovik
{
    /// <summary>
    /// Логика взаимодействия для Testo.xaml
    /// </summary>
    public partial class Testo : Page
    {
        public Testo()
        {
            InitializeComponent();
            SldPrice.Minimum = 0; 
            SldPrice.Maximum = 100000;
            SldPrice.ValueChanged += ProgressUpdate;
        }
        private void ProgressUpdate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxbPrice.Text = ""+Math.Round(e.NewValue);
 
        }

        private void TxbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

            Button G = new Button
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 100,
                Width = 100,
                Content = "GG"
            };
            GEGE.Children.Add(G);
            G.Click += new RoutedEventHandler(G_Click);
        }
        private void G_Click (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ало ПИД");
        }
    }
}
