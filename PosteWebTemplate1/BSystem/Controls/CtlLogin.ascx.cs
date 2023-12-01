using BArts;
using BArts.BData;
using BArts.BInterface;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Linq;

namespace PosteWebTemplate1
{
  public partial class CtlLogin : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event AccediEventHandler Accedi;
    public delegate void AccediEventHandler();

    public event LogInErratoEventHandler LogInErrato;
    public delegate void LogInErratoEventHandler();

    public event RegistrazioneEventHandler Registrazione;
    public delegate void RegistrazioneEventHandler();

    public event RecuperaPassawordEventHandler RecuperaPassaword;
    public delegate void RecuperaPassawordEventHandler();

    // DEFINIZIONE PROPRIETA'
    #region private string Password
    private const string K_VS_PASSWORD = ".Password";
    private string Password
    {
      set
      {
        base.ViewState[base.ID + K_VS_PASSWORD] = value;
      }
      get
      {
        return base.ViewState[base.ID + K_VS_PASSWORD].ToString();
      }
    }
    #endregion

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      btnAccedi.Click += btnAccedi_Click;
      btnAccedi.Invio += btnAccedi_Click;
      btnRegistrazione.Click += btnRegistrazione_Click;
      btnRecuperaPwd.Click += btnRecuperaPwd_Click;
      pnlSelectDomain.Conferma += PnlSelectDomain_Conferma;

