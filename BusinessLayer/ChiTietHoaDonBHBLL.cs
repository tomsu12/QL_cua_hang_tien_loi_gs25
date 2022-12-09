using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class ChiTietHoaDonBHBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListDetailHoaDonBHBySoCT(string SoHoaDon)
        {
            string select = "Select a.*,b.TenHang,b.DonViTinh from ChiTietHoaDonBH a,MatHang b" +
                            " where a.MaHang=b.MaHang and a.SoHoaDon='" + SoHoaDon + "'";
            return da.GetDataTable(select);

        }
        public DataTable GetListDetailHoaDonBH(string SoHoaDon, string Mahang, string SoLo)
        {
            string select = "Select a.*,b.TenHang,b.DonViTinh from ChiTietHoaDonBH a,MatHang b" +
                            " where a.MaHang=b.MaHang and a.SoHoaDon='" + SoHoaDon + "'" +
                            " and a.MaHang='" + Mahang + "'" +
                            " and a.SoLo='" + SoLo + "'";

            return da.GetDataTable(select);

        }
        public void Insert(ChiTietHoaDonBH DetailHoaDon)
        {
            string query = "Insert into ChiTietHoaDonBH Values ('" + DetailHoaDon.SoHoaDon +
                                                                "','" + DetailHoaDon.MaHang +
                                                                "','" + DetailHoaDon.SoLo +
                                                                "','" + DetailHoaDon.SoLuong +
                                                                "','" + DetailHoaDon.GiaBan +
                                                                "','" + DetailHoaDon.ChietKhauMatHang +
                                                                "','" + DetailHoaDon.ThanhTien +
                                                                "')";
            da.ExecuteNonQuery(query);
        }
        public void Update(ChiTietHoaDonBH DetailHoaDon)
        {
            string query;
            query = "Update ChiTietHoaDonBH set SoLuong=N'" + DetailHoaDon.SoLuong + "'," +
                                        "GiaBan='" + DetailHoaDon.GiaBan + "'," +
                                        "ChietKhauMatHang=N'" + DetailHoaDon.ChietKhauMatHang + "'," +
                                        "ThanhTien='" + DetailHoaDon.ThanhTien + "' " +
                                    "where SoHoaDon='" + DetailHoaDon.SoHoaDon + "'" +
                                    " and MaHang='" + DetailHoaDon.MaHang + "'" +
                                    " and SoLo='" + DetailHoaDon.SoLo + "'";

            da.ExecuteNonQuery(query);
        }
        public void Delete(ChiTietHoaDonBH DetailHoaDon)
        {
            string query = "Delete from ChiTietHoaDonBH where SoHoaDon='" + DetailHoaDon.SoHoaDon + "'" +
                                                            " and MaHang='" + DetailHoaDon.MaHang + "'" +
                                                            " and SoLo='" + DetailHoaDon.SoLo + "'";
            da.ExecuteNonQuery(query);

        }
    }
}
