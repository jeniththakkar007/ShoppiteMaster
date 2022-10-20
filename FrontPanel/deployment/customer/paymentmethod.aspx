<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paymentmethod.aspx.cs" Inherits="FrontPanel.customer.paymentmethod" %>

<%@ Register Src="~/usercontrol/uc_ordersummury.ascx" TagPrefix="uc1" TagName="uc_ordersummury" %>
<%@ Register Src="~/usercontrol/stripe_uc.ascx" TagPrefix="uc1" TagName="stripe_uc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="white-bg ">
        <div class="container">
            <h4 class="padding15">
             Payment Method
            </h4>
        </div>
    </div>
    <div class="white-smoke-bg paddingtb-15 ">
          <div class="container">
            <div class="row">
                <div class="col-md-8 o-padding">
                     <div class="white-bg radius padding15">
                         <p>
                             Select Payment Gateway
                         </p>
                         <hr />
                         <div class="checkright">

                      
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="w-100" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                           
                         </asp:RadioButtonList>  
                             <asp:RequiredFieldValidator runat="server" SetFocusOnError="True" ControlToValidate="RadioButtonList1"
                                    CssClass="required" Display="Dynamic" ErrorMessage="Please select payment method." ValidationGroup="pay" />
                         </div>
                         <hr />
                         <uc1:stripe_uc runat="server" id="stripe_uc" Visible="false" />
                          <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn theme-bg f-theme pull-right" OnClick="LinkButton2_Click" ValidationGroup="pay">Proceed to Payment</asp:LinkButton>
                         <br />
                         <br />
                  
                         </div>
                    </div>
                <div class="col-md-4">
                    
                <div class="white-bg radius padding15">
                    <h3 class="bold">
                        Order Summary
                    </h3>
                    <hr />
                    <uc1:uc_ordersummury runat="server" ID="uc_ordersummury" />
                    </div>
                </div>
                </div>
              </div>
        </div>


</asp:Content>
