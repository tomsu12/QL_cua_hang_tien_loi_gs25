using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class KhachHangBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListKhachHang()
        {
            string select = "Select * from KhachHang";
            return da.GetDataTable(select);
        }
        public DataTable GetListKhachHangByID(string MaKH)
        {
            string select = "Select * from KhachHang where MaKhach='" + MaKH + "'";
            return da.GetDataTable(select);
        }
        public string GetMaxKhachHangID()
        {
            string MaKhach = "";
            string select = "select top 1 MaKhach from KhachHang order by MaKhach DESC ";
            if (da.GetDataTable(select).Rows.Count == 1)
            {
                return MaKhach = da.GetDataTable(select).Rows[0]["MaKhach"].ToString();
            }
            else
                return MaKhach;
        }
        public int GetDiemThuong(string MaKhach)
        {
            string select = "Select SoDiemThuong from KhachHang where MaKhach=" + MaKhach + "";
            if (da.GetDataTable(select).Rows.Count > 0)
            {
                return int.Parse(da.GetDataTable(select).Rows[0]["SoDiemThuong"].ToString());
            }
            else
                return 0;
        }
        public void Insert(KhachHang kh)
        {
            string query = "Insert into KhachHang Values(N'" + kh.MaKhach + "'" +
                                                    ",N'" + kh.TenKhach + "'" +
                                                    ",N'" + kh.GioiTinh + "'" +
                                                    ",N'" + kh.DiaChi + "'" +
                                                    ",'" + kh.SDT + "'" +
                                                    ",'" + kh.SoCMND + "'" +
                                                    ",'" + kh.SoTaiKhoan + "'" +
                                                    ",'" + kh.SoDiemThuong + "')";
            da.ExecuteNonQuery(query);
        }
        public void Update(KhachHang kh)
        {
            string query = "Update KhachHang Set TenKhach=N'" + kh.TenKhach + "'" +
                                           ",DiaChi=N'" + kh.DiaChi + "'" +
                                           ",SDT='" + kh.SDT + "'" +
                                           ",SoCMND='" + kh.SoCMND + "'" +
                                           ",SoTaiKhoan='" + kh.SoTaiKhoan + "'" +
                                         " Where MaKhach='" + kh.MaKhach + "'";

            da.ExecuteNonQuery(query);

        }

        public void UpdateDiemThuong(string MaKhach, string SoDiemThuong)
        {
            string query = "Update KhachHang Set SoDiemThuong='" + SoDiemThuong + "' where MaKhach=" + MaKhach + "";
            da.ExecuteNonQuery(query);
        }

        public void Delete(KhachHang kh)
        {
            string query = "Delete  from KhachHang Where MaKhach='" + kh.MaKhach + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(KhachHang kh)
        {
            string select = "Select * from KhachHang Where MaKhach like N'%" + kh.MaKhach + "%'" +
                                                        " and TenKhach like N'%" + kh.TenKhach + "%'" +
                                                        " and DiaChi like N'%" + kh.DiaChi + "%'" +
                                                        " and GioiTinh like N'%" + kh.GioiTinh + "%'" +
                                                        " and SDT like '%" + kh.SDT + "%'" +
                                                        " and SoCMND like '%" + kh.SoCMND + "%'" +
                                                        " and SoTaiKhoan like '%" + kh.SoTaiKhoan + "%'";

            return da.GetDataTable(select);
        }
    }
}
