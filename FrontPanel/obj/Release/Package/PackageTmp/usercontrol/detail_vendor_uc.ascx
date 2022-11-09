<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detail_vendor_uc.ascx.cs" Inherits="FrontPanel.usercontrol.detail_vendor_uc" %>
<%@ Register Src="~/inbox/chat.ascx" TagPrefix="uc1" TagName="chat" %>
<%@ Register Src="~/inbox/msg-counter.ascx" TagPrefix="uc1" TagName="msgcounter" %>



<%--  <a href="/<%#lblshopname.Text %>/StoreProducts">--%>


<div class="l-grey-bg radius padding10 v-image">
  <h5 class="bold"> <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="LinkButton1_Click"> 
        <asp:Label ID="lblshopname" runat="server" Text="Label"></asp:Label> 
        <asp:Image ID="imglogo" runat="server"  CssClass="pull-right" ImageUrl="~/Images/logo.png" /> 

   
   
  </asp:LinkButton>
      <br />  <br />
      <small>
    <asp:LinkButton ID="LinkButton2" Visible="false" runat="server" CssClass="l-blue-c bold" OnClientClick="myFunction();" OnClick="LinkButton2_Click"> <i class="far fa-comment-alt"></i> Chat Now</asp:LinkButton></small>
   </h5> 
</div>

    <%--</a>--%>
     <asp:Label ID="lblurlpath" runat="server" Text="Label" Visible="false"></asp:Label> 


<div class="inbox-fixed" runat="server"  id="dvvendorchat" visible="false">
     <a class="toggle white-c" id="chatbox"><div class="d-grey-bg padding10 ">
      <h5> 

       Messages <uc1:msgcounter runat="server" ID="msgcounter" />
<i class="fas fa-minus-square pull-right"></i></h5> </div></a> 
   
    <div id="target">
<uc1:chat runat="server" ID="chat" /></div>
</div>

<asp:HiddenField ID="hdnshopusername" runat="server" />
<script>
    $('.Show').click(function() {
    $('#target').show(500);
    $('.Show').hide(0);
    $('.Hide').show(0);
});
$('.Hide').click(function() {
    $('#target').hide(500);
    $('.Show').show(0);
    $('.Hide').hide(0);
});
$('.toggle').click(function() {
    $('#target').toggle('slow');
});
</script>

   <script type="text/javascript">
        function chatvisible() {
            $("#chatbox").click();
        }
    </script>

