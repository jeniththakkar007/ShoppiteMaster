<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header_productstatus.ascx.cs" Inherits="FrontPanel.usercontrol.header_productstatus" %>

<asp:ListView ID="ListView1" runat="server">
    <ItemTemplate>
        <li>
            <a href="/<%# Eval("URLPath") %>/Deals/Status">
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Status") %>'></asp:Label></a> </li>
    </ItemTemplate>
</asp:ListView>