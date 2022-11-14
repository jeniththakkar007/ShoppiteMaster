<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="leaveittome.Contact" %>

<%@ Register Src="~/usercontrol/contact.ascx" TagPrefix="uc1" TagName="contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="">
        <div class="">
            <br />
            <h1 class="theme-c bold center">Contact us
            </h1>
        </div>

        <div class="row box-center">
            <div class="col-md-6 form white-bg padding15 border radius">
                <uc1:contact runat="server" ID="contact" />
            </div>
        </div>
    </div>

    <br />
    <br />
</asp:Content>