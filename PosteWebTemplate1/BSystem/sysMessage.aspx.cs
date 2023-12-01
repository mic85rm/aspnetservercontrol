using BArts.BWeb;
using System;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public partial class sysMessage : BPageBase
  {

    //DEFINIZIONE FUNZIONI PRIVATE
    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.AutoRedirect = false;
      this.CheckAuth = false;
      base.BPage_Init(sender, e);
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session[ModConstantList.K_SE_SYSMSG] == null || string.IsNullOrEmpty(Session[ModConstantList.K_SE_SYSMSG].ToString()))
      {
        BRedirect(ModConstantList.K_PAGE_DEFAULT);
        return;
      }

      this.lblTitolo.Text = "Informazione di sistema";
      this.lblSottotitolo.Text = "";
      this.lblMessage.Text = base.Session[ModConstantList.K_SE_SYSMSG].ToString();
    }

  } //END CLASS
} //END NAMESPACE