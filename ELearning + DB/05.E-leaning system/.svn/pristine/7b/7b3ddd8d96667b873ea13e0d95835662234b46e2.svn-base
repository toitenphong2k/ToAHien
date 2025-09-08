<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiniTest.aspx.cs" Inherits="E_Learning.MiniTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <script src="assets/js/sweetalert2.js"></script>
    <link href="assets/css/sweetalert2.css" rel="stylesheet" />--%>
    <script src="Scripts/sweetalert2.js"></script>
    <link href="Scripts/sweetalert2.css" rel="stylesheet" />

    <asp:HiddenField runat="server" ID="hdftime" Value="0" />
    <div class="container">
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-12">
                <h2 class="section-title__title">Mini Test -
                    <asp:Label ID="namecourseid" runat="server" Text="Label"></asp:Label>
                </h2>
            </div>
        </div>
        <div class="row">
            <a onclick="hideButton(this)" class="btn btn-warning">Bắt đầu bài thi</a>
        </div>
        <div class="row" id="contentexam" style="display: none;">
            <div class="row">
                <div class="col-md-6" style="color: black; font-size: 20px;">
                    Time: <span id="time"></span>minutes!
                </div>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-8" style="height: 700px; overflow-y: scroll">
                <div class="course-details__content">
                    <asp:Repeater runat="server" ID="rptQuestion" OnItemDataBound="rptQuestion_ItemDataBound">
                        <ItemTemplate>
                            <table>
                                <tr id="_itemrow">
                                    <td>
                                        <asp:Literal runat="server" ID="lblQuestionID" Text='<%#Eval("QuestionID")%>' Visible="false"></asp:Literal>
                                        <abbr>
                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("Row")%>' ForeColor="Blue" />.
                                        <asp:Label runat="server" ForeColor="Blue" Text='<%#Eval("Name")%>' />(<%#Eval("Point") %> đ)</abbr>
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rptPage">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" ID="lblAnserID" Text='<%#Eval("AnswerID")%>' Visible="false"></asp:Literal>
                                                <asp:CheckBox ID="ck_AnserID" value='<%#Eval("AnswerID") %>' runat="server" />
                                                <asp:Label runat="server" ForeColor="Black" Text='<%# Eval("Name")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Button ID="bttSubmit" CssClass="btn btn-primary third" runat="server" OnClick="bttSubmit_Click" OnClientClick="return successclick();" Text="Submit" />
                <asp:Button ID="btnSubmitFake" CssClass="btn btn-primary third" runat="server" OnClick="bttSubmit1_Click" Text="Submit" Style="display: none;" />

                <br />
                <asp:Label ID="thongbao" Text="" runat="server" />

                <div class="row row-cols-3">
                    <%foreach (System.Data.DataRow rows in dt_suggest.Rows)
                        {%>
                    <div class="col">
                        <%if (rows["Status"].ToString() == "OK")
                            {%>
                        <%--<input type="text"  name="questionaaa" value="<%=rows["QuestionID"].ToString() %>" style="width: 50px; background-color: blue;">--%>
                        <input type="text" name="questionaaa" value="<%=rows["QuestionID"].ToString() %>" style="width: 50px; background-color: blue;">
                        <% } %>
                        <%else
                            {%>
                        <%--<input type="text" name="questionaaa" value="<%=rows["QuestionID"].ToString() %>" style="width: 50px; background-color: red;">--%>
                        <input type="text" name="questionaaa" value="<%=rows["QuestionID"].ToString() %>" style="width: 50px; background-color: red;">
                        <% } %>
                    </div>
                    <% } %>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <%-- OnPreRender="dpQuestAnser_PreRender"--%>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
    <script>
        //window.oncontextmenu = function () {
        //    return false;
        //}
        //document.onkeydown = function (e) {
        //    if (window.event.keyCode == 123 || e.button == 2)
        //        return false;
        //}
        function successclick() {
            window.onbeforeunload = null;
            confirm('Are you sure you want to finish exam?');
        }
        function startTimer(duration, display) {
            var timer = duration, minutes, seconds;
            setInterval(function () {
                minutes = parseInt(timer / 60, 10);
                seconds = parseInt(timer % 60, 10);

                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;

                display.textContent = minutes + ":" + seconds;
                if (minutes < 1) {
                    document.getElementById("time").style.color = "red";
                }
                if (--timer < 0) {
                    success();
                    timer = duration;
                }
            }, 1000);
        }
        function success() {
            window.onbeforeunload = null;
            $('#<%= btnSubmitFake.ClientID %>').click();
            //alert(1);
        }
        function openM(content, type, courseid) {
            window.onbeforeunload = null;
            Swal.fire("Bạn đã hoàn thành bài thi", content, type).then(function () {
                window.location = "/Detail_Course_Learning.aspx?CourseID_=" + courseid;
            });
        }
    </script>

    <script>
        function hideButton(x) {
            x.style.display = 'none';
            $("#contentexam").removeAttr("style");
            var minutes = $("#" + '<%=hdftime.ClientID %>').val();
            //alert(minutes);
            var fiveMinutes = 60 * parseInt(minutes),
                display = document.querySelector('#time');
            startTimer(fiveMinutes, display);

        }
        window.onbeforeunload = function (e) {
            window.open(document.URL, "_blank");
            return 'Dialog text here.';
        };
    </script>
</asp:Content>




