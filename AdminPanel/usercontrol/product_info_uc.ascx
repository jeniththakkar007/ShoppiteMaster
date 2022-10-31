<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_info_uc.ascx.cs" Inherits="AdminPanel.usercontrol.product_info_uc" %>



<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<div class="row">
    <div class="col-md-8 no-padding">
        <div class="white-bg padding15 shadow">
            <br />
           
            <div class="form-group">
                Product Name
                    <asp:TextBox ID="txtproductname" runat="server"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender runat="server" BehaviorID="txtproductname_FilteredTextBoxExtender"  FilterType="Custom, UppercaseLetters, LowercaseLetters, Numbers" TargetControlID="txtproductname" ID="txtproductname_FilteredTextBoxExtender" ValidChars=" "></ajaxToolkit:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtproductname" Display="Dynamic" ValidationGroup="pro"></asp:RequiredFieldValidator>

            </div>

            <br />
            


            <div class="form-group">
                Short Description
                    <asp:TextBox ID="txtshortdescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtshortdescription" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{30,200}$" runat="server" ErrorMessage="Minimum 30 and Maximum 200 characters required." CssClass="required" ValidationGroup="pro"></asp:RegularExpressionValidator>

            </div>

            <div class="form-group">
                Description
                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"></asp:TextBox>



                <script>
                    $(document).ready(function () {
                        //$('#summernote').summernote();


                        $('[id*=txtdescription]').summernote()
                    });
                </script>

            </div>



            














        </div>

        <br />
        <div class="white-bg  shadow">
            <h4 class="padding15 no-margin">Inventory
            </h4>

            <hr class="no-margin" />
            <br />

            <div class="row">
            <div class="form-group col-md-6">
                SKU
                    <asp:TextBox ID="txtsku" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtsku" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group col-md-6">
                Product Quantity
                    <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtqty" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group col-md-6">
                Start Date 
                <asp:TextBox ID="txtstartdate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtstartdate" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group col-md-6">
                End Date
                           
                    <asp:TextBox ID="txtenddate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtenddate" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
        </div></div>

        <br />


    </div>
</div>
<div class="row">
    <div class="col-md-8 no-padding">
        <div class="white-bg padding15 shadow ">

            <div class="form-group">
                Categories
                <br />
                <small>Press Ctrl to select multiple categories</small>
                <br />
                <%-- <asp:TextBox ID="txtcategories" runat="server"></asp:TextBox>--%>
                <div class="dropdown">
                 
                        Select Categries 
                        <asp:ListBox ID="ListBox1" runat="server"  Height="500px" SelectionMode="Single"></asp:ListBox>

                    
                </div>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="ListBox1" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                Brands
                <br />
                <small>Press Ctrl to slect multiple brands </small>
                <br />
        
                


                <div class="dropdown">
                    <button class="btn btn-default w-100 dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                        Select Brands
    <span class="caret"></span>
                    </button>

                    <ul class="dropdown-menu dropdown-menu-form" aria-labelledby="dropdownMenu2" style="width: 500px; height: 500px;">
                        <asp:ListBox ID="ListBox2" runat="server"  Height="500px"></asp:ListBox>
                    </ul>
                </div>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="ListBox2" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group checkright">
                <asp:CheckBox ID="chkpublish" runat="server" Text="Published" Checked="True" />


                <asp:CheckBoxList ID="chkstatus" runat="server">
                </asp:CheckBoxList>


            </div>

            <div class="form-group">
                Tags
                    <asp:TextBox ID="txttags" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txttags" ValidationGroup="pro" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>

        </div>
    </div>
</div>

 <script>
    $("document").ready(function () {

        $('.dropdown-menu').on('click', function (e) {
            if ($(this).hasClass('dropdown-menu-form')) {
                e.stopPropagation();
            }
        });
    });
</script>


<asp:Label ID="lblchklist" Visible="false" runat="server" Text=""></asp:Label>


<link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
<script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>


<%-- <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="https://resources/demos/style.css">
<%--  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>--%>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<script>
    $(function () {
        $('[id*=txtstartdate]').datepicker({
            changeMonth: true,
            changeYear: true
        });
    });



    $(function () {
        $('[id*=txtenddate]').datepicker({
            changeMonth: true,
            changeYear: true
        });
    });
  </script>


<asp:Label ID="lblcatlist" Visible="false" runat="server" Text=""></asp:Label>

<asp:Label ID="lblbrandlist" Visible="false" runat="server" Text=""></asp:Label>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="sp_getcat_withoutparent" SelectCommandType="StoredProcedure">
     <%--<SelectParameters>
        <asp:ControlParameter Name="ContactName" ControlID="txtSearch" PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="false"/>
    </SelectParameters>--%>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSourceOrg" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SP_getorg" SelectCommandType="StoredProcedure"></asp:SqlDataSource>