using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BInterface;
using BArts.BIO;
using BArts.BMail;
using BArts.BReports;
using BArts.BSecurity;
using BArts.BWeb;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace PosteWebTemplate1
{
  public abstract class BPageBase : Page
  {
    public BPageBase()
    {
      this.Init += BPageBase_Init;
      this.Load += BPageBase_Load;
    }

    //DEFINIZIONE DATI 
    protected bool IsSessionExpired;


    // DEFINIZIONE EVENTI
    public event AttachCommandEventHandler AttachCommand;
    public delegate void AttachCommandEventHandler();

    public event EventManagerEventHandler EventManager;
    public delegate void EventManagerEventHandler(string CommandName, string Args, string sender);

    // DEFINIZIONE PROPRIETA'
    #region public Guid PageID
    private const string K_PAGEID = "PAGEID";
    public Guid PageID
    {
      get
      {
        if (ViewState[K_PAGEID] == null)
        {
          ViewState[K_PAGEID] = Guid.NewGuid();
        }
        return (Guid)ViewState[K_PAGEID];
      }
    }
    #endregion
    public WebControl CtlFocusOnCheckBeforeUpdateAlert;

    #region public int SysIDFunzione
    private int m_SysIDFunzione = -1;
    public int SysIDFunzione
    {
      get
      {
        return m_SysIDFunzione;
      }
    }
    #endregion
    #region public BsysFunzioni Funzione
    private BsysFunzioni m_Funzione;
    public BsysFunzioni Funzione
    {
      get
      {
        return m_Funzione;
      }
    }
    #endregion
    #region public int SysIDRuolo
    private int m_SysIDRuolo = -1;
    public int SysIDRuolo
    {
      get
      {
        return m_SysIDRuolo;
      }
    }
    #endregion

    #region public IBUtenteEntrato UtenteEntrato
    public IBUtenteEntrato UtenteEntrato
    {
      get
      {
        return (IBUtenteEntrato)base.Session[ModConstantList.K_SE_SYSUTENTEENTRATO];
      }
    }
    #endregion
    #region public BUtenti BSysUtenteEntrato
    public BUtenti BSysUtenteEntrato
    {
      get
      {
        if (UtenteEntrato == null)
          return null;
        if (UtenteEntrato is BUtenti)
        {
          return (BUtenti)UtenteEntrato;
        }
        else
        {
          return null;
        }
      }
    }
    #endregion

    public BConfiguration Config
    {
      get
      {
        if (base.Session[ModConstantList.K_SE_SYSCONFIGURATION] == null && AutoRedirect)
        {
          return null;
        }
        return (BConfiguration)base.Session[ModConstantList.K_SE_SYSCONFIGURATION];
      }
      set
      {
        base.Session[ModConstantList.K_SE_SYSCONFIGURATION] = value;
      }
    }

    //DEFINIZIONE PROPRIETA' READONLY
    public Web BMaster
    {
      get
      {
        return (Web)(this.Page.Master);
      }
    }

    #region public BConnection DB
    public BConnection DB
    {
      get
      {
        if (BWebConfig.WebSiteUseDB && base.Session[ModConstantList.K_SE_SYSDB] == null && AutoRedirect)
        {
          return null;
        }
        return (BConnection)base.Session[ModConstantList.K_SE_SYSDB];
      }
    }
    #endregion
    #region public BConnection DBUser
    public BConnection DBUser
    {
      get
      {
        if (BWebConfig.WebSiteUseDB && base.Session[ModConstantList.K_SE_SYSDBUSER] == null && AutoRedirect)
        {
          return null;
        }

        return (BConnection)base.Session[ModConstantList.K_SE_SYSDBUSER];
      }
    }
    #endregion
    #region public BReportingService ReportingServices
    public BReportingService ReportingServices
    {
      get
      {
        return (BReportingService)base.Session[ModConstantList.K_SE_SYSREPORTINGSERVICES];
      }
      set
      {
        base.Session[ModConstantList.K_SE_SYSREPORTINGSERVICES] = value;
      }
    }
    #endregion

    //DEFINIZIONE PROPRIETA' DI GESTIONE CONTROLLI DI SALVATAGGIO
    #region public List<string> CheckBeforeUpdateAlert
    private string K_CheckBeforeUpdateAlert = ".CheckBeforeUpdateAlert";
    public List<string> CheckBeforeUpdateAlert
    {
      get
      {
        return (List<string>)base.Session[PageID.ToString() + K_CheckBeforeUpdateAlert];
      }
      set
      {
        base.Session[PageID.ToString() + K_CheckBeforeUpdateAlert] = value;
      }
    }
    #endregion



    // DEFINIZIONE PROPRIETA' OVVERRIDABLE
    public virtual bool CheckAuth { get; set; } = true;
    public virtual bool ShowProgresBar { get; set; } = true;
    public virtual bool AutoRedirect { get; set; } = true;

    // DEFINIZIONE CONTROLLI
    protected Literal LitScript { get; set; }

    // DEFINIZIONE METODI OVERRIDABLE
    public virtual void ChangeUrlAuthentication(ref string url) { }
    public virtual void Indietro_Click() { }
    protected virtual void SetAttributes_AddEvents()
    {
    }
    protected virtual void BPage_Init(object sender, EventArgs e)
    {

    }
    protected virtual void BPage_Load(object sender, EventArgs e)
    {

    }
    protected virtual void BPage_AttachCommand()
    {
    }

    //DEFINIZIONE METODI PER PAGETABLEBASE
    protected string GetAndClearAllMsg_CheckBeforeUpdateAlert()
    {
      string ret = "";
      foreach (string msg in CheckBeforeUpdateAlert)
      {
        ret += msg + BVisualBasic.vbNewLine();
      }
      this.CheckBeforeUpdateAlert.Clear();
      this.CheckBeforeUpdateAlert = null;
      return ret;
    }

    // DEFINIZIONE METODI MASTER PAGE
    public void RefreshUpdContainer()
    {
      ((Web)Master).RefreshUpdPnl();
    }
    public void DisabilitaInvio(bool valore)
    {
      ((BBaseMasterPage)Master).DisabilitaInvio = valore;
    }
    public void AbilitaKeyDown(bool valore, string FunctionJS = "")
    {
      if (!string.IsNullOrEmpty(FunctionJS))
        ((BBaseMasterPage)Master).FunctionJSOnKeyDown = FunctionJS;
      ((BBaseMasterPage)Master).EnabledKeyDownEventOnPage = valore;
    }

    // DEFINIZIONE METODI SU AUTENTICAZIONE
    public bool ReadAuthFunzione(BsysFunzioni Funzione)
    {
      DataTable dt = null;
      try
      {
        if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.WPAppChild)
        {
          DB.ClearParameter();
          DB.AddParameter("@IDSysFunzione", Funzione.ID);
          DB.AddParameter("@IDUtente", BSysUtenteEntrato.IDUtenteWP);
          if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
          {
            DB.AddParameter("@Developer", UtenteEntrato.Developer);
          }

          dt = DB.ApriDT("BSP_sysGetAuthFunzioniWP", CommandType.StoredProcedure);
        }
        else
        {
          DB.ClearParameter();
          DB.AddParameter("@IDSysFunzione", Funzione.ID);
          if (UtenteEntrato != null && !UtenteEntrato.IsNothing && UtenteEntrato.IDProfilo != -1)
          {
            DB.AddParameter("@IDSysProfilo", UtenteEntrato.IDProfilo);
          }

          if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
          {
            DB.AddParameter("@Developer", UtenteEntrato.Developer);
          }

          dt = DB.ApriDT("BSP_sysGetAuthFunzioni", CommandType.StoredProcedure);

        }
        if (dt != null && dt.Rows.Count > 0)
        {
          m_SysIDFunzione = (int)(dt.Rows[0]["IDFunzione"]);
          m_SysIDRuolo = (int)(dt.Rows[0]["IDRuolo"]);
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("BPageTableBase.ReadAuthFunzione()", "", ex, BEnumerations.eSeverity.ERROR);
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

    // DEFINIZIONE FUNZIONI PRIVATE
    private void LoadAttachCommand()
    {
      //EnsureChildControls();
      //LitScript.Text = "";
      this.BPage_AttachCommand();
      AttachCommand?.Invoke();
    }
    protected void BEventManager()
    {
      string Args = Request.Form["__EVENTARGUMENT"];
      string Target = Request.Form["__EVENTTARGET"];
      string Command = "";
      if (Args == null)
        return;
      var aArgs = Args.Split('|');
      if (aArgs.Count() == 2)
      {
        Command = aArgs[0];
        Args = aArgs[1];
        EventManager?.Invoke(Command, Args, Target);
      }
    }


    // DEFINIZIONE FUNZIONI PRIVATE INIZIALIZZAZIONE
    private bool InizializzaApplicazione()
    {
      BConfiguration conf = null;
      BReportingService report = null;
      Session.Clear();

      // INIZIALIZZAZIONE DATABASE APPLICAZIONE 
      if (BWebConfig.WebSiteUseDB && !this.InitializeDBApplication(ModInit.TipoDB))
      {
        ShowMessagePage("Connessione al database assente.");
        return false;
      }

      if (BWebConfig.WebSiteUseDB && !string.IsNullOrEmpty(BWebConfig.DBUser_DB) && !this.InitializeDBUser(ModInit.TipoDB))
      {
        ShowMessagePage("Connessione al database utente assente.");
        return false;
      }

      // INIZIALIZZAZIONE CONFIGURAZIONE
      if (Config == null && !BWebConfig.InitDB)
      {
        conf = new BConfiguration(DB);
        Config = conf;
      }

      // VERIFICA VERSIONE DEL BROWSER (CHROME - SAFARI - FIREFOX - IE9 - IE10 - IE11)
      if (!(Request.UserAgent.ToUpper().Contains("TRIDENT/8.0")
              || Request.UserAgent.ToUpper().Contains("TRIDENT/7.0")
              || Request.UserAgent.ToUpper().Contains("TRIDENT/6.0")
              || Request.UserAgent.ToUpper().Contains("TRIDENT/5.0")
              || Request.UserAgent.ToUpper().Contains("CHROME")
              || Request.UserAgent.ToUpper().Contains("FIREFOX")
              || Request.UserAgent.ToUpper().Contains("SAFARI")))
      {
        WriteLog("default.Page_Load():", "User Agent = " + Request.UserAgent, BEnumerations.eSeverity.INFORMATION);
        ShowMessagePage(BWebConfig.Message_Old_Browser);
        return false;
      }

      // INIZIALIZZAZIONE REPORTINGSERVICE
      if (ReportingServices == null)
      {
        report = new BReportingService(BWebConfig.ServerReport_VERSION, BWebConfig.ServerReport_Nome, BWebConfig.ServerReport_SSL);
        report.Domain = BWebConfig.ServerReport_Domain;
        report.Username = BWebConfig.ServerReport_User;
        report.Password = BWebConfig.ServerReport_PWD;
        report.ReportFolder = BWebConfig.ServerReport_FOLDER;
        report.ClearLog();
        ReportingServices = report;
      }

      // INIZIALIZZA SAVE GLOBAL SESSION
      SaveGlobalSession();

      // INIZIALIZZAZIONE APPLICATIVO
      if (BWebConfig.InitDB)
      {
        BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
      }
      else
      {
        if (BWebConfig.OffLine)
        {
          if (!Request.IsLocal)
          {
            ShowMessagePage(BWebConfig.OffLine_MSG);
            Session[ModConstantList.K_SE_SYSINITAPP] = true;
            return true;
          }
        }
        if (BUtenti.CheckStartAuthentication() && UtenteEntrato == null && AutoRedirect)
        {
          switch (BWebConfig.TipoApplicazione)
          {
            case BWebConfig.eTipoApplicazione.WPAppChild:
            case BWebConfig.eTipoApplicazione.WPInterna:
              break;
            default:
              this.BRedirect(ModConstantList.K_PAGE_LOGIN);
              break;
          }
        }
        else
        {
          //che si fa?
        }

      }

      Session[ModConstantList.K_SE_SYSINITAPP] = true;
      return true;
    }
    private bool InitializeDBApplication(ModEnumeration.eTipoDB mbcTipoDB)
    {
      try
      {
        // Impostazione della version
        ModInit.InitVersion(ref ModInit.SetDB, mbcTipoDB);

        // Caricamento DB
        if (LoadDB(mbcTipoDB))
        {
          try
          {
            DB.ApriDatabase();
          }
          catch (Exception exp)
          {
            this.WriteLog("default.InitializeDBApplication", "", exp, BEnumerations.eSeverity.ERROR);
            return false;
          }
        }
        else
        {
          return false;
        }

        return true;
      }
      catch (Exception exp)
      {
        this.WriteLog("default.InitializeDBApplication", "", exp, BEnumerations.eSeverity.ERROR);
        ShowMessagePage(exp.Source + " - " + exp.Message);
        return false;
      }
      finally
      {
        DB?.ChiudiDatabase();
      }
    }
    private bool LoadDB(ModEnumeration.eTipoDB mbcTipoDB)
    {
      string PathDB = "";
      BConnection db;
      try
      {
        if (!string.IsNullOrEmpty(BWebConfig.DBApp_DB))
        {
          if (mbcTipoDB == ModEnumeration.eTipoDB.bMSSQL && string.IsNullOrEmpty(BWebConfig.DBApp_Server)) return false;
        }
        else
          return false;

        switch (ModInit.TipoDB)
        {
          case ModEnumeration.eTipoDB.bMSAccess:
          case ModEnumeration.eTipoDB.bMSAccess2007:
            {
              PathDB = Server.MapPath(BWebConfig.DBApp_DB);
              break;
            }
          default:
            {
              PathDB = BWebConfig.DBApp_DB;
              break;
            }
        }
        ModInit.SetConnectionString(ModInit.SetDB, PathDB, BWebConfig.DBApp_Server, BWebConfig.DBApp_User, BWebConfig.DBApp_PWD);
        db = new BConnection(ModInit.SetDB);
        base.Session[ModConstantList.K_SE_SYSDB] = db;
        return true;
      }
      catch (Exception exp)
      {
        this.WriteLog("default.LoadDB", "", exp, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private bool InitializeDBUser(ModEnumeration.eTipoDB mbcTipoDB)
    {
      try
      {
        // Impostazione della version
        ModInit.InitVersion(ref ModInit.SetDBUser, mbcTipoDB);

        // Caricamento DB
        if (LoadDBUser(mbcTipoDB))
        {
          try
          {
            DBUser.ApriDatabase();
          }
          catch (Exception exp)
          {
            this.WriteLog("default.InitializeDBUser", "", exp, BEnumerations.eSeverity.ERROR);
            return false;
          }
        }
        else
        {
          return false;
        }

        return true;
      }
      catch (Exception exp)
      {
        WriteLog("default.InitializeDBApplication", "", exp, BEnumerations.eSeverity.ERROR);
        ShowMessagePage(exp.Source + " - " + exp.Message);
        return false;
      }
      finally
      {
        if (DBUser != null)
        {
          DBUser.ChiudiDatabase();
        }
      }
    }
    private bool LoadDBUser(ModEnumeration.eTipoDB mbcTipoDB)
    {
      string PathDB = "";
      BConnection db = null;
      try
      {
        // Apertura DB
        if (!string.IsNullOrEmpty(BWebConfig.DBUser_DB))
        {
          if (mbcTipoDB == ModEnumeration.eTipoDB.bMSSQL && string.IsNullOrEmpty(BWebConfig.DBUser_Server)) return false;
        }
        else
          return false;

        switch (ModInit.TipoDB)
        {
          case ModEnumeration.eTipoDB.bMSAccess:
          case ModEnumeration.eTipoDB.bMSAccess2007:
            {
              PathDB = Server.MapPath(BWebConfig.DBUser_DB);
              break;
            }
          default:
            {
              PathDB = BWebConfig.DBUser_DB;
              break;
            }
        }

        ModInit.SetConnectionString(ModInit.SetDBUser, PathDB, BWebConfig.DBUser_Server, BWebConfig.DBUser_User, BWebConfig.DBUser_PWD);
        db = new BConnection(ModInit.SetDBUser);
        base.Session[ModConstantList.K_SE_SYSDBUSER] = db;
        return true;
      }
      catch (Exception exp)
      {
        this.WriteLog("default.LoadDBUser", "", exp, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE FUNZIONI OVVERRIDES
    //protected override void CreateChildControls()
    //{
    //  LitScript = new Literal();
    //  LitScript.ID = "LitScript";
    //  LitScript.Visible = true;
    //  Controls.Add(LitScript);
    //  base.CreateChildControls();
    //}

    // GESTIONE VIEW STATE
    protected override object LoadPageStateFromPersistenceMedium()
    {
      Guid viewStateGuid;
      byte[] rawData;
      SqlConnection cnn = null;
      SqlCommand cmd = null;
      SqlDataReader reader = null;
      MemoryStream stream = null;
      var Formatter = new LosFormatter();
      try
      {
        if (!BWebConfig.ViewStateOnDB)
        {
          return base.LoadPageStateFromPersistenceMedium();
        }

        viewStateGuid = GetViewStateGuid();
        rawData = null;
        cnn = new SqlConnection(BWebConfig.ViewState_ConncetionString());
        cmd = new SqlCommand("BSP_sysViewState_GET", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add("@viewStateId", SqlDbType.UniqueIdentifier).Value = viewStateGuid;
        cnn.Open();
        reader = cmd.ExecuteReader();
        if (reader.Read())
        {
          rawData = (byte[])Array.CreateInstance(typeof(byte), reader.GetInt32(0));
        }

        if (reader.NextResult() && reader.Read())
        {
          reader.GetBytes(0, 0, rawData, 0, rawData.Length);
        }

        stream = new MemoryStream(rawData);
        return Formatter.Deserialize(stream);
      }
      catch (Exception ex)
      {
        this.WriteLog("BPageBase.LoadPageStateFromPersistenceMedium", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
      finally
      {
        if (reader != null)
        {
          reader.Close();
          reader = null;
        }

        if (cmd != null)
        {
          cmd.Dispose();
          cmd = null;
        }

        if (cnn != null)
        {
          if (cnn.State != ConnectionState.Closed) cnn.Close();
          cnn.Dispose();
          cnn = null;
        }

        if (stream != null)
        {
          stream.Close();
          stream.Dispose();
          stream = null;
        }

        Formatter = null;
      }
    }
    protected override void SavePageStateToPersistenceMedium(object state)
    {
      Guid viewStateGuid;
      HtmlInputHidden control;
      SqlConnection cnn = null;
      SqlCommand cmd = null;
      SqlDataReader reader = null;
      MemoryStream stream = null;
      var Formatter = new LosFormatter();
      try
      {
        if (!BWebConfig.ViewStateOnDB)
        {
          base.SavePageStateToPersistenceMedium(state);
          return;
        }

        viewStateGuid = GetViewStateGuid();
        stream = new MemoryStream();
        Formatter = new LosFormatter();
        Formatter.Serialize(stream, state);
        cnn = new SqlConnection(BWebConfig.ViewState_ConncetionString());
        cmd = new SqlCommand("bsp_sysViewState_SET", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add("@viewStateId", SqlDbType.UniqueIdentifier).Value = viewStateGuid;
        cmd.Parameters.Add("@value", SqlDbType.Image).Value = stream.ToArray();
        cmd.Parameters.Add("@timeout", SqlDbType.Int).Value = BWebConfig.ViewStateTimeOut;
        cnn.Open();
        cmd.ExecuteNonQuery();
        control = (HtmlInputHidden)FindControl("__VIEWSTATEGUID");
        if (control == null)
        {
          ClientScript.RegisterHiddenField("__VIEWSTATEGUID", viewStateGuid.ToString());
        }
        else
        {
          control.Value = viewStateGuid.ToString();
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("BPageBase.SavePageStateToPersistenceMedium", "", ex, BEnumerations.eSeverity.ERROR);
      }
      finally
      {
        if (reader != null)
        {
          reader.Close();
          reader = null;
        }
        if (cmd != null)
        {
          cmd.Dispose();
          cmd = null;
        }
        if (cnn != null)
        {
          if (cnn.State != ConnectionState.Closed) cnn.Close();
          cnn.Dispose();
          cnn = null;
        }
        if (stream != null)
        {
          stream.Close();
          stream.Dispose();
          stream = null;
        }
        Formatter = null;
      }
    }
    private Guid GetViewStateGuid()
    {
      string viewStateKey;
      try
      {
        viewStateKey = Request.Form["__VIEWSTATEGUID"];
        if (viewStateKey != null && viewStateKey.Length > 0)
        {
          return new Guid(viewStateKey);
        }
        else
        {
          viewStateKey = Request.QueryString["__VIEWSTATEGUID"];
          if (viewStateKey != null && viewStateKey.Length > 0)
          {
            return new Guid(viewStateKey);
          }
          else
          {
            return Guid.NewGuid();
          }
        }
      }
      catch (FormatException ex)
      {
        this.WriteLog("BPageBase.GetViewStateGuid", "", ex, BEnumerations.eSeverity.ERROR);
        return Guid.NewGuid();
      }
    }

    // DEFINIZIONE METODI PUBLICI
    public bool LoadGlobalSession()
    {
      try
      {
        // DATABASE
        ModInit.SetDB = (BSettingDatabase)base.Session[ModConstantList.K_SE_SYSSETDB];
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BPageBase.LoadGlobalSession", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public bool SaveGlobalSession()
    {
      try
      {
        // DATABASE
        base.Session[ModConstantList.K_SE_SYSSETDB] = ModInit.SetDB;
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BPageBase.SaveGlobalSession", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    [Obsolete("L'attuale metodo è deprecato. Il metodo è stato sostituito con MsgBox.")]
    public void Alert(string Testo)
    {
      Testo = Testo.Replace("'", @"\'");
      ScriptManager.RegisterStartupScript(this, GetType(), "ALERT", "alert('" + Testo + "');", true);
    }

    public void MsgBox(string Messaggio, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      BMaster.MsgBoxManager.Show(Messaggio, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      BMaster.MsgBoxManager.Show(Messaggio, Titolo, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, BArts.BWeb.BControls.BMsgBox.ButtonClick BtnSub, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      BMaster.MsgBoxManager.Show(Messaggio, Titolo, BtnSub, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, bool Confirm, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      BMaster.MsgBoxManager.Show(Messaggio, Titolo, Confirm: Confirm, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, bool Confirm, BArts.BWeb.BControls.BMsgBox.ButtonClick BtnSub, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      BMaster.MsgBoxManager.Show(Messaggio, Titolo, Confirm, BtnSub, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }

    public void ShowToast(string Messaggio, string Titolo = "Notifica")
    {
      BMaster.ToastManager.ShowToast(Titolo, Messaggio);
    }

    public void BRedirect(string url)
    {
      ((BBaseMasterPage)Master).BRedirect(url);
    }

    // FUNZIONI DI MESSAGGISTICA DI SISTEMA
    public void ShowMessagePage(string msg)
    {
      Session[ModConstantList.K_SE_SYSMSG] = msg;
      Session[ModConstantList.K_SE_SYSINITAPPFAILED] = true;
      BRedirect(ModConstantList.K_PAGE_SHOWMESSAGEPAGE);
    }

    // DEFINIZIONE METODI PUBLICI SENDMAIL
    public bool SendMail(string Oggetto, string Body, params string[] Destinatari)
    {
      var lD = Destinatari.ToList();
      return SendMail(Oggetto, Body, lD);
    }
    public bool SendMail(string Oggetto, string Body, List<string> Destinatari, List<string> Cc = null, List<string> BCc = null, List<string> Allegati = null)
    {
      BSenderMailConfig ConfigMail = null;
      BSMTP smtp = null;
      bool ret = false;
      string sDest = "";
      string sCc = "";
      string sBCc = "";

      try
      {
        ConfigMail = new BSenderMailConfig(BWebConfig.SendMail_SMTPServer, int.Parse(BWebConfig.SendMail_SMTPPort),
                                                                          BWebConfig.SendMail_UserName, BArts.BSecurity.BCrypter.Decrypt(BWebConfig.SendMail_Password),
                                                                          BWebConfig.SendMail_SSL, Config.EmailSegnalazioni);
        ConfigMail.SenderType = BWebConfig.SendMail_SenderType;
        ConfigMail.DescrizioneProfilo = BWebConfig.SendMail_NomeProfilo;
        ConfigMail.NomeProfilo = BWebConfig.SendMail_NomeProfilo;
        ConfigMail.NomeAccount = BWebConfig.SendMail_NomeAccount;
        smtp = new BSMTP(ConfigMail);

        if (smtp != null)
        {
          foreach (string email in Destinatari)
            sDest += email + ";";
          if (Cc != null)
          {
            foreach (string email in Cc)
              sCc += email + ";";
          }

          if (BCc != null)
          {
            foreach (string email in BCc)
              sBCc += email + ";";
          }

          if (BWebConfig.SendMail_SenderType == BSenderMailConfig.eSenderType.eSQLSERVER)
            smtp.Cnn = DB;

          ret = smtp.InviaMail(sDest, Oggetto, Body, BWebConfig.SendMail_UserName, BWebConfig.TitoloWebSite, sCc, sBCc);
        }

        if (!ret)
        {
          foreach (Exception ex in smtp.ExceptionList)
            WriteLog("BPageBase.SendMail()", "", ex, BEnumerations.eSeverity.ERROR);
        }

        return ret;
      }
      catch (Exception ex)
      {
        WriteLog("BPageBase.SendMail()", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (smtp != null)
        {
          smtp.Dispose();
          smtp = null;
        }
      }
    }

    // DEFINIZIONE METODI PUBLICI SENDNOTIFY
    public bool SendNotify(string Oggetto, string Body, bool LimitaVisibilita = false, int IDSysSistema = -1, int IDSysProfilo = -1, string IDSysUtente = "")
    {
      BTemplateBaseLibrary.BsysNotifiche ObjN = null;
      try
      {
        ObjN = new BTemplateBaseLibrary.BsysNotifiche(DB);
        ObjN.DataNotifica = DateAndTime.Now;
        if (string.IsNullOrEmpty(IDSysUtente))
        {
          ObjN.IDSysSistema = IDSysSistema;
          ObjN.IDSysProfilo = IDSysProfilo;
        }
        else
        {
          ObjN.IDSysUtente = IDSysUtente;
        }

        ObjN.Titolo = Oggetto;
        ObjN.Descrizione = Body;
        ObjN.LimitaVisibilita = true;
        return ObjN.Update();
      }
      catch (Exception ex)
      {
        WriteLog("BPageBase", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE METODI PUBLICI LOG
    public bool WriteLog(string EntryPoint, string Message, BEnumerations.eSeverity Severity)
    {
      return ModLog.ScriviLogUtenteEntrato(DB, Config, null, UtenteEntrato, EntryPoint, Message, Severity, Page);
    }
    public bool WriteLog(string EntryPoint, string Message, Exception Ex, BEnumerations.eSeverity Severity)
    {
      return ModLog.ScriviLogUtenteEntrato(DB, Config, Ex, UtenteEntrato, EntryPoint, Message, Severity, Page);
    }
    public bool WriteOperation(string Msg)
    {
      if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
      {
        ((BUtenti)UtenteEntrato).WriteOperation(Msg, SysIDFunzione);
      }
      else
      {
        return false;
      }
      return true;
    }

    // DEFINIZIONE METODI PUBLICI FILESYSTEM
    public bool ScriviFileOnServer(BFile f, string SubFolder = "", string Prefix = "", bool CreateFoldereIfNotExist = false)
    {
      string PathFile = "";
      string msg = "";
      try
      {
        PathFile = BWebConfig.ServerFileShare_Folder;
        if (!string.IsNullOrEmpty(SubFolder)) PathFile = BGlobal.CreatePathFile(PathFile, SubFolder);
        if (BWebConfig.ServerFileShare_PathRelative)
        {
          if (!string.IsNullOrEmpty(Prefix)) PathFile = BGlobal.CreatePathFile(Prefix, PathFile);
          PathFile = BGlobal.CreatePathFile("~/", PathFile);
          PathFile = Server.MapPath(PathFile);
        }
        else
        {
          PathFile = BGlobal.CreatePathFile(@"\\" + BWebConfig.ServerFileShare_Name, PathFile);
        }
        // VERIFICO ESISTEMZA DIRECTORY 
        if (!Directory.Exists(PathFile))
        {
          msg = @"PATH NON TROVATO <<" + PathFile + ">>";
          WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.WARNING);
          if (CreateFoldereIfNotExist)
          {
            if (Directory.CreateDirectory(PathFile) == null)
            {
              msg = @"CREAZIONE DIRECTORY <<" + PathFile + ">> FALLITA.";
              WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.ERROR);
              return false;
            }
            else
            {
              msg = @"DIRECTORY <<" + PathFile + ">> CREATA CON SUCCESSO.";
              WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.INFORMATION);
            }
          }
        }

        // CREO FILE
        PathFile = BGlobal.CreatePathFile(PathFile, f.Nome);
        if (File.Exists(PathFile))
        {
          msg = @"IL FILE <<" + PathFile + ">> ESISTE E' VERRA SOVRASCRITTO.";
          WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.INFORMATION);
        }

        // AUTHENTICATION
        if (BWebConfig.ServerFileShare_AuthRequired)
        {
          if (BAuthentication.ImpersonateValidUser(BWebConfig.ServerFileShare_User, BWebConfig.ServerReport_Domain, BCrypter.Decrypt(BWebConfig.ServerReport_PWD)))
          {
            msg = @"AUTENTICAZIONE RIUSCITA PER UTENTE <<" + BWebConfig.ServerReport_Domain + @"\" + BWebConfig.ServerFileShare_User + ">>";
            WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.INFORMATION);
          }
          else
          {
            msg = @"AUTENTICAZIONE NON RIUSCITA PER UTENTE <<" + BWebConfig.ServerReport_Domain + @"\" + BWebConfig.ServerFileShare_User + ">>";
            WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.ERROR);
            return false;
          }
        }

        msg = @"INIZIO SCRITTURA FILE SUL SERVER <<" + PathFile + ">>";
        WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.INFORMATION);

        // SCRIVO FILE
        File.WriteAllBytes(PathFile, f.Content);
        msg = @"FINE SCRITTURA FILE SUL SERVER <<" + PathFile + ">>";
        WriteLog("BPageBase.ScriviFileOnServer()", msg, BEnumerations.eSeverity.INFORMATION);
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("BPageBase.ScriviFileOnServer()", msg, ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // FUNZIONI REPORT
    public void ShowReport(BReport Rpt, string Url)
    {
      Session[sysReportViewer.K_SE_REPORT] = Rpt;
      Session[sysReportViewer.K_SE_URLCHIAMANTE] = Url;
    }

    // FUNZIONI DOWNLOAD
    public void DownloadFile(string FileName, string SubFolder = "", string AliasFileName = "")
    {
      Session[sysDownload.K_SE_FILENAME] = FileName;
      Session[sysDownload.K_SE_SUBFOLDER] = SubFolder;
      Session[sysDownload.K_SE_ALIASFILENAME] = AliasFileName;
    }
    public void DownloadFile(BFile BFile)
    {
      Session[sysDownloadByte.K_SE_FILENAME] = BFile;
    }

    // FUNZIONI EXPORT
    public void ExportToExcel(DataView dv, ModEnumeration.eFormatoExport Formato, string NomeFile)
    {
      Session[ModConstantList.K_EXPORTEXCEL_DTV] = dv;
      Session[ModConstantList.K_EXPORTEXCEL_FORMATO] = Formato;
      Session[ModConstantList.K_EXPORTEXCEL_NOMEFILE] = NomeFile;
      //		BRedirect("~/BSystem/sysEsportaExcel.aspx");
    }

    // DEFINIZIONE METODI PUBLIC PER ATTACH COMMAND
    public void AddAttachCommand(ModEnumeration.eAttachCommandType TypeCommand, string jsFunction, string Args)
    {
      string sTipoComando = ((byte)TypeCommand).ToString();
      string sArgs = jsFunction + "|" + Args;
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(jsFunction, sFunction, sTipoComando, sArgs, sFunction);
    }
    public void AddAttachOpenReport(string BtnStampaID, string PrefixPath = "BSystem/")
    {
      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.Report).ToString();
      string sArgs = BtnStampaID + "|" + PrefixPath + "sysReportViewer.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(BtnStampaID, sFunction, sTipoComando, sArgs, sFunction);
    }
    public void AddAttachExportExcel(string BtnExportID, string PrefixPath = "BSystem/")
    {
      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.Report).ToString();
      string sArgs = BtnExportID + "|" + PrefixPath + "sysEsportaExcel.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(BtnExportID, sFunction, sTipoComando, sArgs, sFunction);
    }
    public void AddAttachDownloadFile(string BtnRunID, string PrefixPath = "BSystem/")
    {
      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = BtnRunID + "|" + PrefixPath + "sysDownload.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(BtnRunID, sFunction, sTipoComando, sArgs, sFunction);
    }
    public void AddAttachDownloadFile(string BtnRunID, string PrefixPath = "BSystem/", bool AsByte = false)
    {
      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = BtnRunID + "|" + PrefixPath + "sysDownloadByte.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(BtnRunID, sFunction, sTipoComando, sArgs, sFunction);
    }
    public void AddAttachOpenPreviewReport(string BtnStampaID, string Titolo = "Anteprima di Stampa", string PrefixPath = "BSystem/")
    {
      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = BtnStampaID + "|" + PrefixPath + "sysPreviewReport.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(BtnStampaID, sFunction, sTipoComando, sArgs, sFunction);
    }

    public bool AddAttachOpenReportOnGridViewRow(GridViewRow row, string BtnStampaID, string PrefixPath = "BSystem/")
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnStampaID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.Report).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysReportViewer.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);

      return true;
    }
    public bool AddAttachExportExcelOnGridViewRow(GridViewRow row, string BtnExportID, string PrefixPath = "BSystem/")
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnExportID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.Report).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysEsportaExcel.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);
      return true;
    }
    public bool AddAttachDownloadFileOnGridViewRow(GridViewRow row, string BtnRunID, string PrefixPath = "BSystem/")
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnRunID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysDownload.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);
      return true;
    }
    public bool AddAttachDownloadFileOnGridViewRow(GridViewRow row, string BtnRunID, string PrefixPath = "BSystem/", bool AsByte = false)
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnRunID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysDownloadByte.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);
      return true;
    }
    public bool AddAttachOpenPreviewReportOnGridViewRow(GridViewRow row, string BtnStampaID, string PrefixPath = "BSystem/")
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnStampaID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.PreviewReport).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysPreviewReport.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);
      return true;
    }
    public bool AddAttachDownloadFileOnRepeaterItem(RepeaterItem row, string BtnRunID, string PrefixPath = "BSystem/")
    {
      WebControl ctl = null;
      if (row == null) return false;
      ctl = (WebControl)row.FindControl(BtnRunID);
      if (ctl == null) return false;

      string sTipoComando = ((byte)ModEnumeration.eAttachCommandType.DownloadFile).ToString();
      string sArgs = ctl.ClientID + "|" + PrefixPath + "sysDownload.aspx";
      string sFunction = "AttachCommand";
      BMaster?.BCommandsManager?.AddCommand(ctl.ClientID, sFunction, sTipoComando, sArgs, sFunction);
      return true;
    }


    public string GetRouteParam(int indexSegment)
    {
      IList l;
      int eFriendlyUrlSegments = 2;
      if (Page.RouteData.DataTokens != null && Page.RouteData.DataTokens.Values != null && Page.RouteData.DataTokens.Values.Count > 1 && Page.RouteData.DataTokens.Values.ElementAtOrDefault(eFriendlyUrlSegments) != null)
      {
        l = (IList)Page.RouteData.DataTokens.Values.ElementAtOrDefault(eFriendlyUrlSegments);
        if (l.Count > indexSegment)
        {
          return l[indexSegment].ToString();
        }
        else
        {
          return "";
        }
      }
      else
      {
        return "";
      }
    }

    public bool CheckSession()
    {
      return !this.IsSessionExpired;
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void BPageBase_Init(object sender, EventArgs e)
    {

      if (Context.Session != null)
      {
        if (Session.IsNewSession)
        {
          string CookieHeader = Request.Headers["Cookie"];
          if ((null != CookieHeader) && (CookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
          {
            this.IsSessionExpired = true;
          }
        }
      }
      if (!IsSessionExpired) this.BPage_Init(sender, e);
    }
    private void BPageBase_Load(object sender, EventArgs e)
    {
      string RelUrl = "";

      // SVUOTO LA CACHE
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      Response.Cache.SetExpires(DateTime.Now);
      Response.Cache.SetLastModified(DateTime.Now);
      Response.Cache.SetAllowResponseInBrowserHistory(false);

      // CHECK SESSION
      if (IsSessionExpired)
      {
        BRedirect(ModConstantList.K_PAGE_DEFAULT);
        Response.End();
        return;
      }

      // CHECK INIT CONNECTION
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null || !(bool)base.Session[ModConstantList.K_SE_SYSINITAPP])
      {
        if (!InizializzaApplicazione()) return;
      }

      // INIZIALIZZA LINGUA
      Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");


      // INIZIALIZZO VARIABILI DI SESSIONE
      if (!LoadGlobalSession()) return;

      //ADD EVENTS
      this.SetAttributes_AddEvents();

      // VERIFICO STATO AUTENTICAZIONE
      if ((BWebConfig.GestioneUtenti && UtenteEntrato != null && !UtenteEntrato.IsNothing) || !BWebConfig.AutenticazioneIniziale)
      {
        BMaster.ShowMenu();
      }
      else
      {
        BMaster.HideMenu();
      }

      // VERIFICO AUTENTICAZIONE PAGINA
      if (RouteData.DataTokens != null && RouteData.DataTokens.Values.Count > 1)
      {
        RelUrl = RouteData.DataTokens.Values.ElementAtOrDefault(1).ToString();
      }
      else
      {
        RelUrl = Request.AppRelativeCurrentExecutionFilePath;
      }
      ChangeUrlAuthentication(ref RelUrl);
      RelUrl = RelUrl.Replace("~/", "");
      m_Funzione = new BsysFunzioni(RelUrl, DB);
      if (RelUrl.ToUpper() != ModConstantList.K_SYS_PAGELOGIN && !BWebConfig.InitDB)
      {
        if (RelUrl.ToUpper() != ModConstantList.K_SYS_PAGEDEFAULT && CheckAuth)
        {
          if (m_Funzione == null || m_Funzione.IsNothing)
          {
            Response.Write("Non è stato possibile individuare la pagina selezionata!");
            Response.End();
            return;
          }
          if (Funzione.Auth && !ReadAuthFunzione(Funzione))
          {
            Response.Write("Non possiedi i privilegi per visualizzare questa pagina!");
            Response.End();
            return;
          }
        }
      }

      // TRACCIO OPERAZIONE DI ACCESSO ALLA PAGINA
      if (UtenteEntrato != null && !UtenteEntrato.IsNothing && !IsPostBack)
      {
        if (UtenteEntrato.UtentePadre != null)
        {
          ((BUtenti)UtenteEntrato).WriteOperation("Utente impersonificato : < " + ((BUtenti)UtenteEntrato).ID
                                            + " >," + " Effettuato accesso nella pagina : " + RelUrl + ";", m_Funzione.ID);
        }
        else
        {
          ((BUtenti)UtenteEntrato).WriteOperation("Effettuato accesso nella pagina: " + RelUrl + ";", m_Funzione.ID);
        }
      }

      //ENABLED SIDEBAR
      if (BMaster != null)
      {
        BMaster.EnabledSideBar = BWebConfig.UseSideBar;
        BMaster.IsVisibleSideBar = BWebConfig.DefaultSidebarOpen;
      }

      // ABILITAZIONE PROGRESS BAR UPDATE PANEL
      if (ShowProgresBar)
      {
        BMaster.ShowProgressPanel();
      }
      else
      {
        BMaster.HideProgressPnl();
      }

      // ATTACHCOMMAND
      LoadAttachCommand();

      //EVENT LOAD
      this.BPage_Load(sender, e);

      // EVENT MANAGER
      if (IsPostBack) BEventManager();
    }

  } //END CLASS
} //END NAMESPACE