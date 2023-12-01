<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="BCtlsysWiki.ascx.cs" Inherits="PosteWebTemplate1.BCtlsysWiki" %>

<asp:Panel ID="BCssLink" runat="server" Visible="false">
  <link href="../Css/Master.css" rel="stylesheet" />
  <link href="../Css/MasterBackgroundColor.css" rel="stylesheet" />
  <link href="../Css/MasterBase.css" rel="stylesheet" />
  <link href="../Css/MasterBorder.css" rel="stylesheet" />
  <link href="../Css/MasterButtons.css" rel="stylesheet" />
  <link href="../Css/MasterColors.css" rel="stylesheet" />
  <link href="../Css/MasterCommandBar.css" rel="stylesheet" />
  <link href="../Css/MasterFonts.css" rel="stylesheet" />
  <link href="../Css/MasterFontsSmartphone.css" rel="stylesheet" />
  <link href="../Css/MasterFontsTablet.css" rel="stylesheet" />
  <link href="../Css/MasterHeight.css" rel="stylesheet" />
  <link href="../Css/MasterMargin.css" rel="stylesheet" />
  <link href="../Css/MasterPadding.css" rel="stylesheet" />
  <link href="../Css/MasterPanels.css" rel="stylesheet" />
  <link href="../Css/MasterResponsive.css" rel="stylesheet" />
  <link href="../Css/MasterResponsiveSmartphone.css" rel="stylesheet" />
  <link href="../Css/MasterResponsiveTablet.css" rel="stylesheet" />
  <link href="../Css/MasterRound.css" rel="stylesheet" />
  <link href="../Css/MasterTable.css" rel="stylesheet" />
  <link href="../Css/MasterWidth.css" rel="stylesheet" />


  <link href="../../BThemes/tmBApp/00_Base.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/00_Pannelli.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_Advertaising_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_BPagePreviewReport.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_SmartPhone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_Spinner.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_MasterPage_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_PageTableBase.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/01_WebControlSearchBase.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-Sidebar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-Sidebar_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/02_Header-Footer-SideBar_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_BCtlCalendario.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Clock.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_CommandBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Copyright.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_HeaderBar.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Notify_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_Segnalazioni.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/03_UtenteEntrato_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/04_Extender.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_LogIn.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/05_Registrazione.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/06_Images32.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BAutoComplete.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCheck.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCollapsiblePanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BCombo.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridView_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BGridViewPanel.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BImage.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMenu_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BMsgBox_Tablet.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BNotify.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPager_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BPropertyGrid.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BRadio.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BSwitch.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BTesto_Smartphone.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BToast.css" rel="stylesheet" />
  <link href="../../BThemes/tmBApp/BArtsFramework_BUploader.css" rel="stylesheet" />
