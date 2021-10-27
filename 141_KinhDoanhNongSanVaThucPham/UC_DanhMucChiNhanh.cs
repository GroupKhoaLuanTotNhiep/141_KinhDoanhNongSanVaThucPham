using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucChiNhanh : UserControl
    {
        public UC_DanhMucChiNhanh()
        {
            InitializeComponent();
        }

        private void btnXemHoatDong_Click(object sender, EventArgs e)
        {
            frmHoatDongChiNhanh hdChiNhanh = new frmHoatDongChiNhanh();
            hdChiNhanh.ShowDialog();
        }
    }
}
