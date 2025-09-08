<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MW_RandomLabel_History1.aspx.cs" Inherits="Traceability_Hien3.MW_RandomLabel_History1" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>TRACEABILITY SYSTEM - MCW</title>
    <!-- Bootstrap -->
    <link href="build/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- iCheck -->
    <link href="vendors/iCheck/skins/flat/green.css" rel="stylesheet">
    <!-- Datatables -->
    <link href="vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">
    <!-- bootstrap-datetimepicker -->
    <link href="vendors/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css" rel="stylesheet">
    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
    <style>
        .nav-md {
            overflow-x: hidden;
        }
    </style>
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</head>
<body class="nav-md">
    <form id="form1" runat="server">
        <div class="main_container">
            <!-- top navigation -->
            <%--<div class="top_nav">
            <div class="nav_menu">
                <div class="nav toggle">
                  <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                </div>
            </div>
          </div>--%>
            <!-- /top navigation -->
            <!-- page content -->
            <%--<div class="right_col" role="main">
          <div class="">--%>            <%--<div class="clearfix"></div>--%>            <%--          <div class="row">
             <div class="col-md-12 col-sm-12 ">
                 <div class="col-md-4">
                    </div>
            </div>
        </div>--%>
            <div class="row">
                <div class="col-md-12 col-sm-12 ">
                    <div class="x_panel">
                        <div class="x_title">
                            <h1>TRACEABILITY SYSTEM - MCW</h1>
                            <div class="clearfix"></div>
                        </div>
                        <div class="field item form-group">
                            <label class="col-form-label label-align">From<span class="required"></span></label>
                            <div class="col-md-3 col-sm-3">
                                <input class="form-control" type="date" name="date" required='required' id="dateinput" runat="server">
                            </div>
                            <label class="col-form-label label-align">To<span class="required"></span></label>
                            <div class="col-md-3 col-sm-3">
                                <input class="form-control" type="date" name="date" required='required' id="ToDate" runat="server">
                            </div>
                           <%-- <label class="col-form-label label-align">Process</label>
                            <div class="col-md-3 col-sm-3">
                                <asp:DropDownList ID="ddltype" class="form-control" runat="server">
                                    <asp:ListItem Value="1">Laser Marking</asp:ListItem>
                                    <asp:ListItem Value="2">SMT In Out</asp:ListItem>
                                    <asp:ListItem Value="3">DIP</asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="col-md-8 col-md-offset-3">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-success btn-lg" OnClick="btnSearch_Click" />
                            </div>
                            <%--                        <div class="col-md-4">
                        Date Range Picker
                          <fieldset>
                            <div class="control-group ">
                              <div class="controls">
                                <div class="input-prepend input-group">
                                  <span class="add-on input-group-addon"><i class="glyphicon glyphicon-calendar fa fa-calendar"></i></span>
                                  <input type="text" style="width: 200px" name="reservation" id="reservation" class="form-control" value="01/01/2016 - 01/25/2016" />
                                </div>
                              </div>
                            </div>
                          </fieldset>
                      </div>--%>
                        </div>
                        <div class="x_content">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card-box table-responsive">
                                        <asp:Literal ID="ltltable" runat="server">  </asp:Literal>
                                        <table id="datatable-buttons" class="table table-striped table-bordered" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>NO</th>
                                                    <th>LINE</th>
                                                    <th>SERIAL</th>
                                                    <th>TIME</th>
                                                    <th>MODEL</th>
                                                    <th>SERIAL Customer</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptData" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("Row")%></td>
                                                            <td><%#Eval("COD_SCALE_NO")%></td>
                                                            <td><%#Eval("STR_SERIAL")%></td>
                                                            <td><%#Eval("TMR_DATE")%></td>
                                                            <td><%#Eval("STR_PROCESS")%></td>
                                                            <td><%#Eval("CustomerSerialNo")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </div>
        </div>--%>
        <!-- /page content -->
        <!-- footer content -->
        <footer>
            <div class="pull-right">
                <h6>TRACEABILITY SYSTEM - MCW - &copy; 2022</h6>
            </div>
            <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
        <!-- jQuery -->
        <script src="vendors/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="vendors/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
        <!-- FastClick -->
        <script src="vendors/fastclick/lib/fastclick.js"></script>
        <!-- NProgress -->
        <script src="vendors/nprogress/nprogress.js"></script>
        <!-- iCheck -->
        <script src="vendors/iCheck/icheck.min.js"></script>
        <!-- Datatables -->
        <script src="vendors/datatables.net/js/jquery.dataTables.min.js"></script>
        <script src="vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
        <script src="vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
        <script src="vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
        <script src="vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
        <script src="vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
        <script src="vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
        <script src="vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
        <script src="vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
        <script src="vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
        <script src="vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
        <script src="vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
        <script src="vendors/jszip/dist/jszip.min.js"></script>
        <script src="vendors/pdfmake/build/pdfmake.min.js"></script>
        <script src="vendors/pdfmake/build/vfs_fonts.js"></script>
        <!-- bootstrap-datetimepicker -->
        <script src="vendors/bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
        <!-- Custom Theme Scripts -->
        <script src="build/js/custom.min.js"></script>
        <!-- Initialize datetimepicker -->
        <script type="text/javascript">
            $(function () {
                $('#myDatepicker').datetimepicker();
            });
            $('#myDatepicker2').datetimepicker({
                format: 'DD.MM.YYYY'
            });
            $('#myDatepicker3').datetimepicker({
                format: 'hh:mm A'
            });
            $('#myDatepicker4').datetimepicker({
                ignoreReadonly: true,
                allowInputToggle: true
            });
            $('#datetimepicker6').datetimepicker();
            $('#datetimepicker7').datetimepicker({
                useCurrent: false
            });
            $("#datetimepicker6").on("dp.change", function (e) {
                $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepicker7").on("dp.change", function (e) {
                $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
            });
        </script>
    </form>
</body>
</html>
