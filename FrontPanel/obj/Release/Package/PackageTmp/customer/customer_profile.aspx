<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customer_profile.aspx.cs" Inherits="FrontPanel.customer.customer_profile" %>

<%@ Register Src="~/usercontrol/ImageUploadJquery_uc.ascx" TagPrefix="uc1" TagName="ImageUploadJquery_uc" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

           <div class="paddingtb-15 ">
               <div class="container">
                   <div class="h3 padding15 center bold">
                       Customer Profile
                   </div>
               <br />
                       <div class="row box-center">
                           <div class="col-md-7 white-bg radius form padding15">
                       
                               <br />
         
                           <div class="paddingtb">
                               Profile Image
                            <uc1:ImageUploadJquery_uc runat="server" ID="ImageUploadJquery_uc" />
</div>
                              




                               <div class="textbox-2">
    <div class="form-group">
       Public Name
         <asp:TextBox ID="txtshopname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="txtshopname" CssClass="required"></asp:RequiredFieldValidator>
    </div>
<div class="form-group">
     Tag line
         <asp:TextBox ID="tagline" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" ControlToValidate="tagline" CssClass="required"></asp:RequiredFieldValidator>
    </div>


</div>
<div class="textbox-2">
    
 <div class="form-group">
        Phone
        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" ControlToValidate="txtphone" CssClass="required"></asp:RequiredFieldValidator>
    </div>
<div class="form-group">
    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
   
    


</div>
</div>


 



                           </div>
                       </div>
                       
                 

               </div>
               </div>


</asp:Content>
