<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discount_View.aspx.cs" Inherits="AdminPanel.Admin.Discount_View" %>

<%@ Register Src="~/usercontrol/discount_module_uc.ascx" TagPrefix="uc1" TagName="discount_module_uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="page_title">
    <h1>
     Offer Discount
    </h1>
</div>
    <div class="form">
        <div class="row">
            <div class="col-md-4">
                <div class="white-bg shadow padding15">

              
         
    <uc1:discount_module_uc runat="server" ID="discount_module_uc" />    </div> </div>
        </div>

    </div>
</asp:Content>
