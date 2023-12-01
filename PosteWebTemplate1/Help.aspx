<%@ Page Title="" Language="C#" AutoEventWireup="false" MasterPageFile="~/Web.Master" CodeBehind="Help.aspx.cs" Inherits="PosteWebTemplate1.Help" %>

<%@ Register Src="~/BSystem/Controls/CtlItemWiki.ascx" TagPrefix="uc1" TagName="CtlItemWiki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <style>
    .BSideBar_Nav {
      min-width: 300px;
      max-width: 300px;
      color: #fff;
      overflow: auto;
      background-color: #eedc00;
      padding-bottom: 30px;
      min-height: calc(100vh - 70px) !important;
      display: block;
    }

    .BSideBar_Wrapper {
      width: 100%;
      min-height: calc(100vh - 70px) !important;
      display: flex;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CtnSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctnMain" runat="server">

  
  <div class="BSideBar_Wrapper BFloatLeft ">
    <div id="Panel1" class="BSideBar_Nav BFloatLeft" style="overflow: hidden">
      <div style="margin-top: 30px; margin-left: 15px;" class="BWidth100-30 BFloatLeft">
        <BWC:BTesto runat="server" ID="txtCerca"
          placeholder="Cerca..."
          CssClass="BWidth100" Style="height: 32px; border-radius: 5px; margin-bottom: 10px;" INVIO="false" 
          AutoCompleteCampoID="ID" AutoCompleteCampoDescrizione="Descrizione"
          Autocomplete="true" AutoCompleteMinLength="2" 
          AutoCompleteWebApiUrl="http://localhost/webempty/webapi/BsysWikiController.cs/autocomplete/"></BWC:BTesto>
<%--        <AJX:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
          DelimiterCharacters="" Enabled="True" TargetControlID="txtCerca" ServicePath="~/WebService/WSAutoComplete.asmx"
          ServiceMethod="GetSysWiki" MinimumPrefixLength="1" CompletionInterval="1000" EnableCaching="true"
          CompletionSetCount="20" CompletionListCssClass="List" CompletionListItemCssClass="ListItem"
          CompletionListHighlightedItemCssClass="SelectedItem" ShowOnlyCurrentWordInCompletionListItem="true">
        </AJX:AutoCompleteExtender>--%>
      </div>
      <div class="BFloatLeft BWidth100 BHeight100-50 Pannello1px" style="min-height: 400px;">
        <div style="overflow: auto; margin-top: 20px; height: 521px;" class="BWidth100-25 BHeight100 BFloatLeft">
          <BWC:BTreeView ID="tvwWiki" runat="server" ExpandDepth="0" CssClass="BTestoDefault BTesto10" LeafNodeStyle-CssClass="BTestoDefault BTesto10"
            CollapseImageUrl="~/BSystem/Image/Collapse.png"
            SelectedNodeStyle-CssClass="BTestoBold BTesto12 BTestoUnderline BTestoDefault"
            ExpandImageUrl="~/BSystem/Image/Expand.png" DynamicLoading="false">
            <LevelStyles>
              <asp:TreeNodeStyle Font-Underline="False" Height="24px" Width="204px" CssClass="BTestoDefault BTesto10" />
            </LevelStyles>
          </BWC:BTreeView>
        </div>
        <%--      <div class="BFloatLeft BHeight100" style="width: 25px; background-color: #707070; min-height: 400px;">
        <asp:Button ID="btnNodoSuperiore" runat="server" CssClass="BIconFrecciaSu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" />
        <div class="BHeight100-25 BFloatLeft" style="min-height: 521px;"></div>
        <asp:Button ID="btnNodoInferiore" runat="server" CssClass="BIconFrecciaGiu BBtnTrasparente BFloatLeft" Height="24px" Width="24px" />
      </div>--%>
      </div>
    </div>

    <%-- Style="width: 20%; min-width: 300px; min-height:calc(100vh - 70px) !important; background-color:#eedc00;" CssClass="BFloatLeft BHeight100-50" --%>


    <%--  calc(100vh - 70px) !important --%>




    <%-- CONTENT --%>

    <asp:Panel ID="pnlContenitoreContent" runat="server" Style="width: 60%" CssClass=" BFloatLeft BPaddingLeft20">

      <asp:Panel ID="PnlDettaglio" runat="server" Visible="false ">
        <uc1:CtlItemWiki runat="server" ID="CtlItemWikiDettaglio" />
      </asp:Panel>
      <asp:Panel ID="pnlElenco" runat="server">
        <asp:DataList ID="dtlWikies" runat="server" CssClass="BWidth100 DtlSmartPhone">
          <ItemTemplate>
            <uc1:CtlItemWiki runat="server" ID="CtlItemWiki" />
          </ItemTemplate>
        </asp:DataList>
      </asp:Panel>
    </asp:Panel>
  </div>

</asp:Content>
