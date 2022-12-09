using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class ChucVuBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListChucVu()
        {
            string select;
            select = "select cv.MaCV, cv.TenCV, bp.TenBoPhan from ChucVu cv, BoPhan bp" +
                " where cv.MaBoPhan = bp.MaBoPhan";
            return da.GetDataTable(select);

        }
        public DataTable GetChucVuById(string id)
        {
            string select;
            select = "Select cv.MaCV, cv.TenCV, bp.TenBoPhan from ChucVu cv, BoPhan bp" +
                " where cv.MaBoPhan=bp.MaBoPhan and cv.MaCV='" + id + "'";
            return da.GetDataTable(select);
        }
        public void Insert(ChucVu cv)
        {
            string query;
            query = "Insert into ChucVu values(N'" + cv.MaCV + "',N'" + cv.TenCV + "','" + cv.MaBoPhan + "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(ChucVu cv)
        {
            string query;
            query = "Delete from ChucVu where MaCV=N'" + cv.MaCV + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(ChucVu cv)
        {
            string query;
            query = "Update ChucVu set TenCV=N'" + cv.TenCV + "' where MaCV=N'" + cv.MaCV + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(ChucVu cv)
        {
            string condition = "";
            string select;
            if (cv.MaCV != "")
                condition = condition + "and cv.MaCV like N'%" + cv.MaCV + "%'";
            if (cv.TenCV != "")
                condition = condition + "and cv.TenCV like N'%" + cv.TenCV + "%'";
            select = "Select cv.MaCV, cv.TenCV, bp.TenBoPhan from ChucVu cv, BoPhan bp" +
                " where cv.MaBoPhan=bp.MaBoPhan " + condition;
            return da.GetDataTable(select);
        }
    }
}
