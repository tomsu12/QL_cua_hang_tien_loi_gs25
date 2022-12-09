using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class CongNoNCC
    {
        DateTime _Ngay;

        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        string _SoChungTu;

        public string SoChungTu
        {
            get { return _SoChungTu; }
            set { _SoChungTu = value; }
        }
        string _MaNCC;

        public string MaNCC
        {
            get { return _MaNCC; }
            set { _MaNCC = value; }
        }
        int _DauKy;

        public int DauKy
        {
            get { return _DauKy; }
            set { _DauKy = value; }
        }
        int _PhatSinhTang;

        public int PhatSinhTang
        {
            get { return _PhatSinhTang; }
            set { _PhatSinhTang = value; }
        }
        int _PhatSinhGiam;

        public int PhatSinhGiam
        {
            get { return _PhatSinhGiam; }
            set { _PhatSinhGiam = value; }
        }
        int _CuoiKy;

        public int CuoiKy
        {
            get { return _CuoiKy; }
            set { _CuoiKy = value; }
        }
        string _DienGiai;

        public string DienGiai
        {
            get { return _DienGiai; }
            set { _DienGiai = value; }
        }
        public CongNoNCC()
        {
        }
    }
}
