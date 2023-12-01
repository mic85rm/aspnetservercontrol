<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCommandBar.ascx.cs" Inherits="PosteWebTemplate1.CtlCommandBar" %>

<asp:Panel ID="PnlCommandBar" runat="server" CssClass="PnlCommandBar">
  <asp:Label ID="LblNomePagina" runat="server" CssClass="BTestoBianco BTestoItalic BTesto12 LblPageName"></asp:Label>
  <div class="PnlSeparatoreDx"></div>
  <BWC:BButton ID="BtnAnnulla" ToolTip="Annulla modifiche effettuate" runat="server" CausesValidation="False" CssClass="BIconAnnulla BtnAnnulla BBtnCenter"/>
  <BWC:BButton ID="BtnSalva" ToolTip="Salva le modifiche effettuate" runat="server" CausesValidation="True" CssClass="BIconSalva BtnSalva BBtnCenter" />
  <BWC:BButton ID="BtnElimina" ToolTip="Elimina l'elemento" runat="server" CausesValidation="False" CssClass="BIconElimina BtnElimina BBtnCenter" />
  <BWC:BButton ID="BtnStampa" ToolTip="Stampa" runat="server" CausesValidation="False" CssClass="BIconStampa BtnStampa BBtnCenter" />
  <BWC:BButton ID="BtnNew" ToolTip="Aggiungi un nuovo elemento" runat="server" CausesValidation="false" CssClass="BIconNuovo BtnNuovo BBtnCenter " />
  <asp:Panel ID="PnlOtherElements" runat="server" CssClass="PnlOtherControls">
  </asp:Panel>
</asp:Panel>
