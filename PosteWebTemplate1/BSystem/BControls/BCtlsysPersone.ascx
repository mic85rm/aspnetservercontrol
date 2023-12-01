<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysPersone.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysPersone" %>
<asp:Panel ID="lnkToDesign" runat="server" Visible="false">
  <link href="../Css/Master.css" rel="stylesheet" />
  <link href="../Css/MasterBackgroundColor.css" rel="stylesheet" />
  <link href="../Css/MasterBase.css" rel="stylesheet" />
  <link href="../Css/MasterBorder.css" rel="stylesheet" />
  <link href="../Css/MasterButtons.css" rel="stylesheet" />
  <link href="../Css/MasterColors.css" rel="stylesheet" />
  <link href="../Css/MasterCommandBar.css" rel="stylesheet" />
  <link href="../Css/MasterFonts.css" rel="stylesheet" />
  <link href="../Css/MasterHeight.css" rel="stylesheet" />
  <link href="../Css/MasterMargin.css" rel="stylesheet" />
  <link href="../Css/MasterPadding.css" rel="stylesheet" />
  <link href="../Css/MasterPanels.css" rel="stylesheet" />
  <link href="../Css/MasterResponsive.css" rel="stylesheet" />
  <link href="../Css/MasterResponsiveSmartphone.css" rel="stylesheet" />
  <link href="../Css/MasterResponsiveTablet.css" rel="stylesheet" />
  <link href="../Css/MasterRound.css" rel="stylesheet" />
  <link href="../Css/MasterTable.css" rel="stylesheet" />
  <link href="../Css/MasterWidth.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/00_Base.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/00_Pannelli.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_BPagePreviewReport.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_SmartPhone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_Spinner.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_PageTableBase.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_WebControlSearchBase.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-Sidebar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-Sidebar_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-SideBar_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_BCtlCalendario.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Clock.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_CommandBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Copyright.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_HeaderBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Segnalazioni.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/04_Extender.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_LogIn.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_Registrazione.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images32.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BAutoComplete.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCheck.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCollapsiblePanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCombo.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridViewPanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BNotify.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPropertyGrid.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BRadio.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BSwitch.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BToast.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BUploader.css" rel="stylesheet" />
</asp:Panel>

<asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">
  <%--COLONNA SX--%>
  <asp:Panel ID="Internal_PnlFoto" runat="server" class="BInputControl BNextControlGoDown " Style="width: 280px; margin-right: 0!important">
    <BWC:BImage ID="Internal_imgFoto" runat="server"
      Width="200px" Height="200px"
      AltezzaImmagine="200" LarghezzaImmagine="200"
      AbilitaPasteImage="true"
      AbilitaUpload="true"
      CssClass="BImage BCircle BMargin40 BBorder1"
      CssImage="BCircle "
      CssDivPasteImage="BTesto10 TestoDefault BFloatLeft BBorder1"
      MaxSize="700000" />
    <BWC:BTesto ID="Internal_mbtID" runat="server"
      Style="width: 100px;" INVIO="True"
      CssClass="BInputControl BTesto10 TestoDefault "
      CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" Visible="false"></BWC:BTesto>
    <asp:LinkButton ID="lnkEliminaFoto" runat="server" Text="Elimina Foto" CssClass="BFloatLeft BWidth100-20 BTesto10 BTestoRosso BTestoCenter BMargin10"></asp:LinkButton>
  </asp:Panel>

  <%--COLONNA DX--%>
  <asp:Panel ID="Internal_PnlColDati" runat="server" CssClass="BInputControl BNextControlGoDownCenter" Style="width: calc(100% - 300px);">

    <%--ANAGRAFICA--%>
    <asp:Panel ID="Internal_PnlAnagrafica" runat="server" CssClass="BPanelRadius BMarginBottom20 BNextControlGoDownCenter BMarginLeft0 BInputControl BWidth100-20 " Style="box-sizing: border-box;">
      <%-- Titolo Pannello --%>
      <div class="BPanelTitle">Anagrafica</div>

      <%-- Controllo Nome--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Nome</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtNome" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton=""
          DataType="ALFANUMERICO"
          TextFormat="MAIUSCOLO"
          HelpButton="FALSE"
          MaxLength="50"></BWC:BTesto>
      </div>

      <%-- Controllo Cognome--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Cognome</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtCognome" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton=""
          DataType="ALFANUMERICO"
          TextFormat="MAIUSCOLO"
          HelpButton="FALSE"
          MaxLength="50"></BWC:BTesto>
      </div>

      <%-- Controllo Data Nascita--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Data Nascita</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtDataNascita" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault"
          CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter"
          DataType="DATA"
          TextFormat="NESSUNO"
          TextHelpButton=""
          HelpButton="TRUE"
          CalendarOnHelpButton="true"
          MaxLength="10"></BWC:BTesto>
      </div>

      <%-- Controllo Sesso--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Sesso</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BCombo ID="Internal_mbcSesso" runat="server"
          NomeTabella="" CampoKey="" CampoDescr="" CampiOrdinati=""
          INVIO="True"
          CssClass="BWidth100-20 BFloatLeft BTesto10 TestoDefault ">
          <asp:ListItem Value="1">MASCHIO</asp:ListItem>
          <asp:ListItem Value="0">FEMMINA</asp:ListItem>
        </BWC:BCombo>
      </div>

      <%-- Controllo Stato Nascita--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Stato Nascita</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BCombo ID="Internal_mbcIDStatoNascita" runat="server"
          NomeTabella="sysStati" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
          INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20">
        </BWC:BCombo>
      </div>

      <%-- CONTROLLO IDComuneNascita --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Comune Nascita</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtIDComuneNascita" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton=""
          DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          AutoCompleteCampoID="ID" AutoCompleteCampoDescrizione="Descrizione"
          Autocomplete="true" AutoCompleteMinLength="2"
          AutoCompleteWebApiUrl="http://localhost/webempty/webapi/BsysComuni/autocomplete/"
          HelpButton="FALSE"></BWC:BTesto>
      </div>



      <%-- CONTROLLO Codice Fiscale --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault BMarginBottom20 " style="width: 180px;">Codice Fiscale</div>
      <div class="BInputControl BNextControlGoDown BMarginBottom20" style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtCodiceFiscale" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-60"
          CssHelpButton="BTestoHelpButton BIconCodiceFiscale BBtnCenter"
          TextHelpButton=""
          DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          HelpButton="TRUE"
          MaxLength="20"></BWC:BTesto>
      </div>
    </asp:Panel>

    <%--RESIDENZA--%>
    <asp:Panel ID="Internal_PnlResidenza" runat="server" CssClass="BPanelRadius BInputControl BNextControlGoDownCenter BMarginLeft0 BMarginBottom20 BWidth50-15">
      <%-- Titolo Pannello --%>
      <div class="BTestoBianco BPanelTitle">Residenza</div>

      <%-- Controllo Indirizzo --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Indirizzo</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtIndirizzoResidenza"
          runat="server" INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          HelpButton="FALSE"></BWC:BTesto>
      </div>

      <%-- Controllo CAP --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">CAP</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtCAPResidenza" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          HelpButton="FALSE" MaxLength="10"></BWC:BTesto>
      </div>

      <%-- Controllo Stato --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Stato</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BCombo ID="Internal_mbcIDStatoResidenza" runat="server"
          NomeTabella="sysStati" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20">
        </BWC:BCombo>
      </div>

      <%-- CONTROLLO IDComuneResidenza --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Comune</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtIDComuneResidenza"
          runat="server" INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          AutoCompleteCampoID="ID" AutoCompleteCampoDescrizione="Descrizione"
          Autocomplete="true" AutoCompleteMinLength="2"
          AutoCompleteWebApiUrl="http://localhost/webempty/webapi/BsysComuni/autocomplete/"
          HelpButton="FALSE"></BWC:BTesto>
      </div>

      <%-- CONTROLLO Quartiere --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault BMarginBottom20" style="width: 180px;">Quartiere</div>
      <div class="BInputControl BNextControlGoDown BMarginBottom20" style="width: calc(100% - 220px);">
        <BWC:BCombo ID="mbcIDQuartiereResidenza" runat="server"
          NomeTabella="sysComuniQuartieri" CampoKey="IDQuartiere" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20">
        </BWC:BCombo>
      </div>

    </asp:Panel>

    <%--DOMICILIO--%>
    <asp:Panel ID="Internal_PnlDomicilio" runat="server" CssClass="BPanelRadius BMarginBottom20 BNextControlGoDownCenter BInputControl BWidth50-15 ">
      <%-- Titolo Pannello --%>
      <div class="BPanelTitle">Domicilio</div>

      <%-- Controllo Indirizzo --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Indirizzo</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtIndirizzoDomicilio"
          runat="server" INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          HelpButton="FALSE"></BWC:BTesto>
      </div>

      <%-- Controllo CAP --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">CAP</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtCAPDomicilio" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 BWidth100-20 TestoDefault "
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          HelpButton="FALSE"></BWC:BTesto>
      </div>

      <%-- Controllo Stato --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Stato</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BCombo ID="Internal_mbcIDStatoDomicilio" runat="server"
          NomeTabella="sysStati" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 BWidth100-20 TestoDefault ">
        </BWC:BCombo>
      </div>

      <%-- CONTROLLO IDComuneDomicilio --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Comune</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtIDComuneDomicilio"
          runat="server" INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO"
          AutoCompleteCampoID="ID" AutoCompleteCampoDescrizione="Descrizione"
          Autocomplete="true" AutoCompleteMinLength="2"
          AutoCompleteWebApiUrl="http://localhost/webempty/webapi/BsysComuni/autocomplete/"
          HelpButton="FALSE"></BWC:BTesto>
      </div>

      <%-- CONTROLLO Quartiere --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault BMarginBottom20" style="width: 180px;">Quartiere</div>
      <div class="BInputControl BNextControlGoDown BMarginBottom20" style="width: calc(100% - 220px);">
        <BWC:BCombo ID="mbcIDQuartiereDomicilio" runat="server"
          NomeTabella="sysComuniQuartieri" CampoKey="IDQuartiere" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20">
        </BWC:BCombo>
      </div>
    </asp:Panel>

    <%--RECAPITI--%>
    <asp:Panel ID="Internal_PnlRecapiti" runat="server" CssClass="BPanelRadius BInputControl BNextControlGoDownCenter BMarginLeft0 BMarginBottom20 BWidth50-15">
      <%-- Titolo Pannello --%>
      <div class="BTestoBianco BPanelTitle">Recapito</div>

      <%-- Controllo Telefono --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Telefono</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtTelefono" runat="server"
          INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20"
          CssHelpButton="" DataType="ALFANUMERICO"
          TextFormat="NESSUNO" HelpButton="FALSE"
          MaxLength="20"></BWC:BTesto>
      </div>

      <%-- Controllo Cellulare --%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Cellulare</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtCelluare" runat="server" INVIO="True"
          CssClass="BFloatLeft BTesto10 TestoDefault BWidth100-20" CssHelpButton=""
          DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
      </div>

      <%-- Controllo Fax--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Fax</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtFax" runat="server" INVIO="True"
          CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="50"></BWC:BTesto>
      </div>

      <%-- Controllo Altro Recapito--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Altro Recapito</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtAltroRecapito" runat="server" INVIO="True"
          CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault"
          CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
          HelpButton="FALSE" MaxLength="50"></BWC:BTesto>
      </div>

      <%-- Controllo Email--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault " style="width: 180px;">Email</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtEmail" runat="server" INVIO="True"
          CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault" CssHelpButton=""
          DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="200"></BWC:BTesto>
      </div>

      <%-- Controllo WebSite--%>
      <div class="BLabelControl BNextControlGoDown BTesto11 TestoDefault BMarginBottom20" style="width: 180px;">Web Site</div>
      <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
        <BWC:BTesto ID="Internal_mbtWebSite" runat="server" INVIO="True"
          CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault" CssHelpButton=""
          DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="200"></BWC:BTesto>
      </div>
    </asp:Panel>

    <%--NOTE--%>
    <asp:Panel ID="Internal_PnlNote" runat="server" CssClass="BPanelRadius BNextControlGoDownCenter BInputControl BWidth50-15 ">
      <%-- Titolo Pannello --%>
      <div class="BTestoBianco BPanelTitle ">Note</div>
      <BWC:BTesto ID="Internal_mbtNote"
        runat="server"
        INVIO="True"
        CssClass="BFloatLeft BWidth100-2 BHeight100 BTesto10 TestoDefault "
        CssHelpButton="" DataType="ALFANUMERICO"
        TextFormat="NESSUNO" HelpButton="FALSE"
        TextMode="MultiLine"
        Height="150px"></BWC:BTesto>
    </asp:Panel>
  </asp:Panel>
</asp:Panel>
