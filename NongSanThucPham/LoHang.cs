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
    public class LoHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_LoHang;
        DataSet ds_LoHang;
        DataTable dt_LoHang;
        DataView dtv_LoHang;
        string _MaLo, _MaPNH, _MaSP;

        public string MaLo
        {
            get { return _MaLo; }
            set { _MaLo = value; }
        }

        public string MaPNH
        {
            get { return _MaPNH; }
            set { _MaPNH = value; }
        }

        public string MaSP
        {
            get { return _MaSP; }
            set { _MaSP = value; }
        }

        public bool addLoHang(string ma,string ten,DateTime nsx,DateTime hsd,float soluong, int mapnh,string masp, int magia)
        {
            try
            {
                if (!conn.checkExist("LoHang", "malo", ma))
                {
                    string strSQL = "EXEC SP_InsertLoHang '" + ma + "',N'" + ten + "','" + nsx + "','" + hsd+ "'," + soluong+ "," +mapnh+ ",'" + masp + "', " +magia;
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
        public bool updateLoHang(string ma, string ten, DateTime nsx, DateTime hsd, int mapnh, string masp, int gia)
        {
            try
            {

                if (conn.checkExist("LoHang", "MaLo", ma))
                {
                    string strSQL = "Update LoHang Set TenLo=N'" + ten + "', NgaySanXuat='" + nsx + "', HanSuDung='" + hsd + "', MaPNH=" + mapnh + ", MaSP='" + masp + "', MaGia=" + gia + " Where MaLo='" + ma + "'";
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
        public bool deleteLoHang(string ma)
        {
            try
            {
                if (conn.checkExist("LoHang", "malo", ma))
                {
                    string strSQL = "Delete LoHang Where MaLo= '" + ma + "'";
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
        public DataTable loadDataGV_LoHang()
        {
            da_LoHang = new SqlDataAdapter("Select * From LoHang", conn.conn);
            ds_LoHang = new DataSet();
            da_LoHang.Fill(ds_LoHang, "LoHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_LoHang.Tables["LoHang"].Columns["MaLo"];
            ds_LoHang.Tables["LoHang"].PrimaryKey = key;
            return ds_LoHang.Tables["LoHang"];
        }

        public DataTable searchLoHangTheoMaPNH(string mapn)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select MaLo, TenLo, NgaySanXuat, HanSuDung, SoLuong, LoHang.MaPNH, MaSP, MaGia From LoHang, PhieuNhapHang Where LoHang.MaPNH = PhieuNhapHang.MaPNH And PhieuNhapHang.MaPNH='" + mapn + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchLoHangTheoMaLo(string malo)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From LoHang Where MaLo = '" + malo + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable loadLoHang()
        {
            da_LoHang = new SqlDataAdapter("Select * From LoHang", conn.conn);
            dt_LoHang = new DataTable();
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public DataTable loadLoHangHetHan()
        {
            da_LoHang = new SqlDataAdapter("Select * From LoHang Where HanSuDung <'" + DateTime.Now + "' And SoLuong >" + 0 , conn.conn);
            dt_LoHang = new DataTable();
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public DataTable loadLoHangChuaHetHan()
        {
            da_LoHang = new SqlDataAdapter("Select * From LoHang Where HanSuDung >='" + DateTime.Now + "' And SoLuong >" + 0, conn.conn);
            dt_LoHang = new DataTable();
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public string laySoLuong(string malo)
        {
            string soLuong = "";
            string strSql = "Select * From LoHang Where MaLo = '" + malo + "'";
            SqlDataReader soLuongdr = conn.getDataReader(strSql);
            while (soLuongdr.Read())
            {
                soLuong = soLuongdr["SoLuong"].ToString();
            }
            soLuongdr.Close();
            return soLuong;
        }

        public string laySLTheoGiaVaSanPham(string magia, string masp)
        {
            string soLuong = "";
            string strSql = "Select * From LoHang Where MaGia = '" + magia + "' And MaSP='" + masp + "'";
            SqlDataReader soLuongdr = conn.getDataReader(strSql);
            while (soLuongdr.Read())
            {
                soLuong = soLuongdr["SoLuong"].ToString();
            }
            soLuongdr.Close();
            return soLuong;
        }

        public string layHanSuDung(string malo)
        {
            string hsd = "";
            string strSql = "Select * From LoHang Where MaLo = '" + malo + "'";
            SqlDataReader hsddr = conn.getDataReader(strSql);
            while (hsddr.Read())
            {
                hsd = hsddr["HanSuDung"].ToString();
            }
            hsddr.Close();
            return hsd;
        }

        public string layHSDTheoGiaVaSanPham(string magia, string masp)
        {
            string hsd = "";
            string strSql = "Select * From LoHang Where MaGia = '" + magia + "' And MaSP='" + masp + "'";
            SqlDataReader hsddr = conn.getDataReader(strSql);
            while (hsddr.Read())
            {
                hsd = hsddr["HanSuDung"].ToString();
            }
            hsddr.Close();
            return hsd;
        }

        //Lấy tên lô hàng theo mã lô hàng
        public string GetTenLoHang(string malo)
        {
            string ten = "";
            string strSql = "Select TenLo From LoHang Where MaLo='" + malo + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenLo"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenLoHang(string malo)
        {
            return GetTenLoHang(malo);
        }

        public string layMaLoHang(string magia, string masp)
        {
            string ma = "";
            string strSql = "Select MaLo From LoHang Where MaSP='" + masp + "' And MaGia='" + magia + "' And HanSuDung >='" + DateTime.Now + "' And SoLuong >" + 0;
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaLo"].ToString();
            }
            dr.Close();
            return ma;
        }

        public string layMaLoHetHang(string magia, string masp)
        {
            string ma = "";
            string strSql = "Select MaLo From LoHang Where MaSP='" + masp + "' And MaGia='" + magia + "' And HanSuDung >='" + DateTime.Now + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaLo"].ToString();
            }
            dr.Close();
            return ma;
        }

        public string layMaLo(string magia, string masp)
        {
            string ma = "";
            string strSql = "Select MaLo From LoHang Where MaSP='" + masp + "' And MaGia='" + magia + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaLo"].ToString();
            }
            dr.Close();
            return ma;
        }

        public string layMaLoHetHan(string magia, string masp)
        {
            string ma = "";
            string strSql = "Select MaLo From LoHang Where MaSP='" + masp + "' And MaGia='" + magia + "' And HanSuDung <'" + DateTime.Now + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaLo"].ToString();
            }
            dr.Close();
            return ma;
        }

        public string layLo(string masp)
        {
            string ma = "";
            string strSql = "Select MaLo From LoHang Where MaSP='" + masp + "' And (DATEDIFF(day, GETDATE(), HanSuDung) > 30) And SoLuong >" + 0;
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaLo"].ToString();
            }
            dr.Close();
            return ma;
        }

        public string layMaSPTheoLoHang(string malo)
        {
            string ma = "";
            string strSql = "Select MaSP From LoHang Where MaLo = '" + malo + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ma = dr["MaSP"].ToString();
            }
            dr.Close();
            return ma;
        }

        public DataTable loadLoHangChuaHetHanTheoSanPham(string masp)
        {
            da_LoHang = new SqlDataAdapter("Select * From LoHang Where MaSP='" + masp + "' And HanSuDung >='" + DateTime.Now + "'", conn.conn);
            dt_LoHang = new DataTable();
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

    }
}
