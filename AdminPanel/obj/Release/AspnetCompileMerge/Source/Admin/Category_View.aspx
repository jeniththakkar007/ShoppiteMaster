<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category_View.aspx.cs" Inherits="AdminPanel.Admin.Category_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="white-smoke-bg  sticky padding15">
      <span class="pull-right">
            
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/Add_categories.aspx">Add New Category</asp:LinkButton></span>
        <h3 class="bold">All Categories
        </h3>
    </div>
    <div>
        <div class="grid">  
<table>
    <tr>   <th style="width: 45px">
      Edit
        </th>
        <th style="width: 1506px">
            Name
        </th>
   
     
    </tr>

       
       
    <asp:ListView ID="ListView1" runat="server"  OnItemCommand="ListView1_ItemCommand">

        <ItemTemplate>
            <tr> <td>
                    <asp:LinkButton ID="LinkButton2" CommandName="ed" runat="server" Text="Edit" ></asp:LinkButton> <br />
                 <asp:LinkButton ID="LinkButton3" CommandName="del" runat="server" Text="Delete"  OnClientClick="return confirm('Are you sure you want to delete ?')" ></asp:LinkButton>
                </td>
                <td>      <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:Label>
 <asp:Label ID="Label1" runat="server" Text='<%#Eval("catnames") %>'></asp:Label>
                </td>
        
               
            </tr>
        
            

           
               


            
        </ItemTemplate>

    </asp:ListView>


</table> </div> </div>
   <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=51.38.62.7;Initial Catalog=daraz;User ID=gym;Password=Software@1" ProviderName="System.Data.SqlClient" SelectCommand="sp_getcat" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
</asp:Content>
