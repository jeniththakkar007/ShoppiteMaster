<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="logo.aspx.cs" Inherits="Adminweb.Admin.logo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page_title">
        <h1>Website Configration
        </h1>
        <hr />
    </div>

    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <div class="col-md-12">

        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div class="row box-center">
        <div class="col-lg-8 col-md-10">

            <div class="form ">

                <div>
                    <div class="form-horizontal">
                        <div class="form-group">

                            <div class="border white-bg padding15 row">
                                <div class="col-md-8">
                                    <h4>Header Logo
                                        <br />
                                        <small>This logo will show on header in website</small>
                                    </h4>
                                    <label class="file-upload">
                                        <asp:FileUpload ID="FU1" runat="server" Width="100%" />
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                                        <span class="btn btn-default ">Select Image</span>
                                        <script type="text/javascript">
                                    function UploadFile(fileUpload) {
                                        if (fileUpload.value != '') {
                                            document.getElementById("<%=btnUpload.ClientID %>").click();
                                }
                            }
                                        </script>
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <div class="img-box h-155">
                                        <asp:Image ID="Image2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="border white-bg padding15 row" runat="server" visible="false">
                                <div class="col-md-8">
                                    <h4>Mobile Logo
                                        <br />
                                        <small>This logo will show on mibile view in website</small>   </h4>

                                    <label class="file-upload">
                                        <span class="btn btn-default">Select Image</span>

                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
                                        <asp:Button ID="Button1" Text="Upload" runat="server" OnClick="Upload1" Style="display: none" />

                                        <script type="text/javascript">
                                    function UploadFile1(fileUpload1) {
                                        if (fileUpload1.value != '') {
                                            document.getElementById("<%=Button1.ClientID %>").click();
                                        }
                                    }
                                        </script>
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <div class="img-box h-155">
                                        <asp:Image ID="Image1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="border white-bg padding15 row">
                                <div class="col-md-8">
                                    <h4>Favicon
                                        <br />

                                        <asp:Label ID="lblerror" ForeColor="red" runat="server" Text=""></asp:Label>
                                        <small>Upload image in ico format</small>
                                    </h4>
                                    <label class="file-upload">
                                        <span class="btn btn-default">Select Image</span>

                                        <asp:FileUpload ID="FileUpload2" runat="server" Width="100%" />
                                        <asp:Button ID="Button3" Text="Upload" runat="server" OnClick="Upload2" Style="display: none" />

                                        <script type="text/javascript">
                                    function UploadFile2(fileUpload2) {
                                        if (fileUpload2.value != '') {
                                            document.getElementById("<%=Button3.ClientID %>").click();
                                        }
                                    }
                                        </script>
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <div class="img-box h-155">
                                        <asp:Image ID="Image3" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="form-group">

                            <h4>Company Detail<br />
                                <small>This is your company detail which will be use through out the website</small>
                            </h4>
                            <div class="border white-bg padding15  ">
                                <div class="textbox-2">
                                    <div class="form-group">
                                        Company Name
                                          <div class="textbox">
                                              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                          </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Feild Required" ValidationGroup="seo" CssClass="text text-danger" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        Support Contact Number<br />
                                        <div class="textbox">
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="textbox-2">
                                    <div class="form-group">
                                        Address
                                    <div class="textbox">
                                        <asp:TextBox ID="TextBox4" runat="server" required></asp:TextBox>
                                    </div>
                                    </div>
                                    <div class="form-group">
                                        Support Email
                                    <div class="textbox">
                                        <asp:TextBox ID="TextBox1" runat="server" required></asp:TextBox>
                                    </div>
                                    </div>
                                </div>

                                <br />
                                <br />
                                <br />
                            </div>
                            <br />
                            <h4>Seo Meta Tags<br />
                                <small>It will improve your search engine </small>
                            </h4>
                            <div class="border white-bg padding15  ">

                                <div class="textbox-2">
                                    <%--                                   <div class="form-group ">Search engine friendly page name
   <asp:TextBox ID="txtpagename" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Feild Required" ValidationGroup="seo" CssClass="text text-danger" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                     </div>--%>

                                    <div class="form-group ">
                                        Meta title
 <asp:TextBox ID="txtmetatitle" runat="server" MaxLength="500"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Feild Required" ValidationGroup="seo" CssClass="text text-danger" ControlToValidate="txtmetatitle"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="textbox-2">
                                    <div class="form-group ">
                                        Meta keywords
                          <asp:TextBox ID="txtkeywords" runat="server" MaxLength="500"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Feild Required" ValidationGroup="seo" CssClass="text text-danger" ControlToValidate="txtkeywords"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group ">
                                        Meta description (max 500 Character)
   <asp:TextBox ID="txtmetadescription" runat="server" MaxLength="500"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Feild Required" ValidationGroup="seo" CssClass="text text-danger" ControlToValidate="txtmetadescription"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:Button ID="Button4" runat="server" Text="Save" ValidationGroup="seo" OnClick="Button1_Click" CssClass="pull-right" />

                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Default %>" InsertCommand="INSERT INTO Slider(SliderImage, Status) VALUES (@Image, @Status)" ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" SelectCommand="SELECT Logo, logowidth, logoheight, CompanyName, Address, SupportContact, FooterLogo, Favicon, Title, Keyword, Description FROM dbo.Logo" UpdateCommand="UPDATE dbo.Logo SET Logo = @Image, logowidth = @logowidth, logoheight = @logoheight, CompanyName = @companyname, Address = @address, SupportContact = @support, FooterLogo = @footerlogo, Favicon = @favicon, Title = @title, Keyword = @keyword, Description = @description">
        <InsertParameters>
            <asp:ControlParameter ControlID="RadioButtonList1" Name="Status" PropertyName="SelectedValue" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter DefaultValue="0" Name="logowidth" />
            <asp:Parameter DefaultValue="0" Name="logoheight" />
            <asp:ControlParameter ControlID="TextBox3" Name="companyname" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox4" Name="address" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox5" Name="support" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtmetatitle" Name="title" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtkeywords" Name="keyword" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtmetadescription" Name="description" PropertyName="Text" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>