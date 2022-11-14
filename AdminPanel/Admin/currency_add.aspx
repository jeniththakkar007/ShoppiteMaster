<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="currency_add.aspx.cs" Inherits="AdminPanel.Admin.currency_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <span class="pull-right margin15">

        <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold btn-lg h-fonts" OnClick="lnksave_Click">Save</asp:LinkButton></span>
    <h3 class="bold padding10">Add a new Currency
    </h3>

    <div class="form form-horizontal margin10 ">
        <h4 class="padding15 border no-margin l-yellow-bg">Currency
        </h4>
        <div class="white-bg  border">
            <br />
            <div class="row form-group">
                <div class="col-md-2 right">
                    Currency  Name
                </div>
                <div class="col-md-4 ">
                    <asp:TextBox ID="txtcurrency" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtcurrency" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-2 right">
                    Is Published
                </div>
                <div class="col-md-4 ">
                    <asp:CheckBox ID="chkpublish" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="grid">
        <h3 class="bold padding10">All Currencies
        </h3>
        <table>
            <tr>
                <th style="width: 45px">Edit
                </th>
                <th style="width: 1475px">Currency
                </th>
            </tr>
            <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">
                <ItemTemplate>

                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("CurrencyId") %>' Visible="false"></asp:Label>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="ed" CssClass="edit"></asp:LinkButton>
                        </td>
                        <td style="width: 1475px">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("CurrencyName") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>