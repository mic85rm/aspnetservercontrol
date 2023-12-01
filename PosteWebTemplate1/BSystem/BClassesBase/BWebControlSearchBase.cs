using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BWebControlSearchBase : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event InternalSelectedEventHandler InternalSelected;
    public delegate void InternalSelectedEventHandler(List<string> l);

    public event CancelEventHandler Cancel;
    public delegate void CancelEventHandler();

    public event InternalShowExtenderEventHandler InternalShowExtender;
    public delegate void InternalShowExtenderEventHandler();

    public event OnInitBeforeEventHandler OnInitBefore;
    public delegate void OnInitBeforeEventHandler(object sender, EventArgs e);

    public event OnInitAfterEventHandler OnInitAfter;
    public delegate void OnInitAfterEventHandler(object sender, EventArgs e);

    public event OnLoadBeforeEventHandler OnLoadBefore;
    public delegate void OnLoadBeforeEventHandler(object sender, EventArgs e);

    public event OnLoadAfterEventHandler OnLoadAfter;
    public delegate void OnLoadAfterEventHandler(object sender, EventArgs e);

    // DEFINIZIONE PROPRIETA' 
    protected string Titolo { get; set; }
    protected string SP_SEARCH { get; set; }

    #region protected BConnection DB_SEARCH
    private BConnection m_DB_SEARCH;
    protected BConnection DB_SEARCH
    {
      get
      {
        if (m_DB_SEARCH == null)
          m_DB_SEARCH = new BConnection(this.DB.Setting.Clone());
        return m_DB_SEARCH;
      }
      set
      {
        m_DB_SEARCH = value;
      }
    }
    #endregion

    protected BModalPopup CtlModalPopup;
    #region protected BGridView CtlDtgElenco
    private BGridView _CtlDtgElenco;
    protected BGridView CtlDtgElenco
    {
      get
      {
        return _CtlDtgElenco;
      }
      set
      {
        if (_CtlDtgElenco != null)
        {

          _CtlDtgElenco.RowDataBound -= DtgElenco_RowDataBound;
          _CtlDtgElenco.RowClick -= CtlDtgElenco_RowClick;
        }
        _CtlDtgElenco = value;
        if (_CtlDtgElenco != null)
        {
          _CtlDtgElenco.RowDataBound += DtgElenco_RowDataBound;
          _CtlDtgElenco.RowClick += CtlDtgElenco_RowClick;
        }
      }
    }
    #endregion
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
        if (_CtlBPager != null)
        {
          _CtlBPager.ChangePage -= CtlBPager_ChangePage;
          _CtlBPager.ChangeNumRowForPage -= CtlBPager_ChangeNumRowForPage;
          _CtlBPager.ExportToExcel -= CtlBPager_ExportToExcel;
        }
        _CtlBPager = value;
        if (_CtlBPager != null)
        {
          _CtlBPager.ChangePage += CtlBPager_ChangePage;
          _CtlBPager.ChangeNumRowForPage += CtlBPager_ChangeNumRowForPage;
          _CtlBPager.ExportToExcel += CtlBPager_ExportToExcel;
        }
      }
    }
    #endregion

    protected WebControl FirstCtlRicerca;
    #region protected List<BItemField> Filtri
    private string K_FILTRI = ".Filtri";
    protected List<BItemField> Filtri
    {
      get
      {
        return (List<BItemField>)base.Session[base.ID + K_FILTRI];
      }
      set
      {
        base.Session[base.ID + K_FILTRI] = value;
      }
    }
    #endregion
    #region protected DataTable DTElenco
    private const string K_SE_DTELENCO = ".DTElenco";
    protected DataTable DTElenco
    {
      get
      {
        return (DataTable)base.Session[base.ID + K_SE_DTELENCO];
      }
      set
      {
        base.Session[base.ID + K_SE_DTELENCO] = value;
      }
    }
    #endregion

    // PROPRIETA DI GESTIONE DEL CONTROLLO
    protected bool MultiSelect { get; set; } = false;

    #region private bool CheckedAll
    private const string K_CHECKEDALL = ".CHECKEDALL";
    private const bool k_DEF_CHECKEDALL = false;
    private bool CheckedAll
    {
      get
      {
        if (this.ViewState[base.ID + K_CHECKEDALL] == null)
        {
          return k_DEF_CHECKEDALL;
        }
        else
        {
          return (bool)(this.ViewState[base.ID + K_CHECKEDALL]);
        }
      }
      set
      {
        this.ViewState[base.ID + K_CHECKEDALL] = value;
      }
    }
    #endregion
    #region protected BArts.BLists.BListOfBItemField CheckedList
    private const string K_CHECKEDLIST = ".CHECKEDLIST";
    protected BArts.BLists.BListOfBItemField CheckedList
    {
      get
      {
        if (this.Session[base.ID + K_CHECKEDLIST] == null)
          this.Session[base.ID + K_CHECKEDLIST] = new BArts.BLists.BListOfBItemField();
        return (BArts.BLists.BListOfBItemField)this.Session[base.ID + K_CHECKEDLIST];
      }
      set
      {
        this.Session[base.ID + K_CHECKEDLIST] = value;
      }
    }
    #endregion

    protected int? LockSearchFilterLeastOf { get; set; } = null;
    protected bool RunSearchToLoad { get; set; } = true;
    protected bool DTElencoInSession { get; set; } = false;

    #region protected bool AllowPaging
    private const bool K_DEF_ALLOWPAGING = true;
    private const string K_VS_ALLOWPAGING = ".AllowPaging";
    protected bool AllowPaging
    {
      get
      {
        if (!base.ViewState[base.ID + K_VS_ALLOWPAGING].ToString().Equals(""))
        {
          return K_DEF_ALLOWPAGING;
        }
        else
        {
          return (bool)(base.ViewState[base.ID + K_VS_ALLOWPAGING]);
        }
      }
      set
      {
        base.ViewState[base.ID + K_VS_ALLOWPAGING] = value;
      }
    }
    #endregion

    // DEFINIZIONE FUNZIONI MUST OVERRIDES
    protected abstract bool InitBControlSearchBase();
    protected abstract void LoadFilter();
    protected abstract DataTable CreateDTEmpty();
    protected abstract BItemField GetNewItemField(GridViewRow row);
    protected abstract string GetItemFieldKey(GridViewRow row);


    // DEFINIZIONE FUNZIONI OVERRIDABLE
    protected virtual void SetAttributes_Invio()
    {
    }
    protected virtual void SetAttributes_Other()
    {
    }
    protected new virtual void SetAttributes_AddEvents()
    {
      this.AttachCommand += BPageTableBase_AttachCommand;

      CtlDtgElenco.RowDataBound += DtgElenco_RowDataBound;
      CtlDtgElenco.RowClick += CtlDtgElenco_RowClick;
      CtlBPager.ChangePage += CtlBPager_ChangePage;
      CtlBPager.ChangeNumRowForPage += CtlBPager_ChangeNumRowForPage;
      CtlBPager.ExportToExcel += CtlBPager_ExportToExcel;

      base.SetAttributes_AddEvents();
    }


    protected override void OnLoad(EventArgs e)
    {
      if (!this.BPage.CheckSession()) return;
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return;
      OnLoadBefore?.Invoke(this, e);
      if (!this.IsPostBack)
      {
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

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO
        if (FirstCtlRicerca != null) FirstCtlRicerca.Focus();
      }
      else
      {
        SaveCheckedList();
      }

      this.SetAttributes_AddEvents();
      OnLoadAfter?.Invoke(this, e);

      base.OnLoad(e);
    }

    protected override void OnInit(EventArgs e)
    {
      if (!this.BPage.CheckSession()) return;
      if (this.DB == null) return;
      OnInitBefore?.Invoke(this, e);
      InitBControlSearchBase();
      OnInitAfter?.Invoke(this, e);
      base.OnInit(e);
    }

    // FUNZIONI PROTECTED SU DTG
    protected void BindEmpty()
    {
      CtlDtgElenco.DataSource = CreateDTEmpty();
      CtlDtgElenco.DataBind();
      if (CtlBPager != null)
        CtlBPager.SetPager(0);
    }
    protected void BindDTG(DataTable DT)
    {
      if (DT != null)
      {
        CtlDtgElenco.DataSource = DT;
        CtlDtgElenco.DataBind();
        if (CtlBPager != null)
          CtlBPager.SetPager(DT.Rows.Count);
      }
      else
      {
        BindEmpty();
      }
    }

    // DEFINIZIONE FUNZIONI PROTECTED PER RICERCA
    protected void AddFilter(string Key, string Value)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key))
        return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Key.Substring(1);
      Filtro.Valore = Value;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, string Description)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key))
        return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Description;
      Filtro.Valore = Value;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, SqlDbType DbType)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key))
        return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Key.Substring(1);
      Filtro.Valore = Value;
      Filtro.Tipo = DbType;
      Filtri.Add(Filtro);
    }
    protected void AddFilter(string Key, string Value, string Description, SqlDbType DbType)
    {
      var Filtro = new BItemField();
      if (string.IsNullOrEmpty(Key))
        return;
      Filtro.Codice = Key;
      Filtro.Descrizione = Description;
      Filtro.Valore = Value;
      Filtro.Tipo = DbType;
      Filtri.Add(Filtro);
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
      try
      {
        if (!EscludiFiltriRicerca)
        {
          LoadDBParameterByFiltri();
          if (LockSearchFilterLeastOf.HasValue && Filtri.Count < LockSearchFilterLeastOf.Value)
          {
            if (LockSearchFilterLeastOf.Value == 1)
            {
              this.MsgBox("Inserire almeno un filtro di ricerca");
            }
            else
            {
              this.MsgBox("Inserire almeno " + LockSearchFilterLeastOf + " filtri di ricerca");
            }

            if (FirstCtlRicerca != null)
              FirstCtlRicerca.Focus();
            return false;
          }
        }
        // AZZERO CHECKED LIST
        CheckedList.Clear();
        CtlDtgElenco.PageIndex = 0;
        if (MultiSelect)
        {
          CheckedAll = false;
        }

        dt = DB_SEARCH.ApriDT(SP_SEARCH, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (DTElencoInSession)
            DTElenco = dt;
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
        this.WriteLog("BWebControlSearchBase.LoadDTGElenco()", "", ex, BEnumerations.eSeverity.ERROR);
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
      try
      {
        if (!EscludiFiltriRicerca)
          LoadDBParameterByFiltri();
        dt = DB_SEARCH.ApriDT(SP_SEARCH, CommandType.StoredProcedure);
        return dt;
      }
      catch (Exception ex)
      {
        this.WriteLog("BWebControlSearchBase.GetDTElenco()", "", ex, BEnumerations.eSeverity.ERROR);
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
        this.WriteLog("BWebControlSearchBase.GetValueFromKey()", "", ex, BEnumerations.eSeverity.ERROR);
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
        return "Nessuno";
      }
    }

    protected virtual string ConvertValueToHelp(BItemField itm)
    {
      if (itm == null)
        return "";
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
            if (itm.Valore == null)
              return "0";
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

    // DEFINIZIONE FUNZIONI PROTECTED PER RAISE EVENT
    protected void Annulla()
    {
      Hide();
      Cancel?.Invoke();
    }
    protected void Conferma()
    {
      var l = new List<string>();
      SaveCheckedList();

      // RESTITUISCO VALORI
      l = CheckedList.GetKeysByValue(true);
      if (l != null && l.Count > 0)
      {
        InternalSelected?.Invoke(l);
      }
      else
      {
        this.MsgBox("Non è stato selezionato alcun elemento");
        CtlDtgElenco.Focus();
        EnsureControl();
        return;
      }
    }

    protected void EnsureControl()
    {
      InternalShowExtender?.Invoke();
    }

    // DEFINIZIONE FUNZIONI PRIVATE SUI FILTRI
    private void LoadDBParameterByFiltri()
    {
      IDbDataParameter p = null;
      DB_SEARCH.ClearParameter();
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

          DB_SEARCH.AddParameter(p);
          p = null;
        }
      }
    }
    private bool SaveFiltri()
    {
      try
      {
        if (Filtri == null)
          Filtri = new List<BItemField>();
        Filtri.Clear();

        // AGGIUNGO FILTRO PER DESCRIZIONE
        LoadFilter();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BWebControlSearchBase.SaveFiltri()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadAttributes()
    {
      CtlDtgElenco.AllowPaging = AllowPaging;
      if (CtlBPager != null)
        CtlBPager.Visible = AllowPaging;
      CtlModalPopup.Titolo = Titolo;
      SetAttributes_Invio();
      SetAttributes_Other();
      return true;
    }
    private void SaveCheckedList()
    {
      BCheck ChkSelectAll = null;
      string CtlChkID = "";
      // Dim CtlChkID As String = ""
      var l = new List<GridViewRow>();
      if (CtlDtgElenco != null)
      {
        ChkSelectAll = (BCheck)CtlDtgElenco.HeaderRow.FindControl("ChkSelectAll");
        if (ChkSelectAll == null)
          return;
        CheckedAll = ChkSelectAll.Checked;

        // save collection
        if (CtlDtgElenco.Rows.Count == 0)
          return;

        // IMPLEMENTARE QUI LA LOGICA DELLA SELEZIONE
        if (!MultiSelect)
        {
          CtlChkID = "OptSelect";
          // da implementare
          var res = from GridViewRow row in CtlDtgElenco.Rows
                    where (row.FindControl(CtlChkID) != null && ((RadioButton)row.FindControl(CtlChkID)).Checked) | row.RowIndex == 0
                    select row;
          if (res != null && res.Count() > 0)
          {
            RadioButton chk = (RadioButton)res.ElementAtOrDefault(0).FindControl(CtlChkID);
            if (chk != null && chk.Checked)
            {
              CheckedList.Clear();
              CheckedList.AddItem(this.GetItemFieldKey(res.ElementAtOrDefault(0)), true);
            }

            if (res.Count() > 1)
            {
              CheckedList.Clear();
              CheckedList.AddItem(this.GetItemFieldKey(res.ElementAtOrDefault(1)), true);
            }
          }
        }
        else
        {
          CtlChkID = "ChkSelect";
          foreach (GridViewRow row in CtlDtgElenco.Rows)
          {
            BCheck Chk = (BCheck)row.FindControl(CtlChkID);
            if (Chk != null)
            {
              CheckedList.AddItem(GetItemFieldKey(row), Chk.Checked);
            }
            else
            {
              // error
            }
          }
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
      return "../BSystem/";
    }

    // DEFINIZIONE METODI
    public void InitControl()
    {
      LoadAttributes();
    }

    public bool Show()
    {
      if (CtlModalPopup == null) return false;
      CtlModalPopup.Show();
      return true;
    }
    public bool Hide()
    {
      if (CtlModalPopup == null) return false;
      CtlModalPopup.Hide();
      return true;
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    private void DtgElenco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      RadioButton OptSelect = null;
      BCheck ChkSelectAll = null;
      BCheck ChkSelect = null;
      var switchExpr = e.Row.RowType;
      switch (switchExpr)
      {
        case DataControlRowType.Header:
          {
            ChkSelectAll = (BCheck)e.Row.FindControl("ChkSelectAll");
            if (ChkSelectAll == null)
              return;
            if (!MultiSelect)
            {
              ChkSelectAll.Visible = false;
            }

            ChkSelectAll.Checked = CheckedAll;
            ChkSelectAll.Attributes["onclick"] = "return BGridView_SelectAll('" + ChkSelectAll.ClientID + "', '" + CtlDtgElenco.ClientID + "', 0)";
            break;
          }

        case DataControlRowType.DataRow:
          {
            OptSelect = (RadioButton)e.Row.FindControl("OptSelect");
            if (OptSelect == null)
              return;
            ChkSelect = (BCheck)e.Row.FindControl("ChkSelect");
            if (ChkSelect == null)
              return;
            ChkSelectAll = (BCheck)CtlDtgElenco.HeaderRow.FindControl("ChkSelectAll");
            if (ChkSelectAll == null)
              return;
            if (MultiSelect)
            {
              OptSelect.Visible = false;
              var itm = CheckedList.get_Item(GetItemFieldKey(e.Row));
              if (itm != null)
              {
                ChkSelect.Checked = (bool)(itm.Valore);
              }
              else
              {
                ChkSelect.Checked = ChkSelectAll.Checked;
              }
            }
            else
            {
              ChkSelect.Visible = false;
              var itm = CheckedList.get_Item(GetItemFieldKey(e.Row));
              if (itm != null)
              {
                OptSelect.Checked = (bool)(itm.Valore);
              }

              OptSelect.Attributes["onclick"] = "return BGridView_SelectOne('" + OptSelect.ClientID + "', '" + CtlDtgElenco.ClientID + "', 0, 0)";
            }

            break;
          }
      }
    }
    private void CtlDtgElenco_RowClick(int RowIndex)
    {
      List<string> l = null;
      if (RowIndex != -1)
      {
        if (!MultiSelect)
        {
          l = new List<string>();
          l.Add(GetItemFieldKey(CtlDtgElenco.Rows[RowIndex]));
          InternalSelected?.Invoke(l);
        }
      }
      else
      {
        CtlDtgElenco.Focus();
        EnsureControl();
      }
    }

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

      InternalShowExtender?.Invoke();
    }
    private void CtlBPager_ChangeNumRowForPage()
    {
      CtlDtgElenco.PageSize = CtlBPager.DefaultRowForPage;
      CtlDtgElenco.PageIndex = 0;
      if (DTElencoInSession)
      {
        BindDTG(DTElenco);
      }
      else
      {
        LoadDTGElenco();
      }

      InternalShowExtender?.Invoke();
    }
    private void CtlBPager_ExportToExcel()
    {
      DataView dv = null;
      dv = GetCustomDataViewToExportXls();
      if (dv != null && dv.Table != null && dv.Table.Rows.Count > 0)
      {
        if (DTElencoInSession)
        {
          BPage.ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, "Elenco");
        }
        else
        {
          BPage.ExportToExcel(dv, ModEnumeration.eFormatoExport.XLS, "Elenco");
        }
      }
      else
      {
        this.MsgBox("Non ci sono elementi da esportare.");
      }

      InternalShowExtender?.Invoke();
    }

    private void BPageTableBase_AttachCommand()
    {
      if (CtlBPager != null) this.BPage.AddAttachExportExcel(CtlBPager.BtnExportXls_ClientID, GetPrefixUrlToExportXls());
    }

  } //END CLASS
} //END NAMESPACE