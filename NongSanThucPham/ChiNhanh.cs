using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBConnect;

namespace NongSanThucPham
{
    public class ChiNhanh
    {
        Connection conn = new Connection();
        SqlDataAdapter da_ChiNhanh;
        DataTable dt_ChiNhanh;
        DataSet ds_ChiNhanh;

        public DataTable loadChiNhanh()
        {
            da_ChiNhanh = new SqlDataAdapter("Select * From ChiNhanh", conn.conn);
            dt_ChiNhanh = new DataTable();
            da_ChiNhanh.Fill(dt_ChiNhanh);
            return dt_ChiNhanh;
        }

        //Lấy tên chi nhánh theo mã chi nhánh
        public string GetTenChiNhanh(string macn)
        {
            string ten = "";
            string strSql = "Select TenChiNhanh From ChiNhanh Where MaChiNhanh='" + macn + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenChiNhanh"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenChiNhanh(string macn)
        {
            return GetTenChiNhanh(macn);
        }
        public DataTable loadDataGV_ChiNhanh()
        {
            da_ChiNhanh = new SqlDataAdapter("Select * From ChiNhanh", conn.conn);
            ds_ChiNhanh = new DataSet();
            da_ChiNhanh.Fill(ds_ChiNhanh, "ChiNhanh");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ChiNhanh.Tables["ChiNhanh"].Columns[0];
            ds_ChiNhanh.Tables["ChiNhanh"].PrimaryKey = key;
            return ds_ChiNhanh.Tables["ChiNhanh"];
        }

        public DataTable searchChiNhanh(string tukhoa)
        {
            da_ChiNhanh = new SqlDataAdapter("Exec SP_SearchChiNhanh N'" + tukhoa + "'", conn.conn);
            ds_ChiNhanh = new DataSet();
            da_ChiNhanh.Fill(ds_ChiNhanh, "ChiNhanh");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ChiNhanh.Tables["ChiNhanh"].Columns[0];
            ds_ChiNhanh.Tables["ChiNhanh"].PrimaryKey = key;
            return ds_ChiNhanh.Tables["ChiNhanh"];
        }
        public bool addchinhanh(string macn, string tencn, string diachi, string dienthoai)
        {
            try
            {
                if (!conn.checkExist("Chinhanh", "machinhanh", macn))
                {
                    string strSQL = "EXEC SP_InsertChiNhanh '" + macn + "',N'" + tencn + "',N'" + diachi + "','" + dienthoai + "'";
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool updateChiNhanh(string macn, string tencn, string diachi, string dienthoai)
        {
            try
            {
                if (conn.checkExist("ChiNhanh", "machinhanh", macn))
                {
                    string strSQL = "EXEC SP_UpdateChiNhanh '" + macn + "',N'" + tencn + "',N'" + diachi + "','" + dienthoai + "'";
                    //string strSQL = "Update ChiNhanh Set TenChiNhanh=N'" + tencn + "', DiaChi=N'" + diachi + "', DienThoai='" + dienthoai + "' Where MaChiNhanh='" + macn + "'";
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool deleteChiNhanh(string macn)
        {
            try
            {
                if (conn.checkExist("ChiNhanh", "machinhanh", macn))
                {
                    string strSQL = "EXEC sp_deleteChiNhanh '" + macn + "'";
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //Lấy phiếu nhập hàng theo chi nhánh
        public DataTable GetPhieuNhap(string macn)
        {
            string lenh = string.Format("Select * From PhieuNhapHang Where MaChiNhanh='" + macn + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layPhieuNhap(string macn)
        {
            return GetPhieuNhap(macn);
        }

        //Lấy phiếu xuất hàng theo chi nhánh
        public DataTable GetPhieuXuat(string macn)
        {
            string lenh = string.Format("Select * From PhieuXuatHang Where MaChiNhanh='" + macn + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layPhieuXuat(string macn)
        {
            return GetPhieuXuat(macn);
        }

        //Lấy phiếu thanh lý theo chi nhánh
        public DataTable GetPhieuThanhLy(string macn)
        {
            string lenh = string.Format("Select * From PhieuThanhLy Where MaChiNhanh='" + macn + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layPhieuThanhLy(string macn)
        {
            return GetPhieuThanhLy(macn);
        }

        //Lấy phiếu giao hàng theo chi nhánh
        public DataTable GetPhieuGiao(string macn)
        {
            string lenh = string.Format("Select * From PhieuGiaoHang Where MaChiNhanh='" + macn + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layPhieuGiao(string macn)
        {
            return GetPhieuGiao(macn);
        }
    }
}
