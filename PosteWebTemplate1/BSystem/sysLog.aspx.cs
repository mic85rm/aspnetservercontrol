// *****************************************************
// *** Classe generata con BStudio [Ver. 3.2.1] ***
// *****************************************************

using BArts.BData;
using BArts.BGlobal;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysLog : BPageTableBase
  {

    // DEFINIZIONE DATI

    private const string K_TBL = "sysLog";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";
    private const string K_SP_DELETEALL = "BSP_" + K_TBL + "_DELETEALL";

    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      Data,
      Origine,
      Messaggio,
      IDSysAccesso,
      IDSysSeverity
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysLog";
      this.CtlCommandBar.PageName = "Gestione Log";
      this.SP_ELENCO_SELECT = K_SP_SELECT;
      this.SP_ELENCO_DELETE = K_SP_DELETE;
      this.SP_ELENCO_DELETEALL = K_SP_DELETEALL;
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
      this.BCtlsysLog.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysLog.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysLog.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysLog.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysLog.Visible = true;
      this.BCtlsysLog.Enabled = true;
      return true;
    }

    protected override void SetAttributes_Invio()
    {
      this.mbtDataDalRicerca.CtlNextFocus = this.mbtDataAlRicerca.ClientID;
      this.mbtDataAlRicerca.CtlNextFocus = this.mbtOrigineRicerca.ClientID;
      this.mbtOrigineRicerca.CtlNextFocus = this.mbtMessaggioRicerca.ClientID;
      this.mbtMessaggioRicerca.CtlNextFocus = this.mbcIDSysSeverityRicerca.ClientID;
      this.mbcIDSysSeverityRicerca.CtlNextFocus = this.BtnCerca.ClientID;
      this.BCtlsysLog.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.mbcIDSysSeverityRicerca.Init(this.DB.Setting);
      this.mbcIDSysSeverityRicerca.Items.Insert(0, new ListItem("TUTTI", "-1"));
      this.mbtDataDalRicerca_CalendarExtender.PopupButtonID = this.mbtDataDalRicerca.HelpButtonClientID;
      this.mbtDataAlRicerca_CalendarExtender.PopupButtonID = this.mbtDataAlRicerca.HelpButtonClientID;
      this.BCtlsysLog.SetAttributes_Other();
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
      // AGGIUNGO FILTRO PER DataDal
      if (!string.IsNullOrEmpty(this.mbtDataDalRicerca.Text))
      {
        this.AddFilter("@DataDal", this.mbtDataDalRicerca.Text + " 00:00:00", "Data", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER DataAl
      if (!string.IsNullOrEmpty(this.mbtDataAlRicerca.Text))
      {
        this.AddFilter("@DataAl", this.mbtDataAlRicerca.Text + " 23:59:59", "Data", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER Origine
      if (!string.IsNullOrEmpty(this.mbtOrigineRicerca.Text))
      {
        this.AddFilter("@Origine", this.mbtOrigineRicerca.Text, "Origine");
      }
      // AGGIUNGO FILTRO PER Messaggio
      if (!string.IsNullOrEmpty(this.mbtMessaggioRicerca.Text))
      {
        this.AddFilter("@Messaggio", this.mbtMessaggioRicerca.Text, "Messaggio");
      }
      // AGGIUNGO FILTRO PER IDSysSeverity
      if ((this.mbcIDSysSeverityRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@IDSysSeverity", this.mbcIDSysSeverityRicerca.SelectedValue, "Sys Severity");
      }

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }

    protected override string ConvertValueToHelp(BItemField itm)
    {
      // CAMPO RICERCA Sys Severity
      if ((itm.Codice ?? "") == "@IDSysSeverity")
      {
        var vItm = this.mbcIDSysSeverityRicerca.Items.FindByValue(itm.Valore.ToString());
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

    // DEFINIZIONE FUNZIONI OVERRIDES DTG
    protected override DataTable CreateDTEmpty()
    {
      var DT = new DataTable();
      DT.Columns.Add("ID");
      DT.Columns.Add("IDSysAccesso");
      DT.Columns.Add("Data");
      DT.Columns.Add("Origine");
      DT.Columns.Add("Messaggio");
      DT.Columns.Add("IDSysSeverity");
      return DT;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override void NuovoRec()
    {
      this.BCtlsysLog.NuovoRec();
    }
    protected override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysLog.CambiaRec(Obj);
    }
    protected override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysLog.ScriviRec(Obj);
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
      if (!this.Elimina(new SqlParameter("@ID", this.BCtlsysLog.mbtID.Text)))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        BSysUtenteEntrato.WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysLog.mbtID.Text + ";>> DELLA TABELLA sysLog");
        this.Annulla();
      }
    }
    private void CtlCommandBar_Salva()
    {
      BsysLog Obj = null;
      if (this.StatoDetails == BPageTableBase.eStatusDetails.NUOVO)
      {
        Obj = new BsysLog(this.DB);
      }
      else
      {
        Obj = new BsysLog(BConvert.ToInt(this.BCtlsysLog.mbtID.Text), this.DB);
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
      BsysLog obj = null;
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
              IndexRow = BConvert.ToInt(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = BConvert.ToInt(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
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
              IndexRow = BConvert.ToInt(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = BConvert.ToInt(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysLog(ID, this.DB);
            this.Modifica(obj);
            break;
          }

        case "BVIEW":
          {
            if (e.CommandArgument.ToString() != "")
              IndexRow = BConvert.ToInt(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              // RECUPERO VALORE KEY DA DTG
              ID = BConvert.ToInt(this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text);
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysLog(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex)
    {
      int ID = -1;
      BsysLog obj = null;
      if (RowIndex != -1)
      {
        // RECUPERO VALORE KEY DA DTG
        ID = BConvert.ToInt(this.DtgElenco.Rows[RowIndex].Cells[(int)eDTGElenco.ID].Text);
      }
      else
      {
        this.MsgBox("Non è stato possibile individuare la riga selezionata.");
        return;
      }

      obj = new BsysLog(BConvert.ToInt(ID), this.DB);
      this.Visiona(obj);
    }

  } //END CLASS
} //END NAMESPACE