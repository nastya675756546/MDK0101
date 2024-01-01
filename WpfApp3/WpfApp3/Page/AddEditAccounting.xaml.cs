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
    /// Логика взаимодействия для AddEditAccounting.xaml
    /// </summary>
    public partial class AddEditAccounting : System.Windows.Controls.Page
    {
        Accounting accounting;
        bool checkNew;
        public AddEditAccounting(Accounting c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Accounting();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = accounting = c;
        
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connect.context.Accounting.Add(accounting);
            }
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        public static bool chekAccounting(Accounting c)
        {
            if (string.IsNullOrEmpty(c.nameProduct) || !c.nameProduct.All(char.IsLetter))
                return false;
            return true;
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
