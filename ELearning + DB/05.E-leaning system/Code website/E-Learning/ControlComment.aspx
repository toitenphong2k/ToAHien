<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlComment.aspx.cs" Inherits="E_Learning.ControlComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <h3 style="text-align: center">Management Comment in Class </h3>
            </div>
         
        </div>
        <div class="row">

            <div class="col-md-2">
                <asp:TreeView ID="TreeCourse" runat="server" OnSelectedNodeChanged="Tree_Course_SelectedNodeChanged">
                </asp:TreeView>
                <asp:HiddenField ID="hdfCourseID" runat="server" />
            </div>
            <div class="col-md-10">

                <table class="table fixed-table-container" id="dtDataLoad">
                    <thead>
                        <tr>
                            <th>Employee</th>
                            <th>FullName</th>
                            <th>NameCourse</th>
                            <th>Trainner Comment</th>
                            <th>Date Commnet</th>
                            <th>GA Comment</th>
                            <th>Date GA Commnet</th>
                            <th>Funtion</th>
                        </tr>
                    </thead>


                    <tbody>
                        <%int i = 1; %>
                        <% foreach (System.Data.DataRow Comment in dtListComment.Rows)
                            { %>
                        <tr>
                            <td><%= Comment["Username"].ToString() %></td>
                            <td><%= Comment["FullName"].ToString() %></td>
                            <td><%= Comment["NameCourse"].ToString() %></td>
                            <td><%= Comment["Trainer_Comment"].ToString() %></td>
                            <td><%= Comment["DateComent"].ToString() %></td>
                            <td><%= Comment["GA_Comment"].ToString() %></td>
                            <td><%= Comment["GA_DateComent"].ToString() %></td>
                           
                            <td>
                                <button type="button" id="<%= Comment["ID"].ToString()%>"
                                    onclick="openEditModal('<%= Comment["ID"].ToString() %>','<%= Comment["NameCourse"].ToString() %>','<%= Comment["Trainer_Comment"].ToString() %>',
                                    '<%= Comment["DateComent"].ToString()%>','<%= Comment["GA_Comment"].ToString()%>','<%= Comment["GA_DateComent"].ToString()%>')"
                                    class="btn btn-primary">
                                 <i class="fa fa-edit"></i>Edit</button>
                                <a href="#" onclick="ConfirmDeleting('<%= Comment["ID"].ToString() %>')" class="btn btn-danger">Del</a>
                            </td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
                
                <button type="button" id="bttDownload" runat="server" onserverclick="bttDownload_ServerClick" class="btn btn-warning">
                    <i class="fas fa-download"></i>DOWNLOAD

                </button>

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
                    <button type="button" id="bttUpdate" onserverclick ="bttUpdate_ServerClick"  runat="server"     class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
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
