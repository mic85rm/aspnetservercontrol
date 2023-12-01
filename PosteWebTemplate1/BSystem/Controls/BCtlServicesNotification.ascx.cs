using BArts.BData;
using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace PosteWebTemplate1
{
  public partial class BCtlServicesNotification : BWebControlsBase
  {

    //DEFINIZIONE METODI OVERRIDES
    protected override void BControl_Load(object sender, EventArgs e)
    {
      if (!base.IsPostBack && base.BSysUtenteEntrato != null && !base.BSysUtenteEntrato.IsNothing)
      {
        SyncNotifiche();
        CheckToNotify();
      }
    }
    public override void SetAttributes_AddEvents()
    {
      BNotifica.Click += BNotifica_Click;
      lnkChiudi.Click += lnkChiudi_Click;
      rptNotifiche.ItemCommand += rptNotifiche_ItemCommand;
      lnkIgnoraTutto.Click += lnkIgnoraTutto_Click;
      lnkEliminaAll.Click += lnkEliminaAll_Click;

      base.SetAttributes_AddEvents();
    }


    // DEFINIZIONE FUNZIONI PRIVATE
    private int GetCountNotifiche()
    {
      string sp = "BSP_sysNotifiche_COUNT";
      int? Count = -1;
      try
      {
        if (base.UtenteEntrato == null || base.BSysUtenteEntrato.IsNothing) return 0;
        base.DB.ClearParameter();
        base.DB.AddParameter("@IDSysUtente", this.BSysUtenteEntrato.ID);
        Count = (int?)base.DB.ExecuteScalar(sp, CommandType.StoredProcedure);
        if (Count != null && Count.HasValue)
        {
          return Count.Value;
        }
        else
        {
          return 0;
        }
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.GetCountNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return 0;
      }
    }
    private bool LoadNotifiche()
    {
      BDataTable dt = null;
      string sp = "BSP_sysNotifiche_ByUser";
      try
      {
        base.DB.ClearParameter();
        base.DB.AddParameter("@IdSysUtente", this.BSysUtenteEntrato.ID);
        dt = base.DB.ApriDT(sp, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (dt.Rows.Count > 1)
          {
            this.lblNumNotifiche.Text = dt.Rows.Count + " Notifiche";
          }
          else
          {
            this.lblNumNotifiche.Text = dt.Rows.Count + " Notifica";
          }

          this.rptNotifiche.DataSource = dt;
          this.rptNotifiche.DataBind();
          this.rptNotifiche.Visible = true;
          this.PnlEmpty.Visible = false;
        }
        else
        {
          this.lblNumNotifiche.Text = "0 Notifiche";
          this.rptNotifiche.Visible = false;
          this.PnlEmpty.Visible = true;
        }

        return true;
      }
      catch (Exception ex)
      {
        this.rptNotifiche.Visible = false;
        this.PnlEmpty.Visible = true;
        this.WriteLog("BCtlServicesNotification.LoadNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
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
    private bool Notificato(BsysNotifiche ObjN)
    {
      BsysUtentiNotifiche ObjUN = null;
      ObjUN = new BsysUtentiNotifiche(this.BSysUtenteEntrato.ID, ObjN.ID, base.DB);
      if (ObjUN != null && !ObjUN.IsNothing)
      {
        ObjUN.Notificata = true;
        ObjUN.DataNotificata = DateAndTime.Now;
        if (!ObjUN.Update())
        {
          this.WriteLog("BCtlServicesNotification.Checknotifiy()", "Flag notificato non aggiornato per notifica " + ObjN.ID + ", utente " + UtenteEntrato.ID, BArts.BEnumerations.eSeverity.ERROR);
          return false;
        }
        else
        {
          this.WriteLog("BCtlServicesNotification.Checknotifiy()", "La notifica " + ObjN.ID + " è stata notificata all'utente " + UtenteEntrato.ID, BArts.BEnumerations.eSeverity.INFORMATION);
        }
      }
      else
      {
        this.WriteLog("BCtlServicesNotification.Checknotifiy()", "Flag notificato non aggiornato per notifica " + ObjN.ID + ", utente " + UtenteEntrato.ID, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }

      return true;
    }
    private bool NotificatoAll()
    {
      string sp = "BSP_sysNotifiche_NotifyAll";
      int ret = 0;
      try
      {
        if (base.UtenteEntrato == null || base.BSysUtenteEntrato.IsNothing) return false;
        base.DB.ClearParameter();
        base.DB.AddParameter("@IDSysUtente", this.BSysUtenteEntrato.ID);
        ret = base.DB.ExecuteNonQuery(sp, CommandType.StoredProcedure);
        this.WriteLog("BCtlServicesNotification.NotificatoAll()", "Flag notificato aggiornato per notifica a " + ret + " notifche per utente " + BSysUtenteEntrato.ID, BArts.BEnumerations.eSeverity.INFORMATION);
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.NotificatoAll()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }

    // DEFINIZIONE METODI
    public bool SyncNotifiche()
    {
      string sp = "BSP_sysNotifiche_SYNC";
      BConfiguration BConfig = (BConfiguration)this.Config;
      long min = 0;
      try
      {
        if (BConfig.LastSyncNotifiche.HasValue)
        {
          min = DateAndTime.DateDiff(DateInterval.Minute, BConfig.LastSyncNotifiche.Value, DateAndTime.Now);
        }
        else
        {
          min = long.MaxValue;
        }

        if (min > (long)BConfig.TimerSyncNotify)
        {
          this.DB.ClearParameter();
          this.DB.ExecuteNonQuery(sp, CommandType.StoredProcedure);
          BConfig.LastSyncNotifiche = DateAndTime.Now;
          if (!BConfig.Update())
          {
            this.WriteLog("BCtlServicesNotification.SyncNotifiche()", "Salvataggio LastSyncNotifiche in configurazione non riuscito", BArts.BEnumerations.eSeverity.ERROR);
            return false;
          }
        }

        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.SyncNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public bool CheckToNotify()
    {
      string sp = "BSP_sysNotifiche_ToNotify";
      BDataTable dt = null;
      BsysNotifiche ObjN = null;
      string Msg = "";
      try
      {
        this.DB.ClearParameter();
        this.DB.AddParameter("@IDSysUtente", base.BSysUtenteEntrato.ID);
        dt = this.DB.ApriDT(sp, CommandType.StoredProcedure);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (dt.Rows.Count == 1)
          {
            ObjN = new BsysNotifiche(dt.Rows[0], this.DB);
            if (ObjN != null && !ObjN.IsNothing)
            {
              if (Notificato(ObjN))
                Msg = ObjN.Titolo;
            }
            else
            {
              this.WriteLog("BCtlServicesNotification.Checknotifiy()", "Oggetto notifiche non inizializzato. ", BArts.BEnumerations.eSeverity.ERROR);
            }
          }
          else
          {
            NotificatoAll();
          }

          this.ShowToast("Hai delle notifiche da leggere.", "Notifiche Ricevute (" + dt.Rows.Count + ")");
        }

        RefreshNotifiche();
        return true;
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.CheckNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
        return false;
      }
    }
    public void RefreshNotifiche()
    {
      this.BNotifica.CountNotifiche = GetCountNotifiche();
    }


    //DEFINIZIONE EVENTI INTERCETTATI   
    private void BNotifica_Click(object sender, EventArgs e)
    {
      LoadNotifiche();
      this.PnlNotifications.Visible = !this.PnlNotifications.Visible;
    }
    private void lnkChiudi_Click(object sender, EventArgs e)
    {
      this.PnlNotifications.Visible = false;
    }

    private void rptNotifiche_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      BsysNotifiche Obj = null;
      BsysUtentiNotifiche ObjNU = null;
      int ID = int.Parse(e.CommandArgument.ToString());
      var switchExpr = e.CommandName.ToUpper();
      switch (switchExpr)
      {
        case "BREADNOTIFICA":
          {
            Obj = new BsysNotifiche(ID, base.DB);
            if (Obj != null && !Obj.IsNothing)
            {
              ObjNU = new BsysUtentiNotifiche(this.BSysUtenteEntrato.ID, Obj.ID, base.DB);
              if (ObjNU != null && !ObjNU.IsNothing)
              {
                ObjNU.Letta = true;
                ObjNU.DataLetta = DateAndTime.Now;
                if (ObjNU.Update())
                {
                  LoadNotifiche();
                  RefreshNotifiche();
                }

                this.BPnlNotifica.Show();
                this.lblNotificaTitolo.Text = Obj.Titolo;
                this.LblNotificaData.Text = Strings.Format(Obj.DataNotifica, "ddd dd MMM yyyy HH:mmm");
                this.lblNotificaDescrizione.Text = Obj.Descrizione;
                this.BPnlNotifica.Titolo = "Notifica"; // & Format(Obj.DataNotifica, "ddd dd MMM yyyy HH:mmm")
              }
              else
              {
                this.MsgBox("Non è stato possibile caricare la notifica");
              }
            }

            break;
          }
        case "BDELETENOTIFICA":
          {
            Obj = new BsysNotifiche(ID, base.DB);
            if (Obj != null && !Obj.IsNothing)
            {
              ObjNU = new BsysUtentiNotifiche(this.BSysUtenteEntrato.ID, Obj.ID, base.DB);
              if (ObjNU != null && !ObjNU.IsNothing)
              {
                ObjNU.Cancellata = true;
                ObjNU.DataCancellata = DateAndTime.Now;
                if (ObjNU.Update())
                {
                  LoadNotifiche();
                  RefreshNotifiche();
                }
                else
                {
                  this.MsgBox("Non è stato possibile eliminare la notifica");
                }
              }
              else
              {
                this.MsgBox("Non è stato possibile eliminare la notifica");
              }
            }
            else
            {
              this.MsgBox("Non è stato possibile eliminare la notifica");
            }

            break;
          }
      }
    }
    private void lnkIgnoraTutto_Click(object sender, EventArgs e)
    {
      string sp = "BSP_sysNotifiche_ReadAllUser";
      try
      {
        if (base.UtenteEntrato == null || base.BSysUtenteEntrato.IsNothing)
          return;
        base.DB.ClearParameter();
        base.DB.AddParameter("@IDSysUtente", this.BSysUtenteEntrato.ID);
        base.DB.ExecuteNonQuery(sp, CommandType.StoredProcedure);
        LoadNotifiche();
        RefreshNotifiche();
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.GetCountNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
      }
    }
    private void lnkEliminaAll_Click(object sender, EventArgs e)
    {
      string sp = "BSP_sysNotifiche_DeleteAllUser";
      try
      {
        if (base.UtenteEntrato == null || base.BSysUtenteEntrato.IsNothing)
          return;
        base.DB.ClearParameter();
        base.DB.AddParameter("@IDSysUtente", this.BSysUtenteEntrato.ID);
        base.DB.ExecuteNonQuery(sp, CommandType.StoredProcedure);
        LoadNotifiche();
        RefreshNotifiche();
      }
      catch (Exception ex)
      {
        this.WriteLog("BCtlServicesNotification.GetCountNotifiche()", "", ex, BArts.BEnumerations.eSeverity.ERROR);
      }
    }


  } //END CLASS
} //END NAMESPACE