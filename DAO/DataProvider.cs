﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_cua_hang_tien_loi.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;


        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        private string cStr = "Data Source=MINHANH\\MSSQLSERVER01;Initial Catalog=QuanLyCuaHangGS25;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(cStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listParemeter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParemeter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                con.Close();
            }

            return data;
        } // Return Rows And Result
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(cStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                con.Close();
            }
            return data;
        } // Return Number Of Row
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection con = new SqlConnection(cStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                con.Close();
            }
            return data;
        }
    }
}