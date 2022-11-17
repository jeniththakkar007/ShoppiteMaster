<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_socialmedia.ascx.cs" Inherits="FrontPanel.usercontrol.uc_socialmedia" %>
<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" SelectCommand="SELECT Icon, URL, Status FROM SocialMedia WHERE (Status = N'Active')"></asp:SqlDataSource>

<asp:ListView ID="ListView6" runat="server" DataSourceID="SqlDataSource6">
    <AlternatingItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IconLabel" runat="server" Text='<%# Eval("Icon") %>' />
            </td>
            <td>
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
            </td>
            <td>
                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
                <asp:TextBox ID="IconTextBox" runat="server" Text='<%# Bind("Icon") %>' />
            </td>
            <td>
                <asp:TextBox ID="URLTextBox" runat="server" Text='<%# Bind("URL") %>' />
            </td>
            <td>
                <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    <EmptyDataTemplate>
        <table runat="server" style="">
            <tr>
                <td>No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <tr style="">
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            </td>
            <td>
                <asp:TextBox ID="IconTextBox" runat="server" Text='<%# Bind("Icon") %>' />
            </td>
            <td>
                <asp:TextBox ID="URLTextBox" runat="server" Text='<%# Bind("URL") %>' />
            </td>
            <td>
                <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IconLabel" runat="server" Text='<%# Eval("Icon") %>' />
            </td>
            <td>
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
            </td>
            <td>
                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                        <tr runat="server" style="">
                            <th runat="server">Icon</th>
                            <th runat="server">URL</th>
                            <th runat="server">Status</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" style=""></td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IconLabel" runat="server" Text='<%# Eval("Icon") %>' />
            </td>
            <td>
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
            </td>
            <td>
                <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>