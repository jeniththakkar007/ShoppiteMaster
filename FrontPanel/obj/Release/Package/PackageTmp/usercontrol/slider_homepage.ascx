<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider_homepage.ascx.cs" Inherits="FrontPanel.usercontrol.slider_homepage" %>




<link rel="stylesheet"   type='text/css' href="<%= Page.ResolveClientUrl("~/homepage_Slider/frontslider.css")%>"/> 
<div class="swiper-containercos">
    <div class="swiper-wrappercos">
 

             <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
           
                  <div class="swiper-slidecos">
                      <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' />  
     
        </div>
            </ItemTemplate>
        </asp:ListView>

         
  
    </div>
  </div>
             
     
      <style>
  
    .swiper-containercos
        {
            width: 100%;
            /*height: 200px;*/
        }
        .swiper-slidecos
        {
            text-align: center;
            font-size: 18px;
            background: #fff; /* Center slide text vertically */
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

  <!-- Swiper -->
  

  <!-- Swiper JS -->
 <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/homepage_Slider/frontslider.js")%>"></script>
      
  <!-- Initialize Swiper -->
  <script type="text/javascript">
      var swiper1 = new Swiper('.swiper-containercos', {
          spaceBetween: 30,
          centeredSlides: true,
          autoplay: 1000,
          speed: 3000, // Speed in milliseconds.
          pagination: {
              el: '.swiper-pagination',
              clickable: true
          },

          autoplay: {
        delay: 2500,
        disableOnInteraction: false,
      },
          navigation: {
              nextEl: '.swiper-button-next',
              prevEl: '.swiper-button-prev'
          },
          effect: 'fade'
      });
         

    
        </script>

