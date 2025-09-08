<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlClassEmployee.aspx.cs" Inherits="E_Learning.Register_Course_Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="assets/vendors/bootstrap-table.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <h3 style="text-align: center;color:blue">Management Students of The Class </h3>
        </div>

        <div class="row" style ="color:blue">
            <div class="col-md-1">
                CourseID: 
                <asp:Label ID="lblCourseID" runat="server"></asp:Label>
            </div>
            <div class="col-md-3">
                Course Name :
                    <asp:DropDownList ID="ddlCourse" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                    </asp:DropDownList>

            </div>
            <div class="col-md-3">
                Class:
                    <asp:DropDownList ID="ddlClass" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                    </asp:DropDownList>
            </div>
         
        </div>

        <br />
        <div class="row">
            <div class="col-md-12">
              
                <table class="table fixed-table-container" id="dtDataLoad">  
                    <thead>
                        <tr>
                            <th>Code</th>
                            <th>FullName</th>
                            <th>Email</th>
                            <th>Class</th>
                            <th>Couse</th>
                            <th>Dept</th>
                            <th>FromDate</th>
                            <th>ToDate</th>
                            <th>Re_Traing </th>
                            <th>Re_Test </th>
                            <th>Status </th>
                            <th>Funtion </th>
                        </tr>
                    </thead>

                    <tbody>
                        <%int i = 1; %>
                        <%foreach (System.Data.DataRow Course in dtRegistionE.Rows)
                            { %>
                          <%if (Course["ResultCourse"].ToString() == "Complete")
                              {%>
                        <tr style =" background-color:antiquewhite;color:blue">
                            <td><%= Course["UserName"].ToString() %></td>
                            <td><%= Course["FullName"].ToString() %></td>
                            <td><%= Course["EmailAddress"].ToString() %></td>
                            <td><%= Course["Class"].ToString() %></td>
                            <td><%= Course["NameCourse"].ToString() %></td>
                            <td><%= Course["DeptID"].ToString() %></td>
                            <td><%= Course["FromDate_Trainig"].ToString() %></td>
                            <td><%= Course["ToDate_Training"].ToString() %></td>
                            <td><%= Course["ResultStudy"].ToString() %></td>
                            <td><%= Course["ResultTest"].ToString() %></td>
                            <td><%= Course["ResultCourse"].ToString() %></td>
                              
                            
                            <td>
                                <%if (Course["ResultCourse"].ToString() != "Complete")
                                {%>
                                <button type="button" id="<%=Course["ID"].ToString() %>"
                                    onclick="openEditModal('<%= Course["ID"].ToString() %>','<%= Course["IDCourse"].ToString() %>','<%= Course["Class"].ToString() %>','<%= Course["UserName"].ToString() %>')"
                                    class="btn btn-primary">
                                      <i class="fa fa-edit"></i>Edit</button>
                                <a href="#" onclick="ConfirmDeleting('<%= Course["IDCourse"].ToString() %>','<%= Course["Class"].ToString() %>','<%= Course["UserName"].ToString() %>')" class="btn btn-danger">Del</a>
                            <%} %>
                                </td>
                        </tr>
                             <%} %>
                        <%else%>
                        <%{%>
                           <tr>
                            <td><%= Course["UserName"].ToString() %></td>
                            <td><%= Course["FullName"].ToString() %></td>
                            <td><%= Course["EmailAddress"].ToString() %></td>
                            <td><%= Course["Class"].ToString() %></td>
                            <td><%= Course["NameCourse"].ToString() %></td>
                            <td><%= Course["DeptID"].ToString() %></td>
                            <td><%= Course["FromDate_Trainig"].ToString() %></td>
                            <td><%= Course["ToDate_Training"].ToString() %></td>
                            <td><%= Course["ResultStudy"].ToString() %></td>
                            <td><%= Course["ResultTest"].ToString() %></td>
                            <td><%= Course["ResultCourse"].ToString() %></td>
                           
                            <td>
                                 <%if (Course["ResultCourse"].ToString() != "OK")
                                {%>
                                <button type="button" id="<%=Course["ID"].ToString() %>%>"
                                    onclick="openEditModal('<%= Course["ID"].ToString() %>','<%= Course["IDCourse"].ToString() %>','<%= Course["Class"].ToString() %>','<%= Course["UserName"].ToString() %>')"
                                    class="btn btn-primary">
                                      <i class="fa fa-edit"></i>Edit</button>
                                <a href="#" onclick="ConfirmDeleting('<%= Course["IDCourse"].ToString() %>','<%= Course["Class"].ToString() %>','<%= Course["UserName"].ToString() %>')" class="btn btn-danger">Del</a>
                            <%} %>
                                </td>
                        </tr> 

                        <%}%>
                           <%} %>
                    </tbody>
                </table>

                <%-- </div>--%>
                <%--  </div>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10">
                <asp:FileUpload runat="server" ID="ftp_Upload" BackColor="WhiteSmoke" />
                
                 <button type="button" id="bttUpload" runat="server" class="btn btn-warning" onserverclick ="bttUpload_Click">
                     <i class="fa fa-plus"></i>Upload</button>

                
                 <button type="button" id="bttDownloadTemp" runat="server" onserverclick="bttTempFile_Click" class="btn btn-warning">
                  <i class="fas fa-download"></i>DOWNLOAD TEMP UPLOAD</button>
                
                 <button type="button" id="bttLoad" runat="server" onserverclick="bttLoadData_Click" class="btn btn-warning">
                  <i class="fab fa-digital-ocean"></i>LOAD DATA</button>
         
                 <button type="button" id="bttDownload" runat="server" onserverclick="bttDownload_Click" class="btn btn-warning">
                  <i class="fas fa-download"></i>DOWNLOAD</button>


                

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
                    <asp:HiddenField ID="hdfID" runat="server" />
                    <%-- Modal footer --%>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="employee">Employee</label>
                                        <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                        <asp:TextBox ID="txtEmpID" type="text" CssClass="form-control" placeholder="Enter Employee" runat="server"></asp:TextBox>
                                        <%-- The edit Modal --%>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                        Course:  
                                    <asp:DropDownList ID="ddlCourse_Edit" runat="server" AutoPostBack ="true"
                                        AppendDataBoundItems="true"  OnSelectedIndexChanged ="ddlCourse_Edit_SelectedIndexChanged"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="Class">Class</label>
                                        <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                        <asp:DropDownList ID="ddlClass_Edit" runat="server"
                                            AppendDataBoundItems="true"
                                            CssClass="custom-select custom-select-sm form-control form-control-sm">
                                        </asp:DropDownList>
                                        <%-- end add Modal --%>
                                    </div>
                                </div>
                            </div>



                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                        <button type="button" id="bttSave" runat="server" onserverclick="bttSaveClick" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                        <%--onserverclick="bttAddClick"--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal" id="mySearch">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="Name Course">CourseID</label>
                                        <asp:TextBox ID="txtCourseID_Search" CssClass="form-control" placeholder="Enter CourseID" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="TimeVideo">Department</label>
                                        <asp:TextBox ID="txtDept_Seach" CssClass="form-control" placeholder="Enter Dept Traning" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="Name Course">Class</label>
                                        <asp:TextBox ID="txtClass_Search" CssClass="form-control" placeholder="Enter From Date" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="EmpID">Employee</label>
                                        <asp:TextBox ID="txtEmp_Search" CssClass="form-control" placeholder="Enter EmpoyeeID" runat="server"></asp:TextBox>
                                        <%-- end add Modal --%>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="bttSeach" runat="server" onserverclick="bttSeachClick" class="btn btn-primary"><i class="fas fa-download"></i>Search</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
    <script>
        function openEditModal(ID, CourseID, Class, User) {
            $('#MainContent_hdfID').val(ID);
            $('#MainContent_txtEmpID').val(User);
            $('#MainContent_ddlClass_Edit').val(Class);
            $('#myModal').modal('show');
        }

        function Search() {
            $('#mySearch').modal('show');
        }

        function ConfirmDeleting(CourseID, Class, User) {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) {

                    var data = { CourseID: CourseID, Class: Class, User: User }
                    $.ajax({
                        type: "POST",
                        url: "ControlClassEmployee.aspx/Delete_CourseID",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlClassEmployee.aspx' }, 2000);
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








