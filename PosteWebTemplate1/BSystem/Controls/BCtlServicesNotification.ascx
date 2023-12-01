<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlServicesNotification.ascx.cs" Inherits="PosteWebTemplate1.BCtlServicesNotification" %>

<BWC:BNotify ID="BNotifica" runat="server" CssButton="BBtnTrasparente BIconCampana32 BBtnBar" style="margin-top:12px"></BWC:BNotify>

<asp:Panel ID="PnlNotifications" runat="server" class="BCtlServiceNotification_Container" Visible="false">
  <div class="BCtlServiceNotification_Header">
    <asp:Label ID="lblNumNotifiche" runat="server" CssClass="BCtlServiceNotification_LblCount"></asp:Label>
    <asp:LinkButton ID="lnkChiudi" runat="server" Text="x" ToolTip="Nascondi" CssClass="BCtlServiceNotification_BtnChiudi"></asp:LinkButton>
    <asp:LinkButton ID="lnkEliminaAll" runat="server" ToolTip="Elimina tutte le notifiche" CssClass="BFloatRight BMarginTop4 BBtnTrasparente BIconElimina"
      Width="24px" Height="24px"></asp:LinkButton>
    <asp:LinkButton ID="lnkIgnoraTutto" runat="server" Text="Leggi tutto" ToolTip="Segna tutte le notifiche come lette" CssClass="BCtlServiceNotification_LnkClearAll"></asp:LinkButton>
  </div>
  <asp:Repeater ID="rptNotifiche" runat="server">
    <ItemTemplate>
      <div class='<%# "BCtlServiceNotification_NotificaContainer" + Eval("CssLetta") %>'>
        <div class='<%# "BCtlServiceNotification_NotificaHead" + Eval("CssLetta") %>'>
          <span class='<%# "BCtlServiceNotification_Data" + Eval("CssLetta") %>'><%# String.Format(Eval("DataNotifica").ToString(), "ddd dd MMM yyyy HH:mm") %></span>
          <asp:LinkButton ID="lnkElimina" runat="server" ToolTip="Elimina notifica" CssClass="BFloatRight BPadding8 BBtnTrasparente BPaddingTop5 BIconElimina"
            Width="16px" Height="16px" CommandName="BDeleteNotifica" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
        </div>
        <div class='<%# "BCtlServiceNotification_NotificaHead" + Eval("CssLetta") %>'>
          <asp:LinkButton ID="LnkTitolo" runat="server" Text='<%# Eval("Titolo") %>' ToolTip="Leggi notifica"
            CssClass='<%# "BCtlServiceNotification_Data" + Eval("CssLetta") %>' CommandName="BReadNotifica" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
        </div>
        <div class='<%# "BCtlServiceNotification_NotificaContent" + Eval("CssLetta") %>'>
          <span class="BCtlServiceNotification_Descrizione"><%# Eval("Descrizione") %></span>
        </div>
      </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <div class='<%# "BCtlServiceNotification_NotificaContainer_Alternate" + Eval("CssLetta") %>'>
        <div class="BCtlServiceNotification_NotificaHead">
          <span class='<%# "BCtlServiceNotification_Data" + Eval("CssLetta") %>'><%# String.Format(Eval("DataNotifica").ToString(), "ddd dd MMM yyyy HH:mm") %></span>
          <asp:LinkButton ID="lnkElimina" runat="server" ToolTip="Elimina notifica" CssClass="BFloatRight BPadding8 BBtnTrasparente BPaddingTop5 BIconElimina"
            Width="16px" Height="16px" CommandName="BDeleteNotifica" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
        </div>
        <div class="BCtlServiceNotification_NotificaHead">
          <asp:LinkButton ID="LnkTitolo" runat="server" Text='<%# Eval("Titolo") %>' ToolTip="Leggi notifica"
            CssClass='<%# "BCtlServiceNotification_Data" + Eval("CssLetta") %>' CommandName="BReadNotifica" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
        </div>
        <div class='<%# "BCtlServiceNotification_NotificaContent" + Eval("CssLetta") %>'>
          <span class="BCtlServiceNotification_Descrizione"><%# Eval("Descrizione") %></span>
        </div>
      </div>
    </AlternatingItemTemplate>
  </asp:Repeater>
  <asp:Panel ID="PnlEmpty" runat="server" CssClass="BWidth100 BHeight100" Visible="false">
    <span class="BCtlServiceNotification_LabelEmpty">Nessuna Notifica Disponibile</span>
  </asp:Panel>
</asp:Panel>


<BWC:BModalPopup runat="server" ID="BPnlNotifica"
  CssBtnClose="BDisplayNone"
  TextAnnulla="Chiudi"
  TextConferma="Salva"
  Width="80%"
  Height="80%"
  CssPnlContainer="BPanelRadius"
  CssPnlContent="BPanelContent"
  CssPnlFooter="BPanelFooter"
  CssPnlHeader="BPanelTitle"
  CssBtnAnnulla="BFloatRight BBtnCancel"
  CssBtnConferma="BDisplayNone">
  <Content>
    <asp:Label ID="lblNotificaTitolo" runat="server" Text="" CssClass="BH1"></asp:Label>
    <br />
    <asp:Label ID="LblNotificaData" runat="server" Text="" CssClass="BH3 BMarginLeft3 BTesto9 BTestoAzzurro"></asp:Label>
    <br />
    <div class="BWidth100-5 BMarginLeft3 BMarginTop10">
      <asp:Label ID="lblNotificaDescrizione" runat="server" Text=""></asp:Label>

    </div>
  </Content>
</BWC:BModalPopup>
