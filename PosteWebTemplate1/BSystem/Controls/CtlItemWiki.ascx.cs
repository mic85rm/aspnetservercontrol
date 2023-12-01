using BArts;
using BArts.BGlobal;
using BArts.BSecurity;
using BTemplateBaseLibrary;
using System;
using System.Data.Common;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PosteWebTemplate1
{
  public partial class CtlItemWiki : BWebControlsBase
  {

    // DEFINIZIONE EVENTI
    public event Link_ClickEventHandler Link_Click;
    public delegate void Link_ClickEventHandler(int IDLink);

    //DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      rptLinks.ItemCommand += rptLinks_ItemCommand;
      rptAllegati.ItemDataBound += rptAllegati_ItemDataBound;
      base.SetAttributes_AddEvents();
    }

    // DEFINIZIONE PROPRIETA'
    #region public BsysWiki Wiki
    private const string K_SE_WIKI = ".Wiki";
    public BsysWiki Wiki
    {
      get
      {
        return (BsysWiki)Session[base.ID + K_SE_WIKI];
      }
      set
      {
        Session[base.ID + K_SE_WIKI] = value;
      }
    }
    #endregion

    // DEFINIZIONE METODI
    public bool InitControl(int IDWiki, bool AllText)
    {
      var obj = new BsysWiki(IDWiki, DB);
      if (obj == null || obj.IsNothing) return false;
      return InitControl(obj, AllText);
    }
    public bool InitControl(BsysWiki Obj, bool AllText)
    {
      if (Obj == null || Obj.IsNothing) return false;
      Wiki = Obj;
      // LOAD ITEM
      if (AllText) RemoveMaxHeight();
      pnlLink.Visible = AllText;
      pnlAllegati.Visible = AllText;

      this.SetAttributes_AddEvents();

      return LoadItm();
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private bool LoadItm()
    {
      lblTitolo.Text = Wiki.Titolo;
      LblSottotitolo.Text = Wiki.Sottotitolo;
      ltlBody.Text = Wiki.Descrizione;
      if (Wiki.Allegati != null && Wiki.Allegati.Count > 0)
      {
        rptAllegati.DataSource = Wiki.Allegati;
        rptAllegati.DataBind();
        pnlAllegati.Visible = true;
      }
      else
      {
        pnlAllegati.Visible = false;
      }

      if (Wiki.Links != null && Wiki.Links.Count > 0)
      {
        rptLinks.DataSource = Wiki.Links;
        rptLinks.DataBind();
        pnlLink.Visible = true;
      }
      else
      {
        pnlLink.Visible = false;
      }

      return true;
    }
    private void RemoveMaxHeight()
    {
      string s = contentLiteral.Attributes["Style"];
      contentLiteral.Attributes["style"] = s.Replace("max-height: 100px;", "");
    }
    private void rptLinks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      switch (e.CommandName.ToUpper())
      {
        case "LNK_CLICK":
          {
            Link_Click?.Invoke(BConvert.ToInt(e.CommandArgument));
            break;
          }
      }
    }

    private void rptAllegati_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      HyperLink LnkPathAllegato = null;
      string Path = "";
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        LnkPathAllegato = (HyperLink)e.Item.FindControl("LnkPathAllegato");
        if (LnkPathAllegato == null) return;

        BsysWikiAllegati Obj = (BsysWikiAllegati)e.Item.DataItem;
        if (Obj == null) return;
        Path = BWebConfig.ServerFileShare_Folder;
        if (BWebConfig.ServerFileShare_PathRelative) Path = BGlobal.CreatePathFile("~/", Path);
        Path = BGlobal.CreatePathFile(Path, "wiki/wiki_" + Obj.IDSysWiki);
        Path = BGlobal.CreatePathFile(Path, Obj.PathAllegato);

        LnkPathAllegato.Target = "_blank";
        LnkPathAllegato.NavigateUrl = Path;
      }
    }


  } //END CLASS
} //END NAMESPACE