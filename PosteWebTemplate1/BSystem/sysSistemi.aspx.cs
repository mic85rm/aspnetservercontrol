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
  public partial class sysSistemi : BPageTableBase
  {

    //DEFINIZIONE DATI
    private const string K_TBL = "sysSistemi";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";

    private const string K_TBL_sysSistemiAttributi = "sysSistemiAttributi";
    private const string K_SP_sysSistemiAttributi_DELETE = "BSP_" + K_TBL_sysSistemiAttributi + "_DELETEALL";

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
      this.PageName = "sysSistemi";
      this.CtlCommandBar.PageName = "Gestione Sistemi";
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
      this.BCtlsysSistemi.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysSistemi.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysSistemi.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysSistemi.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysSistemi.Visible = true;
      this.BCtlsysSistemi.Enabled = true;
      return true;
    }

    protected override void SetAttributes_Invio()
    {
      mbtDescrizioneRicerca.CtlNextFocus = BtnCerca.ClientID;
      this.BCtlsysSistemi.SetAttributes_Invio();

      base.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {

      this.BCtlsysSistemi.SetAttributes_Other();

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
      BCtlsysSistemi.NuovoRec();
    }
    protected override bool CambiaRec(BBaseObject Obj)
    {
      return BCtlsysSistemi.CambiaRec(Obj);
    }
    protected override BBaseObject ScriviRec(BBaseObject Obj)
    {
      return BCtlsysSistemi.ScriviRec(Obj);
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      //RIMOZIONE RECORD RELAZIONATI sysSistemiAttributi
      DB.ClearParameter();
      DB.AddParameter("@IDSysSistema", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_sysSistemiAttributi_DELETE, CommandType.StoredProcedure);

      return base.DeleteRowsRelation(ParamsKey);
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
new SqlParameter("@ID", this.BCtlsysSistemi.mbtID.Text)
      ))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        BSysUtenteEntrato.WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysSistemi.mbtID.Text + ";>> DELLA TABELLA sysSistemi");
        this.Annulla();
      }
    }

    private void CtlCommandBar_Salva() //Handles CtlCommandBar.Salva
    {
      BsysSistemi Obj = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
        Obj = new BsysSistemi(this.DB);
      else
        Obj = new BsysSistemi(BConvert.ToInt(BCtlsysSistemi.mbtID.Text), this.DB);
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
      int ID = -1;

      int IndexRow = -1;
      BsysSistemi obj = null;
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
              ID = BConvert.ToInt(DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text);

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
              ID = BConvert.ToInt(DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text);

            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            obj = new BsysSistemi(ID, this.DB);
            this.Modifica(obj);
            break;
          }
        case "BVIEW":
          {
            if (e.CommandArgument.ToString() != "") IndexRow = BConvert.ToInt(e.CommandArgument);
            if (IndexRow != -1)
            {
              //RECUPERO VALORE KEY DA DTG
              ID = BConvert.ToInt(DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text);

            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            obj = new BsysSistemi(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex) //Handles dtgElenco.RowClick
    {
      int ID = -1;

      int IndexRow = RowIndex;
      BsysSistemi obj = null;
      if (IndexRow != -1)
      {
        //RECUPERO VALORE KEY DA DTG
        ID = BConvert.ToInt(DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text);

      }
      else
      {
        this.MsgBox("Non è stato possibile individuare la riga selezionata.");
        return;
      }
      obj = new BsysSistemi(ID, this.DB);
      this.Modifica(obj);
    }
  } //END CLASS
} //END NAMESPACE
