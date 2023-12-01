using BTemplateBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlElencoProfili : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event ProfiloSelezionatoEventHandler ProfiloSelezionato;
    public delegate void ProfiloSelezionatoEventHandler(int IDProfilo);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      rblSceltaProfilo.SelectedIndexChanged += rblSceltaProfilo_SelectedIndexChanged;

      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE PROPRIETA'
    public int IDProfilo
    {
      get
      {
        if (string.IsNullOrEmpty(this.rblSceltaProfilo.SelectedValue))
          return -1;
        return int.Parse(this.rblSceltaProfilo.SelectedValue);
      }
      set
      {
        this.rblSceltaProfilo.SelectedValue = value.ToString();
      }
    }

    // DEFINIZIONE PROPRIETA' READONLY
    public int Count
    {
      get
      {
        return this.rblSceltaProfilo.Items.Count;
      }
    }

    // DEFINIZIONE METODI

    public bool InitControl(int IDSistema, bool HideWhenOne = false)
    {
      List<BsysUtentiProfili> Lst = null;
      try
      {
        if (base.UtenteEntrato == null)
          return false;
        Lst = this.FilterLstProfili(((BsysUtenti)this.UtenteEntrato).Profili, IDSistema);
        this.rblSceltaProfilo.DataTextField = "DescrizioneProfilo";
        this.rblSceltaProfilo.DataValueField = "IDSysProfilo";
        this.rblSceltaProfilo.DataSource = Lst;
        this.rblSceltaProfilo.DataBind();
        if (IDSistema == ((BsysUtenti)this.UtenteEntrato).IDSysSistema && this.rblSceltaProfilo.Items.FindByValue(((BsysUtenti)this.UtenteEntrato).IDSysProfilo.ToString()) != null)
        {
          IDProfilo = ((BsysUtenti)this.UtenteEntrato).IDSysProfilo;
        }

        if (this.rblSceltaProfilo.Items.Count == 1)
        {
          this.pnlElencoProfili.Visible = !HideWhenOne;
          this.rblSceltaProfilo.SelectedIndex = 0;
        }
        else
        {
          this.pnlElencoProfili.Visible = true;
        }

        return true;
      }
      catch (Exception ex)
      {
        this.pnlElencoProfili.Visible = false;
        this.WriteLog("CtlElencoProfili.LoadSistemi(" + IDSistema + ")", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private List<BsysUtentiProfili> FilterLstProfili(List<BsysUtentiProfili> Lst, int IDSistema)
    {
      try
      {
        var res = from c in Lst
                  where c.IDSysSistema == IDSistema
                  select c;
        if (res != null && res.ToList().Count > 0)
        {
          return res.ToList();
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("CtlElencoProfili.FilterLstProfili(" + IDSistema + ")", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return null;
      }
    }

    // DEFINIZIONE EVENTI INTERCETTATI
    private void rblSceltaProfilo_SelectedIndexChanged(object sender, EventArgs e)
    {
      ProfiloSelezionato?.Invoke(IDProfilo);
    }

  } //END CLASS
} //END NAMESPACE