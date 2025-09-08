<%@ Page Title="" Language="C#" MasterPageFile="~/Trace.Master" AutoEventWireup="true" CodeBehind="MWDash.aspx.cs" Inherits="Traceability_Hien3.MWDash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <main class="app-content">
      <div class="app-title">
        <div>
          <h1><i class="fa fa-dashboard"></i> Dashboard</h1>
          <p>Production result overview</p>
        </div>
        <ul class="app-breadcrumb breadcrumb">
          <li class="breadcrumb-item"><i class="fa fa-home fa-lg"></i></li>
          <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
        </ul>
      </div>
       <div class="row">
            <div class="info"></div>
       </div>
      <div class="row">
        
        <div class="col-md-6 col-lg-3">
          <div class="widget-small info coloured-icon"><i class="icon fa fa-thumbs-o-up fa-3x"></i>
            <div class="info">
              <h4>Today</h4>
              <h3><%=total_Daily%></h3>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-lg-3">
          <div class="widget-small warning coloured-icon"><i class="icon fa fa-files-o fa-3x"></i>
            <div class="info">
              <h4>This month</h4>
              <h3><%=total_month%></h3>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-lg-3">
          <div class="widget-small danger coloured-icon"><i class="icon fa fa-star fa-3x"></i>
            <div class="info">
              <h4>This year</h4>
              <h3><%=total_year %></h3>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-lg-3">
          <div class="widget-small primary coloured-icon"><i class="icon fa fa-shopping-cart fa-3x"></i>
            <div class="info">
              <h4>Total Product</h4>
              <h3><b><%=total_problems %></b> </h3>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="tile">
            <h4 class="tile-title">Production quantity of the month (<%=DateTime.Now.Year %>)</h4>
            <div class="embed-responsive embed-responsive-16by9">
              <canvas class="embed-responsive-item" id="lineChartDemo"></canvas>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="tile">
            <h4 class="tile-title">Top 15 largest model products</h4>
            <div class="embed-responsive embed-responsive-16by9">
              <canvas class="embed-responsive-item" id="BarChartDemo"></canvas>
            </div>
          </div>
        </div>
          <%--<div class="col-md-6">
          <div class="tile">
            <h4 class="tile-title">Doughnut Chart</h4>
            <div class="embed-responsive embed-responsive-16by9">
              <canvas class="embed-responsive-item" id="doughnutChartDemo"></canvas>
            </div>
          </div>
        </div>--%>

          





      </div>
    </main>
    <!-- Essential javascripts for application to work-->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
    <!-- The javascript plugin to display page loading on top-->
    <script src="js/plugins/pace.min.js"></script>
    <!-- Page specific javascripts-->
    <script type="text/javascript" src="js/plugins/chart.js"></script>

    <script type="text/javascript">
        var datapie = {
            labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
           
            datasets: [
                {
                    label: "My First dataset",
                    fillColor: "rgba(30, 144, 255,0.5)",
                    strokeColor: "rgba(255,0,0,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#FFA500",
                    pointHighlightStroke: "rgba(0, 238, 118,1)",
                    data: [<%=renderdataMonth() %>]
                },
                //{
                //    label: "My Second dataset",
                //    fillColor: "rgba(30, 144, 255,0.5)",
                //    strokeColor: "rgba(255,0,0,1)",
                //    pointColor: "rgba(220,220,220,1)",
                //    pointStrokeColor: "#FFA500",
                //    pointHighlightFill: "#fff",
                //    pointHighlightStroke: "rgba(220,220,220,1)",
                //    data: [100, 200, 300, 455, 12, 45, 58]
                //}
            ]
        };
          var datathang = {
            labels: [<%=rederPie()%>],
         // labels: [1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2],
            datasets: [
                {
                    label: 100,
                    fillColor: "rgba(30, 144, 255,0.5)",
                    strokeColor: "rgba(255,0,0,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#FFA500",
                    pointHighlightStroke: "rgba(0, 238, 118,1)",
                    data: [<%=rederDataPie() %>]
                }
            ]
            }
       var pdata = [
      	{
      		value: 300,
      		color:"#F7464A",
      		highlight: "#FF5A5E",
      		label: "Red"
      	},
      	{
      		value: 50,
      		color: "#46BFBD",
      		highlight: "#5AD3D1",
      		label: "Green"
      	},
      	{
      		value: 100,
      		color: "#FDB45C",
      		highlight: "#FFC870",
      		label: "Yellow"
      	}
      ]
        var ctxl = $("#lineChartDemo").get(0).getContext("2d");
        var lineChart = new Chart(ctxl).Line(datapie);

        var ctxb = $("#BarChartDemo").get(0).getContext("2d");
        var barChart = new Chart(ctxb).Bar(datathang);

        var ctxd = $("#doughnutChartDemo").get(0).getContext("2d");
        var doughnutChart = new Chart(ctxd).Doughnut(pdata);
    </script>
    




</asp:Content>
