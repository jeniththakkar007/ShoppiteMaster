<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homepage_brands.ascx.cs" Inherits="FrontPanel.usercontrol.homepage_brands" %>



        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
        <ItemTemplate>

        
 <div class="col-md-2 col-xs-3 no-padding">
            <div class="brand border white-smoke-bd">
                <asp:LinkButton ID="LinkButton1" CommandName="view" runat="server">
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("brandname") %>' Visible="false"></asp:Label>
                      <asp:Label ID="Label2" runat="server" Text='<%#Eval("brandurlpath") %>' Visible="false"></asp:Label>
                     <asp:Label ID="Label3" runat="server" Text='<%#Eval("brandid") %>' Visible="false"></asp:Label>
                <asp:Image ID="Image1" runat="server"  ImageUrl='<%#Eval("brandimage") %>' AlternateText='<%#Eval("brandname") %>'  />

                </asp:LinkButton>
            </div>
        </div>
            </ItemTemplate>
        </asp:ListView>
       
<asp:Label ID="lblselectedbrand" runat="server" Text="" Visible="false"></asp:Label>