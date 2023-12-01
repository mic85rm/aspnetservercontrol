<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysSelectProfilo.aspx.cs" Inherits="PosteWebTemplate1.sysSelectProfilo" %>

<%@ Register Src="~/BSystem/Controls/BCtlSidebar.ascx" TagPrefix="uc1" TagName="BCtlSidebar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase ">

    <%--RIMUOVERE HideForDesign PRIMA DELL'ESECUZIONE--%>
    <asp:Panel ID="PnlSelectProfilo" runat="server" CssClass="BFloatLeft BWidth100-40 BMargin20 BSelectProfiloContainer">
      <uc1:BCtlSidebar runat="server" ID="BCtlSidebarInternal" />

      <div class="BFloatLeft BWidth100" style="height: 50px;"></div>
      <div class="BFloatLeft BWidth100-40" style="height: 50px;">
        <BWC:BButton ID="BtnSelectProfilo" runat="server" Style="height: 50px; width: 250px;" Text="Accedi al sistema" CssClass="BFloatRight BBtnLeft BTesto14 BBtnSuccess BIconSeleziona32 " />
      </div>
    </asp:Panel>
  </asp:Panel>
</asp:Content>
