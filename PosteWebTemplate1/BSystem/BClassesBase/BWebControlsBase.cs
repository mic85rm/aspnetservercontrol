using BArts;
using BArts.BData;
using BArts.BInterface;
using BArts.BIO;
using BArts.BMail;
using BArts.BReports;
using BArts.BWeb;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public class BWebControlsBase : UserControl
  {
    //DEFINIZIONE COSTRUTTORI
    public BWebControlsBase()
    {
      // DEFINIZIONE EVENTI INTERCETTATI
      this.Init += BWebControlsBase_Init;
      this.Load += BWebControlsBase_Load;
    }

    // DEFINIZIONE EVENTI
    public event AttachCommandEventHandler AttachCommand;
    public delegate void AttachCommandEventHandler();

    public event EventManagerEventHandler EventManager;
    public delegate void EventManagerEventHandler(string CommandName, string Args, string sender);

    public event ShowExtenderEventHandler ShowExtender;
    public delegate void ShowExtenderEventHandler();

    // DEFINIZIONE PROPRIETA'
    public IBUtenteEntrato UtenteEntrato
    {
      get
      {
        return (IBUtenteEntrato)Session[ModConstantList.K_SE_SYSUTENTEENTRATO];
      }
      set
      {
        Session[ModConstantList.K_SE_SYSUTENTEENTRATO] = value;
      }
    }
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

    // DEFINIZIONE PROPRIETA' READONLY
    public Web BMaster
    {
      get
      {
        return (Web)(this.Page.Master);
      }
    }
    public BPageBase BPage
    {
      get
      {
        return (BPageBase)(this.Page);
      }
    }

    public BConfiguration Config
    {
      get
      {
        return BPage.Config;
      }
    }

    public BConnection DB
    {
      get
      {
        return (BConnection)Session[ModConstantList.K_SE_SYSDB];
      }
    }
    public BConnection DBUser
    {
      get
      {
        return (BConnection)Session[ModConstantList.K_SE_SYSDBUSER];
      }
    }
    public BReportingService ReportingServices
    {
      get
      {
        return (BReportingService)Session[ModConstantList.K_SE_SYSREPORTINGSERVICES];
      }
      set
      {
        Session[ModConstantList.K_SE_SYSREPORTINGSERVICES] = value;
      }
    }

    // DEFINIZIONE METODI OVERRIDABLE
    protected virtual void BControl_Init(object sender, EventArgs e)
    {
    }
    protected virtual void BControl_Load(object sender, EventArgs e)
    {
    }
    protected virtual void BControl_AttachCommand()
    {
    }
    public virtual void SetAttributes_AddEvents()
    {
    }


    // DEFINIZIONE METODI
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
      BMaster.BRedirect(url);
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
      return BPage.SendMail(Oggetto, Body, Destinatari, Cc, BCc, Allegati);
    }

    // DEFINIZIONE METODI PUBLICI SENDNOTIFY
    public bool SendNotify(string Oggetto, string Body, bool LimitaVisibilita = false, int IDSysSistema = -1, int IDSysProfilo = -1, string IDSysUtente = "")
    {
      return BPage.SendNotify(Oggetto, Body, LimitaVisibilita, IDSysSistema, IDSysProfilo, IDSysUtente);
    }

    // DEFINIZIONE METODI PUBLICI LOG
    public bool WriteLog(string EntryPoint, string Message, BEnumerations.eSeverity Severity)
    {
      return BPage.WriteLog(EntryPoint, Message, Severity);
    }
    public bool WriteLog(string EntryPoint, string Message, Exception Ex, BEnumerations.eSeverity Severity)
    {
      return BPage.WriteLog(EntryPoint, Message, Ex, Severity);
    }

    public bool WriteOperation(string Msg)
    {
      return BPage.WriteOperation(Msg);
    }
    public bool ScriviFileOnServer(BFile f, string SubFolder = "", string Prefix = "", bool CreateFoldereIfNotExist = false)
    {
      return BPage.ScriviFileOnServer(f, SubFolder, Prefix, CreateFoldereIfNotExist);
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

    //METODI PER EXTENDER AJAX
    public void RaiseEvent_ShowExtender()
    {
      ShowExtender?.Invoke();
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void BWebControlsBase_Init(object sender, EventArgs e)
    {
      this.BControl_Init(sender, e);
    }
    private void BWebControlsBase_Load(object sender, EventArgs e)
    {
      if (!this.BPage.CheckSession()) return;
      this.SetAttributes_AddEvents();
      this.BControl_Load(sender, e);
      this.BControl_AttachCommand();
      AttachCommand?.Invoke();
      if (IsPostBack) BEventManager();
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void BEventManager()
    {
      string Args = Request.Form["__EVENTARGUMENT"];
      string Target = Request.Form["__EVENTTARGET"];
      string Command = "";
      var aArgs = Args.Split('|');
      if (aArgs.Count() == 2)
      {
        Command = aArgs[0];
        Args = aArgs[1];
        EventManager?.Invoke(Command, Args, Target);
      }
    }

  } //END CLASS
} //END NAMESPACE