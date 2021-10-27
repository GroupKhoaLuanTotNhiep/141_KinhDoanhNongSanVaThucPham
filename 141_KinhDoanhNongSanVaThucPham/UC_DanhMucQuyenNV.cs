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
    public partial class UC_DanhMucQuyenNV : UserControl
    {
        Connection conn = new Connection();
        SqlDataAdapter da_Quyen, da_NhanVien;
        DataSet ds_Quyen;
        DataSet ds;

        public UC_DanhMucQuyenNV()
        {
            InitializeComponent();
            loadDataGV_Quyen();
        }

        void loadDataGV_Quyen()
        {
            da_Quyen = new SqlDataAdapter("Select * From NhomQuyen", conn.conn);
            ds_Quyen = new DataSet();
            da_Quyen.Fill(ds_Quyen, "NhomQuyen");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_Quyen.Tables["NhomQuyen"].Columns[0];
            ds_Quyen.Tables["NhomQuyen"].PrimaryKey = key;
            dataGV_DMQuyen.DataSource = ds_Quyen.Tables["NhomQuyen"];
        }

        void loadDataGV_NhanVien()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, Quyen_NhanVien, NhomQuyen");

            dataGV_DSNhanVien.DataSource = ds.Tables["NhanVien, Quyen_NhanVien, NhomQuyen"];
        }

        public DataTable GetNhanVien(string ma)
        {
            string lenh = string.Format("Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen And NhomQuyen.MaQuyen='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }

        public DataTable layNhanVien(string ma)
        {
            return GetNhanVien(ma);
        }

        private void dataGV_DMQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaQuyen.Text = dataGV_DMQuyen.Rows[index].Cells[0].Value.ToString();
            txtTenQuyen.Text = dataGV_DMQuyen.Rows[index].Cells[1].Value.ToString();
            string a = dataGV_DMQuyen.Rows[index].Cells[0].Value.ToString().Trim();
            dataGV_DSNhanVien.DataSource = layNhanVien(a);
        }
    }
}
