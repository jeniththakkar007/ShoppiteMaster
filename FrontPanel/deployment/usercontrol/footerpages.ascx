<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footerpages.ascx.cs" Inherits="FrontPanel.usercontrol.footerpages" %>


<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">

        <ItemTemplate>


            <div class="col-md-3">
                    <p class="bold">
                        <asp:Label ID="Label3" runat="server" Visible="false" Text='<%# Eval("MainPageCategoryID") %>'></asp:Label>

             <asp:Label ID="Label2" runat="server" Text='<%# Eval("MainPageCategory") %>'></asp:Label>
                    </p>
                
                <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2" OnItemCommand="ListView2_ItemCommand">

                <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Visible="false" Text='<%# Eval("url") %>'></asp:Label>
                                          <asp:Label ID="Label4" runat="server" Visible="false" Text='<%# Eval("isurl") %>'></asp:Label>
                    <p>
                           <asp:LinkButton ID="LinkButton1" runat="server" CommandName="pgview">
     <%--  <a class="grey-c" href="/<%# Eval("PageCategoryId") %>/<%# Eval("urlPageCategory") %>/page">--%>

                               <asp:Label ID="Label2" runat="server" Visible="false" Text='<%# Eval("PageCategoryId") %>'></asp:Label>
     <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pagecategory") %>'></asp:Label>

                           </asp:LinkButton>
                    </p>
                      
                </ItemTemplate>

            </asp:ListView>
                   
                </div>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT PageCategoryId, PageCategory, REPLACE(PageCategory, ' ', '-') AS urlPageCategory, IsURL, URL FROM dbo.PageCategory WHERE (Status = N'Active') AND (Type = N'Footer') AND (MainPageCategoryId = @ID)">
    <SelectParameters>
        <asp:ControlParameter ControlID="Label3" Name="ID" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>



      </ItemTemplate>
    </asp:ListView>


    

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT MainPageCategoryId, MainPageCategory, Status FROM dbo.MainPageCategory WHERE (Status = N'Active')"></asp:SqlDataSource>





            