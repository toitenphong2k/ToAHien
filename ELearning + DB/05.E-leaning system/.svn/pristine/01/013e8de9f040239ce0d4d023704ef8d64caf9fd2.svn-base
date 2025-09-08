<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlClass.aspx.cs" Inherits="E_Learning.ControlClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <h3 style="text-align: center">Management Class </h3>
            </div>
        
        </div>
        <div class="row">

            <div class="col-md-3">
                <asp:TreeView ID="Tree_Course" runat="server" OnSelectedNodeChanged="Tree_Course_SelectedNodeChanged">
                </asp:TreeView>
                <asp:HiddenField ID="hdfCourseID" runat="server" />
            </div>
            <div class="col-md-9">

                <table class="table fixed-table-container" id="dtDataLoad">
                    <thead>
                        <tr>

                            <th>CourseID</th>
                            <th>NameCourse</th>
                            <th>Name</th>
                            <th>From Date Traning</th>
                            <th>To Date Traning</th>
                            <th>Status</th>
                            <th>Funtion</th>

                        </tr>
                    </thead>


                    <tbody>
                        <%int i = 1; %>
                        <% foreach (System.Data.DataRow Course in dtListClass.Rows)
                            { %>
                         <%if (Course["Status_Class"].ToString() == "Finish")
                            {%>
                             <tr style =" background-color:antiquewhite;color:blue" >
                            <td><%=Course["CourseID"].ToString()%></td>
                            <td><%=Course["NameCourse"].ToString()%></td>
                            <td><%=Course["Class"].ToString()%></td>
                            <td><%=Course["FromTraing"].ToString()%></td>
                            <td><%=Course["ToTraining"].ToString()%></td>
                            <td><%=Course["Status_Class"].ToString()%></td>
                                 <td></td>
                           <%-- <td  <%if (Course["Status_Class"].ToString() == "Finish")>
                                <button type="button" id="<%=Course["ID"].ToString()%>"
                                    onclick="openEditModal('<%= Course["NameCourse"].ToString() %>','<%= Course["CourseID"].ToString() %>','<%= Course["Class"].ToString() %>',
                                    '<%= Course["FromTraing"].ToString()%>','<%= Course["ToTraining"].ToString()%>','<%= Course["Status_Class"].ToString()%>')"
                                    class="btn btn-primary">
                                    <i class="fa fa-edit"></i>Edit</button>
                                <a href="#" onclick="ConfirmDeleting('<%= Course["CourseID"].ToString() %>','<%=Course["Class"].ToString()%>')" class="btn btn-danger">Del</a>
                            </td>--%>
                        </tr>
                            <%} %>
                        <%else%>
                            <%{%>
                                 <tr>
                                <td><%=Course["CourseID"].ToString()%></td>
                                <td><%=Course["NameCourse"].ToString()%></td>
                                <td><%=Course["Class"].ToString()%></td>
                                <td><%=Course["FromTraing"].ToString()%></td>
                                <td><%=Course["ToTraining"].ToString()%></td>
                               <td><%=Course["Status_Class"].ToString()%></td>
                                <td>
                                    <button type="button" id="<%=Course["CourseID"].ToString()%>"
                                        onclick="openEditModal('<%=Course["NameCourse"].ToString() %>','<%= Course["CourseID"].ToString() %>','<%= Course["Class"].ToString() %>',
                                        '<%=Course["FromTraing"].ToString()%>','<%=Course["ToTraining"].ToString()%>','<%= Course["Status_Class"].ToString()%>')"
                                        class="btn btn-primary">
                                        <i class="fa fa-edit"></i>Edit</button>
                                    <a href="#" onclick="ConfirmDeleting('<%=Course["CourseID"].ToString() %>','<%=Course["Class"].ToString()%>')" class="btn btn-danger">Del</a>
                                </td>
                            </tr>

                             <%}%>
                        <%}%>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
                <button type="button" id="bttAdd" runat="server" class="btn btn-warning" onclick="Add()"><i class="fa fa-plus"></i>ADD</button>
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
                            <h4 class="modal-title">Edit</h4>
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
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Class">Name Class</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtClass" CssClass="form-control" placeholder="Enter Name Class" runat="server"></asp:TextBox>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Class">Status</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlStatus_Update" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>


                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="DateFrom">From Date</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtDateForm" TextMode="Date" CssClass="form-control" placeholder="Enter From Date" runat="server"></asp:TextBox>
                                    <%-- end add Modal --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Skill Video">To Date</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtToDate" TextMode="Date" type="text" CssClass="form-control" placeholder="Enter To Date" runat="server"></asp:TextBox>
                                    <%-- The edit Modal --%>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <%--onServerClick ="bttSave_ServerClick"--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttUpdate" runat="server" onserverclick="bttUpdate_ServerClick" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="myModal_ADD">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="modal-title">ADD</h4>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>


                <div class="modal-body">

                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Class">Name Course</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlNameCourse_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Class">Name Class</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtClass_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="DateFrom">From Date</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtFromDate_Add" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Skill Video">To Date</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtToDate_Add" TextMode="Date" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Class">Status Name</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <%--onServerClick ="bttSave_ServerClick"--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttSAVE" runat="server" onserverclick="bttSAVE_ServerClick" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>
        </div>
    </div>

    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
    <script>
        function openEditModal(NameCourse, CourseID, NameClass, ToDate, FromDate, Status) {
            $('#MainContent_hdfCourse').val(CourseID);
            $('#<%=lblCourseName.ClientID%>').html(NameCourse);
            $('#MainContent_txtClass').val(NameClass);
            $('#MainContent_txtDateForm').val(ToDate);
            $('#MainContent_txtToDate').val(FromDate);
            $('#MainContent_ddlStatus_Update').val(Status);
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


        function Add() {
            $('#myModal_ADD').modal('show');
        }

        function ConfirmDeleting(CourseID, Class) {
            bootbox.confirm("Do you want to delete class?", function (result) {
                if (result === true) {
                    //debugger;

                    var data = { CourseID: CourseID, Class: Class }
                    $.ajax({
                        type: "POST",
                        url: "ControlClass.aspx/Delete_CourseIDClass",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlClass.aspx' }, 2000);
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
