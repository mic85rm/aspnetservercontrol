using MTHtmlEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace MTHtmlEditor
{



  [ValidationPropertyAttribute("Testo"),
  DefaultProperty("Testo"),
  ParseChildren(true),
  PersistChildren(true),
    ToolboxData("<{0}:MTHtmlEditor runat=\"server\"></{0}:MTHtmlEditor>")]
  public class MTHtmlEditor : WebControl, IPostBackDataHandler, INamingContainer, IPostBackEventHandler, IDisposable
  {

    private string viewStateText;
    public event EventHandler TextChanged;
    public event EventHandler ProcessaTesto;
    HtmlInputHidden hiddenField;
    HtmlInputHidden hiddenFieldTabSelezionato;
    HtmlGenericControl divEditorContenitore;
    HtmlGenericControl MTEditorContentEditableDesign;
    HtmlGenericControl MTToolbar;
    HtmlGenericControl MTTabs;
    HtmlButton bottoniToolbar;
    HtmlGenericControl MTEditorContentEditableHTML;
    HtmlButton buttonTabDesign;
    HtmlButton buttonTabHTML;

    //comandi presi da questo link
    //https://www.w3schools.com/jsref/met_document_execcommand.asp
    public enum EComandi
    {
      backColor,
      bold,
      createLink,
      copy,
      cut,
      defaultParagraphSeparator,
      delete,
      fontName,
      fontSize,
      foreColor,
      formatBlock,
      forwardDelete,
      insertHorizontalRule,
      insertHTML,
      insertImage,
      insertLineBreak,
      insertOrderedList,
      insertParagraph,
      insertText,
      insertUnorderedList,
      justifyCenter,
      justifyFull,
      justifyLeft,
      justifyRight,
      outdent,
      paste,
      redo,
      selectAll,
      strikethrough,
      styleWithCss,
      subscript,
      superscript,
      undo,
      unlink,
      useCSS
    }



    //public MTHtmlEditor()
    //{
    //  this.ProcessaTesto += new EventHandler(ProcessaTestoMetodo);
    //}


    //private void ProcessaTestoMetodo(object source, EventArgs args)
    //{
    //  MTHtmlEditor editor = (MTHtmlEditor)source;
    //  this.Text=editor.Text;

    //}


    public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
    {
      string PresentValue = this.Text;
      string PostedValue = postCollection[this.hiddenField.ClientID.Replace("_","$")];


      if (!PresentValue.Equals(PostedValue))
      {

        this.Text = PostedValue;
        viewStateText = PostedValue;

        return true;

      }

      return false;
    }

    public void RaisePostBackEvent(string eventArgument)
    {
      System.Web.HttpContext.Current.Trace.Write("PostBackEvent", eventArgument);

      switch (eventArgument)
      {
        case "Save":
          // this.OnSaveClick(EventArgs.Empty);
          break;
        default:
          break;
      }
    }

    public void RaisePostDataChangedEvent()
    {
      OnTextChanged(EventArgs.Empty);

      OnProcessText(EventArgs.Empty);
    }


    protected virtual void OnTextChanged(EventArgs e)
    {
      if (TextChanged != null)
      {
        TextChanged(this, e);
      }
    }

    protected virtual void OnProcessText(EventArgs e)
    {
      if (ProcessaTesto != null)
      {
        ProcessaTesto(this, e);
      }
    }


    protected override void CreateChildControls()
    {
      base.CreateChildControls();
   

     

      string idDaCambiare = "_MT";


      hiddenField = new HtmlInputHidden();
      hiddenField.ID = "MTHiddenText";
      hiddenField.Value = "";

      hiddenFieldTabSelezionato = new HtmlInputHidden();
      hiddenFieldTabSelezionato.ID = "MTHiddenTabSelezionato";
      hiddenFieldTabSelezionato.Value = "design";


      divEditorContenitore = new HtmlGenericControl();
      divEditorContenitore.TagName = "div";
      divEditorContenitore.ID = idDaCambiare.Remove(0, 1) + "EditorContenitore";
      divEditorContenitore.Style.Add("background-color", "background-color");
      divEditorContenitore.Style.Add("border", "1px solid #cccccc");
      divEditorContenitore.Style.Add("height", Height.ToString());
      divEditorContenitore.Style.Add("width", Width.ToString());


      MTEditorContentEditableDesign = new HtmlGenericControl();
      MTEditorContentEditableDesign.TagName = "div";
      MTEditorContentEditableDesign.ID = idDaCambiare.Remove(0, 1) + "EditorContentEditableDesign";
      MTEditorContentEditableDesign.Style.Add("display", "block");
      MTEditorContentEditableDesign.Style.Add("height", "calc(100% - 100px)");
      MTEditorContentEditableDesign.Style.Add("width", "calc(100% - 2px)");
      MTEditorContentEditableDesign.Style.Add("border", "1px solid #cccccc");
      MTEditorContentEditableDesign.Attributes.Add("contenteditable", "true");
      MTEditorContentEditableDesign.Attributes.Add("oninput", $"MTMoveTextFromDivToHiddenField('{this.ClientID}_')");


      MTEditorContentEditableHTML = new HtmlGenericControl();
      MTEditorContentEditableHTML.TagName = "div";
      MTEditorContentEditableHTML.ID = idDaCambiare.Remove(0, 1) + "EditorContentEditableHTML";
      MTEditorContentEditableHTML.Style.Add("display", "none");
      MTEditorContentEditableHTML.Style.Add("height", "calc(100%)");
      MTEditorContentEditableHTML.Style.Add("width", "calc(100% - 2px)");
      MTEditorContentEditableHTML.Attributes.Add("contenteditable", "true");
      MTEditorContentEditableHTML.Attributes.Add("oninput", $"MTMoveTextFromDivToHiddenField('{this.ClientID}_')");




      MTToolbar = new HtmlGenericControl();
      MTToolbar.TagName = "div";
      MTToolbar.ID = idDaCambiare.Remove(0, 1) + "Toolbar";




      foreach (EComandi comandi in (EComandi[])Enum.GetValues(typeof(EComandi)))
      {
        bottoniToolbar = new HtmlButton();
        bottoniToolbar.ID = $"MT{comandi}";
        bottoniToolbar.Style.Add("height", "32px");
        bottoniToolbar.Style.Add("width", "32px");
        bottoniToolbar.Style.Add("background",$"url({this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTHtmlEditor.immagini.bold.png")})");
        bottoniToolbar.Style.Add("background-repeat", "no-repeat");
        bottoniToolbar.Style.Add("background-position", "center");
        bottoniToolbar.Attributes.Add("class", "class1");
        bottoniToolbar.Attributes.Add("type", "button");
        bottoniToolbar.Attributes.Add("onclick", $"MTcallFormatting(\"{comandi.ToString()}\");MTToggleButton({this.ClientID}_MT{comandi});");
        MTToolbar.Controls.Add(bottoniToolbar);
      }


      MTTabs = new HtmlGenericControl();
      MTTabs.TagName = "div";
      MTTabs.ID = idDaCambiare.Remove(0, 1) + "MTTABS";
      MTTabs.Attributes.Add("class", "MTTABS");



      buttonTabDesign = new HtmlButton();
      buttonTabDesign.ID = "MTTABDESIGN";
      buttonTabDesign.Attributes.Add("class", "MTTABLINKS class1");
      buttonTabDesign.Attributes.Add("type", "button");
      buttonTabDesign.InnerText = "Design";
      buttonTabDesign.Attributes.Add("onclick", $"MTCambiaPannello('design','{this.ClientID}_');MTToggleTabs({this.ClientID}_MTTABDESIGN,{this.ClientID}_MTTABHTML,'{this.ClientID}_');");


      buttonTabHTML = new HtmlButton();
      buttonTabHTML.ID = "MTTABHTML";
      buttonTabHTML.Attributes.Add("class", "MTTABLINKS class2");
      buttonTabHTML.Attributes.Add("type", "button");
      buttonTabHTML.InnerText = "HTML";
      buttonTabHTML.Attributes.Add("onclick", $"MTCambiaPannello('html','{this.ClientID}_');MTToggleTabs({this.ClientID}_MTTABHTML,{this.ClientID}_MTTABDESIGN,'{this.ClientID}_');");

      MTTabs.Controls.Add(buttonTabDesign);
      MTTabs.Controls.Add(buttonTabHTML);



      Controls.Add(hiddenField);
      Controls.Add(hiddenFieldTabSelezionato);
      divEditorContenitore.Controls.Add(MTToolbar);
      divEditorContenitore.Controls.Add(MTEditorContentEditableDesign);
      divEditorContenitore.Controls.Add(MTEditorContentEditableHTML);
      divEditorContenitore.Controls.Add(MTTabs);
      Controls.Add(divEditorContenitore);
      //Controls.Add(MTTabs);





    }


    [
    CategoryAttribute("Output"),
    Description("Contiene HTML per l'editor.")
    ]
    //public string Text
    //{
    //  set
    //  {
    //    ViewState["Text"] = value;
    //  }
    //  get
    //  {
    //    object savedState = this.ViewState["Text"];
    //    return (savedState == null) ? "" : (string)savedState;
    //  }
    //}
    public string Text
    {

      get
      {
        EnsureChildControls();

        if (this.Page.IsPostBack)
        {


          string HiddenFieldPostedValue =   Context.Request.Form[hiddenField.UniqueID];
          string HiddenFieldTabSelezionato = Context.Request.Form[hiddenFieldTabSelezionato.UniqueID];

          if (!string.IsNullOrEmpty(HiddenFieldTabSelezionato))
          {
            if (HiddenFieldTabSelezionato == "design")
            {
              MTEditorContentEditableDesign.InnerHtml = HttpUtility.HtmlDecode(HiddenFieldPostedValue);
              MTEditorContentEditableHTML.Style.Add("display", "none");
              MTEditorContentEditableDesign.Style.Add("display", "block");
              MTToolbar.Style.Add("display", "block");
              buttonTabDesign.Attributes.Add("class", "MTTABLINKS class1");  
              buttonTabHTML.Attributes.Add("class", "MTTABLINKS class2");  
            }
            else
            {
              MTEditorContentEditableHTML.InnerText = HttpUtility.HtmlDecode(HiddenFieldPostedValue);
              MTEditorContentEditableHTML.Style.Add("display","block");
              MTEditorContentEditableDesign.Style.Add("display", "none");
              MTToolbar.Style.Add("display", "none");
              buttonTabDesign.Attributes.Add("class", "MTTABLINKS class2");
              buttonTabHTML.Attributes.Add("class", "MTTABLINKS class1");
            }
          }


          return HiddenFieldPostedValue;
        }
        else
        {
          return divEditorContenitore.InnerText;
        }
      }
      set
      {
        EnsureChildControls();

        if (this.Page.IsPostBack)
        {

          string HiddenFieldPostedValue = Context.Request.Form[hiddenField.UniqueID];
          string HiddenFieldTabSelezionato = Context.Request.Form[hiddenFieldTabSelezionato.UniqueID];
          if (!string.IsNullOrEmpty(HiddenFieldTabSelezionato))
          {
            if (HiddenFieldTabSelezionato == "design")
            {
              MTEditorContentEditableDesign.InnerHtml = HttpUtility.HtmlDecode( value);
            }
            else
            {
              MTEditorContentEditableHTML.InnerText = value;
            }
          }
        }
        else
        {
          
          string HiddenFieldTabSelezionato = Context.Request.Form[hiddenFieldTabSelezionato.UniqueID];
          hiddenField.Value=value;
          if (!string.IsNullOrEmpty(HiddenFieldTabSelezionato)||HiddenFieldTabSelezionato==null)
          {
            if (HiddenFieldTabSelezionato == "design" || HiddenFieldTabSelezionato==null)
            {
              MTEditorContentEditableDesign.InnerText = value;
            }
            else
            {
              MTEditorContentEditableHTML.InnerText = value;
            }
          }
        }
      }
    }

    //public override string ClientID
    //{
    //  get
    //  {
    //    string id = base.ClientID;
    //    // remove beginning _ for CSS
    //    while (id.Substring(0, 1) == "_")
    //    {
    //      id = id.Substring(1);
    //    }
    //    // remove an nested file-specific characters
    //    return id.Replace("\\", "_").Replace("/", "_").Replace(".", "_");
    //  }
    //}


    //[
    //CategoryAttribute("Behavior"),
    //]
    //public string ClientSideTextChanged
    //{
    //  set { ViewState["ClientSideTextChanged"] = value; }
    //  get
    //  {
    //    object savedState = this.ViewState["ClientSideTextChanged"];
    //    return (savedState == null) ? string.Empty : (string)savedState;
    //  }
    //}

    public Unit Width
    {
      get
      {
        object savedState = this.ViewState["Width"];
        return (savedState == null) ? new Unit("600px") : (Unit)savedState;
      }
      set
      {
        ViewState["Width"] = value;
      }
    }
    /// <summary>
    /// Gets or sets the height of the editor including toolbars.
    /// </summary>
    [
    CategoryAttribute("Appearance"),
    Description("Gets or sets the height of the editor.")
    ]
    public Unit Height
    {
      get
      {
        object savedState = this.ViewState["Height"];
        return (savedState == null) ? new Unit("350px") : (Unit)savedState;

      }
      set
      {
        ViewState["Height"] = value;
      }
    }








    protected override void OnPreRender(EventArgs e)
    {


      Page.RegisterRequiresPostBack(this);
      RegisterClientScript();
      string HiddenFieldTabSelezionato = Context.Request.Form[hiddenFieldTabSelezionato.UniqueID];
      if (HiddenFieldTabSelezionato == "design")
      {
        
      }
      else
      {
       
      }
      base.OnPreRender(e);
    }


    protected virtual void RegisterClientScript()
    {



    }


  }
}
