<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="VendorPanel.membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background: white;
        }
    </style>
    <div class="row box-center">
        <div class="col-md-9">
            <div class="member-bg center">
                <h1 class="bold white-c ">Sell Online with us
                </h1>
                <br />

                <h4 class="white-c">
                    <asp:Label ID="Label1" runat="server" Text="$ 30"></asp:Label>
                    / One Time Membership Fee
                </h4>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn d-grey-bg white-c btn-lg ">Start Now</asp:LinkButton>
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/membershipbuy.png" Width="70%" />
            </div>
        </div>
    </div>
</asp:Content>