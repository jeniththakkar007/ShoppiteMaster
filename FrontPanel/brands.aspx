<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="brands.aspx.cs" Inherits="FrontPanel.brands" %>

<%@ Register Src="~/usercontrol/search_allproducts.ascx" TagPrefix="uc1" TagName="search_allproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row margintb-15">
            <h4 class="no-margin padding5">Products By Brand
                </h4>
            <div class="row ">
                <uc1:search_allproducts runat="server" ID="search_allproducts" />
            </div>
        </div>
    </div>
</asp:Content>