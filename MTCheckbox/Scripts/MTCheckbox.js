function MTMostraSottopannello(nomecontrollo) {
  /*alert(nomecontrollo);*/
 // var stringa = nomecontrollo + '_' + 'MTmyDropdown';
  var stringa = nomecontrollo.replace("chk","MTmyDropdown");
/*  console.log(stringa);*/
  
  var x = document.getElementById(stringa);

  /* var x = document.getElementById('<%=nomecontrollo.ClientID %>');*/
  if (x) {
    
    x.classList.toggle("MTshow");
  }
    else {
    var stringac = nomecontrollo + '_' + 'MTmyDropdown' + '_' + nomecontrollo.substr(nomecontrollo.length - 1);
    //console.log(nomecontrollo);
    //console.log(stringac);
    var x = document.getElementById(stringac);
  /*  console.log(stringac);*/
    x.classList.toggle("MTshow");
    }
  
  /*  document.getElementsByClassName("MTdropdown-content").item(1).classList.toggle("show");*/
  //document.getElementById('<%=myDropdown.ClientID %>').classList.toggle("show");
  //alert('<%=myDropdown.ClientID %>');
}

function MTNascondiSottopannello(controlname) {
    //alert(controlname);
  /*  var stringa2 = controlname + '_' + 'MTmyDropdown';*/
  var stringa2 = controlname.replace("chk", "MTmyDropdown");

  var x2 = document.getElementById(stringa2);
  if (x2) {
   /* alert(stringa2);*/
  /*var x2 = document.getElementById('<%=stringa2.ClientID %>');*/
    x2.classList.remove("MTshow");
  }
  else {
    var stringac2 = controlname + '_' + 'MTmyDropdown' + '_' + controlname.substr(controlname.length - 1);
    //console.log(nomecontrollo);
    //console.log(stringac);
    var x2 = document.getElementById(stringac2);
    /*console.log(stringac);*/
    x2.classList.toggle("MTshow");
  }
  /*  document.getElementsByClassName("MTdropdown-content").item(1).classList.remove("show");*/
  /*document.getElementById('<%=myDropdown.ClientID %>').classList.remove("show");*/
}


function AddCSS() {

  var css = '.MTdropbtn{padding:16px;font-size:16px;border:none;cursor:pointer}.MTCheckbox{display:inline-block;vertical-align:text-top;margin-top:6px}.MTarrow-down{width:0;height:0;border-left:5px solid transparent;border-right:5px solid transparent;border-top:5px solid #000;display:inline-block}.MTdisplayNone{display:none}.MTdropbtn:focus,.MTdropbtn:hover{background-color:#3e8e41}.MTdropdown{position:relative;display:inline-block}.MTdropdown-content{display:none;position:absolute;background-color:#f9f9f9;min-width:160px;box-shadow:0 8px 16px 0 rgba(0,0,0,.2);z-index:100000000!important}.MTunstyled-button{border:none;padding:0;background:0 0;cursor:pointer;text-align:left;text-indent:20px;z-index:917;height:100%;width:100%;margin-left:-3px!important;margin-right:-3px!important;font-size:.78vw}.MTdropdown-content li{color:#000;height:48px;width:222px;text-decoration:none;display:block}.MTdropdown-content li:hover{background-color:#f1f1f1;cursor:pointer}.MTshow{display:block}.MTround{position:relative}.MTround label{background-color:#fff;border:1px solid #ccc;border-radius:50%;cursor:pointer;height:12px;left:12px;position:absolute;top:0;width:12px;margin-top:4px}.MTround label:after{border:2px solid #fff;border-top:none;border-right:none;content:"";height:2px;left:3px;opacity:0;position:absolute;top:3px;transform:rotate(-45deg);width:4px}.MTround input[type=checkbox]{visibility:hidden}.MTround input[type=checkbox]:checked+label{background-color:#3c3e3c;border-color:#3c3e3c;margin-top:4px}.MTround input[type=checkbox]:checked+label:after{opacity:1}',
    head = document.head || document.getElementsByTagName('head')[0],
    style = document.createElement('style');

  head.appendChild(style);

  style.type = 'text/css';
  if (style.styleSheet) {
    // This is required for IE8 and below.
    style.styleSheet.cssText = css;
  } else {
    style.appendChild(document.createTextNode(css));
  }







}





//function cliccaMTChkbox(nameofcontrol) {

//  var stringa = nameofcontrol + '_' + 'MTcheckbox';
//  var x = document.getElementById(stringa);
//  x.checked = true;
//  __doPostBack(x, '');
//}


//function __doPostBack(eventTarget, eventArgument) {
//  if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
//    theForm.__EVENTTARGET.value = eventTarget;
//    theForm.__EVENTARGUMENT.value = eventArgument;
//    theForm.submit();
//  }
//}

// Close the dropdown menu if the user clicks outside of it
//window.onmouseleave = function (event) {
//    if (!event.target.matches('.MTdropbtn')) {

//        var dropdowns = document.getElementsByClassName("MTdropdown-content");
//        var i;
//        for (i = 0; i < dropdowns.length; i++) {
//            var openDropdown = dropdowns[i];
//            if (openDropdown.classList.contains('show')) {
//                openDropdown.classList.remove('show');
//            }
//        }
//    }
//}

//$('MTdropdown').on('mouseenter', 'input', function () {
//    alert('ciao');
//    /*$('.btn').prop('disabled', true);*/
//});
//$('MTdropdown').on('mouseout', 'input', function () {
//    alert('ciao2')
//    /*$('.btn').prop('disabled', false);*/
//});