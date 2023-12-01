<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysAccessi.aspx.cs" Inherits="PosteWebTemplate1.sysAccessi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJX" %>
<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysAccessi.ascx" TagPrefix="CCB" TagName="BCtlsysAccessi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <ccb:ctlcommandbar runat="server" id="CtlCommandBar" />

    <%-- PANNELLO RICERCA --%>
    <asp:Panel ID="PnlRicerca" runat="server" CssClass="Page_Ricerca">
      <bwc:bcollapsiblepanel id="bcpRicerca" runat="server" cssclass="Page_Ricerca" titolo="Ricerca:">
        <Content>
          <asp:Panel ID="PnlRicercaInternal" runat="server" Class="BFloatLeft BWidth100-40 BMarginLeft20">
            <%--GESTIONE CONTROLLI RICERCA INIZIO--%>
            <%--CONTROLLO RICERCA mbtDataAccesso--%>
            <label class="BLabelControlSearch BCollapseSmartPhone BNextControlGoDown BTesto10 TestoDefault" style="width: 100px;">Data Accesso</label>
            <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 180px); margin-top: 0px !important;">
              <div class="BFloatLeft BNextControlGoDown" style="width: 180px; height: 36px;">
                <label class="BFloatLeft BTesto10 TestoDefault" style="width: 30px; line-height: 36px;">Dal</label>
                <BWC:BTesto ID="mbtDataAccessoDalRicerca" runat="server"
                  INVIO="True"
                  Style="width: 100px;"
                  CssClass="BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
                  CssHelpButton="BTestoHelpButton"
                  placeholder="Data Accesso"
                  DataType="Data"
                  TextFormat="NESSUNO"
                  HelpButton="TRUE"
                  MaxLenght="10"></BWC:BTesto>
              </div>
              <div class="BFloatLeft BNextControlGoDown " style="width: 180px; height: 36px;">
                <label class="BFloatLeft BTesto10 TestoDefault" style="width: 30px; line-height: 36px;">al</label>
                <BWC:BTesto ID="mbtDataAccessoAlRicerca" runat="server"
                  INVIO="True"
                  Style="width: 100px;"
                  CssClass="BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
                  CssHelpButton="BTestoHelpButton"
                  placeholder="Data Accesso"
                  DataType="Data"
                  TextFormat="NESSUNO"
                  HelpButton="TRUE"
                  MaxLenght="10"></BWC:BTesto>
              </div>
            </div>
            <AJX:CalendarExtender ID="mbtDataAccessoDalRicerca_CalendarExtender" runat="server" Enabled="True" TargetControlID="mbtDataAccessoDalRicerca" CssClass="calExtender"></AJX:CalendarExtender>
            <AJX:CalendarExtender ID="mbtDataAccessoAlRicerca_CalendarExtender" runat="server" Enabled="True" TargetControlID="mbtDataAccessoAlRicerca" CssClass="calExtender"></AJX:CalendarExtender>


            <label class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Computer</label>
            <BWC:BTesto ID="mbtNomeComputerRicerca" runat="server"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BNextControlGoDown BSetPlaceHolderOnSmartphone BInputControl BTesto10 TestoDefault"
              CssHelpButton=""
              placeholder="Nome Computer"
              DataType="ALFANUMERICO"
              TextFormat="NESSUNO"
              HelpButton="FALSE"></BWC:BTesto>

            <div class="BLabelControlSearch BNextControlGoDown BTesto10 TestoDefault" style="width: 100px;">Sistema</div>
            <BWC:BCombo ID="mbcIDSysSistemaRicerca" runat="server"
              NomeTabella="sysSistemi" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BNextControlGoDown BInputControl BTesto10 TestoDefault">
            </BWC:BCombo>

          </asp:Panel>
          <%--GESTIONE CONTROLLO COMMAND BAR SEARCH--%>
          <div class="BFloatLeft BWidth100 BMarginTop20 Page_Ricerca_CommandBar" style="height: 40px;">
            <BWC:BButton ID="BtnCerca" runat="server" Text="Cerca" ToolTip="Ricerca" CssClass="Page_Ricerca_ButtonSearch BIconLente BBtnLeft" />
          </div>

        </Content>
      </bwc:bcollapsiblepanel>
    </asp:Panel>


    <%-- PANNELLO ELENCO --%>
    <asp:Panel ID="PnlElenco" runat="server" CssClass="Page_Elenco">
      <bwc:bgridview id="DtgElenco" runat="server" autogeneratecolumns="False" showfooter="False" showheaderwhenempty="True" cssclass="BDtg BWidth100" allowpaging="True">
        <Columns>
          <asp:TemplateField ShowHeader="False">
            <FooterTemplate>
              <BWC:BButton ID="BtnNew" ToolTip="Aggiungi un nuovo elemento" runat="server" CausesValidation="false" CommandName="" CssClass="BFloatLeft BDisplayNone BIconNuovo BBtnTrasparente" Text="" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </FooterTemplate>
            <HeaderTemplate>
              <BWC:BButton ID="BtnNew" ToolTip="Aggiungi un nuovo elemento" runat="server" CausesValidation="false" CommandName="" CssClass="BFloatLeft BDisplayNone BIconNuovo BBtnTrasparente" Text="" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </HeaderTemplate>
            <ItemTemplate>
              <BWC:BButton ID="BtnEdit" ToolTip="Modifica l'elemento selezionato" runat="server" CausesValidation="false" CommandName="BView" CssClass="BFloatLeft BIconLente BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" CssClass="BDtgHeaderCommand" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" ToolTip="Elimina elemento selezionato" runat="server" CausesValidation="false" CommandName="" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" CssClass="BDtgHeader BDisplayNone" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand BDisplayNone" />
          </asp:TemplateField>
          <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="DataAccesso" HeaderText="Data Accesso" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="200px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="NomeComputer" HeaderText="Nome Computer" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle />
          </asp:BoundField>
          <asp:BoundField DataField="OraFineLavoro" HeaderText="Ora Fine Lavoro" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="200px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="SysSistema" HeaderText="Sistema" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle />
          </asp:BoundField>

        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </bwc:bgridview>
      <bwc:bpager id="BDtgPager" runat="server" cssclass="BPager"></bwc:bpager>
    </asp:Panel>
    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">
      <ccb:bctlsysaccessi runat="server" id="BCtlsysAccessi" visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
