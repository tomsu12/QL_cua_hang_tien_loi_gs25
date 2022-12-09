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
    class BoPhanBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListBoPhan()
        {
            string select;
            select = "select * from BoPhan";
            return da.GetDataTable(select);

        }
        public DataTable GetBoPhanById(string id)
        {
            string select;
            select = "Select bp.MaBoPhan, bp.TenBoPhan from BoPhan bp where bp.MaBoPhan='" + id + "'";
            return da.GetDataTable(select);
        }
        public void Insert(BoPhan bp)
        {
            string query;
            query = "Insert into BoPhan values(N'" + bp.MaBoPhan + "',N'" + bp.TenBoPhan + "')";
            da.ExecuteNonQuery(query);
        }
        public void Delete(BoPhan bp)
        {
            string query;
            query = "Delete from BoPhan where MaBoPhan=N'" + bp.MaBoPhan + "'";
            da.ExecuteNonQuery(query);
        }
        public void Update(BoPhan bp)
        {
            string query;
            query = "Update BoPhan set TenBoPhan=N'" + bp.TenBoPhan + "' where MaBoPhan=N'" + bp.MaBoPhan + "'";
            da.ExecuteNonQuery(query);
        }
        public DataTable Search(BoPhan bp, bool MaBoPhan, bool TenBoPhan)
        {
            string condition = "";
            string select;
            if (MaBoPhan == true)
                condition = condition + " MaBoPhan like N'%" + bp.MaBoPhan + "%' and";
            if (TenBoPhan == true)
                condition = condition + " TenBoPhan like N'%" + bp.TenBoPhan + "%' and";
            condition = condition.Remove(condition.Length - 3, 3);
            select = "Select * from BoPhan where " + condition;
            return da.GetDataTable(select);
        }
    }
}
