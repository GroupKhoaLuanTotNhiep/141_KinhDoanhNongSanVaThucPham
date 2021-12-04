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
    public class NhaCungCap
    {
        Connection conn = new Connection();
        SqlDataAdapter da_NhaCungCap;
        DataTable dt_NhaCungCap;
        DataSet ds_NhaCungCap;

        public DataTable loadDataGV_NhaCungCap()
        {
            da_NhaCungCap = new SqlDataAdapter("Select * From NhaCungCap", conn.conn);
            ds_NhaCungCap = new DataSet();
            da_NhaCungCap.Fill(ds_NhaCungCap, "NhaCungCap");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhaCungCap.Tables["NhaCungCap"].Columns[0];
            ds_NhaCungCap.Tables["NhaCungCap"].PrimaryKey = key;
            return ds_NhaCungCap.Tables["NhaCungCap"];
        }

        public DataTable searchNCC(string tukhoa)
        {
            da_NhaCungCap = new SqlDataAdapter("Exec SP_SearchNCC N'" + tukhoa + "'", conn.conn);
            ds_NhaCungCap = new DataSet();
            da_NhaCungCap.Fill(ds_NhaCungCap, "NhaCungCap");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhaCungCap.Tables["NhaCungCap"].Columns[0];
            ds_NhaCungCap.Tables["NhaCungCap"].PrimaryKey = key;
            return ds_NhaCungCap.Tables["NhaCungCap"];
        }
        public bool addNCC(string mancc, string tenncc, string diachi, string dienthoai, string email, int congno, string stk)
        {
            try
            {
                if (!conn.checkExist("Nhacungcap", "mancc", mancc))
                {
                    string strSQL = "EXEC SP_InsertNCC '" + mancc + "',N'" + tenncc + "',N'" + diachi + "','" + dienthoai + "','" + email + "'," + congno + ",'" + stk + "'";
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
        public bool updateNCC(string mancc, string tenncc, string diachi, string dienthoai, string email, int congno, string stk)
        {
            try
            {
                if (conn.checkExist("Nhacungcap", "mancc", mancc))
                {

                    //string strSQL = "EXEC SP_UpdateNCC '" + mancc + "',N'" + tenncc + "',N'" + diachi + "','" + dienthoai + "','" + email + "'," + congno + ",'" + stk + "'";
                    string strSQL = "Update NhaCungCap Set TenNCC=N'" + tenncc + "', DiaChi=N'" + diachi + "',DienThoai='" + dienthoai + "',Email='" + email + "',CongNo=" + congno + ",SoTaiKhoan='" + stk + "' Where MaNCC='" + mancc + "'";
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
        public bool deleteNCC(string mancc)
        {
            try
            {
                if (conn.checkExist("Nhacungcap", "mancc", mancc))
                {
                    string strSQL = "EXEC sp_deletencc '" + mancc + "'";
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
        public DataTable loadNhaCungCap()
        {
            da_NhaCungCap = new SqlDataAdapter("Select * From NhaCungCap", conn.conn);
            dt_NhaCungCap = new DataTable();
            da_NhaCungCap.Fill(dt_NhaCungCap);
            return dt_NhaCungCap;
        }

        //Lấy tên nhà cung cấp theo mã nhà cung cấp
        public string GetTenNhaCC(string mancc)
        {
            string ten = "";
            string strSql = "Select TenNCC From NhaCungCap Where MaNCC='" + mancc + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenNCC"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenNhaCC(string mancc)
        {
            return GetTenNhaCC(mancc);
        }

        public DataTable GetPhieuNhapHang(string mancc)
        {
            string lenh = string.Format("Select * From PhieuNhapHang Where MaNCC='" + mancc + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layPhieuNhapHang(string mancc)
        {
            return GetPhieuNhapHang(mancc);
        }

        public string layCongNo(string mancc)
        {
            string congno = "";
            string strSql = "Select * From NhaCungCap Where MaNCC='" + mancc + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                congno = dr["CongNo"].ToString();
            }
            dr.Close();
            return congno;
        }
    }
}
