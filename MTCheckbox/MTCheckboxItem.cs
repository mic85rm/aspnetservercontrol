using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace MTCheckbox
{
  [ToolboxData("<{0}:MTCheckboxItem runat=server></{0}:MTCheckboxItem>")]
  public class MTCheckboxItem
  {
    private string _itemTestoVisualizzato;
    private string _itemValore;
    //private bool __itemSelezionato;
    

    [
    Category("Behavior"),
    DefaultValue(""),
    Description("Valore della dropdown."),
    NotifyParentProperty(true),
    ]
    public virtual String Valore
    {
      get
      {
        return _itemValore;
      }
      set
      {
        _itemValore = value;
      }
    }

    [
    Category("Behavior"),
    DefaultValue(""),
    Description("Testo della dropdown."),
    NotifyParentProperty(true),
    ]
    public virtual String Testo
    {
      get
      {
        return _itemTestoVisualizzato;
      }
      set
      {
        _itemTestoVisualizzato = value;
      }
    }

    //[
    //Category("Behavior"),
    //DefaultValue(""),
    //Description("Valore selezionato ritorna booleano"),
    //NotifyParentProperty(true),
    //]
    //public virtual bool IsSelected
    //{
    //  get
    //  {
    //    return __itemSelezionato;
    //  }
    //  set
    //  {
    //    __itemSelezionato = value;
    //  }
    //}
  }
}

