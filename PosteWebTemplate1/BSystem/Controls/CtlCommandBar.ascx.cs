using BArts.BGlobal;
using BArts.BWeb.BControls;
using System;
using System.Linq;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public partial class CtlCommandBar : BWebControlsBase
  {


    // DEFINIZIONE DATI
    public event NuovoEventHandler Nuovo;
    public delegate void NuovoEventHandler();

    public event EliminaEventHandler Elimina;
    public delegate void EliminaEventHandler();

    public event SalvaEventHandler Salva;
    public delegate void SalvaEventHandler();

    public event AnnullaEventHandler Annulla;
    public delegate void AnnullaEventHandler();

    public event StampaEventHandler Stampa;
    public delegate void StampaEventHandler();


    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      BtnNew.Click += BtnNew_Click;
      BtnElimina.Click += BtnElimina_Click;
      BtnSalva.Click += BtnSalva_Click;
      BtnAnnulla.Click += BtnAnnulla_Click;
      BtnStampa.Click += BtnStampa_Click;
      BtnNew.Invio += BtnNew_Click;
      BtnElimina.Invio += BtnElimina_Click;
      BtnSalva.Invio += BtnSalva_Click;
      BtnAnnulla.Invio += BtnAnnulla_Click;
      BtnStampa.Invio += BtnStampa_Click;
      base.SetAttributes_AddEvents();
    }

    //DEFINIZIONE PROPRIETA'
    public string PageName
    {
      get
      {
        return this.LblNomePagina.Text;
      }
      set
      {
        this.LblNomePagina.Text = value;
      }
    }

    #region public string PathOtherControlAspx
    private string K_VS_PATHOTHERCONTROLASPX = ".PathOtherControlAspx ";
    public string PathOtherControlAspx
    {
      get
      {
        return BConvert.ToString(this.ViewState[base.ID + K_VS_PATHOTHERCONTROLASPX]);
      }
      set
      {
        this.ViewState[base.ID + K_VS_PATHOTHERCONTROLASPX] = value;
      }
    }
    #endregion

    public BButton CtlBtnNuovo
    {
      get
      {
        return this.BtnNew;
      }
      set
      {
        this.BtnNew = value;
      }
    }
    public BButton CtlBtnElimina
    {
      get
      {
        return this.BtnElimina;
      }
      set
      {
        this.BtnElimina = value;
      }
    }
    public BButton CtlBtnSalva
    {
      get
      {
        return this.BtnSalva;
      }
      set
      {
        this.BtnSalva = value;
      }
    }
    public BButton CtlBtnAnnulla
    {
      get
      {
        return this.BtnAnnulla;
      }
      set
      {
        this.BtnAnnulla = value;
      }
    }
    public BButton CtlBtnStampa
    {
      get
      {
        return this.BtnStampa;
      }
      set
      {
        this.BtnStampa = value;
      }
    }
    public UserControl CtlOtherControl
    {
      get
      {
        if (this.PnlOtherElements.Controls.Count > 1)
        {
          return (UserControl)this.PnlOtherElements.Controls[1];
        }
        else
        {
          return null;
        }
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void BtnNew_Click(object sender, EventArgs e)
    {
      Nuovo?.Invoke();
    }
    private void BtnElimina_Click(object sender, EventArgs e)
    {
      Elimina?.Invoke();
    }
    private void BtnSalva_Click(object sender, EventArgs e)
    {
      Salva?.Invoke();
    }
    private void BtnAnnulla_Click(object sender, EventArgs e)
    {
      Annulla?.Invoke();
    }
    private void BtnStampa_Click(object sender, EventArgs e)
    {
      Stampa?.Invoke();
    }

    //DEFINIZIONE METODI OVERRIDE
    protected override void BControl_Init(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(PathOtherControlAspx))
      {
        if (System.IO.File.Exists(base.Server.MapPath(PathOtherControlAspx)))
        {
          this.PnlOtherElements.Controls.Add(base.LoadControl(PathOtherControlAspx));
        }
      }
    }


  } //END CLASS
} //END NAMESPACE