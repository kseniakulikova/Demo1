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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PartnersListView.ItemsSource = DemoEntities.GetContext().Partners.ToList();
        }
        private void UpdateListView()
        {
            PartnersListView.ItemsSource = DemoEntities.GetContext().Partners.ToList();
        }
        private void AddPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow(new Partners());
            addPartnerWindow.ShowDialog();
            UpdateListView();
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Partners partners = menuItem.DataContext as Partners;
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow(partners);
            addPartnerWindow.ShowDialog();
            UpdateListView();
        }
        private void HistoryProductMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Partners partners = menuItem.DataContext as Partners;
            HistoryPartnerProducts historyPartnerProducts = new HistoryPartnerProducts(partners);
            historyPartnerProducts.ShowDialog();
        }
    }
}
