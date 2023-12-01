using BArts.BBaseClass;
using BArts.BGlobal;
using BTemplateBaseLibrary;

namespace PosteWebTemplate1
{
  public partial class sysConfiguration : BPageOneRecordBase
  {

    // DEFINIZIONE FUNZIONI OVERRIDES
    protected override bool InitBTablePage()
    {
      this.PageName = "sysConfiguration";
      this.CtlCommandBar.PageName = "Configurazione Applicazione";
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnElimina.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;
      this.CtlPnlDettaglio = this.PnlDettaglio;
      this.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;

      // INIT CONTROL BTABLEBASE
      this.BCtlConfiguration.CtlBtnSalva = this.CtlCommandBar.CtlBtnSalva;
      this.BCtlConfiguration.CtlBtnAnnulla = this.CtlCommandBar.CtlBtnAnnulla;
      this.BCtlConfiguration.Visible = true;
      this.BCtlConfiguration.Enabled = true;
      return default;
    }

    protected override void SetAttributes_Invio()
    {
      this.BCtlConfiguration.SetAttributes_Invio();
    }
    protected override void SetAttributes_Other()
    {
      this.BCtlConfiguration.SetAttributes_Other();
      base.SetAttributes_Other();
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      CtlCommandBar.Annulla += CtlCommandBar_Annulla;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE FUNZIONI OVERRIDES DI GESTIONE
    protected override BBaseObject LoadObject()
    {
      return new BConfiguration(this.DB);
    }
    protected override void NuovoRec()
    {
      this.BCtlConfiguration.NuovoRec();
    }
    protected override bool CambiaRec(BBaseObject Obj)
    {
      return this.BCtlConfiguration.CambiaRec(Obj);
    }
    protected override BBaseObject ScriviRec(BBaseObject Obj)
    {
      return this.BCtlConfiguration.ScriviRec(Obj);
    }

    // DEFINIZIONE EVENTI INTERCETTATI SULLA BARRA DI COMANDO
    private void CtlCommandBar_Salva()
    {
      BConfiguration Obj = null;
      if (this.StatoDetails == eStatusDetails.NUOVO)
      {
        Obj = new BConfiguration(DB);
      }
      else
      {
        Obj = new BConfiguration(BConvert.ToInt(BCtlConfiguration.mbtID.Text), DB);
      }

      if (this.Salva(Obj))
      {
        this.Annulla();
      }
      else
      {
        this.MsgBox("Salvataggio fallito.");
      }
      Obj = null;
    }
    private void CtlCommandBar_Annulla()
    {
      this.Annulla();
    }


  } //END CLASS
} //END NAMESPACE