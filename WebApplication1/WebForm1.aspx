<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" EnableEventValidation="true" %>

<%--<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>--%>
<%@ Register Assembly="MTWebControl" Namespace="MTCheckbox" TagPrefix="cc2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--  <script src="MTCheckbox.js"></script>
  <link href="MTCheckbox.css" rel="stylesheet" />--%>
    <title></title>
  
</head>
<body>
  

 
    <form id="form1" runat="server">
<%--      <asp:ScriptManager ID="SM" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true" AsyncPostBackTimeout="10000000"></asp:ScriptManager>
      <asp:UpdatePanel runat="server" UpdateMode="Always">--%>
        <ContentTemplate>
<%--      <asp:checkbox runat="server"></asp:checkbox>--%>
          <asp:GridView ID="mic123" runat="server" AllowPaging="true"  >
           
           <Columns>
             <asp:TemplateField>
               <ItemTemplate>
                 <cc2:MTCheckbox runat="server" ID="chk" Selezionato='<%# Eval("chk")%>'   AutoPostBackCHK="true" AutoPostBackMENU="false"   OnValoreRestituito="chk_ValoreRestituito" OnCheckSelezionata="chk_CheckSelezionata"    >
                  <MTDropdownItems >
                    <cc2:MTCheckboxItem Testo="Seleziona tutto" Valore="1" />
                    <cc2:MTCheckboxItem Testo="Seleziona solo questa pagina" Valore="0" />
                    <cc2:MTCheckboxItem Testo="Deseleziona tutto" Valore="-1" />
                    <cc2:MTCheckboxItem Testo="Deseleziona pagina corrente" Valore="-2" />
                  </MTDropdownItems>
                </cc2:MTCheckbox>
                 </ItemTemplate>
               </asp:TemplateField>
             </Columns>
           </asp:GridView>
          </ContentTemplate>
   <%--     </asp:UpdatePanel>--%>
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
