<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="facebooklogin.ascx.cs" Inherits="FrontPanel.SocialMediaLogin.facebooklogin" %>


 <asp:Literal runat="server" ID="ErrorMessage" />
<asp:Label ID="lblerror" runat="server" Text="" ForeColor="red"></asp:Label>
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="FacebookLogin"> <asp:Image ID="Image1" runat="server" ImageUrl="~/images/l-facebook.png" Width="55px" /></asp:LinkButton>
<asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">
<hr />
<table>
    <tr>
        <td rowspan="5" valign="top">
            <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
        </td>
    </tr>
    <tr>
        <td>ID:<asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>UserName:<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Name:<asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
    </tr>
</table>

</asp:Panel>
 