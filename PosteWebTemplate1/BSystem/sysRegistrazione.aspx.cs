using BArts;
using BArts.BGlobal;
using BArts.BNet.BSocial;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysRegistrazione : BPageBase
  {

    public const string K_SE_BSOCIALUSER = "BSocialUser";
    public BSocialUser SocialUser
    {
      get
      {
        return (BSocialUser)Session[K_SE_BSOCIALUSER];
      }
      set
      {
        Session[K_SE_BSOCIALUSER] = value;
      }
    }


    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.CheckAuth = false;
      this.CtlCommandBar.PageName = "Registrati a " + BWebConfig.TitoloWebSite;
      this.CtlCommandBar.CtlBtnElimina.Visible = false;
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;
      base.BPage_Init(sender, e);
    }
    protected override void OnLoad(EventArgs e)
    {
      if (!base.IsPostBack)
      {
        SetInitProperty();
      }

      SetAttributes_Invio();
      base.OnLoad(e);
    }

    protected override void SetAttributes_AddEvents()
    {
      mbtCodiceFiscale.HelpButtonClick += mbtCodiceFiscale_HelpButtonClick;
      mbtIDUtente.HelpButtonClick += mbtIDUtente_HelpButtonClick;
      btnShowInformativa.Click += btnShowInformativa_Click;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;
      PnlShowMessage.Annulla += PnlShowMessage_Annulla;
      BtnConferma.Click += BtnConferma_Click;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void SetInitProperty()
    {
      this.PnlDettaglio.Visible = true;

      // NUOVO REC
      if (this.SocialUser == null)
      {
        this.mbtIDUtente.Text = "";
        this.mbtID.Text = "";
        this.mbtCodiceFiscale.Text = "";
        this.mbtNome.Text = "";
        this.mbtCognome.Text = "";
        this.mbtPassword.Text = "";
        this.mbtDataNascita.Text = "";
        this.mbtemail.Text = "";
        this.mbtIDComuneNascita.Text = "";
      }
      else
      {
        this.mbtID.Text = "";
        this.mbtCodiceFiscale.Text = "";
        this.mbtNome.Text = SocialUser.Nome;
        this.mbtCognome.Text = SocialUser.Cognome;
        this.mbtIDUtente.Text = SocialUser.Nome.Substring(0, 1) + mbtCognome.Text;
        this.mbtPassword.Text = "";
        this.mbtDataNascita.Text = "";
        this.mbtemail.Text = SocialUser.Email;
        this.mbtIDComuneNascita.Text = "";

      }
      // SET ATTRIBUTES OTHER
      CaricaComboSesso();
      mbtIDComuneNascita.SetAutoComplete(this.Page, "BsysComuni", "autocomplete");

      // SET FOCUS
      this.mbtNome.Focus();
    }
    private void SetAttributes_Invio()
    {
      this.mbtNome.CtlNextFocus = this.mbtCognome.ClientID;
      this.mbtNome.INVIO = true;
      this.mbtCognome.CtlNextFocus = this.mbtDataNascita.ClientID;
      this.mbtDataNascita.CtlNextFocus = this.mbcSesso.ClientID;
      this.mbcSesso.CtlNextFocus = this.mbtIDComuneNascita.ClientID;
      this.mbtIDComuneNascita.CtlNextFocus = this.mbtCodiceFiscale.ClientID;
      this.mbtCodiceFiscale.CtlNextFocus = this.mbtemail.ClientID;
      this.mbtemail.CtlNextFocus = this.mbtIDUtente.ClientID;
      this.mbtIDUtente.CtlNextFocus = this.mbtPassword.ClientID;
      this.mbtPassword.CtlNextFocus = this.CtlCommandBar.CtlBtnSalva.ClientID;
    }
    private void CaricaComboSesso()
    {
      this.mbcSesso.Items.Insert(0, new ListItem("Selezione", (-1).ToString()));
      this.mbcSesso.Items.Insert(1, new ListItem("Femmina", 0.ToString()));
      this.mbcSesso.Items.Insert(2, new ListItem("Maschio", 1.ToString()));
    }
    private bool CheckBeforeUpdate(string idComuneNascita)
    {
      if (string.IsNullOrEmpty(this.mbtNome.Text.Trim()))
      {
        this.MsgBox("Nome obbligatorio", CtlFocusOnClick: this.mbtNome);
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtCognome.Text.Trim()))
      {
        this.MsgBox("Cognome obbligatorio", CtlFocusOnClick: this.mbtCognome);
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtDataNascita.Text.Trim()))
      {
        this.MsgBox("Data nascita obbligatoria", CtlFocusOnClick: this.mbtDataNascita);
        return false;
      }

      if (int.Parse(this.mbcSesso.SelectedValue) == -1)
      {
        this.MsgBox("Sesso Obbligatorio", CtlFocusOnClick: this.mbcSesso);
        return false;
      }

      if (string.IsNullOrEmpty(idComuneNascita))
      {
        this.MsgBox("Comune di nascita obbligatorio", CtlFocusOnClick: this.mbtIDComuneNascita);
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtCodiceFiscale.Text.Trim()))
      {
        this.MsgBox("Codice fiscale obbligatorio", CtlFocusOnClick: this.mbtCodiceFiscale);
        return false;
      }

      if (this.mbtCodiceFiscale.Text != BGlobal.CalcolaCodiceFiscale(this.mbtNome.Text, this.mbtCognome.Text, this.mbtDataNascita.Text, idComuneNascita, BConvert.ToBool(this.mbcSesso.SelectedValue)))
      {
        this.MsgBox("Il codice fiscale non è formalmente correto.", CtlFocusOnClick: this.mbtCodiceFiscale);
        return false;
      }

      if (this.EsisteAnagrafica(this.mbtCodiceFiscale.Text))
      {
        this.MsgBox("Impossibile procedere, è già presente un'altro utente con il codice fiscale inserito.", CtlFocusOnClick: this.mbtCodiceFiscale);
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtemail.Text.Trim()))
      {
        this.MsgBox("Email Obbligatoria", CtlFocusOnClick: this.mbtemail);
        return false;
      }

      if (!BGlobal.IsSyntaxEmailCorrect(this.mbtemail.Text))
      {
        this.MsgBox("Il campo email non è formalmente corretto.", CtlFocusOnClick: this.mbtemail);
        return false;
      }

      if (this.EsisteEmailUtente(this.mbtemail.Text))
      {
        this.MsgBox("Impossibile procedere, l'indirizzo email è già stato utilizzato da un'altro utente.", CtlFocusOnClick: this.mbtemail);
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtIDUtente.Text.Trim()))
      {
        this.MsgBox("ID Utente Obbligatorio", CtlFocusOnClick: this.mbtIDUtente);
        return false;
      }

      if (BGlobal.EsistonoRecord("sysUtenti", this.DB, "ID = '" + this.mbtIDUtente.Text.Trim() + "'") | BGlobal.EsistonoRecord("sysRegistrazioniRichieste", this.DB, "IDUtente = '" + this.mbtIDUtente.Text + "'"))
      {
        this.MsgBox("ID Utente già utilizzato", CtlFocusOnClick: this.mbtIDUtente);
        this.ImgCheckUser.CssClass = "ImageCheckUserFailed";
        return false;
      }

      if (string.IsNullOrEmpty(this.mbtPassword.Text.Trim()))
      {
        this.MsgBox("La password non può essere vuota.", CtlFocusOnClick: this.mbtPassword);
        return false;
      }

      if (!this.chkTermini.Checked)
      {
        this.MsgBox("Impossibile procedere, accettare prima i termini di condizione.", CtlFocusOnClick: this.chkTermini);
        return false;
      }

      return true;
    }
    private bool EsisteEmailUtente(string email)
    {
      string q = "select * from sysUtenti u inner join sysPersone p on u.IDPersona = p.ID  where p.Email = '" + email.Replace("'", "''") + "'";
      DataTable dt = null;
      try
      {
        this.DB.ClearParameter();
        dt = this.DB.ApriDT(q, CommandType.Text);
        if (dt != null && dt.Rows.Count > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysRegistrazione.EsisteEmailUtente", "", ex, BEnumerations.eSeverity.ERROR);
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }

      return false;
    }
    private bool EsisteAnagrafica(string CF)
    {
      string q = "select * from sysUtenti u inner join sysPersone p on u.IDPersona = p.ID  where p.CodiceFiscale = '" + CF.Replace("'", "''") + "'";
      DataTable dt = null;
      try
      {
        this.DB.ClearParameter();
        dt = this.DB.ApriDT(q, CommandType.Text);
        if (dt != null && dt.Rows.Count > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysRegistrazione.EsisteEmailUtente", "", ex, BEnumerations.eSeverity.ERROR);
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }

      return false;
    }

    // DEFINIZIONE METODI OVERRIDES
    public override void Indietro_Click()
    {
      if (!BWebConfig.AutenticazioneIniziale)
      {
        this.BRedirect(ModConstantList.K_PAGE_DEFAULT);
      }

      base.Indietro_Click();
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void mbtCodiceFiscale_HelpButtonClick()
    {
      if (this.mbtNome == null | string.IsNullOrEmpty(this.mbtNome.Text.Trim()))
      {
        this.MsgBox("Attenzione! Campo Nome obbligatorio.");
        return;
      }
      else if (this.mbtCognome == null | string.IsNullOrEmpty(this.mbtCognome.Text.Trim()))
      {
        this.MsgBox("Attenzione! Campo Cognome obbligatorio.");
        return;
      }
      else if (this.mbtDataNascita == null | string.IsNullOrEmpty(this.mbtDataNascita.Text.Trim()))
      {
        this.MsgBox("Attenzione! Campo Data di nascita obbligatorio.");
        return;
      }
      else if (this.mbtIDComuneNascita == null | string.IsNullOrEmpty(this.mbtIDComuneNascita.Text.Trim()))
      {
        this.MsgBox("Attenzione! Campo Comune di nascita obbligatorio.");
      }
      else if (BConvert.ToInt(this.mbcSesso.SelectedValue) == -1)
      {
        this.MsgBox("Attenzione! Il campo Sesso obbligatorio.");
        return;
      }
      else
      {
        string idComune = "";
        idComune = this.mbtIDComuneNascita.AutoCompleteValue;
        if (idComune == "0" && !string.IsNullOrEmpty(mbtIDComuneNascita.Text)) idComune = ModWebServices.GetIDComuneFromDescrWS(mbtIDComuneNascita.Text, DB, this);
        if (string.IsNullOrEmpty(idComune))
        {
          this.MsgBox("Attenzione! il campo Comune non è formalmente corretto");
          return;
        }

        this.mbtCodiceFiscale.Text = BGlobal.CalcolaCodiceFiscale(this.mbtNome.Text, this.mbtCognome.Text, this.mbtDataNascita.Text, idComune, BConvert.ToBool(this.mbcSesso.SelectedValue));
      }

      this.mbtCodiceFiscale.Focus();
    }
    private void mbtIDUtente_HelpButtonClick()
    {
      if (string.IsNullOrEmpty(this.mbtIDUtente.Text.Trim()))
      {
        this.MsgBox("Inserimento obbligatorio.", CtlFocusOnClick: this.mbtIDUtente);
        return;
      }

      if (BGlobal.EsistonoRecord("sysUtenti", this.DB, "ID = '" + this.mbtIDUtente.Text.Trim() + "'") | BGlobal.EsistonoRecord("sysRegistrazioniRichieste", this.DB, "IDUtente = '" + this.mbtIDUtente.Text + "'"))
      {
        this.ImgCheckUser.CssClass = "PnlImageCheck BIconSemaforoRosso";
      }
      else
      {
        this.ImgCheckUser.CssClass = "PnlImageCheck BIconSemaforoVerde";
      }

      this.mbtIDUtente.Focus();
    }
    private void btnShowInformativa_Click(object sender, EventArgs e)
    {
      this.lblInfo.Text = this.Config.LeggePrivacy;
      this.PnlInformation.Show();
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA COMMAND BAR
    protected void CtlCommandBar_Salva()
    {
      string oggetto = "Registrazione " + BWebConfig.TitoloWebSite;
      string welcome = "";
      string messaggio = "";
      string IDComuneNascita = this.mbtIDComuneNascita.AutoCompleteValue;
      if (IDComuneNascita == "0" && !string.IsNullOrEmpty(mbtIDComuneNascita.Text)) IDComuneNascita = ModWebServices.GetIDComuneFromDescrWS(mbtIDComuneNascita.Text, DB, this);
      BsysRegistrazioniRichieste Obj = null;
      try
      {
        if (!CheckBeforeUpdate(IDComuneNascita)) return;
        Obj = new BsysRegistrazioniRichieste(this.DB);
        Obj.IDUtente = this.mbtIDUtente.Text;
        Obj.CodiceFiscale = this.mbtCodiceFiscale.Text;
        Obj.Nome = BVisualBasic.UppercaseFirstLetter(this.mbtNome.Text);
        Obj.Cognome = BVisualBasic.UppercaseFirstLetter(this.mbtCognome.Text);
        Obj.DataNascita = BGlobal.PrendiData(this.mbtDataNascita.Text);
        Obj.Sesso = BConvert.ToBool(this.mbcSesso.SelectedValue);
        Obj.email = this.mbtemail.Text;
        Obj.Password = BCrypter.Encrypt(this.mbtPassword.Text);
        Obj.IDComuneNascita = IDComuneNascita;
        if (Obj.Update())
        {
          // composizione messaggio mail
          string url = "";
          url = base.Request.Url.ToString().Substring(0, base.Request.Url.ToString().LastIndexOf("/"));
          url += "/sysConfermaRegistrazione.aspx?key=" + BCrypter.Encrypt(Obj.ID.ToString());
          welcome = "Salve " + Obj.Nome + " " + Obj.Cognome + ", ";
          messaggio = welcome + Environment.NewLine + "di seguito trova i dati per accedere all'applicativo " + BWebConfig.TitoloWebSite + ": " + Environment.NewLine + Environment.NewLine + "Nome Utente: " + this.mbtIDUtente.Text + Environment.NewLine + "Password: " + this.mbtPassword.Text + Environment.NewLine + Environment.NewLine + "<a href=\"" + url + "\"> Clicca qui per completare la registrazione</a>";
          if (!base.SendMail(oggetto, messaggio, this.mbtemail.Text))
          {
            Obj.Delete();
            this.MsgBox("Attenzione... non è stato possibile completare la registrazione...");
            this.WriteLog("sysRegistrazione.CtlCommandBar_Salva()", "Invio email non riuscito.", BEnumerations.eSeverity.ERROR);
            this.mbtNome.Focus();
            return;
          }
          // REGISTRAZIONE COMPLETATA
          this.PnlShowMessage.Show();
        }
        else
        {
          this.MsgBox("Attenzione... non è stato possibile completare la registrazione...");
        }

        Obj = null;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysRegistrazione.BtnSalva():", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }
    protected void CtlCommandBar_Annulla()
    {
      this.BRedirect(ModConstantList.K_PAGE_LOGIN);
    }
    private void PnlShowMessage_Annulla()
    {
      this.BRedirect(ModConstantList.K_PAGE_DEFAULT);
    }
    private void BtnConferma_Click(object sender, EventArgs e)
    {
      CtlCommandBar_Salva();
    }

  } //END CLASS
} //END NAMESPACE