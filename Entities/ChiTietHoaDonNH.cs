using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class ChiTietHoaDonNH
    {
        string _SoHoaDon;

        public string SoHoaDon
        {
            get { return _SoHoaDon; }
            set { _SoHoaDon = value; }
        }

        string _MaHang;

        public string MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        double _SoLo;

        public double SoLo
        {
            get { return _SoLo; }
            set { _SoLo = value; }
        }
        double _SoLuong;

        public double SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        double _GiaNhap;

        public double GiaNhap
        {
            get { return _GiaNhap; }
            set { _GiaNhap = value; }
        }
        double _ChietKhauMatHang;

        public double ChietKhauMatHang
        {
            get { return _ChietKhauMatHang; }
            set { _ChietKhauMatHang = value; }
        }
        double _ThanhTien;

        public double ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
        public ChiTietHoaDonNH()
        {
        }
    }
}
