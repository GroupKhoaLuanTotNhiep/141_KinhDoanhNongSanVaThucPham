using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_LichSuGia : UserControl
    {
        Connection cn = new Connection();
        SanPham sp = new SanPham();
        public UC_LichSuGia()
        {
            InitializeComponent();
        }
        void loadComboboxGiaBan()
        {
            cbbSanPhamGia.DataSource = sp.loadMaSP();
            cbbSanPhamGia.DisplayMember = "TenSP";
            cbbSanPhamGia.ValueMember = "MaSP";
        }
        void LSGiaBan()
        {
            DataTable dt = new DataTable();
            dt = sp.loadLichSuGiaBan(cbbSanPhamGia.SelectedValue.ToString());
            dataGV_GiaSanPham.DataSource = dt;
        }
        void loadComboboxGiaVon()
        {
            cbbSanPhamVon.DataSource = sp.loadGiaVon();
            cbbSanPhamVon.DisplayMember = "TenSP";
            cbbSanPhamVon.ValueMember = "MaSP";
        }
        void LSGiaVon()
        {
            DataTable dt = new DataTable();
            dt = sp.loadLichSuGiaVon(cbbSanPhamVon.SelectedValue.ToString());
            dataGV_GiaVon.DataSource = dt;
        }
        void loadComboboxGiamGia()
        {
            cbbSanPhamGiam.DataSource = sp.loadGiamGia();
            cbbSanPhamGiam.DisplayMember = "TenSP";
            cbbSanPhamGiam.ValueMember = "MaSP";
        }
        void LSGiamGia()
        {
            DataTable dt = new DataTable();
            dt = sp.loadLichSuGiamGia(cbbSanPhamGiam.SelectedValue.ToString());
            dataGV_GiamGia.DataSource = dt;
        }

        private void UC_LichSuGia_Load(object sender, EventArgs e)
        {
            loadComboboxGiaBan();
            loadComboboxGiaVon();
            loadComboboxGiamGia();

            LSGiaBan();
            LSGiaVon();
            LSGiamGia();
        }

        private void cbbSanPhamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("LichSuGiaBan", cn.conn);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar, 100));
            adapt.SelectCommand.Parameters["@masp"].Value = cbbSanPhamGia.SelectedValue.ToString();

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            adapt.Dispose();
            dataGV_GiaSanPham.DataSource = dt;
        }

        private void cbbSanPhamVon_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("LichSuGiaNhap", cn.conn);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar, 100));
            adapt.SelectCommand.Parameters["@masp"].Value = cbbSanPhamVon.SelectedValue.ToString();

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            adapt.Dispose();
            dataGV_GiaVon.DataSource = dt;
        }

        private void cbbSanPhamGiam_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("LichSuGiamGia", cn.conn);
            adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapt.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar, 100));
            adapt.SelectCommand.Parameters["@masp"].Value = cbbSanPhamGiam.SelectedValue.ToString();

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            adapt.Dispose();
            dataGV_GiamGia.DataSource = dt;
        }
    }
}
