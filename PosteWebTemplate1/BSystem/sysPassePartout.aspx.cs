using System;

namespace PosteWebTemplate1
{
  public partial class sysPassePartout : BPageBase
  {
    // DEFINIZIONE FUNZIONI OVERRIDES
    public override void Indietro_Click()
    {
      base.BRedirect("HomeConsoleDeveloper.aspx");
      base.Indietro_Click();
    }

    protected override void BPage_Load(object sender, EventArgs e)
    {
      this.CtlCommandBar.PageName = "Passepartout";
      this.CtlCommandBar.CtlBtnNuovo.Visible = false;
      this.CtlCommandBar.CtlBtnAnnulla.Visible = false;
      this.CtlCommandBar.CtlBtnStampa.Visible = false;
      this.CtlCommandBar.CtlBtnSalva.Visible = true;
      this.CtlCommandBar.CtlBtnElimina.Visible = true;
    }
    protected override void SetAttributes_AddEvents()
    {
      CtlCommandBar.Elimina += CtlCommandBar_Elimina;
      CtlCommandBar.Salva += CtlCommandBar_Salva;
      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void CtlCommandBar_Salva()
    {
      if (string.IsNullOrEmpty(this.mbtPassword.Text))
      {
        this.MsgBox("Inserimento obbligatiorio!!");
        this.mbtPassword.Focus();
      }

      if (BUtenti.SetPassepartout(this.mbtPassword.Text, this.DB))
      {
        this.MsgBox("Passepartout inserito correttamente!");
      }
      else
      {
        this.MsgBox("Creazione Passepartout fallita.");
      }
    }
    private void CtlCommandBar_Elimina()
    {
      if (BUtenti.DeletePassepartout(this.DB))
      {
        this.MsgBox("Passepartout rimosso correttamente!");
      }
      else
      {
        this.MsgBox("Rimozione Passepartout fallita.");
      }
    }

  } //END CLASS
} //END NAMESPACE