<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysStartAppDebug.aspx.cs" Inherits="PosteWebTemplate1.BSystem.sysStartAppDebug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel runat="server" ID="PnlInternaApp">
    <%-- CONTROLLO ID --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID Utente</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <%--<BWC:BTesto ID="mbtIDUtente" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>--%>
      <BWC:BCombo ID="mbcIDUtente" runat="server" Style="width: 300px;" NomeTabella="vw_DebugUtenti" CampoDescr="Descrizione" CampoKey="ID" AutoPostBack="true"></BWC:BCombo>
    </div>

    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID Visibilità</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BCombo ID="mbcIDVisibilita" runat="server" Style="width: 300px;" NomeTabella="vw_DebugVisibilita" CampoDescr="Descrizione" CampoKey="IDVisibilitaTerritoriale" AutoPostBack="true"></BWC:BCombo>
    </div>

    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID Applicazione</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BCombo ID="mbcIDApplicazione" runat="server" Style="width: 300px;" NomeTabella="vw_DebugApplicazioni" CampoDescr="Descrizione" CampoKey="ID" AutoPostBack="true"></BWC:BCombo>
    </div>
  </asp:Panel>

  <asp:Panel runat="server" ID="pnlChildApp">
    <%-- CONTROLLO ID --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID Token</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BTesto ID="mbtIDToken" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
    </div>
    
  </asp:Panel>

  <div style="margin: 20px;">
    <BWC:BButton ID="BtnToken" runat="server" Text="Start With Token " ToolTip="Ricerca" CssClass=" BIconLente BBtnLeft" />
    <BWC:BButton ID="BtnStartDeveloper" runat="server" Text="Start Developer" ToolTip="Ricerca" CssClass=" BIconLente BBtnLeft" />
  </div>
</asp:Content>
