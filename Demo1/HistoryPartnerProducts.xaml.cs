using Demo1.DataBase;
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
using System.Windows.Shapes;

namespace Demo1
{
    /// <summary>
    /// Логика взаимодействия для HistoryPartnerProducts.xaml
    /// </summary>
    public partial class HistoryPartnerProducts : Window
    {
        Partners _currentPartner;
        public HistoryPartnerProducts(Partners currentPartner)
        {
            InitializeComponent();
            if (currentPartner.GetProductCount() != 0)
            {
                //Вывод в listView продуктов выбранного партнера
                PartnersProductsListView.ItemsSource = currentPartner.PartnerProducts.ToList();
            }
            else
            {
                MessageBox.Show("0 Продуктов");
            }

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
