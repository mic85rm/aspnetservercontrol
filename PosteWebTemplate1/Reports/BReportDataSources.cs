using BArts.BData;
using BArts.BReports;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosteWebTemplate1.Reports
{
  public static class BReportDataSources
  {

    public static BReport GetRptElencoComuni(BConnection DB)
    {
      BReport rpt = null;
      BDataSet ds = null;
      BDataTable dt = null;
      try
      {
        rpt = new BReport("rptElencoComuni.rdlc", "ElencoComuni");
        rpt.IsRDLC = true;
        rpt.Format = BReport.eExport.PDF;
        dt = (BDataTable)BsysComuni.GetElenco(DB);
        if (dt != null)
        {
          dt.TableName = "DSPrint"; // SET SAME NAME OF TABLE INTO DSPRINT.XSD

          ds = new BDataSet();
          ds.Tables.Add(dt);

          rpt.DataSource = ds;
        }
        else
        {
          rpt.DataSource = null;
        }
        return rpt;

      }
      catch (Exception Ex)
      {
        throw Ex;
      }
      finally
      {
        if (ds != null)
        {
          ds.Dispose();
          ds = null;
        }
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }

  }
}