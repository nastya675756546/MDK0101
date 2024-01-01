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
    /// Логика взаимодействия для SortingPage.xaml
    /// </summary>
    public partial class SortingPage : System.Windows.Controls.Page
    {
        public SortingPage()
        {
            InitializeComponent();
            var sorting = Connect.context.Accounting.OrderBy(x => x.company_id).ToList();
            SortingDG.ItemsSource = sorting;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
