<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chatinsert.ascx.cs" Inherits="VendorPanel.inbox.chatinsert" %>






<asp:UpdatePanel runat="server"  ClientIDMode="AutoID" UpdateMode="Conditional">
    <ContentTemplate>
<div onkeypress="return WebForm_FireDefaultButton(event, '<%= Button1.ClientID %>')" class="padding10">



       <hr class="l-grey-bd no-margin" />



     <div class="input-group">
      <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control no-radius no-border" placeholder="Type your message here" TextMode="SingleLine" Height="70px" AutoCompleteType="Disabled"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Type Message" CssClass="required" ControlToValidate="TextBox1" ValidationGroup="msg"></asp:RequiredFieldValidator>
         <span class="input-group-btn">
          <asp:Button ID="Button1" OnClick="LinkButton1_Click" runat="server" ValidationGroup="msg" ClientIDMode="AutoID" Text="Send" OnClientClick="if (!Page_ClientValidate('msg')){ return false; } this.disabled = true; this.value = 'Sending...';" UseSubmitBehavior="False" CssClass="btn theme-bg white-c pull-right" />


      <%-- <asp:LinkButton ID="LinkButton1"  runat="server"  CssClass="d-grey-c  " ><i class="far fa-paper-plane d-grey-c"></i></asp:LinkButton>--%>
 <%--         <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd">
                            <ProgressTemplate>
                                <div class="box-center">

                                 <i class="fas fa-spinner fa-pulse fa-4x"></i>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>--%>
      </span>
    </div>







    <asp:Label ID="lblchatid" runat="server" Text=""></asp:Label>








  

<asp:HiddenField ID="HiddenField1" Value="No" runat="server" />

</div>

           </ContentTemplate>

    <Triggers>
       

         <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
    </Triggers>

</asp:UpdatePanel>