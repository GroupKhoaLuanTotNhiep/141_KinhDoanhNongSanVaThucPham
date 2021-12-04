using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmLuuNoNhaCungCap : Form
    {
        Connection conn = new Connection();
        NhaCungCap ncc = new NhaCungCap();

        public frmLuuNoNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //try
            //{
                //string strCongNo = ncc.layCongNo(UC_NhapKho.maNCC);
                //string strSQLUD1 = "UPDATE NhaCungCap SET CongNo=" + int.Parse(strCongNo) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                //conn.updateToDatabase(strSQLUD1);
                //string strSQLUD2 = "UPDATE NhaCungCap SET CongNo=" + (int.Parse(strCongNo) + int.Parse(UC_NhapKho.tienNo)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                //conn.updateToDatabase(strSQLUD2);
                //int strCongNoMoi = int.Parse(ncc.layCongNo(UC_NhapKho.maNCC));
                ////string strSQLUD3 = "UPDATE NhaCungCap SET CongNo=" + (strCongNoMoi) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                ////conn.updateToDatabase(strSQLUD3);
                //if (txtTienTraThem.Text.Trim() == "0")
                //{
                //    MessageBox.Show("Lưu công nợ thành công!");
                //    this.Close();
                //    string strSQLUDCu = "UPDATE NhaCungCap SET CongNo=" + ((strCongNoMoi) - int.Parse(strCongNo)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                //    conn.updateToDatabase(strSQLUDCu);
                //    string strSQL = "UPDATE NhaCungCap SET CongNo=" + (strCongNoMoi + int.Parse(strCongNo)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                //    conn.updateToDatabase(strSQL);
                //}
                //else
                //{
                //    string strSQLMoi = "UPDATE NhaCungCap SET CongNo=" + (strCongNoMoi - int.Parse(txtTienTraThem.Text.Trim()) - int.Parse(strCongNo)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                //    conn.updateToDatabase(strSQLMoi);
                //    MessageBox.Show("Lưu công nợ thành công!");
                //    this.Close();
                //}
                //MessageBox.Show("Lưu công nợ thành công!");
                //this.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Lưu công nợ thất bại!");
            //}

            //int congNo = int.Parse(UC_NhapKho.layNoCu);
            //int conNo = int.Parse(UC_NhapKho.tienNo);
            //if(txtTienNhapThem.Text == "0")
            //{
            //    string strSQLUD1 = "UPDATE NhaCungCap SET CongNo=" + (congNo + conNo) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
            //    conn.updateToDatabase(strSQLUD1);
            //}
            //else
            //{
            //    string strSQLUD1 = "UPDATE NhaCungCap SET CongNo=" + (congNo + int.Parse(txtTienNhapThem.Text)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
            //    conn.updateToDatabase(strSQLUD1);
            //}

            try
            {
                int congNo = int.Parse(UC_NhapKho.layNoCu);
                string strSQLUD1 = "UPDATE NhaCungCap SET CongNo=" + (congNo - int.Parse(txtTienTraThem.Text)) + " WHERE MaNCC='" + UC_NhapKho.maNCC + "'";
                conn.updateToDatabase(strSQLUD1);
                MessageBox.Show("Lưu công nợ thành công!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lưu công nợ thất bại!");
            }
        }



    }
}
