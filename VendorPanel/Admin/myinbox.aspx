<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="myinbox.aspx.cs" Inherits="VendorPanel.Admin.myinbox" %>

<%@ Register Src="~/inbox/chat.ascx" TagPrefix="uc1" TagName="chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h3 class="bold">Inbox
        </h3>
        <uc1:chat runat="server" ID="chat" />

        <div id="dvhours" style="display: none">
            <asp:Label ID="lblbprogrss" runat="server" CssClass="loading">     <i class="fas fa-spinner fa-pulse fa-3x color" style="z-index:100000;"></i> </asp:Label>
        </div>

        <script type="text/javascript">
        function myFunction() {

            document.getElementById("dvhours").style.display = "block";

            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblbprogrss.ClientID %>").style.display = "none";
            }, seconds * 1000);

        }
        </script>

        <style>
            .loading {
                position: fixed;
                top: 0;
                left: 0;
                background-color: black;
                z-index: 99;
                opacity: 0.8;
                filter: alpha(opacity=80);
                -moz-opacity: 0.8;
                min-height: 100%;
                width: 100%;
            }

                .loading i {
                    position: fixed;
                    top: 50%;
                    right: 50%;
                    color: white;
                }
        </style>
    </div>
</asp:Content>