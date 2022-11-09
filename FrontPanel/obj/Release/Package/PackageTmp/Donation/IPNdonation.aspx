<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPNdonation.aspx.cs" Inherits="FrontPanel.Donation.IPNdonation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" UpdateCommand="UPDATE dbo.SessionBooking SET PaymentDate = GETDATE(), Paypalid = @Paypal WHERE (SessionBookingId = @orderId)">
            <UpdateParameters>
                <asp:SessionParameter Name="orderId" SessionField="custom" />
            </UpdateParameters>
        </asp:SqlDataSource>--%>
    </div>
    </form>
</body>
</html>