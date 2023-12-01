// *****************************************************
// *** Classe generata con BStudio 2017 [Ver. 3.0.6] ***
// *****************************************************
using BArts;
using BArts.BExceptions;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlsysPersone : BWebControlTableBase
  {
    public BCtlsysPersone()
    {

    }


    // DEFINIZIONE PROPRIETA'

    #region public bool Silente
    private const string K_VS_SILENTE = ".Silente";
    public bool Silente
    {
      get
      {
        if (base.ViewState[base.ID + K_VS_SILENTE] == null) return false;
        return (bool)(base.ViewState[base.ID + K_VS_SILENTE]);
      }
      set
      {
        base.ViewState[base.ID + K_VS_SILENTE] = value;
      }
    }
    #endregion

    public bool Enabled
    {
      get
      {
        return this.PnlDettaglio.Enabled;
      }
      set
      {
        this.PnlDettaglio.Enabled = value;
        this.Internal_imgFoto.AbilitaUpload = value;
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
    public BTesto mbtCodiceFiscale
    {
      get
      {
        return this.Internal_mbtCodiceFiscale;
      }

      set
      {
        this.Internal_mbtCodiceFiscale = value;
      }
    }
    public BTesto mbtNome
    {
      get
      {
        return this.Internal_mbtNome;
      }

      set
      {
        this.Internal_mbtNome = value;
      }
    }
    public BTesto mbtCognome
    {
      get
      {
        return this.Internal_mbtCognome;
      }

      set
      {
        this.Internal_mbtCognome = value;
      }
    }
    public BTesto mbtDataNascita
    {
      get
      {
        return this.Internal_mbtDataNascita;
      }

      set
      {
        this.Internal_mbtDataNascita = value;
      }
    }
    public BCombo mbcSesso
    {
      get
      {
        return this.Internal_mbcSesso;
      }

      set
      {
        this.Internal_mbcSesso = value;
      }
    }
    public BTesto mbtFax
    {
      get
      {
        return this.Internal_mbtFax;
      }

      set
      {
        this.Internal_mbtFax = value;
      }
    }
    public BTesto mbtTelefono
    {
      get
      {
        return this.Internal_mbtTelefono;
      }

      set
      {
        this.Internal_mbtTelefono = value;
      }
    }
    public BTesto mbtCelluare
    {
      get
      {
        return this.Internal_mbtCelluare;
      }

      set
      {
        this.Internal_mbtCelluare = value;
      }
    }
    public BTesto mbtAltroRecapito
    {
      get
      {
        return this.Internal_mbtAltroRecapito;
      }

      set
      {
        this.Internal_mbtAltroRecapito = value;
      }
    }
    public BTesto mbtEmail
    {
      get
      {
        return this.Internal_mbtEmail;
      }

      set
      {
        this.Internal_mbtEmail = value;
      }
    }
    public BTesto mbtCAPResidenza
    {
      get
      {
        return this.Internal_mbtCAPResidenza;
      }

      set
      {
        this.Internal_mbtCAPResidenza = value;
      }
    }
    public BTesto mbtCAPDomicilio
    {
      get
      {
        return this.Internal_mbtCAPDomicilio;
      }

      set
      {
        this.Internal_mbtCAPDomicilio = value;
      }
    }
    public BTesto mbtIndirizzoDomicilio
    {
      get
      {
        return this.Internal_mbtIndirizzoDomicilio;
      }

      set
      {
        this.Internal_mbtIndirizzoDomicilio = value;
      }
    }
    public BTesto mbtIndirizzoResidenza
    {
      get
      {
        return this.Internal_mbtIndirizzoResidenza;
      }

      set
      {
        this.Internal_mbtIndirizzoResidenza = value;
      }
    }
    public BCombo mbcIDStatoNascita
    {
      get
      {
        return this.Internal_mbcIDStatoNascita;
      }

      set
      {
        this.Internal_mbcIDStatoNascita = value;
      }
    }
    public BCombo mbcIDStatoDomicilio
    {
      get
      {
        return this.Internal_mbcIDStatoDomicilio;
      }

      set
      {
        this.Internal_mbcIDStatoDomicilio = value;
      }
    }
    public BCombo mbcIDStatoResidenza
    {
      get
      {
        return this.Internal_mbcIDStatoResidenza;
      }

      set
      {
        this.Internal_mbcIDStatoResidenza = value;
      }
    }
    public BTesto mbtIDComuneNascita
    {
      get
      {
        return this.Internal_mbtIDComuneNascita;
      }

      set
      {
        this.Internal_mbtIDComuneNascita = value;
      }
    }
    public BTesto mbtIDComuneDomicilio
    {
      get
      {
        return this.Internal_mbtIDComuneDomicilio;
      }

      set
      {
        this.Internal_mbtIDComuneDomicilio = value;
      }
    }
    public BTesto mbtIDComuneResidenza
    {
      get
      {
        return this.Internal_mbtIDComuneResidenza;
      }

      set
      {
        this.Internal_mbtIDComuneResidenza = value;
      }
    }
    public BTesto mbtNote
    {
      get
      {
        return this.Internal_mbtNote;
      }

      set
      {
        this.Internal_mbtNote = value;
      }
    }
    public BTesto mbtWebSite
    {
      get
      {
        return this.Internal_mbtWebSite;
      }

      set
      {
        this.Internal_mbtWebSite = value;
      }
    }
    public BImage imgFoto
    {
      get
      {
        return this.Internal_imgFoto;
      }

      set
      {
        this.Internal_imgFoto = value;
      }
    }

    //private void Internal_imgFoto_LoadScriptManager()
    //{
    //  this.Internal_imgFoto.AttachScriptManager(((Web)this.Page.Master).ScriptManager);
    //}


    public Panel PnlFoto
    {
      get
      {
        return this.Internal_PnlFoto;
      }
      set
      {
        this.Internal_PnlFoto = value;
      }
    }
    public Panel PnlColDati
    {
      get
      {
        return this.Internal_PnlColDati;
      }

      set
      {
        this.Internal_PnlColDati = value;
      }
    }
    public Panel PnlAnagrafica
    {
      get
      {
        return this.Internal_PnlAnagrafica;
      }

      set
      {
        this.Internal_PnlAnagrafica = value;
      }
    }
    public Panel PnlResidenza
    {
      get
      {
        return this.Internal_PnlResidenza;
      }

      set
      {
        this.Internal_PnlResidenza = value;
      }
    }
    public Panel PnlDomicilio
    {
      get
      {
        return this.Internal_PnlDomicilio;
      }

      set
      {
        this.Internal_PnlDomicilio = value;
      }
    }
    public Panel PnlRecapiti
    {
      get
      {
        return this.Internal_PnlRecapiti;
      }

      set
      {
        this.Internal_PnlRecapiti = value;
      }
    }
    public Panel PnlNote
    {
      get
      {
        return this.Internal_PnlNote;
      }

      set
      {
        this.Internal_PnlNote = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      // DETTAGLIO
      mbtID.CtlNextFocus = mbtNome.ClientID;
      mbtID.INVIO = true;
      mbtNome.CtlNextFocus = mbtCognome.ClientID;
      mbtNome.INVIO = true;
      mbtCognome.CtlNextFocus = mbtDataNascita.ClientID;
      mbtCognome.INVIO = true;
      mbtDataNascita.CtlNextFocus = mbcSesso.ClientID;
      mbtDataNascita.INVIO = true;
      mbcSesso.CtlNextFocus = mbcIDStatoNascita.ClientID;
      mbcSesso.INVIO = true;
      mbcIDStatoNascita.CtlNextFocus = mbtIDComuneNascita.ClientID;
      mbcIDStatoNascita.INVIO = true;
      mbtIDComuneNascita.CtlNextFocus = mbtCodiceFiscale.ClientID;
      mbtIDComuneNascita.INVIO = true;
      mbtCodiceFiscale.CtlNextFocus = mbtIndirizzoResidenza.ClientID;
      mbtCodiceFiscale.INVIO = true;
      mbtIndirizzoResidenza.CtlNextFocus = mbtCAPResidenza.ClientID;
      mbtIndirizzoResidenza.INVIO = true;
      mbtCAPResidenza.CtlNextFocus = mbcIDStatoResidenza.ClientID;
      mbtCAPResidenza.INVIO = true;
      mbcIDStatoResidenza.CtlNextFocus = mbtIDComuneResidenza.ClientID;
      mbcIDStatoResidenza.INVIO = true;
      mbtIDComuneResidenza.CtlNextFocus = mbtIndirizzoDomicilio.ClientID;
      mbtIDComuneResidenza.INVIO = true;
      mbtIndirizzoDomicilio.CtlNextFocus = mbtCAPDomicilio.ClientID;
      mbtIndirizzoDomicilio.INVIO = true;
      mbtCAPDomicilio.CtlNextFocus = mbcIDStatoDomicilio.ClientID;
      mbtCAPDomicilio.INVIO = true;
      mbcIDStatoDomicilio.CtlNextFocus = mbtIDComuneDomicilio.ClientID;
      mbcIDStatoDomicilio.INVIO = true;
      mbtIDComuneDomicilio.CtlNextFocus = mbtTelefono.ClientID;
      mbtIDComuneDomicilio.INVIO = true;
      mbtTelefono.CtlNextFocus = mbtCelluare.ClientID;
      mbtTelefono.INVIO = true;
      mbtCelluare.CtlNextFocus = mbtFax.ClientID;
      mbtCelluare.INVIO = true;
      mbtFax.CtlNextFocus = mbtAltroRecapito.ClientID;
      mbtFax.INVIO = true;
      mbtAltroRecapito.CtlNextFocus = mbtEmail.ClientID;
      mbtAltroRecapito.INVIO = true;
      mbtEmail.CtlNextFocus = mbtWebSite.ClientID;
      mbtEmail.INVIO = true;
      mbtWebSite.CtlNextFocus = mbtNote.ClientID;
      mbtWebSite.INVIO = true;
      if (this.CtlBtnSalva != null)
        mbtNote.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      mbcIDStatoNascita.Init(this.DB.Setting);
      mbcIDStatoNascita.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDStatoDomicilio.Init(this.DB.Setting);
      mbcIDStatoDomicilio.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDStatoResidenza.Init(this.DB.Setting);
      mbcIDStatoResidenza.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      this.mbcIDQuartiereResidenza.Filtro = "IDComune = '-1'";
      this.mbcIDQuartiereResidenza.Init(this.DB.Setting);
      this.mbcIDQuartiereResidenza.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      this.mbcIDQuartiereDomicilio.Filtro = "IDComune = '-1'";
      this.mbcIDQuartiereDomicilio.Init(this.DB.Setting);
      this.mbcIDQuartiereDomicilio.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));

      mbtIDComuneNascita.SetAutoComplete(this.Page, "BsysComuni", "autocomplete");
      mbtIDComuneResidenza.SetAutoComplete(this.Page, "BsysComuni", "autocomplete");
      mbtIDComuneDomicilio.SetAutoComplete(this.Page, "BsysComuni", "autocomplete");

      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      this.EventManager += BCtlsysPersone_EventManager;

      //Internal_imgFoto.LoadScriptManager += Internal_imgFoto_LoadScriptManager;
      Internal_mbtCodiceFiscale.HelpButtonClick += mbtCodiceFiscale_HelpButtonClick;
      lnkEliminaFoto.Click += LnkEliminaFoto_Click;
      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = BGlobal.GeneraCodice("sysPersone", "ID", this.DB).ToString();
      mbtCodiceFiscale.Text = "";
      mbtNome.Text = "";
      mbtCognome.Text = "";
      mbtDataNascita.Text = "";
      mbcSesso.SelectedIndex = 0;
      mbtFax.Text = "";
      mbtTelefono.Text = "";
      mbtCelluare.Text = "";
      mbtAltroRecapito.Text = "";
      mbtEmail.Text = "";
      mbtCAPResidenza.Text = "";
      mbtCAPDomicilio.Text = "";
      mbtIndirizzoDomicilio.Text = "";
      mbtIndirizzoResidenza.Text = "";
      mbcIDStatoNascita.SelectedValue = "-1";
      mbcIDStatoDomicilio.SelectedValue = "-1";
      mbcIDStatoResidenza.SelectedValue = "-1";
      mbtIDComuneNascita.Text = "";
      mbtIDComuneDomicilio.Text = "";
      mbtIDComuneResidenza.Text = "";
      mbtIDComuneNascita.Tag = "";
      mbtIDComuneDomicilio.Tag = "";
      mbtIDComuneResidenza.Tag = "";
      mbtNote.Text = "";
      mbtWebSite.Text = "";
      imgFoto.ImageUrl = "";
      imgFoto.ImageByte = null;

      //ADD ATTRIBUTES
      mbtIDComuneResidenza.Attributes["onblur"] = "return BPostBack('BCOMUNERESIDENZA_CHANGE', '-1', '" + mbtIDComuneResidenza.ClientID + "')";
      mbtIDComuneDomicilio.Attributes["onblur"] = "return BPostBack('BCOMUNEDOMICILIO_CHANGE', '-1', '" + mbtIDComuneDomicilio.ClientID + "')";

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtNome.Focus();
    }
    public override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysPersone MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysPersone)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtCodiceFiscale.Text = MyObj.CodiceFiscale;
        mbtNome.Text = MyObj.Nome;
        mbtCognome.Text = MyObj.Cognome;
        mbtDataNascita.Text = BGlobal.FormattaData(MyObj.DataNascita);
        mbcSesso.SelectedValue = BGlobal.CBoolOracle(MyObj.Sesso).ToString();
        mbtFax.Text = MyObj.Fax;
        mbtTelefono.Text = MyObj.Telefono;
        mbtCelluare.Text = MyObj.Celluare;
        mbtAltroRecapito.Text = MyObj.AltroRecapito;
        mbtEmail.Text = MyObj.Email;
        mbtCAPResidenza.Text = MyObj.CAPResidenza;
        mbtCAPDomicilio.Text = MyObj.CAPDomicilio;
        mbtIndirizzoDomicilio.Text = MyObj.IndirizzoDomicilio;
        mbtIndirizzoResidenza.Text = MyObj.IndirizzoResidenza;
        if (mbcIDStatoNascita.Items.FindByValue(MyObj.IDStatoNascita) != null)
        {
          mbcIDStatoNascita.SelectedValue = MyObj.IDStatoNascita;
        }
        else
        {
          mbcIDStatoNascita.SelectedValue = "-1";
        }
        if (mbcIDStatoDomicilio.Items.FindByValue(MyObj.IDStatoDomicilio) != null)
        {
          mbcIDStatoDomicilio.SelectedValue = MyObj.IDStatoDomicilio;
        }
        else
        {
          mbcIDStatoDomicilio.SelectedValue = "-1";
        }
        if (mbcIDStatoNascita.Items.FindByValue(MyObj.IDStatoResidenza) != null)
        {
          mbcIDStatoResidenza.SelectedValue = MyObj.IDStatoResidenza;
        }
        else
        {
          mbcIDStatoResidenza.SelectedValue = "-1";
        }

        mbtIDComuneNascita.Text = ModWebServices.GetDescrizioneComuneFromWS(MyObj.IDComuneNascita, base.DB, (BPageBase)this.Page);
        mbtIDComuneDomicilio.Text = ModWebServices.GetDescrizioneComuneFromWS(MyObj.IDComuneDomicilio, base.DB, (BPageBase)this.Page);
        mbtIDComuneResidenza.Text = ModWebServices.GetDescrizioneComuneFromWS(MyObj.IDComuneResidenza, base.DB, (BPageBase)this.Page);
        mbtIDComuneNascita.AutoCompleteValue = MyObj.IDComuneNascita;
        mbtIDComuneDomicilio.AutoCompleteValue = MyObj.IDComuneDomicilio;
        mbtIDComuneResidenza.AutoCompleteValue = MyObj.IDComuneResidenza;

        this.mbcIDQuartiereResidenza.Filtro = "IDComune = '" + MyObj.IDComuneResidenza + "'";
        this.mbcIDQuartiereResidenza.Init(this.DB.Setting);
        this.mbcIDQuartiereResidenza.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
        mbtIDComuneResidenza.Attributes["onblur"] = "return BPostBack('BCOMUNERESIDENZA_CHANGE', '" + MyObj.IDComuneResidenza + "', '" + mbtIDComuneResidenza.ClientID + "')";
        if (MyObj.IDQuartiereResidenza > 0)
        {
          this.mbcIDQuartiereResidenza.SelectedValue = MyObj.IDQuartiereResidenza.ToString();
        }

        this.mbcIDQuartiereDomicilio.Filtro = "IDComune = '" + MyObj.IDComuneDomicilio + "'";
        this.mbcIDQuartiereDomicilio.Init(this.DB.Setting);
        this.mbcIDQuartiereDomicilio.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
        mbtIDComuneDomicilio.Attributes["onblur"] = "return BPostBack('BCOMUNEDOMICILIO_CHANGE', '" + MyObj.IDComuneDomicilio + "', '" + mbtIDComuneDomicilio.ClientID + "')";
        if (MyObj.IDQuartiereDomicilio > 0)
        {
          this.mbcIDQuartiereDomicilio.SelectedValue = MyObj.IDQuartiereDomicilio.ToString();
        }

        mbtNote.Text = MyObj.Note;
        mbtWebSite.Text = MyObj.WebSite;
        if (MyObj.Foto != null && MyObj.Foto.Length > 0)
        {
          imgFoto.ImageByte = MyObj.Foto;
        }
        else
        {
          imgFoto.ImageByte = null;
          imgFoto.ImageUrl = "";
        }
        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtNome.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysPersone.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysPersone MyObj = null;
      bool Ret = false;
      try
      {
        this.IsCheckBeforeUpdateFailled = !this.CheckBeforeUpdate();
        if (this.IsCheckBeforeUpdateFailled) return null;
        MyObj = (BsysPersone)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.CodiceFiscale = mbtCodiceFiscale.Text;
          MyObj.Nome = mbtNome.Text;
          MyObj.Cognome = mbtCognome.Text;
          MyObj.DataNascita = BGlobal.PrendiData(mbtDataNascita.Text);
          MyObj.Sesso = BGlobal.PrendiBool(mbcSesso.SelectedValue);
          MyObj.Fax = mbtFax.Text;
          MyObj.Telefono = mbtTelefono.Text;
          MyObj.Celluare = mbtCelluare.Text;
          MyObj.AltroRecapito = mbtAltroRecapito.Text;
          MyObj.Email = mbtEmail.Text;
          MyObj.CAPResidenza = mbtCAPResidenza.Text;
          MyObj.CAPDomicilio = mbtCAPDomicilio.Text;
          MyObj.IndirizzoDomicilio = mbtIndirizzoDomicilio.Text;
          MyObj.IndirizzoResidenza = mbtIndirizzoResidenza.Text;
          MyObj.IDStatoNascita = mbcIDStatoNascita.SelectedValue;
          MyObj.IDStatoDomicilio = mbcIDStatoDomicilio.SelectedValue;
          MyObj.IDStatoResidenza = mbcIDStatoResidenza.SelectedValue;


          if (mbtIDComuneNascita.Text == "")
          {
            MyObj.IDComuneNascita = "";
          }
          else
          {
            if (mbtIDComuneNascita.AutoCompleteValue == "0") mbtIDComuneNascita.AutoCompleteValue = "";
            MyObj.IDComuneNascita = mbtIDComuneNascita.AutoCompleteValue;
          }
          if (mbtIDComuneDomicilio.Text == "")
          {
            MyObj.IDComuneDomicilio = "";
          }
          else
          {
            if (mbtIDComuneDomicilio.AutoCompleteValue == "0") mbtIDComuneDomicilio.AutoCompleteValue = "";
            MyObj.IDComuneDomicilio = mbtIDComuneDomicilio.AutoCompleteValue;
          }
          if (mbtIDComuneResidenza.Text == "")
          {
            MyObj.IDComuneResidenza = "";
          }
          else
          {
            if (mbtIDComuneResidenza.AutoCompleteValue == "0") mbtIDComuneResidenza.AutoCompleteValue = "";
            MyObj.IDComuneResidenza = mbtIDComuneResidenza.AutoCompleteValue;
          }
          MyObj.IDQuartiereResidenza = BConvert.ToInt(this.mbcIDQuartiereResidenza.SelectedValue);
          MyObj.IDQuartiereDomicilio = BConvert.ToInt(this.mbcIDQuartiereDomicilio.SelectedValue);
          MyObj.Note = mbtNote.Text;
          MyObj.WebSite = mbtWebSite.Text;
          MyObj.Foto = imgFoto.ImageByte;
          Ret = MyObj.Update();
        }

        if (Ret)
        {
          this.BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysPersone");
          if (!Silente) this.ShowToast("Salvataggio effettuato con successo.", "Informazione");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysPersone.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    protected override bool CheckBeforeUpdate()
    {
      if (string.IsNullOrEmpty(mbtCognome.Text))
      {
        this.MsgBox("Inserimento obbligatorio.");
        mbtCognome.Focus();
        return false;
      }

      if (string.IsNullOrEmpty(mbtNome.Text))
      {
        this.MsgBox("Inserimento obbligatorio.");
        mbtNome.Focus();
        return false;
      }

      if (string.IsNullOrEmpty(mbtDataNascita.Text))
      {
        this.MsgBox("Inserimento obbligatorio.");
        mbtDataNascita.Focus();
        return false;
      }

      if (!string.IsNullOrEmpty(mbtIDComuneNascita.Text) && mbtIDComuneNascita.AutoCompleteValue == "0")
      {
        this.MsgBox("Comune di nascita non individuato.");
        mbtIDComuneNascita.Focus();
        return false;
      }
      if (!string.IsNullOrEmpty(mbtIDComuneResidenza.Text) && mbtIDComuneResidenza.AutoCompleteValue == "0")
      {
        this.MsgBox("Comune di residenza non individuato.");
        mbtIDComuneResidenza.Focus();
        return false;
      }
      if (!string.IsNullOrEmpty(mbtIDComuneDomicilio.Text) && mbtIDComuneDomicilio.AutoCompleteValue == "0")
      {
        this.MsgBox("Comune di domicilio non individuato.");
        mbtIDComuneDomicilio.Focus();
        return false;
      }

      if (!string.IsNullOrEmpty(mbtCodiceFiscale.Text) && BGlobal.EsistonoRecord("sysPersone", DB, "CodiceFiscale = " + DB.Setting.C_S + mbtCodiceFiscale.Text + DB.Setting.C_S + " and id <> " + mbtID.Text))
      {
        this.MsgBox("Esiste già un'anagrafica relativa al codice fiscale inserito");
        mbtCodiceFiscale.Focus();
        return false;
      }

      return base.CheckBeforeUpdate();
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void mbtCodiceFiscale_HelpButtonClick()
    {
      this.RaiseEvent_ShowExtender();
      string IDComune = ModWebServices.GetIDComuneFromDescrWS(mbtIDComuneNascita.Text, base.DB, (BPageBase)this.Page);
      if (!string.IsNullOrEmpty(IDComune))
      {
        mbtCodiceFiscale.Text = BGlobal.CalcolaCodiceFiscale(mbtNome.Text, mbtCognome.Text, mbtDataNascita.Text, IDComune, BGlobal.PrendiBool(mbcSesso.SelectedValue));
      }
      else
      {
        base.MsgBox("Comune non presente in archivio o non univoco");
      }

      mbtCodiceFiscale.Focus();
    }
    private void BCtlsysPersone_EventManager(string CommandName, string Args, string sender)
    {
      var switchExpr = CommandName.ToUpper();
      switch (switchExpr)
      {
        case "BCOMUNERESIDENZA_CHANGE":
          {
            string IDComune = mbtIDComuneResidenza.AutoCompleteValue;
            if (string.IsNullOrEmpty(IDComune) || IDComune == "0") IDComune = "-1";
            this.mbcIDQuartiereResidenza.Filtro = "IDComune = '" + IDComune + "'";
            this.mbcIDQuartiereResidenza.Init(this.DB.Setting);
            this.mbcIDQuartiereResidenza.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
            mbtIDComuneResidenza.Attributes["onblur"] = "return BPostBack('BCOMUNERESIDENZA_CHANGE', '" + IDComune + "', '" + mbtIDComuneResidenza.ClientID + "')";
            break;
          }

        case "BCOMUNEDOMICILIO_CHANGE":
          {
            string IDComune = mbtIDComuneDomicilio.AutoCompleteValue;
            if (string.IsNullOrEmpty(IDComune) || IDComune == "0") IDComune = "-1";
            this.mbcIDQuartiereDomicilio.Filtro = "IDComune = '" + IDComune + "'";
            this.mbcIDQuartiereDomicilio.Init(this.DB.Setting);
            this.mbcIDQuartiereDomicilio.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
            mbtIDComuneDomicilio.Attributes["onblur"] = "return BPostBack('BCOMUNEDOMICILIO_CHANGE', '" + IDComune + "', '" + mbtIDComuneDomicilio.ClientID + "')";
            break;
          }
      }
    }

    private void LnkEliminaFoto_Click(object sender, EventArgs e)
    {
      this.imgFoto.ImageUrl = "";
      this.imgFoto.ImageByte = null;
    }


  } //END CLASS
} //END NAMESPACE