using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class NoiDungThuChi
    {
        string _LoaiThuChi;

        public string LoaiThuChi
        {
            get { return _LoaiThuChi; }
            set { _LoaiThuChi = value; }
        }
        string _TienThuChi;

        public string TienThuChi
        {
            get { return _TienThuChi; }
            set { _TienThuChi = value; }
        }
    }
}
