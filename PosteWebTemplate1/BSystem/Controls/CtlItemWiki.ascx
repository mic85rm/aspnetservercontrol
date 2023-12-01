<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CtlItemWiki.ascx.cs" Inherits="PosteWebTemplate1.CtlItemWiki" %>
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

<div class="BFloatLeft BWidth100-10 DtlSmartPhone" style="margin: 5px; margin-top: 20px !important;">
  <asp:Label ID="lblTitolo" runat="server" Text="Label" CssClass="BTesto14 BTestoBold BH1"></asp:Label>
  <br />
  <asp:Label ID="LblSottotitolo" runat="server" Text="Label" CssClass="BTesto9 BTestoItalic BH2"></asp:Label>
  <br />
  <br />

  <div class="BWidth100 BFloatLeft BTesto10 DtlSmartPhone" id="contentLiteral" runat="server" style="max-height: 100px; overflow: hidden; padding-bottom: 20px;">
    <asp:Literal ID="ltlBody" runat="server">                   
    </asp:Literal>
  </div>

  <%-- WIKI ALLEGATI --%>
  <asp:Panel ID="pnlAllegati" runat="server" CssClass="BFloatLeft BWidth100 " Style="margin-top: 20px;">
    <h1 class="BH1">Allegati:</h1>
    <asp:Repeater runat="server" ID="rptAllegati">
      <ItemTemplate>
        <asp:HyperLink runat="server" ID="LnkPathAllegato" Text='<%# Eval("Descrizione") + ";"%>' 
          CssClass="BTestoAzzurro BTestoItalic BTesto12"></asp:HyperLink>
      </ItemTemplate>
    </asp:Repeater>
  </asp:Panel>

  <%-- WIKI LINK --%>
  <asp:Panel ID="pnlLink" runat="server" CssClass="BFloatLeft BWidth100 " Style="margin-top: 20px;">
    <h1 class="BH1">Vedi anche:</h1>
    <asp:Repeater ID="rptLinks" runat="server">
      <ItemTemplate>
        <asp:LinkButton ID="lnkRef" runat="server" Text='<%# Eval("WikiRef.Titolo") + ";"%>' CommandArgument='<%#Eval("WikiRef.ID")%>' CommandName="Lnk_click" 
          CssClass="BTestoAzzurro BTestoItalic BTesto12" Style="margin-right: 5px; margin: 5px;"> </asp:LinkButton>
      </ItemTemplate>
    </asp:Repeater>
  </asp:Panel>
</div>
<div class="BRow" style="border-top: solid 1px #00a1fd; height: 20px;"></div>

