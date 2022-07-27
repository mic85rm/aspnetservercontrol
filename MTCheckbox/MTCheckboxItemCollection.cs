using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCheckboxNS.WebControls
{
  public class MTCheckboxItemCollection: CollectionBase
  {
    public MTCheckboxItem this[int index]
    {
      get
      {
        return (MTCheckboxItem)this.List[index];
      }
      set
      {
        this.List[index] = value;
      }
    }

    public void Add(MTCheckboxItem item)
    {
      this.List.Add(item);
    }

    public void Insert(int index, MTCheckboxItem item)
    {
      this.List.Insert(index, item);
    }

    public void Remove(MTCheckboxItem item)
    {
      List.Remove(item);
    }

    public bool Contains(MTCheckboxItem item)
    {
      return this.List.Contains(item);
    }

    //Collection IndexOf method 
    public int IndexOf(MTCheckboxItem item)
    {
      return List.IndexOf(item);
    }

    public void CopyTo(MTCheckboxItem[] array, int index)
    {
      List.CopyTo(array, index);
    }
  }
}
