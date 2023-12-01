<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysConfigReportingServices.aspx.cs" Inherits="PosteWebTemplate1.sysConfigReportingServices" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server">
      <div class="BFloatLeft BWidth100-20 BMarginBottom20 BMarginLeft10 BMarginTop20">
        <BWC:BPropertyGrid ID="BPropertyGrid1" runat="server" />
      </div>

      <asp:Panel ID="PnlTestMail" runat="server" CssClass="BFloatLeft BPanel BWidth100-20 BRound8px BMarginBottom20" Style="margin: 10px;">
        <asp:Label ID="lblTitolo" runat="server" CssClass="BFloatLeft BPanelTitle BTestoCenter BWidth100 BMarginBottom30" Text="Test Stampa Report"></asp:Label>
        <div class="BPanelContent BMarginBottom30">
          <div class="BFloatLeft BWidth100-20 BMarginLeft10 TestoDefault BTesto12 BMarginBottom10">Formato</div>
          <BWC:BCombo ID="mbcFormat" runat="server" CssClass="BFloatLeft BWidth100-20 BMarginLeft10 BPaddingTop10" AutoPostBack="true">
          </BWC:BCombo>
        </div>
        <div class="BPanelFooter">
          <BWC:BButton ID="btnTestPDF" runat="server" OnClientClick="aspnetForm.target ='_blank';" Text="Stampa report di prova" Style="margin-top: 1.5px" CssClass="BFloatRight BBtnWarning BMarginRight10" />
        </div>
      </asp:Panel>

      <div class="BFloatLeft TestoDefault BTesto10 BWidth100-20 BMargin10">
        <asp:Label ID="lblFolderInfo" runat="server" Text="Cartella Report" CssClass="BFloatLeft TestoDefault BTesto10" Style="min-width: 300px"></asp:Label>
        <BWC:BButton ID="btnCreaFolder" runat="server" Style="width: 300px" CssClass="BFloatLeft" Text="Crea Cartella Report" />
        <asp:Image ID="imgFolderRosso" runat="server" ImageUrl="~/BThemes/tmBApp/Image/Icon32/rosso.png" CssClass="BFloatRight" />
        <asp:Image ID="imgFolderVerde" runat="server" ImageUrl="~/BThemes/tmBApp/Image/Icon32/verde.png" CssClass="BFloatRight" Visible="False" />
      </div>

      <div class="BFloatLeft TestoDefault Testo10 BWidth100-20 BMargin10">
        <asp:Label ID="lblCnn" runat="server" Text="Connessione dati" CssClass="BFloatLeft TestoDefault BTesto10 " Style="min-width: 300px"></asp:Label>
        <BWC:BButton ID="btnCreaCnn" runat="server" Style="width: 300px" CssClass="BFloatLeft" Text="Crea Connessione Dati" />
        <asp:Image ID="imgCnnRosso" runat="server" ImageUrl="~/BThemes/tmBApp/Image/Icon32/rosso.png" CssClass="BFloatRight" />
        <asp:Image ID="imgCnnVerde" runat="server" ImageUrl="~/BThemes/tmBApp/Image/Icon32/verde.png" CssClass="BFloatRight" Visible="False" />
      </div>

      <BWC:BTesto ID="txtLog" runat="server" CssClass="BFloatLeft BTesto10 TestoDefalut BWidth100-20 BMarginLeft10" TextMode="MultiLine" Style="height: 128px;"></BWC:BTesto>
      <BWC:BButton ID="BtnCheckConfigurazione" runat="server" CssClass="BFloatLeft BWidth100-20 BottoneLeft BMarginLeft10 BMarginTop10 BMarginBottom10" Text="Controlla Configurazione Server di Report" />

    </asp:Panel>
  </asp:Panel>
</asp:Content>
