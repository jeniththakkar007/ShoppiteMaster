<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header_searchbar.ascx.cs" Inherits="FrontPanel.usercontrol.header_searchbar" %>

<%--<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>--%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <div class="searchform">
     <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
         <asp:ListItem Value="0">Select Category</asp:ListItem>
     </asp:DropDownList>
                          
                           <asp:TextBox ID="TextBox1" runat="server" placeholder="Search here..." CssClass="form-control" ValidationGroup="search" AutoCompleteType="Disabled"></asp:TextBox>
                           <asp:LinkButton ID="LinkButton1" ValidationGroup="headersearch" runat="server" OnClick="LinkButton1_Click">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/search.png" />
                                </asp:LinkButton>
                        </div>
<asp:Label ID="lblerror" runat="server" Text="" CssClass="required" ></asp:Label>

<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="headersearch" ControlToValidate="DropDownList1" ErrorMessage="Select Category"   InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="headersearch" ControlToValidate="TextBox1" ErrorMessage="Type keyword" CssClass="required" Display="Dynamic"></asp:RequiredFieldValidator>--%>


 <cc1:AutoCompleteExtender ID="AutoCompleteEx" runat="server" EnableCaching="false"
            BehaviorID="AutoCompleteEx" MinimumPrefixLength="1" TargetControlID="TextBox1"
            ServicePath="~/MyService.asmx" ServiceMethod="SearchCustomers" CompletionInterval="1000"
            CompletionSetCount="20"    
         
        
         >
        </cc1:AutoCompleteExtender>
<%--     
 
     <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" EnableCaching="false"
            BehaviorID="AutoCompleteEx" MinimumPrefixLength="1" TargetControlID="TextBox1"
            ServicePath="~/MyService.asmx" ServiceMethod="SearchCustomers" CompletionInterval="1000"
            CompletionSetCount="20"    
         
        
         >
        </ajaxToolkit:AutoCompleteExtender>--%>


