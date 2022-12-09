using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.DataLayer;
using System.Data;
namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class HoaDonNhapHangBLL
    {
        DataAccess da = new DataAccess();
        public void Insert(HoaDonNhapHang ct)
        {

            string query;
            query = " Insert into HoaDonNhapHang values('" + ct.SoHoaDon +
                                              "','" + ct.MaLoaiHoaDon +
                                              "','" + ct.MaNV +
                                              "','" + ct.MaNCC +
                                              "',convert(datetime,'" + ct.NgayThang + "',103) " +
                                              ",'" + ct.MaNV +
                                              "','" + ct.SoHoaDonLienQuan +
                                              "','" + ct.TongTien +
                                              "','" + ct.ChietKhauHoaDon +
                                              "','" + ct.DaThanhToan +
                                              "')";

            da.ExecuteNonQuery(query);

            foreach (ChiTietHoaDonNH ctt in ct.ListChiTietHoaDon)
            {
                string query1;
                query1 = "Insert into ChiTietHoaDonNH Values ('" + ctt.SoHoaDon +
                                                            "','" + ctt.MaHang +
                                                            "','" + ctt.SoLo +
                                                            "','" + ctt.SoLuong +
                                                            "','" + ctt.GiaNhap +
                                                            "','" + ctt.ChietKhauMatHang +
                                                            "','" + ctt.ThanhTien +
                                                            "')";

                da.ExecuteNonQuery(query1);
            }

        }
        public string GetMaxID(LoaiHoaDon loaiCT)
        {
            string ID = "";
            string select = "select top 1 SoHoaDon from HoaDonNhapHang " +
                "where MaLoaiHoaDon='" + loaiCT.MaLoaiHoaDon + "' order by SoHoaDon DESC";
            if (da.GetDataTable(select).Rows.Count > 0)
            {
                ID = da.GetDataTable(select).Rows[0]["SoHoaDon"].ToString();
                return ID.Substring(3, 5);
            }
            else
                return ID;
        }
        public int GetSoLoHangNhapByIdMatHang(string id)
        {
            int SoLo = 0;
            string select = "Select top 1 SoLo from ChiTietHoaDonNH where MaHang='" + id + "' order by SoLo Desc";
            if (da.GetDataTable(select).Rows.Count > 0)
            {
                return SoLo = int.Parse(da.GetDataTable(select).Rows[0]["SoLo"].ToString());
            }
            else
                return SoLo;
        }
        public DataTable GetListHoaDonByID(string soct)
        {
            string select = "Select * from HoaDonNhapHang where SoHoaDon='" + soct + "'";
            return da.GetDataTable(select);
        }
        public DataTable GetListHoaDonByID(string MaNV, string soct)
        {
            string select = "Select * from HoaDonNhapHang where SoHoaDon='" + soct +
                                                    "' and MaNV='" + MaNV + "'";
            return da.GetDataTable(select);
        }
        public DataTable GetListHoaDonByDate(string TuNgay, string DenNgay)
        {
            string select = "Select * from HoaDonNhapHang where" +
                              " convert(datetime,NgayThang,103) between convert(datetime,'" + TuNgay +
                              "',103) and convert(datetime,'" + DenNgay +
                              "',103)";

            return da.GetDataTable(select);
        }
        public DataTable GetListHoaDonByMaNCC(string MaNCC)
        {
            string select = "Select * from HoaDonNhapHang where" +
                              " MaNCC='" + MaNCC + "'";
            return da.GetDataTable(select);
        }

        public void Delete(string SoHoaDon)
        {
            string query;
            query = "Delete from ChiTietHoaDonNH where SoHoaDon='" + SoHoaDon + "' ;" +
                    " Delete from HoaDonNhapHang where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(string SoHoaDon, string NguoiCapNhat, string chietKhauHD, string daThanhToan)
        {
            string query = "Update HoaDonNhapHang Set MaNV='" + NguoiCapNhat + "'," +
                                                    " ChietKhauHoaDon='" + chietKhauHD + "'," +
                                                    " DaThanhToan='" + daThanhToan + "'" +
                                                " where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }

        public void UpdateNguoiLapPhieu(string SoHoaDon, string MaNV)
        {
            string query = "Update HoaDonNhapHang Set MaNV='" + MaNV + "' where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
    }
}
