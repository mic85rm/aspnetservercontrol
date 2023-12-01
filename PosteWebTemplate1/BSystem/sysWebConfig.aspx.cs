using BArts.BReflections;
using BTemplateBaseLibrary;
using System;
using System.Configuration;
using System.Reflection;

namespace PosteWebTemplate1
{
  public partial class sysWebConfig : BPageBase
  {
    public sysWebConfig()
    {

      // DEFINIZINE EVENTI INTERCETTATI



      this.Load += Page_Load;

      this.Init += sysWebConfig_Init;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      CtlCommandBar.Salva += CtlCommandBar_Salva;

      if (!base.IsPostBack)
      {
        this.BPropertyGrid1.BObject = new BWebConfig();
        // BPropertyGrid1.CategoryFilter = "Applicazione"
        this.BPropertyGrid1.EnableEditingReadOnly = true;
        this.BPropertyGrid1.HideBCaptionAttribute = false;
        this.BPropertyGrid1.InitControl(Assembly.GetExecutingAssembly());
      }
    }

    private void sysWebConfig_Init(object sender, EventArgs e)
    {
      // Me.ShowBtnIndietro()
      this.CtlCommandBar.PageName = "Web Config";
      this.CtlCommandBar.CtlBtnAnnulla.Visible = false;
      this.CtlCommandBar.CtlBtnElimina.Visible = false;
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;
    }


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
          Key = "VS_DEBUG";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "CNNSTR";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "WEBSITEUSEDB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "GestioneUtenti";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "AutenticazioneIniziale";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "AuthType";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null)
            {
              config.AppSettings.Settings[Key].Value = ((BArts.BInterface.IBUtenteEntrato.eAuthType)Obj).ToString().ToUpper();
            }
            else
            {
              config.AppSettings.Settings[Key].Value = BArts.BInterface.IBUtenteEntrato.eAuthType.NONE.ToString().ToUpper();
            }
          }

          Key = "DBAPP_DB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBAPP_SERVER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBAPP_USER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBAPP_PWD";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBUSER_DB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBUSER_SERVER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBUSER_USER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "DBUSER_PWD";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "VIEWSTATE_ONDB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("ViewStateOnDB");
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "VIEWSTATE_DB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "VIEWSTATE_SERVER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "VIEWSTATE_USER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "VIEWSTATE_PWD";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "VIEWSTATE_TIMEOUT";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SERVERREPORT_NAME";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
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

          Key = "WRITEERRORONEVENTLOG";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "WRITEERRORONDB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "WRITEERRORONFILE";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "WRITEERRORONFILE_PATHREL";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "WRITEERRORONFILE_PATH";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "WRITEERRORONFILE_WRITEONLYEVENTS";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "WRITEERRORONFILE_FILEEVENTS";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "WRITEERRORONFILE_FILEERRORS";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAILONERROR";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "SENDMAILONERRORFrom";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAILONERRORTo";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAIL_SenderType";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null)
            {
              config.AppSettings.Settings[Key].Value = ((BArts.BMail.BSenderMailConfig.eSenderType)Obj).ToString().ToUpper();
            }
            else
            {
              config.AppSettings.Settings[Key].Value = BArts.BMail.BSenderMailConfig.eSenderType.eNETMail.ToString().ToUpper();
            }
          }

          Key = "SENDMAIL_SMTPServer";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAIL_SMTPPort";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAIL_UserName";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAIL_Password";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAILSSL";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("SendMail_SSL");
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "SENDMAIL_NomeProfilo";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "SENDMAIL_NomeAccount";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "B_THEME";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("BTHEME");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "CSS_RISOLUZIONE";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("CSSRISOLUZIONE");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "CSS_SIZECONTAINER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("CSSSIZECONTAINER");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "CSS_BORDO";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("CSSBORDO");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "CSS_SHOWPROGBAR";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue("CSSSHOWPROGBAR");
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "CENTRA";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "URLIMAGETOP";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "URLIMAGECENTER";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "URLIMAGEBOTTOM";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "BODYBACKGROUNDIMAGE";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "BODYBACKGROUNDCOLOR";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "OFFLINE";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          Key = "OFFLINE_MSG";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            config.AppSettings.Settings[Key].Value = Obj + "";
          }

          Key = "INITDB";
          if (config.AppSettings.Settings[Key] != null)
          {
            Obj = this.BPropertyGrid1.GetPropertyValue(Key);
            if (Obj != null && (bool)Obj)
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_TRUE;
            }
            else
            {
              config.AppSettings.Settings[Key].Value = ModConstantList.K_FALSE;
            }
          }

          config.Save();


          // PROPRIETA' APPLICATION
          BAssemblyInfo BAss = new BAssemblyInfo(base.Server.MapPath("../"), new Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(Assembly.GetExecutingAssembly()));
          //BAssemblyInfo BAss = new BAssemblyInfo(base.Server.MapPath("../"),  My.MyWebExtension.Application.Info);
          Key = "TITOLOWEBSITE";
          Obj = this.BPropertyGrid1.GetPropertyValue(Key);
          BAss.Titolo = Obj + "";
          Key = "DESCRIZIONEWEBSITE";
          Obj = this.BPropertyGrid1.GetPropertyValue(Key);
          BAss.Descrizione = Obj + "";
          Key = "VERSIONEWEBSITE";
          Obj = this.BPropertyGrid1.GetPropertyValue(Key);
          BAss.Versione = Obj + "";
          Key = "COPYRIGHT";
          Obj = this.BPropertyGrid1.GetPropertyValue(Key);
          BAss.Copyright = Obj + "";
          BAss.Save();
        }

        return;
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (base.UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso;
          IDSysUtente = this.UtenteEntrato.Username;
        }

        ModLog.ScriviLog(this.DB, this.Config, IDSysUtente, ex, "sysWebConfig.BtnSalva_Click()", "", BArts.BEnumerations.eSeverity.ERROR, IDAccesso, this.Page);
        // MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        return;
      }
      finally
      {
        config = null;
      }
    }



    public override void Indietro_Click()
    {
      this.BRedirect("../Home.aspx");
      base.Indietro_Click();
    }


  }
}