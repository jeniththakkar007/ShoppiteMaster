<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyFunds.aspx.cs" Inherits="FrontPanel.Donation.MyFunds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="white-bg ">
        <div class="container">
            <h4 class="padding15">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg f-theme btn-xs bold pull-right" PostBackUrl="~/Donation/FundRequest.aspx">Add New Request</asp:LinkButton>
                My Fund Request
            </h4>
        </div>
    </div>
    <div class="white-smoke-bg paddingtb-15 ">
        <div class="container">

            <div class="white-bg radius padding10">
                <div class="row s-bold">
                    <div class="col-xs-10 no-padding">
                        Fund Details
                    </div>
                    <div class="col-xs-2 right no-padding">
                        Option
                    </div>
                </div>

                <hr />

                <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                    <ItemTemplate>

                        <div class="row">
                            <asp:Label ID="Label2" Visible="false" runat="server" Text='<%#Eval("RequestFundGUID") %>'></asp:Label>
                            <div class="col-md-1 col-xs-2 border padding5 center d-none cart">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' />
                            </div>

                            <div class="col-md-11 o-padding">
                                <h5>
                                    <span class="pull-right">
                                        <asp:LinkButton ID="LinkButton2" CommandName="ed" runat="server" CssClass="btn btn-default btn-xs grey-c padding5"> <i class="fas fa-pencil-alt fa-lg"></i>  </asp:LinkButton>
                                    </span>

                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                </h5>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Amount") %>' CssClass="bold"></asp:Label>
                                &nbsp; - &nbsp;
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("InsertDate") %>'></asp:Label>
                            </div>
                        </div>

                        <hr />
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>