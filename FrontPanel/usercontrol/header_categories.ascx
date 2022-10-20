<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header_categories.ascx.cs" Inherits="FrontPanel.usercontrol.header_categories" %>






<div class="dropdown homepage">
    
      <a data-toggle="collapse-side" style="z-index: 1000000;" data-target=".side-collapse" data-target-2=".side-collapse-container" class="pull-right white-c m-block margin15 ">
                <i class="fa fa-times"></i>

            </a>
  <a class="dropdown-toggle category" href=""  id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
    All Departments
    <span class="caret m-none"></span> 
  </a>
  <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
   <asp:ListView ID="ListView1" runat="server" >
    <ItemTemplate>


          <li class=" d-hover">    <span data-toggle="collapse" class="m-block large black-c pull-right" data-target="#collapseExample<%#Container.DataItemIndex%>">
             
               <i class="fas fa-sort-down m-block"></i></span> 
    <a href="/<%# Eval("urlpath") %>/MC/Category">
            <asp:Label ID="Label3" runat="server" Text='<%#Eval("category_id") %>' Visible="false"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text='<%#Eval("category_name") %>'></asp:Label> </a>
            
        
        <ul class="d-hover-content mega-dropdown collapse " id="collapseExample<%#Container.DataItemIndex%>" aria-labelledby="dropdownMenu1">

            <asp:Image ID="Image1" runat="server"  CssClass="h-c-banner" ImageUrl='<%#Eval("Banner") %>'  />
    <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="ListView2_ItemDataBound">
            <ItemTemplate>
               <li>   
      <a href="/<%# Eval("topcat") %>/<%# Eval("urlpath") %>/SC/Category">
           <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
          <asp:Label ID="Label4" runat="server" Text='<%#Eval("HLevel") %>' Visible="False"></asp:Label>
         
       </a>
 </li>
            </ItemTemplate>
        </asp:ListView>
  
           
  </ul>


           

</li>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT displayorder, catnames, Displayname, NAME, HLevel, PARENT_NAMEID, ID, CAST(ID AS nvarchar(20)) + '-' + urlpath AS urlpath, (SELECT CAST(category_id AS nvarchar(20)) + '-' + urlpath AS mainurlpath FROM dbo.f_topcat(getcat_1.ID) AS f_topcat_1) AS topcat FROM dbo.getcat(@ID) AS getcat_1 ORDER BY catnames">
        <SelectParameters>
            <asp:ControlParameter ControlID="Label3" Name="ID" PropertyName="Text" />
        </SelectParameters>
</asp:SqlDataSource>

    </ItemTemplate>



</asp:ListView>
       
        
  </ul>
</div>

 

     
       
