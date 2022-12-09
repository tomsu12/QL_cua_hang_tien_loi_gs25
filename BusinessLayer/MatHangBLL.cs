using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class MatHangBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListMatHang()
        {
            string select = "Select mh.MaHang,mh.TenHang,mh.DonViTinh,mh.GiaBan" +
                                    ",mh.VAT,mh.TonQuay,mh.TonKho" +
                                    ",mh.TonKhoToiThieu,mh.TonQuayToiThieu, nh.TenNhomHang" +
                                    ",hsx.TenHangSX from MatHang mh,NhomHang nh,HangSX hsx" +
                            " where mh.MaHangSX=hsx.MaHangSX and mh.MaNhomHang=nh.MaNhomHang";

            return da.GetDataTable(select);
        }
        public DataTable GetListNCCMatHang(string MaHang)
        {
            string select = "Select TenNCC,DiaChi,SDT,SoFax from NhaCC" +
                                " Where MaNCC in ( Select distinct MaNCC " +
                                                    " from ChiTietHoaDonNH, HoaDonNhapHang " +
                                                    " Where ChiTietHoaDonNH.SoHoaDon=HoaDonNhapHang.SoHoaDon" +
                                                           " and MaHang= '" + MaHang + "')";

            return da.GetDataTable(select);
        }
        public DataTable GetMatHangById(string id)
        {
            string select = "Select mh.MaHang,mh.TenHang,mh.DonViTinh,mh.GiaBan" +
                                   ",mh.VAT,mh.TonQuay,mh.TonKho" +
                                   ",mh.TonKhoToiThieu,mh.TonQuayToiThieu, nh.TenNhomHang" +
                                   ",hsx.TenHangSX from MatHang mh,NhomHang nh,HangSX hsx" +
                           " where mh.MaHangSX=hsx.MaHangSX and mh.MaNhomHang=nh.MaNhomHang" +
                           " and mh.MaHang='" + id + "'";

            return da.GetDataTable(select);
        }
        public DataTable GetLoHang(string MaHang)
        {
            string select = "select SoLo,ConLai from View_TonLoHang where MaHang='" + MaHang + "'" +
                                                        "Order by SoLo";
            return da.GetDataTable(select);
        }
        public DataTable GetSLLoHang(string MaHang, string SoLo)
        {
            string select = "select ConLai from View_TonLoHang where MaHang='" + MaHang + "'" +
                                                        "and SoLo='" + SoLo + "'";
            return da.GetDataTable(select);
        }

        public void Insert(MatHang mh)
        {
            string query = "Insert into MatHang Values(N'" + mh.MaHang + "'" +
                                                    ",N'" + mh.MaNhomHang + "'" +
                                                    ",N'" + mh.MaHangSX + "'" +
                                                    ",N'" + mh.TenHang + "'" +
                                                    ",N'" + mh.DonViTinh + "'" +
                                                    ",'" + mh.GiaBan + "'" +
                                                    ",'" + mh.VAT + "'" +
                                                    ",'" + mh.TonQuay + "'" +
                                                    ",'" + mh.TonKho + "'" +
                                                    ",'" + mh.TonQuayToiThieu + "'" +
                                                    ",'" + mh.TonKhoToiThieu + "')";
            da.ExecuteNonQuery(query);

        }
        public void Update(MatHang mh)
        {
            string query = "Update MatHang Set MaNhomHang=N'" + mh.MaNhomHang + "'" +
                                           ",MaHangSX=N'" + mh.MaHangSX + "'" +
                                           ",TenHang=N'" + mh.TenHang + "'" +
                                           ",DonViTinh=N'" + mh.DonViTinh + "'" +
                                           ",GiaBan='" + mh.GiaBan + "'" +
                                           ",TonQuayToiThieu='" + mh.TonQuayToiThieu + "'" +
                                           ",TonKhoToiThieu='" + mh.TonKhoToiThieu + "'" +
                                           ",VAT='" + mh.VAT + "'" +
                                         " Where MaHang='" + mh.MaHang + "'";
            da.ExecuteNonQuery(query);
        }
        public void Delete(MatHang mh)
        {
            string query = "Delete  from MatHang Where MaHang='" + mh.MaHang + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(MatHang mh)
        {
            string select = "Select mh.MaHang,mh.TenHang,mh.DonViTinh,mh.GiaBan" +
                                    ",mh.VAT,mh.TonQuay,mh.TonKho" +
                                    ",mh.TonKhoToiThieu,mh.TonQuayToiThieu, nh.TenNhomHang" +
                                    ",hsx.TenHangSX from MatHang mh,NhomHang nh,HangSX hsx" +
                            " where mh.MaHangSX=hsx.MaHangSX and mh.MaNhomHang=nh.MaNhomHang" +// and MaHang like '%" + mh.MaHang + "%'";                       
                                                           " and MaHang like N'%" + mh.MaHang + "%'" +
                                                           " and TenHang like N'%" + mh.TenHang + "%'" +
                                                           " and DonViTinh like N'%" + mh.DonViTinh + "%'" +
                                                           " and mh.MaNhomHang like '%" + mh.MaNhomHang + "%'" +
                                                           " and mh.MaHangSX like '%" + mh.MaHangSX + "%'";

            return da.GetDataTable(select);
        }
    }
}
