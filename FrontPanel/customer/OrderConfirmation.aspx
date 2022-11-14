<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="FrontPanel.customer.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="box-center">
        <div class="confirmation">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/orderconformation.png" />

            <h1>Order Confirmation
            </h1>
            <h5>

                <strong>Order #
                    <asp:Label ID="lblorder" runat="server" Text="Label"></asp:Label></strong>  has been placed successfully and an invoice has been emailed to you.     </h5>
            <asp:LinkButton Visible="false" ID="LinkButton1" runat="server" CssClass="btn theme-bg white-c" PostBackUrl="~/customer/MyOrders.aspx">BACK TO STORE</asp:LinkButton><div class="container">
                <br />
                <br />
                <div class="row left">
                    <div class="white-bg radius padding15 form">
                        <h4>Order Details
                        </h4>
                        <hr />
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>

                                <asp:Label ID="lblorderid" Visible="false" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
                                <div class="row">
                                    <div class="col-md-1 col-xs-2 border padding5 center d-none cart">
                                        <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" ImageUrl='<%#Eval("image") %>' />
                                    </div>

                                    <div class="col-md-11 o-padding">
                                        <div class="pull-right">

                                            <div class="pull-right paddingrf-15">
                                                <div class="number">
                                                    QTY
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("qty") %>' CssClass="bold"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <br class="m-block" />
                                        <br class="m-block">
                                        <div>
                                            <%#Eval("ProductName") %>
                                            <br />

                                            <span class="grey-c">
                                                <%#Eval("ordervariation") %>
                                            </span>
                                            <br />
                                            <span class="fonts bold">
                                                <%#Eval("Price") %>  <%#Eval("currencyname") %></span>

                                            <div class=" paddingrf-15 pull-right">
                                                <br />
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 70px;">
                                                            <asp:Label ID="Label2" runat="server" Text="Total: "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Total") %>' CssClass="fonts red-c s-bold"></asp:Label>
                                                            <%#Eval("currencyname") %></td>
                                                    </tr>

                                                    <tr>

                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text="Shipping:"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("shipping") %>' CssClass="fonts black-c s-bold"></asp:Label>
                                                            <%#Eval("currencyname") %> </td>
                                                    </tr>

                                                    <tr>

                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text="Vat:"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("vat") %>' CssClass="fonts black-c s-bold"></asp:Label>
                                                            <%#Eval("currencyname") %></td>
                                                    </tr>

                                                    <tr>

                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text="Tax:"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("Tax") %>' CssClass="fonts black-c s-bold"></asp:Label><%#Eval("currencyname") %></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <hr />
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>