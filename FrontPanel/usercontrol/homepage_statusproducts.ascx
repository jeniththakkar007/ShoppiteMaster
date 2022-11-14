<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homepage_statusproducts.ascx.cs" Inherits="FrontPanel.usercontrol.homepage_statusproducts" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>

                <asp:Label ID="Label2" runat="server" Visible="false" Text='<%#Eval("StatusId") %>'></asp:Label>
                <div class="margintb-15">

                    <h4 class="bold no-margin padding5">
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </h4>
                    <div class="row p-status">
                        <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ListView2_ItemCommand" OnItemDataBound="ListView2_ItemDataBound">
                            <ItemTemplate>

                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("ProductId") %>' Visible="false"></asp:Label>
                                <div class="col-lg-2 col-md-3 col-sm-4 col-xs-6 padding5">

                                    <div class="white-bg radius padding5 shadow-hover">

                                        <asp:LinkButton ID="lnkhomestatus" ClientIDMode="AutoID" CommandName="lk" runat="server" CssClass="p-unlike"> <span class="theme-c padding5 label bold  "><%#Eval("totalpick") %></span></asp:LinkButton>
                                        <a href="/<%# Eval("urlpath") %>/show">
                                            <div class="img-box h-155">
                                                <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                                            </div>
                                            <div class=" padding5">
                                                <p class="h-30 s-bold small">
                                                    <%#Eval("ProductName") %>
                                                </p>
                                                <p class="small">
                                                    Only&nbsp;<span class="red-c bold fonts">

                                                        <asp:Label ID="lblprice" runat="server" Text=' <%#Eval("Price") %>'></asp:Label>
                                                        <asp:Label ID="lblcurrency" runat="server" Text='<%#Eval("CurrencyName") %>'></asp:Label>
                                                    </span>
                                                </p>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT TOP (6) totalpick, ProductId, ProductGUID, ProductName, image, Price, OldPrice, CAST(ProductId AS nvarchar(20)) + '-' + URLPath AS urlpath, CurrencyName FROM dbo.f_getproducts_By_StatusID(@ID) AS f_getproducts_By_StatusID_1 ORDER BY NEWID()">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label2" Name="ID" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ItemTemplate>
        </asp:ListView>
    </ContentTemplate>
</asp:UpdatePanel>