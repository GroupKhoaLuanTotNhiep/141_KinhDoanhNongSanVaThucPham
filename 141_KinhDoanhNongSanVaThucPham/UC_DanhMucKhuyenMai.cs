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
    public partial class UC_DanhMucKhuyenMai : UserControl
    {
        Connection conn = new Connection();
        KhuyenMai km = new KhuyenMai();

        public UC_DanhMucKhuyenMai()
        {
            InitializeComponent();
        }

        private void load()
        {
            dataGV_DMKhuyenMai.DataSource = km.loadDataGV_KM();           
        }

        private void UC_DanhMucKhuyenMai_Load(object sender, EventArgs e)
        {
            load();
            btnSuaKM.Enabled = btnXoaKM.Enabled = btnTaoKM.Enabled = false;
            txtMaKM.Enabled = false;
        }

        private void dataGV_DMKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int index = e.RowIndex;
                txtMaKM.Text = dataGV_DMKhuyenMai.Rows[index].Cells[0].Value.ToString();
                txtTenKM.Text = dataGV_DMKhuyenMai.Rows[index].Cells[1].Value.ToString();
                txtGiaTriKM.Text = dataGV_DMKhuyenMai.Rows[index].Cells[2].Value.ToString();
                txtNoiDungKM.Text = dataGV_DMKhuyenMai.Rows[index].Cells[3].Value.ToString();
                txtTichLuy.Text = dataGV_DMKhuyenMai.Rows[index].Cells[4].Value.ToString();
                btnSuaKM.Enabled = btnXoaKM.Enabled = true;          
            }               
        }

        private void btnTaoKM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKM.Text) || string.IsNullOrEmpty(txtTenKM.Text) || string.IsNullOrEmpty(txtGiaTriKM.Text) || string.IsNullOrEmpty(txtNoiDungKM.Text) || string.IsNullOrEmpty(txtTichLuy.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string makm = txtMaKM.Text;
                    string tenkm = txtTenKM.Text;
                    float giatri = float.Parse(txtGiaTriKM.Text);
                    string noidung = txtNoiDungKM.Text;
                    int tichluy = int.Parse(txtTichLuy.Text);

                    if (conn.checkExist("KhuyenMai", "MaKM", makm))
                    {
                        MessageBox.Show("Mã khuyến mãi " + makm + " đã tồn tại");
                        return;
                    }
                    if (conn.checkExist("KhuyenMai", "TenKM", tenkm))
                    {
                        MessageBox.Show("Tên khuyến mãi " + tenkm + " đã tồn tại");
                        return;
                    }
                    if (km.addKM(makm, tenkm,giatri,noidung, tichluy))
                    {
                        MessageBox.Show("Thêm thành công");
                        load();
                        txtGiaTriKM.Text = txtMaKM.Text = txtNoiDungKM.Text = txtTenKM.Text = txtTichLuy.Text = "";
                        txtMaKM.Focus();                    
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

        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKM.Text) || string.IsNullOrEmpty(txtTenKM.Text) || string.IsNullOrEmpty(txtGiaTriKM.Text) || string.IsNullOrEmpty(txtNoiDungKM.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string makm = txtMaKM.Text;
                    string tenkm = txtTenKM.Text;
                    float giatri = float.Parse(txtGiaTriKM.Text);
                    string noidung = txtNoiDungKM.Text;
                    int tichluy = int.Parse(txtTichLuy.Text);

                    if (!conn.checkExist("KhuyenMai", "MaKM", makm))
                    {
                        MessageBox.Show("Mã khuyến mãi " + makm + " chưa tồn tại");
                        return;
                    }
                    //if (conn.checkExist("KhuyenMai", "TenKM", tenkm))
                    //{
                    //    MessageBox.Show("Tên khuyến mãi " + tenkm + " đã tồn tại");
                    //    return;
                    //}
                    if (km.updateKM(makm, tenkm, giatri, noidung, tichluy))
                    {
                        MessageBox.Show("Sửa thành công");
                        load();
                        txtGiaTriKM.Text = txtMaKM.Text = txtNoiDungKM.Text = txtTenKM.Text = txtTichLuy.Text = "";
                        txtMaKM.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKM.Text) )
                {
                    MessageBox.Show("Vui lòng thông tin mã khuyến mãi");
                    return;
                }
                else
                {
                    string makm = txtMaKM.Text;
                    string tenkm = txtTenKM.Text;
                    float giatri = float.Parse(txtGiaTriKM.Text);
                    string noidung = txtNoiDungKM.Text;

                    if (!conn.checkExist("KhuyenMai", "MaKM", makm))
                    {
                        MessageBox.Show("Mã khuyến mãi " + makm + " chưa tồn tại");
                        return;
                    }
                    if(conn.checkExist("HoaDon", "MaKM", makm))
                    {
                        MessageBox.Show("Mã khuyến mãi này đang được sử dụng ở hóa đơn");
                        return;
                    }
                    if (conn.checkExist("PhieuGiaoHang", "MaKM", makm))
                    {
                        MessageBox.Show("Mã khuyến mãi này đang được sử dụng ở phiếu giao hàng");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thật sự muốn xóa khuyến mãi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    if (km.deleteKM(makm))
                    {
                        MessageBox.Show("Xóa thành công");
                        load();
                        txtGiaTriKM.Text = txtMaKM.Text = txtNoiDungKM.Text = txtTenKM.Text = "";
                        txtMaKM.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            catch {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKM.Clear();
            txtTenKM.Clear();
            txtGiaTriKM.Clear();
            txtNoiDungKM.Clear();
            txtTichLuy.Clear();
            btnTaoKM.Enabled = txtMaKM.Enabled = true;
        }

        private void txtGiaTriKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
        
        private void txtTichLuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnYeuCau_Click(object sender, EventArgs e)
        {
            frmYeuCauTichDiem yeuCau = new frmYeuCauTichDiem();
            yeuCau.ShowDialog();
        }
    }
}
