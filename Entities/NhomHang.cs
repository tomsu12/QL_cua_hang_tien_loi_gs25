using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class NhomHang
    {
        string _MaNhomHang;

        public string MaNhomHang
        {
            get { return _MaNhomHang; }
            set { _MaNhomHang = value; }
        }
        string _TenNhomHang;

        public string TenNhomHang
        {
            get { return _TenNhomHang; }
            set { _TenNhomHang = value; }
        }
        string _MaLoaiSanPham;

        public string MaLoaiSanPham
        {
            get { return _MaLoaiSanPham; }
            set { _MaLoaiSanPham = value; }
        }
        public NhomHang()
        {
        }
        public NhomHang(string maNhomH, string tenNhomH, string maNganhH)
        {
            this._MaLoaiSanPham = maNganhH;
            this._MaNhomHang = maNhomH;
            this._TenNhomHang = tenNhomH;
        }
    }
}
