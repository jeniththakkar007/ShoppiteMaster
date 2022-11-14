<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationReport.aspx.cs" Inherits="AdminPanel.Admin.DonationReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">
        <h3 class="bold">Donation Report
        </h3>

        <table>
            <tr>
                <th>Total Amount
                </th>

                <th>Administrative amount
                </th>

                <th>Community Fund
                </th>

                <th>Payment Date
                </th>

                <th>Paypal Id
                </th>
            </tr>
            <small>
                <asp:Label ID="lblrowscount" runat="server" Text=""></asp:Label></small>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>

                    <tr>

                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("totalamount") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("administrativefund") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Communittyfund") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("paymentdate") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("paypalid") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>