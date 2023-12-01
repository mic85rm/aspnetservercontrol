<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysLog.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysLog" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDSysAccesso --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sys Accesso</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BCombo ID="Internal_mbcIDSysAccesso" runat="server"
      NomeTabella="sysAccessi" CampoKey="ID" CampoDescr="IDSysUtente" CampiOrdinati="IDSysUtente"
      Style="" INVIO="True" CssClass="BInputControl BFloatLeft BTesto10 TestoDefault BWidth100">
    </BWC:BCombo>
  </div>
  <%-- CONTROLLO Data --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtData" runat="server" Style="width: 100px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BHelpButton" DataType="DATA" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="10"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Origine --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Origine</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtOrigine" runat="server" Style="" INVIO="True" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Messaggio --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Messaggio</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtMessaggio" runat="server" Style="min-height: 200px;" INVIO="True" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" TextMode="MultiLine"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDSysSeverity --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sys Severity</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BCombo ID="Internal_mbcIDSysSeverity" runat="server"
      NomeTabella="SysSeverity" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="" INVIO="True" CssClass="BInputControl BFloatLeft BTesto10 TestoDefault BWidth100">
    </BWC:BCombo>
  </div>

</asp:Panel>
