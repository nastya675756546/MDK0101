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

namespace WpfApp3.Page
{
    /// <summary>
    /// Логика взаимодействия для AccountingPage.xaml
    /// </summary>
    public partial class AccountingPage : System.Windows.Controls.Page
    {
        public AccountingPage()
        {
            InitializeComponent();
            AccountingLV.ItemsSource = Connect.context.Accounting.ToList();
        }


        private void AddBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditAccounting(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delAccountings = AccountingLV.SelectedItems.Cast<Accounting>().ToList();

            if (MessageBox.Show($"Удалить {delAccountings.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Accounting.RemoveRange(delAccountings);
            }
            try
            {
                Connect.context.SaveChanges();
                AccountingLV.ItemsSource = Connect.context.Accounting.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountingLV.ItemsSource = Connect.context.Accounting.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditAccounting((sender as Button).DataContext as Accounting));
        }
    }
}
