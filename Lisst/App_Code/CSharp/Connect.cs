using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{

    SqlConnection cnn;
    SqlCommand cmd;
    //get data with parameter
    public string ConstringAppConfig()
    {
        return @"Data Source=192.168.128.33;Initial Catalog=FP_PROC;User ID=sa;Password=Psnvdb2013;connect timeout=900";
    }
    public void OpenConnection()
    {

        cnn = new SqlConnection(ConstringAppConfig());
        if (cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
    }
    public void CloseConnection()
    {

        if (cnn.State == ConnectionState.Open)
        {
            cnn.Close();
            cnn.Dispose();
        }
    }
    public DataSet DataSetWithParameter(string storedname, string[] parameter, object[] objVal)
    {
        OpenConnection();
        cmd = new SqlCommand(storedname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
        for (int i = 0; i < parameter.Length; i++)
        {
            cmd.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
        }
        DataSet db = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        da.SelectCommand = cmd;
        da.Fill(db);
        CloseConnection(); return db;
    }
    //get data no parameter
    public DataSet GetDaTa(string storedname)
    {
        try
        {
            OpenConnection();
            cmd = new SqlCommand(storedname, cnn);
            DataSet db = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;
            da.Fill(db);
            CloseConnection(); return db;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int ExcuteStored(string storedname, string[] parameter, object[] objVal)
    {

        OpenConnection();
        cmd = new SqlCommand(storedname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < parameter.Length; i++)
        {
            cmd.Parameters.Add(new SqlParameter(parameter[i], objVal[i]));
        }
        int kq = cmd.ExecuteNonQuery();
        CloseConnection();
        return kq;
    }
    public int ExcuteStored_NoParam(string storedname)
    {

        OpenConnection();
        cmd = new SqlCommand(storedname, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int kq = cmd.ExecuteNonQuery();
        CloseConnection();
        return kq;
    }

}