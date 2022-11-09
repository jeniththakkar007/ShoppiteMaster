<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_attribute_uc.ascx.cs" Inherits="AdminPanel.usercontrol.product_attribute_uc" %>

<div class="white-bg shadow">
       <h4 class="padding15 no-margin">
   Product Attribute 
    </h4>

    <hr class="no-margin" />
    <br />

    
            <div class="form-group">
                
                <div class="checkright">
                    <div class="row">
                    <asp:ListView ID="ListView2" runat="server" OnItemDataBound="ListView2_ItemDataBound">

                        <ItemTemplate>
                         <div class="col-md-3">
                       
                               <asp:Label ID="Label3" runat="server" Text='<%#Eval("AttributeId") %>' Visible="False"></asp:Label> 
                  <h5 class="bold no-margin paadding10"> <asp:Label ID="Label2" runat="server" Text='<%#Eval("AttributeName") %>' ></asp:Label> </h5>



                              <asp:CheckBoxList ID="chkattribute" DataSourceID="SqlDataSource1" runat="server" RepeatDirection="Vertical" DataTextField="SpecificationName" DataValueField="SpecificationId" ></asp:CheckBoxList>


                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT AttributeId, SpecificationName, SpecificationId FROM dbo.Specification_Setup WHERE (AttributeId = @ID) ORDER BY SpecificationName">
    <SelectParameters>
        <asp:ControlParameter ControlID="Label3" Name="ID" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>

</div>
                        </ItemTemplate>


                    </asp:ListView>


                  </div>
                   

                    </div>  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn theme-bg white-c margin15 s-bold" OnClick="LinkButton1_Click">Add Attribute in List </asp:LinkButton>  </div> 







               
<div class="">

    <div class="checkright grid padding15">    <table style="width:100%;">

        <tr>
            <td>
           Delete
            </td>
            <td>
            Attribute Name</td>
            <td>
  Image: (Optional) 
            </td>
            <td>
 Price: (Optional) 
            </td>
        </tr>
        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
            <EmptyDataTemplate>
                Specification attributes are product features i.e, screen size, number of USB-ports, visible on product details page. 
                Specification attributes can be used for filtering products on the category details page. 
               
            </EmptyDataTemplate>
            <ItemTemplate>

                 <asp:Label ID="Label5" runat="server" Text='<%#Eval("productspecificationid") %>' Visible="false" ></asp:Label>
        
                  
            
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton2" CommandName="del" runat="server" CssClass="delete"></asp:LinkButton>
                        </td>
                        <td>
  <asp:Label ID="Label1" runat="server" Text='<%#Eval("AttributeName") %>' ></asp:Label>:
                   <asp:Label ID="Label4" runat="server" Text='<%#Eval("Specificationname") %>' CssClass="bold black"></asp:Label>
                        </td>
                        <td>
 <div class=" s-bold" >
   
      
            <label class="file-upload pull-left">
                            <span class="border radius padding5">Upload Image</span>
                            <asp:FileUpload ID="fuicon" runat="server" />
                        </label>    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("image") %>'  CssClass="pull-right" Width="100px" /> 
</div>
                        </td>
                        <td>
    <div class="s-bold">
          <asp:TextBox ID="txtprice" runat="server" Width="50px" CssClass="padding5" Text='<%#Eval("price") %>'></asp:TextBox>
               </div>
                        </td>
                    </tr>
              



 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="padding5" Visible="False">
                
                 <asp:ListItem Selected="True">Drop Down</asp:ListItem>
                 <asp:ListItem>Radio Button</asp:ListItem>
             </asp:DropDownList>
          
         
            </ItemTemplate>
        </asp:ListView>


  </table>
      

    </div>
         <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn theme-bg white-c margin15 s-bold pull-right" OnClick="LinkButton3_Click">Update Product Variation</asp:LinkButton>
    <br />
    <br />
    <br />
</div>
        </div>

