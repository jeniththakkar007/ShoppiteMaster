<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="googlelogin.ascx.cs" Inherits="FrontPanel.SocialMediaLogin.googlelogin" %>

<asp:Label ID="lblerror" runat="server" Text="" ForeColor="red"></asp:Label>
<asp:LinkButton ID="btnLogin" runat="server" OnClick="GoogleLogin">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/l-googlep.png" Width="55px" />
</asp:LinkButton>

<asp:Panel ID="pnlProfile" runat="server" Visible="false">
    <hr />
    <table>
        <tr>
            <td rowspan="6" valign="top">
                <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
            </td>
        </tr>
        <tr>
            <td>ID:
            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Name:
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Email:
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Gender:
            <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Type:
            <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
</asp:Panel>