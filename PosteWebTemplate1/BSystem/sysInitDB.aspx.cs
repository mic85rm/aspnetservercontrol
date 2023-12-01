using BArts.BData;
using BArts.BGlobal;
using BArts.BIO;
using BArts.BWeb.BControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using System.Windows.Interop;

namespace PosteWebTemplate1
{
  public partial class sysInitDB : BPageBase
  {
    //DEFINIZIONE DATI
    public enum eDTGElenco
    {
      ChkSelect,
      NomeFile,
      TblDestination,
      Stato
    }

    List<BIFFile> LstBIF
    {
      get
      {

        return (List<BIFFile>)Session["sysInitDB.LstBIF"];
      }
      set
      {
        Session["sysInitDB.LstBIF"] = value;
      }
    }


    protected override void BPage_Load(object sender, EventArgs e)
    {
      CtlCommandBar.PageName = "Inizializzazione database";
      CtlCommandBar.CtlBtnAnnulla.Visible = false;
      CtlCommandBar.CtlBtnElimina.Visible = false;
      CtlCommandBar.CtlBtnNuovo.Visible = false;
      CtlCommandBar.CtlBtnSalva.Visible = false;
      CtlCommandBar.CtlBtnStampa.Visible = false;

      base.BPage_Load(sender, e);
    }

    protected override void SetAttributes_AddEvents()
    {
      BtnAggiornaDB_BTamplate.Click += BtnAggiornaDB_BTamplate_Click;
      BtnInitDB_BSoftware.Click += BtnInitDB_BSoftware_Click;
      DtgElenco.RowDataBound += DtgElenco_RowDataBound;
      pnlImportFile.Conferma += PnlImportFile_Conferma;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void DtgElenco_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
      BSwitch ChkSelectAll = null;
      BSwitch ChkSelect = null;
      var switchExpr = e.Row.RowType;
      switch (switchExpr)
      {
        case DataControlRowType.Header:
          {
            ChkSelectAll = (BSwitch)e.Row.FindControl("ChkSelectAll");
            if (ChkSelectAll == null)
              return;
            ChkSelectAll.Checked = true;
            ChkSelectAll.Attributes["onclick"] = "return BGridView_SwitchAll('" + ChkSelectAll.ClientID + "', '" + DtgElenco.ClientID + "', 0)";
            break;
          }
        case DataControlRowType.DataRow:
          {
            ChkSelect = (BSwitch)e.Row.FindControl("ChkSelect");
            if (ChkSelect == null)
              return;
            ChkSelectAll = (BSwitch)DtgElenco.HeaderRow.FindControl("ChkSelectAll");
            if (ChkSelectAll == null)
              return;
            ChkSelect.Checked = ChkSelectAll.Checked;
          }
          break;
      }
    }

    private void BtnAggiornaDB_BTamplate_Click(object sender, EventArgs e)
    {
      BArts.BLog.BLogText BLog = new BArts.BLog.BLogText();
      bool ret = ModAggiornaDB_BWebAppTemplate.AggiornaDB(DB, BLog);
      if (ret)
      {
        this.MsgBox("Aggiornamento completato con successo.");
      }
      else
      {
        this.MsgBox("Aggiornamento non riuscito.");
      }
      mbtLog.Text = BLog.Text.Replace("/*", "").Replace("//", "").Replace("*/", "").Replace("<--", "").Replace("-->", "").Replace("<<", "[").Replace(">>", "]");
    }
    private void BtnInitDB_BSoftware_Click(object sender, EventArgs e)
    {
      if (LoadBIFFile())
        pnlImportFile.Show();
      else
        MsgBox("Non ci sono file da importare");
    }

    private void PnlImportFile_Conferma()
    {
      BArts.BLog.BLogText BLog = new BArts.BLog.BLogText();
      BIFFile bif;
      IEnumerable<GridViewRow> ret = from GridViewRow row in DtgElenco.Rows
                                     where ((BSwitch)row.FindControl("ChkSelect")).Checked
                                     select row;
      int CountBIFImported = 0;
      if (ret != null && ret.Count() > 0)
      {
        foreach (GridViewRow row in ret.ToList())
        {
          bif = LstBIF[row.DataItemIndex];
          bif.BLog = BLog;
          if (bif.Read())
          {
            if (bif.Import())
            {
              CountBIFImported += 1;
              bif.Stato = BIFFile.eStato.Importato;
              row.Cells[(byte)eDTGElenco.Stato].Text = BIFFile.eStato.Importato.ToString();
              row.ForeColor = Color.Green;
              row.Font.Bold = true;
              BSwitch ChkSelect = (BSwitch)row.FindControl("ChkSelect");
              if (ChkSelect != null) ChkSelect.Checked = false;
            }
            else
            {
              bif.Stato = BIFFile.eStato.Errore;
              row.Cells[(byte)eDTGElenco.Stato].Text = BIFFile.eStato.Errore.ToString();
              row.ForeColor = Color.Red;
              row.Font.Bold = true;
            }
          }
          else
          {
            bif.Stato = BIFFile.eStato.Errore;
            row.Cells[(byte)eDTGElenco.Stato].Text = BIFFile.eStato.Errore.ToString();
            row.ForeColor = Color.Red;
            row.Font.Bold = true;

          }
        }
        if (CountBIFImported > 0) MsgBox("Sono stati importati " + CountBIFImported.ToString() + " file/s");
      }
      mbtLog.Text = BLog.Text.Replace("/*", "").Replace("//", "").Replace("*/", "").Replace("<--", "").Replace("-->", "").Replace("<<", "[").Replace(">>", "]");
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadBIFFile()
    {
      LstBIF = new List<BIFFile>();
      string Path = Server.MapPath(@"~/" + BWebConfig.InitDB_BIFFolder);
      if (Directory.Exists(Path))
      {
        DirectoryInfo dir = new DirectoryInfo(Path);
        foreach (FileInfo f in dir.GetFiles("*.bif"))
        {
          BIFFile itm = new BIFFile(this.DB, f.FullName);
          LstBIF.Add(itm);
          itm = null;
        }

        this.BindDtg();
        return true;
      }
      else
      {
        MsgBox("La cartella <<" + BWebConfig.InitDB_BIFFolder + ">> non è presente sul server.");
        return false;
      }
    }
    private void BindDtg()
    {
      DtgElenco.DataSource = LstBIF;
      DtgElenco.DataBind();
    }

  } //END CLASS
} //END NAMESPACE