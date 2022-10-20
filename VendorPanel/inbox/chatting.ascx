<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chatting.ascx.cs" Inherits="VendorPanel.inbox.chatting" %>






<asp:UpdatePanel runat="server" ClientIDMode="AutoID">
    <ContentTemplate>
        <asp:Timer ID="timer" runat="server" Interval="100" OnTick="Timer1_Tick" >
        </asp:Timer>
<asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound" OnItemCommand="ListView1_ItemCommand">


  
    
    <ItemTemplate>



        <asp:Panel ID="Panel1" runat="server">

       

                             <asp:Image ID="Image3" runat="server"  ImageUrl="~/images/profileimg.jpg" Visible="false" />
             <asp:Label ID="Label2" runat="server" Text='<%# Eval("shopname") %>' CssClass="sendby" Visible="true"></asp:Label>
              <asp:Label ID="lblusername" runat="server" Text='<%# Eval("sender") %>' CssClass="sendby" Visible="false"></asp:Label>
            
               <br />
             <h5>

                             



                            
                             
                            
                  <asp:Label ID="Label5" runat="server"  CssClass="msg" Text='<%# ConvertTextUrlToLink (Eval("message1").ToString()) %>'></asp:Label>
                         
                                 <%--<asp:Label ID="Label5" runat="server"  CssClass="msg" Text='<%# Eval("message1") %>'></asp:Label>--%>
                         <br />
    <small> <asp:Label ID="Label4" runat="server" Text='<%# Eval("senddate") %>'></asp:Label>
                                </small></h5>
                      
   </asp:Panel>

           <asp:Label ID="lblattachment" runat="server" Text='<%# Eval("attachment") %>' Visible="false"></asp:Label> 
        <div class="padding" style="display:none;">
            
            
             
        
                   

                    
                
                      <h5 class="no-margin">

                
                      <asp:Image ID="Image1" runat="server" Width="40px"  CssClass="img-circle o-f" />  
                            <small> </small>



                      
   </h5>

                      <p class="grey-c">
                         
                       
                   
                          <asp:Panel ID="Panel2" runat="server" Visible="false">
                             <div class=" white-bg padding10 line-h shadow">
                                    <h4 class="bold black-c">
                                        New Custome Offer <asp:Label ID="lblofferstatus" runat="server" Text="" Visible="true" CssClass="label label-danger" Font-Size="10px"></asp:Label>   <asp:Label ID="lblfees" runat="server" Text="" CssClass="pull-right"></asp:Label>
                                    </h4>
                                     <hr class="margin5" />
                                 
                                 
                                 <asp:Label ID="lbldescription" runat="server" Text=""></asp:Label>
                                 <span class="pull-right center">
   <i class="far fa-clock theme-c"></i>  <asp:Label ID="lbldatetime" runat="server" Text="" ></asp:Label> <br />
           
                             <asp:LinkButton ID="lnkinvoice" Text="Accept Offer" runat="server" CommandName="invoice" CssClass="btn green-bg white-c btn-xs"></asp:LinkButton>
                               <asp:LinkButton ID="lnkwithdraw" Text="With Draw Offer" runat="server" CommandName="withdraw" CssClass="btn blue-bg white-c btn-xs"></asp:LinkButton>      </span>    <br /><br />   </div>
                         
                                 
                        


                           
                         
                              
                             

                              <asp:Label ID="lblbookingid" Visible="false" runat="server" Text='<%# Eval("sessionbookingid") %>'></asp:Label>



   
                          </asp:Panel>
                     
<asp:LinkButton Visible="false" ID="LinkButton1" runat="server" CommandName="download" CssClass="btn btn-xs theme-bd white-bg theme-c pull-right"><i class="fas fa-cloud-download-alt"></i> Attachment</asp:LinkButton>
                    </p>
               
                           
                

                          
                      
   </div>
           
    

    </ItemTemplate>


</asp:ListView>
<asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>

           </ContentTemplate>

       <Triggers>
        <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
    </Triggers> 

</asp:UpdatePanel>