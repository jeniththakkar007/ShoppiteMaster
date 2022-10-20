<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="discount_module_uc.ascx.cs" Inherits="AdminPanel.usercontrol.discount_module_uc" %>

<div class="form-group">

Discount Type:<asp:RadioButtonList ID="RadioButtonList1" runat="server">
    <asp:ListItem Selected="True">Percentage</asp:ListItem>
    <asp:ListItem>Flat</asp:ListItem>
</asp:RadioButtonList>
</div>
<div class="form-group">
Discount Offer: <asp:TextBox ID="txtdiscountoffer" runat="server"></asp:TextBox>

                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="discount" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdiscountoffer" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
<div class="form-group">
Start Date: <asp:TextBox ID="txtdisstartdate" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="discount" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdisstartdate" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
<div class="form-group">
End Date:<asp:TextBox ID="txtdisenddate" runat="server"></asp:TextBox>

 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ValidationGroup="discount"  CssClass="required" ControlToValidate="txtdisenddate" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
<div class="checkright">
<asp:CheckBox ID="CheckBox1" runat="server" Text="Active" />
</div>
<script>
    $(function () {
        $('[id*=txtdisstartdate]').datepicker({
            changeMonth: true,
            changeYear: true
        });
    });



    $(function () {
        $('[id*=txtdisenddate]').datepicker({
            changeMonth: true,
            changeYear: true
        });
    });
  </script>


<asp:Button ID="Button1" runat="server"  ValidationGroup="discount" Text="Save" OnClick="Button1_Click" />

