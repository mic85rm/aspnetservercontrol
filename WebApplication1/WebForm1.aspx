<<<<<<< Updated upstream
﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%--<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>--%>
<%@ Register Assembly="MTWebControl" Namespace="MTCheckbox" TagPrefix="cc2" %>
=======
﻿<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" EnableEventValidation="true" MasterPageFile="~/Site1.Master" %>
>>>>>>> Stashed changes


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<<<<<<< Updated upstream

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--  <script src="MTCheckbox.js"></script>
  <link href="MTCheckbox.css" rel="stylesheet" />--%>
    <title></title>
  
</head>
<body>
  

 
    <form id="form1" runat="server">
      <asp:ScriptManager ID="SM" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true" AsyncPostBackTimeout="10000000"></asp:ScriptManager>
      <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>
<%--      <asp:checkbox runat="server"></asp:checkbox>--%>

    <cc2:MTCheckbox runat="server" ID="ab"   Selezionato="true"  AutoPostBack="true" OnValoreRestituito="ab_ValoreRestituito"      >
      <MTDropdownItems>
        <cc2:MTCheckboxItem Testo="a" Valore="1" />
      </MTDropdownItems>
    </cc2:MTCheckbox>
          </ContentTemplate>
        </asp:UpdatePanel>
   <%--    <cc2:MTCheckbox runat="server" ID="MTCheckbox1"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox2"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox3"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox4"></cc2:MTCheckbox>--%>
=======
        <ContentTemplate>
         
>>>>>>> Stashed changes

                
       


  
</asp:Content>