using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class LoaiHoaDon
    {
        string _MaLoaiHoaDon;

        public string MaLoaiHoaDon
        {
            get { return _MaLoaiHoaDon; }
            set { _MaLoaiHoaDon = value; }
        }
        string _TenLoaiHoaDon;

        public string TenLoaiHoaDon
        {
            get { return _TenLoaiHoaDon; }
            set { _TenLoaiHoaDon = value; }
        }
        public LoaiHoaDon()
        {
        }
        public LoaiHoaDon(string MaLoaiCT, string TenLoaiCT)
        {
            this._MaLoaiHoaDon = MaLoaiCT;
            this._TenLoaiHoaDon = TenLoaiCT;
        }
       

    }
}
