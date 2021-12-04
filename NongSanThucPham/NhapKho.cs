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
    public class NhapKho
    {
        Connection conn = new Connection();
        SqlDataAdapter da_PhieuNhap, da_CTPN;
        DataSet ds_PhieuNhap, ds_CTPN;

        public DataTable loadPhieuNhapHang()
        {
            da_PhieuNhap = new SqlDataAdapter("Select * From PhieuNhapHang", conn.conn);
            DataTable dt_PhieuNhap = new DataTable();
            da_PhieuNhap.Fill(dt_PhieuNhap);
            return dt_PhieuNhap;
        }

        public DataTable loadDonViTinhTheoSanPham(string masp)
        {
            string strSQL = "Select * From DonViTinh, SanPham Where DonViTinh.MaDVT = SanPham.MaDVT And MaSP='" + masp + "'";
            DataTable dt_DVT = new DataTable();
            SqlDataAdapter da_DVT = new SqlDataAdapter(strSQL, conn.conn);
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
        }

        public string layGiaNhapTheoSanPham(string masp)
        {
            string giaNhap = "";
            string strSql = "Select * From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giaNhap = dr["GiaVon"].ToString();
            }
            dr.Close();
            return giaNhap;
        }

        public string layGiaNhapTheoChiTietPhieuNhap(string mapn, string masp)
        {
            string giaNhap = "";
            string strSql = "Select * From ChiTietPhieuNhapHang Where MaPNH='" + mapn + "' And MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giaNhap = dr["DonGia"].ToString();
            }
            dr.Close();
            return giaNhap;
        }

        public string layMaPNH() //Lấy mã phiếu nhập cuối cùng
        {
            string mapn = "";
            string strSql = "Select * From PhieuNhapHang";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                mapn = dr["MaPNH"].ToString();
            }
            dr.Close();
            return mapn;
        }

        public int updateTongSoLuong(string mapn)
        {
            int tongSLSP = 0;
            string strSql = "Select * From ChiTietPhieuNhapHang Where MaPNH = '" + mapn + "'";
            SqlDataReader tongSLSPdr = conn.getDataReader(strSql);
            while (tongSLSPdr.Read())
            {
                tongSLSP += int.Parse(tongSLSPdr["SoLuong"].ToString());
            }
            tongSLSPdr.Close();
            return tongSLSP;
        }

        public int updateTongTien(string mapn)
        {
            int tongTien = 0;
            string strSql = "Select * From ChiTietPhieuNhapHang Where MaPNH = '" + mapn + "'";
            SqlDataReader tongTiendr = conn.getDataReader(strSql);
            while (tongTiendr.Read())
            {
                tongTien += int.Parse(tongTiendr["ThanhTien"].ToString());
            }
            tongTiendr.Close();
            return tongTien;
        }

        public DataTable searchPhieuNhap(string mapn)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuNhapHang Where MaPNH = '" + mapn + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchPhieuNhapTheoNgay(string ngaynhapdau, string ngaynhapcuoi)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuNhapHang Where '" + ngaynhapdau + "' <= NgayNhap And NgayNhap <='" + ngaynhapcuoi + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        //Bảng trong giao diện phiếu nhập
        public DataTable loadDataGV_CTPNTheoMaPN(string mapn)
        {
            da_CTPN = new SqlDataAdapter("Select * From ChiTietPhieuNhapHang Where MaPNH='" + mapn + "'", conn.conn);
            ds_CTPN = new DataSet();
            da_CTPN.Fill(ds_CTPN, "ChiTietPhieuNhapHang");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_CTPN.Tables["ChiTietPhieuNhapHang"].Columns[0];
            //ds_CTPN.Tables["ChiTietPhieuNhapHang"].PrimaryKey = key;
            return ds_CTPN.Tables["ChiTietPhieuNhapHang"];
        }

        public DataTable GetChiTietPhieuNhap(string ma)
        {
            string lenh = string.Format("Select * From ChiTietPhieuNhapHang Where MaPNH='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layChiTietPhieuNhap(string ma)
        {
            return GetChiTietPhieuNhap(ma);
        }

        //Bảng trong giao diện xem phiếu nhập
        public DataTable loadDataGV_PhieuNhap()
        {
            da_PhieuNhap = new SqlDataAdapter("Select * From PhieuNhapHang", conn.conn);
            ds_PhieuNhap = new DataSet();
            da_PhieuNhap.Fill(ds_PhieuNhap, "PhieuNhapHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_PhieuNhap.Tables["PhieuNhapHang"].Columns["MaPNH"];
            ds_PhieuNhap.Tables["PhieuNhapHang"].PrimaryKey = key;
            return ds_PhieuNhap.Tables["PhieuNhapHang"];
        }

        public DataTable loadDataGV_ChiTietPhieuNhap()
        {
            string strSQL = "Select MaPNH, ChiTietPhieuNhapHang.MaSP, TenSP, TenDVT, SoLuong, DonGia, ThanhTien From ChiTietPhieuNhapHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuNhapHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT";
            da_CTPN = new SqlDataAdapter(strSQL, conn.conn);
            ds_CTPN = new DataSet();
            da_CTPN.Fill(ds_CTPN, "ChiTietPhieuNhapHang, SanPham, DonViTinh");

            return ds_CTPN.Tables["ChiTietPhieuNhapHang, SanPham, DonViTinh"];
        }

        public DataTable GetCTPN(string ma)
        {
            string lenh = string.Format("Select MaPNH, ChiTietPhieuNhapHang.MaSP, TenSP, TenDVT, SoLuong, DonGia, ThanhTien From ChiTietPhieuNhapHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuNhapHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaPNH='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layCTPN(string ma)
        {
            return GetCTPN(ma);
        }
    }
}
