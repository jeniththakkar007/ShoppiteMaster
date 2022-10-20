<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationConfirmation.aspx.cs" Inherits="FrontPanel.Donation.DonationConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="box-center">
        <div class="confirmation">

            <i class="fa fa-check-circle fa-3x"></i>

            <h1>
                Confirmation
            </h1>
            <h5>

       
     <strong>  Donation has been given successfully. We are thankful for your kind gestures </strong>    </h5>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg f-theme" PostBackUrl="~/donation/allfunds.aspx">View All Funds</asp:LinkButton>


        </div>
    </div>
</asp:Content>
