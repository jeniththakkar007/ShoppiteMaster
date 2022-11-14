<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="googleauth.aspx.cs" Inherits="FrontPanel.SocialMediaLogin.googleauth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>

                    <td>
                        <%--<asp:Image ID="imgprofile" runat="server" Height="100px" Width="100px" />--%>
                    </td>

                    <td>
                        <asp:Image ID="imgprofile" runat="server" Height="100px" Width="100px" />
                        <%--<asp:Image ID="imgprofile" runat="server" Height="100px" Width="100px" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Id
                    </td>
                    <td>
                        <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">Name
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                        <%--<asp:Label ID="lblname" runat="server" Text=""></asp:Label>--%>
                    </td>
                </tr>

                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>locale
                    </td>
                    <td>
                        <asp:Label ID="lbllocale" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>link
                    </td>
                    <td>
                        <asp:HyperLink ID="hylprofile" runat="server">Profile link</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>email:</td>
                    <td>
                        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <asp:Literal runat="server" ID="ErrorMessage" />
    </form>
</body>
</html>