<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detail_variation.ascx.cs" Inherits="FrontPanel.usercontrol.detail_variation" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>

 
 <h3 class="bold  ">
      <asp:Label ID="lblcurrentprice" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="lblsaleprice" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="lblcurrency2" runat="server" Text="Label"></asp:Label>
                        <small>
                            <asp:Label ID="lbloldprice" runat="server" Text="0" Font-Strikeout="True"></asp:Label>
                            <asp:Label ID="lblcurrecny" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblsave" runat="server" Text="You save " CssClass="l-green-bg small white-c btn-xs no-radius"></asp:Label>

                        </small>
                    </h3>
                  <hr />

      

<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2">
    <ItemTemplate>

     <asp:Label ID="lblinsideprice" Visible="false" runat="server" Text="0"></asp:Label> 

          <asp:Label ID="Label3" runat="server" Text='<%#Eval("AttributeId") %>' Visible="False"></asp:Label> 
<div class="">
                        <h6>
                           
                               <asp:Label ID="Label2" runat="server" Text='<%#Eval("AttributeName") %>' ></asp:Label>
                           </h6>
                           <div class="radiobtn">
<asp:RadioButtonList ID="RadioButtonList1" runat="server" ClientIDMode="AutoID"  DataSourceID="SqlDataSource1" DataTextField="SpecificationName" DataValueField="ProductSpecificationId" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                  
                               </asp:RadioButtonList>


                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Select Product Variation" Display="Dynamic" CssClass="required" ValidationGroup="buynow"></asp:RequiredFieldValidator>
                           </div>
                       </div>

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT dbo.Specification_Setup.SpecificationName, dbo.Product_Specification.Price, dbo.Product_Specification.Image, dbo.Product_Specification.ProductSpecificationId FROM dbo.Specification_Setup INNER JOIN dbo.Product_Specification ON dbo.Specification_Setup.SpecificationId = dbo.Product_Specification.SpecificationId INNER JOIN dbo.Product_Basic ON dbo.Product_Specification.ProductGUID = dbo.Product_Basic.ProductGUID WHERE (dbo.Product_Basic.ProductId = @ID) AND (dbo.Specification_Setup.AttributeId = @AID) ORDER BY dbo.Specification_Setup.SpecificationName">
    <SelectParameters>
        <asp:ControlParameter ControlID="HiddenField1" Name="ID" PropertyName="Value" />
        <asp:ControlParameter ControlID="Label3" Name="AID" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
    </ItemTemplate>
</asp:ListView>


                               

<asp:HiddenField ID="HiddenField1" runat="server" />


<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT DISTINCT dbo.Attributes_Setup.Attributeid, dbo.Attributes_Setup.AttributeName, dbo.Product_Basic.ProductId FROM dbo.Product_Specification INNER JOIN dbo.Specification_Setup ON dbo.Product_Specification.SpecificationId = dbo.Specification_Setup.SpecificationId INNER JOIN dbo.Attributes_Setup ON dbo.Specification_Setup.AttributeId = dbo.Attributes_Setup.AttributeId INNER JOIN dbo.Product_Basic ON dbo.Product_Specification.ProductGUID = dbo.Product_Basic.ProductGUID WHERE (dbo.Product_Basic.ProductId = @ID)">
    <SelectParameters>
        <asp:ControlParameter ControlID="HiddenField1" Name="ID" PropertyName="Value" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lblvariationdata" runat="server" Text="" Visible="false"></asp:Label>



           </ContentTemplate>
  
</asp:UpdatePanel>

                        
