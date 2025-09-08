using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using E_Learning.Connect;
using System.Data;
namespace E_Learning.Webservice
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public string GetComment(string EmpID, string CourseID)
        {
            string result = string.Empty;
            string content = string.Empty;
            DataTable dtCommnet;

            dtCommnet = DBConnect.FillStore("[S_Report_Traing_Trainner_Progress_Comment_Search]", CommandType.StoredProcedure, CourseID, EmpID);
            if (dtCommnet.Rows.Count > 0)
            {
                foreach (DataRow dt in dtCommnet.Rows)
                {
                    content += @"<tr>
                                    <td>" + dt["Username"].ToString() + @"</td>
                                    <td>" + dt["FullName"].ToString() + @"</td>
                                    <td>" + dt["NameCourse"].ToString() + @"</td>
                                    <td>" + dt["Trainer_Comment"].ToString() + @"</td>
                                    <td>" + dt["DateConment"].ToString() + @"</td>
                                    <td>" + dt["GA_Comment"].ToString() + @"</td>
                                    <td>" + dt["GA_DateComent"].ToString() + @"</td>
                                </tr>";
                }

            }

                        result += @"
                                    <table class='table fixed-table-container' id='dtDataComment'>
                                    <thead>
                                    <tr>
                                        <th>User Comment</th>
                                        <th>FullName</th>
                                        <th>Name Course</th>
                                        <th>Trainer_Comment</th>
                                        <th>DateConment</th>
                                        <th>GA_Comment</th>
                                        <th>GA_DateComent</th>

                                    </tr>
                                </thead>

                                <tbody>
                                   " + content + @"
                                </tbody>
                                </table>



                        ";

            return result;
        }
    }
}
