<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysUtenti.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysUtenti" %>

<%@ Register Src="~/BSystem/BControlsSearch/BCtlsysPersonaleSearch.ascx" TagPrefix="SC" TagName="BCtlsysPersonaleSearch" %>


<asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio ">

  <%-- Controllo ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="False" MaxLength="20" />
  </div>

  <%-- CONTROLLO Anagrafica --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Anagrafica</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtIDPersona" runat="server" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BDisplayNone"></BWC:BTesto>
    <BWC:BTesto ID="Internal_mbtPersona" runat="server" Style="width: calc(100% - 100px);" INVIO="True" CssClass="BBGColorDarkGray BFloatLeft BTesto10" CssHelpButton="BTestoHelpButton BIconLente BBtnCenter" TextHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="True" MaxLength="20" ToolTip="Premere F9 per cercare nell'anagrafica" ReadOnly="True" HelpButtonCausesValidation="false" />
    <BWC:BButton ID="BtnEliminaPersona" runat="server" CssClass="BIconElimina BFloatLeft BBtnCenter BTestoHelpButton" Width="32px" CausesValidation="false" />
  </div>

  <%-- CONTROLLO IDVisibilita --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Visibilità</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDVisibilita" runat="server"
      INVIO="True" CssClass="BFloatLeft BTesto9 TestoDefault SmartCombo"
      NomeTabella="VisibilitaTerritoriali" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione">
    </BWC:BCombo>
  </div>

  <%-- CONTROLLO Dominio --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Dominio</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtDominio" runat="server" Style="" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="200"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Username --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Nome utente</label>
  <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
    <BWC:BTesto ID="Internal_mbtNomeUtente" runat="server" Style="" INVIO="True" Width="200px"
      CssClass="BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO"
      AutoCompleteType="Disabled"
      HelpButton="FALSE" MaxLength="200"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Attivo --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Attivo</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BSwitch ID="Internal_chkAttivo" runat="server" Width="42" Height="24" CssClass="BSwitch" />
  </div>

  <%--TBL RELATION --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Profilo:</label>
  <div class="BInputControl BNextControlGoDown BPanel" style="width: calc(100% - 80px);">
    <BWC:BTreeView ID="tvwProfili" runat="server"
      CollapseImageUrl="~/BSystem/Image/Collapse.png"
      ExpandImageUrl="~/BSystem/Image/Expand.png"
      ExpandDepth="0"
      CssClass="BTesto12"
      LeafNodeStyle-CssClass="BTesto10 TestoDefault" NodeStyle-CssClass="BTesto12 TestoDefault" ParentNodeStyle-CssClass="BTesto12">
      <LevelStyles>
        <asp:TreeNodeStyle Font-Underline="False" Height="24px" Width="204px" CssClass="BTestoNero BTesto12" />
      </LevelStyles>
    </BWC:BTreeView>
  </div>

  <%-- CONTROLLO IDSysSistema --%>
  <label runat="server" id="DivLblSistema" class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sistema Prdefinito</label>
  <div runat="server" id="DivCtlSistema" class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDSysSistema" runat="server"
      INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault SmartCombo"
      NomeTabella="sysSistemi" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione">
    </BWC:BCombo>
  </div>

  <%-- CONTROLLO IDSysProfilo --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Profilo Predefinito</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 220px);">
    <BWC:BCombo ID="Internal_mbcIDSysProfilo" runat="server"
      INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault SmartCombo"
      NomeTabella="sysProfili" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione">
    </BWC:BCombo>
  </div>



  <%-- CONTROLLO Developer --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BDisplayNone" style="width: 200px;">Developer</label>
  <BWC:BCheck ID="Internal_chkDeveloper" runat="server" CssClass="BFloatLeft BDisplayNone" Style="width: calc(100% - 220px);" INVIO="True" />


  <%--MODALPOPUP PANEL--%>
  <SC:BCtlsysPersonaleSearch runat="server" ID="BCtlsysPersonaleSearch" />
</asp:Panel>
