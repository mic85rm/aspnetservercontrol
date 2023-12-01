// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.2] ***
// ************************************************

using BArts.BData;
using BArts.BGlobal;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysPersone : BPageTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL = "sysPersone";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";

    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      CodiceFiscale,
      Nome,
      Cognome,
      DataNascita,
      Sesso,
      Telefono,
      Celluare
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysPersone";
      this.CtlCommandBar.PageName = "Gestione Persone";
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

      // INIT CONTROL BTABLEBASE
      this.BCtlsysPersone.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysPersone.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysPersone.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysPersone.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysPersone.Visible = true;
      this.BCtlsysPersone.Enabled = true;
      return default;
    }

    protected override void SetAttributes_Invio()
    {
      this.mbtCodiceFiscaleRicerca.CtlNextFocus = this.mbtNomeRicerca.ClientID;
      this.mbtNomeRicerca.CtlNextFocus = this.mbtCognomeRicerca.ClientID;
      this.mbtCognomeRicerca.CtlNextFocus = this.mbtDataNascitaDalRicerca.ClientID;
      this.mbtDataNascitaDalRicerca.CtlNextFocus = this.mbtDataNascitaAlRicerca.ClientID;
      this.mbtDataNascitaAlRicerca.CtlNextFocus = this.mbcSessoRicerca.ClientID;
      this.mbcSessoRicerca.CtlNextFocus = this.BtnCerca.ClientID;
      this.BCtlsysPersone.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.mbtDataNascitaDalRicerca_CalendarExtender.PopupButtonID = this.mbtDataNascitaDalRicerca.HelpButtonClientID;
      this.mbtDataNascitaAlRicerca_CalendarExtender.PopupButtonID = this.mbtDataNascitaAlRicerca.HelpButtonClientID;
      this.BCtlsysPersone.SetAttributes_Other();
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
    protected override string GetPrefixUrlToExportXls()
    {
      return "";
    }

    protected override void LoadFilter()
    {
      // AGGIUNGO FILTRO PER CodiceFiscale
      if (!string.IsNullOrEmpty(this.mbtCodiceFiscaleRicerca.Text))
      {
        this.AddFilter("@CodiceFiscale", this.mbtCodiceFiscaleRicerca.Text, "Codice Fiscale");
      }
      // AGGIUNGO FILTRO PER Nome
      if (!string.IsNullOrEmpty(this.mbtNomeRicerca.Text))
      {
        this.AddFilter("@Nome", this.mbtNomeRicerca.Text, "Nome");
      }
      // AGGIUNGO FILTRO PER Cognome
      if (!string.IsNullOrEmpty(this.mbtCognomeRicerca.Text))
      {
        this.AddFilter("@Cognome", this.mbtCognomeRicerca.Text, "Cognome");
      }
      // AGGIUNGO FILTRO PER DataNascitaDal
      if (!string.IsNullOrEmpty(this.mbtDataNascitaDalRicerca.Text))
      {
        this.AddFilter("@DataNascitaDal", this.mbtDataNascitaDalRicerca.Text + " 00:00:00", "Data Nascita", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER DataNascitaAl
      if (!string.IsNullOrEmpty(this.mbtDataNascitaAlRicerca.Text))
      {
        this.AddFilter("@DataNascitaAl", this.mbtDataNascitaAlRicerca.Text + " 23:59:59", "Data Nascita", SqlDbType.DateTime);
      }
      // AGGIUNGO FILTRO PER Sesso
      if ((this.mbcSessoRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@Sesso", this.mbcSessoRicerca.SelectedValue, "Sesso", SqlDbType.Bit);
      }

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string ConvertValueToHelp(BItemField itm)
    {
      // CAMPO RICERCA Sys Sistema
      if ((itm.Codice ?? "") == "@Sesso")
      {
        var vItm = this.mbcSessoRicerca.Items.FindByValue(itm.Valore.ToString());
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
      DT.Columns.Add("CodiceFiscale");
      DT.Columns.Add("Nome");
      DT.Columns.Add("Cognome");
      DT.Columns.Add("DataNascita");
      DT.Columns.Add("Sesso");
      DT.Columns.Add("Telefono");
      DT.Columns.Add("Celluare");
      return DT;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override void NuovoRec()
    {
      this.BCtlsysPersone.NuovoRec();
    }
    protected override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysPersone.CambiaRec(Obj);
    }
    protected override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysPersone.ScriviRec(Obj);
    }

    protected override bool GotoDetails(string id)
    {
      BsysPersone obj = null;
      obj = new BsysPersone(int.Parse(id), this.DB);
      return this.Modifica(obj);
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
      if (!this.Elimina(new SqlParameter("@ID", this.BCtlsysPersone.mbtID.Text)))
      {
      }
      // Me.MsgBox("Non è stato possibile eliminare la riga selezionata!")
      else
      {
        ((BsysUtenti)this.UtenteEntrato).WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysPersone.mbtID.Text + ";>> DELLA TABELLA sysPersone");
        this.Annulla();
      }
    }
    private void CtlCommandBar_Salva()
    {
      BsysPersone Obj = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
      {
        Obj = new BsysPersone(this.DB);
      }
      else
      {
        Obj = new BsysPersone(BConvert.ToInt(this.BCtlsysPersone.mbtID.Text), this.DB);
      }

      if (this.Salva(Obj))
      {
        this.Annulla();
      }
      else
      {
        if (!this.BCtlsysPersone.IsCheckBeforeUpdateFailled) this.MsgBox("Salvataggio fallito.");
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
      BsysPersone obj = null;
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
            }
            // Me.MsgBox("Non è stato possibile eliminare la riga selezionata!")
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

            obj = new BsysPersone(ID, this.DB);
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

            obj = new BsysPersone(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex)
    {
      BsysPersone obj = null;
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

      obj = new BsysPersone(int.Parse(base.ID), this.DB);
      this.Modifica(obj);
    }

  } //END CLASS
} //END NAMESPACE