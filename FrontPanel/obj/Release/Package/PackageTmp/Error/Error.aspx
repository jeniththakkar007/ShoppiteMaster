<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="FrontPanel.Error.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


      <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="box-center">
        <div class="confirmation">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/orderconformation.png" />

            <h1>
               Oops
            </h1>
            <h5>

       
     <strong>  <asp:Label ID="lblerror" runat="server" Text=""></asp:Label></strong>     </h5>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg black-c" PostBackUrl="~/Default">Exciting Deals are available here</asp:LinkButton></div>
    </div>
</asp:Content>
