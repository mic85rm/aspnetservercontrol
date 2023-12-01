<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysModuli.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysModuli" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <bwc:btesto id="Internal_mbtID" runat="server" style="width: 100px;" invio="true" cssclass=" BFloatLeft BTesto10 TestoDefault" csshelpbutton="" datatype="NUMERICO" textformat="NESSUNO" helpbutton="false"></bwc:btesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <bwc:btesto id="Internal_mbtDescrizione" runat="server" style="" invio="true" cssclass="BWidth100 BFloatLeft BTesto10 TestoDefault" csshelpbutton="" datatype="ALFANUMERICO" textformat="NESSUNO" helpbutton="false"></bwc:btesto>
  </div>

</asp:Panel>
