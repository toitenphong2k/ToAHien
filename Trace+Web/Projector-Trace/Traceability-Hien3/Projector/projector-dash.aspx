<%@ Page Title="" Language="C#" MasterPageFile="~/Trace.Master" AutoEventWireup="true" CodeBehind="projector-dash.aspx.cs" Inherits="Traceability_Hien3.Projector.projector_dash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script src="https://code.highcharts.com/modules/export-data.js"></script>


    <script type="text/javascript">
    $(function () {
        $('#container').highcharts({
            chart: {
                type: 'line'
            },
            title: {
                text: 'PRODUCTION QUANTITY OF THE YEAR'
            },
            subtitle: {
                text: '....'
            },
            xAxis: {
                categories: [ <%=renderCategori()%>
                ],
                crosshair: true
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Production Quantity'
                },
                labels: {
                    format: '{value}',
                    style: {
                        color: '#4572A7' //'#89A54E'
                    }
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.1f}        </b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                series: {
                    dataLabels: {
                        enabled: true
                    }
                }
            },
            series: [{
                name: 'Month of the year',
                data: [<%=renderSeri()%>]

            }
            ]
        })
        });
        //]]> 
    </script>
    <script type="text/javascript">
    $(function () {
        $('#container2').highcharts({
            chart: {
                type: 'column'
            },
            title: {
                text: 'PRODUCTION QUANTITY BY MODEL'
            },
            subtitle: {
                text: '...'
            },
            xAxis: {
                categories: [ <%=renderCategori_pen()%>
                ],
                crosshair: true
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Production qty'
                },
                labels: {
                    format: '{value}',
                    style: {
                        color: '#4572A7' //'#89A54E'
                    }
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.1f}        </b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                series: {
                    dataLabels: {
                        enabled: true
                    }
                }
            },
            series: [{
                name: 'Model',
                data: [<%=renderSeri_pen()%>]

            }
            ]
        })
        });
        //]]> 
    </script>

     <script type="text/javascript">
    $(function () {
        $('#pie').highcharts({
              chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'PERCENTAGE OF PRODUCTION QTY BY MODEL'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 45,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name} </b>: {point.percentage:.1f} %'
                    }
                }          
            },
            series: [{
                type: 'pie',
                name: 'Qty: ',
                data: [
                    <%=rederPie()%>
                ]
            }]
        })
        });
        //]]> 
    </script>
     <script type="text/javascript">
    $(function () {
        $('#area').highcharts({
            chart: {
                type: 'area'
            },
            title: {
                text: 'PRODUCTION QUANTITY OF THE YEAR'
            },
            subtitle: {
                text: '...'
            },
            xAxis: {
                categories: [ <%=renderCategori_MONTH()%>
                ],
                crosshair: true
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Production quantity'
                },
                labels: {
                    format: '{value}',
                    style: {
                        color: '#4572A7' //'#89A54E'
                    }
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.1f}        </b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                series: {
                    dataLabels: {
                        enabled: true
                    }
                }
            },
            series: [{
                name: 'Month of the year',
                data: [<%=renderSeri_MONTH()%>]

            }
            ]
        })
        });
        //]]> 
    </script>

    <div class="right_col" role="main">
             <!-- top tiles -->
          <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Total Prod Qty</span>
              <div class="count"><%=total_problems_str %></div>
              <span class="count_bottom"><i class="green"> </i> Total Prod Qty</span>
            </div>
              <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> This Week</span>
              <div class="count"><%=total_week_str %></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i> <%=week_pc %>% </i> This Week</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-clock-o"></i> This month</span>
              <div class="count"><%=total_month_str %></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i><%=month_pc %> % </i> This month</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> This year</span>
              <div class="count green"><%=total_year_str %></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i><%=month_pc %> % </i> This year</span>
            </div>
            <%--<div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Pending</span>
              <div class="count"><%=total_pending_str %></div>
              <span class="count_bottom"><i class="red"><i class="fa fa-sort-desc"></i><%=pending_pc %>% </i> Pending</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Close</span>
              <div class="count"><%=total_close_str %></div>
              <span class="count_bottom"><i class="green"><i class="fa fa-sort-asc"></i><%=close_pc %>% </i> Close</span>
            </div>
            
          </div>--%>
          <!-- /top tiles -->
          <div class="">

            <div class="row">
             

              <!-- Line area -->
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="x_panel">
                 <%-- <div class="x_title">
                    <h2>Line Chart <small> </small>  </h2>
                    
                    <div class="clearfix"></div>
                  </div>--%>
                  <div class="x_content2">
                    <div id="container" style="width:100%; height:300px;"></div>
                  </div>
                </div>
              </div>
              <!-- /Line area -->

              <!-- line graph -->
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="x_panel">
                 
                  <div class="x_content2">
                    <div id="pie" style="width:100%; height:300px;"></div>
                  </div>
                </div>
              </div>
              <!-- /line graph -->
                <!-- area area -->
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="x_panel">
                 
                  <div class="x_content2">
                    <div id="area" style="width:100%; height:300px;"></div>
                  </div>
                </div>
              </div>
              <!-- /are area -->

              <!-- column graph -->
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="x_panel">
                 
                  <div class="x_content2">
                    <div id="container2" style="width:100%; height:300px;"></div>
                  </div>
                </div>
              </div>
              <!-- /column graph -->

            </div>
          </div>
        </div>
        <!-- /page content -->


        </div>

</asp:Content>
