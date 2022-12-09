using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class HoaDonBanHang
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
        string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        string _SDT;

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        string _MaSoThue;

        public string MaSoThue
        {
            get { return _MaSoThue; }
            set { _MaSoThue = value; }
        }
        string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        DateTime _NgayThang = DateTime.Parse("07/12/2022");

        public DateTime NgayThang
        {
            get { return _NgayThang; }
            set { _NgayThang = value; }
        }
        string _TenKhachHang;

        public string TenKhachHang
        {
            get { return _TenKhachHang; }
            set { _TenKhachHang = value; }
        }
        string _DiaChiGiaoHang;

        public string DiaChiGiaoHang
        {
            get { return _DiaChiGiaoHang; }
            set { _DiaChiGiaoHang = value; }
        }
        DateTime _NgayGiaoHang = DateTime.Parse("07/12/2022");

        public DateTime NgayGiaoHang
        {
            get { return _NgayGiaoHang; }
            set { _NgayGiaoHang = value; }
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

        string _KetQua;

        public string KetQua
        {
            get { return _KetQua; }
            set { _KetQua = value; }
        }
        List<ChiTietHoaDonBH> _ListChiTietHoaDon;

        internal List<ChiTietHoaDonBH> ListChiTietHoaDon
        {
            get { return _ListChiTietHoaDon; }
            set { _ListChiTietHoaDon = value; }
        }
        string _NVGiaoHang;

        public string NVGiaoHang
        {
            get { return _NVGiaoHang; }
            set { _NVGiaoHang = value; }
        }
        string _MaPhieuQuaTang;

        public string MaPhieuQuaTang
        {
            get { return _MaPhieuQuaTang; }
            set { _MaPhieuQuaTang = value; }
        }
        double _TriGiaPQT;

        public double TriGiaPQT
        {
            get { return _TriGiaPQT; }
            set { _TriGiaPQT = value; }
        }
        public HoaDonBanHang()
        {
        }
    }
}
