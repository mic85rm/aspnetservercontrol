using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BInterface;
using BArts.BSecurity;
using BIPosteBaseLibraryCS;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public class BUtenti : BTemplateBaseLibrary.BsysUtenti
  {
    public BUtenti(string ID, BConnection cnn) : base(ID, cnn)
    {
    }
    public BUtenti(DataRow dr, BConnection cnn) : base(dr, cnn)
    {

    }
    public BUtenti(string NTAccount, string NTDomain, BConnection cnn) : base(NTAccount, NTDomain, cnn)
    {
    }

    //DEFINIZIONE PROPRIETA'
    public string IDUtenteWP { get; set; }
    public int IDJobRoleWP { get; set; }
    public int IDApplicazione { get; set; }

    #region public BPersonale Personale 
    private BPersonale m_Personale;
    public BPersonale Personale
    {
      get
      {
        if (m_Personale == null || m_Personale.ID != IDPersona) m_Personale = new BPersonale(IDPersona, this.Connection);
        return m_Personale;
      }
      set
      {
        this.m_Personale = value;
      }
    }
    #endregion

    public bool FromPortale { get; set; } = false;


    // DEFINIZIONE METODI OVERRIDES
    public override bool WriteEntry()
    {
      try
      {
        Accesso = new BTemplateBaseLibrary.BsysAccessi(this.Connection);
        Accesso.IDSysUtente = ID;
        Accesso.DataAccesso = DateAndTime.Now;
        return Accesso.Update(false);
      }
      catch (Exception exp)
      {
        ModLog.ScriviLog(this.Connection, null, "BCLASS", exp, "BsysUtenti.WriteEntry", "", BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override bool WriteExit()
    {
      try
      {
        Accesso.OraFineLavoro = DateAndTime.Now;
        return Accesso.Update(false);
      }
      catch (Exception exp)
      {
        ModLog.ScriviLog(this.Connection, null, "BCLASS", exp, "BsysUtenti.WriteExit", "", BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override IBUtenteEntrato.eEsitoLogin CheckLogin(string username, string password, IBUtenteEntrato.eAuthType TipoLogIn)
    {
      if (!OtherCheckBefore())
        return IBUtenteEntrato.eEsitoLogin.bOtherBefore;
      if (!Attivo)
        return IBUtenteEntrato.eEsitoLogin.bNonAttivo;
      if (BUtenti.CheckPassepartout(password, this.Connection))
      {
        return IBUtenteEntrato.eEsitoLogin.bOk;
      }

      if (TipoLogIn == IBUtenteEntrato.eAuthType.NONE | Developer)
      {
        if ((password ?? "") == (BCrypter.Decrypt(Password) ?? ""))
        {
          return IBUtenteEntrato.eEsitoLogin.bOk;
        }
        else
        {
          return IBUtenteEntrato.eEsitoLogin.bLoginFallito;
        }
      }
      else
      {
        try
        {
          if (BAuthentication.ImpersonateValidUser(username, Dominio, password))
          {
            BAuthentication.UndoImpersonation();
            return IBUtenteEntrato.eEsitoLogin.bOk;
          }
          else
          {
            return IBUtenteEntrato.eEsitoLogin.bLoginFallito;
          }
        }
        catch (Exception ex)
        {
          ModLog.ScriviLog(this.Connection, null, "CLASS", ex, "BsysUtenti.CheckLogin", "", BEnumerations.eSeverity.ERROR);
          return IBUtenteEntrato.eEsitoLogin.bLoginFallito;
        }
      }
    }

    //DEFINIZIONE METODI PUBBLICI
    public bool WriteEntry(string UserHostAddress, string UserHostName)
    {
      try
      {
        Accesso = new BTemplateBaseLibrary.BsysAccessi(this.Connection);
        Accesso.IDSysUtente = ID;
        Accesso.DataAccesso = DateAndTime.Now;
        Accesso.NomeComputer = UserHostAddress + "[" + UserHostName + "]";
        return Accesso.Update(false);
      }
      catch (Exception exp)
      {
        ModLog.ScriviLog(this.Connection, null, "BCLASS", exp, "BsysUtenti.WriteEntry", "", BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public bool WriteEntryAccediCome(BUtenti UtenteLoggato, string UserHostAddress, string UserHostName)
    {
      try
      {
        Accesso = new BTemplateBaseLibrary.BsysAccessi(this.Connection);
        Accesso.IDSysUtente = UtenteLoggato.ID;
        Accesso.DataAccesso = DateAndTime.Now;
        Accesso.NomeComputer = UserHostAddress + "[" + UserHostName + "]";
        return Accesso.Update(false);
      }
      catch (Exception ex)
      {
        ModLog.ScriviLog(this.Connection, null, "BCLASS", ex, "BsysUtenti.WriteEntry", "", BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public bool CheckVirtualLogin(string NTAccount, string NTDomain, BPageBase BP)
    {
      if (!BWebConfig.ActiveVirtualLogin)
        return this.SetVirtualUser(NTDomain, NTAccount, BP);
      else
        return false;
    }
    public bool GetCustomProfileForAutoAuthentication(BPageBase p)
    {
      BDataTable DT = null;
      string SP = "BSP_GetCustomProfileForAutoAuth";
      try
      {
        // SCRIVERE QUI LA LOGICA DI AUTO PROFILIAZIONE
        this.Connection.ClearParameter();
        this.Connection.AddParameter("@Username", this.Username);
        this.Connection.AddParameter("@Dominio", this.Dominio);
        DT = this.Connection.ApriDT(SP, CommandType.StoredProcedure);
        if (DT != null && DT.Rows.Count > 0)
        {
          // SET PROFILE FOR AUTO LOGIN
          if (Convert.IsDBNull(DT.Rows[0]["IDSysSistema"]) || Convert.IsDBNull(DT.Rows[0]["IDSysProfilo"]))
          {
            p.WriteLog("BUtenti.GetCustomProfileForAutoAuthentication()", "BSP_GetCustomProfileForAutoAuth return idsistema or idprofilo null", BArts.BEnumerations.eSeverity.ERROR);
          }
          else
          {
            this.IDSysSistema = (int)(DT.Rows[0]["IDSysSistema"]);
            this.IDSysProfilo = (int)(DT.Rows[0]["IDSysProfilo"]);
          }
        }
        else
        {
          // SET PROFILE FOR AUTO LOGIN
          this.IDSysSistema = p.Config.IDSistemaRegistrazione;
          this.IDSysProfilo = p.Config.IDProfiloRegistrazione;
          return false;
        }

        return true;
      }
      catch (Exception ex)
      {
        p.WriteLog("BUtenti.GetCustomProfileForAutoAuthentication()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (DT != null)
        {
          DT.Dispose();
          DT = null;
        }
      }
    }
    public bool HasMnvKey(string key)
    {
      object idfunzione = null;
      try
      {
        string BSP_sysGetMnvWP = "BSP_sysGetMnvWP";
        Connection.ClearParameter();
        Connection.AddParameter("@IDUtente", this.IDUtenteWP);
        Connection.AddParameter("@mnvkey", key);
        idfunzione = Connection.ExecuteScalar(BSP_sysGetMnvWP, CommandType.StoredProcedure);
        if (idfunzione == null)
        {
          return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        ModLog.ScriviLog(this.Connection, null, "BCLASS", ex, "BsysUtenti.HasMnvKey", "", BEnumerations.eSeverity.ERROR);
        return false;
        throw;
      }
    }

    //DEFINIZIONE METODI SHARED
    public static bool CheckPassepartout(string pw, BConnection db)
    {
      string sp = "BSP_sysPasspartout_CHECK";
      db.ClearParameter();
      db.AddParameter("@password", pw);
      if (BConvert.ToInt(db.ExecuteScalar(sp, CommandType.StoredProcedure)) > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public static bool SetPassepartout(string pw, BConnection db)
    {
      string sp = "BSP_sysPassepartout_SET";
      db.ClearParameter();
      db.AddParameter("@Password", pw);
      if (db.ExecuteNonQuery(sp, CommandType.StoredProcedure) > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public static bool DeletePassepartout(BConnection db)
    {
      string sp = "BSP_sysPassepartout_DELETE";
      db.ClearParameter();
      db.ExecuteNonQuery(sp, CommandType.StoredProcedure);
      return true;
    }
    public static bool CheckStartAuthentication()
    {
      if (BWebConfig.GestioneUtenti)
      {
        if (BWebConfig.AutenticazioneIniziale)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        return false;
      }
    }

    public static bool LoadUserFromWebPers(BPageBase p)
    {
      try
      {
        string sLog = "";
        int TknID = BConvert.ToInt(p.Request.QueryString["tknid"]);
        string NewWebPers = BConvert.ToString(p.Request.QueryString["NewWebPers"]);
        string Debug = BConvert.ToString(p.Request.QueryString["debug"]);
        if (TknID < 0)
        {
          p.WriteLog("BUtenti.LoadUserFromWebPers()", "Token non presente", BEnumerations.eSeverity.ERROR);
          return false;
        }

        DataTable dt = new DataTable();
        BUtenti ut;
        p.WriteLog("default.LoadUserFromWebPers()", "Lettura Token n." + TknID.ToString(), BEnumerations.eSeverity.INFORMATION);
        p.DB.ClearParameter();
        p.DB.AddParameter(new SqlParameter("@id", TknID));
        if (Debug != "1") { p.DB.AddParameter(new SqlParameter("@DeleteToken", 0)); }

        if (NewWebPers == "1")
        {
          dt = p.DB.ApriDT("BSP_sysGetToken_NewWP", CommandType.StoredProcedure);
        }
        else
        {
          dt = p.DB.ApriDT("BSP_sysGetToken", CommandType.StoredProcedure);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
          p.WriteLog("default.LoadUserFromWebPers()", "Acquisizione Dati Token n." + TknID.ToString(), BEnumerations.eSeverity.INFORMATION);
          ut = new BUtenti(BConvert.ToString(dt.Rows[0]["NTAccount"]), BConvert.ToString(dt.Rows[0]["NTDomain"]), p.DB);
          if (ut != null && ut.IsNothing == false)
          {
            string LogUtente = BConvert.ToString(dt.Rows[0]["NTDomain"]) + "/" + BConvert.ToString(dt.Rows[0]["NTAccount"]);
            p.WriteLog("default.LoadUserFromWebPers()", "Acquisizione dati Utente " + LogUtente, BEnumerations.eSeverity.INFORMATION);
            ut.IDUtenteWP = BConvert.ToString(dt.Rows[0]["idUtente"]);
            ut.IDApplicazione = BConvert.ToInt(dt.Rows[0]["idApplicazione"]);
            ut.IDVisibilita = BConvert.ToInt(dt.Rows[0]["IDVisibilitaTerritoriale"]);
            if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.WPInterna)
            {
              ut.IDJobRoleWP = BConvert.ToInt(dt.Rows[0]["IDJobRole"]);
              ut.IDSysProfilo = BConvert.ToInt(dt.Rows[0]["IDSysProfilo"]);
            }
            sLog = ("IDApplicazione = " + BConvert.ToString(ut.IDApplicazione) + "; IDUtente = " + BConvert.ToString(ut.IDUtenteWP) + ": IDProfilo= " + BConvert.ToString(ut.IDSysProfilo));
            p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.INFORMATION);
            if (ut.WriteEntry())
            {
              ut.Accesso.IDSysSistema = ut.IDSysSistema;
              ut.Accesso.IDSysProfilo = ut.IDSysProfilo;
              if (ut.Accesso.Update() == false)
              {
                sLog = "Salvataggio Accesso dell'utente " + BConvert.ToString(ut.IDUtenteWP) + " fallito.";
                p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.WARNING);
              }
              ut.WriteOperation("Accesso all'applicazione Child" + BWebConfig.TitoloWebSite + " effettuata.");
              sLog = "Accesso dell'utente " + BConvert.ToString(ut.IDUtenteWP) + " all'applicazione Child" + BWebConfig.TitoloWebSite + " effettuata con token n. " + BConvert.ToString(TknID);
              p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.INFORMATION);

              p.Session[ModConstantList.K_SE_SYSUTENTEENTRATO] = ut;
              return true;
            }
            else
            {
              sLog = "Scrittura accesso dell'utente " + BConvert.ToString(ut.IDUtenteWP) + " fallita.";
              p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.WARNING);
              return false;
            }

          }
          else
          {
            sLog = "Acquisizione dati Utente " + BConvert.ToString(dt.Rows[0]["NTAccount"]) + " fallita.";
            p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.WARNING);
            return false;
          }

        }
        else
        {
          string sqlEx = "";
          if (p.DB.ExceptionList != null)
          {
            foreach (Exception ex in p.DB.ExceptionList)
            {
              sqlEx = sqlEx + " " + ex.Message;
            }
          }
          sLog = "Acquisizione Dati Token n." + BConvert.ToString(TknID) + "fallita." + sqlEx;
          p.WriteLog("default.LoadUserFromWebPers()", sLog, BEnumerations.eSeverity.WARNING);
          return false;
        }
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (p.UtenteEntrato != null && p.UtenteEntrato.IsNothing == false)
        {
          IDAccesso = p.UtenteEntrato.IDAccesso;
          IDSysUtente = p.UtenteEntrato.Username;
        }
        string messaggio = "IDAccesso = " + BConvert.ToString(IDAccesso) + "USERNAME = " + IDSysUtente + " - " + ex.Message;
        p.WriteLog("default.LoadUserFromWebPers()", messaggio, BEnumerations.eSeverity.ERROR);
        return false;
        throw;
      }
    }


    //DEFINIZIONE FUNZIONI PRIVATE
    private bool SetVirtualUser(string NTDomain, string NTAccount, BPageBase BP)
    {
      // ESEMPIO DI VIRTUALIZZAZIONE DELL'UTENTE
      // Dim c As New BClienti(NTAccount, NTDomain, Me.Connection)
      // If Not c Is Nothing AndAlso Not c.IsNothing Then
      // Me.m_IsNothing = False
      // Me.Username = NTAccount
      // Me.Password = BCrypter.Encrypt(c.password)
      // Me.IDPersona = c.ID
      // Me.ID = c.Azienda.Nominativo ' NOME MOSTRATO SUL MENU
      // Me.Attivo = True
      // Return Me.GetCustomProfileForAutoAuthentication(BP)
      // Else
      // Return False
      // End If
      return false; // Commentare se viene implementata la funzione.
    }


  } //END CLASS
} //END NAMESPACE