<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyWishList.aspx.cs" Inherits="FrontPanel.customer.MyWishList" %>
<%@ Register Src="~/usercontrol/search_allproducts.ascx" TagPrefix="uc1" TagName="search_allproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">

   <div class="margintb-15">
 <h4 class="bold no-margin padding5">  My Wish List
                </h4>
       <div class="row ">
       <uc1:search_allproducts runat="server" id="search_allproducts" /></div>
         </div>
 </div>

</asp:Content>
