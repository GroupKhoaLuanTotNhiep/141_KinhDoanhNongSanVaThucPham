using DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NongSanThucPham
{
    public class KhachHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_KhachHang;
        DataSet ds_KhachHang;

        public DataTable loadDataGV_KhachHang()
        {
            da_KhachHang = new SqlDataAdapter("Select * From KhachHang", conn.conn);
            ds_KhachHang = new DataSet();
            da_KhachHang.Fill(ds_KhachHang, "KhachHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KhachHang.Tables["KhachHang"].Columns[0];
            ds_KhachHang.Tables["KhachHang"].PrimaryKey = key;
            return ds_KhachHang.Tables["KhachHang"];
        }

        public DataTable searchKhachHang(string tukhoa)
        {
            da_KhachHang = new SqlDataAdapter("Exec SP_SearchNCC N'" + tukhoa + "'", conn.conn);
            ds_KhachHang = new DataSet();
            da_KhachHang.Fill(ds_KhachHang, "NhaCungCap");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KhachHang.Tables["NhaCungCap"].Columns[0];
            ds_KhachHang.Tables["NhaCungCap"].PrimaryKey = key;
            return ds_KhachHang.Tables["NhaCungCap"];
        }
        public bool addKH(string tenkh, string diachi, string dienthoai, string email, int congno, int tichdiem)
        {
            try
            {
                    string strSQL = "EXEC SP_InsertNCC " + tenkh + "," + diachi + "," + dienthoai + "," + email + "," + tichdiem + "," + congno;
                    conn.updateToDatabase(strSQL);
                    return true;
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

                    string strSQL = "EXEC SP_UpdateNCC " + mancc + "," + tenncc + "," + diachi + "," + dienthoai + "," + email + "," + congno + "," + stk;
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
                    string strSQL = "EXEC sp_deletencc " + mancc;
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
    }
}
