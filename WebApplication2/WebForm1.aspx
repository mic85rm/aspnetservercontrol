<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>


<%@ Register Namespace="MTHtmlEditor" Assembly="MTHtmlEditor" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-ui-1.13.2.min.js"></script>
    <script src="Scripts/jquery-3.7.0.js"></script>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui-1.13.2.js"></script>
    <script type="text/javascript">
        
        function MTcallFormatting(sFormatString) {
            document.execCommand(sFormatString,true,sFormatString);
        }

        function htmlEntities(str) {
            return String(str).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
        }


        function MTMoveTextFromDivToHiddenField(id) {
            document.getElementById(id + 'MTHiddenText').value = htmlEntities(document.getElementById(id+'MTEditorContentEditableDesign').innerHTML);
            
        }


        function MTToggleTabs(me, altro,clientid) {
            if (me.id == clientid+'MTTABDESIGN') {
                if (me.classList == "class1") {
                    
                    altro.classList.toggle("class1");
                }
                else {
                    
                    altro.classList.toggle("class2");
                    me.classList.toggle("class2");
                    me.classList.toggle("class1");
                }
            }
            else {
             
                if (me.classList == "class1") {
                    
                    altro.classList.toggle("class1");
                }
                else {
                    
                    altro.classList.toggle("class2");
                    me.classList.toggle("class2");
                    me.classList.toggle("class1");
                }
            }
            
        }


        function MTToggleButton(me) {
         
                    me.classList.toggle("class2");
                    me.classList.toggle("class1");
         

        }



        function MTCambiaPannello(pannello,id) {
            if (pannello == 'html') {
                document.getElementById(id + 'MTToolbar').style.display = 'none';
                document.getElementById(id + 'MTHiddenTabSelezionato').value= pannello;
                document.getElementById(id + 'MTEditorContentEditableHTML').style.display = 'block';
                document.getElementById(id + 'MTEditorContentEditableDesign').style.display = 'none';
                document.getElementById(id+'MTEditorContentEditableHTML').innerHTML = htmlEntities(document.getElementById(id+'MTEditorContentEditableDesign').innerHTML);
                //document.getElementById(id + 'MTEditorContentEditableHTML').innerHTML = document.getElementById(id + 'MTEditorContentEditableDesign').innerHTML;
            }
            else {
                document.getElementById(id + 'MTToolbar').style.display = 'block';
                document.getElementById(id + 'MTHiddenTabSelezionato').value = pannello;
                document.getElementById(id + 'MTEditorContentEditableHTML').style.display = 'none';
                document.getElementById(id + 'MTEditorContentEditableDesign').style.display = 'block';
                document.getElementById(id + 'MTEditorContentEditableDesign').innerHTML = document.getElementById(id + 'MTEditorContentEditableHTML').innerText;
            }
        }
    </script>
    <style>
body {font-family: Arial;}

/* Style the tab */
.MTTABS {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
}

/* Style the buttons inside the tab */
.MTTABS button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 7px 8px;
  transition: 0.3s;
  font-size: 12px;
}

/* Change background color of buttons on hover */
.MTTABS button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.MTTABS button.active {
  background-color: #ccc;
}

.class1 {
  color: #333;
  background-color: #ccc;
}
.class2 {
  color: #ccc;
  background-color: #333;
}



</style>
</head>
<body>

    <form id="form1" runat="server">


            <asp:Button runat="server" ID="michele2" OnClick="michele2_Click" Text="postback" />
      <cc1:MTHtmlEditor runat="server" ID="michele" Width="500" Height="500" />


    </form>
</body>
</html>
