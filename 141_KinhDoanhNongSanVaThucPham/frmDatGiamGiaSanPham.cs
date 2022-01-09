using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmDatGiamGiaSanPham : Form
    {
        Connection conn = new Connection();
        SanPham sp = new SanPham();

        public frmDatGiamGiaSanPham(string masp)
        {
            InitializeComponent();
            txtMaSP.Text = masp;
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            try
            {
                float giamgia = float.Parse(txtPhanTramGiam.Text.Trim());
                float giam = float.Parse(sp.layGiamGia(txtMaSP.Text));
                if (giam != giamgia)
                {
                    if (conn.checkExist("GiamGia_SanPham", "MaSP", txtMaSP.Text))
                    {
                        string sqln = "UPDATE GiamGia_SanPham SET NgayKT ='" + DateTime.Now.ToString() + "' WHERE MaSP='" + txtMaSP.Text + "' AND MaGiam='" + sp.layMaGiamGiaTheoPhanTramGiam(giam) + "'";
                        conn.updateToDatabase(sqln);
                    }
                    if (conn.checkExistTwoKey("GiamGia_SanPham", "MaSP", "MaGiam", txtMaSP.Text, sp.layMaGiamGiaTheoPhanTramGiam(giamgia)))
                    {
                        string sqlnkt = "UPDATE GiamGia_SanPham SET NgayKT = NULL WHERE MaSP='" + txtMaSP.Text + "' AND MaGiam='" + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + "'";
                        conn.updateToDatabase(sqlnkt);
                    }
                    string sql = "UPDATE SanPham SET GiamGia=" + giamgia + " WHERE MaSP='" + txtMaSP.Text + "'";
                    conn.updateToDatabase(sql);
                    MessageBox.Show("Thêm giảm giá thành công!");
                }

                if (!conn.checkExist("GiamGia", "PhanTramGiam", giamgia.ToString()))
                {
                    string strSqlGG = "Insert GiamGia Values(" + giamgia + ")";
                    conn.updateToDatabase(strSqlGG);
                    MessageBox.Show("Đã thêm thông tin giảm giá");
                    string strSqlGGSP = "Insert GiamGia_SanPham Values('" + txtMaSP.Text + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia).ToString() + ", '" + DateTime.Now.ToString() + "', NULL )";
                    conn.updateToDatabase(strSqlGGSP);
                    MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại phần trăm giảm này trong bảng giảm giá");
                }
                if (!conn.checkExistTwoKey("GiamGia_SanPham", "MaSP", "MaGiam", txtMaSP.Text, sp.layMaGiamGiaTheoPhanTramGiam(giamgia)))
                {
                    string strSqlGG_SP = "Insert GiamGia_SanPham Values('" + txtMaSP.Text + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + ", '" + DateTime.Now.ToString() + "', NULL)";
                    conn.updateToDatabase(strSqlGG_SP);
                    MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                }

                this.Close();
            }
            catch
            {
                MessageBox.Show("Thêm giảm giá thất bại!");
            }
        }

        private void txtPhanTramGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
