<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainBoard.aspx.cs" Inherits="Traceability_Hien3.MainBoard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PCBID List</title>
    <style type="text/css">
    .Grid td
    {
        background-color: #eee;
        color: black;
        font-family: Arial;
        font-size: 10pt;
        line-height: 200%;
        cursor: pointer;
        width: 100px;
        border: 1px solid groove;
    }
    .header
    {
        background-color: #6C6C6C !important;
        color: White !important;
        font-family: Arial;
        font-size: 10pt;
        line-height: 200%;
        width: 100px;
        text-align: center;
    }
</style>
       <!-- Essential javascripts for application to work-->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
        <!-- The javascript plugin to display page loading on top-->
    <script src="js/plugins/pace.min.js"></script>
    <!-- Page specific javascripts-->
    <script type="text/javascript" src="js/plugins/bootstrap-notify.min.js"></script>
    <script type="text/javascript" src="js/plugins/sweetalert.min.js"></script>
        <!-- Main CSS-->
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <!-- Font-icon css-->
   
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" />
      
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<br />--%>
           <h2> <p class="text-center"> PCBID IN - OUT HISTORY</p> </h2>
           <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridView1_RowCommand" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView1_RowDataBound">           
                    <Columns>
                        <asp:BoundField DataField="MesssageID" HeaderText="MesssageID" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LineName" HeaderText="LineName" ItemStyle-Width="150px">                           
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField DataField="MachineID" HeaderText="MachineID" ItemStyle-Width="150px">                           
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PartNumber" HeaderText="PartNumber" ItemStyle-Width="150px">                           
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="WhiteBoard" HeaderText="WhiteBoard" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FinishBoard" HeaderText="FinishBoard" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PCBID" HeaderText="PCBID" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Servertime" HeaderText="Servertime" ItemStyle-Width="150px" Visible="False" >
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="150px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="PCBPartCard" HeaderText="PCBPartCard" ItemStyle-Width="250px">
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:BoundField>--%>
                     
                        <asp:ButtonField ButtonType="Link"  CommandName="link" Text="Click to show RealID List" >
                         <ControlStyle BackColor="#FFFF99" Font-Bold="True" ForeColor="Blue" />
                        </asp:ButtonField>
                         <%--<asp:ButtonField ButtonType="Link" CommandName="test" Text="test" />--%>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Wrap="False" />
                    <RowStyle BackColor="White" ForeColor="#003399" Wrap="False" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
        </div>

        <%--<div class="col-md-12">
                <div class="tile">
                    <div class="tile-body">
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered" id="sampleTable2">
                                <thead>
                                    <tr>
                                        <th>MesssageID</th>
                                        <th>LineName</th>
                                        <th>MachineID</th>
                                        <th>LineName</th>
                                        <th>PartNumber</th>
                                        <th>WhiteBoard</th>
                                        <th>FinishBoard</th>
                                        <th>PCBID</th>
                                        <th>CreatedDate</th>
                                        <th>ServerTime</th>
                                        <th>PCBPartCard</th>
                                        <th>Link</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%for (int i = 0; i < dtReelID1.Rows.Count; i++)
                                        {
                                            string a = dtReelID1.Rows[i]["LineName"].ToString();
                                            %>
                                    <tr>
                                        <td><%=dtReelID1.Rows[i]["MesssageID"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["LineName"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["MachineID"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["LineName"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["PartNumber"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["WhiteBoard"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["FinishBoard"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["PCBID"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["CreatedDate"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["ServerTime"].ToString() %></td>
                                        <td><%=dtReelID1.Rows[i]["PCBPartCard"].ToString() %></td>
                                        
                                      <td> <button class="btn btn-primary" type="button" CommandArgument = "<%=dtReelID1.Rows[i]["LineName"].ToString()%>" onserverclick="ShowReelID_Click" runat="server" ><i class="fa fa-fw fa-lg fa-search"></i>Link to ReelID</button> </td>
                                        <td>  <asp:Button ID="Button1" class="btn btn-primary" CommandArgument = '<%=a%>' runat="server" Text="Link ReelID" OnClick="Button1_Click" /> </td>
                                    </tr>
                                    <%
                                        } %>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>--%>
                        <br />
                        <h2><p class="text-center">REEL ID USING ON PANACIMM MACHINE</p></h2>
        <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="LineName" HeaderText="LineName" ItemStyle-Width="150px">
                  <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Model" HeaderText="Model" ItemStyle-Width="150px">
                  <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                 <asp:TemplateField HeaderText="MaterialBarcode" ItemStyle-Width="150">
                    <ItemTemplate>
                        <%--<asp:TextBox ID="MaterialBarcode" runat="server" Text='<%# Eval("MaterialBarcode") %>'></asp:TextBox>--%>
                        <asp:Label ID="MaterialBarcode" runat="server" Text='<%# Eval("MaterialBarcode") %>'></asp:Label>
                    </ItemTemplate>                         
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="PartNumber" HeaderText="PartNumber" ItemStyle-Width="150px">
                  <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="StartTime" HeaderText="StartTime" ItemStyle-Width="150px">
                  <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EndTime" HeaderText="EndTime" ItemStyle-Width="150px">
                  <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
            </Columns>           
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

        <div class="col-md-12">
                <div class="tile">
                    <div class="tile-body">
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th>LineName</th>
                                        <th>MaterialBarcode</th>
                                        <th>PartNumber</th>
                                        <th>LineName</th>
                                        <th>StartTime</th>
                                        <th>EndTime</th>
                                        <th>Link to ReelID</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        if (dtReelID != null)
	                                    {
		                                         for (int i = 0; i < dtReelID.Rows.Count; i++)
                                                        {
                                                            %>
                                                    <tr>
                                                        <td><%=dtReelID.Rows[i]["LineName"].ToString() %></td>
                                                        <td><%=dtReelID.Rows[i]["MaterialBarcode"].ToString() %></td>
                                                        <td><%=dtReelID.Rows[i]["PartNumber"].ToString() %></td>
                                                        <td><%=dtReelID.Rows[i]["LineName"].ToString() %></td>
                                                        <td><%=dtReelID.Rows[i]["StartTime"].ToString() %></td>
                                                        <td><%=dtReelID.Rows[i]["EndTime"].ToString() %></td>
                                                        <td> <a data-toggle="tooltip" data-placement="top" title="Click here to show" href="RealID_Detail.aspx?realid=<%=dtReelID.Rows[i]["MaterialBarcode"].ToString()%>" target="_blank"> <h6>Click to show Reel ID history </h6></a></td>
                                        
                                                    </tr>
                                                    <%
                                                 } 
	                                    }
                                        %>
                                    <asp:Literal ID="ltrReelID" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
    </form>
        <!-- Data table plugin-->
    <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">$('#sampleTable').DataTable();</script>
    <script type="text/javascript">$('#sampleTable2').DataTable();</script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/select2.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/dropzone.js"></script>
    <script>
        function myFunction(name,job) {
        document.getElementById("demo").innerHTML = "Welcome " + name + ", the " + job + ".";
        }
</script>

</body>
</html>
