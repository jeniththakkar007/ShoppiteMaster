<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membershipsusbcription.aspx.cs" Inherits="VendorPanel.Admin.Membershipsusbcription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Membership Payment</h3>
    <div class="grid">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MembershipId" HeaderText="Membership ID" ReadOnly="True" SortExpression="MembershipId"></asp:BoundField>
                <asp:BoundField DataField="IsFree" HeaderText="Is Free" ReadOnly="True" SortExpression="IsFree"></asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" ReadOnly="True" SortExpression="StartDate"></asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="End Date" ReadOnly="True" SortExpression="EndDate"></asp:BoundField>
                <asp:BoundField DataField="MembershipFee" HeaderText="Membership Fee" ReadOnly="True" SortExpression="MembershipFee"></asp:BoundField>
                <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" ReadOnly="True" SortExpression="PaymentDate"></asp:BoundField>
                <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" ReadOnly="True" SortExpression="PaymentMode"></asp:BoundField>
                <asp:BoundField DataField="ReferenceId" HeaderText="Reference Id" ReadOnly="True" SortExpression="ReferenceId"></asp:BoundField>
                <asp:BoundField DataField="MembershipStatus" HeaderText="Membership Status" ReadOnly="True" SortExpression="MembershipStatus"></asp:BoundField>
                <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" ReadOnly="True" SortExpression="PaymentStatus"></asp:BoundField>
                <asp:BoundField DataField="CancelStatus" HeaderText="Cancel Status" ReadOnly="True" SortExpression="CancelStatus"></asp:BoundField>

                <asp:BoundField DataField="Cancellationdate" HeaderText="Cancellation Date" ReadOnly="True" SortExpression="Cancellationdate"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>