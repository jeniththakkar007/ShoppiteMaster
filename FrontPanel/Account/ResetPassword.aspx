<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="FrontPanel.Account.ResetPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


 

 <div class="container ">
    <div class="row box-center margin-tb">
       
        <div class="col-md-5 padding15 ">

       
            <div class="padding15 white-bg border form l-grey-bd radius ">   
                <h3 class="center">
            Reset Password </h3>
                <hr />
         
       
          
              <div class="form-horizontal " onkeypress="return WebForm_FireDefaultButton(event, '<%= Button1.ClientID %>')">
            

   <div class="form-group">    
 
  Your new password here  
            

                     

                            
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Type Your New Password Here" ></asp:TextBox> <br />
         <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
                                CssClass="text-danger" ErrorMessage="The password field is required." Display="Dynamic" ValidationGroup="reset" />
       </div>
                  <div class="form-group">
    <asp:Button ID="Button1" runat="server" Text="Reset Password" OnClick="Button1_Click"  OnClientClick="if (!Page_ClientValidate('reset')){ return false; } this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="False"  />
        </div>
                           
            
 </div>
             
        </div>    </div> </div>    </div>

   
</asp:Content>
