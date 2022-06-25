<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%--<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>--%>
<%@ Register Assembly="MTCheckbox" Namespace="MTCheckbox" TagPrefix="cc2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   

    <title></title>
  
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
      <br />
      <cc2:MTCheckbox runat="server" OnValoreRestituito="Unnamed_ValoreRestituito">

      </cc2:MTCheckbox>
       <br />
      <cc2:MTCheckbox runat="server" OnValoreRestituito="Unnamed_ValoreRestituito1" CheckedInterno="true">
        <MTDropdownItems>

        </MTDropdownItems>
      </cc2:MTCheckbox>
       <br />
      <cc2:MTCheckbox runat="server" >
        <MTDropdownItems>
          <cc2:MTCheckboxItem      />
            <cc2:MTCheckboxItem  Testo="ciao" />
        </MTDropdownItems>
      </cc2:MTCheckbox>
       <br />


      <cc2:MTCheckbox runat="server">
           <MTDropdownItems>
          <cc2:MTCheckboxItem   Testo="ciao" Valore="q"   />
            <cc2:MTCheckboxItem  Testo="ciao" Valore="q" />
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
