<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysFunzione.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysFunzione" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio ">

  <%-- CONTROLLO ID --%>
  <div class="BFloatLeft BWidth100 BNextControlGoDown">
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">ID</label>
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="True"
      CssClass="BInputControl BTesto10 TestoDefault"
      CssHelpButton=""
      DataType="NUMERICO"
      TextFormat="NESSUNO"
      HelpButton="FALSE"></BWC:BTesto>

    <%-- CONTROLLO ORDINE --%>
    <BWC:BTesto ID="Internal_mbtOrdine" runat="server" Style="width: 100px;" INVIO="True" Visible="FALSE"
      CssClass="BInputControl BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>

    <%-- CONTROLLO PADRE --%>
    <div class="BFloatLeft BNextControlGoDown">
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault">Padre</label>
      <BWC:BCombo ID="Internal_mbcIDPadre" runat="server"
        NomeTabella="sysFunzioni" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
        Style="width: 200px" INVIO="True" CssClass="BInputControl BTesto10 TestoDefault">
      </BWC:BCombo>
    </div>
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO DESCRIZIONE --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BMarginBottom5" style="width: 200px;">Descrizione</label>
    <div class="BMarginBottom5 BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 250px;">
      <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-20 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
    </div>
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO COMANDO --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Comando</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 250px;">
      <BWC:BTesto ID="Internal_mbtComando" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-20 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" TabIndexMaxLength="200"></BWC:BTesto>
    </div>
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO AUTH --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Auth</label>
    <BWC:BSwitch ID="Internal_chkAuth" runat="server" Width="42" Height="24" CssClass="BSwitch" SliderIsSquare="false" />
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO DEVELOPER --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Developer</label>
    <BWC:BSwitch ID="Internal_chkDeveloper" runat="server" Width="42" Height="24" CssClass="BSwitch" />
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO ATTIVO --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Attivo</label>
    <BWC:BSwitch ID="Internal_chkAttivo" runat="server" Width="42" Height="24" CssClass="BSwitch" />
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BMarginBottom5">
    <%-- CONTROLLO MODULO --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Modulo</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 250px;">
      <BWC:BCombo ID="Internal_mbcIDSysModulo" runat="server"
        NomeTabella="sysModuli" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
        Style="width: 200px" INVIO="True" CssClass="BInputControl BTesto10 TestoDefault">
      </BWC:BCombo>
    </div>
  </div>

  <div class="BFloatLeft BWidth100 BNextControlGoDown">
    <%-- CONTROLLO TOOLTIP --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Tooltip</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 250px;">
      <BWC:BTesto ID="Internal_mbtTooltip" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-20 BTesto10 TestoDefault"
        CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
    </div>
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown">
    <%-- CONTROLLO SHORTCUT --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Short Cut</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 250px;">
      <BWC:BTesto ID="Internal_mbtShortCut" runat="server" INVIO="True" CssClass="BInputControl BWidth100-20 BTesto10 TestoDefault"
        CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="50"></BWC:BTesto>
    </div>
  </div>
  <div class="BFloatLeft BWidth100 BNextControlGoDown BDisplayNone">
    <%-- CONTROLLO FUNZIONEWP --%>
    <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID Funzione WP</label>
    <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important; min-width: 150px;">
      <BWC:BTesto ID="Internal_mbtIDFunzioneWP" runat="server" Style="width: 100px;" INVIO="True"
        CssClass="BInputControl BWidth100-20 BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
    </div>
  </div>
  <%-- CONTROLLO IMAGE --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Icona</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BImage ID="Internal_imgImage" runat="server" AbilitaUpload="True" Width="128px" Height="128px" AltezzaImmagine="64" LarghezzaImmagine="64" CssClass="BBorder1 BMarginTop10 BFloatLeft" />
    <BWC:BButton ID="btnCancellaIcona" runat="server" CssClass="BBtn BBtnCenter BFloatLeft BMarginLeft5 BMarginTop10 BIconElimina" Width="32px" Height="32px" />
  </div>
</asp:Panel>
