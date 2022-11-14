<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search_categories.ascx.cs" Inherits="FrontPanel.usercontrol.search_categories" %>

<asp:Label ID="catid" runat="server" Text="" Visible="false"></asp:Label>
<div class="border  padding10 line20">

    <div>
        <asp:Label ID="lblmaincat" runat="server" Text="" CssClass="bold"></asp:Label>
    </div>
    <hr />
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <div>

                <a href="/<%#HiddenField1.Value %>/<%# Eval("ID") %>-<%# Eval("path") %>/SC/Category">
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("NAME")%>' CssClass="grey-c"></asp:Label>
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>

<%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=51.38.62.7;Initial Catalog=daraz;User ID=gym;Password=Software@1" ProviderName="System.Data.SqlClient" SelectCommand="SELECT CAST(ID AS nvarchar(20)) + '-' + urlpath AS urlpath, displayorder, catnames, Displayname, NAME, HLevel, PARENT_NAMEID, ID FROM dbo.getcat(@ID) AS getcat_1 ORDER BY catnames">
        <SelectParameters>
            <asp:ControlParameter ControlID="catid" Name="ID" PropertyName="Text" />
        </SelectParameters>
</asp:SqlDataSource>--%>
<asp:HiddenField ID="HiddenField1" runat="server" />