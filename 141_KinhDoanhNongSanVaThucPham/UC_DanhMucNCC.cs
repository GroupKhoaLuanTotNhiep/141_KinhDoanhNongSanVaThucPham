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
    public partial class UC_DanhMucNCC : UserControl
    {
        frmThemNCC frmNCC = new frmThemNCC();
        NhaCungCap ncc = new NhaCungCap();
        int index;
        public UC_DanhMucNCC()
        {
            InitializeComponent();

        }
        private void btnTaoNCC_Click(object sender, EventArgs e)
        {
            if (frmNCC.IsDisposed)
            {
                frmNCC = new frmThemNCC();
            }
            frmNCC.Show();
            frmNCC.BringToFront();
            frmNCC.Activate();

        }
        private void load_dtgv()
        {
            dataGV_NhaCungCap.DataSource = ncc.loadDataGV_NhaCungCap();
        }
        private void UC_DanhMucNCC_Load(object sender, EventArgs e)
        {
            load_dtgv();
            btnSuaNCC.Enabled = btnXoaNCC.Enabled = false;
        }
        private void dataGV_NhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaNCC.Enabled = btnSuaNCC.Enabled = true;

        }
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            string mancc = dataGV_NhaCungCap.Rows[index].Cells[0].Value.ToString();
            try
            {
                if (string.IsNullOrEmpty(mancc))
                {
                    MessageBox.Show("Xóa thất bại");
                }
                else
                {
                    ncc.deleteNCC(mancc);
                    mancc = "";
                    MessageBox.Show("Xóa thành công");
                    load_dtgv();
                }

            }
            catch { 
                
            }
           
        }
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = dataGV_NhaCungCap.Rows[index].Cells[0].Value.ToString();
                string tenncc = dataGV_NhaCungCap.Rows[index].Cells[1].Value.ToString();
                string diachi = dataGV_NhaCungCap.Rows[index].Cells[2].Value.ToString();
                string dienthoai = dataGV_NhaCungCap.Rows[index].Cells[3].Value.ToString();
                string email = dataGV_NhaCungCap.Rows[index].Cells[4].Value.ToString();
                int congno = int.Parse(dataGV_NhaCungCap.Rows[index].Cells[5].Value.ToString());
                string stk = dataGV_NhaCungCap.Rows[index].Cells[6].Value.ToString();

                if (string.IsNullOrEmpty(mancc))
                {
                    MessageBox.Show("Sửa thất bại");
                }
                else
                {
                    if (ncc.updateNCC(mancc, tenncc, diachi, dienthoai, email, congno, stk))
                    {
                        mancc = "";
                        MessageBox.Show("Sửa thành công");
                        load_dtgv();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch { }
        }

        private void btnTKNCC_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKNCC.Text;
            dataGV_NhaCungCap.DataSource = ncc.searchNCC(tukhoa);
        }
    }
}
