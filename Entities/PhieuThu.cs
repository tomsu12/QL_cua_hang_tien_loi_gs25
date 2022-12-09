using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.Entities
{
    class PhieuThu
    {

        string _SoPhieuThu;

        public string SoPhieuThu
        {
            get { return _SoPhieuThu; }
            set { _SoPhieuThu = value; }
        }
        string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        DateTime _Ngay;

        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        string _NguoiNop;

        public string NguoiNop
        {
            get { return _NguoiNop; }
            set { _NguoiNop = value; }
        }
        string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        string _SDT;

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        string _MaNV;

        public string MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }

        double _SoTienThu;

        public double SoTienThu
        {
            get { return _SoTienThu; }
            set { _SoTienThu = value; }
        }
        int _IdThuChi;

        public int IdThuChi
        {
            get { return _IdThuChi; }
            set { _IdThuChi = value; }
        }

        string _VietBangChu;

        public string VietBangChu
        {
            get { return _VietBangChu; }
            set { _VietBangChu = value; }
        }

        string _ChungTuLienQuan;

        public string ChungTuLienQuan
        {
            get { return _ChungTuLienQuan; }
            set { _ChungTuLienQuan = value; }
        }
        public PhieuThu()
        {
        }
    }
}
