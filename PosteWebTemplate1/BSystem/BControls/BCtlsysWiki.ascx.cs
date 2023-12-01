// *****************************************************
// *** Classe generata con BStudio [Ver. 3.1.5] ***
// *****************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BIO;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using static BArts.BEnumerations;
using static PosteWebTemplate1.ModLog;
using CommandType = System.Data.CommandType;

namespace PosteWebTemplate1
{
  public partial class BCtlsysWiki : BWebControlTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL_WikiAllegati = "WikiAllegati";
    private const string K_SP_WikiAllegati_DELETE = "BSP_" + K_TBL_WikiAllegati + "_DELETE";
    private const string K_TBL_WikiLinks = "WikiLinks";
    private const string K_SP_WikiLinks_DELETE = "BSP_" + K_TBL_WikiLinks + "_DELETE";
    private const string K_PATH_ALLEGATO = @"BWiki\Attach";

    // DEFINIZIONE PROPRIETA WikiAllegati
    #region private List<BsysWikiAllegati> WikiAllegati
    private string K_SE_WikiAllegati = ".WikiAllegati";
    private List<BsysWikiAllegati> WikiAllegati
    {
      get
      {
        List<BsysWikiAllegati> obj;
        obj = (List<BsysWikiAllegati>)Session[base.ID + K_SE_WikiAllegati];
        if (obj == null)
        {
          obj = new List<BsysWikiAllegati>();
        }
        return obj;
      }
      set
      {
        Session[base.ID + K_SE_WikiAllegati] = value;
      }
    }
    #endregion
    #region private eStatusDetails StatoWikiAllegati
    private string K_VS_STATO_WikiAllegati = ".StatoWikiAllegati";
    private eStatusDetails StatoWikiAllegati
    {
      get
      {
        return (eStatusDetails)this.ViewState[base.ID + K_VS_STATO_WikiAllegati];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_WikiAllegati] = value;
      }
    }
    #endregion

    #region private List<BsysWikiLinks> WikiLinks
    private string K_SE_WikiLinks = ".WikiLinks";
    private List<BsysWikiLinks> WikiLinks
    {
      get
      {
        List<BsysWikiLinks> obj;
        obj = (List<BsysWikiLinks>)Session[base.ID + K_SE_WikiLinks];
        if (obj == null)
        {
          obj = new List<BsysWikiLinks>();
        }
        return obj;
      }
      set
      {
        Session[base.ID + K_SE_WikiLinks] = value;
      }
    }
    #endregion
    #region private eStatusDetails StatoWikiLinks
    private string K_VS_STATO_WikiLinks = ".StatoWikiLinks";
    private eStatusDetails StatoWikiLinks
    {
      get
      {
        return (eStatusDetails)this.ViewState[base.ID + K_VS_STATO_WikiLinks];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_WikiLinks] = value;
      }
    }
    #endregion

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
    public BCombo mbcIDPadre
    {
      get
      {
        return this.Internal_mbcIDPadre;
      }
      set
      {
        this.Internal_mbcIDPadre = value;
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
    public BTesto mbtSottotitolo
    {
      get
      {
        return this.Internal_mbtSottotitolo;
      }
      set
      {
        this.Internal_mbtSottotitolo = value;
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
    public BTesto mbtTags
    {
      get
      {
        return this.Internal_mbtTags;
      }
      set
      {
        this.Internal_mbtTags = value;
      }
    }
    public BSwitch ChkPubblica
    {
      get
      {
        return this.Internal_ChkPubblica;
      }
      set
      {
        this.Internal_ChkPubblica = value;
      }
    }
    public BSwitch ChkPubblicaAll
    {
      get
      {
        return this.Internal_ChkPubblicaAll;
      }

      set
      {
        this.Internal_ChkPubblicaAll = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbcIDPadre.ClientID;
      mbcIDPadre.CtlNextFocus = mbtTitolo.ClientID;
      mbtTitolo.CtlNextFocus = mbtSottotitolo.ClientID;
      mbtSottotitolo.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtTags.ClientID;
      if (this.CtlBtnSalva is object) mbtTags.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      mbcIDPadre.Init(this.DB.Setting);
      mbcIDPadre.Items.Insert(0, new ListItem("ROOT", "-1"));
      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      DtgWikiAllegati.RowClick += dtgWikiAllegati_RowClick;
      DtgWikiAllegati.RowDataBound += dtgWikiAllegati_RowDataBound;
      DtgWikiAllegati.RowCommand += dtgWikiAllegati_RowCommand;
      DtgWikiLinks.RowClick += dtgWikiLinks_RowClick;
      DtgWikiLinks.RowDataBound += dtgWikiLinks_RowDataBound;
      DtgWikiLinks.RowCommand += dtgWikiLinks_RowCommand;

      base.SetAttributes_AddEvents();
    }


    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtID.Enabled = false;
      mbcIDPadre.SelectedValue = "-1";
      mbtTitolo.Text = "";
      mbtSottotitolo.Text = "";
      mbtDescrizione.Text = "";
      mbtTags.Text = "";
      ChkPubblica.Checked = false;

      // DETTAGLIO WikiAllegati
      StatoWikiAllegati = eStatusDetails.VISIONE;
      WikiAllegati = new List<BsysWikiAllegati>();
      DTGWikiAllegati_Bind();

      // DETTAGLIO WikiLinks
      StatoWikiLinks = eStatusDetails.VISIONE;
      WikiLinks = new List<BsysWikiLinks>();
      DTGWikiLinks_Bind();

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysWiki MyObj = default;
      try
      {
        if (Obj == null)
          return false;
        MyObj = (BsysWiki)Obj;
        mbtID.Text = BConvert.ToString(MyObj.ID, "-1");
        mbtID.Enabled = false;
        mbcIDPadre.SelectedValue = BConvert.ToString(MyObj.IDPadre, "-1");
        mbtTitolo.Text = MyObj.Titolo;
        mbtSottotitolo.Text = MyObj.Sottotitolo;
        mbtDescrizione.Text = MyObj.Descrizione;
        mbtTags.Text = MyObj.Tags;
        ChkPubblica.Checked = MyObj.Pubblica;

        // CARICA DETTAGLIO WikiAllegati
        StatoWikiAllegati = eStatusDetails.VISIONE;
        WikiAllegati = MyObj.Allegati;
        DTGWikiAllegati_Bind();

        // CARICA DETTAGLIO WikiLinks
        StatoWikiLinks = eStatusDetails.VISIONE;
        WikiLinks = MyObj.Links;
        DTGWikiLinks_Bind();

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("Wiki.CambiaRec():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysWiki MyObj = default;
      bool Ret = false;
      try
      {
        if (!this.CheckBeforeUpdate()) return null;
        MyObj = (BsysWiki)Obj;
        if (MyObj is object)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.IDPadre = BConvert.ToInt(mbcIDPadre.SelectedValue);
          MyObj.Titolo = mbtTitolo.Text;
          MyObj.Sottotitolo = mbtSottotitolo.Text;
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.DataUltimaModifica = DateTime.Now;
          MyObj.Tags = mbtTags.Text;
          MyObj.Pubblica = ChkPubblica.Checked;
          if (MyObj.ID == -1) MyObj.Ordine = ImpostaOrdine(BConvert.ToInt(mbcIDPadre.SelectedValue)) + 1;

          // SCRIVI DETTAGLIO WikiAllegati
          MyObj.Allegati = WikiAllegati;

          // SCRIVI DETTAGLIO WikiLinks
          MyObj.Links = WikiLinks;
          Ret = MyObj.Update();

          // CHECK AND SAVE FILE UPLOAD
          if (Ret)
          {
            if (SaveAllegati(MyObj))
            {
              BSysUtenteEntrato.WriteOperation("SALVATAGGIO ALLEGATI DEL WIKI <<[ID] = " + mbtID.Text + ";>> RIUSCITO. ");
            }
            else
            {
              BSysUtenteEntrato.WriteOperation("SALVATAGGIO ALLEGATI DEL WIKI <<[ID] = " + mbtID.Text + ";>> FALLITO. ");
              this.WriteLog("BCtlCampagne.ScriviRec", "SALVATAGGIO ALLEGATI DEL WIKI <<[ID] = " + mbtID.Text + ";>> FALLITO. ", eSeverity.ERROR);
            }

            if (Ret & ChkPubblicaAll.Checked) UpdatePubblicaFigli(MyObj);
          }
        }

        if (Ret)
        {
          this.ShowToast("Salvataggio effettuato con successo");
          if (UtenteEntrato is object) BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA Wiki");
          return MyObj;
        }
        else
        {
          this.MsgBox("Errore durante il salvataggio");
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("Wiki.ScriviRec():", "", ex, eSeverity.ERROR);
        return null;
      }
    }
    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI WikiAllegati
      DB.ClearParameter();
      DB.AddParameter("@IDWiki", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_WikiAllegati_DELETE, CommandType.StoredProcedure);

      // RIMOZIONE RECORD RELAZIONATI WikiLinks
      DB.ClearParameter();
      DB.AddParameter("@IDWiki", this.GetValueFromKey("ID", ParamsKey));
      DB.ExecuteNonQuery(K_SP_WikiLinks_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }
    public int ImpostaOrdine(int IDPadre)
    {
      int ordineMassimo = -1;
      string sp = "BSP_sysWiki_SORT";
      try
      {
        DB.ClearParameter();
        if (IDPadre != -1) DB.AddParameter("@IDPadre", IDPadre);
        ordineMassimo = BConvert.ToInt(DB.ExecuteScalar(sp, CommandType.StoredProcedure));
        return ordineMassimo;
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.ScriviRec():", "", ex, eSeverity.ERROR);
        return -1;
      }
    }

    // DEFINIZIONE FUNZIONI WikiAllegati
    private void NuovoRec_WikiAllegati(int Index)
    {
      BTesto WikiAllegati_mbtIDAllegato = null;
      BTesto WikiAllegati_mbtDescrizione = null;
      BUploader WikiAllegati_BUpAllegato = null;
      if (Index != -1)
      {
        // RECUPERO CONTROLLI

        WikiAllegati_mbtIDAllegato = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtIDAllegato");
        if (WikiAllegati_mbtIDAllegato == null) return;
        WikiAllegati_mbtDescrizione = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtDescrizione");
        if (WikiAllegati_mbtDescrizione == null) return;
        WikiAllegati_BUpAllegato = (BUploader)DtgWikiAllegati.Rows[Index].FindControl("BUpAllegato");
        if (WikiAllegati_BUpAllegato == null) return;

        // INIZIALIZZO CONTROLLI ROW
        WikiAllegati_mbtIDAllegato.Text = BConvert.ToString(Index + 1);
        WikiAllegati_mbtDescrizione.Text = "";
        WikiAllegati_BUpAllegato.File = null;
        WikiAllegati_BUpAllegato.SetAttributes();

        // IMPOSTO FOCUS
        WikiAllegati_mbtDescrizione.Focus();
      }
    }
    private bool CambiaRec_WikiAllegati(int Index)
    {
      BTesto WikiAllegati_mbtIDAllegato = null;
      BTesto WikiAllegati_mbtDescrizione = null;
      BUploader WikiAllegati_BUpAllegato = null;
      BsysWikiAllegati Obj = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          WikiAllegati_mbtIDAllegato = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtIDAllegato");
          if (WikiAllegati_mbtIDAllegato == null) return false;
          WikiAllegati_mbtDescrizione = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtDescrizione");
          if (WikiAllegati_mbtDescrizione == null) return false;
          WikiAllegati_BUpAllegato = (BUploader)DtgWikiAllegati.Rows[Index].FindControl("BUpAllegato");
          if (WikiAllegati_BUpAllegato == null) return false;
        }

        // RECUPERO OBJECT
        Obj = WikiAllegati[Index];
        if (Obj == null) return false;

        // GET FILE IF EXIST
        BFile f = new BFile();
        string Path = "";
        f.Nome = Obj.Descrizione;
        if (BWebConfig.ServerFileShare_PathRelative)
        {
          Path = Server.MapPath(BWebConfig.ServerFileShare_Folder);
        }
        else
        {
          Path = BWebConfig.ServerFileShare_Folder;
        }

        Path = BGlobal.CreatePathFile(Path, f.Nome);
        if (File.Exists(Path))
        {
          f.Content = File.ReadAllBytes(Path);
          Obj.File = f;
        }

        // AGGIORNO LA COLLECTION
        WikiAllegati_mbtIDAllegato.Text = BConvert.ToString(Obj.IDAllegato);
        WikiAllegati_mbtDescrizione.Text = Obj.Descrizione;
        WikiAllegati_BUpAllegato.File = Obj.File;

        // FOCUS
        WikiAllegati_mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.CambiaRec_WikiAllegati():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    private bool ScriviRec_WikiAllegati(int Index)
    {
      BsysWikiAllegati Obj = null;
      BTesto WikiAllegati_mbtIDAllegato = null;
      BTesto WikiAllegati_mbtDescrizione = null;
      BUploader WikiAllegati_BUpAllegato = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          WikiAllegati_mbtIDAllegato = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtIDAllegato");
          if (WikiAllegati_mbtIDAllegato == null) return false;
          WikiAllegati_mbtDescrizione = (BTesto)DtgWikiAllegati.Rows[Index].FindControl("mbtDescrizione");
          if (WikiAllegati_mbtDescrizione == null) return false;
          WikiAllegati_BUpAllegato = (BUploader)DtgWikiAllegati.Rows[Index].FindControl("BUpAllegato");
          if (WikiAllegati_BUpAllegato == null) return false;

          // CONTROLLI DI VALIDITA'
          if (WikiAllegati_mbtIDAllegato.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            WikiAllegati_mbtIDAllegato.Focus();
            return false;
          }

          if (WikiAllegati_mbtDescrizione.Text == "")
          {
            this.MsgBox("Campo Obbligatorio");
            WikiAllegati_mbtDescrizione.Focus();
            return false;
          }

          // RECUPERO OBJECT
          Obj = WikiAllegati[Index];
          if (Obj == null) return false;

          // AGGIORNO LA COLLECTION
          Obj.IDAllegato = BConvert.ToInt(WikiAllegati_mbtIDAllegato.Text);
          Obj.Descrizione = WikiAllegati_mbtDescrizione.Text;
          Obj.File = WikiAllegati_BUpAllegato.File;
          if (Obj.File != null)
          {
            Obj.File.Nome = WikiAllegati_BUpAllegato.File.Nome;
            Obj.PathAllegato = Obj.File.Nome;
          }

          WikiAllegati[Index] = Obj;
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.ScriviRec_WikiAllegati():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    private void DTGWikiAllegati_Bind()
    {
      try
      {
        DtgWikiAllegati.DataSource = WikiAllegati;
        DtgWikiAllegati.DataBind();
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.DTGWikiAllegati_Bind():", "", ex, eSeverity.ERROR);
      }
    }
    private bool CheckStateWikiAllegati()
    {
      if (StatoWikiAllegati == eStatusDetails.VISIONE)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA WikiAllegati
    private void dtgWikiAllegati_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "BNEW":
          {
            WikiAllegati.Add(new BsysWikiAllegati(this.DB));
            StatoWikiAllegati = eStatusDetails.NUOVO;
            DtgWikiAllegati.EditIndex = WikiAllegati.Count - 1;
            DTGWikiAllegati_Bind();
            this.DisabledButton(true);
            // NUOVO REC
            NuovoRec_WikiAllegati(WikiAllegati.Count - 1);
            break;
          }

        case "BCANCEL":
          {
            if (StatoWikiAllegati == eStatusDetails.NUOVO)
            {
              if (WikiAllegati.Count > 0)
                WikiAllegati.RemoveAt(WikiAllegati.Count - 1);
            }

            StatoWikiAllegati = eStatusDetails.VISIONE;
            DtgWikiAllegati.EditIndex = -1;
            DTGWikiAllegati_Bind();
            this.DisabledButton(false);
            break;
          }

        case "BSAVE":
          {
            int index = -1;
            if (StatoWikiAllegati == eStatusDetails.NUOVO)
            {
              index = WikiAllegati.Count - 1;
            }
            else
            {
              index = BConvert.ToInt(e.CommandArgument);
            }

            if (index == -1) return;
            // SCRIVI REC
            if (ScriviRec_WikiAllegati(index))
            {
              StatoWikiAllegati = eStatusDetails.VISIONE;
              DtgWikiAllegati.EditIndex = -1;
              DTGWikiAllegati_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BEDIT":
          {
            // CAMBIA REC
            int index = BConvert.ToInt(e.CommandArgument);
            if (index == -1)
              return;
            StatoWikiAllegati = eStatusDetails.MODIFICA;
            DtgWikiAllegati.EditIndex = index;
            DTGWikiAllegati_Bind();
            this.DisabledButton(true);
            if (!CambiaRec_WikiAllegati(index))
            {
              this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
              DtgWikiAllegati.EditIndex = -1;
              DTGWikiAllegati_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BDELETE":
          {
            int index = BConvert.ToInt(e.CommandArgument);
            if (index == -1) return;
            WikiAllegati.RemoveAt(index);
            DtgWikiAllegati.EditIndex = -1;
            DTGWikiAllegati_Bind();
            break;
          }
      }
    }
    private void dtgWikiAllegati_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BTesto WikiAllegati_mbtIDAllegato = null;
      BTesto WikiAllegati_mbtDescrizione = null;
      BUploader WikiAllegati_BUpAllegato = null;
      HyperLink LnkPathAllegato = null;
      BButton BtnSalva = null;
      BButton BtnNew = null;
      string Path = "";
      string PathRel = "";
      string PathFolder = "";
      string K_Path = @"Wiki\Wiki_{0}\";
      try
      {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.Footer)
        {
          BtnNew = (BButton)e.Row.FindControl("BtnNew");
          if (BtnNew == null)
            return;
          if (StatoWikiAllegati != eStatusDetails.VISIONE)
          {
            BtnNew.Enabled = false;
          }
          else
          {
            BtnNew.Enabled = true;
          }
        }

        if (e.Row.RowType == DataControlRowType.DataRow & DtgWikiAllegati.EditIndex != -1)
        {
          // RECUPERO CONTROLLI
          WikiAllegati_mbtIDAllegato = (BTesto)e.Row.FindControl("mbtIDAllegato");
          if (WikiAllegati_mbtIDAllegato == null) return;
          WikiAllegati_mbtDescrizione = (BTesto)e.Row.FindControl("mbtDescrizione");
          if (WikiAllegati_mbtDescrizione == null) return;
          WikiAllegati_BUpAllegato = (BUploader)e.Row.FindControl("BUpAllegato");
          if (WikiAllegati_BUpAllegato == null) return;
          BtnSalva = (BButton)e.Row.FindControl("BtnSalva");
          if (BtnSalva == null) return;

          // IMPOSTA ATRIBUTES INVIO
          WikiAllegati_mbtIDAllegato.INVIO = true;
          WikiAllegati_mbtIDAllegato.CtlNextFocus = WikiAllegati_mbtDescrizione.ClientID;
          WikiAllegati_mbtIDAllegato.SetAttributes();
          WikiAllegati_mbtDescrizione.INVIO = true;
          WikiAllegati_mbtDescrizione.SetAttributes();
          WikiAllegati_BUpAllegato.SetAttributes();
        }
        else
        {
          LnkPathAllegato = (HyperLink)e.Row.FindControl("LnkPathAllegato");
          if (LnkPathAllegato == null) return;
          BsysWikiAllegati Obj = (BsysWikiAllegati)e.Row.DataItem;
          if (Obj == null) return;


          PathFolder = string.Format(K_Path, Obj.IDSysWiki);
          Path = BGlobal.CreatePathFile(BWebConfig.ServerFileShare_Folder, PathFolder);
          Path = BGlobal.CreatePathFile(Path, Obj.PathAllegato);

          if (BWebConfig.ServerFileShare_PathRelative)
          {
            PathRel = BGlobal.CreatePathFileWeb("~/", Path);
            Path = Server.MapPath(PathRel);
          }
          else
          {
            PathRel = Path;
          }

          if (File.Exists(Path))
          {
            LnkPathAllegato.Text = "Scarica Allegato";
            LnkPathAllegato.Visible = true;
          }
          else if (Obj.PathAllegato != "")
          {
            LnkPathAllegato.Text = Obj.PathAllegato;
            LnkPathAllegato.NavigateUrl = "";
          }
          else
          {
            LnkPathAllegato.Visible = false;
          }

          LnkPathAllegato.NavigateUrl = PathRel;
        }
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.DtgWikiAllegati_RowDataBound():", "", ex, eSeverity.ERROR);
      }
    }
    private void dtgWikiAllegati_RowClick(int RowIndex)
    {
      int index = RowIndex;
      if (index == -1) return;
      if (!Enabled) return;
      StatoWikiAllegati = eStatusDetails.MODIFICA;
      DtgWikiAllegati.EditIndex = index;
      DTGWikiAllegati_Bind();
      this.DisabledButton(true);
      if (!CambiaRec_WikiAllegati(index))
      {
        this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
        DtgWikiAllegati.EditIndex = -1;
        DTGWikiAllegati_Bind();
        this.DisabledButton(false);
      }
    }

    // DEFINIZIONE FUNZIONI WikiLinks
    private void NuovoRec_WikiLinks(int Index)
    {
      BCombo WikiLinks_mbcIDWikiRef = null;
      if (Index != -1)
      {
        // RECUPERO CONTROLLI
        WikiLinks_mbcIDWikiRef = (BCombo)DtgWikiLinks.Rows[Index].FindControl("mbcIDWikiRef");
        if (WikiLinks_mbcIDWikiRef == null) return;

        // INIZIALIZZO CONTROLLI ROW
        WikiLinks_mbcIDWikiRef.SelectedIndex = 0;

        // IMPOSTO FOCUS
        WikiLinks_mbcIDWikiRef.Focus();
      }
    }
    private bool CambiaRec_WikiLinks(int Index)
    {
      BCombo WikiLinks_mbcIDWikiRef = null;
      BsysWikiLinks Obj = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          WikiLinks_mbcIDWikiRef = (BCombo)DtgWikiLinks.Rows[Index].FindControl("mbcIDWikiRef");
          if (WikiLinks_mbcIDWikiRef == null) return default;
        }

        // RECUPERO OBJECT
        Obj = WikiLinks[Index];
        if (Obj == null) return false;

        // AGGIONO LA COLLECTION
        WikiLinks_mbcIDWikiRef.SelectedValue = BConvert.ToString(Obj.IDSysWikiRef, "-1");

        // FOCUS
        WikiLinks_mbcIDWikiRef.Focus();
        return true;
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.CambiaRec_WikiLinks():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    private bool ScriviRec_WikiLinks(int Index)
    {
      BsysWikiLinks Obj = null;
      BCombo WikiLinks_mbcIDWikiRef = null;
      try
      {
        if (Index != -1)
        {
          // RECUPERO CONTROLLI
          WikiLinks_mbcIDWikiRef = (BCombo)DtgWikiLinks.Rows[Index].FindControl("mbcIDWikiRef");
          if (WikiLinks_mbcIDWikiRef == null) return default;

          // CONTROLLI DI VALIDITA'
          if (WikiLinks_mbcIDWikiRef.SelectedValue == "-1")
          {
            this.MsgBox("Campo Obbligatorio");
            WikiLinks_mbcIDWikiRef.Focus();
            return false;
          }

          // RECUPERO OBJECT
          Obj = WikiLinks[Index];
          if (Obj == null) return false;

          // AGGIORNO LA COLLECTION
          Obj.IDSysWikiRef = BConvert.ToInt(WikiLinks_mbcIDWikiRef.SelectedValue);
          WikiLinks[Index] = Obj;
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.ScriviRec_WikiLinks():", "", ex, eSeverity.ERROR);
        return false;
      }
    }
    private void DTGWikiLinks_Bind()
    {
      try
      {
        DtgWikiLinks.DataSource = WikiLinks;
        DtgWikiLinks.DataBind();
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.DTGWikiLinks_Bind():", "", ex, eSeverity.ERROR);
      }
    }
    private bool CheckStateWikiLinks()
    {
      if (StatoWikiLinks == eStatusDetails.VISIONE)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA GRIGLIA WikiLinks
    private void dtgWikiLinks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "BNEW":
          {
            WikiLinks.Add(new BsysWikiLinks(this.DB));
            StatoWikiLinks = eStatusDetails.NUOVO;
            DtgWikiLinks.EditIndex = WikiLinks.Count - 1;
            DTGWikiLinks_Bind();
            this.DisabledButton(true);
            // NUOVO REC
            NuovoRec_WikiLinks(WikiLinks.Count - 1);
            break;
          }

        case "BCANCEL":
          {
            if (StatoWikiLinks == eStatusDetails.NUOVO)
            {
              if (WikiLinks.Count > 0)
                WikiLinks.RemoveAt(WikiLinks.Count - 1);
            }

            StatoWikiLinks = eStatusDetails.VISIONE;
            DtgWikiLinks.EditIndex = -1;
            DTGWikiLinks_Bind();
            this.DisabledButton(false);
            break;
          }

        case "BSAVE":
          {
            int index = -1;
            if (StatoWikiLinks == eStatusDetails.NUOVO)
            {
              index = WikiLinks.Count - 1;
            }
            else
            {
              index = BConvert.ToInt(e.CommandArgument);
            }

            if (index == -1) return;

            // SCRIVI REC
            if (ScriviRec_WikiLinks(index))
            {
              StatoWikiLinks = eStatusDetails.VISIONE;
              DtgWikiLinks.EditIndex = -1;
              DTGWikiLinks_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BEDIT":
          {
            // CAMBIA REC
            int index = BConvert.ToInt(e.CommandArgument);
            if (index == -1) return;
            StatoWikiLinks = eStatusDetails.MODIFICA;
            DtgWikiLinks.EditIndex = index;
            DTGWikiLinks_Bind();
            this.DisabledButton(true);
            if (!CambiaRec_WikiLinks(index))
            {
              this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
              DtgWikiLinks.EditIndex = -1;
              DTGWikiLinks_Bind();
              this.DisabledButton(false);
            }

            break;
          }

        case "BDELETE":
          {
            int index = BConvert.ToInt(e.CommandArgument);
            if (index == -1) return;
            WikiLinks.RemoveAt(index);
            DtgWikiLinks.EditIndex = -1;
            DTGWikiLinks_Bind();
            break;
          }
      }
    }
    private void dtgWikiLinks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      BCombo WikiLinks_mbcIDWikiRef = null;
      BButton BtnSalva = null;
      BButton BtnNew = null;
      try
      {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.Footer)
        {
          BtnNew = (BButton)e.Row.FindControl("BtnNew");
          if (BtnNew == null) return;
          if (StatoWikiLinks != eStatusDetails.VISIONE)
          {
            BtnNew.Enabled = false;
          }
          else
          {
            BtnNew.Enabled = true;
          }
        }

        if (e.Row.RowType == DataControlRowType.DataRow & DtgWikiLinks.EditIndex != -1)
        {
          // RECUPERO CONTROLLI
          WikiLinks_mbcIDWikiRef = (BCombo)e.Row.FindControl("mbcIDWikiRef");
          if (WikiLinks_mbcIDWikiRef == null) return;
          BtnSalva = (BButton)e.Row.FindControl("BtnSalva");
          if (BtnSalva == null) return;

          // IMPOSTA ATRIBUTES INVIO
          WikiLinks_mbcIDWikiRef.INVIO = true;
          WikiLinks_mbcIDWikiRef.CtlNextFocus = BtnSalva.ClientID;
          WikiLinks_mbcIDWikiRef.Init(this.DB.Setting);
          WikiLinks_mbcIDWikiRef.Items.Insert(0, new ListItem("Nessuna Selezione", "-1"));
          WikiLinks_mbcIDWikiRef.SetAttributes();
        }
      }
      catch (Exception ex)
      {
        WriteLog("Wiki.DtgWikiLinks_RowDataBound():", "", ex, eSeverity.ERROR);
      }
    }
    private void dtgWikiLinks_RowClick(int RowIndex)
    {
      int index = RowIndex;
      if (index == -1) return;
      if (!Enabled) return;
      StatoWikiLinks = eStatusDetails.MODIFICA;
      DtgWikiLinks.EditIndex = index;
      DTGWikiLinks_Bind();
      this.DisabledButton(true);
      if (!CambiaRec_WikiLinks(index))
      {
        this.MsgBox("Si è verificato un errore in fase di caricamento dei dati");
        DtgWikiLinks.EditIndex = -1;
        DTGWikiLinks_Bind();
        this.DisabledButton(false);
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool UpdatePubblicaFigli(BsysWiki ObjPadre)
    {
      bool ret = false;
      if (ObjPadre.sysWiki != null && ObjPadre.sysWiki.Count > 0)
      {
        foreach (BsysWiki obj in ObjPadre.sysWiki)
        {
          obj.Pubblica = ObjPadre.Pubblica;
          ret = obj.Update(false);
          if (ret) UpdatePubblicaFigli(obj);
          if (!ret) return false;
        }
      }
      return true;
    }
    private bool SaveAllegati(BsysWiki Obj)
    {
      string PathFolder = "";
      string K_Path = @"Wiki\Wiki_{0}\";
      try
      {
        PathFolder = string.Format(K_Path, Obj.ID);
        foreach (BsysWikiAllegati f in Obj.Allegati)
        {
          if (f.File is object && f.File.Content.Length > 0)
          {
            string NomeFile = "Allegato_" + f.IDAllegato + BGlobal.GetExtension(f.File.Nome);
            f.File.Nome = NomeFile;
            if (this.BPage.ScriviFileOnServer(f.File, PathFolder, "", true))
            {
              f.PathAllegato = NomeFile;
            }
            else
            {
              f.PathAllegato = "";
              f.File = null;
              this.WriteLog("SysWiki.SaveAllegati()", "Scrittura file sul server fallita <<" + NomeFile + ">>", eSeverity.ERROR);
            }

            f.Update(false);
          }
        }

        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("SysWiki.SaveAllegati", "", ex, eSeverity.ERROR);
        return false;
      }
    }

  } //END CLASS
} //END NAMESPACE