<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysConfigMailDB.aspx.cs" Inherits="PosteWebTemplate1.sysConfigMailDB" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio BMarginTop20">

      <div class="BInputControl BWidth100-20 BNextControlGoDown">
        <BWC:BButton ID="BtnAttivaServerMail" runat="server" Text="Attiva Server Mail" CssClass="BFloatLeft BMarginRight5" />
        <BWC:BButton ID="BtnDisattivaServerMail" runat="server" CssClass="BFloatLeft BMarginRight5" Enabled="False" Text="Disattiva Server Mail" />
        <BWC:BButton ID="BtnCreaProfiloSQL" runat="server" Text="Crea Profilo e Account Server Mail (SQL)" CssClass="BFloatLeft " />
        <asp:Image ID="ImgStatoRosso" CssClass="ImgStatoRosso" runat="server" Style="height: 32px; width: 32px;" ImageUrl="~/BThemes/tmBApp/Image/Icon32/rosso.png" />
        <asp:Image ID="ImgStatoVerde" CssClass="ImgStatoVerde" Visible="false" runat="server" Style="height: 32px; width: 32px;" ImageUrl="~/BThemes/tmBApp/Image/Icon32/verde.png" />
      </div>

      <div class="BFloatLeft BWidth100-20 BMarginBottom20 BMarginTop20 BMarginLeft10">
        <BWC:BPropertyGrid ID="BPropertyGrid1" runat="server" CssClass="BPropertyGrid_BControl" />
      </div>

      <asp:Panel ID="PnlTestMail" runat="server" CssClass="BFloatLeft BWidth100-20 Pannello1px BMarginLeft10 BRound12px BMarginBottom20">
        <label class="BFloatLeft BWidth100 BTesto12 BMargin5 ">Oggetto</label>
        <BWC:BTesto ID="mbtOggetto" runat="server" CssClass="BFloatLeft BWidth100-10" Style="margin-left: 5px!important"></BWC:BTesto>
        <label class="BFloatLeft BWidth100 BTesto12 BMargin5 ">Testo email</label>
        <BWC:BTesto ID="mbtBody" runat="server" CssClass="BFloatLeft BWidth100-10 BMarginLeft5" Style="height: 120px;" TextMode="MultiLine"></BWC:BTesto>
        <BWC:BButton ID="BtnInviaMail" runat="server" CssClass="BFloatLeft BBtnWarning BMargin5" Text="Invia Mail" />
      </asp:Panel>

      <asp:Panel ID="PnlDtg" runat="server" CssClass="BFloatLeft BWidth100-20 BMarginLeft10 BMarginBottom30" Height="400px" ScrollBars="Auto">
        <BWC:BGridView ID="dtgElenco" runat="server" AutoGenerateColumns="False" ShowFooter="False" ShowHeaderWhenEmpty="True" CssClass="BDtg BWidth100" AllowPaging="true">
          <Columns>
            <asp:TemplateField ShowHeader="False">
              <ItemTemplate>
                <BWC:BButton ID="BtnDel" runat="server" CausesValidation="false" CommandName="BDelete" CommandArgument="<%#Container.DataItemIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" CssClass="BIconElimina BottoneTrasparente" Width="24px" Height="24px" Text="" />
              </ItemTemplate>
              <HeaderStyle Width="32px" />
              <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID">
              <ItemStyle Width="80px" CssClass="BTestoCenter" />
            </asp:BoundField>
            <asp:BoundField DataField="NomeProfilo" HeaderText="Nome Profilo">
              <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="NomeAccount" HeaderText="Nome Account">
              <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione">
              <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email">
              <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="DisplayName" HeaderText="Display Name">
              <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="ReplyTo" HeaderText="Reply To">
              <ItemStyle Width="100px" />
            </asp:BoundField>
          </Columns>
          <HeaderStyle CssClass="BDtgRowHeader" />
          <FooterStyle CssClass="BDtgRowFooter" />
          <PagerSettings Visible="False" />
          <RowStyle CssClass="BDtgRow BRowClick" />
          <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
        </BWC:BGridView>

      </asp:Panel>


    </asp:Panel>
  </asp:Panel>
</asp:Content>
