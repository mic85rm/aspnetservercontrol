using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BInterface;
using BArts.BIO;
using BArts.BMail;
using BArts.BReports;
using BArts.BSecurity;
using BArts.BWeb;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebpersBaseLibrary;
using static WebpersBaseLibrary.BApplicazioni;

namespace PosteWebTemplate1
{
  public partial class sysStartApp : BPageBase
  {

    //DEFINIZIONE COSTANTI
    private const string sp_ChildAppToken_INSERT = "BSP_ChildAppToken_INSERT";

    //DEFINIZIONE EVENTI INTERCETTATI
    protected override void BPage_Load(object sender, System.EventArgs e)
    {
      if (!IsPostBack)
      {
        // ID DELL'APPLICAZIONE
        int IDApplicazione = BConvert.ToInt(Request.QueryString["IDApplicazione"]);
        int IDJobRole = BConvert.ToInt(Request.QueryString["IDJobRole"]);
        BApplicazioni App = new BApplicazioni(IDApplicazione, DB);
        if (App != null && !App.IsNothing)
        {
          GestisciToken(App, IDJobRole);
        }
        else
        {
          WriteLog("sysStartApp.BPage_Load", $"Tentativo di accesso con IDApplicazione {IDApplicazione} e IDJobRole {IDJobRole} fallito.", BEnumerations.eSeverity.WARNING);
          ShowMessagePage("Attenzione... Violazione dei parametri di accesso.");
        }
      }
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private void GestisciToken(BApplicazioni App, int IDJobRole)
    {
      switch (App.ETipoApplicazione)
      {
        case eTipiApplicazione.ESTERNA_WEBPERS:
          ESTERNA_WEBPERS(App);
          break;
        case eTipiApplicazione.INTERNA_WEBPERS:
          INTERNA(App, IDJobRole);
          break;
        case eTipiApplicazione.WEBPERS_CHILD:
          WEBPERS_CHILD(App, IDJobRole);
          break;
        case eTipiApplicazione.VIRTUALE:
          VIRTUALE(App);
          break;
        default:
          break;
      }
    }
    private bool INTERNA(BApplicazioni App, int IDJobRole)
    {
      int idprofilo = -1;
      try
      {
        //profilazione dell'applicazione
        BJobRoles jP = new BJobRoles(IDJobRole, DBUser);
        if (jP != null && !jP.IsNothing)
        {
          IEnumerable<BJobRolesProfili> profili = from obj in jP.Profili
                                                  where obj.IDApplicazione == App.ID
                                                  select obj;

          if (profili == null || profili.Count() == 0)
          {
            MsgBox("Non ci sono profili collegati a questa applicazione");
            WriteLog("sysStartApp.INTERNA", $"Non ci sono profili collegati all'applicazione {App.ID} per il JobRole {IDJobRole}", BEnumerations.eSeverity.WARNING);
            this.BRedirect(ModConstantList.K_PAGE_HOME);
          }
          else
          {
            if (profili.Count() > 1)
            {
              MsgBox("Esitono più profili collegati a questa applicazione");
              WriteLog("sysStartApp.INTERNA", $"Ci sono più profili collegati all'applicazione {App.ID} per il JobRole {IDJobRole}", BEnumerations.eSeverity.WARNING);
              this.BRedirect(ModConstantList.K_PAGE_HOME);
            }
            else
            {
              idprofilo = profili.ToList()[0].IDProfilo;
            }
          }

          DBUser.ClearParameter();
          DBUser.AddParameter("@IdUtente", BSysUtenteEntrato.ID);
          DBUser.AddParameter("@IdApplicazione", App.ID);
          DBUser.AddParameter("@IDpersona", BSysUtenteEntrato.IDPersona);
          DBUser.AddParameter("@IdWhere", BSysUtenteEntrato.IDVisibilita);
          DBUser.AddParameter("@IdJobRole", IDJobRole);
          DBUser.AddParameter("@idprofilo", idprofilo);
          int id = BConvert.ToInt(DBUser.ExecuteScalar("BSP_ChildAppToken_INSERT_App_Interna", CommandType.StoredProcedure));
          if (id != 0)
          {
            string tmpUrl = @"{0}{1}?tknid={2}&NewWebPers={3}";
            string url = "";
            if (((BUtenti)UtenteEntrato).FromPortale == false)
            {
              if (App.PathApplicativo == "")
              {
                this.WriteLog("sysStartApp.INTERNA", $"L'applicazione {App.Descrizione} con id {App.ID} non contiene alcun path applicativo.", BArts.BEnumerations.eSeverity.ERROR);
              }
              string pathApplicativo = BGlobal.CreatePathFileWeb(App.PathApplicativo, "default.aspx");
              url = string.Format(tmpUrl, BWebConfig.LinkExternalApp, pathApplicativo, id, "1");
            }
            else
            {
              url = string.Format(tmpUrl, BWebConfig.LinkExternalApp_Internet, App.PathApplicativo, id, "1");
            }
            this.WriteLog("sysStartApp.INTERNA", $"L'utente {BSysUtenteEntrato.ID} ha lanciato l'applicazione {App.Descrizione} con id {App.ID}", BArts.BEnumerations.eSeverity.INFORMATION);
            BRedirect(url);
          }
          else
          {
            WriteLog("sysStartApp.INTERNA", $"La stored BSP_ChildAppToken_INSERT_App_Interna non ha creato il token per l'app {App.ID}", BEnumerations.eSeverity.ERROR);
            MsgBox("La pagina non è al momento disponibile");
          }
        }
        else
        {
          WriteLog("sysStartApp.INTERNA", $"JobRole con id {IDJobRole} non esistente.", BEnumerations.eSeverity.ERROR);
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysStartApp.WEBPERS_INTERNA", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private bool VIRTUALE(BApplicazioni App)
    {
      try
      {
        BsysFunzioni Funzione = new BsysFunzioni(App.IDSysFunzioneApplicazione, DB);
        if (Funzione != null && !Funzione.IsNothing)
        {
          string linkpage = "~/" + Funzione.Comando;
          BRedirect(linkpage);
          this.WriteLog("sysStartApp.VIRTUALE", $"L'utente {BSysUtenteEntrato.ID} ha lanciato l'applicazione {App.Descrizione} con id {App.ID}", BArts.BEnumerations.eSeverity.INFORMATION);
        }
        else
        {
          this.WriteLog("sysStartApp.VIRTUALE", $"La funzione {App.IDSysFunzioneApplicazione} non è stata trovata nel db", BEnumerations.eSeverity.ERROR);
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysStartApp.VIRTUALE", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private bool ESTERNA_WEBPERS(BApplicazioni App)
    {
      string tmpUrl = @"{0}{1}";
      string url = "";
      try
      {
        if (BSysUtenteEntrato == null) return false;
        if (!BSysUtenteEntrato.FromPortale)
        {
          url = string.Format(tmpUrl, BWebConfig.LinkExternalApp, App.PathApplicativo);
        }
        else
        {
          url = string.Format(tmpUrl, BWebConfig.LinkExternalApp_Internet, App.PathApplicativo);
        }
        this.WriteLog("sysStartApp.ESTERNA_WEBPERS", $"L'utente {BSysUtenteEntrato.ID} ha lanciato l'applicazione {App.Descrizione} con id {App.ID}", BEnumerations.eSeverity.INFORMATION);
        LanciaRedirect(url);
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysStartApp.ESTERNA_WEBPERS", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private bool WEBPERS_CHILD(BApplicazioni App, int IDJobRole)
    {
      string tmpUrl = @"{0}{1}?tknid={2}";
      string url = "";
      try
      {
        if (BSysUtenteEntrato == null) return false;
        DBUser.ClearParameter();
        DBUser.AddParameter("@IdUtente", BSysUtenteEntrato.ID);
        DBUser.AddParameter("@IdApplicazione", App.ID);
        DBUser.AddParameter("@IDpersona", BSysUtenteEntrato.IDPersona);
        DBUser.AddParameter("@IdWhere", BSysUtenteEntrato.IDVisibilita);
        DBUser.AddParameter("@IdJobRole", IDJobRole);
        int id = BConvert.ToInt(DBUser.ExecuteScalar(sp_ChildAppToken_INSERT, CommandType.StoredProcedure));
        if (id != 0)
        {
          if (BSysUtenteEntrato.FromPortale == false)
          {
            url = string.Format(tmpUrl, BWebConfig.LinkExternalApp, App.PathApplicativo, id);
          }
          else
          {
            url = string.Format(tmpUrl, BWebConfig.LinkExternalApp_Internet, App.PathApplicativo, id);
          }
          this.WriteLog("sysStartApp.CHILD", $"L'utente {BSysUtenteEntrato.ID} ha lanciato l'applicazione {App.Descrizione} con id {App.ID}", BEnumerations.eSeverity.INFORMATION);
          LanciaRedirect(url);
        }
        else
        {
          MsgBox("La pagina non è al momento disponibile");
          WriteLog("sysStartApp.CHILD", $"La stored BSP_ChildAppToken_INSERT non ha creato il token per l'app {App.ID}", BEnumerations.eSeverity.ERROR);
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysStartApp.WEBPERS_CHILD", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private void LanciaRedirect(string URL)
    {
      Response.Write("<script type='text/javascript'>");
      Response.Write("window.open('" + URL + "','_blank');");
      Response.Write("</script>");

      string homepage = MapPath(ModConstantList.K_PAGE_HOME);

      if (HttpContext.Current.Request.UrlReferrer.OriginalString.Contains(".aspx"))
      {
        homepage = HttpContext.Current.Request.UrlReferrer.OriginalString;
      }
      else
      {
        homepage = HttpContext.Current.Request.UrlReferrer.OriginalString + ".aspx";
      }

      Response.Write("<script type='text/javascript'>");
      Response.Write("window.open('" + homepage + "','_self');");
      Response.Write("</script>");

    }
  }
}