<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlElencoProfili.ascx.cs" Inherits="PosteWebTemplate1.BCtlElencoProfili" %>
<div id="pnlElencoProfili" runat="server" class="BWidth100-20 BMargin10">
  <div runat="server" id="pnlProfili" class="BFloatLeft BWidth100 BNextControlGoDown">
    <asp:Label ID="lblTitle" runat="server" CssClass="BTesto14 TestoDefault lblElencoProfili" Text="Elenco profili" Width="100%"></asp:Label>
    <br />
    <br />
    <asp:RadioButtonList ID="rblSceltaProfilo" runat="server" AutoPostBack="True" CssClass="BTesto16 TestoDefault BSistemi" Style="cursor: pointer;"></asp:RadioButtonList>
  </div>
</div>
