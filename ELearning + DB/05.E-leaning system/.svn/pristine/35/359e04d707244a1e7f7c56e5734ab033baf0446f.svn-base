<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportLearningStatus.aspx.cs" Inherits="E_Learning.ReportLearningStatus" %>
<%--<@meta http-equiv="content-type" content="application/xhtml+xml; charset=UTF-8" />--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <h3 style="text-align: center"> Báo cáo tiến độ học</h3>
            </div>
         
        </div>

         <div class="row">
            <div class="col-md-4">
                 <div class="form-group">
               <b>  Course Name :</b>
                     
                    <asp:DropDownList ID="ddlCourse" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged ="ddlCourse_SelectedIndexChanged"
                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                    </asp:DropDownList>
                     </div>
                     </div>
         </div>
         <div class ="row" style ="height:20px"></div>
             <div class="col-md-8">
             </div>
               
        <div class="row">
            <div class="col-md-12">
                <table class="table fixed-table-container" id="dtDataLoad">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>ID Employee</th>
                            <th>Course Name</th>
                            <th>Status Learning</th>
                            <th>Test Score</th>
                            <th>Result Test(Pass/NG)</th>
                             <th>Processing course</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%int i =1;%>
                        <% foreach (System.Data.DataRow Report in dtReportCourse.Rows)
                            { %>
                         <%if (Report["ResultCourse"].ToString() == "Complete")
                             {%>
                         <tr style =" background-color:antiquewhite;color:blue">
                            <td><%= Report["No"].ToString() %></td>
                            <td><%= Report["UserName"].ToString() %></td>
                            <td><%= Report["NameCourse"].ToString() %></td>
                            <td><%= Report["ResultStudy"].ToString() %></td>
                            <td><%= Report["ScoreTest"].ToString() %></td>
                            <td><%= Report["ResultTest"].ToString() %></td>
                            <td><%= Report["ResultCourse"].ToString() %></td>
                        </tr>
                            <%}%>
                         <%else%>
                             <%{%>
                             <tr>
                                <td><%= Report["No"].ToString() %></td>
                                <td><%= Report["UserName"].ToString() %></td>
                                <td><%= Report["NameCourse"].ToString() %></td>
                                <td><%= Report["ResultStudy"].ToString() %></td>
                                <td><%= Report["ScoreTest"].ToString() %></td>
                                <td><%= Report["ResultTest"].ToString() %></td>
                                <td><%= Report["ResultCourse"].ToString() %></td>
                            </tr>
                              <%}%>    
                          <%}%>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-9">
               
                  <button type="button" id="bttPrintPDF" onserverclick ="bttPrintPDF_ServerClick"  runat="server"  class="btn btn-warning">
                    <i class="fas fa-download"></i>PRINT REPORT
                </button>
            </div>
            <div class="col-md-3">
            </div>
        </div>

    </div>

    <div class="modal" id="myModal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h3 class="modal-title">Update</h3>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>


                <div class="modal-body">
                    <asp:HiddenField ID="hdfCourse" runat="server" />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                Name Course: 
                                <asp:HiddenField ID ="hdfCommnet_ID"  runat ="server" />
                                <asp:Label ID="lblCourseName" Font-Italic ="true"  Font-Bold ="true" Font-Size ="Large"   runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                User'Commnet:
                                <asp:Label ID="lblCommnet" runat="server"></asp:Label>
                            </div>
                                
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                 <div class="form-group">
                                Date User'Commnet:
                                <asp:Label ID="lblDateComment" runat="server"></asp:Label>
                                </div>
                            </div>


                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="DateFrom">GA's Comment </label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtUserComment" TextMode="DateTime" CssClass="form-control"  runat="server"></asp:TextBox>
                                    <%-- end add Modal --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Skill Video">GA's Date Comment</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtDateGa_Comment" TextMode="Date" type="text" CssClass="form-control" placeholder="Enter To Date" runat="server"></asp:TextBox>
                                    <%-- The edit Modal --%>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <%--onServerClick ="bttSave_ServerClick"--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttUpdate"     class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>
        </div>
    </div>
 </div>
   
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
    <script>
        function openEditModal(ID, NameCourse, UserComment, DateComnet,GaComment, GADatecomnet) {
            $('#MainContent_hdfCommnet_ID').val(ID);
            $('#<%=lblCourseName.ClientID%>').html(NameCourse);
            $('#<%=lblCommnet.ClientID%>').html(UserComment);
            $('#<%=lblDateComment.ClientID%>').html(DateComnet);
            $('#MainContent_txtUserComment').val(GaComment);
            $('#MainContent_txtDateGa_Comment').val(GADatecomnet);
            
            $('#myModal').modal('show');
        }

        $(function () {
            $("#dtDataLoad").DataTable({
                "responsive": true,
                "autoWidth": false,
                "order": [[0, "asc"]],
                "pageLength": 10
            });
        });


       
        function ConfirmDeleting(CommentID) {
            bootbox.confirm("Do you want to delete Comment?", function (result) {
                if (result === true) {
                    debugger;

                    var data = { CommentID: CommentID }
                    $.ajax({
                        type: "POST",
                        url: "ControlComment.aspx/DeleteComment",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlComment.aspx' }, 2000);
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
