using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class LoaiSanPham
    {
        
            string _MaLoaiSanPham;

            public string MaLoaiSanPham
            {
                get { return _MaLoaiSanPham; }
                set { _MaLoaiSanPham = value; }
            }
            string _TenLoaiSanPham;

            public string TenLoaiSanPham
            {
                get { return _TenLoaiSanPham; }
                set { _TenLoaiSanPham = value; }
            }
            public LoaiSanPham()
            {
            }
            public LoaiSanPham(string maNganhHang, string tenNganhHang)
            {
                this._MaLoaiSanPham = maNganhHang;
                this._MaLoaiSanPham = tenNganhHang;
            }
        }
    }
