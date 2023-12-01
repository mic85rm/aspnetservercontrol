using BArts.BBaseClass;
using System;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BPageOneRecordBase : BPageBase
  {
    public BPageOneRecordBase()
    {
      // ATTACH EVENTI INTERCETTATI
      this.Init += Page_Init;
      this.Load += Page_Load;
    }

    // DEFINIZIONE DATI
    protected enum eStatusDetails : byte
    {
      NUOVO,
      VISIONE,
      MODIFICA
    }

    public bool RetValueCheckBeforeUpdate = true;

    // DEFINIZIONE EVENTI
    public event OnInitBeforeEventHandler OnInitBefore;
    public delegate void OnInitBeforeEventHandler(object sender, EventArgs e);

    public event OnInitAfterEventHandler OnInitAfter;
    public delegate void OnInitAfterEventHandler(object sender, EventArgs e);

    public event OnLoadBeforeEventHandler OnLoadBefore;
    public delegate void OnLoadBeforeEventHandler(object sender, EventArgs e);

    public event OnLoadAfterEventHandler OnLoadAfter;
    public delegate void OnLoadAfterEventHandler(object sender, EventArgs e);

    // DEFINIZIONE PROPRIETA' PROTECTED
    #region protected eStatusDetails StatoDetails
    private string K_VS_STATODETAILS = ".StatoDetails";
    protected eStatusDetails StatoDetails
    {
      get
      {
        return (eStatusDetails)this.ViewState[PageName + K_VS_STATODETAILS];
      }
      set
      {
        this.ViewState[PageName + K_VS_STATODETAILS] = value;
      }
    }
    #endregion

    // DEFINIZIONE PROPRIETA' 
    protected string PageName { get; set; }
    protected int ID_ONE_RECORD { get; set; }


    // DEFINIZIONE VARIABILI PER GESTIONE CONTROLLI
    protected Panel CtlPnlDettaglio;
    protected WebControl CtlBtnSalva;
    protected WebControl CtlBtnAnnulla;
    protected WebControl FirstCtlDettaglio;

    // DEFINIZIONE FUNZIONI MUST OVERRIDES
    protected abstract bool InitBTablePage();

    // DEFINIZIONE FUNZIONI OVERRIDABLE
    protected virtual void SetAttributes_Invio()
    {
      // NESSUNA OPERAZIONE
    }
    protected virtual void SetAttributes_Other()
    {
      // NESSUNA OPERAZIONE
    }
    protected virtual bool CheckBeforeUpdate()
    {
      // AGGIUNGERE QUI EVENTUALI CONTROLLI LOGICI SUI CONTROLLI
      return true;
    }
    protected virtual bool CheckBeforeUpdate(BBaseObject Obj)
    {
      return true;
    }

    // DEFINIZIONE FUNZIONI MUST OVERRIDES DI GESTIONE
    protected abstract BBaseObject LoadObject();
    protected abstract void NuovoRec();
    protected abstract bool CambiaRec(BBaseObject Obj);
    protected abstract BBaseObject ScriviRec(BBaseObject Obj);

    // DEFINIZIONE METODI
    protected void Nuovo()
    {
      NuovoRec();
      StatoDetails = eStatusDetails.NUOVO;
    }
    protected bool Modifica(BBaseObject Obj)
    {
      if (!CambiaRec(Obj))
      {
        this.MsgBox("Si è verificato un errore durante il caricamento dei dati.");
        return false;
      }
      else
      {
        StatoDetails = eStatusDetails.MODIFICA;
        return true;
      }
    }
    protected bool Salva(BBaseObject Obj)
    {
      Obj = ScriviRec(Obj);
      if (Obj != null)
      {
        Modifica(Obj);
        return true;
      }
      else
      {
        return false;
      }
    }
    protected void Annulla()
    {
      var obj = LoadObject();
      if (obj != null)
      {
        if (obj.IsNothing)
        {
          Nuovo();
        }
        else
        {
          Modifica(obj);
        }
      }
    }

    protected void DisabledButton(bool Disabled = false)
    {
      if (CtlBtnAnnulla != null)
        CtlBtnAnnulla.Enabled = !Disabled;
      if (CtlBtnSalva != null)
        CtlBtnSalva.Enabled = !Disabled;
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadAttribtes()
    {
      if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return false;
      CtlPnlDettaglio.CssClass = CtlPnlDettaglio.CssClass.Replace("ShowForDesign", "");
      this.SetAttributes_Invio();
      this.SetAttributes_Other();
      return true;
    }

    //DEFINIZIONE EVENTI INTERCETTATI
    private void Page_Init(object sender, EventArgs e)
    {
      if (!this.CheckSession()) return;
      OnInitBefore?.Invoke(sender, e);
      this.InitBTablePage();
      if (!this.IsPostBack) this.LoadAttribtes();
      OnInitAfter?.Invoke(sender, e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!this.CheckSession()) return;
      //if (base.Session[ModConstantList.K_SE_SYSINITAPP] == null) return;
      OnLoadBefore?.Invoke(sender, e);
      if (!this.IsPostBack)
      {
        var obj = LoadObject();
        if (obj != null)
        {
          if (obj.IsNothing)
          {
            Nuovo();
          }
          else
          {
            Modifica(obj);
          }
        }
      }

      OnLoadAfter?.Invoke(sender, e);
    }

  }//END CLASS
}//END NAMESPACE