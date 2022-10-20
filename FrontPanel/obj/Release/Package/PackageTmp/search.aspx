<%@ Page Title="Search -" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="FrontPanel.search" %>

<%@ Register Src="~/usercontrol/search_categories.ascx" TagPrefix="uc1" TagName="search_categories" %>
<%@ Register Src="~/usercontrol/search_allproducts.ascx" TagPrefix="uc1" TagName="search_allproducts" %>
<%@ Register Src="~/usercontrol/ad_left_uc.ascx" TagPrefix="uc1" TagName="ad_left_uc" %>
<%@ Register Src="~/usercontrol/homepage_brands.ascx" TagPrefix="uc1" TagName="homepage_brands" %>



<%@ OutputCache Duration="120" VaryByParam="*" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

         
 
   <div class="row margintb-15">
       <div class="col-lg-2 padding5 m-none">
        
           <uc1:search_categories runat="server" id="search_categories" />

           <uc1:ad_left_uc runat="server" ID="ad_left_uc" />
       </div>
       <div class="col-lg-10 no-padding">

          <div class="row" style="padding:10px 0px">
                
                <div class="col-md-8 nopadding"> <h5 class="nomargin"> <small> Total Items Found: <asp:Label ID="lbltotalrecords" runat="server" Text="0"></asp:Label></small></h5> </div>
                <div class="col-md-4 nopadding">
<div class="input-group input-group-sm pull-right">
  <span class="input-group-addon" id="sizing-addon3"> Sort By: </span>
 <asp:DropDownList ID="SortList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="SortList_SelectedIndexChanged" Width="68%">
                <asp:ListItem Value="ProductName">Product Name</asp:ListItem>
                    
                <asp:ListItem Value="Price">Price</asp:ListItem>
          
                
          
            </asp:DropDownList> 

               <asp:DropDownList ID="DirectionList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="SortList_SelectedIndexChanged" Width="30%">
             <asp:ListItem>Asc</asp:ListItem>
                    <asp:ListItem>Desc</asp:ListItem>
          
            </asp:DropDownList> 
</div>
                </div>
            </div>
  
        
        <div class="search border radius padding5">
            <span class="padding5">Brands:</span> 
                <div class="row border white-smoke-bd padding10  margin5">

               
                <uc1:homepage_brands runat="server" ID="homepage_brands" /> </div>
            <div class="row">
         
            <div class="col-md-9 no-padding">
 <div class="padding5">
                       Price:  <asp:TextBox ID="txtpricestart" runat="server" CssClass="border white-smoke-bd" Width="50px"></asp:TextBox> - <asp:TextBox ID="txtpriceend" runat="server" Width="50px" CssClass="border white-smoke-bd"></asp:TextBox>
                      
                   </div>
            </div>
 <div class="col-md-3 padding5 right"> 
                 <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-small theme-bg f-theme" OnClick="LinkButton1_Click">Apply Filter</asp:LinkButton>
     
  
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn-small red-bg white-c" OnClick="LinkButton2_Click">Clear Filter</asp:LinkButton>
               
            </div>
   </div>
        </div>
               

           <div class="row">

             
               <uc1:search_allproducts runat="server" id="search_allproducts" />
         

           </div>
       </div>

 

  </div>
 </div>

         
<%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT ProductGUID, ProductName, URLPath, image, category_name,Price, OldPrice FROM dbo.f_getproducts() AS f_getproducts_1 ">
</asp:SqlDataSource>--%>



</asp:Content>
