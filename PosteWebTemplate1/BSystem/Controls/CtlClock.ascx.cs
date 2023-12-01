using BTemplateBaseLibrary;
using Microsoft.VisualBasic;
using System;
using System.Web.UI;

namespace PosteWebTemplate1
{
  public partial class CtlClock : BWebControlsBase
  {

    // DEFINIZIONE PROPRIETA' 
    #region public bool ShowTime
    private string K_ShowTime = ".SHOWTIME";
    public bool ShowTime
    {
      get
      {
        return (bool)(base.ViewState[base.ID + K_ShowTime]);
      }
      set
      {
        base.ViewState[base.ID + K_ShowTime] = value;
      }
    }
    #endregion 

    // DEFINIZIONE EVENTI INTERCETTATI
    protected void Page_Load(object sender, EventArgs e)
    {
      TmrClock_Tick();
      this.lblOra.Visible = ShowTime;
      if (ShowTime)
      {
        this.Page.ClientScript.RegisterStartupScript(typeof(Page), base.ID + "_LOAD", "BClockStart('" +
          this.lblOra.ClientID + "', '" + this.lblGiorno.ClientID + "', '" +
          this.LblNumGiorno.ClientID + "', '" + this.lblMese.ClientID + "');", true);
      }
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private void TmrClock_Tick()
    {
      this.lblOra.Text = Strings.Format(DateAndTime.Now, "HH:mm").Replace(".", ":");
      this.lblGiorno.Text = BArts.BGlobal.BGlobal.GiornoSettimana(DateAndTime.Now);
      this.LblNumGiorno.Text = DateAndTime.Now.Day.ToString();
      this.lblMese.Text = DateAndTime.MonthName(DateAndTime.Now.Month);
    }

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      this.Load += Page_Load;
      base.SetAttributes_AddEvents();
    }


  } //END CLASS
} //END NAMESPACE