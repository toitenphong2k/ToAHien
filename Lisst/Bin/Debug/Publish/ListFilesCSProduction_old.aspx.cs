using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListFilesCSProduction : System.Web.UI.Page
{
    ControllerFA conTroll = new ControllerFA();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] != null)
            {
                telDate.SelectedDate = DateTime.Now;
                loadData();
            }
            else
            {
                Response.Redirect("Logi.aspx");
            }
        }
        loadData();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string FilePath = "";
        string FileName = "";
        if (FileUpload2.HasFile)
        {
            if (System.IO.Path.GetExtension(FileUpload2.FileName) == ".jpg" || System.IO.Path.GetExtension(FileUpload2.FileName) == ".png" || System.IO.Path.GetExtension(FileUpload2.FileName) == ".pdf")
            {
                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

                string Extension = Path.GetExtension(FileUpload2.PostedFile.FileName);

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                //string FilePath = Server.MapPath(FolderPath + FileName);
                FilePath = Server.MapPath("~/ImagesFA/" + DateTime.Now.ToString("yyyyMMddHHmm") + "_" + FileName);
                FileUpload2.SaveAs(FilePath);
            }
        }
        int kq = 0;
        if (FileName == "")
        {
             kq = conTroll.insert_tblMessages(txtContenr.Text.Trim(), "");
        }
        else
        {
             kq = conTroll.insert_tblMessages(txtContenr.Text.Trim(), DateTime.Now.ToString("yyyyMMddHHmm") + "_" + FileName);
        }
        if (kq > 0)
        {
            string script = "alert(\"Successfully\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }
        else
        {
            string script = "alert(\"Fail\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }
        txtContenr.Text = "";
        loadData();
        //images.ImageUrl = "~/Images/evadribbble.jpg";
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }

    public void loadData()
    {
        try
        {
            DataSet ds = conTroll.getMessages(((DateTime)telDate.DateInput.SelectedDate).ToString("yyyy-MM-dd"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridViewContent.DataSource = ds.Tables[0].DefaultView;
                GridViewContent.DataBind();
            }
            else 
            {
                GridViewContent.DataSource = null;
                GridViewContent.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkContent_Click(object sender, EventArgs e)
    {
        LinkButton lnkUrlImage = (LinkButton)sender;
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string url = lnkUrlImage.CommandArgument.ToString();
            if (url != "")
            {
                string[] list=url.Split('.');
                string fileType=list[list.Length-1].ToString();
                if (fileType == "pdf")
                {
                    Response.Redirect("~/ImagesFA/" + url);
                }
                else
                {
                    images.ImageUrl = "~/ImagesFA/" + url;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                }
            }
        }
    }
    protected void telDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        loadData();
    }
}