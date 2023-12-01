<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysPersoneSearch.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysPersoneSearch" %>
<asp:Panel runat="server" Visible="false">
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
</asp:Panel>
<BWC:BModalPopup ID="BmpSearch" runat="server"
  Titolo="Ricerca Persona"
  CssBtnClose="BDisplayNone"
  Width="90%"
  Height="90%"
  CssPnlContainer="BPanelRadius"
  CssPnlContent="BPanelContent"
  CssPnlFooter="BPanelFooter"
  CssPnlHeader="BPanelTitle"
  CssBtnAnnulla="BFloatRight BBtnCancel"
  CssBtnConferma="BFloatRight BBtnSuccess">
  <Content>
    <%--PANNELLO RICERCA--%>
    <BWC:BCollapsiblePanel ID="bcpRicerca" runat="server" CssClass="Page_Ricerca BMarginBottom50" Titolo="Ricerca:">
      <Content>
        <asp:Panel ID="PnlRicercaInternal" runat="server" Class="BFloatLeft BWidth100-40 BMarginLeft20">
          <div class="BLabelControl BNextControlGoDown BTesto10 BCollapseSmartPhone TestoDefault" style="width: 200px;">Codice Fiscale</div>
          <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtCodiceFiscaleRicerca" runat="server"
              Style=""
              placeholder="Codice Fiscale"
              INVIO="True"
              CssClass="BTesto10 BWidth100 BInputControlSearch BNextControlGoDown BSetPlaceHolderOnSmartphone"
              CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="200" />
          </div>

          <div class="BLabelControl BNextControlGoDown BTesto10 BCollapseSmartPhone TestoDefault" style="width: 200px;">Nome</div>
          <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtNomeRicerca" runat="server"
              Style=""
              placeholder="Nome"
              INVIO="True"
              CssClass="BTesto10 BWidth100 BInputControlSearch BNextControlGoDown BSetPlaceHolderOnSmartphone"
              CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="200" />
          </div>

          <div class="BLabelControl BNextControlGoDown BTesto10 BCollapseSmartPhone TestoDefault" style="width: 200px;">Cognome</div>
          <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtCognomeRicerca" runat="server"
              Style=""
              placeholder="Cognome"
              INVIO="True"
              CssClass="BTesto10 BWidth100 BInputControlSearch BNextControlGoDown BSetPlaceHolderOnSmartphone"
              CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="200" />
          </div>


          <%--CONTROLLO RICERCA mbtDataNascita--%>
          <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Data Nascita</div>
          <div class="BInputControlSearch BNextControlGoDown"
            style="width: calc(100% - 220px);">


            <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="line-height: 11px">Dal</div>
            <BWC:BTesto ID="mbtDataNascitaDalRicerca" runat="server"
              Style="width: 200px;"
              INVIO="True"
              CssClass="BInputControl BTesto10 TestoDefault"
              CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter"
              DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="TRUE"
              TextHelpButton=""
              MaxLength="20"
              CalendarOnHelpButton="true"
              AutoCompleteType="None" />



            <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="line-height: 11px">Dal</div>
            <BWC:BTesto ID="mbtDataNascitaAlRicerca" runat="server"
              Style="width: 200px;"
              INVIO="True"
              CssClass="BInputControl BTesto10 TestoDefault"
              CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter"
              DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="TRUE"
              TextHelpButton=""
              MaxLength="20"
              CalendarOnHelpButton="true"
              AutoCompleteType="None" />

          </div>


        </asp:Panel>

        <%--GESTIONE CONTROLLO COMMAND BAR SEARCH--%>
        <div class="BFloatLeft BWidth100 BMarginTop20 Page_Ricerca_CommandBar" style="height: 40px;">
          <BWC:BButton ID="BtnCerca" runat="server" Text="Cerca" ToolTip="Ricerca" CssClass="Page_Ricerca_ButtonSearch BIconLente BBtnLeft " CausesValidation="false" />
        </div>
      </Content>
    </BWC:BCollapsiblePanel>

    <%-- PANNELLO ELENCO --%>
    <asp:Panel ID="PnlElenco" runat="server" CssClass="WebControlSearchBase_Elenco">
      <BWC:BGridView ID="DtgElenco" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True" CssClass="BDtg BWidth100" AllowPaging="True">
        <Columns>
          <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
              <asp:RadioButton runat="server" ID="OptSelect"></asp:RadioButton>
              <BWC:BCheck runat="server" ID="ChkSelect"></BWC:BCheck>
            </ItemTemplate>
            <HeaderTemplate>
              <BWC:BCheck runat="server" ID="ChkSelectAll" ToolTip="Seleziona/Deseleziona Tutti"></BWC:BCheck>
            </HeaderTemplate>
            <HeaderStyle Width="32px" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" />
          </asp:TemplateField>

          <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="BDisplayNone" ItemStyle-CssClass="BDisplayNone">
            <ItemStyle Width="60px" />
          </asp:BoundField>
          <asp:BoundField DataField="CodiceFiscale" HeaderText="Codice Fiscale">
            <ItemStyle Width="150px" />
          </asp:BoundField>
          <asp:BoundField DataField="Nome" HeaderText="Nome">
            <ItemStyle />
          </asp:BoundField>
          <asp:BoundField DataField="Cognome" HeaderText="Cognome">
            <ItemStyle />
          </asp:BoundField>
          <asp:BoundField DataField="DataNascita" HeaderText="Data Nascita" DataFormatString="{0:dd/MM/yyyy}">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
          </asp:BoundField>

        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
      <BWC:BPager ID="BDtgPager" runat="server" CssClass="BPager"></BWC:BPager>
    </asp:Panel>
  </Content>
</BWC:BModalPopup>
