using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class NhaCungCapBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListNhaCC()
        {
            string select = "Select * from NhaCC";
            return da.GetDataTable(select);
        }
        public DataTable GetNhaccById(string id)
        {
            string select = "Select * from NhaCC where MaNCC='" + id + "'";
            return da.GetDataTable(select);
        }
        public string GetMaxNhaCCID()
        {
            string MaNV = "";
            string select = "select top 1 MaNCC from NhaCC order by MaNCC DESC ";
            if (da.GetDataTable(select).Rows.Count == 1)
            {
                return MaNV = da.GetDataTable(select).Rows[0]["MaNCC"].ToString();
            }
            else
                return MaNV;
        }
        public void Insert(NhaCungCap ncc)
        {
            string query = "Insert into NhaCC Values(N'" + ncc.MaNCC + "'" +
                                                    ",N'" + ncc.TenNCC + "'" +
                                                    ",N'" + ncc.DiaChi + "'" +
                                                    ",'" + ncc.SDT + "'" +
                                                    ",'" + ncc.SoFax + "'" +
                                                    ",'" + ncc.SoTaiKhoan + "'" +
                                                    ",'" + ncc.MaSoThue + "'" +
                                                    ",'" + ncc.No + "'" +
                                                    ",'" + ncc.Co + "')";
            da.ExecuteNonQuery(query);
        }
        public void Update(NhaCungCap ncc)
        {
            string query = "Update NhaCC Set TenNCC=N'" + ncc.TenNCC + "'" +
                                           ",DiaChi=N'" + ncc.DiaChi + "'" +
                                           ",SDT='" + ncc.SDT + "'" +
                                           ",SoFax='" + ncc.SoFax + "'" +
                                           ",SoTaiKhoan='" + ncc.SoTaiKhoan + "'" +
                                           ",MaSoThue='" + ncc.MaSoThue + "'" +
                                         " Where MaNCC='" + ncc.MaNCC + "'";

            da.ExecuteNonQuery(query);

        }

        public void Delete(NhaCungCap ncc)
        {
            string query = "Delete  from NhaCC Where MaNCC='" + ncc.MaNCC + "'";
            da.ExecuteNonQuery(query);

        }
        public DataTable Search(NhaCungCap ncc)
        {
            string select = "Select * from NhaCC Where MaNCC like N'%" + ncc.MaNCC + "%'" +
                                                        " and TenNCC like N'%" + ncc.TenNCC + "%'" +
                                                        " and DiaChi like N'%" + ncc.DiaChi + "%'" +
                                                        " and SDT like '%" + ncc.SDT + "%'" +
                                                        " and SoFax like '%" + ncc.SoFax + "%'" +
                                                        " and SoTaiKhoan like '%" + ncc.SoTaiKhoan + "%'" +
                                                        " and MaSoThue like '%" + ncc.MaSoThue + "%'";
            return da.GetDataTable(select);
        }
        public DataTable GetCongNoNCC(string MaNCC, string TuNgay, string DenNgay)
        {
            string select = "Select * from CongNoNCC where convert(datetime,Ngay,103) between convert(datetime,'" + TuNgay +
                            "',103) and convert(datetime,'" + DenNgay + "',103)" +
                            " and MaNCC='" + MaNCC + "'";
            return da.GetDataTable(select);
        }
        public DataTable GetCongNoNCC(string MaNCC)
        {
            string select = "Select * from CongNoNCC where MaNCC='" + MaNCC + "'";
            return da.GetDataTable(select);
        }
    }
}
