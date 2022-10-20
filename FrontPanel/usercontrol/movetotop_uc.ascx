<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="movetotop_uc.ascx.cs" Inherits="MassagePortal.usercontrol.movetotop_uc" %>

    <a id="moveup" > <i class="fas fa-chevron-up"></i> </a>

        <script>
            var btn = $('#moveup');

            $(window).scroll(function () {
                if ($(window).scrollTop() > 300) {
                    btn.addClass('show');
                } else {
                    btn.removeClass('show');
                }
            });

            btn.on('click', function (e) {
                e.preventDefault();
                $('html, body').animate({ scrollTop: 0 }, '300');
            });



        </script>
<style>
    
#moveup:before {
    opacity: 0.55;

}

#moveup:before,
#moveup:after {
    content: "";
    height: 100%;
    margin: auto;
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    top: 0;
    width: 100%;
    z-index: -1;
    border-radius: 0% 0;
    -webkit-transition: all 0.3s linear 0s;
    transition: all 0.3s linear 0s;
    background: var(--theme-color)
}

#moveup:after {
    opacity: 0.35;
   
}

#moveup:hover:before {
    -webkit-transform: rotate(-45deg);
    transform: rotate(-45deg)
}

#moveup:hover:after {
    -webkit-transform: rotate(-55deg);
    transform: rotate(-55deg)
}



#moveup:active,
#moveup:focus {
    outline: none
}

#moveup {
    position: fixed;
    bottom: 86px;
    right: 30px;
    z-index: 99;
    opacity: 0;
    visibility: hidden;
    cursor:pointer;
    padding:10px 14px;
    color:white;
    transition: background-color .3s, opacity .5s, visibility .5s;
}
  #moveup.show {
        opacity: 1;
        visibility: visible;
    }



</style>