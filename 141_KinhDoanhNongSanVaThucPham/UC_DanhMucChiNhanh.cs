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
    public partial class UC_DanhMucChiNhanh : UserControl
    {
        Connection conn = new Connection();
        frmThemChiNhanh frmCN = new frmThemChiNhanh();
        ChiNhanh cn = new ChiNhanh();
        int index = -1;

        public UC_DanhMucChiNhanh()
        {
            InitializeComponent();
        }

        private void btnXemHoatDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (index == -1)
                {
                    MessageBox.Show("Vui lòng chọn một chi nhánh cần xem");
                }
                else
                {
                    string macn = dataGV_ChiNhanh.Rows[index].Cells[0].Value.ToString().Trim();
                    frmHoatDongChiNhanh hdChiNhanh = new frmHoatDongChiNhanh(macn);
                    hdChiNhanh.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh cần xem");
            }
        }

        private void load()
        {
            dataGV_ChiNhanh.DataSource = cn.loadDataGV_ChiNhanh();
            
        }

        private void UC_DanhMucChiNhanh_Load(object sender, EventArgs e)
        {
            load();
            btnSuaChiNhanh.Enabled = btnXoaChiNhanh.Enabled = true;
        }

        private void btnTaoChinhNhanh_Click(object sender, EventArgs e)
        {
            if (frmCN.IsDisposed)
            {
                frmCN = new frmThemChiNhanh();
            }
            frmCN.ShowDialog();
            frmCN.BringToFront();
            frmCN.Activate();
        }

        private void btnXoaChiNhanh_Click(object sender, EventArgs e)
        {
            try
            {
                string macn = dataGV_ChiNhanh.Rows[index].Cells[0].Value.ToString().Trim();
                if (!conn.checkExist("ChiNhanh", "MaChiNhanh", macn))
                {
                    MessageBox.Show("Mã chi nhánh " + macn + " chưa tồn tại");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi nhánh này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                cn.deleteChiNhanh(macn);
                index = -1;
                MessageBox.Show("Xóa thành công");
                load();
            }
            catch
            {
                MessageBox.Show("Xóa thất bại (mã này có thể đang được sử dụng ở bảng khác)");
            }
        }

        private void btnSuaChiNhanh_Click(object sender, EventArgs e)
        {
            try
            {               
                if (index == -1)
                {
                    MessageBox.Show("Vui lòng chọn chi nhánh cần sửa");
                }
                else
                {
                    string macn = dataGV_ChiNhanh.Rows[index].Cells[0].Value.ToString().Trim();
                    string tencn = dataGV_ChiNhanh.Rows[index].Cells[1].Value.ToString().Trim();
                    string diachi = dataGV_ChiNhanh.Rows[index].Cells[2].Value.ToString().Trim();
                    string dienthoai = dataGV_ChiNhanh.Rows[index].Cells[3].Value.ToString().Trim();
                    if (!conn.checkExist("ChiNhanh", "MaChiNhanh", macn))
                    {
                        MessageBox.Show("Mã chi nhánh " + macn + " chưa tồn tại");
                        return;
                    }
                    if (cn.updateChiNhanh(macn, tencn, diachi, dienthoai))
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
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnTKChinhNhanh_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKChiNhanh.Text;
            dataGV_ChiNhanh.DataSource = cn.searchChiNhanh(tukhoa);
        }

        private void dataGV_ChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaChiNhanh.Enabled = btnSuaChiNhanh.Enabled = true;
        }

        
    }
}
