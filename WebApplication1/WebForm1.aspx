<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>

<%@ Register Assembly="ClassLibrary1" Namespace="ClassLibrary1" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="menu.css" rel="stylesheet" />--%>
</head>
<body>
  

 
    <form id="form1" runat="server">
   
<%--      <cc1:MenuFunzione ID="MenuFunzione2" runat="server" ></cc1:MenuFunzione>--%>
        <cc2:Mtmenu ID="Mtmenu1" runat="server"  />

<%--        <asp:Menu ID="Menu1" runat="server"  ></asp:Menu>
       --%>
    </form>
</body>
</html>
