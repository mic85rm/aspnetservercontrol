<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysRecuperaPassword.aspx.cs" Inherits="PosteWebTemplate1.sysRecuperaPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <div class="BLabelControl BNextControlGoDown BWidth100-30 BMarginLeft30">
    <h1 class="BH1" style="margin-bottom: 0px!important;">Area riservata</h1>
    <h2 class="BH2">Procedura di recupero password</h2>
    <%-- CONTROLLO IDUTENTE--%>
    <div class="BWidth100-20 BMarginBottom20 BMarginTop70">
      <label id="lblIDUtente" runat="server" class="BTesto15 BFloatLeft BMarginRight10" style="width: 100px; height: 32px; line-height: 32px;">ID Utente</label>
      <BWC:BTesto ID="mbtIDUtente" runat="server" Style="width: 200px; margin-bottom: 10px;" INVIO="True" CssClass="BFloatLeft BTesto10 BMarginRight10" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="50"></BWC:BTesto>
      <BWC:BButton ID="BtnRecupera" runat="server" Text="Recupera Password" CssClass="BBtnWarning BFloatLeft BMarginTop2 BMarginLeft6" Height="32px" Width="170px" Visible="True" />
      <p style="clear: both"></p>
    </div>
    <asp:Label ID="lblMessagge" Style="clear: both" runat="server" Text="Inserire l'IDUtente e cliccare sul pulsante Recupera Password" CssClass="BTesto12 BTestoRosso"></asp:Label>
  </div>
</asp:Content>
