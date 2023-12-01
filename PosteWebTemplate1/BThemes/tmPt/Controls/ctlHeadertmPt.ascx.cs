using BTemplateBaseLibrary;
using System;

namespace PosteWebTemplate1
{
  public partial class ctlHeadertmPt : BWebControlsBase
  {
    public ctlHeadertmPt()
    {
      this.Load += Page_Load;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      BCtlUtenteEntrato.ProfiloPersonaClick += BCtlUtenteEntrato_ProfiloPersonaClick;

      // If Not IsPostBack Then
      // Dim c As BConfiguration = CType(Me.Config, BConfiguration)
      // If Not c Is Nothing AndAlso Not c.IsNothing Then
      // If c.Logo Is Nothing OrElse c.Logo.Length = 0 Then
      // Imglogo.ImageByte = Nothing
      // Imglogo.ImageUrl = ""
      // Imglogo.Visible = False
      // Else
      // Imglogo.ImageByte = c.Logo
      // End If
      // Else
      // Imglogo.ImageByte = Nothing
      // Imglogo.ImageUrl = ""
      // Imglogo.Visible = False
      // End If
      // End If
    }

    private void BCtlUtenteEntrato_ProfiloPersonaClick(BsysPersone ut)
    {
      string url = "~/BSystem/sysPersone/{0}";
      this.BRedirect(string.Format(url, ut.ID));
    }
  }
}