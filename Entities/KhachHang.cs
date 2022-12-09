using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class KhachHang
    {
        string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        string _TenKhach;

        public string TenKhach
        {
            get { return _TenKhach; }
            set { _TenKhach = value; }
        }
        string _GioiTinh;

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
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
        string _SoCMND;

        public string SoCMND
        {
            get { return _SoCMND; }
            set { _SoCMND = value; }
        }
        string _SoTaiKhoan;

        public string SoTaiKhoan
        {
            get { return _SoTaiKhoan; }
            set { _SoTaiKhoan = value; }
        }
        int _SoDiemThuong;

        public int SoDiemThuong
        {
            get { return _SoDiemThuong; }
            set { _SoDiemThuong = value; }
        }
        public KhachHang()
        {
            this._SoDiemThuong = 0;
        }
    }
}
