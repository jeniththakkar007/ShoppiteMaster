<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="vendor_package_uc.ascx.cs" Inherits="VendorPanel.usercontrol.vendor_package_uc" %>

<div class="row box-center">
    <asp:ListView ID="ListView1" runat="server">

        <ItemTemplate>
            <div class="col-md-4">
                <div class="border radius padding15 white-bg   shadow">
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Membershipid") %>' Visible="false"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("recurringperiod") %>' Visible="false"></asp:Label>
                    <h2 class="center">
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                    </h2>
                    <h3 class="red-c bold center">

                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("currency") %>'></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("fees") %>'>    </asp:Label>/<asp:Label ID="Label6" runat="server" Text='<%#Eval("unit") %>'>    </asp:Label>
                    </h3>
                    <p class="left padding15">
                        <asp:Label ID="lbltitle" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </p>
                    <a class="btn green-bg white-c w-100" href="/Vendor/paymentmethod?ID=<%#Eval("Membershipid") %>">Subscribe Now!</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>