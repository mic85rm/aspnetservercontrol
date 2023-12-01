// *****************************************************
// *** Classe generata con BStudio [Ver. 3.1.5] ***
// *****************************************************

using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using PosteWebTemplate1;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static BArts.BEnumerations;

namespace PosteWebTemplate1
{
  public partial class FrmWiki : BPageTreeViewBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL = "sysWiki";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";
    private const string K_TBL_WikiAllegati = "WikiAllegati";
    private const string K_SP_WikiAllegati_DELETE = "BSP_" + K_TBL_WikiAllegati + "_DELETEALL";
    private const string K_TBL_WikiLinks = "WikiLinks";
    private const string K_SP_WikiLinks_DELETE = "BSP_" + K_TBL_WikiLinks + "_DELETEALL";

    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      Titolo,
      Descrizione
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "FrmWiki";
      this.CtlCommandBar.PageName = "Gestione Wiki";
      this.SP_ELENCO_DELETE = K_SP_DELETE;

      // Me.CtlPnlRicerca = PnlRicerca
      this.CtlPnlElenco = PnlElenco;
      this.CtlPnlDettaglio = PnlDettaglio;
      this.CtlTvwElenco = this.tvwWiki;
      this.CtlBtnNuovo = this.CtlCommandBar.CtlBtnNuovo;
      this.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.RunSearchToLoad = true;

      // INIT CONTROL BTABLEBASE
      // Me.FirstCtlRicerca = mbtDescrizioneRicerca

