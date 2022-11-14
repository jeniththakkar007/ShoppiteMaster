<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="FrontPanel.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/noheader.css" rel="stylesheet" />
    <div class="">
        <div class="container">
            <br>
            <br>
            <div class="white-bg shadow border radius padding15">

                <asp:ListView ID="ListView1" runat="server">
                    <EmptyDataTemplate>
                        <div class="row margintb box-center ">
                            <div class="col-md-8 center">

                                <asp:Image ID="Image1" runat="server" Width="80%" ImageUrl="~/Images/under-construction.png" />
                                <br>
                                <br>
                                <h2>Sorry, we're doing some work on the site
                                </h2>
                            </div>
                        </div>
                    </EmptyDataTemplate>
                    <ItemTemplate>

                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("PageDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <br>
            <br>
        </div>
    </div>
</asp:Content>