<%@ Page Title="" Language="C#" MasterPageFile="~/Trace.Master" AutoEventWireup="true" CodeBehind="MW_DetailHistory.aspx.cs" Inherits="Traceability_Hien3.MW_DetailHistory" %>
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
                            <asp:DropDownList ID="cbLine" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="auto-style1">
                            <input class="form-control" id="txtScanSerial" type="text" placeholder="Enter Serial / Temp" runat="server">
                        </div>

                        <div class="col-md-2">
                            <%-- <asp:TextBox ID="txtSerialNo" runat="server" CssClass="form-control"></asp:TextBox>--%>
                            <input class="form-control" id="txtDateInput" type="text" placeholder="Select To Date Input" runat="server" clientidmode="Static" autocomplete="off">
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

         <div class="modal fade bd-example-modal-xl" id="lardgeModal" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Detail PO Manetron</h5>
                    </div>
                    <div class="modal-body">
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <h2>Detail </h2>
                        <p></p>
                        <table id="tableID" style="width: 100%">
                            <tr>
                                <th>DA No</th>
                                <th>DA Item</th>
                                <th>PO</th>
                                <th>PO Item</th>
                                <th>Invoice</th>
                                <th>Date Order</th>
                            </tr>
                            <tr>
                                <td id="DANo"></td>
                                <td id="DAItem"></td>
                                <td id="PO"></td>
                                <td id="POItem"></td>
                                <td id="Invoice"></td>
                                 <td id="DateOrder"></td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
               <div class="modal fade bd-example-modal-xl" id="lardgeModalPCB" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">PCB Filter or Panel </h5>
                    </div>
                    <div class="modal-body">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        <h2>Detail </h2>
                        <p></p>
                        <table id="tableIDPCB" style="width: 100%">
                            <tr>
                                <th>PO</th>
                                <th>POItem</th>
                                <th>Material</th>
                                <th>Vendor</th>
                                <th>Invoice</th>
                                <th>Qty</th>
                                <th>Date Order</th>
                            </tr>
                            <tr>
                                <td id="PO_PCB"></td>
                                <td id="POItem_PCB"></td>
                                <td id="Material"></td>
                                <td id="Vendor_PCB"></td>
                                <td id="Invoice_PCB"></td>
                                <td id="Qty_PCB"></td>
                                 <td id="DateOrder_PCB"></td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
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
                            <table class="table table-hover table-bordered" id="ViewData">
                                <thead>
                                    <tr>
                                        <th>No</th>
                                        <th>Model Name</th>
                                        <th>Line Name</th>
                                        <th>Serial No</th>
                                        <th>Magenetron</th>
                                        <th>Filter PCB</th>
                                        <th>Panel PCB</th>
                                        <th>Date FA</th>
                                        <th>Date Weight</th>
                                        <th>Date Shink</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltrsanpham" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
        function Opennotify() {
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
        function ShowPopup(a1, a2, a3,a4) {
            var data = { a1: a1, a2: a2, a3: a3, a4:a4 };
            debugger;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "MW_DetailHistory.aspx/GetManetron",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (l) {
                    $("#lardgeModal").modal("show");
                    var res = l.d.split(";");
                         debugger
                    $("#tableID").find("tr:not(:first)").remove();
                    if (res.length > 0) {
                        $("#tableID").find('tbody')
                            .append($('<tr>')
                                .append($('<td>').text(res[1]))  //text(list.d[0]) text(res[i]
                                .append($('<td>').text(res[2]))
                                .append($('<td>').text(res[4]))
                                .append($('<td>').text(res[5]))
                                .append($('<td>').text(res[10]))
                                .append($('<td>').text(res[3]))
                            );
                          
                    }

                },

            });
        }    
       
    </script>

     <script type="text/javascript">
        function ShowPopupPCB(a1, a2) {
            var data = { a1: a1, a2: a2};
            //debugger;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "MW_DetailHistory.aspx/GetFiltterPCB",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (list) {
                    //debugger;
                    $("#lardgeModalPCB").modal("show");
                    $("#tableIDPCB").find("tr:not(:first)").remove();
                        $("#tableIDPCB").find('tbody')
                            .append($('<tr>')
                                .append($('<td>').text(list.d[0]))
                                .append($('<td>').text(list.d[1]))
                                .append($('<td>').text(list.d[2]))
                                .append($('<td>').text(list.d[3]))
                                .append($('<td>').text(list.d[4]))
                                .append($('<td>').text(list.d[5]))
                                .append($('<td>').text(list.d[6]))
                            );
                },

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
    <!-- Data table plugin-->
    <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">$('#ViewData').DataTable();</script>
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

        $('#txtDateInput').datepicker({
            format: "yyyy-mm-dd",
            autoclose: true,
            todayHighlight: true
        });
        $('#demoSelect').select2();

       
    </script>

</asp:Content>
