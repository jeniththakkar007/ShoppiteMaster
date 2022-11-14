<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lockout.aspx.cs" Inherits="VendorPanel.Lockout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/roots.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
    <link href="Content/vendor.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <style>
                body {
                    background: white;
                }
            </style>

            <div class="container">

                <div class="white-bg padding15 no-margin center bold radius">
                    <br />

                    <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                    <br />
                    <br />

                    <h4>Your Vendor Panel is just a few click away! </h4>
                </div>

                <div class="member-bg center">
                    <h1 class="bold white-c ">Sell Online with us
                    </h1>
                    <br />

                    <h4 class="white-c">
                        <asp:Label ID="lblcurrencyname" runat="server"></asp:Label>
                        <asp:Label ID="lblfees" runat="server"></asp:Label>
                        /
                        <asp:Label ID="lbltitle" runat="server"></asp:Label>
                    </h4>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn d-grey-bg white-c btn-lg " PostBackUrl="~/vendorpackages.aspx" OnClick="LinkButton1_Click">Start Now</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/membershipbuy.png" Width="90%" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>