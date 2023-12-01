using BArts.BBaseClass;
using BArts.BData;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using static System.Configuration.ConfigurationManager;

namespace PosteWebTemplate1.WebApi
{
  public class BSysUfficiController : ApiController
  {
    //DEFINIZIONE DATI
    protected BConnection DB;

    //DEFINIZIONE COSTRUTTORI
    public BSysUfficiController() : base()
    {
      this.DB = new BConnection(AppSettings["DBAPP_SERVER"], AppSettings["DBAPP_DB"], AppSettings["DBAPP_USER"], BCrypter.Decrypt(AppSettings["DBAPP_PWD"]));
    }
    // GET webapi/<controller>
    [HttpGet]
    public string GetValues()
    {
      DataTable dt = null;
      IEnumerable<BsysUtenti> l;
      string ret = "";
      try
      {
        dt = BsysUtenti.GetElenco(DB);
        if (dt != null && dt.Rows.Count > 0)
        {
          l = (from DataRow dr in dt.Rows
               select new BsysUtenti(dr, DB));
          ret = JsonConvert.SerializeObject(l.ToList());
        }
        else
        {
          ret = JsonConvert.SerializeObject(new List<string>());
        }
        return ret;
      }
      catch (Exception)
      {
        return null;
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
    // GET webapi/<controller>/autocomplete/{Descrizione}
    [ActionName("autocomplete")]
    [HttpGet]
    public string GetValues(string param)
    {
      DataTable dt = null;
      IEnumerable<BItemAutoComplete> e = null;
      List<BItemAutoComplete> l = null;
      string ret = "";
      try
      {
        DB.ClearParameter();
        DB.AddParameter("@Descrizione", param);
        dt = DB.ApriDT("BSP_sysUffici_AUTOCOMPLETE", CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          e = (from DataRow dr in dt.Rows
               select new BItemAutoComplete(dr["ID"].ToString(), dr["Descrizione"].ToString()));
          l = e.ToList();

          ret = JsonConvert.SerializeObject(l);
        }
        else
          ret = JsonConvert.SerializeObject(new List<string>());
        return ret;
      }
      catch (Exception)
      {
        // tracciare il log
        return null;
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
    // GET webapi/<controller>/{id}

  }
}
