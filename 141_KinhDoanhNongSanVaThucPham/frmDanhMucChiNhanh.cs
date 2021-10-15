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
    public partial class frmDanhMucChiNhanh : Form
    {
        public frmDanhMucChiNhanh()
        {
            InitializeComponent();
        }

        private void btnXemHoatDong_Click(object sender, EventArgs e)
        {
            frmHoatDongChiNhanh hdcn = new frmHoatDongChiNhanh();
            hdcn.ShowDialog();
        }
    }
}
