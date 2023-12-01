<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlConfiguration.ascx.cs" Inherits="PosteWebTemplate1.BCtlConfiguration" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <div class="BInputControl BNextControlGoDown BDisplayNone">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="True" CssClass="BInputControl  BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Ragione Sociale</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px)">
    <BWC:BTesto ID="Internal_mbtDescrizione"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BTesto10 BWidth100-60 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      MaxLength="20"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Logo --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Logo</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BImage ID="Internal_imgLogo"
      runat="server" AbilitaPasteImage="true"
      Width="200px" Height="100px"
      AltezzaImmagine="100" LarghezzaImmagine="200"
      Style="border: solid 1px #0094ff"
      CssDivPasteImage="BTesto10 TestoDefault BFloatLeft"
      AbilitaUpload="True" />
    <div class="BFloatLeft BWidth100 BMarginTop10 " style="height: 50px;">
      <BWC:BButton runat="server" ID="BtnAnnullaLogo" Text="Elimina logo" Width="150px" CssClass="BMarginTop5 BottoneLeft BIconElimina32" />
    </div>
  </div>

  <%-- CONTROLLO MittenteMail --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Mittente Mail</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px)">
    <BWC:BTesto ID="Internal_mbtMittenteMail"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
  </div>

  <%-- CONTROLLO DestinatarioMail --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Intestatario Mail</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px)">
    <BWC:BTesto ID="Internal_mbtDestinatarioMail"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      MaxLength="20"></BWC:BTesto>
  </div>

  <%-- CONTROLLO LeggePrivacy --%>

  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Legge Privacy</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px)">
    <BWC:BTesto ID="Internal_mbtLeggePrivacy"
      runat="server"
      INVIO="True"
      Style="height: 300px;"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      MaxLength="20"
      TextMode="MultiLine"></BWC:BTesto>
  </div>

  <%-- CONTROLLO IDSistemaRegistrazione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Sistema Registrazione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDSistemaRegistrazione" runat="server"
      NomeTabella="sysSistemi" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="width: 300px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>

  <%-- CONTROLLO IDProfiloRegistrazione --%>

  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Profilo Registrazione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDProfiloRegistrazione" runat="server"
      NomeTabella="sysProfili" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="width: 300px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>

  <%-- CONTROLLO IDProfiloNotificaRegistrazione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Notifica Registrazione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDProfiloNotificaRegistrazione" runat="server"
      NomeTabella="sysProfili" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="width: 300px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>

  <%-- CONTROLLO EmailSegnalazioni --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Email Segnalazioni</label>
  <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtEmailSegnalazioni"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      MaxLength="20"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Timer --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Timer (min)</label>
  <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtTimer"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="Valuta"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      TextAlign="Right"
      MaxLength="20"></BWC:BTesto>
  </div>


  <%-- CONTROLLO Data Ultima Sincronizzazione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Data Ultima Sincronizzazione</label>
  <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtDataUltimaSincronizzazione"
      ReadOnly="true"
      Enabled="false"
      runat="server"
      INVIO="True"
      CssClass="BFloatLeft BWidth100-60 BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="ALFANUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"
      MaxLength="20"></BWC:BTesto>
  </div>

    <%-- CONTROLLO IDAmbiente --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Ambiente</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDAmbienti" runat="server"
      NomeTabella="Ambienti" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="width: 300px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>

    <%-- CONTROLLO IDApplicazione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Applicazione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDApplicazioni" runat="server"
      NomeTabella="Applicazioni" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="width: 300px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>




</asp:Panel>
