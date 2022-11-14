<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Image_uploadasync_uc.ascx.cs" Inherits="VendorPanel.usercontrol.Image_uploadasync_uc" %>

<div class="white-bg shadow">
    <h4 class="padding15 no-margin">Product Cover Image
    </h4>

    <hr class="no-margin" />
    <br />
    <label class="file-upload">
        <span class="border radius padding15">Select Image</span>
        <asp:FileUpload ID="fubanner" runat="server" />
    </label>
    <span class="pull-right">

        <asp:Image ID="imgbanner" runat="server" Width="100px" /></span>
    <br />
    <br />
    <br />
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