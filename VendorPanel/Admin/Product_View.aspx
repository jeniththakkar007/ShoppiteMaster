<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_View.aspx.cs" Inherits="VendorPanel.Admin.Product_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="grid">
                <h3 class="bold"><span class="pull-right">

                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/Product_add.aspx">Add New Product</asp:LinkButton></span>
                    All Products
                </h3>

                <table>
                    <tr>
                        <th style="width: 45px">Edit
                        </th>
                        <th>Product Name
                        </th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                        <ItemTemplate>
                            <asp:Label ID="Label2" Visible="false" runat="server" Text='<%#Eval("Productguid") %>'></asp:Label>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" CommandName="ed" runat="server" CssClass="btn green-bg white-c btn-xs">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClientClick="return confirm('Are you sure you want to delete ?')" CommandName="del" CssClass="btn red-bg white-c btn-xs">Delete</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>