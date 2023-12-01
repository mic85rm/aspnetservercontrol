using System;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PosteWebTemplate1
{
  public partial class _default : BPageBase
  {

    protected override void BPage_Load(object sender, EventArgs e)
    {
      if (BWebConfig.InitDB) return;

      switch (BWebConfig.TipoApplicazione)
      {
        case BWebConfig.eTipoApplicazione.WPAppChild:
        case BWebConfig.eTipoApplicazione.WPInterna:
          if (BUtenti.LoadUserFromWebPers(this))
          {
            BRedirect(ModConstantList.K_PAGE_HOME);
            Session[ModConstantList.K_SE_SYSINITAPP] = true;
          }
          else
          {
            if (BWebConfig.WPAppChildDebug)
              this.BRedirect(ModConstantList.K_PAGE_PAGESTARTAPP);
            else
            {
              this.ShowMessagePage("Utente non abilitato al sistema");
            }
          }
          break;
        default:
          if (BWebConfig.AutenticazioneIniziale)
          {
            if (UtenteEntrato == null)
              BRedirect(ModConstantList.K_PAGE_LOGIN);
            else
            {
              if (UtenteEntrato.Developer)
              {
                BRedirect(ModConstantList.K_PAGE_HOME);
              }
              else
              {
                BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
              }
            }
          }
          break;
      }
      base.BPage_Load(sender, e);
    }


  } //END CLASS
} //END NAMESPACE