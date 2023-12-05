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


        //var selection = '';
        //document.getElementById('ce').onmouseup = function () {
        //    selection = window.getSelection().toString();
        //};

        //mshtml.IHTMLTxtRange range = _dom.selection.createRange() as mshtml.IHTMLTxtRange;
        //if (range != null) {
        //    mshtml.IHTMLElement2 elem = range.parentElement() as mshtml.IHTMLElement2;
        //    fontSize.Text = elem.currentStyle.fontSize.ToString()
        //}




        function MTtestoSelezionato(id) {
             selectionIsBold(id);
        }

        function selectionIsBold(id) {
            
            var isBold = false;
            var isItalic = false;
            var isFont = -1;

            if (document.queryCommandState) {
                isBold = document.queryCommandState("bold");
            }
            if (document.queryCommandState) {
                isItalic = document.queryCommandState("italic");
            }
            if (document.queryCommandState) {
                isFont=document.queryCommandValue("FontSize");
                
            }
           

            MTCambiaStatoBottone(id + 'MTbold', isBold);
            MTCambiaStatoBottone(id + 'MTitalic', isItalic);
            
        }



        function MTCambiaStatoBottone(me, isBold) {
         var button=   document.getElementById(me);
           
            if (isBold === true) {
                if (button != undefined) { 
               
                if (button.classList.length > 0) { 
                if (button.classList.contains("class1")) { 
                  
                    button.classList.replace("class1", "class2");
                    }
                }
                else {
                    button.classList.add("class2");
                    }
                }
            }
            else {
                if (button != undefined) { 
                    
                    if (button.classList.length > 0) {
                        
                    if (button.classList.contains("class2")) {
                       
                        button.classList.replace("class2", "class1");
                    }
                }
                else {
                    button.classList.add("class1");
                }
            }
            }
        }


        function MTcallFormatting(sFormatString, showui = false, valore = '') {
            if (valore === '-1') {
                var fontElements = document.getElementsByTagName("font");
                alert(fontElements.length);
                     
                
            }
            else { 
                document.execCommand(sFormatString, showui, valore);
            }
        }

        function htmlEntities(str) {
            return String(str).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
        }


        function MTMoveTextFromDivToHiddenField(id) {
            document.getElementById(id + 'MTHiddenText').value = htmlEntities(document.getElementById(id+'MTEditorContentEditableDesign').innerHTML);
            
        }


        function MTToggleTabs(me, altro,clientid) {
            if (me.id == clientid+'MTTABDESIGN') {
                if (me.classList == "MTTabDisattivo") {
                    
                    altro.classList.toggle("MTTabDisattivo");
                }
                else {
                    
                    altro.classList.toggle("MTTabDisattivo");
                    me.classList.toggle("MTTabAttivo");
                    me.classList.toggle("MTTabDisattivo");
                }
            }
            else {
             
                if (me.classList == "MTTabDisattivo") {
                    
                    altro.classList.toggle("MTTabDisattivo");
                }
                else {
                    
                    altro.classList.toggle("MTTabDisattivo");
                    me.classList.toggle("MTTabAttivo");
                    me.classList.toggle("MTTabDisattivo");
                }
            }
            
        }




        function MTIncollaFoto(e, id) {
           
            var clipboardData = e.clipboardData;
            clipboardData.types.forEach((type, i) => {
                const fileType = clipboardData.items[i].type;
                if (fileType.match(/image.*/)) {
                    const file = clipboardData.items[i].getAsFile();
                    const reader = new FileReader();
                    reader.onload = function (evt) {
                        const dataURL = evt.target.result;
                        const img = document.createElement("img");
                        img.src = dataURL;
                        document.execCommand('insertHTML', true, img.outerHTML);
                    };
                    reader.readAsDataURL(file);
                }
            });

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

.class1:hover {
  border:2px solid red;
  background-color: #333;
   cursor: pointer;
}

.class2 {
  color: #ccc;
  background-color: lightgrey !important;
}

.class2:hover {
  border:2px solid red;
   cursor: pointer;
}


.MTTabAttivo {
  color: #333;
  background-color: #ccc;
}

.MTTabAttivo:hover {
  /*border:2px solid red;*/
  background-color: #333;
   cursor: pointer;
}

.MTTabDisattivo {
  color: #ccc;
  background-color: #333!important;
}

.MTTabDisattivo:hover {
  /*border:2px solid red;*/
   cursor: pointer;
}

[contenteditable]:focus {
    outline: 0px solid transparent;
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
