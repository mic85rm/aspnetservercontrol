using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PosteWebTemplate1
{
  public partial class Home : BPageBase
  {
    public Home()
    {
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected override void BPage_Load(object sender, EventArgs e)
    {
      this.lblTitoloApplicazione.Text = BWebConfig.TitoloWebSite;
      this.lblDescrizione.Text = BWebConfig.DescrizioneWebSite;
      this.lblVersione.Text = "Ver. " + BWebConfig.VersioneWebSite;
    }
  } //END CLASS
}//END NAMESPACE