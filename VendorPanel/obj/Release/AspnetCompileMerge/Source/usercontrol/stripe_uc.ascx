<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="stripe_uc.ascx.cs" Inherits="FrontPanel.usercontrol.stripe_uc" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>


  
                   

               <div class="form-horizontal form  padding10">  <h3 class="bold ">

           
                   Card Details
                    

      


      </h3>    <br />
<div class="textbox-2">

<div class="form-group">
    Full Name
    <asp:TextBox ID="txtfullname" runat="server" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="required" runat="server" ValidationGroup="pay" ControlToValidate="txtfullname" ErrorMessage="Please Enter Full Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

</div>

                   

<div class="form-group">
    
    CARD NUMBER 
    <asp:TextBox ID="txtcardnumber" runat="server" placeholder="Valid Card Number"  Text=""></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="required" runat="server" ControlToValidate="txtcardnumber" ValidationGroup="pay" ErrorMessage="Please Enter Card Number" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


</div>
</div>
<div class="textbox-3">



<div class="form-group">
    EXPIRATION MONTH

    <div>
        <asp:TextBox ID="txtmonth" runat="server" placeholder="MM"  MaxLength="2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="required" ValidationGroup="pay" runat="server" ControlToValidate="txtmonth" ErrorMessage="Please Enter Month" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

        <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtmonth_FilteredTextBoxExtender" TargetControlID="txtmonth" ID="txtmonth_FilteredTextBoxExtender" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender>
    </div></div>
                                    <div class="form-group">
                                      EXPIRATION Year
                                        
                                         <asp:TextBox ID="txtyear" runat="server" placeholder="YYYY" MaxLength="4"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="required" runat="server" ValidationGroup="pay" ControlToValidate="txtyear" ErrorMessage="Please Enter Year" ForeColor="Red"  ></asp:RequiredFieldValidator>


                                        <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtmonth_FilteredTextBoxExtender" TargetControlID="txtyear" FilterType="Numbers" ID="FilteredTextBoxExtender1"></ajaxToolkit:FilteredTextBoxExtender>
                                    </div> <div class="form-group">CVC 
    <asp:TextBox ID="txtcvc" runat="server" placeholder="CVC"  Text=""></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="required" runat="server" ControlToValidate="txtcvc" ValidationGroup="pay" ErrorMessage="Please Enter CVC" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


</div>
                                 </div>
                                   </div> 

<asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

<%--  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/3.3.4/inputmask/inputmask.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/3.3.4/inputmask/inputmask.extensions.min.js"></script>

  <script type="text/javascript">
    $(function () {
        var inputmask = new Inputmask("####-####-####-####");
        inputmask.mask($('[id*=txtcardnumber]'));
    });
</script>




  <script type="text/javascript">
      $(function () {
          var inputmask = new Inputmask("###");
          inputmask.mask($('[id*=txtcvc]'));
      });
</script>


  <script type="text/javascript">
      $(function () {
          var inputmask = new Inputmask("##");
          inputmask.mask($('[id*=txtmonth]'));
      });
</script>


  <script type="text/javascript">
      $(function () {
          var inputmask = new Inputmask("####");
          inputmask.mask($('[id*=txtyear]'));
      });
</script>
