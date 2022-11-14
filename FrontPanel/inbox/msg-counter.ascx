<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="msg-counter.ascx.cs" Inherits="FrontPanel.inbox.msg_counter" %>

<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(beginRequest);

    function beginRequest() {
        prm._scrollPosition = null;
    }
</script>

<style>
    #MainContent_detail_vendor_uc_msgcounter_UpdatePanel1 {
        display: inline-block
    }
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="badge theme-bg white-c"></asp:Label>

        <%-- <asp:Timer ID="Timer1" runat="server" Interval="5000"></asp:Timer>--%>
    </ContentTemplate>
</asp:UpdatePanel>