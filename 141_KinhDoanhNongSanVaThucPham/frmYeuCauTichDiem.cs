using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmYeuCauTichDiem : Form
    {
        public static string tongTienNho = "";
        public static int tongTienLon = 0;
        public static int diemCongNho = 0;
        public static int diemCongLon = 0;

        public frmYeuCauTichDiem()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            tongTienNho = txtTongTienHDNho.Text;
            txtTongTienHDNho.Enabled = txtTongTienHDLon.Enabled = txtDiemCong.Enabled = txtDiemCongHD.Enabled = false;
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTongTienHDNho.Enabled = txtTongTienHDLon.Enabled = txtDiemCong.Enabled = txtDiemCongHD.Enabled = true;
        }


    }
}
