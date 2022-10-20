<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order_Master.aspx.cs" Inherits="VendorPanel.Admin.Order_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container white-bg">   
         <h2>
        All Orders
    </h2>
        <div class="row">
       

  
        
            <div class="form checkright padding15">
                Search by Order ID
                <asp:TextBox ID="txtsearch" runat="server" Width="200px"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg white-c" OnClick="LinkButton1_Click">Search</asp:LinkButton>

                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="pull-right" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Pending</asp:ListItem>
                    <asp:ListItem>Delivered</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                     <asp:ListItem>Request Cancellation</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div></div>
    
    <div class="row bold border m-none padding5">
        <div class="col-md-2">Order ID</div>
             <div class="col-md-2"> Order Date </div>
             <div class="col-md-2">Total Price</div>
             <div class="col-md-2">Delivery Status</div>
             <div class="col-md-2">Delivery Sttatus Date</div>
        <div class="col-md-2 right">
            Action
        </div>
        </div>

 

    <asp:ListView ID="ListView1" runat="server">

        <EmptyDataTemplate>

           <div class="box-center">
                            <div class="confirmation white-bg">
                               
                                <h3>No Result Found
                                   
                                </h3>
                            </div>
                        </div>
        </EmptyDataTemplate>
        <ItemTemplate> <div class="row border padding5">
        <div class="col-md-2">  <asp:Label ID="lblorderid" runat="server" Text='<%#Eval("orderid") %>'></asp:Label></div>
             <div class="col-md-2"> <asp:Label ID="lblorderdate" runat="server" Text='<%#Eval("orderdate", "{0:MMM dd,yyyy}") %>'></asp:Label></div>
             <div class="col-md-2">   <asp:Label ID="lblamount" runat="server" Text='<%#Eval("totalPrice" , "{0:#,0}") %>'></asp:Label></div>
             <div class="col-md-2">  <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("orderdeliverystatus") %>'></asp:Label></div>
             <div class="col-md-2"> 
               <asp:Label ID="lbldeliverydate" runat="server" Text='<%#Eval("orderdeliverystatusdate") %>'></asp:Label></div>
             <div class="col-md-2 right">
           <a target="_blank" href="Order_detail?ID=<%#Eval("OrderGUID") %>" class="btn btn-xs green-bg white-c">View Order Detail</a>
                 </div>
        </div>
           
           
           
           
        </ItemTemplate>
    </asp:ListView>

    </div>
</asp:Content>
