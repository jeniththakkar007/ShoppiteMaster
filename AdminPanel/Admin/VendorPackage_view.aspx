<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorPackage_view.aspx.cs" Inherits="AdminPanel.Admin.VendorPackage_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c pull-right" PostBackUrl="~/Admin/VendorPackages.aspx">Add New Package</asp:LinkButton>
    <h3>Vendor Packages</h3>

    <div class="grid">

        <asp:GridView ID="GridView1" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="MembershipType" HeaderText="Membership Type" ReadOnly="True" SortExpression="MembershipType" />
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" SortExpression="Title" />
                <asp:BoundField DataField="RecurringPeriod" HeaderText="Recurring Period" ReadOnly="True" SortExpression="RecurringPeriod" />
                <asp:BoundField DataField="CurrencyName" HeaderText="Currency Name" ReadOnly="True" SortExpression="CurrencyName" />
                <asp:BoundField DataField="Fees" HeaderText="Fees" ReadOnly="True" SortExpression="Fees" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" ReadOnly="True" SortExpression="CreatedDate" />
                <asp:BoundField DataField="IsActive" HeaderText="Is Active" ReadOnly="True" SortExpression="IsActive" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>