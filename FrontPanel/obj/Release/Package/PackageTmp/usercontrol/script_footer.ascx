<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="script_footer.ascx.cs" Inherits="FrontPanel.usercontrol.script_footer" %>



<asp:ListView ID="ListView1" runat="server">
    <ItemTemplate>

        <asp:Label ID="Label1" runat="server" Text='<%#Eval("scriptname") %>' ></asp:Label>
    </ItemTemplate>
</asp:ListView>
