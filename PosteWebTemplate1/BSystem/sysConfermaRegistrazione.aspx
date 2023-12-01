<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysConfermaRegistrazione.aspx.cs" Inherits="PosteWebTemplate1.sysConfermaRegistrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server">

    <asp:Panel ID="PnlShowMessage" runat="server" CssClass="BPanelRadius BWidth50" Style="margin-left: 20px; margin-right: 20px; margin-top: 50px;">
      <div class="BPanelTitle BMarginBottom20">Registrazione</div>
      <div class="BPanelContent">
        <asp:Label ID="lblShowMessage" runat="server" Text="" CssClass="TestoDefault BTesto12" />
      </div>
      <div class="BPanelFooter BMarginTop20">
        <BWC:BButton ID="BtnBackHome" runat="server" Text="Torna alla Home" CssClass="BottoneAnnulla BottoneLeft BFloatRight BBtnSuccess BMarginTop3 BMarginRight3" CausesValidation="False" />
      </div>

    </asp:Panel>

  </asp:Panel>

</asp:Content>
