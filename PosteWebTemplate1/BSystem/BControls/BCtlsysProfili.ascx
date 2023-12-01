<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysProfili.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysProfili" %>

<asp:Panel runat="server" Visible="false">
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
  <link href="../../BThemes/tmBApp/03_Clock.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_CommandBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Copyright.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_HeaderBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_MenuFunzioni.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_MenuFunzioni_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_MenuFunzioni_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Segnalazioni.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/04_Extender.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_LogIn.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_Registrazione.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images32.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCheck.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCollapsiblePanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCombo.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridViewPanel.css" rel="stylesheet" />
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
  <link href="../../BThemes/tmBApp/testcss.css" rel="stylesheet" />
</asp:Panel>


<asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">

  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server"
      Style="width: 100px;"
      INVIO="True"
      CssClass="BFloatLeft BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="NUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault"
      CssHelpButton="" DataType="ALFANUMERICO"
      TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%--CONTROLLO RICERCA DataInizio--%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Data Inizio</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtDataInizio" runat="server"
      INVIO="True"
      Width="100px"
      CssClass="BFloatLeft BTesto10 TestoDefault"
      CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter"
      DataType="Data" TextFormat="NESSUNO" HelpButton="TRUE"
      CalendarOnHelpButton="true"
      TextHelpButton=""
      MaxLength="10" />
  </div>
  <%--CONTROLLO RICERCA DataFine--%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px">Data Fine</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtDataFine" runat="server"
      INVIO="True"
      Width="100px"
      CssClass="BFloatLeft BTesto10 TestoDefault"
      CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter"
      DataType="Data" TextFormat="NESSUNO" HelpButton="TRUE"
      CalendarOnHelpButton="true"
      TextHelpButton=""
      MaxLength="10"
      />
  </div>

  <%--TBL RELATION --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BWidth100-10">Elenco Funzioni:</div>

  <asp:Panel ID="pnlTreeFunction" CssClass="BInputControl BMarginTop20 BNextControlGoDown BPanel BWidth100-10" runat="server" Style="max-height: 300px; overflow: auto;">
    <BWC:BTreeView ID="tvwMenu"
      runat="server"
      CollapseImageUrl="~/BSystem/Image/Collapse.png"
      ExpandImageUrl="~/BSystem/Image/Expand.png"
      ExpandDepth="0"
      SelectedNodeStyle-CssClass="BTestoBold BTestoUnderline BTestoAzzurro"
      LeafNodeStyle-CssClass="BTesto10 BTestoNero"
      NodeStyle-CssClass="BTesto12 BTestoNero"
      ParentNodeStyle-CssClass="BTesto12">
      <LevelStyles>
        <asp:TreeNodeStyle Font-Underline="False" Height="24px" Width="204px" />
      </LevelStyles>
    </BWC:BTreeView>
  </asp:Panel>

  <BWC:BButton ID="BtnModRole" runat="server" Text="Modifica Ruolo" Height="32px" Width="140px"
    CssClass="BIconRuoli BBtnLeft BInputControl BNextControlGoDown" />

  <div class="BRow"></div>

  <%-- CONTROLLO Note --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px">Note</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtNote" runat="server"
      Style="height: 100px;"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-20 BTesto10 TestoDefault"
      CssHelpButton="" DataType="ALFANUMERICO"
      TextFormat="NESSUNO" HelpButton="FALSE"
      TextMode="MultiLine"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Immagine --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px">Icona profilo</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BImage ID="Internal_imgImmagine" runat="server"
      AbilitaPasteImage="true"
      AbilitaUpload="true"
      Width="100px" Height="100px"
      AltezzaImmagine="100" LarghezzaImmagine="100"
      CssClass="BImage BCircle BMargin40"
      CssImage="BCircle "
      CssDivPasteImage="BTesto10 TestoDefault BFloatLeft Border1px"
      MaxSize="700000" />
  </div>


  <BWC:BModalPopup runat="server" ID="pnlModificaRuolo" Titolo="Modifica Ruolo"
    CssBtnClose="BDisplayNone"
    TextAnnulla="Annulla"
    TextConferma="Salva"
    Width="300px"
    Height="300px"
    CssPnlContainer="BPanelRadius"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnAnnulla="BFloatRight BBtnCancel"
    CssBtnConferma="BFloatRight BBtnSuccess">
    <Content>

      <%-- CONTROLLO FUNZIONE--%>
      <div class="BInputControl BNextControlGoDown BTesto10 TestoDefault BWidth100-20">Funzione</div>
      <div class="BInputControl BNextControlGoDown BWidth100-20">
        <BWC:BTesto ID="mbtFunzione" runat="server" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100" Enabled="False"></BWC:BTesto>
      </div>

      <%-- CONTROLLO RUOLO--%>
      <div class="BInputControl BNextControlGoDown BTesto10 TestoDefault BWidth100-20">Ruolo</div>
      <div class="BInputControl BNextControlGoDown BWidth100-20">
        <BWC:BCombo ID="ddlRoles" runat="server" CssClass="BFloatLeft Testo10 BWidth100 TestoDefault "></BWC:BCombo>
      </div>

    </Content>
  </BWC:BModalPopup>

</asp:Panel>

