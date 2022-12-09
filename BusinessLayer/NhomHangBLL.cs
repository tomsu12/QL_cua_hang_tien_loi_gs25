using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.DataLayer;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class NhomHangBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListNhomHang()
        {
            string select;
            select = "Select NhomHang.MaNhomHang, NhomHang.TenNhomHang, LoaiSanPham.TenLoaiSanPham from NhomHang,LoaiSanPham where NhomHang.MaLoaiSanPham=LoaiSanPham.MaLoaiSanPham";
            return da.GetDataTable(select);
        }
        public DataTable GetNhomHangByID(string id)
        {
            string select;
            select = "Select NhomHang.MaNhomHang, NhomHang.TenNhomHang, LoaiSanPham.TenLoaiSanPham from NhomHang,LoaiSanPham" +
                " where NhomHang.MaLoaiSanPham=LoaiSanPham.MaLoaiSanPham and NhomHang.MaNhomHang='" + id + "'";
            return da.GetDataTable(select);
        }
        public DataTable GetListNhomHangByLoaiSanPham(string maNganh)
        {
            string select;
            select = "Select NhomHang.MaNhomHang, NhomHang.TenNhomHang, LoaiSanPham.TenLoaiSanPham from NhomHang,LoaiSanPham where NhomHang.MaLoaiSanPham=LoaiSanPham.MaLoaiSanPham and NhomHang.MaLoaiSanPham='" + maNganh + "'";
            return da.GetDataTable(select);
        }
        public void Insert(NhomHang nh)
        {
            string query;
            query = "Insert into NhomHang values(N'" + nh.MaNhomHang +
                "',N'" + nh.TenNhomHang + "',N'" + nh.MaLoaiSanPham + "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(NhomHang nh)
        {
            string query;
            query = "Delete from NhomHang where MaNhomHang=N'" + nh.MaNhomHang + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(NhomHang nh)
        {
            string query;
            query = "Update NhomHang set TenNhomHang=N'" +
                nh.TenNhomHang + "', MaLoaiSanPham=N'" + nh.MaLoaiSanPham + "' where MaNhomHang=N'" + nh.MaNhomHang + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(NhomHang nh)
        {
            string select;
            select = "Select NhomHang.MaNhomHang,NhomHang.TenNhomHang,LoaiSanPham.TenLoaiSanPham from NhomHang,LoaiSanPham " +
                "where NhomHang.MaLoaiSanPham=LoaiSanPham.MaLoaiSanPham" +
                " and MaNhomHang like N'%" + nh.MaNhomHang +
                "%' and TenNhomHang like N'%" + nh.TenNhomHang +
                "%' and NhomHang.MaLoaiSanPham like N'%" + nh.MaLoaiSanPham + "%'";
            return da.GetDataTable(select);
        }

    }
}
