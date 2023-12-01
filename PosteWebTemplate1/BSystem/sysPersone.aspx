<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysPersone.aspx.cs" Inherits="PosteWebTemplate1.sysPersone" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJX" %>
<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysPersone.ascx" TagPrefix="CCB" TagName="BCtlsysPersone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <ccb:ctlcommandbar runat="server" id="CtlCommandBar" />

    <%-- PANNELLO RICERCA --%>
    <asp:Panel ID="PnlRicerca" runat="server" CssClass="Page_Ricerca">
      <bwc:bcollapsiblepanel id="bcpRicerca" runat="server" cssclass="Page_Ricerca" titolo="Ricerca:">
        <content>
          <asp:Panel ID="PnlRicercaInternal" runat="server" Class="BFloatLeft BWidth100-40 BMarginLeft20">
            <%--GESTIONE CONTROLLI RICERCA INIZIO--%>
            <div class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Codice Fiscale</div>
            <bwc:btesto id="mbtCodiceFiscaleRicerca" runat="server"
              style="width: calc(100% - 180px);"
              invio="True"
              cssclass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              csshelpbutton=""
              placeholder="Codice Fiscale"
              datatype="ALFANUMERICO"
              textformat="NESSUNO"
              helpbutton="FALSE">
            </bwc:btesto>
            <div class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Nome</div>
            <bwc:btesto id="mbtNomeRicerca" runat="server"
              style="width: calc(100% - 180px);"
              invio="True"
              cssclass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              csshelpbutton=""
              placeholder="Nome"
              datatype="ALFANUMERICO"
              textformat="NESSUNO"
              helpbutton="FALSE">
            </bwc:btesto>
            <div class="BLabelControlSearch BNextControlGoDown BCollapseSmartPhone BTesto10 TestoDefault" style="width: 100px;">Cognome</div>
            <bwc:btesto id="mbtCognomeRicerca" runat="server"
              style="width: calc(100% - 180px);"
              invio="True"
              cssclass="BInputControl BNextControlGoDown BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
              csshelpbutton=""
              placeholder="Cognome"
              datatype="ALFANUMERICO"
              textformat="NESSUNO"
              helpbutton="FALSE">
            </bwc:btesto>
            <%--CONTROLLO RICERCA mbtDataNascita--%>
            <div class="BLabelControlSearch BCollapseSmartPhone BNextControlGoDown BTesto10 TestoDefault" style="width: 100px;">Data Nascita</div>
            <div class="BInputControl BNextControlGoDown"
              style="width: calc(100% - 180px); margin-top: 0px !important;">
              <div class="BFloatLeft BNextControlGoDown" style="width: 180px; height: 36px;">
                <div class="BFloatLeft BTesto10 TestoDefault" style="line-height: 36px; width: 30px;">Dal</div>
                <bwc:btesto id="mbtDataNascitaDalRicerca" runat="server"
                  invio="True"
                  style="width: 100px;"
                  cssclass="BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
                  csshelpbutton="BTestoHelpButton"
                  placeholder="Data Nascita"
                  datatype="Data"
                  textformat="NESSUNO"
                  helpbutton="TRUE"
                  maxlenght="10">
                </bwc:btesto>
              </div>

              <div class="BFloatLeft BNextControlGoDown " style="width: 180px; height: 36px;">
                <div class="BFloatLeft BTesto10 TestoDefault" style="line-height: 36px; width: 30px;">al</div>
                <bwc:btesto id="mbtDataNascitaAlRicerca" runat="server"
                  invio="True"
                  style="width: 100px;"
                  cssclass="BSetPlaceHolderOnSmartphone BFloatLeft BTesto10 TestoDefault"
                  csshelpbutton="BTestoHelpButton"
                  placeholder="Data Nascita"
                  datatype="Data"
                  textformat="NESSUNO"
                  helpbutton="TRUE"
                  maxlenght="10">
                </bwc:btesto>
              </div>
            </div>
            <ajx:calendarextender id="mbtDataNascitaDalRicerca_CalendarExtender" runat="server" enabled="True" targetcontrolid="mbtDataNascitaDalRicerca" cssclass="calExtender"></ajx:calendarextender>
            <ajx:calendarextender id="mbtDataNascitaAlRicerca_CalendarExtender" runat="server" enabled="True" targetcontrolid="mbtDataNascitaAlRicerca" cssclass="calExtender"></ajx:calendarextender>
            <div class="BLabelControlSearch BTesto10 TestoDefault" style="width: 100px;">Sesso</div>
            <div class="BInputControl BNextControlGoDown " style="width: calc(100% - 220px);">
              <bwc:bcombo id="mbcSessoRicerca" runat="server"
                nometabella="" campokey="" campodescr="" campiordinati=""
                invio="True" cssclass="BFloatLeft BTesto10 TestoDefault BWidth100">
                <asp:ListItem Value="-1">TUTTI</asp:ListItem>
                <asp:ListItem Value="1">MASCHIO</asp:ListItem>
                <asp:ListItem Value="0">FEMMINA</asp:ListItem>
              </bwc:bcombo>
            </div>
          </asp:Panel>
          <%--GESTIONE CONTROLLO COMMAND BAR SEARCH--%>
          <div class="BFloatLeft BWidth100 BMarginTop20 Page_Ricerca_CommandBar" style="height: 40px;">
            <bwc:bbutton id="BtnCerca" runat="server" text="Cerca" tooltip="Ricerca" cssclass="Page_Ricerca_ButtonSearch BIconLente BBtnLeft" />
          </div>

        </content>
      </bwc:bcollapsiblepanel>
    </asp:Panel>
    <%-- PANNELLO ELENCO --%>
    <asp:Panel ID="PnlElenco" runat="server" CssClass="Page_Elenco">
      <bwc:bgridview id="DtgElenco" runat="server" autogeneratecolumns="False" showfooter="False" showheaderwhenempty="True" cssclass="BDtg BWidth100" allowpaging="True">
        <columns>
          <asp:TemplateField ShowHeader="False">
            <footertemplate>
              <bwc:bbutton id="BtnNew" tooltip="Aggiungi un nuovo elemento" runat="server" causesvalidation="false" commandname="BNew" cssclass="BFloatLeft BIconNuovo BBtnTrasparente" text="" width="24px" height="24px" style="margin-left: 4px !important;" />
            </footertemplate>
            <headertemplate>
              <bwc:bbutton id="BtnNew" tooltip="Aggiungi un nuovo elemento" runat="server" causesvalidation="false" commandname="BNew" cssclass="BFloatLeft BIconNuovo BBtnTrasparente" text="" width="24px" height="24px" style="margin-left: 4px !important;" />
            </headertemplate>
            <itemtemplate>
              <bwc:bbutton id="BtnEdit" tooltip="Modifica l'elemento selezionato" runat="server" causesvalidation="false" commandname="BEdit" cssclass="BFloatLeft BIconModifica BBtnTrasparente" text="" commandargument="<%#Container.DisplayIndex%>" width="24px" height="24px" style="margin-left: 4px !important;" />
            </itemtemplate>
            <headerstyle width="32px" cssclass="BDtgHeaderCommand" />
            <itemstyle width="32px" horizontalalign="Center" verticalalign="Middle" cssclass="BDtgCommand" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <itemtemplate>
              <bwc:bbutton id="BtnDel" tooltip="Elimina elemento selezionato" runat="server" causesvalidation="false" commandname="BDelete" cssclass="BFloatLeft BIconElimina BBtnTrasparente" text="" commandargument="<%#Container.DisplayIndex%>" onclientclick="javascript:return confirm('Sei sicuro di voler eliminare?');" width="24px" height="24px" style="margin-left: 4px !important;" />
            </itemtemplate>
            <headerstyle width="32px" cssclass="BDtgHeader" />
            <itemstyle width="32px" horizontalalign="Center" verticalalign="Middle" cssclass="BDtgEndCommand" />
          </asp:TemplateField>
          <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="CodiceFiscale" HeaderText="Codice Fiscale" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="200px" />
          </asp:BoundField>
          <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle />
          </asp:BoundField>
          <asp:BoundField DataField="Cognome" HeaderText="Cognome" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle />
          </asp:BoundField>
          <asp:BoundField DataField="DataNascita" HeaderText="Data Nascita" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="100px" horizontalalign="Center" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Sesso" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="80px" horizontalalign="Center" />
            <itemtemplate>
              <asp:Label runat="server" ID="lblSesso" Text='<%# BHTML.FormattaBool((bool)Eval("Sesso"), "MASCHIO", "FEMMINA") %>'></asp:Label>
            </itemtemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="Telefono" HeaderText="Telefono" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="200px" />
          </asp:BoundField>
          <asp:BoundField DataField="Celluare" HeaderText="Celluare" HeaderStyle-CssClass="BDtgHeader">
            <itemstyle width="200px" />
          </asp:BoundField>

        </columns>
        <headerstyle cssclass="BDtgRowHeader" />
        <footerstyle cssclass="BDtgRowFooter" />
        <pagersettings visible="False" />
        <rowstyle cssclass="BDtgRow BRowClick" />
        <alternatingrowstyle cssclass="BDtgAlternatingRow BRowClick" />
      </bwc:bgridview>
      <bwc:bpager id="BDtgPager" runat="server" cssclass="BPager"></bwc:bpager>
    </asp:Panel>
    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio">
      <ccb:bctlsyspersone runat="server" id="BCtlsysPersone" visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
