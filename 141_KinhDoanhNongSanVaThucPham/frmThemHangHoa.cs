using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmThemHangHoa : Form
    {
        Connection conn = new Connection();
        SanPham sp = new SanPham();
        LoaiSP loaisp = new LoaiSP();
        DonViTinh dvt = new DonViTinh();
        QuayHang qh = new QuayHang();
        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
        public frmThemHangHoa()
        {
            InitializeComponent();
        }
        void load()
        {
            cbbLoaiSanPham.DataSource = loaisp.loadDataGV_LoaiSP();
            cbbLoaiSanPham.DisplayMember = "tenloaisp";
            cbbLoaiSanPham.ValueMember = "maloaisp";

            cbbDonViTinh.DataSource = dvt.loadDataGV_DVT();
            cbbDonViTinh.DisplayMember = "tendvt";
            cbbDonViTinh.ValueMember = "madvt";

            cbbQuayHang.DataSource = qh.loadDataGV_QuayHang();
            cbbQuayHang.DisplayMember = "tenquay";
            cbbQuayHang.ValueMember = "maquay";
        }
        void txtload()
        {
            txtGiaBan.Text = txtGiamGia.Text = txtGiaVon.Text = txtHinhAnh.Text = txtMaSP.Text = txtMota.Text = txtSoLuongSP.Text = txtTenHang.Text = txtXuatXu.Text = "";

        }
        private void frmThemHangHoa_Load(object sender, EventArgs e)
        {
            load();
            txtload();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            try 
            {
                if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenHang.Text) || string.IsNullOrEmpty(txtGiaVon.Text) || string.IsNullOrEmpty(txtGiaBan.Text) || string.IsNullOrEmpty(txtGiamGia.Text) || string.IsNullOrEmpty(txtSoLuongSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin yêu cầu");
                    return;
                }
                else
                {
                    string masp = txtMaSP.Text;
                    string tensp = txtTenHang.Text;
                    string hinhanh = txtHinhAnh.Text;
                    int giavon = int.Parse(txtGiaVon.Text);
                    int giaban = int.Parse(txtGiaBan.Text);
                    float giamgia = float.Parse(txtGiamGia.Text);
                    float soluong = float.Parse(txtSoLuongSP.Text);
                    string xuatxu = txtXuatXu.Text;
                    string mota = txtMota.Text;
                    int maloaisp = int.Parse(cbbLoaiSanPham.SelectedValue.ToString());
                    int madvt = int.Parse(cbbDonViTinh.SelectedValue.ToString());
                    string maquay = cbbQuayHang.SelectedValue.ToString();

                    if(conn.checkExist("SanPham", "MaSP", masp))
                    {
                        MessageBox.Show("Mã sản phẩm " + masp + " đã tồn tại");
                        return;
                    }
                    if(giaban <= giavon)
                    {
                        MessageBox.Show("Giá bán phải lớn hơn giá vốn!");
                        return;
                    }
                    if (sp.addSP(masp, tensp, hinhanh, giavon, giaban, giamgia, soluong, xuatxu, mota, maloaisp, madvt, maquay))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                        //Thêm thông tin bảng Bảng giá và Giá sản phẩm
                        if (!conn.checkExist("BangGia", "GiaSP", giaban.ToString()))
                        {
                            string strSqlBG = "Insert BangGia Values(" + giaban + ")";
                            conn.updateToDatabase(strSqlBG);
                            MessageBox.Show("Đã thêm thông tin giá bán");
                            string strSqlGSP = "Insert Gia_SanPham Values('" + masp + "', " + sp.layMaGiaBanTheoTenGia(giaban) + ", '" + DateTime.Now.ToString() + "', NULL)";
                            conn.updateToDatabase(strSqlGSP);
                            MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                        }
                        else
                        {
                            if (!conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", masp, sp.layMaGiaBanTheoTenGia(giaban)))
                            {
                                string strSql_GSP = "Insert Gia_SanPham Values('" + masp + "', " + sp.layMaGiaBanTheoTenGia(giaban) + ", '" + DateTime.Now.ToString() + "', NULL)";
                                conn.updateToDatabase(strSql_GSP);
                                MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                            }
                        }
                        //Thêm thông tin bảng Giảm giá và Giảm giá sản phẩm
                        if (!conn.checkExist("GiamGia", "PhanTramGiam", giamgia.ToString()))
                        {
                            string strSqlGG = "Insert GiamGia Values(" + giamgia + ")";
                            conn.updateToDatabase(strSqlGG);
                            MessageBox.Show("Đã thêm thông tin giảm giá");
                            string strSqlGGSP = "Insert GiamGia_SanPham Values('" + masp + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + ", '" + DateTime.Now.ToString() + "', NULL)";
                            conn.updateToDatabase(strSqlGGSP);
                            MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                        }
                        else
                        {
                            if (!conn.checkExistTwoKey("GiamGia_SanPham", "MaSP", "MaGiam", masp, sp.layMaGiamGiaTheoPhanTramGiam(giamgia)))
                            {
                                string strSqlGG_SP = "Insert GiamGia_SanPham Values('" + masp + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + ", '" + DateTime.Now.ToString() + "', NULL)";
                                conn.updateToDatabase(strSqlGG_SP);
                                MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                            }
                        }

                        txtload();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenHang.Clear();
            txtHinhAnh.Clear();
            txtGiaVon.Clear();
            txtGiamGia.Clear();
            txtGiaBan.Clear();
            txtSoLuongSP.Clear();
            txtXuatXu.Clear();
            cbbDonViTinh.SelectedIndex = 0;
            cbbLoaiSanPham.SelectedIndex = 0;
            cbbQuayHang.SelectedIndex = 0;
        }

        private void txtGiaVon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnUploadHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\";
            open.Filter = "Image File (*.jpg)|*.jpg|All File (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = System.IO.Path.GetFileName(open.FileName);
                string luu = paths + "\\image\\" + name;
                try
                {
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    System.IO.File.Copy(open.FileName, luu);
                    MessageBox.Show("Upload file ảnh thành công", "Thông báo");
                    txtHinhAnh.Text = name;
                    fs.Close();
                }
                catch
                {
                    MessageBox.Show("Hình ảnh đã tồn tại hoặc trùng tên, vui lòng kiểm tra lại");
                }
            }
        }
    }
}
