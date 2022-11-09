<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FrontPanel.customer.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <%--   <link href="../Content/noheader.css" rel="stylesheet" />--%>
    <div class="white-bg ">
        <div class="container">
            <h4 class="padding15">

                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/cart.png" Width="25px" />My Orders
            </h4>
        </div>
    </div>
    <div class="white-smoke-bg paddingtb-15 ">
        <div class="container">
            <div class=" margin15">
               
             <%--   <div class="row  white-bg radius bold  radius">
                    <div class="col-md-8 padding10 col-xs-8 border">
                        Order ID
                    </div>
                    <div class="col-md-4 padding10 col-xs-4 border">
                        Order Date
                    </div>
                </div>--%>
              
             


                <asp:ListView ID="ListView1" runat="server"  >

                    <EmptyDataTemplate>
                        <div class="box-center">
                            <div class="confirmation white-bg">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/nosearchfound.png" />
                                <h3>No Result
                                    <br />
                                    <br />
                                    <small>We're sorry. We cannot find any order history.</small>
                                </h3>
                            </div>
                        </div>
                    </EmptyDataTemplate>

                    <ItemTemplate>



                      <%--  <a class="showBtn">BUTTON</a>

<div class="hideme">
  <h1>Hello</h1>
</div>

<a class="showBtn">BUTTON</a>

<div class="hideme">
  <h1>Hello 2</h1>
</div>--%>








                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("OrderGUID") %>' Visible="false"></asp:Label>

                        <div class="white-bg border white-bd ">

                        
                               <a  class="showBtn" href="#"> <div class="row padding5">
                                  <h5 class="line20 row">
                                      <div class="col-xs-8">

                                    
                                     Order ID: <span class="c-green-c">#<asp:Label ID="Label6" runat="server" Text='<%# Eval("orderid") %>' ></asp:Label> </span>  <br />
                                       <small>  Placed on <asp:Label ID="Label8" runat="server" Text='<%# Eval("orderdate" , "{0:MMM-dd-yyyy}") %>'></asp:Label>
                                

                                   </small>
                                          



                                      </div>
                                      <div class="col-xs-4 right">
                                      
                                     <asp:Label ID="Label9" runat="server" Text="View Detail" CssClass="c-green-c small "></asp:Label>
                                    
                                        
                                         

                                 </div>
                                   </h5>
                                   


                                    

                                  <%--  <span class="pull-right">Total: <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></span>--%>
                                      <%--  <asp:Label ID="Label1" runat="server" CssClass="pull-right bold text-warning" Font-Size="11px"> Check Status <i class="fa fa-angle-down"></i></asp:Label>--%>
                                  
                                </div>
                         </a>
                      
                              <div class="hideme"  > <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ListView2_ItemCommand">


                                    <ItemTemplate>

                                     
                                        <div class="row border" >  
                                             <asp:Label ID="Label11" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("orderid") %>' Visible="false"></asp:Label>
                                            <div class="col-md-1 col-xs-3">
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' CssClass="img-responsive padding5" />

                                            </div>
                                            <div class="col-md-6 col-xs-7">
                                                <h5>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                                    <br />
                                                    <small><%# Eval("OrderVariation") %></small>
                                                </h5>  <h5><small>Qty:</small>


                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("qty") %>'></asp:Label>
                                                    </h5>

                                                <h4></h4>
                                            </div>
                                            <div class="col-md-5 ">

                                                <div class="col-xs-6 nopadding">
                                                  
                                                <span class="badge m-bold margin10 padding5 white-smoke-bg black-c upp pull-right"><asp:Label ID="Label5" runat="server" Text='<%# Eval("orderdeliverystatus") %>' CssClass=""></asp:Label> :    <asp:Label ID="Label10" runat="server" Text='<%# Eval("orderdeliverystatusdate") %>' CssClass="m-bold"></asp:Label></span>     <br />
                                                  
                                                </div>

                                                <div class="col-xs-6 ">
                                                    <div class="pull-right dropdown">
                                                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="action" > <i class="fa fa-info-circle red-c margin10 pull-right small dropbtn"></i></asp:LinkButton>
                                                    <div class="dropdown-content">
 <h6 class="line20">
   <span class="black-c bold">Cancelled:</span><br>
   <a class="red-c" >    Click    </a> 
     <small>if you want to cancel your order</small>
      </h6>

                                                        
                                                    
  </div>
                                                    </div>
                                                   

                                                   <h5><small class="text-muted">Price &nbsp; </small>
                                                         <asp:Label ID="Label13" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                      

                                                    </h5>

                                                      <h5><small class="text-muted">Shipping &nbsp; </small>
                                                         <asp:Label ID="Label18" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                        <asp:Label ID="Label19" runat="server" Text='<%# Eval("deliveryfees") %>'></asp:Label>
                                                      

                                                    </h5>

                                                      <h5><small class="text-muted">Vat &nbsp; </small>
                                                         <asp:Label ID="Label20" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("Vat") %>'></asp:Label>
                                                      

                                                    </h5>

                                                           <h5><small class="text-muted">Tax &nbsp;&nbsp;&nbsp;&nbsp; </small>
                                                         <asp:Label ID="Label15" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                                       

                                                    </h5>

                                                    <h5><small class="text-muted">Total &nbsp; </small>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("totalPrice","{0:#,##0.00}") %>'></asp:Label>

                                                    </h5>

                                                </div>



                                            </div>

                                        </div>


                                    </ItemTemplate>
                                </asp:ListView>

                                <div class="margin15 border radius white-smoke-bg padding10 row">
                                    <div class="col-md-8">
                                        <h5 >
                                            Shipping Detail
                                        </h5>
                                        <p class="small">
                                        
                                            <%# Eval("FirstName") %>   <%# Eval("LastName") %> <br />
                                            <%# Eval("Address") %>,  <%# Eval("street") %> ,  <%# Eval("city") %>,  <%# Eval("zipcode") %><br />
                                               <%# Eval("email") %> ||  <%# Eval("phone") %>
                                        </p>
                                            <br />

                                   
                                

                               
                                         
                                    </div>
                                    <div class="col-md-4 right"> 
                                         <h5><small> Payment Mode:  <asp:Label ID="Label16" runat="server" Text='<%# Eval("PaymentMode") %>' CssClass="d-grey-c bold"></asp:Label></small> &nbsp; - &nbsp;   <small>  Payment Date: <asp:Label ID="Label17"  CssClass="d-grey-c bold" runat="server" Text='<%# Eval("PaymentDate" , "{0:MMM-dd-yyyy}") %>'></asp:Label> </small> </h5>  
               <br />
                                        <h4>

                                       
   Total Amount: <br />

                                                      <strong class="orange-c"> <asp:Label ID="Label3" runat="server" Text='<%# Eval("totalPrice","{0:#,##0.00}") %>'></asp:Label> <%# Eval("CurrencyName") %></strong> 

                                </h4>     </div>
                                </div>

                                  <hr />
                              </div> 
                           

                     

                        </div>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT id, ProductName, image, QTY, Price, Tax, DeliveryFees, InsertDate, orderdate, totalPrice, orderid, OrderGUID, ProductId, Comments, OrderStatus, CurrencyName, orderdeliverystatus, orderdeliverystatusdate, PaymentMode, PaymentDate, ReferenceID, Commission, Donation, OrderVariation, Vat FROM dbo.f_order_detail(@ID) AS f_order_detail_1">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="Label2" Name="ID" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
              
       
                    </ItemTemplate>
                </asp:ListView>
            </div>



        </div>
    </div>

 

   <%--     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT OrderGUID, orderid, totalPrice, orderdate FROM dbo.f_order_master(@UserName) AS f_order_master_1 ORDER BY orderdate DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField1" Name="UserName" PropertyName="Value" />
        </SelectParameters>
       </asp:SqlDataSource>--%>
    <asp:HiddenField ID="HiddenField1" runat="server" />       

           <script>
