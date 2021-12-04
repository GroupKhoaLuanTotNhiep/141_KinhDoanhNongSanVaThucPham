using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_NhapKho : UserControl
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        ChiNhanh chiNhanh = new ChiNhanh();
        NhaCungCap ncc = new NhaCungCap();
        SanPham sanPham = new SanPham();
        NhapKho nhapKho = new NhapKho();
        public static string maNCC = "";
        public static string tienNo = "";
        public static string layNoCu = "";

        public UC_NhapKho()
        {
            InitializeComponent();
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void loadComboBoxChiNhanh()
        {
            cbbChiNhanh.DataSource = chiNhanh.loadChiNhanh();
            cbbChiNhanh.DisplayMember = "TenChiNhanh";
            cbbChiNhanh.ValueMember = "MaChiNhanh";
        }

        void loadComboBoxNhaCungCap()
        {
            cbbNhaCungCap.DataSource = ncc.loadNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
        }

        void loadComboBoxSanPham()
        {
            cbbSanPham.DataSource = sanPham.loadSanPham();
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        void createTable_PhieuNhap()
        {
            dataGV_PhieuNhap.DataSource = nhapKho.loadDataGV_PhieuNhap();
        }

        void createTable_ChiTietPhieuNhap()
        {
            dataGV_CTHangHoaNhap.DataSource = nhapKho.loadDataGV_CTPNTheoMaPN(txtMaPhieuNhap.Text);
        }

        private void UC_NhapKho_Load(object sender, EventArgs e)
        {
            createTable_ChiTietPhieuNhap();
            //loadComboBoxNhanVien();
            cbbNhanVien.Text = frmDangNhap.maNV;
            loadComboBoxChiNhanh();
            loadComboBoxNhaCungCap();
            loadComboBoxSanPham();
            createTable_PhieuNhap();
            btnThanhToan.Enabled = btnLuuNo.Enabled = btnLuuPN.Enabled = btnXoaCTPN.Enabled = btnSuaPN.Enabled = false;
            btnXoaPhieuNhap.Enabled = false;
            cbbDonViTinh.Enabled = false;
            txtMaPhieuNhap.Enabled = false;
            txtTienNo.Enabled = txtTongSoLuong.Enabled = txtTongTienNhap.Enabled = false;
            radTienMat.Checked = true;
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = nhapKho.loadDonViTinhTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";

            txtGiaNhap.Text = nhapKho.layGiaNhapTheoSanPham(cbbSanPham.SelectedValue.ToString());
        }

        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public bool kiemTraNgayNhapVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayNhap = DateTime.ParseExact(txtNgayNhap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayNhap).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strNgayNhap).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strNgayNhap).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                string strNgayNhap = DateTime.ParseExact(txtNgayNhap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strNhaCungCap = cbbNhaCungCap.SelectedValue.ToString().Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strThanhToan = txtThanhToan.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongNhap = txtSoLuongNhap.Text.Trim();
                string strGiaNhap = txtGiaNhap.Text.Trim();
                if (strSoLuongNhap == string.Empty)
                {
                    txtSoLuongNhap.Focus();
                    return;
                }
                int thanhTien = int.Parse(strSoLuongNhap) * int.Parse(strGiaNhap);
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                string strConNo = txtTienNo.Text.Trim();

                if(!conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    if (kiemTraNgayNhapVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày nhập phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    string strSqlISPN = "INSERT PhieuNhapHang VALUES('" + strNgayNhap + "', " + strTongTienNhap + ", '" + strNhanVien + "', '" + strNhaCungCap + "', '" + strChiNhanh + "', " + strThanhToan + ", " + strConNo + ")";
                    conn.updateToDatabase(strSqlISPN);
                    createTable_PhieuNhap();
                    MessageBox.Show("Lưu phiếu nhập thành công!");
                    txtMaPhieuNhap.Text = nhapKho.layMaPNH();
                }
                if(conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    if(!conn.checkExist("SanPham", "MaSP", strSanPham))
                    {
                        MessageBox.Show("Sản phẩm này chưa tồn tại!");
                        return;
                    }
                    if(conn.checkExistTwoKey("ChiTietPhieuNhapHang", "MaPNH", "MaSP", strMaPhieuNhap, strSanPham))
                    {
                        MessageBox.Show("Trùng khóa chính rồi!");
                        return;
                    }
                    string strSqlCTPN = "INSERT ChiTietPhieuNhapHang VALUES('" + strMaPhieuNhap + "', '" + strSanPham + "', " + strSoLuongNhap + ", " + strGiaNhap + ", " + thanhTien + ")";
                    conn.updateToDatabase(strSqlCTPN);
                    createTable_ChiTietPhieuNhap();
                    MessageBox.Show("Lưu chi tiết phiếu nhập thành công!");
                }
                txtTongSoLuong.Text = nhapKho.updateTongSoLuong(strMaPhieuNhap).ToString();
                strTongTienNhap = nhapKho.updateTongTien(strMaPhieuNhap).ToString();
                txtTongTienNhap.Text = strTongTienNhap;
                int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                txtTienNo.Text = String.Format("{0:0,0}", conNo);
                string strSqlUDPN = "UPDATE PhieuNhapHang SET TongTienNhap=" + strTongTienNhap + ", ThanhToan=" + strThanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlUDPN);
                createTable_PhieuNhap();
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại!");
            }
            btnXoaCTPN.Enabled = btnSuaPN.Enabled = false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Clear();
            txtNgayNhap.Text = DateTime.Now.ToString();
            txtTongTienNhap.Text = "0";
            txtThanhToan.Text = "0";
            txtTienNo.Text = "0";
            txtTongSoLuong.Clear();
            //cbbNhanVien.SelectedIndex = 0;
            cbbChiNhanh.SelectedIndex = 0;
            cbbNhaCungCap.SelectedIndex = 0;
            cbbSanPham.SelectedIndex = 0;
            cbbDonViTinh.Text = "";
            txtSoLuongNhap.Clear();
            txtGiaNhap.Clear();
            loadComboBoxNhaCungCap();
            loadComboBoxSanPham();
            createTable_ChiTietPhieuNhap();
            dataGV_CTPhieuNhap.DataSource = nhapKho.layCTPN(txtMaPhieuNhap.Text);
            btnLuuPN.Enabled = true;
            btnThanhToan.Enabled = btnLuuNo.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                string strThanhToan = txtThanhToan.Text.Trim();
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                string strConNo = conNo.ToString();
                //txtTienNo.Text = String.Format("{0:0,0}", conNo);
                txtTienNo.Text = strConNo;
                string strSqlUDPN = "UPDATE PhieuNhapHang SET ThanhToan=" + strThanhToan + ", ConNo=" + strConNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlUDPN);
                createTable_PhieuNhap();
                MessageBox.Show("Thanh toán thành công!");
                btnLuuNo.Enabled = true;
                btnThanhToan.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại!");
            }
        }

        private void dataGV_CTHangHoaNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuNhap.Text = dataGV_CTHangHoaNhap.Rows[index].Cells[0].Value.ToString();
            cbbSanPham.Text = dataGV_CTHangHoaNhap.Rows[index].Cells[1].Value.ToString();
            txtSoLuongNhap.Text = dataGV_CTHangHoaNhap.CurrentRow.Cells[2].Value.ToString();
            txtGiaNhap.Text = dataGV_CTHangHoaNhap.Rows[index].Cells[3].Value.ToString();
            btnXoaCTPN.Enabled = btnSuaPN.Enabled = true;
        }

        private void dataGV_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuNhap.Text = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            txtNgayNhap.Text = dataGV_PhieuNhap.Rows[index].Cells[1].Value.ToString();
            txtTongTienNhap.Text = dataGV_PhieuNhap.Rows[index].Cells[2].Value.ToString();
            cbbNhanVien.Text = dataGV_PhieuNhap.Rows[index].Cells[3].Value.ToString();
            cbbNhaCungCap.Text = ncc.layTenNhaCC(dataGV_PhieuNhap.Rows[index].Cells[4].Value.ToString());
            cbbChiNhanh.Text = chiNhanh.layTenChiNhanh(dataGV_PhieuNhap.Rows[index].Cells[5].Value.ToString());
            txtThanhToan.Text = dataGV_PhieuNhap.Rows[index].Cells[6].Value.ToString();
            txtTienNo.Text = dataGV_PhieuNhap.Rows[index].Cells[7].Value.ToString();
            string a = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuNhap.DataSource = nhapKho.layCTPN(a);
            //string b = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHangHoaNhap.DataSource = nhapKho.layChiTietPhieuNhap(a);
            btnSuaPN.Enabled = btnXoaPhieuNhap.Enabled = true;

            txtTongSoLuong.Text = nhapKho.updateTongSoLuong(a).ToString();
        }

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                string strNgayNhap = DateTime.ParseExact(txtNgayNhap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strNhaCungCap = cbbNhaCungCap.SelectedValue.ToString().Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strThanhToan = txtThanhToan.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongNhap = txtSoLuongNhap.Text.Trim();
                string strGiaNhap = txtGiaNhap.Text.Trim();
                if (strSoLuongNhap == string.Empty)
                {
                    txtSoLuongNhap.Focus();
                    return;
                }
                int thanhTien = int.Parse(strSoLuongNhap) * int.Parse(strGiaNhap);
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                string strConNo = txtTienNo.Text.Trim();

                if (!conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    MessageBox.Show("Mã phiếu nhập không tồn tại!");
                    return;
                }

                if (!conn.checkExist("NhanVien", "MaNV", strNhanVien))
                {
                    MessageBox.Show("Nhân viên này chưa tồn tại!");
                    return;
                }
                if (!conn.checkExist("NhaCungCap", "MaNCC", strNhaCungCap))
                {
                    MessageBox.Show("Nhà cung cấp này chưa tồn tại!");
                    return;
                }
                if (!conn.checkExist("ChiNhanh", "MaChiNhanh", strChiNhanh))
                {
                    MessageBox.Show("Chi nhánh này chưa tồn tại!");
                    return;
                }
                string strSqlPN = "UPDATE PhieuNhapHang SET NgayNhap='" + strNgayNhap + "', MaNV='" + strNhanVien + "', MaNCC='" + strNhaCungCap + "', MaChiNhanh='" + strChiNhanh + "' WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlPN);
                createTable_PhieuNhap();
                MessageBox.Show("Cập nhật phiếu nhập thành công!");

                if (!conn.checkExistTwoKey("ChiTietPhieuNhapHang", "MaPNH", "MaSP", strMaPhieuNhap, strSanPham))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if(conn.checkExistTwoKey("LoHang", "MaPNH", "MaSP", strMaPhieuNhap, strSanPham))
                {
                    MessageBox.Show("Đã thêm vào thông tin lô hàng nên không thể cập nhật!");
                    return;
                }
                string strSqlCTPN = "UPDATE ChiTietPhieuNhapHang SET SoLuong=" + strSoLuongNhap + ", DonGia=" + strGiaNhap + ", ThanhTien=" + thanhTien + " WHERE MaPNH='" + strMaPhieuNhap + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlCTPN);
                createTable_ChiTietPhieuNhap();
                MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công!");

                txtTongSoLuong.Text = nhapKho.updateTongSoLuong(strMaPhieuNhap).ToString();
                strTongTienNhap = nhapKho.updateTongTien(strMaPhieuNhap).ToString();
                txtTongTienNhap.Text = strTongTienNhap;
                int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                txtTienNo.Text = String.Format("{0:0,0}", conNo);
                string strSqlUDPN = "UPDATE PhieuNhapHang SET TongTienNhap=" + strTongTienNhap + ", ThanhToan=" + strThanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlUDPN);
                createTable_PhieuNhap();
            }
            catch
            {
                MessageBox.Show("Quá trình cập nhật thất bại!");
            }
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                string strThanhToan = txtThanhToan.Text.Trim();

                if (!conn.checkExistTwoKey("ChiTietPhieuNhapHang", "MaPNH", "MaSP", strMaPhieuNhap, strSanPham))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (conn.checkExistTwoKey("LoHang", "MaPNH", "MaSP", strMaPhieuNhap, strSanPham))
                {
                    MessageBox.Show("Đã thêm vào thông tin lô hàng nên không thể xóa được!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết phiếu nhập hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE ChiTietPhieuNhapHang WHERE MaPNH='" + strMaPhieuNhap + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa chi tiết phiếu nhập thành công!");
                createTable_ChiTietPhieuNhap();

                txtTongSoLuong.Text = nhapKho.updateTongSoLuong(strMaPhieuNhap).ToString();
                strTongTienNhap = nhapKho.updateTongTien(strMaPhieuNhap).ToString();
                txtTongTienNhap.Text = strTongTienNhap;
                int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                txtTienNo.Text = String.Format("{0:0,0}", conNo);
                string strSqlUDPN = "UPDATE PhieuNhapHang SET TongTienNhap=" + strTongTienNhap + ", ThanhToan=" + strThanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlUDPN);
                createTable_PhieuNhap();
            }
            catch
            {
                MessageBox.Show("Xóa chi tiết phiếu nhập thất bại!");
            }
        }

        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();

                if (!conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    MessageBox.Show("Chưa tồn tại phiếu nhập hàng này!");
                    return;
                }
                if (conn.checkExist("ChiTietPhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    MessageBox.Show("Phiếu nhập hàng " + strMaPhieuNhap + " đang được sử dụng ở bảng Chi tiết phiếu nhập hàng!");
                    return;
                }
                if (conn.checkExist("LoHang", "MaPNH", strMaPhieuNhap))
                {
                    MessageBox.Show("Phiếu nhập hàng " + strMaPhieuNhap + " đang được sử dụng ở bảng Lô hàng!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu nhập hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE PhieuNhapHang WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa phiếu nhập thành công!");
                createTable_PhieuNhap();
            }
            catch
            {
                MessageBox.Show("Xóa phiếu nhập thất bại!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("PhieuNhapHang", "MaPNH", txtTimKiem.Text.Trim()))
            {
                dataGV_PhieuNhap.DataSource = nhapKho.searchPhieuNhap(txtTimKiem.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu nhập hàng!");
                createTable_PhieuNhap();
            }
        }

        private void btnThemTTLoHang_Click(object sender, EventArgs e)
        {
            frmThemLoHang themLo = new frmThemLoHang(txtMaPhieuNhap.Text.Trim(), cbbSanPham.Text.Trim(), txtSoLuongNhap.Text.Trim());
            themLo.ShowDialog();
        }

        private void dataGV_CTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuNhap.Text = dataGV_CTPhieuNhap.Rows[index].Cells[0].Value.ToString();
            cbbSanPham.Text = dataGV_CTPhieuNhap.Rows[index].Cells[1].Value.ToString();
            txtSoLuongNhap.Text = dataGV_CTPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            txtGiaNhap.Text = dataGV_CTPhieuNhap.Rows[index].Cells[5].Value.ToString();
            btnXoaCTPN.Enabled = btnSuaPN.Enabled = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dataGV_PhieuNhap.DataSource = nhapKho.searchPhieuNhapTheoNgay(txtNgayDau.Text, txtNgayCuoi.Text);
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            frmThemNCC ncc = new frmThemNCC();
            ncc.ShowDialog();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            frmThemHangHoa sp = new frmThemHangHoa();
            sp.ShowDialog();
        }

        private void btnLuuNo_Click(object sender, EventArgs e)
        {
            maNCC = cbbNhaCungCap.SelectedValue.ToString().Trim();
            tienNo = txtTienNo.Text.Trim();
            layNoCu = txtLayNoCu.Text.Trim();
            frmLuuNoNhaCungCap luuNo = new frmLuuNoNhaCungCap();
            luuNo.ShowDialog();
            btnLuuNo.Enabled = false;
        }

        private void btnLayNoCu_Click(object sender, EventArgs e)
        {
            string strCongNo = ncc.layCongNo(cbbNhaCungCap.SelectedValue.ToString().Trim());
            txtLayNoCu.Text = strCongNo;
            //string strSQL = "UPDATE NhaCungCap SET CongNo=" + strCongNo + " WHERE MaNCC='" + cbbNhaCungCap.SelectedValue.ToString().Trim() + "'";
            //conn.updateToDatabase(strSQL);
            btnThanhToan.Enabled = true;
        }

    }
}
