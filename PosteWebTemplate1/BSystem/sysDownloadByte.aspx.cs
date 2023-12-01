using BArts;
using BArts.BIO;
using BTemplateBaseLibrary;
using System;
using System.Xml.Linq;

namespace PosteWebTemplate1
{
  public partial class sysDownloadByte : BPageBaseNoMaster
  {
    public sysDownloadByte()
    {
      this.Load += Page_Load;
    }

    // DEFINIZIONE DATI
    private const string K_PAGENAME = "SYSDOWNLOADBYTE";

    // DEFINIZIONI PROPRIETA' 
    #region public BFile BFile
    public const string K_SE_FILENAME = K_PAGENAME + ".BFILE";
    public BFile BFile
    {
      get
      {
        return (BFile)base.Session[K_SE_FILENAME];
      }
      set
      {
        base.Session[K_SE_FILENAME] = value;
      }
    }
    #endregion

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (BFile != null && BFile.Content.Length > 0)
        {
          TransmitFile();
        }
        else
        {
          string IDSysUtente = "";
          string IDAccesso = "";
          if (base.UtenteEntrato != null && !UtenteEntrato.IsNothing)
          {
            IDAccesso = this.UtenteEntrato.IDAccesso.ToString();
            IDSysUtente = this.UtenteEntrato.Username;
          }

          ModLog.ScriviLog(base.DB, (BConfiguration)base.Config, IDSysUtente, null, "sysDownloadByte.Page_Load()", "BFile is nothing or empty", BEnumerations.eSeverity.ERROR, int.Parse(IDAccesso));
          Response.Clear();
          Response.ClearHeaders();
          Response.ClearContent();
          Response.ContentType = "text/plain";
          Response.AddHeader("Content-disposition", "attachment; filename= " + BFile.Nome);
          Response.Flush();
          Response.End();
        }
      }
      catch (System.Threading.ThreadAbortException)
      {
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

        ModLog.ScriviLog(base.DB, (BConfiguration)base.Config, IDSysUtente, ex, "sysDownloadByte.Page_Load()", "", BEnumerations.eSeverity.ERROR, int.Parse(IDAccesso));
      }
      finally
      {
        if (BFile != null)
        {
          BFile = null;
          Session.Remove(K_SE_FILENAME);
        }
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE 
    private void TransmitFile()
    {
      Response.Clear();
      Response.ClearHeaders();
      Response.ClearContent();
      Response.ContentType = "text/plain";
      Response.AddHeader("Content-disposition", "attachment; filename= " + BFile.Nome);
      Response.BinaryWrite(BFile.Content);
      Response.Flush();
      Response.End();
    }

  } //END CLASS
} //END NAMESPACE