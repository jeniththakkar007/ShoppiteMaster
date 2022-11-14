<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_price_uc.ascx.cs" Inherits="AdminPanel.usercontrol.product_price_uc" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<div class="white-bg shadow">
    <h4 class="padding15 no-margin">Pricing
    </h4>

    <hr class="no-margin" />
    <br />
    <div class="row form-group">

        <div class="col-md-3">
            Currency
              <asp:DropDownList ID="ddlcurrency" AppendDataBoundItems="true" runat="server" CssClass="center">
                  <asp:ListItem Value="0">Currency</asp:ListItem>
              </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="ddlcurrency" ValidationGroup="pro" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-3">
            Price
            <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtprice_FilteredTextBoxExtender" TargetControlID="txtprice" ID="txtprice_FilteredTextBoxExtender" FilterType="Custom,Numbers" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtprice" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-3 ">
            Old Price
                    <asp:TextBox ID="txtoldprice" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtoldprice_FilteredTextBoxExtender" TargetControlID="txtoldprice" ID="FilteredTextBoxExtender1" FilterType="Custom,Numbers" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtoldprice" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" ValidationGroup="pro" CssClass="required"
                runat="server" ControlToValidate="txtprice" ControlToCompare="txtoldprice"
                Operator="LessThan" Type="Double" ErrorMessage="Price must be less than old price" Display="Dynamic"></asp:CompareValidator>
        </div>

        <div class="col-md-3 ">
            Shipping Fees
                    <asp:TextBox ID="txtdeliveryfees" runat="server" Text="0"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtdeliveryfees_FilteredTextBoxExtender" TargetControlID="txtdeliveryfees" ID="FilteredTextBoxExtender2" FilterType="Custom,Numbers" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdeliveryfees" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row form-group">

        <div class="padding15 checkright">
            <asp:CheckBox ID="chckdisablebuybutton" runat="server" Text="Disable Buy Button" />
            <asp:CheckBox ID="chcktaxexempt" runat="server" Text="Tax exempt" />
        </div>
    </div>
</div>