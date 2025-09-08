<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail_Course_Learning.aspx.cs" Inherits="E_Learning.Detail_Course_Learning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hdfCourseID" runat="server" />
            <asp:HiddenField ID="hdfUserTraing" runat="server" />
            <asp:HiddenField ID="hdfLessonName" runat="server" />
            <!--Start Course Details Sidebar-->
            <div class="col-xl-3 col-lg-3">
                <div class="course-details__sidebar" >
                    <div class="course-details__sidebar-meta wow fadeInUp animated" data-wow-delay="0.3s" >
                        <ul class="course-details__sidebar-meta-list list-unstyled">
                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-bell"></i></a>
                                </div>
                                <div class="text">
                                    <p style="color: black">
                                        <b>Status Learning:</b>
                                        <asp:Label ID="lblStatusCourse" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </li>
                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-clock"></i></a>
                                </div>
                                <div class="text">
                                    <p style="color: black">
                                        <b>FromDate:</b>
                                        <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                    </p>
                                    <br />
                                    <p style="color: black">
                                        <b>ToDate:</b>
                                        <asp:Label ID="lblToDate" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </li>
                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-flag"></i></a>
                                </div>
                                <div class="text">
                                    <p style="color: black"><b>Skill Level:</b>     <span>
                                        <asp:Label ID="lbllevelTraing" Style="color: black" runat="server"></asp:Label></span></p>
                                </div>
                            </li>

                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-bell"></i></a>
                                </div>
                                <div class="text">
                                    <p style="color: black"><b>Language:</b>    <span>
                                        <asp:Label ID="lblLanguage" Style="color: black" runat="server"></asp:Label></span></p>
                                </div>

                            </li>
                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-folder-open"></i></a>
                                </div>
                                <a class="nav-link dropdown-toggle" style="color: black; font-size: 17px" data-bs-toggle="dropdown"><b>Lessons:</b>   </a>
                                <div class="dropdown-menu" id="Tr_ID" runat="server">
                                    <asp:Repeater ID="prtDetailLeasson" runat="server" OnItemDataBound="prtDetailLeasson_ItemDataBound">
                                        <%--Bind repter de su dung duoc link OnItemDataBound ="prtDetailLeasson_ItemDataBound" --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtSearchLeason" runat="server" OnClick="lbtSearchLeason_Click" class="dropdown-item" Text='<%# Eval("Detail_Lesson") %>'>  </asp:LinkButton>
                                            <asp:HiddenField ID="hdfStatusLesson" runat="server" Value='<%# Eval("Status_Lesson") %>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </li>




                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="fas fa-play"></i></a>
                                </div>

                                <div class="text">
                                    <p>
                                        <a>
                                            <%if (dtResultTraing.Rows[0]["ResultTest"].ToString().Trim() == "PASS")%>
                                            <%{%>
                                            <span>
                                                <asp:LinkButton ID="lbkTest" runat="server" BackColor="YellowGreen" Font-Bold="true" ToolTip="Bạn đã pass bài kiểm tra!" Enabled="false" ForeColor="black" Text="Test(Pass)"></asp:LinkButton>
                                            </span>
                                            <%--<span class="badge">Pass</span>--%>
                                            <%}%>
                                            <%else   %>
                                            <%{%>
                                            <span>
                                                <asp:LinkButton ID="lbkTest1" runat="server" OnClick="lbkTest_Click" Font-Bold="true" ForeColor="black" Text="Test" OnClientClick="openInNewTab()"></asp:LinkButton>
                                            </span>
                                            <%--<span class="badge">Pending</span>--%>
                                            <%}%>
                                        </a>

                                    </p>
                                </div>
                            </li>



                            <li style ="height:400px">

                                <div class="row  d-flex justify-content-center" >
                                   <div class="col-md-12">
                                        <div class="headings d-flex justify-content-between align-items-center mb-3">
                                            <h5>Comments(<asp:Label ID="lblTotalComment" runat="server"></asp:Label>
                                                )</h5>
                                        </div>
                                        <div style ="height:300px; overflow-y:auto">
                                        <div>
                                            <table>

                                                <asp:Repeater ID="rptComment" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="d-flex justify-content-between align-items-center">
                                                            <td class="user d-flex flex-row align-items-center" style="width: 12%">
                                                                <%--<img src ="Image/icons8-male-user-48.png"   class="user-img rounded-circle mr-2">--%>
                                                                <small>User: </small>
                                                                <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("ID") %>' />
                                                            </td>

                                                            <td style="float: left">
                                                                <small><%# Eval("Trainer_Comment") %></small>
                                                                ( <small style="font-style: italic"><%# Eval("TotalDay") %> - days)</small>
                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex justify-content-between align-items-center">
                                                            <td class="user d-flex flex-row align-items-center" style="width: 12%">
                                                                <small style="color: orangered">GA: </small>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                                            </td>
                                                            <td style="float: left; color: orangered" colspan="2">
                                                                <small style="color: orangered"><%# Eval("GA_Comment") %></small>
                                                                ( <small style="font-style: italic; color: orangered"><%# Eval("DateGA") %> - days)</small>
                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                  </div>
                                </div>

                            </li>
                        </ul>
                          <ul>
                              <li style  ="height:200px">
                                     <div class="form-group">
                                        <input class="form-control" id="txtComment" type="text" placeholder="Your comments" runat="server" />
                                        <br />
                                        <asp:LinkButton runat="server" ID="bttSendComment" OnClick="bttSendComment_Click" CssClass="btn btn-success">
                                    <i class="fa fa-edit"></i> Send Comment</asp:LinkButton>
                                    </div>
                              </li>
                          </ul>
                    </div>
            </div>
        </div>
        <!--End Course Details Sidebar-->
        <!--Start Course Details Content-->
        <div class="col-xl-9 col-lg-9">
            <div class="course-details__content">
                <!--Start Single Courses One-->
                <div class="courses-one__single style2 wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                    <video width="1000" height="500" poster="Video/Clickbegin.gif" controls="controls" onended="videoEnded()">

                        <%foreach (System.Data.DataRow rows in dtVideo.Rows)
                            {%>
                        <source src="<%=rows["LinkVideo"].ToString()%>"    type="video/mp4" id="id_Video">
                        <% } %>
                    </video>

                    <div class="courses-one__single-content">
                        <div class="courses-one__single-content-overlay-img">
                        </div>

                        <h6 class="courses-one__single-content-name">Author:<asp:Label ID="lblAuthor" runat="server"></asp:Label>
                            <span style="color: red">Recently Updated:<asp:Label ID="lblDateUpdate" runat="server"></asp:Label></span></h6>
                        <div class="headings d-flex justify-content-between align-items-center mb-3">
                            <h1 style="color: #0000ff">COURSE NAME :<asp:Label ID="lblNameCouse" ForeColor="#0000ff" runat="server"></asp:Label>
                            </h1>
                        </div>

                        <%--<div style ="height:200px; overflow-y:auto">--%>
                            <div class="headings d-flex justify-content-between align-items-center mb-3">
                                <h5>
                                    <asp:Label ID="lblgioithieu" ForeColor="#0000ff" runat="server"></asp:Label>
                                </h5>
                            </div>

                            <div class="headings d-flex justify-content-between align-items-center mb-3">
                                <h5>
                                    <asp:Label ID="lblnoidung" runat="server"></asp:Label>
                                </h5>
                            </div>
                        <%--</div>--%>
                    </div>
                </div>


            </div>
        </div>

    </div>
    </div>
    
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script type='text/javascript'>

        function openInNewTab() {
            window.document.forms[0].target = '_blank';
            setTimeout(function () { window.document.forms[0].target = ''; }, 0);
        }

        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function videoEnded() {

            var LessonName = $("#MainContent_hdfLessonName").val();
            var CourseID = $("#MainContent_hdfCourseID").val();
            var UserTraing = $("#MainContent_hdfUserTraing").val();
            debugger;
            var data = { LessonName: LessonName, CourseID: CourseID, UserTraing: UserTraing };
            $.ajax({
                type: "POST",
                url: "Detail_Course_Learning.aspx/UpdateStatus",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (response) {
                    toastr.warning('Hoàn thành bài học.');
                    window.setTimeout(function () { window.location.href = '\Detail_Course_Learning.aspx?CourseID_=' + CourseID }, 2000);
                },
                failure: function (response) {
                    toastr.warning('Bạn chưa hoàn thành bài học.');
                }
            });

        }

    </script>


</asp:Content>
