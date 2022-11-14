<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product_homepage.ascx.cs" Inherits="FrontPanel.usercontrol.Product_homepage" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("category_id") %>' Visible="false"></asp:Label>
                <div class="margintb-15">
                    <h4 class="bold no-margin padding5"><%#Eval("category_name") %>
                    </h4>
                    <div class="row c-product">
                        <div class="col-lg-2 col-md-3 padding5 m-none c-banner">
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("Banner") %>' Width="100%" />
                        </div>
                        <div class="col-lg-10 col-md-9 no-padding">
                            <div class="row">

                                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ListView2_ItemCommand" OnItemDataBound="ListView2_ItemDataBound">
                                    <ItemTemplate>

                                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("ProductId") %>' Visible="false"></asp:Label>
                                        <div class="col-lg-3 col-md-4 col-sm-4 col-xs-6 padding5">

                                            <div class="white-bg radius padding5 shadow-hover">

                                                <asp:LinkButton ID="lnkhomeproduct" ClientIDMode="AutoID" CommandName="lk" runat="server" CssClass="p-unlike"> <span class="theme-c padding5 label bold"><%#Eval("totalpick") %></span></asp:LinkButton>
                                                <a href="/<%# Eval("urlpath") %>/show">
                                                    <div class="img-box h-220">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                                                    </div>
                                                    <div class="padding5">
                                                        <p class="h-30 no-margin small">
                                                            <%#Eval("ProductName") %>
                                                        </p>
                                                        <span class="black-c large red-c">
                                                            <asp:Label ID="lblprice" runat="server" Text=' <%#Eval("Price") %>'></asp:Label>
                                                            <asp:Label ID="lblcurrency" runat="server" Text='<%#Eval("CurrencyName") %>'></asp:Label>
                                                        </span>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT top 8 totalpick, ProductId, ProductGUID, ProductName, CAST(ProductId AS nvarchar(20)) + '-' + URLPath AS URLPath, image, category_name, Price, OldPrice, maincatid, maincaturlpath, CurrencyName FROM dbo.f_getproducts_By_CategoryID(@ID) AS f_getproducts_By_CategoryID_1 order by newid()">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="ID" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%--    SELECT        TOP (8) ProductGUID, ProductName, CAST(ProductId AS nvarchar(20)) + '-' + URLPath AS URLPath, image, category_name, Price, OldPrice,
                             (SELECT        category_id AS mainurlpath
                               FROM            dbo.f_topcat(f_getproducts_1.category_id) AS f_topcat_1) AS topcat
FROM            dbo.f_getproducts() AS f_getproducts_1
WHERE        ((SELECT        category_id AS mainurlpath
                            FROM            dbo.f_topcat(f_getproducts_1.category_id) AS f_topcat_1) = @ID)--%>
            </ItemTemplate>
        </asp:ListView>
    </ContentTemplate>
</asp:UpdatePanel>