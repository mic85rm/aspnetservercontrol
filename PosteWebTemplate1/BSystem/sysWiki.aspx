<%@ Page Title="" Language="C#" AutoEventWireup="false" MasterPageFile="~/Web.Master" CodeBehind="sysWiki.aspx.cs" Inherits="PosteWebTemplate1.FrmWiki" %>

<%@ Register Src="~/BSystem/BControls/BCtlsysWiki.ascx" TagPrefix="uc1" TagName="BCtlsysWiki" %>
<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagPrefix="uc1" TagName="CtlCommandBar" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CtnSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <uc1:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO ELENCO --%>
    <asp:Panel ID="PnlElenco" runat="server" Style="width: 20%; margin: 10px; min-width: 300px; min-height: 400px; border: 1px solid black" CssClass="BFloatLeft BHeight100-50">

      <div class="BFloatLeft BWidth100 BHeight100-50 BPanel" style="min-height: 400px;">
        <div style="overflow: auto; height: 521px;" class="BWidth100-25 BHeight100 BFloatLeft">
          <BWC:BTreeView ID="tvwWiki" runat="server" ExpandDepth="0" CssClass="TestoDefault BTesto10" LeafNodeStyle-CssClass="TestoDefault BTesto10"
            CollapseImageUrl="~/BSystem/Image/Collapse.png"
            SelectedNodeStyle-CssClass="BTestoBold BTesto12 BTestoUnderline BTestoAzzurro"
            ExpandImageUrl="~/BSystem/Image/Expand.png" DynamicLoading="false">
            <LevelStyles>
              <asp:TreeNodeStyle Font-Underline="False" Height="24px" Width="204px" CssClass=" BTestoBianco BTesto10" />
            </LevelStyles>
          </BWC:BTreeView>
        </div>
        <div class="BFloatLeft BHeight100" style="width: 25px; background-color: #707070; min-height: 400px;">
          <asp:Button ID="btnNodoSuperiore" runat="server" CssClass="BIconFrecciaSu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" />
          <div class="BHeight100-25 BFloatLeft" style="min-height: 521px;"></div>
          <asp:Button ID="btnNodoInferiore" runat="server" CssClass="BIconFrecciaGiu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" Style="margin-top: 472px" />
        </div>
      </div>
    </asp:Panel>

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="Page_Dettaglio BFloatLeft BHeight100-95 Pannello1px" Style="width: 65%; margin: 10px; min-width: 300px; min-height: 450px;">
      <uc1:BCtlsysWiki runat="server" id="BCtlWiki" Visible="True" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
