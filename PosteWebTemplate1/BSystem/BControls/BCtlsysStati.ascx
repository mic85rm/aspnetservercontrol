<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysStati.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysStati" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 60px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="3"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Nota --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Nota</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtNota" runat="server" Style="height: 100px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="150" TextMode="MultiLine"></BWC:BTesto>
  </div>
  <%-- CONTROLLO FlagCEE --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">FlagCEE</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtFlagCEE" runat="server" Style="width: 60px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="1"></BWC:BTesto>
  </div>

</asp:Panel>
