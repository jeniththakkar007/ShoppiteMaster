<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="seo_uc.ascx.cs" Inherits="AdminPanel.usercontrol.seo_uc" %>

<div class="white-bg shadow">
    <h4 class="padding15 no-margin">SEO
    </h4>

    <hr class="no-margin" />
    <br />

    <div class="paddingrf-15">

        <div class="form-group ">
            Search engine friendly page name
   <asp:TextBox ID="txtpagename" runat="server"></asp:TextBox>
        </div>
        <div class="form-group ">
            Meta title
 <asp:TextBox ID="txtmetatitle" runat="server"></asp:TextBox>
        </div>
        <div class="form-group ">
            Meta keywords
                          <asp:TextBox ID="txtkeywords" runat="server"></asp:TextBox>
        </div>
        <div class="form-group ">
            Meta description
   <asp:TextBox ID="txtmetadescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>

    <br />
</div>