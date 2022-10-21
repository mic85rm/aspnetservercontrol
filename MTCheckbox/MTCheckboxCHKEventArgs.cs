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
    private string _chkIDSelezionata;
    private int _index;

    public MTCheckboxCHKEventArgs(Boolean chkSelezionata,string chkIDSelezionata,int index)
    {
      this._chkSelezionata = chkSelezionata;
      this._chkIDSelezionata = chkIDSelezionata;
      this._index = index;
    }

    public Boolean CheckSelezionata
    {
      get
      {
        return this._chkSelezionata;
      }
    }

    public string IDCheckSelezionata
    {
      get
      {
        return this._chkIDSelezionata;
      }
    }

    public int Index
    {
      get
      {
        return this._index;
      }
    }

  }
}
