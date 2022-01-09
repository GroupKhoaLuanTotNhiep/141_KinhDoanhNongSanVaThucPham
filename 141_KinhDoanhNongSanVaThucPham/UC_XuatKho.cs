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
    public partial class UC_XuatKho : UserControl
    {
        Connection conn = new Connection();
        ChiNhanh chiNhanh = new ChiNhanh();
        NhanVien nhanVien = new NhanVien();
        LoHang loHang = new LoHang();
        SanPham sanPham = new SanPham();
        QuayHang quayHang = new QuayHang();
        XuatHang xuatHang = new XuatHang();

        public UC_XuatKho()
        {
            InitializeComponent();
        }

        void loadComboBoxChiNhanh()
        {
            cbbChiNhanh.DataSource = chiNhanh.loadChiNhanh();
            cbbChiNhanh.DisplayMember = "TenChiNhanh";
            cbbChiNhanh.ValueMember = "MaChiNhanh";
        }

        void loadComboBoxQuayHang()
        {
            cbbQuayHang.DataSource = quayHang.loadQuayHang();
            cbbQuayHang.DisplayMember = "TenQuay";
            cbbQuayHang.ValueMember = "MaQuay";
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void loadComboBoxLoHang()
        {
            cbbLoSanPham.DataSource = loHang.loadLoHang();
            cbbLoSanPham.DisplayMember = "TenLo";
            cbbLoSanPham.ValueMember = "MaLo";
        }

        void loadComboBoxSanPham()
        {
            cbbSanPham.DataSource = sanPham.loadSanPham();
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        void createTable_PhieuXuatHang()
        {
            dataGV_PhieuXuat.DataSource = xuatHang.loadDataGV_PhieuXuatHang();
        }

        void createTable_CTPXH()
        {
            dataGV_CTHangHoaXuat.DataSource = xuatHang.loadDataGV_CTPXTheoMaPXH(txtMaPhieuXuat.Text);
        }

        private void txtSoLuongXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void UC_XuatKho_Load(object sender, EventArgs e)
        {
            loadComboBoxChiNhanh();
            loadComboBoxQuayHang();
            //loadComboBoxNhanVien();
            cbbNhanVien.Text = frmDangNhap.maNV;
            loadComboBoxLoHang();
            loadComboBoxSanPham();
            createTable_PhieuXuatHang();
            createTable_CTPXH();
            txtMaPhieuXuat.Enabled = false;
            txtTongSLXuat.Enabled = txtTongSLSanPham.Enabled = false;
            cbbDonViTinh.Enabled = cbbNhanVien.Enabled = false;
            btnLuuPXH.Enabled = btnXoaCTPXH.Enabled = btnSuaPXH.Enabled = btnXoaPhieuXuat.Enabled = false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            loadComboBoxQuayHang();
            txtMaPhieuXuat.Clear();
            txtNgayXuat.Text = DateTime.Now.ToString();
            //cbbNhanVien.SelectedIndex = 0;
            cbbNhanVien.Text = frmDangNhap.maNV;
            cbbChiNhanh.SelectedIndex = 0;
            cbbQuayHang.SelectedIndex = 0;
            cbbLoSanPham.Text = "";
            cbbSanPham.SelectedIndex = 0;
            cbbDonViTinh.Text = "";
            txtSoLuongXuat.Clear();
            txtTongSLXuat.Text = "0";
            txtTongSLSanPham.Text = "0";
            createTable_CTPXH();
            dataGV_CTPhieuXuat.DataSource = xuatHang.layChiTietPhieuXuatHang(txtMaPhieuXuat.Text);
            btnLuuPXH.Enabled = true;
        }

        public bool kiemTraNgayXuatVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayXuat = DateTime.ParseExact(txtNgayXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayXuat).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strNgayXuat).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strNgayXuat).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuPXH_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuXuat = txtMaPhieuXuat.Text.Trim();
                string strNgayXuat = DateTime.ParseExact(txtNgayXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strQuayHang = cbbQuayHang.SelectedValue.ToString().Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongXuat = txtSoLuongXuat.Text.Trim();
                if (strSoLuongXuat == string.Empty)
                {
                    txtSoLuongXuat.Focus();
                    return;
                }

                if (!conn.checkExist("PhieuXuatHang", "MaPXH", strMaPhieuXuat))
                {
                    if (kiemTraNgayXuatVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày xuất phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    string strSqlPX = "INSERT PhieuXuatHang VALUES('" + strNgayXuat + "', '" + strNhanVien + "', '" + strChiNhanh + "', '" + strQuayHang + "')";
                    conn.updateToDatabase(strSqlPX);
                    createTable_PhieuXuatHang();
                    MessageBox.Show("Lưu phiếu xuất hàng thành công!");
                    txtMaPhieuXuat.Text = xuatHang.layMaPhieuXuat();
                }
                if (conn.checkExist("PhieuXuatHang", "MaPXH", strMaPhieuXuat))
                {
                    if (!conn.checkExist("LoHang", "MaLo", strLoHang))
                    {
                        MessageBox.Show("Lô hàng này chưa tồn tại!");
                        return;
                    }
                    if (conn.checkExistTwoKey("ChiTietPhieuXuatHang", "MaPXH", "MaLo", strMaPhieuXuat, strLoHang))
                    {
                        MessageBox.Show("Trùng khóa chính rồi!");
                        return;
                    }
                    if (float.Parse(strSoLuongXuat) > float.Parse(loHang.laySoLuong(strLoHang)))
                    {
                        MessageBox.Show("Số lượng xuất phải nhỏ hơn hoặc bằng số lượng có trong lô (" + float.Parse(loHang.laySoLuong(strLoHang)) + ")!");
                        return;
                    }
                    if(float.Parse(strSoLuongXuat) > float.Parse(loHang.laySoLuong(strLoHang)) - xuatHang.layTongSLHangXuatCuaLoHangCuaSanPham(strLoHang))
                    {
                        MessageBox.Show("Số lượng xuất phải nhỏ hơn hoặc bằng số lượng có trong kho của lô hàng đó (" + (float.Parse(loHang.laySoLuong(strLoHang)) - xuatHang.layTongSLHangXuatCuaLoHangCuaSanPham(strLoHang)) + ")!");
                        return;
                    }
                    string strSqlCTPX = "INSERT ChiTietPhieuXuatHang VALUES('" + strMaPhieuXuat + "', '" + strLoHang + "', " + strSoLuongXuat + ")";
                    conn.updateToDatabase(strSqlCTPX);
                    createTable_CTPXH();
                    MessageBox.Show("Lưu chi tiết phiếu xuất hàng thành công!");
                }
                txtTongSLXuat.Text = xuatHang.updateTongSoLuongXuat(strMaPhieuXuat).ToString();
                txtTongSLSanPham.Text = xuatHang.demSLMatHang(strMaPhieuXuat).ToString();
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại!");
            }
        }

        private void btnSuaPXH_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuXuat = txtMaPhieuXuat.Text.Trim();
                string strNgayXuat = DateTime.ParseExact(txtNgayXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strQuayHang = cbbQuayHang.SelectedValue.ToString().Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongXuat = txtSoLuongXuat.Text.Trim();
                if (strSoLuongXuat == string.Empty)
                {
                    txtSoLuongXuat.Focus();
                    return;
                }

                if (!conn.checkExist("PhieuXuatHang", "MaPXH", strMaPhieuXuat))
                {
                    MessageBox.Show("Mã phiếu xuất hàng này không tồn tại!");
                    return;
                }

                string strSqlPX = "UPDATE PhieuXuatHang SET NgayXuat='" + strNgayXuat + "', MaChiNhanh='" + strChiNhanh + "' WHERE MaPXH='" + strMaPhieuXuat + "'";
                conn.updateToDatabase(strSqlPX);
                createTable_PhieuXuatHang();
                MessageBox.Show("Cập nhật phiếu xuất hàng thành công!");

                if (!conn.checkExist("LoHang", "MaLo", strLoHang))
                {
                    MessageBox.Show("Lô hàng này chưa tồn tại!");
                    return;
                }
                if (!conn.checkExistTwoKey("ChiTietPhieuXuatHang", "MaPXH", "MaLo", strMaPhieuXuat, strLoHang))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (float.Parse(strSoLuongXuat) > float.Parse(loHang.laySoLuong(strLoHang)))
                {
                    MessageBox.Show("Số lượng xuất phải nhỏ hơn hoặc bằng số lượng có trong lô (" + float.Parse(loHang.laySoLuong(strLoHang)) + ")!");
                    return;
                }
                //string strSqlUPCTPX = "UPDATE ChiTietPhieuXuatHang SET SoLuongXuat=" + 1 + " WHERE MaPXH='" + strMaPhieuXuat + "' AND MaLo='" + strLoHang + "'";
                //conn.updateToDatabase(strSqlUPCTPX);
                if (float.Parse(strSoLuongXuat) > float.Parse(loHang.laySoLuong(strLoHang)) - xuatHang.layTongSLHangXuatCuaLoHangCuaSanPham(strLoHang) + xuatHang.laySLHangXuatCuaMotChiTiet(strMaPhieuXuat, strLoHang))
                {
                    MessageBox.Show("Số lượng xuất phải nhỏ hơn hoặc bằng số lượng có trong kho của lô hàng đó (" + (float.Parse(loHang.laySoLuong(strLoHang)) - xuatHang.layTongSLHangXuatCuaLoHangCuaSanPham(strLoHang) + xuatHang.laySLHangXuatCuaMotChiTiet(strMaPhieuXuat, strLoHang)) + ")!");
                    return;
                }
                string strSqlCTPX = "UPDATE ChiTietPhieuXuatHang SET SoLuongXuat=" + strSoLuongXuat + " WHERE MaPXH='" + strMaPhieuXuat + "' AND MaLo='" + strLoHang + "'";
                conn.updateToDatabase(strSqlCTPX);
                createTable_CTPXH();
                MessageBox.Show("Cập nhật chi tiết phiếu xuất hàng thành công!");

                txtTongSLXuat.Text = xuatHang.updateTongSoLuongXuat(strMaPhieuXuat).ToString();
                txtTongSLSanPham.Text = xuatHang.demSLMatHang(strMaPhieuXuat).ToString();
            }
            catch
            {
                MessageBox.Show("Quá trình cập nhật thất bại!");
            }
        }

        private void dataGV_PhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuXuat.Text = dataGV_PhieuXuat.Rows[index].Cells[0].Value.ToString();
            txtNgayXuat.Text = dataGV_PhieuXuat.Rows[index].Cells[1].Value.ToString();
            cbbNhanVien.Text = dataGV_PhieuXuat.Rows[index].Cells[2].Value.ToString();
            cbbChiNhanh.Text = chiNhanh.layTenChiNhanh(dataGV_PhieuXuat.Rows[index].Cells[3].Value.ToString());
            cbbQuayHang.Text = quayHang.layTenQuayHang(dataGV_PhieuXuat.Rows[index].Cells[4].Value.ToString());
            string a = dataGV_PhieuXuat.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuXuat.DataSource = xuatHang.layChiTietPhieuXuatHang(a);
            dataGV_CTHangHoaXuat.DataSource = xuatHang.layCTPX(a);
            btnSuaPXH.Enabled = btnXoaPhieuXuat.Enabled = true;

            txtTongSLXuat.Text = xuatHang.updateTongSoLuongXuat(a).ToString();
            txtTongSLSanPham.Text = xuatHang.demSLMatHang(a).ToString();
        }

        private void dataGV_CTHangHoaXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuXuat.Text = dataGV_CTHangHoaXuat.Rows[index].Cells[0].Value.ToString();
            cbbLoSanPham.Text = loHang.layTenLoHang(dataGV_CTHangHoaXuat.Rows[index].Cells[1].Value.ToString());
            cbbSanPham.Text = dataGV_CTHangHoaXuat.Rows[index].Cells[2].Value.ToString();
            txtSoLuongXuat.Text = dataGV_CTHangHoaXuat.Rows[index].Cells[3].Value.ToString();
            btnXoaCTPXH.Enabled = btnSuaPXH.Enabled = true;

            cbbDonViTinh.DataSource = xuatHang.loadDVTTheoSanPham(dataGV_CTHangHoaXuat.Rows[index].Cells[2].Value.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";
        }

        private void btnXoaCTPXH_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuXuat = txtMaPhieuXuat.Text.Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();

                if (!conn.checkExistTwoKey("ChiTietPhieuXuatHang", "MaPXH", "MaLo", strMaPhieuXuat, strLoHang))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết phiếu xuất hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE ChiTietPhieuXuatHang WHERE MaPXH='" + strMaPhieuXuat + "' AND MaLo='" + strLoHang + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa chi tiết phiếu xuất hàng thành công!");
                createTable_CTPXH();

                txtTongSLXuat.Text = xuatHang.updateTongSoLuongXuat(strMaPhieuXuat).ToString();
                txtTongSLSanPham.Text = xuatHang.demSLMatHang(strMaPhieuXuat).ToString();
            }
            catch
            {
                MessageBox.Show("Quá trình xóa thất bại!");
            }
        }

        private void btnXoaPhieuXuat_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuXuat = txtMaPhieuXuat.Text.Trim();

                if (!conn.checkExist("PhieuXuatHang", "MaPXH", strMaPhieuXuat))
                {
                    MessageBox.Show("Chưa tồn tại phiếu xuất hàng này!");
                    return;
                }
                if (conn.checkExist("ChiTietPhieuXuatHang", "MaPXH", strMaPhieuXuat))
                {
                    MessageBox.Show("Phiếu xuất hàng " + strMaPhieuXuat + " đang được sử dụng ở bảng Chi tiết phiếu xuất hàng!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu xuất hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE PhieuXuatHang WHERE MaPXH='" + strMaPhieuXuat + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa phiếu xuất hàng thành công!");
                createTable_PhieuXuatHang();
            }
            catch
            {
                MessageBox.Show("Xóa phiếu xuất hàng thất bại!");
            }
        }

        private void btnTimKiemXuat_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("PhieuXuatHang", "MaPXH", txtTimKiemXuat.Text.Trim()))
            {
                dataGV_PhieuXuat.DataSource = xuatHang.searchPhieuXuatHang(txtTimKiemXuat.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu xuất hàng này!");
                createTable_PhieuXuatHang();
            }
        }

        private void btnXemXuat_Click(object sender, EventArgs e)
        {
            dataGV_PhieuXuat.DataSource = xuatHang.searchPhieuXuatHangTheoNgay(txtNgayDau.Text, txtNgayCuoi.Text);
        }

        //int laySoNgay()
        //{
        //    string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
        //    string strHanSuDung = loHang.layHanSuDung(strLoHang);
        //    DateTime ngayht = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    DateTime hsd = Convert.ToDateTime(strHanSuDung);
        //    TimeSpan Time = ngayht - hsd;
        //    int TongSoNgay = Time.Days;
        //    return TongSoNgay;
        //}

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.checkExist("LoHang", "MaSP", cbbSanPham.SelectedValue.ToString()))
            {
                cbbLoSanPham.DataSource = xuatHang.loadLoHangTheoSanPhamConHSD(cbbSanPham.SelectedValue.ToString());
                cbbLoSanPham.DisplayMember = "TenLo";
                cbbLoSanPham.ValueMember = "MaLo";
                if (cbbLoSanPham.Items.Count == 0)
                    cbbLoSanPham.Text = "";
            }
            else
            {
                cbbLoSanPham.DataSource = xuatHang.loadLoHangTheoSanPhamConHSD(cbbSanPham.SelectedValue.ToString());
                cbbLoSanPham.Text = "";
            }

            cbbDonViTinh.DataSource = xuatHang.loadDVTTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";
        }

        private void btnThemChiNhanh_Click(object sender, EventArgs e)
        {
            frmThemQuayHang quay = new frmThemQuayHang();
            quay.ShowDialog();
        }

        private void cbbQuayHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.checkExist("SanPham", "MaQuay", cbbQuayHang.SelectedValue.ToString()))
            {
                cbbSanPham.DataSource = sanPham.searchSanPhamTheoQuayHang(cbbQuayHang.SelectedValue.ToString());
                cbbSanPham.DisplayMember = "MaSP";
                cbbSanPham.ValueMember = "MaSP";
            }
            else
                loadComboBoxSanPham();
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_CTXK(dataGV_CTPhieuXuat, saveFileDialog1.FileName);
        }
        private void exportExcel_CTXK(DataGridView dv, string fileName)
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
                worksheet.Name = "CT phiếu xuất kho";

                worksheet.Cells[2, 2] = "CHI TIẾT PHIẾU XUẤT KHO";

                worksheet.Cells[4, 3] = "Ngày xuất:                  " + txtNgayXuat.Text;
                worksheet.Cells[5, 3] = "Mã nhân viên:             " + cbbNhanVien.Text;
                worksheet.Cells[7, 3] = "Chi nhánh:                  " + cbbChiNhanh.Text;
                worksheet.Cells[6, 3] = "Quầy hàng:                 " + cbbQuayHang.Text;

                for (int i = 0; i < dataGV_CTPhieuXuat.ColumnCount; i++)
                {
                    worksheet.Cells[9, i + 1] = dataGV_CTPhieuXuat.Columns[i].HeaderText;
                }

                int tkshh = dataGV_CTPhieuXuat.RowCount;

                for (int i = 0; i < dataGV_CTPhieuXuat.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_CTPhieuXuat.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 10, j + 1] = dataGV_CTPhieuXuat.Rows[i].Cells[j].Value.ToString();
                    }
                }

                worksheet.Cells[tkshh + 11, 3] = "Tổng số lượng xuất: " + txtTongSLXuat.Text;
                worksheet.Range["A" + (tkshh + 11), "G" + (tkshh + 11)].Font.Bold = true;

                worksheet.Cells[tkshh + 12, 3] = "Tổng số lượng SP:    " + txtTongSLSanPham.Text;
                worksheet.Range["A" + (tkshh + 12), "G" + (tkshh + 12)].Font.Bold = true;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 10;
                worksheet.Range["B1"].ColumnWidth = 13.89;
                worksheet.Range["C1"].ColumnWidth = 22.44;
                worksheet.Range["D1"].ColumnWidth = 13.67;
                worksheet.Range["E1"].ColumnWidth = 52.22;
                worksheet.Range["F1"].ColumnWidth = 14.78;
                worksheet.Range["G1"].ColumnWidth = 16.44;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A3", "G3"].MergeCells = true;
                worksheet.Range["A3", "G3"].Font.Italic = true;
                worksheet.Range["A3", "G3"].Font.Size = 15;

                worksheet.Range["A9", "G9"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A9", "G" + (tkshh + 9)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A9", "G9"].HorizontalAlignment = 3;
                worksheet.Range["A10", "A" + (tkshh + 10)].HorizontalAlignment = 3;
                worksheet.Range["D10", "D" + (tkshh + 10)].HorizontalAlignment = 3;
                worksheet.Range["F10", "F" + (tkshh + 10)].HorizontalAlignment = 3;
                worksheet.Range["G10", "G" + (tkshh + 10)].HorizontalAlignment = 3;

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

        private void btnInAllXuat_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_XK(dataGV_PhieuXuat, saveFileDialog1.FileName);
        }
        private void exportExcel_XK(DataGridView dv, string fileName)
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
                worksheet.Name = "Phiếu xuất kho";

                worksheet.Cells[2, 2] = "PHIẾU XUẤT KHO";

                worksheet.Cells[3, 2] = "Từ " + txtNgayDau.Text + "đến " + txtNgayCuoi.Text;

                for (int i = 0; i < dataGV_PhieuXuat.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 2] = dataGV_PhieuXuat.Columns[i].HeaderText;
                }

                int tkshh = dataGV_PhieuXuat.RowCount;

                for (int i = 0; i < dataGV_PhieuXuat.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_PhieuXuat.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 2] = dataGV_PhieuXuat.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                //worksheet.Range["A1"].ColumnWidth =  7.11;
                worksheet.Range["B1"].ColumnWidth = 16.78;
                worksheet.Range["C1"].ColumnWidth = 20.22;
                worksheet.Range["D1"].ColumnWidth = 16.78;
                worksheet.Range["E1"].ColumnWidth = 17.56;
                worksheet.Range["F1"].ColumnWidth = 13.67;
                //worksheet.Range["G1"].ColumnWidth = 10.56;

                //Định dạng fone chữ
                worksheet.Range["B1", "F100"].Font.Name = "Times New Roman";
                worksheet.Range["B1", "F100"].Font.Size = 13;
                worksheet.Range["B2", "F2"].MergeCells = true;
                worksheet.Range["B2", "F2"].Font.Bold = true;
                worksheet.Range["B2", "F2"].Font.Size = 15;

                worksheet.Range["B3", "F3"].MergeCells = true;
                worksheet.Range["B3", "F3"].Font.Italic = true;
                worksheet.Range["B3", "F3"].Font.Size = 15;

                worksheet.Range["B5", "F5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["B5", "F" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["B2", "F2"].HorizontalAlignment = 3;
                worksheet.Range["B3", "F3"].HorizontalAlignment = 3;
                worksheet.Range["B5", "F5"].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["F6", "F" + (tkshh + 6)].HorizontalAlignment = 3;

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
