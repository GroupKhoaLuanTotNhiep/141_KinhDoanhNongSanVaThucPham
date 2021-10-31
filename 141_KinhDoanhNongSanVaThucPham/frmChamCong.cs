using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmChamCong : Form
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();

        public frmChamCong()
        {
            InitializeComponent();
            createTable_ChamCong();
            loadComboBoxTinhTrang();
        }

        void createTable_ChamCong()
        {
            dataGV_ChamCong.DataSource = nhanVien.loadBangChamCong();
        }

        void loadComboBoxTinhTrang()
        {
            string[] tinhTrang = { "Đi làm", "Không đi làm" };
            foreach (string s in tinhTrang)
                cbbTinhTrang.Items.Add(s);
            cbbTinhTrang.SelectedIndex = 0;
        }

    }
}
