<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Add_categories.aspx.cs" Inherits="AdminPanel.Admin.Add_categories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>
    <div class="white-smoke-bg padding15">
        <span class="pull-right">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="black-c bold margin5 " CausesValidation="False" PostBackUrl="~/Admin/Category_View.aspx">Back to List</asp:LinkButton>
            <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold btn-lg h-fonts" OnClick="lnksave_Click">Save</asp:LinkButton></span>

        <h3 class="bold">Add a new category
        </h3>

        <asp:ValidationSummary ID="ValidationSummary1" CssClass="required" runat="server" />
    </div>
    <div class="form form-horizontal padding10">

        <h4 class="padding15 no-margin l-yellow-bg">Category info
        </h4>
        <div class="white-bg ">
            <br />
            <div class="form-group row">
                <div class="col-md-2 right">
                    Name
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Category Required" CssClass="required" ControlToValidate="txtname" Display="Dynamic"></asp:RequiredFieldValidator>
                    <cc1:FilteredTextBoxExtender runat="server" BehaviorID="txtname_FilteredTextBoxExtender" FilterType="Custom, UppercaseLetters, LowercaseLetters, Numbers" TargetControlID="txtname" ID="txtname_FilteredTextBoxExtender" ValidChars=" "></cc1:FilteredTextBoxExtender>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-2 right">
                    Parent Category (If Any)
                </div>
                <div class="col-md-4">
                    <%--<asp:DropDownList ID="ddlcat" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="catnames" DataValueField="ID">
                    <asp:ListItem Value="0">None</asp:ListItem>
                </asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlcat" runat="server">
                        <%--<asp:ListItem Value="0">None</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-2 right">
                    Upload Category Icon
                </div>
                <div class="col-md-4">
                    <label class="file-upload">
                        <span class="border radius padding15">Select Image</span>
                        <asp:FileUpload ID="fuicon" runat="server" />
                    </label>

                    <asp:Image ID="imgicon" runat="server" Width="50px" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-2 right">
                    Upload Category Banner
                </div>
                <div class="col-md-6">
                    <label class="file-upload">
                        <span class="border radius padding15">Select Image</span>
                        <asp:FileUpload ID="fubanner" runat="server" />
                    </label>

                    <asp:Image ID="imgbanner" runat="server" Width="100px" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-2 right">
                    Description
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"></asp:TextBox>

                    <script>
                                    $(document).ready(function () {
                                        //$('#summernote').summernote();

                                        $('[id*=txtdescription]').summernote()
                                    });
                    </script>
                </div>
            </div>

            <div class="form-group row" runat="server" visible="false">
                <div class="col-md-2 right">
                    Display Order
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtdisplayorder" runat="server" Text="1" min="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Display Order Required" CssClass="required" ControlToValidate="txtdisplayorder" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <br />
        <div class="white-bg">
            <h4 class="padding15 no-margin l-yellow-bg">Display
            </h4>
            <div class="form-group row">

                <div class="col-md-4 col-md-offset-2">
                    <div class="checkright padding15 line20">

                        <asp:CheckBox ID="chkpublish" runat="server" Text="Published" Checked="True" />
                        <asp:CheckBox ID="chkshowhomepage" runat="server" Text="Show on home page" />
                        <asp:CheckBox ID="chkincludeinmenu" runat="server" Text="Include in top menu" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="white-bg">
            <h4 class="padding15 no-margin l-yellow-bg">SEO
            </h4>
            <br />

            <div class="form-group row">
                <div class="col-md-2 right">
                    Search engine friendly page name
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtpagename" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-2 right">
                    Meta title
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtmetatitle" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-2 right">
                    Meta keywords
                </div>
                <div class="col-md-4">

                    <asp:TextBox ID="txtkeywords" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-2 right">
                    Meta description
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtmetadescription" runat="server" TextMode="MultiLine"></asp:TextBox>
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

    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="sp_getcat" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="SqlDataSourceOrg" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SP_getorg" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>