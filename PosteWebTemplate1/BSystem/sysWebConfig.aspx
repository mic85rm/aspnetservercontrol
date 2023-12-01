<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysWebConfig.aspx.cs" Inherits="sysWebConfig" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">
      <div style="width: calc(100% - 20px);" class="BFloatLeft">
        <BWC:BPropertyGrid ID="BPropertyGrid1" runat="server" CssClass="BControlResponsive BWidth100-20" Style="margin: 10px; min-width: 300px;" />
      </div>
    </asp:Panel>
  </asp:Panel>
</asp:Content>
