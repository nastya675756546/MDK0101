using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfApp3.Page
{
    /// <summary>
    /// Логика взаимодействия для ReportPDFPage.xaml
    /// </summary>
    public partial class ReportPDFPage : System.Windows.Controls.Page

    {
        public ReportPDFPage()
        {
            InitializeComponent();
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Продукты.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                PdfPTable table = new PdfPTable(6);
                PdfPCell cell = new PdfPCell(new Phrase("Ведомость отгрузки продукции предприятием \n", font));
                cell.Colspan = 2;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(new PdfPCell(new Phrase("Наименование продукции", font)));
                table.AddCell(new PdfPCell(new Phrase("Код продукции", font)));
                table.AddCell(new PdfPCell(new Phrase("Дата", font)));
                table.AddCell(new PdfPCell(new Phrase("Количество", font)));
                table.AddCell(new PdfPCell(new Phrase("Цена", font)));
                table.AddCell(new PdfPCell(new Phrase("Стоимость", font)));
                var accountings = Connect.context.Accounting.ToList();
                foreach (var item in accountings)
                {
                    table.AddCell(new Phrase(item.nameProduct.ToString(), font));
                    table.AddCell(new Phrase(item.records_id.ToString(), font));
                    table.AddCell(new Phrase(DateTime.Now.ToString(), font));
                    table.AddCell(new Phrase(item.quantity.ToString(), font));
                    table.AddCell(new Phrase(item.price.ToString(), font));
                    table.AddCell(new Phrase((item.price * item.quantity).ToString(), font));
                }
                doc.Add(table);
                doc.Close();
                MessageBox.Show("Pdf документ сокранен");

            }
            catch
            {
                MessageBox.Show("Pdf документ не сокранен");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
           
        }
    }
}
