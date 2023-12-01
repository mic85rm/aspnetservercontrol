using BArts.BGlobal;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebpersBaseLibrary;

namespace PosteWebTemplate1
{
  public partial class BCtlElencoVisibilita : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event VisibilitaSelezionataEventHandler VisibilitaSelezionata;
    public delegate void VisibilitaSelezionataEventHandler(int IDVisibilita, bool ChangeClick = true);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE PROPRIETA'
    private const string K_VS_IDVISIBILITASELEZIONATA = ".IDVisibilitaSelezionata";
    public int IDVisibilitaSelezionata
    {
      get
      {
        return BConvert.ToInt(this.ViewState[this.ID + K_VS_IDVISIBILITASELEZIONATA]);
      }
      set
      {
        this.ViewState[this.ID + K_VS_IDVISIBILITASELEZIONATA] = value;
        if (this.BSysUtenteEntrato != null) BSysUtenteEntrato.IDVisibilita = value;
      }
    }

    // DEFINIZIONE PROPRIETA' READONLY
    public int Count
    {
      get
      {
        return this.dtlSceltaVisibilita.Items.Count;
      }
    }

    // DEFINIZIONE METODI
    public bool InitControl()
    {
      string sp = "BSP_UtentiVisibilita_SEARCH";
      try
      {
        if (this.UtenteEntrato == null) return false;
        DBUser.ClearParameter();
        DBUser.AddParameter("@IDSysUtente", BSysUtenteEntrato.ID);
        DBUser.AddParameter("@IDVisibilitaSelezionata", this.IDVisibilitaSelezionata);
        DataTable dt = DBUser.ApriDT(sp, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          this.dtlSceltaVisibilita.DataSource = dt;
          this.dtlSceltaVisibilita.DataBind();
        }
        else
        {
          this.WriteLog("CtlElencoVisibilita.InitControl", $"L'utente {BSysUtenteEntrato.ID} non ha associato nessuna visibilità.", BArts.BEnumerations.eSeverity.INFORMATION);
          this.pnlElencoVisibilita.Visible = false;
        }
        if (this.dtlSceltaVisibilita.Items.Count == 1)
        {
          this.pnlElencoVisibilita.Visible = false;
        }
        else
        {
          this.pnlElencoVisibilita.Visible = true;
        }
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("CtlElencoVisibilita.InitControl", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    protected void LinkVisibilita_Click(object sender, EventArgs e)
    {
      this.IDVisibilitaSelezionata = BConvert.ToInt(((LinkButton)sender).CommandArgument);

      this.InitControl();

      VisibilitaSelezionata?.Invoke(IDVisibilitaSelezionata);
    }

    protected void btnPreferito_Click(object sender, EventArgs e)
    {
      string sp = "BSP_CambiaPreferito";
      int IDVisibilita = BConvert.ToInt(((Button)sender).CommandArgument);
      try
      {
        DB.ClearParameter();
        DB.AddParameter("@IDSysUtente", BSysUtenteEntrato.ID);
        DB.AddParameter("@IDVisibilita", IDVisibilita);
        if (DB.ExecuteNonQuery(sp, CommandType.StoredProcedure) == 0)
        {
          MsgBox("Errore durante il cambio della visibilità preferita.");
        }
        else
        {
          InitControl();
          //VisibilitaSelezionata?.Invoke(IDVisibilita, false);
        }

      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlElencoVisibilita.btnPreferito_Click", "", ex, BArts.BEnumerations.eSeverity.ERROR);
      }
    }
  }


}