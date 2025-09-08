using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;

namespace Trace_Projector
{
    class DataConn
    {
        public static int Check_Leader = 0;
        public static int day1;
        public static string month1;
        public static int year1;
        public static int month2;
        public static string E_Month;
        public static string source;
        private static SqlConnection con;
        public static int gio;
        // static String result;
        public static string path = "~/CELL_MG/Employee_Images/";
        public static string path2 = "~/Images/";
        public static string[] extensions = { ".gif", ".jpg", ".bmp", ".jpeg", ".png" };
        public static string ImagePath(string MaNV)
        {
            FileInfo file;
            for (int e = 0; e < extensions.Length; e++)
            {
                file = new FileInfo(path + MaNV + extensions[e]);
                if (file.Exists)
                {
                    return path + MaNV + extensions[e];
                }
            }
            return path + "Noimg.jpg";
        }
        public static DateTime chiaca()
        {
            string HT1;
            gio = DateTime.Now.Hour;
            if (gio == 0 || gio == 1 || DateTime.Now.Hour == 2 || gio == 3 || gio == 4 || gio == 5 || gio == 6)
            {
                HT1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            else
            {
                HT1 = DateTime.Now.ToString("yyyy-MM-dd");
            }
            return Convert.ToDateTime(HT1);
        }
        public static DateTime chiaca1()
        {
            DateTime HT1;
            gio = DateTime.Now.Hour;
            if (gio == 0 || gio == 1 || DateTime.Now.Hour == 2 || gio == 3 || gio == 4 || gio == 5 || gio == 6)
            {
                HT1 = DateTime.Now.AddDays(-1);
            }
            else
            {
                HT1 = DateTime.Now;
            }
            return HT1;
        }
        static DataConn()
        {
            //source = @"Data Source=MRHIEN-PC\SQLEXPRESS;Initial Catalog=PROJECTOR_TRACE;User ID=sa;Password=12345678@@";
            source = @"Data Source=192.168.128.1;Initial Catalog=PROJECTOR_TRACE;User ID=sa;Password=Psnvdb2013";
            con = new SqlConnection(source);
            try
            {
                con.Open();
            }
            catch
            {
            }
        }
        public static DataTable DataTable_Sql(string sql)
        {
            using (SqlConnection conn = new SqlConnection(source))
            {
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dap.Fill(ds);
                        conn.Close();
                        conn.Dispose();
                        return ds.Tables[0];
                    }
                }
            }
        }
        public static int Execute_NonSQL(string sql)
        {
            SqlTransaction sqltran = null;
            //try
            //{
            SqlConnection conn = new SqlConnection(source);

            int row = 0;
            conn.Open();
            sqltran = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(sql, conn, sqltran);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            row = cmd.ExecuteNonQuery();
            sqltran.Commit();
            conn.Dispose();
            conn.Close();
            return row;
            //}
            //catch (Exception ex)
            //{
            //    // throw new Exception(ex.Message);
            //    sqltran.Rollback();
            //    var _ex = new Exception(ex.Message + "Chỗ này sai rồi... : '" + sql + "'");
            //    throw _ex;
            //}
        }
        public static DataTable StoreFillDS(string query_object, CommandType type, params object[] obj)
        {
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query_object, conn);
            cmd.CommandType = type;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1; i <= obj.Length; i++)
            {
                cmd.Parameters[i].Value = obj[i - 1];
            }
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            conn.Dispose();
            conn.Close();
            return ds.Tables[0];
        }
        /*Nguyen Hien*/
        //Store Procedure tra ve datatable
        public static int ExecuteStore(string query_object, CommandType type, params object[] obj)
        {
            int row = 0;
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query_object, conn);
            cmd.CommandType = type;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1; i <= obj.Length; i++)
            {
                cmd.Parameters[i].Value = obj[i - 1];
            }
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
            return row;
        }
        //Store Procedure tra ve datatable
        public static DataTable FillStore(string storename, CommandType type, params object[] obj)
        {
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(storename, conn);
            cmd.CommandType = type;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 1; i <= obj.Length; i++)
            {
                cmd.Parameters[i].Value = obj[i - 1];
            }
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            //cmd.ExecuteNonQuery();
            dap.Fill(ds);
            conn.Dispose();
            conn.Close();
            return ds.Tables[0];
        }

        public static string returnQuater()
        {
            string q = "Q1";
            int h = DateTime.Now.Hour;
            if (h == 8 || h == 9 || h == 21 || h == 22)
            {
                q = "Q1";
            }
            if (h == 10 || h == 11 || h == 23 || h == 0)
            {
                q = "Q2";
            }
            if (h == 13 || h == 14 || h == 2 || h == 3)
            {
                q = "Q3";
            }
            if (h == 15 || h == 16 || h == 4 || h == 6)
            {
                q = "Q4";
            }
            return q;
        }
        //Ham lay ngay cuoi cung cua thang truyen vao
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        public static bool PingToAddress(string IP)
        {
            try
            {
                Ping PingSender = new Ping();
                int TimeOut = 120;
                string PingData = "aaaa";
                byte[] Buffer = System.Text.Encoding.ASCII.GetBytes(PingData);
                PingReply PingReply = PingSender.Send(IP, TimeOut, Buffer);

                if (PingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch { return false; }
        }
    }
}
