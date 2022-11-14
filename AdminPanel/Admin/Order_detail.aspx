<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order_detail.aspx.cs" Inherits="AdminPanel.Admin.Order_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Order Print</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

    <div class="padding15">

        <div class="row">
            <div class="col-md-8">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return PrintPanel();" CssClass="btn blue-bg margin15 white-c pull-right btn">Print Invoice</asp:LinkButton>

                <asp:Panel ID="pnlContents" runat="server">
                    <div class="white-bg padding15">
                        <h4 class="bold upp">Order #
                            <asp:Label ID="lblorderid" runat="server" Text=""></asp:Label>
                        </h4>
                        <br />

                        <table style="width: 50%;">
                            <tr class="padding10">
                                <td>Order Date</td>
                                <td>
                                    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr class="padding10">
                                <td>Order Status</td>
                                <td>
                                    <asp:Label ID="lblorderstatus" runat="server" Text="Pending" CssClass="bold"></asp:Label></td>
                            </tr>

                            <tr class="padding10">
                                <td>Payment Method</td>
                                <td>
                                    <asp:Label ID="lblpaymenttype" runat="server"></asp:Label></td>
                            </tr>

                            <tr class="padding10">
                                <td>Remarks</td>
                                <td>
                                    <asp:Label ID="lblremarks" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>

                        <br />

                        <asp:ListView ID="ListView1" runat="server">

                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("orderid") %>' Visible="false"></asp:Label>

                                <table style="width: 100%; border: solid 1px #eee; padding: 10px;">
                                    <td style="width: 50%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" ImageUrl='<%# Eval("image") %>' CssClass=" padding5" />
                                                </td>
                                                <td>
                                                    <h5>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                                        <br />
                                                        <small><%# Eval("OrderVariation") %></small>
                                                    </h5>
                                                    <h5><small>Qty:</small>

                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("qty") %>'></asp:Label>
                                                    </h5>
                                                    <span class="bold">
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("orderdeliverystatus") %>' CssClass=""></asp:Label>
                                                        :
                                                       <asp:Label ID="Label10" runat="server" Text='<%# Eval("orderdeliverystatusdate") %>' CssClass="m-bold"></asp:Label></span>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%; padding: 10px;">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 170px">Price</td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Price") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Shipping</td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("deliveryfees") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Vat</td>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("Vat") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Tax
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="bold">
                                                <td>Sub Total
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("totalPrice","{0:#,##0.00}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>

                        <table style="width: 100%; font-size: 20px; border: solid 1px #eee" class="bold">
                            <tr>
                                <td style="width: 50%"></td>
                                <td style="width: 170px; padding: 10px;">Total:</td>
                                <td>
                                    <asp:Label ID="lbltotal" runat="server" Text="0" CssClass="red-c"></asp:Label>
                                </td>
                            </tr>
                        </table>

                        <br />
                        <br />
                        <table style="width: 100%;">
                            <tr class="padding10">

                                <td style="vertical-align: top; font-weight: bold">Shipping Detail </td>
                                <td style="vertical-align: top;">
                                    <asp:Label ID="lblshipping" runat="server" Text=""></asp:Label></td>

                                <td style="vertical-align: top; font-weight: bold;">Seller Detail:
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:Label ID="lblsellerdetail" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>

            <div class="col-md-3">
                <div class="white-bg padding15">
                    <h4>Mark Order Status
                    </h4>
                    <hr />
                    <div class="form form-horizontal">
                        <div class="form-group checkright">
                            Status:
               <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                   <asp:ListItem Selected="True">Pending</asp:ListItem>
                   <asp:ListItem>Delivered</asp:ListItem>
                   <asp:ListItem>Cancelled</asp:ListItem>
                   <asp:ListItem>Completed</asp:ListItem>
                   <asp:ListItem>Request Cancellation</asp:ListItem>
               </asp:RadioButtonList>
                        </div>

                        <div class="form-group">
                            Remarks/Shipping Details:
                <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtreason"
                                CssClass="text-danger" ErrorMessage="Field is Required." SetFocusOnError="True" ValidationGroup="camcel" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" ValidationGroup="camcel" Text="Update Status" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>