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
    public partial class UC_DanhMucHT_ThanhToan : UserControl
    {
        Connection conn = new Connection();
        HinhThucThanhToan httt = new HinhThucThanhToan();
        int index = -1;
        public UC_DanhMucHT_ThanhToan()
        {
            InitializeComponent();
        }

        private void dataGV_HTThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
            txtTenHinhThuc.Text = dataGV_HTThanhToan.Rows[index].Cells[1].Value.ToString();
            btnXoaHinhThuc.Enabled = btnSuaHinhThuc.Enabled = true;
        }
        private void load()
        {
            dataGV_HTThanhToan.DataSource = httt.loadDataGV_HTTT();
            
        }
        private void UC_DanhMucHT_ThanhToan_Load(object sender, EventArgs e)
        {
            load();
            btnSuaHinhThuc.Enabled = btnXoaHinhThuc.Enabled = false;
            txtTenHinhThuc.Enabled = false;
        }

        private void btnThemHinhThuc_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenHinhThuc.Text.Trim();
                if (conn.checkExist("HT_ThanhToan", "TenHT", ten))
                {
                    MessageBox.Show("Tên hình thức thanh toán " + ten + " đã tồn tại");
                    return;
                }
                if (httt.addHTTT(ten))
                {
                    MessageBox.Show("Thêm thành công");
                    load();
                    txtTenHinhThuc.Clear();
                    txtTenHinhThuc.Focus();
                    txtTenHinhThuc.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
                
            }
            catch {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnXoaHinhThuc_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = dataGV_HTThanhToan.Rows[index].Cells[0].Value.ToString();

                if(!conn.checkExist("HT_ThanhToan", "MaHT", ma))
                {
                    MessageBox.Show("Mã hình thức thanh toán " + ma + " chưa tồn tại");
                    return;
                }
                if (conn.checkExist("HoaDon", "MaTH", ma))
                {
                    MessageBox.Show("Hình thức thanh toán này đang được sử dụng ở bảng hóa đơn");
                    return;
                }
                if (conn.checkExist("PhieuNhapHang", "MaHT", ma))
                {
                    MessageBox.Show("Hình thức thanh toán này đang được sử dụng ở bảng phiếu nhập hàng");
                    return;
                }
                if(ma == "1" || ma == "2" || ma == "3")
                {
                    MessageBox.Show("Mã " + ma + " này đã mặt định nên không thể xóa");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa hình thức thanh toán này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                if (httt.deleteHTTT(ma))
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

        private void btnSuaHinhThuc_Click(object sender, EventArgs e)
        {
            try
            {

                int ma = int.Parse(dataGV_HTThanhToan.Rows[index].Cells[0].Value.ToString());
                string ten = dataGV_HTThanhToan.Rows[index].Cells[1].Value.ToString();
                if (!conn.checkExist("HT_ThanhToan", "MaHT", ma.ToString()))
                {
                    MessageBox.Show("Mã hình thức thanh toán " + ma + " chưa tồn tại");
                    return;
                }
                httt.updateHTTT(ma, ten);
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
            txtTenHinhThuc.Enabled = true;
            txtTenHinhThuc.Clear();
            txtTenHinhThuc.Focus();
            load();
        }
    }
}
