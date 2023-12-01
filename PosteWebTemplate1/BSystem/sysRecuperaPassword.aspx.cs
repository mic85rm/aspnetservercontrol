using BArts;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using System;

namespace PosteWebTemplate1
{
  public partial class sysRecuperaPassword : BPageBase
  {

    protected override void OnInit(EventArgs e)
    {
      this.CheckAuth = false;
      base.OnInit(e);
    }
    protected override void SetAttributes_AddEvents()
    {
      BtnRecupera.Click += BtnRecupera_Click;
      base.SetAttributes_AddEvents();
    }

    protected void BtnRecupera_Click(object sender, EventArgs e)
    {
      BsysUtenti ut = null;
      string url = "";
      try
      {
        ut = new BsysUtenti(this.mbtIDUtente.Text, base.DB);
        if (ut == null || ut.IsNothing)
        {
          this.lblMessagge.Text = "Identificativo utente non valido.";
          this.mbtIDUtente.Focus();
        }
        else if (ut.Persona == null || ut.Persona.IsNothing || !BArts.BGlobal.BGlobal.IsSyntaxEmailCorrect(ut.Persona.Email))
        {
          this.lblMessagge.Text = "La scheda anagrafica dell'utente non è completa. Si prega di contattare l'assistenza all'indirizzo info@b-arts.eu";
          this.mbtIDUtente.Focus();
        }
        else
        {
          string oggetto = "Recupero Password " + BWebConfig.TitoloWebSite;
          string welcome = "Gentile " + ut.Persona.Nome + " " + ut.Persona.Cognome + ",";
          url = base.Request.Url.ToString().Replace("BSystem/sysRecuperaPassword", "BSystem/sysLogin");
          string messaggio = welcome + Environment.NewLine + Environment.NewLine + "Questa email è stata inviata automaticamente in risposta alla richiesta di recupero della password." + Environment.NewLine + "Riepilogo Dati inseriti in fase di registrazione:" + Environment.NewLine + Environment.NewLine + "Il Nome utente da lei scelto è: " + ut.Username + Environment.NewLine + "La Password da lei scelta è: " + BCrypter.Decrypt(ut.Password) + Environment.NewLine + Environment.NewLine + "per accedere all'applicazione clicca qui in basso:  " + Environment.NewLine + "<a href=\"" + url + "\"> Vai alla Login </a>";
          if (this.SendMail(oggetto, messaggio, ut.Persona.Email))
          {
            this.lblMessagge.Text = "E' stata inviata una mail all'indirizzo email associato al suo ID Utente.";
          }
          else
          {
            this.lblMessagge.Text = "Il recupero Password non è stato possibile per un problema tecnico.";
          }
        }
      }
      catch (Exception ex)
      {
        this.lblMessagge.Text = "Il recupero Password non è stato possibile per un problema tecnico.";
        this.WriteLog("sysRecuperaPassword.BtnRecupera_Click()", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }

  }//END CLASS
} //END NAMESPACE