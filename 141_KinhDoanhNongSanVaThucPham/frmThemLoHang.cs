using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class frmThemLoHang : Form
    {
        Connection conn = new Connection();
        NhapKho nhapKho = new NhapKho();
        SanPham sanPham = new SanPham();

        public frmThemLoHang(string strMaPN, string strSanPham, string strSoLuongNhap)
        {
            InitializeComponent();
            cbbPhieuNhap.Text = strMaPN;
            cbbSanPham.Text = strSanPham;
            txtSoLuong.Text = strSoLuongNhap;
            cbbGiaBan.DataSource = sanPham.loadGiaBanTheoSanPham(cbbSanPham.Text.Trim());
            cbbGiaBan.DisplayMember = "GiaSP";
            cbbGiaBan.ValueMember = "MaGia";
            txtSoLuong.Enabled = false;
        }

        public frmThemLoHang()
        {
            InitializeComponent();
            
        }

        void loadComboBoxPhieuNhap()
        {
            cbbPhieuNhap.DataSource = nhapKho.loadPhieuNhapHang();
            cbbPhieuNhap.DisplayMember = "MaPNH";
            cbbPhieuNhap.ValueMember = "MaPNH";
        }

        void loadComboBoxSanPham()
        {
            cbbSanPham.DataSource = sanPham.loadSanPham();
            cbbSanPham.DisplayMember = "MaSP";
            cbbSanPham.ValueMember = "MaSP";
        }

        public bool kiemTraNgaySXVaNgayHSD()
        {
            string strNgaySanXuat = DateTime.ParseExact(txtNgaySanXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strHanSuDung = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            int ngay = DateTime.Parse(strHanSuDung).Day - DateTime.Parse(strNgaySanXuat).Day;
            int thang = DateTime.Parse(strHanSuDung).Month - DateTime.Parse(strNgaySanXuat).Month;
            int nam = DateTime.Parse(strHanSuDung).Year - DateTime.Parse(strNgaySanXuat).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay == 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        public bool kiemTraNgaySXVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgaySanXuat = DateTime.ParseExact(txtNgaySanXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strNgayHienTai).Day - DateTime.Parse(strNgaySanXuat).Day;
            int thang = DateTime.Parse(strNgayHienTai).Month - DateTime.Parse(strNgaySanXuat).Month;
            int nam = DateTime.Parse(strNgayHienTai).Year - DateTime.Parse(strNgaySanXuat).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        public bool kiemTraNgayHSDVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strHanSuDung = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(strHanSuDung).Day - DateTime.Parse(strNgayHienTai).Day;
            int thang = DateTime.Parse(strHanSuDung).Month - DateTime.Parse(strNgayHienTai).Month;
            int nam = DateTime.Parse(strHanSuDung).Year - DateTime.Parse(strNgayHienTai).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay == 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnLuuLoHang_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaLo = txtMaLo.Text.Trim() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                string strTenLo = txtTenLo.Text.Trim() + " " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                string strNgaySanXuat = DateTime.ParseExact(txtNgaySanXuat.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strHanSuDung = DateTime.ParseExact(txtHanSuDung.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strSoLuong = txtSoLuong.Text.Trim();
                string strPhieuNhap = cbbPhieuNhap.Text;
                string strSanPham = cbbSanPham.Text;
                string strGiaBan = "";

                if (strMaLo != string.Empty && strTenLo != string.Empty && strSoLuong != string.Empty && strPhieuNhap != string.Empty && strSanPham != string.Empty)
                {
                    if (conn.checkExist("LoHang", "MaLo", strMaLo))
                    {
                        MessageBox.Show("Mã lô " + strMaLo + " này đã tồn tại!");
                        return;
                    }
                    if(conn.checkExistTwoKey("LoHang", "MaPNH", "MaSP", strPhieuNhap, strSanPham))
                    {
                        MessageBox.Show("Phiếu nhập hàng và sản phẩm đã tồn tại với nhau!");
                        return;
                    }
                    if (kiemTraNgaySXVaNgayHSD() == false)
                    {
                        MessageBox.Show("Ngày sản xuất phải nhỏ hơn Hạn sử dụng!");
                        return;
                    }
                    if (kiemTraNgaySXVaNgayHT() == false)
                    {
                        MessageBox.Show("Ngày sản xuất phải nhỏ hơn hoặc là Ngày hiện tại!");
                        return;
                    }
                    if (kiemTraNgayHSDVaNgayHT() == false)
                    {
                        MessageBox.Show("Hạn sử dụng phải lớn hơn Ngày hiện tại!");
                        return;
                    }
                    if (chkGiaBan.Checked)
                    {
                        //cbbGiaBan.Visible = false;
                        //txtGiaBan.Visible = true;
                        strGiaBan = txtGiaBan.Text.Trim();
                        if (int.Parse(strGiaBan) <= int.Parse(nhapKho.layGiaNhapTheoChiTietPhieuNhap(strPhieuNhap, strSanPham)))
                        {
                            MessageBox.Show("Giá bán phải lớn hơn Giá nhập!");
                            return;
                        }
                        if (!conn.checkExist("BangGia", "GiaSP", strGiaBan))
                        {
                            string strSqlBG = "Insert BangGia Values(" + strGiaBan + ")";
                            conn.updateToDatabase(strSqlBG);
                            MessageBox.Show("Đã thêm thông tin giá bán");
                        }
                        if(!conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", strSanPham, sanPham.layMaGiaBanTheoTenGia(int.Parse(strGiaBan))))
                        {
                            string strSql_GSP = "Insert Gia_SanPham Values('" + strSanPham + "', " + sanPham.layMaGiaBanTheoTenGia(int.Parse(strGiaBan)) + ", '" + DateTime.Now.ToString() + "', NULL)";
                            conn.updateToDatabase(strSql_GSP);
                            MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                        }

                        string strSql = "INSERT LoHang VALUES('" + strMaLo + "', N'" + strTenLo + "', '" + strNgaySanXuat + "', '" + strHanSuDung + "', " + strSoLuong + ", " + strPhieuNhap + ", '" + strSanPham + "', " + sanPham.layMaGiaBanTheoTenGia(int.Parse(strGiaBan)) + ")";
                        conn.updateToDatabase(strSql);
                        MessageBox.Show("Lưu lô hàng thành công!");

                        string strSQLSP = "UPDATE SanPham SET GiaBan=" + strGiaBan + " WHERE MaSP='" + strSanPham + "'";
                        conn.updateToDatabase(strSQLSP);

                        this.Close();
                    }
                    else
                    {
                        //txtGiaBan.Visible = false;
                        //cbbGiaBan.Visible = true;
                        strGiaBan = cbbGiaBan.SelectedValue.ToString().Trim();
                        if (int.Parse(cbbGiaBan.Text.Trim()) <= int.Parse(nhapKho.layGiaNhapTheoChiTietPhieuNhap(strPhieuNhap, strSanPham)))
                        {
                            MessageBox.Show("Giá bán phải lớn hơn Giá nhập!");
                            return;
                        }
                        if (!conn.checkExist("BangGia", "GiaSP", cbbGiaBan.Text.Trim()))
                        {
                            string strSqlBG = "Insert BangGia Values(" + cbbGiaBan.Text.Trim() + ")";
                            conn.updateToDatabase(strSqlBG);
                            MessageBox.Show("Đã thêm thông tin giá bán");
                        }
                        if (!conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", strSanPham, strGiaBan))
                        {
                            string strSql_GSP = "Insert Gia_SanPham Values('" + strSanPham + "', " + strGiaBan + ", '" + DateTime.Now.ToString() + "', NULL)";
                            conn.updateToDatabase(strSql_GSP);
                            MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                        }

                        string strSql = "INSERT LoHang VALUES('" + strMaLo + "', N'" + strTenLo + "', '" + strNgaySanXuat + "', '" + strHanSuDung + "', " + strSoLuong + ", " + strPhieuNhap + ", '" + strSanPham + "', " + strGiaBan + ")";
                        conn.updateToDatabase(strSql);
                        MessageBox.Show("Lưu lô hàng thành công!");

                        string strSqlSp = "UPDATE SanPham SET GiaBan=" + strGiaBan + " WHERE MaSP='" + strSanPham + "'";
                        conn.updateToDatabase(strSqlSp);

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Bạn phải nhập đủ thông tin!");
            }
            catch
            {
                MessageBox.Show("Lưu lô hàng thất bại!");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void frmThemLoHang_Load(object sender, EventArgs e)
        {
            //loadComboBoxPhieuNhap();
            //loadComboBoxSanPham();
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaLo.Clear();
            txtTenLo.Clear();
            txtHanSuDung.Text = DateTime.Now.ToString();
            txtNgaySanXuat.Text = DateTime.Now.ToString();
            txtSoLuong.Clear();
            cbbPhieuNhap.Text = "";
            cbbSanPham.Text = "";
            //loadComboBoxPhieuNhap();
            //loadComboBoxSanPham();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbbGiaBan.DataSource = sanPham.loadGiaBanTheoSanPham(cbbSanPham.Text.Trim());
            //cbbGiaBan.DisplayMember = "GiaSP";
            //cbbGiaBan.ValueMember = "MaGia";
        }

        private void cbbSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void chkGiaBan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiaBan.Checked)
            {
                cbbGiaBan.Visible = false;
                txtGiaBan.Visible = true;
            }
            else
            {
                txtGiaBan.Visible = false;
                cbbGiaBan.Visible = true;
            }
        }
    }
}
