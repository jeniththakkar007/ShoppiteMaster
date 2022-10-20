<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rdbimages.aspx.cs" Inherits="FrontPanel.rdbimages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:RadioButtonList runat="server" ID="rblImages" RepeatColumns="3" RepeatLayout="Table"
    RepeatDirection="Horizontal">
</asp:RadioButtonList>
<hr />
<asp:Button Text="Save" runat="server" OnClick="Save" />

    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