      this.BCtlWiki.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlWiki.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlWiki.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlWiki.Visible = true;
      this.BCtlWiki.Enabled = true;
      return default;
    }
    protected override void SetAttributes_Invio()
    {
      this.BCtlWiki.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.BCtlWiki.SetAttributes_Other();
      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlCommandBar.Nuovo += CtlCommandBar_Nuovo;
      CtlCommandBar.Elimina += CtlCommandBar_Elimina;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;
      CtlCommandBar.Stampa += CtlCommandBar_Stampa;
      tvwWiki.SelectedNodeChanged += tvwWiki_SelectedNodeChanged;
      tvwWiki.TreeNodeExpanded += tvwWiki_TreeNodeExpanded;
      btnNodoInferiore.Click += BtnNodoInferiore_Click;
      btnNodoSuperiore.Click += BtnNodoSuperiore_Click;

      base.SetAttributes_AddEvents();
    }


    protected override void LoadFilter()
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.CheckAuth = false;
      this.DisabilitaInvio(false);
      base.OnInit(e);
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI WikiAllegati
      DB.ClearParameter();
      DB.AddParameter("@IDWiki", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_WikiAllegati_DELETE, CommandType.StoredProcedure);
      // RIMOZIONE RECORD RELAZIONATI WikiLinks
      DB.ClearParameter();
      DB.AddParameter("@IDWiki", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_WikiLinks_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }
    private bool EliminaNodo(int id)
    {
      var funzione = new BsysWiki(id, DB);
      if (funzione is object && !funzione.IsNothing)
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
          if (!ret) return EliminaNodo(BConvert.ToInt(nodo.Value));
        }
      }

      return EliminaNodo(BConvert.ToInt(nodoPadre.Value));
    }

    // DEFINIZIONE EVENTI INTERCETTATI

    // DEFINIZIONE EVENTI INTERCETTATI SULLA BARRA DI COMANDO
    private void CtlCommandBar_Nuovo()
    {
      this.Nuovo((BTreeNode)tvwWiki.SelectedNode);
      BCtlWiki.SetAttributes_Other();
      if (tvwWiki.SelectedNode != null && BConvert.ToInt(tvwWiki.SelectedNode.Value) > 0)
      {
        BCtlWiki.mbcIDPadre.SelectedValue = tvwWiki.SelectedNode.Value;
      }
    }
    private void CtlCommandBar_Elimina()
    {
      TreeNode n = tvwWiki.SelectedNode;
      int IDPadre = -1;
      if (n.Parent != null) IDPadre = BConvert.ToInt(n.Parent.Value);
      if (EliminaRamo(tvwWiki.SelectedNode))
      {
        BsysWiki.AggiornaOrdini(DB);
        this.MsgBox("Eliminazione effettuata correttamente!");
      }
      else
      {
        this.MsgBox(@"Attenzione! Errore durante l\'eliminazione.");
      }

      CaricaTreeView();
      n = this.tvwWiki.SelectNode(BConvert.ToString(IDPadre));
      if (n is object) n.Expand();
    }
    private void CtlCommandBar_Salva()
    {
      BsysWiki Obj = null;
      TreeNode nSelect = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
      {
        nSelect = null;
        Obj = new BsysWiki(this.DB);
      }
      else
      {
        nSelect = tvwWiki.SelectedNode;
        Obj = new BsysWiki(BConvert.ToInt(nSelect.Value), this.DB);
      }

      if (this.Salva(Obj, (BTreeNode)nSelect))
      {
        CaricaTreeView();
        this.tvwWiki.SelectNode(BConvert.ToString(Obj.ID));
        tvwWiki_SelectedNodeChanged(null, null);
      }
      else
      {
        this.MsgBox("Salvataggio fallito.");
      }

      Obj = null;
    }
    private void CtlCommandBar_Annulla()
    {
      this.Annulla();
    }
    private void CtlCommandBar_Stampa()
    {
      // ADD CODE TO PRINT
    }

    protected override void NuovoRec(BTreeNode n)
    {
      BCtlWiki.NuovoRec();
    }
    protected override bool CambiaRec(BBaseObject Obj, BTreeNode n)
    {
      return BCtlWiki.CambiaRec(Obj);
    }
    protected override BBaseObject ScriviRec(BBaseObject Obj, BTreeNode n)
    {
      return BCtlWiki.ScriviRec(Obj);
    }

    protected override bool CaricaTreeView(bool EscludiFiltriRicerca = false)
    {
      string sp = K_SP_SELECT;
      DataTable dt = null;
      BDataSet ds = null;
      try
      {
        // dt = BWiki.GetElenco(Me.DB)
        DB.ClearParameter();
        this.LoadDBParameterByFiltri();
        dt = DB.ApriDT(sp, CommandType.StoredProcedure);
        if (dt == null)
          return false;
        ds = new BDataSet();
        ds.Tables.Add(dt);
        this.tvwWiki.ShowCheckBoxes = TreeNodeTypes.All;
        this.tvwWiki.CampoID = "ID";
        this.tvwWiki.CampoIDPadre = "IDPadre";
        this.tvwWiki.CampoDescrizione = "Titolo";
        this.tvwWiki.CampoOrdine = "Ordine";
        this.tvwWiki.CampoImage = "";
        this.tvwWiki.CampoToolTip = "Sottotitolo";
        this.tvwWiki.RootValueIsNull = true;
        this.tvwWiki.TipoDatoCampoKey = BArts.BWeb.BControls.BTreeView.eTipoDatoKey.NUMERICO;
        this.tvwWiki.DynamicLoading = true;
        this.tvwWiki.ShowCheckBoxes = TreeNodeTypes.None;
        this.tvwWiki.ShowLines = false;
        this.tvwWiki.Nodes.Clear();
        return this.tvwWiki.InitControl(ds);
      }
      catch (Exception ex)
      {
        this.WriteLog("sysFunzioni.CaricaFunzioni()", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    private void tvwWiki_SelectedNodeChanged(object sender, EventArgs e)
    {
      BsysWiki Obj = default;
      if (tvwWiki.SelectedNode == null) return;
      if (BConvert.ToInt(tvwWiki.SelectedNode.Value) == -1)
      {
        this.Annulla();
      }
      else
      {
        Obj = new BsysWiki(BConvert.ToInt(tvwWiki.SelectedNode.Value), this.DB);
        SetAttributes_Invio();
        SetAttributes_Other();
        this.Modifica(Obj, (BTreeNode)tvwWiki.SelectedNode);
        if (tvwWiki.SelectedNode.ChildNodes.Count > 0)
        {
          CtlCommandBar.CtlBtnElimina.Attributes["onclick"] = @"javascript:return confirm('Attenzione! Se si elimina il nodo anche tutti i nodi figli verranno eliminati. \n\nProcedere comunque?')";
        }
        else
        {
          CtlCommandBar.CtlBtnElimina.Attributes["onclick"] = @"javascript:return confirm('Procedere con l\'eliminazione?')";
        }
      }
    }
    private void tvwWiki_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
      tvwWiki_SelectedNodeChanged(null, null);
    }
    // DEFINIZIONE EVENTI INTERCETTATI SUI BOTTONI
    private void BtnNodoSuperiore_Click(object sender, EventArgs e)
    {
      int IDNode = -1;
      if (tvwWiki.SelectedNode == null) return;
      IDNode = BConvert.ToInt(tvwWiki.SelectedNode.Value);
      BsysWiki.CambiaOrdine(DB, BConvert.ToInt(tvwWiki.SelectedNode.Value), -1);
      CaricaTreeView();
      this.tvwWiki.SelectNode(IDNode.ToString());
      tvwWiki_SelectedNodeChanged(null, null);
    }

    private void BtnNodoInferiore_Click(object sender, EventArgs e)
    {
      int IDNode = -1;
      if (tvwWiki.SelectedNode == null) return;
      IDNode = BConvert.ToInt(tvwWiki.SelectedNode.Value);
      BsysWiki.CambiaOrdine(DB, IDNode, 1);
      CaricaTreeView();
      this.tvwWiki.SelectNode(IDNode.ToString());
      tvwWiki_SelectedNodeChanged(null, null);
    }


  } //END CLASS
} //END NAMESPACE