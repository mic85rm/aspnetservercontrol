// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.9] ***
// ************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using static BArts.BEnumerations;
using static PosteWebTemplate1.ModLog;

namespace PosteWebTemplate1
{
  public partial class BCtlsysNotifiche : BWebControlTableBase
  {

    // DEFINIZIONE DATI

    protected enum eDtgElenco
    {
      IDUtente,
      Notificata,
      DataNotificata,
      Letta,
      DataLetta,
      Cancellata,
      DataCancellata
    }

    // DEFINIZIONE PROPRIETA'

    public bool Enabled
    {
      get
      {
        return PnlDettaglio.Enabled;
      }
      set
      {
        PnlDettaglio.Enabled = value;
      }
    }
    public BTesto mbtDataNotifica
    {
      get
      {
        return this.Internal_mbtDataNotifica;
      }
      set
      {
        this.Internal_mbtDataNotifica = value;
      }
    }
    public BTesto mbtOraNotifica
    {
      get
      {
        return this.Internal_mbtOraNotifica;
      }
      set
      {
        this.Internal_mbtOraNotifica = value;
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
    public BCombo mbcIDSysProfilo
    {
      get
      {
        return this.Internal_mbcIDSysProfilo;
      }
      set
      {
        this.Internal_mbcIDSysProfilo = value;
      }
    }
    public BCombo mbcIDSysSistema
    {
      get
      {
        return this.Internal_mbcIDSysSistema;
      }
      set
      {
        this.Internal_mbcIDSysSistema = value;
      }
    }
    public BTesto mbtIDSysUtente
    {
      get
      {
        return this.Internal_mbtIDSysUtente;
      }
      set
      {
        this.Internal_mbtIDSysUtente = value;
      }
    }
    public BSwitch chkInviaEmail
    {
      get
      {
        return this.Internal_chkInviaEmail;
      }
      set
      {
        this.Internal_chkInviaEmail = value;
      }
    }
    public BSwitch chkLimitaVisibilita
    {
      get
      {
        return this.Internal_chkLimitaVisibilita;
      }
      set
      {
        this.Internal_chkLimitaVisibilita = value;
      }
    }
    public BTesto mbtTitolo
    {
      get
      {
        return this.Internal_mbtTitolo;
      }
      set
      {
        this.Internal_mbtTitolo = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtTitolo.ClientID;
      mbtTitolo.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtDataNotifica.ClientID;
      mbtDataNotifica.CtlNextFocus = mbtOraNotifica.ClientID;
      mbtOraNotifica.CtlNextFocus = chkLimitaVisibilita.ClientID;
      chkLimitaVisibilita.CtlNextFocus = mbcIDSysSistema.ClientID;
      mbcIDSysSistema.CtlNextFocus = mbcIDSysProfilo.ClientID;
      mbcIDSysProfilo.CtlNextFocus = chkInviaEmail.ClientID;
      chkInviaEmail.CtlNextFocus = mbtIDSysUtente.ClientID;
      if (this.CtlBtnSalva != null) mbtIDSysUtente.CtlNextFocus = this.CtlBtnSalva.ClientID;

      base.SetAttributes_Invio();
    }
    public override void SetAttributes_Other()
    {
      this.mbcIDSysSistema.Init(this.DB.Setting);
      this.mbcIDSysSistema.Items.Insert(0, new ListItem("TUTTI I SISTEMI", "-1"));

      this.mbcIDSysProfilo.Init(this.DB.Setting);
      this.mbcIDSysProfilo.Items.Insert(0, new ListItem("TUTTI I PROFILI", "-1"));


      chkLimitaVisibilita.BindToProperty = BSwitch.eBindToProperty.DISPLAY;
      chkLimitaVisibilita.CtlTargetBind = PnlVisibilita;

      //mbtIDSysUtente.Autocomplete = true;
      //mbtIDSysUtente.AutoCompleteCampoID = "ID";
      //mbtIDSysUtente.AutoCompleteCampoDescrizione = "Descrizione";
      //mbtIDSysUtente.AutoCompleteMinLength = 2;
      //mbtIDSysUtente.AutoCompleteWebApiUrl = BGlobalNet.GetAutoCompleteUrl("bsysutenti", this.Page);
      //mbtIDSysUtente.SetAttributes();
      mbtIDSysUtente.SetAutoComplete(this.Page, "BsysUtenti", "autocomplete");

      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      DtgElenco.RowDataBound += DtgElenco_RowDataBound;
      BtnShowNotifiche.Click += BtnShowNotifiche_Click;
      base.SetAttributes_AddEvents();
    }


    protected override bool CheckBeforeUpdate()
    {
      bool ret = true;
      if (String.IsNullOrEmpty(mbtTitolo.Text))
      {
        this.AddCheckBeforeUpdateAlert("Titolo obbligatorio.", (WebControl)mbtTitolo);
        ret = false;
      }

      return ret;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtID.Enabled = false;
      mbtTitolo.Text = "";
      mbtDescrizione.Text = "";
      mbtDataNotifica.Text = BGlobal.FormattaData(DateTime.Now);
      mbtOraNotifica.Text = BGlobal.FormattaOra(DateTime.Now);
      chkLimitaVisibilita.Checked = false;
      mbcIDSysSistema.SelectedValue = "-1";
      mbcIDSysProfilo.SelectedValue = "-1";
      chkInviaEmail.Checked = false;
      mbtIDSysUtente.Text = "";
      mbtIDSysUtente.AutoCompleteValue = "";

      BtnShowNotifiche.Visible = false;
      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtTitolo.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysNotifiche MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysNotifiche)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtTitolo.Text = MyObj.Titolo.ToString();
        mbtDescrizione.Text = MyObj.Descrizione.ToString();
        mbtDataNotifica.Text = BGlobal.FormattaData(MyObj.DataNotifica);
        mbtOraNotifica.Text = BGlobal.FormattaOra(MyObj.DataNotifica);
        chkLimitaVisibilita.Checked = MyObj.LimitaVisibilita;
        mbcIDSysSistema.SelectedValue = MyObj.IDSysSistema.ToString();
        mbcIDSysProfilo.SelectedValue = MyObj.IDSysProfilo.ToString();
        chkInviaEmail.Checked = MyObj.InviaEmail;
        BsysUtenti u = new BsysUtenti(MyObj.IDSysUtente.ToString(), DB);
        if (u != null && !u.IsNothing && u.Persona != null && !u.Persona.IsNothing)
        {
          mbtIDSysUtente.Text = u.Persona.Cognome + " " + u.Persona.Nome + " [" + u.ID + "]";
        }
        else
        {
          mbtIDSysUtente.Text = MyObj.IDSysUtente.ToString();
        }
        mbtIDSysUtente.Tag = MyObj.IDSysUtente.ToString();
        mbtIDSysUtente.AutoCompleteValue = MyObj.IDSysUtente.ToString();

        BtnShowNotifiche.Visible = true;
        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtTitolo.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysNotifiche.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysNotifiche MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysNotifiche)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.Titolo = mbtTitolo.Text;
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.DataNotifica = BGlobal.PrendiData(mbtDataNotifica.Text + " " + mbtOraNotifica.Text);
          MyObj.LimitaVisibilita = chkLimitaVisibilita.Checked;
          MyObj.IDSysSistema = BConvert.ToInt(mbcIDSysSistema.SelectedValue);
          MyObj.IDSysProfilo = BConvert.ToInt(mbcIDSysProfilo.SelectedValue);
          MyObj.InviaEmail = chkInviaEmail.Checked;
          MyObj.DataUltimaModifica = DateTime.Now;
          MyObj.IDSysUtenteUltimaModifica = this.UtenteEntrato.Username;
          if (mbtIDSysUtente.Text == "")
            MyObj.IDSysUtente = "";
          else
            MyObj.IDSysUtente = mbtIDSysUtente.AutoCompleteValue;



          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysNotifiche");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysNotifiche.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }


    //DEFINIZIONE METODI OVERRIDES
    protected override void BControl_Load(object sender, EventArgs e)
    {
      WebControl Pnl = (WebControl)PnlVisibilita;
      BGlobalNet.Display(ref Pnl, chkLimitaVisibilita.Checked);
      base.BControl_Load(sender, e);
    }


    //DEFINIZIONE EVENTI INTERCETTATI
    private void DtgElenco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DataRowView drv = (DataRowView)(e.Row.DataItem);
        if (drv == null) return;
        e.Row.Cells[(byte)eDtgElenco.Notificata].Text = BGlobal.FormattaBool(BConvert.ToBool(drv.Row["Notificata"]));
        e.Row.Cells[(byte)eDtgElenco.Letta].Text = BGlobal.FormattaBool(BConvert.ToBool(drv.Row["Letta"]));
        e.Row.Cells[(byte)eDtgElenco.Cancellata].Text = BGlobal.FormattaBool(BConvert.ToBool(drv.Row["Cancellata"]));
      }
    }
    private void BtnShowNotifiche_Click(object sender, EventArgs e)
    {
      DataTable dt = null;
      try
      {
        dt = BsysUtentiNotifiche.GetElenco(this.DB, new SqlParameter("@IDSysNotifica", mbtID.Text));
        if (dt != null && dt.Rows.Count > 0)
        {
          DtgElenco.DataSource = dt;
          DtgElenco.DataBind();
        }
        pnlNotifiche.Show();

      }
      catch (Exception ex)
      {
        this.WriteLog("sysNotifiche.BtnShowNotifiche_Click():", "", ex, eSeverity.ERROR);
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }

      }
    }




  } //END CLASS
} //END NAMESPACE