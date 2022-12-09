using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class LoaiSanPhamBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListLoaiSanPham()
        {
            string select;
            select = "select * from LoaiSanPham";
            return da.GetDataTable(select);

        }

        public LoaiSanPham GetLoaiSanPhamByID(string id)
        {
            string select;
            LoaiSanPham lsp = new LoaiSanPham();
            select = "select * from LoaiSanPham where MaLoaiSanPham='" + id + "'";
            if (da.GetDataTable(select).Rows.Count > 0)
            {
                lsp.MaLoaiSanPham = da.GetDataTable(select).Rows[0]["MaLoaiSanPham"].ToString();
                lsp.TenLoaiSanPham = da.GetDataTable(select).Rows[0]["TenLoaiSanPham"].ToString();
            }
            return lsp;
        }
        public void Insert(LoaiSanPham lsp)
        {
            string query;
            query = "Insert into LoaiSanPham values(N'" + lsp.MaLoaiSanPham +
                "',N'" + lsp.TenLoaiSanPham + "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(LoaiSanPham lsp)
        {
            string query;
            query = "Delete from LoaiSanPham where MaLoaiSanPham=N'" + lsp.MaLoaiSanPham + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(LoaiSanPham lsp)
        {
            string query;
            query = "Update LoaiSanPham set TenLoaiSanPham=N'" +
                lsp.TenLoaiSanPham + "' where MaLoaiSanPham=N'" + lsp.MaLoaiSanPham + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(LoaiSanPham lsp)
        {
            string select;
            select = "Select * from LoaiSanPham where MaLoaiSanPham like N'%" + lsp.MaLoaiSanPham +
                "%' and TenLoaiSanPham like N'%" + lsp.TenLoaiSanPham + "%'"; ;
            return da.GetDataTable(select);
        }
    }
}
