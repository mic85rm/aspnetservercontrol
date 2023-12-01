//************************************************
//*** Classe generata con BStudio [Ver. 3.2.9] ***
//************************************************

using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysRegioni : BPageTableBase
  {

    //DEFINIZIONE DATI
    private const string K_TBL = "sysRegioni";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";


    private enum eDTGElenco
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      Descrizione

    }

    //DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysRegioni";
      this.CtlCommandBar.PageName = "Gestione Regioni";
      this.SP_ELENCO_SELECT = K_SP_SELECT;
      this.SP_ELENCO_DELETE = K_SP_DELETE;

      this.CtlPnlRicerca = PnlRicerca;
      this.CtlPnlElenco = PnlElenco;
      this.CtlPnlDettaglio = PnlDettaglio;
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

      //INIT CONTROL BTABLEBASE
      this.BCtlsysRegioni.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysRegioni.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysRegioni.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysRegioni.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysRegioni.Visible = true;
      this.BCtlsysRegioni.Enabled = true;
      return true;
    }

    protected override void SetAttributes_Invio()
    {
      mbtDescrizioneRicerca.CtlNextFocus = BtnCerca.ClientID;
      this.BCtlsysRegioni.SetAttributes_Invio();

      base.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.BCtlsysRegioni.SetAttributes_Other();

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
      //AGGIUNGO FILTRO PER Descrizione
      if (!string.IsNullOrEmpty(mbtDescrizioneRicerca.Text))
        this.AddFilter("@Descrizione", mbtDescrizioneRicerca.Text, "Descrizione");

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string GetPrefixUrlToExportXls()
    {
      return "";
    }

    //DEFINIZIONE FUNZIONI OVERRIDES DTG
    protected override DataTable CreateDTEmpty()
    {
      DataTable DT = new DataTable();
      DT.Columns.Add("ID");
      DT.Columns.Add("Descrizione");

      return DT;
    }

    //DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override void NuovoRec()
    {
      BCtlsysRegioni.NuovoRec();
    }
    protected override bool CambiaRec(BBaseObject Obj)
    {
      return BCtlsysRegioni.CambiaRec(Obj);
    }
    protected override BBaseObject ScriviRec(BBaseObject Obj)
    {
      return BCtlsysRegioni.ScriviRec(Obj);
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void BtnCerca_Click(Object sender, EventArgs e) // Handles BtnCerca.Click, BtnCerca.Invio
    {
      this.Cerca();
    }

    //DEFINIZIONE EVENTI INTERCETTATI SULLA BARRA DI COMANDO
    private void CtlCommandBar_Nuovo() // Handles CtlCommandBar.Nuovo
    {
      this.Nuovo();
    }
    private void CtlCommandBar_Elimina() //Handles CtlCommandBar.Elimina
    {
      if (!this.Elimina(
          new SqlParameter("@ID", this.BCtlsysRegioni.mbtID.Text)
      ))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        BSysUtenteEntrato.WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysRegioni.mbtID.Text + ";>> DELLA TABELLA sysRegioni");
        this.Annulla();
      }
    }

    private void CtlCommandBar_Salva() //Handles CtlCommandBar.Salva
    {
      BsysRegioni Obj = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
        Obj = new BsysRegioni(this.DB);
      else
        Obj = new BsysRegioni(BCtlsysRegioni.mbtID.Text, this.DB);
      if (this.Salva(Obj))
        this.Annulla();
      else
        this.MsgBox("Salvataggio fallito.");
      Obj = null;
    }
    private void CtlCommandBar_Annulla() //Handles CtlCommandBar.Annulla
    {
      this.Annulla();
    }
    private void CtlCommandBar_Stampa() //Handles CtlCommandBar.Stampa
    {
      //ADD CODE TO PRINT
    }

    //DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA
    private void dtgElenco_RowCommand(Object sender, GridViewCommandEventArgs e) //Handles dtgElenco.RowCommand
    {
      string ID = "";

      int IndexRow = -1;
      BsysRegioni obj = null;
      switch (e.CommandName.ToUpper())
      {
        case "BNEW":
          {
            this.Nuovo();
            break;
          }
        case "BDELETE":
          {
            if (e.CommandArgument.ToString() != "") IndexRow = BConvert.ToInt(e.CommandArgument);
            if (IndexRow != -1)
            {
              //RECUPERO VALORE KEY DA DTG
              ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;

            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            if (!this.Elimina(
new SqlParameter("@ID", ID)
            ))
              this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
            else
              this.Annulla();
            break;
          }
        case "BDELETEALL":
          {
            if (!this.EliminaAll())
              this.MsgBox("Non è stato possibile eliminare tutte le righe!");
            else
              this.Annulla();
            break;
          }
        case "BEDIT":
          {
            if (e.CommandArgument.ToString() != "") IndexRow = BConvert.ToInt(e.CommandArgument);
            if (IndexRow != -1)
            {
              //RECUPERO VALORE KEY DA DTG
              ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;

            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            obj = new BsysRegioni(ID, this.DB);
            this.Modifica(obj);
            break;
          }
        case "BVIEW":
          {
            if (e.CommandArgument.ToString() != "") IndexRow = BConvert.ToInt(e.CommandArgument);
            if (IndexRow != -1)
            {
              //RECUPERO VALORE KEY DA DTG
              ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;

            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            obj = new BsysRegioni(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex) //Handles dtgElenco.RowClick
    {
      string ID = "";

      int IndexRow = RowIndex;
      BsysRegioni obj = null;
      if (IndexRow != -1)
      {
        //RECUPERO VALORE KEY DA DTG
        ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;

      }
      else
      {
        this.MsgBox("Non è stato possibile individuare la riga selezionata.");
        return;
      }
      obj = new BsysRegioni(ID, this.DB);
      this.Modifica(obj);
    }
  } //END CLASS
} //END NAMESPACE
