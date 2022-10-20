<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="FundRequest.aspx.cs" Inherits="FrontPanel.Donation.FundRequest" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/usercontrol/ImageUploadJquery_uc.ascx" TagPrefix="uc1" TagName="ImageUploadJquery_uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/noheader.css" rel="stylesheet" />
      <div class="container ">
    <div class="row box-center margintb"  onkeypress="return WebForm_FireDefaultButton(event, '<%= Button1.ClientID %>')">
       
        <div class="col-md-8 padding15 form">

       
            <div class="padding15 white-bg border l-grey-bd radius ">   
                <h3 class="center">
            Requested for Funds  </h3>
                <hr />

    
       
       <uc1:ImageUploadJquery_uc runat="server" ID="ImageUploadJquery_uc" />

                <div class="textbox-2">

                      <div class="form-group">
    Payal ID to Receive Funds:<asp:TextBox ID="txtpaypalid" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtpaypalid"  ValidationGroup="donation" Display="Dynamic"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="True" runat="server" CssClass="required" ValidationGroup="donation" ControlToValidate="txtpaypalid" ErrorMessage="Valid email is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>

                      </div>
  <div class="form-group">
    Title:<asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txttitle"  ValidationGroup="donation" Display="Dynamic"></asp:RequiredFieldValidator>
                      </div>
 <div class="form-group">
    Required Funds:<asp:TextBox ID="txtrequiredfunds" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtrequiredfunds"  ValidationGroup="donation" Display="Dynamic"></asp:RequiredFieldValidator>
        </div> 
                </div>
                  <div class="form-group">
    Description:<asp:TextBox ID="txtdescription" TextMode="MultiLine" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdescription"  ValidationGroup="donation" Display="Dynamic"></asp:RequiredFieldValidator>
  </div>  <div class="form-group checkright">
            <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtrequiredfunds_FilteredTextBoxExtender" TargetControlID="txtrequiredfunds" ID="txtrequiredfunds_FilteredTextBoxExtender" FilterType="Custom,Numbers" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender>
<asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="donation" OnClick="Button1_Click" OnClientClick="if (!Page_ClientValidate('donation')){ return false; } this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="False" />
    
    <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" Text="Is Active:" />
   <br />
    
              </div>  
       <script>
                                    $(document).ready(function () {
                                        //$('#summernote').summernote();


                                        $('[id*=txtdescription]').summernote()
                                    });
  </script>


      <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
<script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>

                </div>     </div>     </div>     </div>

</asp:Content>
