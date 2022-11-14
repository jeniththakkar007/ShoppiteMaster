<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="review_view_uc.ascx.cs" Inherits="FrontPanel.usercontrol.review_view_uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div class="row">

    <br />
    <asp:ListView ID="ListView1" runat="server">
        <EmptyDataTemplate>
            <div class="box-center">
                <div class="confirmation">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/nosearchfound.png" />
                    <h3>No Reviews
                        <br />
                        <br />
                    </h3>
                </div>
            </div>
        </EmptyDataTemplate>
        <ItemTemplate>

            <div class="col-md-6 nopadding">

                <h5 class="border l-grey-bd radius padding5 line20">
                    <%--   <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("profileimage") %>' />--%>

                    <%-- <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>--%>

                    <br>
                    <small>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("InsertDate") %>'></asp:Label>
                    </small>

                    <small><span>

                        <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" CurrentRating='<%#Eval("Star") %>' Enabled="False" ReadOnly="True" CssClass="pull-right"></ajaxToolkit:Rating>
                    </span>
                        <br />
                    </small>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Comments") %>' CssClass="d-grey-c"></asp:Label></h5>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>