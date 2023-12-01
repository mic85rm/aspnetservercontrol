using Microsoft.VisualBasic;
using System;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public partial class BCtlCalendario : UserControl
  {
    public BCtlCalendario()
    {
      this.Load += Page_Load;
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      string format = "dddd d MMMM yyyy";
      this.lnkDate.Text = DateAndTime.Now.ToString(format).ToUpper();
      this.lnkDate.OnClientClick = "return BCtlCalendario_ShowPanel('" + this.pnlTendinaCalendario.ClientID + "');";
    }


  }
}