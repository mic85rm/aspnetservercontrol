using BArts;
using BArts.BGlobal;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;

namespace PosteWebTemplate1
{
  public partial class sysConfermaRegistrazione : BPageBase
  {

    //DEFINIZIONE PROPRIETA'
    #region private string IDRichiesta
    private string m_IDRichiesta = "";
    private string IDRichiesta
    {
      get
      {
        int IndexKey = -1;
        string Key = base.Request.RawUrl;
        IndexKey = base.Request.RawUrl.LastIndexOf("key");
        if (IndexKey != -1)
        {
          Key = Key.Substring(IndexKey).Replace("key=", "");
        }
        else
        {
          Key = "";
        }
        if (!string.IsNullOrEmpty(Key))
        {
          return BCrypter.Decrypt(Key);
        }
        else
        {
          return m_IDRichiesta;
        }
      }
    }
    #endregion

    //DEFINIZIONE METODI OVERRIDE
    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.CheckAuth = false;
      this.AutoRedirect = false;
    }
    protected override void BPage_Load(object sender, EventArgs e)
    {
      string errorMessage = "Attenzione! non è stato possibile creare l'utente per un problema tecnico.";
      BsysNotifiche objNotifica = null;
      try
      {
        if (!base.IsPostBack)
        {

          if (!string.IsNullOrEmpty(IDRichiesta))
          {
            var richiesta = new BsysRegistrazioniRichieste(int.Parse(IDRichiesta), base.DB);
            if (richiesta != null && richiesta.IsNothing == false)
            {
              var persona = new BsysPersone(richiesta.CodiceFiscale, DB, true);
              if (persona == null) persona = new BsysPersone(DB);
              persona.Cognome = richiesta.Cognome;
              persona.Nome = richiesta.Nome;
              persona.DataNascita = richiesta.DataNascita;
              persona.Email = richiesta.email;
              persona.IDComuneNascita = richiesta.IDComuneNascita;
              persona.Sesso = richiesta.Sesso;
              persona.CodiceFiscale = richiesta.CodiceFiscale;
              if (persona.Update())
              {
                var Utente = new BsysUtenti(base.DB);
                Utente.Password = richiesta.Password;
                Utente.Attivo = true;
                Utente.DataCreazione = DateAndTime.Now;
                Utente.Developer = false;
                Utente.ID = richiesta.IDUtente;
                Utente.Username = richiesta.IDUtente;
                Utente.IDPersona = persona.ID;
                Utente.IDSysPolicyPwd = -1; // Aggiungere anche questa nella tabella di configurazione
                Utente.IDSysSistema = this.Config.IDSistemaRegistrazione;
                Utente.IDSysProfilo = this.Config.IDProfiloRegistrazione;
                var ObjP = new BsysUtentiProfili(base.DB);
                ObjP.IDSysUtente = Utente.ID;
                ObjP.IDSysSistema = Utente.IDSysSistema;
                ObjP.IDSysProfilo = Utente.IDSysProfilo;
                Utente.Profili.Add(ObjP);
                if (Utente.Update())
                {
                  richiesta.Delete();
                  string sesso = "";
                  if (!richiesta.Sesso)
                  {
                    sesso = "Benvenuta ";
                  }
                  else
                  {
                    sesso = "Benvenuto ";
                  }

                  this.lblShowMessage.Text = sesso + BVisualBasic.UppercaseFirstLetter(richiesta.Nome) + " " + BVisualBasic.UppercaseFirstLetter(richiesta.Cognome) + ", <BR />" + "la registrazione è andata a buon fine. <BR /> <BR />" + "Effettua il login per accedere a tutte le funzionalità di " + BWebConfig.TitoloWebSite;
                  this.WriteLog("sysConfermaRegistrazione.pageLoad():", "Utente creato e attivo per id richiesta = " + IDRichiesta, BEnumerations.eSeverity.WARNING);

                  // CREA NOTIFICA
                  objNotifica = new BsysNotifiche(base.DB);
                  objNotifica.Titolo = "Registrazione nuovo utente";
                  objNotifica.Descrizione = "Ha completato la registrazione l'utente \"" + richiesta.Nome + " " + richiesta.Cognome + "\" con utenza \"" + Utente.Username + "\"";
                  objNotifica.DataNotifica = DateAndTime.Now;
                  objNotifica.LimitaVisibilita = true;
                  objNotifica.IDSysSistema = this.Config.IDSistemaRegistrazione;
                  objNotifica.IDSysProfilo = this.Config.IDProfiloNotificaRegistrazione;
                  objNotifica.InviaEmail = false;
                  objNotifica.Update();
                  // notifica per email al sistema
                  base.SendMail(objNotifica.Titolo, objNotifica.Descrizione, base.Config.EmailSegnalazioni);
                  objNotifica = null;

                  // CREA NOTIFICA
                  objNotifica = new BsysNotifiche(base.DB);
                  objNotifica.Titolo = "Benvenuto in " + BWebConfig.TitoloWebSite;
                  objNotifica.Descrizione = "La tua utenza è stata attivata. ";
                  objNotifica.DataNotifica = DateAndTime.Now;
                  objNotifica.LimitaVisibilita = true;
                  objNotifica.IDSysUtente = Utente.ID;
                  objNotifica.IDSysSistema = -1;
                  objNotifica.IDSysProfilo = -1;
                  objNotifica.InviaEmail = false;
                  objNotifica.Update();
                  // notifica per email al sistema
                  base.SendMail(objNotifica.Titolo, objNotifica.Descrizione, persona.Email);
                  objNotifica = null;
                }

                // 'CREA ATLETA
                // Dim atleta As New BAtleti(richiesta.CodiceFiscale, DB, True)
                // If Not atleta Is Nothing AndAlso atleta.IsNothing Then
                // atleta.IDSysPersona = persona.ID
                // atleta.IDAtletaPadre = -1
                // atleta.Update()
                // End If


                else
                {
                  this.WriteLog("sysConfermaRegistrazione.pageLoad():", "Salvataggio Utente (BSysUtenti) fallito per id richiesta = " + IDRichiesta, BEnumerations.eSeverity.WARNING);
                  this.lblShowMessage.Text = errorMessage;
                }
              }
              else
              {
                this.WriteLog("sysConfermaRegistrazione.pageLoad():", "Inizializzazione oggetto BsysRegistrazioniRichieste fallito per id richiesta = " + IDRichiesta, BEnumerations.eSeverity.WARNING);
                this.lblShowMessage.Text = errorMessage;
              }
            }
            else
            {
              this.lblShowMessage.Text = "Attenzione!!! <br /> <br /> L'Utente risulta già attivo a sistema. ";
            }
          }
          else
          {
            this.WriteLog("sysConfermaRegistrazione.pageLoad():", "Tentativo di accesso dalla postazione client <<" + base.Request.UserHostAddress + ">> senza parametro Key.", BEnumerations.eSeverity.INFORMATION);
            this.lblShowMessage.Text = "Attenzione!!! Si sta violando la key di registrazione. La seguente segnalazione è stata inoltrata alla polizia postale.";
          }

        }
      }
      // connessione assente
      catch (Exception ex)
      {
        this.lblShowMessage.Text = errorMessage;
        this.WriteLog("sysConfermaRegistrazione.pageLoad():", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }

    protected override void SetAttributes_AddEvents()
    {
      BtnBackHome.Click += BtnBackHome_Click;
      base.SetAttributes_AddEvents();
    }

    protected void BtnBackHome_Click(object sender, EventArgs e)
    {
      this.BRedirect(ModConstantList.K_PAGE_LOGIN);
    }


  } //END CLASS
} //END NAMESPCAE