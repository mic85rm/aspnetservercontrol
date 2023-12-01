<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysInitDB.aspx.cs" Inherits="PosteWebTemplate1.sysInitDB" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <asp:Panel ID="pnlLnk" runat="server" Visible="false">
    <link href="Css/Master.css" rel="stylesheet" />
    <link href="Css/MasterBackgroundColor.css" rel="stylesheet" />
    <link href="Css/MasterBase.css" rel="stylesheet" />
    <link href="Css/MasterBorder.css" rel="stylesheet" />
    <link href="Css/MasterButtons.css" rel="stylesheet" />
    <link href="Css/MasterColors.css" rel="stylesheet" />
    <link href="Css/MasterCommandBar.css" rel="stylesheet" />
    <link href="Css/MasterFonts.css" rel="stylesheet" />
    <link href="Css/MasterFontsSmartphone.css" rel="stylesheet" />
    <link href="Css/MasterFontsTablet.css" rel="stylesheet" />
    <link href="Css/MasterHeight.css" rel="stylesheet" />
    <link href="Css/MasterMargin.css" rel="stylesheet" />
    <link href="Css/MasterPadding.css" rel="stylesheet" />
    <link href="Css/MasterPanels.css" rel="stylesheet" />
    <link href="Css/MasterResponsive.css" rel="stylesheet" />
    <link href="Css/MasterResponsiveSmartphone.css" rel="stylesheet" />
    <link href="Css/MasterResponsiveTablet.css" rel="stylesheet" />
    <link href="Css/MasterRound.css" rel="stylesheet" />
    <link href="Css/MasterTable.css" rel="stylesheet" />
    <link href="Css/MasterWidth.css" rel="stylesheet" />
  </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <%-- PANNELLO COMANDI --%>
  <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

  <%-- PANNELLO DETTAGLIO --%>
  <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPanelContainerBase ">
    <div class="BFloatLeft BPanelShadowRadius BMargin5 ">
      <label class="BLabelControl BNextControlGoDown" style="min-width: 200px">Database Template</label>
      <BWC:BButton ID="BtnAggiornaDB_BTamplate" runat="server" Text="Aggiorna Struttura"
        CssClass="BBtn BBtnMenu_Doppio_Empty BBtnLeft BIconInitDB" />
    </div>

    <div class="BFloatLeft BPanelShadowRadius BMargin5 ">
      <label class="BLabelControl BNextControlGoDown" style="min-width: 200px">Database Applicativo</label>
      <BWC:BButton ID="BtnAggiornaDB_BSoftware" runat="server" Text="Aggiorna Struttura"
        CssClass="BFloatLeft BBtn BBtnMenu_Doppio_Empty BBtnLeft BIconInitDB" />
      <BWC:BButton ID="BtnInitDB_BSoftware" runat="server" Text="Inizialliza Dati"
        CssClass="BFloatLeft BBtn BBtnMenu_Doppio_Empty BBtnLeft BIconUpload" />
    </div>
    <div class="BFloatLeft BPanelShadowRadius BMargin5 BWidth100-10 " style="min-height: 400px;">
      <label class="BPanelTitle BFloatLeft BWidth100">Log</label>
      <BWC:BTesto ID="mbtLog" runat="server"
        DataType="Alfanumerico" TextMode="MultiLine"
        CssClass="BWidth100-2 BBorderNone"
        Style="background-color: transparent; height:350px"></BWC:BTesto>
    </div>
  </asp:Panel>

  <%-- PANNELLO PRIVACY --%>
  <BWC:BModalPopup ID="pnlImportFile" runat="server" Titolo="Inizializza dati"
    CssBtnClose="BDisplayNone"
    TextAnnulla="Chiudi"
    TextConferma="Importa"
    Width="90%"
    Height="90%"
    CssPnlContainer="BPanelRadius"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnAnnulla="BFloatRight BBtnCancel"
    CssBtnConferma="BFloatRight BBtnSuccess">
    <Content>

      <%-- PANNELLO ELENCO --%>
      <asp:Panel ID="PnlElenco" runat="server" CssClass="WebControlSearchBase_Elenco">
        <BWC:BGridView ID="DtgElenco" runat="server"
          AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True"
          CssClass="BDtg BWidth100" AllowPaging="false" AllowRowClick="false">
          <Columns>
            <asp:TemplateField ShowHeader="False">
              <ItemTemplate>
                <BWC:BSwitch ID="ChkSelect" runat="server" Width="42" Height="24" CssClass="BSwitch" SliderIsSquare="false" />
              </ItemTemplate>
              <HeaderTemplate>
                <BWC:BSwitch ID="ChkSelectAll" runat="server" Width="42" Height="24" CssClass="BSwitch" SliderIsSquare="false" ToolTip="Seleziona/Deseleziona Tutti" />
              </HeaderTemplate>
              <HeaderStyle Width="50px" CssClass="BDtgHeaderCommand" />
              <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
            </asp:TemplateField>

            <asp:BoundField DataField="FileName" HeaderText="BIF File" HeaderStyle-CssClass="BDtgHeader">
              <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="TblName" HeaderText="Tabella" HeaderStyle-CssClass="BDtgHeader">
              <ItemStyle />
            </asp:BoundField>
            <asp:BoundField DataField="Stato" HeaderText="Stato" HeaderStyle-CssClass="BDtgHeader" HeaderStyle-HorizontalAlign="Center">
              <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:BoundField>

          </Columns>
          <HeaderStyle CssClass="BDtgRowHeader" />
          <FooterStyle CssClass="BDtgRowFooter" />
          <PagerSettings Visible="False" />
          <RowStyle CssClass="BDtgRow BRowClick" />
          <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
        </BWC:BGridView>
      </asp:Panel>

    </Content>
  </BWC:BModalPopup>
</asp:Content>
