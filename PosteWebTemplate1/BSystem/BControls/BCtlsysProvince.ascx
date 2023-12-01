<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysProvince.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysProvince" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 80px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="2"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDRegione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Regione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BCombo ID="Internal_mbcIDRegione" runat="server"
      NomeTabella="sysRegioni" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="" INVIO="true" CssClass="BInputControl BFloatLeft BTesto10 TestoDefault BWidth100">
    </BWC:BCombo>
  </div>

</asp:Panel>
