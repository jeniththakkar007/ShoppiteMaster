<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="shippingdetail.aspx.cs" Inherits="FrontPanel.customer.shippingdetail" %>

<%@ Register Src="~/usercontrol/uc_ordersummury.ascx" TagPrefix="uc1" TagName="uc_ordersummury" %>
<%@ Register Src="~/usercontrol/uc_shipping.ascx" TagPrefix="uc1" TagName="uc_shipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="white-bg ">
        <div class="container">
            <h4 class="padding15">Shipping & Review
            </h4>
        </div>
    </div>
    <div class="white-smoke-bg paddingtb-15 ">
        <div class="container">
            <div class="row">
                <div class="col-md-8 o-padding">
                    <div class="white-bg radius padding15 form">
                        <h4>Shipping Details
                        </h4>
                        <hr />

                        <uc1:uc_shipping runat="server" ID="uc_shipping" />
                    </div>
                    <br />
                    <br />
                    <div class="white-bg radius padding15 form">
                        <h4>Review Your Order
                        </h4>
                        <hr />
                        <asp:ListView ID="ListView1" runat="server">
                            <ItemTemplate>

                                <asp:Label ID="lblorderid" Visible="false" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
                                <div class="row">
                                    <div class="col-md-1 col-xs-2 border padding5 center d-none cart">
                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                                    </div>

                                    <div class="col-md-8 o-padding">
                                        <div class="pull-right">
                                        </div>
                                        <br class="m-block" />
                                        <br class="m-block">
                                        <div>
                                            <%#Eval("ProductName") %>
                                            <br />

                                            <span class="grey-c">QTY
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("qty") %>' CssClass="bold"></asp:Label>
                                                ||

       <%#Eval("ordervariation") %>
                                            </span>
                                            <br />
                                            <span class="fonts ">
                                                <%#Eval("Price") %>  <%#Eval("currencyname") %></span>
                                        </div>
                                    </div>

                                    <div class="col-md-3 no-padding">

                                        <table style="width: 100%;">

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
                                            <tr>
                                                <td style="width: 70px;">
                                                    <asp:Label ID="Label2" runat="server" Text="Total: "></asp:Label>
                                                </td>
                                                <td class="fonts red-c bold">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                                                    <%#Eval("currencyname") %></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>

                                <hr />
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>

                <div class="col-md-4 o-padding">

                    <div class="white-bg radius padding15">
                        <h3 class="bold">Order Summary
                        </h3>
                        <hr />
                        <uc1:uc_ordersummury runat="server" ID="uc_ordersummury" />
                        <br />

                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn theme-bg f-theme w-100" OnClick="LinkButton2_Click">Place Order</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>