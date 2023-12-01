<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysLog.aspx.cs" Inherits="PosteWebTemplate1.sysLog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJX" %>
<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysLog.ascx" TagPrefix="CCB" TagName="BCtlsysLog" %>

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
            <%--CONTROLLO RICERCA mbtData--%>
            <label class="BLabelControlSearch BCollapseSmartPhone BNextControlGoDown BTesto10 TestoDefault" style="width: 100px;">Data</label>
            <div class="BInputControl BNextControlGoDown"
              style="width: calc(100% - 180px); margin-top: 0px !important;">
              <div class="BFloatLeft BNextControlGoDown" style="width: 180px; height: 36px;">
                <label class="BFloatLeft BTesto10 TestoDefault" style="line-height: 36px; width: 30px;">Dal</label>
                <BWC:BTesto ID="mbtDataDalRicerca" runat="server"
                  INVIO="True"
                  Style="width: 100px;"
                  CssClass="BSetPlaceHolderOnSmartphone BFloatLeft BFloatLeft BTesto10 TestoDefault"
                  CssHelpButton="BTestoHelpButton"
                  placeholder="Data"
                  DataType="Data"
                  TextFormat="NESSUNO"
                  HelpButton="TRUE"
                  MaxLenght="10"></BWC:BTesto>
              </div>

              <div class="BFloatLeft BNextControlGoDown " style="width: 180px; height: 36px;">
                <label class="BFloatLeft BTesto10 TestoDefault" style="line-height: 36px; width: 30px;">al</label>
                <BWC:BTesto ID="mbtDataAlRicerca" runat="server"
                  INVIO="True"
                  Style="width: 100px;"
                  CssClass="BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
                  CssHelpButton="BTestoHelpButton"
                  placeholder="Data"
                  DataType="Data"
                  TextFormat="NESSUNO"
                  HelpButton="TRUE"
                  MaxLenght="10"></BWC:BTesto>
              </div>
            </div>
            <AJX:CalendarExtender ID="mbtDataDalRicerca_CalendarExtender" runat="server" Enabled="True" TargetControlID="mbtDataDalRicerca" CssClass="calExtender"></AJX:CalendarExtender>
            <AJX:CalendarExtender ID="mbtDataAlRicerca_CalendarExtender" runat="server" Enabled="True" TargetControlID="mbtDataAlRicerca" CssClass="calExtender"></AJX:CalendarExtender>
            <label class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Origine</label>
            <BWC:BTesto ID="mbtOrigineRicerca" runat="server"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              CssHelpButton=""
              placeholder="Origine"
              DataType="ALFANUMERICO"
              TextFormat="NESSUNO"
              HelpButton="FALSE"></BWC:BTesto>
            <label class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Messaggio</label>
            <BWC:BTesto ID="mbtMessaggioRicerca" runat="server"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              CssHelpButton=""
              placeholder="Messaggio"
              DataType="ALFANUMERICO"
              TextFormat="NESSUNO"
              HelpButton="FALSE"></BWC:BTesto>
            <label class="BLabelControlSearch BNextControlGoDown BTesto10 TestoDefault" style="width: 100px;">Severity</label>
            <BWC:BCombo ID="mbcIDSysSeverityRicerca" runat="server"
              NomeTabella="SysSeverity" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
              Style="width: calc(100% - 180px);"
              INVIO="True"
              CssClass="BInputControl BNextControlGoDown BFloatLeft BTesto10 TestoDefault">
            </BWC:BCombo>

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
            <ItemTemplate>
              <BWC:BButton ID="BtnView" ToolTip="Visualizza elemento selezionato" runat="server" CausesValidation="false" CommandName="BView" CssClass="BIconLente BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" Width="24px" Height="24px" />
            </ItemTemplate>
            <HeaderStyle Width="32px" CssClass="BDtgHeaderCommand" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <HeaderTemplate>
              <BWC:BButton ID="BtnDelAll" ToolTip="Elimina tutti gli elementi" runat="server" CausesValidation="false" CommandName="BDeleteAll" CssClass="BIconElimina BBtnTrasparente" Text="" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare tutte le righe?');" Width="24px" Height="24px" />
            </HeaderTemplate>
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" ToolTip="Elimina elemento selezionato" runat="server" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Text="" CommandArgument="<%#Container.DisplayIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <HeaderStyle Width="32px" CssClass="BDtgHeader" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
          </asp:TemplateField>
          <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="150px" HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="Origine" HeaderText="Origine" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="150px" />
          </asp:BoundField>
          <asp:BoundField DataField="Messaggio" HeaderText="Messaggio" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle />
          </asp:BoundField>
          <asp:BoundField DataField="IDSysAccesso" HeaderText="Accesso" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="80px" HorizontalAlign="Right" />
          </asp:BoundField>
          <asp:BoundField DataField="SysSeverity" HeaderText="Severity" HeaderStyle-CssClass="BDtgHeader">
            <ItemStyle Width="100px" HorizontalAlign="Center" />
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
      <CCB:BCtlsysLog runat="server" ID="BCtlsysLog" Visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
