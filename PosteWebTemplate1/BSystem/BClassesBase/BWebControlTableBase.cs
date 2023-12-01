using BArts;
using BArts.BBaseClass;
using BArts.RSSQL2000;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public abstract class BWebControlTableBase : BWebControlsBase
  {
    //DEFINIZIONE COSTRUTTORI
    public BWebControlTableBase() : base()
    {
    }

    // DEFINIZIONE DATI
    protected enum eStatusPage : byte
    {
      ELENCO,
      DETTAGLIO
    }
    protected enum eStatusDetails : byte
    {
      NUOVO,
      VISIONE,
      MODIFICA
    }

    // DEFINIZIONE VARIABILI PER GESTIONE CONTROLLI
    public WebControl CtlBtnSalva;
    public WebControl CtlBtnAnnulla;
    public WebControl CtlBtnElimina;
    public WebControl CtlBtnStampa;

    public bool IsCheckBeforeUpdateFailled { get; set; }

    // DEFINIZIONE FUNZIONI MUST OVERRIDES DI GESTIONE
    public abstract void NuovoRec();
    public abstract bool CambiaRec(BBaseObject Obj);
    public abstract BBaseObject ScriviRec(BBaseObject Obj);


    // DEFINIZIONE METODI OVERRIDABLE
    public virtual void SetAttributes_Invio()
    {
    }
    public virtual void SetAttributes_Other()
    {
    }

    protected virtual bool CheckBeforeUpdate()
    {
      return true;
    }
    protected virtual bool CheckBeforeUpdate(BBaseObject Obj)
    {
      return true;
    }
    protected virtual bool CheckBeforeDelete(params IDbDataParameter[] ParamsKey)
    {
      return true;
    }
    protected virtual bool DeleteRowsRelation(params IDbDataParameter[] ParamsKey)
    {
      return true;
    }

    protected void DisabledButton(bool Disabled = false)
    {
      if (CtlBtnAnnulla != null)
        CtlBtnAnnulla.Enabled = !Disabled;
      if (CtlBtnSalva != null)
        CtlBtnSalva.Enabled = !Disabled;
      if (CtlBtnElimina != null)
        CtlBtnElimina.Enabled = !Disabled;
      if (CtlBtnStampa != null)
        CtlBtnStampa.Enabled = !Disabled;
    }

    protected object GetValueFromKey(string CampoKey, params IDbDataParameter[] ParamsKey)
    {
      List<IDbDataParameter> l = null;
      IDbDataParameter rEmpty = null;
      try
      {
        l = ParamsKey.ToList();
        // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        rEmpty = new System.Data.SqlClient.SqlParameter();
        rEmpty.ParameterName = "@" + CampoKey;
        rEmpty.Value = "empty";
        l.Add(rEmpty);

        // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        var res = from c in l
                  where (c.ParameterName ?? "") == ("@" + CampoKey ?? "")
                  select c;
        l.Remove(rEmpty); // NECESSARIO PER BUG LINQ TO OBJECT NO ROW
        if (res != null && res.Count() > 0)
        {
          return res.ElementAtOrDefault(0).Value;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("BWebControlTableBase.GetValueFromKey()", "", ex, BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    public void AddCheckBeforeUpdateAlert(string msg, WebControl CtlCheck)
    {
      if (this.BPage is BPageBase)
      {
        if (((BPageBase)this.BPage).CheckBeforeUpdateAlert == null) ((BPageBase)this.BPage).CheckBeforeUpdateAlert = new List<string>();
        ((BPageBase)this.BPage).CheckBeforeUpdateAlert.Add(msg);
        ((BPageBase)this.BPage).CtlFocusOnCheckBeforeUpdateAlert = CtlCheck;

      }
    }


  } //END CLASS
} //END NAMESPACE