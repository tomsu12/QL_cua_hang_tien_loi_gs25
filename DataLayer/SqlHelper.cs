using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace QL_cua_hang_tien_loi.DataLayer
{
    class SqlHelper
    {
        public static int Role;
        public static string ConnectString = @"Data Source=MINHANH\MSSQLSERVER01;Initial Catalog=QuanLyCuaHangGS25;Integrated Security=True";
        public static SqlConnection cnn;
    }
}
