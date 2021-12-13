using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace NongSanThucPham
{
    public class ThanhLy
    {
        Connection conn = new Connection();
        SqlDataAdapter da_ThanhLy, da_CTPTL;
        DataSet ds_ThanhLy, ds_CTPTL;

        public DataTable loadSanPhamTheoLoHang(string malo)
        {
            string strSQL = "Select * From LoHang, SanPham Where LoHang.MaSP = SanPham.MaSP And MaLo='" + malo + "'";
            DataTable dt_SanPham = new DataTable();
            SqlDataAdapter da_SanPham = new SqlDataAdapter(strSQL, conn.conn);
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }

        public DataTable loadDVTTheoLoHang(string malo)
        {
            string strSQL = "Select * From LoHang, SanPham, DonViTinh Where LoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaLo='" + malo + "'";
            DataTable dt_DVT = new DataTable();
            SqlDataAdapter da_DVT = new SqlDataAdapter(strSQL, conn.conn);
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
        }

        public DataTable loadLoHangTheoSanPhamHetHSD(string masp)
        {
            string strSQL = "Select * From LoHang, SanPham Where LoHang.MaSP = SanPham.MaSP And SanPham.MaSP='" + masp + "' And HanSuDung < '" + DateTime.Now + "'";
            DataTable dt_LoHang = new DataTable();
            SqlDataAdapter da_LoHang = new SqlDataAdapter(strSQL, conn.conn);
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public string layMaPTL() //Lấy mã phiếu thanh lý cuối cùng
        {
            string matl = "";
            string strSql = "Select * From PhieuThanhLy";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                matl = dr["MaPTL"].ToString();
            }
            dr.Close();
            return matl;
        }

        public float updateTongSLThanhLy(string matl)
        {
            float tongSL = 0;
            string strSql = "Select * From ChiTietPhieuThanhLy Where MaPTL = '" + matl + "'";
            SqlDataReader tongSLdr = conn.getDataReader(strSql);
            while (tongSLdr.Read())
            {
                tongSL += float.Parse(tongSLdr["SoLuong"].ToString());
            }
            tongSLdr.Close();
            return tongSL;
        }

        public int demSLMatHang(string matl)
        {
            int demSL = 0;
            string strSql = "Select * From ChiTietPhieuThanhLy Where MaPTL = '" + matl + "'";
            SqlDataReader demSLdr = conn.getDataReader(strSql);
            while (demSLdr.Read())
            {
                demSL++;
            }
            demSLdr.Close();
            return demSL;
        }

        public string laySoLuongSanPham(string masp)
        {
            string soLuong = "";
            string strSql = "Select * From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                soLuong = dr["SoLuongSP"].ToString();
            }
            dr.Close();
            return soLuong;
        }

        public string laySoLuongCTPTL(string matl, string malo)
        {
            string soLuong = "";
            string strSql = "Select * From ChiTietPhieuThanhLy Where MaPTL = '" + matl + "' And MaLo='" + malo + "'";
            SqlDataReader soLuongdr = conn.getDataReader(strSql);
            while (soLuongdr.Read())
            {
                soLuong = soLuongdr["SoLuong"].ToString();
            }
            soLuongdr.Close();
            return soLuong;
        }

        public string layLiDo(string matl)
        {
            string liDo = "";
            string strSql = "Select * From PhieuThanhLy Where MaPTL='" + matl + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                liDo = dr["LiDo"].ToString();
            }
            dr.Close();
            return liDo;
        }

        public string layTinhTrangPTL(string matl)
        {
            string tinhTrang = "";
            string strSql = "Select * From PhieuThanhLy Where MaPTL='" + matl + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                tinhTrang = dr["TinhTrang"].ToString();
            }
            dr.Close();
            return tinhTrang;
        }

        public DataTable searchPhieuThanhLy(string matl)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuThanhLy Where MaPTL = '" + matl + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchPhieuThanhLyTheoNgay(string ngaylapdau, string ngaylapcuoi)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuThanhLy Where '" + ngaylapdau + "' <= NgayTL And NgayTL <='" + ngaylapcuoi + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        //Bảng trong giao diện lập phiếu thanh lý
        public DataTable loadDataGV_CTPTLTheoMaPTL(string matl)
        {
            da_CTPTL = new SqlDataAdapter("Select MaPTL, ChiTietPhieuThanhLy.MaLo, MaSP, ChiTietPhieuThanhLy.SoLuong From ChiTietPhieuThanhLy, LoHang Where ChiTietPhieuThanhLy.MaLo = LoHang.MaLo And MaPTL='" + matl + "'", conn.conn);
            ds_CTPTL = new DataSet();
            da_CTPTL.Fill(ds_CTPTL, "ChiTietPhieuThanhLy, LoHang");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_CTPTL.Tables["ChiTietPhieuThanhLy, LoHang"].Columns[0];
            //ds_CTPTL.Tables["ChiTietPhieuThanhLy, LoHang"].PrimaryKey = key;
            return ds_CTPTL.Tables["ChiTietPhieuThanhLy, LoHang"];
        }

        public DataTable GetCTPTL(string matl)
        {
            string lenh = string.Format("Select MaPTL, ChiTietPhieuThanhLy.MaLo, MaSP, ChiTietPhieuThanhLy.SoLuong From ChiTietPhieuThanhLy, LoHang Where ChiTietPhieuThanhLy.MaLo = LoHang.MaLo And MaPTL='" + matl + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layCTPTL(string matl)
        {
            return GetCTPTL(matl);
        }

        //Bảng trong giao diện xem phiếu thanh lý
        public DataTable loadDataGV_PhieuThanhLy()
        {
            da_ThanhLy = new SqlDataAdapter("Select * From PhieuThanhLy", conn.conn);
            ds_ThanhLy = new DataSet();
            da_ThanhLy.Fill(ds_ThanhLy, "PhieuThanhLy");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ThanhLy.Tables["PhieuThanhLy"].Columns["MaPTL"];
            ds_ThanhLy.Tables["PhieuThanhLy"].PrimaryKey = key;
            return ds_ThanhLy.Tables["PhieuThanhLy"];
        }

        public DataTable loadDataGV_ChiTietPhieuThanhLy()
        {
            string strSQL = "Select MaPTL, ChiTietPhieuThanhLy.MaLo, TenLo, LoHang.MaSP, TenSP, TenDVT, ChiTietPhieuThanhLy.SoLuong From ChiTietPhieuThanhLy, LoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuThanhLy.MaLo = LoHang.MaLo And LoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT";
            da_CTPTL = new SqlDataAdapter(strSQL, conn.conn);
            ds_CTPTL = new DataSet();
            da_CTPTL.Fill(ds_CTPTL, "ChiTietPhieuThanhLy, LoHang, SanPham, DonViTinh");

            return ds_CTPTL.Tables["ChiTietPhieuThanhLy, LoHang, SanPham, DonViTinh"];
        }

        public DataTable GetChiTietPhieuThanhLy(string matl)
        {
            string lenh = string.Format("Select MaPTL, ChiTietPhieuThanhLy.MaLo, TenLo, LoHang.MaSP, TenSP, TenDVT, ChiTietPhieuThanhLy.SoLuong From ChiTietPhieuThanhLy, LoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuThanhLy.MaLo = LoHang.MaLo And LoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaPTL='" + matl + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layChiTietPhieuThanhLy(string matl)
        {
            return GetChiTietPhieuThanhLy(matl);
        }
    }
}
