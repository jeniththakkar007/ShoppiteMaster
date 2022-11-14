<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="specification_view.aspx.cs" Inherits="AdminPanel.Admin.specification_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">
        <h3 class="bold"><span class="pull-right">

            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/specification_add.aspx">Add New Specification</asp:LinkButton></span>
            All Specifications
        </h3>
        <table>
            <tr>
                <th style="width: 150px">Edit
                </th>
                <th style="width: 1475px">Attribute
                </th>
                <th style="width: 1475px">Specification
                </th>
            </tr>

            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ed" CssClass="btn btn-success white-c l-bold btn-xs">Edit</asp:LinkButton>

                            <asp:LinkButton ID="LinkButton2" CommandName="del" OnClientClick="return confirm('Are you sure you want to delete ?')" runat="server" CssClass="btn btn-danger white-c l-bold btn-xs ">Delete</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("attributename") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("specificationid") %>' Visible="False"></asp:Label>

                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("specificationname") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>