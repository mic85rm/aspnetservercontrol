using BArts.BGlobal;
using System;
using System.Data;

namespace PosteWebTemplate1
{
  public partial class BCtlHeaderBar : BWebControlsBase
  {

    // DEFINIZIONE DATI
    public enum eDtgElenco : byte
    {
      Descrizione,
      Comando,
      Tipo,
      Args
    }

    // DEFINIZIONE PROPRIETA'
    public bool GlobalSearch_Enabled
    {
      get
      {
        return this.PnlSearch.Visible;
      }
      set
      {
        this.PnlSearch.Visible = value;
      }
    }
    public bool Help_Enabled
    {
      get
      {
        return this.BtnHelp.Visible;
      }
      set
      {
        this.BtnHelp.Visible = value;
      }
    }
    public bool Notify_Enabled
    {
      get
      {
        return this.BCtlServicesNotification.Visible;
      }

      set
      {
        this.BCtlServicesNotification.Visible = value;
      }
    }

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      BtnHelp.Click += BtnHelp_Click;
      BtnSearch.Click += BtnSearch_Click;
      pnlRicercaGlobale.Annulla += pnlRicercaGlobale_Annulla;
      DtgElenco.RowClick += DtgElenco_RowClick;
      this.Load += Page_Load;
      this.EventManager += BCtlHeaderBar_EventManager;

      base.SetAttributes_AddEvents();
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!base.IsPostBack)
      {
        if (this.UtenteEntrato == null || this.UtenteEntrato.IsNothing)
        {
          this.Visible = false;
        }
        else
        {
          this.Visible = true;
        }

        this.mbtSearchAll.JS_OnKeyDown = "BCtlHeaderBar_KeyDown(this, event);";
      }
    }

    private void BtnHelp_Click(object sender, EventArgs e)
    {
      base.BRedirect(BWebConfig.URLHelpOnline);
    }
    private void BtnSearch_Click(object sender, EventArgs e)
    {
      DataTable dt = null;
      string sp = "SSP_Gloabl_SEARCH";
      try
      {
        DB.ClearParameter();
        DB.AddParameter("@IDSysProfilo", base.UtenteEntrato.IDProfilo);
        base.DB.AddParameter("@Descrizione", this.mbtSearchAll.Text);
        dt = DB.ApriDT(sp, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          this.DtgElenco.DataSource = dt;
          this.DtgElenco.DataBind();
          this.pnlRicercaGlobale.Show();
          if (this.BDtgPager != null)
            this.BDtgPager.SetPager(dt.Rows.Count);
        }
        else
        {
          this.MsgBox("Nessun elemento trovato.");
        }
      }
      catch (Exception ex)
      {
        this.MsgBox("Non è stato possibile effettuare la ricerca.");
        this.WriteLog("BCtlHeaderBar.BtnSearch()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }
    private void pnlRicercaGlobale_Annulla()
    {
      this.pnlRicercaGlobale.Hide();
      this.mbtSearchAll.Text = "";
    }
    private void DtgElenco_RowClick(int RowIndex)
    {

      string comando = this.DtgElenco.Rows[RowIndex].Cells[(int)eDtgElenco.Comando].Text;
      byte tipo = BConvert.ToByte(this.DtgElenco.Rows[RowIndex].Cells[(int)eDtgElenco.Tipo].Text);
      string args = this.DtgElenco.Rows[RowIndex].Cells[(int)eDtgElenco.Args].Text;
      this.BMaster.ExecCommand(comando, (ModEnumeration.eGlobalSearch)tipo, args);
    }

    private void BCtlHeaderBar_EventManager(string CommandName, string Args, string sender)
    {
      if ((CommandName ?? "") == "BCtlHeaderBar_KeyDown")
      {
        BtnSearch_Click(null, null);
      }
    }

  } //END CLASS
} //END NAMESPACE