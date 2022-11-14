<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="brand_view.aspx.cs" Inherits="AdminPanel.Admin.brand_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">
        <h3 class="bold"><span class="pull-right">

            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/brand_add.aspx">Add New Brand</asp:LinkButton></span>All Brands
        </h3>
        <table>
            <tr>
                <th style="width: 45px">Edit
                </th>
                <th style="width: 1475px">Name
                </th>
            </tr>

            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton2" CommandName="ed" runat="server" Text="Edit"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="LinkButton3" CommandName="del" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?')"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("BrandID") %>' Visible="False"></asp:Label>

                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("BrandName") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>