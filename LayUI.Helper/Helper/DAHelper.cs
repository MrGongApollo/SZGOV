using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LayUI.Utility.Helper
{
    /// <summary>
    /// 数据库公用数据访问方法 
    /// </summary>
    public class DAHelper
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["TeamWork"].ConnectionString.Trim();
        
        #region 获取服务器时间
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeNow()
        {
            string sql = "SELECT GETDATE()";
            object obj = ExecuteScalar(sql);
            if (obj != null && obj != DBNull.Value)
            {
                return DateTime.Parse(obj.ToString());
            }
            else
            {
                return DateTime.Now;
            }
        }
        #endregion

        #region 获取Guid码(默认从服务器获取)
        /// <summary>
        /// 获取Guid码(默认从服务器获取)
        /// </summary>
        /// <returns></returns>
        public string GetGuid()
        {
            string sql = "SELECT NEWID()";
            object obj = ExecuteScalar(sql);
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString().ToLower().Replace("-", "");
            }
            else
            {
                return Guid.NewGuid().ToString().ToLower().Replace("-", "");
            }
        }
        #endregion

        #region 执行sql语句并返回受影响行数
        /// <summary>
        /// 执行sql语句语句并返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        public int ExecuteNonQuery(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return -1;
            int m = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        m = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        m = -1;
                        //LogWrite(sql, ex.ToString());
                    }
                }
            }
            return m;
        }
        #endregion

        #region 执行sql语句并返回受影响行数
        /// <summary>
        /// 执行sql语句语句并返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        public int ExecuteNonQuery(string sql, params SqlParameter[] values)
        {
            if (string.IsNullOrEmpty(sql)) return -1;
            int m = 0;

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i].Value == null)
                            {
                                values[i].Value = System.DBNull.Value;
                                cmd.Parameters.Add(values[i]);
                                continue;
                            }

                            if (values[i].Value != null && values[i].SqlDbType == SqlDbType.DateTime && DateTime.Parse(values[i].Value.ToString()) == DateTime.Parse("1900-1-1"))
                            {
                                values[i].Value = System.DBNull.Value;
                                cmd.Parameters.Add(values[i]);
                                continue;
                            }
                            cmd.Parameters.Add(values[i]);
                        }
                        m = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        m = -1;
                        //LogWrite(sql, ex.ToString());
                    }
                }
            }
            return m;
        }
        #endregion

        #region 返回第一行、第一列的值
        /// <summary>
        /// 返回第一行、第一列的值
        /// </summary>
        /// <param name="str_sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return null;
            object obj = null;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        obj = cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        //LogWrite(sql, ex.ToString());
                    }
                }
            }
            return obj;
        }
        #endregion

        #region 返回第一行、第一列的值
        /// <summary>
        /// 返回第一行、第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params SqlParameter[] values)
        {
            if (string.IsNullOrEmpty(sql)) return null;
            object obj = null;

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i].Value == null)
                            {
                                values[i].Value = System.DBNull.Value;
                                cmd.Parameters.Add(values[i]);
                                continue;
                            }

                            if (values[i].Value != null && values[i].SqlDbType == SqlDbType.DateTime && DateTime.Parse(values[i].Value.ToString()) == DateTime.Parse("1900-1-1"))
                            {
                                values[i].Value = System.DBNull.Value;
                                cmd.Parameters.Add(values[i]);
                                continue;
                            }
                            cmd.Parameters.Add(values[i]);
                        }
                        obj = cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        //LogWrite(sql, ex.ToString());
                    }
                }
            }
            return obj;
        }
        #endregion

        #region 返回DataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="str_sql"></param>
        /// <returns></returns>
        public DataTable GetTable(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return new DataTable();

            DataTable TempDB = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            connection.Open();
                            DataSet ds = new DataSet();
                            da.Fill(ds, "ds");
                            TempDB = ds.Tables[0];
                        }
                        catch (SqlException ex)
                        {
                            //LogWrite(sql, ex.ToString());
                        }
                    }
                }
            }
            return TempDB;
        }
        #endregion

        #region 返回DataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetTable(string sql, params SqlParameter[] values)
        {
            if (string.IsNullOrEmpty(sql)) return new DataTable();

            DataTable TempDB = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            connection.Open();
                            DataSet ds = new DataSet();

                            for (int i = 0; i < values.Length; i++)
                            {
                                if (values[i].Value == null)
                                {
                                    values[i].Value = System.DBNull.Value;
                                    cmd.Parameters.Add(values[i]);
                                    continue;
                                }

                                if (values[i].Value != null && values[i].SqlDbType == SqlDbType.DateTime && DateTime.Parse(values[i].Value.ToString()) == DateTime.Parse("1900-1-1"))
                                {
                                    values[i].Value = System.DBNull.Value;
                                    cmd.Parameters.Add(values[i]);
                                    continue;
                                }
                                cmd.Parameters.Add(values[i]);
                            }

                            da.SelectCommand = cmd;
                            da.Fill(ds, "ds");
                            TempDB = ds.Tables[0];
                        }
                        catch (SqlException ex)
                        {
                            //LogWrite(sql, ex.ToString());
                        }
                    }
                }
            }
            return TempDB;
        }
        #endregion

    }
}
