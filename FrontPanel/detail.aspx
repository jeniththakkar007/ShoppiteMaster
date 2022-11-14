<%@ Page Title="Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="detail.aspx.cs" Inherits="FrontPanel.detail" %>

<%@ Register Src="~/usercontrol/slider_detail.ascx" TagPrefix="uc1" TagName="slider_detail" %>
<%@ Register Src="~/usercontrol/Review_uc.ascx" TagPrefix="uc1" TagName="Review_uc" %>
<%@ Register Src="~/usercontrol/review_view_uc.ascx" TagPrefix="uc1" TagName="review_view_uc" %>

<%@ Register Src="~/usercontrol/detail_variation.ascx" TagPrefix="uc1" TagName="detail_variation" %>
<%@ Register Src="~/usercontrol/detail_vendor_uc.ascx" TagPrefix="uc1" TagName="detail_vendor_uc" %>
<%@ Register Src="~/usercontrol/thumbnail_slider.ascx" TagPrefix="uc1" TagName="thumbnail_slider" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/usercontrol/detail_payment_accepted.ascx" TagPrefix="uc1" TagName="detail_payment_accepted" %>

<%--<%@ OutputCache Duration="120" VaryByParam="*" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
       var prm = Sys.WebForms.PageRequestManager.getInstance();
       prm.add_beginRequest(beginRequest);

       function beginRequest() {
           prm._scrollPosition = null;
       }
    </script>

    <uc1:Review_uc runat="server" ID="Review_uc" />
    <div class="margintb-15">
        <div class="container ">
            <p>
                <asp:Label ID="lblbreadcrumb" runat="server" Text=""></asp:Label>
            </p>
            <div class="row border">
                <div class="col-md-5 padding10 sep-r">
                    <uc1:slider_detail runat="server" ID="slider_detail" />
                </div>
                <div class="col-md-7 no-padding ">
                    <div class="padding15">
                        <h4><small>Brand:
                            <asp:Label ID="lblbrand" runat="server" Text="Label" CssClass="text-primary"></asp:Label>
                        </small>
                            <br />
                            <asp:Label ID="lblproduct" runat="server" Text="Label"></asp:Label>
                        </h4>
                        <h4 class="no-margin">
                            <small>
                                <asp:Label ID="lblshortdes" runat="server" Text="Short description"></asp:Label>
                            </small>
                            <br />
                            <small>

                                <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" CurrentRating='<%#Eval("Star") %>' Enabled="False" ReadOnly="True" CssClass="margin5"></ajaxToolkit:Rating>

                                <%--<i class="fa fa-star yellow-c"></i><i class="fa fa-star yellow-c"></i><i class="fa fa-star yellow-c"></i><i class="fa fa-star yellow-c"></i><i class="fa fa-star yellow-c"></i> (4.1) --%>

                                <asp:LinkButton ID="LinkButton4" runat="server" data-toggle="modal" data-target="#myModal" CausesValidation="False" CssClass="btn orange-bg white-c margin5 no-radius  btn-xs">
 Write Review
                                </asp:LinkButton>
                            </small>
                        </h4>

                        <%--        <h3 class="bold  ">
                        <asp:Label ID="lblsaleprice" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblcurrency2" runat="server" Text="Label"></asp:Label>
                        <small>
                            <asp:Label ID="lbloldprice" runat="server" Text="Label" Font-Strikeout="True"></asp:Label>
                            <asp:Label ID="lblcurrecny" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblsave" runat="server" Text="You save " CssClass="l-green-bg small white-c btn-xs no-radius"></asp:Label>
                        </small>
                    </h3>
                  <hr />--%>
                        <div class="">
                            <uc1:detail_variation runat="server" ID="detail_variation" />
                            <div>
                                <h6>Quantity:
                                </h6>
                                <div class="number">
                                    <span class="minus">-</span>
                                    <asp:TextBox ID="TextBox1" runat="server" Text="1"></asp:TextBox>
                                    <span class="plus">+</span>
                                </div>
                                <%--       <div class="center">
                               <asp:Label ID="Label1" runat="server" Text="Only 1 item left" CssClass="small grey-c"></asp:Label></div>--%>
                            </div>
                        </div>
                    </div>

                    <div class="padding15 row">
                        <div class="col-md-6 no-padding">

                            <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="buynow" CssClass="btn no-radius theme-bg f-theme h-fonts upp bold" OnClick="LinkButton1_Click">Buy Now</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="buynow" CssClass="btn no-radius red-bg white-c h-fonts upp bold" OnClick="LinkButton2_Click">Add to Cart</asp:LinkButton>

                            <uc1:detail_payment_accepted runat="server" ID="detail_payment_accepted" />
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn  no-radius grey-c btn-default " OnClick="LinkButton3_Click"><i class="far fa-heart"></i></asp:LinkButton>
                        </div>
                        <div class="col-md-6">

                            <uc1:detail_vendor_uc runat="server" ID="detail_vendor_uc" />
                        </div>
                    </div>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-3 m-none no-padding d-new">

                    <div class=" border radius">

                        <uc1:thumbnail_slider runat="server" ID="thumbnail_slider3" />
                        <%--  <div class="white-bg radius padding5 margin5 ">
                       <div class="img-box h-220 section1">
                           <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/sampleproduct.jpeg" />
                       </div>
                       <div class="padding5 section2">
                     <p class="h-30 no-margin v-center small">
                       Xiaomi Redmi Note 7  </p>
                       <span class="black-c bold">$183.99</span> <br />
                          <i class="fa fa-star yellow-c"></i>       <i class="fa fa-star yellow-c"></i>
                    </div>
                   </div>--%>
                        <%--  <hr class="white-bd" />--%>
                    </div>
                </div>
                <!-- thumbanil Slider -->

                <!-- Similar Product -->
                <div class="col-md-9 no-padding">
                    <div class="margin-left border">

                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs white-smoke-bg" role="tablist">
                            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Details</a></li>
                            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Reviews</a></li>
                            <%--    <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Shipping and Payments</a></li>
    <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Product FAQ</a></li>--%>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content padding15">
                            <div role="tabpanel" class="tab-pane active" id="home">
                                <asp:Label ID="lbldescription" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div role="tabpanel" class="tab-pane" id="profile">
                                <uc1:review_view_uc runat="server" ID="review_view_uc" />
                            </div>
                            <div role="tabpanel" class="tab-pane" id="messages">...</div>
                            <div role="tabpanel" class="tab-pane" id="settings">...</div>
                        </div>
                    </div>
                    <div class="margin15 ">
                        <h4 class="padding10 no-margin">Recommended
                        </h4>
                        <div class="white-smoke-bg padding10">
                            <div class="white-bg">
                                <uc1:thumbnail_slider runat="server" ID="thumbnail_slider" />
                            </div>
                        </div>
                    </div>
                    <div class="margin15 ">
                        <h4 class="padding10 no-margin">Similar Product
                        </h4>
                        <div class="white-smoke-bg padding10">
                            <div class="white-bg">

                                <uc1:thumbnail_slider runat="server" ID="thumbnail_slider1" />
                            </div>
                        </div>
                    </div>

                    <div class="margin15 ">
                        <%-- <h4 class="padding10 no-margin">Recenlty Viewed
                    </h4>--%>
                        <div class="white-smoke-bg padding10">
                            <div class="white-bg">

                                <uc1:thumbnail_slider runat="server" ID="thumbnail_slider2" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Recentlt viwed -->
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:HiddenField ID="HiddenField2" runat="server" />

    <button data-toggle="modal" id="btnShowPopup1" data-target="#myModal1" style="visibility: hidden;">gfdfgdfg</button>
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm c-shadow center white-bg">
            <h3 class="bold no-margin ">Product Added Successfully
               <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" class="grey-c small">&times;</span></button>--%>
            </h3>
            <hr />
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/added.png" Width="100px" />
            <p>
                You product has been added into cart
            </p>
            <hr />
            <div class="row">
                <div class="col-xs-6">
                    <asp:Button ID="Button4" runat="server" Text="Continue Shopping" PostBackUrl="~/Default.aspx" CssClass="btn white-bg grey-c border grey-bd" />
                </div>
                <div class="col-xs-6">
                    <asp:Button ID="Button5" runat="server" Text="Checkout" PostBackUrl="~/cart.aspx" CssClass="btn theme-bg black-c" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowPopup1() {
            $("#btnShowPopup1").click();
        }
    </script>

    <div id="dvhours" style="display: none">
        <asp:Label ID="lblbprogrss" runat="server" CssClass="loading">     <i class="fas fa-spinner fa-pulse fa-3x color" style="z-index:100000;"></i> </asp:Label>
    </div>

    <script type="text/javascript">
        function myFunction() {

            document.getElementById("dvhours").style.display = "block";

            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblbprogrss.ClientID %>").style.display = "none";
            }, seconds * 1000);

        }
    </script>

    <style>
        .loading {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

            .loading i {
                position: fixed;
                top: 50%;
                right: 50%;
                color: white;
            }
    </style>
</asp:Content>