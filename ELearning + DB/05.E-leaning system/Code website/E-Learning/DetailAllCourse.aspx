<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailAllCourse.aspx.cs" Inherits="E_Learning.DetailAllCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 

    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hdfCourseID" runat="server" />
            <asp:HiddenField ID="hdfUserTraing" runat="server" />
            <asp:HiddenField ID="hdfLessonName" runat="server" />
            <!--Start Course Details Sidebar-->
            <div class="col-xl-3 col-lg-3">
                <div class="course-details__sidebar">
                    <div class="course-details__sidebar-meta wow fadeInUp animated" data-wow-delay="0.3s">
                        <ul class="course-details__sidebar-meta-list list-unstyled">
                               <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-clock"></i></a>
                                </div>
                                <div class="text">
                                    <a>From Date:<asp:Label ID  ="lblFromDate" runat ="server"></asp:Label></a><br />
                                    <a>To Date:<asp:Label ID  ="lblToDate" runat ="server"></asp:Label></a>
                                </div>
                            </li>

                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-folder-open"></i></a>
                                </div>
                                <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown">Lectures</a>
                                <div class="dropdown-menu" id="Tr_ID" runat ="server">
                                   <asp:Repeater ID="prtDetailLeasson" runat="server" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtSearchLeason"    runat="server"  class="dropdown-item" Text='<%# Eval("Detail_Lesson") %>'>  </asp:LinkButton>
                                            <asp:HiddenField ID ="hdfStatusLesson" runat ="server" Value ='<%# Eval("Status_Lesson") %>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </li>
                               <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-flag"></i></a>
                                </div>
                                <div class="text">
                                    <p><a href="#">Skill Level: <span><asp:Label ID ="lbllevelTraing"  ForeColor ="Black" runat ="server"></asp:Label></span></a></p>
                                </div>
                            </li>

                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-bell"></i></a>
                                </div>
                                <div class="text">
                                    <p><a href="#">Language: <span><asp:Label ID ="lblLanguage"  ForeColor ="Black"  runat  ="server"></asp:Label></span></a></p>
                                </div>

                            </li>
                            <li class="course-details__sidebar-meta-list-item">
                                <div class="icon">
                                    <a><i class="far fa-user-circle"></i></a>
                                </div>
                                <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown">Students</a>
                                   <div class="dropdown-menu"  runat ="server">
                                    <asp:Repeater ID="prtListUser" runat="server"  >  <%--Bind repter de su dung duoc link OnItemDataBound ="prtDetailLeasson_ItemDataBound" --%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtUser"    runat="server"  class="dropdown-item" Text='<%# Eval("Detail_Lesson") %>'>  </asp:LinkButton>
                                            <asp:HiddenField ID ="hdfStatusLesson" runat ="server" Value ='<%# Eval("Status_Lesson") %>' />
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
                                        <asp:LinkButton ID ="lbkTest" runat ="server"   ForeColor ="Black" Text ="The Exam"  ></asp:LinkButton>
                                       </a></p>
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



                        
                        <video width="1000" height="500" controls " onended="videoEnded()">

                            <%foreach (System.Data.DataRow rows in dtVideo.Rows)
                                {%>
                            <source src="<%=rows["LinkVideo"].ToString()%>" type="video/mp4" id="id_Video">
                            <% } %>
                        </video>



                        <div class="courses-one__single-content">
                            <div class="courses-one__single-content-overlay-img">
                                
                            </div>
                            <h6 class="courses-one__single-content-name">Author: <span style="color:red">Recently Updated: 20 June, 2021</span></h6>
                            <h4 class="courses-one__single-content-title">Course Name : <asp:Label ID ="lblNameCouse" runat ="server"></asp:Label></h4>
                         <%--   <div class="courses-one__single-content-review-box">
                                <ul class="list-unstyled">
                                    <li><i class="fa fa-star"></i></li>
                                    <li><i class="fa fa-star"></i></li>
                                    <li><i class="fa fa-star"></i></li>
                                    <li><i class="fa fa-star"></i></li>
                                    <li><i class="fa fa-star"></i></li>
                                </ul>
                                <div class="rateing-box">
                                    <span>(4)</span>
                                </div>
                            </div>--%>
                            <div class="course-details__content-text1">
                                <p>
                                    <b style="font-family:Tahoma;"><asp:Label ID ="lblgioithieu" runat ="server"></asp:Label></b>
                                </p>
                            </div>

                            <div class="course-details__content-text2">
                                 <p>
                                    <span style="font-family:Tahoma; font-size:14px;"><asp:Label ID ="lblnoidung" runat ="server"></asp:Label></span>
                                </p>
                            </div>

                            <hr />
                            <div style="font-family:Tahoma; font-size:18px; padding-bottom:10px;"><b>Khoa hoc lien quan</b></div>

                            <div class="course-details__content-list">
                                <ul class="list-unstyled">
                                     <%foreach (System.Data.DataRow rows1 in dtCourseuser.Rows)
                                   {%>
                                        <li>
                                        <div class="icon">
                                            <span class="icon-confirmation"></span>
                                        </div>
                                        <div class="text">
                                            <p><a href="Detail_Course.aspx?CourseID_=<%=rows1["CourseID"].ToString() %>"><b><%=rows1["NameCourse"].ToString() %></b></a></p>                                            
                                        </div>
                                    </li>
                                 <% } %>
                                    <%--<li>
                                        <div class="icon">
                                            <span class="icon-confirmation"></span>
                                        </div>
                                        <div class="text">
                                            <p>It has survived not only five centuries</p>
                                        </div>
                                    </li>    --%>                                
                                </ul>
                            </div>

                        </div>
                    </div>
                    <!--End Single Courses One-->

                   
                </div>
            </div>
            <!--End Course Details Content-->
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
                    url: "Detail_Course.aspx/UpdateStatus",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: function (response) {
                        toastr.warning('Finished the lesson.');
                        window.setTimeout(function () { window.location.href = '\Detail_Course.aspx?CourseID_='+ CourseID }, 2000);
                    },
                    failure: function (response) {
                        toastr.warning('Faile training the lesson.');
                    }
                });

            }

    </script>


</asp:Content>
