<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course_Kynangmem.aspx.cs" Inherits="E_Learning.Course_Kynangmem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="section-title text-center">
            <h5 style="background-color: #0dcbf045; color: darkblue;"> Các khóa học bạn phải học:</h5>
        </div>
        <div class="row">
            <!--Start Single Courses One-->
            <%foreach (System.Data.DataRow rows in dtAllCourse_Join.Rows)
                {%>
            <div class="col-xl-3 col-lg-6 col-md-6">
                <div class="courses-one__single wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                    <a href="Detail_Course_Learning.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()">

                    <div class="courses-one__single-img">

                        <img src="<%=rows["Image"].ToString()%>" alt="" />
                        <div class="courses-one__single-content-overlay-img">
                        </div>
                        <div class="overlay-text">
                            <p><%=rows["DeptTraing"].ToString()%>  ___ <%=rows["Status_Join"].ToString()%></p>
                        </div>

                    </div>
                        </a>
                    <div class="courses-one__single-content">
                        <h6 class="courses-one__single-content-name"><%=rows["Teacher"].ToString()%> </h6>
                        <h4 class="courses-one__single-content-title">
                            <a href="Course_Kynangmem.aspx">Course_Kynangmem.aspx</a>
                            <a href="Detail_Course_Learning.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()"><%=rows["NameCourse"].ToString()%>
                            </a></h4>


                      <%--  <div class="courses-one__single-content-review-box">
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

                        <ul class="courses-one__single-content-courses-info list-unstyled">
                            <li><%=rows["TotalLesson"].ToString()%> Lessons </li>

                            <li><%=rows["TimeVideo"].ToString()%>'</li>
                            <li><%=rows["Skill_Level"].ToString()%></li>
                        </ul>
                    </div>
                </div>
            </div>

            <% } %>
        </div>


          <div class="section-title text-center">
            <h5  style="background-color: #0dcbf045; color: darkblue;"> Các khóa học bạn đã hoàn thành:</h5>
        </div>
        <div class="row">
            <!--Start Single Courses One-->
            <%foreach (System.Data.DataRow rows in dtAllCourse_Finish.Rows)
                {%>
            <div class="col-xl-3 col-lg-6 col-md-6">
                <div class="courses-one__single wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                    <a href="Detail_Course_Learning.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()">

                    <div class="courses-one__single-img">

                        <img src="<%=rows["Image"].ToString()%>" alt="" />
                        <div class="courses-one__single-content-overlay-img">
                        </div>
                        <div class="overlay-text">
                            <p><%=rows["DeptTraing"].ToString()%>  ___ <%=rows["Status_Join"].ToString()%></p>
                        </div>

                    </div>
                        </a>
                    <div class="courses-one__single-content">
                        <h6 class="courses-one__single-content-name"><%=rows["Teacher"].ToString()%> </h6>
                        <h4 class="courses-one__single-content-title">

                            <a href="DetailAllCourse.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()"><%=rows["NameCourse"].ToString()%>
                            </a></h4>


                      <%--  <div class="courses-one__single-content-review-box">
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

                        <ul class="courses-one__single-content-courses-info list-unstyled">
                            <li><%=rows["TotalLesson"].ToString()%> Lessons </li>

                            <li><%=rows["TimeVideo"].ToString()%>'</li>
                            <li><%=rows["Skill_Level"].ToString()%></li>
                        </ul>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
        <hr />
          <div class="section-title text-center">
            <h5 style="background-color: #0dcbf045; color: darkblue;">Các khóa học khác: </h5>
        </div>
        <div class="row">
            <!--Start Single Courses One-->
            <%foreach (System.Data.DataRow rows in dtCourse_NotJoin.Rows)
                {%>
            <div class="col-xl-3 col-lg-6 col-md-6">
                <div class="courses-one__single wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                     <a href="#" onclick="openShow()">
                    <div class="courses-one__single-img">

                        <img src="<%=rows["Image"].ToString()%>" alt="" />
                        <div class="courses-one__single-content-overlay-img">
                        </div>
                        <div class="overlay-text">
                            <p><%=rows["DeptTraing"].ToString()%>  ___ <%=rows["Status_Join"].ToString()%></p>
                        </div>

                    </div>
                         </a>
                    <div class="courses-one__single-content">
                        <h6 class="courses-one__single-content-name"><%=rows["Teacher"].ToString()%> </h6>
                        <h4 class="courses-one__single-content-title">
                            <a>
                            </a>
                                <a href="#" onclick="openShow()"> <%=rows["NameCourse"].ToString()%></a>
                                
                             </h4>

                    <%--    <div class="courses-one__single-content-review-box">
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

                        <ul class="courses-one__single-content-courses-info list-unstyled">
                            <li><%=rows["TotalLesson"].ToString()%> Lessons </li>

                            <li><%=rows["TimeVideo"].ToString()%>'</li>
                            <li><%=rows["Skill_Level"].ToString()%></li>
                        </ul>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
    </div>
    <div class="modal" id="myModal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
              <%--  <div class="modal-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h3 class="modal-title">Thông báo</h3>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>--%>


                <div class="modal-body">
                
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <p style ="color:orangered;">
                                    <p style ="color:red">
                                   RẤT TIẾC, BẠN KHÔNG THỂ TRUY CẬP BỞI BẠN CHƯA ĐƯỢC QUẢN TRỊ VIÊN ĐĂNG KÝ CHO KHÓA HỌC NÀY.  <br />
                                               <br />
                                   HÃY LIÊN HỆ QUẢN TRỊ VIÊN ĐỂ ĐƯỢC VÀO LỚP.
                                    </p>
                               </p>
                            </div>
                        </div>

                   

                    </div>
                </div>
                <div class="modal-footer">
                    <%--onServerClick ="bttSave_ServerClick"--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    
                </div>
            </div>
        </div>
    </div>
    <hr />
    <script type="text/javascript" src="textedittor/tiny_mce.js"></script>
    <script type="text/javascript"> 
        function openInNewTab() {
            window.document.forms[0].target = '_blank';
            setTimeout(function () { window.document.forms[0].target = ''; }, 0);
        }
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",
        });
        function openShow() {
            $('#myModal').modal('show');
        }
    </script>

</asp:Content>
