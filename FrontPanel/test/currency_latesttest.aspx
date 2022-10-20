<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="currency_latesttest.aspx.cs" Inherits="FrontPanel.test.currency_latesttest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <asp:DropDownList runat="server" ID="ddlExchangeRates" CssClass="currency" AutoPostBack="True" OnSelectedIndexChanged="ddlExchangeRates_SelectedIndexChanged"  AppendDataBoundItems="True">
    
  </asp:DropDownList>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
