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
  public partial class BCtlElencoApplicazioni : BWebControlsBase
  {

    private string sp_BCtlElencoApplicazioni = "BSP_ElencoApplicazioni";


    // DEFINIZIONE PROPRIETA'
    private const string K_VS_IDAPPLICAZIONESELEZIONATA = ".IDApplicazioneSelezionata";
    public int IDApplicazioneSelezionata
    {
      get
      {
        return BConvert.ToInt(this.ViewState[this.ID + K_VS_IDAPPLICAZIONESELEZIONATA]);
      }
      set
      {
        this.ViewState[this.ID + K_VS_IDAPPLICAZIONESELEZIONATA] = value;
      }
    }

    // DEFINIZIONE PROPRIETA' READONLY
    public int Count
    {
      get
      {
        return this.dtlSceltaApplicazione.Items.Count;
      }
    }

    // DEFINIZIONE METODI
    public bool InitControl(bool HideWhenOne = false)
    {
      try
      {
        if (this.BSysUtenteEntrato == null) return false;
        DBUser.ClearParameter();
        DBUser.AddParameter("@IdSysUtente", BSysUtenteEntrato.ID);
        DBUser.AddParameter("@IDVisibilitaTerritoriale", BSysUtenteEntrato.IDVisibilita);
        DataTable dt = DBUser.ApriDT(sp_BCtlElencoApplicazioni, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          this.dtlSceltaApplicazione.DataSource = dt;
          this.dtlSceltaApplicazione.DataBind();
          this.dtlSceltaApplicazione.Visible = true;

        }
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlElencoApplicazioni.InitControl", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    protected void LinkApplicazione_Click(object sender, EventArgs e)
    {
      string IDApplicazioneIDJobRole = ((LinkButton)sender).CommandArgument;
      int IDApplicazione = BConvert.ToInt(BGlobal.PrendiParteStr(IDApplicazioneIDJobRole, 1, "@"));
      int IDJobRole = BConvert.ToInt(BGlobal.PrendiParteStr(IDApplicazioneIDJobRole, 2, "@"));
      string querystring = "?IDApplicazione=" + IDApplicazione + "&IDJobRole=" + IDJobRole;
      BRedirect(ModConstantList.K_PAGE_Token.ToString() + querystring);
    }

  }
}
