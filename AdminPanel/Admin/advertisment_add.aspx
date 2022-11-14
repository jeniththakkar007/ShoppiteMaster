<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="advertisment_add.aspx.cs" Inherits="AdminPanel.Admin.advertisment_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row ">

        <div class="form-horizontal col-md-6 col-md-offset-3">
            <h3 class="bold">Add a new Banner  <small class="pull-right">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="black-c bold margin5 " CausesValidation="False" PostBackUrl="~/Admin/advertisement_all.aspx">Back to List</asp:LinkButton>
            </small>
            </h3>
            <div class="form padding15 border white-bg l-grey-bd radius">

                <h4 class="padding15 no-margin l-yellow-bg">Add banner
                </h4>
                <hr>
                <div class="textbox-2">
                    <div class="form-group">
                        Banner Position
                              <asp:DropDownList ID="ddlposition" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlposition_SelectedIndexChanged">
                                  <asp:ListItem Value="0">Select</asp:ListItem>
                              </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" ControlToValidate="ddlposition" InitialValue="0" CssClass="required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        Image Size should be
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text=""></asp:Label>
                        <br />
                        <label class="file-upload">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <span class="btn btn-default center">Upload Image</span>
                        </label>
                    </div>

                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CausesValidation="false" OnClick="Upload" Style="display: none" />

                    <script type="text/javascript">
            function UploadFile(fileUpload) {
                if (fileUpload.value != '') {
                    document.getElementById("<%=btnUpload.ClientID %>").click();
                }
            }
                    </script>
                </div>
                <asp:Label ID="lblerror" runat="server" CssClass="alert alert-danger padding10 w-100 center" Text=""></asp:Label>
                <div class="form-group ad-banner">
                    <asp:Image ID="Image1" runat="server" Width="100%" />
                </div>
                <div class="form-group">
                    Select Page
                                 <div class="radiobtn">
                                     <asp:CheckBoxList ID="chckpage" runat="server">
                                     </asp:CheckBoxList>

                                     <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please select at least one item."
                                         CssClass="required" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
                                 </div>
                </div>
                <div class="textbox-2">
                    <div class="form-group">
                        Select Date
                              <asp:TextBox ID="txtstartdate" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" ControlToValidate="txtstartdate" CssClass="required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        End Date
                              <asp:TextBox ID="txtenddate" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="txtenddate" CssClass="required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    Description
                                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" ControlToValidate="txtdescription" CssClass="required"></asp:RequiredFieldValidator>
                </div>

                <script>
                                 $(document).ready(function () {
                                     //$('#summernote').summernote();

                                     $('[id*=txtdescription]').summernote()
                                 });
                </script>

                <div class="form-group">
                    Status
                                 <div class="radiobtn">
                                     <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                         <asp:ListItem Selected="True">Active</asp:ListItem>
                                         <asp:ListItem>In Active</asp:ListItem>
                                     </asp:RadioButtonList>
                                 </div>

                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="pull-right" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
    function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=chckpage.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
    }
    </script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.7.1/css/bootstrap-datepicker3.min.css" />

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.7.1/js/bootstrap-datepicker.min.js"></script>

    <script>
    $(function () {
        $('[id*=txtstartdate]').datepicker({
            changeMonth: true,
            changeYear: true,

        });
    });

    $(function () {
        $('[id*=txtenddate]').datepicker({
            changeMonth: true,
            changeYear: true,

        });
    });
    </script>
</asp:Content>