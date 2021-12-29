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
    public partial class frmYeuCauTichDiem : Form
    {
        Connection conn = new Connection();
        KhuyenMai khuyenMai = new KhuyenMai();
        //public static string tongTienNho = "";
        //public static int tongTienLon = 0;
        //public static int diemCongNho = 0;
        //public static int diemCongLon = 0;

        public frmYeuCauTichDiem()
        {
            InitializeComponent();
        }

        void loadDataGV_YeuCauTichDiem()
        {
            dataGV_TichDiem.DataSource = khuyenMai.loadDataGV_YCTichDiem();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //tongTienNho = txtTongTienHDNho.Text;
            //txtTongTienHDNho.Enabled = txtTongTienHDLon.Enabled = txtDiemCong.Enabled = txtDiemCongHD.Enabled = false;
            //this.Close();
            try
            {
                if(txtTongTienHDNho.Text == string.Empty || txtDiemCong.Text == string.Empty || txtTongTienHDLon.Text == string.Empty || txtDiemCongHD.Text == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập đủ thông tin!");
                    return;
                }
                int hoaDonNho = int.Parse(txtTongTienHDNho.Text);
                int tichDiemNho = int.Parse(txtDiemCong.Text);
                int hoaDonLon = int.Parse(txtTongTienHDLon.Text);
                int tichDiemLon = int.Parse(txtDiemCongHD.Text);
                string strSQL = "INSERT YeuCauTichDiem VALUES('" + DateTime.Now.ToString() + "', " + hoaDonNho + ", " + tichDiemNho + ", " + hoaDonLon + ", " + tichDiemLon + ")";
                conn.updateToDatabase(strSQL);
                loadDataGV_YeuCauTichDiem();
                MessageBox.Show("Lưu thông tin thành công!");
            }
            catch
            {
                MessageBox.Show("Lưu thông tin thất bại!");
            }
        }

        private void frmYeuCauTichDiem_Load(object sender, EventArgs e)
        {
            loadDataGV_YeuCauTichDiem();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGV_TichDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtTongTienHDNho.Text = dataGV_TichDiem.Rows[index].Cells[2].Value.ToString();
            txtDiemCong.Text = dataGV_TichDiem.Rows[index].Cells[3].Value.ToString();
            txtTongTienHDLon.Text = dataGV_TichDiem.CurrentRow.Cells[4].Value.ToString();
            txtDiemCongHD.Text = dataGV_TichDiem.Rows[index].Cells[5].Value.ToString();
        }


    }
}
