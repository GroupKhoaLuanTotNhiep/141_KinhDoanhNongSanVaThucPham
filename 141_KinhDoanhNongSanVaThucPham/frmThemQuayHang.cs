using NongSanThucPham;
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

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmThemQuayHang : Form
    {
        Connection conn = new Connection();
        QuayHang qh = new QuayHang();
        public frmThemQuayHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaQuay.Text = txtTenQuay.Text = "";
            txtMaQuay.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtMaQuay.Text) || string.IsNullOrEmpty(txtTenQuay.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string maquay = txtMaQuay.Text;
                    string tenquay = txtTenQuay.Text;

                    if(conn.checkExist("QuayHang", "MaQuay", maquay))
                    {
                        MessageBox.Show("Mã quầy này đã tồn tại");
                        return;
                    }
                    if(conn.checkExist("QuayHang", "TenQuay", tenquay))
                    {
                        MessageBox.Show("Tên quầy này đã tồn tại");
                        return;
                    }
                    if (qh.addQuayHang(maquay, tenquay))
                    {
                        MessageBox.Show("Thêm thành công");
                        btnThemMoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch { }
        }
    }
}
