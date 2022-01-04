using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_ThongKeTop10SPBanChay : UserControl
    {
        Connection cn = new Connection();
        SanPham sp = new SanPham();
        public UC_ThongKeTop10SPBanChay()
        {
            InitializeComponent();
        }

        private void btnXemTK_Top10SPBanChay_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD.Value;
            var toDate = txtNgayKT.Value;
            dt = sp.loadThongKe_Top5SPBanChay(fromDate, toDate);
            dataGV_Top5SPBanChay.DataSource = dt;
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_top5BanChay(dataGV_Top5SPBanChay, saveFileDialog1.FileName);
        }
        private void exportExcel_top5BanChay(DataGridView dv, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "Thống kê Top 5 SP Bán Chạy";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ TOP 5 SẢN PHẨM BÁN CHẠY NHẤT";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD.Text + " đến " + txtNgayKT.Text;

                for (int i = 0; i < dataGV_Top5SPBanChay.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_Top5SPBanChay.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_Top5SPBanChay.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_Top5SPBanChay.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_Top5SPBanChay.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_Top5SPBanChay.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 17.11;
                worksheet.Range["B1"].ColumnWidth = 53.89;
                worksheet.Range["C1"].ColumnWidth = 15.44;
                worksheet.Range["D1"].ColumnWidth = 15.44;

                //Định dạng fone chữ
                worksheet.Range["A1", "D100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "D100"].Font.Size = 13;
                worksheet.Range["A2", "D2"].MergeCells = true;
                worksheet.Range["A2", "D2"].Font.Bold = true;
                worksheet.Range["A2", "D2"].Font.Size = 15;

                worksheet.Range["A3", "D3"].MergeCells = true;
                worksheet.Range["A3", "D3"].Font.Italic = true;

                worksheet.Range["A5", "D5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "D" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "D2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "D3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "D5"].HorizontalAlignment = 3;
                worksheet.Range["A5", "A" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["C5", "C" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["D5", "D" + (tkshh + 5)].HorizontalAlignment = 3;


                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất excel thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
