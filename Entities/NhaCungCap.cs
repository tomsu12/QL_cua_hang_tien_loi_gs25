using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class NhaCungCap
    {
        private string _MaNCC;
        public string MaNCC
        {
            get { return _MaNCC; }
            set { _MaNCC = value; }
        }
        private string _TenNCC;
        public string TenNCC
        {
            get { return _TenNCC; }
            set { _TenNCC = value; }
        }

        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        private string _SoFax;
        public string SoFax
        {
            get { return _SoFax; }
            set { _SoFax = value; }
        }
        private string _SoTaiKhoan;
        public string SoTaiKhoan
        {
            get { return _SoTaiKhoan; }
            set { _SoTaiKhoan = value; }
        }
        private string _MaSoThue;
        public string MaSoThue
        {
            get { return _MaSoThue; }
            set { _MaSoThue = value; }
        }
        private float _No;
        public float No
        {
            get { return _No; }
            set { _No = value; }
        }

        private float _Co;
        public float Co
        {
            get { return _Co; }
            set { _Co = value; }
        }
        public NhaCungCap()
        {
            this._No = 0;
            this._Co = 0;
         
        }


    }
}
