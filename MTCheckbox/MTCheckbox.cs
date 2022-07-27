using MTCheckboxNS.WebControls;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace MTCheckboxNS
{
  [ParseChildren(true)]
  
  [ToolboxData("<{0}:MTCheckbox runat=server></{0}:MTCheckbox>")]
    public class MTCheckbox:WebControl,INamingContainer,IPostBackEventHandler
    {


    private MTCheckboxItemCollection MTdropdownItems;
    private CheckBox MTChk;
    private Panel FrecciaINBasso;
    private HtmlGenericControl iHtml;
    private HtmlGenericControl liHtml;
    private Panel PannelloItem;
    private Panel MTCheckboxControllo;
    private Panel MTCheckboxWidth;
    private Button button;
    private bool _itemChecked;
    private Forma _rotondoQuadrato;
    private string _MTCSSClass;
    private string _MTJS;
    private HtmlGenericControl labelRound;
    private Boolean _MTAutoPostBack;
    ClientScriptProxy ClientScriptProxy;

    public delegate void MTCheckboxMenuEventArgsHandler(object sender, MTCheckboxMenuEventArgs e);
    public delegate void MTCheckboxCHKEventArgsHandler(object sender, MTCheckboxCHKEventArgs e);

    public const string SCRIPTLIBRARY_SCRIPT_RESOURCE = "MTCheckbox.Scripts.MTCheckbox.js";
    public enum Forma
    {
      Quadrata,
      Rotonda
    }
    

    //private Boolean checkedInterno; // field



    /// <summary>
    /// Imposta o ritorna il valore della checkbox di questo controllo
    /// true quando è spuntata false quando non è spuntata
    /// </summary>
    [Bindable(true)]
    [Category("Behavior")]
    [DefaultValue("false")]
    [Localizable(true)]
    [Description("Imposta o ritorna il valore della checkbox di questo controllo")]
    [System.ComponentModel.Browsable(true)]
    public virtual Boolean Selezionato   // property
    {
      get { return _itemChecked; }   // get method
      set { _itemChecked = value; }  // set method
    }


    /// <summary>
    /// Imposta o ritorna il valore della checkbox di questo controllo
    /// true quando è spuntata false quando non è spuntata
    /// </summary>
    [Bindable(true)]
    [Category("Behavior")]
    [DefaultValue("false")]
    [Localizable(true)]
    [Description("Imposta o ritorna la forma della checkbox di questo controllo")]
    [System.ComponentModel.Browsable(true)]
    public virtual Forma FormaCheckbox   // property
    {
      get { return _rotondoQuadrato; }   // get method
      set { _rotondoQuadrato = value; }  // set method
    }






    //[Bindable(false)]
    //[Category("Option")]
    //[DefaultValue("MTCheckbox.Css.MTCheckbox.css")]
    //[Localizable(true)]
    //[CssClassProperty]
    //public virtual string MTCssClass  // property
    //{
    //  get { return _MTCSSClass; }   // get method
    //  set { _MTCSSClass = value; }  // set method
    //}

    //[Bindable(false)]
    //[Category("Option")]
    //[DefaultValue("MTCheckbox.Scripts.MTCheckbox.js")]
    //[Localizable(true)]
    //[CssClassProperty]
    //public virtual string MTJS  // property
    //{
    //  get { return _MTJS; }   // get method
    //  set { _MTJS = value; }  // set method
    //}


    [Bindable(false)]
    [Category("Option")]
    [DefaultValue(false)]
    public virtual Boolean AutoPostBack  // property
    {
      get { return _MTAutoPostBack; }   // get method
      set { _MTAutoPostBack = value; }  // set method
    }




    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public MTCheckboxItemCollection MTDropdownItems
    {
      get
      {
        if (MTdropdownItems == null)
        {
          MTdropdownItems = new MTCheckboxItemCollection();
        }
        return MTdropdownItems;
      }
    }


    protected override void AddParsedSubObject(object obj)
    {
      if (obj is MTCheckboxItem)
      {
        this.MTDropdownItems.Add((MTCheckboxItem)obj);
        return;
      }
    }


  

    protected override void CreateChildControls()
    {
      
      try
      {

       
        InizializzaControllo();
        int conta = Controls.Count;
        this.Controls.Clear();
     
        this.MTCheckboxWidth.Attributes.Add("onmouseleave", string.Format("MTNascondiSottopannello('{0}');", this.ClientID.ToString()));
        this.FrecciaINBasso.Attributes.Add("onmouseenter", string.Format("MTMostraSottopannello('{0}');", this.ClientID.ToString()));
        if (_rotondoQuadrato == Forma.Rotonda)
        {
          labelRound.Attributes.Add("for", string.Format("{0}_MTcheckbox", this.ClientID.ToString().Trim()));//nuovo
        }
          
        
        Controls.Add(MTCheckboxControllo);
        
        



        HtmlLink cssSource = new HtmlLink();
        cssSource.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Css.MTCheckbox.css");
        cssSource.Attributes["rel"] = "stylesheet";
        cssSource.Attributes["type"] = "text/css";
        Page.Header.Controls.Add(cssSource);
       // Page.Controls.Add(cssSource);

        this.ClientScriptProxy.RegisterClientScriptResource(this, this.GetType(), SCRIPTLIBRARY_SCRIPT_RESOURCE);



     
        base.CreateChildControls();
      }
      catch (Exception a)
      {


      }

      
    }

   

    private Boolean InizializzaControllo()
    {

     
      try
      {
        this.MTChk = new CheckBox();
        this.MTChk.ID = "MTcheckbox";
        this.MTChk.InputAttributes.Add("class", "MTCheckbox");
        this.MTChk.Checked = Selezionato;
        this.MTChk.AutoPostBack = AutoPostBack;
        if (MTChk.AutoPostBack == true)
        {
          MTChk.CheckedChanged += MTChk_CheckedChanged;
        }

        this.iHtml = new HtmlGenericControl("i");
        this.iHtml.Visible = true;
        this.iHtml.Attributes.Add("class", "MTdropdown-content");
        this.iHtml.Attributes.Add("aria-hidden", "true");

        this.PannelloItem = new Panel();
        this.PannelloItem.ID = "MTmyDropdown";
        this.PannelloItem.CssClass = "MTdropdown-content";



        this.FrecciaINBasso = new Panel();

        if (MTdropdownItems != null)
        {
          this.FrecciaINBasso.CssClass = "MTarrow-down";
        }
        else
        {
          this.FrecciaINBasso.CssClass = "MTdisplayNone";
        }



        if (MTdropdownItems != null)
        {
          int i = 1;
          foreach (MTCheckboxItem item in MTdropdownItems)
          {
            if (item.Testo!=null) { 
            this.liHtml = new HtmlGenericControl("li");

            this.button = new Button();
            this.button.CssClass = "MTunstyled-button";
            this.button.ID = string.Format("btn{0}",i);
           
            this.button.Click += Button_Click;
            this.button.Text = item.Testo;
            this.button.CommandArgument = item.Valore;
            this.liHtml.Controls.Add(button);
            this.PannelloItem.Controls.Add(liHtml);
            i++;
            }
            //else
            //{
            //  this.liHtml = new HtmlGenericControl("li");
            //  this.liHtml.Attributes.Add("style", "width:100%;");
            //  //this.liHtml.Attributes.Add("Onclick", string.Format("cliccaMTChkbox('{0}')",this.ID.ToString()));
            //  //this.liHtml.Attributes.Add("value", item.Valore);
            //  //this.liHtml.InnerText = item.Testo;
            //  this.button = new Button();
            //  this.button.CssClass = "unstyled-button";
            //  this.button.ID = string.Format("btn{0}", i);
            //  //this.button.Click += Button_Click;
            //  this.button.Text = "Se non vuoi che venga visualizzato cancella MTCheckboxItem  che non ha il campo Testo";
            //  //this.button.CommandArgument = item.Valore;
            //  this.liHtml.Controls.Add(button);
            //  this.PannelloItem.Controls.Add(liHtml);
            //  i++;
            //}
          }
        }

        this.MTCheckboxControllo = new Panel();
        this.MTCheckboxControllo.Visible = true;
        this.MTCheckboxControllo.CssClass = "MTdropdown";
        this.MTCheckboxControllo.ID = "MTdropdown";

        this.MTCheckboxWidth = new Panel();
        this.MTCheckboxWidth.Visible = true;
        this.MTCheckboxWidth.Attributes.Add("style", "width:50px;");
        if (_rotondoQuadrato == Forma.Rotonda)
        {
          this.MTCheckboxWidth.CssClass = "MTround";//nuovo

        }
        this.MTCheckboxWidth.Controls.Add(MTChk);
        if (_rotondoQuadrato == Forma.Rotonda)
        {

         labelRound= new HtmlGenericControl("label");//nuovo
        
          this.MTCheckboxWidth.Controls.Add(labelRound);//nuovo
        }
        this.MTCheckboxWidth.Controls.Add(FrecciaINBasso);
        
        this.MTCheckboxWidth.Controls.Add(iHtml);
        this.MTCheckboxWidth.Controls.Add(PannelloItem);


        this.MTCheckboxControllo.Controls.Add(MTCheckboxWidth);

        return true;
      }
      catch (Exception a)
      {

        return false;
      }


    }

   

    private void Button_Click(object sender, EventArgs e)
    {
      MTChk.Checked = true;
      Button prova =(Button) sender;
      MTCheckboxMenuEventArgs eventValore = new MTCheckboxMenuEventArgs(prova.CommandArgument);
      OnValoreRestituito(eventValore);

    }

    private void MTChk_CheckedChanged(object sender, EventArgs e)
    {
      _itemChecked = MTChk.Checked;
      MTCheckboxCHKEventArgs eventValore = new MTCheckboxCHKEventArgs(MTChk.Checked);
      OnCHKSelezionata(eventValore);
      

    }

    

    protected override void OnInit(EventArgs e)

    {

      this.ClientScriptProxy = ClientScriptProxy.Current;

      base.OnInit(e);

    }


 
    public void RaisePostBackEvent(string eventArgument)
    {
      
    }


    public event MTCheckboxMenuEventArgsHandler ValoreRestituito;
    public event MTCheckboxCHKEventArgsHandler CheckSelezionata;

    protected virtual void OnValoreRestituito(MTCheckboxMenuEventArgs e)
    {
      if (ValoreRestituito != null)
      {
        ValoreRestituito(this,e);
      }
    }
  

  protected virtual void OnCHKSelezionata(MTCheckboxCHKEventArgs e)
  {
    if (CheckSelezionata != null)
    {
      CheckSelezionata(this, e);
    }
  }
}























}
