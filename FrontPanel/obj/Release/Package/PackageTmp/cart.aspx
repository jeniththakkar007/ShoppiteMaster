<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="FrontPanel.cart" %>

<%@ Register Src="~/usercontrol/uc_ordersummury.ascx" TagPrefix="uc1" TagName="uc_ordersummury" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/noheader.css" rel="stylesheet" />

    <div class="white-bg ">
        <div class="container">
            <h4 class="padding15">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cart.png" Width="25px" /> Shopping Cart 
            </h4>
        </div>
    </div>
    <div class="white-smoke-bg paddingtb-15 ">
        <div class="container">
            <div class="row">
                <div class="col-md-8 o-padding">
      <div class="white-bg radius padding10">
          <div class="row s-bold">
              <div class="col-xs-10 no-padding">
                  Product
              </div>
                 <div class="col-xs-2 right no-padding">
                     Option
                 </div>
          </div>
       

          <hr />


          <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">

              <EmptyDataTemplate>
                    <div class="box-center">
               <div class="confirmation">
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cart.png" />
                   <h3>
                    
                       
Your cart is Empty
                   </h3>
               </div>
           </div>
              </EmptyDataTemplate>

              <ItemTemplate>

                  <asp:Label ID="lblorderid" Visible="false" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
<div class="row">
                 <div class="col-md-1 col-xs-2 border padding5 center d-none cart">
                     <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                 </div> 
          
              <div class="col-md-11 o-padding"> 
               <div class="pull-right">
                             <%-- <a class="btn btn-default btn-xs grey-c padding5"> <i class="far fa-heart fa-lg"></i> </a>--%>
                   <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CssClass="btn btn-default btn-xs grey-c padding5"> <i class="far fa-trash-alt fa-lg"></i> </asp:LinkButton>  

                     <div class="pull-right paddingrf-15">
                   <div class="number">
	<span class="minus">-</span>
                     <asp:TextBox ID="TextBox2" OnTextChanged="updateorder" AutoPostBack="true" runat="server" Text='<%#Eval("qty") %>' ></asp:TextBox>
	<span class="plus">+</span>
</div>

</div> 
           
            
               
               </div>   <br class="m-block" /><br class="m-block">
                <div>
                    <%#Eval("ProductName") %> <br />
                    
 <span class="grey-c">
                      <%#Eval("ordervariation") %>
                  </span> <br />
   <span class="fonts bold">
                <%#Eval("Price") %>  <%#Eval("currencyname") %></span>
                    
                    
                    <div class=" paddingrf-15 pull-right">  <br />
                        <table style="width: 100%;">
                            <tr>
                                <td style="width:70px;"> <asp:Label ID="Label2" runat="server" Text="Total: "></asp:Label> </td>
                                <td> <asp:Label ID="Label1" runat="server" Text='<%#Eval("Total") %>' CssClass="fonts red-c s-bold"></asp:Label>  <%#Eval("currencyname") %></td> 

                               
                            </tr>

                              <tr>
                                  
                               <td > <asp:Label ID="Label3" runat="server" Text="Shipping:"></asp:Label></td>
                                <td> <asp:Label ID="Label4" runat="server" Text='<%#Eval("shipping") %>' CssClass="fonts black-c s-bold"></asp:Label> <%#Eval("currencyname") %> </td> 
                                  </tr>

                               <tr>
                                   
                                 <td > <asp:Label ID="Label5" runat="server" Text="Vat:"></asp:Label></td>
                                <td> <asp:Label ID="Label6" runat="server" Text='<%#Eval("vat") %>' CssClass="fonts black-c s-bold"></asp:Label> <%#Eval("currencyname") %></td>
                                   </tr>
                             
                               <tr>

                                 <td > <asp:Label ID="Label7" runat="server" Text="Tax:"></asp:Label></td>
                                <td> <asp:Label ID="Label8" runat="server" Text='<%#Eval("Tax") %>' CssClass="fonts black-c s-bold"></asp:Label><%#Eval("currencyname") %></td>
                           
                      </tr>
                        </table>
                
              
                       

                                                                      </div>
                </div>
                 
               
                
                  

              </div>
             
          </div>

            <hr />  
              </ItemTemplate>
          </asp:ListView>
             
             
            </div>
                </div>
            
            <div class="col-md-4 no-padding">

                <div class="white-bg radius padding15">
                    <h3 class="bold">
                        Order Summary
                    </h3>
                    <hr />
                       <uc1:uc_ordersummury runat="server" id="uc_ordersummury" />
                   
                
               

                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn theme-bg f-theme w-100" ValidationGroup="policy" OnClick="LinkButton2_Click">Proceed to Checkout</asp:LinkButton>

                </div>

           
            </div>
            
            </div>
      
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />







</asp:Content>
