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
    public partial class UC_ThanhLy : UserControl
    {
        Connection conn = new Connection();
        ChiNhanh chiNhanh = new ChiNhanh();
        NhanVien nhanVien = new NhanVien();
        LoHang loHang = new LoHang();
        SanPham sanPham = new SanPham();
        ThanhLy thanhLy = new ThanhLy();

        public UC_ThanhLy()
        {
            InitializeComponent();
        }

        private void btnThanhLyNhapThem_Click(object sender, EventArgs e)
        {
            frmNhapKho nhapKho = new frmNhapKho();
            nhapKho.ShowDialog();
        }

        private void btnThanhLyXuatBan_Click(object sender, EventArgs e)
        {
            frmXuatKho xuatKho = new frmXuatKho();
            xuatKho.ShowDialog();
        }

        void loadComboBoxChiNhanh()
        {
            cbbChiNhanh.DataSource = chiNhanh.loadChiNhanh();
            cbbChiNhanh.DisplayMember = "TenChiNhanh";
            cbbChiNhanh.ValueMember = "MaChiNhanh";
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void loadComboBoxLoHang()
        {
            cbbLoSanPham.DataSource = loHang.loadLoHangHetHan();
            cbbLoSanPham.DisplayMember = "TenLo";
            cbbLoSanPham.ValueMember = "MaLo";
        }

        void loadComboBoxSanPham()
        {
            cbbSanPham.DataSource = sanPham.loadSanPham();
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        void loadComboBoxTinhTrang()
        {
            string[] tinhTrang = { "Đã thanh lý", "Chưa thanh lý" };
            foreach (string s in tinhTrang)
            {
                cbbTinhTrangTL.Items.Add(s);
            }
            cbbTinhTrangTL.SelectedIndex = 0;
        }

        void createTable_PhieuThanhLy()
        {
            dataGV_PhieuThanhLy.DataSource = thanhLy.loadDataGV_PhieuThanhLy();
        }

        void createTable_CTPTL()
        {
            dataGV_CTHangHoaThanhLy.DataSource = thanhLy.loadDataGV_CTPTLTheoMaPTL(txtMaPhieuThanhLy.Text);
        }

        private void UC_ThanhLy_Load(object sender, EventArgs e)
        {
            loadComboBoxChiNhanh();
            //loadComboBoxNhanVien();
            cbbNhanVien.Text = frmDangNhap.maNV;
            loadComboBoxLoHang();
            loadComboBoxSanPham();
            loadComboBoxTinhTrang();
            createTable_PhieuThanhLy();
            createTable_CTPTL();
            txtMaPhieuThanhLy.Enabled = false;
            txtSLThanhLy.Enabled = txtTongSLThanhLy.Enabled = txtTongSLSanPham.Enabled = false;
            cbbSanPham.Enabled = cbbDonViTinh.Enabled = false;
            btnLuuPTL.Enabled = btnSuaPTL.Enabled = btnXoaCTPTL.Enabled = btnXoaPhieuTL.Enabled = false;
        }

        private void cbbLoSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbSanPham.DataSource = thanhLy.loadSanPhamTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";

            cbbDonViTinh.DataSource = thanhLy.loadDVTTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";

            txtSLThanhLy.Text = loHang.laySoLuong(cbbLoSanPham.SelectedValue.ToString());
        }

        private void txtSLThanhLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuThanhLy.Clear();
            txtNgayThanhLy.Text = DateTime.Now.ToString();
            txtNgayKetThuc.Text = DateTime.Now.ToString();
            txtSLThanhLy.Clear();
            cbbChiNhanh.SelectedIndex = 0;
            //cbbNhanVien.SelectedIndex = 0;
            cbbLoSanPham.SelectedIndex = 0;
            cbbSanPham.Text = "";
            cbbDonViTinh.Text = "";
            cbbTinhTrangTL.SelectedIndex = 0;
            txtTongSLThanhLy.Text = "0";
            txtTongSLSanPham.Text = "0";
            createTable_CTPTL();
            btnLuuPTL.Enabled = true;
        }

        public bool kiemTraNgayThanhLyVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayThanhLy).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strNgayThanhLy).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strNgayThanhLy).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        public bool kiemTraNgayThanhLyVaNgayKetThuc()
        {
            string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayKetThuc = DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            int ngay = DateTime.Parse(strNgayKetThuc).Day - DateTime.Parse(strNgayThanhLy).Day;
            int thang = DateTime.Parse(strNgayKetThuc).Month - DateTime.Parse(strNgayThanhLy).Month;
            int nam = DateTime.Parse(strNgayKetThuc).Year - DateTime.Parse(strNgayThanhLy).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuPTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();
                string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNgayKetThuc = DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuong = txtSLThanhLy.Text.Trim();
                if (strSoLuong == string.Empty)
                {
                    txtSLThanhLy.Focus();
                    return;
                }
                string strTinhTrangTL = cbbTinhTrangTL.Text.Trim();

                if (!conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    if (kiemTraNgayThanhLyVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày thanh lý phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                    {
                        MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                        return;
                    }
                    string strSqlPTL = "INSERT PhieuThanhLy VALUES('" + strNgayThanhLy + "', '" + strNhanVien + "', '" + strChiNhanh + "')";
                    conn.updateToDatabase(strSqlPTL);
                    createTable_PhieuThanhLy();
                    MessageBox.Show("Lưu phiếu thanh lý thành công!");
                    txtMaPhieuThanhLy.Text = thanhLy.layMaPTL();
                }
                if (conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                    {
                        MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                        return;
                    }
                    if (!conn.checkExist("LoHang", "MaLo", strLoHang))
                    {
                        MessageBox.Show("Lô hàng này chưa tồn tại!");
                        return;
                    }
                    if (conn.checkExistTwoKey("ChiTietPhieuThanhLy", "MaPTL", "MaLo", strMaPTL, strLoHang))
                    {
                        MessageBox.Show("Trùng khóa chính rồi!");
                        return;
                    }
                    //if (int.Parse(strSoLuong) > int.Parse(loHang.laySoLuong(strLoHang)))
                    //{
                    //    MessageBox.Show("Số lượng thanh lý phải nhỏ hơn hoặc bằng số lượng có trong lô (" + int.Parse(loHang.laySoLuong(strLoHang)) + ")!");
                    //    return;
                    //}
                    string strSqlCTPTL = "INSERT ChiTietPhieuThanhLy VALUES('" + strMaPTL + "', '" + strLoHang + "', " + strSoLuong + ", '" + strNgayKetThuc + "', N'" + strTinhTrangTL + "')";
                    conn.updateToDatabase(strSqlCTPTL);
                    createTable_CTPTL();
                    MessageBox.Show("Lưu chi tiết phiếu thanh lý thành công!");
                }
                txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                txtTongSLSanPham.Text = thanhLy.demSLMatHang(strMaPTL).ToString();
                //string strSqlUDCTPTL = "UPDATE ChiTietPhieuThanhLy SET SoLuong=" + int.Parse(loHang.laySoLuong(strLoHang)) + " WHERE MaPTL='" +  strMaPTL + "' AND MaLo='" + strLoHang + "'";
                //conn.updateToDatabase(strSqlUDCTPTL);
                //createTable_CTPTL();
                //txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + 0 + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDLH);
                string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (int.Parse(thanhLy.laySoLuongSanPham(strSanPham)) - int.Parse(strSoLuong)) + " WHERE MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDSP);
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại!");
            }
        }

        private void dataGV_CTHangHoaThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuThanhLy.Text = dataGV_CTHangHoaThanhLy.Rows[index].Cells[0].Value.ToString();
            cbbLoSanPham.Text = loHang.layTenLoHang(dataGV_CTHangHoaThanhLy.Rows[index].Cells[1].Value.ToString());
            cbbSanPham.Text = dataGV_CTHangHoaThanhLy.Rows[index].Cells[2].Value.ToString();
            txtSLThanhLy.Text = dataGV_CTHangHoaThanhLy.CurrentRow.Cells[3].Value.ToString();
            txtNgayKetThuc.Text = dataGV_CTHangHoaThanhLy.Rows[index].Cells[4].Value.ToString();
            cbbTinhTrangTL.Text = dataGV_CTHangHoaThanhLy.Rows[index].Cells[5].Value.ToString();
            btnXoaCTPTL.Enabled = btnSuaPTL.Enabled = true;
        }

        private void btnSuaPTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();
                string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNgayKetThuc = DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text.Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuong = txtSLThanhLy.Text.Trim();
                if (strSoLuong == string.Empty)
                {
                    txtSLThanhLy.Focus();
                    return;
                }
                string strTinhTrangTL = cbbTinhTrangTL.Text.Trim();

                if (!conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    MessageBox.Show("Mã phiếu thanh lý này không tồn tại!");
                    return;
                }

                if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                    return;
                }
                string strSqlPTL = "UPDATE PhieuThanhLy SET NgayTL='" + strNgayThanhLy + "', MaNV='" + strNhanVien + "', MaChiNhanh='" + strChiNhanh + "' WHERE MaPTL='" + strMaPTL + "'";
                conn.updateToDatabase(strSqlPTL);
                createTable_PhieuThanhLy();
                MessageBox.Show("Cập nhật phiếu thanh lý thành công!");

                if (!conn.checkExist("LoHang", "MaLo", strLoHang))
                {
                    MessageBox.Show("Lô hàng này chưa tồn tại!");
                    return;
                }
                if (!conn.checkExistTwoKey("ChiTietPhieuThanhLy", "MaPTL", "MaLo", strMaPTL, strLoHang))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                //if (int.Parse(strSoLuong) > int.Parse(loHang.laySoLuong(strLoHang)))
                //{
                //    MessageBox.Show("Số lượng thanh lý phải nhỏ hơn hoặc bằng số lượng có trong lô!");
                //    return;
                //}
                string strSqlCTPTL = "UPDATE ChiTietPhieuThanhLy SET SoLuong=" + strSoLuong + ", NgayKT='" + strNgayKetThuc + "', TinhTrang=N'" + strTinhTrangTL + "' WHERE MaPTL='" + strMaPTL + "' AND MaLo='" + strLoHang + "'";
                conn.updateToDatabase(strSqlCTPTL);
                createTable_CTPTL();
                MessageBox.Show("Cập nhật chi tiết phiếu thanh lý thành công!");

                txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                txtTongSLSanPham.Text = thanhLy.demSLMatHang(strMaPTL).ToString();
                //string strSqlUDCTPTL = "UPDATE ChiTietPhieuThanhLy SET SoLuong=" + int.Parse(loHang.laySoLuong(strLoHang)) + " WHERE MaPTL='" +  strMaPTL + "' AND MaLo='" + strLoHang + "'";
                //conn.updateToDatabase(strSqlUDCTPTL);
                //createTable_CTPTL();
                //txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + 0 + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDLH);
                //string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (int.Parse(thanhLy.laySoLuongSanPham(strSanPham)) - int.Parse(strSoLuong)) + " WHERE MaSP='" + strSanPham + "'";
                //conn.updateToDatabase(strSqlUDSP);
            }
            catch
            {
                MessageBox.Show("Quá trình sửa thất bại!");
            }
        }

        private void btnXoaCTPTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();
                string strLoHang = cbbLoSanPham.SelectedValue.ToString().Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuong = txtSLThanhLy.Text.Trim();
                if (strSoLuong == string.Empty)
                {
                    txtSLThanhLy.Focus();
                    return;
                }
                string strTinhTrangTL = cbbTinhTrangTL.Text.Trim();

                if (!conn.checkExistTwoKey("ChiTietPhieuThanhLy", "MaPTL", "MaLo", strMaPTL, strLoHang))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết phiếu thanh lý này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                //Update số lượng ở bảng Lô hàng và Sản phẩm trước
                string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + int.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang)) + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDLH);
                string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (int.Parse(thanhLy.laySoLuongSanPham(strSanPham)) + int.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang))) + " WHERE MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDSP);
                //Xóa Chi tiết phiếu thanh lý sau
                string strSql = "DELETE ChiTietPhieuThanhLy WHERE MaPTL='" + strMaPTL + "' AND MaLo='" + strLoHang + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa chi tiết phiếu thanh lý thành công!");
                createTable_CTPTL();

                txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                txtTongSLSanPham.Text = thanhLy.demSLMatHang(strMaPTL).ToString();
            }
            catch
            {
                MessageBox.Show("Quá trình xóa thất bại!");
            }
        }

        private void btnXoaPhieuTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();

                if (!conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    MessageBox.Show("Chưa tồn tại phiếu thanh lý này!");
                    return;
                }
                if (conn.checkExist("ChiTietPhieuThanhLy", "MaPTL", strMaPTL))
                {
                    MessageBox.Show("Phiếu thanh lý " + strMaPTL + " đang được sử dụng ở bảng Chi tiết phiếu thanh lý!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu thanh lý này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE PhieuThanhLy WHERE MaPTL='" + strMaPTL + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa phiếu thanh lý thành công!");
                createTable_PhieuThanhLy();
            }
            catch
            {
                MessageBox.Show("Xóa phiếu thanh lý thất bại!");
            }
        }

        private void dataGV_PhieuThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuThanhLy.Text = dataGV_PhieuThanhLy.Rows[index].Cells[0].Value.ToString();
            txtNgayThanhLy.Text = dataGV_PhieuThanhLy.Rows[index].Cells[1].Value.ToString();
            cbbNhanVien.Text = dataGV_PhieuThanhLy.Rows[index].Cells[2].Value.ToString();
            cbbChiNhanh.Text = chiNhanh.layTenChiNhanh(dataGV_PhieuThanhLy.Rows[index].Cells[3].Value.ToString());
            string a = dataGV_PhieuThanhLy.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuThanhLy.DataSource = thanhLy.layChiTietPhieuThanhLy(a);
            dataGV_CTHangHoaThanhLy.DataSource = thanhLy.layCTPTL(a);
            btnSuaPTL.Enabled = btnXoaPhieuTL.Enabled = true;

            txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(txtMaPhieuThanhLy.Text.Trim()).ToString();
            txtTongSLSanPham.Text = thanhLy.demSLMatHang(txtMaPhieuThanhLy.Text.Trim()).ToString();
        }

        private void btnTKPhieuThanhLy_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("PhieuThanhLy", "MaPTL", txtTKPhieuThanhLy.Text.Trim()))
            {
                dataGV_PhieuThanhLy.DataSource = thanhLy.searchPhieuThanhLy(txtTKPhieuThanhLy.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu thanh lý này!");
                createTable_PhieuThanhLy();
            }
        }

        private void btnXemThanhLy_Click(object sender, EventArgs e)
        {
            dataGV_PhieuThanhLy.DataSource = thanhLy.searchPhieuThanhLyTheoNgay(txtNgayDau.Text, txtNgayCuoi.Text);
        }
    }
}
