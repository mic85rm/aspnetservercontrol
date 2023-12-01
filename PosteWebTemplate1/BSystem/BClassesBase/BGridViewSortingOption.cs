using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Automation.Peers;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace PosteWebTemplate1.BSystem.BClassesBase
{
  public class BGridViewSortingOption
  {
    //DEFINIZIONE COSTRUTTORI
    public BGridViewSortingOption() { }
    public BGridViewSortingOption(string field, SortDirection direction)
    {
      Campo = field;
      Direzione = direction;
    }

    //DEFINIZIONE PROPRIETA'
    public string Campo { get; set; } = "";
    public SortDirection Direzione { get; set; } = SortDirection.Ascending;

    //DEFINIZIONE METODI
    public SortDirection GetNewSortingDirection()
    {
      if (Direzione == SortDirection.Ascending)
        return SortDirection.Descending;
      else
        return SortDirection.Ascending;

    }
    public string Sort(string field)
    {
      if (Campo == field)
      {
        Direzione = GetNewSortingDirection();
        return this.ToString();
      }
      else
      {
        Campo = field;
        Direzione = SortDirection.Ascending;
        return this.ToString();
      }
    }
    public void Draw(GridViewRow row)
    {

      if (row.RowType == DataControlRowType.Header)
      {
        foreach (TableCell cell in row.Cells)
        {
          if (cell.HasControls() && cell.Controls[0] is LinkButton)
          {

            LinkButton f = (LinkButton)cell.Controls[0];
            if (f.CommandName.ToLower() == "sort")
            {
              if (f.CommandArgument == Campo)
              {
                LinkButton lnkIcon = new LinkButton();
                lnkIcon.CommandArgument = f.CommandArgument;
                lnkIcon.CommandName = f.CommandName;
                lnkIcon.Text = "";
                lnkIcon.Style.Add("margin-left", "5px !important;");
                if (Direzione == SortDirection.Descending)
                  lnkIcon.CssClass = "BBtn BBtnTrasparente BIconSortDESC";
                else
                  lnkIcon.CssClass = "BBtn BBtnTrasparente BIconSortASC";

                cell.Controls.Add(lnkIcon);

                lnkIcon = new LinkButton();
                lnkIcon.Text = "";
                lnkIcon.Style.Add("margin-left", "5px !important;");
                if (Direzione == SortDirection.Descending)
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";
                else
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";
                cell.Controls.AddAt(0, lnkIcon);

              }
              else
              {
                LinkButton lnkIcon = new LinkButton();
                lnkIcon.Text = "";
                lnkIcon.Style.Add("margin-left", "5px !important;");
                if (Direzione == SortDirection.Descending)
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";
                else
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";

                cell.Controls.Add(lnkIcon);
                lnkIcon = new LinkButton();
                lnkIcon.Text = "";
                lnkIcon.Style.Add("margin-left", "5px !important;");
                if (Direzione == SortDirection.Descending)
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";
                else
                  lnkIcon.CssClass = "BBtn BBtnTrasparente ";
                cell.Controls.AddAt(0, lnkIcon);

              }
            }
          }
        }

      }
    }


    //DEFINIZIONE METODI OVERRIDE 
    public override string ToString()
    {
      if (Direzione == SortDirection.Ascending)
        return $"{Campo}";
      else
        return $"{Campo} DESC";

    }
  }
}