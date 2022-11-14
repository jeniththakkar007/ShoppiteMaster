<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="advertisement_all.aspx.cs" Inherits="AdminPanel.Admin.advertisement_all" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="bold">
        <span class="pull-right">

            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/advertisment_add.aspx">Add New Banner</asp:LinkButton></span>
        All Advertisement banner
    </h3>
    <div class="grid">
        <table style="width: 100%;">
            <tr>
                <th style="width: 128px">Action</th>
                <th style="width: 241px">Placement</th>

                <th style="width: 362px">Start & End  Date
                </th>
                <th style="width: 228px">Status</th>
                <th>Image</th>
            </tr>

            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("AdId") %>' Visible="False"></asp:Label>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CommandName="ed" runat="server">Edit</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="LinkButton2" CommandName="del" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?')">Delete</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Placement") %>'></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("PageName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("startdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("enddate",  "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                        </td>
                        <td class=" ad-banner">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>