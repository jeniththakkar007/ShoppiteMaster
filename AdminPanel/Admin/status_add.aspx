<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="status_add.aspx.cs" Inherits="AdminPanel.Admin.status_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="bold padding10"></h3>

    <div class="form form-horizontal margin10 ">
        <div class="row">
            <div class="col-md-3">

                <div class="white-bg  border padding10">
                    <h4 class="padding5 bold no-margin">Add a new Product Status
                    </h4>
                    <hr />
                    <div class="form-group">
                        Name

                    <asp:TextBox ID="txtstatus" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtstatus" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Status Image<br />
                        <label class="file-upload">
                            <span class="btn btn-default">Select Image</span>
                            <asp:FileUpload ID="FileUpload1" runat="server" /></label>

                        <asp:Image ID="Image1" runat="server" CssClass="pull-right" Width="80px" />
                    </div>
                    <div class="row form-group checkright">

                        <asp:CheckBox ID="chckhomepage" runat="server" Text=" Is Show on Home page" />
                        <br />
                        <asp:Label ID="lblerror" runat="server" Text="" CssClass="required"></asp:Label>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold btn-lg h-fonts pull-right" OnClick="lnksave_Click">Save</asp:LinkButton>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-7 col-md-offset-1">
                <div class="grid">
                    <table>
                        <tr>
                            <th style="width: 45px">Edit
                            </th>
                            <th style="width: 45px">Delete
                            </th>
                            <th style="width: 1475px">Name
                            </th>
                            <th style="width: 1475px">Image
                            </th>
                        </tr>
                        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                            <ItemTemplate>

                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Statusid") %>' Visible="False"></asp:Label>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ed" CausesValidation="False" CssClass="btn btn-success white-c l-bold btn-xs">Edit</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" CssClass="btn btn-danger white-c l-bold btn-xs" CausesValidation="False">Delete</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Status1") %>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("cssclass") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>