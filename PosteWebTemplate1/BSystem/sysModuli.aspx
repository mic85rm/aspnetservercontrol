<%@ Page Title="Moduli" Language="C#" AutoEventWireup="false" MasterPageFile="~/Web.Master" CodeBehind="sysModuli.aspx.cs" Inherits="PosteWebTemplate1.sysModuli" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysModuli.ascx" TagPrefix="CCB" TagName="BCtlsysModuli" %>

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
            <label class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Descrizione</label>
            <BWC:BTesto ID="mbtDescrizioneRicerca" runat="server"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              CssHelpButton=""
              placeholder="Descrizione"
              DataType="ALFANUMERICO"
              TextFormat="NESSUNO"
              HelpButton="FALSE"></BWC:BTesto>

          </asp:Panel>
          <%--GESTIONE CONTROLLO COMMAND BAR SEARCH--%>
          <div class="BFloatLeft BWidth100 BMarginTop20 Page_Ricerca_CommandBar" style="height: 40px;">
            <BWC:BButton ID="BtnCerca" runat="server" Text="Cerca" ToolTip="Ricerca" CssClass="Page_Ricerca_ButtonSearch BIconLente BBtnLeft" />
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
            <HeaderStyle Width="32px" CssClass="BDtgHeaderCommand" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" ToolTip="Elimina elemento selezionato" runat="server" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" CssClass="BDtgHeader" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
          </asp:TemplateField>
          <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle />
          </asp:BoundField>

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
      <CCB:BCtlsysModuli runat="server" ID="BCtlsysModuli" Visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
