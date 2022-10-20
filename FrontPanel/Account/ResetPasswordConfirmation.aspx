<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="FrontPanel.Account.ResetPasswordConfirmation1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <div class="alice-bg">
        <div class="container">
          
            <div class="padding-top-100 padding-bottom-100">
   
            
            <div class="padding dashboard-form text-center row">
                <div class="col-md-3"></div>
            <div class="col-md-6 white-bg padding radius">
        <h5>
          Your password has been changed.  
            <br />
            <small>

            </small>
        </h5>
                <br />
                <br />
                <div class="row"><div class="col-md-3"></div>
                    <div class="col-md-6"> <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login" CssClass="button primary-bg btn-block">Login into Your Account</asp:HyperLink>

                    </div>
                </div>
               

                </div>
</div>
       
    </div></div>

            </div>

        
</asp:Content>
