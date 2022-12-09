using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class PhieuQuaTang
    {
        string _MaPhieuQuaTang;

        public string MaPhieuQuaTang
        {
            get { return _MaPhieuQuaTang; }
            set { _MaPhieuQuaTang = value; }
        }
        double _TriGiaPhieu;

        public double TriGiaPhieu
        {
            get { return _TriGiaPhieu; }
            set { _TriGiaPhieu = value; }
        }
        DateTime _HanSuDung;

        public DateTime HanSuDung
        {
            get { return _HanSuDung; }
            set { _HanSuDung = value; }
        }

        DateTime _NgayUpdate;

        public DateTime NgayUpdate
        {
            get { return _NgayUpdate; }
            set { _NgayUpdate = value; }
        }

        public PhieuQuaTang()
        {
            this.HanSuDung = DateTime.Now.Date;

        }
    }
}
