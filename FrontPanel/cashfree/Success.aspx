<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="FrontPanel.cashfree.Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box-center margintb">
        <div class="radius shadow white-bg padding25 center">
            <br />
            <br />
            <h2 class="c-green-c upp">Successful
            </h2>
            <i class="fa fa-credit-card fa-4x c-green-c"></i>
            <br />
            <br />
            <h3>You Purchased the bid successfully
                <br />
                <small>Exciting Deals are available</small>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg " PostBackUrl="~/Default.aspx">Start Bid Now</asp:LinkButton>
            </h3>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>