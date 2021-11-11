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

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucKhachHang : UserControl
    {
        KhachHang kh = new KhachHang();
        frmThemKhachHang frmNCC = new frmThemKhachHang();
        public UC_DanhMucKhachHang()
        {
            InitializeComponent();
        }

        private void btnTaoKhachHang_Click(object sender, EventArgs e)
        {
            if (frmNCC.IsDisposed)
            {
                frmNCC = new frmThemKhachHang();
            }
            frmNCC.Show();
            frmNCC.BringToFront();
            frmNCC.Activate();
        }

        private void UC_DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = kh.loadDataGV_KhachHang();
            }
            catch { }
            
        }
    }
}
