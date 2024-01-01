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
    /// Логика взаимодействия для FiltrPage.xaml
    /// </summary>
    public partial class FiltrPage : System.Windows.Controls.Page
    {
        public FiltrPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filtr = Connect.context.Accounting.Select(x => new
            {
                records_id = x.records_id,
                nameProduct = x.nameProduct,
                quantity = x.quantity,
                price = x.price,
                company_id = 500
            }).Where(x => x.nameProduct == NameProduct.Text).ToList();
            FiltrDG.ItemsSource = filtr;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int sale = 0;
            try
            {
                sale = Int32.Parse(saleProduct.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var filtr = Connect.context.Accounting.Select(x => new
            {
                records_id = x.records_id,
                nameProduct = x.nameProduct,
                quantity = x.quantity,
                price = x.price,
                company_id = 500
            }).Where(x => x.company_id == sale).ToList();
            FiltrDG.ItemsSource = filtr;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
