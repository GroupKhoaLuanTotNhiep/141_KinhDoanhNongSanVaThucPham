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
    public partial class UC_BanHang : UserControl
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        KhachHang khachHang = new KhachHang();
        LoHang loHang = new LoHang();
        SanPham sanPham = new SanPham();
        KhuyenMai khuyenMai = new KhuyenMai();
        HoaDon hoaDon = new HoaDon();
        HinhThucThanhToan hinhThuc = new HinhThucThanhToan();
        public static string mahd = "";

        public UC_BanHang()
        {
            InitializeComponent();
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        void loadComboBoxKhachHang()
        {
            cbbKhachHang.DataSource = khachHang.loadKhachHang();
            cbbKhachHang.DisplayMember = "MaKH";
            cbbKhachHang.ValueMember = "MaKH";
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

        void createTable_HoaDon()
        {
            dataGV_HoaDon.DataSource = hoaDon.loadDataGV_HoaDon();
        }

        void createTable_CTHD()
        {
            dataGV_CTBanHang.DataSource = hoaDon.loadDataGV_CTHDTheoMaHD(txtMaHoaDon.Text);
        }

        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Text = frmDangNhap.maNV;
            createTable_HoaDon();
            //loadComboBoxNhanVien();
            loadComboBoxKhachHang();
            loadComboBoxSanPham();
            loadComboBoxKhuyenMai();
            loadComboBoxHinhThuc();
            loadComboBoxTinhTrang();
            txtMaHoaDon.Enabled = false;
            txtGiaBan.Enabled = txtTongTien.Enabled = txtTienPhaiTra.Enabled = txtKhauTru.Enabled = false;
            cbbDonViTinh.Enabled = cbbGiamGia.Enabled = cbbTinhTrangHD.Enabled = cbbKhuyenMai.Enabled = cbbNhanVien.Enabled = false;
            btnLuuHD.Enabled = btnSuaHD.Enabled = btnXoaCTHD.Enabled = btnTichDiem.Enabled = btnCapNhatDiem.Enabled = btnLayNo.Enabled = false;
        }

        void loadComboBoxTinhTrang()
        {
            string[] tinhTrang = { "Chưa giao hàng", "Đã giao hàng", "Hủy hàng"};
            foreach (string s in tinhTrang)
                cbbTinhTrangHD.Items.Add(s);
            cbbTinhTrangHD.SelectedIndex = 0;
        }

        void loadComboBoxHinhThuc()
        {
            cbbHinhThuc.DataSource = hinhThuc.loadHinhThuc();
            cbbHinhThuc.DisplayMember = "TenHT";
            cbbHinhThuc.ValueMember = "MaHT";
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = hoaDon.loadDonViTinhTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbDonViTinh.DisplayMember = "TenDVT";
            cbbDonViTinh.ValueMember = "MaDVT";

            //if (conn.checkExist("LoHang", "MaSP", cbbSanPham.SelectedValue.ToString()))
            //{
            //    cbbLoHang.DataSource = hoaDon.loadLoHangTheoSanPhamChuaHetHan(cbbSanPham.SelectedValue.ToString());
            //    cbbLoHang.DisplayMember = "TenLo";
            //    cbbLoHang.ValueMember = "MaLo";
            //    //if (cbbLoHang.Items.Count > 0)
            //    //    cbbLoHang.SelectedText = " ";
            //    if (cbbLoHang.Items.Count == 0)
            //        cbbLoHang.Text = " ";
            //}
            //else
            //{
            //    cbbLoHang.DataSource = hoaDon.loadLoHangTheoSanPhamChuaHetHan(cbbSanPham.SelectedValue.ToString());
            //    cbbLoHang.DisplayMember = "";
            //    cbbLoHang.ValueMember = "MaLo";
            //    cbbLoHang.Text = " ";
            //}
            txtGiaBan.Text = hoaDon.layGiaBanTheoSanPham(cbbSanPham.SelectedValue.ToString());
            cbbGiamGia.Text = hoaDon.layGiamGiaTheoSanPham(cbbSanPham.SelectedValue.ToString());
        }

        private void txtSoLuongBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Clear();
            txtNgayLap.Text = DateTime.Now.ToString();
            txtNgayGiao.Text = DateTime.Now.ToString();
            txtTongTien.Text = "0";
            txtTienPhaiTra.Text = "0";
            txtGhiChu.Clear();
            //cbbNhanVien.SelectedIndex = 0;
            cbbNhanVien.Text = frmDangNhap.maNV;
            cbbKhachHang.SelectedIndex = 0;
            cbbKhuyenMai.SelectedIndex = 0;
            cbbSanPham.SelectedIndex = 0;
            cbbTinhTrangHD.SelectedIndex = 0;
            cbbDonViTinh.Text = "";
            cbbGiamGia.Text = "";
            txtSoLuongBan.Clear();
            txtGiaBan.Clear();
            loadComboBoxKhachHang();
            createTable_CTHD();
            btnLuuHD.Enabled = btnLayNo.Enabled = true;
            cbbKhuyenMai.Enabled = false;
        }

        //public int laySoNgay()
        //{
        //    string layMaGia = sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim()));
        //    string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
        //    string strLoHang = loHang.layMaLo(layMaGia, strSanPham);
        //    string strHanSuDung = loHang.layHanSuDung(strLoHang);
        //    DateTime ngayht = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    DateTime hsd = Convert.ToDateTime(strHanSuDung);
        //    TimeSpan Time = ngayht - hsd;
        //    int TongSoNgay = Time.Days;
        //    return TongSoNgay;
        //}

        public bool kiemTraNgayLapVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayLap = DateTime.ParseExact(txtNgayLap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayLap).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strNgayLap).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strNgayLap).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        public bool kiemTraNgayLapVaNgayGiao()
        {
            string strNgayLap = DateTime.ParseExact(txtNgayLap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            int ngay = DateTime.Parse(strNgayGiao).Day - DateTime.Parse(strNgayLap).Day;
            int thang = DateTime.Parse(strNgayGiao).Month - DateTime.Parse(strNgayLap).Month;
            int nam = DateTime.Parse(strNgayGiao).Year - DateTime.Parse(strNgayLap).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaHoaDon = txtMaHoaDon.Text.Trim();
                string strNgayLap = DateTime.ParseExact(txtNgayLap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text;
                string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strHinhThuc = cbbHinhThuc.SelectedValue.ToString().Trim();
                string strTinhTrang = cbbTinhTrangHD.Text.Trim();
                string strTongTien = txtTongTien.Text.Trim();
                string strKhauTru = txtKhauTru.Text.Trim();
                if (strKhauTru == string.Empty)
                {
                    btnLayNo.Focus();
                    return;
                }
                string strTienPhaiTra = txtTienPhaiTra.Text.Trim();
                string strGhiChu = txtGhiChu.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                //Lô còn hạn sử dụng và số lượng
                string strLoHang = loHang.layMaLoHang(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham);
                string strSoLuongBan = txtSoLuongBan.Text.Trim();
                string strGiaBan = txtGiaBan.Text.Trim();
                string strGiamGia = cbbGiamGia.Text.Trim();
                if(strGiamGia == string.Empty)
                {
                    strGiamGia = "0";
                    cbbGiamGia.Text = "0";
                }
                if (strSoLuongBan == string.Empty)
                {
                    txtSoLuongBan.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongBan) * (int.Parse(strGiaBan) - (int.Parse(strGiaBan) * float.Parse(strGiamGia))));

                if(!conn.checkExist("HoaDon", "MaHoaDon", strMaHoaDon))
                {
                    if(kiemTraNgayLapVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày lập phải lớn hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    if(kiemTraNgayLapVaNgayGiao() == false)
                    {
                        MessageBox.Show("Ngày giao phải lớn hơn hoặc là Ngày lập!");
                        return;
                    }
                    string strSqlHD = "INSERT HoaDon VALUES('" + strNhanVien + "', '" + strKhachHang + "', '" + strNgayLap + "', '" + strNgayGiao + "', " + strTongTien + ", " + strTienPhaiTra + ", '" + strHinhThuc + "', '" + strKhuyenMai + "', N'" + strTinhTrang + "', N'" + strGhiChu + "', " + 0 + ")";
                    conn.updateToDatabase(strSqlHD);
                    createTable_HoaDon();
                    MessageBox.Show("Lưu hóa đơn thành công!");
                    txtMaHoaDon.Text = hoaDon.layMaHoaDon();
                }
                if(conn.checkExist("HoaDon", "MaHoaDon", strMaHoaDon))
                {
                    if (hoaDon.layTinhTrang(strMaHoaDon) == "Đã giao hàng" || hoaDon.layTinhTrang(strMaHoaDon) == "Hủy hàng")
                    {
                        MessageBox.Show("Hóa đơn này đã hoàn tất, không thể thêm!");
                        return;
                    }
                    if (!conn.checkExist("SanPham", "MaSP", strSanPham))
                    {
                        MessageBox.Show("Sản phẩm này chưa tồn tại!");
                        return;
                    }
                    if (conn.checkExistTwoKey("ChiTietHoaDon", "MaHoaDon", "MaSP", strMaHoaDon, strSanPham))
                    {
                        MessageBox.Show("Trùng khóa chính rồi!");
                        return;
                    }
                    if(float.Parse(strSoLuongBan) > float.Parse(hoaDon.laySoLuongSPTheoSanPham(strSanPham)))
                    {
                        MessageBox.Show("Không đủ số lượng sản phẩm để bán!");
                        return;
                    }
                    if(!conn.checkExist("LoHang", "MaSP", strSanPham))
                    {
                        MessageBox.Show("Sản phẩm này chưa được nhập vào kho/lô!");
                        return;
                    }
                    //if (float.Parse(loHang.laySLTheoGiaVaSanPham(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham)) == 0)
                    //{
                    //    MessageBox.Show("Sản phẩm này đã hết số lượng trong lô!");
                    //    return;
                    //}
                    //if (laySoNgay() < 0)
                    //{
                    //    MessageBox.Show("Sản phẩm này đã hết hạn sử dụng!");
                    //    return;
                    //}
                    if(float.Parse(strSoLuongBan) > float.Parse(loHang.laySoLuong(strLoHang)))
                    {
                        MessageBox.Show("Lô này không đủ sản phẩm để bán!");
                        return;
                    }
                    string strSqlCTHD = "INSERT ChiTietHoaDon VALUES('" + strMaHoaDon + "', '" + strSanPham + "', " + strSoLuongBan + ", " + strGiaBan + ", " + thanhTien + ")";
                    conn.updateToDatabase(strSqlCTHD);
                    createTable_CTHD();
                    MessageBox.Show("Lưu chi tiết hóa đơn thành công!");
                    string strSqlUPLH = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) - float.Parse(hoaDon.laySoLuongBan(strMaHoaDon, strSanPham))) + " From LoHang, SanPham WHERE LoHang.MaSP = SanPham.MaSP AND MaLo='" + strLoHang + "' AND LoHang.MaSP='" + strSanPham + "'";
                    conn.updateToDatabase(strSqlUPLH);
                
                    strTongTien = hoaDon.updateTongTien(strMaHoaDon).ToString();
                    txtTongTien.Text = strTongTien;
                    string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                    string strTichDiem = khachHang.layTichDiem(strKhachHang);
                    string strTichLuy = khuyenMai.layTichLuy(strKhuyenMai);
                    int khauTruCu = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(strMaHoaDon));
                    int tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - khauTruCu;
                    if (tienTra < 0)
                    {
                        string strSqlKH = "UPDATE KhachHang SET CongNo=" + Math.Abs(tienTra) + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlKH);
                        txtKhauTru.Text = (khauTruCu - Math.Abs(tienTra)).ToString();
                        tienTra = 0;
                    }
                    else
                    {
                        string strSqlKH = "UPDATE KhachHang SET CongNo=" + 0 + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlKH);
                        strKhauTru = (int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - tienTra).ToString();
                        txtKhauTru.Text = strKhauTru;
                    }
                    if ((int.Parse(strTichDiem) - int.Parse(strTichLuy) >= 0))
                    {
                        string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(strTichLuy)) + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlUDKH);
                    }
                    else
                    {
                        string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem)) + " WHERE MaKH='" + strKhachHang + "'";
                        conn.updateToDatabase(strSqlUDKH);
                    }
                    //int tienTra = 0;
                    //string strTichDiem = khachHang.layTichDiem(strKhachHang);
                    //string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                    //if (cbbKhuyenMai.Text.Trim() == "Voucher 0%" || cbbKhuyenMai.SelectedIndex == -1)
                    //{
                    //    tienTra = int.Parse(strTongTien);
                    //}
                    //else if (cbbKhuyenMai.Text.Trim() == "Voucher 10%" && int.Parse(strTichDiem) >= 3)
                    //{
                    //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                    //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 3) + " WHERE MaKH='" + strKhachHang + "'";
                    //    conn.updateToDatabase(strSqlKH); 
                    //}
                    //else if (cbbKhuyenMai.Text.Trim() == "Voucher 20%" && int.Parse(strTichDiem) >= 7)
                    //{
                    //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                    //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 7) + " WHERE MaKH='" + strKhachHang + "'";
                    //    conn.updateToDatabase(strSqlKH);
                    //}
                    //else if (cbbKhuyenMai.Text.Trim() == "Voucher 30%" && int.Parse(strTichDiem) >= 10)
                    //{
                    //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                    //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 10) + " WHERE MaKH='" + strKhachHang + "'";
                    //    conn.updateToDatabase(strSqlKH);
                    //}
                    //else if (cbbKhuyenMai.Text.Trim() == "Voucher 40%" && int.Parse(strTichDiem) >= 15)
                    //{
                    //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                    //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 15) + " WHERE MaKH='" + strKhachHang + "'";
                    //    conn.updateToDatabase(strSqlKH);
                    //}
                    //else if (cbbKhuyenMai.Text.Trim() == "Voucher 50%" && int.Parse(strTichDiem) >= 20)
                    //{
                    //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                    //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 20) + " WHERE MaKH='" + strKhachHang + "'";
                    //    conn.updateToDatabase(strSqlKH);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Bạn không đủ điểm để sử dụng khuyến mãi này!");
                    //    tienTra = int.Parse(strTongTien);
                    //    return;
                    //}
                    txtTienPhaiTra.Text = String.Format("{0:0,0}", tienTra);
                    string strSqlUDHD = "UPDATE HoaDon SET TongTien=" + strTongTien + ", TienPhaiTra=" + tienTra + ", KhauTru=" + txtKhauTru.Text + " WHERE MaHoaDon='" + strMaHoaDon + "'";
                    conn.updateToDatabase(strSqlUDHD);
                    createTable_HoaDon();
                    btnXoaCTHD.Enabled = btnSuaHD.Enabled = false;
                    //if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) >= 100000)
                    //{
                    //    btnTichDiem.Enabled = true;
                    //    btnCapNhatDiem.Enabled = false;
                    //}
                }
            }
            catch
            {
                MessageBox.Show("Quá trình lưu thất bại (Có thể do hết HSD hoặc hết số lượng trong lô)!");
            }
        }

        private void btnTichDiem_Click(object sender, EventArgs e)
        {
            try
            {
                string mayeucau = khuyenMai.layMaYeuCau();
                string strMaHoaDon = txtMaHoaDon.Text.Trim();
                string strKhachHang = cbbKhachHang.SelectedValue.ToString();
                string strTichDiem = khachHang.layTichDiem(strKhachHang);
                if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) >= int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)) && int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonLon(mayeucau)))
                {
                    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) + int.Parse(khuyenMai.layTichDiemBT(mayeucau))) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    MessageBox.Show("Lưu tích điểm thành công!");
                    btnTichDiem.Enabled = false;
                }
                else if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) >= int.Parse(khuyenMai.layGTHoaDonLon(mayeucau)))
                {
                    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) + int.Parse(khuyenMai.layTichDiemLon(mayeucau))) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    MessageBox.Show("Lưu tích điểm thành công!");
                    btnTichDiem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Tổng tiền hóa đơn của bạn không đủ để tích điểm!");
                    btnTichDiem.Enabled = false;
                }
                
            }
            catch
            {
                MessageBox.Show("Lưu tích điểm không thành công!");
                btnTichDiem.Enabled = false;
            }

        }

        private void dataGV_CTBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaHoaDon.Text = dataGV_CTBanHang.Rows[index].Cells[0].Value.ToString();
            cbbSanPham.Text = dataGV_CTBanHang.Rows[index].Cells[1].Value.ToString();
            txtSoLuongBan.Text = dataGV_CTBanHang.CurrentRow.Cells[2].Value.ToString();
            txtGiaBan.Text = dataGV_CTBanHang.Rows[index].Cells[3].Value.ToString();
            cbbGiamGia.Text = dataGV_CTBanHang.Rows[index].Cells[4].Value.ToString();
            btnXoaCTHD.Enabled = btnSuaHD.Enabled = true;
            
        }

        private void dataGV_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaHoaDon.Text = dataGV_HoaDon.Rows[index].Cells[0].Value.ToString();
            cbbNhanVien.Text = dataGV_HoaDon.Rows[index].Cells[1].Value.ToString();
            cbbKhachHang.Text = dataGV_HoaDon.Rows[index].Cells[2].Value.ToString();
            txtNgayLap.Text = dataGV_HoaDon.Rows[index].Cells[3].Value.ToString();
            txtNgayGiao.Text = dataGV_HoaDon.Rows[index].Cells[4].Value.ToString();
            txtTongTien.Text = dataGV_HoaDon.Rows[index].Cells[5].Value.ToString();
            txtTienPhaiTra.Text = dataGV_HoaDon.Rows[index].Cells[6].Value.ToString();
            cbbHinhThuc.Text = hinhThuc.layTenHTTT(dataGV_HoaDon.Rows[index].Cells[7].Value.ToString());
            cbbKhuyenMai.Text = khuyenMai.layTenKhuyenMai(dataGV_HoaDon.Rows[index].Cells[8].Value.ToString());
            cbbTinhTrangHD.Text = dataGV_HoaDon.Rows[index].Cells[9].Value.ToString();
            txtGhiChu.Text = dataGV_HoaDon.Rows[index].Cells[10].Value.ToString();
            txtKhauTru.Text = dataGV_HoaDon.Rows[index].Cells[11].Value.ToString();
            string a = dataGV_HoaDon.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHoaDon.DataSource = hoaDon.layChiTietHoaDon(a);
            dataGV_CTBanHang.DataSource = hoaDon.layCTHD(a);
            btnSuaHD.Enabled = btnLayNo.Enabled = true;
            cbbKhuyenMai.Enabled = cbbTinhTrangHD.Enabled = true;
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaHoaDon = txtMaHoaDon.Text.Trim();
                string strNgayLap = DateTime.ParseExact(txtNgayLap.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNgayGiao = DateTime.ParseExact(txtNgayGiao.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strNhanVien = cbbNhanVien.Text;
                string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strHinhThuc = cbbHinhThuc.SelectedValue.ToString().Trim();
                string strTinhTrang = cbbTinhTrangHD.Text.Trim();
                string strTongTien = txtTongTien.Text.Trim();
                string strTienPhaiTra = txtTienPhaiTra.Text.Trim();
                string strGhiChu = txtGhiChu.Text.Trim();
                string strKhauTru = txtKhauTru.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                //Lô còn hạn sử dụng, không quan tâm số lượng
                string strLoHang = loHang.layMaLoHetHang(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham);
                string strSoLuongBan = txtSoLuongBan.Text.Trim();
                string strGiaBan = txtGiaBan.Text.Trim();
                string strGiamGia = cbbGiamGia.Text.Trim();
                if (strGiamGia == string.Empty)
                {
                    strGiamGia = "0";
                    cbbGiamGia.Text = "0";
                }
                if (strSoLuongBan == string.Empty)
                {
                    txtSoLuongBan.Focus();
                    return;
                }
                int thanhTien = (int)(float.Parse(strSoLuongBan) * (int.Parse(strGiaBan) - (int.Parse(strGiaBan) * float.Parse(strGiamGia))));

                if (!conn.checkExist("HoaDon", "MaHoaDon", strMaHoaDon))
                {
                    MessageBox.Show("Mã hóa đơn này không tồn tại!");
                    return;
                }

                //if (kiemTraNgayLapVaNgayHT() == false)
                //{
                //    MessageBox.Show("Ngày lập phải lớn hơn hoặc là Ngày hiện tại!");
                //    return;
                //}
                if(kiemTraNgayLapVaNgayGiao() == false)
                {
                    MessageBox.Show("Ngày giao phải lớn hơn hoặc là Ngày lập!");
                    return;
                }
                if (hoaDon.layTinhTrang(strMaHoaDon) == "Đã giao hàng" || hoaDon.layTinhTrang(strMaHoaDon) == "Hủy hàng")
                {
                    MessageBox.Show("Hóa đơn này đã hoàn tất, không thể sửa!");
                    return;
                }
                string strSqlHD = "UPDATE HoaDon SET MaKH='" + strKhachHang + "', NgayLap='" + strNgayLap + "', NgayGiao='" + strNgayGiao + "', MaTH='" + strHinhThuc + "', MaKM='" + strKhuyenMai + "', TinhTrang=N'" + strTinhTrang + "', GhiChu=N'" + strGhiChu + "' WHERE MaHoaDon='" + strMaHoaDon + "'";
                conn.updateToDatabase(strSqlHD);
                createTable_HoaDon();
                MessageBox.Show("Cập nhật hóa đơn thành công!");

                if (!conn.checkExistTwoKey("ChiTietHoaDon", "MaHoaDon", "MaSP", strMaHoaDon, strSanPham))
                {
                    MessageBox.Show("Khóa chính này chưa có tồn tại!");
                    return;
                }
                if (!conn.checkExist("LoHang", "MaSP", strSanPham))
                {
                    MessageBox.Show("Sản phẩm này chưa được nhập vào kho/lô!");
                    return;
                }
                //if (float.Parse(loHang.laySLTheoGiaVaSanPham(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham)) == 0)
                //{
                //    MessageBox.Show("Sản phẩm này đã hết số lượng trong lô!");
                //    return;
                //}
                //if (loHang.laySoNgay(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham) < 0)
                //{
                //    MessageBox.Show("Sản phẩm này đã hết hạn sử dụng!");
                //    return;
                //}
                if (float.Parse(strSoLuongBan) > float.Parse(hoaDon.laySoLuongSPTheoSanPham(strSanPham)))
                {
                    MessageBox.Show("Không đủ số lượng sản phẩm để bán!");
                    return;
                }
                string strSqlUPLHCu = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(hoaDon.laySoLuongBan(strMaHoaDon, strSanPham))) + " From LoHang, SanPham WHERE LoHang.MaSP = SanPham.MaSP AND MaLo='" + strLoHang + "' AND LoHang.MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUPLHCu);
                if (float.Parse(strSoLuongBan) > float.Parse(loHang.laySoLuong(strLoHang)))
                {
                    MessageBox.Show("Lô này không đủ sản phẩm để bán - Số lượng lô (" + float.Parse(loHang.laySoLuong(strLoHang)) + ")");
                    return;
                }
                string strSqlCTHD = "UPDATE ChiTietHoaDon SET SoLuongBan=" + strSoLuongBan + ", GiaBan=" + strGiaBan + ", ThanhTien=" + thanhTien + " WHERE MaHoaDon='" + strMaHoaDon + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlCTHD);
                createTable_CTHD();
                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!");
                string strSqlUPLHMoi = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strLoHang)) - float.Parse(hoaDon.laySoLuongBan(strMaHoaDon, strSanPham))) + " From LoHang, SanPham WHERE LoHang.MaSP = SanPham.MaSP AND MaLo='" + strLoHang + "' AND LoHang.MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUPLHMoi);

                strTongTien = hoaDon.updateTongTien(strMaHoaDon).ToString();
                txtTongTien.Text = strTongTien;
                string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                string strTichDiem = khachHang.layTichDiem(strKhachHang);
                string strTichLuy = khuyenMai.layTichLuy(strKhuyenMai);
                int khauTruCu = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(strMaHoaDon));
                int tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - khauTruCu;
                if (tienTra < 0)
                {
                    string strSqlKH = "UPDATE KhachHang SET CongNo=" + Math.Abs(tienTra) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    txtKhauTru.Text = (khauTruCu - Math.Abs(tienTra)).ToString();
                    tienTra = 0;
                }
                else
                {
                    string strSqlKH = "UPDATE KhachHang SET CongNo=" + 0 + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    strKhauTru = (int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - tienTra).ToString();
                    txtKhauTru.Text = strKhauTru;
                }
                if((int.Parse(strTichDiem) - int.Parse(strTichLuy) >= 0))
                {
                    string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(strTichLuy)) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlUDKH);
                }
                else
                {
                    string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem)) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlUDKH);
                }
                //int tienTra = 0;
                //string strTichDiem = khachHang.layTichDiem(strKhachHang);
                //string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                //if (cbbKhuyenMai.Text.Trim() == "Voucher 0%" || cbbKhuyenMai.SelectedIndex == -1)
                //{
                //    tienTra = int.Parse(strTongTien);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 10%" && int.Parse(strTichDiem) >= 3)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 3) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 20%" && int.Parse(strTichDiem) >= 7)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 7) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 30%" && int.Parse(strTichDiem) >= 10)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 10) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 40%" && int.Parse(strTichDiem) >= 15)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 15) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 50%" && int.Parse(strTichDiem) >= 20)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 20) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else
                //{
                //    MessageBox.Show("Bạn không đủ điểm để sử dụng khuyến mãi này!");
                //    tienTra = int.Parse(strTongTien);
                //    return;
                //}
                txtTienPhaiTra.Text = String.Format("{0:0,0}", tienTra);
                string strSqlUDHD = "UPDATE HoaDon SET TongTien=" + strTongTien + ", TienPhaiTra=" + tienTra + ", KhauTru=" + txtKhauTru.Text + " WHERE MaHoaDon='" + strMaHoaDon + "'";
                conn.updateToDatabase(strSqlUDHD);
                createTable_HoaDon();
                btnXoaCTHD.Enabled = btnSuaHD.Enabled = false;
                string mayeucau = khuyenMai.layMaYeuCau();
                if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)) || int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonLon(mayeucau)))
                {
                    btnCapNhatDiem.Enabled = true;
                    btnTichDiem.Enabled = false;               
                }
            }
            catch
            {
                MessageBox.Show("Quá trình cập nhật thất bại (Có thể do HSD hoặc hết số lượng trong lô)!");
            }
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaHoaDon = txtMaHoaDon.Text.Trim();
                string strSanPham = cbbSanPham.SelectedValue.ToString().Trim();
                string strLoHang = loHang.layMaLoHetHang(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham);
                string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strTongTien = txtTongTien.Text.Trim();
                string strTienPhaiTra = txtTienPhaiTra.Text.Trim();
                string strKhauTru = txtKhauTru.Text.Trim();
                float soLuong = float.Parse(loHang.laySoLuong(strLoHang)) + float.Parse(hoaDon.laySoLuongBan(strMaHoaDon, strSanPham));

                if (!conn.checkExistTwoKey("ChiTietHoaDon", "MaHoaDon", "MaSP", strMaHoaDon, strSanPham))
                {
                    MessageBox.Show("Khóa chính này chưa tồn tại!");
                    return;
                }
                if (hoaDon.layTinhTrang(strMaHoaDon) == "Đã giao hàng" || hoaDon.layTinhTrang(strMaHoaDon) == "Hủy hàng")
                {
                    MessageBox.Show("Hóa đơn này đã hoàn tất, không thể xóa chi tiết!");
                    return;
                }
                if (!conn.checkExist("LoHang", "MaSP", strSanPham))
                {
                    MessageBox.Show("Sản phẩm này chưa được nhập vào kho/lô!");
                    return;
                }
                //if (int.Parse(loHang.laySLTheoGiaVaSanPham(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text.Trim())), strSanPham)) == 0)
                //{
                //    MessageBox.Show("Sản phẩm này đã hết số lượng trong lô!");
                //    return;
                //}
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSql = "DELETE ChiTietHoaDon WHERE MaHoaDon='" + strMaHoaDon + "' AND MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSql);
                MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                createTable_CTHD();
                string strSqlUPLH = "UPDATE LoHang SET SoLuong=" + soLuong + " From LoHang, SanPham WHERE LoHang.MaSP = SanPham.MaSP AND MaLo='" + strLoHang + "' AND LoHang.MaSP='" + strSanPham + "'";
                conn.updateToDatabase(strSqlUPLH);

                strTongTien = hoaDon.updateTongTien(strMaHoaDon).ToString();
                txtTongTien.Text = strTongTien;
                string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                string strTichDiem = khachHang.layTichDiem(strKhachHang);
                string strTichLuy = khuyenMai.layTichLuy(strKhuyenMai);
                int khauTruCu = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(strMaHoaDon));
                int tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - khauTruCu;
                if (tienTra < 0)
                {
                    string strSqlKH = "UPDATE KhachHang SET CongNo=" + Math.Abs(tienTra) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    txtKhauTru.Text = (khauTruCu - Math.Abs(tienTra)).ToString();
                    tienTra = 0;
                }
                else
                {
                    string strSqlKH = "UPDATE KhachHang SET CongNo=" + 0 + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    strKhauTru = (int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM)) - tienTra).ToString();
                    txtKhauTru.Text = strKhauTru;
                }
                if ((int.Parse(strTichDiem) - int.Parse(strTichLuy) >= 0))
                {
                    string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(strTichLuy)) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlUDKH);
                }
                else
                {
                    string strSqlUDKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem)) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlUDKH);
                }
                //int tienTra = 0;
                //string strTichDiem = khachHang.layTichDiem(strKhachHang);
                //string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                //if (cbbKhuyenMai.Text.Trim() == "Voucher 0%" || cbbKhuyenMai.SelectedIndex == -1)
                //{
                //    tienTra = int.Parse(strTongTien);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 10%" && int.Parse(strTichDiem) >= 3)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 3) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 20%" && int.Parse(strTichDiem) >= 7)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 7) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 30%" && int.Parse(strTichDiem) >= 10)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 10) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 40%" && int.Parse(strTichDiem) >= 15)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 15) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else if (cbbKhuyenMai.Text.Trim() == "Voucher 50%" && int.Parse(strTichDiem) >= 20)
                //{
                //    tienTra = int.Parse(strTongTien) - (int)(int.Parse(strTongTien) * float.Parse(strGiaTriKM));
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - 20) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else
                //{
                //    MessageBox.Show("Bạn không đủ điểm để sử dụng khuyến mãi này!");
                //    tienTra = int.Parse(strTongTien);
                //    return;
                //}
                txtTienPhaiTra.Text = String.Format("{0:0,0}", tienTra);
                string strSqlUDHD = "UPDATE HoaDon SET TongTien=" + strTongTien + ", TienPhaiTra=" + tienTra + ", KhauTru=" + txtKhauTru.Text + " WHERE MaHoaDon='" + strMaHoaDon + "'";
                conn.updateToDatabase(strSqlUDHD);
                createTable_HoaDon();
                btnXoaCTHD.Enabled = btnSuaHD.Enabled = false;
                string mayeucau = khuyenMai.layMaYeuCau();
                if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)) || int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonLon(mayeucau)))
                {
                    btnCapNhatDiem.Enabled = true;
                    btnTichDiem.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Xóa chi tiết hóa đơn thất bại!");
            }
        }

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            try
            {
                string mayeucau = khuyenMai.layMaYeuCau();
                string strMaHoaDon = txtMaHoaDon.Text.Trim();
                string strKhachHang = cbbKhachHang.SelectedValue.ToString();
                string strTichDiem = khachHang.layTichDiem(strKhachHang);
                if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) >= int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)) && int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonLon(mayeucau)))
                {
                    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(khuyenMai.layTichDiemLon(mayeucau))) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    MessageBox.Show("Cập nhật điểm thành công!");
                    btnCapNhatDiem.Enabled = false;
                }
                else if (int.Parse(hoaDon.layTongTien(strMaHoaDon)) < int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)))
                {
                    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(khuyenMai.layTichDiemBT(mayeucau))) + " WHERE MaKH='" + strKhachHang + "'";
                    conn.updateToDatabase(strSqlKH);
                    MessageBox.Show("Cập nhật điểm thành công!");
                    btnCapNhatDiem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Tổng tiền hóa đơn của bạn đã phù hợp!");
                    btnCapNhatDiem.Enabled = false;
                }

            }
            catch
            {
                MessageBox.Show("Cập nhật điểm không thành công!");
                btnCapNhatDiem.Enabled = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn tìm kiếm theo hóa đơn?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                if (conn.checkExist("HoaDon", "MaHoaDon", txtTimKiem.Text.Trim()))
                {
                    dataGV_HoaDon.DataSource = hoaDon.searchHoaDon(txtTimKiem.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn này!");
                    createTable_HoaDon();
                }
            }
            else if(result == DialogResult.No)
            {
                if (conn.checkExist("HoaDon", "MaKH", txtTimKiem.Text.Trim()))
                {
                    dataGV_HoaDon.DataSource = hoaDon.searchHoaDonTheoMaKH(txtTimKiem.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng này!");
                    createTable_HoaDon();
                }
            }
            else
                createTable_HoaDon();
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            dataGV_HoaDon.DataSource = hoaDon.searchHoaDonTheoNgayLap(txtNgayDau.Text, txtNgayCuoi.Text);
        }

        private void btnHuyHang_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = txtMaHoaDon.Text.Trim();
                string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                if (hoaDon.layTinhTrang(mahd) == "Đã giao hàng" || hoaDon.layTinhTrang(mahd) == "Hủy hàng")
                {
                    MessageBox.Show("Đơn hàng " + mahd + " đã được xử lý xong!");
                    return;
                }
                if(conn.checkExist("PhieuGiaoHang", "MaHoaDon", mahd))
                {
                    MessageBox.Show("Đơn hàng " + mahd + " đã được lập phiếu giao, không thể hủy!");
                    return;
                }
                for (int i = 0; i < dataGV_CTBanHang.RowCount - 1; i++)
                {
                    string masp = dataGV_CTBanHang.Rows[i].Cells["MaSP"].Value.ToString().Trim();
                    string gia = dataGV_CTBanHang.Rows[i].Cells["GiaBan"].Value.ToString().Trim();
                    string malo = loHang.layMaLo(sanPham.layMaGiaBanTheoTenGia(int.Parse(gia)), masp);
                    float soluong = float.Parse(dataGV_CTBanHang.Rows[i].Cells["SoLuongBan"].Value.ToString().Trim());
                    if (conn.checkExistTwoKey("LoHang", "MaLo", "MaSP", malo, masp))
                    {
                        string strSQLLo = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(malo)) + soluong) + " WHERE MaLo='" + malo + "'";
                        conn.updateToDatabase(strSQLLo);
                    }
                    string strSQLSP = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(sanPham.laySoLuongSPTheoSanPham(masp)) + soluong) + " WHERE MaSP='" + masp + "'";
                    conn.updateToDatabase(strSQLSP);                   
                }
                int tichDiem = int.Parse(khachHang.layTichDiem(strKhachHang)) + int.Parse(khuyenMai.layTichLuy(strKhuyenMai));
                int congNo = int.Parse(khachHang.layCongNo(strKhachHang)) + int.Parse(hoaDon.layKhauTru(mahd)) + int.Parse(hoaDon.layTienPhaiTra(mahd));
                string strSqlKH = "UPDATE KhachHang SET TichDiem=" + tichDiem + ", CongNo=" + congNo + " WHERE MaKH='" + strKhachHang + "'";
                conn.updateToDatabase(strSqlKH);
                string strSQLHD = "UPDATE HoaDon SET TinhTrang=N'Hủy hàng' WHERE MaHoaDon='" + mahd + "'";
                conn.updateToDatabase(strSQLHD);
                createTable_HoaDon();
                MessageBox.Show("Hủy hàng thành công!");
            }
            catch
            {
                MessageBox.Show("Hủy hàng thất bại!");
            }
        }

        private void btnLapPhieuGiao_Click(object sender, EventArgs e)
        {
            mahd = txtMaHoaDon.Text;
            if (cbbTinhTrangHD.Text == "Chưa giao hàng")
            {
                frmGiaoHang giaoHang = new frmGiaoHang();
                giaoHang.Show();
            }
            else
                MessageBox.Show("Đơn hàng đã được giao!");
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            frmThemKhachHang kh = new frmThemKhachHang();
            kh.ShowDialog();
        }

        private void btnLayNo_Click(object sender, EventArgs e)
        {
            txtKhauTru.Text = khachHang.layCongNo(cbbKhachHang.Text.Trim());
            btnLayNo.Enabled = false;
        }

        private void cbbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                //string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                //string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                //string strTichDiem = khachHang.layTichDiem(strKhachHang);
                //string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                //string strTichLuy = khuyenMai.layTichLuy(strKhuyenMai);
                //if (int.Parse(strTichDiem) >= int.Parse(strTichLuy))
                //{
                //    int tienPhaiTra = 0;
                //    tienPhaiTra = int.Parse(txtTongTien.Text) - (int)(int.Parse(txtTongTien.Text) * float.Parse(strGiaTriKM));
                //    txtTienPhaiTra.Text = tienPhaiTra.ToString();
                //    string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(strTichLuy)) + " WHERE MaKH='" + strKhachHang + "'";
                //    conn.updateToDatabase(strSqlKH);
                //}
                //else
                //{
                //    MessageBox.Show("Bạn không đủ điểm để sử dụng khuyến mãi này!");
                //    return;
                //}
            //}
            //catch
            //{
            //    MessageBox.Show("Bị lỗi, hãy kiểm tra lại!");
            //}
        }

        private void cbbKhuyenMai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string mayeucau = khuyenMai.layMaYeuCau();
                string strMaHoaHon = txtMaHoaDon.Text.Trim();
                string strKhachHang = cbbKhachHang.SelectedValue.ToString().Trim();
                string strKhuyenMai = cbbKhuyenMai.SelectedValue.ToString().Trim();
                string strTichDiem = khachHang.layTichDiem(strKhachHang);
                string strGiaTriKM = khuyenMai.layGiaTriKM(strKhuyenMai);
                string strTichLuy = khuyenMai.layTichLuy(strKhuyenMai);
                if (int.Parse(strTichDiem) >= int.Parse(strTichLuy))
                {
                    int tienPhaiTra = 0;
                    tienPhaiTra = int.Parse(txtTongTien.Text) - (int)(int.Parse(txtTongTien.Text) * float.Parse(strGiaTriKM));
                    txtTienPhaiTra.Text = tienPhaiTra.ToString();
                    //string strSqlKH = "UPDATE KhachHang SET TichDiem=" + (int.Parse(strTichDiem) - int.Parse(strTichLuy)) + " WHERE MaKH='" + strKhachHang + "'";
                    //conn.updateToDatabase(strSqlKH);
                    if (int.Parse(hoaDon.layTongTien(strMaHoaHon)) >= int.Parse(khuyenMai.layGTHoaDonBT(mayeucau)))
                    {
                        btnTichDiem.Enabled = true;
                        btnCapNhatDiem.Enabled = false;
                    }
                    else
                    {
                        btnCapNhatDiem.Enabled = true;
                        btnTichDiem.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không đủ điểm để sử dụng khuyến mãi này!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Bị lỗi, hãy kiểm tra lại!");
            }
        }

        private void btnInReport_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = txtMaHoaDon.Text.Trim();
                frmReportHoaDonBanHang rptHD = new frmReportHoaDonBanHang(mahd);
                rptHD.ShowDialog();
            }
            catch { }
        }

        private void btnInTatCaHD_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_HD(dataGV_HoaDon, saveFileDialog1.FileName);
        }
        private void exportExcel_HD(DataGridView dv, string fileName)
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
                worksheet.Name = "Báo cáo hóa đơn";

                worksheet.Cells[2, 2] = "BÁO CÁO HÓA ĐƠN";
                worksheet.Cells[3, 2] = "Từ " + txtNgayDau.Text + "đến " + txtNgayCuoi.Text;

                int tkshh = dataGV_HoaDon.RowCount;
                for (int i = 0; i < dataGV_HoaDon.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_HoaDon.Columns[i].HeaderText;
                    worksheet.Cells[tkshh + 6, 6] = (dataGV_HoaDon.DataSource as DataTable).Compute("Sum(TongTien)", "");
                    worksheet.Cells[tkshh + 6, 7] = (dataGV_HoaDon.DataSource as DataTable).Compute("Sum(TienPhaiTra)", "");
                }

                for (int i = 0; i < dataGV_HoaDon.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_HoaDon.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_HoaDon.Rows[i].Cells[j].Value.ToString();

                    }
                }

                worksheet.Cells[tkshh + 6, 1] = "Tổng";
                worksheet.Range["A" + (tkshh + 6), "L" + (tkshh + 6)].Font.Bold = true;
                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 8.78;
                worksheet.Range["B1"].ColumnWidth = 8;
                worksheet.Range["C1"].ColumnWidth = 9.56;
                worksheet.Range["D1"].ColumnWidth = 16.78;
                worksheet.Range["E1"].ColumnWidth = 16.78;
                worksheet.Range["F1"].ColumnWidth = 12.11;
                worksheet.Range["G1"].ColumnWidth = 13.56;
                worksheet.Range["H1"].ColumnWidth = 8.78;
                worksheet.Range["I1"].ColumnWidth = 9.89;
                worksheet.Range["J1"].ColumnWidth = 15.44;
                worksheet.Range["K1"].ColumnWidth = 8.78;
                worksheet.Range["L1"].ColumnWidth = 11.11;

                //Định dạng fone chữ
                worksheet.Range["A1", "L100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "L100"].Font.Size = 13;
                worksheet.Range["A2", "L2"].MergeCells = true;
                worksheet.Range["A2", "L2"].Font.Bold = true;
                worksheet.Range["A2", "L2"].Font.Size = 15;

                worksheet.Range["A3", "L3"].MergeCells = true;
                worksheet.Range["A3", "L3"].Font.Italic = true;
                worksheet.Range["A3", "L3"].Font.Size = 15;

                worksheet.Range["A5", "L5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "L" + (tkshh + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "L2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "L3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "L5"].HorizontalAlignment = 3;
                worksheet.Range["A5", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["B5", "B" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["C5", "C" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["H5", "H" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["I5", "I" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["L5", "L" + (tkshh + 5)].HorizontalAlignment = 3;

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
