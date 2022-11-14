<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ad_middle_uc.ascx.cs" Inherits="FrontPanel.usercontrol.ad_middle_uc" %>

<div>

    <div class="swiper-container swiper2">
        <div class="swiper-wrapper">

            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>

                    <div class="swiper-slide">
                        <img src='<%#Eval("Image") %>' width="100%" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

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
</div>