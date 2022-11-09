<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_socialmedia.ascx.cs" Inherits="FrontPanel.usercontrol.uc_socialmedia" %>
  <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT Icon, URL, Status FROM SocialMedia WHERE (Status = N'Active')"></asp:SqlDataSource>
    
   <asp:ListView ID="ListView6" runat="server" DataSourceID="SqlDataSource6">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("URL") %>' Visible="false"></asp:Label>
                             
                            <a target="_blank" href='<%# Eval("URL") %>' runat="server"> <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("icon") %>'  Width="25px" /></a>
                            </ItemTemplate>
                        </asp:ListView>