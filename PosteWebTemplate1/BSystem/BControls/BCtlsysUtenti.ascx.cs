// *****************************************************
// *** Classe generata con BStudio 2017 [Ver. 3.0.3] ***
// *****************************************************
using BArts;
using BArts.BBaseClass;
using BArts.BData;
using BArts.BGlobal;
using BArts.BWeb.BControls;
using BIPosteBaseLibraryCS;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Configuration.ConfigurationManager;
using VbStrConv = BArts.BEnumerations.VbStrConv;

namespace PosteWebTemplate1
{
  public partial class BCtlsysUtenti : BWebControlTableBase
  {

    // DEFINIZIONE DATI
    private const string K_TBL_sysUtentiProfili = "sysUtentiProfili";
    private const string K_SP_sysUtentiProfili_DELETE = "BSP_" + K_TBL_sysUtentiProfili + "_DELETE";

    // DEFINIZIONE PROPRIETA sysUtentiProfili
    private string K_SE_sysUtentiProfili = ".sysUtentiProfili";
    private List<BsysUtentiProfili> sysUtentiProfili
    {
      get
      {
        List<BsysUtentiProfili> obj;
        obj = (List<BsysUtentiProfili>)base.Session[base.ID + K_SE_sysUtentiProfili];
        if (obj == null)
        {
          obj = new List<BsysUtentiProfili>();
        }

        return obj;
      }

      set
      {
        base.Session[base.ID + K_SE_sysUtentiProfili] = value;
      }
    }

