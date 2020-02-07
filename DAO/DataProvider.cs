using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        static DataProvider instance;

        protected string path = "Data Source=THINH;Initial Catalog=SweetStoreDemo;Integrated Security=True";
        protected SqlConnection conn;
        protected SqlDataAdapter da;
        protected SqlCommand cmd;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }

                return instance;
            }
        }


        public DataTable ExecuteQuery(string query, object[] parameters = null)
        //parameter cuối trong danh sách có thể = null để chấp nhận null  
        {
            DataTable dt = new DataTable();
            using (conn = new SqlConnection(path))
            {
                cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] items = query.Split(' ');
                    int i = 0;
                    foreach (string item in items)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                da = new SqlDataAdapter(cmd);
                conn.Open();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                conn.Close();
            }
            return dt;
        }

        public int ExecuteNoneQuery(string query, object[] parameters = null)
        //return effected lines   
        {
            int lines = 0;
            using (conn = new SqlConnection(path))
            {
                cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] items = query.Split(' ');
                    int i = 0;
                    foreach (string item in items)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                da = new SqlDataAdapter(cmd);
                conn.Open();
                try
                {
                    lines = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                conn.Close();
            }
            return lines;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        //use for searching/ looking for a variable 
        {
            object data = null;

            using (conn = new SqlConnection(path))
            {
                cmd = new SqlCommand(query, conn);

                if (parameters != null)
                {
                    string[] items = query.Split(' ');
                    int i = 0;
                    foreach (string item in items)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                da = new SqlDataAdapter(cmd);
                conn.Open();
                try
                {
                    data = cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                conn.Close();
            }
            return data;
        }

    }
}
