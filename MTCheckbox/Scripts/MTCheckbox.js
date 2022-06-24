function myFunction() {
  /*alert(document.getElementsByClassName("MTdropdown-content").item(1));*/
   /*document.getElementById("myDropdown").classList.toggle("show");*/
  document.getElementsByClassName("MTdropdown-content").item(1).classList.toggle("show");
  
}

function myFunction2() {
/*  document.getElementById("myDropdown").classList.remove("show");*/
  document.getElementsByClassName("MTdropdown-content").item(1).classList.remove("show");
}

function cliccaMTChkbox(nameofcontrol) {
  /*document.getElementById("MTcheckbox").checked=true;*/
  /*alert(document.getElementsByClassName("MTdropdown-content").length);*/
  //document.getElementsByClassName("MTCheckbox").item(0).checked = true;
  //__doPostBack(document.getElementsByClassName("MTCheckbox").item(0).id,'');
  /*var stringa = '<%=' + nameofcontrol + '_' + 'MTcheckbox.ClientID%>';*/
  var stringa = nameofcontrol + '_' + 'MTcheckbox';
  /*alert(stringa);*/
  var x = document.getElementById(stringa);
  x.checked = true;
  __doPostBack(x, '');
}


function __doPostBack(eventTarget, eventArgument) {
  if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
    theForm.__EVENTTARGET.value = eventTarget;
    theForm.__EVENTARGUMENT.value = eventArgument;
    theForm.submit();
  }
}

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