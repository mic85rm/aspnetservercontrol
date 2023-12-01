
using System;

namespace PosteWebTemplate1
{
  public static class ModEnumeration
  {

    public enum eVersione
    {
      bDebug = 0,
      bRelease = 1,
      bDemo = 2
    }

    public enum eTipoDB
    {
      bMSAccess = 0,
      bMSSQL = 1,
      bMSAccess2007 = 2,
      bOracle = 3
    }

    public enum eFormatoExport
    {
      CSV,
      XLS
    }

    public enum eAttachCommandType : byte
    {
      Report,
      Function,
      DownloadFile,
      PreviewReport
    }

    public enum eGlobalSearch
    {
      Menu,
      Wiki,
      Other
    }

  }
}