<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="loading_javascript.ascx.cs" Inherits="VendorPanel.usercontrol.loading_javascript" %>

<style>
    .loading{
 position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
}

.loading i{
position: fixed;
top: 50%;
right: 50%;
color:
white;
}
</style>     

<div  id="dvhours" style="display:none">
                          <asp:Label ID="lblbprogrss" runat="server" CssClass="loading">     <i class="fas fa-spinner fa-pulse fa-3x color" style="z-index:100000;"></i> </asp:Label>
     
                    </div>

        
    <script type="text/javascript">
        function myFunction() {

            document.getElementById("dvhours").style.display = "block";



            var seconds = 2;
            setTimeout(function () {
                document.getElementById("<%=lblbprogrss.ClientID %>").style.display = "none";
            }, seconds * 1000);

        }
</script>

