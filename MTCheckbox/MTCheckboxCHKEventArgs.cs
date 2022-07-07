using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCheckbox
{
  public class MTCheckboxCHKEventArgs : EventArgs
  {
    private Boolean _chkSelezionata;

    public MTCheckboxCHKEventArgs(Boolean chkSelezionata)
    {
      this._chkSelezionata = chkSelezionata;
    }

    public Boolean CheckSelezionata
    {
      get
      {
        return this._chkSelezionata;
      }
    }
  }
}
