using System;

namespace PosteWebTemplate1
{
  public partial class sysSelectProfilo : BPageBase
  {

    //DEFINIZIONE METODI OVERRIDES 
    protected override void SetAttributes_AddEvents()
    {
      BtnSelectProfilo.Click += BtnSelectProfilo_Click;
      base.SetAttributes_AddEvents();
    }

    protected override void OnInit(EventArgs e)
    {
      this.CheckAuth = false;
      base.OnInit(e);
    }
    protected override void OnLoad(EventArgs e)
    {
      BMaster.HideMenu();
      if (!BWebConfig.UseSideBar || !BMaster.EnabledSideBar)
      {
        if (this.BCtlSidebarInternal.InitControl())
        {
          this.PnlSelectProfilo.Visible = true;
        }
        else
        {
          base.Session.Clear();
          base.BRedirect(ModConstantList.K_PAGE_DEFAULT);
        }
      }
      else
      {
        this.PnlSelectProfilo.Visible = false;
      }
      base.OnLoad(e);
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void BtnSelectProfilo_Click(object sender, EventArgs e)
    {
      BSysUtenteEntrato.IDSysProfilo = this.BCtlSidebarInternal.IDProfiloSelected;
      BSysUtenteEntrato.IDSysSistema = this.BCtlSidebarInternal.IDSistemaSelected;
      BSysUtenteEntrato.Accesso.IDSysSistema = this.BCtlSidebarInternal.IDSistemaSelected;
      BSysUtenteEntrato.Accesso.IDSysProfilo = this.BCtlSidebarInternal.IDProfiloSelected;
      if (!BSysUtenteEntrato.Accesso.Update())
      {
        this.WriteLog("sysSelectProfilo", "Accesso al sistema " + this.BCtlSidebarInternal.IDSistemaSelected + " con profilo " + this.BCtlSidebarInternal.IDProfiloSelected + " non salvato per l'utente " + this.UtenteEntrato.Descrizione, BArts.BEnumerations.eSeverity.ERROR);
      }
      BSysUtenteEntrato.WriteOperation("Accesso al sistema " + this.BCtlSidebarInternal.IDSistemaSelected + " con profilo " + this.BCtlSidebarInternal.IDProfiloSelected);
      this.BRedirect(ModConstantList.K_PAGE_HOME);
    }

  } //END CLASS
} //END NAMESPACE