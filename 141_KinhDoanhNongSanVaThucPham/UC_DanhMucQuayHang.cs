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
    public partial class UC_DanhMucQuayHang : UserControl
    {
        Connection conn = new Connection();
        QuayHang qh = new QuayHang();
        frmThemQuayHang frmQH = new frmThemQuayHang();
        int index = -1;
        public UC_DanhMucQuayHang()
        {
            InitializeComponent();
        }
        private void load()
        {
            dataGV_QuayHang.DataSource = qh.loadDataGV_QuayHang();
            btnSuaQuay.Enabled = btnXoaQuay.Enabled = false;
        }
        private void dataGV_QuayHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaQuay.Enabled = btnSuaQuay.Enabled = true;
        }

        private void btnTKQuay_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKQuay.Text;
            dataGV_QuayHang.DataSource = qh.searchQuayHang(tukhoa);
        }

        private void btnTaoQuay_Click(object sender, EventArgs e)
        {
            if (frmQH.IsDisposed)
            {
                frmQH = new frmThemQuayHang();
            }
            frmQH.Show();
            frmQH.BringToFront();
            frmQH.Activate();
        }

        private void btnXoaQuay_Click(object sender, EventArgs e)
        {
            try
            {
                string maquay = dataGV_QuayHang.Rows[index].Cells[0].Value.ToString();

                if(!conn.checkExist("QuayHang", "MaQuay", maquay))
                {
                    MessageBox.Show("Mã quầy " + maquay + " này chưa tồn tại");
                    return;
                }
                if(conn.checkExist("PhieuXuatHang", "MaQuay", maquay))
                {
                    MessageBox.Show("Mã quầy này đang được sử dụng ở phiếu xuất hàng");
                    return;
                }
                if (conn.checkExist("SanPham", "MaQuay", maquay))
                {
                    MessageBox.Show("Mã quầy này đang được sử dụng ở bảng sản phẩm");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa quầy hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                qh.deleteQuayHang(maquay);
                index = -1;
                MessageBox.Show("Xóa thành công");
                load();

            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaQuay_Click(object sender, EventArgs e)
        {
            try
            {

                string maquay = dataGV_QuayHang.Rows[index].Cells[0].Value.ToString();
                string tenquay = dataGV_QuayHang.Rows[index].Cells[1].Value.ToString();
                if (!conn.checkExist("QuayHang", "MaQuay", maquay))
                {
                    MessageBox.Show("Mã quầy " + maquay + " này chưa tồn tại");
                    return;
                }
                if (qh.updateQuayHang(maquay, tenquay))
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

        private void UC_DanhMucQuayHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load();
            txtTKQuay.Clear();
        }
    }
}
