<%@ Page Title="Home -" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontPanel._Default" %>

<%@ Register Src="~/usercontrol/ad_middle_uc.ascx" TagPrefix="uc1" TagName="ad_middle_uc" %>
<%@ Register Src="~/usercontrol/slider_homepage.ascx" TagPrefix="uc1" TagName="slider_homepage" %>

<%@ Register Src="~/usercontrol/homepage_statusproducts.ascx" TagPrefix="uc1" TagName="homepage_statusproducts" %>

<%@ Register Src="~/usercontrol/Product_homepage.ascx" TagPrefix="uc1" TagName="Product_homepage" %>

<%@ Register Src="~/usercontrol/thumbnail_slider.ascx" TagPrefix="uc1" TagName="thumbnail_slider" %>

<%@ Register Src="~/usercontrol/homepage_brands.ascx" TagPrefix="uc1" TagName="homepage_brands" %>

<%--<%@ OutputCache VaryByParam="None" VaryByHeader="User-Agent" Location="Any" Duration="3000" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .homepage .dropdown-menu {
            display: block !important;
            height: 400px;
        }

        .sub-header {
            background: var(--white-smoke);
        }

        .category {
            background: var(--theme-color);
            color: var(--f-theme);
        }
    </style>

    <div class="white-smoke-bg">
        <div class="container">

            <div class="row ">
                <div class="col-md-offset-2 col-md-10 slider">

                    <uc1:slider_homepage runat="server" ID="slider_homepage" />
                </div>
            </div>
            <br />
            <script data-ad-client="ca-pub-9279551756710048" async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        </div>

        <div class="container">
            <br />
            <uc1:ad_middle_uc runat="server" ID="ad_middle_uc" />
            <uc1:homepage_statusproducts runat="server" ID="homepage_statusproducts" />

            <uc1:Product_homepage runat="server" ID="Product_homepage" />

            <div class="margintb-15">
                <h4 class="bold no-margin padding5">Brand Zone
                </h4>
                <div class="row home">
                    <uc1:homepage_brands runat="server" ID="homepage_brands" />
                </div>
            </div>

            <div class="margintb-15">
                <%--<h4 class="bold no-margin padding5">  Just For You
                </h4>--%>
                <div class="row home">
                    <uc1:thumbnail_slider runat="server" ID="thumbnail_slider" />
                </div>
            </div>

            <div class="margintb-15">
                <%--  <h4 class="bold no-margin padding5">  Mega Offers
                </h4>--%>
                <div class="row home">
                    <uc1:thumbnail_slider runat="server" ID="thumbnail_slider1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>