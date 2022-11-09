<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="imagemultiupload-uc.ascx.cs" Inherits="AdminPanel.usercontrol.imagemultiupload_uc" %>
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<%--<script language="javascript" type="text/javascript">
    $(function () {
        $('[id*=fuUpload1]').change(function () {
            if (typeof (FileReader) != "undefined") {
                var dvPreview = $("#dvPreview");
                dvPreview.html("");
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                $($(this)[0].files).each(function () {
                    var file = $(this);
                    if (regex.test(file[0].name.toLowerCase())) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var img = $("<img />");
                            img.attr("style", "max-height:250px;width: 150px");
                            img.attr("src", e.target.result);
                            dvPreview.append(img);
                        }
                        reader.readAsDataURL(file[0]);
                    } else {
                        alert(file[0].name + " is not a valid image file.");
                        dvPreview.html("");
                        return false;
                    }
                });
            } else {
                alert("This browser does not support HTML5 FileReader.");
            }
        });
    });
</script>--%>


<script type="text/javascript">
    $(function () {
        $('[id*=fuUpload1]').change(function () {
            if (typeof (FileReader) != "undefined") {
                var dvPreview = $("[id*=dvPreview]");
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
                $($(this)[0].files).each(function () {
                    var file = $(this);
                    if (regex.test(file[0].name.toLowerCase())) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var img = $("<img />");
                            img.attr("style", "max-height:250px;width: 150px");
                            img.attr("src", e.target.result);
                            dvPreview.append(img);
                        }
                        reader.readAsDataURL(file[0]);
                    } else {
                        alert(file[0].name + " is not a valid image file.");
                        dvPreview.html("");
                        return false;
                    }
                });
            } else {
                alert("This browser does not support HTML5 FileReader.");
            }
        });
    });
</script>



   
   <div class="white-bg shadow">
    <h4 class="padding15 no-margin">
     Other Images of Product
    </h4>

    <hr class="no-margin" />
    <br />


<label class="file-upload center">
                                        <span class="btn btn-default">
                                            
                                            <i class="fa fa-image"></i> &nbsp;
                                            Select Images</span>   
                                           
                                    
        <asp:FileUpload ID="fuUpload1" runat="server" multiple="multiple" /> 
                                        
                                      </label>
                                 
    
    
  
<div id="dvPreview">
</div> 

         <asp:Button ID="btnUpload" Text="Upload" runat="server" Visible="false"  Width="100%" CssClass="btn btn-default" OnClick="btnUpload_Click" />


<div class="row">

    <asp:Label ID="lblfile" runat="server" Text="" Visible="false"></asp:Label>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                  <ProgressTemplate>
                      Updating....
                  </ProgressTemplate>
              </asp:UpdateProgress>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>

<asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
    <ItemTemplate>
        <div class="col-md-4 padding5">
            <div class="multi-img-upl radius padding5">
       <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CssClass="pull-right btn btn-xs red-bg white-c"><i class="fa fa-times"></i></asp:LinkButton> 
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductImagesId") %>' Visible="false" ></asp:Label>
        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' CssClass="radius" Width="100px" />
</div>
        </div>
    </ItemTemplate>

</asp:ListView>
                       </ContentTemplate>
              </asp:UpdatePanel>
</div></div> 