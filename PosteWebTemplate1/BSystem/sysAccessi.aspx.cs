// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.0] ***
// ************************************************

using BArts.BData;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysAccessi : BPageTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL = "sysAccessi";
    private const string K_SP_SELECT = "SSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";

    private const string K_TBL_sysAccessiOperazioni = "sysAccessiOperazioni";
    private const string K_SP_sysAccessiOperazioni_DELETE = "BSP_" + K_TBL_sysAccessiOperazioni + "_DELETEALL";


    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      DataAccesso,
      NomeComputer,
      OraFineLavoro,
      IDSysSistema
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysAccessi";
      this.CtlCommandBar.PageName = "Gestione Accessi";
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
      this.OnView_BtnNuovo_Visible = false;

      // INIT CONTROL BTABLEBASE
      this.BCtlsysAccessi.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysAccessi.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysAccessi.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysAccessi.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysAccessi.Visible = true;
      this.BCtlsysAccessi.Enabled = true;
      return default;
    }
    protected override void SetAttributes_Invio()
    {
      this.mbtDataAccessoDalRicerca.CtlNextFocus = this.mbtDataAccessoAlRicerca.ClientID;
      this.mbtDataAccessoAlRicerca.CtlNextFocus = this.mbtNomeComputerRicerca.ClientID;
      this.mbtNomeComputerRicerca.CtlNextFocus = this.mbcIDSysSistemaRicerca.ClientID;
      this.mbcIDSysSistemaRicerca.CtlNextFocus = this.BtnCerca.ClientID;
      this.BCtlsysAccessi.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.mbcIDSysSistemaRicerca.Init(this.DB.Setting);
      this.mbcIDSysSistemaRicerca.Items.Insert(0, new ListItem("TUTTI", "-1"));
      this.mbtDataAccessoDalRicerca_CalendarExtender.PopupButtonID = this.mbtDataAccessoDalRicerca.HelpButtonClientID;
      this.mbtDataAccessoAlRicerca_CalendarExtender.PopupButtonID = this.mbtDataAccessoAlRicerca.HelpButtonClientID;
      this.BCtlsysAccessi.SetAttributes_Other();
      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      BtnCerca.Click += BtnCerca_Click;
      BtnCerca.Invio += BtnCerca_Click;
      CtlCommandBar.Nuovo += CtlCommandBar_Nuovo;
      CtlCommandBar.Elimina += CtlCommandBar_Elimina;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;
      CtlCommandBar.Stampa += CtlCommandBar_Stampa;
      DtgElenco.RowCommand += dtgElenco_RowCommand;
      DtgElenco.RowClick += dtgElenco_RowClick;

      base.SetAttributes_AddEvents();
    }
    protected override void LoadFilter()
    {
      // AGGIUNGO FILTRO PER DataAccessoDal
      if (!string.IsNullOrEmpty(this.mbtDataAccessoDalRicerca.Text))
      {
        this.AddFilter("@DataAccessoDal", this.mbtDataAccessoDalRicerca.Text + " 00:00:00", "Data Accesso", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER DataAccessoAl
      if (!string.IsNullOrEmpty(this.mbtDataAccessoAlRicerca.Text))
      {
        this.AddFilter("@DataAccessoAl", this.mbtDataAccessoAlRicerca.Text + " 23:59:59", "Data Accesso", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER NomeComputer
      if (!string.IsNullOrEmpty(this.mbtNomeComputerRicerca.Text))
      {
        this.AddFilter("@NomeComputer", this.mbtNomeComputerRicerca.Text, "Nome Computer");
      }
      // AGGIUNGO FILTRO PER IDSysSistema
      if ((this.mbcIDSysSistemaRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@IDSysSistema", this.mbcIDSysSistemaRicerca.SelectedValue, "Sistema");
      }

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string ConvertValueToHelp(BItemField itm)
    {
      // CAMPO RICERCA Sistema
      if (itm.Codice == "@IDSysSistema")
      {
        ListItem vItm = this.mbcIDSysSistemaRicerca.Items.FindByValue(itm.Valore.ToString());
        if (vItm != null)
        {
          return vItm.Text;
        }
        else
        {
          return itm.Valore.ToString();
        }
      }
      else
      {
        return base.ConvertValueToHelp(itm);
      }
    }
    protected override DataTable CreateDTEmpty()
    {
      var DT = new DataTable();
      DT.Columns.Add("ID");
      DT.Columns.Add("DataAccesso");
      DT.Columns.Add("NomeComputer");
      DT.Columns.Add("OraFineLavoro");
      DT.Columns.Add("IDSysSistema");
      return DT;
    }
    protected override string GetPrefixUrlToExportXls()
    {
      return "";
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE

    protected override void NuovoRec()
    {
      this.BCtlsysAccessi.NuovoRec();
    }
    protected override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysAccessi.CambiaRec(Obj);
    }
    protected override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysAccessi.ScriviRec(Obj);
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysAccessiOperazioni
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysAccesso", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysAccessiOperazioni_DELETE, CommandType.StoredProcedure);
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
      if (!this.Elimina(new SqlParameter("@ID", this.BCtlsysAccessi.mbtID.Text)))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        ((BsysUtenti)this.UtenteEntrato).WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysAccessi.mbtID.Text + ";>> DELLA TABELLA sysAccessi");
        this.Annulla();
      }
    }
    private void CtlCommandBar_Salva()
    {
      BsysAccessi Obj = null;
      if (this.StatoDetails == BPageTableBase.eStatusDetails.NUOVO)
      {
        Obj = new BsysAccessi(this.DB);
      }
      else
      {
        Obj = new BsysAccessi(int.Parse(this.BCtlsysAccessi.mbtID.Text), this.DB);
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
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA
    private void dtgElenco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int ID = -1;
      int IndexRow = -1;
      BsysAccessi obj = null;
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

            obj = new BsysAccessi(ID, this.DB);
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

            obj = new BsysAccessi(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex)
    {
      BsysAccessi obj = null;
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

      obj = new BsysAccessi(int.Parse(base.ID), this.DB);
      this.Visiona(obj);
    }

  } //END CLASS
} //END NAMESPACE