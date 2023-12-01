<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysPolicyPwd.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysPolicyPwd" %>


<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO ScadenzaPwd --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Scadenza Pwd</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BSwitch ID="Internal_chkScadenzaPwd" runat="server" Width="42" Height="24" CssClass="BSwitch BFloatLeft" BindToProperty="DISPLAY" />
  </div>
  <div class="BRow"></div>
  <asp:Panel ID="PnlScadenzaPwd" runat="server" CssClass="BWidth100 BFloatLeft">
    <%-- CONTROLLO NumGiorni --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Dopo Giorni</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BTesto ID="Internal_mbtNumGiorni" runat="server" Style="width: 60px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="3"></BWC:BTesto>
    </div>
    <%-- CONTROLLO ChkPwdImmessa --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Check Pwd Ripetuta</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
      <BWC:BSwitch ID="Internal_chkChkPwdImmessa" runat="server" Width="42" Height="24" CssClass="BSwitch BFloatLeft" BindToProperty="DISPLAY" />
    </div>
    <div class="BRow"></div>
    <%-- CONTROLLO NumMaxChkPwdImmessa --%>
    <asp:Panel ID="PnlNumPwd" runat="server" CssClass="BWidth100 BFloatLeft">
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Dopo Num. Pwd</label>
      <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
        <BWC:BTesto ID="Internal_mbtNumMaxChkPwdImmessa" runat="server" Style="width: 60px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
      </div>
    </asp:Panel>
  </asp:Panel>
  <%-- CONTROLLO Sistema --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sistema</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BCheck ID="Internal_chkSistema" runat="server" CssClass="BFloatLeft BCheck"  INVIO="true" />
  </div>
</asp:Panel>
