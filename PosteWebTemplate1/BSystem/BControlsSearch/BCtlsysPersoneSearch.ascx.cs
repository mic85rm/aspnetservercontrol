using BArts.BData;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlsysPersoneSearch : BWebControlSearchBase
  {
    // DEFINIZIONE EVENTI
    public event SelectedEventHandler Selected;
    public delegate void SelectedEventHandler(List<BsysPersone> l);

    // DEFINIZIONE DATI

    private const string K_TBL = "sysPersone";
    private const string K_SP_SEARCH = "BSP_" + K_TBL + "_SEARCH";

    public enum eDTGElenco : byte
    {
      BTN_SELECT,
      ID,
      CodiceFiscale,
      Nome,
      Cognome,
      DataNascita
    }

    // DEFINIZIONE METODI OVERRIDES
    protected override bool InitBControlSearchBase()
    {
      this.CtlDtgElenco = this.DtgElenco;
      this.CtlBPager = this.BDtgPager;
      this.Titolo = "Ricerca Persona";
      this.SP_SEARCH = K_SP_SEARCH;
      var BSet = new BSettingDatabase();
      BSet = this.DB.Setting.Clone();
      // BSet.NomeDatabase = "BIPoste" 'SE VUOI CAMBIARE DATABASE DECOMMENTA
      this.DB_SEARCH = new BConnection(BSet);
      this.FirstCtlRicerca = this.mbtCodiceFiscaleRicerca;
      this.MultiSelect = false;
      this.LockSearchFilterLeastOf = 0;
      this.CtlModalPopup = this.BmpSearch;
      this.RunSearchToLoad = false;
      this.DTElencoInSession = true;
      this.AllowPaging = true;
      return default;
    }

    protected override void SetAttributes_Invio()
    {
      this.mbtCodiceFiscaleRicerca.CtlNextFocus = this.mbtNomeRicerca.ClientID;
      this.mbtNomeRicerca.CtlNextFocus = this.mbtCognomeRicerca.ClientID;
      this.mbtCognomeRicerca.CtlNextFocus = this.mbtDataNascitaDalRicerca.ClientID;
      this.mbtDataNascitaDalRicerca.CtlNextFocus = this.mbtDataNascitaAlRicerca.ClientID;
      this.mbtDataNascitaAlRicerca.CtlNextFocus = this.BtnCerca.ClientID;
    }
    protected override void SetAttributes_Other()
    {
      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      BtnCerca.Click += BtnCerca_Click;
      BtnCerca.Invio += BtnCerca_Click;
      BmpSearch.Conferma += BmpSearch_Conferma;
      BmpSearch.Annulla += BmpSearch_Annulla;
      this.InternalShowExtender += CtlPersonaleAllSearch_InternalShowExtender;
      this.InternalSelected += CtlPersonaleAllSearch_InternalSelected;

      base.SetAttributes_AddEvents();
    }

    protected override void LoadFilter()
    {
      byte CountFilter = 0;
      // AGGIUNGO FILTRO PER CodiceFiscale
      if (!string.IsNullOrEmpty(this.mbtCodiceFiscaleRicerca.Text))
      {
        this.AddFilter("@CodiceFiscale", this.mbtCodiceFiscaleRicerca.Text, "Codice Fiscale");
        CountFilter += 1;
      }
      // AGGIUNGO FILTRO PER Nome
      if (!string.IsNullOrEmpty(this.mbtNomeRicerca.Text))
      {
        this.AddFilter("@Nome", this.mbtNomeRicerca.Text, "Nome");
        CountFilter += 1;
      }
      // AGGIUNGO FILTRO PER Cognome
      if (!string.IsNullOrEmpty(this.mbtCognomeRicerca.Text))
      {
        this.AddFilter("@Cognome", this.mbtCognomeRicerca.Text, "Cognome");
        CountFilter += 1;
      }
      // AGGIUNGO FILTRO PER DataNascitaDal
      if (!string.IsNullOrEmpty(this.mbtDataNascitaDalRicerca.Text))
      {
        this.AddFilter("@DataNascitaDal", this.mbtDataNascitaDalRicerca.Text + " 00:00:00", "Data Nascita", SqlDbType.DateTime);
        CountFilter += 1;
      }
      // AGGIUNGO FILTRO PER DataNascitaAl
      if (!string.IsNullOrEmpty(this.mbtDataNascitaAlRicerca.Text))
      {
        this.AddFilter("@DataNascitaAl", this.mbtDataNascitaAlRicerca.Text + " 23:59:59", "Data Nascita", SqlDbType.DateTime);
        CountFilter += 1;
      }

      // Me.LblTitoloRicerca.Text = "Filtri Impostati: " & MyBase.GetHelpFiltri
    }

    protected override DataTable CreateDTEmpty()
    {
      var DT = new DataTable();
      DT.Columns.Add("ID");
      DT.Columns.Add("CodiceFiscale");
      DT.Columns.Add("Nome");
      DT.Columns.Add("Cognome");
      DT.Columns.Add("DataNascita");
      return DT;
    }
    protected override BItemField GetNewItemField(GridViewRow row)
    {
      var itm = new BItemField();
      itm.Codice = row.Cells[(int)eDTGElenco.ID].Text;
      return itm;
    }
    protected override string GetItemFieldKey(GridViewRow row)
    {
      string Key = "";
      Key = row.Cells[(int)eDTGElenco.ID].Text;
      return Key;
    }

    // DEFINIZIONE METODI PUBLIC
    public bool ResetSearch()
    {
      if (this.DTElenco != null) this.DTElenco.Dispose();
      this.DTElenco = null;
      this.mbtCodiceFiscaleRicerca.Text = "";
      this.mbtNomeRicerca.Text = "";
      this.mbtCognomeRicerca.Text = "";
      this.mbtDataNascitaDalRicerca.Text = "";
      this.mbtDataNascitaAlRicerca.Text = "";

      this.CheckedList.Clear();
      this.BindEmpty();
      this.mbtCodiceFiscaleRicerca.Focus();
      return true;
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void BtnCerca_Click(object sender, EventArgs e)
    {
      this.Cerca();
      this.Show();
    }
    private void BmpSearch_Conferma()
    {
      this.Conferma();
    }
    private void BmpSearch_Annulla()
    {
      this.Hide();
    }

    private void CtlPersonaleAllSearch_InternalShowExtender()
    {
      this.Show();
    }
    private void CtlPersonaleAllSearch_InternalSelected(List<string> l)
    {
      var lB = new List<BsysPersone>();
      if (l != null && l.Count > 0)
      {
        lB = (from item in l
              select new BsysPersone(int.Parse(item), this.DB)).ToList();
      }

      Selected?.Invoke(lB);
    }


  } //END CLASS
} //END NAMESPACE