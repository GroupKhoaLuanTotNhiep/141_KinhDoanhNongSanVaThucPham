using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucDonViTinh : UserControl
    {
        int index = -1;
        Connection conn = new Connection();
        DonViTinh dvt = new DonViTinh();
        public UC_DanhMucDonViTinh()
        {
            InitializeComponent();
        }
        private void load()
        {
            dataGV_DonViTinh.DataSource = dvt.loadDataGV_DVT();
            btnSuaDVT.Enabled = btnXoaDVT.Enabled = false;
        }
        private void dataGV_DonViTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
            txtTenDVT.Text = dataGV_DonViTinh.Rows[index].Cells[1].Value.ToString();
            btnSuaDVT.Enabled = btnXoaDVT.Enabled = true;

        }

        private void UC_DanhMucDonViTinh_Load(object sender, EventArgs e)
        {
            load();
            txtTenDVT.Enabled = false;
        }

        private void btnThemDVT_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDVT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string tenloai = txtTenDVT.Text;
                    if (conn.checkExist("DonViTinh", "TenDVT", tenloai))
                    {
                        MessageBox.Show("Tên đvt " + tenloai + " đã tồn tại");
                        return;
                    }
                    if (dvt.addDVT(tenloai))
                    {
                        MessageBox.Show("Thêm thành công");
                        load();
                        txtTenDVT.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnXoaDVT_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = int.Parse(dataGV_DonViTinh.Rows[index].Cells[0].Value.ToString());
                if (conn.checkExist("SanPham", "MaDVT", ma.ToString()))
                {
                    MessageBox.Show("Mã dvt " + ma + " đang được sử dụng ở bảng sản phẩm");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa đơn vị tính này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                if (dvt.deleteDVT(ma))
                {
                    index = -1;
                    MessageBox.Show("Xóa thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
                
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaDVT_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = int.Parse(dataGV_DonViTinh.Rows[index].Cells[0].Value.ToString());
                string ten = dataGV_DonViTinh.Rows[index].Cells[1].Value.ToString();
                if (conn.checkExist("DonViTinh", "TenDVT", ten))
                {
                    MessageBox.Show("Tên đvt " + ten + " đã tồn tại");
                    return;
                }
                if (dvt.updateDVT(ma,ten))
                {
                    index = -1;
                    MessageBox.Show("Sửa thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }

            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDVT.Enabled = true;
            txtTenDVT.Clear();
            txtTenDVT.Focus();
            load();
        }
    }
}
