<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorAll.aspx.cs" Inherits="AdminPanel.Admin.VendorAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">
        <h3 class="bold">All Vendors
        </h3>

        <table>
            <tr>
                <th style="width: 45px">ID
                </th>
                <th>User Name
                </th>

                <th>Registered Date
                </th>

                <th>Logo
                </th>

                <th>Shop Name
                </th>

                <th>Contact Number
                </th>

                <th>Country
                </th>

                <th>City
                </th>

                <th>Zip
                </th>

                <th>State
                </th>

                <th>Address
                </th>

                <th>Description
                </th>

                <th>PaypalID
                </th>

                <th>Total Products
                </th>

                <th>Total Products Sold
                </th>

                <th>Account Status (Inactive users cannot login)
                </th>
                <th>Action
                </th>
            </tr>
            <small>
                <asp:Label ID="lblrowscount" runat="server" Text=""></asp:Label></small>
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>

                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("profileid") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("insertdate") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("logo") %>' />
                        </td>

                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("shopname") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("contactnumber") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("country") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("city") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("zip") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("city") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("ShopDescription") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text='<%#Eval("paypalid") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label14" runat="server" Text='<%#Eval("total_products") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label15" runat="server" Text='<%#Eval("totalproduct_Sold") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            <br />
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CommandName="change" runat="server" CssClass="btn btn-success white-c l-bold btn-xs ">Change Status</asp:LinkButton><br />
                            <br />
                            <asp:LinkButton ID="LinkButton2" CommandName="del" OnClientClick="return confirm('Are you sure you want to delete ?')" runat="server" CssClass="btn btn-danger white-c l-bold btn-xs ">Delete</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>