using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace QL_cua_hang_tien_loi.DataLayer
{
    class DataAccess
    {
        public static string strConnection = @"Data Source=MINHANH\MSSQLSERVER01;Initial Catalog=QuanLyCuaHangGS25;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        public DataAccess()
        {
            cnn = new SqlConnection(strConnection);
        }
        //Mo ket noi toi CSDL
        public void Open()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
        }
        public void Close()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
        }
        public DataTable GetDataTable(string select)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(select, cnn);
                da.Fill(dt);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dt;

        }

        public bool CheckKey(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }
        public void ExecuteNonQuery(string query)
        {
            try
            {
                Open();
                cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }   
    }
}
