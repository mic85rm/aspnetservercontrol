<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlLogin.ascx.cs" Inherits="PosteWebTemplate1.CtlLogin" %>

<div class="BLogin_Container">
  <div class="BLogin_InputsContainer BMarginBottom15">
    <div class="BLogin_Username">
      <div class="BLabelControl BNextControlGoDown BTesto10 " style="width: 100px;">Utente</div>
      <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 120px); margin: 0px !important;">
        <BWC:BTesto ID="mbtUsername" runat="server" Text="" ToolTip="Inserisci il nome utente" INVIO="True" MaxLength="20" Style="width: 100%" CssClass="BInputControl BTesto10 "></BWC:BTesto>
      </div>
    </div>
    <div class="BLogin_Password BMarginTop8">
      <div class="BLabelControl BNextControlGoDown BTesto10 " style="width: 100px;">Password</div>
      <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 120px); margin: 0px !important;">
        <BWC:BTesto ID="mbtPassword" runat="server" Text="" ToolTip="Inserisci la password" INVIO="True" TextMode="Password" Style="width: 100%" CssClass="BInputControl BTesto10 " />
      </div>
    </div>
    <div class="BLogin_Buttons BMarginBottom10">
      <BWC:BButton ID="btnAccedi" runat="server" CssClass=" BBtnPoste BMarginRight8 BMarginTop10 BFloatRight" Text="Accedi" EnabledInvio="false" Visible="true" />
    </div>
    <div class="BLogin_MsgBox">
      <asp:Label ID="lblInfo" runat="server" CssClass="BLogin_LabelMsgBox BDisplayNone"></asp:Label>
    </div>
  </div>
  <div class="BLogin_Error">
    <asp:HyperLink ID="imgDivieto" runat="server" CssClass="BLogin_ImgError BDisplayNone" Visible="False" Width="48px" Height="48" />
  </div>
  <div class="BLogin_Registrazione">
    <asp:LinkButton ID="btnRegistrazione" runat="server" ToolTip="Registrati" CssClass="BTesto10 " Visible="false">Se non sei registrato, clicca qui...</asp:LinkButton><br />
    <asp:LinkButton ID="btnRecuperaPwd" runat="server" CssClass="BTesto10 " ToolTip="Recupero Password">Hai dimenticato la password? clicca qui</asp:LinkButton>
  </div>
</div>

<BWC:BModalPopup runat="server" ID="pnlSelectDomain" Titolo="Scelta Dominio"
  CssBtnClose="BDisplayNone"
  TextAnnulla="Annulla"
  TextConferma="Salva"
  Width="90%"
  Height="90%"
  CssPnlContainer="BPanelRadius"
  CssPnlContent="BPanelContent"
  CssPnlFooter="BPanelFooter"
  CssPnlHeader="BPanelTitle"
  CssBtnAnnulla="BFloatRight BBtnCancel"
  CssBtnConferma="BFloatRight BBtnSuccess">
  <Content>
    <%-- ADD CONTENT HERE --%>
      <div style="width: 98%; margin-left: 1%; margin-right: 1%;">
        <span>Attenzione, l'utente di rete risulta associato a diversi domini. Si prega di selezionare il dominio con cui effettaure il login:</span>
        <br />
        <br />
        <asp:RadioButtonList runat="server" ID="rblDomini" RepeatDirection="Vertical" DataTextField="Dominio" DataValueField="Dominio">
        </asp:RadioButtonList>
        <br />
        <asp:Label runat="server" ID="lblErrore" Text="Attenzione, specificare il dominio per procedere." ForeColor="Red" Visible="false"></asp:Label>
      </div>
  </Content>
</BWC:BModalPopup>
