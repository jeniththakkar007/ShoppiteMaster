<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentmethod.aspx.cs" Inherits="VendorPanel.paymentmethod" %>

<%@ Register Src="~/usercontrol/stripe_uc.ascx" TagPrefix="uc1" TagName="stripe_uc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/roots.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>
 <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500&display=swap" rel="stylesheet"/> 
 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row margintb box-center">
                <div class="col-md-6">
                <div class="white-bg radius padding15">
                         <h4 class="bold">
                            Payment Gateway
                         </h4>
                         <hr />
                         <div class="checkright">

                      
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="w-100" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                           
                         </asp:RadioButtonList>   </div>
                         <hr />
                    <uc1:stripe_uc runat="server" id="stripe_uc" Visible="false" />
                          <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn d-green-bg white-c pull-right w-100" OnClick="LinkButton2_Click" ValidationGroup="pay">Proceed to Payment</asp:LinkButton>
                         <br />
                      </div>   <br />
                  
                         </div>
            </div>
        </div>
    </form>
</body>
</html>
