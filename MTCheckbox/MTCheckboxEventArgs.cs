using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCheckbox
{
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
}
