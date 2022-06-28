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
    HtmlGenericControl labelRound;

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
      MTCheckboxEventArgs eventValore = new MTCheckboxEventArgs(prova.CommandArgument);
      OnValoreRestituito(eventValore);

    }

    private void MTChk_CheckedChanged(object sender, EventArgs e)
    {
      _itemChecked = MTChk.Checked;
      

    }

    //protected override void Render(HtmlTextWriter writer)
    //{
    //  writer.Indent = 4;

    //  //if (Page != null)
    //  //{
    //  //  if (!Page.Controls.Contains(this))
    //  //  {
    //  //    Page.VerifyRenderingInServerForm(this);
    //  //  }
    //  //  else { return; }
    //  //}
    //  this.RenderContents(writer);
    //  this.EnsureChildControls();

    //  //base.Render(writer);


    //}

    //protected override void RenderContents(HtmlTextWriter writer)
    //{
    //  writer.Indent = 4;


    //  //this.RenderContents(writer);
    //  this.EnsureChildControls();

    //  //base.Render(writer);


    //}


    //protected override void AddAttributesToRender(HtmlTextWriter writer)
    //{
    //  base.AddAttributesToRender(writer);



    //}


    protected override void OnPreRender(EventArgs e)
        {
           
            Page.ClientScript.RegisterClientScriptResource(typeof(MTCheckbox), "MTCheckbox.Scripts.MTCheckbox.js");
            Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Image.sortdown.png");


            HtmlLink cssSource = new HtmlLink();
            cssSource.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "MTCheckbox.Css.MTCheckbox.css");
            cssSource.Attributes["rel"] = "stylesheet";
            cssSource.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(cssSource); 
    
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
