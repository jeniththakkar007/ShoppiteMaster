<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cart_counter_uc.ascx.cs" Inherits="FrontPanel.usercontrol.cart_counter_uc" %>

<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/cart.aspx" CssClass="cart-icon">
    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/cart.png" /><asp:Label ID="lblcount" CssClass="notify" runat="server" Text=""></asp:Label><span class="m-none">

                                 Cart</span>
</asp:LinkButton>