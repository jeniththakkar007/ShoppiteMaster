<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_shipping.ascx.cs" Inherits="FrontPanel.usercontrol.uc_shipping" %>

<div class="textbox-3">
    <div class="form-group">
        First Name
        <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="txtfirstname" CssClass="required"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        Last Name
        <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="txtlastname" CssClass="required"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        Phone
        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ControlToValidate="txtphone" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>

<div class="form-group">
    Address
        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ControlToValidate="txtaddress" CssClass="required"></asp:RequiredFieldValidator>
</div>
<div class="textbox-3">
    <div class="form-group">
        City
        <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ControlToValidate="txtcity" CssClass="required"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        State
        <asp:TextBox ID="txtstreet" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ControlToValidate="txtstreet" CssClass="required"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        Zipcode
        <asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" ControlToValidate="txtzipcode" CssClass="required"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        Email
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" ControlToValidate="txtemail" CssClass="required"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="True" runat="server" CssClass="required" ControlToValidate="txtemail" ErrorMessage="Valid email is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
    </div>
</div>