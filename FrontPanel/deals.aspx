<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="deals.aspx.cs" Inherits="FrontPanel.deals" %>

<%@ Register Src="~/usercontrol/search_allproducts.ascx" TagPrefix="uc1" TagName="search_allproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row margintb-15">
            <uc1:search_allproducts runat="server" ID="search_allproducts" />
        </div>
    </div>
</asp:Content>