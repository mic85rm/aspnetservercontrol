using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlSidebar : BWebControlsBase
  {
    // DEFINIZIONE EVENTI
    public event Sistema_ChangedEventHandler Sistema_Changed;
    public delegate void Sistema_ChangedEventHandler(int IDSistema);

    public event Profilo_ChangedEventHandler Profilo_Changed;
    public delegate void Profilo_ChangedEventHandler(int IDSistema, int IDProfilo);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      CtlElencoSistemi.SistemaSelezionato += CtlElencoSistemi_SistemaSelezionato;
      CtlElencoProfili.ProfiloSelezionato += CtlElencoProfili_ProfiloSelezionato;
      CtlElencoVisibilita.VisibilitaSelezionata += CtlElencoVisibilita_VisibilitaSelezionata;

      base.SetAttributes_AddEvents();
    }

    private void CtlElencoVisibilita_VisibilitaSelezionata(int IDVisibilita, bool ChangeClick = true)
    {
      if (BSysUtenteEntrato != null)
      {
        if (ChangeClick) BSysUtenteEntrato.IDVisibilita = IDVisibilita;
        CtlElencoApplicazioni.InitControl(true);
      }
      else
      {
        //write log
        //error
      }

    }

    // DEFINIZIONE PROPRIETA
    public int IDSistemaSelected
    {
      get
      {
        return this.CtlElencoSistemi.IDSistema;
      }
      set
      {
        this.CtlElencoSistemi.IDSistema = value;
        CtlElencoSistemi_SistemaSelezionato(value);
        Sistema_Changed?.Invoke(value);
      }
    }
    public int IDProfiloSelected
    {
      get
      {
        return this.CtlElencoProfili.IDProfilo;
      }
      set
      {
        this.CtlElencoProfili.IDProfilo = value;
        Profilo_Changed?.Invoke(IDSistemaSelected, value);
      }
    }

    // DEFINIZIONE PROPRIETA' READONLY
    public int CountSistemi
    {
      get
      {
        return this.CtlElencoSistemi.Count;
      }
    }
    public int CountProfili
    {
      get
      {
        return this.CtlElencoProfili.Count;
      }
    }

    // DEFINIZIONE METODI
    public bool InitControl()
    {
      if (base.IsPostBack) return true;
      if (this.UtenteEntrato != null && !this.UtenteEntrato.IsNothing)
      {
        if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.PosteRUO)
        {
          CtlElencoProfili.Visible = true;
          CtlElencoSistemi.Visible = true;
          if (this.CtlElencoSistemi.InitControl(((BUtenti)this.UtenteEntrato).ID, true))
          {
            if (!this.CtlElencoProfili.InitControl(this.CtlElencoSistemi.IDSistema, true))
            {
              this.MsgBox("Caricamento profili non riuscito");
              return false;
            }
          }
          else
          {
            return false;
          }
        }
        else
        {
          CtlElencoProfili.Visible = false;
          CtlElencoSistemi.Visible = false;
          if (BSysUtenteEntrato != null && !BSysUtenteEntrato.IsNothing)
          {
            CtlElencoVisibilita.IDVisibilitaSelezionata = BSysUtenteEntrato.IDVisibilita;
          }
          CtlElencoVisibilita.InitControl();

          if (CtlElencoVisibilita.IDVisibilitaSelezionata > 0)
            CtlElencoApplicazioni.InitControl(true);
        }
      }
      else
      {
        return false;
      }
      return true;
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void CtlElencoSistemi_SistemaSelezionato(int IDSistema)
    {
      if (!this.CtlElencoProfili.InitControl(IDSistema, true))
      {
        this.MsgBox("Caricamento profili non riuscito");
      }
      else
      {
        Sistema_Changed?.Invoke(IDSistema);
      }
    }
    private void CtlElencoProfili_ProfiloSelezionato(int IDProfilo)
    {
      Profilo_Changed?.Invoke(IDSistemaSelected, IDProfilo);
    }

  } //END CLASS
} //END NAMESPACE