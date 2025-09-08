<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlQuestionAnser.aspx.cs" Inherits="E_Learning.ControlQuestionAnser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row">
            <h3 style="text-align: center">Management Question & Anser </h3>
        </div>
        <div class="row">
            <div class="col-md-2">
                <div class="row">
                    <div class="form-group">
                        <label for="Status">Course Name</label>
                        <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                        <asp:DropDownList ID="ddlCourse" runat="server"
                            AutoPostBack="true"  OnSelectedIndexChanged ="ddlCourse_SelectedIndexChanged" 
                          
                            CssClass="custom-select custom-select-sm form-control form-control-sm" >
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-10">
                <div class="row">
                    <div style="height: 550px; overflow-y: scroll">
                        <div class="table-responsive">
                            <table class="table table-bordered ">
                                <thead>
                                    <tr>
                                        <th>CourseID</th>
                                        <th>NameCourse</th>
                                        <th>No-Question</th>
                                        <th>TextQuestion</th>
                                        <th>No-Anser</th>
                                        <th>TextAnser</th>
                                        <th>AnserCorrect</th>
                                        <th>Decription</th>
                                        <th>Funtion</th>

                                    </tr>
                                </thead>
                               

                                <tbody>
                                    <%int i = 1; %>
                                    <% foreach (System.Data.DataRow Course in dtQuestion.Rows)
                                        { %>
                                    <tr>

                                        <td><%= Course["CourseID"].ToString() %></td>
                                        <td><%= Course["NameCourse"].ToString() %></td>
                                        <td><%= Course["QuestionID"].ToString() %></td>
                                        <td><%= Course["Content"].ToString() %></td>
                                        <td><%= Course["AnserID"].ToString() %></td>
                                        <td><%= Course["TextAnser"].ToString() %></td>
                                        <td><%= Course["AnserCorrect"].ToString() %></td>
                                        <td><%= Course["Decription"].ToString() %></td>
                                      
                                        <td>
                                            <a href="#" onclick="ConfirmDeleting('<%= Course["CourseID"].ToString() %>','<%= Course["QuestionID"].ToString() %>','<%= Course["AnserID"].ToString() %>')" class="btn btn-danger">Del</a>
                                        </td>
                                    </tr>
                                    <% } %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr />
                    </div>
                <div class="row">
                      <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="ftp_Upload" BackColor="WhiteSmoke" />
                    <asp:Button ID="bttUpload" runat="server" Text="Upload" OnClick ="bttUpload_Click"  CssClass="btn btn-primary" />
                    <asp:Button ID="bttTempFile" runat="server" Text="Temp File Upload"  OnClick ="bttTempFile_Click"  CssClass="btn btn-primary" />
                    <asp:Button ID="bttDownload" runat="server" Text="Download" OnClick ="bttDownload_Click"  CssClass="btn btn-primary " />

                    <%--<button type="button" id="bttSeachs" runat="server" class="btn btn-primary" onclick="Search()">Search</button>--%>
                          </div>
                    <div class="col-md-2">
                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    
                    </div>

                </div>
        </div>
    </div>
     </div>
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
     <script src="assets/js/toastr.js"></script>
    <script>
        function ConfirmDeleting(CourseID, QuestionID, AnserID )
        {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) { 
                    //debugger;
                    //var courseID = '<%=Session["UserName"] %>';
                    var data = { CourseID: CourseID, QuestionID: QuestionID, AnserID: AnserID }
                    $.ajax({
                        type: "POST",
                        url: "ControlQuestionAnser.aspx/Delete_CourseIDQuestion",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlQuestionAnser.aspx' }, 2000);
                        },
                        failure: function (response) {
                            toastr.warning('Delete  failed');
                        }
                    });
                }
            });
        }
    </script>
    
</asp:Content>
