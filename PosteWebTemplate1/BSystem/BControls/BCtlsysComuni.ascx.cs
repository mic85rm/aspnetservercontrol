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
using System.Web.UI.WebControls;
using static BArts.BEnumerations;
using static PosteWebTemplate1.ModLog;

namespace PosteWebTemplate1
{
  public partial class BCtlsysComuni : BWebControlTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL_sysComuniQuartieri = "sysComuniQuartieri";
    private const string K_SP_sysComuniQuartieri_DELETE = "BSP_" + K_TBL_sysComuniQuartieri + "_DELETE";

    // DEFINIZIONE PROPRIETA sysComuniQuartieri
    #region private List<BsysComuniQuartieri> sysComuniQuartieri
    private string K_SE_sysComuniQuartieri = ".sysComuniQuartieri";
    private List<BsysComuniQuartieri> sysComuniQuartieri
    {
      get
      {
        List<BsysComuniQuartieri> obj;
        obj = (List<BsysComuniQuartieri>)Session[base.ID + K_SE_sysComuniQuartieri];
        if (obj == null)
        {
          obj = new List<BsysComuniQuartieri>();
        }
        return obj;
      }
      set
      {
        Session[base.ID + K_SE_sysComuniQuartieri] = value;
      }
    }
    #endregion
    #region private eStatusDetails StatosysComuniQuartieri
    private string K_VS_STATO_sysComuniQuartieri = ".StatosysComuniQuartieri";
    private eStatusDetails StatosysComuniQuartieri
    {
      get
      {
        return (eStatusDetails)this.ViewState[base.ID + K_VS_STATO_sysComuniQuartieri];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_sysComuniQuartieri] = value;
      }
    }
    #endregion 

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
    public BTesto mbtCodiceIstat
    {
      get
      {
        return this.Internal_mbtCodiceIstat;
      }
      set
      {
        this.Internal_mbtCodiceIstat = value;
      }
    }
    public BTesto mbtCodiceIstatAsl
    {
      get
      {
        return this.Internal_mbtCodiceIstatAsl;
      }
      set
      {
        this.Internal_mbtCodiceIstatAsl = value;
      }
    }
    public BTesto mbtCAP
    {
      get
      {
        return this.Internal_mbtCAP;
      }
      set
      {
        this.Internal_mbtCAP = value;
      }
    }
    public BCombo mbcIDProvincia
    {
      get
      {
        return this.Internal_mbcIDProvincia;
      }
      set
      {
        this.Internal_mbcIDProvincia = value;
      }
    }
    public BTesto mbtDataIstituzione
    {
      get
      {
        return this.Internal_mbtDataIstituzione;
      }
      set
      {
        this.Internal_mbtDataIstituzione = value;
      }
    }
    public BTesto mbtDataCessazione
    {
      get
      {
        return this.Internal_mbtDataCessazione;
      }
      set
      {
        this.Internal_mbtDataCessazione = value;
      }
    }
    public BTesto mbtPatrono
    {
      get
      {
        return this.Internal_mbtPatrono;
      }
      set
      {
        this.Internal_mbtPatrono = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtCodiceIstat.ClientID;
      mbtCodiceIstat.CtlNextFocus = mbtCodiceIstatAsl.ClientID;
      mbtCodiceIstatAsl.CtlNextFocus = mbtCAP.ClientID;
      mbtCAP.CtlNextFocus = mbcIDProvincia.ClientID;
      mbcIDProvincia.CtlNextFocus = mbtDataIstituzione.ClientID;
      mbtDataIstituzione.CtlNextFocus = mbtDataCessazione.ClientID;
      mbtDataCessazione.CtlNextFocus = mbtPatrono.ClientID;
      if (this.CtlBtnSalva != null) mbtPatrono.CtlNextFocus = this.CtlBtnSalva.ClientID;

      base.SetAttributes_Invio();
    }
    public override void SetAttributes_Other()
    {
      this.mbcIDProvincia.Init(this.DB.Setting);
      this.mbcIDProvincia.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));


      this.Internal_mbtDataIstituzione_CalendarExtender.PopupButtonID = this.mbtDataIstituzione.HelpButtonClientID;
      this.Internal_mbtDataCessazione_CalendarExtender.PopupButtonID = this.mbtDataCessazione.HelpButtonClientID;

      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      dtgsysComuniQuartieri.RowCommand += dtgsysComuniQuartieri_RowCommand;
      dtgsysComuniQuartieri.RowDataBound += dtgsysComuniQuartieri_RowDataBound;
      dtgsysComuniQuartieri.RowClick += dtgsysComuniQuartieri_RowClick;

      base.SetAttributes_AddEvents();
    }

    protected override bool CheckBeforeUpdate()
    {
      bool ret = true;
      if (String.IsNullOrEmpty(mbtID.Text))
      {
        this.AddCheckBeforeUpdateAlert("ID Comune obbligatorio.", (WebControl)mbtID);
        ret = false;
      }
      if (String.IsNullOrEmpty(mbtDescrizione.Text))
      {
        this.AddCheckBeforeUpdateAlert("Descrizione obbligatoria.", (WebControl)mbtDescrizione);
        ret = false;
      }
      return ret;
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "";
      mbtID.Enabled = true;
      mbtDescrizione.Text = "";
      mbtCodiceIstat.Text = "";
      mbtCodiceIstatAsl.Text = "";
      mbtCAP.Text = "";
      mbcIDProvincia.SelectedValue = "-1";
      mbtDataIstituzione.Text = "";
      mbtDataCessazione.Text = "";
      mbtPatrono.Text = "";

      // DETTAGLIO sysComuniQuartieri
      this.StatosysComuniQuartieri = eStatusDetails.VISIONE;
      this.sysComuniQuartieri = new List<BsysComuniQuartieri>();
      this.DTGsysComuniQuartieri_Bind();

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtID.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysComuni MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysComuni)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione.ToString();
        mbtCodiceIstat.Text = MyObj.CodiceIstat.ToString();
        mbtCodiceIstatAsl.Text = MyObj.CodiceIstatAsl.ToString();
        mbtCAP.Text = MyObj.CAP.ToString();
        mbcIDProvincia.SelectedValue = MyObj.IDProvincia.ToString();
        mbtDataIstituzione.Text = BGlobal.FormattaData(MyObj.DataIstituzione);
        mbtDataCessazione.Text = BGlobal.FormattaData(MyObj.DataCessazione);
        mbtPatrono.Text = MyObj.Patrono.ToString();

        // CARICA DETTAGLIO sysComuniQuartieri
        this.StatosysComuniQuartieri = eStatusDetails.VISIONE;
        this.sysComuniQuartieri = MyObj.Quartieri;
        this.DTGsysComuniQuartieri_Bind();


        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtID.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysComuni.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysComuni MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysComuni)Obj;
        if (MyObj != null)
        {
          MyObj.ID = mbtID.Text;
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.CodiceIstat = mbtCodiceIstat.Text;
          MyObj.CodiceIstatAsl = mbtCodiceIstatAsl.Text;
          MyObj.CAP = mbtCAP.Text;
          MyObj.IDProvincia = mbcIDProvincia.SelectedValue;
          MyObj.DataIstituzione = BGlobal.PrendiData(mbtDataIstituzione.Text);
          MyObj.DataCessazione = BGlobal.PrendiData(mbtDataCessazione.Text);
          MyObj.Patrono = mbtPatrono.Text;

          // SCRIVI DETTAGLIO sysComuniQuartieri
          MyObj.Quartieri = this.sysComuniQuartieri;

          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysComuni");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysComuni.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysComuniQuartieri
      DB.ClearParameter();
      DB.AddParameter("@IDComune", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_sysComuniQuartieri_DELETE, CommandType.StoredProcedure);

      return base.DeleteRowsRelation(ParamsKey);
    }

    // DEFINIZIONE FUNZIONI sysComuniQuartieri
    private void NuovoRec_sysComuniQuartieri(int Index)
    {
      BTesto sysComuniQuartieri_mbtIDQuartiere = null;
      BTesto sysComuniQuartieri_mbtDescrizione = null;
      if (Index != -1)
      {
        // RECUPERO CONTROLLI
        sysComuniQuartieri_mbtIDQuartiere = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtIDQuartiere");
        if (sysComuniQuartieri_mbtIDQuartiere == null) return;
        sysComuniQuartieri_mbtDescrizione = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtDescrizione");
        if (sysComuniQuartieri_mbtDescrizione == null) return;

        // INIZIALIZZO CONTROLLI ROW
        sysComuniQuartieri_mbtIDQuartiere.Text = (Index + 1).ToString();
        sysComuniQuartieri_mbtDescrizione.Text = "";

        // IMPOSTO FOCUS
        sysComuniQuartieri_mbtDescrizione.Focus();
      }
    }
    private bool CambiaRec_sysComuniQuartieri(int Index)
    {
      BTesto sysComuniQuartieri_mbtIDQuartiere = null;
      BTesto sysComuniQuartieri_mbtDescrizione = null;

      BsysComuniQuartieri Obj = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          sysComuniQuartieri_mbtIDQuartiere = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtIDQuartiere");
          if (sysComuniQuartieri_mbtIDQuartiere == null) return false;
          sysComuniQuartieri_mbtDescrizione = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtDescrizione");
          if (sysComuniQuartieri_mbtDescrizione == null) return false;

        }

        // RECUPERO OBJECT
        Obj = (BsysComuniQuartieri)this.sysComuniQuartieri[Index];
        if (Obj == null) return false;

        // AGGIONO LA COLLECTION
        sysComuniQuartieri_mbtIDQuartiere.Text = Obj.IDQuartiere.ToString();
        sysComuniQuartieri_mbtDescrizione.Text = Obj.Descrizione.ToString();


        // FOCUS
        sysComuniQuartieri_mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso;
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysComuni.CambiaRec_sysComuniQuartieri():", "", eSeverity.ERROR, IDAccesso, this.Page);
        return false;
      }
    }
    private bool ScriviRec_sysComuniQuartieri(int Index)
    {
      BsysComuniQuartieri Obj = null;
      BTesto sysComuniQuartieri_mbtIDQuartiere = null;
      BTesto sysComuniQuartieri_mbtDescrizione = null;

      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          sysComuniQuartieri_mbtIDQuartiere = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtIDQuartiere");
          if (sysComuniQuartieri_mbtIDQuartiere == null) return false;
          sysComuniQuartieri_mbtDescrizione = (BTesto)dtgsysComuniQuartieri.Rows[Index].FindControl("mbtDescrizione");
          if (sysComuniQuartieri_mbtDescrizione == null) return false;

          // CONTROLLI DI VALIDITA'
          if (sysComuniQuartieri_mbtIDQuartiere.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            sysComuniQuartieri_mbtIDQuartiere.Focus();
            return false;
          }
          if (sysComuniQuartieri_mbtDescrizione.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            sysComuniQuartieri_mbtDescrizione.Focus();
            return false;
          }

          // RECUPERO OBJECT
          Obj = (BsysComuniQuartieri)this.sysComuniQuartieri[Index];
          if (Obj == null) return false;

          // AGGIORNO LA COLLECTION
          Obj.IDQuartiere = int.Parse(sysComuniQuartieri_mbtIDQuartiere.Text);
          Obj.Descrizione = sysComuniQuartieri_mbtDescrizione.Text;

          this.sysComuniQuartieri[Index] = Obj;
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso;
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysComuni.ScriviRec_sysComuniQuartieri():", "", eSeverity.ERROR, IDAccesso, this.Page);
        return false;
      }
    }
    private void DTGsysComuniQuartieri_Bind()
    {
      try
      {
        dtgsysComuniQuartieri.DataSource = this.sysComuniQuartieri;
        dtgsysComuniQuartieri.DataBind();
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso;
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysComuni.DTGsysComuniQuartieri_Bind():", "", eSeverity.ERROR, IDAccesso, this.Page);
      }
    }
    private bool CheckStatesysComuniQuartieri()
    {
      if (this.StatosysComuniQuartieri == eStatusDetails.VISIONE)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA sysComuniQuartieri
    private void dtgsysComuniQuartieri_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "BNEW":
          {
            this.sysComuniQuartieri.Add(new BsysComuniQuartieri(this.DB));
            this.StatosysComuniQuartieri = eStatusDetails.NUOVO;
            dtgsysComuniQuartieri.EditIndex = this.sysComuniQuartieri.Count - 1;
            this.DTGsysComuniQuartieri_Bind();
            this.DisabledButton(true);
            // NUOVO REC
            this.NuovoRec_sysComuniQuartieri(this.sysComuniQuartieri.Count - 1);
            break;
          }
        case "BCANCEL":
          {
            if (this.StatosysComuniQuartieri == eStatusDetails.NUOVO)
            {
              if (this.sysComuniQuartieri.Count > 0) this.sysComuniQuartieri.RemoveAt(this.sysComuniQuartieri.Count - 1);
            }
            this.StatosysComuniQuartieri = eStatusDetails.VISIONE;
            dtgsysComuniQuartieri.EditIndex = -1;
            this.DTGsysComuniQuartieri_Bind();
            this.DisabledButton(false);
            break;
          }
        case "BSAVE":
          {
            int index = -1;
            if (this.StatosysComuniQuartieri == eStatusDetails.NUOVO)
            {
              index = this.sysComuniQuartieri.Count - 1;
            }
            else
            {
              index = int.Parse(e.CommandArgument.ToString());
            }
            if (index == -1) return;
            // SCRIVI REC
            if (this.ScriviRec_sysComuniQuartieri(index))
            {
              this.StatosysComuniQuartieri = eStatusDetails.VISIONE;
              dtgsysComuniQuartieri.EditIndex = -1;
              this.DTGsysComuniQuartieri_Bind();
              this.DisabledButton(false);
            }
            break;
          }
        case "BEDIT":
          {
            // CAMBIA REC
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1) return;
            this.StatosysComuniQuartieri = eStatusDetails.MODIFICA;
            dtgsysComuniQuartieri.EditIndex = index;
            this.DTGsysComuniQuartieri_Bind();
            this.DisabledButton(true);
            if (!this.CambiaRec_sysComuniQuartieri(index))
            {
              this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
              dtgsysComuniQuartieri.EditIndex = -1;
              this.DTGsysComuniQuartieri_Bind();
              this.DisabledButton(false);
            }
            break;
          }
        case "BDELETE":
          {
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1) return;
            this.sysComuniQuartieri.RemoveAt(index);
            dtgsysComuniQuartieri.EditIndex = -1;
            this.DTGsysComuniQuartieri_Bind();
            break;
          }
      }
    }
    private void dtgsysComuniQuartieri_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BTesto sysComuniQuartieri_mbtIDQuartiere = null;
      BTesto sysComuniQuartieri_mbtDescrizione = null;

      BButton BtnSalva = null;
      BButton BtnNew = null;
      try
      {
        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
        {
          BtnNew = (BButton)e.Row.FindControl("BtnNew");
          if (BtnNew == null) return;
          if (this.StatosysComuniQuartieri != eStatusDetails.VISIONE)
          {
            BtnNew.Enabled = false;
          }
          else
          {
            BtnNew.Enabled = true;
          }
        }
        if (e.Row.RowType == DataControlRowType.DataRow & dtgsysComuniQuartieri.EditIndex != -1)
        {
          // RECUPERO CONTROLLI
          sysComuniQuartieri_mbtIDQuartiere = (BTesto)e.Row.FindControl("mbtIDQuartiere");
          if (sysComuniQuartieri_mbtIDQuartiere == null) return;
          sysComuniQuartieri_mbtDescrizione = (BTesto)e.Row.FindControl("mbtDescrizione");
          if (sysComuniQuartieri_mbtDescrizione == null) return;

          BtnSalva = (BButton)e.Row.FindControl("BtnSalva");
          if (BtnSalva == null) return;
          // IMPOSTA ATRIBUTES INVIO
          sysComuniQuartieri_mbtIDQuartiere.INVIO = true;
          sysComuniQuartieri_mbtIDQuartiere.CtlNextFocus = sysComuniQuartieri_mbtDescrizione.ClientID;
          sysComuniQuartieri_mbtIDQuartiere.SetAttributes();

          sysComuniQuartieri_mbtDescrizione.INVIO = true;
          sysComuniQuartieri_mbtDescrizione.CtlNextFocus = BtnSalva.ClientID;
          sysComuniQuartieri_mbtDescrizione.SetAttributes();


        }
      }
      catch (Exception ex)
      {
        int IDAccesso = -1;
        string IDSysUtente = "";
        if (UtenteEntrato != null && !UtenteEntrato.IsNothing)
        {
          IDAccesso = this.UtenteEntrato.IDAccesso;
          IDSysUtente = this.UtenteEntrato.Username;
        }
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysComuni.DtgsysComuniQuartieri_RowDataBound():", "", eSeverity.ERROR, IDAccesso, this.Page);
      }
    }
    private void dtgsysComuniQuartieri_RowClick(int RowIndex)
    {
      int index = RowIndex;
      if (index == -1) return;
      if (!this.Enabled) return;
      this.StatosysComuniQuartieri = eStatusDetails.MODIFICA;
      dtgsysComuniQuartieri.EditIndex = index;
      this.DTGsysComuniQuartieri_Bind();
      this.DisabledButton(true);
      if (!this.CambiaRec_sysComuniQuartieri(index))
      {
        this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
        dtgsysComuniQuartieri.EditIndex = -1;
        this.DTGsysComuniQuartieri_Bind();
        this.DisabledButton(false);
      }
    }

  }
}