      base.SetAttributes_AddEvents();
    }

    protected override void BControl_Load(object sender, EventArgs e)
    {
      this.Page.Form.DefaultButton = btnAccedi.ClientID.Replace("_", "$");
      this.mbtUsername.CtlNextFocus = this.mbtPassword.ClientID;
      this.mbtPassword.CtlNextFocus = this.btnAccedi.ClientID;
      this.btnRegistrazione.Visible = BWebConfig.ShowRegistrati;
      this.btnRecuperaPwd.Visible = BWebConfig.ShowPwdSmarrita;
      if (!base.IsPostBack)
      {
        if (BWebConfig.AuthType == IBUtenteEntrato.eAuthType.WINDOWS)
        {
          if (!this.Page.User.Identity.IsAuthenticated | !BWebConfig.ShowNTAccount)
          {
            this.mbtUsername.Text = "";
            this.mbtUsername.Focus();
          }
          else
          {
            var aAccount = this.Page.User.Identity.Name.Split('\\');
            if (aAccount.Length > 1)
            {
              this.mbtUsername.Text = aAccount[1];
            }
            else
            {
              this.mbtUsername.Text = this.Page.User.Identity.Name;
            }
            this.mbtPassword.Focus();
          }
        }
        else
        {
          this.mbtUsername.Focus();
        }
      }
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void btnAccedi_Click(object sender, EventArgs e)
    {
      string Username = "";
      string Domain = "";
      if (string.IsNullOrEmpty(this.mbtUsername.Text))
      {
        this.imgDivieto.Visible = true;
        this.lblInfo.Text = "Username e/o Password non validi.";
        this.mbtUsername.Focus();
        LogInErrato?.Invoke();
        return;
      }

      Username = this.mbtUsername.Text;
      if (Username.IndexOf(@"\") != -1)
      {
        Domain = BArts.BGlobal.BGlobal.PrendiParteStr(Username, 1, @"\");
        Username = BArts.BGlobal.BGlobal.PrendiParteStr(Username, 2, @"\");
        this.LogIn(Username, this.mbtPassword.Text, Domain);
      }
      else
      {
        DataTable dt = this.GetDominiPerUtente(this.mbtUsername.Text);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (dt.Rows.Count > 1)
          {
            this.pnlSelectDomain.Show();
            this.lblErrore.Visible = false;
            Password = this.mbtPassword.Text;
            this.rblDomini.DataSource = dt;
            this.rblDomini.DataBind();
          }
          else
          {
            this.LogIn(this.mbtUsername.Text, this.mbtPassword.Text, dt.Rows[0]["Dominio"].ToString());
          }
        }
        else
        {
          this.imgDivieto.Visible = true;
          this.lblInfo.Text = "Username e/o Password non validi.";
          this.mbtPassword.Focus();
          LogInErrato?.Invoke();
        }
      }
    }
    private void btnRegistrazione_Click(object sender, EventArgs e)
    {
      Registrazione?.Invoke();
    }
    private void btnRecuperaPwd_Click(object sender, EventArgs e)
    {
      RecuperaPassaword?.Invoke();
    }
    private void PnlSelectDomain_Conferma()
    {
      if (this.rblDomini.SelectedIndex >= 0)
      {
        this.LogIn(this.mbtUsername.Text, Password, this.rblDomini.SelectedValue);
        Password = "";
      }
      else
      {
        this.lblErrore.Visible = true;
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private DataTable GetDominiPerUtente(string Username)
    {
      DataTable dt;
      try
      {
        base.DB.ClearParameter();
        base.DB.AddParameter("@Username", Username);
        dt = base.DB.ApriDT("BSP_sysUtenti_CheckDomain", CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          return dt;
        }
        else if (BWebConfig.ActiveVirtualLogin)
        {
          base.DB.ClearParameter();
          base.DB.AddParameter("@Username", Username);
          dt = base.DB.ApriDT("BSP_sysUtenti_CheckVirtualDomain", CommandType.StoredProcedure);
          if (dt != null && dt.Rows.Count > 0)
          {
            return dt;
          }
          else
          {
            return null;
          }
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("CtlLogin.GetDominiPerUtente():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }
    private void LogIn(string UserName, string Password, string Domain)
    {
      BUtenti utente;
      bool ret = false;
      try
      {
        utente = new BUtenti(UserName, Domain, DB);
        if (utente != null)
        {
          // VERIFICO SE L'UTENTE E' VIRTUALE NEL CASO IN CUI NON E' PRESENTE NELLA TABELLA UTENTI
          if (utente.IsNothing && !utente.CheckVirtualLogin(UserName, Domain, this.BPage))
          {
            this.imgDivieto.Visible = true;
            this.lblInfo.Text = "L'utente non è abilitato all'utilizzo dell'applicazione";
            this.mbtUsername.Focus();
            LogInErrato?.Invoke();
            return;
          }

          // CONTROLLO AUTENTICAZIONE
          IBUtenteEntrato.eEsitoLogin switchExpr = utente.CheckLogin(this.mbtUsername.Text, Password, BWebConfig.AuthType);
          switch (switchExpr)
          {
            case IBUtenteEntrato.eEsitoLogin.bOk:
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
                  ret = true;
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
                    this.WriteLog("CtlLogin.Login():", "Salvataggio accesso fallito.", BEnumerations.eSeverity.ERROR);
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

                  ret = true;
                }

                break;
              }

            case IBUtenteEntrato.eEsitoLogin.bLoginFallito:
              {
                this.imgDivieto.Visible = true;
                this.lblInfo.Text = "Username e/o Password non validi.";
                this.mbtPassword.Focus();
                ret = false;
                LogInErrato?.Invoke();
                break;
              }

            case IBUtenteEntrato.eEsitoLogin.bNonAttivo:
              {
                this.imgDivieto.Visible = true;
                this.lblInfo.Text = "L'accesso per questo utente è bloccato.";
                this.mbtPassword.Focus();
                ret = false;
                LogInErrato?.Invoke();
                break;
              }

            case IBUtenteEntrato.eEsitoLogin.bOtherBefore:
              {
                this.imgDivieto.Visible = true;
                this.lblInfo.Text = "L'utente non è abilitato all'utilizzo dell'applicazione";
                this.mbtPassword.Focus();
                ret = false;
                LogInErrato?.Invoke();
                break;
              }

            default:
              {
                ret = false;
                LogInErrato?.Invoke();
                break;
              }
          }
        }
        else
        {
          this.imgDivieto.Visible = true;
          this.lblInfo.Text = "Utente errato.";
          this.mbtUsername.Focus();
          LogInErrato?.Invoke();
        }

        if (ret)
        {
          Accedi?.Invoke();
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("CtlLogin.Login():", "", ex, BEnumerations.eSeverity.ERROR);
        this.imgDivieto.Visible = true;
        this.lblInfo.Text = "Si è verificato un errore in fase di login.";
        this.mbtUsername.Focus();
        LogInErrato?.Invoke();
      }
    }

  } //END CLASS
} //END NAMESPACE