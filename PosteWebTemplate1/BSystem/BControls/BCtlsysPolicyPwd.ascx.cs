// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.9] ***
// ************************************************
using BArts;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using static BArts.BEnumerations;
using static PosteWebTemplate1.ModLog;

namespace PosteWebTemplate1
{
  public partial class BCtlsysPolicyPwd : BWebControlTableBase
  {

    // DEFINIZIONE DATI

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
    public BSwitch chkScadenzaPwd
    {
      get
      {
        return this.Internal_chkScadenzaPwd;
      }
      set
      {
        this.Internal_chkScadenzaPwd = value;
      }
    }
    public BTesto mbtNumGiorni
    {
      get
      {
        return this.Internal_mbtNumGiorni;
      }
      set
      {
        this.Internal_mbtNumGiorni = value;
      }
    }
    public BSwitch chkChkPwdImmessa
    {
      get
      {
        return this.Internal_chkChkPwdImmessa;
      }
      set
      {
        this.Internal_chkChkPwdImmessa = value;
      }
    }
    public BTesto mbtNumMaxChkPwdImmessa
    {
      get
      {
        return this.Internal_mbtNumMaxChkPwdImmessa;
      }
      set
      {
        this.Internal_mbtNumMaxChkPwdImmessa = value;
      }
    }
    public BCheck chkSistema
    {
      get
      {
        return this.Internal_chkSistema;
      }
      set
      {
        this.Internal_chkSistema = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = chkScadenzaPwd.ClientID;
      chkScadenzaPwd.CtlNextFocus = mbtNumGiorni.ClientID;
      mbtNumGiorni.CtlNextFocus = chkChkPwdImmessa.ClientID;
      chkChkPwdImmessa.CtlNextFocus = mbtNumMaxChkPwdImmessa.ClientID;
      mbtNumMaxChkPwdImmessa.CtlNextFocus = chkSistema.ClientID;
      if (this.CtlBtnSalva != null) chkSistema.CtlNextFocus = this.CtlBtnSalva.ClientID;

      base.SetAttributes_Invio();
    }
    public override void SetAttributes_Other()
    {
      chkScadenzaPwd.BindToProperty = BSwitch.eBindToProperty.DISPLAY;
      chkScadenzaPwd.CtlTargetBind = PnlScadenzaPwd;
      chkChkPwdImmessa.BindToProperty = BSwitch.eBindToProperty.DISPLAY;
      chkChkPwdImmessa.CtlTargetBind = PnlNumPwd;

      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {

      base.SetAttributes_AddEvents();
    }

    protected override void OnLoad(EventArgs e)
    {
      WebControl ctl = (WebControl)PnlScadenzaPwd;
      BGlobalNet.Display(ref ctl, chkScadenzaPwd.Checked);
      ctl = (WebControl)PnlNumPwd;
      BGlobalNet.Display(ref ctl, chkChkPwdImmessa.Checked);
      base.OnLoad(e);
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtID.Enabled = false;
      mbtDescrizione.Text = "";
      chkScadenzaPwd.Checked = false;
      mbtNumGiorni.Text = "";
      chkChkPwdImmessa.Checked = false;
      mbtNumMaxChkPwdImmessa.Text = "";
      chkSistema.Checked = false;
      chkSistema.Enabled = this.UtenteEntrato.Developer;

      WebControl ctl = (WebControl)PnlScadenzaPwd;
      BGlobalNet.Display(ref ctl, chkScadenzaPwd.Checked);
      ctl = (WebControl)PnlNumPwd;
      BGlobalNet.Display(ref ctl, chkChkPwdImmessa.Checked);

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysPolicyPwd MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysPolicyPwd)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione.ToString();
        chkScadenzaPwd.Checked = MyObj.ScadenzaPwd;
        mbtNumGiorni.Text = MyObj.NumGiorni.ToString();
        chkChkPwdImmessa.Checked = MyObj.ChkPwdImmessa;
        mbtNumMaxChkPwdImmessa.Text = MyObj.NumMaxChkPwdImmessa.ToString();
        chkSistema.Checked = MyObj.Sistema;
        chkSistema.Enabled = this.UtenteEntrato.Developer;

        WebControl ctl = (WebControl)PnlScadenzaPwd;
        BGlobalNet.Display(ref ctl, chkScadenzaPwd.Checked);
        ctl = (WebControl)PnlNumPwd;
        BGlobalNet.Display(ref ctl, chkChkPwdImmessa.Checked);


        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysPolicyPwd.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysPolicyPwd MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysPolicyPwd)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.ScadenzaPwd = chkScadenzaPwd.Checked;
          MyObj.NumGiorni = BConvert.ToByte(mbtNumGiorni.Text);
          MyObj.ChkPwdImmessa = chkChkPwdImmessa.Checked;
          MyObj.NumMaxChkPwdImmessa = BConvert.ToInt(mbtNumMaxChkPwdImmessa.Text);
          MyObj.Sistema = chkSistema.Checked;

          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysPolicyPwd");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysPolicyPwd.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }

  }
}