<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="currencies_uc.ascx.cs" Inherits="FrontPanel.usercontrol.currencies_uc" %>

<style>

    .currency{
            padding: 3px !important;
    line-height: 1.428571429;
    color: #555555;
    vertical-align: middle;
    background-color: #fff;
    border: 1px solid #a5a5a599;
    border-radius: 12px;
        margin-top: -10px;
    margin-left: 10px;
}
    
   .country{
       margin-top: -9px;
    position: absolute;
   }

</style>
<small class="country">

<asp:Image ID="Image1" runat="server" Width="20px" /> &nbsp;<asp:Label ID="lblcountry" runat="server" Font-Size="12px"></asp:Label></small><br />
  <asp:DropDownList runat="server" ID="ddlExchangeRates" CssClass="currency" AutoPostBack="True" OnSelectedIndexChanged="ddlExchangeRates_SelectedIndexChanged" AppendDataBoundItems="True">
      <asp:ListItem Value="1">EUR</asp:ListItem>
  </asp:DropDownList> 

