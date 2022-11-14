<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateproducts.aspx.cs" Inherits="MyAdmin.updateproducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Productid") %>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>