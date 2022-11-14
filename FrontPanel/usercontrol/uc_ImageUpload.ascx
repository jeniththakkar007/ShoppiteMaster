<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ImageUpload.ascx.cs" Inherits="FrontPanel.user_controls.uc_ImageUpload" %>

<div class="border padding5 radius pull-left w-100 form-group">

    <span class="pull-right">

        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/usernoimage.png" CssClass="radius" Width="100px" />
        <br />
    </span>
    Photo
    <br />
    <small class="grey-c visible-lg">Follow our guidelines to choose or take a great photo.
        <br />
        JPG or PNG format; maximum size of 2MB
    </small>
    <label class="file-upload">
        <span class="btn btn-default margin5">Upload Photo</span>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </label>
</div>

<asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />

<script type="text/javascript">
            function UploadFile(fileUpload) {
                if (fileUpload.value != '') {
                    document.getElementById("<%=btnUpload.ClientID %>").click();
                }
            }
</script>