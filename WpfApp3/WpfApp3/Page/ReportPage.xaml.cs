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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace WpfApp3.Page
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : System.Windows.Controls.Page
    {
        Excel.Application app;
        public ReportPage()
        {
            InitializeComponent();
            app = new Excel.Application();
            {
                app.Visible = true;
                app.SheetsInNewWorkbook = 1;
            }

            Workbook workBook = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Worksheet sheet = (Worksheet)app.Worksheets.get_Item(1);

            sheet.Name = "Отчет";
            sheet.Cells[1, 2] = "Ведомость отгрузки продукции предприятием";

            Excel.Range range2 = sheet.get_Range("B1", "F1");
            range2.Merge(Type.Missing);

            sheet.Cells[2, 2] = "--------------------------------------------------------------------------------";

            Excel.Range mergeCelles = sheet.get_Range("B2", "D2");
            mergeCelles.Merge(Type.Missing);

            sheet.Cells[3, 1] = "Наименование продукции";
            sheet.Cells[3, 2] = "Код продукции";
            sheet.Cells[3, 3] = "Дата";
            sheet.Cells[3, 4] = "Количество";
            sheet.Cells[3, 5] = "Цена";
            sheet.Cells[3, 6] = "Стоимость";
            var currentRow = 4;
            var accountings = Connect.context.Accounting.ToList();
            foreach (var item in accountings)
            {
                sheet.Cells[currentRow, 1] = item.nameProduct;
                sheet.Cells[currentRow, 2] = item.records_id;
                sheet.Cells[currentRow, 3] = DateTime.Now.ToString();
                sheet.Cells[currentRow, 4] = item.quantity;
                sheet.Cells[currentRow, 5] = item.price;
                sheet.Cells[currentRow, 6] = item.price * item.quantity;
                currentRow++;
            }
            var accountingsSum = Connect.context.Accounting.Select(x => new
            {
                sum = x.price * x.quantity
            }).Sum(x => x.sum);

            Excel.Range mergeCelles2 = sheet.get_Range("A14", "E14");
            mergeCelles2.Merge(Type.Missing);
            mergeCelles2.HorizontalAlignment = Excel.Constants.xlCenter;
            sheet.Cells[currentRow, 1] = "Итого:";

            sheet.Cells[currentRow, 6] = accountingsSum;

            Range r = sheet.get_Range("A3", "F14");
            Borders body = r.Borders;
            body.LineStyle = XlLineStyle.xlContinuous;

            sheet.Columns.AutoFit();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
