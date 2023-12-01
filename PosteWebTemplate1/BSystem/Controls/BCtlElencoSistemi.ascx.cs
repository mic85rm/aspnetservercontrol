using BArts.BData;
using BTemplateBaseLibrary;
using System;
using System.Data;
using System.Linq;

namespace PosteWebTemplate1
{
  public partial class BCtlElencoSistemi : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event SistemaSelezionatoEventHandler SistemaSelezionato;
    public delegate void SistemaSelezionatoEventHandler(int IDSistema);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      rblSceltaSistema.SelectedIndexChanged += rblSceltaSistema_SelectedIndexChanged;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE PROPRIETA'
    public int IDSistema
    {
      get
      {
        if (string.IsNullOrEmpty(this.rblSceltaSistema.SelectedValue))
          return -1;
        return int.Parse(this.rblSceltaSistema.SelectedValue);
      }
      set
      {
        this.rblSceltaSistema.SelectedValue = value.ToString();
      }
    }

    // DEFINIZIONE PROPRIETA' READONLY
    public int Count
    {
      get
      {
        return this.rblSceltaSistema.Items.Count;
      }
    }

    // DEFINIZIONE METODI
    public bool InitControl(string IDUtente, bool HideWhenOne = false)
    {
      BDataTable dt = null;
      try
      {
        base.DB.AddParameter("@idsysutente", IDUtente);
        dt = base.DB.ApriDT("BSP_sysUtentiSistemi_SELECT", CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          this.rblSceltaSistema.DataTextField = "Descrizione";
          this.rblSceltaSistema.DataValueField = "idsyssistema";
          this.rblSceltaSistema.DataSource = dt;
          this.rblSceltaSistema.DataBind();
          if (this.rblSceltaSistema.Items.FindByValue(((BsysUtenti)this.UtenteEntrato).IDSysSistema.ToString()) != null)
          {
            this.rblSceltaSistema.SelectedValue = ((BsysUtenti)this.UtenteEntrato).IDSysSistema.ToString();
          }
        }

        if (this.rblSceltaSistema.Items.Count == 1)
        {
          this.pnlElencoSistemi.Visible = !HideWhenOne;
        }
        else
        {
          this.pnlElencoSistemi.Visible = true;
        }

        return true;
      }
      catch (Exception ex)
      {
        this.pnlElencoSistemi.Visible = false;
        this.WriteLog("CtlElencoSistemi.LoadSistemi(" + IDUtente + ")", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void rblSceltaSistema_SelectedIndexChanged(object sender, EventArgs e)
    {
      SistemaSelezionato?.Invoke(int.Parse(this.rblSceltaSistema.SelectedValue));
    }

  } //END CLASS
} //END NAMESPACE