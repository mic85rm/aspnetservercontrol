<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>
<%@ Register Src="~/UserControl1.ascx" TagPrefix="uc1" TagName="UserControl1" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
    <title></title>
    <script src="navbar.js"></script>
    <link href="StyleSheet1.css" rel="stylesheet" />
    
</head>
<body>
  

 
    <form id="form1" runat="server">

        
        <cc2:Mtmenu ID="Mtmenu1" runat="server" />


       

        <uc1:usercontrol1 runat="server" id="UserControl1" />

    </form>
</body>



</html>
