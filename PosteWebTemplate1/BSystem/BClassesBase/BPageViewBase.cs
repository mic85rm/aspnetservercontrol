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
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BPageViewBase : BPageBase
  {
    public BPageViewBase()
    {
      // DEFINIZIONE ATTACH EVENTI 
      this.Init += Page_Init;
      this.Load += Page_Load;
      this.AttachCommand += BPageTableBase_AttachCommand;
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

    // PROPRIETA DI GESTIONE DELLA PAGINA
    protected bool RunSearchToLoad { get; set; } = true;
    protected bool DTElencoInSession { get; set; } = false;
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

    // DEFINIZIONE FUNZIONI MUST OVERRIDES
    protected abstract bool InitBViewPage();
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
        WriteLog("BPageViewBase.LoadDTGElenco()", "", ex, BEnumerations.eSeverity.ERROR);
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
        WriteLog("BPageViewBase.GetDTElenco()", "", ex, BEnumerations.eSeverity.ERROR);
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
        WriteLog("BPageViewBase.GetValueFromKey()", "", ex, BEnumerations.eSeverity.ERROR);
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
      CtlPnlElenco.CssClass = CtlPnlElenco.CssClass.Replace("ShowForDesign", "");
      CtlPnlRicerca.CssClass = CtlPnlRicerca.CssClass.Replace("ShowForDesign", "");
      SetAttributes_Invio();
      SetAttributes_Other();
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
        WriteLog("BPageViewBase.SaveFiltri()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void Page_Init(object sender, EventArgs e)
    {
      if (!this.CheckSession()) return;
      OnInitBefore?.Invoke(sender, e);
      InitBViewPage();
      if (!this.IsPostBack) LoadAttribtes();
      OnInitAfter?.Invoke(sender, e);
    }
    protected void Page_Load(object sender, EventArgs e)
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
    private void CtlBPager_ExportToExcel()
    {
      DataView dv = null;
      dv = GetCustomDataViewToExportXls();
      if (dv != null && dv.Table.Rows.Count > 0)
      {
        if (DTElencoInSession)
        {
          ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, "Elenco");
        }
        else
        {
          ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, "Elenco");
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