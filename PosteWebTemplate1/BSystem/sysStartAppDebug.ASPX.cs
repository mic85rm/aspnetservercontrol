using BArts.BGlobal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebpersBaseLibrary;

namespace PosteWebTemplate1.BSystem
{
  public partial class sysStartAppDebug : BPageBase
  {

    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.CheckAuth = false;
      base.BPage_Init(sender, e);
    }

    protected override void SetAttributes_AddEvents()
    {
      mbcIDUtente.SelectedIndexChanged += MbcIDUtente_SelectedIndexChanged;
      mbcIDVisibilita.SelectedIndexChanged += MbcIDVisibilita_SelectedIndexChanged;
      BtnToken.Click += BtnToken_Click;
      BtnStartDeveloper.Click += BtnStartDeveloper_Click;
      base.SetAttributes_AddEvents();
    }

    private void BtnStartDeveloper_Click(object sender, EventArgs e)
    {
      BRedirect(ModConstantList.K_PAGE_LOGIN);
    }

    private void BtnToken_Click(object sender, EventArgs e)
    {
      if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.WPInterna)
      {
        string url = "~/BSystem/sysStartApp.aspx?IDApplicazione={0}&IDJobRole={1}";
        int IDApplicazione = BConvert.ToInt(BGlobal.PrendiParteStr(mbcIDApplicazione.SelectedValue, 1));
        int IDJr = BConvert.ToInt(BGlobal.PrendiParteStr(mbcIDApplicazione.SelectedValue, 2));

        url = string.Format(url, IDApplicazione, IDJr);

        BApplicazioni App = new BApplicazioni(IDApplicazione, DBUser);
        BUtenti ut = new BUtenti(mbcIDUtente.SelectedValue, DBUser);
        if (ut != null && !ut.IsNothing && App != null && !App.IsNothing)
        {
          DBUser.ClearParameter();
          DBUser.AddParameter("@IdUtente", ut.ID);
          DBUser.AddParameter("@IdApplicazione", IDApplicazione);
          DBUser.AddParameter("@IDpersona", ut.IDPersona);
          DBUser.AddParameter("@IdWhere", mbcIDVisibilita.SelectedValue);
          DBUser.AddParameter("@IdJobRole", IDJr);
          DBUser.AddParameter("@idprofilo", 1);
          int id = BConvert.ToInt(DBUser.ExecuteScalar("BSP_ChildAppToken_INSERT_App_Interna", CommandType.StoredProcedure));
          if (id != 0)
          {
            string tmpUrl = @"~/default.aspx?tknid={0}&NewWebPers={1}";
            url = string.Format(tmpUrl, id, "1");

            Session[ModConstantList.K_SE_SYSINITAPP] = false;
            BRedirect(url);
          }
        }
      }
      else
      {
        string urlChild = "~/default.aspx?tknid={0}";
        urlChild = string.Format(urlChild, mbtIDToken.Text, "0");

        Session[ModConstantList.K_SE_SYSINITAPP] = false;
        BRedirect(urlChild);

      }


    }

    private void MbcIDVisibilita_SelectedIndexChanged(object sender, EventArgs e)
    {
      mbcIDApplicazione.Items.Clear();
      mbcIDApplicazione.Filtro = "IDSysUtente = '" + mbcIDUtente.SelectedValue + "' and IDVisibilitaTerritoriale = " + mbcIDVisibilita.SelectedValue
                                 + " and IDApplicazione = " + Config.IDApplicazione.ToString();
      mbcIDApplicazione.Init(this.DB.Setting);
      mbcIDApplicazione.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
    }

    private void MbcIDUtente_SelectedIndexChanged(object sender, EventArgs e)
    {
      mbcIDVisibilita.Items.Clear();
      mbcIDVisibilita.Filtro = "IDSysUtente = '" + mbcIDUtente.SelectedValue + "'";
      mbcIDVisibilita.Init(this.DB.Setting);
      mbcIDVisibilita.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
      mbcIDVisibilita.SelectedIndex = 0;

      mbcIDApplicazione.Items.Clear();
      mbcIDApplicazione.Filtro = "IDSysUtente = '" + mbcIDUtente.SelectedValue + "' and IDVisibilitaTerritoriale = " + mbcIDVisibilita.SelectedValue
                                + " and IDApplicazione = " + Config.IDApplicazione.ToString();
      mbcIDApplicazione.Init(this.DBUser.Setting);
      mbcIDApplicazione.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));


    }

    protected override void BPage_Load(object sender, EventArgs e)
    {
      if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.WPInterna)
      {
        if (!IsPostBack)
        {
          CaricaCombo();
        }
        pnlChildApp.Visible = false;
        PnlInternaApp.Visible = true;
      }
      else
      {
        pnlChildApp.Visible = true;
        PnlInternaApp.Visible = false;
      }

    }

    private void CaricaCombo()
    {
      mbcIDUtente.Items.Clear();
      mbcIDVisibilita.Items.Clear();
      mbcIDApplicazione.Items.Clear();
      mbcIDUtente.Init(this.DB.Setting);
      mbcIDVisibilita.SelectedIndex = 0;
      mbcIDVisibilita.Filtro = "IDSysUtente = '" + mbcIDUtente.SelectedValue + "'";
      mbcIDVisibilita.Init(this.DB.Setting);
      mbcIDVisibilita.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
      mbcIDVisibilita.SelectedIndex = 0;
      mbcIDApplicazione.Filtro = "IDSysUtente = '" + mbcIDUtente.SelectedValue + "' and IDVisibilitaTerritoriale = " + mbcIDVisibilita.SelectedValue;
      mbcIDApplicazione.Init(this.DBUser.Setting);
      mbcIDApplicazione.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
    }

  }
}