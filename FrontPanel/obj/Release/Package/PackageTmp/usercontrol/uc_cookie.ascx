<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_cookie.ascx.cs" Inherits="FrontPanel.usercontrol.uc_cookie" %>
<%--    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />--%>
<%--<script src="//code.jquery.com/jquery.min.js" type="text/javascript"></script>--%>
<script type="text/javascript">
    $(function () {
        if (document.cookie.indexOf("Megazar-CookiePolicy") < 0) {
            $('[id*=dvCookieMessage]').slideDown('slow');
        }
        $('[id*=lnkOk]').on('click', function () {
            document.cookie = "Megazar-CookiePolicy=yes; max-age=" + (5 * 365 * 24 * 60 * 60);
            $('[id*=dvCookieMessage]').slideUp('slow');
        });
    });
</script>
<div id="dvCookieMessage" style="display: none;">
    <div>
        <p>We use cookies to improve and personalise your browsing experience, to perform analytics and research, and to provide social media features. By continuing to use our site, you accept our 
            
            
            <a href="#PolicyURL">cookie and Privacy policy</a>.</p>
        <a id="lnkOk" class="btn theme-bg f-theme pull-right bold margin5 ">Agree</a>
        <a class="pull-right btn l-grey-bg l-grey-bd pull-right bold margin5 "> More Info </a>

        
        
    </div>
</div>


<style>
   #dvCookieMessage{
position: fixed;
top: -5px;
left: 19px;
text-align: left;
padding: 15px;
margin: 5px;
border: solid 2px var(--theme-color);
border-radius: 4px;
background: white;
width: 315px;
font-size: 12px;
background:
white;
z-index: 10000;
    }
   #dvCookieMessage p{
      color:black !important;
   }

</style>