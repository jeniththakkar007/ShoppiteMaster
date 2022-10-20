<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="thumbnail_slider.ascx.cs" Inherits="FrontPanel.usercontrol.thumbnail_slider" %>



 
<%--    <link rel="stylesheet"   type='text/css' href="<%= Page.ResolveClientUrl("~/thumbnailslider1/thumb-slide.css")%>"/> 
  
 <style>
    
  </style>--%>


 

<%--  <div class="swiper-containerthumb">
      --%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

 
      
      <h4 class="bold no-margin padding5 d-new-head"> <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label></h4>
    <div class="row">
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" OnItemDataBound="ListView1_ItemDataBound" >
                   <ItemTemplate>

                         <asp:Label ID="lblid" runat="server" Text='<%#Eval("ProductId") %>' Visible="false"></asp:Label>
         <div class="col-lg-2 col-md-3 col-sm-4 col-xs-6 padding5">

     
           

          
                                 <div class="white-bg radius padding5 left"> 
                                     
                                    <asp:LinkButton ID="lnkhomestatus"  ClientIDMode="AutoID" CommandName="lk" runat="server" CssClass="p-unlike"> <span class="theme-c padding5 label bold"><%#Eval("totalpick") %></span></asp:LinkButton>
                                     <a href="/<%# Eval("Productid") %>-<%# Eval("urlpath") %>/show">
                                    <div class="img-box h-155 section1">
                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                                    </div>
                                    <div class="padding5">
                                        <p class="h-30 no-margin small">
                                        <%#Eval("ProductName") %>
                                        </p>
                                        <span class="black-c small red-c bold">
                                        <%--    <%#Eval("Price") %> <%#Eval("currencyname") %>--%>
                                             <asp:Label ID="lblprice" runat="server" Text=' <%#Eval("Price") %>'></asp:Label> <asp:Label ID="lblcurrency" runat="server" Text='<%#Eval("CurrencyName") %>'></asp:Label>


                                        </span>
                                        
                                        </div>  </a>
                                </div>
         
                            </div>
    </ItemTemplate>
        </asp:ListView>


    </div>
           </ContentTemplate>
</asp:UpdatePanel>
    <!-- Add Pagination -->
<%--    <div class="swiper-pagination"></div>--%>
       <!-- Navigation -->
   <%-- <div class="swiper-button-next swiper-button-white">
         <i class="fas fa-caret-right"></i>  
    </div>
    <div class="swiper-button-prev swiper-button-white">
     <i class="fas fa-caret-left"></i>
    </div>
  </div>--%>

<%--  <!-- Swiper JS -->
 <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/thumbnailslider1/thumb-slide.js")%>"></script>--%>
  <%--  <script src="../thumbnailslider1/thumb-slide.js"></script>--%>

  <!-- Initialize Swiper -->
 <%-- <script>
    var swiper = new Swiper('.swiper-containerthumb', {
      slidesPerView: 1,
      spaceBetween: 10,
      // init: false,
      pagination: {
        el: '.swiper-pagination',
        clickable: true,
        },
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      breakpoints: {
        640: {
          slidesPerView: 2,
          spaceBetween: 10,
        },
        768: {
          slidesPerView: 4,
          spaceBetween: 10,
        },
        1024: {
          slidesPerView: 5,
          spaceBetween: 10,
        },
      }
    });
  </script>--%>
