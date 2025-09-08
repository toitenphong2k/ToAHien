<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TheExam.aspx.cs" Inherits="E_Learning.TheExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-4">
                <h5 class="section-title__title">Mini Test</h5>
            </div>
            <div class="col-md-3">
                Time:
            </div>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-8" style="height: 700px; overflow-y: scroll">
                <div class="course-details__content">
                    <asp:ListView ID="listQuestAnser" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Table"     >   
                        <ItemTemplate>
                            <table>
                                <tr id ="_itemrow">
                                    <td>
                                        <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# Eval("AnserID").ToString() == "0" %>'>
                                            <abbr>
                                                <asp:Label runat="server" ID="lblQuestionID" Text='<%# Eval("QuestionID") %>' ForeColor="Blue" />.
                                        </asp:PlaceHolder>
                                        <asp:Label runat="server" ForeColor="Blue" Text='<%# Eval("Question") %>' /></abbr>
                                    </td>

                                </tr>
                                <tr>
                                    <td >
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%# Eval("TextAnser").ToString() != "" %>'>
                                            <input id="ck_AnserID" value='<%# Eval("AnserID") %>' type="checkbox" runat="server" />
                                        </asp:PlaceHolder>
                                        <asp:Label runat="server" ForeColor="Black" Text='<%# Eval("TextAnser") %>' />
                                        <asp:HiddenField ID="hdfAnserID" runat="server" Value='<%# Eval("AnserID") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Panel ID="pQuestion" GroupingText=" List Anser" runat="server">
                    <asp:DataList ID="dtListQuestion" runat="server" RepeatDirection="Horizontal"
                        RepeatColumns="5" ForeColor="Blue"
                        RepeatLayout="Table">
                        <ItemTemplate>
                            <asp:Button ID="bttCourse" class="btn btn-primary" ForeColor="White" Text='<%# Eval("QuestionID") == DBNull.Value ? false : Eval("QuestionID") %>' runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
                <br />
                <asp:Button ID="bttSubmit" CssClass="btn btn-primary" runat="server"  Text="Submit" />
            </div>

        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
            </div>

        </div>
    </div>
    <script src="assets/vendors/jquery/jquery-3.5.1.min.js"></script>
    <script src="assets/js/toastr.js"></script>
</asp:Content>
