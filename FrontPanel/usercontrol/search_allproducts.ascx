<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="search_allproducts.ascx.cs" Inherits="FrontPanel.usercontrol.search_allproducts" %>

<%--<script type="text/javascript" language="javascript">

   Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoadedHandler)

function pageLoadedHandler(sender, args)

{

         window.scrollTo(0,0);

}
</script>--%>


<%--<script type="text/javascript">
    var xPos, yPos, needScroll;
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(BeginRequestHandler);
    prm.add_pageLoaded(EndRequestHandler)

    function BeginRequestHandler(sender, args) {
        xPos = 0;
        yPos = window.pageYOffset || document.documentElement.scrollTop;
    }

    function EndRequestHandler(sender, args) {
        if (needScroll) {
            window.setTimeout("window.scrollTo(" + xPos + "," + yPos + ")", 100);
        }
    }
</script> --%>


   <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                   <div class="loading">

                     <i class="fas fa-spinner fa-pulse fa-4x"></i>
                    </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

                          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
  
    <div class="row">

    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" OnItemDataBound="ListView1_ItemDataBound" >

       <EmptyDataTemplate>
           <div class="box-center">
               <div class="confirmation">
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/nosearchfound.png" />
                   <h3>
                      Search No Result <br /> <br />
                       <small>
We're sorry. We cannot find any matches for your search term.</small>
                   </h3>
               </div>
           </div>
       </EmptyDataTemplate>

            <ItemTemplate>

                  <asp:Label ID="lblid" runat="server" Text='<%#Eval("ProductId") %>' Visible="false"></asp:Label>

<div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 padding5">

     
          
          
                                 <div class="white-bg radius padding5 shadow-hover border radius"> 
                                          
                                     
                                       <asp:LinkButton ID="lnkhomeproduct"  ClientIDMode="AutoID" CommandName="lk" runat="server" CssClass="p-unlike"> <span class="theme-c padding5 label bold"><%#Eval("totalpick") %></span></asp:LinkButton> 
                                     <a href="/<%# Eval("Productid") %>-<%# Eval("urlpath") %>/show">
           

               <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("badgestatus") %>' CssClass="c-badge" />
                                    <div class="img-box h-220 section1">
                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%#Eval("image") %>' />
                                    </div>
                                    <div class="padding5">
                                        <p class="h-30 no-margin small">
                                        <%#Eval("ProductName") %>
                                        </p>
                                        <span class="black-c red-c large"><%#Eval("Price") %> <%#Eval("currencyname") %></span><br />
                                        
</div>
                              </a>    </div>
         
                            </div>

            </ItemTemplate>
        </asp:ListView>
</div>

<div class="center padding10">

                
    <div class="center">
<asp:Repeater ID="rptPager" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>'  CommandArgument='<%#Eval("Value") %>'
            Enabled='<%#Eval("Enabled") %>' OnClick="Page_Changed"  CssClass="btn btn-default btn-xs" />
    </ItemTemplate>
</asp:Repeater>

 </div>

<%--
<asp:LinkButton ID="LinkButton1" runat="server"   OnClick="LinkButton1_Click" CssClass="btn theme-bg f-theme btn-xs margin5">Back</asp:LinkButton><asp:LinkButton ID="LinkButton2"  CssClass="btn theme-bg f-theme btn-xs margin5" runat="server" OnClick="LinkButton2_Click">Next</asp:LinkButton>--%>



</div>

          </ContentTemplate>
 
</asp:UpdatePanel>