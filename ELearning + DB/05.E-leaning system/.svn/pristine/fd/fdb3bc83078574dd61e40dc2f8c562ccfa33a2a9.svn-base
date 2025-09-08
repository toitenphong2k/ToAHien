<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlCourse.aspx.cs" Inherits="E_Learning.ControlCourse" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<link href="Content/dataTables.bootstrap4.min.css" rel="stylesheet" />--%>
    <link href="assets/css/toastr.css" rel="stylesheet" />
    <link href="assets/css/toastr.min.css" rel="stylesheet" />

    <div class="container">
        <div class="row">


            <div class="col-md-9">
            </div>
            <div class="col-md-3" style="float: right">
                <asp:LinkButton ID="linkMasterCourse" runat="server" Font-Bold="true" Font-Underline="true" OnClick="linkMasterCourse_Click" ForeColor="ForestGreen" Text="Control Content Course"></asp:LinkButton>
                &nbsp&nbsp&nbsp
            <asp:LinkButton ID="linkVideo" runat="server" Text="Control Lesson " Font-Bold="true" Font-Underline="true" ForeColor="ForestGreen" OnClick="linkVideo_Click"></asp:LinkButton>
            </div>
        </div>

        <asp:MultiView ID="mtvMasterContent" runat="server">
            <asp:View ID="VContent" runat="server">
                <div class="row">
                    <h3 style="text-align: center; color: blue">Management Master and Content of Course </h3>
                </div>
                <div class="row">
                   <table class="table fixed-table-container" id="dtDataLoad">  
                        <thead>
                            <tr>
                                <th>CourseID</th>
                                <th>Name</th>
                                <th>Image</th>
                                <th>Time</th>
                                <th>Level</th>
                                <th>Lesson</th>
                                <th>Teacher</th>
                                <th>Dept</th>
                                <th>Status</th>
                                <th>Funtion</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%int i = 1; %>
                            <asp:HiddenField ID="hdfCourseImage" runat="server" />
                            <% foreach (System.Data.DataRow Course in dtCourse.Rows)
                                { %>

                            <tr>
                                <td><%= Course["CourseID"].ToString() %></td>
                                <td><%= Course["NameCourse"].ToString() %></td>
                                <td><%= Course["Image"].ToString() %></td>
                                <td><%= Course["TimeVideo"].ToString() %></td>
                                <td><%= Course["Skill_Level"].ToString() %></td>
                                <td><%= Course["TotalLesson"].ToString() %></td>
                                <td><%= Course["Teacher"].ToString() %></td>
                                <td><%= Course["DeptTraing"].ToString() %></td>
                                <td><%= Course["Status"].ToString() %></td>
                                <%if (Course["Status"].ToString() == "Pending")
                                    {%>
                                <td>
                                    <button type="button" id="<%=Course["CourseID"].ToString()%>"
                                        onclick="openEditModal('<%=Course["CourseID"].ToString()%>','<%=Course["ContentID"].ToString()%>','<%=Course["DeptTraing"].ToString()%>','<%=Course["NameCourse"].ToString()%>','<%=Course["TimeVideo"].ToString()%>',
                                        '<%=Course["Skill_Level"].ToString()%>','<%=Course["Language"].ToString()%>','<%=Course["Image"].ToString()%>',
                                '<%=Course["TotalLesson"].ToString()%>','<%=Course["Teacher"].ToString()%>','<%=Course["FromDateTraining"].ToString()%>',
                                '<%=Course["ToDateTraining"].ToString()%>','<%=Course["Language"].ToString()%>','<%=Course["Status"].ToString()%>')"
                                        class="btn btn-primary">
                                        Edit</button>

                                    <a href="#" onclick="ConfirmDeleting('<%= Course["CourseID"].ToString()%>')" class="btn btn-danger">Del</a>

                                </td>
                                <%} %>
                                <%else
                                    { %>
                                <td></td>
                                <%} %>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
                <div class="row">
                    <div class="col-md-8">
                        <%--<asp:FileUpload runat="server" ID="ftp_Upload" BackColor="WhiteSmoke" />--%>

                        <button type="button" id="bttAdd" runat="server" class="btn btn-warning" onclick="Add()"><i class="fa fa-plus"></i>ADD</button>


                        <button type="button" id="bttDownload" runat="server" onserverclick="bttDownload_Click" class="btn btn-warning"><i class="fas fa-download"></i>DOWNLOAD</button>


                    </div>

                    <%--<div class="col-md-4" style="float: initial; color: forestgreen; font-style: oblique" />--%>
                    <%--<asp:Label ID="lblTotal" runat="server"></asp:Label>--%>
                </div>
            </asp:View>

        </asp:MultiView>
        <asp:MultiView ID="mtvLession" runat="server">
            <asp:View ID="VLession" runat="server">
                <div class="row">
                    <h3 style="text-align: center; color: blue">Management Master Lession of Course </h3>
                </div>
                <div class="row">

                    <table class="table fixed-table-container" id="dtDataLesstion">
                        <thead>
                            <tr>
                                <th>CourseID</th>
                                <th>Course Name</th>
                                <th>LeasonID</th>
                                <th>Detail_Leason</th>
                                <th>LinkVideo</th>
                                <th>UserInsert</th>
                                <th>DateInsert</th>
                                <th>Funtion</th>
                            </tr>
                        </thead>

                        <tbody>
                            <%int i = 1; %>
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <% foreach (System.Data.DataRow Course in dtLesson.Rows)
                                { %>
                            <tr>
                                <td><%= Course["CourseID"].ToString() %></td>
                                <td><%= Course["NameCourse"].ToString() %></td>
                                <td><%= Course["LeasonID"].ToString() %></td>
                                <td><%= Course["Detail_Leason"].ToString() %></td>
                                <td><%= Course["LinkVideo"].ToString() %></td>
                                <td><%= Course["UserInsert"].ToString() %></td>
                                <td><%= Course["DateInsert"].ToString() %></td>
                                <td>
                                  
                                    <button type="button" id="<%= Course["CourseID"].ToString()%>"
                                        onclick="openEditModal_Lesson('<%= Course["NameCourse"].ToString() %>','<%= Course["CourseID"].ToString() %>','<%= Course["LeasonID"].ToString() %>','<%= Course["Detail_Leason"].ToString() %>','<%= Course["LinkVideo"].ToString() %>')"
                                        class="btn btn-primary">
                                       Edit</button>
                                    <a href="#" onclick="ConfirmDeleting_LessonID('<%= Course["CourseID"].ToString() %>','<%= Course["LeasonID"].ToString() %>')" class="btn btn-danger"><i class="far fa-trash-alt"></i>Del</a>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>

                </div>

                <div class="row">
                    <div class="col-md-8">
                        <button type="button" id="bttAddLession" runat="server" class="btn btn-warning" onclick="AddLesstion()"><i class="fa fa-plus"></i>ADD LESSION</button>
                        <button type="button" id="bttDowloadLesstion" runat="server" onserverclick="bttDowloadLesstion_ServerClick" class="btn btn-warning"><i class="fas fa-download"></i>DOWNLOAD</button>

                    </div>
                </div>
            </asp:View>
        </asp:MultiView>


    </div>

    <div class="modal" id="mySearch">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <%-- Modal footer --%>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Name Course</label>
                                    <asp:TextBox ID="txtCourseIDSearch" CssClass="form-control" placeholder="Enter CourseID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="TimeVideo">Department Training</label>
                                    <asp:TextBox ID="txtDeptSeach" CssClass="form-control" placeholder="Enter Dept Traning" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Name Course</label>
                                    <asp:TextBox ID="bttCourName" CssClass="form-control" placeholder="Enter Course name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="TimeVideo">Teach</label>
                                    <asp:TextBox ID="txtTeach" CssClass="form-control" placeholder="Enter Teach Name" runat="server"></asp:TextBox>
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

    <div class="modal" id="myModal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 class="modal-title">Update</h4>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </div>

                <%-- Modal footer --%>
                <div class="modal-body">
                    <asp:HiddenField ID="hdfCourseID_Update" runat="server" />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Type Content</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddl_TypeContent_Update" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>

                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Image">Dept Training</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddl_DeptUpdate" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Name Course</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtName_Update" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="TimeVideo">TimeVideo</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtTimeVideo_Update" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- end add Modal --%>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Skill Video">Level</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtSlill_Update" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- The edit Modal --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Languge">Language</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtLage_Update" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal Header --%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <%--<div class="form-group">
                                    <label for="Image">Image</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtImage_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>

                                <div class="form-group">
                                    <label for="CopyImage">Copy Image</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:FileUpload ID="UploadImage_Update" runat="server" BackColor="#c0c0c0" />

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="">Total Lessons</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtTotalLesson_Update" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="">Teacher</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtTeacher_Update" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Status">Status</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlStatus" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Image">Content</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <CKEditor:CKEditorControl ID="CkEditor_Update" BasePath="/ckeditor/" runat="server"> 

                                    </CKEditor:CKEditorControl>
                                    <%-- <asp:TextBox ID="txt_Contr" CssClass="form-control"  runat="server" TextMode="MultiLine" Height="200px" Width ="100%" > </asp:TextBox>--%>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttUpdate" runat="server" onserverclick="bttUpdate_ServerClick" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>

        </div>
    </div>

    <div class="modal" id="myAdd">
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

                <%-- Modal footer --%>
                <div class="modal-body">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Type Content</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlTypeContetn_Add" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>

                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Image">Dept Training</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlDept" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Course">Name Course</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtNameCourse_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%--onserverclick="btnAddClick"--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="TimeVideo">TimeVideo</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txt_TimeVideo_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- end add Modal --%>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Skill Video">Skill</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtSkikkVideo_Add" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- The edit Modal --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Languge">Language</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtLangua_Add" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal Header --%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <%--<div class="form-group">
                                    <label for="Image">Image</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtImage_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>

                                <div class="form-group">
                                    <label for="CopyImage">Copy Image</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:FileUpload ID="Upload_Image_Add" runat="server" BackColor="#c0c0c0" />

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="">Total Lessons</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtTotalLeasson_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="">Teacher</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtTeacher_Add" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%-- Modal body --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Status">Status</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddlStatus_Add" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Image">Content</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <CKEditor:CKEditorControl ID="CK_Editor_Add" BasePath="/ckeditor/" runat="server"> 

                                    </CKEditor:CKEditorControl>
                                    <%-- <asp:TextBox ID="txt_Contr" CssClass="form-control"  runat="server" TextMode="MultiLine" Height="200px" Width ="100%" > </asp:TextBox>--%>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttSave_Add" runat="server" onserverclick="bttSave_Add_ServerClick" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>

        </div>
    </div>
    
    <div class="modal" id="myModalLession">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-10">
                            <h6 class="modal-title">ADD LESSION</h6>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>

                
                <div class="modal-body">
                    <asp:HiddenField ID="hdfCourse" runat="server" />
                    <asp:HiddenField ID="hdfLessonID" runat="server" />
                    <div class="container-fluid">
                         <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="Name Course">Course</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:DropDownList ID="ddl_TypeCourse_Lession_Add" runat="server"
                                        AppendDataBoundItems="true"
                                        CssClass="custom-select custom-select-sm form-control form-control-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                             
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Leasson">Name Leasson</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtNameLeason_Add" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="LinkVideo">Link Video</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:FileUpload ID ="Upload_Video_Lesstion_Add" runat ="server" />
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Content">Content Lesson</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <CKEditor:CKEditorControl ID="CKEditor_LessonContent" BasePath="/ckeditor/" runat="server"> 
                                    </CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttSave_Lession" onserverclick="bttSave_Lession_ServerClick"  runat="server" class="btn btn-primary"><i class="fas fa-download"></i>Save</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" id="myModalLession_Update">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <asp:HiddenField ID ="hdfLessonUpdate_ID" runat ="server" />
                        <asp:HiddenField ID ="hdfCourseID_LessonUpdate" runat ="server" />
                        <div class="col-md-10">
                            <h6 class="modal-title">UPDATE LESSON</h6>
                            <span id="mSpan" style="color: red;"></span>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>

                
                <div class="modal-body">
                    <div class="container-fluid">
                         <div class="row">
                               <div class="col-md-6">
                                <div class="form-group">
                                   Name Course:<asp:Label ID ="lblNameCourse" runat ="server"></asp:Label> 
                                    
                                </div>
                            </div>
                               <div class="col-md-6">
                              
                            </div>
                             </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="Name Leasson">Name Lesson</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:TextBox ID="txtName_Lesson_Update" CssClass="form-control"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="LinkVideo">Link Video</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <asp:FileUpload ID ="hdf_Update_Video_Update" runat ="server" />
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="Content">Content Lesson</label>
                                    <span style="color: red; font-size: 11px; font-style: italic;">(*)</span>
                                    <CKEditor:CKEditorControl ID="CKEditorLesson_Update" BasePath="/ckeditor/" runat="server"> 
                                    </CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal"><i class="fas fa-times"></i>Close</button>
                    <button type="button" id="bttUpdate_Lesson"  onserverclick ="bttUpdate_Lesson_ServerClick"  runat="server" class="btn btn-primary"><i class="fas fa-download"></i>UPDATE</button>
                </div>
            </div>
        </div>
    </div>


    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>

    <script src="ckeditor/ckeditor.js"></script>
    <script src="assets/js/toastr.js"></script>
    
    

    <script>
        $(document).ready(function () {
            $("#cke_pastebin").removeAttr("style");
        });
        function openEditModal(CourseID, TypeContent, Dept, Name, TimeVideo, Skill, Langue, Image, TotalLesson, Teacher, Status, FromDate, ToDate, Content) {
            $('#MainContent_ddl_TypeContent_Update').val(TypeContent);
            $('#MainContent_txtName_Update').val(Dept);
            $('#MainContent_txtName_Update').val(Name);
            $('#MainContent_txtSlill_Update').val(Skill);
            $('#MainContent_txtTimeVideo_Update').val(TimeVideo);
            $('#MainContent_txtTotalLesson_Update').val(TotalLesson);
            $('#MainContent_txtLage_Update').val(Langue);
            $('#MainContent_txtTeacher_Update').val(Teacher);

            $('#MainContent_txt_FromDate_Update').val(FromDate);
            $('#MainContent_txtToDate_Update').val(ToDate);
            $('#MainContent_hdfCourseID_Update').val(CourseID);

            //$('#MainContent_txtToDate_Update').val(Content);
            $('#myModal').modal('show');
        }
        function openEditModal_Lession(CourseID, LesonID, NameLeason, Linkvideo)
        {
         
            $('#MainContent_hdfCourse').val(CourseID);
            $('#MainContent_hdfLessonID').val(LesonID);
            $('#MainContent_txtNameLeasonEdit').val(NameLeason);
            $('#MainContent_txtLinkEdit').val(Linkvideo);
            $('#myModal').modal('show');
        }

        function ConfirmDeleting_Lession(CourseID, LessonID) {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) {

                    var data = { CourseID: CourseID, LessonID: LessonID }
                    $.ajax({
                        type: "POST",
                        url: "ControlCourse.aspx/DeleteLession",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                            window.setTimeout(function () { window.location.href = '\ControlCourse.aspx' }, 2000);
                        },
                        failure: function (response) {
                            toastr.warning('Delete  failed');
                        }
                    });
                }
            });
        }
        function openWin() {
            var customWindow = window.open('', '_blank', '');
            customWindow.close();
        }

        function closeWin() {
            var customWindow = window.open('', '_blank', '');
            customWindow.close();
        }
        function openUploadImage(CourseID) {
            $('#MainContent_hdfCourseImage').val(CourseID);
        }
        function Add() {

            $('#myAdd').modal('show');
        }

        function AddLesstion() {

           $('#myModalLession').modal('show');
            
        }

        function openEditModal_Lesson(CourseName,CourseID, LesonID, NameLeason)
        {
            
          
            $('#MainContent_hdfLessonUpdate_ID').val(LesonID);
            $('#MainContent_hdfCourseID_LessonUpdate').val(CourseID);
            $('#MainContent_txtName_Lesson_Update').val(NameLeason);
            $('#<%=lblNameCourse.ClientID%>').html(CourseName);
            $('#myModalLession_Update').modal('show');
        }


        function Search() {
            $('#mySearch').modal('show');
        }
        $(function () {
            $("#dtDataLoad").DataTable({
                "responsive": true,
                "autoWidth": false,
                "order": [[0, "asc"]],
                "pageLength": 10
            });
        });


        $(function () {
            $("#dtDataLesstion").DataTable({
                "responsive": true,
                "autoWidth": false,
                "order": [[0, "asc"]],
                "pageLength": 10
            });
        });
        function ConfirmDeleting_LessonID(CourseID, LessonID) {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) {

                    var data = { CourseID: CourseID, LessonID: LessonID }
                    $.ajax({
                        type: "POST",
                        url: "ControlCourse.aspx/DeleteLession",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                           // window.setTimeout(function () { window.location.href = '\ControlCourse.aspx/BindAllLesson' }, 2000);
                        },
                        failure: function (response) {
                            toastr.warning('Delete  failed');
                        }
                    });
                }
            });
        }

        function ConfirmDeleting(CourseID) {
            bootbox.confirm("Do you want to delete?", function (result) {
                if (result === true) {
                    //debugger;
                    //var courseID = '<%=Session["UserName"] %>';
                    var data = { CourseID: CourseID }
                    $.ajax({
                        type: "POST",
                        url: "ControlCourse.aspx/Delete_CourseID",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: function (response) {
                            toastr.success('Delete successfully');
                            localStorage.clear();
                           window.setTimeout(function () { window.location.href = '/ControlCourse.aspx' }, 2000);
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
