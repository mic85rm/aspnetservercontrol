using MTCheckbox.WebControls;
using System;
using System.ComponentModel;
using System.Text;
using System.Web;
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
    //private Panel PannelloItem;
    private HtmlGenericControl PannelloItem;
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
    private string _ID;
    private int indiceinternochk;
    private HiddenField HFcontaindexchk;
    ClientScriptProxy ClientScriptProxy;


    private int ControlsCount
    {
      get
      {
        object o = ViewState["ControlCount"];
        if (o != null)
          return (int)o;

        return 0;
      }
      set
      {
        ViewState["ControlCount"] = value;
      }
    }

    public delegate void MTCheckboxMenuEventArgsHandler(object sender, MTCheckboxMenuEventArgs e);
    public delegate void MTCheckboxCHKEventArgsHandler(object sender, MTCheckboxCHKEventArgs e);

    public const string SCRIPTLIBRARY_SCRIPT_RESOURCE = "MTCheckbox.Scripts.MTCheckbox.js";
    public const string SCRIPTLIBRARY_SCRIPT_CSS = "MTCheckbox.Scripts.AddCSS.js";


    public enum Forma
    {
      Quadrata,
      Rotonda
    }

   

    public void RaisePostBackEvent(string eventArgument)
    {
      string target = eventArgument.Split('§')[1];
      if (target == "bottone") {
        MTCheckboxMenuEventArgs e = new MTCheckboxMenuEventArgs(eventArgument.Split('§')[0]);
        OnValoreRestituito(e);
      }
      else
      {
        Selezionato = !Convert.ToBoolean(eventArgument.Split('§')[0]);
        //int index = Convert.ToInt32( eventArgument.Split('§')[2]);
        string appoggio= Page.Request.Params.Get("__EVENTTARGET");
        string[] conta = appoggio.Split('$');
        int indice = -1;
        int trovato = -1;
        string prova = "";
        foreach (string item in conta)
        {
          indice += 1;
          if (item.Contains("ctl"))
          {
            trovato = indice;
          }
        }
        prova = conta[trovato].Replace("ctl", "");
        MTCheckboxCHKEventArgs e = new MTCheckboxCHKEventArgs(Selezionato, Page.Request.Params.Get("__EVENTTARGET"),Convert.ToInt32(prova) - 2); 
        OnCHKSelezionata(e);
      }
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
       
        string idDaCambiare = ClientID;
        idDaCambiare=idDaCambiare.Replace(this.ID, "MTmyDropdown");
        this.MTCheckboxWidth.Attributes.Add("onmouseleave", string.Format("MTNascondiSottopannello('{0}');", idDaCambiare));
        this.FrecciaINBasso.Attributes.Add("onmouseenter", string.Format("MTMostraSottopannello('{0}');", idDaCambiare));
        if (_rotondoQuadrato == Forma.Rotonda)
        {
          labelRound.Attributes.Add("for", string.Format("{0}_MTcheckbox", this.ClientID.ToString().Trim()));//nuovo
        }

      
        Controls.Add(MTCheckboxControllo);
        


        this.ClientScriptProxy = ClientScriptProxy.Current;
        Page page = HttpContext.Current.Handler as Page;
        

        ClientScriptProxy.RegisterClientScriptResource(this, this.GetType(), SCRIPTLIBRARY_SCRIPT_RESOURCE);


      



        ClientScriptProxy.RegisterStartupScript(this, this.GetType(), "MTCss", " AddCSS();", true);



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
        //string compostatarget = clientIdHbtn.Replace(this.ID,"MTcheckbox");

        //string stringaLancioEvento = string.Format("__doPostBack('{1}', '{0}');", !Selezionato, UniqueID);
        
        


        //this.MTChk = new CheckBox();
        this.MTChk = new HtmlInputCheckBox();
        this.MTChk.ID = "MTcheckbox";
        //this.MTChk.InputAttributes.Add("class", "MTCheckbox");
        this.MTChk.Attributes.Add("class", "MTCheckbox");
        this.MTChk.Checked = Selezionato;

       

        string stringaLancioEvento = string.Format("__doPostBack('{1}', '{0}§{2}§{3}');", Selezionato, UniqueID, "checkbox",ClientID);
        
        placeHolder.Controls.Add(hiddenButtonMTChk);
        placeHolder.Controls.Add(MTChk);
        if(AutoPostBackCHK== true)
        {
          this.MTChk.Attributes.Add("onclick", stringaLancioEvento);
        //  hiddenButtonMTChk.ServerClick += new System.EventHandler(HiddenButtonMTChk_ServerClick);

        }
        else
        {
          this.MTChk.Attributes.Remove("onclick");
          //hiddenButtonMTChk.ServerClick -= new System.EventHandler(HiddenButtonMTChk_ServerClick);
        }
       
        this.iHtml = new HtmlGenericControl("i");
        this.iHtml.Visible = true;
        this.iHtml.Attributes.Add("class", "MTdropdown-content");
        this.iHtml.Attributes.Add("aria-hidden", "true");


        this.PannelloItem= new HtmlGenericControl("div");
        this.PannelloItem.ID= "MTmyDropdown";
        this.PannelloItem.Attributes.Add("class", "MTdropdown-content");
        //this.PannelloItem = new Panel();
        //this.PannelloItem.ID = "MTmyDropdown";
        //this.PannelloItem.CssClass = "MTdropdown-content";



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
                //this.button.ServerClick += new System.EventHandler(this.Button_Click);
                this.button.Attributes.Remove("onclick");
                string stringaLancioEventoBTN = string.Format("__doPostBack('{1}', '{0}§{2}');", item.Valore, UniqueID,"bottone");
                this.button.Attributes.Add("onclick",stringaLancioEventoBTN);
              }
              else
              {
                this.button.Attributes.Add("onclick","return false");
                //this.button.ServerClick -= new System.EventHandler(this.Button_Click);
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
