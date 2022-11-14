<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="VendorPackages.aspx.cs" Inherits="AdminPanel.Admin.VendorPackages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
    <div class="page_title">
        <h1>Vendor Membership Package
        </h1>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h4 class="padding15 no-margin l-yellow-bg">Craete Page
            </h4>
            <div class="form border white-bg shadow radius padding15">

                <div class="form-horizontal  ">

                    <div class="form-group checkright">
                        Membership Type:
                 <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="True">
                     <asp:ListItem>Free</asp:ListItem>
                     <asp:ListItem>One Time</asp:ListItem>
                     <asp:ListItem Selected="True">Recurring</asp:ListItem>
                 </asp:RadioButtonList>
                    </div>

                    <div class="form-group">
                        Title:
                   <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txttitle" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Package Description:
                   <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdescription" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group" id="recurringperiod" runat="server">
                        Recurring Period in Days:
                   <asp:TextBox ID="txtrecurringperiod" runat="server" TextMode="Number"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtrecurringperiod" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">

                        <asp:DropDownList ID="ddlcurrency" AppendDataBoundItems="true" runat="server" CssClass="center">
                            <asp:ListItem Value="0">Currency</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="ddlcurrency" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                        Fees:
                   <asp:TextBox ID="txtfees" runat="server"></asp:TextBox>
                        /
                        <asp:TextBox ID="txtunit" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtfees_FilteredTextBoxExtender" TargetControlID="txtfees" ID="txtfees_FilteredTextBoxExtender" FilterType="Custom,Numbers" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtunit" Display="Dynamic"></asp:RequiredFieldValidator>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtfees" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group checkright">
                        Status: (active will show on front end)
  <asp:CheckBox ID="CheckBox1" Text="IsActive" runat="server" />
                    </div>

                    <div class="form-group">
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
                    $(document).ready(function () {
                        //$('#summernote').summernote();

                        $('[id*=txtdescription]').summernote()
                    });
    </script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>
</asp:Content>