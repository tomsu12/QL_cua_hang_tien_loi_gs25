using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class HangSX
    {
        string _MaHangSX;

        public string MaHangSX
        {
            get { return _MaHangSX; }
            set { _MaHangSX = value; }
        }
        string _TenHangSX;

        public string TenHangSX
        {
            get { return _TenHangSX; }
            set { _TenHangSX = value; }
        }
        public HangSX()
        {
        }
        public HangSX(string maHangSX, string tenHangSX)
        {
            this._MaHangSX = maHangSX;
            this._TenHangSX = tenHangSX;
        }
    }
}
