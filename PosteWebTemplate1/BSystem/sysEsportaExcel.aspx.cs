// PER L'UTILIZZO DI QUESTA PAGINA E' NECESSARIO PASSARE TRE PARAMETRI IN SESSIONE
// 1: Session(K_EXPORTEXCEL_FORMATO): Tipo di dato eFormatoExport
// 2: Session(K_EXPORTEXCEL_DTV): Tipo di dato Dataview
// 3: Session(K_EXPORTEXCEL_NOMEFILE); Nome File senza estenzione
using BArts;
using BArts.BGlobal;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysEsportaExcel : BPageBaseNoMaster
  {
    //DEFINIZIONE COSTRUTTORI
    public sysEsportaExcel()
    {
      base.Load += Page_Load;
    }

    //DEFINIZIOBNE EVENTI INTERCETTATI
    private void Page_Load(object sender, EventArgs e)
    {
      ModEnumeration.eFormatoExport formato = ModEnumeration.eFormatoExport.XLS;
      try
      {
        byte Obj = BConvert.ToByte(base.Session[ModConstantList.K_EXPORTEXCEL_FORMATO]);
        formato = (ModEnumeration.eFormatoExport)Obj;
        switch (formato)
        {
          case ModEnumeration.eFormatoExport.CSV:
            {
              ExportCSV();
              break;
            }

          case ModEnumeration.eFormatoExport.XLS:
            {
              ExportXLS();
              break;
            }
        }
      }
      catch (Exception ex)
      {
        string IDSysUtente = "";
        string IDAccesso = "";
        if (base.UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso.ToString();
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ModLog.ScriviLog(base.DB, (BConfiguration)base.Config, IDSysUtente, ex, "sysDownload.Page_Load()", "", BEnumerations.eSeverity.ERROR, int.Parse(IDAccesso));
      }
      finally
      {
        DataView dt = (DataView)base.Session[ModConstantList.K_EXPORTEXCEL_DTV];
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
          base.Session.Remove(ModConstantList.K_EXPORTEXCEL_DTV);
        }
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void ExportCSV()
    {
      var dt = ((DataView)Session[ModConstantList.K_EXPORTEXCEL_DTV]).ToTable();
      int i = 0;
      var sb = new StringBuilder();
      foreach (DataColumn col in dt.Columns)
        sb.Append(col.ColumnName + ";");
      if (sb.Length > 0)
      {
        sb.Remove(sb.Length - 1, 1);
        sb.Append(Environment.NewLine);
        foreach (DataRow row in dt.Rows)
        {
          var loopTo = dt.Columns.Count - 1;
          for (i = 0; i <= loopTo; i++)
            sb.Append(row[i].ToString() + ";");
          sb.Append(Environment.NewLine);
        }
      }

      Response.Clear();
      Response.ContentType = "application/CSV";
      Response.AddHeader("content-disposition", (string)("attachment; filename=\"" + base.Session[ModConstantList.K_EXPORTEXCEL_NOMEFILE] + ".csv \""));
      Response.Write(sb.ToString());
      Response.Flush();
      Response.End();
    }
    private void ExportXLS()
    {
      var GridToExport = new DataGrid();
      var tw = new System.IO.StringWriter();
      var hw = new HtmlTextWriter(tw);
      DataView dtToExport;
      Response.ContentType = "application/vnd.ms-excel";
      Response.AddHeader("Content-Disposition", "attachment;filename=" + base.Session[ModConstantList.K_EXPORTEXCEL_NOMEFILE].ToString() + ".xls");
      Response.Charset = "ISO-8859-1";
      Response.ContentEncoding = Encoding.Default;
      EnableViewState = false;
      dtToExport = (DataView)base.Session[ModConstantList.K_EXPORTEXCEL_DTV];
      GridToExport.DataSource = dtToExport;
      GridToExport.DataBind();
      GridToExport.RenderControl(hw);
      Response.Write(tw.ToString());
      Response.Flush();
      Response.End();
    }


  } //END CLASS
} //END NAMESPACE