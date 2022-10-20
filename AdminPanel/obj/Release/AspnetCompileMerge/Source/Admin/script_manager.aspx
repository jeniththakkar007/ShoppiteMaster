<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="script_manager.aspx.cs" Inherits="AdminPanel.Admin.script_manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div class="padding5">
      <h3 class="bold padding10 no-margin">  
         
   Script Manager
           
        </h3>
   </div>
       <div class="row">  <div class="col-md-4 white-bg">
<h4>Add Sciprt</h4>
        <hr />
    <div class="form form-horizontal margin10  ">


        
                <div class="form-group checkright">
                Type
                   <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                       <asp:ListItem>Header</asp:ListItem>
                       <asp:ListItem Selected="True">Footer</asp:ListItem>
                   </asp:RadioButtonList>
            </div>   <div class="form-group">
                Title
                   <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txttitle" Display="Dynamic" ValidationGroup="script"></asp:RequiredFieldValidator>

            </div>
  
           <div class="form-group">
              Script
                   <asp:TextBox ID="txtscript" runat="server" TextMode="MultiLine"></asp:TextBox>  
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtscript" Display="Dynamic" ValidationGroup="script"></asp:RequiredFieldValidator>

            </div>
        <hr />
        <div class="form-group">
            <asp:Button ID="Button1" ValidationGroup="script" runat="server" Text="Save" OnClick="Button1_Click" />
        </div>
         
        </div> </div>


           <div class="col-md-8 grid">

               <table style="width: 100%;">
                   <tr>
                       <th style="width: 100px">Script ID</th>
                       <th style="width: 486px">Title</th>
                      
                       <th colspan="2">Action</th>
                   </tr>
              
                
            
               <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                   <ItemTemplate>
     <tr>
                       <td>  <asp:Label ID="lblid" runat="server" Text='<%#Eval("Scriptid") %>'></asp:Label></td>
                       <td>   <%#Eval("title") %></td>
                       <td> <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ed" CssClass="edit"></asp:LinkButton></td>
         <td> <asp:LinkButton ID="LinkButton2"  OnClientClick="return confirm('Are you sure you want to delete ?')"   runat="server" CommandName="del" CssClass="delete"></asp:LinkButton>
              </td>
                   </tr>
                     


                    
                       
                       
                     
                            </ItemTemplate>
               </asp:ListView>   </table>
           </div>

       </div>

</asp:Content>
