using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmThemChiNhanh : Form
    {
        Connection conn = new Connection();
        ChiNhanh cn = new ChiNhanh();

        public frmThemChiNhanh()
        {
            InitializeComponent();
        }

        private void btnLuuChiNhanh_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtmachinhanh.Text) || string.IsNullOrEmpty(txtTenChiNhanh.Text) || string.IsNullOrEmpty(txtDienThoai.Text)|| string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    string ma = txtmachinhanh.Text.Trim();
                    string ten= txtTenChiNhanh.Text.Trim();
                    string diachi = txtDiaChi.Text.Trim();
                    string dienthoai = txtDienThoai.Text.Trim();

                    if(conn.checkExist("ChiNhanh", "MaChiNhanh", ma))
                    {
                        MessageBox.Show("Mã chi nhánh " + ma + " đã tồn tại");
                        return;
                    }
                    if (conn.checkExist("ChiNhanh", "TenChiNhanh", ten))
                    {
                        MessageBox.Show("Tên chi nhánh không được trùng");
                        return;
                    }
                    if (conn.checkExist("ChiNhanh", "DienThoai", dienthoai))
                    {
                        MessageBox.Show("Điện thoại của các chi nhánh không được trùng");
                        return;
                    }
                    if (cn.addchinhanh(ma, ten,diachi,dienthoai))
                    {
                        MessageBox.Show("Thêm thành công");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load()
        {
            txtDiaChi.Text = txtDienThoai.Text = txtmachinhanh.Text = txtTenChiNhanh.Text = "";
            txtDiaChi.Enabled = txtDienThoai.Enabled = txtmachinhanh.Enabled = txtTenChiNhanh.Enabled = btnLuuChiNhanh.Enabled= false;
        }
        private void frmThemChiNhanh_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDienThoai.Text = txtmachinhanh.Text = txtTenChiNhanh.Text = "";
            txtDiaChi.Enabled = txtDienThoai.Enabled = txtmachinhanh.Enabled = txtTenChiNhanh.Enabled =  btnLuuChiNhanh.Enabled= true;
            txtmachinhanh.Focus();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
