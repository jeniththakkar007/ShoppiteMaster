<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="websitesetup.aspx.cs" Inherits="AdminPanel.Admin.websitesetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page_title">
        <h1>Website Setup
        </h1>
    </div>

    <div class="row">

        <div class="border white-bg padding15 form radius shadow">
            <div class="form-horizontal row">
                <div class="col-md-4">
                    <div class="form-group">
                        Setup Name
                        <asp:TextBox ID="txtsetupname" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Setup Name Required" CssClass="required" ControlToValidate="txtsetupname" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        Value <small>0 if not applied</small>
                        <asp:TextBox ID="txtvalue" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Value Required" CssClass="required" ControlToValidate="txtvalue" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        Description
                        <asp:TextBox ID="txtdes" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Value Required" CssClass="required" ControlToValidate="txtdes" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group checkright">

                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Active" /><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="grid " style="overflow: auto">
        <asp:GridView ID="GridView1" DataKeyNames="WebsiteSetupId" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table-responsive">
            <Columns>
                <asp:CommandField SelectText="Edit" ShowSelectButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>