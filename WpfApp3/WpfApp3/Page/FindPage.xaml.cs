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
    /// Логика взаимодействия для FindPage.xaml
    /// </summary>
    public partial class FindPage : System.Windows.Controls.Page
    {
        public FindPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var find = Connect.context.Accounting.Where(x => x.nameProduct.Contains(NameProduct.Text)).ToList();
            FindDG.ItemsSource = find;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int saleProduct = 0;
            try
            {
                saleProduct = Int32.Parse(saleP.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var find = Connect.context.Accounting.Where(x => x.nameProduct.Contains(ProductName.Text)).ToList();
            FindDG.ItemsSource = find;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
