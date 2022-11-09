<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="FrontPanel.Account.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <br />    <br />
    <div class="container">

       <div class="title center margin15">

           
            <h1> Change Password
                
            
            </h1>
              


            </div>
    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="center">

          
            <span class="alert alert-danger "><%: SuccessMessage %></span>  </p>
        </asp:PlaceHolder>

    </div>
        <br/>  <br/>

     <div class="row box-center">
        <div>
             
            
            <div class="form radius white-bg border padding15 " >
            <section id="passwordForm">
               

                <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="true">
                    <p>You're logged in as <strong><%: User.Identity.Name %></strong>.</p>
                    <div class="form-horizontal ">
                       
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group" runat="server" visible="false">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                            <div>
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                               <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="text-danger" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                            <div>
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="text-danger" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                            <div>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                           
                                <asp:Button runat="server" Text="Change password" OnClick="ChangePassword_Click" CssClass="pull-right" ValidationGroup="ChangePassword" />
                            
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>

            <%--<section id="externalLoginsForm">

                <asp:ListView runat="server"
                    ItemType="Microsoft.AspNet.Identity.UserLoginInfo"
                    SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                    <LayoutTemplate>
                        <h4>Registered Logins</h4>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.LoginProvider %></td>
                            <td>
                                <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Remove this " + Item.LoginProvider + " login from your account" %>'
                                    Visible="<%# CanRemoveExternalLogins %>" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <uc:openauthproviders runat="server" returnurl="~/Account/Manage" />
            </section>--%>

        </div>
    </div> </div>
  </div>  <br />     <br />    <br />
</asp:Content>
