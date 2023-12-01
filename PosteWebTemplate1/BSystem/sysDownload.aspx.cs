using BArts;
using BArts.BGlobal;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using System;

namespace PosteWebTemplate1
{
  public partial class sysDownload : BPageBaseNoMaster
  {

    //DEFINIZIONE COSTRUTTORI
    public sysDownload()
    {
      this.Load += Page_Load;
    }

    // DEFINIZIONE DATI
    private const string K_PAGENAME = "SYSDOWNLOAD";

    //DEFINIZIONI PROPRIETA' 
    #region public string FileName
    public const string K_SE_FILENAME = K_PAGENAME + ".FILENAME";
    public string FileName
    {
      get
      {
        return BConvert.ToString(Session[K_SE_FILENAME]);
      }
      set
      {
        Session[K_SE_FILENAME] = value;
      }
    }
    #endregion
    #region public string SubFolder
    public const string K_SE_SUBFOLDER = K_PAGENAME + ".SUBFOLDER";
    public string SubFolder
    {
      get
      {
        return BConvert.ToString(Session[K_SE_SUBFOLDER]);
      }
      set
      {
        base.Session[K_SE_SUBFOLDER] = value;
      }
    }
    #endregion
    #region public string AliasFileName
    public const string K_SE_ALIASFILENAME = K_PAGENAME + ".ALIASFILENAME";
    public string AliasFileName
    {
      get
      {
        return BConvert.ToString(Session[K_SE_ALIASFILENAME]);
      }

      set
      {
        base.Session[K_SE_ALIASFILENAME] = value;
      }
    }
    #endregion

    //DEFINIZIONE EVENTI ITNERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      string PathFile = "";
      string msg = "";
      try
      {
        // COMPONGO IL PATH DAL FOLDER AL NOME FILE
        PathFile = BWebConfig.ServerFileShare_Folder;
        if (!string.IsNullOrEmpty(SubFolder)) PathFile = BGlobal.CreatePathFile(PathFile, SubFolder);
        PathFile = BGlobal.CreatePathFile(PathFile, FileName);
        if (BWebConfig.ServerFileShare_PathRelative)
        {
          PathFile = BGlobal.CreatePathFile("..", PathFile);
          PathFile = Server.MapPath(PathFile);
        }
        else
        {
          PathFile = BGlobal.CreatePathFile(@"\\" + BWebConfig.ServerFileShare_Name, PathFile);
        }

        // AUTHENTICATION
        if (BWebConfig.ServerFileShare_AuthRequired)
        {
          if (BAuthentication.ImpersonateValidUser(BWebConfig.ServerFileShare_User, BWebConfig.ServerReport_Domain, BCrypter.Decrypt(BWebConfig.ServerReport_PWD)))
          {
            msg = "Autenticazione riuscita per utente <<" + BWebConfig.ServerReport_Domain + @"\" + BWebConfig.ServerFileShare_User + ">>";
            ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, this.UtenteEntrato.Username, null, msg, BEnumerations.eSeverity.INFORMATION.ToString());
          }
          else
          {
            msg = "Autenticazione non riuscita per utente <<" + BWebConfig.ServerReport_Domain + @"\" + BWebConfig.ServerFileShare_User + ">>";
            ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, this.UtenteEntrato.Username, null, msg, BEnumerations.eSeverity.ERROR.ToString());
          }
        }

        // TRANSMIT FILE
        if (System.IO.File.Exists(PathFile))
        {
          if (string.IsNullOrEmpty(AliasFileName)) AliasFileName = FileName;
          TransmitFile(PathFile, AliasFileName);
        }
        else
        {
          ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, this.UtenteEntrato.Username, null, "sysDownload.Page_Load()", "File <<" + PathFile + ">> non trovato.", BEnumerations.eSeverity.ERROR);
        }
      }
      catch (Exception ex)
      {
        string IDSysUtente = "";
        string IDAccesso = "";
        if (base.UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso.ToString();
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ModLog.ScriviLog(base.DB, (BConfiguration)base.Config, IDSysUtente, ex, "sysDownload.Page_Load()", "", BEnumerations.eSeverity.ERROR, int.Parse(IDAccesso));
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE 
    private void TransmitFile(string PathFile, string FileName)
    {
      base.Response.Clear();
      base.Response.ClearHeaders();
      base.Response.ClearContent();
      base.Response.ContentType = "text/plain";
      base.Response.AddHeader("Content-disposition", "attachment; filename= " + FileName);
      base.Response.TransmitFile(PathFile);
      base.Response.Flush();
      base.Response.End();
    }

  } //END CLASS
} //END NAMESPACE