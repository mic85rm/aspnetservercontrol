using BArts;
using BArts.BGlobal;
using BArts.BWeb;
using BArts.BWeb.BControls;
using System;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace PosteWebTemplate1
{
  public partial class Web : BBaseMasterPage
  {
    //DEFINIZIONE COSTRUTTORI
    public Web()
    {
      this.Load += Web_Load;
      this.Init += Web_Init;
    }

    // DEFINIZIONE PROPRIETA' OVERRIDES
    public override string RealClientID
    {
      get
      {
        return base.ID;
      }
    }
    protected override bool VS_Debug
    {
      get
      {
        string sVSDebug = BWebConfig.VS_DEBUG.ToString();
        if ((sVSDebug.ToUpper() ?? "") == "TRUE")
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    // DEFINIZIONE PROPRIETA'
    //public string BodyEventsOnResize
    //{
    //  get
    //  {
    //    return this.hBodyEventsOnResize.Value;
    //  }
    //  set
    //  {
    //    this.hBodyEventsOnResize.Value = value;
    //  }
    //}

    #region public bool AuthCookie
    private string K_CK_AUTHCOOKIE = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_AUTHCOOKIE";
    public bool AuthCookie
    {
      get
      {
        if (this.Request.Cookies[K_CK_AUTHCOOKIE] == null)
          return false;
        return BGlobal.PrendiBool(this.Request.Cookies[K_CK_AUTHCOOKIE].Value);
      }
      set
      {
        if (this.Request.Browser.Cookies)
        {
          if (this.Request.Cookies[K_CK_AUTHCOOKIE] == null)
          {
            var c = new HttpCookie(K_CK_AUTHCOOKIE);
            c.Expires = DateTime.MaxValue;
            c.Value = BGlobal.CBoolOracle(value).ToString();
            if (this.Response.Cookies[K_CK_AUTHCOOKIE] == null)
            {
              this.Response.Cookies.Add(c);
            }
            else
            {
              this.Response.Cookies.Set(c);
            }
          }
        }
      }
    }
    #endregion
    #region public bool EnabledSideBar
    private const string K_SE_ENABLEDSIDEBAR = "BMasterPage.EnabledSideBar";
    public bool EnabledSideBar
    {
      get
      {
        if (base.Session[K_SE_ENABLEDSIDEBAR] == null)
        {
          base.Session[K_SE_ENABLEDSIDEBAR] = BWebConfig.UseSideBar;
          return BWebConfig.UseSideBar;
        }
        else
        {
          return (bool)(base.Session[K_SE_ENABLEDSIDEBAR]);
        }
      }
      set
      {
        base.Session[K_SE_ENABLEDSIDEBAR] = value;
        SetAttributes();
      }
    }
    #endregion
    #region public bool IsVisibleSideBar
    private const string K_SE_ISVISIBLESIDEBAR = "BMasterPage.IsVisibleSideBar";
    public bool IsVisibleSideBar
    {
      get
      {
        if (base.Session[K_SE_ISVISIBLESIDEBAR] == null)
        {
          base.Session[K_SE_ENABLEDSIDEBAR] = BWebConfig.DefaultSidebarOpen;
          return BWebConfig.DefaultSidebarOpen;
        }
        else
        {
          return (bool)(base.Session[K_SE_ISVISIBLESIDEBAR]);
        }
      }
      set
      {
        base.Session[K_SE_ISVISIBLESIDEBAR] = value;
        SetAttributes();
      }
    }
    #endregion
    #region public string StatePnlSidebar
    private string K_CK_StatePnlSidebar = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_StatePnlSidebar";
    public string StatePnlSidebar
    {
      get
      {
        if (this.Request.Cookies[K_CK_StatePnlSidebar] == null)
        {
          if (base.Session[K_CK_StatePnlSidebar] == null)
          {
            return "";
          }
          else
          {
            return base.Session[K_CK_StatePnlSidebar].ToString();
          }
        }

        return this.Request.Cookies[K_CK_StatePnlSidebar].Value;
      }
      set
      {
        if (this.Request.Browser.Cookies)
        {
          if (this.Request.Cookies[K_CK_StatePnlSidebar] == null)
          {
            var c = new HttpCookie(K_CK_StatePnlSidebar);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Add(c);
          }
          else
          {
            var c = new HttpCookie(K_CK_StatePnlSidebar);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Set(c);
          }
        }
        else
        {
          base.Session[K_CK_StatePnlSidebar] = value;
        }
      }
    }
    #endregion
    #region public string StatePnlSidebarHide
    private string K_CK_StatePnlSidebarHide = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_StatePnlSidebarHide";
    public string StatePnlSidebarHide
    {
      get
      {
        if (this.Request.Cookies[K_CK_StatePnlSidebarHide] == null)
        {
          if (base.Session[K_CK_StatePnlSidebarHide] == null)
          {
            return "";
          }
          else
          {
            return base.Session[K_CK_StatePnlSidebarHide].ToString();
          }
        }
        return this.Request.Cookies[K_CK_StatePnlSidebarHide].Value;
      }
      set
      {
        if (this.Request.Browser.Cookies)
        {
          if (this.Request.Cookies[K_CK_StatePnlSidebarHide] == null)
          {
            var c = new HttpCookie(K_CK_StatePnlSidebarHide);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Add(c);
          }
          else
          {
            var c = new HttpCookie(K_CK_StatePnlSidebarHide);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Set(c);
          }
        }
        else
        {
          base.Session[K_CK_StatePnlSidebarHide] = value;
        }
      }
    }
    #endregion
    #region public string StatePnlMain
    private string K_CK_StatePnlMain = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_StatePnlMain";
    public string StatePnlMain
    {
      get
      {
        if (this.Request.Cookies[K_CK_StatePnlMain] == null)
        {
          if (base.Session[K_CK_StatePnlMain] == null)
          {
            return "";
          }
          else
          {
            return base.Session[K_CK_StatePnlMain].ToString();
          }
        }
        return this.Request.Cookies[K_CK_StatePnlMain].Value;
      }
      set
      {
        if (this.Request.Browser.Cookies)
        {
          if (this.Request.Cookies[K_CK_StatePnlMain] == null)
          {
            var c = new HttpCookie(K_CK_StatePnlMain);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Add(c);
          }
          else
          {
            var c = new HttpCookie(K_CK_StatePnlMain);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Set(c);
          }
        }
        else
        {
          base.Session[K_CK_StatePnlMain] = value;
        }
      }
    }
    #endregion
    #region public string StatePnlMainHeaderContainer
    private string K_CK_StatePnlMainHeaderContainer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_StatePnlMainHeaderContainer";
    public string StatePnlMainHeaderContainer
    {
      get
      {
        if (this.Request.Cookies[K_CK_StatePnlMainHeaderContainer] == null)
        {
          if (base.Session[K_CK_StatePnlMainHeaderContainer] == null)
          {
            return "";
          }
          else
          {
            return base.Session[K_CK_StatePnlMainHeaderContainer].ToString();
          }
        }
        return this.Request.Cookies[K_CK_StatePnlMainHeaderContainer].Value;
      }
      set
      {
        if (this.Request.Browser.Cookies)
        {
          if (this.Request.Cookies[K_CK_StatePnlMainHeaderContainer] == null)
          {
            var c = new HttpCookie(K_CK_StatePnlMainHeaderContainer);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Add(c);
          }
          else
          {
            var c = new HttpCookie(K_CK_StatePnlMainHeaderContainer);
            c.Expires = DateTime.MaxValue;
            c.Value = value;
            this.Response.Cookies.Set(c);
          }
        }
        else
        {
          base.Session[K_CK_StatePnlMainHeaderContainer] = value;
        }
      }
    }
    #endregion 

    // DEFINIZIONE PROPRIETA' READ ONLY
    public BCtlMenu Menu
    {
      get
      {
        return this.MenuFunzioni;
      }
    }
    public BCtlSidebar SideBarSystem
    {
      get
      {
        return this.BCtlSidebarSystem;
      }
    }
    public ScriptManager ScriptManager
    {
      get
      {
        return this.SM;
      }
    }
    public BScriptManager BCommandsManager
    {
      get
      {
        return this.BSM;
      }
    }
    public BMsgBox MsgBoxManager
    {
      get
      {
        return this.MsgBoxMaster;
      }
    }
    public BToast ToastManager
    {
      get
      {
        return this.BToastManager;
      }
    }
    public UpdatePanel UpdPanel
    {
      get
      {
        return this.UpdContainer;
      }
      set
      {
        this.UpdContainer = value;
      }
    }

    // DEFINIZIONE METODI OVERRIDES
    public override string BTheme()
    {
      return BWebConfig.BTheme;
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void SetAttributes()
    {
      string s = "return BSideBarBtnCollapse_Click('{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}','{7}')";
      // SIDE BAR
      if (string.IsNullOrEmpty(this.HStatePnlSidebar.Text))
        this.HStatePnlSidebar.Text = this.BSidebar.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlSidebarHide.Text))
        this.HStatePnlSidebarHide.Text = this.BSideBarHide.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlMain.Text))
        this.HStatePnlMain.Text = this.BMain.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlMainHeaderContainer.Text))
        this.HStatePnlMainHeaderContainer.Text = this.BMainHeaderContainer.CssClass;
      if (BWebConfig.UseSideBar & EnabledSideBar)
      {
        s = string.Format(s, this.BSidebar.ClientID, this.BSideBarHide.ClientID, this.BMain.ClientID, this.BMainHeaderContainer.ClientID, this.HStatePnlSidebar.ClientID, this.HStatePnlSidebarHide.ClientID, this.HStatePnlMain.ClientID, this.HStatePnlMainHeaderContainer.ClientID);
        this.BtnCollapse.Attributes["onclick"] = s;
        this.BSidebar.CssClass = this.HStatePnlSidebar.Text;
        this.BSideBarHide.CssClass = this.HStatePnlSidebarHide.Text;
        this.BMain.CssClass = this.HStatePnlMain.Text;
        this.BMainHeaderContainer.CssClass = this.HStatePnlMainHeaderContainer.Text;
        this.BMainHeaderPnlBtn.Visible = true;
      }
      else
      {
        this.BSidebar.CssClass = this.HStatePnlSidebar.Text + " active";
        this.BSideBarHide.CssClass = this.HStatePnlSidebarHide.Text + " active";
        this.BMain.CssClass = this.HStatePnlMain.Text + " active";
        this.BMainHeaderContainer.CssClass = this.HStatePnlMainHeaderContainer.Text + " active";
        this.BMainHeaderPnlBtn.Visible = false;
      }
    }
    private void SetAttributes_AddEvents()
    {
      BtnAccettaCookie.Click += BtnAccettaCookie_Click;
      BCtlSidebarSystem.Profilo_Changed += BCtlSidebarSystem_Profilo_Changed;
      BCtlSidebarSystem.Sistema_Changed += BCtlSidebarSystem_Sistema_Changed;
    }

    // DEFINIZIONE METODI
    public void ShowSideBar()
    {
      this.HStatePnlSidebar.Text = this.HStatePnlSidebar.Text.Replace(" active", "");
      this.HStatePnlSidebarHide.Text = this.HStatePnlSidebarHide.Text.Replace(" active", "");
      this.HStatePnlMain.Text = this.HStatePnlMain.Text.Replace(" active", "");
      this.HStatePnlMainHeaderContainer.Text = this.HStatePnlMainHeaderContainer.Text.Replace(" active", "");
      SetAttributes();
    }
    public void HideSideBar()
    {
      // SIDE BAR
      if (string.IsNullOrEmpty(this.HStatePnlSidebar.Text))
        this.HStatePnlSidebar.Text = this.BSidebar.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlSidebarHide.Text))
        this.HStatePnlSidebarHide.Text = this.BSideBarHide.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlMain.Text))
        this.HStatePnlMain.Text = this.BMain.CssClass;
      if (string.IsNullOrEmpty(this.HStatePnlMainHeaderContainer.Text))
        this.HStatePnlMainHeaderContainer.Text = this.BMainHeaderContainer.CssClass;
      if (this.HStatePnlSidebar.Text.IndexOf(" active") == -1)
        this.HStatePnlSidebar.Text = this.HStatePnlSidebar.Text + " active";
      if (this.HStatePnlSidebarHide.Text.IndexOf(" active") == -1)
        this.HStatePnlSidebarHide.Text = this.HStatePnlSidebarHide.Text + " active";
      if (this.HStatePnlMain.Text.IndexOf(" active") == -1)
        this.HStatePnlMain.Text = this.HStatePnlMain.Text + " active";
      if (this.HStatePnlMainHeaderContainer.Text.IndexOf(" active") == -1)
        this.HStatePnlMainHeaderContainer.Text = this.HStatePnlMainHeaderContainer.Text + " active";
      SetAttributes();
    }

    public void HideProgressPnl()
    {
      this.UpdLoader.AssociatedUpdatePanelID = "UpdDisabled";
    }
    public void ShowProgressPanel()
    {
      this.UpdLoader.AssociatedUpdatePanelID = "UpdContainer";
    }

    public void HideMenu()
    {
      this.MenuFunzioni.Visible = false;
    }
    public void ShowMenu()
    {
      this.MenuFunzioni.Visible = true;
    }
    public bool LoadMenu()
    {
      return this.MenuFunzioni.InitControl();
    }

    public void RefreshUpdPnl()
    {
      this.UpdContainer.Update();
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void Web_Init(object sender, EventArgs e)
    {
      this.SetAttributes_AddEvents();

      this.DisabilitaInvio = true;
      this.BPage.BTheme = BWebConfig.BTheme;
      this.pnlContainerHeader.Controls.Add(base.LoadControl("~/BThemes/" + BWebConfig.BTheme + "/Controls/ctlHeader" + BWebConfig.BTheme + ".ascx"));
      this.pnlContainerFooter.Controls.Add(base.LoadControl("~/BThemes/" + BWebConfig.BTheme + "/Controls/ctlFooter" + BWebConfig.BTheme + ".ascx"));
      this.BMasterJS = "JS";
      this.AutoMinify = BWebConfig.AutoMinify;
    }
    private void Web_Load(object sender, EventArgs e)
    {
      BPageBase p = null;
      SetAttributes();
      if (!this.IsPostBack)
      {
        if (EnabledSideBar)
        {
          this.BCtlSidebarSystem.InitControl();
          if (IsVisibleSideBar)
          {
            this.ShowSideBar();
          }
          else
          {
            this.HideSideBar();

          }
        }
        if (BWebConfig.ShowUseCookie && !AuthCookie)
        {
          this.PnlAuthCookie.Visible = true;
          this.BtnAccettaCookie.Focus();
          return;
        }

        if (this.Page is BPageBase)
        {
          p = (BPageBase)this.Page;
          if (p.DB != null && !this.MenuFunzioni.InitControl())
          {
            p.WriteLog("web.BCtlSidebarSystem_Profilo_Changed", "Menu funzioni non inizializzato.", BEnumerations.eSeverity.ERROR);
          }
        }
      }
      else
      {
        if (this.HStatePnlSidebar.Text.IndexOf(" active") != -1)
        {
          this.IsVisibleSideBar = false;
        }
        else
        {
          this.IsVisibleSideBar = true;
        }
      }
    }


    private void BtnAccettaCookie_Click(object sender, EventArgs e)
    {
      AuthCookie = true;
      this.PnlAuthCookie.Visible = false;
    }

    private void BCtlSidebarSystem_Profilo_Changed(int IDSistema, int IDProfilo)
    {
      BPageBase p = (BPageBase)this.Page;
      p.BSysUtenteEntrato.IDSysProfilo = IDProfilo;
      p.BSysUtenteEntrato.IDSysSistema = IDSistema;
      p.BSysUtenteEntrato.Accesso.IDSysSistema = IDSistema;
      p.BSysUtenteEntrato.Accesso.IDSysProfilo = IDProfilo;
      if (!p.BSysUtenteEntrato.Accesso.Update())
      {
        p.WriteLog("web.BCtlSidebarSystem_Profilo_Changed", "Accesso al sistema " + IDSistema + " con profilo " + IDProfilo + " non salvato per l'utente " + p.UtenteEntrato.Descrizione, BEnumerations.eSeverity.ERROR);
      }
      p.BSysUtenteEntrato.WriteOperation("Accesso al sistema " + IDSistema + " con profilo " + IDProfilo);
      p.ShowToast("Hai cambiato sistema/profilo.", "Informazione");
      if (!this.MenuFunzioni.InitControl())
      {
        p.WriteLog("web.BCtlSidebarSystem_Profilo_Changed", "Menu funzioni non inizializzato.", BEnumerations.eSeverity.ERROR);
      }
      p.BRedirect(ModConstantList.K_PAGE_HOME);
    }
    private void BCtlSidebarSystem_Sistema_Changed(int IDSistema)
    {
      BPageBase p = (BPageBase)this.Page;
      if (this.BCtlSidebarSystem.CountProfili == 1 && this.BCtlSidebarSystem.IDProfiloSelected != -1)
      {
        this.BCtlSidebarSystem_Profilo_Changed(IDSistema, this.BCtlSidebarSystem.IDProfiloSelected);
      }
      else
      {
        p.BSysUtenteEntrato.IDSysSistema = IDSistema;
        p.BSysUtenteEntrato.Accesso.IDSysSistema = IDSistema;
        p.BSysUtenteEntrato.Accesso.Update();
      }

      p.BRedirect(ModConstantList.K_PAGE_HOME);
    }

  } //END CLASS
} //END NAMESPACE