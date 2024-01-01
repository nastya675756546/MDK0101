using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    /// Логика взаимодействия для AddEditReference.xaml
    /// </summary>
    public partial class AddEditReference : System.Windows.Controls.Page
    {
        Reference reference;
        public static bool checkNew;

        public AddEditReference(Reference c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Reference();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = reference = c;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connect.context.Reference.Add(reference);
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
        public static bool chekReference(Reference c)
        {
            if (string.IsNullOrEmpty(c.nameCompany) || !c.nameCompany.All(char.IsLetter))
                return false;
            return true;
        }
        

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
