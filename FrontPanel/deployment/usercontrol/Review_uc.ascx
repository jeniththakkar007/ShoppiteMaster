<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review_uc.ascx.cs" Inherits="FrontPanel.usercontrol.Review_uc" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <style>
     .ratingEmpty {
         background-image: url(../../../Starrating/ratingStarEmpty.gif);
       
          width:18px;
         height: 18px;
     }
.ratingFilled
{
background-image: url(../../../Starrating/ratingStarFilled.gif);
width:18px;
height:18px;
}
.ratingSaved
{
 background-image: url(../../../Starrating/ratingStarSaved.gif);
width:18px;
height:18px;
}


    </style>



&nbsp;


<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Write Review</h4>
      </div>
      <div class="modal-body">
    <div class="form noshadow noborder">


              
                   <asp:Label ID="Label1" runat="server" Text="Post Review" CssClass="bold"></asp:Label> <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" CurrentRating="3" CssClass="pull-right"></ajaxToolkit:Rating>
<br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="Post" CssClass="btn btn-black" OnClick="Button1_Click" /><br /><br />
                </div>
      </div>
    
    </div>
  </div>
</div>



