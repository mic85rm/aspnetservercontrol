using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using static BArts.BEnumerations;

namespace PosteWebTemplate1
{
  public partial class Help : BPageBase
  {

    protected override void OnInit(EventArgs e)
    {
      this.CheckAuth = false;
      base.OnInit(e);
    }
    protected override void OnLoad(EventArgs e)
    {
      this.LoadAttributes();
      if (!IsPostBack)
      {
        this.CaricaTreeView();
        if (tvwWiki.Nodes.Count > 0)
        {
          tvwWiki.Nodes[0].Select();
          tvwWiki.Nodes[0].Expand();
          tvwWiki_SelectedNodeChanged(null, null);
        }

        if (Request.QueryString["q"] != null)
        {
          txtCerca.Text = BCrypter.Decrypt(Request.QueryString["q"].Replace(" ", "+"));
          CaricaRiferimenti();
        }
      }
      base.OnLoad(e);
    }

    protected override void SetAttributes_AddEvents()
    {
      tvwWiki.SelectedNodeChanged += tvwWiki_SelectedNodeChanged;
      dtlWikies.ItemDataBound += dtlWikies_ItemDataBound;
      dtlWikies.ItemCommand += dtlWikies_ItemCommand;
      CtlItemWikiDettaglio.Link_Click += CtlItemWikiDettaglio_Link_Click;
      this.EventManager += Help_EventManager;
      base.SetAttributes_AddEvents();
    }

    private void Help_EventManager(string CommandName, string Args, string sender)
    {
      switch (CommandName.ToUpper())
      {
        case "TXTCERCA_ONKEYDOWN":
          {
            CaricaRiferimenti();
            break;
          }
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void tvwWiki_SelectedNodeChanged(object sender, EventArgs e)
    {
      BsysWiki wik = null;
      if (tvwWiki.SelectedNode != null)
      {
        wik = new BsysWiki(BConvert.ToInt(tvwWiki.SelectedNode.Value), DB);
        if (wik != null && !wik.IsNothing)
        {
          if (CtlItemWikiDettaglio.InitControl(wik, true))
            this.SetVisibility(true);
          else
            this.SetVisibility(false);
        }
      }
    }
    private void dtlWikies_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      CtlItemWiki ItmWiki = null;
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ItmWiki = (CtlItemWiki)e.Item.FindControl("CtlItemWiki");
        if (ItmWiki == null) return;
        DataRowView drv = (DataRowView)e.Item.DataItem;
        if (drv == null || drv.Row == null) return;
        ItmWiki.InitControl(BConvert.ToInt(drv.Row["ID"]), false);
      }
    }
    private void dtlWikies_ItemCommand(object source, DataListCommandEventArgs e)
    {
      int id = -1;
      switch (e.CommandName)
      {
        case "TitoloClick":
          {
            id = BConvert.ToInt(e.CommandArgument);
            if (CtlItemWikiDettaglio.InitControl(id, true))
              this.SetVisibility(true);
            else
              this.SetVisibility(false);
            break;
          }
      }
    }

    private void CtlItemWikiDettaglio_Link_Click(int IDLink)
    {
      CtlItemWikiDettaglio.InitControl(IDLink, true);
      AttivaNodoTree(tvwWiki.Nodes, IDLink.ToString());
      this.SetVisibility(true);
    }


    // DEFINIZIONE FUNZIONI PRIVATE
    private void LoadAttributes()
    {
      txtCerca.JS_OnKeyDown = "BWiki_txtCerca_onkeydown(this, event);";
      txtCerca.SetAutoComplete(this.Page, "BsysWiki", "autocomplete");
    }
    private bool CaricaTreeView(bool EscludiFiltriRicerca = false)
    {
      string sp = "BSP_sysWIKI_SEARCH";
      DataTable dt = null;
      BDataSet ds = null;
      try
      {
        DB.ClearParameter();
        DB.AddParameter("@Pubblica", true);
        dt = DB.ApriDT(sp, CommandType.StoredProcedure);

        if (dt == null) return false;
        ds = new BDataSet();
        ds.Tables.Add(dt);

        this.tvwWiki.ShowCheckBoxes = TreeNodeTypes.All;
        this.tvwWiki.CampoID = "ID";
        this.tvwWiki.CampoIDPadre = "IDPadre";
        this.tvwWiki.CampoDescrizione = "Titolo";
        this.tvwWiki.CampoOrdine = "";
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
    private bool AttivaNodoTree(TreeNodeCollection nodi, string IDLink)
    {
      foreach (TreeNode nodo in nodi)
      {
        if (nodo.Value == IDLink)
        {
          nodo.Selected = true;
          return true;
        }
        else if (nodo.ChildNodes != null && nodo.ChildNodes.Count > 0)
        {
          if (nodo.ChildNodes[0].Value.StartsWith("BLOADING")) nodo.Expand();
          if (AttivaNodoTree(nodo.ChildNodes, IDLink)) return true;
        }
      }
      return false;
    }
    private void CaricaRiferimenti()
    {
      DataTable dt = null;
      string sp = "WSP_sysWiki_SEARCH";
      DB.ClearParameter();
      DB.AddParameter("@Testo", txtCerca.Text);
      dt = this.DB.ApriDT(sp, CommandType.StoredProcedure);

      if (dt != null && dt.Rows.Count > 0)
      {
        if (dt.Rows.Count == 1)
        {
          if (CtlItemWikiDettaglio.InitControl(BConvert.ToInt(dt.Rows[0]["ID"]), false))
            this.SetVisibility(true);
          else
            this.SetVisibility(false);
        }
        else
        {
          this.SetAttributes_AddEvents();
          dtlWikies.DataSource = dt;
          dtlWikies.DataBind();
          this.SetVisibility(false);
        }
      }
      else
        this.SetVisibility(false);
    }
    private void SetVisibility(bool OnlyItem)
    {
      pnlElenco.Visible = !OnlyItem;
      PnlDettaglio.Visible = OnlyItem;
    }

  } //END CLASS
} //END NAMESPACE