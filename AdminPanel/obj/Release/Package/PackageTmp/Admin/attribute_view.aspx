<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="attribute_view.aspx.cs" Inherits="AdminPanel.Admin.attribute_view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
        <div class="grid">   <h3 class="bold"><span class="pull-right">
            
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/attribute_add.aspx">Add New Attribute</asp:LinkButton></span>
            All Attributes
        </h3> 
<table>
    <tr> <th style="width: 100px">
           Edit
        </th>
        <th style="width: 1475px">
            Name
        </th>
 
       
    </tr>


    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
        <ItemTemplate>
            <tr>      <td >
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ed" CssClass="btn btn-success white-c l-bold btn-xs">Edit</asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" CommandName="del" OnClientClick="return confirm('Are you sure you want to delete ?')"  runat="server" CssClass="btn btn-danger white-c l-bold btn-xs ">Delete</asp:LinkButton>
                      </td>
                <td>
             <asp:Label ID="Label2" runat="server" Text='<%#Eval("attributeid") %>' Visible="False"></asp:Label>

             <asp:Label ID="Label1" runat="server" Text='<%#Eval("attributename") %>'></asp:Label></td>
          
</tr>
        </ItemTemplate>

    </asp:ListView>
    
    </table>
            </div>
    
</asp:Content>
