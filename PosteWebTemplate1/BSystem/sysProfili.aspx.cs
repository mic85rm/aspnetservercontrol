// *****************************************************
// *** Classe generata con BStudio [Ver. 3.2.2] ***
// *****************************************************

using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysProfili : BPageTableBase
  {

    // DEFINIZIONE DATI

    private const string K_TBL = "sysProfili";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";
    private const string K_TBL_sysProfiliFunzioni = "sysProfiliFunzioni";
    private const string K_SP_sysProfiliFunzioni_DELETE = "BSP_" + K_TBL_sysProfiliFunzioni + "_DELETEALL";

    private const string K_SP_SYNCPROFILI_INTERNAWP = "BSP_" + K_TBL + "_SYNC";

    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      Descrizione
    }

    // DEFINIZIONE FUNZIONI OVERRIDES

    protected override bool InitBTablePage()
    {
      this.PageName = "sysProfili";
      this.CtlCommandBar.PageName = "Gestione Profili";

      this.SP_ELENCO_SELECT = K_SP_SELECT;
      this.SP_ELENCO_DELETE = K_SP_DELETE;
      this.CtlPnlRicerca = this.PnlRicerca;
      this.CtlPnlElenco = this.PnlElenco;
      this.CtlPnlDettaglio = this.PnlDettaglio;
      this.CtlDtgElenco = this.DtgElenco;
      this.CtlBPager = this.BDtgPager;
      this.CtlBtnNuovo = this.CtlCommandBar.CtlBtnNuovo;
      this.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.RunSearchToLoad = true;
      this.DTElencoInSession = true;
      this.AllowPaging = true;

      if (BWebConfig.TipoApplicazione != BWebConfig.eTipoApplicazione.PosteRUO)
      {
        this.CtlCommandBar.CtlBtnNuovo.Style.Add("display", "none");

      }
      if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.PosteRUO)
      {
        this.BtnSyncProfili.Style.Add("display", "none");
      }


      // INIT CONTROL BTABLEBASE
      this.BCtlsysProfili.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysProfili.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysProfili.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysProfili.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysProfili.Visible = true;
      this.BCtlsysProfili.Enabled = true;
      return default;
    }

    protected override void SetAttributes_Invio()
    {
      this.mbtDescrizioneRicerca.CtlNextFocus = this.BtnCerca.ClientID;
      this.BCtlsysProfili.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.BCtlsysProfili.SetAttributes_Other();
      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      BtnCerca.Click += BtnCerca_Click;
      BtnCerca.Invio += BtnCerca_Click;
      BtnSyncProfili.Click += BtnSyncProfili_Click;
      BtnSyncProfili.Invio += BtnSyncProfili_Click;

      CtlCommandBar.Nuovo += CtlCommandBar_Nuovo;
      CtlCommandBar.Elimina += CtlCommandBar_Elimina;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;
      CtlCommandBar.Stampa += CtlCommandBar_Stampa;
      DtgElenco.RowCommand += dtgElenco_RowCommand;
      DtgElenco.RowClick += dtgElenco_RowClick;
      DtgElenco.RowDataBound += DtgElenco_RowDataBound;

      base.SetAttributes_AddEvents();
    }

    private void BtnSyncProfili_Click(object sender, EventArgs e)
    {
      DB.ClearParameter();
      DB.AddParameter("@IDApplicazione", Config.IDApplicazione);
      DB.ExecuteNonQuery(K_SP_SYNCPROFILI_INTERNAWP, CommandType.StoredProcedure);

    }

    private void DtgElenco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BButton btnDel = null;

      if (BWebConfig.TipoApplicazione != BWebConfig.eTipoApplicazione.PosteRUO)
      {
        if (e.Row.RowType == DataControlRowType.Header)
        {
          BButton btn = (BButton)e.Row.FindControl("BtnNew");
          if (btn != null)
          {
            btn.Visible = false;
          }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          btnDel = (BButton)e.Row.FindControl("BtnDel");
          if (btnDel != null)
          {
            btnDel.Visible = false;
          }
        }
      }
    }

    protected override void LoadFilter()
    {
      // AGGIUNGO FILTRO PER Descrizione
      if (!string.IsNullOrEmpty(this.mbtDescrizioneRicerca.Text))
      {
        this.AddFilter("@Descrizione", this.mbtDescrizioneRicerca.Text, "Descrizione");
      }

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string GetPrefixUrlToExportXls()
    {
      return "";
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DTG

    protected override DataTable CreateDTEmpty()
    {
      var DT = new DataTable();
      DT.Columns.Add("ID");
      DT.Columns.Add("Descrizione");
      return DT;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override void NuovoRec()
    {
      this.BCtlsysProfili.NuovoRec();
    }
    protected override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysProfili.CambiaRec(Obj);
    }
    protected override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysProfili.ScriviRec(Obj);
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysProfiliFunzioni
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysProfilo", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysProfiliFunzioni_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void BtnCerca_Click(object sender, EventArgs e)
    {
      this.Cerca();
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA BARRA DI COMANDO

    private void CtlCommandBar_Nuovo()
    {
      this.Nuovo();
    }
    private void CtlCommandBar_Elimina()
    {
      if (!this.Elimina(new SqlParameter("@ID", this.BCtlsysProfili.mbtID.Text)))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        ((BsysUtenti)this.UtenteEntrato).WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysProfili.mbtID.Text + ";>> DELLA TABELLA sysProfili");
        this.Annulla();
      }
    }
    private void CtlCommandBar_Salva()
    {
      BsysProfili Obj = null;
      if (this.StatoDetails == BPageTableBase.eStatusDetails.NUOVO)
      {
        Obj = new BsysProfili(this.DB);
      }
      else
      {
        Obj = new BsysProfili(int.Parse(this.BCtlsysProfili.mbtID.Text), this.DB);
      }

      if (this.Salva(Obj))
      {
        this.Annulla();
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

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA

    private void dtgElenco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int ID = -1;
      int IndexRow = -1;
      BsysProfili obj = null;
      var switchExpr = e.CommandName.ToUpper();
      switch (switchExpr)
      {
        case "BNEW":
          {
            this.Nuovo();
            break;
          }

        case "BDELETE":
          {
            if (e.CommandArgument.ToString() != "")
              IndexRow = int.Parse(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = int.Parse(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            if (!this.Elimina(new SqlParameter("@ID", ID)))
            {
              this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
            }
            else
            {
              this.Annulla();
            }

            break;
          }

        case "BDELETEALL":
          {
            if (!this.EliminaAll())
            {
              this.MsgBox("Non è stato possibile eliminare tutte le righe!");
            }
            else
            {
              this.Annulla();
            }

            break;
          }

        case "BEDIT":
          {
            if (e.CommandArgument.ToString() != "")
              IndexRow = int.Parse(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = int.Parse(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysProfili(ID, this.DB);
            this.Modifica(obj);
            break;
          }

        case "BVIEW":
          {
            if (e.CommandArgument.ToString() != "")
              IndexRow = int.Parse(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = int.Parse(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysProfili(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }

    private void dtgElenco_RowClick(int RowIndex)
    {
      BsysProfili obj = null;
      if (RowIndex != -1)
      {
        // RECUPERO VALORE KEY DA DTG
        base.ID = this.DtgElenco.Rows[RowIndex].Cells[(int)eDTGElenco.ID].Text;
      }
      else
      {
        this.MsgBox("Non è stato possibile individuare la riga selezionata.");
        return;
      }

      obj = new BsysProfili(int.Parse(base.ID), this.DB);
      this.Modifica(obj);
    }

  } //END CLASS
} //END NAMESPACE