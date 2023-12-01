<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysRegistrazione.aspx.cs" Inherits="PosteWebTemplate1.sysRegistrazione" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase ">
    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">

      <%-- CONTROLLO Nome --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 BPaddingBottom8" style="width: 200px;">Nome</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important">
        <BWC:BTesto ID="mbtNome" runat="server" INVIO="True" CssClass="BInputControl BWidth100 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
      </div>

      <%-- CONTROLLO Cognome --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8 " style="width: 200px;">Cognome</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtCognome" runat="server" INVIO="True" Style="" CssClass=" BInputControl BWidth100  BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
      </div>
      <%-- CONTROLLO DataNascita --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Data Nascita</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtDataNascita" runat="server" Style="width: 100px;" INVIO="True" CssClass="BInputControl  BTesto10 TestoDefault" 
          TextHelpButton="" CssHelpButton="BTestoHelpButton BIconCalendar BBtnCenter" DataType="DATA" TextFormat="NESSUNO" HelpButton="TRUE" MaxLength="10"
          CalendarOnHelpButton="true"
          ></BWC:BTesto>
      </div>
      <%-- CONTROLLO Sesso --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Sesso</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BCombo ID="mbcSesso" runat="server"
          Style="width: 100px;" INVIO="True" CssClass="BInputControl BTesto10 TestoDefault">
        </BWC:BCombo>
      </div>
      <%-- CONTROLLO IDComuneNascita --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Comune Nascita</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtIDComuneNascita" runat="server" INVIO="True"
          CssClass="BInputControl BWidth100 BTesto10 TestoDefault"
          CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
          AutoCompleteCampoID="ID" AutoCompleteCampoDescrizione="Descrizione"
          Autocomplete="true" AutoCompleteMinLength="2"
          AutoCompleteWebApiUrl="http://localhost/webempty/webapi/BsysComuni/autocomplete/"
          HelpButton="FALSE"></BWC:BTesto>
      </div>


      <%-- CONTROLLO CodiceFiscale --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Codice Fiscale</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtCodiceFiscale" runat="server" Style="width: 200px;" INVIO="True" CssClass="BInputControl BTesto10 TestoDefault" TextHelpButton="" CssHelpButton="BTestoHelpButton BIconCodiceFiscale32 BBtnCenter" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="TRUE" MaxLength="20"></BWC:BTesto>
      </div>
      <%-- CONTROLLO Email --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Email</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtemail" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100  BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="200"></BWC:BTesto>
      </div>


      <%-- CONTROLLO IDUtente --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Utente</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtIDUtente" runat="server" Style="width: 200px;" INVIO="True" CssClass="BInputControl  BTesto10 TestoDefault" CssHelpButton="BTestoHelpButton BIconSeleziona BBtnCenter" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="TRUE" TextHelpButton="" MaxLength="20" AutoCompleteType="None"></BWC:BTesto>

        <asp:Panel runat="server" ID="ImgCheckUser" CssClass="BIconSemaforoRosso PnlImageCheck " Style="">
        </asp:Panel>
      </div>


      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8" style="width: 200px;">Password</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important;">
        <BWC:BTesto ID="mbtPassword" runat="server" Style="width: 200px;" INVIO="True" CssClass="BInputControl  BTesto10 TestoDefault" TextMode="Password" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20" AutoCompleteType="None"></BWC:BTesto>
      </div>

      <%-- CONTROLLO ID --%>
      <BWC:BTesto ID="mbtID" runat="server" INVIO="True" CssClass="BControlResponsive BTesto10 TestoDefault" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" Visible="false"></BWC:BTesto>


      <div class="BLabelControl BNextControlGoDown BWidth100-20">
        <asp:LinkButton ID="btnShowInformativa" runat="server" ToolTip="Leggi Informativa Privacy" CssClass="BFloatLeft BTestoAzzurro" Visible="true" Font-Size="9pt">Leggi l'informativa e la prestazione del consenso al Trattamento dei Dati DEL D.LGS. N. 196/2003</asp:LinkButton>

      </div>
      <asp:CheckBox ID="chkTermini" runat="server" Text="AUTORIZZO AL TRATTAMENTO DEI DATI ANAGRAFICI" CssClass="BCheck BFloatLeft BMarginLeft10 " TextAlign="Right" />


      <div class="BInputControl BNextControlGoDown BPaddingBottom8 BMarginTop20 BWidth100-20">
        <BWC:BButton ID="BtnConferma" runat="server" CssClass="BBtn BBtnLeft BIconSeleziona" Width="300px" Height="40px" Text="Conferma registrazione." />
      </div>

      <br />
      <br />
    </asp:Panel>

  </asp:Panel>

  <%-- PANNELLO PRIVACY --%>
  <BWC:BModalPopup ID="PnlInformation" runat="server" Titolo="Informativa Privacy"
    CssBtnClose="BDisplayNone"
    TextAnnulla="Chiudi"
    Width="80%"
    Height="80%"
    CssPnlContainer="BPanel"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnAnnulla="BFloatRight BBtnCancel"
    CssBtnConferma="BDisplayNone">
    <Content>
      <asp:Label ID="lblInfo" runat="server" CssClass="TestoInformativa"></asp:Label>
    </Content>
  </BWC:BModalPopup>

  <%-- PANNELLO REGISTRAZIONE COMPLETATA --%>
  <BWC:BModalPopup ID="PnlShowMessage" runat="server"
    Titolo="Registrazione" Width="50%" Height="300px"
    CssPnlContainer="BPanelRadius"
    CssPnlContent="BPanelContent"
    CssPnlFooter="BPanelFooter"
    CssPnlHeader="BPanelTitle"
    CssBtnClose="BDisplayNone"
    CssBtnAnnulla="BFloatRight BBtnSuccess"
    CssBtnConferma="BDisplayNone" TextAnnulla="Torna alla home">
    <Content>
      <asp:Label ID="lblShowMessage" runat="server" Text="Registrazione completata correttamente. A breve riceverà una email per confermare la registrazione" CssClass="TestoShowMessage TestoDefault"></asp:Label>
    </Content>
  </BWC:BModalPopup>
</asp:Content>

