using BArts;
using BArts.BData;
using BArts.BGlobal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.Animation;

namespace PosteWebTemplate1
{
  public static class ModGenerale
  {

    // DEFAULT DATABASE NAME 
    public static string K_NOMEDATABASE = BWebConfig.DBApp_DB;
    public static string K_NOMEDATABASE_USER = BWebConfig.DBUser_DB;

    // FUNZIONI UPLOADER
    public static string SerializeParameter(List<IDbDataParameter> @params, string K_ParamSeparetor = ":", string K_ParamsSeparetor = "|")
    {
      string sParam = "";
      string sParams = "";
      string K_StringFormat = "{0}" + K_ParamSeparetor + "{1}";
      if (@params == null)
        return "";
      foreach (IDbDataParameter p in @params)
      {
        sParam = string.Format(K_StringFormat, p.ParameterName, p.Value);
        sParams += K_ParamSeparetor + sParam;
      }

      if (!string.IsNullOrEmpty(sParams))
        sParams = sParams.Substring(1);
      return sParams;
    }
    public static List<IDbDataParameter> DeserializeParameters(string sParams, string K_ParamSeparetor = ":", string K_ParamsSeparetor = "|")
    {
      var @params = new List<IDbDataParameter>();
      SqlParameter iParam = null;
      var aParams = sParams.Split(char.Parse(K_ParamsSeparetor));
      if (string.IsNullOrEmpty(sParams))
        return null;
      foreach (string sParam in aParams)
      {
        var aParam = sParam.Split(char.Parse(K_ParamSeparetor));
        if (aParam.Length == 2)
        {
          iParam = new SqlParameter();
          iParam.ParameterName = aParam[0];
          iParam.Value = aParam[1];
          @params.Add(iParam);
        }
      }

      return @params;
    }
    public static IDbDataParameter GetParameter(List<IDbDataParameter> ListParamas, string ParamName)
    {
#pragma warning disable CS0168 // La variabile 'ex' è dichiarata, ma non viene mai usata
      try
      {
        IEnumerable<IDbDataParameter> res = from c in ListParamas
                                            where (c.ParameterName.ToUpper() ?? "") == (ParamName.ToString().ToUpper() ?? "")
                                            select c;
        if (res != null && res.Count() > 0)
        {
          return res.ToList()[0];
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        return null;
      }
#pragma warning restore CS0168 // La variabile 'ex' è dichiarata, ma non viene mai usata
    }

    public enum EProfili
    {
      Final_User = 0,
      Administrator = 1,
      Referente = 2,
      Responsabile = 3,
      Sviluppatore = 4,
      Team_Leader = 5

    }

    public enum ETipoProfilo
    {
      User = 0,
      Semplice = 0,
      Avanzato = 1,
    }

    public enum EStatoChiarimento
    {
      Richiesta = 1,
      Risposta = 2
    }


    public static ETipoProfilo TipoProfilo(int MyProfilo)
    {
      EProfili Profilo = (EProfili)MyProfilo;
      switch (Profilo)
      {
        case EProfili.Final_User:
          return ETipoProfilo.User;
        case EProfili.Administrator:
          return ETipoProfilo.Semplice;
        case EProfili.Referente:
          return ETipoProfilo.Avanzato;
        case EProfili.Responsabile:
          return ETipoProfilo.Avanzato;
        case EProfili.Sviluppatore:
          return ETipoProfilo.Avanzato;
        case EProfili.Team_Leader:
          return ETipoProfilo.Avanzato;
      }
      return ETipoProfilo.User;
    }

    public enum eTipiPreferiti
    {
      URL_ESTERNO = 1,
      APPLICAZIONE = 2
    }

    public enum eStatiApplicazione
    {
      Produzione = 1,
      Dismessa = 2,
      Collaudo = 3,
      Sviluppo = 4
    }

    public enum eStatiTicket
    {
      NESSUNA = -1,
      INSERIMENTO = 0,
      RICHIESTO = 1,
      APERTO = 2,
      INLAVORAZIONE = 3,
      INVERIFICA = 4,
      CHIUSO = 5,
      INPAUSA = 6
    }
  } //END CLASS
} //END NAMESPACE