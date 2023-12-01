using Microsoft.VisualBasic;

namespace PosteWebTemplate1
{
  public static class ModConstantList
  {

    // COSTANTI FOR CHECK PAGINE DI SISTEMA
    public const string K_SYS_PAGESHOWMESSAGE = "BSystem/sysMessage.aspx";
    public const string K_SYS_HOMECONSOLEDEVELOPER = "BSystem/HomeConsoleDeveloper.aspx";
    public const string K_SYS_PAGELOGIN = "BSYSTEM/SYSLOGIN.ASPX";
    public const string K_SYS_PAGESTARTAPP = "BSYSTEM/SYSSTARTAPPDEBUG.ASPX";
    public const string K_SYS_PAGEDEFAULT = "DEFAULT.ASPX";
    public const string K_SYS_PAGEHOME = "HOME.ASPX";

    public const string K_SYS_PAGE_AUTHGOOGLE = "BSystem/AuthGoogle";
    public const string K_SYS_PAGE_AUTHAPPLE = "BSystem/AuthApple";
    public const string K_SYS_PAGE_AUTHMICROSOFT = "BSystem/AuthMicrosoft";


    // COSTANTI FOR NAVIGATION PAGINE DI SISTEMA
    public const string K_PAGE_DEFAULT = "~/default.aspx";
    public const string K_PAGE_HOME = "~/home.aspx";
    public const string K_PAGE_LOGIN = "~/BSystem/sysLogin.aspx";
    public const string K_PAGE_SELECTPROFILO = "~/BSystem/sysSelectProfilo.aspx";
    public const string K_PAGE_SHOWMESSAGEPAGE = "~/BSystem/sysMessage.aspx";
    public const string K_PAGE_HOMECONSOLEDEVELOPER = "~/BSystem/HomeConsoleDeveloper.aspx";
    public const string K_PAGE_REGISTRAZIONE = "~/BSystem/sysRegistrazione.aspx";
    public const string K_PAGE_RECUPERAPWD = "~/BSystem/sysRecuperaPassword.aspx";
    public const string K_PAGE_HELP = "~/Help.aspx";
    public const string K_PAGE_PAGESTARTAPP = "~/BSystem/sysStartAppDebug.aspx";



    // COSTANTI DI SISTEMA
    public const string K_SE_SYSINITAPP = "SYS.INITAPP";
    public const string K_SE_SYSINITAPPFAILED = "SYS.INITAPPFAILED";
    public const string K_SE_VERSIONE = "SYS.VERSIONE";
    public const string K_SE_SYSMSG = "SYS.MSG";
    public const string K_SE_SYSDBUSER = "SYS.DBUSER";
    public const string K_SE_SYSSETDBUSER = "SYS.SETDBUSER";
    public const string K_SE_SYSDB = "SYS.DB";
    public const string K_SE_SYSSETDB = "SYS.SETDB";
    public const string K_SE_SYSUTENTEENTRATO = "SYS.UTENTEENTRATO";
    public const string K_SE_SYSCONFIGURATION = "SYS.CONFIGURATION";
    public const string K_SE_SYSREPORTINGSERVICES = "SYS.REPORTINGSERVICES";
    public const string K_SE_SYSPAGEREQUIRED = "SYS.PAGEREQUIRED";
    public const string K_SE_SYSSESSIONID = "SYS.SESSIONID";


    // NOMENCLATURA ERRORI
    public const string K_ErroreGenerico = "Si è verificato un errore nell'applicativo. Contattare il distributore!!";
    public const string K_ErroreCambiaRec = "Si è verificato un errore durante il caricamento dei dati...";
    public const string K_InsObb = "Inserimento obbligatorio!!";

    // COSTANTI APPLICATIVE
    public const string K_TRUE = "TRUE";
    public const string K_FALSE = "FALSE";

    // PWD
    public const int K_LUNGHEZZA_MINIMA_USERNAME = 6;
    public const string K_PreviousPage = "Paginaprecedente";

    // COSTANTI PER L'EXPORT EXCEL
    public const string K_EXPORTEXCEL_DTV = "ExportExcel_Dataview";
    public const string K_EXPORTEXCEL_PAGINA = "ExportExcel_PaginaChiamante";
    public const string K_EXPORTEXCEL_FORMATO = "ExportExcel_Formato";
    public const string K_EXPORTEXCEL_NOMEFILE = "ExportExcel_NomeFile";

    // COSTANTE PER LA SESSIONE DELL'OGGETTO REPORTISTICA
    public const string K_REPORT_OGGETTOREPORTISTICA = "Report_ObjReportistica";
    public const string K_REPORT_NOMEREPORTPROVA = "rptProva";

    // COSTANTI PER WEBPERS
    public const string K_PAGE_Token = "~/BSystem/sysStartApp.aspx";
  }
}