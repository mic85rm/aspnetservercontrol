﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%--<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>--%>
<%@ Register Assembly="MTCheckbox" Namespace="MTCheckbox" TagPrefix="cc2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   

    <title></title>
  
</head>
<body>
  

 
    <form id="form1" runat="server">


<%--      <asp:checkbox runat="server"></asp:checkbox>--%>

    <cc2:MTCheckbox runat="server" ID="ab"   Selezionato="true" FormaCheckbox="Rotonda">
      <MTDropdownItems>
        <cc2:MTCheckboxItem Testo="a" Valore="1" />
      </MTDropdownItems>
    </cc2:MTCheckbox>
   <%--    <cc2:MTCheckbox runat="server" ID="MTCheckbox1"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox2"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox3"></cc2:MTCheckbox>
       <cc2:MTCheckbox runat="server" ID="MTCheckbox4"></cc2:MTCheckbox>--%>

      <%--  <cc2:Mtmenu ID="Mtmenu1" runat="server" />--%>

            <script>
//    $('#navigation').slimmenu(
//{
//    resizeWidth: '1000',
//    collapserTitle: 'Main Menu',
//    animSpeed: 'medium',
//    easingEffect: null,
//    indentChildren: false,
//    childrenIndenter: '&nbsp;'
//            });

//    $('MTdropdown').on('mouseenter', 'input', function () {
//    alert('ciao');
//    /*$('.btn').prop('disabled', true);*/
//});
//$('MTdropdown').on('mouseout', 'input', function () {
//    alert('ciao2')
//    /*$('.btn').prop('disabled', false);*/
//});


        </script>
       


    </form>
</body>



</html>
