
function BSideBarBtnCollapse_Click(IDPnlSidebar, IDPnlSidebarHide, IDPnlMain, IDPnlMainHeaderContainer, IDHStateSidebar, IDHStateSidebarHide, IDHStateMain, IDHStatePnlMainHeaderContainer) {
  var pnlSideBar = window.document.getElementById(IDPnlSidebar);
  if (pnlSideBar == null) return false;
  var pnlSideBarHide = window.document.getElementById(IDPnlSidebarHide);
  if (pnlSideBarHide == null) return false;
  var pnlMain = window.document.getElementById(IDPnlMain);
  if (pnlMain == null) return false;
  var PnlMainHeaderContainer = window.document.getElementById(IDPnlMainHeaderContainer);
  if (PnlMainHeaderContainer == null) return false;

  var HStateSideBar = document.getElementById(IDHStateSidebar);
  if (HStateSideBar == null) return false;
  var HStateSideBarHide = document.getElementById(IDHStateSidebarHide);
  if (HStateSideBarHide == null) return false;
  var HStateMain = document.getElementById(IDHStateMain);
  if (HStateMain == null) return false;
  var HStatePnlMainHeaderContainer = document.getElementById(IDHStatePnlMainHeaderContainer);
  if (HStatePnlMainHeaderContainer == null) return false;

  $('#' + IDPnlSidebar).toggleClass('active');
  $('#' + IDPnlSidebarHide).toggleClass('active');
  $('#' + IDPnlMain).toggleClass('active');
  $('#' + IDPnlMainHeaderContainer).toggleClass('active');

  HStateSideBar.value = pnlSideBar.className;
  HStateSideBarHide.value = pnlSideBarHide.className;
  HStateMain.value = pnlMain.className;
  HStatePnlMainHeaderContainer.value = PnlMainHeaderContainer.className;

  return false;
}

function MenuResponsive_Click(Btn, IDPnl) {
  var css = "";
  var Pnl = window.document.getElementById(IDPnl);
  if (Pnl == null) return false;
  var vis = Pnl.className.indexOf("MenuResponsive_DisplayNone");
  if (vis == -1) { // MENU IS VISIBLE
    css = Pnl.className.replace("MenuResponsive_DisplayBlock", "MenuResponsive_DisplayNone");
  } else {
    css = Pnl.className.replace("MenuResponsive_DisplayNone", "MenuResponsive_DisplayBlock");
  }
  Pnl.className = css;

  $('#' + Pnl.id + ' > ul > *').removeAttr('style');
  return false;
}

//function BCtlUtenteEntrato_ShowPanel(IDPnl, IDHFocus) {
//  var hFocus = document.getElementById(IDHFocus);
//  if (hFocus == null) return false;
//  var Pnl = document.getElementById(IDPnl);
//  if (Pnl == null) return false;

//  if (Pnl.style['opacity'] == 0) {
//    $('#' + IDPnl).fadeIn(1000);
//    hFocus.focus();
//    $('#' + IDHFocus).blur(function () {
//      $('#' + IDPnl).fadeOut(1000);
//    });
//  }
//  return false;
//}

function BCtlUtenteEntrato_ShowPanel(IDPnl) {
  var Pnl = document.getElementById(IDPnl);
  if (Pnl == null) return false;
  $('#' + IDPnl).fadeToggle(1000);
  return false;
}


function BCtlHeaderBar_KeyDown(Ctl, e) {
  if (Ctl == null) return false;
  var KeyCode = GetKeyCode(e);
  if (KeyCode == 13) {
    BPostBack("BCtlHeaderBar_KeyDown", KeyCode, Ctl.id);
  }
  return true;
}

function BCtlServicesNotification_ShowPanel(IDPnl) {
  var Pnl = document.getElementById(IDPnl);
  if (Pnl == null) return false;

  if (Pnl.style['opacity'] == 0) {
    $('#' + IDPnl).fadeIn(1000);
  } else {
    $('#' + IDPnl).fadeOut(1000);
  }
  return false;
}

/*
***************************************************
         BGridView_SwitchAll For GridView
***************************************************
Data Creazione: 06/05/2020
Owner: Marco Balsamo
Note: Effettua la selezione totale di tutte le switch di una pagina della griglia
*/

function BGridView_SwitchAll(idChk, idDtg, indexColCheck) {
  var chkHeader = $('#' + idChk + ' input').get(0); //GET SWITCH CHECKBOX

  var aChks = $('#' + idDtg + ' input').get();
  if (aChks.length > 0) {
    for (i = 1; i < aChks.length; i++) {
      aChks[i].checked = chkHeader.checked;
    }
  }
  return true;
}



/*
***************************************************
              BWiki_txtCerca_onkeydown
***************************************************
Data Creazione: 17/06/2020
Owner: Marco Balsamo
Note: Effettua la ricerca tramite il tasto invio nell'help on line
*/


function BWiki_txtCerca_onkeydown(ctl, e) {
  var keycode = GetKeyCode(e);
  if (keycode === 13) {
    if (ctl.value === '') return false;
    BPostBack('TXTCERCA_ONKEYDOWN', '', ctl.id);
    return false;
  }
}
