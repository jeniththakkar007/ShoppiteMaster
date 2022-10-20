<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="allmessages.ascx.cs" Inherits="FrontPanel.inbox.allmessages" %>


<asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" OnItemDataBound="ListView1_ItemDataBound" DataSourceID="SqlDataSource1">
   
    <ItemTemplate>
    
           <div class="all-msgs d-inbox ">
                   <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="myFunction();" CommandName="chat" CausesValidation="false">
               <h6>
                               <asp:Label ID="Label3" runat="server" CssClass="badge pull-right theme-bg"></asp:Label>
                                       <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("avatar") %>' CssClass="m-none" />   


 <asp:Label ID="Label1" runat="server" Text='<%# Eval("chatid") %>' Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("username") %>' Visible="false" ></asp:Label>
                <%--     <asp:Label ID="Label4" runat="server" Text='<%# Eval("shopname") %>' ></asp:Label>--%>

                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("shopname") %>'></asp:Label>

                

                                <br />
                            
                            </h6>   
                       
                       
                       
                       
                  
              
              </asp:LinkButton>     
               <asp:LinkButton ID="LinkButton2" CommandName="del" runat="server" CssClass="pull-right delete-i red-c"><i class="far fa-trash-alt"></i></asp:LinkButton>
               
               
            
                    </div>




      
        <asp:Panel ID="Panel1" runat="server"  CssClass="inbox-selected">  </asp:Panel> 
  
      
    </ItemTemplate>


</asp:ListView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SP_AllMessages" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="HiddenField1" Name="UserName" PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:HiddenField ID="HiddenField1" runat="server" />




  

