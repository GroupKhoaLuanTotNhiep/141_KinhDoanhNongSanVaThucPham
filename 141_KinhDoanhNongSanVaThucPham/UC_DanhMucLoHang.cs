using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucLoHang : UserControl
    {
        Connection conn = new Connection();
        LoHang loHang = new LoHang();
        NhapKho nhapKho = new NhapKho();
        SanPham sanPham = new SanPham();
        frmThemLoHang frm = new frmThemLoHang();
        int index = -1;

        public UC_DanhMucLoHang()
        {
            InitializeComponent();
        }

        void loadComboBoxPhieuNhapHang()
        {
            cbbPhieuNhap.DataSource = nhapKho.loadPhieuNhapHang();
            cbbPhieuNhap.DisplayMember = "MaPNH";
            cbbPhieuNhap.ValueMember = "MaPNH";
        }
        
        void loadCBBPhieuNhapHangTrongGridView()
        {
            MaPNH.DataSource = nhapKho.loadPhieuNhapHang();
            MaPNH.DisplayMember = "MaPNH";
            MaPNH.ValueMember = "MaPNH";
        }

        void loadCBBSanPhamTrongGridView()
        {
            MaSP.DataSource = sanPham.loadSanPham();
            MaSP.DisplayMember = "TenSP";
            MaSP.ValueMember = "MaSP";
        }

        void loadCBBGiaBanTrongGridView()
        {
            MaGia.DataSource = sanPham.loadGiaBan();
            MaGia.DisplayMember = "GiaSP";
            MaGia.ValueMember = "MaGia";
        }

        void createTable_LoHang()
        {
            dataGV_LoHang.DataSource = loHang.loadDataGV_LoHang();
        }

        private void UC_DanhMucLoHang_Load(object sender, EventArgs e)
        {
            loadComboBoxPhieuNhapHang();
            loadCBBPhieuNhapHangTrongGridView();
            loadCBBSanPhamTrongGridView();
            loadCBBGiaBanTrongGridView();
            createTable_LoHang(); 
        }

        private void btnTKLoHang_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("LoHang", "MaLo", txtTKLoHang.Text.Trim()))
            {
                dataGV_LoHang.DataSource = loHang.searchLoHangTheoMaLo(txtTKLoHang.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy lô hàng này!");
                createTable_LoHang();
            }
        }

        private void dataGV_LoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                index = e.RowIndex;
                btnSuaLo.Enabled = btnXoaLo.Enabled = true;
            }
        }

        public bool kiemTraNgaySXVaNgayHSD()
        {
            string strNgaySanXuat = dataGV_LoHang.Rows[index].Cells[2].Value.ToString();
            string strHanSuDung = dataGV_LoHang.Rows[index].Cells[3].Value.ToString();
            int ngay = DateTime.Parse(strHanSuDung).Day - DateTime.Parse(strNgaySanXuat).Day;
            int thang = DateTime.Parse(strHanSuDung).Month - DateTime.Parse(strNgaySanXuat).Month;
            int nam = DateTime.Parse(strHanSuDung).Year - DateTime.Parse(strNgaySanXuat).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay == 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnXoaLo_Click(object sender, EventArgs e)
        {
            try
            {
                string malo = dataGV_LoHang.Rows[index].Cells[0].Value.ToString();
                if (!conn.checkExist("LoHang", "MaLo", malo))
                {
                    MessageBox.Show("Mã lô " + malo + " này chưa tồn tại!");
                    return;
                }
                if(conn.checkExist("ChiTietPhieuXuatHang", "MaLo", malo))
                {
                    MessageBox.Show("Lô này đang được sử dụng trong bảng chi tiết phiếu xuất hàng");
                    return;
                }
                if (conn.checkExist("ChiTietPhieuThanhLy", "MaLo", malo))
                {
                    MessageBox.Show("Lô này đang được sử dụng trong bảng chi tiết phiếu thanh lý");
                    return;
                }
                if (string.IsNullOrEmpty(malo))
                {
                    MessageBox.Show("Xóa thất bại");
                }
                else
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa lô hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    loHang.deleteLoHang(malo);
                    index = -1;
                    MessageBox.Show("Xóa thành công");
                    createTable_LoHang();
                    btnSuaLo.Enabled = btnXoaLo.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaLo_Click(object sender, EventArgs e)
        {
            try
            {
                string malo = dataGV_LoHang.Rows[index].Cells[0].Value.ToString();
                string tenlo = dataGV_LoHang.Rows[index].Cells[1].Value.ToString();
                DateTime nsx = DateTime.Parse( dataGV_LoHang.Rows[index].Cells[2].Value.ToString());
                DateTime hsd= DateTime.Parse(dataGV_LoHang.Rows[index].Cells[3].Value.ToString());
                float sl = float.Parse( dataGV_LoHang.Rows[index].Cells[4].Value.ToString());
                int mapnh = int.Parse(dataGV_LoHang.Rows[index].Cells[5].Value.ToString());
                string masp = dataGV_LoHang.Rows[index].Cells[6].Value.ToString();
                int magia = int.Parse(dataGV_LoHang.Rows[index].Cells[7].Value.ToString());

                if (string.IsNullOrEmpty(malo))
                {
                    MessageBox.Show("Sửa thất bại");
                }
                else
                {
                    if (!conn.checkExist("LoHang", "MaLo", malo))
                    {
                        MessageBox.Show("Mã lô " + malo + " này chưa tồn tại!");
                        return;
                    }
                    if (kiemTraNgaySXVaNgayHSD() == false)
                    {
                        MessageBox.Show("Ngày sản xuất phải nhỏ hơn Hạn sử dụng!");
                        return;
                    }
                    if (loHang.updateLoHang(malo, tenlo, nsx, hsd, mapnh, masp, magia))
                    {
                        index = -1;
                        MessageBox.Show("Sửa thành công");
                        createTable_LoHang();
                        btnSuaLo.Enabled = btnXoaLo.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void cbbPhieuNhap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbPhieuNhap.Items.Count > 0)
                dataGV_LoHang.DataSource = loHang.searchLoHangTheoMaPNH(cbbPhieuNhap.Text.Trim());
            else
                createTable_LoHang();
        }

        private void btnInExc_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_LSP(dataGV_LoHang, saveFileDialog1.FileName);
        }
        private void exportExcel_LSP(DataGridView dv, string fileName)
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
                worksheet.Name = "Danh mục lô sản phẩm";

                worksheet.Cells[2, 2] = "DANH MỤC LÔ SẢN PHẨM";


                for (int i = 0; i < dataGV_LoHang.ColumnCount; i++)
                {
                    worksheet.Cells[4, i + 1] = dataGV_LoHang.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_LoHang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_LoHang.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dataGV_LoHang.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int dmLH = dataGV_LoHang.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 12.56;
                worksheet.Range["B1"].ColumnWidth = 19.22;
                worksheet.Range["C1"].ColumnWidth = 19.44;
                worksheet.Range["D1"].ColumnWidth = 16.56;
                worksheet.Range["E1"].ColumnWidth = 11.67;
                worksheet.Range["F1"].ColumnWidth = 12.56;
                worksheet.Range["G1"].ColumnWidth = 17.22;
                worksheet.Range["H1"].ColumnWidth = 8.22;

                //Định dạng fone chữ
                worksheet.Range["A1", "H100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "H100"].Font.Size = 13;
                worksheet.Range["A2", "H2"].MergeCells = true;
                worksheet.Range["A2", "H2"].Font.Bold = true;
                worksheet.Range["A2", "H2"].Font.Size = 15;

                worksheet.Range["A4", "H4"].Font.Bold = true;

                //worksheet.Range["D" + (dmLH + 7), "E" + (dmLH + 7)].MergeCells = true;
                //worksheet.Range["D" + (dmLH + 7), "E" + (dmLH + 7)].Font.Bold = true;

                //worksheet.Range["D" + (dmLH + 8), "E" + (dmLH + 8)].MergeCells = true;
                //worksheet.Range["D" + (dmLH + 8), "E" + (dmLH + 8)].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A4", "H" + (dmLH + 4)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "H2"].HorizontalAlignment = 3;
                worksheet.Range["A4", "H4"].HorizontalAlignment = 3; 
                worksheet.Range["E5", "E" + (dmLH + 5)].HorizontalAlignment = 3;
                worksheet.Range["F5", "F" + (dmLH + 5)].HorizontalAlignment = 3;
                worksheet.Range["G5", "G" + (dmLH + 5)].HorizontalAlignment = 3;
                //worksheet.Range["C6", "C" + (dmLH + 6)].HorizontalAlignment = 3;
                //worksheet.Range["D6", "D" + (dmLH + 6)].HorizontalAlignment = 3;

                //worksheet.Range["D" + (dmLH + 7), "E" + (dmLH + 7)].HorizontalAlignment = 3;

                //worksheet.Range["D" + (dmLH + 8), "E" + (dmLH + 8)].HorizontalAlignment = 3;

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
