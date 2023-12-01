<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysUtenti.aspx.cs" Inherits="PosteWebTemplate1.sysUtenti" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysUtenti.ascx" TagPrefix="CCB" TagName="BCtlsysUtenti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO RICERCA --%>
    <asp:Panel ID="PnlRicerca" runat="server" CssClass="Page_Ricerca">
      <BWC:BCollapsiblePanel ID="bcpRicerca" runat="server" CssClass="Page_Ricerca" Titolo="Ricerca:">
        <Content>
          <asp:Panel ID="PnlRicercaInternal" runat="server" Class="BFloatLeft BWidth100-40 BMarginLeft20">
            <%--GESTIONE CONTROLLI RICERCA INIZIO--%>

            <%-- Controllo ID --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BTesto ID="mbtIDRicerca" runat="server" INVIO="True"
                CssClass="BFloatLeft BTesto10 TestoDefault"
                DataType="ALFANUMERICO" TextFormat="NESSUNO"
                HelpButton="FALSE" MaxLength="20" Width="200px"></BWC:BTesto>
            </div>

            <%-- Controllo Sistema ComboBox --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sistema</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BCombo ID="mbcIDSysSistemaRicerca" runat="server"
                NomeTabella="sysSistemi" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
                INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100">
              </BWC:BCombo>
            </div>

            <%-- Controllo Profilo ComboBox --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Profilo</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BCombo ID="mbcIDSysProfiloRicerca" runat="server"
                NomeTabella="sysProfili" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
                INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100">
              </BWC:BCombo>
            </div>

            <%-- Controllo policy Password ComboBox--%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Policy Pwd</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BCombo ID="mbcIDSysPolicyPwdRicerca" runat="server"
                NomeTabella="SysPolicyPwd" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
                INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100">
              </BWC:BCombo>
            </div>

            <%-- Controllo Dominio --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Dominio</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BTesto ID="mbtDominioRicerca" runat="server" INVIO="True"
                CssClass="BFloatLeft BTesto10 TestoDefault" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20" Width="200px"></BWC:BTesto>
            </div>

            <%-- Controllo UserName --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault" style="width: 200px;">Username</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BTesto ID="mbtUsernameRicerca" runat="server" INVIO="True"
                CssClass="BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20" Width="200px"></BWC:BTesto>
            </div>

            <%-- Controlo Nominativo --%>
            <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Nominativo</label>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <BWC:BTesto ID="mbtPersonaRicerca" runat="server" INVIO="True" CssClass="BFloatLeft BWidth100 BTesto10 TestoDefault"
                DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
            </div>


          </asp:Panel>

          <%--GESTIONE CONTROLLO COMMAND BAR SEARCH--%>
          <div class="BFloatLeft BWidth100 BMarginTop20 Page_Ricerca_CommandBar" style="height: 40px;">
            <BWC:BButton ID="BtnCerca" runat="server" Text="Cerca" ToolTip="Ricerca" CssClass="Page_Ricerca_ButtonSearch BIconLente BBtnLeft " />
          </div>
        </Content>
      </BWC:BCollapsiblePanel>
    </asp:Panel>

    <%-- PANNELLO ELENCO --%>
    <asp:Panel ID="PnlElenco" runat="server" CssClass="Page_Elenco">
      <BWC:BGridView ID="DtgElenco" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True" CssClass="BDtg BWidth100" AllowPaging="True">
        <Columns>
          <asp:TemplateField ShowHeader="False">
            <FooterTemplate>
              <BWC:BButton ID="BtnNew" ToolTip="Aggiungi un nuovo elemento" runat="server" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Text="" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </FooterTemplate>
            <HeaderTemplate>
              <BWC:BButton ID="BtnNew" ToolTip="Aggiungi un nuovo elemento" runat="server" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Text="" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </HeaderTemplate>
            <ItemTemplate>
              <BWC:BButton ID="BtnEdit" ToolTip="Modifica l'elemento selezionato" runat="server" CausesValidation="false" CommandName="BEdit" CssClass="BFloatLeft BIconModifica BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" ToolTip="Elimina elemento selezionato" runat="server" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" />
          </asp:TemplateField>
          <asp:BoundField DataField="ID" HeaderText="ID">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="SysSistema" HeaderText="Sistema" HeaderStyle-CssClass="BColumnAutoCollapse" ItemStyle-CssClass="BColumnAutoCollapse">
            <ItemStyle Width="200px" />
          </asp:BoundField>
          <asp:BoundField DataField="SysProfilo" HeaderText="Profilo" HeaderStyle-CssClass="BColumnAutoCollapse" ItemStyle-CssClass="BColumnAutoCollapse">
            <ItemStyle Width="200px" />
          </asp:BoundField>
          <asp:BoundField DataField="Nominativo" HeaderText="Utente">
            <ItemStyle />
          </asp:BoundField>
          <asp:BoundField DataField="Dominio" HeaderText="Dominio" HeaderStyle-CssClass="BColumnAutoCollapse" ItemStyle-CssClass="BColumnAutoCollapse">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="Username" HeaderText="Username" HeaderStyle-CssClass="BColumnAutoCollapse" ItemStyle-CssClass="BColumnAutoCollapse">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Attivo" HeaderStyle-CssClass="BColumnAutoCollapse" ItemStyle-CssClass="BColumnAutoCollapse">
            <ItemStyle Width="30px" HorizontalAlign="Center" />
            <ItemTemplate>
              <asp:Label runat="server" ID="lblAttivo" Text='<%# BHTML.FormattaBool((bool)Eval("Attivo")) %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
      <BWC:BPager ID="BDtgPager" runat="server" CssClass="BPager"></BWC:BPager>
    </asp:Panel>

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">
      <CCB:BCtlsysUtenti runat="server" ID="BCtlsysUtenti" Visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
