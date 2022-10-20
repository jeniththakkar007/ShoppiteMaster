<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ad_top_uc.ascx.cs" Inherits="FrontPanel.usercontrol.ad_top_uc" %>



 <link rel="stylesheet"   type='text/css' href="<%= Page.ResolveClientUrl("~/ad_top/slider.css")%>"/> 



<style>
      .swiper-container {
      width: 100%;
      height: 100%;
    }
    .swiper-slide {
      text-align: center;
      font-size: 18px;
      background: transparent;
      /* Center slide text vertically */
      display: -webkit-box;
      display: -ms-flexbox;
      display: -webkit-flex;
      display: flex;
      -webkit-box-pack: center;
      -ms-flex-pack: center;
      -webkit-justify-content: center;
      justify-content: center;
      -webkit-box-align: center;
      -ms-flex-align: center;
      -webkit-align-items: center;
      align-items: center;
    }
</style>

<div class="alert-dismissible">


 <div class="swiper-container">
    <div class="swiper-wrapper">
       
      
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                  <div class="swiper-slide">
            <img src='<%#Eval("Image") %>' width="100%" />
     
        </div>
            </ItemTemplate>
        </asp:ListView>



     
    </div>
    <!-- Add Arrows -->
   <%-- <div class="swiper-button-next">
        <i class="fas fa-chevron-right white-c text-shadow fa-2x"></i>

    </div>
    <div class="swiper-button-prev">
        <i class="fas fa-chevron-left white-c text-shadow fa-2x"></i>

    </div>--%>
  </div>

  <!-- Swiper JS -->
 
 <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/ad_top/responsiveslides.min.js")%>"></script>
  <!-- Initialize Swiper -->
  <script>
      var swiper = new Swiper('.swiper-container', {


      effect: 'fade',
      pagination: {
        el: '.swiper-pagination',
        clickable: true,
      },

      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
        },
         autoplay: {
        delay: 2500,
        disableOnInteraction: false,
      },
    });
  </script>

   
    <script>
       $("div.alert-dismissible").on("click", "button.close", function() {
    $(this).parent().animate({opacity: 0}, 500).hide('slow');
});
    </script>







</div>