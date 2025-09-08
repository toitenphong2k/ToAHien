<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportTrainerProgess.aspx.cs" Inherits="E_Learning.ReportTrainerProgess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <h3 style="text-align: center">Báo cáo tiến độ học </h3>
            </div>

        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <b>Course Name :</b>
                    <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged1"
                        AutoPostBack="true"
                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row" style="height: 20px"></div>
        <div class="col-md-8">
        </div>

        <div class="row">
            <div class="col-md-12">

                 <table   class="table fixed-table-container" id="dtDataLoad">
                   
                    <thead>
                        <tr>
                           <%-- <th>No</th>--%>
                            <th>Employee</th>
                            <th>Name</th>
                            <th>Section</th>
                            <th>Course Name</th>
                            <th>Class Name</th>
                            <th>Start Date</th>
                            <th>Finish Date</th>
                            <th>% Complete</th>
                            <th>Trainees Evaluation Score</th>
                            <th>Trainees Feedback</th>
                        </tr>
                    </thead>

                    <asp:Repeater ID="rptData" runat="server" OnItemCommand="rptData_ItemCommand">
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <%--<%--<td>
                                        <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("No") %>' /></td>--%>
                                    <td>
                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserName") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("FullName") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("DeptName") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("NameCourse") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Class")%>' /></td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("FromTraing") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("ToTraining") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Progess") %>' /></td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("ScoreTest") %>' /></td>
                                    <asp:HiddenField ID="hdfCourseID" Value='<%# Eval("CourseID") %>' runat="server" />

                                    <td>
                                        <a onclick='openEditModal(<%# Eval("CourseID") %>,<%# Eval("UserName") %>)' class="btn btn-primary">View Comment
                                        </a>

                                    </td>

                                </tr>
                            </tbody>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>


            </div>
        </div>
        <div class="row">
            <div class="col-md-9">

                <button type="button" id="bttPrintPDF" onserverclick="bttPrintPDF_ServerClick" runat="server" class="btn btn-warning">
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
                            <h4 class="modal-title">Edit</h4>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>

                <div class="modal-body">
                    <asp:HiddenField ID="hdfCourse" runat="server" />
                    <asp:HiddenField ID="hdfEmpID" runat="server" />
                    <div class="container-fluid">

                        <div class="row" id="comment">
                        </div>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>


    <script>
        function openEditModal(courseid, idmember) {
            /*debugger;*/
            $.ajax({
                url: "/Webservice/WebService1.asmx/GetComment",
                type: "GET",
                contentType: "application/json;charset=utf-8",
                /*  data: { EmpID: idmember, CourseID: courseid },*/
                /* data: '{"EmpID":"' + idmember + '","CourseID":"' + courseid +'"}',*/
                data: {
                    EmpID: "'" + idmember + "'",
                    CourseID: "'" + courseid + "'"
                },
                async: false,
                success: function (data) {
                    if (data.d != "") {
                       // console.log(data.d)
                        $("#comment").html(data.d);
                        $('#myModal').modal('show');
                    }
                },
                error: function (errormessage) {
                    //alert(errormessage.responseText);
                    // window.showToast("err", "Có lỗi xảy ra, vui lòng thử lại sau.!", 3000);
                }
            });

        }
        </script>
        <script>
     
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