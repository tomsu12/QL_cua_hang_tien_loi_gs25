using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class UserBLL
    {
        DataAccess da = new DataAccess();
        public void Insert(User us)
        {
            string query = "Insert into tblUser values(N'" + us.TenDangNhap + "',N'" + us.MatKhau + "','" + us.MaNV + "',N'" + us.Role + "')";
            da.ExecuteNonQuery(query);
        }
        public DataTable GetListUser()
        {
            string select = "Select * from tblUser";
            return da.GetDataTable(select);
        }
        public bool ExistUser(User us)
        {
            string sql = "Select * from tblUser where TenDangNhap=N'" + us.TenDangNhap + "' and MatKhau=N'" + us.MatKhau + "'";
            if (da.GetDataTable(sql).Rows.Count > 0)
            {
                UserLogin.TenDangNhap = da.GetDataTable(sql).Rows[0]["TenDangNhap"].ToString();
                UserLogin.MatKhau = da.GetDataTable(sql).Rows[0]["MatKhau"].ToString();
                UserLogin.MaNV = da.GetDataTable(sql).Rows[0]["MaNV"].ToString();
                UserLogin.Role = Convert.ToInt32(da.GetDataTable(sql).Rows[0]["Role"].ToString());
                SqlHelper.Role = Convert.ToInt32(UserLogin.Role);
                return true;
            }
            else
                return false;
        }
        public bool ExistUser(string TenDangNhap)
        {
            string sql = "Select * from tblUser where TenDangNhap=N'" + TenDangNhap + "'";
            if (da.GetDataTable(sql).Rows.Count != 0)
            {
                return true;
            }
            else
                return false;
        }
        public void ChangePassword(string NewPassword)
        {
            string query = "Update tblUser set MatKhau=N'" + NewPassword + "' where TenDangNhap=N'" + UserLogin.TenDangNhap + "'";
            UserLogin.MatKhau = NewPassword;
            da.ExecuteNonQuery(query);
        }
        public void Update(User us)
        {
            string query = "Update tblUser set MatKhau=N'" + us.MatKhau + "', MaNV='" + us.MaNV + "', Role =N'" + us.Role + "' where TenDangNhap=N'" + us.TenDangNhap + "'";
            da.ExecuteNonQuery(query);
        }
        public void Delete(User us)
        {
            string query = "Delete  from tblUser Where TenDangNhap=N'" + us.TenDangNhap + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(User us)
        {
            string select = "Select * from tblUser Where TenDangNhap like N'%" + us.TenDangNhap + "%'" +
                                                        " and MatKhau like N'%" + us.MatKhau + "%'" +
                                                        " and MaNV like N'%" + us.MaNV + "%'" +
                                                        " and Role like N'%" + us.Role + "%'";

            return da.GetDataTable(select);
        }
    }
}
