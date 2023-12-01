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
  public partial class BCtlsysSistemi : BWebControlTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL_sysSistemiAttributi = "sysSistemiAttributi";
    private const string K_SP_sysSistemiAttributi_DELETE = "BSP_" + K_TBL_sysSistemiAttributi + "_DELETE";

    // DEFINIZIONE PROPRIETA sysSistemiAttributi
    private string K_SE_sysSistemiAttributi = ".sysSistemiAttributi";
    private List<BsysSistemiAttributi> sysSistemiAttributi
    {
      get
      {
        List<BsysSistemiAttributi> obj;
        obj = (List<BsysSistemiAttributi>)Session[base.ID + K_SE_sysSistemiAttributi];
        if (obj == null)
        {
          obj = new List<BsysSistemiAttributi>();
        }
        return obj;
      }
      set
      {
        Session[base.ID + K_SE_sysSistemiAttributi] = value;
      }
    }
    private string K_VS_STATO_sysSistemiAttributi = ".StatosysSistemiAttributi";
    private eStatusDetails StatosysSistemiAttributi
    {
      get
      {
        return (eStatusDetails)this.ViewState[base.ID + K_VS_STATO_sysSistemiAttributi];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_sysSistemiAttributi] = value;
      }
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
    public BTesto mbtDataInizio
    {
      get
      {
        return this.Internal_mbtDataInizio;
      }
      set
      {
        this.Internal_mbtDataInizio = value;
      }
    }
    public BTesto mbtDataFine
    {
      get
      {
        return this.Internal_mbtDataFine;
      }
      set
      {
        this.Internal_mbtDataFine = value;
      }
    }
    public BCheck chkAttivo
    {
      get
      {
        return this.Internal_chkAttivo;
      }
      set
      {
        this.Internal_chkAttivo = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtDataInizio.ClientID;
      mbtDataInizio.CtlNextFocus = mbtDataFine.ClientID;
      mbtDataFine.CtlNextFocus = chkAttivo.ClientID;
      if (this.CtlBtnSalva != null) chkAttivo.CtlNextFocus = this.CtlBtnSalva.ClientID;

      base.SetAttributes_Invio();
    }
    public override void SetAttributes_Other()
    {

      this.Internal_mbtDataInizio_CalendarExtender.PopupButtonID = this.mbtDataInizio.HelpButtonClientID;
      this.Internal_mbtDataFine_CalendarExtender.PopupButtonID = this.mbtDataFine.HelpButtonClientID;

      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      dtgsysSistemiAttributi.RowCommand += dtgsysSistemiAttributi_RowCommand;
      dtgsysSistemiAttributi.RowDataBound += dtgsysSistemiAttributi_RowDataBound;
      dtgsysSistemiAttributi.RowClick += dtgsysSistemiAttributi_RowClick;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtID.Enabled = false;
      mbtDescrizione.Text = "";
      mbtDataInizio.Text = "";
      mbtDataFine.Text = "";
      chkAttivo.Checked = false;

      // DETTAGLIO sysSistemiAttributi
      this.StatosysSistemiAttributi = eStatusDetails.VISIONE;
      this.sysSistemiAttributi = new List<BsysSistemiAttributi>();
      this.DTGsysSistemiAttributi_Bind();

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysSistemi MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysSistemi)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione.ToString();
        mbtDataInizio.Text = BGlobal.FormattaData(MyObj.DataInizio);
        mbtDataFine.Text = BGlobal.FormattaData(MyObj.DataFine);
        chkAttivo.Checked = MyObj.Attivo;

        // CARICA DETTAGLIO sysSistemiAttributi
        this.StatosysSistemiAttributi = eStatusDetails.VISIONE;
        this.sysSistemiAttributi = MyObj.Attributi;
        this.DTGsysSistemiAttributi_Bind();


        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysSistemi.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysSistemi MyObj = null;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysSistemi)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.DataInizio = BGlobal.PrendiData(mbtDataInizio.Text);
          MyObj.DataFine = BGlobal.PrendiData(mbtDataFine.Text);
          MyObj.Attivo = chkAttivo.Checked;

          // SCRIVI DETTAGLIO sysSistemiAttributi
          MyObj.Attributi = this.sysSistemiAttributi;

          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysSistemi");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysSistemi.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysSistemiAttributi
      DB.ClearParameter();
      DB.AddParameter("@IDSysSistema", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_sysSistemiAttributi_DELETE, CommandType.StoredProcedure);

      return base.DeleteRowsRelation(ParamsKey);
    }
    // DEFINIZIONE FUNZIONI sysSistemiAttributi
    private void NuovoRec_sysSistemiAttributi(int Index)
    {
      BTesto sysSistemiAttributi_mbtChiave = null;
      BTesto sysSistemiAttributi_mbtValore = null;
      if (Index != -1)
      {
        // RECUPERO CONTROLLI
        sysSistemiAttributi_mbtChiave = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtChiave");
        if (sysSistemiAttributi_mbtChiave == null) return;
        sysSistemiAttributi_mbtValore = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtValore");
        if (sysSistemiAttributi_mbtValore == null) return;

        // INIZIALIZZO CONTROLLI ROW
        sysSistemiAttributi_mbtChiave.Text = "";
        sysSistemiAttributi_mbtValore.Text = "";

        // IMPOSTO FOCUS
        // PRIMO CONTROLLO NON IDENTIFICATO
      }
    }
    private bool CambiaRec_sysSistemiAttributi(int Index)
    {
      BTesto sysSistemiAttributi_mbtChiave = null;
      BTesto sysSistemiAttributi_mbtValore = null;

      BsysSistemiAttributi Obj = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          sysSistemiAttributi_mbtChiave = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtChiave");
          if (sysSistemiAttributi_mbtChiave == null) return false;
          sysSistemiAttributi_mbtValore = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtValore");
          if (sysSistemiAttributi_mbtValore == null) return false;

        }

        // RECUPERO OBJECT
        Obj = (BsysSistemiAttributi)this.sysSistemiAttributi[Index];
        if (Obj == null) return false;

        // AGGIONO LA COLLECTION
        sysSistemiAttributi_mbtChiave.Text = Obj.Chiave.ToString();
        sysSistemiAttributi_mbtValore.Text = Obj.Valore.ToString();


        // FOCUS
        // PRIMO CONTROLLO NON IDENTIFICATO
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
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysSistemi.CambiaRec_sysSistemiAttributi():", "", eSeverity.ERROR, IDAccesso, this.Page);
        return false;
      }
    }
    private bool ScriviRec_sysSistemiAttributi(int Index)
    {
      BsysSistemiAttributi Obj = null;
      BTesto sysSistemiAttributi_mbtChiave = null;
      BTesto sysSistemiAttributi_mbtValore = null;

      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          sysSistemiAttributi_mbtChiave = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtChiave");
          if (sysSistemiAttributi_mbtChiave == null) return false;
          sysSistemiAttributi_mbtValore = (BTesto)dtgsysSistemiAttributi.Rows[Index].FindControl("mbtValore");
          if (sysSistemiAttributi_mbtValore == null) return false;

          // CONTROLLI DI VALIDITA'
          if (sysSistemiAttributi_mbtChiave.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            sysSistemiAttributi_mbtChiave.Focus();
            return false;
          }
          if (sysSistemiAttributi_mbtValore.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            sysSistemiAttributi_mbtValore.Focus();
            return false;
          }

          // RECUPERO OBJECT
          Obj = (BsysSistemiAttributi)this.sysSistemiAttributi[Index];
          if (Obj == null) return false;

          // AGGIORNO LA COLLECTION
          Obj.Chiave = sysSistemiAttributi_mbtChiave.Text;
          Obj.Valore = sysSistemiAttributi_mbtValore.Text;

          this.sysSistemiAttributi[Index] = Obj;
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
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysSistemi.ScriviRec_sysSistemiAttributi():", "", eSeverity.ERROR, IDAccesso, this.Page);
        return false;
      }
    }
    private void DTGsysSistemiAttributi_Bind()
    {
      try
      {
        dtgsysSistemiAttributi.DataSource = this.sysSistemiAttributi;
        dtgsysSistemiAttributi.DataBind();
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
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysSistemi.DTGsysSistemiAttributi_Bind():", "", eSeverity.ERROR, IDAccesso, this.Page);
      }
    }
    private bool CheckStatesysSistemiAttributi()
    {
      if (this.StatosysSistemiAttributi == eStatusDetails.VISIONE)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA sysSistemiAttributi
    private void dtgsysSistemiAttributi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "BNEW":
          {
            this.sysSistemiAttributi.Add(new BsysSistemiAttributi(this.DB));
            this.StatosysSistemiAttributi = eStatusDetails.NUOVO;
            dtgsysSistemiAttributi.EditIndex = this.sysSistemiAttributi.Count - 1;
            this.DTGsysSistemiAttributi_Bind();
            this.DisabledButton(true);
            // NUOVO REC
            this.NuovoRec_sysSistemiAttributi(this.sysSistemiAttributi.Count - 1);
            break;
          }
        case "BCANCEL":
          {
            if (this.StatosysSistemiAttributi == eStatusDetails.NUOVO)
            {
              if (this.sysSistemiAttributi.Count > 0) this.sysSistemiAttributi.RemoveAt(this.sysSistemiAttributi.Count - 1);
            }
            this.StatosysSistemiAttributi = eStatusDetails.VISIONE;
            dtgsysSistemiAttributi.EditIndex = -1;
            this.DTGsysSistemiAttributi_Bind();
            this.DisabledButton(false);
            break;
          }
        case "BSAVE":
          {
            int index = -1;
            if (this.StatosysSistemiAttributi == eStatusDetails.NUOVO)
            {
              index = this.sysSistemiAttributi.Count - 1;
            }
            else
            {
              index = int.Parse(e.CommandArgument.ToString());
            }
            if (index == -1) return;
            // SCRIVI REC
            if (this.ScriviRec_sysSistemiAttributi(index))
            {
              this.StatosysSistemiAttributi = eStatusDetails.VISIONE;
              dtgsysSistemiAttributi.EditIndex = -1;
              this.DTGsysSistemiAttributi_Bind();
              this.DisabledButton(false);
            }
            break;
          }
        case "BEDIT":
          {
            // CAMBIA REC
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1) return;
            this.StatosysSistemiAttributi = eStatusDetails.MODIFICA;
            dtgsysSistemiAttributi.EditIndex = index;
            this.DTGsysSistemiAttributi_Bind();
            this.DisabledButton(true);
            if (!this.CambiaRec_sysSistemiAttributi(index))
            {
              this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
              dtgsysSistemiAttributi.EditIndex = -1;
              this.DTGsysSistemiAttributi_Bind();
              this.DisabledButton(false);
            }
            break;
          }
        case "BDELETE":
          {
            int index = int.Parse(e.CommandArgument.ToString());
            if (index == -1) return;
            this.sysSistemiAttributi.RemoveAt(index);
            dtgsysSistemiAttributi.EditIndex = -1;
            this.DTGsysSistemiAttributi_Bind();
            break;
          }
      }
    }
    private void dtgsysSistemiAttributi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BTesto sysSistemiAttributi_mbtChiave = null;
      BTesto sysSistemiAttributi_mbtValore = null;

      BButton BtnSalva = null;
      BButton BtnNew = null;
      try
      {
        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
        {
          BtnNew = (BButton)e.Row.FindControl("BtnNew");
          if (BtnNew == null) return;
          if (this.StatosysSistemiAttributi != eStatusDetails.VISIONE)
          {
            BtnNew.Enabled = false;
          }
          else
          {
            BtnNew.Enabled = true;
          }
        }
        if (e.Row.RowType == DataControlRowType.DataRow & dtgsysSistemiAttributi.EditIndex != -1)
        {
          // RECUPERO CONTROLLI
          sysSistemiAttributi_mbtChiave = (BTesto)e.Row.FindControl("mbtChiave");
          if (sysSistemiAttributi_mbtChiave == null) return;
          sysSistemiAttributi_mbtValore = (BTesto)e.Row.FindControl("mbtValore");
          if (sysSistemiAttributi_mbtValore == null) return;

          BtnSalva = (BButton)e.Row.FindControl("BtnSalva");
          if (BtnSalva == null) return;
          // IMPOSTA ATRIBUTES INVIO
          sysSistemiAttributi_mbtChiave.INVIO = true;
          sysSistemiAttributi_mbtChiave.CtlNextFocus = sysSistemiAttributi_mbtValore.ClientID;
          sysSistemiAttributi_mbtChiave.SetAttributes();

          sysSistemiAttributi_mbtValore.INVIO = true;
          sysSistemiAttributi_mbtValore.CtlNextFocus = BtnSalva.ClientID;
          sysSistemiAttributi_mbtValore.SetAttributes();


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
        ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysSistemi.DtgsysSistemiAttributi_RowDataBound():", "", eSeverity.ERROR, IDAccesso, this.Page);
      }
    }
    private void dtgsysSistemiAttributi_RowClick(int RowIndex)
    {
      int index = RowIndex;
      if (index == -1) return;
      if (!this.Enabled) return;
      this.StatosysSistemiAttributi = eStatusDetails.MODIFICA;
      dtgsysSistemiAttributi.EditIndex = index;
      this.DTGsysSistemiAttributi_Bind();
      this.DisabledButton(true);
      if (!this.CambiaRec_sysSistemiAttributi(index))
      {
        this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
        dtgsysSistemiAttributi.EditIndex = -1;
        this.DTGsysSistemiAttributi_Bind();
        this.DisabledButton(false);
      }
    }

  }
}