using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class HoaDonBanHangBLL
    {
        DataAccess da = new DataAccess();
        public void Insert(HoaDonBanHang ct)
        {

            string query;
            query = " Insert into HoaDonBanHang values('" + ct.SoHoaDon +
                                              "','" + ct.MaLoaiHoaDon +
                                              "','" + ct.MaNV +
                                              "','" + ct.MaKhach +
                                              "',N'" + ct.TenKhachHang +
                                              "',N'" + ct.DiaChi +
                                              "','" + ct.SDT +
                                              "',convert(datetime,'" + ct.NgayThang + "',103) " +
                                              "',N'" + ct.DiaChiGiaoHang +
                                              "','" + ct.TongTien +
                                              "','" + ct.ChietKhauHoaDon +
                                              "','" + ct.DaThanhToan +
                                              "',N'" + ct.KetQua +
                                              "','" + ct.MaPhieuQuaTang +
                                              "','" + ct.TriGiaPQT +
                                              "','false' )";

            da.ExecuteNonQuery(query);

            foreach (ChiTietHoaDonBH ctt in ct.ListChiTietHoaDon)
            {
                string query1;
                query1 = "Insert into ChiTietHoaDonBH Values ('" + ctt.SoHoaDon +
                                                            "','" + ctt.MaHang +
                                                            "','" + ctt.SoLo +
                                                            "','" + ctt.SoLuong +
                                                            "','" + ctt.GiaBan +
                                                            "','" + ctt.ChietKhauMatHang +
                                                            "','" + ctt.ThanhTien +
                                                            "')";

                da.ExecuteNonQuery(query1);
            }

        }
        public bool Exist(HoaDonBanHang HoaDon)
        {
            string select = "Select * from HoaDonBanHang where SoHoaDon='" + HoaDon.SoHoaDon + "'";
            if (da.GetDataTable(select).Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable GetDonHangChuaGiao()
        {
            string select = "Select SoHoaDon,MaLoaiHoaDon,MaNV,MaKhach," +
                "TenKhachHang,SDT,DiaChiGiaoHang" +
                " from HoaDonBanHang where KetQua=N'Chưa giao hàng'";
            return da.GetDataTable(select);
        }
        public DataTable GetDonHangDangGiaoHang()
        {
            string select = "Select SoHoaDon,MaLoaiHoaDon,MaNV,MaKhach,NVGiaoHang, " +
                "TenKhachHang,SDT,DiaChiGiaoHang " +
                " from HoaDonBanHang where KetQua=N'Đang giao hàng'";
            return da.GetDataTable(select);
        }
        public DataTable GetDonHangDaGiaoHang(DateTime TuNgay, DateTime DenNgay)
        {
            string select = "Select SoHoaDon,MaLoaiHoaDon,MaNV,MaKhach,NVGiaoHang," +
                "TenKhachHang,SDT,DiaChiGiaoHang" +
                " from HoaDonBanHang where KetQua=N'Đã giao hàng' and convert(datetime,NgayThang,103) between convert(datetime,'" + TuNgay + "',103) and convert(datetime,'" + DenNgay + "',103)";
            return da.GetDataTable(select);
        }
        public string GetMaxID(LoaiHoaDon loaiCT)
        {
            string ID = "";
            string select = "select top 1 SoHoaDon from HoaDonBanHang " +
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
            string select = "Select top 1 SoLo from ChiTietHoaDonBH where MaHang='" + id + "' order by SoLo Desc";
            if (da.GetDataTable(select).Rows.Count > 0)
            {
                return SoLo = int.Parse(da.GetDataTable(select).Rows[0]["SoLo"].ToString());
            }
            else
                return SoLo;
        }
        public DataTable GetListHoaDonByID(string soct)
        {
            string select = "Select * from HoaDonBanHang where SoHoaDon='" + soct + "'";
            return da.GetDataTable(select);
        }
        public DataTable GetListHoaDonByDate(string TuNgay, string DenNgay)
        {
            string select = "Select * from HoaDonBanHang where" +
                              " convert(datetime,NgayThang,103) between convert(datetime,'" + TuNgay +
                              "',103) and convert(datetime,'" + DenNgay +
                              "',103)";
            return da.GetDataTable(select);
        }
        public DataTable GetListHoaDonByMaKhach(string MaKhach)
        {
            string select = "Select * from HoaDonBanHang where MaKhach=" + "'" + MaKhach + "'";
            return da.GetDataTable(select);
        }
        public void Delete(string SoHoaDon)
        {
            string query;
            query = "Delete from ChiTietHoaDonBH where SoHoaDon='" + SoHoaDon + "' ;" +
                    " Delete from HoaDonBanHang where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
        public void UpdateMaNV(string SoHoaDon, string MaNV)
        {
            string query = "Update HoaDonBanHang Set MaNV='" + MaNV + "'" +
                            " where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
        public void UpdateKetQuaGiaoHang(string SoHoaDon, string KetQua)
        {
            string query = "Update HoaDonBanHang Set KetQua=N'" + KetQua + "'" +
                            " where SoHoaDon='" + SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(HoaDonBanHang ct)
        {
            string query = "Update HoaDonBanHang Set ChietKhauHoaDon='" + ct.ChietKhauHoaDon + "'," +
                                                    " DaThanhToan='" + ct.DaThanhToan + "'," +
                                                    " DiaChiGiaoHang= N'" + ct.DiaChiGiaoHang + "'" +
                                                " where SoHoaDon='" + ct.SoHoaDon + "'";
            da.ExecuteNonQuery(query);
        }
        public void UpdateNhanPQT(string SoHoaDonBH)
        {
            string query = "Update HoaDonBanHang set DuocNhanPQT='true' where SoHoaDon='" + SoHoaDonBH + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable ReportBanHangTheoNgay(string TuNgay, string DenNgay, string LoaiPhieuXuat)
        {
            string select = "Select ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                     " where convert(datetime,HoaDonBanHang.NgayThang,103)" +
                    " between convert(datetime,'" + TuNgay + "',103) and " +
                    " convert(datetime,'" + DenNgay + "',103) " +
                    " and HoaDonBanHang.MaLoaiHoaDon='" + LoaiPhieuXuat + "'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoNgay(string TuNgay, string DenNgay)
        {
            string select = "Select ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                     " where convert(datetime,HoaDonBanHang.NgayThang,103)" +
                    " between convert(datetime,'" + TuNgay + "',103) and " +
                    " convert(datetime,'" + DenNgay + "',103) " +
                    " group by ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoThang(string Thang, string Nam)
        {
            string select = "Select  ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where Month(NgayThang)='" + Thang + "'" +
                    " and Year(NgayThang)='" + Nam + "'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoThang(string Thang, string Nam, string LoaiPhieuXuat)
        {
            string select = "Select  ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where Month(NgayThang)='" + Thang + "'" +
                    " and Year(NgayThang)='" + Nam + "'" +
                    " and HoaDonBanHang.MaLoaiHoaDon='" + LoaiPhieuXuat + "'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoThang(string Thang, string Nam, string MaNV, string MaHang)
        {
            string select = "Select  ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where Month(NgayThang)='" + Thang + "'" +
                    " and Year(NgayThang)='" + Nam + "'" +
                    " and MaNV like '%" + MaNV + "%' and ChiTietHoaDonBH.MaHang like '%" + MaHang + "%'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoThang(string Thang, string Nam, string LoaiPhieuXuat, string MaNV, string MaHang)
        {
            string select = "Select  ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where Month(NgayThang)='" + Thang + "'" +
                    " and Year(NgayThang)='" + Nam + "'" +
                    " and MaNV like '%" + MaNV + "%' and ChiTietHoaDonBH.MaHang like '%" + MaHang + "%'" +
                    " and HoaDonBanHang.MaLoaiHoaDon='" + LoaiPhieuXuat + "'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }

        public DataTable ReportBanHangTheoNgay(string TuNgay, string DenNgay, string MaNV, string MaHang)
        {
            string select = "Select ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where convert(datetime,HoaDonBanHang.NgayThang,103)" +
                    " between convert(datetime,'" + TuNgay + "',103) and " +
                    " convert(datetime,'" + DenNgay + "',103) " +
                      " and MaNV like '%" + MaNV + "%' and ChiTietHoaDonBH.MaHang like '%" + MaHang + "%'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoNgay(string TuNgay, string DenNgay, string LoaiPhieuXuat, string MaNV, string MaHang)
        {
            string select = "Select ChiTietHoaDonBH.MaHang,TenHang,DonViTinh,SoLo," +
                      "ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,sum(SoLuong) as SoLuong,sum(ThanhTien) as ThanhTien" +
                      " from (ChiTietHoaDonBH inner join HoaDonBanHang " +
                      " on ChiTietHoaDonBH.SoHoaDon=HoaDonBanHang.SoHoaDon)" +
                      " inner join MatHang on ChiTietHoaDonBH.MaHang=MatHang.MaHang" +
                    " where convert(datetime,HoaDonBanHang.NgayThang,103)" +
                    " between convert(datetime,'" + TuNgay + "',103) and " +
                    " convert(datetime,'" + DenNgay + "',103) " +
                    " and HoaDonBanHang.MaLoaiHoaDon='" + LoaiPhieuXuat + "'" +
                    " and MaNV like '%" + MaNV + "%' and ChiTietHoaDonBH.MaHang like '%" + MaHang + "%'" +
                    " group by ChiTietHoaDonBH.MaHang,SoLo,ChiTietHoaDonBH.GiaBan,ChietKhauMatHang,TenHang,DonViTinh ";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoNhanVien(string TuNgay, string DenNgay)
        {
            string select = "SELECT HoaDonBanHang.MaNV,NhanVien.TenNV," +
                            " SUM(ChiTietHoaDonBH.ThanhTien) AS DoanhSo" +
                            " FROM ChiTietHoaDonBH INNER JOIN HoaDonBanHang ON " +
                 " ChiTietHoaDonBH.SoHoaDon = HoaDonBanHang.SoHoaDon INNER JOIN" +
                 " NhanVien ON HoaDonBanHang.MaNV = dbo.NhanVien.MaNV" +
            " WHERE  (CONVERT(datetime, HoaDonBanHang.NgayThang, 103)" +
            "  BETWEEN CONVERT(datetime,'" + TuNgay + "', 103) AND CONVERT(datetime,'" + DenNgay +
            "', 103))GROUP BY dbo.HoaDonBanHang.MaNV, dbo.NhanVien.TenNV";
            return da.GetDataTable(select);
        }
        public DataTable ReportBanHangTheoNhanVien(string MaNV, string TuNgay, string DenNgay)
        {
            string select = "SELECT HoaDonBanHang.MaNV,NhanVien.TenNV," +
                            " SUM(ChiTietHoaDonBH.ThanhTien) AS DoanhSo" +
                            " FROM ChiTietHoaDonBH INNER JOIN HoaDonBanHang ON " +
                 " ChiTietHoaDonBH.SoHoaDon = HoaDonBanHang.SoHoaDon INNER JOIN" +
                 " NhanVien ON HoaDonBanHang.MaNV = dbo.NhanVien.MaNV" +
            " WHERE  (CONVERT(datetime, HoaDonBanHang.NgayThang, 103)" +
            "  BETWEEN CONVERT(datetime,'" + TuNgay + "', 103) AND CONVERT(datetime,'" + DenNgay +
            "', 103)) and HoaDonBanHang.MaNV='" + MaNV + "' GROUP BY dbo.HoaDonBanHang.MaNV, dbo.NhanVien.TenNV";
            return da.GetDataTable(select);
        }


    }
}
