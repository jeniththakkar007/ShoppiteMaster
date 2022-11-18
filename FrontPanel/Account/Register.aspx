<%@ Page Title="Register" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FrontPanel.Account.Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckBox1.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
    <link href="../Content/noheader.css" rel="stylesheet" />
    <div class="container ">
        <div class="row box-center margin-tb" onkeypress="return WebForm_FireDefaultButton(event, '<%= signupbtn.ClientID %>')">

            <div class="col-md-6 padding15">
                <div class="border l-grey-bd radius  margin15 o-margin padding15">

                    <h3 class="center">Sign up
                    </h3>
                    <hr />

                    <div class="padding15">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>

                        <div class="form-horizontal form">

                            <div class="form-group" id="vendor" runat="server" visible="false">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtshopname" placeholder="Shop Name" />

                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtshopname_FilteredTextBoxExtender" runat="server" BehaviorID="txtshopname_FilteredTextBoxExtender" FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtshopname" ValidChars=" "></ajaxToolkit:FilteredTextBoxExtender>

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/shop.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtshopname"
                                    CssClass="required" ErrorMessage="The Shop name field is required." ValidationGroup="profile" SetFocusOnError="True" Display="Dynamic" />

                                <br />

                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtphone" placeholder="Phone Number" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/shop.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtphone"
                                    CssClass="required" ErrorMessage="The Phone field is required." ValidationGroup="profile" SetFocusOnError="True" Display="Dynamic" />
                                <br />
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtaddress" placeholder="Shop Address" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/shop.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtaddress"
                                    CssClass="required" ErrorMessage="The address field is required." ValidationGroup="profile" SetFocusOnError="True" Display="Dynamic" />
                            </div>

                            <div class="form-group">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtemail" placeholder="Email Address" TextMode="Email" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/envelop.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail"
                                    CssClass="required" ErrorMessage="The email field is required." ValidationGroup="profile" SetFocusOnError="True" Display="Dynamic" />

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="True" runat="server" CssClass="required" ValidationGroup="profile" ControlToValidate="txtemail" ErrorMessage="Valid email is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" placeholder="Password" />

                                    <span class="input-group-addon">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/lock.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" SetFocusOnError="True" ControlToValidate="txtpassword" CssClass="required" ErrorMessage="The password field is required." ValidationGroup="profile" Display="Dynamic" />
                            </div>
                            <div class="form-group">

                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtconfirmpassword" placeholder="Confirm Password" TextMode="Password" />
                                    <span class="input-group-addon">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/lock.png" Height="15px" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" SetFocusOnError="True" ControlToValidate="txtconfirmpassword"
                                    CssClass="required" Display="Dynamic" ErrorMessage="The confirm password field is required." ValidationGroup="profile" />
                                <asp:CompareValidator runat="server" SetFocusOnError="True" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword"
                                    CssClass="required" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." ValidationGroup="profile" />
                            </div>

                            <div class="form-group ">
                                <asp:Button runat="server" ID="signupbtn" OnClick="CreateUser_Click" Text="Sign up" ValidationGroup="profile" CssClass="w-100" OnClientClick="if (!Page_ClientValidate('profile')){ return false; } this.disabled = true; this.value = 'Processing...';" UseSubmitBehavior="False" />
                            </div>

                            <h5 class="grey-c checkright">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="I accept to the " /><asp:HyperLink ID="hypterms" runat="server" Target="_blank"> Terms and Conditions</asp:HyperLink>

                                <asp:CustomValidator ID="CustomValidator1" ValidationGroup="profile" CssClass="required" runat="server" ErrorMessage="Please acccept Terms & Conditions" ClientValidationFunction="ValidateCheckBox"></asp:CustomValidator>
                            </h5>

                            <hr />

                            <h5 class="right">Already have an account?
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="c-green-c bold" PostBackUrl="~/Account/Login.aspx" CausesValidation="False">Log in</asp:LinkButton>
                            </h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&sensor=false&key=AIzaSyD_Ia-RHd5bIWMLLL05tUJlDy_7DHb2--4"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            //var options = { types: ['(cities)'] };
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txtaddress.ClientID%>'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                //alert(mesg);
            });
        });
    </script>
</asp:Content>