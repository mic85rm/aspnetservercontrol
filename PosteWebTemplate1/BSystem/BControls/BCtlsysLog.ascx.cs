// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.1] ***
// ************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlsysLog : BWebControlTableBase
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
    public BCombo mbcIDSysAccesso
    {
      get
      {
        return this.Internal_mbcIDSysAccesso;
      }

      set
      {
        this.Internal_mbcIDSysAccesso = value;
      }
    }
    public BTesto mbtData
    {
      get
      {
        return this.Internal_mbtData;
      }

      set
      {
        this.Internal_mbtData = value;
      }
    }
    public BTesto mbtOrigine
    {
      get
      {
        return this.Internal_mbtOrigine;
      }

      set
      {
        this.Internal_mbtOrigine = value;
      }
    }
    public BTesto mbtMessaggio
    {
      get
      {
        return this.Internal_mbtMessaggio;
      }

      set
      {
        this.Internal_mbtMessaggio = value;
      }
    }
    public BCombo mbcIDSysSeverity
    {
      get
      {
        return this.Internal_mbcIDSysSeverity;
      }

      set
      {
        this.Internal_mbcIDSysSeverity = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbcIDSysAccesso.ClientID;
      mbcIDSysAccesso.CtlNextFocus = mbtData.ClientID;
      mbtData.CtlNextFocus = mbtOrigine.ClientID;
      mbtOrigine.CtlNextFocus = mbtMessaggio.ClientID;
      mbtMessaggio.CtlNextFocus = mbcIDSysSeverity.ClientID;
      if (this.CtlBtnSalva != null) mbcIDSysSeverity.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      mbcIDSysAccesso.Init(this.DB.Setting);
      mbcIDSysAccesso.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      mbcIDSysSeverity.Init(this.DB.Setting);
      mbcIDSysSeverity.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));
      base.SetAttributes_Other();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = (-1).ToString();
      mbtID.Enabled = false;
      mbcIDSysAccesso.SelectedValue = "-1";
      mbtData.Text = "";
      mbtOrigine.Text = "";
      mbtMessaggio.Text = "";
      mbcIDSysSeverity.SelectedValue = "-1";

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      // CtlControlloForFirstFocus.Focus()
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysLog MyObj = null;
      try
      {
        if (Obj == null)
          return false;
        MyObj = (BsysLog)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbcIDSysAccesso.SelectedValue = MyObj.IDSysAccesso.ToString();
        mbtData.Text = BGlobal.FormattaData(MyObj.Data);
        mbtOrigine.Text = MyObj.Origine;
        mbtMessaggio.Text = MyObj.Messaggio;
        mbcIDSysSeverity.SelectedValue = MyObj.IDSysSeverity.ToString();

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        // CtlControlloForFirstFocus.Focus()
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysLog.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysLog MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysLog)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.IDSysAccesso = BConvert.ToInt(mbcIDSysAccesso.SelectedValue);
          MyObj.Data = BGlobal.PrendiData(mbtData.Text);
          MyObj.Origine = mbtOrigine.Text;
          MyObj.Messaggio = mbtMessaggio.Text;
          MyObj.IDSysSeverity = BConvert.ToInt(mbcIDSysSeverity.SelectedValue);
          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysLog");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysLog.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

  } //END CLASS
} //END NAMESPACE