</asp:Panel>
<asp:Panel ID="PnlDettaglio" runat="server" CssClass="BPageBaseContainer Page_Dettaglio">

  <%-- CONTROLLO ID --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">ID</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BTesto ID="Internal_mbtID" runat="server" Style="width: 100px;"
      INVIO="True" CssClass="BInputControl  BTesto10 TestoDefault" CssHelpButton="" DataType="NUMERICO" TextFormat="NESSUNO" HelpButton="FALSE"></BWC:BTesto>
  </div>
  <%-- CONTROLLO IDPadre --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Articolo Padre</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BCombo ID="Internal_mbcIDPadre" runat="server"
      NomeTabella="sysWiki" CampoKey="ID" CampoDescr="Titolo" CampiOrdinati="Titolo"
      Style="width: 400px;" INVIO="True" CssClass="BInputControl BTesto10 TestoDefault">
    </BWC:BCombo>
  </div>
  <%-- CONTROLLO Titolo --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Titolo</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BTesto ID="Internal_mbtTitolo" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-10 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="250"></BWC:BTesto>
  </div>
  <%-- CONTROLLO Sottotitolo --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Sottotitolo</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BTesto ID="Internal_mbtSottotitolo" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-10 BTesto10 TestoDefault" CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="500"></BWC:BTesto>
  </div>

  <%-- CONTROLLO Pubblica --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Pubblica</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BSwitch ID="Internal_ChkPubblica" runat="server" Width="42" Height="24" CssClass="BFloatLeft BInputControl BSwitch" />
  </div>
  <%-- CONTROLLO Pubblica All--%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Pubblica per tutti i figli</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px);">
    <BWC:BSwitch ID="Internal_ChkPubblicaAll" runat="server" Width="42" Height="24" CssClass="BFloatLeft BInputControl BSwitch" />
  </div>

  <%-- TBL RELATION --%>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 80px);">
    <asp:Panel ID="PnlTabs" runat="server" Style="width: 100%; height: 335px !important;">
      <AJX:TabContainer ID="TabsRelation" runat="server" Width="100%" Height="300px" ActiveTabIndex="0" CssClass="MyTabStyle" CssTheme="None">

        <AJX:TabPanel ID="TabEditor" runat="server" HeaderText="Descrizione">
          <ContentTemplate>
            <div class="BFloatLeft BWidth100 BHeight100">
              <BWC:BTesto ID="Internal_mbtDescrizione" runat="server" Style="height: 300px;" CssClass="BFloatLeft BWidth100 BTesto10 TestoDefault" TextMode="MultiLine"></BWC:BTesto>
              <ajaxToolkit:HtmlEditorExtender ID="Internal_mbtDescrizione_HtmlEditorExtender" runat="server"
                BehaviorID="Internal_mbtDescrizione_HtmlEditorExtender" TargetControlID="Internal_mbtDescrizione" EnableSanitization="false">
              </ajaxToolkit:HtmlEditorExtender>
            </div>
          </ContentTemplate>
        </AJX:TabPanel>

        <AJX:TabPanel ID="TabWikiAllegati" runat="server" HeaderText="Allegati">
          <ContentTemplate>

            <BWC:BGridViewPanel ID="PnlDtgWikiAllegati" runat="server" Style="height: 300px !important;" ScrollBars="Auto" CssClass="BWidth100">
              <BWC:BGridView ID="DtgWikiAllegati" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeaderWhenEmpty="true" CssClass="BDtg BWidth100" AllowPaging="false">
                <Columns>
                  <asp:TemplateField ShowHeader="false">
                    <FooterTemplate>
                      <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
                    </FooterTemplate>
                    <HeaderTemplate>
                      <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
                    </HeaderTemplate>
                    <ItemTemplate>
                      <BWC:BButton ID="BtnEdit" runat="server" ToolTip="Modifica l'elemento selezionato" CausesValidation="false" CommandName="BEdit" CssClass="BFloatLeft BIconModifica BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </ItemTemplate>
                    <EditItemTemplate>
                      <BWC:BButton ID="BtnSalva" runat="server" ToolTip="Conferma le modifiche" CausesValidation="false" CommandName="BSave" CssClass="BFloatLeft BIconSalva BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </EditItemTemplate>
                    <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeaderCommand" />
                    <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                      <BWC:BButton ID="BtnDel" runat="server" ToolTip="Elimina elemento selezionato" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Style="margin-left: 4px !important;" />
                    </ItemTemplate>
                    <EditItemTemplate>
                      <BWC:BButton ID="BtnAnnulla" runat="server" ToolTip="Annulla le modifiche" CausesValidation="false" CommandName="BCancel" CssClass="BFloatLeft BIconAnnulla BBtnTrasparente" Width="32px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </EditItemTemplate>
                    <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeader" />
                    <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
                  </asp:TemplateField>

                  <%-- IDSysWiki --%>
                  <asp:BoundField DataField="IDsysWiki" HeaderText="IDWiki">
                    <ItemStyle Width="100px" CssClass="BDisplayNone" />
                    <HeaderStyle CssClass="BDisplayNone" />
                    <FooterStyle CssClass="BDisplayNone" />
                    <ControlStyle CssClass="BDisplayNone" />
                  </asp:BoundField>

                  <%-- ID Allegato --%>
                  <asp:TemplateField HeaderText="ID Allegato" HeaderStyle-CssClass="BDtgHeader">
                    <EditItemTemplate>
                      <div style="text-align: LEFT">
                        <BWC:BTesto ID="mbtIDAllegato" runat="server" INVIO="True" CssClass="BTesto10 TestoDefault BWidth100-4 " DataType="NUMERICO" TextFormat="NESSUNO" Absolute="TRUE" HelpButton="FALSE"></BWC:BTesto>
                      </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="LblIDAllegato" runat="server" Text='<%# Eval("IDAllegato")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                  </asp:TemplateField>

                  <%--  Descrizione --%>
                  <asp:TemplateField HeaderText="Descrizione" HeaderStyle-CssClass="BDtgHeader">
                    <EditItemTemplate>
                      <div style="text-align: LEFT">
                        <BWC:BTesto ID="mbtDescrizione" runat="server" INVIO="True" CssClass="BTesto10 TestoDefault BWidth100-4 " DataType="ALFANUMERICO" TextFormat="NESSUNO" Absolute="TRUE" HelpButton="FALSE"></BWC:BTesto>
                      </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="LblDescrizione" runat="server" Text='<%# Eval("Descrizione")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" HorizontalAlign="Left" />
                  </asp:TemplateField>

                  <%-- Upload Allegato --%>
                  <asp:TemplateField HeaderText="Upload Allegato" HeaderStyle-CssClass="BDtgHeader">
                    <EditItemTemplate>
                      <div style="text-align: LEFT">
                        <BWC:BUploader ID="BUpAllegato" runat="server" Height="32px" CssClass="BPanel BWidth100-10" Style="margin-left: 5px; margin-right: 5px;" AbilitaDragDrop="FALSE" MaxSize="1000000000"  />
                      </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="LblPathAllegato" runat="server" Text='<%# Eval("PathAllegato")%>' CssClass="BTesto10 TestoDefault BDisplayNone"></asp:Label>

                      <asp:HyperLink ID="LnkPathAllegato" runat="server" Target="_blank" CssClass="TestoDefault BTesto10 "></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>

                </Columns>
                <HeaderStyle CssClass="BDtgRowHeader" />
                <FooterStyle CssClass="BDtgRowFooter" />
                <PagerSettings Visible="False" />
                <RowStyle CssClass="BDtgRow BRowClick" />
                <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
              </BWC:BGridView>
            </BWC:BGridViewPanel>
          </ContentTemplate>
        </AJX:TabPanel>

        <AJX:TabPanel ID="TabWikiLinks" runat="server" HeaderText="Collegamenti">
          <ContentTemplate>

            <BWC:BGridViewPanel ID="PnlDtgWikiLinks" runat="server" Style="height: 300px !important;" ScrollBars="Auto" CssClass="BWidth100">
              <BWC:BGridView ID="DtgWikiLinks" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeaderWhenEmpty="true" CssClass="BDtg BWidth100" AllowPaging="false">
                <Columns>
                  <asp:TemplateField ShowHeader="false">
                    <FooterTemplate>
                      <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
                    </FooterTemplate>
                    <HeaderTemplate>
                      <BWC:BButton ID="BtnNew" runat="server" ToolTip="Aggiungi un nuovo elemento" CausesValidation="false" CommandName="BNew" CssClass="BFloatLeft BIconNuovo BBtnTrasparente" Width="24px" Height="24px" Style="margin-left: 4px !important;" />
                    </HeaderTemplate>
                    <ItemTemplate>
                      <BWC:BButton ID="BtnEdit" runat="server" ToolTip="Modifica l'elemento selezionato" CausesValidation="false" CommandName="BEdit" CssClass="BFloatLeft BIconModifica BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </ItemTemplate>
                    <EditItemTemplate>
                      <BWC:BButton ID="BtnSalva" runat="server" ToolTip="Conferma le modifiche" CausesValidation="false" CommandName="BSave" CssClass="BFloatLeft BIconSalva BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </EditItemTemplate>
                    <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeaderCommand" />
                    <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgCommand" />
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                      <BWC:BButton ID="BtnDel" runat="server" ToolTip="Elimina elemento selezionato" CausesValidation="false" CommandName="BDelete" CssClass="BFloatLeft BIconElimina BBtnTrasparente" Width="24px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" OnClientClick="javascript:return confirm('Sei sicuro di voler eliminare?');" Style="margin-left: 4px !important;" />
                    </ItemTemplate>
                    <EditItemTemplate>
                      <BWC:BButton ID="BtnAnnulla" runat="server" ToolTip="Annulla le modifiche" CausesValidation="false" CommandName="BCancel" CssClass="BFloatLeft BIconAnnulla BBtnTrasparente" Width="32px" Height="24px" CommandArgument="<%#Container.DataItemIndex%>" Style="margin-left: 4px !important;" />
                    </EditItemTemplate>
                    <HeaderStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgHeader" />
                    <ItemStyle Width="32px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="BDtgEndCommand" />
                  </asp:TemplateField>


                  <%-- IDSysWiki --%>
                  <asp:BoundField DataField="IDsysWiki" HeaderText="IDWiki">
                    <ItemStyle Width="100px" CssClass="BDisplayNone" />
                    <HeaderStyle CssClass="BDisplayNone" />
                    <FooterStyle CssClass="BDisplayNone" />
                    <ControlStyle CssClass="BDisplayNone" />
                  </asp:BoundField>

                  <%-- Articolo Riferimento --%>
                  <asp:TemplateField HeaderText="Articolo di Riferimento" HeaderStyle-CssClass="BDtgHeader">
                    <EditItemTemplate>
                      <div style="text-align: LEFT">
                        <BWC:BCombo ID="mbcIDWikiRef" runat="server" CampiOrdinati="Titolo" CampoDescr="Titolo" CampoKey="ID" NomeTabella="sysWiki" CssClass=" BWidth100-4 ">
                        </BWC:BCombo>
                      </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="LblIDWikiRef" runat="server" Text='<%# Eval("WikiRef.Titolo")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle />
                    <ItemStyle HorizontalAlign="LEFT" />
                  </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="BDtgRowHeader" />
                <FooterStyle CssClass="BDtgRowFooter" />
                <PagerSettings Visible="False" />
                <RowStyle CssClass="BDtgRow BRowClick" />
                <AlternatingRowStyle CssClass="BDtgAlternatingRow BRowClick" />
              </BWC:BGridView>
            </BWC:BGridViewPanel>
          </ContentTemplate>
        </AJX:TabPanel>

      </AJX:TabContainer>
    </asp:Panel>
  </div>

  <%-- CONTROLLO Tags --%>
  <div class="BLabelControl BNextControlGoDown BTesto10 TestoDefault " style="width: 200px;">Tags</div>
  <div class="BInputControl BNextControlGoDown" style="width: calc(100% - 280px); margin: 0px !important;">
    <BWC:BTesto ID="Internal_mbtTags" runat="server" Style="" INVIO="True" CssClass="BInputControl BWidth100-10 BTesto10 TestoDefault"
      CssHelpButton="" DataType="ALFANUMERICO" TextFormat="NESSUNO" HelpButton="FALSE" MaxLength="250"></BWC:BTesto>
  </div>

</asp:Panel>
