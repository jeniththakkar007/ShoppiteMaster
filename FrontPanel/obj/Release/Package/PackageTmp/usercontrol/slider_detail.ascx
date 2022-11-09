<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="slider_detail.ascx.cs" Inherits="FrontPanel.usercontrol.slider_detail" %>



  <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/detail_slider/jquery.min.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/detail_slider/tiksluscarousel.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/detail_slider/rainbow.min.js")%>"></script>
    <link rel="stylesheet"   type='text/css' href="<%= Page.ResolveClientUrl("~/detail_slider/normalize.css")%>"/> 
    <link rel="stylesheet"  type='text/css' href="<%= Page.ResolveClientUrl("~/detail_slider/tiksluscarousel.css")%>" /> 
    <link rel="stylesheet"  type='text/css' href="<%= Page.ResolveClientUrl("~/detail_slider/github.css")%>"/> 
    <link rel="stylesheet"  type='text/css' href="<%= Page.ResolveClientUrl("~/detail_slider/animate.css")%>" />

    <style>
     
    

        #wrapper {
            margin: auto;
            width: 100%;
        }

        a {
            text-decoration: none;
            
        }

            a:hover {
                text-decoration: underline;
            }

        #fruits {
            border: 10px solid #000;
        }
    </style>


<div id="wrapper">

  <div id="carousel1">
                <ul>
                 
                    <asp:ListView ID="ListView1" runat="server">
    <ItemTemplate>
  <li>
      <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' /></li>
    </ItemTemplate>
</asp:ListView>   
                   

                       
                  
                        
               
                
                </ul>
            </div>

            <script language="javascript">
                $(document).ready(function () {
                    $("#carousel1").tiksluscarousel({ width: 750, height: 480, nav: 'thumbnails', type: "slide" });
                });
		</script>


        	</div>

<asp:HiddenField ID="HiddenField1" runat="server" />
