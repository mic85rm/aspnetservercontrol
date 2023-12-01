using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
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
  public class BSysWikiController : ApiController
  {
    //DEFINIZIONE DATI
    protected BConnection DB;

    //DEFINIZIONE COSTRUTTORI
    public BSysWikiController() : base()
    {
      this.DB = new BConnection(AppSettings["DBAPP_SERVER"], AppSettings["DBAPP_DB"], AppSettings["DBAPP_USER"], BCrypter.Decrypt(AppSettings["DBAPP_PWD"]));
    }

    //DEFINIZIONE METODI REST

    // GET webapi/<controller>
    [HttpGet]
    public string GetValues()
    {
      DataTable dt = null;
      IEnumerable<BsysWiki> l;
      string ret = "";
      try
      {
        dt = BsysWiki.GetElenco(DB);
        if (dt != null && dt.Rows.Count > 0)
        {
          l = (from DataRow dr in dt.Rows
               select new BsysWiki(dr, DB));
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
        dt = DB.ApriDT("BSP_sysWiki_AUTOCOMPLETE", CommandType.StoredProcedure);
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
    [HttpGet]
    public string GetValue(string id)
    {
      BsysWiki Obj = null;
      try
      {
        Obj = new BsysWiki(BConvert.ToInt(id), DB);
        if (Obj != null && !Obj.IsNothing)
          return JsonConvert.SerializeObject(Obj);
        else
          return "";
      }
      catch (Exception ex)
      {
        // tracciare il log
        return ex.Message;
      }
    }
    // POST webapi/<controller>
    [HttpPost]
    public void PostValue([FromBody()] string value)
    {
      BsysWiki Obj = null;
      Obj = JsonConvert.DeserializeObject<BsysWiki>(value);
      if (Obj != null)
      {
        Obj.ChangeConnection(DB);
        Obj.Update();
      }
    }
    // PUT webapi/<controller>/{id}
    [HttpPut]
    public void PutValue(string id, [FromBody()] string value)
    {
      this.PostValue(value);
    }
    // DELETE api/<controller>/{id}
    [HttpDelete]
    public void DeleteValue(string id)
    {
      BsysWiki obj = new BsysWiki(BConvert.ToInt(id), DB);
      if (obj != null && !obj.IsNothing)
        obj.Delete();
    }


  }
}
