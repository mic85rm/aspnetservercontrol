// *****************************************************
// *** Classe generata con BStudio 2017 [Ver. 3.0.5] ***
// *****************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using System;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlConfiguration : BWebControlTableBase
  {

    // DEFINIZIONE PROPRIETA'
    public bool Enabled
    {
      get
      {
        return this.PnlDettaglio.Enabled;
      }
      set
      {
        this.PnlDettaglio.Enabled = value;
        this.Internal_imgLogo.AbilitaUpload = value;
      }
    }
    public BTesto mbtID
    {
      get
      {
        return this.Internal_mbtID;
      }
      set
      {
        this.Internal_mbtID = value;
      }
    }
    public BTesto mbtDescrizione
    {
      get
      {
        return this.Internal_mbtDescrizione;
      }
      set
      {
        this.Internal_mbtDescrizione = value;
      }
    }
    public BImage imgLogo
    {
      get
      {
        return this.Internal_imgLogo;
      }
      set
      {
        this.Internal_imgLogo = value;
      }
    }
    public BTesto mbtMittenteMail
    {
      get
      {
        return this.Internal_mbtMittenteMail;
      }
      set
      {
        this.Internal_mbtMittenteMail = value;
      }
    }
    public BTesto mbtDestinatarioMail
    {
      get
      {
        return this.Internal_mbtDestinatarioMail;
      }
      set
      {
        this.Internal_mbtDestinatarioMail = value;
      }
    }
    public BTesto mbtLeggePrivacy
    {
      get
      {
        return this.Internal_mbtLeggePrivacy;
      }
      set
      {
        this.Internal_mbtLeggePrivacy = value;
      }
    }
    public BCombo mbcIDProfiloRegistrazione
    {
      get
      {
        return this.Internal_mbcIDProfiloRegistrazione;
      }
      set
      {
        this.Internal_mbcIDProfiloRegistrazione = value;
      }
    }
    public BCombo mbcIDSistemaRegistrazione
    {
      get
      {
        return this.Internal_mbcIDSistemaRegistrazione;
      }
      set
      {
        this.Internal_mbcIDSistemaRegistrazione = value;
      }
    }
    public BCombo mbcIDProfiloNotificaRegistrazione
    {
      get
      {
        return this.Internal_mbcIDProfiloNotificaRegistrazione;
      }
      set
      {
        this.Internal_mbcIDProfiloNotificaRegistrazione = value;
      }
    }
    public BTesto mbtEmailSegnalazioni
    {
      get
      {
        return this.Internal_mbtEmailSegnalazioni;
      }
      set
      {
        this.Internal_mbtEmailSegnalazioni = value;
      }
    }
    public BTesto mbtDataUltimaSincronizzazione
    {
      get
      {
        return this.Internal_mbtDataUltimaSincronizzazione;
      }
      set
      {
        this.Internal_mbtDataUltimaSincronizzazione = value;
      }
    }
    public BTesto mbtTimer
    {
      get
      {
        return this.Internal_mbtTimer;
      }
      set
      {
        this.Internal_mbtTimer = value;
      }
    }
    public BCombo mbcIDAmbienti
    {
      get
      {
        return this.Internal_mbcIDAmbienti;
      }
      set
      {
        this.Internal_mbcIDAmbienti = value;
      }
    }
    public BCombo mbcIDApplicazioni
    {
      get
      {
        return this.Internal_mbcIDApplicazioni;
      }
      set
      {
        this.Internal_mbcIDApplicazioni = value;
      }
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private void Internal_imgLogo_LoadScriptManager()
    {
      this.Internal_imgLogo.AttachScriptManager(BMaster.ScriptManager);
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtMittenteMail.ClientID;
      mbtMittenteMail.CtlNextFocus = mbtDestinatarioMail.ClientID;
      mbtDestinatarioMail.CtlNextFocus = mbtLeggePrivacy.ClientID;
      mbtLeggePrivacy.CtlNextFocus = mbcIDSistemaRegistrazione.ClientID;
      mbcIDSistemaRegistrazione.CtlNextFocus = mbcIDProfiloRegistrazione.ClientID;
      mbcIDProfiloRegistrazione.CtlNextFocus = mbcIDProfiloNotificaRegistrazione.ClientID;
      mbcIDProfiloNotificaRegistrazione.CtlNextFocus = mbtEmailSegnalazioni.ClientID;
      mbtEmailSegnalazioni.CtlNextFocus = mbtDataUltimaSincronizzazione.ClientID;
      if (this.CtlBtnSalva != null) mbtEmailSegnalazioni.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      mbcIDProfiloRegistrazione.Init(this.DB.Setting);
      mbcIDProfiloRegistrazione.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDSistemaRegistrazione.Init(this.DB.Setting);
      mbcIDSistemaRegistrazione.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDProfiloNotificaRegistrazione.Init(this.DB.Setting);
      mbcIDProfiloNotificaRegistrazione.Items.Insert(0, new ListItem("TUTTI I PROFILI", "-1"));
      mbcIDAmbienti.Init(this.DBUser.Setting);
      mbcIDAmbienti.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDApplicazioni.Init(this.DBUser.Setting);
      mbcIDApplicazioni.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      Internal_imgLogo.LoadScriptManager += Internal_imgLogo_LoadScriptManager;
      BtnAnnullaLogo.Click += BtnAnnullaLogo_Click;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = BGlobal.GeneraCodice("Configuration", "ID", this.DB).ToString();
      mbtDescrizione.Text = "";
      imgLogo.ImageUrl = "";
      mbtMittenteMail.Text = "";
      mbtDestinatarioMail.Text = "";
      mbtLeggePrivacy.Text = "";
      mbcIDSistemaRegistrazione.SelectedValue = "-1";
      mbcIDProfiloRegistrazione.SelectedValue = "-1";
      mbcIDProfiloNotificaRegistrazione.SelectedValue = "-1";
      mbtEmailSegnalazioni.Text = "";
      mbtTimer.Text = "";
      mbtDataUltimaSincronizzazione.Text = "";
      mbcIDAmbienti.SelectedValue = "-1";
      mbcIDApplicazioni.SelectedValue = "-1";

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BConfiguration MyObj = null;
      try
      {
        if (Obj == null)
          return false;
        MyObj = (BConfiguration)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione;
        imgLogo.ImageByte = MyObj.Logo;
        mbtMittenteMail.Text = MyObj.MittenteMail;
        mbtDestinatarioMail.Text = MyObj.DestinatarioMail;
        mbtLeggePrivacy.Text = MyObj.LeggePrivacy;
        mbcIDSistemaRegistrazione.SelectedValue = MyObj.IDSistemaRegistrazione.ToString();
        mbcIDProfiloRegistrazione.SelectedValue = MyObj.IDProfiloRegistrazione.ToString();
        mbcIDProfiloNotificaRegistrazione.SelectedValue = MyObj.IDProfiloNotificaRegistrazione.ToString();
        mbtEmailSegnalazioni.Text = MyObj.EmailSegnalazioni;
        if (!string.IsNullOrEmpty(MyObj.LastSyncNotifiche.ToString()))
        {
          mbtDataUltimaSincronizzazione.Text = MyObj.LastSyncNotifiche.ToString();
        }
        else
        {
          mbtDataUltimaSincronizzazione.Text = "";
        }

        if (MyObj.TimerSyncNotify != 0)
        {
          mbtTimer.Text = MyObj.TimerSyncNotify.ToString();
        }
        else
        {
          mbtTimer.Text = "";
        }
        mbcIDAmbienti.SelectedValue = MyObj.IDAmbiente.ToString();
        mbcIDApplicazioni.SelectedValue = MyObj.IDApplicazione.ToString();

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("Configuration.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BConfiguration MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BConfiguration)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.Logo = imgLogo.ImageByte;
          MyObj.MittenteMail = mbtMittenteMail.Text;
          MyObj.DestinatarioMail = mbtDestinatarioMail.Text;
          MyObj.LeggePrivacy = mbtLeggePrivacy.Text;
          MyObj.IDSistemaRegistrazione = BConvert.ToInt(mbcIDSistemaRegistrazione.SelectedValue);
          MyObj.IDProfiloRegistrazione = BConvert.ToInt(mbcIDProfiloRegistrazione.SelectedValue);
          MyObj.IDProfiloNotificaRegistrazione = BConvert.ToInt(mbcIDProfiloNotificaRegistrazione.SelectedValue);
          MyObj.EmailSegnalazioni = mbtEmailSegnalazioni.Text;
          MyObj.TimerSyncNotify = BConvert.ToInt(mbtTimer.Text, 0);
          if (!string.IsNullOrEmpty(mbtDataUltimaSincronizzazione.Text))
          {
            MyObj.LastSyncNotifiche = BGlobal.PrendiData(mbtDataUltimaSincronizzazione.Text);
          }
          else
          {
            MyObj.LastSyncNotifiche = null;
          }
          MyObj.IDAmbiente = BConvert.ToInt(mbcIDAmbienti.SelectedValue);
          MyObj.IDApplicazione = BConvert.ToInt(mbcIDApplicazioni.SelectedValue);

          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA Configuration");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        WriteLog("Configuration.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void BtnAnnullaLogo_Click(object sender, EventArgs e)
    {
      imgLogo.ImageByte = null;
      imgLogo.ImageUrl = "";
    }

  } //END CLASS
} //END NAMESPACE