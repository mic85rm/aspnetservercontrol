<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysMessage.aspx.cs" Inherits="PosteWebTemplate1.sysMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">

  <div class="BWidth100-20 BFloatLeft BMargin10 BPanel">
    <h1 class="BFloatLeft BPadding10">
      <asp:Label ID="lblTitolo" runat="server" Text="Informazione di sistema"></asp:Label>
    </h1>
    <h2 class="BFloatLeft BPadding10">
      <asp:Label ID="lblSottotitolo" runat="server"></asp:Label>
    </h2>
    <div class="BWidth100-50 BFloatLeft BMargin10 BPadding10">
      <asp:Label ID="lblMessage" runat="server" CssClass="BTesto12"></asp:Label>
    </div>
  </div>
</asp:Content>
