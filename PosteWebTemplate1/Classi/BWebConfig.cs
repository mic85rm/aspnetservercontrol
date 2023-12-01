using BArts.BAttributes;
using BArts.BGlobal;
using System.ComponentModel;
using System.Configuration;

namespace PosteWebTemplate1
{
  public partial class BWebConfig
  {

    // DEFINIZIONE COSTANTI
    private const string K_CATEGORY_WP = "WEBPERS";
    private const string K_LinkExternalApp = "LinkExternalApp";
    private const string K_LinkExternalApp_Internet = "LinkExternalApp_Internet";


    // PER OGNI CHIAVE AGGIUNTA NELLA SEZIONE APPSETTINGS DEL WEB CONFIG IMPLEMENTARE LA RELATIVA PROPRIETA' NELLA SEGUENTE CLASSE
    // COME MOSTRATO DI SEGUITO:

    [Description("LinkExternalApp")]
    [BCaption("LinkExternalApp")]
    [Category(K_CATEGORY_WP)]
    [BOrder(2)]
    public static string LinkExternalApp
    {
      get
      {
        return BConvert.ToString(ConfigurationManager.AppSettings[K_LinkExternalApp]);
      }
    }

    [Description("LinkExternalApp_Internet")]
    [BCaption("LinkExternalApp_Internet")]
    [Category(K_CATEGORY_WP)]
    [BOrder(2)]
    public static string LinkExternalApp_Internet
    {
      get
      {
        return BConvert.ToString(ConfigurationManager.AppSettings[K_LinkExternalApp_Internet]);
      }
    }


  }
}