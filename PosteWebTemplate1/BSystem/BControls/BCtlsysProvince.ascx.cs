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
  public partial class BCtlsysProvince : BWebControlTableBase
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
    public BCombo mbcIDRegione
    {
      get
      {
        return this.Internal_mbcIDRegione;
      }
      set
      {
        this.Internal_mbcIDRegione = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbcIDRegione.ClientID;
      if (this.CtlBtnSalva != null) mbcIDRegione.CtlNextFocus = this.CtlBtnSalva.ClientID;

      base.SetAttributes_Invio();
    }
    public override void SetAttributes_Other()
    {
      this.mbcIDRegione.Init(this.DB.Setting);
      this.mbcIDRegione.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));


      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "";
      mbtID.Enabled = true;
      mbtDescrizione.Text = "";
      mbcIDRegione.SelectedValue = "-1";

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysProvince MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysProvince)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione.ToString();
        mbcIDRegione.SelectedValue = MyObj.IDRegione.ToString();


        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProvince.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysProvince MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysProvince)Obj;
        if (MyObj != null)
        {
          MyObj.ID = mbtID.Text;
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.IDRegione = mbcIDRegione.SelectedValue;

          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysProvince");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProvince.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }

  }
}