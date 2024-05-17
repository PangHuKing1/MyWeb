﻿using System.Data.SqlClient;
namespace BackGroundManagement.Commons
{
    public class JdbcUtil
    {
        public static string MyConn = "Server=localhost;Database=Admin_System;User ID=sa;Password=LZSlzs0915;TrustServerCertificate=true";

        public static SqlConnection conn = new SqlConnection(MyConn);

        ///<summary>
        ///查询数据，查询结束后手动关闭数据库连接
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader select(string sql)
        {
            SqlDataReader reader = null;
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            reader = comm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return reader;
        }

        //添加、修改、删除
        public static int ExecuteUpdate(string sql)
        {
            int result = 0;
            conn.Open();
            SqlCommand comm = new SqlCommand(sql,conn);
            result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        //单条数据查询
        public static Object ExecteOnlyOneVaule(string sql)
        {
            Object obj = null;
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            obj = comm.ExecuteScalar();
            conn.Close();
            return obj;
        }
    }
}
