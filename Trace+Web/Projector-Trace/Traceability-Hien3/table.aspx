<%@ Page Title="" Language="C#" MasterPageFile="~/Trace.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="Traceability_Hien3.table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <main class="app-content">
        <div class="app-title">
            <div>
                <h1><i class="fa fa-th-list"></i>Product history </h1>
                <p>Progress will be display as below</p>
            </div>
            <ul class="app-breadcrumb breadcrumb side">
                <li class="breadcrumb-item"><i class="fa fa-home fa-lg"></i></li>
                <li class="breadcrumb-item">Projector</li>
                <li class="breadcrumb-item active"><a href="#">History</a></li>
            </ul>
        </div>
        <div class="auto-style2">
            <div class="tile">
                <div class="tile-body">
                    <div class="row">
                        <div class="col-md-2">
                            <%-- <label class="control-label">Model</label>--%>
                            <asp:DropDownList ID="cbModel" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="auto-style1">
                            <input class="form-control" id="txtFrom" type="text" placeholder="Select From Date" runat="server" clientidmode="Static" autocomplete="off">
                        </div>
                        <div class="auto-style1">
                            <input class="form-control" id="txtTo" type="text" placeholder="Select To Date" runat="server" clientidmode="Static" autocomplete="off">
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="cbLine" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <%-- <asp:TextBox ID="txtSerialNo" runat="server" CssClass="form-control"></asp:TextBox>--%>
                            <input class="form-control" id="txtSerialNo" type="text" placeholder="Enter Serial / Temp" runat="server">
                        </div>
                        <%--<div class="col-md-2">
                          <button class="btn btn-primary"  type="button" runat="server" onserverClick="btnSearch_Click" ><i class="fa fa-fw fa-lg fa-search" ></i>Search</button>
                        </div>--%>
                        <div class="col-md-2">
                            <button class="btn btn-primary" type="button" onserverclick="btnSearch_Click" runat="server"><i class="fa fa-fw fa-lg fa-search"></i>Search</button>
                            <%--<asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Button" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearix"></div>
        <div class="row">
            <div class="col-md-12">
                <div class="tile">
                    <div class="tile-body">
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th>No</th>
                                        <th>Model Name</th>
                                        <th>Temp Serial</th>
                                        <th>Product Serial</th>
                                        <th>Optical</th>
                                        <th>ASSY2</th>
                                        <th>ASSY4</th>
                                        <th>Visual Check</th>
                                        <th>Acessories</th>
                                        <th>Weigh</th>
                                        <th>Shrink</th>
