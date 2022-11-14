<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchvendor.aspx.cs" Inherits="FrontPanel.searchvendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row margintb-15">
            <div class="col-lg-2 padding5 m-none">
                <div class="border radius padding10 form">
                    <h4>Search Filter
                    </h4>
                    <hr />
                    <div class="form-group">
                        Keyword for product search
                <asp:TextBox ID="txtkeyword" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        Search Location
                <asp:TextBox ID="txtarea" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlradiussearch" runat="server">
                            <asp:ListItem Selected="True" Value="5">5 Miles</asp:ListItem>
                            <asp:ListItem Value="10">10 Miles</asp:ListItem>
                            <asp:ListItem Value="15">15 Miles</asp:ListItem>
                            <asp:ListItem Value="20">20 Miles</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        Catgeories
             <asp:ListBox ID="lstcat" Height="300px" runat="server" DataSourceID="SqlDataSource1" DataTextField="catnames" DataValueField="catnames" CssClass="small"></asp:ListBox>
                    </div>

                    <asp:LinkButton ID="LinkButton1" PostBackUrl="~/searchvendor.aspx" CssClass="btn-xs btn btn-default" runat="server">Clear All Search</asp:LinkButton>
                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="padding5" OnClick="Button1_Click" />
                    <br />

                    <br />
                    <br />
                </div>
            </div>
            <div class="col-lg-10">

                <asp:Label ID="lblsearch" runat="server" Text="" CssClass="bold large margintb-15"></asp:Label>

                <div class="row">

                    <asp:ListView ID="ListView1" runat="server">

                        <EmptyDataTemplate>
                            No Record Found
                        </EmptyDataTemplate>

                        <ItemTemplate>

                            <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 padding5">

                                <div class="white-bg radius padding5 shadow-hover border radius">

                                    <a href="/<%#Eval("shopurl") %>/StoreProducts" target="_blank">

                                        <div class="img-box h-155 section1">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("logo") %>' />
                                        </div>
                                        <div class="padding5">
                                            <h5 class="h-30 no-margin ">
                                                <%#Eval("ShopName") %>
                                                <br />
                                                <small>Total Product:
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("totalproducts") %>' CssClass="bold "></asp:Label>
                                                </small>
                                            </h5>
                                            <p class="h-40 no-margin">
                                                <small><%#Eval("address") %></small>
                                            </p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT displayorder, catnames, Displayname, NAME, HLevel, PARENT_NAMEID, ID, CAST(ID AS nvarchar(20)) + '-' + urlpath AS urlpath, ID AS Expr1, (SELECT CAST(category_id AS nvarchar(20)) + '-' + urlpath AS mainurlpath FROM dbo.f_topcat(getcat_1.ID) AS f_topcat_1) AS topcat FROM dbo.getcat(0) AS getcat_1 WHERE (HLevel = 0) ORDER BY catnames"></asp:SqlDataSource>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&sensor=false&key=AIzaSyD_Ia-RHd5bIWMLLL05tUJlDy_7DHb2--4"></script>
    <script type="text/javascript">

    $(function () {

        var textbox1 = $(this).find('[id*=txtarea]');

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
        initialize(document.getElementById('<%=txtarea.ClientID%>'));

        directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
    })
    </script>

    <asp:HiddenField ID="hdnlat" runat="server" />
    <asp:HiddenField ID="hdnlong" runat="server" />
</asp:Content>