<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlUtenteEntrato.ascx.cs" Inherits="PosteWebTemplate1.BCtlUtenteEntrato" %>



<%--<asp:LinkButton ID="lnkUtente2" runat="server" Text="" CssClass="User" OnClientClick="" Enabled="false" Style="text-decoration: none; display: none" />--%>
<%--<asp:LinkButton ID="LinkButton1" runat="server" Text="Benvenut{0} {1} {2}" CssClass="UtenteEntrato-LabelLogOut " OnClientClick="" />--%>

<div class="UtenteEntrato-Containers" style="margin-top: 9px!important">
  <asp:LinkButton ID="lnkUtente" style="Border:1px solid #0346BB" runat="server" Text="" CssClass="User" OnClientClick="" />
  <%-- PANNELLO TENDINA --%>
  <asp:Panel runat="server" ID="pnlTendinaUtente" CssClass="UtenteEntrato-PanelDetail" Style="display: none">
    <%-- DIV SINISTRA IMMAGINE --%>
    <%--    <div class="BFloatLeft " style="width: 35%">
      <div class="BWidth100-40 BFloatLeft">
        <asp:Image runat="server" ID="imgFotoProfilo" CssClass="BRound52px BFloatLeft BMargin5" Height="100px" Width="100px" />
      </div>
    </div>--%>
    <%-- DIV DESTRA INFORMAZIONI PERSONA --%>
    <div class="BFloatRight" style="margin-left:10px; margin-right:10px">
      <div class="">
        <asp:Label runat="server" ID="lblNominativo" CssClass="BTesto10 BFloatLeft BTestoLeft BMarginTop10 BMarginBottom10"></asp:Label>
      </div>
      <div class="">
        <asp:Label runat="server" ID="lblEmail" CssClass="BTesto10 BTestoLeft BFloatLeft BMarginTop10 BMarginBottom10"></asp:Label>
      </div>
      <div class="BWidth100 BFloatLeft" style="display: none!important">
        <asp:LinkButton ID="linkProfiloPersona" runat="server" CssClass="BTestoLeft BTesto10 BTestoNero BFloatLeft BMarginTop12" Text="VISUALIZZA PROFILO" />
      </div>
    </div>
  </asp:Panel>
  <BWC:BButton ID="BtnLogOut" runat="server" Style="margin-top: 4px!important" CssClass="UtenteEntrato-BtnLogOut BIconLogOut BBtn BBtnTrasparente BBtnCenter" Width="32px" Height="32px" Text="" />
</div>
