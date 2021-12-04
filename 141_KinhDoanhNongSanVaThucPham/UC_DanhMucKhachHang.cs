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
    public partial class UC_DanhMucKhachHang : UserControl
    {
        Connection conn = new Connection();
        KhachHang kh = new KhachHang();
        frmThemKhachHang frmKH = new frmThemKhachHang();
        int index = -1;

        public UC_DanhMucKhachHang()
        {
            InitializeComponent();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKKhach.Text;
            dataGV_KhachHang.DataSource = kh.searchKhachHang(tukhoa);
        }

        private void loadDTGV()
        {
            dataGV_KhachHang.DataSource = kh.loadDataGV_KhachHang();
        }

        private void btnTaoKhachHang_Click(object sender, EventArgs e)
        {
            if (frmKH.IsDisposed)
            {
                frmKH = new frmThemKhachHang();
            }
            frmKH.Show();
            frmKH.BringToFront();
            frmKH.Activate();
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = int.Parse(dataGV_KhachHang.Rows[index].Cells[0].Value.ToString());

                if(!conn.checkExist("KhachHang", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng " + makh + " chưa tồn tại");
                    return;
                }
                if(conn.checkExist("HoaDon", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng này đang được sử dụng trong bảng hóa đơn");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                kh.deleteKH(makh);
                index = -1;
                MessageBox.Show("Xóa thành công");
                UC_DanhMucKhachHang_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = int.Parse(dataGV_KhachHang.Rows[index].Cells[0].Value.ToString());
                string tenkh = dataGV_KhachHang.Rows[index].Cells[1].Value.ToString();
                string diachi = dataGV_KhachHang.Rows[index].Cells[2].Value.ToString();
                string dienthoai = dataGV_KhachHang.Rows[index].Cells[3].Value.ToString();
                string email = dataGV_KhachHang.Rows[index].Cells[4].Value.ToString();
                int tichdiem = int.Parse(dataGV_KhachHang.Rows[index].Cells[5].Value.ToString());
                int congno = int.Parse(dataGV_KhachHang.Rows[index].Cells[6].Value.ToString());
                if (!conn.checkExist("KhachHang", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng " + makh + " chưa tồn tại");
                    return;
                }
                if (!conn.isEmail(email))
                {
                    MessageBox.Show("Email " + email + " không hợp lệ");
                    return;
                }
                //if (conn.checkExist("KhachHang", "Email", email))
                //{
                //    MessageBox.Show("Email này đã tồn tại");
                //    return;
                //}
                //if (conn.checkExist("KhachHang", "DienThoai", dienthoai))
                //{
                //    MessageBox.Show("Điện thoại này đã tồn tại");
                //    return;
                //}
                if (kh.updateKH(makh, tenkh, diachi, dienthoai, email, congno, tichdiem))
                {
                    index = -1;
                    MessageBox.Show("Sửa thành công");
                    UC_DanhMucKhachHang_Load(sender, e);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaKhachHang.Enabled = btnSuaKhachHang.Enabled = true;
        }

        private void UC_DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            loadDTGV();
            btnSuaKhachHang.Enabled = btnXoaKhachHang.Enabled = false;
        }
    }
}
