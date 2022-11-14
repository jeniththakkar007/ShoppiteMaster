<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oops.aspx.cs" Inherits="EcheckCallV2.oops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Oops!</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href='//fonts.googleapis.com/css?family=Capriola' rel='stylesheet' type='text/css'>
    <style type="text/css">
        body {
            font-family: 'Capriola', sans-serif;
        }

        body {
            background: #fff;
        }

        .wrap {
            margin: 0 auto;
            width: 1000px;
        }

        .logo h1 {
            font-size: 200px;
            color: #FF7A00;
            text-align: center;
            margin-bottom: 1px;
            text-shadow: 4px 4px 1px white;
        }

        .logo p {
            color: #B1A18D;
            font-size: 20px;
            margin-top: 1px;
            text-align: center;
        }

            .logo p span {
                color: lightgreen;
            }

        .sub a {
            color: #ff7a00;
            text-decoration: none;
            padding: 5px;
            font-size: 13px;
            font-family: arial, serif;
            font-weight: bold;
        }

        .footer {
            color: white;
            position: absolute;
            right: 10px;
            bottom: 10px;
        }

            .footer a {
                color: #ff7a00;
            }

        @media (max-width:1024px) {
            .logo h1 {
                font-size: 170px;
                margin-top: 140px;
            }

            .wrap {
                width: 100%;
            }

            .footer {
                font-size: 14px;
                line-height: 30px;
            }
        }

        @media (max-width: 991px) {
            .logo h1 {
                font-size: 150px;
            }
        }

        @media (max-width: 768px) {
            body {
                display: -webkit-flex;
                display: flex;
                align-items: center;
                justify-content: center;
                height: 100vh;
                padding: 0;
                margin: 0;
            }

            .logo h1 {
                margin-top: 0px;
            }

            .footer {
                right: 0;
                width: 100%;
                text-align: center;
            }
        }

        @media (max-width: 736px) {
            .logo h1 {
                font-size: 120px;
            }
        }

        @media (max-width: 600px) {
            .logo h1 {
                font-size: 100px;
            }
        }

        @media (max-width: 568px) {
            .logo p {
                font-size: 15px;
                margin-bottom: 5px;
                margin-top: 1px;
            }
        }

        @media (max-width: 480px) {
            .logo p {
                margin-bottom: 10px;
            }
        }

        @media (max-width: 384px) {
            .footer {
                font-size: 13px;
                line-height: 25px;
            }
        }

        @media (max-width: 320px) {
            .logo h1 {
                font-size: 90px;
            }

            .logo p {
                font-size: 14px;
                margin-top: 10px;
                margin-bottom: 15px;
            }

            .footer {
                right: 10px;
                left: 10px;
                width: 94%;
            }
        }

        .auto-style1 {
            width: 100%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="logo">
                <h1>OPPS..!</h1>
                <p>Some thing went wrong. Please try again!</p>
                <div class="sub">
                    <p><a href="../Default">Back to App</a></p>

                    <%-- <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Click here to confirm your understanding" LogoutPageUrl="~/account/login" OnLoggingOut="Unnamed_LoggingOut" />--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>