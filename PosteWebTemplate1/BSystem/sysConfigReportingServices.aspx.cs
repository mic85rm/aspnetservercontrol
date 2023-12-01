using BArts.BGlobal;
using BArts.BReports;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Reflection;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class sysConfigReportingServices : BPageBase
  {

    // DEFINIZIONE METODI OVERRIDES
    public override void Indietro_Click()
    {
      BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
      base.Indietro_Click();
    }

    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.DisabilitaInvio(false);
      //this.ShowBtnIndietro();
      this.CtlCommandBar.PageName = "Configurazione Reporting Services";
      this.CtlCommandBar.CtlBtnAnnulla.Visible = false;
      this.CtlCommandBar.CtlBtnElimina.Visible = false;
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;
    }
    protected override void BPage_Load(object sender, EventArgs e)
    {
      if (!base.IsPostBack)
      {
        this.BPropertyGrid1.BObject = new BWebConfig();
        this.BPropertyGrid1.EnableEditingReadOnly = true;
        this.BPropertyGrid1.HideBCaptionAttribute = false;
        this.BPropertyGrid1.CategoryFilter = "Reportistica";
        this.BPropertyGrid1.InitControl(Assembly.GetExecutingAssembly());
        this.mbcFormat.Items.Clear();
        this.mbcFormat.Items.Add(new ListItem(BReport.eExport.HTML4_0.ToString(), BReport.eExport.HTML4_0.ToString()));
        this.mbcFormat.Items.Add(new ListItem(BReport.eExport.PDF.ToString(), BReport.eExport.PDF.ToString()));
        this.mbcFormat.Items.Add(new ListItem(BReport.eExport.EXCEL.ToString(), BReport.eExport.EXCEL.ToString()));
        this.mbcFormat.Items.Add(new ListItem(BReport.eExport.IMAGE.ToString(), BReport.eExport.IMAGE.ToString()));
        InizializzaReport();
        BtnCheckConfigurazione_Click(null, null);
      }
    }
    protected override void BPage_AttachCommand()
    {
      this.AddAttachOpenReport(this.btnTestPDF.ClientID, "");
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      mbcFormat.SelectedIndexChanged += mbcFormat_SelectedIndexChanged;
      BtnCheckConfigurazione.Click += BtnCheckConfigurazione_Click;
      btnCreaFolder.Click += btnCreaFolder_Click;
      btnCreaCnn.Click += btnCreaCnn_Click;
      base.SetAttributes_AddEvents();
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    private void CtlCommandBar_Salva()
    {
      Configuration config;
      string PathFile = "";
      ExeConfigurationFileMap fileMap;
      string Key = "";
      object Obj;
      try
      {
        fileMap = new ExeConfigurationFileMap();
        PathFile = base.Server.MapPath("../") + "web.config";
        fileMap.ExeConfigFilename = PathFile;
        fileMap.LocalUserConfigFilename = PathFile;
        fileMap.RoamingUserConfigFilename = PathFile;
        config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        if (config != null)
        {
          Key = "SERVERREPORT_NAME";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("ServerReport_Nome");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_DOMAIN";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_USER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_PWD";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_FOLDER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_VERSION";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_SSL";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          config.Save();
        }

        return;
      }
      catch (Exception ex)
      {
        WriteLog("sysConfigReportingServices.BtnSalva_Click():", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return;
      }
      finally
      {
        config = null;
      }
    }
    private void mbcFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
      InizializzaReport();
    }
    protected void BtnCheckConfigurazione_Click(object sender, EventArgs e)
    {
      var Stato = BReportingService.eExistItem.NOT_EXIST;
      BReportingService BRS = null;
      try
      {
        BRS = new BReportingService((BModReports.eReportVersion)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SERVERREPORT_VERSION")),
                                      BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_NOME")));
        if (BRS != null)
        {
          BRS_SetProperty(ref BRS);
          Stato = BRS.ExitItem(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_FOLDER")));
          var switchExpr = Stato;
          switch (switchExpr)
          {
            case BReportingService.eExistItem.EXIST:
              {
                this.imgFolderRosso.Visible = false;
                this.imgFolderVerde.Visible = true;
                this.btnCreaFolder.Enabled = false;
                this.lblFolderInfo.Text = "Cartella Report esistente.";
                Stato = BRS.ExitItem("cnn", BRS.ReportFolder);
                switch (Stato)
                {
                  case BReportingService.eExistItem.EXIST:
                    {
                      this.imgCnnRosso.Visible = false;
                      this.imgCnnVerde.Visible = true;
                      this.btnCreaCnn.Text = "Aggiorna connessione dati";
                      this.lblCnn.Text = "Connessione dati esistente.";
                      break;
                    }

                  case BReportingService.eExistItem.NOT_EXIST:
                    {
                      this.imgCnnRosso.Visible = true;
                      this.imgCnnVerde.Visible = false;
                      this.btnCreaCnn.Text = "Crea connessione dati";
                      this.lblCnn.Text = "Connessione dati non esistente.";
                      break;
                    }
                }

                break;
              }

            case BReportingService.eExistItem.NOT_EXIST:
              {
                this.imgFolderRosso.Visible = true;
                this.imgFolderVerde.Visible = false;
                this.btnCreaFolder.Enabled = true;
                this.lblFolderInfo.Text = "Cartella Report non esistente.";
                this.imgCnnRosso.Visible = true;
                this.imgCnnVerde.Visible = false;
                this.btnCreaCnn.Text = "Crea connessione dati";
                this.lblCnn.Text = "Connessione dati non esistente.";
                break;
              }
          }
        }

        this.txtLog.Text += BRS.GetTextLog();
      }
      catch (Exception ex)
      {
        this.txtLog.Text += ex.Message + Environment.NewLine;
      }
    }
    protected void btnCreaFolder_Click(object sender, EventArgs e)
    {
      BReportingService BRS = new BReportingService((BModReports.eReportVersion)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SERVERREPORT_VERSION")),
                                    BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_NOME")));
      if (BRS != null)
      {
        BRS_SetProperty(ref BRS);
        BRS.CreateReportFolder();
        this.txtLog.Text += BRS.GetTextLog();
        BtnCheckConfigurazione_Click(sender, e);
      }
    }
    protected void btnCreaCnn_Click(object sender, EventArgs e)
    {
      BReportingService BRS = new BReportingService((BModReports.eReportVersion)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SERVERREPORT_VERSION")),
                                    BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_NOME")));
      if (BRS != null)
      {
        BRS_SetProperty(ref BRS);
        BRS.CreateDataSource();
        this.txtLog.Text += BRS.GetTextLog();
        BtnCheckConfigurazione_Click(sender, e);
      }
    }
    private void BRS_SetProperty(ref BReportingService brs)
    {
      brs.Domain = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_DOMAIN"));
      brs.Username = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_USER"));
      brs.Password = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_PWD"));
      brs.ReportFolder = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SERVERREPORT_FOLDER"));
      brs.SSL = BConvert.ToBool(BPropertyGrid1.GetPropertyValue("SERVERREPORT_SSL"));
      brs.DBReport_DB = BWebConfig.DBApp_DB;
      brs.DBReport_Server = BWebConfig.DBApp_Server;
      brs.DBReport_Username = BWebConfig.DBApp_User;
      brs.DBReport_Password = BWebConfig.DBApp_PWD;
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void InizializzaReport()
    {
      var rep = new BReport("Test");
      rep.Format = (BReport.eExport)(byte)mbcFormat.SelectedIndex;
      ShowReport(rep, "BSystem/sysConfigReportingServices.aspx");
    }

  } //END CLASS
} //END NAMESPACE