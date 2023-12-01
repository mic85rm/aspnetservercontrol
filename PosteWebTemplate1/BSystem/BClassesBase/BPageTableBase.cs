using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Interop;

namespace PosteWebTemplate1
{
  public abstract class BPageTableBase : BPageBase
  {
    public BPageTableBase()
    {
      // DEFINIZIONE ATTACH EVENTI 
      this.AttachCommand += BPageTableBase_AttachCommand;
    }

    // DEFINIZIONE ENUMERATIVI
    protected enum eStatusPage : byte
    {
      ELENCO,
      DETTAGLIO
    }
    protected enum eStatusDetails : byte
    {
      NUOVO,
      VISIONE,
      MODIFICA
    }

    //DEFINIZIONE DATI
    public bool RetValueCheckBeforeUpdate = true;

    // DEFINIZIONE EVENTI
    public event OnInitBeforeEventHandler OnInitBefore;
    public delegate void OnInitBeforeEventHandler(object sender, EventArgs e);

    public event OnInitAfterEventHandler OnInitAfter;
    public delegate void OnInitAfterEventHandler(object sender, EventArgs e);

    public event OnLoadBeforeEventHandler OnLoadBefore;
    public delegate void OnLoadBeforeEventHandler(object sender, EventArgs e);

    public event OnLoadAfterEventHandler OnLoadAfter;
    public delegate void OnLoadAfterEventHandler(object sender, EventArgs e);


    // DEFINIZIONE PROPRIETA' PROTECTED
    #region protected eStatusPage Stato
    private string K_VS_STATO = ".Stato";
    protected eStatusPage Stato
    {
      get
      {
        return (eStatusPage)this.ViewState[PageName + K_VS_STATO];
      }
      set
      {
        this.ViewState[PageName + K_VS_STATO] = value;
      }
    }
    #endregion
    #region protected eStatusDetails StatoDetails
    private string K_VS_STATODETAILS = ".StatoDetails";
    protected eStatusDetails StatoDetails
    {
      get
      {
        return (eStatusDetails)this.ViewState[PageName + K_VS_STATODETAILS];
      }

      set
      {
        this.ViewState[PageName + K_VS_STATODETAILS] = value;
      }
    }
    #endregion
    #region protected List<BItemField> Filtri
    private string K_FILTRI = ".Filtri";
    protected List<BItemField> Filtri
    {
      get
      {
        return (List<BItemField>)base.Session[PageName + K_FILTRI];
      }
      set
      {
        base.Session[PageName + K_FILTRI] = value;
      }
    }
    #endregion
    #region protected DataTable DTElenco
    private const string K_SE_DTELENCO = ".DTElenco";
    protected DataTable DTElenco
    {
      get
      {
        return (DataTable)base.Session[PageName + K_SE_DTELENCO];
      }
      set
      {
        base.Session[PageName + K_SE_DTELENCO] = value;
      }
    }
    #endregion 

    // DEFINIZIONE PROPRIETA' 
    protected string PageName { get; set; }
    protected string SP_ELENCO_SELECT { get; set; }
    protected string SP_ELENCO_DELETE { get; set; }
    protected string SP_ELENCO_DELETEALL { get; set; }
    protected string NOMEFILEEXCEL { get; set; }

    //#region public List<string> CheckBeforeUpdateAlert
    //private string K_CheckBeforeUpdateAlert = ".CheckBeforeUpdateAlert";
    //public new List<string> CheckBeforeUpdateAlert
    //{
    //  get
    //  {
    //    return (List<string>)base.Session[PageName + K_CheckBeforeUpdateAlert];
    //  }
    //  set
    //  {
    //    base.Session[PageName + K_CheckBeforeUpdateAlert] = value;
    //  }
    //}
    //#endregion


