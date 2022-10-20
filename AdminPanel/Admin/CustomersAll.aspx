<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomersAll.aspx.cs" Inherits="AdminPanel.Admin.CustomersAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">   <h3 class="bold">
            
         
                All Customers
        </h3> 

         

    <table>
    <tr>  <th style="width: 45px">
            ID
        </th>
        <th>
        User Name
        </th>

          <th>
        Registered Date
        </th>

         

            <th>
   Total Purchased
        </th>

        
      
           <th>
Account Status (Inactive users cannot login)
        </th>
      <th>
 <small> <asp:Label ID="lblrowscount" runat="server" Text=""></asp:Label></small>
      </th>
    </tr>
      
    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" >
        <ItemTemplate>
          
             <tr>
      <td>
   <asp:Label ID="Label2"  runat="server" Text='<%#Eval("profileid") %>'></asp:Label>
                 </td>  
                  <td>
      <asp:Label ID="Label1" runat="server" Text='<%#Eval("username") %>'></asp:Label>
           
        </td>

                     <td>
      <asp:Label ID="Label3" runat="server" Text='<%#Eval("insertdate") %>'></asp:Label>
           
        </td>

                     

                 <td>
      <asp:Label ID="Label14" runat="server" Text='<%#Eval("total_purchased") %>'></asp:Label>
           
        </td>

                     <td>
      <asp:Label ID="Label4" runat="server" Text='<%#Eval("status") %>'></asp:Label>
               </td>
                <td>
 <asp:LinkButton ID="LinkButton1" CommandName="change" runat="server" CssClass="btn btn-success white-c l-bold btn-xs ">Change Status</asp:LinkButton>
                       <asp:LinkButton ID="LinkButton2" CommandName="del" OnClientClick="return confirm('Are you sure you want to delete ?')"  runat="server" CssClass="btn btn-danger white-c l-bold btn-xs ">Delete</asp:LinkButton>
    
                </td>
                
    </tr>
            

        </ItemTemplate>
    </asp:ListView>

        </table> </div>
</asp:Content>
