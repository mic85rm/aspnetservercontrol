<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCtlElencoApplicazioni.ascx.cs" Inherits="PosteWebTemplate1.BCtlElencoApplicazioni" %>
<div id="pnlElencoApplicazioni" runat="server" class="BWidth100-20 BMargin10">
    <div runat="server" id="pnlApplicazioni" class="BFloatLeft BWidth100 BNextControlGoDown">
        <asp:Label ID="lblTitle" runat="server" CssClass="lblElencoProfili" Style="font-size: 12px; font-weight: bold" Text="Le mie applicazioni" Width="100%"></asp:Label>
        <asp:DataList ID="dtlSceltaApplicazione" runat="server" RepeatDirection="Vertical" >
            <ItemTemplate>
                <asp:LinkButton ID="LinkApplicazione" runat="server" OnClick="LinkApplicazione_Click"
                    Style="cursor: pointer; font-size: 13px; color: black; text-align: left; margin-top: 5px;" 
                    Text=<%# DataBinder.Eval(Container.DataItem, "DescrizioneApplicazione") %> 
                    CommandArgument=<%# DataBinder.Eval(Container.DataItem, "IDApplicazioneIDJobRole") %>>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
