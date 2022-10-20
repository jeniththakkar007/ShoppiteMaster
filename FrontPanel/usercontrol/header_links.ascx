<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header_links.ascx.cs" Inherits="FrontPanel.usercontrol.header_links" %>

   


<asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
    <ItemTemplate>
         <asp:Label ID="Label3" runat="server" Visible="false" Text='<%# Eval("URL") %>'></asp:Label>
       <asp:Label ID="Label4" runat="server" Visible="false" Text='<%# Eval("isurl") %>'></asp:Label>

        <li>  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="pgview">
           
               <asp:Label ID="Label2" runat="server" Visible="false" Text='<%# Eval("PageCategoryId") %>'></asp:Label>
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("PageCategory1") %>'></asp:Label> 

         </asp:LinkButton>  </li>
    </ItemTemplate>

</asp:ListView>


<%--href="/<%# Eval("PageCategoryId") %>/<%# Eval("urlPageCategory") %>/page"--%>