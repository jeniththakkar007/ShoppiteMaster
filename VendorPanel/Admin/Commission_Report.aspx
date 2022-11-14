<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Commission_Report.aspx.cs" Inherits="VendorPanel.Admin.Commission_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid">

        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="Paid Disbursement">Paid Disbursement</asp:ListItem>
            <asp:ListItem Selected="True" Value="Balance Disbursement">Balance Disbursement</asp:ListItem>
        </asp:RadioButtonList>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">

            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField DataField="InsertDate" HeaderText="Order Date" ReadOnly="True" SortExpression="InsertDate"></asp:BoundField>
                <asp:BoundField DataField="totaprice" HeaderText="Total Price" ReadOnly="True" SortExpression="totaprice"></asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="Per Unit Price" ReadOnly="True" SortExpression="Price"></asp:BoundField>
                <asp:BoundField DataField="QTY" HeaderText="QTY" ReadOnly="True" SortExpression="QTY"></asp:BoundField>
                <asp:BoundField DataField="Tax" HeaderText="Tax" ReadOnly="True" SortExpression="Tax"></asp:BoundField>
                <asp:BoundField DataField="Vat" HeaderText="VAT" ReadOnly="True" SortExpression="Vat"></asp:BoundField>
                <asp:BoundField DataField="DeliveryFees" HeaderText="Delivery Fees" ReadOnly="True" SortExpression="DeliveryFees"></asp:BoundField>
                <asp:BoundField DataField="Commission" HeaderText="Commission" ReadOnly="True" SortExpression="Commission"></asp:BoundField>
                <asp:BoundField DataField="Donation" HeaderText="Donation" ReadOnly="True" SortExpression="Donation"></asp:BoundField>

                <asp:BoundField DataField="balancedisbursment" HeaderText="Balance Amount After Deduction" ReadOnly="True" SortExpression="balancedisbursment"></asp:BoundField>
                <asp:BoundField DataField="Disbursementamount" HeaderText="Paid Amount" ReadOnly="True" SortExpression="Disbursementamount"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>