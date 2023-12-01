//************************************************
//*** Classe generata con BStudio [Ver. 3.2.9] ***
//************************************************

using BArts.BGlobal;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysAccediCome : BPageViewBase
  {
    // DEFINIZIONE DATI
    public enum eDTGElenco
    {
      BTN_SELECT,
      ID,
      DescrizioneSistema,
      NomePersona,
      CognomePersona,
      CodiceFiscalePersona,
      DescrizioneProfilo
    }

    //DEFINIZIONE DATI
    private const string K_SP_SELECT = "BSP_sysAccediCome_SEARCH";

    //DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBViewPage()
    {
      this.PageName = "sysAccediCome";
      this.CtlCommandBar.PageName = "Accedi come altro utente";
      this.SP_ELENCO_SELECT = K_SP_SELECT;

      this.CtlPnlRicerca = PnlRicerca;
      this.CtlPnlElenco = PnlElenco;
      this.CtlDtgElenco = this.DtgElenco;
      this.CtlBPager = this.BDtgPager;

      this.CtlCommandBar.CtlBtnAnnulla.Visible = false;
      this.CtlCommandBar.CtlBtnElimina.Visible = false;
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnSalva.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;

      this.RunSearchToLoad = true;
      this.DTElencoInSession = false;
      this.AllowPaging = true;

      return true;
    }

    protected override void SetAttributes_Invio()
    {
      mbtIDUtenteRicerca.CtlNextFocus = mbtNomeRicerca.ClientID;
      mbtNomeRicerca.CtlNextFocus = mbtCognomeRicerca.ClientID;
      mbtCognomeRicerca.CtlNextFocus = BtnCerca.ClientID;

      base.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {

      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      BtnCerca.Click += BtnCerca_Click;
      BtnCerca.Invio += BtnCerca_Click;

      DtgElenco.RowCommand += dtgElenco_RowCommand;
      DtgElenco.RowClick += dtgElenco_RowClick;
      base.SetAttributes_AddEvents();
    }

    protected override void LoadFilter()
    {
      //AGGIUNGO FILTRO PER Descrizione
      if (!string.IsNullOrEmpty(mbtIDUtenteRicerca.Text))
        this.AddFilter("@IDUtente", mbtIDUtenteRicerca.Text, "ID Utente");
      if (!string.IsNullOrEmpty(mbtCognomeRicerca.Text))
        this.AddFilter("@Cognome", mbtCognomeRicerca.Text, "Cognome");
      if (!string.IsNullOrEmpty(mbtNomeRicerca.Text))
        this.AddFilter("@Nome", mbtNomeRicerca.Text, "Nome");

      if (BSysUtenteEntrato.IDSysSistema != -1)
        this.AddFilter("@IDSysSistema", BConvert.ToString(BSysUtenteEntrato.IDSysSistema, "-1"), "");
      this.AddFilter("@IDUtenteEntrato", BConvert.ToString(BSysUtenteEntrato.ID, "-1"), "");

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string GetPrefixUrlToExportXls()
    {
      return "";
    }
    protected override DataTable CreateDTEmpty()
    {
      DataTable DT = new DataTable();
      DT.Columns.Add("IDUtente");
      DT.Columns.Add("DescrizioneSistema");
      DT.Columns.Add("NomePersona");
      DT.Columns.Add("CognomePersona");
      DT.Columns.Add("CodiceFiscalePersona");
      DT.Columns.Add("DescrizioneProfilo");

      return DT;
    }

    protected override void BPage_Load(object sender, EventArgs e)
    {

      if (!this.IsPostBack && this.UtenteEntrato.UtentePadre != null)
      {
        this.ShowMessagePage("Prima di poter accedere con un altro utente, è necessario disconnettersi.");
      }
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private bool AccediCome(string IDUtente)
    {
      BUtenti NewUser = new BUtenti(IDUtente, DB);
      if (NewUser != null && !NewUser.IsNothing)
      {
        NewUser.WriteEntryAccediCome(BSysUtenteEntrato, Request.UserHostAddress, Request.UserHostName);

        // Faccio diventare L'Utente Padre l'utente che si è loggato alla login
        Session[ModConstantList.K_SE_SYSUTENTEENTRATO] = NewUser;

        // Assegno all'utente Padre l'utente loggato
        UtenteEntrato.UtentePadre = NewUser;

        this.ShowToast("Accesso con utente " + NewUser.Username + " effettuato correttamente.");
        BRedirect(ModConstantList.K_PAGE_HOME);
        return true;
      }
      else
      {
        return false;
      }
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void BtnCerca_Click(Object sender, EventArgs e)
    {
      this.Cerca();
    }

    //DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA
    private void dtgElenco_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
      string ID = "";
      int IndexRow = -1;
      switch (e.CommandName.ToUpper())
      {
        case "BSELECT":
          {
            if (e.CommandArgument.ToString() != "") IndexRow = BConvert.ToInt(e.CommandArgument);
            if (IndexRow != -1)
            {
              //RECUPERO VALORE KEY DA DTG
              ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;
              if (!AccediCome(ID)) this.MsgBox("Accesso non riuscito.");
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex)
    {
      string ID = "";
      int IndexRow = RowIndex;
      if (IndexRow != -1)
      {
        //RECUPERO VALORE KEY DA DTG
        ID = DtgElenco.Rows[IndexRow].Cells[BConvert.ToInt(eDTGElenco.ID)].Text;
        if (!AccediCome(ID)) this.MsgBox("Accesso non riuscito.");
      }
      else
      {
        this.MsgBox("Non è stato possibile individuare la riga selezionata.");
        return;
      }
    }


  } //END CLASS
} //END NAMESPACE