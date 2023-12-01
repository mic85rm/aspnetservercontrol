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

namespace PosteWebTemplate1
{
  public class BPageBaseNoMaster : BBaseWebPage
  {

    // DEFINIZIONE PROPRIETA'
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

    public IBUtenteEntrato UtenteEntrato
    {
      get
      {
        return (IBUtenteEntrato)base.Session[ModConstantList.K_SE_SYSUTENTEENTRATO];
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

    //DEFINIZINE PROPERTY OVERRIDABLE
    public virtual bool AutoRedirect { get; set; } = true;

    // DEFINIZIONE METODI PUBLICI
    public void ShowReport(BReport Rpt, string Url)
    {
      Session[sysReportViewer.K_SE_REPORT] = Rpt;
      Session[sysReportViewer.K_SE_URLCHIAMANTE] = Url;
    }
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

    public void BRedirect(string url)
    {
      ((BBaseWebPage)this.Page).BPage.BRedirect(url);
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

  } //END CLASS
} //END NAMESPACE