<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%--<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>--%>
<%@ Register Assembly="MTCheckbox" Namespace="MTCheckbox" TagPrefix="cc2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%-- <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
    
    <script src="jquery.slimmenu.min.js"></script>--%>
    <title></title>
   <%-- <script src="navbar.js"></script>
    <link href="StyleSheet1.css" rel="stylesheet" />--%>
<%--    <link rel="stylesheet" href="slimmenu.min.css" type="text/css"/>--%>
   <%-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css" integrity="sha512-5A8nwdMOWrSz20fDsjczgUidUBR8liPYU+WymTZP1lmY9G6Oc7HlZv156XqnsgNUzTyMefFTcsFH/tnJE/+xBg==" crossorigin="anonymous" referrerpolicy="no-referrer" />--%>
</head>
<body>
  

 
    <form id="form1" runat="server">
      <asp:CheckBox ID="speriamodino" runat="server" Checked="true" />
      <asp:DropDownList runat="server" AutoPostBack="true">
  <%--      <asp:ListItem Text="2" Value="1"> 
          
        </asp:ListItem>
        <asp:ListItem Text="3" Value="4">

        </asp:ListItem>--%>
      </asp:DropDownList>
        <cc2:MTCheckbox  runat="server" ID="provaIDboh" OnValoreRestituito="provaIDboh_ValoreRestituito"       >
          <MTDropdownItems>
            <cc2:MTCheckboxItem      />
            <cc2:MTCheckboxItem  Testo="ciao" />
          </MTDropdownItems>
        </cc2:MTCheckbox>  

      

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
