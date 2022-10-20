<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="FrontPanel.moncash.Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box-center margintb">
        <div class="radius shadow white-bg padding25 center">
            <br /> <br /> 
            <h2 class="red-c upp">
                UnSuccessful
            </h2>
            <i class="fa fa-credit-card fa-4x red-c"></i>
             <br />    <br />
            <h3>
                Your payment has been declined<br />
        
                <br />    <br />
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg " PostBackUrl="~/Account/auctionpackage">Try Again</asp:LinkButton>
            </h3>
        <br /> <br /> <br /> </div>
    </div>


</asp:Content>
