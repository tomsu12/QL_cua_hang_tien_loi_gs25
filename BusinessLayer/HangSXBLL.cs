using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.DataLayer;
using System.Data;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class HangSXBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListHangSX()
        {
            string select;
            select = "select * from HangSX";
            return da.GetDataTable(select);

        }
        public void Insert(HangSX hsx)
        {
            string query;
            query = "Insert into HangSX values(N'" + hsx.MaHangSX +
                "',N'" + hsx.TenHangSX + "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(HangSX hsx)
        {
            string query;
            query = "Delete from HangSX where MaHangSX=N'" + hsx.MaHangSX + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(HangSX hsx)
        {
            string query;
            query = "Update HangSX set TenHangSX=N'" +
                hsx.TenHangSX + "' where MaHangSX=N'" + hsx.MaHangSX + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(HangSX hsx)
        {
            string select;
            select = "Select * from HangSX where MaHangSX like N'%" + hsx.MaHangSX +
                "%' and TenHangSX like N'%" + hsx.TenHangSX + "%'"; ;
            return da.GetDataTable(select);
        }
    }
}
