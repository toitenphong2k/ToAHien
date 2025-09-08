
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using Traceability_Hien3.App_Code;

/// <summary>
/// Summary description for Login
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Login : System.Web.Services.WebService
{

    public Login()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public string checklogin(string username, string password)
    {
        string result = string.Empty;
        DataTable dtResult = new DataTable();
        string strWhere = string.Empty;
        string strOrder = string.Empty;
        try
        {
            strWhere += "[userid] = '" + username.Trim().Replace("'", "").Replace("\"", "") + "'";
            dtResult = DataConn.DataTable_Sql("SELECT * FROM TBL_USER WHERE " + strWhere);
            if (dtResult.Rows.Count == 0)
            {
                result = "0";
                //Không tồn tại tài khoản hoặc chưa được kích hoạt
            }
            else
            {
                strWhere = "[userid] = '" + username.Trim().Replace("'", "").Replace("\"", "") + "' AND [pass] = '" + password + "'";
                // dtResult = BusinessRulesLocator.GetUserBO().GetAsDataTable(strWhere, strOrder);
                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["SessionUserID"] = dtResult.Rows[0]["userid"].ToString();
                        HttpContext.Current.Session["SessionUserName"] = username.Trim().Replace("'", "").Replace("\"", "");
                        HttpContext.Current.Session["SessionFullName"] = dtResult.Rows[0]["name"].ToString();
                        result = "1";
                        //Login ok
                    }
                }


            }

        }
        catch (Exception ex)
        {

        }
        return result;
    }

}
