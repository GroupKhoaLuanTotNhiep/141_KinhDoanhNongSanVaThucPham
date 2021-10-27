using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucChucVu : UserControl
    {
        Connection conn = new Connection();
        SqlDataAdapter da_ChucVu, da_NhanVien;
        DataSet ds_ChucVu, ds_NhanVien;
        //DataTable dt_ChucVu;
        //DataView dtv_ChucVu;

        public UC_DanhMucChucVu()
        {
            InitializeComponent();
            loadDataGV_ChucVu();
        }

        void loadDataGV_ChucVu()
        {
            da_ChucVu = new SqlDataAdapter("Select * From ChucVu", conn.conn);
            ds_ChucVu = new DataSet();
            da_ChucVu.Fill(ds_ChucVu, "ChucVu");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ChucVu.Tables["ChucVu"].Columns[0];
            ds_ChucVu.Tables["ChucVu"].PrimaryKey = key;
            dataGV_DMChucVu.DataSource = ds_ChucVu.Tables["ChucVu"];
        }

        void loadDataGV_NhanVien()
        {
            da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            dataGV_DSNhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
        }

        public DataTable GetNhanVien(string ma)
        {
            string lenh = string.Format("Select * From NhanVien Where MaChucVu ='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }

        public DataTable layNhanVien(string ma)
        {
            return GetNhanVien(ma);
        }

        private void dataGV_DMChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaCV.Text = dataGV_DMChucVu.Rows[index].Cells[0].Value.ToString();
            txtTenCV.Text = dataGV_DMChucVu.Rows[index].Cells[1].Value.ToString();
            txtHeSoLuong.Text = dataGV_DMChucVu.Rows[index].Cells[2].Value.ToString();
            txtLuongCB.Text = dataGV_DMChucVu.Rows[index].Cells[3].Value.ToString();
            string a = dataGV_DMChucVu.Rows[index].Cells[0].Value.ToString().Trim();
            dataGV_DSNhanVien.DataSource = layNhanVien(a);
        }


    }
}
