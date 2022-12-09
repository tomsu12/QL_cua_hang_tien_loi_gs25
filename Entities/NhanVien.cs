using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class NhanVien
    {
        private string _MaNV;
        public string MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }

        private string _MaCV;
        public string MaCV
        {
            get { return _MaCV; }
            set { _MaCV = value; }
        }

        private string _TenNV;
        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }

        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Img;
        public string Img
        {
            get { return _Img; }
            set { _Img = value; }
        }

        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        private string _SoCMND;
        public string SoCMND
        {
            get { return _SoCMND; }
            set { _SoCMND = value; }
        }

        private string _SoTaiKhoan;
        public string SoTaiKhoan
        {
            get { return _SoTaiKhoan; }
            set { _SoTaiKhoan = value; }
        }

        private DateTime _NgaySinh;
        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }

        private string _GioiTinh;
        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }

        private string _TrangThai;
        public string TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }

        private string _Pass;
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
    }
}