    // PROPRIETA' PER LA VISIBILITA
    protected bool OnView_BtnNuovo_Visible { get; set; } = true;
    protected bool OnDetails_BtnElimina_Visible { get; set; } = true;
    protected bool OnDetails_BtnStampa_Visible { get; set; } = false;
    protected bool OnDetails_BtnSalva_Visible { get; set; } = true;
    protected bool OnView_BtnElimina_Visible { get; set; } = false;
    protected bool OnView_BtnStampa_Visible { get; set; } = false;

    // PROPRIETA DI GESTIONE DELLA PAGINA
    protected bool RunSearchToLoad { get; set; } = true;
    protected bool DTElencoInSession { get; set; } = false;
    protected List<string> RemoveColumns;
    protected bool UseDBUSER { get; set; } = false;

    #region protected bool AllowPaging
    private const bool K_DEF_ALLOWPAGING = true;
    private const string K_VS_ALLOWPAGING = ".AllowPaging";
    protected bool AllowPaging
    {
      get
      {
        if (!string.IsNullOrEmpty(ViewState[PageName + K_VS_ALLOWPAGING].ToString()))
        {
          return K_DEF_ALLOWPAGING;
        }
        else
        {
          return (bool)(base.ViewState[PageName + K_VS_ALLOWPAGING]);
        }
      }
      set
      {
        base.ViewState[PageName + K_VS_ALLOWPAGING] = value;
      }
    }
    #endregion

    // DEFINIZIONE VARIABILI PER GESTIONE CONTROLLI
    protected Panel CtlPnlRicerca;
    protected Panel CtlPnlElenco;
    protected Panel CtlPnlDettaglio;
    protected WebControl CtlBtnNuovo;
    protected WebControl CtlBtnElimina;
    protected WebControl CtlBtnStampa;
    protected WebControl CtlBtnSalva;
    protected WebControl CtlBtnAnnulla;
    protected GridView CtlDtgElenco;

    #region protected BPager CtlBPager
    private BPager _CtlBPager;
    protected BPager CtlBPager
    {
      get
      {
        return _CtlBPager;
      }
      set
      {
        _CtlBPager = value;
      }
    }
    #endregion

    protected WebControl FirstCtlRicerca;
    protected WebControl FirstCtlDettaglio;

    //public new WebControl CtlFocusOnCheckBeforeUpdateAlert;

    // DEFINIZIONE FUNZIONI MUST OVERRIDES
    protected abstract bool InitBTablePage();
    protected abstract void LoadFilter();
    protected abstract DataTable CreateDTEmpty();

