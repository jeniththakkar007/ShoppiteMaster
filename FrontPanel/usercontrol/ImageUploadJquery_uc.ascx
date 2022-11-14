<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadJquery_uc.ascx.cs" Inherits="FrontPanel.usercontrol.ImageUploadJquery_uc" %>

<div class="border padding5 radius pull-left w-100 form-group">

    <span class="pull-right">
        <asp:Image ID="imgicon" runat="server" CssClass="radius" Width="100px" />
        <br />
    </span>
    Upload Image
    <br />
    <%-- <small class="grey-c visible-lg">
        Follow our guidelines to choose or take a great photo.
    </small> --%>
    <br />
    <label class="file-upload">
        <span class="btn btn-default margin5">Select Image</span>
        <asp:FileUpload ID="fuicon" runat="server" />
    </label>
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