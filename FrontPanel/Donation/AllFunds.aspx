<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllFunds.aspx.cs" Inherits="FrontPanel.Donation.AllFunds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="../Content/noheader.css" rel="stylesheet" />
    <div class="container">  <br />   <h4 class="no-margin padding5">     Top Fundraisers   
                </h4>
            <br />
        <div class="row">
<asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
        <ItemTemplate>
            <div class="col-md-3 padding5">
                <div class="border radius">
                    <div class="img-box h-220">
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' />
                                    </div>
                    <div class="padding10">
                    <h5 class="line20">
   <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>'></asp:Label> <br />
                        <small>
      <asp:Label ID="Label5" runat="server" Text='<%#Eval("shortdescription") %>'></asp:Label>
                        </small>
                    </h5>
                        <hr />
                        <p>

                    
    <strong>
        <asp:Label ID="Label1" runat="server" Text='<%#Eval("totalreceived") %>'></asp:Label> raised 
    </strong>  of <asp:Label ID="Label4" runat="server" Text='<%#Eval("Amount") %>' ></asp:Label>      <asp:LinkButton ID="LinkButton2" CommandName="pay"  runat="server" Text="Donate" CssClass="btn btn-xs theme-bg pull-right f-theme"></asp:LinkButton>    </p>
                </div>
            </div>
            <asp:Label ID="Label2" Visible="false" runat="server" Text='<%#Eval("RequestFundGUID") %>'></asp:Label>
           
</div>
        </ItemTemplate>
    </asp:ListView>
        </div>
    </div>
 

    
</asp:Content>