    // FUNZIONI PROTECTED SU DTG
    protected void BindEmpty()
    {
      CtlDtgElenco.DataSource = CreateDTEmpty();
      CtlDtgElenco.DataBind();
      if (CtlBPager != null) CtlBPager.SetPager(0);
    }
    protected void BindDTG(DataTable DT)
    {
      if (DT != null)
      {
        CtlDtgElenco.DataSource = DT;
        CtlDtgElenco.DataBind();
        if (CtlBPager != null) CtlBPager.SetPager(DT.Rows.Count);
      }
      else
      {
        BindEmpty();
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDABLE
    protected virtual void SetAttributes_Invio()
    {
      // NESSUNA OPERAZIONE
    }
    protected virtual void SetAttributes_Other()
    {
      // NESSUNA OPERAZIONE
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlBPager.ChangePage += CtlBPager_ChangePage;
      CtlBPager.ChangeNumRowForPage += CtlBPager_ChangeNumRowForPage;
      CtlBPager.ExportToExcel += CtlBPager_ExportToExcel;
      base.SetAttributes_AddEvents();
    }

    protected virtual bool CheckBeforeUpdate()
    {
      return true;
    }
    protected virtual bool CheckBeforeUpdate(BBaseObject Obj)
    {
      return true;
    }
    protected virtual bool CheckBeforeDelete(params IDbDataParameter[] ParamsKey)
    {
      return true;
    }
    protected virtual bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      return true;
    }
    protected virtual bool GotoDetails(string id)
    {
      return false;
    }

    // DEFINIZIONE FUNZIONI PROTECTED PER RICERCA
    protected void AddFilter(string Key, string Value)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key)) return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Key.Substring(1);
      Filtro.Valore = Value;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, string Description)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key)) return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Description;
      Filtro.Valore = Value;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, SqlDbType DbType)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key)) return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Key.Substring(1);
      Filtro.Valore = Value;
      Filtro.Tipo = DbType;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, string Description, SqlDbType DbType)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key)) return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Description;
      Filtro.Valore = Value;
      Filtro.Tipo = DbType;
      Filtri.Add(Filtro);
    }

    // DEFINIZIONE FUNZIONI MUST OVERRIDES DI GESTIONE
    protected abstract void NuovoRec();
    protected abstract bool CambiaRec(BBaseObject Obj);
    protected abstract BBaseObject ScriviRec(BBaseObject Obj);

    // DEFINIZIONE METODI
    protected void Nuovo()
    {
      NuovoRec();
      Stato = eStatusPage.DETTAGLIO;
      StatoDetails = eStatusDetails.NUOVO;
      DisplayPanels();
      CtlBtnElimina.Visible = false;
    }
    protected bool Visiona(BBaseObject Obj)
    {
      if (!CambiaRec(Obj))
      {
        this.MsgBox("Si è verificato un errore durante il caricamento dei dati.");
        return false;
      }
      else
      {
        Stato = eStatusPage.DETTAGLIO;
        StatoDetails = eStatusDetails.VISIONE;
        DisplayPanels();
        return true;
      }
    }
    protected bool Modifica(BBaseObject Obj)
    {
      if (!CambiaRec(Obj))
      {
        this.MsgBox("Si è verificato un errore durante il caricamento dei dati.");
        return false;
      }
      else
      {
        Stato = eStatusPage.DETTAGLIO;
        StatoDetails = eStatusDetails.MODIFICA;
        DisplayPanels();
        return true;
      }
    }
    protected bool Elimina(params IDbDataParameter[] ParamsKey)
    {
      BConnection cnn = null;
      try
      {
        if (UseDBUSER)
        {
          cnn = this.DBUser;
        }
        else
        {
          cnn = this.DB;
        }
        if (!CheckBeforeDelete(ParamsKey)) return false;

        cnn.BeginTrans();
        if (DeleteRowsRelation(ParamsKey))
        {
          cnn.ClearParameter();
          cnn.AddParameter(ParamsKey);
          if (cnn.ExecuteNonQuery(SP_ELENCO_DELETE, CommandType.StoredProcedure) != -1)
          {
            cnn.CommitTrans();
            return true;
          }
          else
          {
            cnn.RollBackTrans();
            WriteLog("BPageTableBase.Elimina()", "Esecuzione Stored Procedure " + SP_ELENCO_DELETE + " fallita.", BEnumerations.eSeverity.ERROR);
            return false;
          }
        }
        else
        {
          cnn.RollBackTrans();
          WriteLog("BPageTableBase.Elimina()", "Metodo DeleteRowRelation() fallito", BEnumerations.eSeverity.ERROR);
          return false;
        }
      }
      catch (Exception ex)
      {
        cnn.RollBackTrans();
        WriteLog("BPageTableBase.Elimina()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (cnn != null) cnn.EndTrans();
      }
    }
    protected bool EliminaAll()
    {
      BConnection cnn = null;
      try
      {
        if (UseDBUSER)
        {
          cnn = this.DBUser;
        }
        else
        {
          cnn = this.DB;
        }

        cnn.BeginTrans();
        cnn.ClearParameter();
        if (cnn.ExecuteNonQuery(SP_ELENCO_DELETEALL, CommandType.StoredProcedure) != -1)
        {
          cnn.CommitTrans();
          return true;
        }
        else
        {
          cnn.RollBackTrans();
          WriteLog("BPageTableBase.EliminaAll()", "Esecuzione Stored Procedure " + SP_ELENCO_DELETEALL + " fallita.", BEnumerations.eSeverity.ERROR);
          return false;
        }
      }
      catch (Exception ex)
      {
        cnn.RollBackTrans();
        WriteLog("BPageTableBase.EliminaAll()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (cnn != null) cnn.EndTrans();
      }
    }
    protected bool Salva(BBaseObject Obj)
    {
      this.CheckBeforeUpdateAlert = new List<string>();
      Obj = ScriviRec(Obj);
      if (Obj != null)
      {
        this.ShowToast("Salvataggio effettuato con successo.", "Informazione");
        Modifica(Obj);
        return true;
      }
      else
      {
        return false;
      }
    }
    protected bool Annulla()
    {
      this.SaveFiltri();
      if (LoadDTGElenco())
      {
        Stato = eStatusPage.ELENCO;
        DisplayPanels();
        return true;
      }
      else
      {
        this.MsgBox("Si è verificato un errore durante il caricamento dei dati.");
        return false;
      }
    }
    protected bool Cerca()
    {
      SaveFiltri();
      if (!LoadDTGElenco())
      {
        this.MsgBox("Non è stato possibile effettuare la ricerca!");
        return false;
      }
      else
      {
        return true;
      }
    }

    protected bool LoadDTGElenco(bool EscludiFiltriRicerca = false)
    {
      BDataTable dt = null;
      BConnection cnn = null;
      try
      {
        if (UseDBUSER)
        {
          cnn = this.DBUser;
        }
        else
        {
          cnn = this.DB;
        }
        if (!EscludiFiltriRicerca) LoadDBParameterByFiltri();
        dt = cnn.ApriDT(SP_ELENCO_SELECT, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (CtlDtgElenco.AutoGenerateColumns)
          {
            foreach (DataColumn c in dt.Columns)
            {
              var r = new Regex("(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
              c.ColumnName = r.Replace(c.ColumnName, " ");
            }
          }
          if (RemoveColumns != null && RemoveColumns.Count > 0)
          {
            foreach (string col in RemoveColumns)
            {
              dt.Columns.Remove(col);
            }
          }

          if (DTElencoInSession) DTElenco = dt;
          BindDTG(dt);
        }
        else
        {
          BindEmpty();
        }
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("BPageTableBase.LoadDTGElenco()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }
    protected BDataTable GetDTElenco(bool EscludiFiltriRicerca = false)
    {
      BDataTable dt = null;
      BConnection cnn = null;
      try
      {
        if (UseDBUSER)
        {
          cnn = this.DBUser;
        }
        else
        {
          cnn = this.DB;
        }

        if (!EscludiFiltriRicerca) LoadDBParameterByFiltri();
        dt = cnn.ApriDT(SP_ELENCO_SELECT, CommandType.StoredProcedure);
        return dt;
      }
      catch (Exception ex)
      {
        WriteLog("BPageTableBase.GetDTElenco()", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }

    protected void DisabledButton(bool Disabled = false)
    {
      if (CtlBtnAnnulla != null) CtlBtnAnnulla.Enabled = !Disabled;
      if (CtlBtnSalva != null) CtlBtnSalva.Enabled = !Disabled;
      if (CtlBtnElimina != null) CtlBtnElimina.Enabled = !Disabled;
      if (CtlBtnStampa != null) CtlBtnStampa.Enabled = !Disabled;
    }
    protected object GetValueFromKey(string CampoKey, params IDbDataParameter[] ParamsKey)
    {
      List<IDbDataParameter> l = null;
      IDbDataParameter rEmpty = null;
      try
      {
        l = ParamsKey.ToList();
        // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        rEmpty = new System.Data.SqlClient.SqlParameter();
        rEmpty.ParameterName = "@" + CampoKey;
        rEmpty.Value = "empty";
        l.Add(rEmpty);

        // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        var res = from c in l
                  where (c.ParameterName ?? "") == ("@" + CampoKey ?? "")
                  select c;
        l.Remove(rEmpty); // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        if (res != null && res.Count() > 0)
        {
          return res.ElementAtOrDefault(0).Value;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        WriteLog("BPageTableBase.GetValueFromKey()", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }
    protected string GetHelpFiltri()
    {
      string s = "";
      string k_Filtro = "{0}={1}; ";
      if (Filtri != null && Filtri.Count > 0)
      {
        foreach (BItemField f in Filtri)
        {
          if (!string.IsNullOrEmpty(f.Descrizione))
          {
            s += string.Format(k_Filtro, f.Descrizione, ConvertValueToHelp(f));
          }
        }
        return s;
      }
      else
      {
        return "";
      }
    }

    // DEFINIZIONE METODI OVERRIDABLE FOR HELP IN SEARCH
    protected virtual string ConvertValueToHelp(BItemField itm)
    {
      if (itm == null) return "";
      var switchExpr = itm.Tipo;
      switch (switchExpr)
      {
        case SqlDbType.Bit:
          {
            if (itm.Valore != null && (bool)(itm.Valore))
            {
              return "Sì";
            }
            else
            {
              return "No";
            }
          }
        case SqlDbType.Date:
        case SqlDbType.SmallDateTime:
        case var @case when @case == SqlDbType.Date:
          {
            return BGlobal.FormattaData(DateTime.Parse(itm.Valore.ToString()));
          }
        case SqlDbType.DateTime:
        case SqlDbType.DateTime2:
          {
            if (itm.Valore == null)
              return "";
            return BGlobal.FormattaData(DateTime.Parse(itm.Valore.ToString()), "dd/MM/yyyy HH:mm");
          }

        case SqlDbType.Time:
        case SqlDbType.Timestamp:
          {
            if (itm.Valore == null)
              return "";
            return BGlobal.FormattaData(DateTime.Parse(itm.Valore.ToString()), "HH:mm");
          }
        case SqlDbType.Money:
        case SqlDbType.Decimal:
        case SqlDbType.Float:
          {
            if (itm.Valore == null) return "0";
            return BGlobal.FormattaNumero(itm.Valore);
          }
        default:
          {
            return itm.Valore.ToString();
          }
      }
    }
    protected virtual object ConvertValueToParmValue(BItemField Itm)
    {
      if (Itm == null)
        return DBNull.Value;
      var switchExpr = Itm.Tipo;
      switch (switchExpr)
      {
        case SqlDbType.Bit:
          {
            return BGlobal.PrendiBool(Itm.Valore.ToString());
          }
        case SqlDbType.Date:
        case SqlDbType.SmallDateTime:
        case var @case when @case == SqlDbType.Date:
          {
            return BGlobal.PrendiData(Itm.Valore.ToString());
          }
        case SqlDbType.DateTime:
        case SqlDbType.DateTime2:
          {
            return BGlobal.PrendiData(Itm.Valore.ToString());
          }
        case SqlDbType.Time:
        case SqlDbType.Timestamp:
          {
            return BGlobal.PrendiData(Itm.Valore.ToString());
          }
        case SqlDbType.Money:
        case SqlDbType.Decimal:
        case SqlDbType.Float:
          {
            if (Itm.Valore == null)
              return DBNull.Value;
            return BGlobal.PrendiNumero(Itm.Valore.ToString());
          }
        default:
          {
            return Itm.Valore + "";
          }
      }
    }

    // DEFINIZIONE METODI OVERRIDABLE FOR EXPORT XLS
    protected virtual DataView GetCustomDataViewToExportXls()
    {
      if (DTElencoInSession)
      {
        return new DataView(DTElenco);
      }
      else
      {
        return new DataView(GetDTElenco());
      }
    }
    protected virtual string GetPrefixUrlToExportXls()
    {
      return "./BSystem/";
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadAttribtes()
    {
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return false;
      CtlDtgElenco.AllowPaging = AllowPaging;
      if (CtlBPager != null) CtlBPager.Visible = AllowPaging;
      CtlPnlElenco.CssClass = CtlPnlElenco.CssClass.Replace("HideForDesign", "");
      CtlPnlRicerca.CssClass = CtlPnlRicerca.CssClass.Replace("HideForDesign", "");
      CtlPnlDettaglio.CssClass = CtlPnlDettaglio.CssClass.Replace("HideForDesign", "");
      CtlPnlElenco.CssClass = CtlPnlElenco.CssClass.Replace("ShowForDesign", "");
      CtlPnlRicerca.CssClass = CtlPnlRicerca.CssClass.Replace("ShowForDesign", "");
      CtlPnlDettaglio.CssClass = CtlPnlDettaglio.CssClass.Replace("ShowForDesign", "");
      SetAttributes_Invio();
      SetAttributes_Other();
      return true;
    }
    private bool DisplayPanels()
    {
      // IMPOSTO VISIBILITA' PANNELLI
      CtlPnlRicerca.Visible = false;
      CtlPnlElenco.Visible = false;
      CtlPnlDettaglio.Visible = false;
      var switchExpr = Stato;
      switch (switchExpr)
      {
        case eStatusPage.ELENCO:
          {
            // IMPOSTO VISIBILITA' BOTTONI
            CtlBtnStampa.Visible = OnView_BtnStampa_Visible;
            CtlBtnElimina.Visible = OnView_BtnElimina_Visible;
            CtlBtnNuovo.Visible = OnView_BtnNuovo_Visible;
            if (CtlBtnSalva != null)
              CtlBtnSalva.Visible = false;
            if (CtlBtnAnnulla != null)
              CtlBtnAnnulla.Visible = false;

            // IMPOSTO VISIBILITA' PANNELLI
            CtlPnlRicerca.Visible = true;
            CtlPnlElenco.Visible = true;
            StatoDetails = eStatusDetails.VISIONE;
            break;
          }
        case eStatusPage.DETTAGLIO:
          {
            if (StatoDetails != eStatusDetails.VISIONE)
            {
              // IMPOSTO VISIBILITA' BOTTONI
              CtlBtnElimina.Visible = OnDetails_BtnElimina_Visible;
              CtlBtnStampa.Visible = OnDetails_BtnStampa_Visible;
              if (CtlBtnNuovo != null)
                CtlBtnNuovo.Visible = false;
              if (CtlBtnSalva != null)
                CtlBtnSalva.Visible = OnDetails_BtnSalva_Visible;
              if (CtlBtnAnnulla != null)
                CtlBtnAnnulla.Visible = true;
              CtlPnlDettaglio.Enabled = true;
            }
            else
            {
              CtlBtnStampa.Visible = OnDetails_BtnStampa_Visible;
              if (CtlBtnNuovo != null)
                CtlBtnNuovo.Visible = false;
              if (CtlBtnElimina != null)
                CtlBtnElimina.Visible = false;
              if (CtlBtnSalva != null)
                CtlBtnSalva.Visible = false;
              if (CtlBtnAnnulla != null)
                CtlBtnAnnulla.Visible = true;
              CtlPnlDettaglio.Enabled = false;
            }

            // IMPOSTO VISIBILITA' PANNELLI
            CtlPnlDettaglio.Visible = true;
            break;
          }
      }

      return true;
    }

    // DEFINIZIONE FUNZIONI PRIVATE SUI FILTRI
    private void LoadDBParameterByFiltri()
    {
      IDbDataParameter p = null;
      BConnection cnn = null;
      if (UseDBUSER)
      {
        cnn = this.DBUser;
      }
      else
      {
        cnn = this.DB;
      }

      cnn.ClearParameter();
      if (Filtri != null)
      {
        foreach (BItemField f in Filtri)
        {
          p = new System.Data.SqlClient.SqlParameter(f.Codice, f.Tipo);
          if (f.Valore == null)
          {
            p.Value = DBNull.Value;
          }
          else
          {
            p.Value = ConvertValueToParmValue(f);
          }

          cnn.AddParameter(p);
          p = null;
        }
      }
    }
    private bool SaveFiltri()
    {
      try
      {
        if (Filtri == null) Filtri = new List<BItemField>();
        Filtri.Clear();

        // AGGIUNGO FILTRO PER DESCRIZIONE
        LoadFilter();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("BPageTableBase.SaveFiltri()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    protected override void BPage_Init(object sender, EventArgs e)
    {
      if (!this.CheckSession()) return;
      OnInitBefore?.Invoke(sender, e);
      InitBTablePage();
      if (!this.IsPostBack) LoadAttribtes();
      OnInitAfter?.Invoke(sender, e);
    }
    protected override void BPage_Load(object sender, EventArgs e)
    {
      if (!this.CheckSession()) return;
      //if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return;
      OnLoadBefore?.Invoke(sender, e);
      if (!this.IsPostBack)
      {
        if (!string.IsNullOrEmpty(base.GetRouteParam(0)))
        {
          if (this.GotoDetails(base.GetRouteParam(0)))
          {
            OnLoadAfter?.Invoke(sender, e);
            return;
          }
        }

        Stato = eStatusPage.ELENCO;
        DisplayPanels();

        // UTILIZZARE UNA DELLE DUE OPZIONI 
        if (!RunSearchToLoad)
        {
          // MOSTRA GRID VUOTO
          BindEmpty();
        }
        else
        {
          // MOSTRA TUTTO
          SaveFiltri();
          LoadDTGElenco();
        }

        // AGGINGO ATTRIBUTI 
        if (CtlBtnElimina != null)
          CtlBtnElimina.Attributes["onclick"] = "javascript: return confirm('Sei sicuro di voler eliminare?');";
      }
      OnLoadAfter?.Invoke(sender, e);
    }

    //DEFINIZIONE EVENTI INTERCETTATI SU PAGER
    private void CtlBPager_ChangePage()
    {
      CtlDtgElenco.PageIndex = CtlBPager.PageIndex;
      if (DTElencoInSession)
      {
        BindDTG(DTElenco);
      }
      else
      {
        LoadDTGElenco();
      }
    }
    private void CtlBPager_ChangeNumRowForPage()
    {
      if (CtlBPager.DefaultRowForPage == -1)
      {
        CtlDtgElenco.PageSize = CtlBPager.RowCount;
      }
      else
      {
        CtlDtgElenco.PageSize = CtlBPager.DefaultRowForPage;
      }

      CtlDtgElenco.PageIndex = 0;
      if (DTElencoInSession)
      {
        BindDTG(DTElenco);
      }
      else
      {
        LoadDTGElenco();
      }
    }

    //private void CtlBPager_ExportToExcel()  vecchia versione
    protected virtual void CtlBPager_ExportToExcel()
    {
      DataView dv = null;
      dv = GetCustomDataViewToExportXls();
      if (dv != null && dv.Table.Rows.Count > 0)
      {
        if (DTElencoInSession)
        {
          //  ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS,  "Elenco"); vecchia versione
          ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, NOMEFILEEXCEL ?? "Elenco");
        }
        else
        {
          ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, NOMEFILEEXCEL ?? "Elenco");
        }
      }
      else
      {
        this.MsgBox("Non ci sono elementi da esportare.");
      }
    }
    private void BPageTableBase_AttachCommand()
    {
      if (CtlBPager != null) base.AddAttachExportExcel(CtlBPager.BtnExportXls_ClientID, GetPrefixUrlToExportXls());
    }

  } //END CLASS
} //END NAMESPACE