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
    public partial class UC_DanhMucLoaiSanPham : UserControl
    {
        int index = -1;
        Connection conn = new Connection();
        LoaiSP loaisp = new LoaiSP();
        public UC_DanhMucLoaiSanPham()
        {
            InitializeComponent();
        }
        private void load()
        {
            dataGV_LoaiSanPham.DataSource = loaisp.loadDataGV_LoaiSP();
        }
        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenLoai.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string tenloai = txtTenLoai.Text.Trim();
                    if(conn.checkExist("LoaiSanPham", "TenLoaiSP", tenloai))
                    {
                        MessageBox.Show("Tên loại " + tenloai + " đã tồn tại");
                        return;
                    }
                    if (loaisp.addLoaiSP(tenloai))
                    {
                        MessageBox.Show("Thêm thành công");
                        load();
                        txtTenLoai.Clear();
                        txtTenLoai.Focus();
                        txtTenLoai.Enabled = false;
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

        private void UC_DanhMucLoaiSanPham_Load(object sender, EventArgs e)
        {
            load();
            txtTenLoai.Enabled = false;
            btnSuaLoai.Enabled = btnXoaLoai.Enabled = false;
        }

        private void dataGV_LoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
            txtTenLoai.Text = dataGV_LoaiSanPham.Rows[index].Cells[1].Value.ToString();
            btnXoaLoai.Enabled = btnSuaLoai.Enabled = true;
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            try
            {
                int maloai = int.Parse(dataGV_LoaiSanPham.Rows[index].Cells[0].Value.ToString());
                if (conn.checkExist("SanPham", "MaLoaiSP", maloai.ToString()))
                {
                    MessageBox.Show("Mã loại " + maloai + " đang được sử dụng ở bảng sản phẩm");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa loại sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                loaisp.deleteLoaiSP(maloai);
                index = -1;
                MessageBox.Show("Xóa thành công");
                load();
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            try
            {
                int maloai = int.Parse(dataGV_LoaiSanPham.Rows[index].Cells[0].Value.ToString());
                string ten = dataGV_LoaiSanPham.Rows[index].Cells[1].Value.ToString();
                if (conn.checkExist("LoaiSanPham", "TenLoaiSP", ten))
                {
                    MessageBox.Show("Tên loại " + ten + " đã tồn tại");
                    return;
                }
                loaisp.updateLoaiSP(maloai,ten);
                index = -1;
                MessageBox.Show("Sửa thành công");
                load();
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenLoai.Enabled = true;
            txtTenLoai.Clear();
            txtTenLoai.Focus();
            load();
        }
    }
}