<%--                                        <th>PCBID</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltrsanpham" runat="server"></asp:Literal>
                                    <%-- <tr>                                                                                                           
                   <td>  m + " </td>                                                                                              
                    <td>  dk.Rows[i]["MODEL_NM"].ToString() + "</td>                                                               
                    <td><a href="javascript:void(0);" onclick= "TempClick"  >  </a></td>           
                    <td> + dk.Rows[i]["PROD_SERIAL"].ToString() + "</td>                                                            
                    <td> + dk.Rows[i]["ASSY2"].ToString() + "</td>                                                                  
                    <td> + dk.Rows[i]["ASSY4"].ToString() + "</td>                                                                  
                    <td> + dk.Rows[i]["VISUAL_CHECK"].ToString() + "</td>                                                           
                    <td> + dk.Rows[i]["ACCESSORIES_DT"].ToString() + " </td>                                                        
                    <td> + dk.Rows[i]["WEIGHT_DT"].ToString() + " </td>                                                             
                    <td> + dk.Rows[i]["SHRINK_DT"].ToString() + " </td>                                                            
                    </tr>  --%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">System Detail...</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->
        <!-- Extra large model -->
        <div class="modal fade bd-example-modal-xl" id="lardgeModal" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">System Detail of PCBID</h5>
                    </div>
                    <div class="modal-body">
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <h2>List PCBID</h2>
                        <p></p>
                        <table id="tableID" style="width: 100%">
                            <tr>
                                <th>PCBID</th>
                                <%--<th>PARTCARD</th>--%>
                                <th>Path</th>
                            </tr>
                            <tr>
                                <td id="PCBID"></td>
                                <%--<td id="PARTCARD"></td>--%>
                                <td id="vendor_code"><a href="MainBoard.aspx">link</a></td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Extra large model -->
        <!-- Extra large model -->
        <div class="modal fade bd-example-modal-xl" id="ModalOptical" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">System Detail of Optical</h5>
                    </div>
                    <div class="modal-body">
                        
                        <h2>OPTICAL ID</h2>
                        <p></p>
                        <table id="tableID1" style="width: 100%">
                            <tr>
                                <th>OPTICAL ID</th>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Extra large model -->
    </main>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }
        th, td {
            padding: 15px;
        }
        .auto-style1 {
            position: relative;
            width: 100%;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 16.6666666667%;
            flex: 0 0 16.6666666667%;
            max-width: 16.6666666667%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style2 {
            position: relative;
            width: 100%;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <script type="text/javascript">
        function Open-notify() {
            $.notify({
                // options
                icon: 'glyphicon glyphicon-warning-sign',
                title: '<strong>This is the warning of system: </strong> </br>',
                message: '<strong>Turning standard Bootstrap alerts into "notify" like notifications</strong> </br> I dont know',
                url: '#',
                target: '_blank'
            }, {
                    // settings
                    element: 'body',
                    position: null,
                    type: "info",
                    allow_dismiss: true,
                    newest_on_top: true,
                    showProgressbar: false,
                    placement: {
                        from: "bottom",
                        align: "right"
                    },
                    offset: 20,
                    spacing: 10,
                    z_index: 1031,
                    delay: 5000,
                    timer: 1000,
                    url_target: '_blank',
                    mouse_over: null,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    onShow: null,
                    onShown: null,
                    onClose: null,
                    onClosed: null,
                    icon_type: 'class',
                    template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                        '<span data-notify="icon"></span> ' +
                        '<span data-notify="title">{1}</span> ' +
                        '<span data-notify="message">{2}</span>' +
                        '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                        '</div>' +
                        '<a href="{3}" target="{4}" data-notify="url"></a>' +
                        '</div>'
                });
        }
    </script>
    <script type="text/javascript">
        function ShowPopup(a1) {
            $("#lardgeModal").modal("show");
            var res = a1.split(";");
           $("#tableID").find("tr:not(:first)").remove();
            for (var i = 0; i < res.length; i++) {
                if (res[i].length>15) {
                    $("#tableID").find('tbody')                                   
                        .append($('<tr>')
                        .append($('<td>').text(res[i]))
                        .append($('<td><a data-toggle="tooltip" data-placement="top" title="Click here to show" target="_blank" href="MainBoard.aspx?PCBID='+res[i]+'&lineName=0&model=0&starttime=0&endtime=0 ">MainBoard</a>'))  
                    );
                }
                else {
                    $("#tableID").find('tbody')                                   
                        .append($('<tr>')
                        .append($('<td>').text(res[i]))
                        .append($('<td>'))  
                    );
                }

                
            }
        }
        function ShowPopupOptical(a1) {
            $("#ModalOptical").modal("show");
            var res = a1.split(";");
           $("#tableID1").find("tr:not(:first)").remove();
            for (var i = 0; i < res.length; i++) {
                $("#tableID1").find('tbody')                                   
                        .append($('<tr>')
                        .append($('<td>').text(res[i]))
                    );
            }
        }
        function ShowPopup1(a1) {
            document.getElementById("test").value = a1;
        }
        function openPopup() {
            if (window.name != "nouvelle") {
                var options = "toolbar=no,location=no,status=yes,resizable=yes,scrollbars=yes";
                var url = "target-popup.html";
                var newWin = window.open(url, "nouvelle", options);
                if (newWin == null) {
                    window.status = "Nouvelle fenetre null : popup bloquée !";
                    window.alert(_MsgWindowOpenError);
                }
                else if (window.top != newWin) {
                    window.opener = window.self;
                    window.self.close();
                }
            }
        }
        function CallButtonClick2() {
            document.getElementById('Button2').click();
        }
        function openPop(tempID) {
            var data = { tempID: tempID }
            $.ajax({
                type: "POST",
                url: "table.aspx/Search_Click",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (response) {
                },
                failure: function (response) {
                }
            });
        }
    </script>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <!-- Essential javascripts for application to work-->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
    <!-- The javascript plugin to display page loading on top-->
    <script src="js/plugins/pace.min.js"></script>
    <!-- Page specific javascripts-->
    <!-- Data table plugin-->
    <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">$('#sampleTable').DataTable();</script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/select2.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/dropzone.js"></script>
    <script type="text/javascript">
        $('#sl').on('click', function () {
            $('#tl').loadingBtn();
            $('#tb').loadingBtn({ text: "Signing In" });
        });
        $('#el').on('click', function () {
            $('#tl').loadingBtnComplete();
            $('#tb').loadingBtnComplete({ html: "Sign In" });
        });
        $('#txtFrom').datepicker({
            format: "yyyy-mm-dd",
            autoclose: true,
            todayHighlight: true
        });
        $('#txtTo').datepicker({
            format: "yyyy-mm-dd",
            autoclose: true,
            todayHighlight: true
        });
        $('#demoSelect').select2();
    </script>
</asp:Content>
