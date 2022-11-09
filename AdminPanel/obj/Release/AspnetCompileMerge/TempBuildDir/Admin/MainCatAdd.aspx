<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainCatAdd.aspx.cs" Inherits="Adminweb.Admin.MainCatAdd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <div class="page_title">
    <h1>
      Footer Category
    </h1>
</div>

    <div class="row">
        <div class="col-md-4">
          
 <div class="form border  white-bg radius ">
              <h4 class=" padding15 no-margin l-yellow-bg"> Add Footer Category

                    <span class="pull-right">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="green-c bold margin5 " CausesValidation="False" PostBackUrl="~/Admin/PageCat.aspx">Back to List</asp:LinkButton>
                  </span>
      </h4>
           <div class="form-horizontal  padding15">
               <div class="form-group">
                   Name:
                   <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtcategory" Display="Dynamic"></asp:RequiredFieldValidator>



                   
               </div>
         

             




                   <div class="form-group checkright">
                  Status: (active will show on front end)
     <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
         <asp:ListItem Selected="True">Active</asp:ListItem>
         <asp:ListItem>InActive</asp:ListItem>
     </asp:RadioButtonList>

           
               </div>
               <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="form-group">
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                        </div>
           </div>
        </div></div>

        <div class="col-md-6">
            
            <div class="grid">
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="MainPageCategoryId" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                       <Columns>

                           <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                           <asp:TemplateField HeaderText="Category">
            <ItemTemplate>
                <asp:Label ID="lblcategoryname" runat="server" Text='<%# Eval("MainPageCategory1") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

                                  


                           
                                      <asp:TemplateField HeaderText="Status" >
            <ItemTemplate>
                <asp:Label ID="lblcategoryname" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>


        
    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>





</asp:Content>
