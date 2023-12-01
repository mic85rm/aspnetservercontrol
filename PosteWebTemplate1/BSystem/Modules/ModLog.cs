using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BLog;
using BArts.BMail;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public static class ModLog
  {

    // DEFINIZIONE FUNZIONI PRIVATE
    private static bool EscludiEccezioni(Exception ex)
    {
      if (ex == null) return false;
      if (ex is System.Threading.ThreadAbortException) return true;
      // AGGIUNGERE DI SEGUITO EVENTUALI ECCEZIONI DA ESCLUDERE
      return false;
    }

    // DEFINIZIONE METODI PUBLICI
    public static bool ScriviLog(BConnection db, BConfiguration Config, string IDSysUtente,
                                 Exception ex, string EntryPoint = "", string Message = ""
                                 , BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR
                                 , int IdAccesso = -1, Page Page = null, int LevelLog = 0)
    {
      bool ret = true;
      try
      {
        if (Config == null) return false;
        if (LevelLog > Config.LevelLog) return false;
        if (EscludiEccezioni(ex)) return true;
        if (Config.WriteErrorOnDB) ret = WriteErrorOnDB(db, IDSysUtente, ex, EntryPoint, Message, Severity, IdAccesso);
        if (Config.WriteErrorOnFile)
        {
          if (!WriteErrorOnFile(db, Config, IDSysUtente, ex, EntryPoint, Message, Severity, IdAccesso, Page))
          {
            ret = false;
          }
        }
        if (Config.WriteErrorOnEventLog)
        {
          if (!WriteErrorOnEventLog(db, IDSysUtente, ex, EntryPoint, Message, Severity, IdAccesso))
          {
            ret = false;
          }
        }
        if (Config.SendMailOnError)
        {
          if (!SendMailOnError(Config, IDSysUtente, ex, Severity: Severity, EntryPoint: EntryPoint, Message: Message, IdAccesso: IdAccesso))
          {
            ret = false;
          }
        }
        return ret;
      }
      catch (Exception)
      {
        return false;
      }
    }
    public static bool ScriviLogUtenteEntrato(BConnection db, BConfiguration Config, Exception ex, BArts.BInterface.IBUtenteEntrato UtenteEntrato = null, string EntryPoint = "", string Message = "", BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR, Page Page = null, int LevelLog = 0)
    {
      int IDAccesso = -1;
      string IDSysUtente = "";
      if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
      {
        IDAccesso = UtenteEntrato.IDAccesso;
        IDSysUtente = UtenteEntrato.Username;
      }
      return ScriviLog(db, Config, IDSysUtente, ex, EntryPoint, Message, Severity, IDAccesso, Page);
    }

    public static bool WriteErrorOnDB(BConnection db, string IDSysUtente, Exception ex, string EntryPoint = "", string Message = "", BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR, int IdAccesso = -1)
    {
      var Log = new BTemplateBaseLibrary.BsysLog(db);
      Log.IDSysAccesso = IdAccesso;
      Log.IDSysSeverity = (int)Severity;
      if (!string.IsNullOrEmpty(EntryPoint))
      {
        Log.Origine = EntryPoint;
        if (ex != null)
          Log.Origine += " [" + ex.Source + "]";
      }
      else if (ex != null)
      {
        Log.Origine = ex.Source;
      }
      else
      {
        Log.Origine = "EX NOTHING";
      }

      if (!string.IsNullOrEmpty(Message))
      {
        Log.Messaggio = Message;
        if (ex != null)
          Log.Messaggio += " [" + ex.Message + "]";
      }
      else if (ex != null)
      {
        Log.Messaggio = ex.Message;
      }
      else
      {
        Log.Messaggio = "EX NOTHING";
      }

      Log.Data = DateAndTime.Now;
      return Log.Update();
    }
    public static bool WriteErrorOnFile(BConnection db, BConfiguration Config, string IDSysUtente, Exception ex, string EntryPoint = "", string Message = "", BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR, int IdAccesso = -1, Page Page = null)
    {
      string Origine = "";
      string Messaggio = "";
      string Path = "";
      if (Config == null) return false;
      if (!string.IsNullOrEmpty(EntryPoint))
      {
        Origine = EntryPoint;
        if (ex != null)
          Origine += " [" + ex.Source + "]";
      }
      else if (ex != null)
      {
        Origine = ex.Source;
      }
      else
      {
        Origine = "EX NOTHING";
      }

      if (!string.IsNullOrEmpty(IDSysUtente))
      {
        Origine = "[" + IDSysUtente + "]." + Origine;
      }

      if (!string.IsNullOrEmpty(Message))
      {
        Messaggio = Message;
        if (ex != null)
          Messaggio += " [" + ex.Message + "]";
      }
      else if (ex != null)
      {
        Messaggio = ex.Message;
      }
      else
      {
        Messaggio = "EX NOTHING";
      }

      if (Config.WriteErrorOnFile_PathRel & Page != null)
      {
        Path = Page.Server.MapPath(Config.WriteErrorOnFile_Path);
      }
      else
      {
        Path = Config.WriteErrorOnFile_Path;
      }

      return BLogTracer.WriteOnFile(Severity, Origine, Messaggio, Path, Config.WriteErrorOnFile_FileErrors, Config.WriteErrorOnFile_FileEvents, Config.WriteErrorOnFile_WriteOnlyEvents);
    }
    public static bool WriteErrorOnEventLog(BConnection db, string IDSysUtente, Exception ex, string EntryPoint = "", string Message = "", BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR, int IdAccesso = -1)
    {
      string Origine = "";
      string Messaggio = "";
      if (!string.IsNullOrEmpty(EntryPoint))
      {
        Origine = EntryPoint;
        if (ex != null)
          Origine += " [" + ex.Source + "]";
      }
      else if (ex != null)
      {
        Origine = ex.Source;
      }
      else
      {
        Origine = "EX NOTHING";
      }

      if (!string.IsNullOrEmpty(IDSysUtente))
      {
        Origine = "[" + IDSysUtente + "]." + Origine;
      }

      if (!string.IsNullOrEmpty(Message))
      {
        Messaggio = Message;
        if (ex != null)
          Messaggio += " [" + ex.Message + "]";
      }
      else if (ex != null)
      {
        Messaggio = ex.Message;
      }
      else
      {
        Messaggio = "EX NOTHING";
      }

      return BLogTracer.WriteOnEventLog(Severity, Origine, Message);
    }
    public static bool SendMailOnError(BConfiguration Config, string IDSysUtente, Exception ex, string Mittente = "", string ReplyTo = "", string CC = "", string BCC = "", string EntryPoint = "", string Message = "", BEnumerations.eSeverity Severity = BEnumerations.eSeverity.ERROR, int IdAccesso = -1)
    {
      string Origine = "";
      string Messaggio = "";
      if (Config == null)
        return false;
      if (!string.IsNullOrEmpty(EntryPoint))
      {
        Origine = EntryPoint;
        if (ex != null)
          Origine += " [" + ex.Source + "]";
      }
      else if (ex != null)
      {
        Origine = ex.Source;
      }
      else
      {
        Origine = "EX NOTHING";
      }

      if (!string.IsNullOrEmpty(IDSysUtente))
      {
        Origine = "[" + IDSysUtente + "]." + Origine;
      }

      if (!string.IsNullOrEmpty(Message))
      {
        Messaggio = Message;
        if (ex != null)
          Messaggio += " [" + ex.Message + "]";
      }
      else if (ex != null)
      {
        Messaggio = ex.Message;
      }
      else
      {
        Messaggio = "EX NOTHING";
      }

      BSenderMailConfig cMail = new BSenderMailConfig(Config.SendMail_SMTPServer, BConvert.ToInt(Config.SendMail_SMTPPort),
                                                      Config.SendMail_UserName, Config.SendMail_Password,
                                                      BConvert.ToBool(Config.SendMailOnErrorTo));

      return SendMail(cMail, Origine, Messaggio, Config.SendMailOnErrorFrom);
    }
    public static bool SendMail(BSenderMailConfig Config, string Oggetto, string Body, string Mittente = "", string ReplyTo = "", string CC = "", string BCC = "")
    {
      return BLogTracer.SendMail(Config, Oggetto, Body, Mittente, ReplyTo, CC, BCC);
    }

  } //END CLASS
} //END NAMESPACE