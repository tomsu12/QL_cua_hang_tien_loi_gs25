using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QL_cua_hang_tien_loi.BusinessLayer;
using QL_cua_hang_tien_loi.Entities;
using System.Data;
using QL_cua_hang_tien_loi.DataLayer;

namespace QL_cua_hang_tien_loi.BusinessLayer
{
    class PhieuQuaTangBLL
    {
        DataAccess da = new DataAccess();
        public DataTable GetListPhieuQuaTang()
        {
            string select;
            select = "select * from PhieuQuaTang";
            return da.GetDataTable(select);

        }
        public DataTable GetTriGiaPhieuQuaTang(string MaPhieuQuaTang, DateTime date)
        {
            string select;
            select = "select * from PhieuQuaTang where MaPhieuQuaTang='" + MaPhieuQuaTang + "'" +
                            " and convert(nchar(10),HanSuDung,103)>= convert(nchar(10),'" + date + "',103) and TrangThai='false'";
            return da.GetDataTable(select);

        }
        public void Insert(PhieuQuaTang pqt)
        {
            string query;
            query = "Insert into PhieuQuaTang values('" + pqt.MaPhieuQuaTang + "'" +
                                                    ",'" + pqt.TriGiaPhieu + "'" +
                                                    ",convert(datetime,'" + pqt.HanSuDung + "',103)" +
                                                     ", 'false' " +
                                                      ",null)";
            da.ExecuteNonQuery(query);
        }
        public void Delete(string MaPhieuQuaTang)
        {
            string query;
            query = "Delete from PhieuQuaTang where MaPhieuQuaTang='" + MaPhieuQuaTang + "'";
            da.ExecuteNonQuery(query);
        }
        public void UpdateState(string MaPhieuQuaTang, DateTime NgayUpdate)
        {
            string query;
            query = "Update PhieuQuaTang set TrangThai='true', NgayUpdate= convert(datetime,'" + NgayUpdate + "',103)" +
                        " where MaPhieuQuaTang='" + MaPhieuQuaTang + "'";
            da.ExecuteNonQuery(query);
        }
    }
}
