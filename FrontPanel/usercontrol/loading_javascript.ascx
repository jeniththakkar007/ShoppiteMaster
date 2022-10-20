<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="loading_javascript.ascx.cs" Inherits="FrontPanel.usercontrol.loading_javascript" %>

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

