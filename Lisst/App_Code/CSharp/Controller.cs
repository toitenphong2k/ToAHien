using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Controller
/// </summary>
public class Controller
{
    Connect connect = new Connect();

    //insert_tblMessages
    public int insert_tblMessages(string Messages, string ImageUrl)
    {
        string[] parameter = { "@Messages", "@ImageUrl" };
        object[] objV = { Messages, ImageUrl};
        int value1 = connect.ExcuteStored("insert_tblMessages", parameter, objV);
        return value1;
    }

    public DataSet getMessages(String Date)
    {
        try
        {
            string stored = "getMessages";
            string[] parameter = {"@Date"};
            object[] objV = { Date};
            DataSet objDS = connect.DataSetWithParameter(stored,parameter,objV);

            if (objDS.Tables[0].Rows.Count > 0)
            {
                return objDS;
            }
            else
            {
                return objDS;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}