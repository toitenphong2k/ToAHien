<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCourse.aspx.cs" Inherits="E_Learning.All_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="section-title text-center">
            <h3 class="section-title__title" style="background-color: #0dcbf045; color: darkblue;">User's Courses</h3>
        </div>

        <div class="row">
            <!--Start Single Courses One-->
            <%foreach (System.Data.DataRow rows in dtCourse.Rows)
                {%>
            <div class="col-xl-3 col-lg-6 col-md-6">
                <div class="courses-one__single wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                    <div class="courses-one__single-img">

                        <img src="<%=rows["Image"].ToString()%>" alt="" />
                        <div class="courses-one__single-content-overlay-img">
                        </div>
                        <div class="overlay-text">
                            <p><%=rows["DeptTraing"].ToString()%></p>
                        </div>
                    </div>
                    <div class="courses-one__single-content">
                        <b style="font-family: Tahoma; font-size: 14px;"><%=rows["Teacher"].ToString()%> </b>

                        <%if (rows["status_traning"].ToString() == "OK")
                            {%>
                        <%if (rows["status_exam"].ToString() == "")
                            {%>
                        <b style="padding-left: 50px; font-family: Tahoma; font-size: 14px; color: blue;">Finished exam </b>
                        <% } %>
                        <%else
                            {%>
                        <b style="padding-left: 50px; font-family: Tahoma; font-size: 14px; color: red;">Not exam </b>
                        <% } %>
                        <% } %>
                        <%else
                            {%>
                        <b style="padding-left: 50px; font-family: Tahoma; font-size: 14px; color: red;">Not exam </b>
                        <% } %>





                        <h4 class="courses-one__single-content-title">

                            <a href="Detail_Course.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()"><%=rows["NameCourse"].ToString()%>

                            </a></h4>


                        <div class="courses-one__single-content-review-box">
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
                        </div>

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
        <br />

        <div class="section-title text-center">
            <h5 class="section-title__title" style="background-color: #0dcbf045; color: darkblue;">All PSNV's Courses</h5>
        </div>
        <div class="row">
            <!--Start Single Courses One-->
            <%foreach (System.Data.DataRow rows in dtAllCourse.Rows)
                {%>
            <div class="col-xl-3 col-lg-6 col-md-6">
                <div class="courses-one__single wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1000ms">
                    <div class="courses-one__single-img">

                        <img src="<%=rows["Image"].ToString()%>" alt="" />
                        <div class="courses-one__single-content-overlay-img">
                        </div>
                        <div class="overlay-text">
                            <p><%=rows["DeptTraing"].ToString()%>  ___ <%=rows["Status_Join"].ToString()%></p>
                        </div>

                    </div>
                    <div class="courses-one__single-content">
                        <h6 class="courses-one__single-content-name"><%=rows["Teacher"].ToString()%> </h6>
                        <h4 class="courses-one__single-content-title">

                            <a href="DetailAllCourse.aspx?CourseID_=<%=rows["CourseID"].ToString()%>" target="openInNewTab()"><%=rows["NameCourse"].ToString()%>
                            </a></h4>


                        <div class="courses-one__single-content-review-box">
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
                        </div>

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

    </script>

</asp:Content>
