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