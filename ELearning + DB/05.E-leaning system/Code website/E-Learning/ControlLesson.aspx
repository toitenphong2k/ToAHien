<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlLesson.aspx.cs" Inherits="E_Learning.ControlLesson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="assets/css/toastr.css" rel="stylesheet" />
    <link href="assets/css/toastr.min.css" rel="stylesheet" />

    <div class="container">
        <div class="row">
            <h3 style="text-align: center">Management Detail Lesson of Course </h3>
        </div>

        <div class="row">
            
                <table class="table fixed-table-container" id ="dtDataLoad">
                    <thead>
                        <tr>
                            <th>CourseID</th>
                            <th>Course Name</th>
                            <th>LeasonID</th>
                            <th>Detail_Leason</th>
                            <th>LinkVideo</th>
                            <th>UserInsert</th>
                            <th>DateInsert</th>
                            <th>Funtion</th>
                        </tr>
                    </thead>
                    
                    <tbody>
                        <%int i = 1; %>
                        <asp:HiddenField ID="hdfCourseImage" runat="server" />
                        <% foreach (System.Data.DataRow Course in dtLesson.Rows)
                            { %>
                        <tr>

                            <td><%= Course["CourseID"].ToString() %></td>
                            <td><%= Course["NameCourse"].ToString() %></td>
                            <td><%= Course["LeasonID"].ToString() %></td>
                            <td><%= Course["Detail_Leason"].ToString() %></td>
                            <td><%= Course["LinkVideo"].ToString() %></td>
                            <td><%= Course["UserInsert"].ToString() %></td>
                            <td><%= Course["DateInsert"].ToString() %></td>

                            <td>
                                <button type="button" id="<%= Course["CourseID"].ToString()%>"
                                    onclick="openEditModal('<%= Course["CourseID"].ToString() %>','<%= Course["LeasonID"].ToString() %>','<%= Course["Detail_Leason"].ToString() %>','<%= Course["LinkVideo"].ToString() %>')"
                                    class="btn btn-primary">
                                    <%--<i class="fa fa-edit"></i>--%>Edit</button>
                                <a href="#" onclick="ConfirmDeleting('<%= Course["CourseID"].ToString() %>','<%= Course["LeasonID"].ToString() %>')" class="btn btn-danger"><%--<i class="far fa-trash-alt">--%></i>Del</a>

                            </td>


                            <%--id ="<%= Course["ID"].ToString()%>"--%>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
     
        </div>
        <hr />
        <div class="row">
            <div class="col-md-2">
                </div>
            <div class="col-md-10">
                <asp:FileUpload runat="server" ID="ftp_Upload" BackColor="WhiteSmoke" />
                <asp:Button ID="bttUpload" runat="server" Text="UploadFile" BackColor="#4d5fe3" CssClass="btn btn-primary" OnClick="bttUpload_Click" />
                <asp:Button ID="bttLoadData" runat="server" Text="Load Data" BackColor="#4d5fe3" CssClass="btn btn-primary" OnClick="bttLoadData_Click" />
                <asp:Button ID="bttTempFile" runat="server" Text="Temp File Upload" BackColor="#4d5fe3" CssClass="btn btn-primary" OnClick="bttTempFile_Click" />
                <asp:Button ID="bttDownload" runat="server" Text="Download" BackColor="#4d5fe3" CssClass="btn btn-primary " OnClick="bttDownload_Click" />
                <button type="button" id="bttSeachs" style="background-color: #4d5fe3" runat="server" class="btn btn-primary" onclick="Search()">Search</button>
                <%--onclick="Search()"--%>
            </div>

            <div class="col-md-2" style="float: initial; color: forestgreen; font-style: oblique" />
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-10">
                <asp:FileUpload runat="server" ID="fptUploadVideo" AllowMultiple="true" BackColor="WhiteSmoke" />
                <asp:Button ID="bttUploadVideo" runat="server" Text="Copy All Video To Server" OnClick="bttUploadVideo_Click" BackColor="#4d5fe3" CssClass="btn btn-primary" />
            </div>
        </div>

  
    <div class="modal" id="mySearch">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <%-- Modal footer --%>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Leasson">Name Leasson</label>
                                    <asp:TextBox ID="txtNameLessonSearch" CssClass="form-control" placeholder="Enter Name Leasson" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="LinkVideoSeach">Name Video</label>
                                    <asp:TextBox ID="txtNameVideoseach" CssClass="form-control" placeholder="Enter NameVideo" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="CourseID">CourseID</label>

                                    <asp:TextBox ID="txtCourseIDSearch" CssClass="form-control" placeholder="Enter Course ID" runat="server" ></asp:TextBox>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="LeasonName">LeassonID</label>
                                    <asp:TextBox ID="txtLeasonIDSeach" CssClass="form-control" placeholder="Enter LeassonID" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="bttSeach" runat="server" class="btn btn-primary" onserverclick ="bttSeachClick"  ><i class="fas fa-download"></i>Search</button>
            </div>
        </div>
    </div>
        </div>
    <div class="modal" id="myModal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="modal-title">Edit</h4>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>

                
                <div class="modal-body">
                    <asp:HiddenField ID="hdfCourse" runat="server" />
                    <asp:HiddenField ID="hdfLessonID" runat="server" />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Leasson">Name Leasson</label>
                                    <asp:TextBox ID="txtNameLeasonEdit" CssClass="form-control" placeholder="Enter Name Leasson" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="LinkVideo">Name Video</label>
                                    <asp:TextBox ID="txtLinkEdit" CssClass="form-control" placeholder="Enter NameVideo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="bttClose" onclick="window.close(); return false" class="btn btn-danger" data-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttSave" onserverclick="bttSave_ServerClick"  runat="server" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
    <script>
        function openEditModal(CourseID, LesonID, NameLeason, Linkvideo) {
            debugger;
            $('#MainContent_hdfCourse').val(CourseID);
            $('#MainContent_hdfLessonID').val(LesonID);
            $('#MainContent_txtNameLeasonEdit').val(NameLeason);
            $('#MainContent_txtLinkEdit').val(Linkvideo);
            $('#myModal').modal('show');
            
        }
        function Search()
        {
             $('#mySearch').modal('show');            
        }
        function ConfirmDeleting(CourseID, LessonID)
        {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) { 
                    
                    var data = { CourseID: CourseID, LessonID: LessonID}
                    $.ajax({
                        type: "POST",
                        url: "ControlLesson.aspx/Delete",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlLesson.aspx' }, 2000);
                        },
                        failure: function (response) {
                            toastr.warning('Delete  failed');
                        }
                    });
                }
            });
        }
        $(function () {
            $("#dtDataLoad").DataTable({
                "responsive": true,
                "autoWidth": false,
                "order": [[0, "asc"]],
                "pageLength": 10
            });
        });
    </script>
   

   



 






 

 






 

   



 






 

 






 

</asp:Content>
