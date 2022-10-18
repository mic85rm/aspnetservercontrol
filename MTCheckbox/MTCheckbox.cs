using MTCheckbox.WebControls;
using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace MTCheckbox
{
  [ParseChildren(true)]

  [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
  [ToolboxData("<{0}:MTCheckbox runat=server></{0}:MTCheckbox>")]
    public class MTCheckbox:WebControl,IPostBackEventHandler
    {


    private MTCheckboxItemCollection MTdropdownItems;
    //private CheckBox MTChk;
    private HtmlInputCheckBox MTChk;
    private HtmlButton hiddenButtonMTChk;
    private HiddenField hiddenField;
    private PlaceHolder placeHolder;
    private Panel FrecciaINBasso;
    private HtmlGenericControl iHtml;
    private HtmlGenericControl liHtml;
    private Panel PannelloItem;
    private Panel MTCheckboxControllo;
    private Panel MTCheckboxWidth;
    private HtmlButton button;
    private bool _itemChecked;
    private Forma _rotondoQuadrato;
    private string _MTCSSClass;
    private string _MTJS;
    private HtmlGenericControl labelRound;
    private Boolean _MTAutoPostBackCHK;
    private Boolean _MTAutoPostBackMENU;

    ClientScriptProxy ClientScriptProxy;
  

    //public event EventHandler Click;
    //public event EventHandler Checked;

    public delegate void MTCheckboxMenuEventArgsHandler(object sender, MTCheckboxMenuEventArgs e);
    public delegate void MTCheckboxCHKEventArgsHandler(object sender, MTCheckboxCHKEventArgs e);

    public const string SCRIPTLIBRARY_SCRIPT_RESOURCE = "MTCheckbox.Scripts.MTCheckbox.js";
    public enum Forma
    {
      Quadrata,
      Rotonda
    }

    //protected virtual void Prova(EventArgs e)
    //{
    //  if (Checked != null)
    //  {
    //    Checked(this, e);
    //  }
    //}




    //protected virtual void OnClick(EventArgs e)
    //{
     
    //  if (Click != null)
    //  {
    //    Click(this, e);
    //  }
   
    //}

    public void RaisePostBackEvent(string eventArgument)
    {
      //string prova = eventArgument;
      //OnClick(new EventArgs());
      //Prova(new EventArgs());
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


    [Bindable(true)]
    [Category("Option")]
    [DefaultValue(false)]
    public virtual Boolean AutoPostBackCHK // property
    {
      get { return _MTAutoPostBackCHK; }   // get method
      set { _MTAutoPostBackCHK = value; }  // set method
    }

    [Bindable(true)]
    [Category("Option")]
    [DefaultValue(false)]
    public virtual Boolean AutoPostBackMENU // property
    {
      get { return _MTAutoPostBackMENU; }   // get method
      set { _MTAutoPostBackMENU = value; }  // set method
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

        //Attributes.Add("onclick", string.Format("__doPostBack('{0}','');",MTChk.UniqueID+button.UniqueID));
        //this.bottoneCliccato += Button_Click;

        Controls.Add(MTCheckboxControllo);



        HtmlLink cssSource = new HtmlLink();
        cssSource.Href = this.ClientScriptProxy.GetWebResourceUrl(this, this.GetType(), "MTCheckbox.Css.MTCheckbox.css");
        cssSource.Attributes["rel"] = "stylesheet";
        cssSource.Attributes["type"] = "text/css";
        //Page.Header.Controls.Add(cssSource);
        this.Controls.Add(cssSource);





        this.ClientScriptProxy.RegisterClientScriptResource(this, this.GetType(), SCRIPTLIBRARY_SCRIPT_RESOURCE);



     
        base.CreateChildControls();
      }
      catch (Exception a)
      {


      }

      
    }

    

   

    private Boolean InizializzaControllo()
    {

      this.placeHolder = new PlaceHolder();

      
      try
      {
        this.hiddenButtonMTChk = new HtmlButton();
        hiddenButtonMTChk.ID = "hbtn";
        hiddenButtonMTChk.Attributes.Add("style","display:none;");
        string clientIdHbtn = this.ClientID;
      string stringaLancioEvento = string.Format("{0}.click();",clientIdHbtn.Replace("chk","hbtn"));

        //this.MTChk = new CheckBox();
        this.MTChk = new HtmlInputCheckBox();
        this.MTChk.ID = "MTcheckbox";
        //this.MTChk.InputAttributes.Add("class", "MTCheckbox");
        this.MTChk.Attributes.Add("class", "MTCheckbox");
        this.MTChk.Checked = Selezionato;
        




        //this.MTChk.AutoPostBack = AutoPostBack;
        //if (MTChk.AutoPostBack == true)
        //{
        //  MTChk.CheckedChanged += MTChk_CheckedChanged;
        //}
        placeHolder.Controls.Add(hiddenButtonMTChk);
        placeHolder.Controls.Add(MTChk);
        if(AutoPostBackCHK== true)
        {
          this.MTChk.Attributes.Add("onclick", stringaLancioEvento);
          hiddenButtonMTChk.ServerClick += new System.EventHandler(HiddenButtonMTChk_ServerClick);

        }
        else
        {
          this.MTChk.Attributes.Remove("onclick");
          hiddenButtonMTChk.ServerClick -= new System.EventHandler(HiddenButtonMTChk_ServerClick);
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

              //this.button = new Button();
              this.button = new HtmlButton();
            this.button.Attributes.Add("class","MTunstyled-button");
            this.button.ID = string.Format("btn{0}",i);

              //this.button.Click += Button_Click;
             
              //this.button.Disabled = false;
              if (AutoPostBackMENU == true)
              {
                this.button.ServerClick += new System.EventHandler(this.Button_Click);
                this.button.Attributes.Remove("onclick");
              }
              else
              {
                this.button.Attributes.Add("onclick","return false");
                this.button.ServerClick -= new System.EventHandler(this.Button_Click);
              }
              //this.button.InnerText = item.Testo;
              this.button.InnerHtml= item.Testo;
              //this.button.CommandArgument = item.Valore;
              this.button.Attributes.Add("CommandArgument",item.Valore);
              
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
        //this.MTCheckboxWidth.Controls.Add(MTChk);
        this.MTCheckboxWidth.Controls.Add(placeHolder);
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

    private void HiddenButtonMTChk_ServerClick(object sender, EventArgs e)
    {
      _itemChecked = MTChk.Checked;
      MTCheckboxCHKEventArgs eventValore = new MTCheckboxCHKEventArgs(MTChk.Checked, this.ID);
      OnCHKSelezionata(eventValore);
    }

    private void Button_Click(object sender, EventArgs e)
    {
      
      //MTChk.Checked = true;
      HtmlButton prova =(HtmlButton) sender;
      //MTCheckboxMenuEventArgs eventValore = new MTCheckboxMenuEventArgs(prova.CommandArgument);
      MTCheckboxMenuEventArgs eventValore = new MTCheckboxMenuEventArgs(prova.Attributes["CommandArgument"]); ;
      OnValoreRestituito(eventValore);

    }

    //private void MTChk_CheckedChanged(object sender, EventArgs e)
    //{
    //  _itemChecked = MTChk.Checked;
    //  MTCheckboxCHKEventArgs eventValore = new MTCheckboxCHKEventArgs(MTChk.Checked, this.ID);
    //  OnCHKSelezionata(eventValore);


    //}



    protected override void OnInit(EventArgs e)

    {

      this.ClientScriptProxy = ClientScriptProxy.Current;
      HtmlLink cssSource = new HtmlLink();
      cssSource.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Css.MTCheckbox.css");
      cssSource.Attributes["rel"] = "stylesheet";
      cssSource.Attributes["type"] = "text/css";
      Page.Header.Controls.Add(cssSource);
      this.Controls.Add(cssSource);
      base.OnInit(e);

    }


    protected override void OnLoad(EventArgs e)
    {
      string IDUNICO = this.UniqueID;
      string IDCLIENT = this.ClientID;
      string IDCORRETTO = string.Empty;
      string valoreInterno = string.Empty;
      string IDCHIAMANTE= Page.Request.Params.Get("__EVENTTARGET");
      if (!(string.IsNullOrWhiteSpace(IDCHIAMANTE))&&(IDCHIAMANTE.Split('$')[2] != "hbtn")) { 
      int posizione=Convert.ToInt32( IDCHIAMANTE.Split('$')[2].Replace("btn",string.Empty));
        valoreInterno = MTDropdownItems[posizione - 1].Valore;
      }
      if ((Page.IsPostBack)) {

      if (IDUNICO.Split('$')[1] == IDCHIAMANTE.Split('$')[1]){
          //if (IDCHIAMANTE.Split('$')[2] != "hbtn") {

          // var oggetto= this.FindControl(IDCORRETTO);
          //  Button_Click(oggetto,e); }
          if (IDCHIAMANTE.Split('$')[2] != "hbtn") { MTCheckboxMenuEventArgs e2 = new MTCheckboxMenuEventArgs(valoreInterno);
            OnValoreRestituito(e2); }
          if (IDCHIAMANTE.Split('$')[2] == "hbtn") { MTCheckboxCHKEventArgs e3 = new MTCheckboxCHKEventArgs(false,IDUNICO); OnCHKSelezionata(e3); }
          //OnClick(e);
        }
       
      }
        
      base.OnLoad(e);
    }



    public event MTCheckboxMenuEventArgsHandler ValoreRestituito;
    public event MTCheckboxCHKEventArgsHandler CheckSelezionata;

    protected virtual void OnValoreRestituito(MTCheckboxMenuEventArgs e)
    {
      if (ValoreRestituito != null)
      {
        ValoreRestituito(this, e);
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
