using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class MatHang
    {
        string _MaHang;

        public string MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        string _MaNhomHang;

        public string MaNhomHang
        {
            get { return _MaNhomHang; }
            set { _MaNhomHang = value; }
        }
        string _MaHangSX;

        public string MaHangSX
        {
            get { return _MaHangSX; }
            set { _MaHangSX = value; }
        }
        string _TenHang;

        public string TenHang
        {
            get { return _TenHang; }
            set { _TenHang = value; }
        }
        string _DonViTinh;

        public string DonViTinh
        {
            get { return _DonViTinh; }
            set { _DonViTinh = value; }
        }
        int _GiaBan;

        public int GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }
        int _VAT;

        public int VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        int _TonQuay;

        public int TonQuay
        {
            get { return _TonQuay; }
            set { _TonQuay = value; }
        }
        int _TonKho;

        public int TonKho
        {
            get { return _TonKho; }
            set { _TonKho = value; }
        }
        int _TonQuayToiThieu;

        public int TonQuayToiThieu
        {
            get { return _TonQuayToiThieu; }
            set { _TonQuayToiThieu = value; }
        }
        int _TonKhoToiThieu;

        public int TonKhoToiThieu
        {
            get { return _TonKhoToiThieu; }
            set { _TonKhoToiThieu = value; }
        }
        public MatHang()
        {

        }
    }
}
