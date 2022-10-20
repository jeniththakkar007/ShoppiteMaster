<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="guestlogin.aspx.cs" Inherits="FrontPanel.Account.guestlogin" %>

<%@ Register Src="~/SocialMediaLogin/googlelogin.ascx" TagPrefix="uc1" TagName="googlelogin" %>
<%@ Register Src="~/SocialMediaLogin/facebooklogin.ascx" TagPrefix="uc1" TagName="facebooklogin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="box-center row">
            <div class=" col-md-7 border radius padding15 margintb">
                <div class="row">
                    <h3 class="center">
                        You are not login...  <br /><small>  Already have account   
      <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Account/Login.aspx" CssClass="orange-c">Click here to Login </asp:LinkButton></small> 
                    </h3>
                    <hr />
                   

                    <div class="padding15">
    
            <h3 class="line30">
            <small>
                    Don’t have an account? </small> <br /> <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Account/Register.aspx" CssClass="orange-c"> Sign up  </asp:LinkButton>  & Get
                </h3>
                        <br />
                <ul>
                    <li>
                        Order Tracking History

                    </li>
                    <li>
                        Quick Order processing

                    </li>
                    <li>
                        Get notification for deals

                    </li>
                    <li>
                        Add product to your wishlist

                    </li>
                    <li>
                        Get Discount Coupon Code
                    </li>
                </ul>
             
                </div>     </div>

          
              
               <div class="or-div"><span>OR</span></div>
              <div class="right">No Thanks!
                <asp:LinkButton ID="LinkButton3" PostBackUrl="~/customer/shippingdetail.aspx" runat="server" CssClass="btn theme-bg f-theme">Continue as Guest</asp:LinkButton></div>
            </div>
        </div>
    </div>


</asp:Content>
