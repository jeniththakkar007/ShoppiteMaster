<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders_All.aspx.cs" Inherits="AdminPanel.Admin.Orders_All" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="form-group checkright white-bg padding10">
       <h4 class="padding10 no-margin">Order Report</h4>

     <asp:RadioButtonList ID="RadioButtonList1"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">Pending</asp:ListItem>
            <asp:ListItem>Processing</asp:ListItem>
            <asp:ListItem>Received</asp:ListItem>
            <asp:ListItem>Cancelled</asp:ListItem>
        </asp:RadioButtonList>
 
    
    <div class="grid">



   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="X-Small">



        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order ID" ReadOnly="True" SortExpression="OrderId"></asp:BoundField>
           <asp:BoundField DataField="orderdeliverystatus" HeaderText="Delivery Status" ReadOnly="True" SortExpression="orderdeliverystatus">
            <ItemStyle Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField DataField="totalPrice" HeaderText="Total Price" ReadOnly="True" SortExpression="totalPrice"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Per Unit Price" ReadOnly="True" SortExpression="Price"></asp:BoundField>
            <asp:BoundField DataField="QTY" HeaderText="QTY" ReadOnly="True" SortExpression="QTY"></asp:BoundField>
            <asp:BoundField DataField="Tax" HeaderText="Tax" ReadOnly="True" SortExpression="Tax"></asp:BoundField>
            <asp:BoundField DataField="VAT" HeaderText="VAT" ReadOnly="True" SortExpression="VAT"></asp:BoundField>
            <asp:BoundField DataField="DeliveryFees" HeaderText="Delivery Fees" ReadOnly="True" SortExpression="DeliveryFees"></asp:BoundField>
            <asp:BoundField DataField="Commission" HeaderText="Commission" ReadOnly="True" SortExpression="Commission"></asp:BoundField>
            <asp:BoundField DataField="Donation" HeaderText="Donation" ReadOnly="True" SortExpression="Donation"></asp:BoundField>
            <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" ReadOnly="True" SortExpression="OrderStatus"></asp:BoundField>
            <asp:BoundField DataField="InsertDate" HeaderText="Order Date" ReadOnly="True" SortExpression="InsertDate"></asp:BoundField>
            <asp:BoundField DataField="ShopName" HeaderText="Shop Name" ReadOnly="True" SortExpression="ShopName"></asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="Client Name" SortExpression="FirstName"></asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="Client Last Name" SortExpression="LastName"></asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" SortExpression="Address"></asp:BoundField>
            <asp:BoundField DataField="Street" HeaderText="Street" ReadOnly="True" SortExpression="Street"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone"></asp:BoundField>
            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" ReadOnly="True" SortExpression="PaymentMode"></asp:BoundField>
            <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" ReadOnly="True" SortExpression="PaymentDate"></asp:BoundField>
            <asp:BoundField DataField="ReferenceID" HeaderText="Reference ID" ReadOnly="True" SortExpression="ReferenceID"></asp:BoundField>
            <asp:BoundField DataField="Comments" HeaderText="Comments" ReadOnly="True" SortExpression="Comments"></asp:BoundField>
       
        </Columns>
    </asp:GridView>
           </div> </div>
</asp:Content>
