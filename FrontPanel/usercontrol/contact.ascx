<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact.ascx.cs" Inherits="leaveittome.usercontrol.contact" %>



<div class="form-group">
    Name
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="TextBox1" Display="Dynamic" ValidationGroup="con"></asp:RequiredFieldValidator>


</div>


<div class="form-group">
   Email
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="TextBox2" Display="Dynamic" ValidationGroup="con"></asp:RequiredFieldValidator>


</div>

<div class="form-group">
Phone
     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="TextBox3" Display="Dynamic" ValidationGroup="con"></asp:RequiredFieldValidator>

</div>
<div class="form-group w-100">
Your Message
     <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="TextBox4" Display="Dynamic" ValidationGroup="con"></asp:RequiredFieldValidator>

</div>

<div class="form-group w-100">
    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="con" OnClick="Button1_Click" />

    </div>