<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ordersummury.ascx.cs" Inherits="FrontPanel.usercontrol.uc_ordersummury" %>

<h5>Item(s) Total: <strong class="pull-right fonts ">

    <asp:Label ID="lblitemtotal" runat="server" Text="0"></asp:Label>
    <asp:Label ID="lblcurrency" runat="server" Text=""></asp:Label>
</strong>
</h5>

<hr />
<h5>Shipping: <strong class="pull-right fonts ">
    <asp:Label ID="lblshippingfees" runat="server" Text="0" Visible="true"></asp:Label>
    <asp:Label ID="lblshippingcurrency" runat="server" Text=""></asp:Label>
</strong>
</h5>
<hr />
<h5>VAT: <strong class="pull-right fonts ">
    <asp:Label ID="lblvatfees" runat="server" Text="0" Visible="true"></asp:Label>
    <asp:Label ID="lblvartcurrency" runat="server" Text=""></asp:Label>
</strong>
</h5>

<hr />
<h5>Tax: <strong class="pull-right fonts ">
    <asp:Label ID="lbltax" runat="server" Text="0"></asp:Label>
    <asp:Label ID="lbldelcurrency" runat="server" Text=""></asp:Label></strong>
</h5>
<hr />

<h5>Total: <strong class="pull-right fonts large">
    <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label>
</strong>
</h5>

<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:Label ID="lblcartcount" Visible="false" runat="server" Text="0"></asp:Label>