<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlHeaderBar.ascx.cs" Inherits="PosteWebTemplate1.BCtlHeaderBar" %>
<%@ Register Src="~/BSystem/Controls/BCtlServicesNotification.ascx" TagPrefix="uc1" TagName="BCtlServicesNotification" %>

<asp:Panel runat="server" ID="pnlLnk" Visible="false">
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
  <link href="../../BThemes/tmBApp/BArtsFramework_BCombo.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridViewPanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPropertyGrid.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BRadio.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BSwitch.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BUploader.css" rel="stylesheet" />
</asp:Panel>

<div class="BWidth100 BHeight100">
  <uc1:BCtlServicesNotification runat="server" ID="BCtlServicesNotification" />
  <BWC:BButton ID="BtnHelp" runat="server" CssClass="BBtnTrasparente BIconHelpButton32 BBtnBar" Style="margin-top:16px" />
  <asp:Panel ID="PnlSearch" runat="server" CssClass="PnlSearchAll ">
    <BWC:BTesto ID="mbtSearchAll" runat="server" placeholder="Cerca ..." CssClass="mbtSearchAll BWidth100-50 " TextHelpButton="" HelpButton="FALSE"></BWC:BTesto>
    <BWC:BButton ID="BtnSearch" runat="server" CssClass="BtnSearchAll BBtnTrasparente BIconLenteWhite32" Style="margin: 15px;" />
  </asp:Panel>

  <%-- Modal PopUp ricerca Globale --%>
  <BWC:BModalPopup runat="server" ID="pnlRicercaGlobale" Titolo="Ricerca"
    CssBtnClose="BDisplayNone"
    TextAnnulla="Chiudi"
    TextConferma="Salva"
    Width="80%"
    Height="400px"
    CssPnlContainer="BPanelRadius"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnAnnulla="BFloatRight BBtnCancel"
    CssBtnConferma="BDisplayNone">
    <Content>
      <BWC:BGridView ID="DtgElenco" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeader="false" CssClass="BDtg BWidth100" AllowPaging="True">
        <Columns>
          <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
          <asp:BoundField DataField="Comando" HeaderText="Descrizione" ItemStyle-CssClass="BDisplayNone" HeaderStyle-CssClass="BDisplayNone" />
          <asp:BoundField DataField="Tipo" HeaderText="Tipo" ItemStyle-CssClass="BDisplayNone" HeaderStyle-CssClass="BDisplayNone" />
          <asp:BoundField DataField="Args" HeaderText="Args" ItemStyle-CssClass="BDisplayNone" HeaderStyle-CssClass="BDisplayNone" />
        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
      <BWC:BPager ID="BDtgPager" runat="server" CssClass="BPager" CssBtnXlsExport="BDisplayNone"></BWC:BPager>

    </Content>
  </BWC:BModalPopup>

</div>
