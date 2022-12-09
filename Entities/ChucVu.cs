using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class ChucVu
    {
        private string _MaCV;
        public string MaCV
        {
            get { return _MaCV; }
            set { _MaCV = value; }
        }

        private string _TenCV;
        public string TenCV
        {
            get { return _TenCV; }
            set { _TenCV = value; }
        }

        private string _MaBoPhan;
        public string MaBoPhan
        {
            get { return _MaBoPhan; }
            set { _MaBoPhan = value; }
        }

        public ChucVu()
        {
        }
        public ChucVu(string maCV, string tenCV, string maBoPhan)
        {
            this._MaCV = maCV;
            this._TenCV = tenCV;
            this._MaBoPhan = maBoPhan;
        }
    }
}
