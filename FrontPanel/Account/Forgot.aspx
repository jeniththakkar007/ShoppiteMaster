<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="FrontPanel.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

   <div class="container ">
    <div class="row box-center margin-tb">
       
        <div class="col-md-5 padding15 ">

       
            <div class="padding15 white-bg border form l-grey-bd radius ">   
                <h3 class="center">
           Forgot password  </h3>
                <hr />
         
            
               <asp:PlaceHolder id="loginForm" runat="server">
                <div class="form-horizontal" onkeypress="return WebForm_FireDefaultButton(event, '<%= forgot.ClientID %>')">
                  
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                          Enter uour email to recover your password   
                            <asp:TextBox runat="server" ID="Email" placeholder="Email Addess"  TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." Display="Dynamic" ValidationGroup="fg" />
                      <asp:RegularExpressionValidator ControlToValidate="Email" ID="RegularExpressionValidator1" Display="Dynamic" CssClass="text-danger"  runat="server" ErrorMessage="Valid email is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="fg"></asp:RegularExpressionValidator>

                        
                    </div>
                    <div class="form-group">
                      
                            <asp:Button runat="server" OnClick="Forgot" Text="Email Link" ID="forgot" OnClientClick="if (!Page_ClientValidate('fg')){ return false; } this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="False"  />
                       
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="true">
                <p class="text-info">
                   <%-- Please check your email to reset your password.--%>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </p>
            </asp:PlaceHolder>
              
               
             
            </div>
          </div>
        </div>
</div>
</asp:Content>
