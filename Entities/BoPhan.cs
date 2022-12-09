using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class BoPhan
    {
        private string _MaBoPhan;
        public string MaBoPhan
        {
            get { return _MaBoPhan; }
            set { _MaBoPhan = value; }
        }

        private string _TenBoPhan;
        public string TenBoPhan
        {
            get { return _TenBoPhan; }
            set { _TenBoPhan = value; }
        }

        public BoPhan() { }

        public BoPhan(string maBoPhan, string tenBoPhan)
        {
            this._MaBoPhan = maBoPhan;
            this._TenBoPhan = tenBoPhan;
        }
    }
}