$('.showBtn').click(function() {
  //$('.hideme').hide();  
  if ($(this).hasClass('active')) {    
    $(this).removeClass('active');
    $('.hideme').slideUp();
  } else {
    $('.hideme').slideUp();
    $('.showBtn').removeClass('active');
    $(this).addClass('active');
    $(this).next().filter('.hideme').slideDown();
  }
});
           </script>

    <style>
        .showBtn {
            display: block;
border-bottom: solid 1px
#ccc;
padding: 10px 5px;

}
.hideme {
  display: none;  
}

 .dropbtn {

}

.dropdown {
  position: relative;
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #fff;
 padding:10px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
  top: 29px;
  width: 170px;
}

.dropdown-content h6{

  padding: 5px;
  text-decoration: none;
  display: block;
}



.dropdown:hover .dropdown-content {display: block;}

    </style>


     <button data-toggle="modal" id="btnShowPopup1" data-target="#myModal1" style="visibility:hidden"></button>
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm c-shadow  white-bg">
              <button type="button" class="close margin15 grey-c" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h3 class="bold no-margin ">Cancel Order <BR />
            <small>
                <a runat="server" href="~/1/Help-Center/page">Click to read our terms and Condition before cancel your order</a>
            </small>
            </h3>
            <hr />
            <div class="form form-horizontal">
                <div class="form-group">
                Reason:
                <asp:TextBox ID="txtreason" runat="server" TextMode="MultiLine"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtreason"
                                CssClass="text-danger" ErrorMessage="Field is Required." SetFocusOnError="True" ValidationGroup="camcel" />
                     </div>
                 <div class="form-group">
                     <asp:Button ID="Button1" runat="server" ValidationGroup="camcel" Text="Send Cancel Request" OnClick="Button1_Click" />
                     </div>
            </div>
             </div>    </div>
    <script type="text/javascript">
        function ShowPopup1() {
            $("#btnShowPopup1").click();
        }
    </script>
    <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />

</asp:Content>
