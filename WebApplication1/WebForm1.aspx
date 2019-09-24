<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="ClassLibrary3" Namespace="ClassLibrary3" TagPrefix="cc2" %>

<%@ Register Assembly="ClassLibrary1" Namespace="ClassLibrary1" TagPrefix="cc1" %>


<script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
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

    <script type="text/javascript">
    $(".btn-responsive-menu").click(function() {

	$("#mainmenu").toggleClass("show");

});
</script>
 <%--<script type="text/javascript">
     $(function () {

         // Appendiamo la tendina al <nav>
         $("<select />").appendTo("nav");

         // Creiamo un'opzione di default "Vai a..."
         $("<option />", {
             "selected": "selected",
             "value": "",
             "text": "Vai a..."
         }).appendTo("nav select");

         // Valorizziamo gli elementi della tendina prendendo l'attributo
         // href dei link ed inserendolo nel value delle <option>
         $("nav a").each(function () {
             var el = $(this);
             $("<option />", {
                 "value": el.attr("href"),
                 "text": el.text()
             }).appendTo("nav select");
         });

         // Per rendere funzionante la tendina, ogni volta che viene
         // cambiato il valore della select, effetuiamo un redirect
         // alla pagina interessata (value della option)
         $("nav select").change(function () {
             window.location = $(this).find("option:selected").val();
         });

     });
</script>--%>

</html>
