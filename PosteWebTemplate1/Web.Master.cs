using BArts.BSecurity;
using BArts.BWeb;
using Microsoft.Win32;

namespace PosteWebTemplate1
{
  public partial class Web
  {
    // IMPLEMENTARE QUI EVENTUALI FUNZIONI CUSTOM RELATIVE ALL'APPLICATIVO


    //GLOBAL SEARCH

    public bool ExecCommand(string Command, ModEnumeration.eGlobalSearch Tipo, string Args)
    {
      switch (Tipo)
      {
        case ModEnumeration.eGlobalSearch.Menu:
          if (!string.IsNullOrEmpty(Command))
          {
            base.BRedirect("~/" + Command);
          }
          break;
        case ModEnumeration.eGlobalSearch.Wiki:
          base.BRedirect(ModConstantList.K_PAGE_HELP + "?q=" + BCrypter.Encrypt(Args));

          break;
        case ModEnumeration.eGlobalSearch.Other:
          break;
        default:

          break;
      }

      return false;
    }




  } //END CLASS
} //END NAMESPACE