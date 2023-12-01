using BArts;
using BArts.BGlobal;
using BArts.BInterface;
using BArts.BNet.BSocial;
using System;
using System.Globalization;

namespace PosteWebTemplate1
{
  public partial class sysLogin : BPageBase
  {
    //DEFINIZIONE METODI OVERRIDES
    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.DisabilitaInvio(false);
    }
    protected override void BPage_Load(object sender, EventArgs e)
    {

      this.lblApplicazione.Text = BWebConfig.TitoloWebSite;
      this.lblTitolo.Text = BWebConfig.DescrizioneWebSite;
      this.LblVersione.Text = "Ver. " + BWebConfig.VersioneWebSite;
      if (!base.IsPostBack) BMaster.EnabledSideBar = false;
      if (base.UtenteEntrato == null)
      {
        if (BWebConfig.AuthType == IBUtenteEntrato.eAuthType.WINDOWS)
        {
          this.lblMessaggio.Visible = false;
          //SETTAGGI SOCIAL
          this.BtnLoginWithGoogle.Visible = false;
          this.BtnLoginWithApple.Visible = false;
          this.BtnLoginWithMicrosoft.Visible = false;
        }
        else
        {
          this.lblMessaggio.Visible = false;
          //SETTAGGI SOCIAL
          this.BtnLoginWithGoogle.Visible = BWebConfig.GoogleAuth;
          this.BtnLoginWithApple.Visible = BWebConfig.AppleAuth;
          this.BtnLoginWithMicrosoft.Visible = BWebConfig.MicrosoftAuth;
        }
      }
      else
      {
        ShowMessagePage("Attenzione utente " + BSysUtenteEntrato.ID + " !<BR /> <BR />" + "per poter accedere come un nuovo utente, premere il tasto Disconnetti e <BR />" + "procedere nuovamente con l'autenticazione.");
      }
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlLogin.Registrazione += CtlLogin_Registrazione;
      CtlLogin.RecuperaPassaword += CtlLogin_RecuperaPassaword;
      CtlLogin.Accedi += CtlLogin_Accedi;
      BtnLoginWithGoogle.Click += BtnLoginWithGoogle_Click;
      BtnLoginWithFacebook.Click += BtnLoginWithFacebook_Click;
      BtnLoginWithMicrosoft.Click += BtnLoginWithMicrosoft_Click;

      base.SetAttributes_AddEvents();
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    private void CtlLogin_Registrazione()
    {
      this.BRedirect(ModConstantList.K_PAGE_REGISTRAZIONE);
    }
    private void CtlLogin_RecuperaPassaword()
    {
      this.BRedirect(ModConstantList.K_PAGE_RECUPERAPWD);
    }
    private void CtlLogin_Accedi()
    {
      BMaster.EnabledSideBar = BWebConfig.UseSideBar;
      BMaster.IsVisibleSideBar = BWebConfig.DefaultSidebarOpen;
    }

    //DA STUDIARE E COMPLETARE
    private void BtnLoginWithGoogle_Click(object sender, EventArgs e)
    {
      string ClientID = BWebConfig.GoogleAuth_ClientID;
      string clientsecret = BWebConfig.GoogleAuth_ClientSecret;
      string redirection_url = BGlobalNet.GetApplicationUrl(this);
      redirection_url = BGlobal.CreatePathFileWeb(redirection_url, ModConstantList.K_SYS_PAGE_AUTHGOOGLE);
      string Googleurl = "";
      var socgoogle = new BGoogleSocialAuth(ClientID, clientsecret, redirection_url);
      Googleurl = socgoogle.GetUrlAuthentication();
      this.BRedirect(Googleurl);
    }
    private void BtnLoginWithMicrosoft_Click(object sender, EventArgs e)
    {
      string ClientID = BWebConfig.MicrosoftAuth_ClientID;
      string clientsecret = BWebConfig.MicrosoftAuth_ClientSecret;
      string TenantID = BWebConfig.MicrosoftAuth_TenantID;
      string redirection_url = BGlobalNet.GetApplicationUrl(this);
      redirection_url = BGlobal.CreatePathFileWeb(redirection_url, ModConstantList.K_SYS_PAGE_AUTHMICROSOFT);
      string Googleurl = "";
      var socgoogle = new BMicrosoftSocialAuth(ClientID, clientsecret, TenantID, redirection_url);
      Googleurl = socgoogle.GetUrlAuthentication();
      this.BRedirect(Googleurl);
    }

    private void BtnLoginWithFacebook_Click(object sender, EventArgs e)
    {
      string ClientID = "178021793305344";
      string clientsecret = "31ad28a390a9926b0bd3a7d76f477958";
      string redirection_url = "http://localhost/BWebTemplate/BSports/BSystem/AuthFacebook";
      var SocFacebook = new BFacebookSocialAuth(ClientID, clientsecret, redirection_url);
      string url = "";
      url = SocFacebook.GetUrlAuthentication("email, public_profile");
      this.BRedirect(url);
    }


  } //END CLASS
} //END NAMESPACE