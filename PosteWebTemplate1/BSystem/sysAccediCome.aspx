<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysAccediCome.aspx.cs" Inherits="PosteWebTemplate1.sysAccediCome" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagPrefix="uc1" TagName="CtlCommandBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CtnSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctnMain" runat="server">

  <%-- PANNELLO COMANDI --%>
  <uc1:CtlCommandBar runat="server" ID="CtlCommandBar" />

  <%-- PANNELLO RICERCA --%>
  <asp:Panel ID="PnlRicerca" runat="server" CssClass="Page_Ricerca">
    <BWC:BCollapsiblePanel ID="bcpRicerca" runat="server" CssClass="Page_Ricerca" Titolo="Ricerca:">
      <Content>
        <asp:Panel ID="PnlRicercaInternal" runat="server" Class="BFloatLeft BWidth100-40 BMarginLeft20">

          <%-- Controllo ID --%>
          <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">IDUtente</label>
          <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtIDUtenteRicerca" runat="server" INVIO="True"
              CssClass="BFloatLeft BTesto10 TestoDefault"
              DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="20" Width="200px"></BWC:BTesto>
          </div>

          <%-- Controllo Nome --%>
          <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Nome</label>
          <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtNomeRicerca" runat="server" INVIO="True"
              CssClass="BFloatLeft BTesto10 BWidth100-20 TestoDefault"
              DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
          </div>

          <%-- Controllo Cognome--%>
          <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Cognome</label>
          <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
            <BWC:BTesto ID="mbtCognomeRicerca" runat="server" INVIO="True"
              CssClass="BFloatLeft BTesto10 BWidth100-20 TestoDefault"
              DataType="ALFANUMERICO" TextFormat="NESSUNO"
              HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
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
    <BWC:BGridView ID="DtgElenco" runat="server"
      AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True"
      CssClass="BDtg BWidth100" AllowPaging="True">
      <Columns>
        <asp:TemplateField ShowHeader="False">
          <ItemTemplate>
            <BWC:BButton ID="BtnSelect" ToolTip="Seleziona l'elemento" runat="server"
              CausesValidation="false" CommandName="BSelect"
              CssClass="BFloatLeft BIconSeleziona BBtnTrasparente" Text=""
              CommandArgument="<%#Container.DisplayIndex%>"
              Width="24px" Height="24px"
              Style="margin-left: 4px !important;" />
          </ItemTemplate>
          <HeaderStyle Width="32px" CssClass="BDtgHeader" />
          <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
        </asp:TemplateField>
        <asp:BoundField DataField="IDUtente" HeaderText="IDUtente">
          <ItemStyle Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="DescrizioneSistema" HeaderText="Sistema"
          HeaderStyle-CssClass="BDtgHeader">
          <ItemStyle Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="NomePersona" HeaderText="Nome"
          HeaderStyle-CssClass="BDtgHeader"></asp:BoundField>
        <asp:BoundField DataField="CognomePersona"
          HeaderStyle-CssClass="BDtgHeader"></asp:BoundField>
        <asp:BoundField DataField="CodiceFiscalePersona" HeaderText="CodiceFiscale"
          HeaderStyle-CssClass="BDtgHeader">
          <ItemStyle Width="120px" />
        </asp:BoundField>
        <asp:BoundField DataField="DescrizioneProfilo" HeaderText="Profilo"
          HeaderStyle-CssClass="BDtgHeader">
          <ItemStyle Width="120px" />
        </asp:BoundField>
      </Columns>
      <HeaderStyle CssClass="BDtgRowHeader" />
      <FooterStyle CssClass="BDtgRowFooter" />
      <PagerSettings Visible="False" />
      <RowStyle CssClass="BDtgRow BRowClick" />
      <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
    </BWC:BGridView>
    <BWC:BPager ID="BDtgPager" runat="server" CssClass="BPager" CssBtnXlsExport="BDisplayNone"></BWC:BPager>
  </asp:Panel>

</asp:Content>
