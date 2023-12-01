<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysComuni.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysComuni" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 80px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="4" ></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO CodiceIstat --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Codice Istat</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtCodiceIstat" runat="server" Style="width: 100px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="10"></BWC:BTesto>
  </div>
  <%-- CONTROLLO CodiceIstatAsl --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Codice Istat Asl</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtCodiceIstatAsl" runat="server" Style="width: 30px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="3"></BWC:BTesto>
  </div>
  <%-- CONTROLLO CAP --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">CAP</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtCAP" runat="server" Style="width: 100px;" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="10"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDProvincia --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Provincia</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BCombo ID="Internal_mbcIDProvincia" runat="server"
      NomeTabella="sysProvince" CampoKey="ID" CampoDescr="Descrizione" CampiOrdinati="Descrizione"
      Style="" INVIO="true" CssClass="BInputControl BFloatLeft BTesto10 TestoDefault BWidth100">
    </BWC:BCombo>
  </div>
  <%-- CONTROLLO DataIstituzione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data Istituzione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataIstituzione" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BTestoHelpButton" DataType="DATA" TextFormat="NESSUNO" HelpButton="true" MaxLength="10"></BWC:BTesto>
    <AJX:CalendarExtender ID="Internal_mbtDataIstituzione_CalendarExtender" runat="server" Enabled="true" TargetControlID="Internal_mbtDataIstituzione" CssClass="calExtender"></AJX:CalendarExtender>
  </div>
  <%-- CONTROLLO DataCessazione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data Cessazione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataCessazione" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BTestoHelpButton" DataType="DATA" TextFormat="NESSUNO" HelpButton="true" MaxLength="10"></BWC:BTesto>
    <AJX:CalendarExtender ID="Internal_mbtDataCessazione_CalendarExtender" runat="server" Enabled="true" TargetControlID="Internal_mbtDataCessazione" CssClass="calExtender"></AJX:CalendarExtender>
  </div>
  <%-- CONTROLLO Patrono --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Patrono</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtPatrono" runat="server" Style="width: 40px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false" MaxLength="4"></BWC:BTesto>
  </div>

  <%--TBL RELATION --%>
  <div class="BFloatLeft BMargin10 BNextControlGoDown" style="width: calc(100% - 40px);">

    <BWC:BGridViewPanel ID="PnlDtgsysComuniQuartieri" runat="server" Style="height: 300px !important;" ScrollBars="Auto" CssClass="BWidth100">
      <BWC:BGridView ID="dtgsysComuniQuartieri" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeaderWhenEmpty="true" CssClass="BDtg BWidth100" AllowPaging="false">
        <Columns>
          <asp:TemplateField ShowHeader="false">
            <FooterTemplate>
              <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </FooterTemplate>
            <HeaderTemplate>
              <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
            </HeaderTemplate>
            <ItemTemplate>
              <BWC:BButton ID="BtnEdit" runat="server" ToolTip="Modifica l'elemento selezionato" CausesValidation="false" CommandName="BEdit" CssClass="BFloatLeft BIconModifica BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <EditItemTemplate>
              <BWC:BButton ID="BtnSalva" runat="server" ToolTip="Conferma le modifiche" CausesValidation="false" CommandName="BSave" CssClass="BFloatLeft BIconSalva BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
            </EditItemTemplate>
            <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeaderCommand" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="false">
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" runat="server" ToolTip="Elimina elemento selezionato" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <EditItemTemplate>
              <BWC:BButton ID="BtnAnnulla" runat="server" ToolTip="Annulla le modifiche" CausesValidation="false" CommandName="BCancel" CssClass="BFloatLeft BIconAnnulla BBtnTrasparente" Width="32px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
            </EditItemTemplate>
            <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeader" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
          </asp:TemplateField>
          <asp:BoundField DataField="IDComune" HeaderText="IDComune">
            <ItemStyle Width="100px" CssClass="BDisplayNone" />
            <HeaderStyle CssClass="BDisplayNone" />
            <FooterStyle CssClass="BDisplayNone" />
            <ControlStyle CssClass="BDisplayNone" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="ID Quartiere" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtIDQuartiere" runat="server" Style="height: 36px;" INVIO="true" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="NUMERICO" TextFormat="NESSUNO" Absolute="true" HelpButton="false"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblIDQuartiere" runat="server" Text='<%# Eval("IDQuartiere")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="LEFT" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Descrizione" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtDescrizione" runat="server" Style="height: 36px;" INVIO="true" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="ALFANUMERICO" TextFormat="NESSUNO" Absolute="true" HelpButton="false"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblDescrizione" runat="server" Text='<%# Eval("Descrizione")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle />
            <ItemStyle HorizontalAlign="LEFT" />
          </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="false" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
    </BWC:BGridViewPanel>
  </div>
</asp:Panel>
