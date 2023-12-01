using BArts.BGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class BHTML
{


  // FUNCTION TO USE INTO HTML
  public static string FormattaBool(bool valore, string TextTrue = "Sì", string TextFalse = "No")
  {
    return BGlobal.FormattaBool(valore, TextTrue, TextFalse);
  }
  public static string FormattaNumero(float valore, byte ZeroDopoVirgola_CifreArrSenzaVirgolaMobile = 2, bool VirgolaMobile = false, byte CifreArrConVirgolaMobile = 4)
  {
    return BGlobal.FormattaNumero(valore, ZeroDopoVirgola_CifreArrSenzaVirgolaMobile, VirgolaMobile, CifreArrConVirgolaMobile);
  }
  public static string FormattaData(DateTime valore, string Formato = "dd/MM/yyyy")
  {
    return BGlobal.FormattaData(valore, Formato);
  }


}
