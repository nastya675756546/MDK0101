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
    /// Логика взаимодействия для ReferencePage.xaml
    /// </summary>
    public partial class ReferencePage : System.Windows.Controls.Page
    {
        public ReferencePage()
        {
            InitializeComponent();
            ReferenceLV.ItemsSource = Connect.context.Reference.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReferenceLV.ItemsSource = Connect.context.Reference.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delReferences = ReferenceLV.SelectedItems.Cast<Reference>().ToList();
            foreach (var delReference in delReferences)
            {
                if (Connect.context.Accounting.Any(x => x.company_id == delReference.company_id))
                {
                    MessageBox.Show("Данные используются в учетной таблицы", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (MessageBox.Show($"Удалить {delReferences.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Reference.RemoveRange(delReferences);
            }
            try
            {
                Connect.context.SaveChanges();
                ReferenceLV.ItemsSource = Connect.context.Reference.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditReference((sender as Button).DataContext as Reference));
        }
    }
}
