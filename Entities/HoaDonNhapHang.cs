using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class HoaDonNhapHang
    {
        
            string _SoHoaDon;

            public string SoHoaDon
            {
                get { return _SoHoaDon; }
                set { _SoHoaDon = value; }
            }
            string _MaLoaiHoaDon;

            public string MaLoaiHoaDon
            {
                get { return _MaLoaiHoaDon; }
                set { _MaLoaiHoaDon = value; }
            }
            string _MaNV;

            public string MaNV
            {
                get { return _MaNV; }
                set { _MaNV = value; }
            }
            string _MaNCC;

            public string MaNCC
            {
                get { return _MaNCC; }
                set { _MaNCC = value; }
            }

            DateTime _NgayThang = DateTime.Parse("07/12/2022");

            public DateTime NgayThang
            {
                get { return _NgayThang; }
                set { _NgayThang = value; }
            }
            string _NguoiLapPhieu;

            public string NguoiLapPhieu
            {
                get { return _NguoiLapPhieu; }
                set { _NguoiLapPhieu = value; }
            }
            string _SoHoaDonLienQuan;

            public string SoHoaDonLienQuan
            {
                get { return _SoHoaDonLienQuan; }
                set { _SoHoaDonLienQuan = value; }
            }

            double _TongTien;

            public double TongTien
            {
                get { return _TongTien; }
                set { _TongTien = value; }
            }
            double _ChietKhauHoaDon;

            public double ChietKhauHoaDon
            {
                get { return _ChietKhauHoaDon; }
                set { _ChietKhauHoaDon = value; }
            }
            double _DaThanhToan;

            public double DaThanhToan
            {
                get { return _DaThanhToan; }
                set { _DaThanhToan = value; }
            }
            double _ConLai;

            public double ConLai
            {
                get { return _ConLai; }
                set { _ConLai = value; }
            }


            List<ChiTietHoaDonNH> _ListChiTietHoaDon;

            internal List<ChiTietHoaDonNH> ListChiTietHoaDon
        {
                get { return _ListChiTietHoaDon; }
                set { _ListChiTietHoaDon = value; }
            }
            public HoaDonNhapHang()
            {
            }


        
    }
}
