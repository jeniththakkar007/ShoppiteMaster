<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="VendorPanel.Admin.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--   <div class="alert alert-danger">
        Please complete your profile to add Product
    </div>--%>
    <div class="row">
        <div class="col-md-6 col-md-offset-3 no-padding">

            <div class="alert alert-success center alert-dismissible" role="alert" id="dvsave" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                Your Profile has been succesfully save
            </div>

            <div class="white-bg padding15 shadow form">
                <h3 class="bold  no-margin">My Profile
                </h3>
                <br />

                <div class="border padding5 radius form-group ">

                    <div class="c-logo pull-right">
                        <asp:Image ID="imgicon" runat="server" Width="50px" />
                        <br>
                    </div>

                    Cover Image
                    <br>
                    <small class="grey-c visible-lg">Upload your Cover Image here
                        <br>
                    </small>
                    <br>
                    <label class="file-upload ">
                        <span class="btn btn-default margin5">Upload Photo</span>
                        <asp:FileUpload ID="fuicon" runat="server" />
                    </label>
                </div>

                <div class="border padding5 radius form-group ">

                    <div class="c-logo pull-right">
                        <asp:Image ID="imgbanner" runat="server" />
                        <br>
                    </div>

                    Logo
                    <br>
                    <small class="grey-c visible-lg">Upload your company logo here
                        <br>
                    </small>
                    <br>
                    <label class="file-upload ">
                        <span class="btn btn-default margin5">Upload Photo</span>
                        <asp:FileUpload ID="fubanner" runat="server" />
                    </label>
                </div>
                <div class="form-group">
                    Shop Name
           <asp:TextBox ID="txtshopname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtshopname" Display="Dynamic" ValidationGroup="profile"></asp:RequiredFieldValidator>
                </div>
                <div class="textbox-2">
                    <div class="form-group">
                        Contact Number
           <asp:TextBox ID="txtcontactnumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtcontactnumber" Display="Dynamic" ValidationGroup="profile"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="textbox-2">
                    <div class="form-group">
                        Country

   <asp:DropDownList ID="ddlcountry" runat="server">
       <asp:ListItem Value="0">Select Country</asp:ListItem>
   </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlcountry"
                            CssClass="required" ErrorMessage="Field Required." ValidationGroup="profile" InitialValue="0" />
                    </div>

                    <div class="form-group">
                        City

    <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcity"
                            CssClass="required" ErrorMessage="Field Required." ValidationGroup="profile" />
                    </div>
                </div>
                <div class="textbox-2">
                    <div class="form-group">
                        Zip

    <asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtzipcode"
                            CssClass="required" ErrorMessage="Field Required." ValidationGroup="profile" />
                    </div>

                    <div class="form-group">
                        State

    <asp:TextBox ID="txtstate" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    Address

    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtaddress"
                        CssClass="required" ErrorMessage="Field Required." ValidationGroup="profile" />
                </div>

                <div class="form-group">
                    Shop Description
           <asp:TextBox ID="txtshortdesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtshortdesc" Display="Dynamic" ValidationGroup="profile"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    Paypal Id
           <asp:TextBox ID="txtpaypalid" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtpaypalid" Display="Dynamic" ValidationGroup="profile"></asp:RequiredFieldValidator>--%>
                </div>

                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="profile" OnClick="Button1_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        $(function () {
            $('[id*=fubanner]').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('[id*=imgbanner]').attr("src", e.target.result).attr("style", "");
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            alert(file[0].name + " is not a valid image file.");
                            return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('[id*=txtzipcode]').on('blur', function () {
                var url = 'https://ziptasticapi.com/' + $(this).val().trim();
                $.getJSON(url, function (response) {
                    $('[id*=txtcity]').val(response.city);
                    $('[id*=txtstate]').val(response.state);
                    //$('[id*=lblCountry]').html(response.country);
                });
            });
        });
    </script>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&sensor=false&key=AIzaSyCXH-IGTEU4esvnu4S7QQYLpGDLUoFDU40"></script>
    <script type="text/javascript">

    $(function () {

        var textbox1 = $(this).find('[id*=txtaddress]');

        ApplyAutoComplete(textbox1);

    });
    function ApplyAutoComplete(input) {
        google.maps.event.addDomListener(window, 'load', function () {
            var places;
            for (var i = 0; i < input.length; i++) {
                var options = { types: ['(cities)'] };
                places = new google.maps.places.Autocomplete(input[i], options);
            }
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var mesg = "Address: " + address;
            });
        });
    }
    var source, destination;
    var directionsDisplay;
    var directionsService = new google.maps.DirectionsService();

    function initialize(textBox) {
        var input = textBox;
        var options = {
            types: ['(cities)']
            // Uncomment if restrict for Country.
            //, componentRestrictions: { country: 'in' }
        };
        var autocomplete = new google.maps.places.Autocomplete(input, options);
    }

    google.maps.event.addDomListener(window, 'load', function () {
        initialize(document.getElementById('<%=txtaddress.ClientID%>'));

        directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
    })
    </script>

    <script language="javascript" type="text/javascript">
        $(function () {
            $('[id*=fubanner]').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('[id*=imgbanner]').attr("src", e.target.result).attr("style", "height:100px;width: 100px;");
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            alert(file[0].name + " is not a valid image file.");
                            return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>

    <script language="javascript" type="text/javascript">
        $(function () {
            $('[id*=fuicon]').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                    $($(this)[0].files).each(function () {
                        var file = $(this);
                        if (regex.test(file[0].name.toLowerCase())) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('[id*=imgicon]').attr("src", e.target.result).attr("style", "height:100px;width: 100px;");
                            }
                            reader.readAsDataURL(file[0]);
                        } else {
                            alert(file[0].name + " is not a valid image file.");
                            return false;
                        }
                    });
                } else {
                    alert("This browser does not support HTML5 FileReader.");
                }
            });
        });
    </script>
</asp:Content>