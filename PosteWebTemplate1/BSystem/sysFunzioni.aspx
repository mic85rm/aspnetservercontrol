<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="sysFunzioni.aspx.cs" Inherits="PosteWebTemplate1.sysFunzioni" %>

<%@ Register Src="~/BSystem/Controls/CtlCommandBar.ascx" TagName="CtlCommandBar" TagPrefix="CCB" %>
<%@ Register Src="~/BSystem/BControls/BCtlsysFunzione.ascx" TagPrefix="CCB" TagName="BCtlsysFunzione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentLeft" ContentPlaceHolderID="CtnSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnMain" runat="server">

  <asp:Panel ID="PnlContainer" runat="server" CssClass="BPanelContainerBase">

    <%-- PANNELLO COMANDI --%>
    <CCB:CtlCommandBar runat="server" ID="CtlCommandBar" />

    <%-- PANNELLO ELENCO TREEVIEW--%>
    <asp:Panel ID="PnlElenco" runat="server" Style="width: 280px" CssClass="BFloatLeft BMargin10">

      <div class="BFloatLeft BWidth100 BPanelRadius">
        <table class="BFloatLeft BTableNoBorder BWidth100">
          <tr>
            <td class="BTestoNero BTesto12 BPaddingLeft10">Funzioni Applicative:</td>
            <td style="width: 25px; background-color: transparent; padding: 0px;">
              <div style="background-color: #424242; height: 25px; width: 100%; border-radius: 0px 6px 0px 0px">
                <asp:Button ID="btnNodoSuperiore" runat="server" CssClass="BIconFrecciaSu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" />
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div style="overflow: auto; max-width: 300px">
                <BWC:BTreeView ID="tvwFunzioni" runat="server" ExpandDepth="0" CssClass="BTesto10" LeafNodeStyle-CssClass="BTesto10"
                  CollapseImageUrl="~/BSystem/Image/Collapse.png"
                  ExpandImageUrl="~/BSystem/Image/Expand.png">
                  <LevelStyles>
                    <asp:TreeNodeStyle Font-Underline="False" Height="24px" Width="204px" CssClass="BTesto10 " />
                  </LevelStyles>
                </BWC:BTreeView>
              </div>
            </td>
            <td style="width: 25px; background-color: #424242;">
          </tr>
          <tr>
            <td></td>
            <td style="width: 25px; background-color: transparent; padding: 0px;">
              <div style="background-color: #424242; height: 25px; width: 100%; border-radius: 0px 0px 6px 0px">
                <asp:Button ID="btnNodoInferiore" runat="server" CssClass="BIconFrecciaGiu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" />
              </div>
            </td>
          </tr>
        </table>
      </div>
      <BWC:BButton ID="BtnResetOrder" runat="server" Text="Reset Order" CausesValidation="False" Height="32px" CssClass="BIconAnnulla BBtnLeft" Style="margin: 5px;" />
    </asp:Panel>

    <%-- PANNELLO DETTAGLIO --%>
    <asp:Panel ID="PnlDettaglio" runat="server" CssClass="BFloatLeft" Style="width: calc(100% - 320px); margin: 10px; min-width: 300px; min-height: 450px;">
      <CCB:BCtlsysFunzione runat="server" ID="BCtlsysFunzione" />
    </asp:Panel>
  </asp:Panel>
</asp:Content>
