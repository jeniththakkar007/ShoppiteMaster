<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FundsDetails.aspx.cs" Inherits="FrontPanel.Donation.FundsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link href="../Content/noheader.css" rel="stylesheet" />

    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <h3>
<asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label>
                </h3>
                <hr />
<asp:Image ID="imgdonatoin" runat="server" Width="100%" />
                <br /> <br />
                <h5>
<asp:Label ID="lbldescription" runat="server" Text="Label"></asp:Label>
                </h5>
            </div>
            <div class="col-md-4 padding15">
                   <div class="white-bg border radius padding15">
                    <h3 class="bold">
                    Donation summury
                </h3>
                <hr />
                  <h5>
                  Amount:      <strong class="pull-right fonts ">
<asp:Label ID="lblamount" runat="server" Text="Label"></asp:Label>  <asp:Label ID="lblcurrency" runat="server" Text="Label"></asp:Label> 
                      </strong>

                            </h5><hr />
             <h5>
   Amount Received:   <strong class="pull-right fonts "> <asp:Label ID="lblamountreceived" runat="server" Text="Label"></asp:Label>

       </strong>
             </h5><hr />

         <h5>
  Balance Needed:   <strong class="pull-right fonts ">  <asp:Label ID="lblbalance" runat="server" Text="Label"></asp:Label>   </strong>
         </h5>

<hr />
   

                <h5>
 Campaign Start Date:   <strong class="pull-right fonts ">  <asp:Label ID="lblcampaignstartdate" runat="server" Text="Label"></asp:Label>
     </strong>
                </h5>
                <hr />
<asp:Button ID="Button1" runat="server" Text="Donate" OnClick="Button1_Click" CssClass="btn theme-bg f-theme w-100" />
    <asp:Label ID="lblpaypalid" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>


        </div>




  

    

    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
