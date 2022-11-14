<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_newsletter.ascx.cs" Inherits="FrontPanel.usercontrol.uc_newsletter" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upnewsletter">
    <ProgressTemplate>
        <span class="text-info">Processing...</span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="upnewsletter" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <!--newslatter area start-->

        <div class="input-group">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Your Email here"></asp:TextBox>
            <span class="input-group-btn">
                <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="news" OnClick="LinkButton1_Click" CssClass="btn theme-bg f-theme">Subscribe</asp:LinkButton>
            </span>
        </div>

        <asp:Label ID="Label1" runat="server" CssClass="text-success bold"></asp:Label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ValidationGroup="news" ErrorMessage="Valid Email Required" Display="Dynamic" ControlToValidate="TextBox1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="news" ErrorMessage="Email Required" ControlToValidate="TextBox1" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

        <!--newslatter area end-->
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>