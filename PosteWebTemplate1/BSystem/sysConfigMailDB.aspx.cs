using BArts.BGlobal;
using BArts.BMail;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Windows.Interop;

namespace PosteWebTemplate1
{
  public partial class sysConfigMailDB : BPageBase
  {

    // DEFINIZIONE ENUMERATIVI

    private enum eDTG : byte
    {
      BTNDELATE,
      ID,
      NOMEPROFILO,
      NOMEACCOUNT,
      DESCRIZIONE,
      EMAIL,
      DISPLAYNAME,
      REPLYTO
    }

    // DEFINIZIONE METODI OVERRIDES
    public override void Indietro_Click()
    {
      BRedirect(ModConstantList.K_PAGE_HOMECONSOLEDEVELOPER);
      Indietro_Click();
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private void CheckServerMail()
    {
      BSMTP Smtp = null;
      try
      {
        var SendConfig = new BSenderMailConfig(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer")),
                                              BConvert.ToInt(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                              BConvert.ToBool(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));
        SendConfig.SenderType = (BSenderMailConfig.eSenderType)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SendMail_SenderType"));
        SendConfig.Username = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Username"));
        SendConfig.Password = BCrypter.Decrypt(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Password")));
        SendConfig.NomeAccount = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeAccount"));
        SendConfig.NomeProfilo = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeProfilo"));
        Smtp = new BSMTP(SendConfig);
        if (Smtp != null)
        {
          Smtp.Cnn = base.DB;
          bool Attiva = Smtp.StateDBMail();
          this.ImgStatoVerde.Visible = Attiva;
          this.ImgStatoRosso.Visible = !Attiva;
          this.BtnDisattivaServerMail.Enabled = Attiva;
          this.BtnAttivaServerMail.Enabled = !Attiva;
        }
      }
      catch (Exception ex)
      {
        MsgBox(ex.Message);
      }
    }
    private void LoadServerMail()
    {
      BSMTP Smtp = null;
      var SendConfig = new BSenderMailConfig(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer")),
                                            BConvert.ToInt(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                            BConvert.ToBool(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));
      SendConfig.SenderType = (BSenderMailConfig.eSenderType)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SendMail_SenderType"));
      SendConfig.Username = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Username"));
      SendConfig.Password = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Password"));
      SendConfig.NomeAccount = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeAccount"));
      SendConfig.NomeProfilo = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeProfilo"));
      Smtp = new BSMTP(SendConfig);
      if (Smtp != null)
      {
        Smtp.Cnn = DB;
        this.dtgElenco.DataSource = Smtp.GetProfiloDBMail();
        this.dtgElenco.DataBind();
      }
    }
    private void ConfiguraServerMail(bool Attiva)
    {
      BSMTP Smtp = null;
      var SendConfig = new BSenderMailConfig(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer")),
                                            BConvert.ToInt(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                            BConvert.ToBool(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));
      SendConfig.SenderType = (BSenderMailConfig.eSenderType)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SendMail_SenderType"));
      SendConfig.Username = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Username"));
      SendConfig.Password = BCrypter.Decrypt(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Password")));
      SendConfig.NomeAccount = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeAccount"));
      SendConfig.NomeProfilo = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeProfilo"));
      Smtp = new BSMTP(SendConfig);
      if (Smtp != null)
      {
        Smtp.Cnn = base.DB;
        Smtp.ActiveDBMail(true);
        this.ImgStatoVerde.Visible = Attiva;
        this.ImgStatoRosso.Visible = !Attiva;
        this.BtnDisattivaServerMail.Enabled = Attiva;
        this.BtnAttivaServerMail.Enabled = !Attiva;
      }
    }


    //DEFINIZIONE METODI OVERRIDE
    protected override void BPage_Init(object sender, EventArgs e)
    {
      this.CheckAuth = false;
      this.DisabilitaInvio(false);
      // Me.ShowBtnIndietro()
      this.CtlCommandBar.PageName = "Configurazione Email";
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
        this.BPropertyGrid1.CategoryFilter = "Configurazione EMAIL";
        this.BPropertyGrid1.InitControl(Assembly.GetExecutingAssembly());
        CheckServerMail();
        LoadServerMail();
      }
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      BtnAttivaServerMail.Click += BtnConfiguraServerMail_Click;
      BtnDisattivaServerMail.Click += BtnDisattivaServerMail_Click;
      BtnCreaProfiloSQL.Click += BtnCreaProfiloSQL_Click;
      BtnInviaMail.Click += BtnInviaMail_Click;
      dtgElenco.RowCommand += dtgElenco_RowCommand;

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
              config.AppSettings.Settings[Key].Value = ((BSenderMailConfig.eSenderType)Obj).ToString().ToUpper();
            }
            else
            {
              config.AppSettings.Settings[Key].Value = BSenderMailConfig.eSenderType.eNETMail.ToString().ToUpper();
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

          config.Save();
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

        ModLog.ScriviLog(this.DB, this.Config, IDSysUtente, ex, "sysConfigMailDB.BtnSalva_Click():", "", BArts.BEnumerations.eSeverity.ERROR, IDAccesso, this.Page);
        return;
      }
      finally
      {
        config = null;
      }
    }

    private void BtnConfiguraServerMail_Click(object sender, EventArgs e)
    {
      ConfiguraServerMail(true);
    }
    private void BtnDisattivaServerMail_Click(object sender, EventArgs e)
    {
      ConfiguraServerMail(false);
    }
    private void BtnCreaProfiloSQL_Click(object sender, EventArgs e)
    {
      BSMTP Smtp = null;
      var SendConfig = new BSenderMailConfig(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer").ToString(),
                                            (int)(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                            (bool)(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));

      SendConfig.SenderType = (BSenderMailConfig.eSenderType)this.BPropertyGrid1.GetPropertyValue("SendMail_SenderType");
      SendConfig.Username = this.BPropertyGrid1.GetPropertyValue("SendMail_Username").ToString();
      SendConfig.Password = this.BPropertyGrid1.GetPropertyValue("SendMail_Password").ToString();
      SendConfig.NomeAccount = this.BPropertyGrid1.GetPropertyValue("SendMail_NomeAccount").ToString();
      SendConfig.NomeProfilo = this.BPropertyGrid1.GetPropertyValue("SendMail_NomeProfilo").ToString();
      Smtp = new BSMTP(SendConfig);
      if (Smtp != null)
      {
        Smtp.Cnn = this.DB;
        if (Smtp.CreaProfiloDBMail())
        {
          this.MsgBox("Profilo creato con successo.");
          LoadServerMail();
        }
        else
        {
          this.MsgBox("Crezione profilo fallita. Verificare la configurazione.");
        }
      }
    }
    protected void BtnInviaMail_Click(object sender, EventArgs e)
    {
      BSMTP Smtp = null;
      var SendConfig = new BSenderMailConfig(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer")),
                                            BConvert.ToInt(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                            BConvert.ToBool(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));
      SendConfig.SenderType = (BSenderMailConfig.eSenderType)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SendMail_SenderType"));
      SendConfig.Username = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Username"));
      SendConfig.Password = BCrypter.Decrypt(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_Password")));
      SendConfig.NomeAccount = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeAccount"));
      SendConfig.NomeProfilo = BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_NomeProfilo"));
      Smtp = new BSMTP(SendConfig);
      if (Smtp != null)
      {
        Smtp.Cnn = this.DB;
        Smtp.Oggetto = this.mbtOggetto.Text;
        Smtp.Body = this.mbtBody.Text;
        Smtp.AliasMittente = BWebConfig.SendMailOnErrorFrom;
        var dest = new List<string>();
        dest.Add(BWebConfig.SendMailOnErrorTo);
        Smtp.Destinatari = dest;
        if (Smtp.InviaMail())
        {
          this.ShowToast("Messaggio inviato con successo.");
        }
        else
        {
          string msg = "Messaggio non inviato. Verificare la configurazione:";
          foreach (Exception ex in Smtp.ExceptionList)
          {
            msg += ex.Message + BVisualBasic.vbNewLine();
          }

          this.MsgBox(msg);
        }
      }
      else
      {
        this.MsgBox("Messaggio non inviato. Send Config non inizializzato.");
      }
    }
    private void dtgElenco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "BDELETE":
          {
            BSMTP Smtp = null;
            var SendConfig = new BSenderMailConfig(BConvert.ToString(BPropertyGrid1.GetPropertyValue("SendMail_SMTPServer")),
                                                  BConvert.ToInt(this.BPropertyGrid1.GetPropertyValue("SendMail_SMTPPort")),
                                                  BConvert.ToBool(this.BPropertyGrid1.GetPropertyValue("SendMail_SSL")));
            SendConfig.SenderType = (BSenderMailConfig.eSenderType)BConvert.ToByte(BPropertyGrid1.GetPropertyValue("SendMail_SenderType"));
            SendConfig.NomeAccount = this.dtgElenco.Rows[int.Parse(e.CommandArgument.ToString())].Cells[(int)eDTG.NOMEACCOUNT].Text;
            SendConfig.NomeProfilo = this.dtgElenco.Rows[int.Parse(e.CommandArgument.ToString())].Cells[(int)eDTG.NOMEPROFILO].Text;
            Smtp = new BSMTP(SendConfig);
            if (Smtp != null)
            {
              Smtp.Cnn = this.DB;
              if (Smtp.EliminaProfiloDBMail())
              {
                this.MsgBox("Profilo eliminato con successo.");
                LoadServerMail();
              }
              else
              {
                this.MsgBox("Rimozione profilo non riuscita.");
              }
            }

            break;
          }
      }
    }

  } //END CLASS
} //END NAMESPACE