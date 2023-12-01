using BArts;
using BArts.BData;
using BArts.BGlobal;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PosteWebTemplate1
{
  public static class ModWebServices
  {
    // DEFINIZIONE COSTANTI
    public const string K_PwdKey = "qxW96N2fR4CNMD42OA2UpQ90/IrlTd6e9TCEp3cOJSo=";


    // DECODIFICA ID WEB SERVICE

    //TABELLA sysComuni
    public static string GetIDComuneFromDescrWS(string descrizione, BConnection DB, BPageBase p)
    {
      string sID = "";
      try
      {
        if (string.IsNullOrEmpty(descrizione)) return "";
        if (descrizione.IndexOf("[") != -1)
        {
          sID = descrizione.Substring(descrizione.IndexOf("[") + 1).Replace("]", "");
        }
        else
        {
          BDataTable dt = null;
          dt = (BDataTable)BsysComuni.GetElenco(DB, new SqlParameter("@Descrizione", descrizione));
          if (dt is object && dt.Rows.Count == 1)
          {
            sID = dt.Rows[0]["ID"].ToString();
          }
          else
          {
            sID = "";
          }
        }
        return sID;
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetIDCOmuneFromDescrWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }
    public static string GetDescrizioneComuneFromWS(string ID, BConnection db, BPageBase p)
    {
      BTemplateBaseLibrary.BsysComuni ObjC = null;
      try
      {
        ObjC = new BTemplateBaseLibrary.BsysComuni(ID, db);
        if (ObjC is object && !ObjC.IsNothing)
        {
          return ObjC.Descrizione.Trim() + " [" + ID.ToUpper().Trim() + "]";
        }
        else
        {
          return "";
        }
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetDescrizioneComuneFromWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }

    //TABELLA sysPersone
    public static string GetIDSysPersonaFromDescrWS(string descrizione, BConnection DB, BPageBase p)
    {
      string sID = "";
      try
      {
        if (string.IsNullOrEmpty(descrizione)) return "";
        if (descrizione.IndexOf("[") != -1)
        {
          sID = descrizione.Substring(descrizione.IndexOf("[") + 1).Replace("]", "");
        }
        else
        {
          BDataTable dt = null;
          DB.ClearParameter();
          DB.AddParameter("@Descrizione", descrizione);
          dt = DB.ApriDT("WSP_sysPersone_SEARCH");
          if (dt is object && dt.Rows.Count == 1)
          {
            sID = dt.Rows[0]["ID"].ToString();
          }
          else
          {
            sID = "";
          }
        }
        return sID;
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetIDSysPersonaFromDescrWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }
    public static string GetDescrizioneSysPersonaFromWS(string ID, BConnection db, BPageBase p)
    {
      BTemplateBaseLibrary.BsysPersone Obj = null;
      try
      {
        Obj = new BTemplateBaseLibrary.BsysPersone(BConvert.ToInt(ID), db);
        if (Obj is object && !Obj.IsNothing)
        {
          return Obj.Descrizione.Trim() + " [" + ID.ToUpper().Trim() + "]";
        }
        else
        {
          return "";
        }
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetDescrizioneSysPersonaFromWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }

    //TABELLA sysUtenti
    public static string GetIDSysUtenteFromDescrWS(string descrizione, BConnection DB, BPageBase p)
    {
      string sID = "";
      try
      {
        if (string.IsNullOrEmpty(descrizione)) return "";
        if (descrizione.IndexOf("[") != -1)
        {
          sID = descrizione.Substring(descrizione.IndexOf("[") + 1).Replace("]", "");
        }
        else
        {
          BDataTable dt = null;
          DB.ClearParameter();
          DB.AddParameter("@Descrizione", descrizione);
          dt = DB.ApriDT("WSP_sysUtenti_SEARCH", CommandType.StoredProcedure);
          if (dt is object && dt.Rows.Count == 1)
          {
            sID = dt.Rows[0]["ID"].ToString();
          }
          else
          {
            sID = "";
          }
        }
        return sID;
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetIDSysUtenteFromDescrWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }
    public static string GetDescrizioneSysUtentuFromWS(string ID, BConnection db, BPageBase p)
    {
      BTemplateBaseLibrary.BsysUtenti Obj = null;
      try
      {
        Obj = new BTemplateBaseLibrary.BsysUtenti(ID, db);
        if (Obj is object && !Obj.IsNothing)
        {
          if (Obj.Persona is null || Obj.Persona.IsNothing)
          {
            return Obj.Username.Trim() + " [" + ID.ToUpper().Trim() + "]";
          }
          else
          {
            return Obj.Persona.Cognome.Trim() + " " + Obj.Persona.Nome.Trim() + " [" + ID.ToUpper().Trim() + "]";
          }
        }
        else
        {
          return "";
        }
      }
      catch (Exception ex)
      {
        p.WriteLog("ModWebServices.GetDescrizioneSysUtentuFromWS()", "", ex, BEnumerations.eSeverity.ERROR);
        return "";
      }
    }

  } //END CLASS
} //END NAMESPACE