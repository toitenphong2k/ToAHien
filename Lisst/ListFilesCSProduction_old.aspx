<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ListFilesCSProduction.aspx.cs" Inherits="ListFilesCSProduction" %>

<%@ Register Src="UserControls/FileGridCS.ascx" TagName="FileGridVB" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <%--<script src="Styles/jquery-ui.min.js"></script>--%>
    <style type="text/css">
        td.column_style
        {
            border-left: 1px solid #5680c4;
            border-right: 1px solid #5680c4;
            border-bottom: 1px solid #5680c4;
            border-top: 1px solid #5680c4;
        }

        .aParent div
        {
            float: left;
            clear: none;
            width: 100%;
        }
    </style>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <script src="Styles/jquery.min.js"></script>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
    <script src="Styles/bootstrap.min.js"></script>

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>

    <h2 style="color: #104E8B;">List Filebrowser
    </h2>
    <div class="aParent" >
        <div style="width: 45%">
            <uc1:FileGridVB ID="FileGridVB1" HomeFolder="~/ContentFA" runat="server" PageSize="10" />
        </div>
        <div style="width: 55%">
            <table runat="server" id="tblChat" style="width: 100%">
                <tr>
                    <td style="width: 15%">
                        <asp:Label ID="lblContent" runat="server" ForeColor="#104E8B" Text="Messages:" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width: 55%">
                        <asp:TextBox ID="txtContenr" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtContenr" ValidationGroup="GR1"
                        CssClass="text-danger" ErrorMessage="The Message field is required." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image:" ForeColor="#104E8B" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload CssClass="ddl" ID="FileUpload2" multiple="true" runat="server" Height="30px" Width="398px" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server"  OnClick="btnUpload_Click" CssClass="btn btn-default" ValidationGroup="GR1" Text="Upload" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblFromdate" runat="server" Text="Date: " Font-Size="14pt" ForeColor="#104E8B"></asp:Label></td>
                    <td colspan="2">
                            <telerik:RadDatePicker ID="telDate" runat="server" Width="110px" Culture="en-US" EnableTyping="False" OnSelectedDateChanged="telDate_SelectedDateChanged" AutoPostBack="true">
                                <DateInput ID="Completeddate" ReadOnly="true" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"> 
                                </DateInput>
                            </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table style="width: 100%; height: 30px; background-color: #5680c4; text-align: center; color: White; font-size: 16px; font-weight: 700">
                            <tr>
                                <td style="width: 75%">Content</td>
                                <td style="width: 25%">Date</td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel5" runat="server" ScrollBars="Auto" Width="100%" Height="300px">
                            <asp:GridView ID="GridViewContent" runat="server" Width="100%"
                                PagerStyle-Font-Size="18px" ShowHeader="false"
                                AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal"
                                BorderColor="#CCCCCC"
                                HeaderStyle-BackColor="#5680c4" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White">

                                <Columns>

                                    <asp:TemplateField HeaderText="Content">
                                        <ItemStyle CssClass="column_style" Width="75%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkContent" runat="server"
                                                CommandArgument='<%# Eval("ImageUrl")%>' ForeColor='<%# Convert.ToInt32(Eval("Status").ToString()) ==1 ? System.Drawing.Color.Gray:System.Drawing.Color.OrangeRed  %>'
                                                Text='<%# Eval("Messages")%>' OnClick="lnkContent_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemStyle CssClass="column_style" Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" ForeColor='<%# Eval("ImageUrl").ToString() =="" ? System.Drawing.Color.Gray:System.Drawing.Color.Blue  %>' runat="server" Text='<%# Eval("CreateDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            
        </div>
    </div>

    <button type="button" id="btnShowPopup" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal" style="display: none;">Open Modal</button>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Image ID="images" runat="server" Width="100%" Height="100%" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>





</asp:Content>

