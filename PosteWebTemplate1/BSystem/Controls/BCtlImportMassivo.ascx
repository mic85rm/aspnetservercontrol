<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlImportMassivo.ascx.cs" Inherits="PosteWebTemplate1.BCtlImportMassivo" %>

<asp:Panel runat="server" ID="PnlLinkCss" Visible="false">
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

<div class="BWidth100 BFloatLeft">
  <asp:Panel ID="DivTitolo" Visible="true" runat="server" CssClass="BWidth100"
    Style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
    <asp:Label ID="LblTitolo" runat="server" CssClass="lblTitolo" Text="Gestione Import Massivo"></asp:Label>
  </asp:Panel>

  <hr class="BRow" />

  <div class="BWidth100 BFloatLeft" style="height: 30px;">
    <div class="BFloatLeft BWidth50">
      <BWC:BUploader ID="BUploader" runat="server" Height="32px" CssClass="BPanel BWidth100-10" Style="margin-left: 5px; margin-right: 5px;" AbilitaDragDrop="FALSE" />
    </div>
    <div class="BFloatLeft BWidth50">
      <BWC:BButton ID="btnAdd" runat="server" CssClass="BBtn BBtnLeft BIconNuovo BFloatLeft" Style="width: 100px; height: 32px; margin-right: 5px;" Text="Carica" CausesValidation="false" />
      <BWC:BButton ID="btnDownloadTemplate" runat="server" CssClass="BBtn BBtnLeft BIconExcel BFloatRight" Style="width: 150px; height: 32px; margin-right: 10px;" Text="Scarica Template" CausesValidation="false" />
    </div>
  </div>

  <asp:Panel ID="PnlDtg" runat="server" CssClass="BWidth100-20 BFloatLeft BPanel" Style="height: 300px; margin-left: 10px; margin-top: 10px; overflow: auto;">
    <BWC:BGridView ID="dtgElenco" runat="server"
      AutoGenerateColumns="true" ShowFooter="False"
      ShowHeaderWhenEmpty="True" CssClass="BDtg BWidth100-20" AllowPaging="True">
      <Columns>
        <asp:TemplateField ShowHeader="False">
          <ItemTemplate>
            <asp:LinkButton ID="BtnDel" ToolTip="Elimina elemento" runat="server" CausesValidation="false" CommandName="BDelete" CssClass="BBtnTrasparente BIconElimina" Text="" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" CommandArgument="<%#Container.DisplayIndex%>" Width="24px" Height="24px" />
          </ItemTemplate>
          <HeaderStyle Width="32px" CssClass="BDtgHeaderCommand" />
          <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
        </asp:TemplateField>
      </Columns>
      <HeaderStyle CssClass="BDtgRowHeader" />
      <FooterStyle CssClass="BDtgRowFooter" />
      <PagerSettings Visible="False" />
      <RowStyle CssClass="BDtgRow BRowClick" />
      <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
    </BWC:BGridView>

  </asp:Panel>
  <div class="BWidth100-20 BFloatLeft" style="margin-left: 10px">
    <BWC:BPager ID="BDtgPager" runat="server" CssClass="BPager BWidth100-5"></BWC:BPager>
  </div>
  <div class="BWidth100-10 BFloatLeft" style="text-align: right; margin: 5px; margin-top: 15px !important;">
    <BWC:BButton ID="BtnAnnulla" runat="server" CssClass="BBtnLeft BIconAnnulla BFloatRight" Style="width: 120px; height: 32px;" Text="Annulla" CausesValidation="false" />
    <BWC:BButton ID="BtnConferma" runat="server" CssClass="BBtnLeft BIconSeleziona BFloatRight" Style="width: 120px; height: 32px;" Text="Conferma" CausesValidation="false" />
  </div>

</div>
