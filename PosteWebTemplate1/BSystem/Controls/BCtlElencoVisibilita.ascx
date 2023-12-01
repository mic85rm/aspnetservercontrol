<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlElencoVisibilita.ascx.cs" Inherits="PosteWebTemplate1.BCtlElencoVisibilita" %>
<div id="pnlElencoVisibilita" runat="server" class="BWidth100-20 BMargin10">
  <div runat="server" id="pnlVisibilita" class="BFloatLeft BWidth100 BNextControlGoDown">
    <asp:Label ID="lblTitle" runat="server" CssClass="lblElencoProfili" Style="font-size: 12px; font-weight: bold" Text="Le mie visibilità" Width="100%"></asp:Label>
    <br />
    <asp:DataList ID="dtlSceltaVisibilita" runat="server" RepeatDirection="Vertical" 
      Style="width: 100%!important;" CssClass="SceltaVisibilitaPnl"  >
      <ItemTemplate>
        <div style="width: 100%!important;" class="SceltaVisibilitaItemPnl">
          <asp:LinkButton ID="LinkVisibilita" runat="server" OnClick="LinkVisibilita_Click"            
            CssClass='<%# DataBinder.Eval(Container.DataItem, "CssLink") %>'
            Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione") %>'
            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDVisibilitaTerritoriale") %>'>
          </asp:LinkButton>
          <BWC:BButton ID="btnPreferito" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDVisibilitaTerritoriale") %>' 
            runat="server" OnClick="btnPreferito_Click" 
            CssClass='<%# DataBinder.Eval(Container.DataItem, "CssPreferito") %>'
            ></BWC:BButton>

          <asp:HiddenField ID="hidPreferito" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Preferito") %>' />
        </div>
      </ItemTemplate>
    </asp:DataList>
  </div>
</div>
