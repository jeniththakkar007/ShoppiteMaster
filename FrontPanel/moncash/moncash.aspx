<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moncash.aspx.cs" Inherits="FrontPanel.moncash.moncash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form method="post" action="https://sandbox.moncashbutton.digicelgroup.com/Moncash-middleware/Checkout/ZDFkWVJFaDZTVTkzVnpROSBlRkZGZG5aVFYwMXVWRzFsTldWV2FrMUlibGhJWnowOQ==" >
        <input type="hidden" name="amount" value='<%=Request.QueryString["Amount"]%>'/>
        <input type="hidden" name="orderId" value='<%=Request.QueryString["OrderID"]%>'/>
        <input type="image" name="ap_image" src="https://sandbox.moncashbutton.digicelgroup.com/Moncash-middleware/resources/assets/images/MC_button.png"/>
    </form>


<%-- <form id="iformbid" method="post" action="https://test.cashfree.com/billpay/checkout/post/submit">
    <input type="hidden" name="appId" value="19021245091e8fba17e93d99812091"/>
    <input type="hidden" name="orderId" value='<%=Request.QueryString["OrderID"]%>'/>
    <input type="hidden" name="orderAmount" value='<%=Request.QueryString["Amount"]%>'/>
    <input type="hidden" name="orderCurrency" value="INR"/>
    <input type="hidden" name="orderNote" value="test"/>
    <input type="hidden" name="customerName" value="John Doe"/>
    <input type="hidden" name="customerEmail" value="Johndoe@test.com"/>
    <input type="hidden" name="customerPhone" value="9999999999"/>
    <input type="hidden" name="returnUrl" value="http://localhost:4052//cashfree/response?PackageID=<%=Request.QueryString["OrderID"]%>&Status=success" />
    <input type="hidden" name="notifyUrl" value="http://localhost:4052//cashfree/response?PackageID=<%=Request.QueryString["OrderID"]%>&Status=Cancel" />
    <input type="hidden" name="signature" value='<%=Request.QueryString["Signature"]%>'/>
  </form>--%>
    <%--  <button type="submit" class="btn theme-bg f-theme">Submit</button> --%>

   <%-- <script>document.getElementById("redirectForm").submit();</script>--%>

<%--    <script>
    $('#iformbid').submit(function () {
        $.ajax({
            url: $('#iformbid').attr('action'),
            type: 'POST',
            data: $('#iformbid').serialize(),
            success: function (result) {
                window.location = result.payment_redirect_url;
            }
        });
        return false;
    });
  </script>--%>
</body>
</html>
