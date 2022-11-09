<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" MaintainScrollPositionOnPostback="true" CodeBehind="Product_add.aspx.cs" Inherits="VendorPanel.Admin.Product_add" %>

<%@ Register Src="~/usercontrol/product_info_uc.ascx" TagPrefix="uc1" TagName="product_info_uc" %>
<%@ Register Src="~/usercontrol/product_price_uc.ascx" TagPrefix="uc1" TagName="product_price_uc" %>
<%@ Register Src="~/usercontrol/product_Images_uc.ascx" TagPrefix="uc1" TagName="product_Images_uc" %>
<%@ Register Src="~/usercontrol/product_attribute_uc.ascx" TagPrefix="uc1" TagName="product_attribute_uc" %>
<%@ Register Src="~/usercontrol/seo_uc.ascx" TagPrefix="uc1" TagName="seo_uc" %>
<%@ Register Src="~/usercontrol/Image_uploadasync_uc.ascx" TagPrefix="uc1" TagName="Image_uploadasync_uc" %>
<%@ Register Src="~/usercontrol/imagemultiupload-uc.ascx" TagPrefix="uc1" TagName="imagemultiuploaduc" %>











<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row  box-center">
        <div class="col-lg 8 col-md-12">
  <div class="sticky padding5">
      <h3 class="bold padding10 no-margin">  <span class="pull-right paddingrf-15">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="black-c bold margin5 medium" CausesValidation="False" PostBackUrl="~/Admin/Product_View.aspx">Back to List</asp:LinkButton>
            <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold  h-fonts" OnClick="lnksave_Click"  ValidationGroup="pro" >Save</asp:LinkButton></span>
  
      Add Product 
           
        </h3>
   </div>
    <div class="form form-horizontal margin10 ">
          <asp:Label ID="lblerror" runat="server" Text="" ForeColor="red"></asp:Label>
        <uc1:Image_uploadasync_uc runat="server" ID="Image_uploadasync_uc" />
        <br />
        <uc1:product_info_uc runat="server" id="product_info_uc" />
  
      <div class="row">
          <div class="col-md-8 no-padding">
 <uc1:product_price_uc runat="server" id="product_price_uc" />  
               <br />  
             
              <uc1:imagemultiuploaduc runat="server" ID="imagemultiuploaduc" />
             <%--  <uc1:product_Images_uc runat="server" ID="product_Images_uc" /> --%>
              <br />

         
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>

            
                <uc1:product_attribute_uc runat="server" id="product_attribute_uc" />
                            </ContentTemplate>
              </asp:UpdatePanel>
              <br />
        <uc1:seo_uc runat="server" id="seo_uc" />
          </div>
      </div>
       
       
   
        </div>

        </div>

    </div>
    
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="required"  ValidationGroup="pro" runat="server" />
   
</asp:Content>
