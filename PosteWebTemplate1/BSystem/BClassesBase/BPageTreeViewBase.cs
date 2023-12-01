using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BPageTreeViewBase : BPageBase
  {

    // DEFINIZIONE ENUM
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

    // DEFINIZIONE PROPRIETA' 
    protected string PageName { get; set; }
    protected string SP_ELENCO_DELETE { get; set; }
    protected string SP_ELENCO_DELETEALL { get; set; }

    // PROPRIETA' PER LA VISIBILITA
    protected bool OnView_BtnNuovo_Visible { get; set; } = true;
    protected bool OnView_BtnElimina_Visible { get; set; } = false;
    protected bool OnView_BtnStampa_Visible { get; set; } = false;
    protected bool OnDetails_BtnNuovo_Visible { get; set; } = true;
    protected bool OnDetails_BtnElimina_Visible { get; set; } = true;
    protected bool OnDetails_BtnStampa_Visible { get; set; } = false;

    // PROPRIETA DI GESTIONE DELLA PAGINA
    protected bool RunSearchToLoad { get; set; } = true;
    protected bool UseDBUSER { get; set; } = false;

    // DEFINIZIONE VARIABILI PER GESTIONE CONTROLLI
    protected Panel CtlPnlRicerca;
    protected Panel CtlPnlElenco;
    protected Panel CtlPnlDettaglio;
    protected WebControl CtlBtnNuovo;
    protected WebControl CtlBtnElimina;
    protected WebControl CtlBtnStampa;
    protected WebControl CtlBtnSalva;
    protected WebControl CtlBtnAnnulla;
    protected BTreeView CtlTvwElenco;
    protected WebControl FirstCtlRicerca;
    protected WebControl FirstCtlDettaglio;

    // DEFINIZIONE FUNZIONI MUST OVERRIDES
    protected abstract bool InitBTablePage();
    protected abstract void LoadFilter();

    // DEFINIZIONE FUNZIONI OVERRIDABLE
    protected virtual void SetAttributes_Invio()
    {
      // NESSUNA OPERAZIONE
    }
    protected virtual void SetAttributes_Other()
    {
      // NESSUNA OPERAZIONE
    }
    protected virtual bool CheckBeforeUpdate()
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
    protected abstract void NuovoRec(BTreeNode n);
    protected abstract bool CambiaRec(BBaseObject Obj, BTreeNode n);
    protected abstract BBaseObject ScriviRec(BBaseObject Obj, BTreeNode n);
    protected abstract bool CaricaTreeView(bool EscludiFiltriRicerca = false);

    // DEFINIZIONE METODI
    protected void Nuovo(BTreeNode n)
    {
      NuovoRec(n);
      Stato = eStatusPage.DETTAGLIO;
      StatoDetails = eStatusDetails.NUOVO;
      DisplayPanels();
      CtlBtnElimina.Visible = false;
    }
    protected bool Visiona(BBaseObject Obj, BTreeNode n)
    {
      if (!CambiaRec(Obj, n))
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
    protected bool Modifica(BBaseObject Obj, BTreeNode n)
    {
      if (!CambiaRec(Obj, n))
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
            WriteLog("BPageTreeViewBase.Elimina()", "Esecuzione Stored Procedure " + SP_ELENCO_DELETE + " fallita.", BEnumerations.eSeverity.ERROR);
            return false;
          }
        }
        else
        {
          cnn.RollBackTrans();
          WriteLog("BPageTreeViewBase.Elimina()", "Metodo DeleteRowRelation() fallito", BEnumerations.eSeverity.ERROR);
          return false;
        }
      }
      catch (Exception ex)
      {
        cnn.RollBackTrans();
        WriteLog("BPageTreeViewBase.Elimina()", "", ex, BEnumerations.eSeverity.ERROR);
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
    protected bool Salva(BBaseObject Obj, BTreeNode n)
    {
      Obj = ScriviRec(Obj, n);
      if (Obj != null)
      {
        Modifica(Obj, n);
        return true;
      }
      else
      {
        return false;
      }
    }
    protected bool Annulla()
    {
      if (CaricaTreeView())
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
      if (!CaricaTreeView())
      {
        this.MsgBox("Non è stato possibile effettuare la ricerca!");
        return false;
      }
      else
      {
        return true;
      }
    }

    protected void DisabledButton(bool Disabled = false)
    {
      if (CtlBtnAnnulla != null)
        CtlBtnAnnulla.Enabled = !Disabled;
      if (CtlBtnSalva != null)
        CtlBtnSalva.Enabled = !Disabled;
      if (CtlBtnElimina != null)
        CtlBtnElimina.Enabled = !Disabled;
      if (CtlBtnStampa != null)
        CtlBtnStampa.Enabled = !Disabled;
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

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadAttribtes()
    {
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return false;
      CtlPnlElenco.CssClass = CtlPnlElenco.CssClass.Replace("HideForDesign", "");
      if (CtlPnlRicerca != null) CtlPnlRicerca.CssClass = CtlPnlRicerca.CssClass.Replace("HideForDesign", "");
      CtlPnlDettaglio.CssClass = CtlPnlDettaglio.CssClass.Replace("HideForDesign", "");
      CtlPnlElenco.CssClass = CtlPnlElenco.CssClass.Replace("ShowForDesign", "");
      if (CtlPnlRicerca != null) CtlPnlRicerca.CssClass = CtlPnlRicerca.CssClass.Replace("ShowForDesign", "");
      CtlPnlDettaglio.CssClass = CtlPnlDettaglio.CssClass.Replace("ShowForDesign", "");
      SetAttributes_Invio();
      SetAttributes_Other();
      return true;
    }
    private bool DisplayPanels()
    {
      // IMPOSTO VISIBILITA' PANNELLI
      if (CtlPnlRicerca != null)
        CtlPnlRicerca.Visible = true;
      CtlPnlElenco.Visible = true;
      CtlPnlDettaglio.Visible = true;
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
            StatoDetails = eStatusDetails.VISIONE;
            CtlPnlDettaglio.Enabled = false;
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
                CtlBtnNuovo.Visible = OnDetails_BtnNuovo_Visible;
              if (CtlBtnSalva != null)
                CtlBtnSalva.Visible = true;
              if (CtlBtnAnnulla != null)
                CtlBtnAnnulla.Visible = true;
              CtlPnlDettaglio.Enabled = true;
            }
            else
            {
              CtlBtnElimina.Visible = OnDetails_BtnElimina_Visible;
              CtlBtnStampa.Visible = OnDetails_BtnStampa_Visible;
              if (CtlBtnNuovo != null)
                CtlBtnNuovo.Visible = false;
              if (CtlBtnSalva != null)
                CtlBtnSalva.Visible = false;
              if (CtlBtnAnnulla != null)
                CtlBtnAnnulla.Visible = true;
              CtlPnlDettaglio.Enabled = false;
            }
            break;
          }
      }
      return true;
    }

    // DEFINIZIONE FUNZIONI PRIVATE SUI FILTRI
    protected void LoadDBParameterByFiltri()
    {
      IDbDataParameter p = null;
      this.DB.ClearParameter();
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

          this.DB.AddParameter(p);
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
        Stato = eStatusPage.ELENCO;
        DisplayPanels();

        // UTILIZZARE UNA DELLE DUE OPZIONI 
        if (!RunSearchToLoad)
        {
          // MOSTRA GRID VUOTO
          CtlTvwElenco.Nodes.Clear();
        }
        else
        {
          // MOSTRA TUTTO
          SaveFiltri();
          CaricaTreeView();
        }
        // AGGINGO ATTRIBUTI 
        if (CtlBtnElimina != null) CtlBtnElimina.Attributes["onclick"] = "javascript: return confirm('Sei sicuro di voler eliminare?');";
      }
      OnLoadAfter?.Invoke(sender, e);
    }

  } //END CLASS
} //END NAMESPACE