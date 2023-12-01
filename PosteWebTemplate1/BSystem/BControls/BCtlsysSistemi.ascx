<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysSistemi.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysSistemi" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Descrizione --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Descrizione</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="" INVIO="true" CssClass="BWidth100 BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="false"></BWC:BTesto>
  </div>
  <%-- CONTROLLO DataInizio --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data Inizio</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataInizio" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BTestoHelpButton" DataType="DATA" TextFormat="NESSUNO" HelpButton="true" MaxLength="10"></BWC:BTesto>
    <AJX:CalendarExtender ID="Internal_mbtDataInizio_CalendarExtender" runat="server" Enabled="true" TargetControlID="Internal_mbtDataInizio" CssClass="calExtender"></AJX:CalendarExtender>
  </div>
  <%-- CONTROLLO DataFine --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data Fine</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataFine" runat="server" Style="width: 100px;" INVIO="true" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BTestoHelpButton" DataType="DATA" TextFormat="NESSUNO" HelpButton="true" MaxLength="10"></BWC:BTesto>
    <AJX:CalendarExtender ID="Internal_mbtDataFine_CalendarExtender" runat="server" Enabled="true" TargetControlID="Internal_mbtDataFine" CssClass="calExtender"></AJX:CalendarExtender>
  </div>
  <%-- CONTROLLO Attivo --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Attivo</label>
  <BWC:BCheck ID="Internal_chkAttivo" runat="server" CssClass="BInputControl BCheck" Style="width: calc(100% - 280px);" INVIO="true" />
  <%--TBL RELATION --%>
  <div class="BFloatLeft BMargin10 BNextControlGoDown" style="width: calc(100% - 40px);">

    <BWC:BGridViewPanel ID="PnlDtgsysSistemiAttributi" runat="server" Style="height: 300px !important;" ScrollBars="Auto" CssClass="BWidth100">
      <BWC:BGridView ID="dtgsysSistemiAttributi" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeaderWhenEmpty="true" CssClass="BDtg BWidth100" AllowPaging="false">
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
          <asp:BoundField DataField="IDSysSistema" HeaderText="IDSysSistema">
            <ItemStyle Width="100px" CssClass="BDisplayNone" />
            <HeaderStyle CssClass="BDisplayNone" />
            <FooterStyle CssClass="BDisplayNone" />
            <ControlStyle CssClass="BDisplayNone" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Chiave" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtChiave" runat="server" Style="height: 36px;" INVIO="true" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="ALFANUMERICO" TextFormat="NESSUNO" Absolute="true" HelpButton="false" MaxLength="250"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblChiave" runat="server" Text='<%# Eval("Chiave")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="200px" />
            <ItemStyle Width="200px" HorizontalAlign="LEFT" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Valore" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtValore" runat="server" Style="height: 36px;" INVIO="true" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="ALFANUMERICO" TextFormat="NESSUNO" Absolute="true" HelpButton="false" MaxLength="250"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblValore" runat="server" Text='<%# Eval("Valore")%>'></asp:Label>
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
