<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminPanel.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<%@ Register Src="~/usercontrol/Logo_uc.ascx" TagPrefix="uc" TagName="Logo_uc" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="../Content/noheader.css" rel="stylesheet" />
    <div class="container ">
        <div class="row box-center margintb" onkeypress="return WebForm_FireDefaultButton(event, '<%= loginbtn.ClientID %>')">

            <div class="col-md-5 padding15 ">
                <div class="img-box h-220">
                    <uc:Logo_uc runat="server" ID="Logo_uc" />
                </div>
                <div class="padding15 white-bg border l-grey-bd radius ">
                    <h3 class="center upp bold">Admin Panel </h3>
                    <hr />
                    <%--    <a class="btn facebook-btn ">Login in with Facebook </a>
                <a class="btn google-btn ">Login in with Google </a>

                <div class="or-div"><span>or</span></div>--%>

                    <section id="loginForm">
                        <div class="form form-horizontal">

                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="true">
                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="FailureText" />
                                </p>
                            </asp:PlaceHolder>
                            <div class="form-group">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtemail" placeholder="Email Address" TextMode="Email" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/envelop.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail"
                                    CssClass="text-danger" ErrorMessage="The email field is required." SetFocusOnError="True" ValidationGroup="login" />
                            </div>
                            <div class="form-group">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" placeholder="Password" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/lock.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpassword" ValidationGroup="login" SetFocusOnError="True" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                            <div class="form-group">

                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="c-green-c pull-right" CausesValidation="False" PostBackUrl="~/Account/Forgot.aspx">Forgot Password</asp:LinkButton> --%>
                                </div>
                            </div>
                            <div class="form-group paddingtb-15">

                                <asp:Button runat="server" OnClick="LogIn" ID="loginbtn" Text="Log in" CssClass="w-100" ValidationGroup="login" OnClientClick="if (!Page_ClientValidate('login')){ return false; } this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="False" />
                            </div>
                            <%--   <p class="center">

                       Email: <strong>admin
</strong> <br />
            Password: <strong>software </strong>
               </p> --%>
                        </div>

                        <h5 class="right">
                            <asp:HyperLink runat="server" ID="RegisterHyperLink" Visible="false" ViewStateMode="Disabled" CssClass="c-green-c bold">Sign up</asp:HyperLink>
                        </h5>

                        <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                        --%>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <%--   <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>--%>
</asp:Content>