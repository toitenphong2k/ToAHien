<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlContencourse.aspx.cs" Inherits="E_Learning.ControlContencourse"  ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rich Text Editor</title>

    <script type="text/javascript" src="textedittor/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
           
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 59px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">


        <table align="center" style="height: 586px; width: 80%">
            <tr>
                <td align="center" colspan="2">                   
                    <h3>Input content Article</h3>
                    <p>&nbsp;</p>
                </td>
            </tr>
             <tr>
                <td class="auto-style1">Course Name : 
                </td>
                <td>                    
                        <asp:DropDownList ID="dr_filter_course" runat="server" AppendDataBoundItems="true" DataTextField="NameCourse" DataValueField="CourseID"
                            CssClass="custom-select custom-select-sm form-control form-control-sm">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Introduce : 
                </td>
                <td>
                    <asp:TextBox ID="txtintroduce" runat="server" Width="250px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" class="auto-style1">Content :
                </td>
                <td>
                    <asp:TextBox ID="txtcontent" runat="server" TextMode="MultiLine" Height="327px"
                        Width="528px"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Tags :
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="267px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="Submit" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <%--<asp:Button ID="Button1" runat="server" Text="Post" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;--%>
               <asp:Button ID="Button2" runat="server" Text="Clear" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
