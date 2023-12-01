using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BInterface;
using BArts.BIO;
using BArts.BMail;
using BArts.BReports;
using BArts.BSecurity;
using BArts.BWeb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BPopupPageBase : BBaseWebPage
  {
    public BPopupPageBase()
    {
      // EVENTI INTERCETTATI
      this.Init += BPopupPageBase_Init;
      this.Load += Page_Load;
    }

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
    #region public BTemplateBaseLibrary.BsysFunzioni Funzione
    private BTemplateBaseLibrary.BsysFunzioni m_Funzione;
    public BTemplateBaseLibrary.BsysFunzioni Funzione
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

    #region public BConfiguration Config
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
    #endregion

    #region public BConnection DB
    public BConnection DB
    {
      get
      {
        if (BWebConfig.WebSiteUseDB && base.Session[ModConstantList.K_SE_SYSDB] == null && AutoRedirect) //?? autoredirect??
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

    public virtual bool CheckAuth { get; set; } = true;
    public virtual bool ShowProgresBar { get; set; } = true;
    public virtual bool AutoRedirect { get; set; } = true;

    #region protected override bool VS_Debug
    protected override bool VS_Debug
    {
      get
      {
        string sVSDebug = BWebConfig.VS_DEBUG.ToString();
        if ((sVSDebug.ToUpper() ?? "") == "TRUE")
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    #endregion

    //DEFINIZIONE METODI OVERRIDE
    public override string BTheme()
    {
      return BWebConfig.BTheme;
    }

    //DEFINIZIONE METODI OVOERRIDABLE
    public virtual void ChangeUrlAuthentication(ref string url)
    {
    }
    public virtual void SetAttributes_AddEvents()
    {
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

    #region public void MsgBox(...)
    public void MsgBox(string Messaggio, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      ((Web)Master).MsgBoxManager.Show(Messaggio, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      ((Web)Master).MsgBoxManager.Show(Messaggio, Titolo, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, BArts.BWeb.BControls.BMsgBox.ButtonClick BtnSub, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      ((Web)Master).MsgBoxManager.Show(Messaggio, Titolo, BtnSub, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, bool Confirm, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      ((Web)Master).MsgBoxManager.Show(Messaggio, Titolo, Confirm: Confirm, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    public void MsgBox(string Titolo, string Messaggio, bool Confirm, BArts.BWeb.BControls.BMsgBox.ButtonClick BtnSub, string CssIcona = "BIconInfo32", Unit Altezza = default, Unit Larghezza = default, WebControl CtlFocusOnClick = null)
    {
      ((Web)Master).MsgBoxManager.Show(Messaggio, Titolo, Confirm, BtnSub, Altezza: Altezza, Larghezza: Larghezza, CssIcona: CssIcona, CtlFocusOnClick: CtlFocusOnClick);
    }
    #endregion

    public void BRedirect(string url)
    {
      ((BBaseWebPage)this.Page).BPage.BRedirect(url);
    }
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
        ObjN.DataNotifica = DateTime.Now;
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
    public bool ReadAuthFunzione(BTemplateBaseLibrary.BsysFunzioni Funzione)
    {
      DataTable dt = null;
      try
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
    public bool ScriviFileOnServer(BFile f, string SubFolder = "", string Prefix = "", bool CreateFoldereIfNotExist = false)
    {
      string PathFile = "";
      string msg = "";
      try
      {
        PathFile = BWebConfig.ServerFileShare_Folder;
        if (!string.IsNullOrEmpty(SubFolder))
          PathFile = BGlobal.CreatePathFile(PathFile, SubFolder);
        if (BWebConfig.ServerFileShare_PathRelative)
        {
          if (!string.IsNullOrEmpty(Prefix))
            PathFile = BGlobal.CreatePathFile(Prefix, PathFile);
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

      // CONTROLLO OFFLINE
      if (BWebConfig.OffLine)
      {
        if (!Request.IsLocal)
        {
          ShowMessagePage(BWebConfig.OffLine_MSG);
          return false;
        }
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
        //BRedirect(BGlobal.CreatePathFile(Request.ApplicationPath, ModConstantList.K_SYS_HOMECONSOLEDEVELOPER));
        BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
      }
      else if (BUtenti.CheckStartAuthentication() && UtenteEntrato == null)
      {
        //BRedirect(BGlobal.CreatePathFile(Request.ApplicationPath, ModConstantList.K_SYS_PAGELOGIN));
        BRedirect(ModConstantList.K_PAGE_LOGIN);
      }

      Session[ModConstantList.K_SE_SYSINITAPP] = true;
      return true;
    }
    private void RegistraAccesso(BUtenti utente)
    {
      utente.WriteEntry(Request.UserHostAddress, Request.UserHostName);
      if (utente.Profili.Count > 1)
      {
        BRedirect(ModConstantList.K_PAGE_SELECTPROFILO);
      }
      else
      {
        if (((BUtenti)UtenteEntrato).Developer)
        {
          ((BUtenti)UtenteEntrato).IDSysProfilo = -1;
          ((BUtenti)UtenteEntrato).IDSysSistema = -1;
          ((BUtenti)UtenteEntrato).Accesso.IDSysSistema = -1;
          ((BUtenti)UtenteEntrato).Accesso.IDSysProfilo = -1;
        }
        else
        {
          ((BUtenti)UtenteEntrato).IDSysProfilo = utente.Profili[0].IDSysProfilo;
          ((BUtenti)UtenteEntrato).IDSysSistema = utente.Profili[0].IDSysSistema;
          ((BUtenti)UtenteEntrato).Accesso.IDSysSistema = utente.Profili[0].IDSysSistema;
          ((BUtenti)UtenteEntrato).Accesso.IDSysProfilo = utente.Profili[0].IDSysProfilo;
        }

        if (!((BUtenti)UtenteEntrato).Accesso.Update(false))
        {
          WriteLog("CtlLogin.Login():", "Salvataggio accesso fallito.", BEnumerations.eSeverity.ERROR);
        }
        // TRACCIO SCELTA PROFILO
        if (!((BUtenti)UtenteEntrato).Developer)
        {
          ((BUtenti)UtenteEntrato).WriteOperation("Accesso al sistema " + utente.Profili[0].SysSistema.Descrizione
                                                + " con profilo " + utente.Profili[0].SysProfilo.Descrizione);
        }

        BRedirect(ModConstantList.K_PAGE_HOME);
      }
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
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = UtenteEntrato.IDAccesso;
          IDSysUtente = UtenteEntrato.Username;
        }

        ModLog.ScriviLog(DB, Config, IDSysUtente, exp, "default.InitializeDBApplication", "", BEnumerations.eSeverity.ERROR, IDAccesso, Page);
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

    //DEFINIZIONE EVENTI INTERCETTATI
    private void BPopupPageBase_Init(object sender, EventArgs e)
    {
      this.SetAttributes_AddEvents();
    }
    private void Page_Load(object sender, EventArgs e)
    {
      string RelUrl = "";

      // CHECK INITAPPLICATION
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null && !((bool)base.Session[ModConstantList.K_SE_SYSINITAPP]))
      {
        if (!InizializzaApplicazione())
          return;
      }

      // INIZIALIZZA LINGUA
      Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");

      // CONTROLLO LICENZA
      if (ModInit.mbcVersione == ModEnumeration.eVersione.bDemo)
      {
#pragma warning disable CS0162 // È stato rilevato codice non raggiungibile -- DISABILITO WARNING NON CORRETTO
        if (DateTime.Now >= ModInit.mbcScadenza)
#pragma warning restore CS0162 // È stato rilevato codice non raggiungibile -- DISABILITO WARNING NON CORRETTO
        {
          Response.End();
          return;
        }
      }

      // INIZIALIZZO VARIABILI DI SESSIONE
      if (!LoadGlobalSession()) return;

      // SVUOTO LA CACHE
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      Response.Cache.SetExpires(DateTime.Now);
      Response.Cache.SetLastModified(DateTime.Now);
      Response.Cache.SetAllowResponseInBrowserHistory(false);

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
      if ((RelUrl.ToUpper() ?? "") != ModConstantList.K_SYS_PAGELOGIN & !BWebConfig.InitDB)
      {
        if ((RelUrl.ToUpper() ?? "") != ModConstantList.K_SYS_PAGEDEFAULT & CheckAuth)
        {
          m_Funzione = new BTemplateBaseLibrary.BsysFunzioni(RelUrl, DB);
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

    }

  } //END CLASS
} //END NAMESPACE