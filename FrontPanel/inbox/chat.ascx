<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chat.ascx.cs" Inherits="FrontPanel.inbox.chat" %>
<%@ Register Src="~/inbox/allmessages.ascx" TagPrefix="uc1" TagName="allmessages" %>
<%@ Register Src="~/inbox/chatting.ascx" TagPrefix="uc1" TagName="chatting" %>
<%@ Register Src="~/inbox/chatinsert.ascx" TagPrefix="uc1" TagName="chatinsert" %>

<link href="../inbox/inbox.css" rel="stylesheet" />

<div class="shadow ">

    <div class="row">
        <div class="col-md-4 col-xs-4 no-padding">
            <%-- <h4 class="padding15 no-margin visible-lg">Messages
                        </h4>--%>
            <uc1:allmessages runat="server" ID="allmessages" />
        </div>
        <div class="col-md-8 col-xs-8 no-padding">
            <div class="inbox-error" runat="server" id="chaterror" visible="false">
                <h4>
                    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                </h4>
            </div>
            <div class="chatbox chat_container">
                <uc1:chatting runat="server" ID="chatting" />
            </div>

            <div class="msgform ">
                <uc1:chatinsert runat="server" ID="chatinsert" />
            </div>
        </div>
    </div>
</div>

<%--<script>
$(function () {
    var ChatDiv = $('.chat_container');
    var height = ChatDiv[0].scrollHeight;
    ChatDiv.scrollTop(height);
});
</script>--%>