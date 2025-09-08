<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealID_Detail.aspx.cs" Inherits="Traceability_Hien3.RealID_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RELL IS LIST</title>
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
            <br />
             <h2><p class="text-center">REEL ID CREATED LIST</p></h2>
            
            <p></p>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridView1_RowCommand" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">           
                 <Columns>
                    <asp:BoundField DataField="sReelID" HeaderText="sReelID" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sPartNoID" HeaderText="sPartNoID" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="iQuantity" HeaderText="iQuantity" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sBarcode" HeaderText="sBarcode" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sPlant" HeaderText="sPlant" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sCategory" HeaderText="sCategory" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sLocation" HeaderText="sLocation" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="KI_PL" HeaderText="KI_PL" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="dCreated" HeaderText="dCreated" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sUserCreated" HeaderText="sUserCreated" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="sBarcodeID" HeaderText="sBarcodeID" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="PstgDate" HeaderText="PstgDate" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                     <asp:ButtonField ButtonType="Link" CommandName="link" Text="Click to Show PO Detail" >

                     <ControlStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="Blue" />
                     </asp:ButtonField>

                 </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Wrap="False" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" Wrap="False" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>


        </div>



        <br />
        <br />
        <div>
            <h2><p class="text-center">PO - INVOICE DETAIL</p></h2>
            <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="Grid" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="StockCardID" HeaderText="StockCardID" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Plant" HeaderText="Plant" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Material" HeaderText="Material" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PstgDate" HeaderText="PstgDate" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="SLoc" HeaderText="SLoc" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Reference" HeaderText="Reference" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PO" HeaderText="PO" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="POItem" HeaderText="POItem" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Vendor" HeaderText="Vendor" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Create_Date" HeaderText="Create_Date" ItemStyle-Width="150px">
                      <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>

                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Wrap="False" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" Wrap="False" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>

        </div>
    </form>
</body>

      <!-- Data table plugin-->
    <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/plugins/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">$('#sampleTable').DataTable();</script>
    <script type="text/javascript">$('#sampleTable2').DataTable();</script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/select2.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="js/plugins/dropzone.js"></script>
</html>
