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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : System.Windows.Controls.Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new ReferencePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AccountingPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new FindPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SortingPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new FindPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new ReportPage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new ReportPDFPage());
        }
    }
}
