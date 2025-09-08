<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateExam.aspx.cs" Inherits="E_Learning.CreateExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="Content/dataTables.bootstrap4.min.css" rel="stylesheet" />--%>
    <link href="assets/css/toastr.css" rel="stylesheet" />
    <link href="assets/css/toastr.min.css" rel="stylesheet" />
    <style>
        .form-group label {
            color: black !important;
        }

        .checkbox label {
            color: forestgreen !important;
        }

        .viewdata {
            
            color: red;
        }
    </style>
    <asp:ScriptManager runat="server" ID="sc"></asp:ScriptManager>
   <%-- <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate--%>>
            <div class="container">

                <div class="row">

                    <div class="col-lg-6">
                        <div class="row">
                            <h3 style="text-align: center; color: forestgreen">Bài Thi</h3>
                        </div>
                        <div class="form-group">
                            <label for="Class">Khóa học</label>
                            <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                            <asp:DropDownList runat="server" ID="ddlCourse"
                                AppendDataBoundItems="true"
                                CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label for="Class">Thời gian thi</label>
                            <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtTime" type="number" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">minutes</div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="Class">Tổng điểm  </label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtPoint" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <label for="Class">Điểm đỗ</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtPointPass" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-10">
                                    <asp:Button runat="server" ID="btnAddE" ClientIDMode="Static" OnClick="btnSaveE_Click" class="btn btn-success" Text="Thêm Bài Thi" />
                                    <asp:Button runat="server" ID="bttLuu" ClientIDMode="Static" OnClick="bttLuu_Click" class="btn btn-success" Text="Lưu Bài Thi" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6" runat="server" id="questionanswer" visible="true">
                        <div class="row">
                            <h3 style="text-align: center; color: forestgreen">Câu hỏi và Câu trả lời</h3>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="Class">Master-BàiKT</label>
                                      <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList runat="server" ID="ddlMasterExamID" OnSelectedIndexChanged ="ddlMasterExamID_SelectedIndexChanged"  AutoPostBack ="true"  CssClass="form-control select2" data-parsley-required="true" data-parsley-allselected="true" >
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="Class">Thứ tự câu</label>
                                    <asp:TextBox ID="txtSort" CssClass="form-control" type="number" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="Class">Nội dung câu hỏi</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtQuestion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="Class">Điểm mỗi câu</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtPointQuestion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>


                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="Class">Danh sách câu hỏi</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList runat="server" ID="ddlQuestion" CssClass="form-control select2" data-parsley-required="true" data-parsley-allselected="true" data-parsley-required-message="Haven't selected a Question">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="Class">Nội dung câu trả lời</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtAnswer" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="Class">Cài đặt đáp án đúng</label>
                                    <div class="checkbox checkbox-success mt-4">
                                        <asp:CheckBox runat="server" ID="ckcorrect" ClientIDMode="Static" Text="Answer Correct" />
                                    </div>
                                </div>


                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="form-group" runat="server">
                                        <asp:Button runat="server" ID="btnSave_Q" ClientIDMode="Static" OnClick="btnSaveQ_Click" class="btn btn-success" Text="Thêm Mới" />

                                        <asp:Button runat="server" ID="bttLuu_Q" ClientIDMode="Static" OnClick="bttLuu_Q_Click" class="btn btn-success" Text="Lưu" />
                                    </div>
                                </div>
                                <asp:HiddenField ID  ="hdfExamID_View" runat="server" />
                                <asp:HiddenField ID  ="hdfQuestion_View" runat="server" />
                                <asp:HiddenField ID  ="hdfAnser_View" runat="server" />
                                 <asp:HiddenField ID  ="hdfQuestion_Ans_View" runat="server" />
                                <asp:HiddenField ID  ="hdfAnsID_Update_View" runat="server" />

                            </div>
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="form-group" runat="server">
                                        <asp:Button runat="server" ID="btnSave_A" ClientIDMode="Static" OnClick="btnSaveA_Click" class="btn btn-success" Text="Thêm Mới" />
                                        <asp:Button runat="server" ID="bttLuu_A" ClientIDMode="Static" OnClick="bttLuu_A_Click" class="btn btn-success" Text="Lưu" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <hr style="background-color: blue" />
                <div class="row">
                    <div class="col-lg-6">
                        <table class="table fixed-table-container" id="dtDataQuestion">
                            <thead>
                                <tr>
                                    <td>ExamID</td>
                                    <td>CourseName</td>
                                    <td>Time</td>
                                    <td>Tổng điểm</td>
                                    <td>Điểm Pass</td>
                                    <td>Chức năng</td>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="prt_Exam_Master" OnItemCommand="prt_Exam_Master_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lbnkLoad" runat="server" CommandName="cmd" Text='<%#Eval("ExamID")%>' CommandArgument='<%# Eval("ExamID") %>' ForeColor="Blue"> </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNameCourse" runat="server" Text='<%#Eval("NameCourse")%>'></asp:Label>
                                            <asp:HiddenField ID="hdfCourseID" runat="server" Value='<%#Eval("CourseID")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTime" runat="server" Text='<%#Eval("Time")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPointLadder" runat="server" Text='<%#Eval("PointLadder")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPointPass" runat="server" Text='<%#Eval("PointPass")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="bttUpdate" CssClass='btn btn-warning' CommandName="Update" CommandArgument='<%#Eval("ExamID") %>'>
                                         <i class="fa fa-edit"></i>Edit
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>

                    </div>
                    <div class="col-lg-6" style="height: 400px; overflow-y: auto">

                        <div runat="server" id="RolePermission" visible="true">
                            <div class="role">
                                <asp:Repeater runat="server" ID="rptQuestion" OnItemCommand="rptQuestion_ItemCommand" OnItemDataBound="rptQuestion_ItemDataBound">
                                    <ItemTemplate>
                                        <table class="table fixed-table-container" id="dtDataQuestionAsn">
                                            <thead>
                                            </thead>
                                            <tbody>
                                                <tr id="_itemrow">
                                                    <td class="col-lg-9">
                                                        <asp:Literal runat="server" ID="lblQuestionID" Text='<%#Eval("QuestionID")%>' Visible="false"></asp:Literal>
                                                        <asp:HiddenField ID="hdfQuestionID_Update" runat="server" Value='<%#Eval("QuestionID")%>' />
                                                        <asp:HiddenField ID ="hdfExamID_Update" runat ="server" Value = '<%#Eval("ExamID")%>' />
                                                        
                                                        <abbr  style = "background-color:yellow;color:blue; font-style:inherit; ">
                                                            <asp:Label runat="server" ID="Label1"   Text='<%#Eval("Row")%>' ForeColor="Blue" />.
                                                        <asp:Label runat="server" ID="lblContent"  ForeColor="Blue" Text='<%#Eval("Name")%>' />(<asp:Label runat="server" ID="lblScore" Font-Size ="18px" ForeColor="Blue" Text='<%#Eval("Point")%>'></asp:Label>
                                                            đ)</abbr>

                                                    </td>
                                                    <td class="col-lg-3">
                                                        <abbr style = "background-color:chartreuse;color:blue; font-style:inherit; ">
                                                            <asp:LinkButton runat="server" ID="bttUpdate" ForeColor="Blue" Font-Underline="true" Text="Edit" CommandName="Update_Q" CommandArgument='<%#Eval("QuestionID") %>'>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="bttDelete" ForeColor="Blue" Font-Underline="true" Text="Delete" CommandName="Delete_Q" CommandArgument='<%#Eval("QuestionID") %>'>
                                                            </asp:LinkButton>
                                                        </abbr>
                                                    </td>
                                                </tr>

                                                <asp:Repeater runat="server" ID="rptPage" OnItemCommand ="rptPage_ItemCommand"  OnItemDataBound ="rptPage_ItemDataBound"  >
                                                    <ItemTemplate>
                                                        <tr>
                                                            <%--<td class='<%#(int.Parse(Eval("CheckCorrect").ToString()) == 0)?"":"viewdata"%>'>--%>
                                                            <td class="col-lg-9">
                                                                <asp:Label ID ="lblContenAns"  runat="server" CssClass='<%#(int.Parse(Eval("CheckCorrect").ToString()) == 0)?"":"viewdata"%>'  Text='<%# Eval("Name") %>' />
                                                                <asp:HiddenField ID  ="hdfCheckAns" runat ="server" Value ='<%#Eval("CheckCorrect")%>' />
                                                                <asp:HiddenField ID ="hdfQuestionID_AnsUpdate" runat ="server"   Value ='<%#Eval("QuestionID")%>' />
                                                                <asp:HiddenField ID ="hdfAnserID_Update" runat ="server"  Value ='<%#Eval("AnswerID")%>'  />
                                                               <%-- <asp:HiddenField ID ="hdfExamID_UpdateAns" runat ="server"  Value ='<%#Eval("ExamID")%>'  />--%>

                                                            </td>
                                                            <td class="col-lg-3">
                                                                <abbr>
                                                                    <asp:LinkButton runat="server" ID="bttUpdate" Text="Edit" CommandName="Update_Ans" CommandArgument='<%#Eval("AnswerID") %>'>
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="bttDelete" Text="Delete" CommandName="Delete_Ans" CommandArgument='<%#Eval("AnswerID") %>'>
                                                                    </asp:LinkButton>
                                                                </abbr>
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>

                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <br />
                        </div>

                    </div>
                </div>
                <asp:HiddenField ID="hdfExamID" runat="server" />
                <asp:HiddenField ID="hdfQuestionID" runat="server" />
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>

    <script src="ckeditor/ckeditor.js"></script>
    <script src="assets/js/toastr.js"></script>

    <script>


    
        $(function () {
            $("#dtDataQuestion").DataTable({
                "responsive": true,
                "autoWidth": false,
                "order": [[0, "asc"]],
                "pageLength": 10
            });
        });
        //$(function () {
        //    $("#dtDataQuestionAsn").DataTable({
        //        "responsive": true,
        //        "autoWidth": false,
        //        "order": [[0, "asc"]],
        //        "pageLength": 10
        //    });
        //});
    </script>
</asp:Content>
