<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>



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


        <asp:Table ID="Table1" runat="server"></asp:Table>

 <asp:Menu ID="Menu" runat="server"
      Orientation="Horizontal"
      StaticSubMenuIndent="10px"
      DynamicHorizontalOffset="5"
      DynamicVerticalOffset="5"
      CssClass="MenuBArts"
      StaticMenuStyle-CssClass="MenuBArts-Node"
      DynamicMenuStyle-CssClass="MenuBArts-ChildNode"
      StaticSelectedStyle-CssClass="MenuBArts-NodeSelected"
      RenderingMode="Default">
      <DynamicItemTemplate>
        <%# Eval("Text") %> 
      </DynamicItemTemplate>
    </asp:Menu>
    </form>
</body>



</html>
