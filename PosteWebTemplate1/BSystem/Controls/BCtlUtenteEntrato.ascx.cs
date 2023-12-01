using BArts;
using BArts.BInterface;
using BTemplateBaseLibrary;
using System;
using System.Linq;

namespace PosteWebTemplate1
{
  public partial class BCtlUtenteEntrato : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event ChangeDisplayNameEventHandler ChangeDisplayName;
    public delegate void ChangeDisplayNameEventHandler(string IDSysUtente);

    public event LogOutEventHandler LogOut;
    public delegate void LogOutEventHandler(IBUtenteEntrato Utente);

    public event ProfiloPersonaClickEventHandler ProfiloPersonaClick;
    public delegate void ProfiloPersonaClickEventHandler(BsysPersone ut);

    // DEFINIZIONE PROPRIETA'
    #region public string DisplayName
    private string K_VS_DISPLAYNAME = ".DisplayName";
    public string DisplayName
    {
      get
      {
        return this.ViewState[base.ID + K_VS_DISPLAYNAME].ToString();
      }
      set
      {
        this.ViewState[base.ID + K_VS_DISPLAYNAME] = value;
      }
    }
    #endregion
    #region public bool InfoUtente
    private string K_VS_INFOUTENTE = "ViewStateInfoUtente";
    public bool InfoUtente
    {
      get
      {
        return (bool)(base.ViewState[K_VS_INFOUTENTE]);
      }
      set
      {
        base.ViewState[K_VS_INFOUTENTE] = value;
      }
    }
    #endregion

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      this.Load += Page_Load;
      BtnLogOut.Click += BtnLogOut_Click;
      linkProfiloPersona.Click += linkProfiloPersona_Click;
      base.SetAttributes_AddEvents();
    }
    public BIPosteBaseLibraryCS.BPersonale GetPersonale(int idpersonale)
    {
      BIPosteBaseLibraryCS.BPersonale obj = new BIPosteBaseLibraryCS.BPersonale(idpersonale, this.DB);
      if (obj.IsNothing)
      {
        return null;
      }

      return obj;
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.UtenteEntrato != null && !this.UtenteEntrato.IsNothing)
      {
        this.BtnLogOut.Visible = true;
        BUtenti ut = (BUtenti)this.UtenteEntrato;
        BIPosteBaseLibraryCS.BPersonale DettaglioPersona = GetPersonale(ut.IDPersona);
        if (DettaglioPersona != null)
        {
          DisplayName = DettaglioPersona.Nome + " " + DettaglioPersona.Cognome;
        }
        else
        {
          DisplayName = ut.ID;
        }

        this.InitPanelDetail(DettaglioPersona);
        ChangeDisplayName?.Invoke(DisplayName);

        //this.lnkUtente.Text = "Benvenuto, " + DisplayName;
        //if (DettaglioPersona != null)
        //{
        //	if (DettaglioPersona.Sesso.Trim() == "F")
        //	{
        //		this.lnkUtente.Text = "Benvenuta, " + DisplayName;
        //	}
        //}

        this.Visible = true;
      }
      else
      {
        this.lnkUtente.Text = "";
        this.Visible = false;
      }
    }

    private void BtnLogOut_Click(object sender, EventArgs e)
    {
      if (this.UtenteEntrato != null && !this.UtenteEntrato.IsNothing)
      {
        this.UtenteEntrato.WriteExit();
        if (this.UtenteEntrato.UtentePadre == null)
        {
          LogOut?.Invoke(base.UtenteEntrato);
          this.UtenteEntrato = null;
        }
        else
        {
          string UtentePadre = UtenteEntrato.UtentePadre.Dominio + "@" + UtenteEntrato.UtentePadre.Username;
          string Utente = ((BsysUtenti)UtenteEntrato).ID;
          this.WriteLog("MenuFunzioni.btnLogOut_Click", "Disconnessione. UtentePadre: " + UtentePadre +
                                                        " - UtenteImpersonificato: " + Utente,
                                                        BEnumerations.eSeverity.INFORMATION);


          LogOut?.Invoke(base.UtenteEntrato);
          this.UtenteEntrato = base.UtenteEntrato.UtentePadre;
        }

        if (this.UtenteEntrato == null)
        {
          this.Session.Clear();
        }
      }
      else
      {
        return;
      }
      switch (BWebConfig.TipoApplicazione)
      {
        case BWebConfig.eTipoApplicazione.PosteRUO:
          if (BWebConfig.AutoLoginWindows & !string.IsNullOrEmpty(BWebConfig.AutoLogin_URLOnLogOut))
          {
            this.BRedirect(BWebConfig.AutoLogin_URLOnLogOut);
          }
          else
          {
            this.BRedirect(ModConstantList.K_PAGE_HOME);
          }
          break;
        case BWebConfig.eTipoApplicazione.WPAppChild:
        case BWebConfig.eTipoApplicazione.WPInterna:
          if (BWebConfig.WPAppChildDebug)
            this.BRedirect(ModConstantList.K_PAGE_PAGESTARTAPP);
          else
            this.BRedirect(BWebConfig.AutoLogin_URLOnLogOut);
          break;
      }
    }
    protected void linkProfiloPersona_Click(object sender, EventArgs e)
    {
      BUtenti ut = (BUtenti)this.UtenteEntrato;
      if (ut.Persona != null && !ut.Persona.IsNothing)
      {
        ProfiloPersonaClick?.Invoke(ut.Persona);
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool InitPanelDetail(BIPosteBaseLibraryCS.BPersonale p)
    {
      if (p == null || p.IsNothing)
      {
        this.lnkUtente.OnClientClick = "return false;";
        this.pnlTendinaUtente.Visible = false;
        return false;
      }
      this.lblNominativo.Text = p.Nome + " " + p.Cognome + " (" + p.NTAccount + ")";
      this.lblEmail.Text = p.Email;
      //if (p.Foto != null && p.Foto.Count() > 0)
      //{
      //	this.imgFotoProfilo.ImageUrl = BArts.BGlobal.BGlobal.GetUrlImage(p.Foto);
      //}
      //else
      //{
      //	this.imgFotoProfilo.ImageUrl = "";
      //	this.imgFotoProfilo.Visible = false;
      //}

      //this.lnkUtente.OnClientClick = "return BCtlUtenteEntrato_ShowPanel('" + this.pnlTendinaUtente.ClientID + "','" + this.linkProfiloPersona.ClientID + "');";
      this.lnkUtente.OnClientClick = "return BCtlUtenteEntrato_ShowPanel('" + this.pnlTendinaUtente.ClientID + "');";
      lnkUtente.Text = (p.Nome.Substring(0, 1) + p.Cognome.Substring(0, 1)).ToUpper();
      return true;
    }
  } //END CLASS
} //END NAMESPACE

