<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysNotifiche.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysNotifiche" %>
<asp:Panel ID="BCssLink" runat="server" Visible="false">
  <link href="../Css/Master.css" rel="stylesheet" />
  <link href="../Css/MasterBackgroundColor.css" rel="stylesheet" />
  <link href="../Css/MasterBase.css" rel="stylesheet" />
  <link href="../Css/MasterBorder.css" rel="stylesheet" />
  <link href="../Css/MasterButtons.css" rel="stylesheet" />
  <link href="../Css/MasterColors.css" rel="stylesheet" />
  <link href="../Css/MasterCommandBar.css" rel="stylesheet" />
  <link href="../Css/MasterFonts.css" rel="stylesheet" />
  <link href="../Css/MasterFontsSmartphone.css" rel="stylesheet" />
  <link href="../Css/MasterFontsTablet.css" rel="stylesheet" />
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
  <link href="../../BThemes/tmBApp/BArtsFramework_BImage.css" rel="stylesheet" />
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
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="true" CssClass="BWidth100 " CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Titolo --%>
  <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Titolo</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtTitolo" runat="server" Style="" INVIO="true" CssClass="BWidth100 " CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="50"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 "
      CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="250" TextMode="MultiLine" Height="100px"></BWC:BTesto>
  </div>
  <%-- CONTROLLO DataNotifica --%>
  <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Data Notifica</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataNotifica" runat="server" Style="width: 100px;" INVIO="true" CssClass="BFloatLeft"
      CssHelpButton="BTestoHelpButton BBtnCenter BIconCalendar" TextHelpButton=""
      DataType="Data" TextFormat="NESSUNO" HelpButton="true" MaxLength="10" CalendarOnHelpButton="true"></BWC:BTesto>
    <BWC:BTesto ID="Internal_mbtOraNotifica" runat="server" Style="width: 60px;" INVIO="true" CssClass="BFloatLeft" CssHelpButton="" DataType="Ora" TextFormat="NESSUNO" HelpButton="false" MaxLength="5"></BWC:BTesto>
  </div>
  <%-- CONTROLLO LimitaVisibilita --%>
  <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Limita Visibilità</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BSwitch ID="Internal_chkLimitaVisibilita" runat="server" Width="42" Height="24" CssClass="BFloatLeft BSwitch" />
  </div>

  <asp:Panel ID="PnlVisibilita" runat="server" class="BFloatLeft BWidth100-20 BPanelRadius BMargin10 ">
    <%-- CONTROLLO IDSysSistema --%>
    <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Sistema</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
      <BWC:BCombo ID="Internal_mbcIDSysSistema" runat="server"
        NomeTabella="sysSistemi" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
        INVIO="true" CssClass="BInputControl BWidth100">
      </BWC:BCombo>
    </div>
    <%-- CONTROLLO IDSysProfilo --%>
    <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Profilo</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
      <BWC:BCombo ID="Internal_mbcIDSysProfilo" runat="server"
        NomeTabella="sysProfili" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
        INVIO="true" CssClass="BInputControl BWidth100">
      </BWC:BCombo>
    </div>
    <%-- CONTROLLO IDSysUtente --%>
    <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Utente</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BTesto ID="Internal_mbtIDSysUtente" runat="server" Style="" INVIO="true"
        CssClass="BWidth100 " CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
        HelpButton="false">       
      </BWC:BTesto>
    </div>
    <%-- CONTROLLO InviaEmail --%>
    <label class="BLabelControl BNextControlGoDown  " style="width: 200px;">Invia Email</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BSwitch ID="Internal_chkInviaEmail" runat="server" Width="42" Height="24" CssClass="BFloatLeft BSwitch" />
    </div>


  </asp:Panel>

  <BWC:BButton ID="BtnShowNotifiche" runat="server"
    Text="Visualizza il dettaglio della notifica"
    CssClass="BBtn BBtnWarning BBtnLeft BIconCampana BWidth100-20 BMargin10 BFloatLeft"
    Style="height: 32px;" />

  <BWC:BModalPopup runat="server" ID="pnlNotifiche" Titolo="Dettaglio notifica"
    CssBtnClose="BDisplayNone"
    TextAnnulla="Chiudi"
    TextConferma=""
    Width="90%"
    Height="90%"
    CssPnlContainer="BPanelRadius"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnAnnulla="BFloatRight BBtnCancel"
    CssBtnConferma="BDisplayNone">
    <Content>
      <%-- ADD CONTENT HERE --%>
      <BWC:BGridView ID="DtgElenco" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True" CssClass="BDtg" AllowPaging="True">
        <Columns>
          <asp:BoundField DataField="IDsysUtente" HeaderText="IDUtente" HeaderStyle-CssClass="BDtgHeader"></asp:BoundField>
          <asp:BoundField DataField="Notificata" HeaderText="Notificata" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="DataNotificata" HeaderText="In Data" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="Letta" HeaderText="Letta" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="DataLetta" HeaderText=" In Data" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="Cancellata" HeaderText="Cancellata" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="DataCancellata" HeaderText="In Data" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>
          <%--IDsysUtente	IDsysNotifica	Letta	Notificata	Cancellata	DataLetta	DataNotificata	DataCancellata--%>
        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
    </Content>
  </BWC:BModalPopup>

</asp:Panel>
