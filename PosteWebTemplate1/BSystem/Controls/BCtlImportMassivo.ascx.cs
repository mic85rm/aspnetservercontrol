using BArts.BData;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlImportMassivo : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public new event ShowExtenderEventHandler ShowExtender;
    public new delegate void ShowExtenderEventHandler();

    public event AnnullaEventHandler Annulla;
    public delegate void AnnullaEventHandler();

    public event ConfermaEventHandler Conferma;
    public delegate void ConfermaEventHandler(BDataTable dt, BsysImportFiles ObjImport);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      btnDownloadTemplate.Click += btnDownloadTemplate_Click;
      btnAdd.Click += btnAdd_Click;
      BtnConferma.Click += BtnConferma_Click;
      BtnAnnulla.Click += BtnAnnulla_Click;
      dtgElenco.RowCommand += dtgElenco_RowCommand;
      BDtgPager.ChangePage += BDtgPager_ChangePage;
      BDtgPager.ChangeNumRowForPage += BDtgPager_ChangeNumRowForPage;
      BUploader.LoadScriptManager += BUploader_LoadScriptManager;
      this.Load += CtlUploader_Load;
      this.AttachCommand += BCtlImportMassivo_AttachCommand;

      base.SetAttributes_AddEvents();
    }

    // DEFINZIONE PROPRIETA'
    public string Titolo
    {
      get
      {
        return this.LblTitolo.Text;
      }
      set
      {
        this.LblTitolo.Text = value;
      }
    }

    #region public bool CreateTmpTable
    private const string K_VS_CREATETMPTABLE = ".CreateTMPTable";
    public bool CreateTmpTable
    {
      get
      {
        return (bool)(base.ViewState[base.ID + K_VS_CREATETMPTABLE]);
      }

      set
      {
        base.ViewState[base.ID + K_VS_CREATETMPTABLE] = value;
      }
    }
    #endregion
    #region public string TmpTableName
    private const string K_SE_TmpTableName = ".TmpTableName";
    public string TmpTableName
    {
      get
      {
        if (base.ViewState[base.ID + K_SE_TmpTableName] == null)
        {
          return "TABLEIMPORT";
        }
        else
        {
          return base.ViewState[base.ID + K_SE_TmpTableName].ToString();
        }
      }
      set
      {
        base.ViewState[base.ID + K_SE_TmpTableName] = value;
      }
    }
    #endregion

    public bool ShowBtnDownloadTemplate
    {
      get
      {
        return this.btnDownloadTemplate.Visible;
      }
      set
      {
        this.btnDownloadTemplate.Visible = value;
      }
    }
    public bool ShowBtnConferma
    {
      get
      {
        return this.btnDownloadTemplate.Visible;
      }
      set
      {
        this.btnDownloadTemplate.Visible = value;
      }
    }
    public bool ShowPreview
    {
      get
      {
        return this.PnlDtg.Visible;
      }
      set
      {
        this.PnlDtg.Visible = value;
      }
    }

    #region public string Delimiter
    private const string K_SE_Delimiter = ".Delimiter";
    public string Delimiter
    {
      get
      {
        if (base.ViewState[base.ID + K_SE_Delimiter] == null)
        {
          return ";";
        }
        else
        {
          return base.ViewState[base.ID + K_SE_Delimiter].ToString();
        }
      }
      set
      {
        base.ViewState[base.ID + K_SE_Delimiter] = value;
      }
    }
    #endregion
    #region public List<string> ColonneTemplate
    private const string K_SE_COLONNETEMPLATE = ".ColonneTemplate";
    public List<string> ColonneTemplate
    {
      get
      {
        if (base.Session[base.ID + K_SE_COLONNETEMPLATE] == null)
        {
          base.Session[base.ID + K_SE_COLONNETEMPLATE] = new List<string>();
        }

        return (List<string>)base.Session[base.ID + K_SE_COLONNETEMPLATE];
      }
      set
      {
        base.Session[base.ID + K_SE_COLONNETEMPLATE] = value;
      }
    }
    #endregion
    #region public string FileName
    private const string K_SE_FileName = ".FileName";
    public string FileName
    {
      get
      {
        if (base.ViewState[base.ID + K_SE_FileName] == null)
        {
          return "Template";
        }
        else
        {
          return base.ViewState[base.ID + K_SE_FileName].ToString();
        }
      }
      set
      {
        base.ViewState[base.ID + K_SE_FileName] = value;
      }
    }
    #endregion
    #region public string StoredTemplate
    private const string K_SE_StoredTemplate = ".StoredTemplate";
    public string StoredTemplate
    {
      get
      {
        if (base.ViewState[base.ID + K_SE_StoredTemplate] == null)
        {
          return "";
        }
        else
        {
          return base.ViewState[base.ID + K_SE_StoredTemplate].ToString();
        }
      }
      set
      {
        base.ViewState[base.ID + K_SE_StoredTemplate] = value;
      }
    }
    #endregion
    #region public List<IDbDataParameter> ParametriStoredTemplate
    private const string K_SE_PARAMETRISTOREDTEPLATE = ".ParametriStoredTemplate";
    public List<IDbDataParameter> ParametriStoredTemplate
    {
      get
      {
        if (base.Session[base.ID + K_SE_PARAMETRISTOREDTEPLATE] == null)
        {
          base.Session[base.ID + K_SE_PARAMETRISTOREDTEPLATE] = new List<IDbDataParameter>();
        }

        return (List<IDbDataParameter>)base.Session[base.ID + K_SE_PARAMETRISTOREDTEPLATE];
      }
      set
      {
        base.Session[base.ID + K_SE_PARAMETRISTOREDTEPLATE] = value;
      }
    }
    #endregion
    #region private BDataTable DTElenco
    private const string K_SE_DTELENCO = ".DTElenco";
    private BDataTable DTElenco
    {
      get
      {
        return (BDataTable)base.Session[base.ID + K_SE_DTELENCO];
      }
      set
      {
        base.Session[base.ID + K_SE_DTELENCO] = value;
      }
    }
    #endregion
    #region private BsysImportFiles ObjImport
    private const string K_SE_OBJIMPORT = ".BsysImportFiles";
    private BsysImportFiles ObjImport
    {
      get
      {
        return (BsysImportFiles)base.Session[base.ID + K_SE_OBJIMPORT];
      }
      set
      {
        base.Session[base.ID + K_SE_OBJIMPORT] = value;
      }
    }
    #endregion

    // DEFINIZIONE FUNZIONI PRIVATE
    private void BindDTG(BDataTable DT)
    {
      this.dtgElenco.DataSource = DTElenco;
      this.dtgElenco.DataBind();
      if (DT != null)
      {
        this.BDtgPager.SetPager(DT.Rows.Count);
      }
      else
      {
        this.BDtgPager.SetPager(0);
      }
    }

    //DDEFINIZIONE EVENTI INTERCETTATI
    protected void CtlUploader_Load(object sender, EventArgs e)
    {
      BMaster.ScriptManager.RegisterPostBackControl(this.btnAdd);
      if (ColonneTemplate == null || ColonneTemplate.Count == 0)
      {
        this.btnDownloadTemplate.Visible = false;
      }

      this.BDtgPager.CssBtnXlsExport = "BDisplayNone";
      this.BDtgPager.SetPager(0);
    }
    private void BCtlImportMassivo_AttachCommand()
    {
      BPage.AddAttachExportExcel(this.btnDownloadTemplate.ClientID, "");
    }

    // EVENTI INTERCETTATI SUI BOTTONI

    private void btnDownloadTemplate_Click(object sender, EventArgs e)
    {
      DataView dv = null;
      DataTable dt = null;
      if (string.IsNullOrEmpty(StoredTemplate))
      {
        dt = new DataTable();
        if (ColonneTemplate != null && ColonneTemplate.Count > 0)
        {
          foreach (string col in ColonneTemplate)
            dt.Columns.Add(new DataColumn(col));
        }
      }
      else
      {
        dt = base.DB.ApriDT(StoredTemplate, (int)CommandType.StoredProcedure, ParametriStoredTemplate.ToArray());
      }

      dv = new DataView(dt);
      BPage.ExportToExcel(dv, ModEnumeration.eFormatoExport.CSV, FileName);
      ShowExtender?.Invoke();
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.UtenteEntrato == null)
        return;
      // LOAD FILE
      if (this.BUploader.File == null)
      {
        base.MsgBox("Selezionare un file da uploadre");
        this.BUploader.Focus();
        return;
      }

      // CREATE OBJECT IMPORT
      var m = new System.IO.MemoryStream(this.BUploader.File.Content);
      var StReader = new System.IO.StreamReader(m);
      ObjImport = new BsysImportFiles(this.DB);
      ObjImport.NomeFile = this.BUploader.File.Nome;
      ObjImport.ContentFile = this.BUploader.File.Content;
      ObjImport.Descrizione = FileName;
      ObjImport.NomeTblImport = TmpTableName + "_" + this.UtenteEntrato.IDAccesso;
      ObjImport.DataCreazione = DateAndTime.Now;
      ObjImport.IDSysUtente = this.UtenteEntrato.Username;
      ObjImport.Update();

      // READ FILE
      DTElenco = base.DB.ApriDT(this.BUploader.File, Delimiter, false);
      // CHECK COLONNE
      foreach (string s in ColonneTemplate)
      {
        if (DTElenco.Columns.IndexOf(s) == -1)
        {
          base.MsgBox("Il file non corrisponde alla struttura del template.");
          this.BUploader.Focus();
          if (DTElenco != null)
          {
            DTElenco.Dispose();
            DTElenco = null;
          }

          return;
        }
      }

      BindDTG(DTElenco);
      ShowExtender?.Invoke();
    }
    private void BtnConferma_Click(object sender, EventArgs e)
    {
      if (DTElenco != null && DTElenco.Rows.Count > 0 && ObjImport != null)
      {
        ObjImport.DTFiles = DTElenco;
        if (CreateTmpTable)
        {
          ObjImport.DataInizioImport = DateAndTime.Now;
          ObjImport.Update();
          ObjImport.CreateTmpTable();
          ObjImport.LoadTmpTable();
          ObjImport.DataFineImport = DateAndTime.Now;
          ObjImport.Update();
          Conferma?.Invoke(DTElenco, ObjImport);
          ObjImport.DropTmpTable();
          ObjImport.DataChiusura = DateAndTime.Now;
        }
        else
        {
          ObjImport.DataInizioImport = DateAndTime.Now;
          ObjImport.Update();
          Conferma?.Invoke(DTElenco, ObjImport);
          ObjImport.DataFineImport = DateAndTime.Now;
          ObjImport.Update();
          ObjImport.DataChiusura = DateAndTime.Now;
        }
        ObjImport.Update();
      }
      else
      {
        Annulla?.Invoke();
      }
    }
    private void BtnAnnulla_Click(object sender, EventArgs e)
    {
      if (DTElenco != null)
      {
        DTElenco.Dispose();
        DTElenco = null;
        BindDTG(DTElenco);
      }
      Annulla?.Invoke();
    }

    // INIZIO METODI INTERCETTATI GRIGLIA
    private void dtgElenco_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int IndexRow = -1;
      var switchExpr = e.CommandName.ToUpper();
      switch (switchExpr)
      {
        case "BDELETE":
          {
            if (e.CommandArgument.ToString() != "")
              IndexRow = int.Parse(e.CommandArgument.ToString());
            if (IndexRow != -1)
            {
              DTElenco.Rows.RemoveAt(IndexRow);
              this.dtgElenco.DataSource = DTElenco;
              this.dtgElenco.DataBind();
            }
            else
            {
              this.MsgBox("Non è stato possibile individuare la riga selezionata.");
            }
            break;
          }
      }
      ShowExtender?.Invoke();
    }
    private void BDtgPager_ChangePage()
    {
      this.dtgElenco.PageIndex = this.BDtgPager.PageIndex;
      BindDTG(DTElenco);
    }
    private void BDtgPager_ChangeNumRowForPage()
    {
      this.dtgElenco.PageSize = this.BDtgPager.DefaultRowForPage;
      this.dtgElenco.PageIndex = 0;
      BindDTG(DTElenco);
    }

    private void BUploader_LoadScriptManager()
    {
      this.BUploader.AttachScriptManager(BMaster.ScriptManager);
    }

  } //END CLASS
} //END NAMESPACE