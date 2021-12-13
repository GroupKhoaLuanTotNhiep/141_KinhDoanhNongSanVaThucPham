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
    public partial class UC_GiaoHang : UserControl
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        ChiNhanh chiNhanh = new ChiNhanh();
        SanPham sanPham = new SanPham();
        KhuyenMai khuyenMai = new KhuyenMai();
        HoaDon hoaDon = new HoaDon();
        GiaoHang giaoHang = new GiaoHang();
        HinhThucThanhToan hinhThuc = new HinhThucThanhToan();
        KhachHang khachHang = new KhachHang();
        LoHang loHang = new LoHang();

        public UC_GiaoHang()
        {
            InitializeComponent();
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVienGiaoHang();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void loadComboBoxChiNhanh()
        {
            cbbChiNhanh.DataSource = chiNhanh.loadChiNhanh();
            cbbChiNhanh.DisplayMember = "TenChiNhanh";
            cbbChiNhanh.ValueMember = "MaChiNhanh";
        }

        void loadComboBoxHoaDon()
        {
            cbbHoaDon.DataSource = giaoHang.loadHoaDonChuaGiao();
            cbbHoaDon.DisplayMember = "MaHoaDon";
            cbbHoaDon.ValueMember = "MaHoaDon";
        }

        void loadComboBoxSanPham()
        {
            cbbSanPham.DataSource = sanPham.loadSanPham();
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        void loadComboBoxKhuyenMai()
        {
            cbbKhuyenMai.DataSource = khuyenMai.loadKhuyenMai();
            cbbKhuyenMai.DisplayMember = "TenKM";
            cbbKhuyenMai.ValueMember = "MaKM";
        }

        void loadComboBoxTinhTrang()
        {
            string[] tinhTrang = { "Đang giao hàng", "Hoàn tất", "Bị hủy" };
            foreach (string s in tinhTrang)
                cbbTinhTrangGiao.Items.Add(s);
            cbbTinhTrangGiao.SelectedIndex = 0;
        }

        void createTable_PhieuGiaoHang()
        {
            dataGV_PhieuGiaoHang.DataSource = giaoHang.loadDataGV_PhieuGiaoHang();
        }

        //void createTable_CTPGH()
        //{
        //    dataGV_CTGiaoHang.DataSource = giaoHang.loadDataGV_CTPGHTheoMaPGH(txtMaPhieuGiao.Text);
        //}

        private void UC_GiaoHang_Load(object sender, EventArgs e)
        {
            loadComboBoxNhanVien();
            loadComboBoxChiNhanh();
            loadComboBoxHoaDon();
            loadComboBoxKhuyenMai();
            loadComboBoxTinhTrang();
            loadComboBoxSanPham();
            createTable_PhieuGiaoHang();
            try
            {
                for(int i = 0; i < dataGV_PhieuGiaoHang.RowCount - 1; i++)
                {
                    string mapg = dataGV_PhieuGiaoHang.Rows[i].Cells[0].Value.ToString();
                    string mahd = dataGV_PhieuGiaoHang.Rows[i].Cells[6].Value.ToString();
                    if(hoaDon.layTinhTrang(mahd) == "Đã giao hàng" || (hoaDon.layTinhTrang(mahd) == "Hủy hàng" && giaoHang.layTinhTrang(mapg) == "Đang giao hàng"))
                    {
                        string strSQL = "UPDATE PhieuGiaoHang SET TinhTrang=N'Hoàn tất' WHERE MaPGH=" + mapg;
                        conn.updateToDatabase(strSQL);
                        createTable_PhieuGiaoHang();
                    }
                    if(hoaDon.layTinhTrang(mahd) == "Chưa giao hàng")
                    {
                        string strSql = "UPDATE PhieuGiaoHang SET TinhTrang=N'Đang giao hàng' WHERE MaPGH=" + mapg;
                        conn.updateToDatabase(strSql);
                        createTable_PhieuGiaoHang();
                    }
                }
            }
            catch { }
            //createTable_CTPGH();
            txtMaPhieuGiao.Enabled = false;
            txtGiaBan.Enabled = false;
            cbbKhuyenMai.Enabled = cbbDonViTinh.Enabled = cbbGiamGia.Enabled = cbbTinhTrangGiao.Enabled = false;
            btnLuuPGH.Enabled = btnSuaPGH.Enabled = false;
            txtTongTien.Enabled = txtTienPhaiTra.Enabled = txtTienTraLai.Enabled = false;
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = giaoHang.loadDonViTinhTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";

            txtGiaBan.Text = giaoHang.layGiaBanTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbGiamGia.Text = giaoHang.layGiamGiaTheoSanPham(cbbSanPham.SelectedValue.ToString());
        }

        private void txtSoLuongGiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuGiao.Clear();
            txtNgayGiao.Text = DateTime.Now.ToString();
            txtSDTGiao.Clear();
            txtDiaChiGiao.Clear();
            txtTongTien.Text = "0";
            txtTienPhaiTra.Text = "0";
            txtTienTraLai.Text = "0";
            cbbNhanVien.SelectedIndex = 0;
            cbbChiNhanh.SelectedIndex = 0;
            cbbHoaDon.Text = "";
            cbbKhuyenMai.SelectedIndex = 0;
            cbbTinhTrangGiao.SelectedIndex = 0;
            cbbSanPham.SelectedIndex = 0;
            cbbDonViTinh.Text = "";
            cbbGiamGia.Text = "";
            txtSoLuongGiao.Clear();
            txtGiaBan.Clear();
            //createTable_CTPGH();
            dataGV_CTGiaoHang.DataSource = hoaDon.loadDataGV_CTHDTheoMaHD(cbbHoaDon.Text.Trim());
            cbbTinhTrangGiao.Enabled = false;
            btnLuuPGH.Enabled = true;
        }

        private void cbbHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public bool kiemTraNgayGiaoVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayGiao).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strNgayGiao).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strNgayGiao).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuPGH_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPGH = txtMaPhieuGiao.Text.Trim();
                string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.SelectedValue.ToString().Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strHoaDon = cbbHoaDon.Text.Trim(); ;
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strTinhTrang = cbbTinhTrangGiao.Text;
                string strTongTien = txtTongTien.Text.Trim();
                string strTienTraLai = txtTienTraLai.Text.Trim();
                string strSDTGiao = txtSDTGiao.Text.Trim();
                string strDCGiao = txtDiaChiGiao.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongGiao = txtSoLuongGiao.Text.Trim();
                string strGiaBan = txtGiaBan.Text.Trim();
                string strGiamGia = cbbGiamGia.Text.Trim();
                if (strGiamGia == string.Empty)
                {
                    strGiamGia = "0";
                    cbbGiamGia.Text = "0";
                }
                if (strSoLuongGiao == string.Empty)
                {
                    txtSoLuongGiao.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongGiao) * (int.Parse(strGiaBan) - (int.Parse(strGiaBan) * float.Parse(strGiamGia))));

                if (conn.checkExist("PhieuGiaoHang", "MaPGH", strMaPGH))
                {
                    MessageBox.Show("Phiếu giao hàng " + strMaPGH + " này đã tồn tại!");
                    return;
                }
                if (conn.checkExist("PhieuGiaoHang", "MaHoaDon", strHoaDon))
                {
                    MessageBox.Show("Hóa đơn " + strHoaDon + " này đang được giao!");
                    return;
                }
                if (kiemTraNgayGiaoVaNgayHT() == false)
                {
                    MessageBox.Show("Ngày giao phải lớn hơn hoặc là Ngày hiện tại!");
                    return;
                }
                string strSqlPGH = "INSERT PhieuGiaoHang VALUES('" + strNhanVien + "', '" + strChiNhanh + "', '" + strNgayGiao + "', " + strTongTien + ", " + strTienTraLai + ", '" + strHoaDon + "', '" + strKhuyenMai + "', N'" + strDCGiao + "', '" + strSDTGiao + "', N'" + strTinhTrang + "')";
                conn.updateToDatabase(strSqlPGH);
                createTable_PhieuGiaoHang();
                MessageBox.Show("Lưu phiếu giao hàng thành công!");
                txtMaPhieuGiao.Text = giaoHang.layMaPhieuGiao();
                //if (conn.checkExist("PhieuGiaoHang", "MaPGH", strMaPGH))
                //{
                //    if (!conn.checkExist("SanPham", "MaSP", strSanPham))
                //    {
                //        MessageBox.Show("Sản phẩm này chưa tồn tại!");
                //        return;
                //    }
                //    if(!conn.checkExistTwoKey("ChiTietHoaDon", "MaHoaDon", "MaSP", strHoaDon, strSanPham))
                //    {
                //        MessageBox.Show("Hóa đơn và sản phẩm này chưa được lập với nhau!");
                //        return;
                //    }
                //    if (conn.checkExistTwoKey("ChiTietPhieuGiaoHang", "MaPGH", "MaSP", strMaPGH, strSanPham))
                //    {
                //        MessageBox.Show("Trùng khóa chính rồi!");
                //        return;
                //    }
                //    if (float.Parse(strSoLuongGiao) > float.Parse(hoaDon.laySoLuongBan(strHoaDon, strSanPham)))
                //    {
                //        MessageBox.Show("Số lượng giao phải nhỏ hơn hoặc bằng số lượng bán!");
                //        return;
                //    }
                //    string strSqlCTPGH = "INSERT ChiTietPhieuGiaoHang VALUES('" + strMaPGH + "', '" + strSanPham + "', " + strSoLuongGiao + ", " + strGiaBan + ", " + thanhTien + ")";
                //    conn.updateToDatabase(strSqlCTPGH);
                //    //createTable_CTPGH();
                //    MessageBox.Show("Lưu chi tiết phiếu giao hàng thành công!");
                //}
                //strTongTien = giaoHang.updateTongTien(strMaPGH).ToString();
                //txtTongTien.Text = strTongTien;
                //int tongTraLai = int.Parse(hoaDon.layTongTien(strHoaDon)) - int.Parse(strTongTien);
                //txtTienPhaiTra.Text = String.Format("{0:0,0}", tongTraLai);
                //string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TongTien=" + strTongTien + ", TienPhaiTra=" + tongTraLai + " WHERE MaPGH='" + strMaPGH + "'";
                //conn.updateToDatabase(strSqlUDPGH);
                //createTable_PhieuGiaoHang();
                //if (cbbTinhTrangGiao.Text.Trim() == "Giao đủ" || cbbTinhTrangGiao.Text.Trim() == "Giao thiếu")
                //{
                //    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Đã giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                //    conn.updateToDatabase(strSqlUDHD);
                //}
                //if (cbbTinhTrangGiao.Text.Trim() == "Bị hủy")
                //{
                //    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                //    conn.updateToDatabase(strSqlUDHD);
                //}
                if (cbbTinhTrangGiao.Text.Trim() == "Đang giao hàng")
                {
                    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Chưa giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                    conn.updateToDatabase(strSqlUDHD);
                }
                if (cbbTinhTrangGiao.Text.Trim() == "Hoàn tất")
                {
                    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Đã giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                    conn.updateToDatabase(strSqlUDHD);
                }
                if (cbbTinhTrangGiao.Text.Trim() == "Bị hủy")
                {
                    try
                    {
                        string strKhachHang = hoaDon.layMakhOHoaDon(cbbHoaDon.Text.Trim());
                        for (int i = 0; i < dataGV_CTGiaoHang.RowCount - 1; i++)
                        {
                            string masp = dataGV_CTGiaoHang.Rows[i].Cells["MaSP"].Value.ToString().Trim();
                            string gia = dataGV_CTGiaoHang.Rows[i].Cells["GiaXuat"].Value.ToString().Trim();
                            string malo = loHang.layMaLo(sanPham.layMaGiaBanTheoTenGia(int.Parse(gia)), masp);
                            float soluong = float.Parse(dataGV_CTGiaoHang.Rows[i].Cells["SoLuongBan"].Value.ToString().Trim());
                            if (conn.checkExistTwoKey("LoHang", "MaLo", "MaSP", malo, masp))
                            {
                                string strSQLLo = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(malo)) + soluong) + " WHERE MaLo='" + malo + "'";
                                conn.updateToDatabase(strSQLLo);
                            }
                            string strSQLSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(sanPham.laySoLuongSPTheoSanPham(masp)) + soluong) + " WHERE MaSP='" + masp + "'";
                            conn.updateToDatabase(strSQLSP);
                        }
                        strTienTraLai = String.Format("{0:0,0}", int.Parse(txtTienPhaiTra.Text));
                        txtTienTraLai.Text = strTienTraLai;
                        int tichDiem = int.Parse(khachHang.layTichDiem(strKhachHang)) + int.Parse(khuyenMai.layTichLuy(strKhuyenMai));
                        int congNo = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(strHoaDon)) + int.Parse(txtTienPhaiTra.Text);
                        string strSqlKH = "UPDATE KhachHang SET TichDiem=" + tichDiem + ", CongNo=" + congNo + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlKH);
                        string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TienPhaiTra=" + int.Parse(txtTienPhaiTra.Text) + ", TinhTrang=N'Bị hủy' WHERE MaPGH='" + strMaPGH + "'";
                        conn.updateToDatabase(strSqlUDPGH);
                        createTable_PhieuGiaoHang();
                        string strSQLHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                        conn.updateToDatabase(strSQLHD);
                        MessageBox.Show("Hủy hàng thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Hủy hàng thất bại!");
                    }
                }
                btnLuuPGH.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại!");
            }
        }

        //private void btnLuuNo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //string strMaPGH = txtMaPhieuGiao.Text.Trim();
        //        //string strTongTien = txtTongTien.Text.Trim();
        //        //strTongTien = giaoHang.updateTongTien(strMaPGH).ToString();
        //        //txtTongTien.Text = strTongTien;
        //        //int tongTraLai = int.Parse(giaoHang.layTongTien(strMaPGH)) - int.Parse(strTongTien);
        //        //txtTienPhaiTra.Text = String.Format("{0:0,0}", tongTraLai);
        //        //string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TongTien=" + strTongTien + ", TienPhaiTra=" + tongTraLai + " WHERE MaPGH='" + strMaPGH + "'";
        //        //conn.updateToDatabase(strSqlUDPGH);
        //        //createTable_PhieuGiaoHang();
        //        string strMaKH = hoaDon.layMakhOHoaDon(cbbHoaDon.Text.Trim());
        //        string strLayCongNo = khachHang.layCongNo(strMaKH);
        //        string strTienTraLai = txtTienPhaiTra.Text.Trim();
        //        string strSQL = "UPDATE KhachHang SET CongNo=" + (int.Parse(strLayCongNo) + int.Parse(strTienTraLai)) + " WHERE MaKH='" + strMaKH + "'";
        //        MessageBox.Show("Lưu nợ thành công!");
        //        btnLuuNo.Enabled = false;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Lưu nợ thất bại!");
        //    }
        //}

        private void dataGV_PhieuGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPhieuGiao.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[0].Value.ToString();
            cbbNhanVien.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[1].Value.ToString();
            cbbChiNhanh.Text = chiNhanh.layTenChiNhanh(dataGV_PhieuGiaoHang.Rows[index].Cells[2].Value.ToString());
            txtNgayGiao.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[3].Value.ToString();
            txtTongTien.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[4].Value.ToString();
            txtTienTraLai.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[5].Value.ToString();
            cbbHoaDon.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[6].Value.ToString();
            cbbKhuyenMai.Text = khuyenMai.layTenKhuyenMai(dataGV_PhieuGiaoHang.Rows[index].Cells[7].Value.ToString());
            txtDiaChiGiao.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[8].Value.ToString();
            txtSDTGiao.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[9].Value.ToString();
            cbbTinhTrangGiao.Text = dataGV_PhieuGiaoHang.Rows[index].Cells[10].Value.ToString();
            string a = dataGV_PhieuGiaoHang.Rows[index].Cells[6].Value.ToString();
            dataGV_ChiTietGiaoHang.DataSource = hoaDon.layChiTietHoaDon(a);
            dataGV_CTGiaoHang.DataSource = hoaDon.layCTHD(a);
            btnSuaPGH.Enabled = true;
            cbbTinhTrangGiao.Enabled = true;

            txtTienPhaiTra.Text = hoaDon.layTienPhaiTra(cbbHoaDon.Text);
        }

        private void dataGV_CTGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (e.RowIndex == -1) return;
                cbbHoaDon.Text = dataGV_CTGiaoHang.Rows[index].Cells[0].Value.ToString();
                cbbSanPham.Text = dataGV_CTGiaoHang.Rows[index].Cells[1].Value.ToString();
                txtSoLuongGiao.Text = dataGV_CTGiaoHang.CurrentRow.Cells[2].Value.ToString();
                txtGiaBan.Text = dataGV_CTGiaoHang.Rows[index].Cells[3].Value.ToString();
                cbbGiamGia.Text = dataGV_CTGiaoHang.Rows[index].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnSuaPGH_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaPGH = txtMaPhieuGiao.Text.Trim();
                string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.SelectedValue.ToString().Trim();
                string strChiNhanh = cbbChiNhanh.SelectedValue.ToString().Trim();
                string strHoaDon = cbbHoaDon.Text.Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strTinhTrang = cbbTinhTrangGiao.Text;
                string strTongTien = txtTongTien.Text.Trim();
                string strTienTraLai = txtTienTraLai.Text.Trim();
                string strSDTGiao = txtSDTGiao.Text.Trim();
                string strDCGiao = txtDiaChiGiao.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strSoLuongGiao = txtSoLuongGiao.Text.Trim();
                string strGiaBan = txtGiaBan.Text.Trim();
                string strGiamGia = cbbGiamGia.Text.Trim();
                if (strGiamGia == string.Empty)
                {
                    strGiamGia = "0";
                    cbbGiamGia.Text = "0";
                }
                if (strSoLuongGiao == string.Empty)
                {
                    txtSoLuongGiao.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongGiao) * (int.Parse(strGiaBan) - (int.Parse(strGiaBan) * float.Parse(strGiamGia))));

                if (!conn.checkExist("PhieuGiaoHang", "MaPGH", strMaPGH))
                {
                    MessageBox.Show("Mã phiếu giao này không tồn tại!");
                    return;
                }
                if (giaoHang.layTinhTrang(strMaPGH) == "Hoàn tất" || giaoHang.layTinhTrang(strMaPGH) == "Bị hủy")
                {
                    cbbTinhTrangGiao.Enabled = false;
                    MessageBox.Show("Đơn hàng đã hoàn thành không thể sửa!");
                    return;
                }
                string strSqlPGH = "UPDATE PhieuGiaoHang SET MaNV='" + strNhanVien + "', MaChiNhanh='" + strChiNhanh + "', NgayGiao='" + strNgayGiao + "', DiaChiGiao=N'" + strDCGiao + "', SDTGiao='" + strSDTGiao + "' WHERE MaPGH='" + strMaPGH + "'";
                conn.updateToDatabase(strSqlPGH);
                createTable_PhieuGiaoHang();
                MessageBox.Show("Cập nhật phiếu giao hàng thành công!");
                cbbHoaDon.Text = giaoHang.layMaHD(strMaPGH);

                //if (!conn.checkExistTwoKey("ChiTietHoaDon", "MaHoaDon", "MaSP", strHoaDon, strSanPham))
                //{
                //    MessageBox.Show("Hóa đơn và sản phẩm này chưa được lập với nhau!");
                //    return;
                //}
                //if (!conn.checkExistTwoKey("ChiTietPhieuGiaoHang", "MaPGH", "MaSP", strMaPGH, strSanPham))
                //{
                //    MessageBox.Show("Khóa chính này chưa tồn tại!");
                //    return;
                //}
                //if (float.Parse(strSoLuongGiao) > float.Parse(hoaDon.laySoLuongBan(strHoaDon, strSanPham)))
                //{
                //    MessageBox.Show("Số lượng giao phải nhỏ hơn hoặc bằng số lượng bán!");
                //    return;
                //}
                //string strSqlCTPGH = " UPDATE ChiTietPhieuGiaoHang SET SoLuongBan=" + strSoLuongGiao + ", GiaXuat=" + strGiaBan + ", ThanhTien=" + thanhTien + " WHERE MaPGH='" + strMaPGH + "' AND MaSP='" + strSanPham + "'";
                //conn.updateToDatabase(strSqlCTPGH);
                ////createTable_CTPGH();
                //MessageBox.Show("Cập nhật chi tiết phiếu giao hàng thành công!");

                //strTongTien = giaoHang.updateTongTien(strMaPGH).ToString();
                //txtTongTien.Text = strTongTien;
                //int tongTraLai = int.Parse(hoaDon.layTongTien(strHoaDon)) - int.Parse(strTongTien);
                //txtTienPhaiTra.Text = String.Format("{0:0,0}", tongTraLai);
                //string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TongTien=" + strTongTien + ", TienPhaiTra=" + tongTraLai + " WHERE MaPGH='" + strMaPGH + "'";
                //conn.updateToDatabase(strSqlUDPGH);
                //createTable_PhieuGiaoHang();
                //if (cbbTinhTrangGiao.Text.Trim() == "Giao đủ" || cbbTinhTrangGiao.Text.Trim() == "Giao thiếu")
                //{
                //    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Đã giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                //    conn.updateToDatabase(strSqlUDHD);
                //}
                //if (cbbTinhTrangGiao.Text.Trim() == "Bị hủy")
                //{
                //    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                //    conn.updateToDatabase(strSqlUDHD);
                //}
                if (cbbTinhTrangGiao.Text.Trim() == "Đang giao hàng")
                {
                    string strSqlUDPGH1 = "UPDATE PhieuGiaoHang SET TinhTrang=N'Đang giao hàng' WHERE MaPGH='" + strMaPGH + "'";
                    conn.updateToDatabase(strSqlUDPGH1);
                    createTable_PhieuGiaoHang();
                    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Chưa giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                    conn.updateToDatabase(strSqlUDHD);
                }
                if (cbbTinhTrangGiao.Text.Trim() == "Hoàn tất")
                {
                    string strSqlUDPGH2 = "UPDATE PhieuGiaoHang SET TinhTrang=N'Hoàn tất' WHERE MaPGH='" + strMaPGH + "'";
                    conn.updateToDatabase(strSqlUDPGH2);
                    createTable_PhieuGiaoHang();
                    string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Đã giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                    conn.updateToDatabase(strSqlUDHD);
                }
                if (cbbTinhTrangGiao.Text.Trim() == "Bị hủy")
                {
                    try
                    {
                        string strKhachHang = hoaDon.layMakhOHoaDon(cbbHoaDon.Text.Trim());
                        for (int i = 0; i < dataGV_CTGiaoHang.RowCount - 1; i++)
                        {
                            string masp = dataGV_CTGiaoHang.Rows[i].Cells["MaSP"].Value.ToString().Trim();
                            string gia = dataGV_CTGiaoHang.Rows[i].Cells["GiaXuat"].Value.ToString().Trim();
                            string malo = loHang.layMaLo(sanPham.layMaGiaBanTheoTenGia(int.Parse(gia)), masp);
                            float soluong = float.Parse(dataGV_CTGiaoHang.Rows[i].Cells["SoLuongBan"].Value.ToString().Trim());
                            if (conn.checkExistTwoKey("LoHang", "MaLo", "MaSP", malo, masp))
                            {
                                string strSQLLo = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(malo)) + soluong) + " WHERE MaLo='" + malo + "'";
                                conn.updateToDatabase(strSQLLo);
                            }
                            string strSQLSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(sanPham.laySoLuongSPTheoSanPham(masp)) + soluong) + " WHERE MaSP='" + masp + "'";
                            conn.updateToDatabase(strSQLSP);
                        }
                        strTienTraLai = String.Format("{0:0,0}", int.Parse(txtTienPhaiTra.Text));
                        txtTienTraLai.Text = strTienTraLai;
                        int tichDiem = int.Parse(khachHang.layTichDiem(strKhachHang)) + int.Parse(khuyenMai.layTichLuy(strKhuyenMai));
                        int congNo = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(strHoaDon)) + int.Parse(txtTienPhaiTra.Text);
                        string strSqlKH = "UPDATE KhachHang SET TichDiem=" + tichDiem + ", CongNo=" + congNo + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlKH);
                        string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TienPhaiTra=" + int.Parse(txtTienPhaiTra.Text) + ", TinhTrang=N'Bị hủy' WHERE MaPGH='" + strMaPGH + "'";
                        conn.updateToDatabase(strSqlUDPGH);
                        createTable_PhieuGiaoHang();
                        string strSQLHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + strHoaDon + "'";
                        conn.updateToDatabase(strSQLHD);          
                        MessageBox.Show("Hủy hàng thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Hủy hàng thất bại!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Quá trình cập nhật thất bại!");
            }
        }

        //private void btnXoaChiTietGH_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string strMaPGH = txtMaPhieuGiao.Text.Trim();
        //        string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
        //        string strHoaDon = cbbHoaDon.SelectedValue.ToString().Trim();
        //        string strTongTien = txtTongTien.Text.Trim();
        //        string strSoLuongGiao = txtSoLuongGiao.Text.Trim();
        //        string strGiaBan = txtGiaBan.Text.Trim();
        //        string strGiamGia = cbbGiamGia.Text.Trim();
        //        if (strGiamGia == string.Empty)
        //        {
        //            strGiamGia = "0";
        //            cbbGiamGia.Text = "0";
        //        }
        //        if (strSoLuongGiao == string.Empty)
        //        {
        //            txtSoLuongGiao.Focus();
        //            return;
        //        }
        //        int thanhTien = (int)(float.Parse(strSoLuongGiao) * (int.Parse(strGiaBan) - (int.Parse(strGiaBan) * float.Parse(strGiamGia))));

        //        if (!conn.checkExistTwoKey("ChiTietPhieuGiaoHang", "MaPGH", "MaSP", strMaPGH, strSanPham))
        //        {
        //            MessageBox.Show("Khóa chính này chưa tồn tại!");
        //            return;
        //        }
        //        if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết phiếu giao hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
        //            return;
        //        string strSql = "DELETE ChiTietPhieuGiaoHang WHERE MaPGH='" + strMaPGH + "' AND MaSP='" + strSanPham + "'";
        //        conn.updateToDatabase(strSql);
        //        MessageBox.Show("Xóa chi tiết phiếu giao hàng thành công!");
        //        createTable_CTPGH();

        //        strTongTien = giaoHang.updateTongTien(strMaPGH).ToString();
        //        txtTongTien.Text = strTongTien;
        //        int tongTraLai = int.Parse(hoaDon.layTongTien(strHoaDon)) - int.Parse(strTongTien);
        //        txtTienPhaiTra.Text = String.Format("{0:0,0}", tongTraLai);
        //        string strSqlUDPGH = "UPDATE PhieuGiaoHang SET TongTien=" + strTongTien + ", TienPhaiTra=" + tongTraLai + " WHERE MaPGH='" + strMaPGH + "'";
        //        conn.updateToDatabase(strSqlUDPGH);
        //        createTable_PhieuGiaoHang();
        //        if (cbbTinhTrangGiao.Text.Trim() == "Giao đủ" || cbbTinhTrangGiao.Text.Trim() == "Giao thiếu")
        //        {
        //            string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Đã giao hàng' WHERE MaHoaDon='" + strHoaDon + "'";
        //            conn.updateToDatabase(strSqlUDHD);
        //        }
        //        if (cbbTinhTrangGiao.Text.Trim() == "Bị hủy")
        //        {
        //            string strSqlUDHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + strHoaDon + "'";
        //            conn.updateToDatabase(strSqlUDHD);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Quá trình xóa thất bại!");
        //    }
        //}

        private void btnTimKiemPGH_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("PhieuGiaoHang", "MaPGH", txtTimKiemPGH.Text.Trim()))
            {
                dataGV_PhieuGiaoHang.DataSource = giaoHang.searchPhieuGiaoHang(txtTimKiemPGH.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu giao hàng này!");
                createTable_PhieuGiaoHang();
            }
        }

        private void btnXemPG_Click(object sender, EventArgs e)
        {
            dataGV_PhieuGiaoHang.DataSource = giaoHang.searchPhieuGiaoHangTheoNgayGiao(txtNgayDau.Text, txtNgayCuoi.Text);
        }

        private void cbbHoaDon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //dataGV_CTGiaoHang.DataSource = hoaDon.layCTHD(cbbHoaDon.Text.Trim());
            dataGV_CTGiaoHang.DataSource = hoaDon.loadDataGV_CTHDTheoMaHD(cbbHoaDon.Text.Trim());

            txtSDTGiao.Text = giaoHang.laySDTGiao(cbbHoaDon.Text.Trim());
            txtDiaChiGiao.Text = giaoHang.layDiaChiGiao(cbbHoaDon.Text.Trim());
            txtTongTien.Text = hoaDon.layTongTien(cbbHoaDon.Text.Trim());
            txtTienPhaiTra.Text = hoaDon.layTienPhaiTra(cbbHoaDon.Text.Trim());

            cbbKhuyenMai.DataSource = giaoHang.loadKhuyenMaiTheoHoaDon(cbbHoaDon.Text.Trim());
        }

        private void btnXoaPGH_Click(object sender, EventArgs e)
        {
            if (cbbTinhTrangGiao.Text == "Đang giao hàng")
            {
                try
                {
                    string strMaPGH = txtMaPhieuGiao.Text.Trim();
                    if (!conn.checkExist("PhieuGiaoHang", "MaPGH", strMaPGH))
                    {
                        MessageBox.Show("Phiếu giao hàng " + strMaPGH + " này chưa tồn tại!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu giao hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string strSql = "DELETE PhieuGiaoHang WHERE MaPGH='" + strMaPGH + "'";
                    conn.updateToDatabase(strSql);
                    MessageBox.Show("Xóa phiếu giao hàng thành công!");
                    createTable_PhieuGiaoHang();
                }
                catch
                {
                    MessageBox.Show("Xóa phiếu giao hàng thất bại!");
                }
            }
            else
                MessageBox.Show("Phiếu giao hàng đã hoàn thành, không thể xóa!");
        }
    }
}
