<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_Images_uc.ascx.cs" Inherits="AdminPanel.usercontrol.product_Images_uc" %>

<div class="white-bg shadow">
    <h4 class="padding15 no-margin">Cover Images
    </h4>

    <hr class="no-margin" />
    <br />
    <br />

    <div class="row form-group">

        <div class="col-md-6">
            Upload Image
            <br />
            <label class="file-upload">
                <span class="btn btn-default w-100 s-bold ">Select Image</span>
                <asp:FileUpload ID="fuicon" runat="server" />
            </label>

            <asp:Image ID="imgicon" runat="server" Width="50px" Visible="false" />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="fuicon" Display="Dynamic" ValidationGroup="img"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            Display order
                    <asp:TextBox ID="txtdisplayorder" runat="server" TextMode="Number" min="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdisplayorder" Display="Dynamic" ValidationGroup="img"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row form-group">
        <div class="col-md-6">
            Image Title
                    <asp:TextBox ID="txtimagetitle" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            Alt
                    <asp:TextBox ID="txtalt" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row form-group paddingrf-15">

        <asp:Button ID="Button1" runat="server" ValidationGroup="img" Text="Add Picture" OnClick="Button1_Click" />
    </div>

    <div class="grid padding15">
        <table>

            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">

                <ItemTemplate>
                    <asp:Label ID="Label3" Visible="false" runat="server" Text='<%#Eval("ProductImagesId") %>'></asp:Label>
                    <tr>
                        <td style="width: 1000px">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Displayorder") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' Width="100px" />
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="rem" CssClass="Delete">Remove</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</div>