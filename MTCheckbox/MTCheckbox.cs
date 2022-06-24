using MTCheckbox.WebControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MTCheckbox
{
  [DefaultEvent("Submit")]
  [ToolboxData("<{0}:MTCheckbox runat=server></{0}:MTCheckbox>")]
    public class MTCheckbox:WebControl,INamingContainer,IPostBackEventHandler
    {

    //public delegate void CheckboxClickHandler(object sender, EventArgs e);
    private MTCheckboxItemCollection dropdownItems;
    //private MTCheckboxItem item;
    private Panel  PannelloContenitore;
    private CheckBox MTChk;
    //private HtmlGenericControl MTChk;
    private Panel FrecciaINBasso;
    private HtmlGenericControl iHtml;
    private HtmlGenericControl liHtml;
    private Panel PannelloItem;
    private Panel MTCheckboxControllo;
    private Panel MTCheckboxWidth;

    //private HtmlInputCheckBox checkBoxMT;


   


    [Bindable(true)]
    [Category("Appearance")]
    [DefaultValue("false")]
    [Localizable(true)]
    private Boolean checkedInterno; // field

    public Boolean CheckedInterno   // property
    {
      get { return checkedInterno; }   // get method
      set { checkedInterno = value; }  // set method
    }








    //private void MTCheckbox_Click(object sender, System.EventArgs e)
    //{

    //    OnClicked();


    //}




    //protected override void AddAttributesToRender(HtmlTextWriter writer)
    //{
    //  base.AddAttributesToRender(writer);
    //  writer.AddAttribute("uniqueId", this.UniqueID);
    //  writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);

    //}


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public MTCheckboxItemCollection DropdownItems
    {
      get
      {
        if (dropdownItems == null)
        {
          dropdownItems = new MTCheckboxItemCollection();
        }
        return dropdownItems;
      }
    }


    protected override void AddParsedSubObject(object obj)
    {
      if (obj is MTCheckboxItem)
      {
        this.DropdownItems.Add((MTCheckboxItem)obj);
        return;
      }
    }


    protected override void CreateChildControls()
    {
      try
      {
        //InizializzaPannelloContenitore();
        InizializzaControllo();
        //this.PannelloContenitore.Controls.Clear();
        //this.PannelloContenitore.Controls.Add(this.MTCheckboxControllo);

        this.Controls.Clear();
        //this.Controls.Add(PannelloContenitore);
        this.Controls.Add(MTCheckboxControllo);

       
      }
      catch (Exception)
      {


      }


    }

 




    //private Boolean InizializzaPannelloContenitore()
    //{

    //  try
    //  {
    //    this.PannelloContenitore = new Panel();
    //    this.ID = "MTPannelloContenitore";
    //    this.Visible = true;
    //    return true;

    //  }
    //  catch (Exception)
    //  {
    //    return false;
    //    throw;
    //  }

    //}



    //public override string ClientID
    //{
    //  get { return "cfgSelectDropdown"; }
    //}

    //public override string UniqueID
    //{
    //  get
    //  {
    //    return "cfgSelectDropdown";
    //  }
    //}

    private Boolean InizializzaControllo()
    {

      
      try
      {
        this.MTChk = new CheckBox();
        this.MTChk.ID = "MTcheckbox";
        //this.MTChk.CheckedChanged += MTChk_CheckedChanged;
        //  this.MTChk.Checked = CheckedInterno;
        //I am creating a delegate (pointer) to HandleSomethingHappened
        //and adding it to SomethingHappened's list of "Event Handlers".
        

        //To raise the event within a method.
        
        //this.MTChk.Attributes.Add("class", "MTCheckbox");
        //this.MTChk = new HtmlGenericControl("input");
        //this.MTChk.ID = "MTcheckbox";
        //this.MTChk.Attributes.Add("class", "MTCheckbox");
        //this.MTChk.Attributes.Add("value", "Seleziona");
        //this.MTChk.Attributes.Add("type", "checkbox");
        //this.MTChk.Attributes.Add("name", "MTcheckbox");


        this.FrecciaINBasso = new Panel();
        //this.Visible = true;
        this.FrecciaINBasso.Attributes.Add("onmouseover", "myFunction();");
        if (dropdownItems != null)
        {
          this.FrecciaINBasso.CssClass = "arrow-down";
        }
        else
        {
          this.FrecciaINBasso.CssClass = "displayNone";
        }

        this.iHtml = new HtmlGenericControl("i");
        this.iHtml.Visible = true;
        this.iHtml.Attributes.Add("class", "MTdropdown-content");
        this.iHtml.Attributes.Add("aria-hidden", "true");

        this.PannelloItem = new Panel();
        this.PannelloItem.ID = "myDropdown";
        this.PannelloItem.CssClass = "MTdropdown-content";
        this.PannelloItem.Attributes.Add("onmouseleave", "myFunction2();");

        
        if (dropdownItems != null)
        {
          foreach (MTCheckboxItem item in dropdownItems)
          {
            this.liHtml = new HtmlGenericControl("li");
            this.liHtml.Attributes.Add("Onclick", string.Format("cliccaMTChkbox('{0}')",this.ID.ToString()));
            this.liHtml.Attributes.Add("value", item.Valore);
            this.liHtml.InnerText = item.Testo;
           
          }
        }

        this.MTCheckboxControllo = new Panel();
        this.MTCheckboxControllo.Visible = true;
        this.MTCheckboxControllo.CssClass = "MTdropdown";
        this.MTCheckboxControllo.ID = "MTdropdown";

        this.MTCheckboxWidth = new Panel();
        this.MTCheckboxWidth.Visible = true;
        this.MTCheckboxWidth.Attributes.Add("style", "width:50px;");

        this.MTCheckboxWidth.Controls.Add(MTChk);
        this.MTCheckboxWidth.Controls.Add(FrecciaINBasso);
        this.PannelloItem.Controls.Add(liHtml);
        this.MTCheckboxWidth.Controls.Add(iHtml);
        this.MTCheckboxWidth.Controls.Add(PannelloItem);


        this.MTCheckboxControllo.Controls.Add(MTCheckboxWidth);

        return true;
      }
      catch (Exception)
      {

        return false;
      }


    }

    private void MTChk_CheckedChanged(object sender, EventArgs e)
    {
      checkedInterno = MTChk.Checked;
    }

    protected override void Render(HtmlTextWriter writer)
    {
      //HtmlInputGenericControl checkboxMT = new HtmlInputGenericControl("checkbox");
      //checkboxMT.Name = "MTcheckbox";
      //checkboxMT.Value = "Seleziona";
      //checkboxMT.ID = "MTcheckbox";
      //checkboxMT.Attributes.Add("class", "MTCheckbox");
      //PostBackOptions pbo = new PostBackOptions(this);
      this.EnsureChildControls();
      
      this.RenderContents(writer);
    }

    //protected override void RenderContents(HtmlTextWriter writer)
    //{
    //  writer.AddAttribute(HtmlTextWriterAttribute.Class, "MTdropdown");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID ?? "MTdropdown");
    //  writer.RenderBeginTag(HtmlTextWriterTag.Div);
    //  //writer.Write(System.Environment.NewLine);
    //  writer.AddAttribute(HtmlTextWriterAttribute.Style, "width: 30px;");
    //  writer.RenderBeginTag(HtmlTextWriterTag.Div);
    //  writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Name, "MTcheckbox");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Value, "Seleziona");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Class, "MTCheckbox");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Id, "MTcheckbox");
    //  writer.RenderBeginTag(HtmlTextWriterTag.Input);
    //  writer.AddAttribute("onmouseover", "myFunction();");
    //  if (dropdownItems != null)
    //  {
    //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "arrow-down");
    //  }
    //  else
    //  {
    //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "displayNone");
    //  }
    //  writer.RenderBeginTag(HtmlTextWriterTag.Div);
    //  writer.RenderEndTag();
    //  writer.AddAttribute(HtmlTextWriterAttribute.Class, "MTdropdown-content");
    //  writer.AddAttribute("aria-hidden", "true");
    //  writer.RenderBeginTag(HtmlTextWriterTag.I);
    //  writer.RenderEndTag();
    //  //writer.Write(System.Environment.NewLine);
    //  writer.AddAttribute(HtmlTextWriterAttribute.Id, "myDropdown");
    //  writer.AddAttribute(HtmlTextWriterAttribute.Class, "MTdropdown-content");
    //  writer.AddAttribute("onmouseleave", "myFunction2();");
    //  writer.RenderBeginTag(HtmlTextWriterTag.Div);
    //  //writer.Write(System.Environment.NewLine);

    //  if (dropdownItems != null)
    //  {
    //    foreach (MTCheckboxItem item in dropdownItems)
    //    {
    //      writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "cliccaMTChkbox()");
    //      writer.AddAttribute(HtmlTextWriterAttribute.Value, item.Valore);
    //      writer.RenderBeginTag(HtmlTextWriterTag.Li);

    //      writer.Write(item.Testo);
    //      item.ElementoCliccato += MTCheckbox_Click;
    //      writer.RenderEndTag();
    //    }
    //  }
    //  writer.RenderEndTag();
    //  //writer.Write(System.Environment.NewLine);
    //  writer.RenderEndTag();
    //  //writer.Write(System.Environment.NewLine);
    //  writer.RenderEndTag();

    //}



    protected override void OnPreRender(EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptResource(typeof(MTCheckbox), "MTCheckbox.Scripts.jquery-3.6.0.min.js");
            Page.ClientScript.RegisterClientScriptResource(typeof(MTCheckbox), "MTCheckbox.Scripts.MTCheckbox.js");
            Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Image.sortdown.png");

            //Page.ClientScript.GetWebResourceUrl(typeof(Class1), "MTCheckbox.Scripts.bootstrap.min.css");
            //Page.ClientScript.GetWebResourceUrl(typeof(Class1), "MTCheckbox.Scripts.font-awesome.min.css");
            HtmlLink cssSource = new HtmlLink();
            cssSource.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Css.MTCheckbox.css");
            cssSource.Attributes["rel"] = "stylesheet";
            cssSource.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(cssSource);

      
            
            //cssSource = new HtmlLink();
            //cssSource.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Scripts.font-awesome.min.css");
            //cssSource.Attributes["rel"] = "stylesheet";
            //cssSource.Attributes["type"] = "text/css";
            //Page.Header.Controls.Add(cssSource);
            //      string includeTemplate = 
            //"<br/> <link rel='stylesheet' text='text/css' href='{0}' />";
            //      string includeLocation =
            //            Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Scripts.bootstrap.min.css");
            //      LiteralControl include =
            //            new LiteralControl(String.Format(includeTemplate, includeLocation));
            //      ((System.Web.UI.HtmlControls.HtmlHead)Page.Header).Controls.Add(include);
            //       includeTemplate =
            //"<link rel='stylesheet' text='text/css' href='{0}' />";
            //       includeLocation =
            //            Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Scripts.font-awesome.min.css");
            //      include =
            //            new LiteralControl(String.Format(includeTemplate, includeLocation));
            //      ((System.Web.UI.HtmlControls.HtmlHead)Page.Header).Controls.Add(include);
        }

    public void RaisePostBackEvent(string eventArgument)
    {
      
    }


    public event MTCheckboxEventArgsHandler ValoreRestituito;

    protected virtual void OnValoreRestituito(MTCheckboxEventArgs e)
    {
      if (ValoreRestituito != null)
      {
        ValoreRestituito(this,e);
      }
    }
  }


  public class MTCheckboxEventArgs : EventArgs
  {
    private string _valoreRestituito;

    public MTCheckboxEventArgs(string valoreRestituito)
    {
      this._valoreRestituito = valoreRestituito;
    }

    public string ValoreRestituito
    {
      get
      {
        return this._valoreRestituito;
      }
    }
  }


  public delegate void MTCheckboxEventArgsHandler(object sender, MTCheckboxEventArgs e);


















}
