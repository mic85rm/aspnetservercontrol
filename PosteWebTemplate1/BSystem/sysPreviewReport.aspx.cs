using BArts.BData;
using BArts.BGlobal;
using BArts.BReports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;

namespace PosteWebTemplate1
{
  public partial class sysPreviewReport : BPopupPageBase
  {

    // DEFINIZIONE PROPRIETA'
    #region public BReport Report
    public const string K_SE_REPORT = "sysPreviewReport.Report";
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
    public const string K_SE_URLCHIAMANTE = "sysPreviewReport.UrlChiamante";
    public string UrlChiamante
    {
      get
      {
        return BConvert.ToString(base.Session[K_SE_URLCHIAMANTE]);
      }
      set
      {
        base.Session[K_SE_URLCHIAMANTE] = value;
      }
    }
    #endregion

    // DEFINIZIONE METODI OVERRIDES
    public override void ChangeUrlAuthentication(ref string url)
    {
      url = UrlChiamante;
      base.ChangeUrlAuthentication(ref url);
    }
    protected override void OnLoad(EventArgs e)
    {
      if (!base.IsPostBack)
      {
        if (Report != null)
        {
          LoadAttributes();

          // LOAD REPORT
          this.ReportViewer1.LocalReport.ReportPath = BWebConfig.ServerReport_FOLDER + @"\" + Report.NomeReport;


          // LOAD PARAMETER
          var lP = new List<ReportParameter>();
          foreach (BParameter p in Report.Parameters)
          {
            string n = p.Name + "";
            string v = p.Value + "";
            var RP = new ReportParameter(n, v);
            lP.Add(RP);
          }

          this.ReportViewer1.LocalReport.SetParameters(lP);


          // LOAD DATASOURCE
          this.ReportViewer1.LocalReport.DataSources.Clear();
          if (Report.DataSource != null && Report.DataSource.Tables.Count > 0)
          {
            foreach (DataTable el in Report.DataSource.Tables)
              this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(el.TableName, el));
          }
        }
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void LoadAttributes()
    {
      this.ReportViewer1.ShowCredentialPrompts = false;
      this.ReportViewer1.ShowParameterPrompts = false;
      this.ReportViewer1.ShowPromptAreaButton = false;
      this.ReportViewer1.ShowDocumentMapButton = false;
      this.ReportViewer1.ShowExportControls = false;
      this.ReportViewer1.ZoomPercent = 100;
      this.ReportViewer1.ZoomMode = ZoomMode.Percent;
    }

  } //END CLASS
} //END NAMESPACE