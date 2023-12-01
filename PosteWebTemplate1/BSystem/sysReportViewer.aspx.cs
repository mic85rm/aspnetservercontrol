using BArts;
using BArts.BReports;
using BTemplateBaseLibrary;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PosteWebTemplate1
{
  public partial class sysReportViewer : BPopupPageBase
  {

    // DEFINIZIONE PROPRIETA'
    #region public BReport Report
    public const string K_SE_REPORT = "sysReportViewer.Report";
    public BReport Report
    {
      get
      {
        return (BReport)base.Session[K_SE_REPORT];
      }
      set
      {
        base.Session[K_SE_REPORT] = value;
      }
    }
    #endregion
    #region public string UrlChiamante
    public const string K_SE_URLCHIAMANTE = "sysReportViewer.UrlChiamante";
    public string UrlChiamante
    {
      get
      {
        return base.Session[K_SE_URLCHIAMANTE].ToString();
      }
      set
      {
        base.Session[K_SE_URLCHIAMANTE] = value;
      }
    }
    #endregion

    // DEFINIZIONE METODI OVERRIDES
    protected override void OnLoad(EventArgs e)
    {
      try
      {
        if (!this.IsPostBack)
        {
          var argCtlLiteral = this.LtrReport;
          if (!this.ReportingServices.Render(Report, this.Page, ref argCtlLiteral))
          {
            base.Response.Write(this.ReportingServices.GetTextLog());
            base.Response.End();
          }
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysReportViewer.Page_Load", "", ex, BEnumerations.eSeverity.ERROR);
      }
      finally
      {
        if (Report != null)
        {
          if (Report.DataSource != null)
          {
            Report.DataSource.Dispose();
            Report = null;
          }

          base.Session.Remove(K_SE_REPORT);
        }
      }
      base.OnLoad(e);
    }
    public override void ChangeUrlAuthentication(ref string url)
    {
      url = UrlChiamante;
      base.ChangeUrlAuthentication(ref url);
    }


  } //END CLASS
} //END NAMESPACE