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
            cbbDonViTinh.Enabled = cbbNhanVien.Enabled = false;
            txtMaPhieuNhap.Enabled = false;
            txtThanhToan.Enabled = txtTienNo.Enabled = txtTongSoLuong.Enabled = txtTongTienNhap.Enabled = txtTienTraThem.Enabled = txtLayNoCu.Enabled = false;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
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
                string strHinhThuc = "";
                if (radTienMat.Checked)
                    strHinhThuc = "1";
                else if (radThe.Checked)
                    strHinhThuc = "2";
                else
                    strHinhThuc = "3";
                string strThanhToan = txtThanhToan.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongNhap = txtSoLuongNhap.Text.Trim();
                string strGiaNhap = txtGiaNhap.Text.Trim();
                if (strSoLuongNhap == string.Empty)
                {
                    txtSoLuongNhap.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongNhap) * int.Parse(strGiaNhap));
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                string strConNo = txtTienNo.Text.Trim();

                if(!conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    if (kiemTraNgayNhapVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày nhập phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    string strSqlISPN = "INSERT PhieuNhapHang VALUES('" + strNgayNhap + "', " + strTongTienNhap + ", '" + strNhanVien + "', '" + strNhaCungCap + "', '" + strChiNhanh + "', " + strThanhToan + ", " + strConNo + ", '" + strHinhThuc + "')";
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
                    if(int.Parse(sanPham.layGiaVon(strSanPham)) != int.Parse(strGiaNhap))
                    {
                        string strSQLSP = "UPDATE SanPham SET GiaVon=" + strGiaNhap + " WHERE MaSP='" + strSanPham + "'";
                        conn.updateToDatabase(strSQLSP);
                    }
                    string strSqlCTPN = "INSERT ChiTietPhieuNhapHang VALUES('" + strMaPhieuNhap + "', '" + strSanPham + "', " + strSoLuongNhap + ", " + strGiaNhap + ", " + thanhTien + ")";
                    conn.updateToDatabase(strSqlCTPN);
                    createTable_ChiTietPhieuNhap();
                    MessageBox.Show("Lưu chi tiết phiếu nhập thành công!");

                    txtTongSoLuong.Text = nhapKho.updateTongSoLuong(strMaPhieuNhap).ToString();
                    strTongTienNhap = nhapKho.updateTongTien(strMaPhieuNhap).ToString();
                    txtTongTienNhap.Text = strTongTienNhap;
                    int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                    txtTienNo.Text = String.Format("{0:0,0}", conNo);
                    string strSqlUDNo = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(ncc.layCongNo(strNhaCungCap)) + int.Parse(nhapKho.layThanhTienCTPN(strMaPhieuNhap, strSanPham))) + " WHERE MaNCC='" + strNhaCungCap + "'";
                    conn.updateToDatabase(strSqlUDNo);
                    string strSqlUDPN = "UPDATE PhieuNhapHang SET TongTienNhap=" + strTongTienNhap + ", ThanhToan=" + strThanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                    conn.updateToDatabase(strSqlUDPN);
                    createTable_PhieuNhap();
                }
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại!");
            }
            txtTienTraThem.Enabled = false;
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
            cbbNhanVien.Text = frmDangNhap.maNV;
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
            txtTienTraThem.Enabled = false;
            btnLuuPN.Enabled = true;
            btnThanhToan.Enabled = btnLuuNo.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string strNhaCungCap = cbbNhaCungCap.SelectedValue.ToString();
                string strMaPhieuNhap = txtMaPhieuNhap.Text.Trim();
                int thanhToan = int.Parse(txtThanhToan.Text.Trim()) + int.Parse(txtTienTraThem.Text.Trim());
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                int conNo = int.Parse(strTongTienNhap) - thanhToan;
                if(conNo < 0)
                {
                    MessageBox.Show("Bạn đã trả dư tiền cho phiếu nhập hàng này!");
                    return;
                }
                txtThanhToan.Text = thanhToan.ToString();
                txtTienNo.Text = String.Format("{0:0,0}", conNo);
                //txtTienNo.Text = conNo.ToString();
                //string strSqlUDNo = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(ncc.layCongNo(strNhaCungCap)) - int.Parse(txtTienTraThem.Text.Trim())) + " WHERE MaNCC='" + strNhaCungCap + "'";
                //conn.updateToDatabase(strSqlUDNo);
                string strSqlUDPN = "UPDATE PhieuNhapHang SET ThanhToan=" + thanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
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
            if (dataGV_PhieuNhap.Rows[index].Cells[8].Value.ToString() == "1")
            {
                radTienMat.Checked = true;
                radThe.Checked = radChuyenKhoan.Checked = false;
            }
            else if (dataGV_PhieuNhap.Rows[index].Cells[8].Value.ToString() == "2")
            {
                radThe.Checked = true;
                radTienMat.Checked = radChuyenKhoan.Checked = false;
            }
            else
            {
                radChuyenKhoan.Checked = true;
                radTienMat.Checked = radThe.Checked = false;
            }
            string a = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuNhap.DataSource = nhapKho.layCTPN(a);
            //string b = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHangHoaNhap.DataSource = nhapKho.layChiTietPhieuNhap(a);
            btnSuaPN.Enabled = btnXoaPhieuNhap.Enabled = true;
            btnThanhToan.Enabled = false;
            txtTienTraThem.Enabled = true;
            txtThanhToan.Enabled = false;
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
                string strHinhThuc = "";
                if (radTienMat.Checked)
                    strHinhThuc = "1";
                else if (radThe.Checked)
                    strHinhThuc = "2";
                else
                    strHinhThuc = "3";
                string strThanhToan = txtThanhToan.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongNhap = txtSoLuongNhap.Text.Trim();
                string strGiaNhap = txtGiaNhap.Text.Trim();
                if (strSoLuongNhap == string.Empty)
                {
                    txtSoLuongNhap.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongNhap) * int.Parse(strGiaNhap));
                string strTongTienNhap = txtTongTienNhap.Text.Trim();
                string strConNo = txtTienNo.Text.Trim();

                if (!conn.checkExist("PhieuNhapHang", "MaPNH", strMaPhieuNhap))
                {
                    MessageBox.Show("Mã phiếu nhập không tồn tại!");
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
                string strSqlPN = "UPDATE PhieuNhapHang SET NgayNhap='" + strNgayNhap + "', MaHT='" + strHinhThuc + "', MaNCC='" + strNhaCungCap + "', MaChiNhanh='" + strChiNhanh + "' WHERE MaPNH='" + strMaPhieuNhap + "'";
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
                if (int.Parse(sanPham.layGiaVon(strSanPham)) != int.Parse(strGiaNhap))
                {
                    string strSQLSP = "UPDATE SanPham SET GiaVon=" + strGiaNhap + " WHERE MaSP='" + strSanPham + "'";
                    conn.updateToDatabase(strSQLSP);
                }
                string strSqlUDNo = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(ncc.layCongNo(strNhaCungCap)) - int.Parse(nhapKho.layThanhTienCTPN(strMaPhieuNhap, strSanPham))) + " WHERE MaNCC='" + strNhaCungCap + "'";
                conn.updateToDatabase(strSqlUDNo);
                string strSqlCTPN = "UPDATE ChiTietPhieuNhapHang SET SoLuong=" + strSoLuongNhap + ", DonGia=" + strGiaNhap + ", ThanhTien=" + thanhTien + " WHERE MaPNH='" + strMaPhieuNhap + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlCTPN);
                createTable_ChiTietPhieuNhap();
                MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công!");
                string strSqlUD = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(ncc.layCongNo(strNhaCungCap)) + int.Parse(nhapKho.layThanhTienCTPN(strMaPhieuNhap, strSanPham))) + " WHERE MaNCC='" + strNhaCungCap + "'";
                conn.updateToDatabase(strSqlUD);

                txtTongSoLuong.Text = nhapKho.updateTongSoLuong(strMaPhieuNhap).ToString();
                strTongTienNhap = nhapKho.updateTongTien(strMaPhieuNhap).ToString();
                txtTongTienNhap.Text = strTongTienNhap;
                int conNo = int.Parse(strTongTienNhap) - int.Parse(strThanhToan);
                txtTienNo.Text = String.Format("{0:0,0}", conNo);
                string strSqlUDPN = "UPDATE PhieuNhapHang SET TongTienNhap=" + strTongTienNhap + ", ThanhToan=" + strThanhToan + ", ConNo=" + conNo + " WHERE MaPNH='" + strMaPhieuNhap + "'";
                conn.updateToDatabase(strSqlUDPN);
                createTable_PhieuNhap();
                btnSuaPN.Enabled = false;
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
                string strNhaCungCap = cbbNhaCungCap.SelectedValue.ToString().Trim();
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
                string strSqlUDNo = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(ncc.layCongNo(strNhaCungCap)) - int.Parse(nhapKho.layThanhTienCTPN(strMaPhieuNhap, strSanPham))) + " WHERE MaNCC='" + strNhaCungCap + "'";
                conn.updateToDatabase(strSqlUDNo);
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
                btnXoaCTPN.Enabled = false;
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
                btnXoaPhieuNhap.Enabled = false;
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
            try
            {
                string strMaNCC = cbbNhaCungCap.SelectedValue.ToString();
                int tienTra = int.Parse(txtTienTraThem.Text);
                int congNo = int.Parse(ncc.layCongNo(strMaNCC));
                if (congNo - tienTra > 0)
                {
                    string strSQL = "UPDATE NhaCungCap SET CongNo=" + (congNo - tienTra) + " WHERE MaNCC='" + strMaNCC + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Lưu nợ thành công!");
                    txtLayNoCu.Text = ncc.layCongNo(strMaNCC);
                    btnLuuNo.Enabled = false;
                    txtTienTraThem.Text = "0";
                    txtTienTraThem.Enabled = false;
                }
                else
                {
                    string strSQL = "UPDATE NhaCungCap SET CongNo=" + txtTienNo.Text + " WHERE MaNCC='" + strMaNCC + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Lưu nợ thành công!");
                    txtLayNoCu.Text = "0";
                    btnLuuNo.Enabled = false;
                    txtTienTraThem.Text = "0";
                    txtTienTraThem.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Lưu nợ thất bại!");
            }
        }

        private void btnLayNoCu_Click(object sender, EventArgs e)
        {
            string strCongNo = ncc.layCongNo(cbbNhaCungCap.SelectedValue.ToString().Trim());
            txtLayNoCu.Text = strCongNo;
            //string strSQL = "UPDATE NhaCungCap SET CongNo=" + strCongNo + " WHERE MaNCC='" + cbbNhaCungCap.SelectedValue.ToString().Trim() + "'";
            //conn.updateToDatabase(strSQL);
            btnThanhToan.Enabled = true;
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_CTNK(dataGV_CTPhieuNhap, saveFileDialog1.FileName);
        }
        private void exportExcel_CTNK(DataGridView dv, string fileName)
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
                worksheet.Name = "CT phiếu nhập kho";

                worksheet.Cells[2, 2] = "CHI TIẾT PHIẾU NHẬP KHO";

                worksheet.Cells[4, 3] = "Ngày nhập:                 " + txtNgayNhap.Text;
                worksheet.Cells[5, 3] = "Mã nhân viên:             " + cbbNhanVien.Text;
                worksheet.Cells[6, 3] = "Chi nhánh:                  " + cbbChiNhanh.Text;
                worksheet.Cells[7, 3] = "Nhà cung cấp:             " + cbbNhaCungCap.Text;
                if (radChuyenKhoan.Checked)
                    worksheet.Cells[8, 3] = "Hình thức thanh toán: " + radChuyenKhoan.Text;
                else if (radThe.Checked)
                    worksheet.Cells[8, 3] = "Hình thức thanh toán: " + radThe.Text;
                else if (radTienMat.Checked)
                    worksheet.Cells[8, 3] = "Hình thức thanh toán: " + radTienMat.Text;



                for (int i = 0; i < dataGV_CTPhieuNhap.ColumnCount; i++)
                {
                    worksheet.Cells[10, i + 1] = dataGV_CTPhieuNhap.Columns[i].HeaderText;
                }

                int tkshh = dataGV_CTPhieuNhap.RowCount;

                for (int i = 0; i < dataGV_CTPhieuNhap.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_CTPhieuNhap.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 11, j + 1] = dataGV_CTPhieuNhap.Rows[i].Cells[j].Value.ToString();
                    }
                }

                worksheet.Cells[tkshh + 12, 3] = "Tổng số lượng SP:    " + txtTongSoLuong.Text;
                //worksheet.Cells[tkshh + 12, 4] = txtTongSoLuong.Text;
                worksheet.Range["A" + (tkshh + 12), "G" + (tkshh + 12)].Font.Bold = true;

                worksheet.Cells[tkshh + 13, 3] = "Tổng tiền nhập:        " + txtTongTienNhap.Text;
                //worksheet.Cells[tkshh + 13, 4] = txtTongTienNhap.Text;
                worksheet.Range["A" + (tkshh + 13), "G" + (tkshh + 13)].Font.Bold = true;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 8.33;
                worksheet.Range["B1"].ColumnWidth = 9.67;
                worksheet.Range["C1"].ColumnWidth = 35.78;
                worksheet.Range["D1"].ColumnWidth = 9.89;
                worksheet.Range["E1"].ColumnWidth = 9.11;
                worksheet.Range["F1"].ColumnWidth = 12.56;
                worksheet.Range["G1"].ColumnWidth = 14.33;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A3", "G3"].MergeCells = true;
                worksheet.Range["A3", "G3"].Font.Italic = true;
                worksheet.Range["A3", "G3"].Font.Size = 15;

                worksheet.Range["A10", "G10"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A10", "G" + (tkshh + 10)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A10", "G10"].HorizontalAlignment = 3;
                worksheet.Range["A11", "A" + (tkshh + 11)].HorizontalAlignment = 3;
                worksheet.Range["D11", "D" + (tkshh + 11)].HorizontalAlignment = 3;
                worksheet.Range["E11", "E" + (tkshh + 11)].HorizontalAlignment = 3;

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

        private void btnInAllNhap_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_NK(dataGV_PhieuNhap, saveFileDialog1.FileName);
        }
        private void exportExcel_NK(DataGridView dv, string fileName)
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
                worksheet.Name = "Phiếu nhập kho";

                worksheet.Cells[2, 2] = "PHIẾU NHẬP KHO";

                worksheet.Cells[3, 2] = "Từ " + txtNgayDau.Text + "đến " + txtNgayCuoi.Text;

                for (int i = 0; i < dataGV_PhieuNhap.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_PhieuNhap.Columns[i].HeaderText;
                }

                int tkshh = dataGV_PhieuNhap.RowCount;

                for (int i = 0; i < dataGV_PhieuNhap.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_PhieuNhap.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_PhieuNhap.Rows[i].Cells[j].Value.ToString();
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
                worksheet.Range["A1"].ColumnWidth = 15.56;
                worksheet.Range["B1"].ColumnWidth = 16.56;
                worksheet.Range["C1"].ColumnWidth = 19.89;
                worksheet.Range["D1"].ColumnWidth = 15.11;
                worksheet.Range["E1"].ColumnWidth = 18.56;
                worksheet.Range["F1"].ColumnWidth = 15;
                worksheet.Range["G1"].ColumnWidth = 14.33;
                worksheet.Range["H1"].ColumnWidth = 12.56;
                worksheet.Range["I1"].ColumnWidth = 14.33;

                //Định dạng fone chữ
                worksheet.Range["A1", "I100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "I100"].Font.Size = 13;
                worksheet.Range["A2", "I2"].MergeCells = true;
                worksheet.Range["A2", "I2"].Font.Bold = true;
                worksheet.Range["A2", "I2"].Font.Size = 15;

                worksheet.Range["A3", "I3"].MergeCells = true;
                worksheet.Range["A3", "I3"].Font.Italic = true;
                worksheet.Range["A3", "I3"].Font.Size = 15;

                worksheet.Range["A5", "I5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "I" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "I2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "I3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "I5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
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
