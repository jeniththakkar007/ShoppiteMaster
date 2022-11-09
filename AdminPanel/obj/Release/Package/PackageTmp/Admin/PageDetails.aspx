<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="PageDetails.aspx.cs" Inherits="Adminweb.Admin.PageDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    


     <div class="row">
        <div class="col-md-11">
  
         <h3 class="bold"><span class="pull-right">
            
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green-bg white-c bold" PostBackUrl="~/Admin/PageCat.aspx" CausesValidation="False">Add New Page</asp:LinkButton></span>
              Pages
        </h3> 
    
 <div class="form border white-bg shadow radius ">
           <h4 class="padding15 no-margin l-yellow-bg"> Add Content
        </h4>
           <div class="form-horizontal padding15 ">
               <div class="form-group">
                  Select Page Name:
                  <asp:DropDownList ID="ddlpage" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlpage_SelectedIndexChanged">
                      <asp:ListItem Value="0">Select Page</asp:ListItem>
                  </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" InitialValue="0" ControlToValidate="ddlpage" Display="Dynamic"></asp:RequiredFieldValidator>



                   
               </div>


                 <div class="form-group">
                 Page Data
                        <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtdetail" Display="Dynamic"></asp:RequiredFieldValidator>
                   
                                <script>
                                    $(document).ready(function () {
                                        //$('#summernote').summernote();


                                        $('[id*=txtdetail]').summernote()
                                    });
  </script>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" ControlToValidate="txtdetail" CssClass="required" InitialValue="0"  Display="Dynamic"></asp:RequiredFieldValidator>



                   
               </div>

                <div class="form-group">
                    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    </div>


    </div>
      </div>
             </div>

          </div>


    <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css" rel="stylesheet">
<script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"></script>
</asp:Content>
