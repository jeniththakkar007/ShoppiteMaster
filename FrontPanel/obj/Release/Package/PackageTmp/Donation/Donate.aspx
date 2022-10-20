<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Donate.aspx.cs" Inherits="FrontPanel.Donation.Donate" %>

<%@ Register Src="~/usercontrol/stripe_uc.ascx" TagPrefix="uc1" TagName="stripe_uc" %>


<%--<%@ Register Src="~/usercontrol/stripe_uc.ascx" TagPrefix="uc1" TagName="stripe_uc" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="../Content/noheader.css" rel="stylesheet" />
    <div class="paddingtb">
    <div class="container">
    <div class="form-center no-form-center row">

       <div class="col-md-6">   
     <asp:Label ID="lbldescription" runat="server" Text="Label" Visible="False"></asp:Label>
         <asp:Label ID="lbltitle" runat="server" Text="Label" Visible="False"></asp:Label>
           <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/donateicon.png" Width="100px" />
                    
                    <h2 class="bold">
                        Donate To Our <span class="theme-c"> Community Fund</span>
                        
                          </h2>
                    <br>

                    <p class="grey-c">
                       Thank you to all who choose to support with a donation.  We truly appreciate your generosity.
                    </p>
                    <br>
           <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/paypal-credit-card-png-15-original.png" Width="90%" />
          
  </div>

    <div class="col-md-4">
    <br class="visisble-xs" />
     <div class="donate">

  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Pay by Paypal</a></li>
    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Pay by Card</a></li>
   
  </ul>

  <!-- Tab panes -->
  <div class="tab-content border paddingtb-15">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <div class="left form marginrf-15">
             
                <div>

 
            <asp:TextBox ID="txtamount" runat="server" OnTextChanged="txtamount_TextChanged" placeholder="Amount Donate" AutoPostBack="True"  CssClass="border2 grey-c padding15 radius30"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ValidationGroup="donate" ID="RequiredFieldValidator1" CssClass="required" runat="server" ErrorMessage="Donation Amount is required" ControlToValidate="txtamount"></asp:RequiredFieldValidator>
                  

                    <div class="border2 padding15 radius30 grey-c">
<asp:Label ID="lbladministrativefees" runat="server" Text="Administrative Fees" ></asp:Label>
                    </div>
 <h4 class="margin10 paddingtb-15 bold">
            Total Donation :   <span class="theme-c">
  
    <asp:Label ID="lblcurrency" runat="server" ></asp:Label> <asp:Label ID="lblamount" runat="server" Text="0"></asp:Label></span>
</h4>
         </div>
            </div> 
           
               
      
      </ContentTemplate>
    </asp:UpdatePanel>
    <div role="tabpanel" class="tab-pane active" id="home"> 
        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="donate" OnClick="Button1_Click" CssClass="btn marginrf-15  theme-bg btn-lg f-theme bold radius30" Width="185px">
            Donate</asp:LinkButton>
        <asp:Label ID="lblpaypalid" Visible="false" runat="server" Text="Label"></asp:Label>
        </div>
    <div role="tabpanel" class="tab-pane" id="profile">
        
        <div class="form marginrf-15 donation">
        <uc1:stripe_uc runat="server" id="stripe_uc" /></div>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="btn marginrf-15  theme-bg btn-lg f-theme bold radius30" Width="185px">Donate</asp:LinkButton>   </div>
   
  </div>

</div>

    
        
      
           
        

   
    
    </div></div></div>
      </div>

    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
