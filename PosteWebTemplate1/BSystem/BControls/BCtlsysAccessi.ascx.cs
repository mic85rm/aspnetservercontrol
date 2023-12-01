// ************************************************
// *** Classe generata con BStudio [Ver. 3.2.0] ***
// ************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlsysAccessi : BWebControlTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL_sysAccessiOperazioni = "sysAccessiOperazioni";
    private const string K_SP_sysAccessiOperazioni_DELETE = "BSP_" + K_TBL_sysAccessiOperazioni + "_DELETE";

    // DEFINIZIONE PROPRIETA sysAccessiOperazioni
    #region private List<BsysAccessiOperazioni> sysAccessiOperazioni
    private string K_SE_sysAccessiOperazioni = ".sysAccessiOperazioni";
    private List<BsysAccessiOperazioni> sysAccessiOperazioni
    {
      get
      {
        List<BsysAccessiOperazioni> obj;
        obj = (List<BsysAccessiOperazioni>)base.Session[base.ID + K_SE_sysAccessiOperazioni];
        if (obj == null)
        {
          obj = new List<BsysAccessiOperazioni>();
        }
        return obj;
      }
      set
      {
        base.Session[base.ID + K_SE_sysAccessiOperazioni] = value;
      }
    }
    #endregion
    #region private eStatusDetails StatosysAccessiOperazioni
    private string K_VS_STATO_sysAccessiOperazioni = ".StatosysAccessiOperazioni";
    private eStatusDetails StatosysAccessiOperazioni
    {
      get
      {
        return (eStatusDetails)this.ViewState[base.ID + K_VS_STATO_sysAccessiOperazioni];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_sysAccessiOperazioni] = value;
      }
    }
    #endregion

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
    public BTesto mbtDataAccesso
    {
      get
      {
        return this.Internal_mbtDataAccesso;
      }

      set
      {
        this.Internal_mbtDataAccesso = value;
      }
    }
    public BTesto mbtNomeComputer
    {
      get
      {
        return this.Internal_mbtNomeComputer;
      }

      set
      {
        this.Internal_mbtNomeComputer = value;
      }
    }
    public BTesto mbtOraFineLavoro
    {
      get
      {
        return this.Internal_mbtOraFineLavoro;
      }

      set
      {
        this.Internal_mbtOraFineLavoro = value;
      }
    }
    public BTesto mbtIDPadre
    {
      get
      {
        return this.Internal_mbtIDPadre;
      }

      set
      {
        this.Internal_mbtIDPadre = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDataAccesso.ClientID;
      mbtDataAccesso.CtlNextFocus = mbtNomeComputer.ClientID;
      mbtNomeComputer.CtlNextFocus = mbtOraFineLavoro.ClientID;
      mbtOraFineLavoro.CtlNextFocus = mbtIDPadre.ClientID;
      if (this.CtlBtnSalva != null)
        mbtIDPadre.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      DtgsysAccessiOperazioni.RowCommand += dtgsysAccessiOperazioni_RowCommand;
      DtgsysAccessiOperazioni.RowDataBound += dtgsysAccessiOperazioni_RowDataBound;
      DtgsysAccessiOperazioni.RowClick += dtgsysAccessiOperazioni_RowClick;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtID.Enabled = false;
      mbtDataAccesso.Text = "";
      mbtNomeComputer.Text = "";
      mbtOraFineLavoro.Text = "";
      mbtIDPadre.Text = "";

      // DETTAGLIO sysAccessiOperazioni
      StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.VISIONE;
      sysAccessiOperazioni = new List<BsysAccessiOperazioni>();
      DTGsysAccessiOperazioni_Bind();

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDataAccesso.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysAccessi MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysAccessi)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDataAccesso.Text = BGlobal.FormattaData(MyObj.DataAccesso, "dd/MM/yyyy HH:mm");
        mbtNomeComputer.Text = MyObj.NomeComputer;
        mbtOraFineLavoro.Text = BGlobal.FormattaData(MyObj.OraFineLavoro, "dd/MM/yyyy HH:mm");
        mbtIDPadre.Text = MyObj.IDPadre.ToString();

        // CARICA DETTAGLIO sysAccessiOperazioni
        StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.VISIONE;
        sysAccessiOperazioni = MyObj.Operazioni;
        DTGsysAccessiOperazioni_Bind();

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDataAccesso.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("sysAccessi.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysAccessi MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate())
          return null;
        MyObj = (BsysAccessi)Obj;
        if (MyObj != null)
        {
          MyObj.ID = int.Parse(mbtID.Text);
          MyObj.IDSysUtente = this.UtenteEntrato.Username;
          MyObj.DataAccesso = BGlobal.PrendiData(mbtDataAccesso.Text);
          MyObj.NomeComputer = mbtNomeComputer.Text;
          MyObj.OraFineLavoro = BGlobal.PrendiData(mbtOraFineLavoro.Text);
          MyObj.IDPadre = int.Parse(mbtIDPadre.Text);

          // SCRIVI DETTAGLIO sysAccessiOperazioni
          MyObj.Operazioni = sysAccessiOperazioni;
          Ret = MyObj.Update();
        }

        if (Ret)
        {
          ((BsysUtenti)this.UtenteEntrato).WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysAccessi");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        WriteLog("sysAccessi.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysAccessiOperazioni
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysAccesso", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysAccessiOperazioni_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }

    // DEFINIZIONE FUNZIONI sysAccessiOperazioni
    private void NuovoRec_sysAccessiOperazioni(int Index)
    {
      BTesto sysAccessiOperazioni_mbtID = null;
      BCombo sysAccessiOperazioni_mbcIDSysFunzione = null;
      BTesto sysAccessiOperazioni_mbtData = null;
      BTesto sysAccessiOperazioni_mbtOperazione = null;
      if (Index != -1)
      {
        // RECUPERO CONTROLLI
        sysAccessiOperazioni_mbtID = (BTesto)this.DtgsysAccessiOperazioni.Rows[Index].FindControl("mbtID");
        if (sysAccessiOperazioni_mbtID == null) return;
        sysAccessiOperazioni_mbcIDSysFunzione = (BCombo)this.DtgsysAccessiOperazioni.Rows[Index].FindControl("mbcIDSysFunzione");
        if (sysAccessiOperazioni_mbcIDSysFunzione == null) return;
        sysAccessiOperazioni_mbtData = (BTesto)this.DtgsysAccessiOperazioni.Rows[Index].FindControl("mbtData");
        if (sysAccessiOperazioni_mbtData == null) return;
        sysAccessiOperazioni_mbtOperazione = (BTesto)this.DtgsysAccessiOperazioni.Rows[Index].FindControl("mbtOperazione");
        if (sysAccessiOperazioni_mbtOperazione == null) return;

        // INIZIALIZZO CONTROLLI ROW
        sysAccessiOperazioni_mbtID.Text = (Index + 1).ToString();
        sysAccessiOperazioni_mbcIDSysFunzione.SelectedValue = "-1";
        sysAccessiOperazioni_mbtData.Text = "";
        sysAccessiOperazioni_mbtOperazione.Text = "";

        // IMPOSTO FOCUS
        sysAccessiOperazioni_mbcIDSysFunzione.Focus();
      }
    }
    private bool CambiaRec_sysAccessiOperazioni(int index)
    {
      BTesto sysAccessiOperazioni_mbtID = null;
      BCombo sysAccessiOperazioni_mbcIDSysFunzione = null;
      BTesto sysAccessiOperazioni_mbtData = null;
      BTesto sysAccessiOperazioni_mbtOperazione = null;
      BsysAccessiOperazioni Obj = null;
      try
      {
        if (index != -1)
        {
          // RECUPERO CONTROLLI
          sysAccessiOperazioni_mbtID = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtID");
          if (sysAccessiOperazioni_mbtID == null) return false;
          sysAccessiOperazioni_mbcIDSysFunzione = (BCombo)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbcIDSysFunzione");
          if (sysAccessiOperazioni_mbcIDSysFunzione == null) return false;
          sysAccessiOperazioni_mbtData = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtData");
          if (sysAccessiOperazioni_mbtData == null) return false;
          sysAccessiOperazioni_mbtOperazione = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtOperazione");
          if (sysAccessiOperazioni_mbtOperazione == null) return false;
        }

        // RECUPERO OBJECT
        Obj = sysAccessiOperazioni[index];
        if (Obj == null)
          return false;

        // AGGIONO LA COLLECTION
        sysAccessiOperazioni_mbtID.Text = Obj.ID.ToString();
        sysAccessiOperazioni_mbcIDSysFunzione.SelectedValue = Obj.IDSysFunzione.ToString();
        sysAccessiOperazioni_mbtData.Text = BGlobal.FormattaData(Obj.Data);
        sysAccessiOperazioni_mbtOperazione.Text = Obj.Operazione;

        // FOCUS
        sysAccessiOperazioni_mbcIDSysFunzione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("sysAccessi.CambiaRec_sysAccessiOperazioni():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private bool ScriviRec_sysAccessiOperazioni(int index)
    {
      BsysAccessiOperazioni Obj = null;
      BTesto sysAccessiOperazioni_mbtID = null;
      BCombo sysAccessiOperazioni_mbcIDSysFunzione = null;
      BTesto sysAccessiOperazioni_mbtData = null;
      BTesto sysAccessiOperazioni_mbtOperazione = null;
      try
      {
        if (index != -1)
        {
          // RECUPERO CONTROLLI
          sysAccessiOperazioni_mbtID = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtID");
          if (sysAccessiOperazioni_mbtID == null) return false;
          sysAccessiOperazioni_mbcIDSysFunzione = (BCombo)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbcIDSysFunzione");
          if (sysAccessiOperazioni_mbcIDSysFunzione == null) return false;
          sysAccessiOperazioni_mbtData = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtData");
          if (sysAccessiOperazioni_mbtData == null) return false;
          sysAccessiOperazioni_mbtOperazione = (BTesto)this.DtgsysAccessiOperazioni.Rows[index].FindControl("mbtOperazione");
          if (sysAccessiOperazioni_mbtOperazione == null) return false;

          // CONTROLLI DI VALIDITA'
          if (string.IsNullOrEmpty(sysAccessiOperazioni_mbtID.Text))
          {
            this.MsgBox("Campo Obbligatorio");
            sysAccessiOperazioni_mbtID.Focus();
            return false;
          }

          if ((sysAccessiOperazioni_mbcIDSysFunzione.SelectedValue ?? "") == "-1")
          {
            this.MsgBox("Campo Obbligatorio");
            sysAccessiOperazioni_mbcIDSysFunzione.Focus();
            return false;
          }

          if (string.IsNullOrEmpty(sysAccessiOperazioni_mbtData.Text))
          {
            this.MsgBox("Campo Obbligatorio");
            sysAccessiOperazioni_mbtData.Focus();
            return false;
          }

          if (string.IsNullOrEmpty(sysAccessiOperazioni_mbtOperazione.Text))
          {
            this.MsgBox("Campo Obbligatorio");
            sysAccessiOperazioni_mbtOperazione.Focus();
            return false;
          }

          // RECUPERO OBJECT
          Obj = sysAccessiOperazioni[index];
          if (Obj == null) return false;

          // AGGIORNO LA COLLECTION
          Obj.ID = int.Parse(sysAccessiOperazioni_mbtID.Text);
          Obj.IDSysFunzione = int.Parse(sysAccessiOperazioni_mbcIDSysFunzione.SelectedValue);
          Obj.Data = BGlobal.PrendiData(sysAccessiOperazioni_mbtData.Text);
          Obj.Operazione = sysAccessiOperazioni_mbtOperazione.Text;
          sysAccessiOperazioni[index] = Obj;
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        WriteLog("sysAccessi.ScriviRec_sysAccessiOperazioni():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    private void DTGsysAccessiOperazioni_Bind()
    {
      try
      {
        this.DtgsysAccessiOperazioni.DataSource = sysAccessiOperazioni;
        this.DtgsysAccessiOperazioni.DataBind();
      }
      catch (Exception ex)
      {
        WriteLog("sysAccessi.DTGsysAccessiOperazioni_Bind():", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }

    private bool CheckStatesysAccessiOperazioni()
    {
      if (StatosysAccessiOperazioni == BWebControlTableBase.eStatusDetails.VISIONE)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA sysAccessiOperazioni

    private void dtgsysAccessiOperazioni_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      var switchExpr = e.CommandName.ToUpper();
      switch (switchExpr)
      {
        case "BNEW":
          {
            sysAccessiOperazioni.Add(new BsysAccessiOperazioni(this.DB));
            StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.NUOVO;
            this.DtgsysAccessiOperazioni.EditIndex = sysAccessiOperazioni.Count - 1;
            DTGsysAccessiOperazioni_Bind();
            this.DisabledButton(true);
            // NUOVO REC
            NuovoRec_sysAccessiOperazioni(sysAccessiOperazioni.Count - 1);
            break;
          }

        case "BCANCEL":
          {
            if (StatosysAccessiOperazioni == BWebControlTableBase.eStatusDetails.NUOVO)
            {
              if (sysAccessiOperazioni.Count > 0)
                sysAccessiOperazioni.RemoveAt(sysAccessiOperazioni.Count - 1);
            }

            StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.VISIONE;
            this.DtgsysAccessiOperazioni.EditIndex = -1;
            DTGsysAccessiOperazioni_Bind();
            this.DisabledButton(false);
            break;
          }

        case "BSAVE":
          {
            int index = -1;
            if (StatosysAccessiOperazioni == BWebControlTableBase.eStatusDetails.NUOVO)
            {
              index = sysAccessiOperazioni.Count - 1;
            }
            else
            {
              index = int.Parse(e.CommandArgument.ToString());
            }

            if (index == -1)
              return;
            // SCRIVI REC
            if (ScriviRec_sysAccessiOperazioni(index))
            {
              StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.VISIONE;
              this.DtgsysAccessiOperazioni.EditIndex = -1;
              DTGsysAccessiOperazioni_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BEDIT":
          {
            // CAMBIA REC
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1)
              return;
            StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.MODIFICA;
            this.DtgsysAccessiOperazioni.EditIndex = index;
            DTGsysAccessiOperazioni_Bind();
            this.DisabledButton(true);
            if (!CambiaRec_sysAccessiOperazioni(index))
            {
              base.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
              this.DtgsysAccessiOperazioni.EditIndex = -1;
              DTGsysAccessiOperazioni_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BDELETE":
          {
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1)
              return;
            sysAccessiOperazioni.RemoveAt(index);
            this.DtgsysAccessiOperazioni.EditIndex = -1;
            DTGsysAccessiOperazioni_Bind();
            break;
          }
      }
    }

    private void dtgsysAccessiOperazioni_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BTesto sysAccessiOperazioni_mbtID = null;
      BCombo sysAccessiOperazioni_mbcIDSysFunzione = null;
      BTesto sysAccessiOperazioni_mbtData = null;
      BTesto sysAccessiOperazioni_mbtOperazione = null;
      BButton BtnSalva = null;
      BButton BtnNew = null;
      try
      {
        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
        {
          BtnNew = (BButton)e.Row.FindControl("BtnNew");
          if (BtnNew == null)
            return;
          if (StatosysAccessiOperazioni != BWebControlTableBase.eStatusDetails.VISIONE)
          {
            BtnNew.Enabled = false;
          }
          else
          {
            BtnNew.Enabled = true;
          }
        }

        if (e.Row.RowType == DataControlRowType.DataRow & this.DtgsysAccessiOperazioni.EditIndex != -1)
        {
          // RECUPERO CONTROLLI
          sysAccessiOperazioni_mbtID = (BTesto)e.Row.FindControl("mbtID");
          if (sysAccessiOperazioni_mbtID == null)
            return;
          sysAccessiOperazioni_mbcIDSysFunzione = (BCombo)e.Row.FindControl("mbcIDSysFunzione");
          if (sysAccessiOperazioni_mbcIDSysFunzione == null)
            return;
          sysAccessiOperazioni_mbtData = (BTesto)e.Row.FindControl("mbtData");
          if (sysAccessiOperazioni_mbtData == null)
            return;
          sysAccessiOperazioni_mbtOperazione = (BTesto)e.Row.FindControl("mbtOperazione");
          if (sysAccessiOperazioni_mbtOperazione == null)
            return;
          BtnSalva = (BButton)e.Row.FindControl("BtnSalva");
          if (BtnSalva == null)
            return;
          // IMPOSTA ATRIBUTES INVIO
          sysAccessiOperazioni_mbtID.INVIO = true;
          sysAccessiOperazioni_mbtID.CtlNextFocus = sysAccessiOperazioni_mbcIDSysFunzione.ClientID;
          sysAccessiOperazioni_mbtID.SetAttributes();
          sysAccessiOperazioni_mbcIDSysFunzione.INVIO = true;
          sysAccessiOperazioni_mbcIDSysFunzione.CtlNextFocus = sysAccessiOperazioni_mbtData.ClientID;
          sysAccessiOperazioni_mbcIDSysFunzione.Init(this.DB.Setting);
          sysAccessiOperazioni_mbcIDSysFunzione.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
          sysAccessiOperazioni_mbcIDSysFunzione.SetAttributes();
          sysAccessiOperazioni_mbtData.INVIO = true;
          sysAccessiOperazioni_mbtData.CtlNextFocus = sysAccessiOperazioni_mbtOperazione.ClientID;
          sysAccessiOperazioni_mbtData.SetAttributes();
          sysAccessiOperazioni_mbtOperazione.INVIO = true;
          sysAccessiOperazioni_mbtOperazione.CtlNextFocus = BtnSalva.ClientID;
          sysAccessiOperazioni_mbtOperazione.SetAttributes();
        }
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

        ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysAccessi.DtgsysAccessiOperazioni_RowDataBound():", "", BEnumerations.eSeverity.ERROR, IDAccesso, this.Page);
      }
    }

    private void dtgsysAccessiOperazioni_RowClick(int RowIndex)
    {
      int index = RowIndex;
      if (index == -1)
        return;
      if (!Enabled)
        return;
      StatosysAccessiOperazioni = BWebControlTableBase.eStatusDetails.MODIFICA;
      this.DtgsysAccessiOperazioni.EditIndex = index;
      DTGsysAccessiOperazioni_Bind();
      this.DisabledButton(true);
      if (!CambiaRec_sysAccessiOperazioni(index))
      {
        this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
        this.DtgsysAccessiOperazioni.EditIndex = -1;
        DTGsysAccessiOperazioni_Bind();
        this.DisabledButton(false);
      }
    }

  }
}