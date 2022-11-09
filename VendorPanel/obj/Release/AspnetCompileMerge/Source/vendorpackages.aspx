<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vendorpackages.aspx.cs" Inherits="VendorPanel.vendorpackages" %>

<%@ Register Src="~/usercontrol/vendor_package_uc.ascx" TagPrefix="uc1" TagName="vendor_package_uc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/roots.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
    <link href="Content/vendor.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous"/>
 <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500&display=swap" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <style>
        body{
           background:whitesmoke
        }
    </style>


         <div class="padding15 no-margin center bold radius">
                     
                          
                         
                          
                  <br />
             <br />        
                          
               <h2> Start With us now </h2>
                        
                             
            </div>

  <div class="container">
       

        <uc1:vendor_package_uc runat="server" ID="vendor_package_uc" />
</div>


    </div>
    </form>
</body>
</html>
