<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Commission_Report.aspx.cs" Inherits="AdminPanel.Admin.Commission_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="grid col-md-3">
            <h5 class="bold">Summary
            </h5>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
    </div>
    <br />
    <br />
    <h5 class="padding10 bold">Detail
    </h5>
    <div class="white-bg padding5">
        <div class="checkright">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem Value="Paid Disbursement">Paid Disbursement</asp:ListItem>
                <asp:ListItem Selected="True" Value="Balance Disbursement">Balance Disbursement</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <div class="grid">

            <asp:GridView ID="GridView1" DataKeyNames="OrderId" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

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
                    <asp:BoundField DataField="PaypalId" HeaderText="Disbursement Paypal ID" ReadOnly="True" SortExpression="PaypalId"></asp:BoundField>
                    <asp:CommandField SelectText="Click Me When Paid" ControlStyle-CssClass="btn btn-success white-c" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>