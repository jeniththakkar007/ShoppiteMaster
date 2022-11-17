<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ad_middle_uc.ascx.cs" Inherits="FrontPanel.usercontrol.ad_middle_uc" %>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper/swiper-bundle.min.css"/>
<style>
    .swiper-button-next,.swiper-button-prev{
        background-color:#ff6801;
        color:white;
    }
</style>
<div>
    <div class="swiper mySwiper">
        <div class="swiper-wrapper">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="swiper-slide">
                        <img src='<%#Eval("Image") %>' width="100%" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="swiper-button-next"></div>
      <div class="swiper-button-prev"></div>
    </div>

 <script src="https://cdn.jsdelivr.net/npm/swiper/swiper-bundle.min.js"></script>
    <script>
        var swiper = new Swiper(".mySwiper", {
            spaceBetween: 30,
            centeredSlides: true,
            loop: true,
            autoplay: {
                delay: 3000,
                disableOnInteraction: false,
            },
            navigation: {
              nextEl: '.swiper-button-next',
              prevEl: '.swiper-button-prev',
            },
    });
    </script>
</div>