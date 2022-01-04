using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucNCC : UserControl
    {
        frmThemNCC frmNCC = new frmThemNCC();
        NhaCungCap ncc = new NhaCungCap();
        Connection conn = new Connection();
        int index;
        public UC_DanhMucNCC()
        {
            InitializeComponent();
        }
        private void btnTaoNCC_Click(object sender, EventArgs e)
        {
            if (frmNCC.IsDisposed)
            {
                frmNCC = new frmThemNCC();
            }
            frmNCC.Show();
            frmNCC.BringToFront();
            frmNCC.Activate();
        }
        private void load_dtgv()
        {
            dataGV_NhaCungCap.DataSource = ncc.loadDataGV_NhaCungCap();
        }
        private void UC_DanhMucNCC_Load(object sender, EventArgs e)
        {
            load_dtgv();
            btnSuaNCC.Enabled = btnXoaNCC.Enabled = false;
        }
        private void dataGV_NhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaNCC.Enabled = btnSuaNCC.Enabled = true;

            string mancc = dataGV_NhaCungCap.Rows[index].Cells[0].Value.ToString();
            dataGV_PhieuNhap.DataSource = ncc.layPhieuNhapHang(mancc);

        }
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = dataGV_NhaCungCap.Rows[index].Cells[0].Value.ToString();
                if (!conn.checkExist("NhaCungCap", "MaNCC", mancc))
                {
                    MessageBox.Show("Mã nhà cung cấp " + mancc + " chưa tồn tại");
                    return;
                }
                if (conn.checkExist("PhieuNhapHang", "MaNCC", mancc))
                {
                    MessageBox.Show("Mã nhà cung cấp " + mancc + " đang tồn tại trong bảng phiếu nhập hàng");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa nhà cung cấp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                if (string.IsNullOrEmpty(mancc))
                {
                    MessageBox.Show("Xóa thất bại");
                }
                else
                {
                    ncc.deleteNCC(mancc);
                    index = -1;
                    MessageBox.Show("Xóa thành công");
                    load_dtgv();
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = dataGV_NhaCungCap.Rows[index].Cells[0].Value.ToString();
                string tenncc = dataGV_NhaCungCap.Rows[index].Cells[1].Value.ToString();
                string diachi = dataGV_NhaCungCap.Rows[index].Cells[2].Value.ToString();
                string dienthoai = dataGV_NhaCungCap.Rows[index].Cells[3].Value.ToString();
                string email = dataGV_NhaCungCap.Rows[index].Cells[4].Value.ToString();
                int congno = int.Parse(dataGV_NhaCungCap.Rows[index].Cells[5].Value.ToString());
                string stk = dataGV_NhaCungCap.Rows[index].Cells[6].Value.ToString();

                if (!conn.checkExist("NhaCungCap", "MaNCC", mancc))
                {
                    MessageBox.Show("Mã nhà cung cấp " + mancc + " chưa tồn tại");
                    return;
                }
                if (conn.isEmail(email) == false)
                {
                    MessageBox.Show("Email không hợp lệ");
                    return;
                }
                if (string.IsNullOrEmpty(mancc))
                {
                    MessageBox.Show("Sửa thất bại");
                }
                else
                {
                    if (ncc.updateNCC(mancc, tenncc, diachi, dienthoai, email, congno, stk))
                    {
                        index = -1;
                        MessageBox.Show("Sửa thành công");
                        load_dtgv();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnTKNCC_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKNCC.Text;
            dataGV_NhaCungCap.DataSource = ncc.searchNCC(tukhoa);
        }

        private void btnInExc_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_NCC(dataGV_NhaCungCap, saveFileDialog1.FileName);
        }
        private void exportExcel_NCC(DataGridView dv, string fileName)
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
                worksheet.Name = "Danh mục nhà cung cấp";

                worksheet.Cells[2, 2] = "DANH MỤC NHÀ CUNG CẤP";


                for (int i = 0; i < dataGV_NhaCungCap.ColumnCount; i++)
                {
                    worksheet.Cells[4, i + 1] = dataGV_NhaCungCap.Columns[i].HeaderText;
                }

                int dmNCC = dataGV_NhaCungCap.RowCount;

                for (int i = 0; i < dataGV_NhaCungCap.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_NhaCungCap.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dataGV_NhaCungCap.Rows[i].Cells[j].Value.ToString();
                        worksheet.Range["D5", "D" + (dmNCC + 5)].NumberFormat = "@";
                        worksheet.Range["G5", "G" + (dmNCC + 5)].NumberFormat = "@";
                    }
                }

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 12.56;
                worksheet.Range["B1"].ColumnWidth = 34.22;
                worksheet.Range["C1"].ColumnWidth = 26;
                worksheet.Range["D1"].ColumnWidth = 13.67;
                worksheet.Range["E1"].ColumnWidth = 27.11;
                worksheet.Range["F1"].ColumnWidth = 12.44;
                worksheet.Range["G1"].ColumnWidth = 17.22;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A4", "G4"].Font.Bold = true;
                //Kẻ bảng
                worksheet.Range["A4", "G" + (dmNCC + 4)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A4", "G4"].HorizontalAlignment = 3;

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
