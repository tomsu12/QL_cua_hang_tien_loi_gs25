using System;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class NhanVienBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListNhanVien()
        {
            string select;
            select = "Select nv.MaNV, cv.TenCV, nv.TenNV, nv.DiaChi, nv.SDT," +
                " nv.SoCMND, nv.SoTaiKhoan, nv.NgaySinh, nv.GioiTinh, nv.TrangThai" +
                " from NhanVien nv, ChucVu cv " + "where nv.MaCV = cv.MaCV";
            return da.GetDataTable(select);
        }
        public DataTable GetListNhanVienBanHang()
        {
            string select;
            select = "Select nv.MaNV,nv.TenNV,nv.GioiTinh,nv.NgaySinh," +
                 "nv.DiaChi,nv.SDT, cv.TenCV from NhanVien nv, ChucVu cv " +
                 "where nv.MaCV = cv.MaCV and cv.MaCV in('06','07')";
            return da.GetDataTable(select);
        }
        public DataTable GetListNhanVienNhapHang()
        {
            string select;
            select = "Select nv.MaNV,nv.TenNV,nv.GioiTinh,nv.NgaySinh," +
                 "nv.DiaChi,nv.SDT, cv.TenCV from NhanVien nv, ChucVu cv " +
                 "where nv.MaCV = cv.MaCV and cv.MaCV in ('02','03')";
            return da.GetDataTable(select);
        }
        public DataTable GetNhanVienById(string id)
        {
            string select;
            select = "Select nv.MaNV,nv.TenNV,nv.GioiTinh,nv.NgaySinh," +
                "nv.DiaChi,nv.SDT from NhanVien nv, ChucVu cv where nv.MaCV = cv.MaCV"
                + " and MaNV='" + id + "'";
            return da.GetDataTable(select);
        }
        public string GetMaxNhanVienID()
        {
            string MaNV = "";
            string select = "select top 1 MaNV from NhanVien order by MaNV DESC ";
            if (da.GetDataTable(select).Rows.Count == 1)
            {
                return MaNV = da.GetDataTable(select).Rows[0]["MaNV"].ToString();
            }
            else
                return MaNV;
        }
        public void Insert(NhanVien nv)
        {
            string query;
            query = "Insert into NhanVien Values ('" + nv.MaNV + "','" +
                                                       nv.MaCV + "','" +
                                                       nv.TenNV + "',N'" +
                                                       nv.GioiTinh + "', convert(datetime,'" +
                                                       nv.NgaySinh + "',23),N'" +
                                                       nv.DiaChi + "','" +
                                                       nv.Img + "','" +
                                                       nv.SDT + "','" +
                                                       nv.SoCMND + "','" +
                                                       nv.SoTaiKhoan + "','" +
                                                       nv.TrangThai+ "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(NhanVien nv)
        {
            string query;
            query = "Delete from NhanVien where MaNV='" + nv.MaNV + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(NhanVien nv)
        {
            string query;
            query = "Update NhanVien set TenNV=N'" + nv.TenNV + "'," +
                                        "MaCV='" + nv.MaCV + "'," +
                                        "GioiTinh=N'" + nv.GioiTinh + "'," +
                                        "NgaySinh= convert(datetime,'" + nv.NgaySinh + "',23)," +
                                        "DiaChi=N'" + nv.DiaChi + "'," +
                                        "SDT='" + nv.SDT + "'" +
                                    " where MaNV='" + nv.MaNV + "'";

            da.ExecuteNonQuery(query);
        }
        public DataTable Search(NhanVien nv)
        {
            string condition = "";
            string select;
            if (nv.MaNV != "")
                condition = condition + "and nv.MaNV like N'%" + nv.MaNV + "%'";
            if (nv.GioiTinh != "")       
                condition = condition + "and nv.GioiTinh = N'" + nv.GioiTinh + "'";
            if (nv.TrangThai != "")
                condition = condition + "and nv.TrangThai = N'" + nv.TrangThai + "'";
            select = "Select nv.MaNV,nv.TenNV,nv.GioiTinh,nv.NgaySinh,nv.TrangThai, " +
                            "nv.DiaChi, nv.SDT,nv.SoCMND, nv.SoTaiKhoan, cv.TenCV from NhanVien nv, ChucVu cv " +
                            "Where nv.MaCV=cv.MaCV " + condition;
            return da.GetDataTable(select);
        }

        public DataTable SearchByDate(NhanVien nv)
        {
            string select;
            select = "Select nv.MaNV,nv.TenNV,nv.DiaChi, nv.SDT,nv.SoCMND,nv.SoTaiKhoan," +
                             "nv.NgaySinh, nv.GioiTinh,cv.TenCV,nv.TrangThai from NhanVien nv,ChucVu cv" +
                             " Where nv.MaCV=cv.MaCV" +
                                    " and nv.MaNV like N'%" + nv.MaNV + "%'" +
                                    " and nv.TenNV like N'%" + nv.TenNV + "%'" +
                                    " and nv.DiaChi like N'%" + nv.DiaChi + "%'" +
                                    " and nv.SDT like '%" + nv.SDT + "%'" +
                                    " and nv.SoCMND like '%" + nv.SoCMND + "%'" +
                                    " and nv.SoTaiKhoan like '%" + nv.SoTaiKhoan + "%'" +
                                    " and nv.NgaySinh like  convert(varchar,'" + nv.NgaySinh + "',23)" +
                                    " and nv.GioiTinh like N'%" + nv.GioiTinh + "%'" +
                                    " and nv.MaCV like '%" + nv.MaCV + "%'" +
                                    " and nv.TrangThai like N'%" + nv.TrangThai + "%'";
            return da.GetDataTable(select);
        }
    }
}
