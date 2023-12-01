<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlCalendario.ascx.cs" Inherits="PosteWebTemplate1.BCtlCalendario" %>

<%-- DATA & CALENDARIO SU SIDEBAR --%>
<div class="BFloatLeft BMarginLeft20 BWidth100-20">

  <asp:LinkButton runat="server" CssClass="BTesto12" ID="lnkDate" OnClientClick=""></asp:LinkButton>

  <asp:UpdatePanel runat="server" ID="UPID">
    <ContentTemplate>
      <asp:Panel runat="server" CssClass="" Style="display: none" ID="pnlTendinaCalendario">
        <asp:Calendar CssClass="BCalendar" ID="calendar" runat="server">
          <TodayDayStyle BorderColor="#00a1fd" BorderStyle="Solid" />
        </asp:Calendar>
      </asp:Panel>
    </ContentTemplate>
  </asp:UpdatePanel>

</div>

