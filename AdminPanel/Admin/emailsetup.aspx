<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="emailsetup.aspx.cs" Inherits="AdminPanel.Admin.emailsetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="page_title">
    <h1>
     Email Setup
    </h1>
</div>


    <div class="row">
        <div class="col-md-3 border white-bg padding15 form radius shadow">
              <div class="form-group">
                      Email from 
                        <asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" CssClass="required" ControlToValidate="txtemail" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
              <div class="form-group">
                   Password
                        <asp:TextBox ID="txtpaswod" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" CssClass="required" ControlToValidate="txtpaswod" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
              <div class="form-group">
                     SMTP port <br />
            <small>You can get it from your server</small>
                        <asp:TextBox ID="txtsmtpport" runat="server" TextMode="Number"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" CssClass="required" ControlToValidate="txtsmtpport" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
              <div class="form-group">
                      SMTP <br />
            <small>You can get it from your server</small>
                        <asp:TextBox ID="txtsmtp" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" CssClass="required" ControlToValidate="txtsmtp" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
              <div class="form-group">
                  BCC
                        <asp:TextBox ID="txtbcc" runat="server" TextMode="Email"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" CssClass="required" ControlToValidate="txtbcc" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
              <div class="form-group">
                  <asp:Label ID="lblerror" runat="server" Text="" ForeColor="red"></asp:Label>
                  <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                  </div>
       
          
       

        </div>
  </div>

</asp:Content>
