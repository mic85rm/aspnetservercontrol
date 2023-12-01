<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="HomeConsoleDeveloper.aspx.cs" Inherits="PosteWebTemplate1.HomeConsoleDeveloper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">

  <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPanelContainerBase BMarginLeft20 BMarginTop20">

    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Doppio   BIconInitDB         BBtnCenter" Text="Inizializzazione DB" ID="btnGoInitDB" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconPolicyPwd      BBtnCenter" Text="Passpartout" ID="BtnGoPasspartout" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Doppio   BIconWebConfig      BBtnCenter" Text="Browser Detection" ID="btnGoBrowserDetection" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconInfo           BBtnCenter" Text="Test" ID="BtnTest" />
    <div class="BRow"></div>
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconProfili        BBtnCenter" Text="Sistemi" ID="BtnGoSistemi" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconRuoli          BBtnCenter" Text="Ruoli" ID="btnGoRuoli" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconModulo         BBtnCenter" Text="Moduli" ID="btnGoModuli" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconFunzioni       BBtnCenter" Text="Funzioni" ID="btnGoFunzioni" />
    <div class="BRow"></div>
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconProfili        BBtnCenter" Text="Gestione Profili" ID="btnGoProfili" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconGestioneUtenti BBtnCenter" Text="Gestione Utenti" ID="btnGoGestioneUtenti" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconPolicyPwd      BBtnCenter" Text="Policy Password" ID="btnGoPolicyPWD" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconLente          BBtnCenter" Text="Accessi" ID="btnGoAccessi" />
    <div class="BRow"></div>
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconSeverity       BBtnCenter" Text="Severity" ID="btnGoSeverity" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconMonitorLog     BBtnCenter" Text="Monitor Log" ID="btnGoLog" />
    <div class="BRow"></div>
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Singolo  BIconWebConfig      BBtnCenter" Text="Web Config" ID="BtnGoWebConfig" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Doppio   BIconConfigMail     BBtnCenter" Text="Config. Mail" ID="BtnGoConfigMail" />
    <BWC:BButton Style="padding-top: 58px;" runat="server" CssClass="BBtnMenu_Default  BBtnMenu_Doppio   BIconWebConfig      BBtnCenter" Text="Reporting Service Config" ID="BtnGoConfigReport" />

  </asp:Panel>
</asp:Content>
