<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCambiaPassword.ascx.cs" Inherits="PosteWebTemplate1.CtlCambiaPassword" %>
<div class="BFloatLeft BWidth100-20 " style="margin: 10px;">

  <%-- CONTROLLO Vecchia Password --%>
  <div id="divLblOldPwd" runat="Server" class="BH4 BNextControlGoDown BTesto10 TestoDefault BMarginBottom15" style="width: 200px;">Vecchia Password</div>
  <div id="divOldPwd" runat="Server" class="BInputControl BNextControlGoDown BWidth100-50 BMarginBottom15">
    <BWC:BTesto ID="Internal_mbtOldPwd" runat="server" Style="min-width: 200px;" INVIO="True" CssClass="BInputControl BWidth50-50 BTesto10 TestoDefault" CssHelpButton="" DataType="Alfanumerico" TextFormat="NESSUNO" TextMode="Password" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Nuova Password --%>
  <div class=" BNextControlGoDown BTesto10 TestoDefault BMarginBottom15 BH4" style="width: 200px;">Nuova Password</div>
  <div class="BInputControl BNextControlGoDown BWidth100-50 BMarginBottom15">
    <BWC:BTesto ID="Internal_mbtNewPwd" runat="server" Style="min-width: 200px;" INVIO="True" CssClass="BInputControl BWidth50-50 BTesto10 TestoDefault BMarginBottom15" CssHelpButton="" DataType="Alfanumerico" TextFormat="NESSUNO" TextMode="Password" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Conferma Password --%>
  <div class=" BNextControlGoDown BTesto10 TestoDefault BMarginBottom15 BH4" style="width: 200px;">Conferma Password</div>
  <div class="BInputControl BNextControlGoDown BWidth100-50 BMarginBottom15">
    <BWC:BTesto ID="Internal_mbtCommitPwd" runat="server" Style="min-width: 200px;" INVIO="True" CssClass="BMarginBottom15 BInputControl BWidth50-50 BTesto10 TestoDefault" CssHelpButton="" DataType="Alfanumerico" TextFormat="NESSUNO" TextMode="Password" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <div class="BWidth100-50 BFloatLeft Pannello1px BTestoCenter BMargin10 BPadding10">
    <asp:Label ID="lblMessage" runat="server" CssClass="BTestoRosso BTesto12" Text="Inserire la vecchia password e la nuova."></asp:Label>
    <br />
    <asp:LinkButton ID="btnRecuperaPwd" runat="server" ToolTip="Recupero Password" PostBackUrl="~/BSystem/sysRecuperaPassword.aspx" CssClass="BTesto8 BTestoBlu">Hai dimenticato la password? clicca qui</asp:LinkButton>
  </div>
</div>
