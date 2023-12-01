<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlsysAccessi.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysAccessi" %>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
  <%-- CONTROLLO ID --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>
  <%-- CONTROLLO DataAccesso --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Data Accesso</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtDataAccesso" runat="server" Style="width: 200px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BHelpButton" DataType="Alfanumerico" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
  </div>
  <%-- CONTROLLO NomeComputer --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Nome Computer</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtNomeComputer" runat="server" Style="" INVIO="True" CssClass=" BFloatLeft BWidth100 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="100"></BWC:BTesto>
  </div>
  <%-- CONTROLLO OraFineLavoro --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Ora Fine Lavoro</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtOraFineLavoro" runat="server" Style="width: 200px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="BHelpButton" DataType="Alfanumerico" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDPadre --%>
  <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Accesso Padre</label>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BTesto ID="Internal_mbtIDPadre" runat="server" Style="width: 100px;" INVIO="True" CssClass=" BFloatLeft BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>

  <%--TBL RELATION --%>
  <div class="BFloatLeft BMargin10 BNextControlGoDown" style="width: calc(100% - 40px);">

    <BWC:BGridViewPanel ID="PnlDtgsysAccessiOperazioni" runat="server" CssClass="BWidth100">
      <BWC:BGridView ID="DtgsysAccessiOperazioni" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True" CssClass="BDtg BWidth100" AllowPaging="False" AllowRowClick="false">
        <Columns>
          <asp:TemplateField ShowHeader="False">
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
            <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass=" BDisplayNone" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand BDisplayNone" />
          </asp:TemplateField>
          <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
              <BWC:BButton ID="BtnDel" runat="server" ToolTip="Elimina elemento selezionato" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Style="margin-left: 4px !important;" />
            </ItemTemplate>
            <EditItemTemplate>
              <BWC:BButton ID="BtnAnnulla" runat="server" ToolTip="Annulla le modifiche" CausesValidation="false" CommandName="BCancel" CssClass="BFloatLeft BIconAnnulla BBtnTrasparente" Width="32px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
            </EditItemTemplate>
            <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeader BDisplayNone" />
            <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand BDisplayNone" />
          </asp:TemplateField>
          <asp:BoundField DataField="IDSysAccesso" HeaderText="IDSysAccesso">
            <ItemStyle Width="100px" CssClass="BDisplayNone" />
            <HeaderStyle CssClass="BDisplayNone" />
            <FooterStyle CssClass="BDisplayNone" />
            <ControlStyle CssClass="BDisplayNone" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtID" runat="server" Style="height: 36px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="NUMERICO" TextFormat="NESSUNO" Absolute="TRUE" HelpButton="FALSE"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="LEFT" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Funzione" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BCombo ID="mbcIDSysFunzione" runat="server" CampiOrdinati="Descrizione" CampoDescr="Descrizione" CampoKey="ID" NomeTabella="sysFunzioni" Style="" CssClass=" BWidth100 ">
                </BWC:BCombo>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblIDSysFunzione" runat="server" Text='<%# Eval("SysFunzione.Descrizione")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle />
            <ItemStyle HorizontalAlign="LEFT" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Data" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: CENTER">
                <BWC:BTesto ID="mbtData" runat="server" Style="height: 36px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault" DataType="DATA" TextFormat="NESSUNO" Absolute="TRUE" HelpButton="FALSE" MaxLength="10"></BWC:BTesto>
                <AJX:CalendarExtender ID="mbtData_CalendarExtender" runat="server" Enabled="True" TargetControlID="mbtData" CssClass="calExtender"></AJX:CalendarExtender>

              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblData" runat="server" Text='<%# Eval("Data")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle Width="200px" />
            <ItemStyle Width="200px" HorizontalAlign="CENTER" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Operazione" HeaderStyle-CssClass="BDtgHeader">
            <EditItemTemplate>
              <div style="text-align: LEFT">
                <BWC:BTesto ID="mbtOperazione" runat="server" Style="height: 36px;" INVIO="True" CssClass="BFloatLeft BTesto10 TestoDefault BWidth100 " DataType="ALFANUMERICO" TextFormat="NESSUNO" Absolute="TRUE" HelpButton="FALSE"></BWC:BTesto>
              </div>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Label ID="LblOperazione" runat="server" Text='<%# Eval("Operazione")%>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle />
            <ItemStyle HorizontalAlign="LEFT" />
          </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="BDtgRowHeader" />
        <FooterStyle CssClass="BDtgRowFooter" />
        <PagerSettings Visible="False" />
        <RowStyle CssClass="BDtgRow BRowClick" />
        <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
      </BWC:BGridView>
    </BWC:BGridViewPanel>
  </div>
</asp:Panel>
