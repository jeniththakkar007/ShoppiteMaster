<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="brand_add.aspx.cs" Inherits="AdminPanel.Admin.brand_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <span class="pull-right margin15">
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="black-c bold margin5 " CausesValidation="False" PostBackUrl="~/Admin/brand_view.aspx">Back to List</asp:LinkButton>
        <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold btn-lg h-fonts" OnClick="lnksave_Click">Save</asp:LinkButton></span>
    <h3 class="bold padding10">Add a new Brand Detail
    </h3>

    <div class="form form-horizontal margin10 ">
        <h4 class="padding15 border no-margin l-yellow-bg">Add Brand
        </h4>
        <div class="white-bg  border">
            <br />

            <div class="row form-group">
                <div class="col-md-2 right">
                    Category
                </div>
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlcategory" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" InitialValue="0" ControlToValidate="ddlcategory" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-2 right">
                    Brand Name
                </div>
                <div class="col-md-4 ">
                    <asp:TextBox ID="txtbrandname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtbrandname" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-2 right">
                    Description
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine"></asp:TextBox>

                    <script>
                                    $(document).ready(function () {
                                        //$('#summernote').summernote();

                                        $('[id*=txtdesc]').summernote()
                                    });
                    </script>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-2 right">
                    Brand Image
                </div>
                <div class="col-md-4">
                    <label class="file-upload">
                        <span class="border radius padding15">Select Image</span>
                        <asp:FileUpload ID="fuicon" runat="server" />
                    </label>

                    <asp:Image ID="imgicon" runat="server" CssClass="pull-right" Width="60px" />
                </div>
            </div>

            <div class="row form-group">

                <div class="col-md-4 col-md-offset-2 checkright">
                    <asp:CheckBox ID="chckpublish" runat="server" Text="Publish" Checked="True" />
                </div>
            </div>
        </div>
    </div>

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

    <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>
</asp:Content>