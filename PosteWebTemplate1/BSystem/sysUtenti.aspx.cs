// *****************************************************
// *** Classe generata con BStudio 2017 [Ver. 3.0.4] ***
// *****************************************************

using BArts.BData;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysUtenti : BPageTableBase
  {

    // DEFINIZIONE DATI

    private const string K_TBL = "sysUtenti";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SEARCH";
    private const string K_SP_SELECTPERSONE = "BSP_" + K_TBL + "Personale_SEARCH";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";
    private const string K_TBL_sysUtentiProfili = "sysUtentiProfili";
    private const string K_SP_sysUtentiProfili_DELETE = "BSP_" + K_TBL_sysUtentiProfili + "_DELETEALL";

    private enum eDTGElenco : byte
    {
      BTN_EDIT,
      BTN_DELETE,
      ID,
      IDSysSistema,
      IDSysProfilo,
      IDPersona,
      Dominio,
      Username,
      Attivo
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysUtenti";
      this.CtlCommandBar.PageName = "Gestione Utenti";
      this.SP_ELENCO_SELECT = K_SP_SELECTPERSONE;
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
      this.BCtlsysUtenti.CtlBtnElimina = this.CtlCommandBar.CtlBtnElimina;
      this.BCtlsysUtenti.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlsysUtenti.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlsysUtenti.CtlBtnStampa = this.CtlCommandBar.CtlBtnStampa;
      this.BCtlsysUtenti.Visible = true;
      this.BCtlsysUtenti.Enabled = true;
      return default;
    }

    protected override void SetAttributes_Invio()
    {
      this.mbtIDRicerca.CtlNextFocus = this.mbcIDSysSistemaRicerca.ClientID;
      this.mbcIDSysSistemaRicerca.CtlNextFocus = this.mbcIDSysProfiloRicerca.ClientID;
      this.mbcIDSysProfiloRicerca.CtlNextFocus = this.mbcIDSysPolicyPwdRicerca.ClientID;
      this.mbcIDSysPolicyPwdRicerca.CtlNextFocus = this.mbtDominioRicerca.ClientID;
      this.mbtDominioRicerca.CtlNextFocus = this.mbtUsernameRicerca.ClientID;
      this.mbtUsernameRicerca.CtlNextFocus = this.mbtPersonaRicerca.ClientID;
      this.mbtPersonaRicerca.CtlNextFocus = this.BtnCerca.ClientID;
      this.BCtlsysUtenti.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.mbcIDSysSistemaRicerca.Init(this.DB.Setting);
      this.mbcIDSysSistemaRicerca.Items.Insert(0, new ListItem("TUTTI", "-1"));
      this.mbcIDSysProfiloRicerca.Init(this.DB.Setting);
      this.mbcIDSysProfiloRicerca.Items.Insert(0, new ListItem("TUTTI", "-1"));
      this.mbcIDSysPolicyPwdRicerca.Init(this.DB.Setting);
      this.mbcIDSysPolicyPwdRicerca.Items.Insert(0, new ListItem("TUTTI", "-1"));
      this.BCtlsysUtenti.SetAttributes_Other();
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
      // AGGIUNGO FILTRO PER ID
      if (!string.IsNullOrEmpty(this.mbtIDRicerca.Text))
      {
        this.AddFilter("@ID", this.mbtIDRicerca.Text, "ID");
      }
      // AGGIUNGO FILTRO PER IDSysSistema
      if ((this.mbcIDSysSistemaRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@IDSysSistema", this.mbcIDSysSistemaRicerca.SelectedValue, "Sistema");
      }
      // AGGIUNGO FILTRO PER IDSysProfilo
      if ((this.mbcIDSysProfiloRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@IDSysProfilo", this.mbcIDSysProfiloRicerca.SelectedValue, "Profilo");
      }
      // AGGIUNGO FILTRO PER IDSysPolicyPwd
      if ((this.mbcIDSysPolicyPwdRicerca.SelectedValue ?? "") != "-1")
      {
        this.AddFilter("@IDSysPolicyPwd", this.mbcIDSysPolicyPwdRicerca.SelectedValue, "Policy Pwd");
      }
      // AGGIUNGO FILTRO PER Dominio
      if (!string.IsNullOrEmpty(this.mbtDominioRicerca.Text))
      {
        this.AddFilter("@Dominio", this.mbtDominioRicerca.Text, "Dominio");
      }
      // AGGIUNGO FILTRO PER Username
      if (!string.IsNullOrEmpty(this.mbtUsernameRicerca.Text))
      {
        this.AddFilter("@Username", this.mbtUsernameRicerca.Text, "Username");
      }
      // AGGIUNGO FILTRO PER Persona
      if (!string.IsNullOrEmpty(this.mbtPersonaRicerca.Text))
      {
        this.AddFilter("@Persona", this.mbtPersonaRicerca.Text, "Nominativo");
      }

      if (this.UtenteEntrato != null && !this.UtenteEntrato.Developer)
      {
        this.AddFilter("@IDUtenteEntrato", ((BsysUtenti)base.UtenteEntrato).ID, "");
      }

      this.bcpRicerca.Titolo = "Ricerca: " + base.GetHelpFiltri();
    }
    protected override string ConvertValueToHelp(BItemField itm)
    {
      // CAMPO RICERCA Sys Sistema
      if ((itm.Codice ?? "") == "@IDSysSistema")
      {
        var vItm = this.mbcIDSysSistemaRicerca.Items.FindByValue(itm.Valore.ToString());
        if (vItm != null)
        {
          return vItm.Text;
        }
        else
        {
          return itm.Valore.ToString();
        }

      }

      // CAMPO RICERCA Sys Profilo
      if ((itm.Codice ?? "") == "@IDSysProfilo")
      {
        var vItm = this.mbcIDSysProfiloRicerca.Items.FindByValue(itm.Valore.ToString());
        if (vItm != null)
        {
          return vItm.Text;
        }
        else
        {
          return itm.Valore.ToString();
        }
      }

      // CAMPO RICERCA Sys Policy Pwd
      if ((itm.Codice ?? "") == "@IDSysPolicyPwd")
      {
        var vItm = this.mbcIDSysPolicyPwdRicerca.Items.FindByValue(itm.Valore.ToString());
        if (vItm != null)
        {
          return vItm.Text;
        }
        else
        {
          return itm.Valore.ToString();
        }

      }

      return base.ConvertValueToHelp(itm);
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
      DT.Columns.Add("IDSysSistema");
      DT.Columns.Add("IDSysProfilo");
      DT.Columns.Add("IDPersona");
      DT.Columns.Add("Dominio");
      DT.Columns.Add("Username");
      DT.Columns.Add("Attivo");
      return DT;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override void NuovoRec()
    {
      this.BCtlsysUtenti.NuovoRec();
    }
    protected override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysUtenti.CambiaRec(Obj);
    }
    protected override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      return this.BCtlsysUtenti.ScriviRec(Obj);
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysUtentiProfili
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysUtente", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysUtentiProfili_DELETE, CommandType.StoredProcedure);
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
      if (!this.Elimina(new SqlParameter("@ID", this.BCtlsysUtenti.mbtID.Text)))
      {
        this.MsgBox("Non è stato possibile eliminare la riga selezionata!");
      }
      else
      {
        ((BsysUtenti)this.UtenteEntrato).WriteOperation("RIMOZIONE DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + this.BCtlsysUtenti.mbtID.Text + ";>> DELLA TABELLA sysUtenti");
        this.Annulla();
      }
    }
    private void CtlCommandBar_Salva()
    {
      BsysUtenti Obj = null;
      if (this.StatoDetails == BPageTableBase.eStatusDetails.NUOVO)
      {
        Obj = new BsysUtenti(this.DB);
      }
      else
      {
        Obj = new BsysUtenti(this.BCtlsysUtenti.mbtID.Text, this.DB);
      }

      if (this.Salva(Obj))
      {
        this.ShowToast("Salvataggio effettuato.");
        this.Annulla();
      }
      else if (this.RetValueCheckBeforeUpdate)
        this.MsgBox("Salvataggio fallito.");
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
      string ID = "";
      int IndexRow = -1;
      BsysUtenti obj = null;
      if (this.DB == null)
        return;
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
              ID = this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text;
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
              ID = this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text;
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysUtenti(ID, this.DB);
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
              ID = this.DtgElenco.Rows[IndexRow].Cells[(int)eDTGElenco.ID].Text;
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
              return;
            }

            obj = new BsysUtenti(ID, this.DB);
            this.Visiona(obj);
            break;
          }
      }
    }
    private void dtgElenco_RowClick(int RowIndex)
    {
      BsysUtenti obj = null;
      if (this.DB == null)
        return;
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

      obj = new BsysUtenti(base.ID, this.DB);
      this.Modifica(obj);
    }

  } //END CLASS
} //END NAMESPACE