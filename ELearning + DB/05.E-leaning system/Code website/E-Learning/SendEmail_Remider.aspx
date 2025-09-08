<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendEmail_Remider.aspx.cs" Inherits="E_Learning.SendEmail_Remider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-12">
            <div class="row">
                <h3 style="text-align: center">Send  Remider Email User Not Join </h3>
            </div>

        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <b>Course Name :</b>

                    <asp:DropDownList ID="ddlCourse" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
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

                <table class="table fixed-table-container" id="dtDataLoad">
                    <thead>
                        <tr>
                            <td style="width: 5%">ID</td>
                            <td style="width: 15%">ID Employee</td>
                            <td style="width: 20%">FullName</td>
                            <td style="width: 20%">Course Name</td>
                            <td style="width: 15%">Status Learning</td>
                            <td style="width: 10%">Test Score</td>
                            <td style="width: 10%">Result Test</td>
                            <td style="width: 10%">Processing course</td>
                        </tr>
                    </thead>
                 <%--   <tbody>--%>
                        <asp:Repeater ID="rptData" runat="server">
                            <ItemTemplate>
                               <%-- <tbody>--%>
                                    <tr>

                                        <td><%#Eval("No") %></td>
                                        <td><%#Eval("UserName") %></td>
                                        <td><%#Eval("FullName") %></td>
                                        <td><%#Eval("NameCourse") %></td>
                                        <td><%#Eval("ResultStudy") %></td>
                                        <td><%#Eval("ScoreTest") %></td>
                                        <td><%#Eval("ResultTest") %></td>
                                        <td><%#Eval("ResultCourse") %></td>

                                    </tr>
                                <%--</tbody>--%>
                            </ItemTemplate>
                        </asp:Repeater>
                </table>


            </div>
        </div>
        <div class="row">
            <div class="col-md-9">

                <button type="button" id="bttDownload" onserverclick="bttDownload_ServerClick" runat="server" class="btn btn-warning">
                    <i class="fas fa-download"></i>DOWNLOAD
                </button>

                <button type="button" id="bttSendEmail" onserverclick="bttSendEmail_ServerClick" runat="server" class="btn btn-warning">
                    <i class="fa fa-send"></i>SENDEMAIL
                </button>
            </div>
            <div class="col-md-3">
            </div>
        </div>

    </div>



    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
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
