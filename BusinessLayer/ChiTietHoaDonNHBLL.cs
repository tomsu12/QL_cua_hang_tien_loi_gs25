using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class ChiTietHoaDonNHBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListDetailHoaDonNHBySoCT(string SoHoaDon)
        {
            string select = "Select a.*,b.TenHang,b.DonViTinh from ChiTietHoaDonNH a,MatHang b" +
                            " where a.MaHang=b.MaHang and a.SoHoaDon='" + SoHoaDon + "'";
            return da.GetDataTable(select);

        }
        public DataTable GetListDetailHoaDonNHBySoCTandMaHang(string SoHoaDon, string Mahang)
        {
            string select = "Select a.*,b.TenHang,b.DonViTinh from ChiTietHoaDonNH a,MatHang b" +
                            " where a.MaHang=b.MaHang and a.SoHoaDon='" + SoHoaDon + "' and a.MaHang='" + Mahang + "'";
            return da.GetDataTable(select);

        }
        public void Insert(ChiTietHoaDonNH DetailHoaDon)
        {
            string query = "Insert into ChiTietHoaDonNH Values ('" + DetailHoaDon.SoHoaDon +
                                                                "','" + DetailHoaDon.MaHang +
                                                                "','" + DetailHoaDon.SoLo +
                                                                "','" + DetailHoaDon.SoLuong +
                                                                "','" + DetailHoaDon.GiaNhap +
                                                                "','" + DetailHoaDon.ChietKhauMatHang +
                                                                "','" + DetailHoaDon.ThanhTien +
                                                                "')";
            da.ExecuteNonQuery(query);
        }
        public void Update(ChiTietHoaDonNH DetailHoaDon)
        {
            string query;
            query = "Update ChiTietHoaDonNH set SoLuong=N'" + DetailHoaDon.SoLuong + "'," +
                                        "GiaNhap='" + DetailHoaDon.GiaNhap + "'," +
                                        "ChietKhauMatHang=N'" + DetailHoaDon.ChietKhauMatHang + "'," +
                                        "ThanhTien='" + DetailHoaDon.ThanhTien + "' " +
                                    "where SoHoaDon='" + DetailHoaDon.SoHoaDon + "'" +
                                    " and MaHang='" + DetailHoaDon.MaHang + "'";

            da.ExecuteNonQuery(query);
        }
        public void Delete(ChiTietHoaDonNH DetailHoaDon)
        {
            string query = "Delete from ChiTietHoaDonNH where SoHoaDon='" + DetailHoaDon.SoHoaDon + "'" +
                                                            " and MaHang='" + DetailHoaDon.MaHang + "'";
            da.ExecuteNonQuery(query);

        }
    }
}
