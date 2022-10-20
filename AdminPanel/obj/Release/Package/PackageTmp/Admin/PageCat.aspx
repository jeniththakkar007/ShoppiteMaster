<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageCat.aspx.cs" Inherits="Adminweb.Admin.PageCat" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="page_title">
    <h1>
       Website Pages
    </h1>
</div>

    <div class="row">
        <div class="col-md-3">
            <h4 class="padding15 no-margin l-yellow-bg">Craete Page
      </h4>
 <div class="form border white-bg shadow radius padding15">
           
           <div class="form-horizontal  ">

               
               <div class="form-group checkright">
                   Type:
                 <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                     <asp:ListItem Selected="True">Header</asp:ListItem>
                     <asp:ListItem>Footer</asp:ListItem>
                 </asp:RadioButtonList>



                   
               </div>



               
               <div class="form-group" id="forfooter" runat="server" visible="true">
                  Main Category  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="pull-right green-c bold" PostBackUrl="~/Admin/MainCatAdd.aspx" CausesValidation="False">Add Category</asp:LinkButton>
                   <small>

                                </small>
                 <asp:DropDownList ID="ddlmaincat" runat="server" AppendDataBoundItems="True">
                     <asp:ListItem Value="0">Select</asp:ListItem>
                 </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Field Required" CssClass="required" InitialValue="0" ControlToValidate="ddlmaincat" Display="Dynamic"></asp:RequiredFieldValidator>



                   
               </div>



               <div class="form-group">
                   Page Name:
                   <asp:TextBox ID="txtpage" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txtpage" Display="Dynamic"></asp:RequiredFieldValidator>



                   
               </div>
    

                     <div class="form-group">
                  Is URL:
                         <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />

                         <asp:TextBox ID="txturl" Visible="false" runat="server" Text ="NA"></asp:TextBox>

                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Required" CssClass="required" ControlToValidate="txturl" Display="Dynamic"></asp:RequiredFieldValidator>

                   
               </div>


    
               <div class="form-group">
                  Sort Number:
                   <asp:TextBox ID="txtsortnumber" runat="server" TextMode="Number"  Text="0"></asp:TextBox>
                 



                   
               </div>


                   <div class="form-group checkright">
                  Status: (active will show on front end)
     <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
         <asp:ListItem Selected="True">Active</asp:ListItem>
         <asp:ListItem>InActive</asp:ListItem>
     </asp:RadioButtonList>

           
               </div>
           
                    <div class="form-group">
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                        </div>
           </div>
        </div></div>

        <div class="col-md-9">
            <div class="grid">
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="PageCategoryId" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                       <Columns>

                           <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                           <asp:TemplateField HeaderText="Page">
            <ItemTemplate>
                <asp:Label ID="lblcategoryname" runat="server" Text='<%# Eval("PageCategory1") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

                              
                            <asp:TemplateField HeaderText="Page">
            <ItemTemplate>
                <asp:Label ID="lbltype" runat="server" Text='<%# Eval("type") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

                           


                           
                                      <asp:TemplateField HeaderText="Status" >
            <ItemTemplate>
                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
                                           
                                      <asp:TemplateField HeaderText="Sort Number" >
            <ItemTemplate>
                <asp:Label ID="lblsortnumber" runat="server" Text='<%# Eval("sortnumber") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>


        
    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
