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
    public class XuatHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_PhieuXuat, da_CTPX;
        DataSet ds_PhieuXuat, ds_CTPX;

        public DataTable loadLoHangTheoSanPhamConHSD(string masp)
        {
            string strSQL = "Select * From LoHang, SanPham Where LoHang.MaSP = SanPham.MaSP And SanPham.MaSP='" + masp + "' And HanSuDung >= '" + DateTime.Now + "'";
            DataTable dt_LoHang = new DataTable();
            SqlDataAdapter da_LoHang = new SqlDataAdapter(strSQL, conn.conn);
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public DataTable loadSanPhamTheoLoHang(string malo)
        {
            string strSQL = "Select * From LoHang, SanPham Where LoHang.MaSP = SanPham.MaSP And MaLo='" + malo + "'";
            DataTable dt_SanPham = new DataTable();
            SqlDataAdapter da_SanPham = new SqlDataAdapter(strSQL, conn.conn);
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }

        public DataTable loadDVTTheoSanPham(string masp)
        {
            string strSQL = "Select * From SanPham, DonViTinh Where SanPham.MaDVT = DonViTinh.MaDVT And MaSP='" + masp + "'";
            DataTable dt_DVT = new DataTable();
            SqlDataAdapter da_DVT = new SqlDataAdapter(strSQL, conn.conn);
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
        }

        public string layMaPhieuXuat() //Lấy mã phiếu xuất cuối cùng
        {
            string mapx = "";
            string strSql = "Select * From PhieuXuatHang";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                mapx = dr["MaPXH"].ToString();
            }
            dr.Close();
            return mapx;
        }

        public float layTongSLHangXuatCuaLoHangCuaSanPham(string malo)
        {
            float tongSL = 0;
            string strSql = "Select * From ChiTietPhieuXuatHang Where MaLo='" + malo + "'";
            SqlDataReader tongSLdr = conn.getDataReader(strSql);
            while (tongSLdr.Read())
            {
                tongSL += float.Parse(tongSLdr["SoLuongXuat"].ToString());
            }
            tongSLdr.Close();
            return tongSL;
        }

        public float laySLHangXuatCuaMotChiTiet(string mapx, string malo)
        {
            float soluong = 0;
            string strSql = "Select * From ChiTietPhieuXuatHang Where MaPXH='" + mapx + "' And MaLo='" + malo + "'";
            SqlDataReader soluongdr = conn.getDataReader(strSql);
            while (soluongdr.Read())
            {
                soluong = float.Parse(soluongdr["SoLuongXuat"].ToString());
            }
            soluongdr.Close();
            return soluong;
        }

        public float updateTongSoLuongXuat(string mapx)
        {
            float tongSL = 0;
            string strSql = "Select * From ChiTietPhieuXuatHang Where MaPXH = '" + mapx + "'";
            SqlDataReader tongSLdr = conn.getDataReader(strSql);
            while (tongSLdr.Read())
            {
                tongSL += float.Parse(tongSLdr["SoLuongXuat"].ToString());
            }
            tongSLdr.Close();
            return tongSL;
        }

        public int demSLMatHang(string mapx)
        {
            int demSL = 0;
            string strSql = "Select * From ChiTietPhieuXuatHang Where MaPXH = '" + mapx + "'";
            SqlDataReader demSLdr = conn.getDataReader(strSql);
            while (demSLdr.Read())
            {
                demSL++;
            }
            demSLdr.Close();
            return demSL;
        }

        public DataTable searchPhieuXuatHang(string mapx)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuXuatHang Where MaPXH = '" + mapx + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchPhieuXuatHangTheoNgay(string ngaylapdau, string ngaylapcuoi)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuXuatHang Where '" + ngaylapdau + "' <= NgayXuat And NgayXuat <='" + ngaylapcuoi + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        //Bảng trong giao diện lập phiếu xuất
        public DataTable loadDataGV_CTPXTheoMaPXH(string mapx)
        {
            da_CTPX = new SqlDataAdapter("Select MaPXH, ChiTietPhieuXuatHang.MaLo, MaSP, SoLuongXuat From ChiTietPhieuXuatHang, LoHang Where ChiTietPhieuXuatHang.MaLo = LoHang.MaLo And MaPXH='" + mapx + "'", conn.conn);
            ds_CTPX = new DataSet();
            da_CTPX.Fill(ds_CTPX, "ChiTietPhieuXuatHang, LoHang");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_CTPX.Tables["ChiTietPhieuXuatHang, LoHang"].Columns[0];
            //ds_CTPX.Tables["ChiTietPhieuXuatHang, LoHang"].PrimaryKey = key;
            return ds_CTPX.Tables["ChiTietPhieuXuatHang, LoHang"];
        }

        public DataTable GetCTPX(string mapx)
        {
            string lenh = string.Format("Select MaPXH, ChiTietPhieuXuatHang.MaLo, MaSP, SoLuongXuat From ChiTietPhieuXuatHang, LoHang Where ChiTietPhieuXuatHang.MaLo = LoHang.MaLo And MaPXH='" + mapx + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layCTPX(string mapx)
        {
            return GetCTPX(mapx);
        }

        //Bảng trong giao diện xem phiếu xuất
        public DataTable loadDataGV_PhieuXuatHang()
        {
            da_PhieuXuat = new SqlDataAdapter("Select * From PhieuXuatHang", conn.conn);
            ds_PhieuXuat = new DataSet();
            da_PhieuXuat.Fill(ds_PhieuXuat, "PhieuXuatHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_PhieuXuat.Tables["PhieuXuatHang"].Columns["MaPXH"];
            ds_PhieuXuat.Tables["PhieuXuatHang"].PrimaryKey = key;
            return ds_PhieuXuat.Tables["PhieuXuatHang"];
        }

        public DataTable loadDataGV_ChiTietPhieuXuatHang()
        {
            string strSQL = "Select MaPXH, ChiTietPhieuXuatHang.MaLo, TenLo, LoHang.MaSP, TenSP, TenDVT, SoLuongXuat From ChiTietPhieuXuatHang, LoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuXuatHang.MaLo = LoHang.MaLo And LoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT";
            da_CTPX = new SqlDataAdapter(strSQL, conn.conn);
            ds_CTPX = new DataSet();
            da_CTPX.Fill(ds_CTPX, "ChiTietPhieuXuatHang, LoHang, SanPham, DonViTinh");

            return ds_CTPX.Tables["ChiTietPhieuXuatHang, LoHang, SanPham, DonViTinh"];
        }

        public DataTable GetChiTietPhieuXuatHang(string mapx)
        {
            string lenh = string.Format("Select MaPXH, ChiTietPhieuXuatHang.MaLo, TenLo, LoHang.MaSP, TenSP, TenDVT, SoLuongXuat From ChiTietPhieuXuatHang, LoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuXuatHang.MaLo = LoHang.MaLo And LoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaPXH='" + mapx + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layChiTietPhieuXuatHang(string mapx)
        {
            return GetChiTietPhieuXuatHang(mapx);
        }
    }
}