    private string K_VS_STATO_sysUtentiProfili = ".StatosysUtentiProfili";
    private BWebControlTableBase.eStatusDetails StatosysUtentiProfili
    {
      get
      {
        return (BWebControlTableBase.eStatusDetails)this.ViewState[base.ID + K_VS_STATO_sysUtentiProfili];
      }

      set
      {
        this.ViewState[base.ID + K_VS_STATO_sysUtentiProfili] = value;
      }
    }


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
    public BTesto mbtIDPersona
    {
      get
      {
        return this.Internal_mbtIDPersona;
      }

      set
      {
        this.Internal_mbtIDPersona = value;
      }
    }
    public BTesto mbtPersona
    {
      get
      {
        return this.Internal_mbtPersona;
      }

      set
      {
        this.Internal_mbtPersona = value;
      }
    }
    public BCombo mbcIDVisibilita
    {
      get
      {
        return this.Internal_mbcIDVisibilita;
      }

      set
      {
        this.Internal_mbcIDVisibilita = value;
      }
    }
    public BSwitch chkAttivo
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
    public BCheck chkDeveloper
    {
      get
      {
        return this.Internal_chkDeveloper;
      }

      set
      {
        this.Internal_chkDeveloper = value;
      }
    }
    public BTesto mbtDominio
    {
      get
      {
        return this.Internal_mbtDominio;
      }

      set
      {
        this.Internal_mbtDominio = value;
      }
    }
    public BTesto mbtUsername
    {
      get
      {
        return this.Internal_mbtNomeUtente;
      }
      set
      {
        this.Internal_mbtNomeUtente = value;
      }
    }

    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void SetAttributes_Invio()
    {
      mbtID.CtlNextFocus = mbtPersona.ClientID;
      mbtPersona.CtlNextFocus = mbcIDVisibilita.ClientID;
      mbcIDVisibilita.CtlNextFocus = mbtDominio.ClientID;
      mbtDominio.CtlNextFocus = mbtUsername.ClientID;
      mbtUsername.CtlNextFocus = chkAttivo.ClientID;
      chkAttivo.CtlNextFocus = tvwProfili.ClientID;

      mbcIDSysSistema.CtlNextFocus = mbcIDSysProfilo.ClientID;
      mbcIDSysProfilo.CtlNextFocus = CtlBtnSalva.ClientID;
    }
    public override void SetAttributes_Other()
    {
      mbcIDSysSistema.Init(this.DB.Setting);
      mbcIDSysSistema.Items.Insert(0, new ListItem("NESSUN SISTEMA PREDEFINITO", "-1"));
      mbcIDSysProfilo.Init(this.DB.Setting);
      mbcIDSysProfilo.Items.Insert(0, new ListItem("NESSUN PROFILO PREDEFINITO", "-1"));

      BConnection BIPosteDB = new BConnection(DB.Setting.NomeServer, AppSettings["DB_LIBRARY_BIPOSTE"], DB.Setting.Utente, DB.Setting.Password);
      mbcIDVisibilita.Init(BIPosteDB.Setting);
      mbcIDVisibilita.Items.Insert(0, new ListItem("NESSUNA SELEZIONE", "-1"));

      // LOAD TVW
      this.tvwProfili.DynamicLoading = false;
      this.tvwProfili.ShowCheckBoxes = TreeNodeTypes.Leaf;
      this.tvwProfili.ShowLines = false;
      base.SetAttributes_Other();
    }
    public override void SetAttributes_AddEvents()
    {
      mbtPersona.HelpButtonClick += mbtID_HelpButtonClick;
      mbtID.HelpButtonClick += mbtID_HelpButtonClick;
      BtnEliminaPersona.Click += BtnEliminaPersona_Click;
      BCtlsysPersonaleSearch.Selected += BCtlsysPersonaleSearch_Selected;
      base.SetAttributes_AddEvents();
    }



    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    public override void NuovoRec()
    {
      mbtID.Text = "";
      mbtID.Enabled = true;
      mbcIDSysSistema.SelectedIndex = 0;
      mbcIDSysProfilo.SelectedIndex = 0;
      mbtIDPersona.Text = "";
      mbtPersona.Text = "";
      mbcIDVisibilita.SelectedIndex = 0;
      chkAttivo.Checked = false;
      chkDeveloper.Checked = false;
      mbtDominio.Text = "";
      mbtUsername.Text = "";

      // DETTAGLIO sysUtentiProfili
      LoadTvw(new List<BsysUtentiProfili>());

      // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
      mbtID.Focus();
    }
    public override bool CambiaRec(BBaseObject Obj)
    {
      BsysUtenti MyObj = null;
      try
      {
        if (Obj == null)
          return false;
        MyObj = (BsysUtenti)Obj;
        mbtID.Text = MyObj.ID;
        mbtID.Enabled = false;

        mbcIDSysSistema.SelectedValue = MyObj.IDSysSistema.ToString();
        mbcIDSysProfilo.SelectedValue = MyObj.IDSysProfilo.ToString();
        if (MyObj.IDPersona != -1)
        {
          mbtIDPersona.Text = MyObj.IDPersona.ToString();
          BPersonale p = new BPersonale(MyObj.IDPersona, DB);
          if (p != null && !p.IsNothing)
          {
            mbtPersona.Text = p.Descrizione;
          }
          else
          {
            mbtIDPersona.Text = "-1";
            mbtPersona.Text = "";
          }
        }
        else
        {
          mbtIDPersona.Text = "-1";
          mbtPersona.Text = "";
        }

        if (mbcIDVisibilita.Items.FindByValue(MyObj.IDVisibilita.ToString()) == null)
        {
          mbcIDVisibilita.SelectedValue = "-1";
        }
        else
        {
          mbcIDVisibilita.SelectedValue = MyObj.IDVisibilita.ToString();
        }

        chkAttivo.Checked = MyObj.Attivo;
        chkDeveloper.Checked = MyObj.Developer;
        mbtDominio.Text = MyObj.Dominio;
        mbtUsername.Text = MyObj.Username;

        // CARICA DETTAGLIO sysUtentiProfili
        this.LoadTvw(MyObj.Profili);

        // IMPOSTO IL FUOCO SUL PRIMO CONTROLLO UTILE
        mbtID.Focus();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("sysUtenti.CambiaRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public override BBaseObject ScriviRec(BBaseObject Obj)
    {
      BsysUtenti MyObj = null;
      bool Ret = false;
      try
      {
        if (!CheckBeforeUpdate(Obj))
        {
          ((BPageTableBase)this.Page).RetValueCheckBeforeUpdate = false;
          return null;
        }
        else
        {
          ((BPageTableBase)this.Page).RetValueCheckBeforeUpdate = true;
        }

        MyObj = (BsysUtenti)Obj;
        if (MyObj != null)
        {
          MyObj.ID = mbtID.Text;
          MyObj.IDSysSistema = BConvert.ToInt(mbcIDSysSistema.SelectedValue);
          MyObj.IDSysProfilo = BConvert.ToInt(mbcIDSysProfilo.SelectedValue);
          MyObj.IDPersona = BConvert.ToInt(mbtIDPersona.Text);

          MyObj.IDVisibilita = BConvert.ToInt(mbcIDVisibilita.SelectedValue);
          MyObj.Attivo = chkAttivo.Checked;
          MyObj.Developer = false;
          MyObj.Dominio = mbtDominio.Text;
          MyObj.Username = mbtUsername.Text;
          MyObj.DataCreazione = DateAndTime.Now;

          // SCRIVI DETTAGLIO sysUtentiProfili
          MyObj.Profili = SaveTvw();
          Ret = MyObj.Update();
        }

        if (Ret)
        {
          BSysUtenteEntrato.WriteOperation("SALVATAGGIO DEL RECORD IDENTIFICATO DALLA CHIAVE <<[ID] = " + mbtID.Text + ";>> DELLA TABELLA sysUtenti");
          return MyObj;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("sysUtenti.ScriviRec():", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    protected override bool CheckBeforeUpdate(BBaseObject Obj)
    {
      BsysUtenti MyObj = null;
      MyObj = (BsysUtenti)Obj;

      if (string.IsNullOrEmpty(mbtID.Text))
      {
        this.MsgBox("ID Utente Obbligatorio");
        mbtID.Focus();
        return false;
      }


      if (string.IsNullOrEmpty(mbtDominio.Text))
      {
        this.MsgBox("Dominio Obbligatorio");
        mbtDominio.Focus();
        return false;
      }


      if (string.IsNullOrEmpty(mbtUsername.Text))
      {
        this.MsgBox("Nome utente Obbligatorio");
        mbtUsername.Focus();
        return false;
      }

      if (MyObj != null)
      {
        if (MyObj.IsNothing) // NUOVOREC
        {
          if (BGlobal.EsistonoRecord("sysUtenti", base.DB, "username = '" + mbtUsername.Text + "' AND dominio= '" + mbtDominio.Text + "'"))
          {
            this.MsgBox("Username già presente per il dominio specificato.");
            mbtUsername.Focus();
            return false;
          }
        }
        else if (mbtUsername.Text != MyObj.Username || mbtDominio.Text != MyObj.Dominio) // MODIFICA
        {
          if (BGlobal.EsistonoRecord("sysUtenti", base.DB, "username = '" + mbtUsername.Text + "' AND dominio= '" + mbtDominio.Text + "'"))
          {
            this.MsgBox("Username già presente per il dominio specificato.");
            mbtUsername.Focus();
            return false;
          }
        }
      }

      //CONTROLLI SUI PROFILI

      if (this.tvwProfili.CheckedNodes.Count == 0 && mbcIDSysProfilo.SelectedValue == "-1")
      {
        this.MsgBox("Nessun profilo selezionato");
        this.tvwProfili.Focus();
        return false;
      }
      else if (this.tvwProfili.CheckedNodes.Count == 1 && mbcIDSysProfilo.SelectedValue == "-1")
      {
        if (this.tvwProfili.CheckedNodes[0].Parent != null)
        {
          mbcIDSysSistema.SelectedValue = this.tvwProfili.CheckedNodes[0].Parent.Value;
        }
        else
        {
          mbcIDSysSistema.SelectedValue = GetSistemaDefault().ToString();
        }

        mbcIDSysProfilo.SelectedValue = this.tvwProfili.CheckedNodes[0].Value;
      }
      else
      {
        if (IsMultiSistema() && mbcIDSysSistema.SelectedValue == "-1")
        {
          this.MsgBox("Sistema non impostato");
          mbcIDSysSistema.Focus();
          return false;
        }
        else
        {
          bool ret = false;
          foreach (TreeNode n in this.tvwProfili.CheckedNodes)
          {
            if (n.Parent != null)
            {
              if (n.Parent.Value == mbcIDSysSistema.SelectedValue)
              {
                ret = true;
                break;
              }
            }
            else
            {
              ret = true;
              break;
            }
          }

          if (!ret)
          {
            this.MsgBox("Il sistema di default non risulta tra i profili selezionati");
            mbcIDSysSistema.Focus();
            return false;
          }
        }

        if (mbcIDSysProfilo.SelectedValue == "-1")
        {
          this.MsgBox("Inserimento Obbligatorio");
          mbcIDSysProfilo.Focus();
          return false;
        }
        else
        {
          bool ret = false;
          foreach (TreeNode n in this.tvwProfili.CheckedNodes)
          {
            if (mbcIDSysProfilo.SelectedValue == n.Value)
            {
              ret = true;
              break;
            }
          }

          if (!ret)
          {
            this.MsgBox("Il profilo di default non risulta tra i profili selezionati");
            mbcIDSysProfilo.Focus();
            return false;
          }
        }
      }

      return base.CheckBeforeUpdate();
    }
    protected override bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      // RIMOZIONE RECORD RELAZIONATI sysUtentiProfili
      base.DB.ClearParameter();
      base.DB.AddParameter("@IDSysUtente", this.GetValueFromKey("ID", ParamsKey));
      base.DB.ExecuteNonQuery(K_SP_sysUtentiProfili_DELETE, CommandType.StoredProcedure);
      return base.DeleteRowsRelation(ParamsKey);
    }

    // DEFINIZIONE FUNZIONI PRIVATE 
    private bool IsMultiSistema()
    {
      List<BsysSistemi> cSistemi = null;
      var Res = BsysSistemi.GetElenco(this.DB).AsEnumerable();
      cSistemi = (from item in Res
                  select new BsysSistemi(item, this.DB)).ToList();
      if (cSistemi.Count > 1)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private int GetSistemaDefault()
    {
      List<BsysSistemi> cSistemi = null;
      var Res = BsysSistemi.GetElenco(this.DB).AsEnumerable();
      cSistemi = (from item in Res
                  select new BsysSistemi(item, this.DB)).ToList();
      if (cSistemi.Count == 1)
      {
        return cSistemi[0].ID;
      }
      else
      {
        return base.UtenteEntrato.IDSistema;
      } // CType(UtenteEntrato, BSysUtenti).IDSysSistema
    }

    private void LoadTvw(List<BsysUtentiProfili> Profili)
    {
      List<BsysSistemi> cSistemi = null;
      List<BsysProfili> cProfili = null;
      TreeNode nS = null;
      TreeNode nP = null;
      try
      {
        this.tvwProfili.AutoCheck = true;
        this.tvwProfili.Nodes.Clear();
        var Res = BsysSistemi.GetElenco(this.DB).AsEnumerable();
        cSistemi = (from item in Res
                    select new BsysSistemi(item, this.DB)).ToList();
        var rProfili = BsysProfili.GetElenco(this.DB).AsEnumerable();
        cProfili = (from item in rProfili
                    select new BsysProfili(item, this.DB)).ToList();
        if (cSistemi != null && cSistemi.Count > 0)
        {
          if (cSistemi.Count == 1)
          {
            int IDSistema = -1;
            IDSistema = GetSistemaDefault();
            mbcIDSysSistema.SelectedValue = IDSistema.ToString();
            this.DivCtlSistema.Visible = false;
            this.DivLblSistema.Visible = false;
            foreach (BsysProfili ObjP in cProfili)
            {
              nP = new TreeNode(ObjP.Descrizione, ObjP.ID.ToString());
              var ObjUP = Profili.Find(x => x.IDSysProfilo == ObjP.ID & x.IDSysSistema == IDSistema);
              if (ObjUP != null)
              {
                nP.Checked = true;
              }
              else
              {
                nP.Checked = false;
              }

              this.tvwProfili.Nodes.Add(nP);
            }
          }
          else
          {
            foreach (BsysSistemi ObjS in cSistemi)
            {
              nS = new TreeNode("Sistema " + BGlobal.FormattaTesto(ObjS.Descrizione, VbStrConv.ProperCase), ObjS.ID.ToString());
              this.tvwProfili.Nodes.Add(nS);
              if (cProfili != null && cProfili.Count > 0)
              {
                foreach (BsysProfili ObjP in cProfili)
                {
                  nP = new TreeNode(ObjP.Descrizione, ObjP.ID.ToString());
                  var ObjUP = Profili.Find(x => x.IDSysProfilo == ObjP.ID & x.IDSysSistema == ObjS.ID);
                  if (ObjUP != null)
                  {
                    nP.Checked = true;
                  }
                  else
                  {
                    nP.Checked = false;
                  }

                  nS.ChildNodes.Add(nP);
                }
              }
            }
          }
        }
        else
        {
          int IDAccesso = -1;
          string IDSysUtente = "";
          if (base.UtenteEntrato != null && !UtenteEntrato.IsNothing)
          {
            IDAccesso = this.UtenteEntrato.IDAccesso;
            IDSysUtente = this.UtenteEntrato.Username;
          }

          ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, null, "sysUtenti.LoadTvw():", "NON CI SONO SISTEMI!!", BEnumerations.eSeverity.WARNING, IDAccesso, this.Page);
        }

        this.tvwProfili.ExpandAll();
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

        ModLog.ScriviLog(this.DB, (BConfiguration)this.Config, IDSysUtente, ex, "sysUtenti.LoadTvw():", "", BEnumerations.eSeverity.ERROR, IDAccesso, this.Page);
      }
    }
    private List<BsysUtentiProfili> SaveTvw()
    {
      var l = new List<BsysUtentiProfili>();
      BsysUtentiProfili Obj = null;
      foreach (TreeNode n in this.tvwProfili.CheckedNodes)
      {
        if (n.Parent != null)
        {
          Obj = new BsysUtentiProfili(this.DB);
          Obj.IDSysUtente = mbtID.Text;
          Obj.IDSysSistema = int.Parse(n.Parent.Value);
          Obj.IDSysProfilo = int.Parse(n.Value);
          l.Add(Obj);
        }
        else
        {
          Obj = new BsysUtentiProfili(this.DB);
          Obj.IDSysUtente = mbtID.Text;
          Obj.IDSysSistema = GetSistemaDefault();
          Obj.IDSysProfilo = int.Parse(n.Value);
          l.Add(Obj);
        }
      }

      if (l.Count == 0) // ADD DEFAULT
      {
        Obj = new BsysUtentiProfili(this.DB);
        Obj.IDSysUtente = mbtID.Text;
        Obj.IDSysSistema = int.Parse(mbcIDSysSistema.SelectedValue);
        Obj.IDSysProfilo = int.Parse(mbcIDSysProfilo.SelectedValue);
        l.Add(Obj);
      }

      return l;
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void mbtID_HelpButtonClick()
    {
      this.BCtlsysPersonaleSearch.InitControl();
      this.BCtlsysPersonaleSearch.ResetSearch();
      this.BCtlsysPersonaleSearch.Show();
    }
    private void BCtlsysPersonaleSearch_Selected(List<BIPosteBaseLibraryCS.BPersonale> l)
    {
      if (l != null && l.Count == 1)
      {
        mbtID.Text = l[0].NTDomain + "@" + l[0].NTAccount;
        if (string.IsNullOrEmpty(mbtUsername.Text))
          mbtUsername.Text = l[0].NTAccount;
        if (string.IsNullOrEmpty(mbtDominio.Text))
          mbtDominio.Text = l[0].NTDomain;
        this.Internal_mbtIDPersona.Text = l[0].ID.ToString();
        this.Internal_mbtPersona.Text = l[0].Cognome + " " + l[0].Nome + " [" + l[0].CodiceFiscale + "]";
        this.BCtlsysPersonaleSearch.Hide();
      }
      else
      {
        base.MsgBox("Ricerca fallita");
      }
    }



    private void BtnEliminaPersona_Click(object sender, EventArgs e)
    {
      this.Internal_mbtIDPersona.Text = "";
      this.Internal_mbtPersona.Text = "";
    }



  } //END CLASS
} //END NAMESPACE