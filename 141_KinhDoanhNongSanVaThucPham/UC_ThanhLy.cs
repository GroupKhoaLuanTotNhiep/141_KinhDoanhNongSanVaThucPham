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
        XuatHang xuatHang = new XuatHang();

        public UC_ThanhLy()
        {
            InitializeComponent();
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
            cbbLoSanPham.DataSource = loHang.loadLoHang();
            cbbLoSanPham.DisplayMember = "TenLo";
            cbbLoSanPham.ValueMember = "MaLo";
        }

        void loadComboBoxLoHangHetHan()
        {
            cbbLoSanPham.DataSource = loHang.loadLoHangHetHan();
            cbbLoSanPham.DisplayMember = "TenLo";
            cbbLoSanPham.ValueMember = "MaLo";
        }

        void loadComboBoxLoHangConHan()
        {
            cbbLoSanPham.DataSource = loHang.loadLoHangChuaHetHan();
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
            string[] tinhTrang = { "Chưa thanh lý", "Đã thanh lý" };
            foreach (string s in tinhTrang)
            {
                cbbTinhTrangTL.Items.Add(s);
            }
            cbbTinhTrangTL.SelectedIndex = 0;
        }

        void loadComboBoxLiDo()
        {
            string[] liDo = { "Hết hạn", "Bị hư", "Bị ương", "Đóng cặn", "Lên mốc", "Úa/héo"};
            foreach (string s in liDo)
            {
                cbbLiDo.Items.Add(s);
            }
            cbbLiDo.SelectedIndex = 0;
        }

        void loadComboBoxXuLy()
        {
            string[] xuLy = { "Phân hủy hàng", "Cho/tặng nhân viên", "Trả nhà cung cấp" };
            foreach (string s in xuLy)
            {
                cbbXuLy.Items.Add(s);
            }
            cbbXuLy.SelectedIndex = 0;
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
            loadComboBoxLiDo();
            loadComboBoxXuLy();
            loadComboBoxTinhTrang();
            createTable_PhieuThanhLy();
            createTable_CTPTL();
            txtMaPhieuThanhLy.Enabled = false;
            txtTongSLThanhLy.Enabled = txtTongSLSanPham.Enabled = false;
            cbbTinhTrangTL.Enabled = cbbDonViTinh.Enabled = cbbNhanVien.Enabled = false;
            btnLuuPTL.Enabled = btnSuaPTL.Enabled = btnXoaCTPTL.Enabled = btnXoaPhieuTL.Enabled = false;
        }

        private void cbbLoSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////cbbSanPham.DataSource = thanhLy.loadSanPhamTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            ////cbbSanPham.DisplayMember = "MaSP";
            ////cbbSanPham.ValueMember = "MaSP";
            //cbbSanPham.Text = loHang.layMaSPTheoLoHang(cbbLoSanPham.SelectedValue.ToString());

            //cbbDonViTinh.DataSource = thanhLy.loadDVTTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            //cbbDonViTinh.DisplayMember = "TenDVT";
            //cbbDonViTinh.ValueMember = "MaDVT";

            //txtSLThanhLy.Text = loHang.laySoLuong(cbbLoSanPham.SelectedValue.ToString());
        }

        private void txtSLThanhLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaPhieuThanhLy.Clear();
                txtNgayThanhLy.Text = DateTime.Now.ToString();
                txtSLThanhLy.Clear();
                cbbChiNhanh.SelectedIndex = 0;
                //cbbNhanVien.SelectedIndex = 0;
                cbbNhanVien.Text = frmDangNhap.maNV;
                cbbLoSanPham.SelectedIndex = 0;
                cbbSanPham.SelectedIndex = 0;
                cbbDonViTinh.Text = "";
                cbbLiDo.SelectedIndex = 0;
                cbbXuLy.SelectedIndex = 0;
                cbbTinhTrangTL.SelectedIndex = 0;
                txtTongSLThanhLy.Text = "0";
                txtTongSLSanPham.Text = "0";
                createTable_CTPTL();
                loadComboBoxLoHang();
                loadComboBoxSanPham();
                txtSLThanhLy.Enabled = true;
                btnLuuPTL.Enabled = true;
                cbbTinhTrangTL.Enabled = false;
            }
            catch { }
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

        //public bool kiemTraNgayThanhLyVaNgayKetThuc()
        //{
        //    string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
        //    string strNgayKetThuc = DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
        //    int ngay = DateTime.Parse(strNgayKetThuc).Day - DateTime.Parse(strNgayThanhLy).Day;
        //    int thang = DateTime.Parse(strNgayKetThuc).Month - DateTime.Parse(strNgayThanhLy).Month;
        //    int nam = DateTime.Parse(strNgayKetThuc).Year - DateTime.Parse(strNgayThanhLy).Year;
        //    if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
        //        return false;
        //    return true;
        //}

        private void btnLuuPTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();
                string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
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
                string strLiDo = cbbLiDo.Text.Trim();
                string strXuLy = cbbXuLy.Text.Trim();
                string strTinhTrangTL = cbbTinhTrangTL.Text.Trim();

                if (!conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    if (kiemTraNgayThanhLyVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày thanh lý phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    //if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                    //{
                    //    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                    //    return;
                    //}
                    string strSqlPTL = "INSERT PhieuThanhLy VALUES('" + strNgayThanhLy + "', '" + strNhanVien + "', '" + strChiNhanh + "', N'" + strLiDo + "', N'" + strXuLy + "', N'" + strTinhTrangTL + "')";
                    conn.updateToDatabase(strSqlPTL);
                    createTable_PhieuThanhLy();
                    MessageBox.Show("Lưu phiếu thanh lý thành công!");
                    txtMaPhieuThanhLy.Text = thanhLy.layMaPTL();
                }
                if (conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    //if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                    //{
                    //    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                    //    return;
                    //}
                    if (thanhLy.layTinhTrangPTL(strMaPTL) == "Đã thanh lý")
                    {
                        MessageBox.Show("Phiếu này đã được thanh lý, không thêm được!");
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
                    if (float.Parse(strSoLuong) > float.Parse(loHang.laySoLuong(strLoHang)))
                    {
                        MessageBox.Show("Số lượng thanh lý phải nhỏ hơn hoặc bằng số lượng có trong lô (" + float.Parse(loHang.laySoLuong(strLoHang)) + ")!");
                        return;
                    }
                    string strSqlCTPTL = "INSERT ChiTietPhieuThanhLy VALUES('" + strMaPTL + "', '" + strLoHang + "', " + strSoLuong + ")";
                    conn.updateToDatabase(strSqlCTPTL);
                    createTable_CTPTL();
                    MessageBox.Show("Lưu chi tiết phiếu thanh lý thành công!");

                    if (thanhLy.layLiDo(strMaPTL) == "Hết hạn")
                    {
                        string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + 0 + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                        conn.updateToDatabase(strSqlUDLH);
                    }
                    else
                    {
                        string strSqlUDLoHang = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) - float.Parse(strSoLuong)) + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                        conn.updateToDatabase(strSqlUDLoHang);
                    }
                    string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(thanhLy.laySoLuongSanPham(strSanPham)) - float.Parse(strSoLuong)) + " WHERE MaSP='" + strSanPham + "'";
                    conn.updateToDatabase(strSqlUDSP);
                }
                txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                txtTongSLSanPham.Text = thanhLy.demSLMatHang(strMaPTL).ToString();
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
            btnXoaCTPTL.Enabled = btnSuaPTL.Enabled = true;
        }

        private void btnSuaPTL_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPTL = txtMaPhieuThanhLy.Text.Trim();
                string strNgayThanhLy = DateTime.ParseExact(txtNgayThanhLy.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
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
                string strXuLy = cbbXuLy.Text.Trim();
                string strTinhTrangTL = cbbTinhTrangTL.Text.Trim();

                if (!conn.checkExist("PhieuThanhLy", "MaPTL", strMaPTL))
                {
                    MessageBox.Show("Mã phiếu thanh lý này không tồn tại!");
                    return;
                }

                //if (kiemTraNgayThanhLyVaNgayKetThuc() == false)
                //{
                //    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc là Ngày thanh lý!");
                //    return;
                //}
                if(thanhLy.layTinhTrangPTL(strMaPTL) == "Đã thanh lý")
                {
                    MessageBox.Show("Phiếu này đã được thanh lý, không sửa được!");
                    return;
                }
                string strSqlPTL = "UPDATE PhieuThanhLy SET NgayTL='" + strNgayThanhLy + "', MaChiNhanh='" + strChiNhanh + "', XuLy=N'" + strXuLy + "', TinhTrang=N'" + strTinhTrangTL + "' WHERE MaPTL='" + strMaPTL + "'";
                conn.updateToDatabase(strSqlPTL);
                createTable_PhieuThanhLy();
                MessageBox.Show("Cập nhật phiếu thanh lý thành công!");

                if(thanhLy.layLiDo(strMaPTL) == "Hết hạn")
                {
                    MessageBox.Show("Phiếu thanh lý do hết hạn nên không sửa chi tiết thanh lý được!");
                    return;
                }
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
                if (float.Parse(strSoLuong) > float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang)))
                {
                    MessageBox.Show("Số lượng thanh lý phải nhỏ hơn hoặc bằng số lượng có trong lô (" + (float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang))) + ")!");
                    return;
                }
                //if (thanhLy.layLiDo(strMaPTL) == "Hết hạn")
                //{
                //    string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + 0 + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                //    conn.updateToDatabase(strSqlUDLH);
                //}
                string strSqlUDLoHang = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang)) - float.Parse(strSoLuong)) + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDLoHang);
                string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(thanhLy.laySoLuongSanPham(strSanPham)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang)) - float.Parse(strSoLuong)) + " WHERE MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUDSP);
                string strSqlCTPTL = "UPDATE ChiTietPhieuThanhLy SET SoLuong=" + strSoLuong + " WHERE MaPTL='" + strMaPTL + "' AND MaLo='" + strLoHang + "'";
                conn.updateToDatabase(strSqlCTPTL);
                createTable_CTPTL();
                MessageBox.Show("Cập nhật chi tiết phiếu thanh lý thành công!");

                txtTongSLThanhLy.Text = thanhLy.updateTongSLThanhLy(strMaPTL).ToString();
                txtTongSLSanPham.Text = thanhLy.demSLMatHang(strMaPTL).ToString();

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

                if (thanhLy.layTinhTrangPTL(strMaPTL) == "Đã thanh lý")
                {
                    MessageBox.Show("Phiếu này đã được thanh lý, không xóa chi tiết thanh lý được!");
                    return;
                }
                if (!conn.checkExistTwoKey("ChiTietPhieuThanhLy", "MaPTL", "MaLo", strMaPTL, strLoHang))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết phiếu thanh lý này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                //Update số lượng ở bảng Lô hàng và Sản phẩm trước
                if (thanhLy.layLiDo(strMaPTL) == "Hết hạn")
                {
                    string strSqlUDLH = "UPDATE LoHang SET SoLuong=" + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang)) + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                    conn.updateToDatabase(strSqlUDLH);
                }
                else
                {
                    string strSqlUDLoHang = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang))) + " WHERE MaLo='" + strLoHang + "' AND MaSP='" + strSanPham + "'";
                    conn.updateToDatabase(strSqlUDLoHang);
                }
                string strSqlUDSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(thanhLy.laySoLuongSanPham(strSanPham)) + float.Parse(thanhLy.laySoLuongCTPTL(strMaPTL, strLoHang))) + " WHERE MaSP='" + strSanPham + "'";
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
            cbbLiDo.Text = dataGV_PhieuThanhLy.Rows[index].Cells[4].Value.ToString();
            cbbXuLy.Text = dataGV_PhieuThanhLy.Rows[index].Cells[5].Value.ToString();
            cbbTinhTrangTL.Text = dataGV_PhieuThanhLy.Rows[index].Cells[6].Value.ToString();
            string a = dataGV_PhieuThanhLy.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuThanhLy.DataSource = thanhLy.layChiTietPhieuThanhLy(a);
            dataGV_CTHangHoaThanhLy.DataSource = thanhLy.layCTPTL(a);
            btnSuaPTL.Enabled = btnXoaPhieuTL.Enabled = true;
            cbbTinhTrangTL.Enabled = true;

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

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (conn.checkExist("LoHang", "MaSP", cbbSanPham.SelectedValue.ToString()))
            //{
            //    cbbLoSanPham.DataSource = sanPham.layLoHangTheoSanPham(cbbSanPham.SelectedValue.ToString());
            //    cbbLoSanPham.DisplayMember = "TenLo";
            //    cbbLoSanPham.ValueMember = "MaLo";
            //}
        }

        private void cbbLiDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLiDo.Text == "Hết hạn")
            {
                loadComboBoxLoHangHetHan();
                txtSLThanhLy.Enabled = false;
                if (cbbSanPham.Items.Count == 0)
                    cbbSanPham.Text = "";
            }
            else
            {
                loadComboBoxLoHangConHan();
                txtSLThanhLy.Enabled = true;
            }
        }

        private void cbbLiDo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cbbLiDo.Text == "Hết hạn")
            //{
            //    loadComboBoxLoHangHetHan();
            //    txtSLThanhLy.Enabled = false;
            //    if (cbbSanPham.Items.Count == 0)
            //        cbbSanPham.Text = "";
            //}
            //else
            //{
            //    loadComboBoxLoHangConHan();
            //    txtSLThanhLy.Enabled = true;
            //}
        }

        private void cbbLoSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cbbSanPham.DataSource = thanhLy.loadSanPhamTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            //cbbSanPham.DisplayMember = "MaSP";
            //cbbSanPham.ValueMember = "MaSP";
            cbbSanPham.Text = loHang.layMaSPTheoLoHang(cbbLoSanPham.SelectedValue.ToString());

            cbbDonViTinh.DataSource = thanhLy.loadDVTTheoLoHang(cbbLoSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";

            txtSLThanhLy.Text = loHang.laySoLuong(cbbLoSanPham.SelectedValue.ToString());
        }

        private void cbbSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbLiDo.SelectedIndex > 0)
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
            }
            else if (cbbLiDo.SelectedIndex == 0)
            {
                if (conn.checkExist("LoHang", "MaSP", cbbSanPham.SelectedValue.ToString()))
                {
                    cbbLoSanPham.DataSource = thanhLy.loadLoHangTheoSanPhamHetHSD(cbbSanPham.SelectedValue.ToString());
                    cbbLoSanPham.DisplayMember = "TenLo";
                    cbbLoSanPham.ValueMember = "MaLo";
                    if (cbbLoSanPham.Items.Count == 0)
                        cbbLoSanPham.Text = "";
                }
                else
                {
                    cbbLoSanPham.DataSource = thanhLy.loadLoHangTheoSanPhamHetHSD(cbbSanPham.SelectedValue.ToString());
                    cbbLoSanPham.Text = "";
                }
            }
            cbbDonViTinh.DataSource = xuatHang.loadDVTTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_CTPTL(dataGV_CTPhieuThanhLy, saveFileDialog1.FileName);
        }
        private void exportExcel_CTPTL(DataGridView dv, string fileName)
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
                worksheet.Name = "CT phiếu thanh lý";

                worksheet.Cells[2, 2] = "CHI TIẾT PHIẾU THANH LÝ";

                worksheet.Cells[4, 3] = "Ngày thanh lý:";
                worksheet.Cells[4, 4] = txtNgayThanhLy.Text;
                worksheet.Cells[5, 3] = "Mã nhân viên:";
                worksheet.Cells[5, 4] = cbbNhanVien.Text;
                worksheet.Cells[6, 3] = "Chi nhánh:";
                worksheet.Cells[6, 4] = cbbChiNhanh.Text;
                worksheet.Cells[7, 3] = "Lí do:";
                worksheet.Cells[7, 4] = cbbLiDo.Text;
                worksheet.Cells[8, 3] = "Xử lý:";
                worksheet.Cells[8, 4] = cbbXuLy.Text;
                worksheet.Cells[9, 3] = "Tình trạng:";
                worksheet.Cells[9, 4] = cbbTinhTrangTL.Text;

                for (int i = 0; i < dataGV_CTPhieuThanhLy.ColumnCount; i++)
                {
                    worksheet.Cells[11, i + 1] = dataGV_CTPhieuThanhLy.Columns[i].HeaderText;
                }

                int tkshh = dataGV_CTPhieuThanhLy.RowCount;

                for (int i = 0; i < dataGV_CTPhieuThanhLy.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_CTPhieuThanhLy.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 12, j + 1] = dataGV_CTPhieuThanhLy.Rows[i].Cells[j].Value.ToString();
                    }
                }

                worksheet.Cells[tkshh + 13, 3] = "Tổng số lượng TL: " + txtTongSLThanhLy.Text;
                worksheet.Range["A" + (tkshh + 13), "G" + (tkshh + 13)].Font.Bold = true;

                worksheet.Cells[tkshh + 14, 3] = "Tổng số lượng SP: " + txtTongSLSanPham.Text;
                worksheet.Range["A" + (tkshh + 14), "G" + (tkshh + 14)].Font.Bold = true;

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
                worksheet.Range["D1"].ColumnWidth = 16.22;
                worksheet.Range["E1"].ColumnWidth = 52.22;
                worksheet.Range["F1"].ColumnWidth = 14.78;
                worksheet.Range["G1"].ColumnWidth = 13.78;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A3", "G3"].MergeCells = true;
                worksheet.Range["A3", "G3"].Font.Italic = true;
                worksheet.Range["A3", "G3"].Font.Size = 15;

                worksheet.Range["A11", "G11"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A11", "G" + (tkshh + 11)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A11", "G11"].HorizontalAlignment = 3;
                worksheet.Range["A12", "A" + (tkshh + 12)].HorizontalAlignment = 3;
                worksheet.Range["B12", "B" + (tkshh + 12)].HorizontalAlignment = 3;
                worksheet.Range["D12", "D" + (tkshh + 12)].HorizontalAlignment = 3;
                worksheet.Range["F12", "F" + (tkshh + 12)].HorizontalAlignment = 3;
                worksheet.Range["G12", "G" + (tkshh + 12)].HorizontalAlignment = 3;

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

        private void btnInTatCaPTL_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_PTL(dataGV_PhieuThanhLy, saveFileDialog1.FileName);
        }
        private void exportExcel_PTL(DataGridView dv, string fileName)
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
                worksheet.Name = "Phiếu thanh lý";

                worksheet.Cells[2, 2] = "PHIẾU THANH LÝ";

                worksheet.Cells[3, 2] = "Từ " + txtNgayDau.Text + "đến " + txtNgayCuoi.Text;

                for (int i = 0; i < dataGV_PhieuThanhLy.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_PhieuThanhLy.Columns[i].HeaderText;
                }

                int tkshh = dataGV_PhieuThanhLy.RowCount;

                for (int i = 0; i < dataGV_PhieuThanhLy.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_PhieuThanhLy.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_PhieuThanhLy.Rows[i].Cells[j].Value.ToString();
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
                worksheet.Range["A1"].ColumnWidth = 9.22;
                worksheet.Range["B1"].ColumnWidth = 16.78;
                worksheet.Range["C1"].ColumnWidth = 9.78;
                worksheet.Range["D1"].ColumnWidth = 14.11;
                worksheet.Range["E1"].ColumnWidth = 17.56;
                worksheet.Range["F1"].ColumnWidth = 17.44;
                worksheet.Range["G1"].ColumnWidth = 14.78;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A3", "G3"].MergeCells = true;
                worksheet.Range["A3", "G3"].Font.Italic = true;
                worksheet.Range["A3", "G3"].Font.Size = 15;

                worksheet.Range["A5", "G5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "G" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "G3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "G5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["C6", "C" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkshh + 6)].HorizontalAlignment = 3;

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
