<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysPassePartout.aspx.cs" Inherits="PosteWebTemplate1.sysPassePartout" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">
    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer BMarginTop20 ">

      <%-- CONTROLLO Password --%>
      <label class="BLabelControl BNextControlGoDown BTesto10 TestoDefault BPaddingBottom8 " style="width: 200px;">Password</label>
      <div class="BInputControl BNextControlGoDown BPaddingBottom8" style="width: calc(100% - 280px); margin: 0px !important">
        <BWC:BTesto ID="mbtPassword" runat="server" INVIO="True" CssClass="BInputControl BWidth100 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="20"></BWC:BTesto>
      </div>

    </asp:Panel>
  </asp:Panel>
</asp:Content>
