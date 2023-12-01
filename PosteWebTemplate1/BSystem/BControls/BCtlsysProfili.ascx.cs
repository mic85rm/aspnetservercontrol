// *****************************************************
// *** Classe generata con BStudio 2017 [Ver. 3.0.3] ***
// *****************************************************
using BArts;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlsysProfili : BWebControlTableBase
  {

    // DEFINIZIONE DATI

    private const string K_TBL_sysProfiliFunzioni = "sysProfiliFunzioni";
    private const string K_SP_sysProfiliFunzioni_DELETE = "BSP_" + K_TBL_sysProfiliFunzioni + "_DELETE";
    private const string K_TBL_FUNZIONI = "sysFunzioni";
    private const string K_SP_SELECT_FUNZIONI = "BSP_" + K_TBL_FUNZIONI + "_LOADTREE";

    private enum eIDTreeView : byte
    {
      ID = 1,
      ID_RUOLO = 2
    }

    // DEFINIZIONE PROPRIETA sysProfiliFunzioni
    #region private List<BsysProfiliFunzioni> sysProfiliFunzioni
    private string K_SE_sysProfiliFunzioni = ".sysProfiliFunzioni";
    private List<BsysProfiliFunzioni> sysProfiliFunzioni
    {
      get
      {
        List<BsysProfiliFunzioni> obj;
        obj = (List<BsysProfiliFunzioni>)base.Session[base.ID + K_SE_sysProfiliFunzioni];
        if (obj == null)
        {
          obj = new List<BsysProfiliFunzioni>();
        }
        return obj;
      }
      set
      {
        base.Session[base.ID + K_SE_sysProfiliFunzioni] = value;
      }
    }
    #endregion
    #region private BWebControlTableBase.eStatusDetails StatosysProfiliFunzioni
    private string K_VS_STATO_sysProfiliFunzioni = ".StatosysProfiliFunzioni";
    private BWebControlTableBase.eStatusDetails StatosysProfiliFunzioni
    {
      get
      {
        return (BWebControlTableBase.eStatusDetails)this.ViewState[base.ID + K_VS_STATO_sysProfiliFunzioni];
      }
      set
      {
        this.ViewState[base.ID + K_VS_STATO_sysProfiliFunzioni] = value;
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
        this.Internal_imgImmagine.AbilitaUpload = value;
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
    public BImage imgImmagine
    {
      get
      {
        return this.Internal_imgImmagine;
      }
      set
      {
        this.Internal_imgImmagine = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES

    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtDescrizione.ClientID;
      mbtDescrizione.CtlNextFocus = mbtDataInizio.ClientID;
      mbtDataInizio.CtlNextFocus = mbtDataFine.ClientID;
      mbtDataFine.CtlNextFocus = mbtNote.ClientID;
      if (this.CtlBtnSalva != null)
        mbtNote.CtlNextFocus = this.CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      this.ddlRoles.NomeTabella = "sysRuoli";
      this.ddlRoles.CampoDescr = "Descrizione";
      this.ddlRoles.CampoKey = "ID";
      this.ddlRoles.CampiOrdinati = "Descrizione";
      this.ddlRoles.Init(this.DB.Setting);
      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      BtnModRole.Click += BtnModRole_Click;
      pnlModificaRuolo.Conferma += pnlModificaRuolo_Conferma;
      pnlModificaRuolo.Annulla += pnlModificaRuolo_Annulla;

      base.SetAttributes_AddEvents();
    }

    protected override void OnLoad(EventArgs e)
    {
      this.tvwMenu.Attributes.Add("onclick", "OnTreeClick(event)");
      if (!base.IsPostBack)
      {
        WebControl argctl = (WebControl)this.pnlModificaRuolo;
        BGlobalNet.DisplayNone(ref argctl);
      }
      base.OnLoad(e);
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "-1";
      mbtDescrizione.Text = "";
      mbtDataInizio.Text = "";
      mbtDataFine.Text = "";
      mbtNote.Text = "";
      imgImmagine.ImageUrl = "";
      imgImmagine.ImageByte = null;

      // DETTAGLIO sysProfiliFunzioni
      GenerateTreeView();

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtDescrizione.Focus();
    }
    public override bool CambiaRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysProfili MyObj = null;
      try
      {
        if (Obj == null) return false;
        MyObj = (BsysProfili)Obj;
        mbtID.Text = MyObj.ID.ToString();
        mbtID.Enabled = false;
        mbtDescrizione.Text = MyObj.Descrizione;
        mbtDataInizio.Text = BGlobal.FormattaData(MyObj.DataInizio);
        mbtDataFine.Text = BGlobal.FormattaData(MyObj.DataFine);
        mbtNote.Text = MyObj.Note;
        imgImmagine.ImageByte = MyObj.Immagine;

        // GESTIONE TABELLA DETTAGLIO
        GenerateTreeView();


        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtDescrizione.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BArts.BBaseClass.BBaseObject ScriviRec(BArts.BBaseClass.BBaseObject Obj)
    {
      BsysProfili MyObj = null;
      bool Ret = false;
      try
      {
        this.IsCheckBeforeUpdateFailled = !this.CheckBeforeUpdate();
        if (this.IsCheckBeforeUpdateFailled) return null;
        MyObj = (BsysProfili)Obj;
        if (MyObj != null)
        {
          MyObj.ID = BConvert.ToInt(mbtID.Text);
          MyObj.Descrizione = mbtDescrizione.Text;
          MyObj.DataInizio = BGlobal.PrendiData(mbtDataInizio.Text);
          MyObj.DataFine = BGlobal.PrendiData(mbtDataFine.Text);
          MyObj.Note = mbtNote.Text;
          MyObj.Immagine = imgImmagine.ImageByte;

          // SCRIVI DETTAGLIO sysProfiliFunzioni
          MyObj.Funzioni = sysProfiliFunzioni;
          if (MyObj.Update())
          {
            if (ScriviDettaglio(MyObj))
            {
              Ret = true;
            }
            else
            {
              Ret = false;
            }
          }
          else
          {
            Ret = false;
          }
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysProfili");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysProfiliFunzioni
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysProfilo", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysProfiliFunzioni_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }


    // DEFINIZIONE FUNZIONI PRIVATE
    private DataSet CaricaDSFunzioni()
    {
      DataTable dt;
      DataSet ds;
      try
      {
        base.DB.Parameters.Clear();
        if (!string.IsNullOrEmpty(mbtID.Text)) base.DB.AddParameter("@IDSysProfilo", mbtID.Text);
        dt = DB.ApriDT(K_SP_SELECT_FUNZIONI, CommandType.StoredProcedure);
        if (!Information.IsNothing(dt) && dt.Rows.Count > 0)
        {
          ds = new DataSet();
          ds.Tables.Add(dt);
          ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["id"] };
          ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["id"], ds.Tables[0].Columns["IDPadre"], false);
          return ds;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.CaricaDSFunzioni():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }
    private void GenerateTreeView()
    {
      TreeNode nodo;
      DataSet ds = null;
      try
      {
        ds = CaricaDSFunzioni();
        this.tvwMenu.ShowCheckBoxes = TreeNodeTypes.All;
        this.tvwMenu.Nodes.Clear();
        if (ds != null)
        {
          foreach (DataRow row1 in ds.Tables[0].Rows)
          {
            if (row1.IsNull("IDPadre") | ds.Tables[0].Rows.Find(row1["IDPadre"]) == null)
            {
              nodo = new TreeNode();
              nodo.Text = row1["Descrizione"].ToString();
              if (!(row1["IDsysRuoloDescrizione"] == DBNull.Value))
                nodo.Text += " - Ruolo: " + row1["IDsysRuoloDescrizione"].ToString();
              nodo.Value = row1["Id"].ToString() + "|" + row1["IDsysRuolo"].ToString();
              if (!(row1["IDSysProfilo"] == DBNull.Value))
              {
                nodo.Checked = true;
              }
              else
              {
                nodo.Checked = false;
              }

              if (row1.GetChildRows("NodeRelation").Length != 0)
              {
                CaricaNodiFigli(row1, ref nodo);
              }

              this.tvwMenu.Nodes.Add(nodo);
            }
          }

          this.tvwMenu.ExpandAll();
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.GenerateTreeView():", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }
    private void CaricaNodiFigli(DataRow dr, ref TreeNode nodoPadre)
    {
      TreeNode nodo;
      try
      {
        nodoPadre.ChildNodes.Clear();
        foreach (DataRow row1 in dr.GetChildRows("NodeRelation"))
        {
          nodo = new TreeNode();
          nodo.Text = row1["Descrizione"].ToString();
          if (!(row1["IDsysRuoloDescrizione"] == DBNull.Value))
            nodo.Text += " - Ruolo: " + row1["IDsysRuoloDescrizione"].ToString();
          nodo.Value = row1["Id"].ToString() + "|" + row1["IDsysRuolo"].ToString();
          if (!(row1["IDSysProfilo"] == DBNull.Value))
          {
            nodo.Checked = true;
          }
          else
          {
            nodo.Checked = false;
          }

          if (row1.GetChildRows("NodeRelation").Length != 0)
          {
            CaricaNodiFigli(row1, ref nodo);
          }

          nodoPadre.ChildNodes.Add(nodo);
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.CaricaNodiFigli():", "", ex, BEnumerations.eSeverity.ERROR);
      }
    }
    private void SalvaRuoloFigli(TreeNode nodoPadre)
    {
      string[] s;
      foreach (TreeNode n in nodoPadre.ChildNodes)
      {
        if (n.Checked)
        {
          s = n.Text.Split(char.Parse(" - Ruolo: "));
          n.Text = s[0] + " - Ruolo: " + this.ddlRoles.SelectedItem.ToString();
          s = n.Value.Split('|');
          n.Value = s[0] + "|" + this.ddlRoles.SelectedValue.ToString();
          if (n.ChildNodes.Count > 0)
          {
            SalvaRuoloFigli(n);
          }
        }
      }
    }
    private bool ScriviDettaglio(BsysProfili ObjProfilo)
    {
      BsysProfiliFunzioni pf;
      if (this.EliminaDettaglio(ObjProfilo.ID))
      {
        foreach (TreeNode n in this.tvwMenu.Nodes)
        {
          if (n.Checked)
          {
            pf = new BsysProfiliFunzioni(base.DB);
            pf.IDSysProfilo = ObjProfilo.ID;
            pf.IDSysFunzione = int.Parse(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID));
            if (!string.IsNullOrEmpty(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID_RUOLO)))
            {
              pf.IDSysRuolo = int.Parse(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID_RUOLO));
            }

            pf.Update();
            if (n.ChildNodes.Count > 0)
              ScriviDettaglioRicorsivo(ObjProfilo, n);
          }
        }
      }

      return true;
    }
    private bool ScriviDettaglioRicorsivo(BsysProfili ObjProfilo, TreeNode nPadre)
    {
      BsysProfiliFunzioni pf;
      foreach (TreeNode n in nPadre.ChildNodes)
      {
        if (n.Checked)
        {
          pf = new BsysProfiliFunzioni(base.DB);
          pf.IDSysProfilo = ObjProfilo.ID;
          pf.IDSysFunzione = int.Parse(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID));
          if (!string.IsNullOrEmpty(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID_RUOLO)))
          {
            pf.IDSysRuolo = int.Parse(BGlobal.PrendiParteStr(n.Value, (byte)eIDTreeView.ID_RUOLO));
          }

          pf.Update();
          if (n.ChildNodes.Count > 0)
            ScriviDettaglioRicorsivo(ObjProfilo, n);
        }
      }

      return true;
    }
    private bool EliminaDettaglio(int IDProfilo)
    {
      try
      {
        this.DB.ClearParameter();
        this.DB.AddParameter("@IDSysProfilo", IDProfilo);
        if (this.DB.ExecuteNonQuery("BSP_sysProfiliFunzioni_DELETE", CommandType.StoredProcedure) >= 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysProfili.EliminaDettaglio():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI SUL POPUP
    protected void BtnModRole_Click(object sender, EventArgs e)
    {
      string s = "";
      if (!string.IsNullOrEmpty(this.tvwMenu.SelectedValue))
      {
        this.mbtFunzione.Text = this.tvwMenu.SelectedNode.Text;
        s = this.tvwMenu.SelectedNode.Value;
        s = BGlobal.PrendiParteStr(s, 2);
        if (!string.IsNullOrEmpty(s))
        {
          this.ddlRoles.SelectedValue = s;
        }
        else
        {
          this.ddlRoles.SelectedIndex = 0;
        }

        this.ddlRoles.Focus();
        this.pnlModificaRuolo.Titolo = "Modifica Ruolo";
        this.pnlModificaRuolo.Show();
      }
      else
      {
        this.MsgBox("Selezionare una funzione");
      }
    }
    private void pnlModificaRuolo_Conferma()
    {
      string[] s;
      if (!string.IsNullOrEmpty(this.tvwMenu.SelectedValue))
      {
        s = this.tvwMenu.SelectedNode.Text.Split(char.Parse(" - Ruolo: "));
        this.tvwMenu.SelectedNode.Text = s[0] + " - Ruolo: " + this.ddlRoles.SelectedItem.ToString();
        s = this.tvwMenu.SelectedNode.Value.Split('|');
        this.tvwMenu.SelectedNode.Value = s[0] + "|" + this.ddlRoles.SelectedValue.ToString();
      }
      else
      {
        foreach (TreeNode n in this.tvwMenu.Nodes)
        {
          if (n.Checked)
          {
            s = n.Text.Split(char.Parse(" - Ruolo: "));
            n.Text = s[0] + " - Ruolo: " + this.ddlRoles.SelectedItem.ToString();
            s = n.Value.Split('|');
            n.Value = s[0] + "|" + this.ddlRoles.SelectedValue.ToString();
            if (n.ChildNodes.Count > 0)
            {
              SalvaRuoloFigli(n);
            }
          }
        }

        this.mbtFunzione.Text = "Funz. selezionate";
      } ((BPageBase)this.Page).ShowToast("Per rendere effettiva la modifica, Premere il tasto Salva", "Info");
      this.pnlModificaRuolo.Hide();
    }
    private void pnlModificaRuolo_Annulla()
    {
      this.pnlModificaRuolo.Hide();
    }

  } //END CLASS
} //END NAMESPACE