<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Image_uploadasync_uc.ascx.cs" Inherits="AdminPanel.usercontrol.Image_uploadasync_uc" %>
  <div class="col-md-6">
      <label class="file-upload">
                            <span class="border radius padding15">Select Image</span>
                            <asp:FileUpload ID="fubanner" runat="server" />
                        </label>

                        <asp:Image ID="imgbanner" runat="server"  Width="100px" />
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