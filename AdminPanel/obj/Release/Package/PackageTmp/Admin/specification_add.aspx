<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="specification_add.aspx.cs" Inherits="AdminPanel.Admin.specification_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



      <span class="pull-right margin15">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="black-c bold margin5 " CausesValidation="False" PostBackUrl="~/Admin/specification_view.aspx">Back to List</asp:LinkButton>

            <asp:LinkButton ID="lnksave" runat="server" CssClass="btn green-bg white-c bold btn-lg h-fonts" OnClick="lnksave_Click" >Save</asp:LinkButton></span>

        <h3 class="bold padding10">Add a new Specification
           
        </h3>
   
    <div class="form form-horizontal margin10 ">
          <h4 class="padding15 border no-margin l-yellow-bg">Add Specification
        </h4>
        <div class="white-bg  border">
            <br />
              <div class="row form-group">
                <div class="col-md-2 right">
                 Select Attribute
                    </div> 
                <div class="col-md-4 ">
                    <asp:DropDownList ID="ddlattribute" runat="server"></asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="ddlattribute" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>
                  <div class="col-md-2">
                      <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn blue-bg white-c margin5" PostBackUrl="~/Admin/attribute_add.aspx" CausesValidation="False">
                          Add New Attribute
                      </asp:LinkButton>
                  </div>

                </div> 
            <div class="row form-group">
                <div class="col-md-2 right">
                  Specification Name
                    </div> 
                <div class="col-md-4 ">
                    <asp:TextBox ID="txtspecificationname" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtspecificationname" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>

                </div> 

              <div class="row form-group">
                <div class="col-md-2 right">
                  Description
                    </div> 
                <div class="col-md-8">
                    <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine"></asp:TextBox>


                    </div>

        </div> </div></div>







</asp:Content>
