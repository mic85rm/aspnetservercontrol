<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PosteWebTemplate1.Home" %>

<%@ Register Assembly="MTConfirmControl" Namespace="MTConfirm" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">

  <div class="BLogin_ApplicationContainer">
    <div class="BBoxApplication">
      <asp:Label ID="lblTitoloApplicazione" runat="server" Text="Label" CssClass="BTesto14 TestoBold BH1"></asp:Label>
      <br />
      <asp:Label ID="lblDescrizione" runat="server" Text="Label" CssClass="BTesto9 BTestoItalic BH2"></asp:Label>
      <br />
      <br />
      <asp:Label ID="lblVersione" runat="server" Text="Label" CssClass="BTesto9 TestoItalic TestoSottotitolo"></asp:Label>
    </div>
  </div>
  
   <cc1:MTConfirm ID="mtMichele" runat="server" ></cc1:MTConfirm>
</asp:Content>


