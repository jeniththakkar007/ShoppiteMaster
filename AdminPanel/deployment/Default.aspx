<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminPanel._Default" %>

<%@ Register Src="~/usercontrol/Logo_uc.ascx" TagPrefix="uc1" TagName="Logo_uc" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="img-box h-220">
    <uc1:Logo_uc runat="server" ID="Logo_uc" /></div>


    <h1 class="bold center">
        Welcome to Admin Panel
    </h1></div>
</asp:Content>
