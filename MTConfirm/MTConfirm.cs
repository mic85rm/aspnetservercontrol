using System.ComponentModel;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace MTConfirm
{
  /// <summary>
  ///     Un <see cref="T:System.Web.UI.WebControls.LinkButton"/> con jquery per avere un confirm bello graficamente
  /// </summary>
  /// <remarks>in questa versione jQueryUI è obbligatorio sto creando versione javascript pura</remarks>
  [DefaultProperty("Text")]
  [ToolboxData("<{0}:MTConfirm runat=\"server\"></{0}:MTConfirm>")]
  public class MTConfirm : LinkButton
  {
    
    protected string eventReference = null;

    
    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("dialog")]
    [Localizable(true)]
    public string DialogCssID
    {
      get
      {
        String s = (String)ViewState["DialogCssID"];
        return ((s == null) ? String.Empty : s);
      }
      set
      {
        ViewState["DialogCssID"] = value;
      }
    }

    internal protected string DialogID
    {
      get
      {
        return String.Format("{0}_{1}", this.ClientID, DialogCssID);
      }
    }

    
    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("<p>Sei sicuro?</p>")]
    [Localizable(true)]
    public string DialogContent
    {
      get
      {
        String s = (String)ViewState["DialogContent"];
        return ((s == null) ? String.Empty : s);
      }
      set
      {
        ViewState["DialogContent"] = value;
      }
    }

    
    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("Titolo finestra")]
    [Localizable(true)]
    public string DialogTitle
    {
      get
      {
        String s = (String)ViewState["DialogTitle"];
        return ((s == null) ? String.Empty : s);
      }
      set
      {
        ViewState["DialogTitle"] = value;
      }
    }

  
    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("SI")]
    [Localizable(true)]
    public string DialogConfirmButtonText
    {
      get
      {
        String s = (String)ViewState["DialogConfirmButtonText"];
        return ((s == null) ? String.Empty : s);
      }
      set
      {
        ViewState["DialogConfirmButtonText"] = value;
      }
    }

 
    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("NO")]
    [Localizable(true)]
    public string DialogRejectButtonText
    {
      get
      {
        String s = (String)ViewState["DialogAnnullaButtonText"];
        return ((s == null) ? String.Empty : s);
      }
      set
      {
        ViewState["DialogAnnullaButtonText"] = value;
      }
    }

   
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.eventReference = Page.ClientScript.GetPostBackEventReference(this, string.Empty);
      Page.ClientScript.RegisterStartupScript(this.GetType(), string.Format("{0}{1}", this.ClientID, "-DialogScript"), this.GetClientScript(), true);
      Page.ClientScript.RegisterClientScriptBlock(this.GetType(), string.Format("{0}{1}", this.ClientID, "-DialogShowScript"), string.Format("function {0}Confirm() {{$('#{0}').dialog('open');}}", this.DialogID), true);
      this.OnClientClick = String.Format("{0}Confirm();return false;", this.DialogID);
    }

   
    protected override void RenderContents(HtmlTextWriter writer)
    {
      base.RenderContents(writer);
      writer.AddAttribute("id", this.DialogID);
      writer.RenderBeginTag("div");
      writer.Write(this.DialogContent);
      writer.RenderEndTag();
    }

    public override void RenderEndTag(HtmlTextWriter writer)
    {
      base.RenderEndTag(writer);
    }

   
    private string GetClientScript()
    {
      return string.Format(@"$(function () {{

                            $('#{0}').dialog({{
                                autoOpen: false,
                                modal: true,
                                resizable: false,
                                buttons: {{
                                    '{1}': function () {{
                                        $(this).dialog('close');
                                        eval({2});
                                    }},
                                    '{3}': function () {{
                                        $(this).dialog('close');
                                    }}
                                }},
                                title: '{4}'
                            }});
                          }});", this.DialogID, this.DialogConfirmButtonText, this.eventReference, this.DialogRejectButtonText, this.DialogTitle);
    }
  }
}