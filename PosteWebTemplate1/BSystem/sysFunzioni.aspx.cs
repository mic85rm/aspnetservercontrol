using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysFunzioni : BPageTreeViewBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL = "sysFunzioni";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";

    // DEFINIZIONE METODI OVERRIDES
    protected override void SetAttributes_Invio()
    {
      this.BCtlsysFunzione.mbtID.CtlNextFocus = this.BCtlsysFunzione.mbcIDPadre.ClientID;
      this.BCtlsysFunzione.mbcIDPadre.CtlNextFocus = this.BCtlsysFunzione.mbtDescrizione.ClientID;
      this.BCtlsysFunzione.mbtDescrizione.CtlNextFocus = this.BCtlsysFunzione.mbtComando.ClientID;
      this.BCtlsysFunzione.mbtComando.CtlNextFocus = this.BCtlsysFunzione.mbtOrdine.ClientID;
      this.BCtlsysFunzione.mbtOrdine.CtlNextFocus = this.BCtlsysFunzione.chkAuth.ClientID;
      this.BCtlsysFunzione.chkAuth.CtlNextFocus = this.BCtlsysFunzione.chkDeveloper.ClientID;
      this.BCtlsysFunzione.chkDeveloper.CtlNextFocus = this.BCtlsysFunzione.chkAttivo.ClientID;
      this.BCtlsysFunzione.chkAttivo.CtlNextFocus = this.BCtlsysFunzione.mbcIDsysModulo.ClientID;
      this.BCtlsysFunzione.mbcIDsysModulo.CtlNextFocus = this.BCtlsysFunzione.mbtToolTip.ClientID;
      this.BCtlsysFunzione.mbtToolTip.CtlNextFocus = this.BCtlsysFunzione.mbtShortCut.ClientID;
      this.BCtlsysFunzione.mbtShortCut.CtlNextFocus = this.BCtlsysFunzione.mbtIDFunzioneWP.ClientID;
      this.BCtlsysFunzione.mbtIDFunzioneWP.CtlNextFocus = this.CtlCommandBar.CtlBtnSalva.ClientID;
    }
    protected override void SetAttributes_Other()
    {
      this.BCtlsysFunzione.mbcIDsysModulo.Init(this.DB.Setting);
      if (this.BCtlsysFunzione.mbcIDsysModulo.Items.Count != 1)
      {
        this.BCtlsysFunzione.mbcIDsysModulo.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      }

      this.BCtlsysFunzione.mbcIDPadre.Init(this.DB.Setting);
      this.BCtlsysFunzione.mbcIDPadre.Items.Insert(0, new ListItem("ROOT", "-1"));
    }
    protected override void SetAttributes_AddEvents()
    {
      btnNodoInferiore.Click += btnNodoInferiore_Click;
      btnNodoSuperiore.Click += btnNodoSuperiore_Click;
      CtlCommandBar.Nuovo += CtlCommandBar_Nuovo;
      CtlCommandBar.Elimina += CtlCommandBar_Elimina;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;
      BtnResetOrder.Click += BtnResetOrder_Click;
      tvwFunzioni.SelectedNodeChanged += tvwFunzioni_SelectedNodeChanged;
      tvwFunzioni.TreeNodeExpanded += tvwFunzioni_TreeNodeExpanded;

      base.SetAttributes_AddEvents();
    }


    protected override bool InitBTablePage()
    {
      this.PageName = "sysFunzioni";
      this.CtlCommandBar.PageName = "Gestione Funzioni";
      this.CtlPnlRicerca = null;
      this.CtlPnlElenco = this.PnlElenco;
      this.CtlPnlDettaglio = this.PnlDettaglio;
      this.CtlTvwElenco = this.tvwFunzioni;
      this.CtlBtnNuovo = this.CtlCommandBar.CtlBtnNuovo;
      this.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.OnView_BtnNuovo_Visible = true;
      this.FirstCtlRicerca = this.tvwFunzioni;
      this.FirstCtlDettaglio = this.BCtlsysFunzione.mbcIDPadre;
      this.RunSearchToLoad = true;
      return true;
    }
    public override void Indietro_Click()
    {
      base.BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
      base.Indietro_Click();
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool EliminaNodo(int id)
    {
      BsysFunzioni funzione = new BsysFunzioni(id, DB);
      if (funzione != null && !funzione.IsNothing)
      {
        return funzione.Delete();
      }
      else
      {
        return false;
      }
    }
    private bool EliminaRamo(TreeNode nodoPadre)
    {
      bool ret = false;
      if (nodoPadre.ChildNodes.Count > 0)
      {
        foreach (TreeNode nodo in nodoPadre.ChildNodes)
        {
          if (nodo.ChildNodes.Count > 0)
          {
            ret = EliminaRamo(nodo);
          }

          if (ret) return EliminaNodo(BConvert.ToInt(nodo.Value));
        }
      }

      return EliminaNodo(BConvert.ToInt(nodoPadre.Value));
    }

    protected override bool CaricaTreeView(bool EscludiFiltriRicerca = false)
    {
      DataTable dt = null;
      BDataSet ds = null;
      try
      {
        dt = BsysFunzioni.GetElenco(DB);
        if (dt == null) return false;
        ds = new BDataSet();
        ds.Tables.Add(dt);
        this.tvwFunzioni.ShowCheckBoxes = TreeNodeTypes.All;
        this.tvwFunzioni.CampoID = "ID";
        this.tvwFunzioni.CampoIDPadre = "IDPadre";
        this.tvwFunzioni.CampoDescrizione = "Descrizione";
        this.tvwFunzioni.CampoOrdine = "Ordine";
        this.tvwFunzioni.CampoImage = "";
        this.tvwFunzioni.CampoToolTip = "Tooltip";
        this.tvwFunzioni.RootValueIsNull = true;
        this.tvwFunzioni.TipoDatoCampoKey = BTreeView.eTipoDatoKey.NUMERICO;
        this.tvwFunzioni.DynamicLoading = true;
        this.tvwFunzioni.ShowCheckBoxes = TreeNodeTypes.None;
        this.tvwFunzioni.ShowLines = false;
        this.tvwFunzioni.Nodes.Clear();
        return this.tvwFunzioni.InitControl(ds);
      }
      catch (Exception ex)
      {
        this.WriteLog("sysFunzioni.CaricaFunzioni()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    protected override void NuovoRec(BTreeNode n)
    {
      this.BCtlsysFunzione.mbtID.Text = BGlobal.GeneraCodice("sysFunzioni", "ID", DB).ToString();
      if (this.tvwFunzioni.SelectedNode != null)
      {
        this.BCtlsysFunzione.mbcIDPadre.SelectedValue = this.tvwFunzioni.SelectedValue;
      }
      else
      {
        this.BCtlsysFunzione.mbcIDPadre.SelectedValue = "-1";
      }

      this.BCtlsysFunzione.mbtDescrizione.Text = "";
      this.BCtlsysFunzione.mbtComando.Text = "";
      this.BCtlsysFunzione.mbtOrdine.Text = "";
      this.BCtlsysFunzione.chkAuth.Checked = true;
      this.BCtlsysFunzione.chkDeveloper.Checked = false;
      this.BCtlsysFunzione.chkAttivo.Checked = true;
      if (this.BCtlsysFunzione.mbcIDsysModulo.Items.Count == 1)
      {
        this.BCtlsysFunzione.mbcIDsysModulo.SelectedIndex = 0;
      }
      else
      {
        this.BCtlsysFunzione.mbcIDsysModulo.SelectedValue = "-1";
      }

      this.BCtlsysFunzione.mbtToolTip.Text = "";
      this.BCtlsysFunzione.mbtShortCut.Text = "";
      this.BCtlsysFunzione.imgImage.ImageUrl = "";
      this.BCtlsysFunzione.mbtIDFunzioneWP.Text = "";

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      this.BCtlsysFunzione.mbtDescrizione.Focus();
    }
    protected override bool CambiaRec(BBaseObject Obj, BTreeNode n)
    {
      BsysFunzioni MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysFunzioni)Obj;
        SetAttributes_Other();
        this.BCtlsysFunzione.mbtID.Text = MyObj.ID.ToString();
        this.BCtlsysFunzione.mbtID.Enabled = false;
        this.BCtlsysFunzione.mbcIDPadre.SelectedValue = MyObj.IDPadre.ToString();
        this.BCtlsysFunzione.mbtDescrizione.Text = MyObj.Descrizione;
        this.BCtlsysFunzione.mbtComando.Text = MyObj.Comando;
        this.BCtlsysFunzione.mbtOrdine.Text = MyObj.Ordine.ToString();
        this.BCtlsysFunzione.chkAuth.Checked = MyObj.Auth;
        this.BCtlsysFunzione.chkDeveloper.Checked = MyObj.Developer;
        this.BCtlsysFunzione.chkAttivo.Checked = MyObj.Attivo;
        this.BCtlsysFunzione.mbcIDsysModulo.SelectedValue = MyObj.IDSysModulo.ToString();
        this.BCtlsysFunzione.mbtToolTip.Text = MyObj.Tooltip;
        this.BCtlsysFunzione.mbtShortCut.Text = MyObj.ShortCut;
        this.BCtlsysFunzione.imgImage.ImageByte = MyObj.Image;
        if (MyObj.IDFunzioneWP != -1)
        {
          this.BCtlsysFunzione.mbtIDFunzioneWP.Text = MyObj.IDFunzioneWP.ToString();
        }
        else
        {
          this.BCtlsysFunzione.mbtIDFunzioneWP.Text = "";
        }

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        this.BCtlsysFunzione.mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("sysFunzioni.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    protected override BBaseObject ScriviRec(BBaseObject Obj, BTreeNode n)
    {
      BsysFunzioni MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate())
          return null;
        MyObj = (BsysFunzioni)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(this.BCtlsysFunzione.mbtID.Text);
          MyObj.IDPadre = BConvert.ToInt(this.BCtlsysFunzione.mbcIDPadre.Text);
          MyObj.Descrizione = this.BCtlsysFunzione.mbtDescrizione.Text;
          MyObj.Comando = this.BCtlsysFunzione.mbtComando.Text;
          MyObj.Ordine = BConvert.ToInt(this.BCtlsysFunzione.mbtOrdine.Text);
          MyObj.Auth = this.BCtlsysFunzione.chkAuth.Checked;
          MyObj.Developer = this.BCtlsysFunzione.chkDeveloper.Checked;
          MyObj.Attivo = this.BCtlsysFunzione.chkAttivo.Checked;
          MyObj.IDSysModulo = BConvert.ToInt(this.BCtlsysFunzione.mbcIDsysModulo.SelectedValue);
          MyObj.Tooltip = this.BCtlsysFunzione.mbtToolTip.Text;
          MyObj.ShortCut = this.BCtlsysFunzione.mbtShortCut.Text;
          MyObj.Image = this.BCtlsysFunzione.imgImage.ImageByte;
          if (!string.IsNullOrEmpty(this.BCtlsysFunzione.mbtIDFunzioneWP.Text))
          {
            MyObj.IDFunzioneWP = BConvert.ToInt(this.BCtlsysFunzione.mbtIDFunzioneWP.Text);
          }
          else
          {
            MyObj.IDFunzioneWP = -1;
          }

          Ret = MyObj.Update();
          // BsysFunzioni.AggiornaOrdini(Me.DB)
        }

        if (Ret)
        {
          ((BsysUtenti)this.UtenteEntrato).WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysFunzione.mbtID.Text + ";>> DELLA TABELLA sysFunzioni");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        WriteLog("sysFunzioni.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    protected override void LoadFilter()
    {
      return;
    }

    // DEFINIZIONE EVENTI INTERCETTATI 
    protected void btnNodoInferiore_Click(object sender, EventArgs e)
    {
      int IDNode = -1;
      if (this.tvwFunzioni.SelectedNode == null) return;
      IDNode = int.Parse(this.tvwFunzioni.SelectedNode.Value);
      BsysFunzioni.CambiaOrdine(DB, BConvert.ToInt(this.tvwFunzioni.SelectedNode.Value), 1);
      CaricaTreeView();
      this.tvwFunzioni.SelectNode(IDNode.ToString());
      tvwFunzioni_SelectedNodeChanged(null, null);
    }
    protected void btnNodoSuperiore_Click(object sender, EventArgs e)
    {
      int IDNode = -1;
      if (this.tvwFunzioni.SelectedNode == null) return;
      IDNode = int.Parse(this.tvwFunzioni.SelectedNode.Value);
      BsysFunzioni.CambiaOrdine(DB, BConvert.ToInt(this.tvwFunzioni.SelectedNode.Value), -1);
      CaricaTreeView();
      this.tvwFunzioni.SelectNode(IDNode.ToString());
      tvwFunzioni_SelectedNodeChanged(null, null);
    }

    protected void CtlCommandBar_Nuovo()
    {
      this.Nuovo((BTreeNode)this.tvwFunzioni.SelectedNode);
      if (this.tvwFunzioni.SelectedNode != null && BConvert.ToInt(this.tvwFunzioni.SelectedNode.Value) > 0)
      {
        this.BCtlsysFunzione.mbcIDPadre.SelectedValue = this.tvwFunzioni.SelectedNode.Value;
      }
    }
    protected void CtlCommandBar_Elimina()
    {
      TreeNode n = this.tvwFunzioni.SelectedNode;
      int IDPadre = -1;
      if (n.Parent != null) IDPadre = BConvert.ToInt(n.Parent.Value);
      if (this.EliminaRamo(this.tvwFunzioni.SelectedNode))
      {
        BsysFunzioni.AggiornaOrdini(base.DB);
        MsgBox("Eliminazione effettuata correttamente!");
      }
      else
      {
        MsgBox(@"Attenzione! Errore durante l\'eliminazione.");
      }
      CaricaTreeView();
      n = this.tvwFunzioni.SelectNode(IDPadre.ToString());
      if (n != null) n.Expand();
    }
    protected void CtlCommandBar_Salva()
    {
      BsysFunzioni Obj = null;
      TreeNode nSelect = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
      {
        nSelect = null;
        Obj = new BsysFunzioni(this.DB);
      }
      else
      {
        nSelect = this.tvwFunzioni.SelectedNode;
        Obj = new BsysFunzioni(BConvert.ToInt(nSelect.Value), DB);
      }

      if (this.Salva(Obj, (BTreeNode)nSelect))
      {
        if (nSelect == null && this.tvwFunzioni.SelectedNode != null)
        {
          string ValuePath = this.tvwFunzioni.SelectedNode.ValuePath + "/" + Obj.ID;
          CaricaTreeView();
          TreeNode n = this.tvwFunzioni.SelectNode(Obj.ID.ToString());
          if (n != null) n.Expand();
        }
      }
      else
      {
        this.MsgBox("Salvataggio fallito.");
      }

      Obj = null;
    }
    protected void CtlCommandBar_Annulla()
    {
      this.Annulla();
    }

    private void BtnResetOrder_Click(object sender, EventArgs e)
    {
      BsysFunzioni.AggiornaOrdini(this.DB);
      CaricaTreeView();
    }
    private void tvwFunzioni_SelectedNodeChanged(object sender, EventArgs e)
    {
      if (DB == null) return; // SESSION END
      BsysFunzioni Obj = null;
      if (this.tvwFunzioni.SelectedNode == null) return;
      if (BConvert.ToInt(this.tvwFunzioni.SelectedNode.Value) == -1)
      {
        this.Annulla();
      }
      else
      {
        Obj = new BsysFunzioni(int.Parse(this.tvwFunzioni.SelectedNode.Value), this.DB);
        this.Modifica(Obj, (BTreeNode)this.tvwFunzioni.SelectedNode);
        if (this.tvwFunzioni.SelectedNode.ChildNodes.Count > 0)
        {
          this.CtlCommandBar.CtlBtnElimina.Attributes["onclick"] = @"javascript:return confirm('Attenzione! Se si elimina il nodo anche tutti i nodi figli verranno eliminati. \n\nProcedere comunque?')";
        }
        else
        {
          this.CtlCommandBar.CtlBtnElimina.Attributes["onclick"] = @"javascript:return confirm('Procedere con l\'eliminazione?')";
        }
      }
    }
    private void tvwFunzioni_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
      tvwFunzioni_SelectedNodeChanged(null, null);
    }

  } //END CLASS
} //END NAMESPACE