using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BNet.BSocial;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace PosteWebTemplate1.BSystem
{
  public partial class AuthGoogle : BPageBaseNoMaster
  {

    public AuthGoogle()
    {
      this.Load += AuthGoogle_Load;
    }

    private void AuthGoogle_Load(object sender, EventArgs e)
    {
      try
      {
        string code = "";
        string ClientID = BWebConfig.GoogleAuth_ClientID;
        string clientsecret = BWebConfig.GoogleAuth_ClientSecret;
        string redirection_url = BGlobalNet.GetApplicationUrl(this);
        redirection_url = BGlobal.CreatePathFileWeb(redirection_url, ModConstantList.K_SYS_PAGE_AUTHGOOGLE);
        BGoogleSocialAuth socgoogle = new BGoogleSocialAuth(ClientID, clientsecret, redirection_url);
        code = Request.Params["code"];
        BSocialToken sToken = socgoogle.GetToken(code);
        if (sToken is object)
        {
          BSocialUser GoogleInfo = socgoogle.GetUser(sToken.access_token);
          if (CheckSocialUser(GoogleInfo))
          {

          }
          socgoogle.LogOut(sToken.access_token);
        }
        else
        {
          Response.Redirect("sysLogin.aspx");
        }
      }
      catch (Exception ex)
      {
        Response.Write(ex.Message);
      }
    }

    public bool CheckSocialUser(BSocialUser Obj)
    {
      BUtenti ut = null;
      BDataTable dt;
      DB.ClearParameter();
      DB.AddParameter("@email", Obj.Email);
      dt = DB.ApriDT("BSP_sysUtenti_SELECT_ByEmail", CommandType.StoredProcedure);
      if (dt != null && dt.Rows.Count > 0)
      {
        if (dt.Rows.Count == 1)
        {
          ut = new BUtenti(dt.Rows[0], DB);

          if (ut != null && !ut.IsNothing)
          {
            this.Accedi(ut);
            return true;
          }
          else
          {
            this.WriteLog("AuthGoogle", "Oggetto BsysUtente non inizializzato", BArts.BEnumerations.eSeverity.ERROR);
            this.ShowMessagePage("Non è stat possibile caricare i dati dell'utente.");
          }
        }
        else
        {
          this.WriteLog("AuthGoogle", "Indirizzo email dell'utente loggato associato a più schede anagrafiche. ", BArts.BEnumerations.eSeverity.ERROR);
          this.ShowMessagePage("Utente non riconosciuto");
        }
      }
      else
      {
        //non registrato
        if (BWebConfig.ShowRegistrati)
        {
          Session[sysRegistrazione.K_SE_BSOCIALUSER] = Obj;
          BRedirect(ModConstantList.K_PAGE_REGISTRAZIONE);
        }
        else
        {
          this.WriteLog("AuthGoogle", "Tentativo di accesso con Google Account dell'utente con email " + Obj.Email + " non autorizzato", BArts.BEnumerations.eSeverity.WARNING);
          this.ShowMessagePage("Utente non autorizzato");
        }
      }

      return false;
    }


    public void Accedi(BUtenti utente)
    {
      base.Session[ModConstantList.K_SE_SYSUTENTEENTRATO] = utente;
      utente.WriteEntry(Request.UserHostAddress, Request.UserHostName);
      if (utente.Profili.Count > 1)
      {
        if (!BWebConfig.UseSideBar)
        {
          this.BRedirect(ModConstantList.K_PAGE_SELECTPROFILO);
        }
        else
        {
          if (utente.Developer)
          {
            this.BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
          }
          else
          {
            this.BRedirect(ModConstantList.K_PAGE_HOME);
          }
        }
      }
      else
      {
        if (BSysUtenteEntrato.Developer)
        {
          BSysUtenteEntrato.IDSysProfilo = -1;
          BSysUtenteEntrato.IDSysSistema = -1;
          BSysUtenteEntrato.Accesso.IDSysSistema = -1;
          BSysUtenteEntrato.Accesso.IDSysProfilo = -1;
        }
        else
        {
          BSysUtenteEntrato.IDSysProfilo = utente.Profili[0].IDSysProfilo;
          BSysUtenteEntrato.IDSysSistema = utente.Profili[0].IDSysSistema;
          BSysUtenteEntrato.Accesso.IDSysSistema = utente.Profili[0].IDSysSistema;
          BSysUtenteEntrato.Accesso.IDSysProfilo = utente.Profili[0].IDSysProfilo;
        }

        if (!BSysUtenteEntrato.Accesso.Update(false))
        {
          this.WriteLog("AuthGoogle.Accedi():", "Salvataggio accesso fallito.", BEnumerations.eSeverity.ERROR);
        }

        // TRACCIO SCELTA PROFILO
        if (!BSysUtenteEntrato.Developer)
        {
          BSysUtenteEntrato.WriteOperation("Accesso al sistema " + utente.Profili[0].SysSistema.Descrizione + " con profilo " + utente.Profili[0].SysProfilo.Descrizione);
          this.BRedirect(ModConstantList.K_PAGE_HOME);
        }
        else
        {
          this.BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
        }

      }

    }



  } //END CLASS
} //END NAMESPACE