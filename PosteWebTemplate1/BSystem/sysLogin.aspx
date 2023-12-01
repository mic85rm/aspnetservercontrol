<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysLogin.aspx.cs" Inherits="PosteWebTemplate1.sysLogin" %>

<%@ Register Src="~/BSystem/Controls/CtlLogin.ascx" TagPrefix="uc1" TagName="CtlLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">
  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">
    <div class="BLogin_ApplicationContainer">
      <div class="BBoxApplication">
        <asp:Label ID="lblApplicazione" runat="server" Text="Label" CssClass="BTesto14 TestoBold BH1"></asp:Label>
        <br />
        <asp:Label ID="lblTitolo" runat="server" Text="Label" CssClass="BTesto9 BTestoItalic BH2"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LblVersione" runat="server" Text="Label" CssClass="BTesto9 TestoItalic TestoSottotitolo"></asp:Label>
      </div>
    </div>
    <div class="BLogin_CtlLoginContainer">
      <uc1:CtlLogin runat="server" ID="CtlLogin" />
    </div>
    <div class="BLogin_InformationNoteContainer BShowOnlyTabletPC">
      <asp:Label ID="lblMessaggio" runat="server" Text="N.B.: Nome utente e password sono le stesse utilizzate per l'avvio di windows" CssClass="BLogin_LabelInfo"></asp:Label>
    </div>
    <%-- FOR STUDY --%>
    <div class="BWidth100 BFloatLeft">
      <div style="min-width: 300px; width: 460px; margin: auto;">
        <BWC:BButton ID="BtnLoginWithGoogle" runat="server"     width="200px" CssClass="BBtn BBtnLeft BIconGoogle" Text="Accedi con google"></BWC:BButton>
        <BWC:BButton ID="BtnLoginWithApple" runat="server"      width="200px" CssClass="BBtn BBtnLeft BIconAggiorna" Text="Accedi con Apple"></BWC:BButton>
        <BWC:BButton ID="BtnLoginWithMicrosoft" runat="server"  width="200px" CssClass="BBtn BBtnLeft BIconMicrosoft" Text="Accedi con Microsoft"></BWC:BButton>
        <BWC:BButton ID="BtnLoginWithFacebook" runat="server"   width="200px" CssClass="BBtn BBtnLeft BIconAggiorna" Visible="false" Text="Accedi con facebook"></BWC:BButton>
      </div>
    </div>

  </asp:Panel>
</asp:Content>
