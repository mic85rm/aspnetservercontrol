using BArts.BAttributes;
using BArts.BGlobal;
using BArts.BReports;
using BTemplateBaseLibrary;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

namespace PosteWebTemplate1
{
  public partial class BWebConfig
  {
    // DEFINIZIONE COSTANTI
    private const string K_WC_VS_DEBUG = "VS_DEBUG";
    private const string K_WC_AUTOMINIFY = "AUTOMINIFY";

    // STRINGE DI CONNESSIONE
    private const string K_WC_CNNSTR = "CNNSTR";

    // COSTANTI GLOBALI PER ACCESSO AL WEB.CONFIG
    private const string K_WC_AUTHTYPE = "AUTHTYPE";
    private const string E_AUTHTYPE_WINDOWS = "WINDOWS";
    private const string E_AUTHTYPE_NONE = "NONE";
    private const string K_WC_SHOWNTACCOUNT = "SHOWNTACCOUNT";
    private const string K_WC_WEBSITEUSEDB = "WEBSITEUSEDB";

    // COSTANTI PER DB USER 
    private const string K_WC_DBUSER_DB = "DBUSER_DB";
    private const string K_WC_DBUSER_SERVER = "DBUSER_SERVER";
    private const string K_WC_DBUSER_USER = "DBUSER_USER";
    private const string K_WC_DBUSER_PWD = "DBUSER_PWD";

    // COSTANTI PER DB APPLICATION
    private const string K_WC_DBAPP_DB = "DBAPP_DB";
    private const string K_WC_DBAPP_SERVER = "DBAPP_SERVER";
    private const string K_WC_DBAPP_USER = "DBAPP_USER";
    private const string K_WC_DBAPP_PWD = "DBAPP_PWD";

    // COSTANTI PER DB VIEWSTATE
    private const string K_WC_VIEWSTATE_ONDB = "VIEWSTATE_ONDB";
    private const string K_WC_VIEWSTATE_DB = "VIEWSTATE_DB";
    private const string K_WC_VIEWSTATE_SERVER = "VIEWSTATE_SERVER";
    private const string K_WC_VIEWSTATE_USER = "VIEWSTATE_USER";
    private const string K_WC_VIEWSTATE_PWD = "VIEWSTATE_PWD";
    private const string K_WC_VIEWSTATE_TIMEOUT = "VIEWSTATE_TIMEOUT";

    // COSTANTI PER REPORTING SERVICE
    private const string K_WC_SERVERREPORT_NOME = "SERVERREPORT_NAME";
    private const string K_WC_SERVERREPORT_DOMAIN = "SERVERREPORT_DOMAIN";
    private const string K_WC_SERVERREPORT_USER = "SERVERREPORT_USER";
    private const string K_WC_SERVERREPORT_PWD = "SERVERREPORT_PWD";
    private const string K_WC_SERVERREPORT_FOLDER = "SERVERREPORT_FOLDER";
    private const string K_WC_SERVERREPORT_VERSION = "SERVERREPORT_VERSION";
    private const string K_WC_SERVERREPORT_SSL = "SERVERREPORT_SSL";

    // COSTANTI PER LOG
    private const string K_WC_LEVELLOG = "LEVELLOG";
    private const string K_WC_WRITEERRORONEVENTLOG = "WRITEERRORONEVENTLOG";
    private const string K_WC_WRITEERRORONDB = "WRITEERRORONDB";
    private const string K_WC_WRITEERRORONFILE = "WRITEERRORONFILE";
    private const string K_WC_WRITEERRORONFILE_PATHREL = "WRITEERRORONFILE_PATHREL";
    private const string K_WC_WRITEERRORONFILE_PATH = "WRITEERRORONFILE_PATH";
    private const string K_WC_WRITEERRORONFILE_WRITEONLYEVENTS = "WRITEONLYEVENTS";
    private const string K_WC_WRITEERRORONFILE_FILEEVENTS = "WRITEERRORONFILE_FILEEVENTS";
    private const string K_WC_WRITEERRORONFILE_FILEERRORS = "WRITEERRORONFILE_FILEERRORS";
    private const string K_WC_SENDMAILONERROR = "SENDMAILONERROR";
    private const string K_WC_SENDMAILONERRORFROM = "SENDMAILONERRORFROM";
    private const string K_WC_SENDMAILONERRORTO = "SENDMAILONERRORTO";
    private const string K_WC_SENDMAIL_SENDERTYPE = "SENDMAIL_SENDERTYPE";
    private const string K_WC_SENDMAIL_SMTPSERVER = "SENDMAIL_SMTPSERVER";
    private const string K_WC_SENDMAIL_SMTPPORT = "SENDMAIL_SMTPPORT";
    private const string K_WC_SENDMAIL_USERNAME = "SENDMAIL_USERNAME";
    private const string K_WC_SENDMAIL_PASSWORD = "SENDMAIL_PASSWORD";
    private const string K_WC_SENDMAIL_SSL = "SENDMAIL_SSL";
    private const string K_WC_SENDMAIL_NOMEPROFILO = "SENDMAIL_NOMEPROFILO";
    private const string K_WC_SENDMAIL_NOMEACCOUNT = "SENDMAIL_NOMEACCOUNT";

    // COSTANTI APPLICATION INFO
    private const string K_WC_GESTIONEUTENTI = "GESTIONEUTENTI";
    private const string K_WC_AUTENTICAZIONEINIZIALE = "AUTENTICAZIONEINIZIALE";
    private const string K_WC_AUTOLOGINWINDOWS = "AUTOLOGINWINDOWS";
    private const string K_WC_ACTIVEVIRTUALLOGIN = "ACTIVEVIRTUALLOGIN";
    private const string K_WC_AUTOCREATEUSERWITHCONFIGURATIONPROFILE = "AUTOCREATEUSERWITHCONFIGURATIONPROFILE";
    private const string K_WC_AUTOLOGIN_URLONLOGOUT = "AUTOLOGIN_URLONLOGOUT";
    private const string K_WC_SHOWREGISTRATI = "SHOWREGISTRATI";
    private const string K_WC_SHOWUSECOOKIE = "SHOWUSECOOKIE";
    private const string K_WC_SHOWPWDSMARRITA = "SHOWPWDSMARRITA";
    private const string K_WC_URLHelpOnline = "URLHelpOnline";

    private const string K_WC_GOOGLEAUTH = "GOOGLEAUTH";
    private const string K_WC_GOOGLEAUTH_CLIENTID = "GOOGLEAUTH_CLIENTID";
    private const string K_WC_GOOGLEAUTH_CLIENTSECRET = "GOOGLEAUTH_CLIENTSECRET";

    private const string K_WC_APPLEAUTH = "APPLEAUTH";
    private const string K_WC_APPLEAUTH_CLIENTID = "APPLEAUTH_CLIENTID";
    private const string K_WC_APPLEAUTH_CLIENTSECRET = "APPLEAUTH_CLIENTSECRET";

    private const string K_WC_MICROSOFTAUTH = "MICROSOFTAUTH";
    private const string K_WC_MICROSOFTAUTH_CLIENTID = "MICROSOFTAUTH_CLIENTID";
    private const string K_WC_MICROSOFTAUTH_CLIENTSECRET = "MICROSOFTAUTH_CLIENTSECRET";
    private const string K_WC_MICROSOFTAUTH_TENANTID = "MICROSOFTAUTH_TENANTID";

    //COSTANTI APPLICATION SETTAGGI GRAFICI
    private const string K_WC_BTHEME = "B_THEME";
    private const string K_WC_USESIDEDBAR = "USE_SIDEBAR";

    // COSTANTI DI MANUTENZIONE
    private const string K_WC_OFFLINE = "OFFLINE";
    private const string K_WC_OFFLINE_MSG = "OFFLINE_MSG";
    private const string K_WC_INITDB = "INITDB";
    private const string K_WC_INITDB_BIFFolder = "INITDB_BIFFolder";

    // DEFINIZIONE COSTANTI PER CATEGORIE
    private const string K_CATEGORY_APPLICAZIONE = "Applicazione";
    private const string K_CATEGORY_AUTENTICAZIONE = "Autenticazione";
    private const string K_CATEGORY_CONFIGURAZIONE = "Configurazione";
    private const string K_CATEGORY_DBAPP = "Database App.";
    private const string K_CATEGORY_DBUSER = "Database User.";
    private const string K_CATEGORY_VIEWSTATE = "Viewstate";
    private const string K_CATEGORY_REPORTINGSERVICE = "Reportistica";
    private const string K_CATEGORY_FTP_FILESHARE = "FTP / FILESHARE";
    private const string K_CATEGORY_MAINTNANCE = "Manutenzione";
    private const string K_CATEGORY_LOG = "Log";
    private const string K_CATEGORY_MAIL = "Configurazione EMAIL";
    private const string K_CATEGORY_GRAFICA = "Grafica e Stili";
    private const string K_CATEGORY_LINK = "Help";

    // DEFINIZIONE PROPRIETA'     

    [Description("Stringa di Connessione")]
    [BCaption("Stringa di Connessione")]
    [Category(K_CATEGORY_CONFIGURAZIONE)]
    public static string CnnStr
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_CNNSTR] + "";
      }
    }

    [Description("Database")]
    [BCaption("Database")]
    [Category(K_CATEGORY_DBAPP)]
    [BOrder(0)]
    public static string DBApp_DB
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBAPP_DB] + "";
      }
    }

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_DBAPP)]
    [BOrder(1)]
    public static string DBApp_Server
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBAPP_SERVER] + "";
      }
    }

    [Description("Username")]
    [BCaption("Username")]
    [Category(K_CATEGORY_DBAPP)]
    [BOrder(2)]
    public static string DBApp_User
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBAPP_USER] + "";
      }
    }

    [Description("Password")]
    [BCaption("Password")]
    [Category(K_CATEGORY_DBAPP)]
    public static string DBApp_PWD
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBAPP_PWD] + "";
      }
    }


    [Description("Database")]
    [BCaption("Database")]
    [Category(K_CATEGORY_DBUSER)]
    [BOrder(0)]
    public static string DBUser_DB
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBUSER_DB] + "";
      }
    }

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_DBUSER)]
    [BOrder(1)]
    public static string DBUser_Server
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBUSER_SERVER] + "";
      }
    }

    [Description("Username")]
    [BCaption("Username")]
    [Category(K_CATEGORY_DBUSER)]
    [BOrder(2)]
    public static string DBUser_User
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBUSER_USER] + "";
      }
    }

    [Description("Password")]
    [BCaption("Password")]
    [Category(K_CATEGORY_DBUSER)]
    public static string DBUser_PWD
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_DBUSER_PWD] + "";
      }
    }

    // <!--CONFIGURAZIONE VIEWSTATE -->

    [Description("Viewstate su DB")]
    [BCaption("Viewstate su DB")]
    [Category(K_CATEGORY_VIEWSTATE)]
    [BOrder(0)]
    public static bool ViewStateOnDB
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_VIEWSTATE_ONDB] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    [Description("Database")]
    [BCaption("Database")]
    [Category(K_CATEGORY_VIEWSTATE)]
    [BOrder(1)]
    public static string Viewstate_DB
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_VIEWSTATE_DB] + "";
      }
    }

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_VIEWSTATE)]
    [BOrder(2)]
    public static string Viewstate_Server
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_VIEWSTATE_SERVER] + "";
      }
    }

    [Description("Username")]
    [BCaption("Username")]
    [Category(K_CATEGORY_VIEWSTATE)]
    [BOrder(3)]
    public static string Viewstate_User
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_VIEWSTATE_USER] + "";
      }
    }

    [Description("Password")]
    [BCaption("Password")]
    [Category(K_CATEGORY_VIEWSTATE)]
    public static string Viewstate_PWD
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_VIEWSTATE_PWD] + "";
      }
    }


    [Description("Timeout")]
    [BCaption("Timeout")]
    [Category(K_CATEGORY_VIEWSTATE)]
    public static int ViewStateTimeOut
    {
      get
      {
        return int.Parse(ConfigurationManager.AppSettings[K_WC_VIEWSTATE_TIMEOUT]);
      }
    }

    // <!--REPORTING SERVICES-->

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    [BOrder(0)]
    public static string ServerReport_Nome
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SERVERREPORT_NOME] + "";
      }
    }

    [Description("Dominio")]
    [BCaption("Dominio")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    [BOrder(1)]
    public static string ServerReport_Domain
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SERVERREPORT_DOMAIN] + "";
      }
    }

    [Description("Username")]
    [BCaption("Username")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    [BOrder(2)]
    public static string ServerReport_User
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SERVERREPORT_USER] + "";
      }
    }

    [Description("Password")]
    [BCaption("Password")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    public static string ServerReport_PWD
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SERVERREPORT_PWD] + "";
      }
    }

    [Description("Folder")]
    [BCaption("Folder")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    public static string ServerReport_FOLDER
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SERVERREPORT_FOLDER] + "";
      }
    }

    [Description("Version")]
    [BCaption("Version")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    public static BModReports.eReportVersion ServerReport_VERSION
    {
      get
      {
        return (BModReports.eReportVersion)((byte.Parse(ConfigurationManager.AppSettings[K_WC_SERVERREPORT_VERSION] + "")));
      }
    }

    [Description("SSL")]
    [BCaption("SSL")]
    [Category(K_CATEGORY_REPORTINGSERVICE)]
    [BOrder(0)]
    public static bool ServerReport_SSL
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SERVERREPORT_SSL] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    // <!--FTP / FILESHARE -->

    private const string K_WC_ServerFileShare_FTP = "SERVERFILESHARE_FTP";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static bool ServerFileShare_FTP
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_ServerFileShare_FTP] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    private const string K_WC_ServerFileShare_PathRelative = "SERVERFILESHARE_PATHRELATIVE";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static bool ServerFileShare_PathRelative
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_ServerFileShare_PathRelative] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    private const string K_WC_SERVERFILESHARE_AUTHREQUIRED = "SERVERFILESHARE_AUTHREQUIRED";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static bool ServerFileShare_AuthRequired
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SERVERFILESHARE_AUTHREQUIRED] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    private const string K_WC_ServerFileShare_Name = "SERVERFILESHARE_NAME";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static string ServerFileShare_Name
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_ServerFileShare_Name] + "";
      }
    }

    private const string K_WC_ServerFileShare_Domain = "ServerFileShare_Domain";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static string ServerFileShare_Domain
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_ServerFileShare_Domain] + "";
      }
    }

    private const string K_WC_ServerFileShare_User = "ServerFileShare_User";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static string ServerFileShare_User
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_ServerFileShare_User] + "";
      }
    }

    private const string K_WC_ServerFileShare_Pwd = "ServerFileShare_Pwd";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static string ServerFileShare_Pwd
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_ServerFileShare_Pwd] + "";
      }
    }

    private const string K_WC_ServerFileShare_Folder = "ServerFileShare_Folder";

    [Description("Server")]
    [BCaption("Server")]
    [Category(K_CATEGORY_FTP_FILESHARE)]
    [BOrder(0)]
    public static string ServerFileShare_Folder
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_ServerFileShare_Folder] + "";
      }
    }

    // <!-- SETTAGGI DI MANUTENZIONE-->

    [Description("Off Line")]
    [BCaption("Off Line")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static bool OffLine
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_OFFLINE] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Off Line Messaggio")]
    [BCaption("Off Line Messaggio")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static string OffLine_MSG
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_OFFLINE_MSG];
      }
    }


    private const string K_WC_MESSAGE_OLD_BROWSER = "MESSAGE_OLD_BROWSER";

    [Description("Old Browser Messaggio")]
    [BCaption("Old Browser Messaggio")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static string Message_Old_Browser
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_MESSAGE_OLD_BROWSER] + "";
      }
    }

    private const string K_WC_VERSION_OLD_BROWSER = "VERSION_OLD_BROWSER";

    [Description("Old Browser Version")]
    [BCaption("Old Browser Version")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static int Version_Old_Browser
    {
      get
      {
        return int.Parse(ConfigurationManager.AppSettings[K_WC_VERSION_OLD_BROWSER]);
      }
    }


    [Description("Auto Minified")]
    [BCaption("Auto Minified")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static bool AutoMinify
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_AUTOMINIFY] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("VS DEBUG EMULATOR")]
    [BCaption("VS DEBUG EMULATOR")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static bool VS_DEBUG
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_VS_DEBUG] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Inizializzazione Database")]
    [BCaption("Inizializzazione Database")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static bool InitDB
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_INITDB] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Cartella contenente i file BIF per importazione dei dati")]
    [BCaption("BIF Folder")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public static string InitDB_BIFFolder
    {
      get
      {
        return BConvert.ToString(ConfigurationManager.AppSettings[K_WC_INITDB_BIFFolder]);
      }
    }

    // <!-- SETTAGGI DI SISTEMA-->

    [Description("Web Site usa DB")]
    [BCaption("Web Site usa DB")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    [BOrder(0)]
    public static bool WebSiteUseDB
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WEBSITEUSEDB] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    [Description("Gestione Utenti")]
    [BCaption("Gestione Utenti")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool GestioneUtenti
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_GESTIONEUTENTI] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Autenticazione Iniziale")]
    [BCaption("Autenticazione Iniziale")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool AutenticazioneIniziale
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_AUTENTICAZIONEINIZIALE] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Tipo Autenticazione")]
    [BCaption("Tipo Autenticazione")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static BArts.BInterface.IBUtenteEntrato.eAuthType AuthType
    {
      get
      {
        var switchExpr = (ConfigurationManager.AppSettings[K_WC_AUTHTYPE] + "").ToUpper();
        switch (switchExpr)
        {
          case E_AUTHTYPE_WINDOWS:
            {
              return BArts.BInterface.IBUtenteEntrato.eAuthType.WINDOWS;
            }

          case E_AUTHTYPE_NONE:
            {
              return BArts.BInterface.IBUtenteEntrato.eAuthType.NONE;
            }

          default:
            {
              return BArts.BInterface.IBUtenteEntrato.eAuthType.NONE;
            }
        }
      }
    }

    [Description("Show NTAccount")]
    [BCaption("Show NTAccount")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool ShowNTAccount
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SHOWNTACCOUNT] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Show Link Registrazione")]
    [BCaption("Show Link Registrazione")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool ShowRegistrati
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SHOWREGISTRATI] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Show Informativa sui cookie")]
    [BCaption("Show Informativa sui cookie")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool ShowUseCookie
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SHOWUSECOOKIE] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    [Description("Show Link Password Smarrita")]
    [BCaption("Show Link Password Smarrita")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool ShowPwdSmarrita
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SHOWPWDSMARRITA] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    [Description("Auto Autenticazione")]
    [BCaption("Auto Autenticazione per tipo auth. windows")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool AutoLoginWindows
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_AUTOLOGINWINDOWS] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Creazione utenti virtuali")]
    [BCaption("Creazione utenti virtuali")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool ActiveVirtualLogin
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_ACTIVEVIRTUALLOGIN] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Auto Creazione utenza di dominio")]
    [BCaption("Auto Creazione utente per tipo auth. windows per applicazioni RUO")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool AutoCreateUserWithConfigurationProfile
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_AUTOCREATEUSERWITHCONFIGURATIONPROFILE] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("AutoLogin_URLOnLogOut")]
    [BCaption("AutoLogin_URLOnLogOut")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string AutoLogin_URLOnLogOut
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_AUTOLOGIN_URLONLOGOUT] + "";
      }
    }


    [Description("Consenti autenticazione con google")]
    [BCaption("Consenti autenticazione con google")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool GoogleAuth
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_GOOGLEAUTH] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    [Description("Google Client ID")]
    [BCaption("Google Client ID")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string GoogleAuth_ClientID
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_GOOGLEAUTH_CLIENTID] + "";
      }
    }
    [Description("Google Client Secret")]
    [BCaption("Google Client Secret")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string GoogleAuth_ClientSecret
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_GOOGLEAUTH_CLIENTSECRET] + "";
      }
    }


    [Description("Consenti autenticazione con Apple")]
    [BCaption("Consenti autenticazione con Apple")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool AppleAuth
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_APPLEAUTH] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    [Description("Apple Client ID")]
    [BCaption("Apple Client ID")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string AppleAuth_ClientID
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_APPLEAUTH_CLIENTID] + "";
      }
    }
    [Description("Apple Client Secret")]
    [BCaption("Apple Client Secret")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string AppleAuth_ClientSecret
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_APPLEAUTH_CLIENTSECRET] + "";
      }
    }


    [Description("Consenti autenticazione con Microsoft")]
    [BCaption("Consenti autenticazione con Microsoft")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static bool MicrosoftAuth
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_MICROSOFTAUTH] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
    [Description("Microsoft Client ID")]
    [BCaption("Microsoft Client ID")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string MicrosoftAuth_ClientID
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_MICROSOFTAUTH_CLIENTID] + "";
      }
    }
    [Description("Microsoft Client Secret")]
    [BCaption("Microsoft Client Secret")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string MicrosoftAuth_ClientSecret
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_MICROSOFTAUTH_CLIENTSECRET] + "";
      }
    }

    [Description("Microsoft TenantID")]
    [BCaption("Microsoft TenantID")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static string MicrosoftAuth_TenantID
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_MICROSOFTAUTH_TENANTID] + "";
      }
    }


    // <!--SETTAGGI APPLICATIVO-->

    [Description("Titolo Web Site")]
    [BCaption("Titolo Web Site")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static string TitoloWebSite
    {
      get
      {
        return new Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(Assembly.GetExecutingAssembly()).Title;
        //return My.MyWebExtension.Application.Info.Title;
      }
    }

    [Description("Descrizione Web Site")]
    [BCaption("Descrizione Web Site")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static string DescrizioneWebSite
    {
      get
      {
        return new Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(Assembly.GetExecutingAssembly()).Description;
        //return My.MyWebExtension.Application.Info.Description;
      }
    }

    [Description("Versione Web Site")]
    [BCaption("Versione Web Site")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static string VersioneWebSite
    {
      get
      {
        string[] ver = null;
        ver = new Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(Assembly.GetExecutingAssembly()).Version.ToString().Split('.');
        if (ver.Length != 4) return "";
        return ver[0] + "." + ver[1] + "." + ver[2];
      }
    }


    [Description("Copyright Web Site")]
    [BCaption("Copyright Web Site")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static string Copyright
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        //return My.MyWebExtension.Application.Info.Copyright;
      }
    }


    // <!--TRACCIATURA ANOMALIE -->

    [Description("Livello di Log")]
    [BCaption("Livello di Log")]
    [Category(K_CATEGORY_LOG)]
    public static int LevelLog
    {
      get
      {
        return int.Parse(ConfigurationManager.AppSettings[K_WC_LEVELLOG]);
      }
    }

    [Description("Traccia Errori nell'eventlog")]
    [BCaption("Traccia Errori nell'eventlog")]
    [Category(K_CATEGORY_LOG)]
    public static bool WriteErrorOnEventLog
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WRITEERRORONEVENTLOG] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Traccia Errori nel DB")]
    [BCaption("Traccia Errori nel DB")]
    [Category(K_CATEGORY_LOG)]
    public static bool WriteErrorOnDB
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WRITEERRORONDB] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Traccia Errori nel file system")]
    [BCaption("Traccia Errori nel file system")]
    [Category(K_CATEGORY_LOG)]
    public static bool WriteErrorOnFile
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Usa Percorso Relativo")]
    [BCaption("Usa Percorso Relativo")]
    [Category(K_CATEGORY_LOG)]
    public static bool WriteErrorOnFile_PathRel
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE_PATHREL] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Path tracciatura anomalie")]
    [BCaption("Path tracciatura anomalie")]
    [Category(K_CATEGORY_LOG)]
    public static string WriteErrorOnFile_Path
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE_PATH] + "";
      }
    }


    [Description("Scrivi solo nel file eventi")]
    [BCaption("Scrivi solo nel file eventi")]
    [Category(K_CATEGORY_LOG)]
    public static bool WriteErrorOnFile_WriteOnlyEvents
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE_WRITEONLYEVENTS] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("Nome file eventi")]
    [BCaption("Nome file eventi")]
    [Category(K_CATEGORY_LOG)]
    public static string WriteErrorOnFile_FileEvents
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE_FILEEVENTS] + "";
      }
    }

    [Description("Nome file errori")]
    [BCaption("Nome file errori")]
    [Category(K_CATEGORY_LOG)]
    public static string WriteErrorOnFile_FileErrors
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_WRITEERRORONFILE_FILEERRORS] + "";
      }
    }


    [Description("Invia email in caso di anomalie")]
    [BCaption("Invia email in caso di anomalie")]
    [Category(K_CATEGORY_LOG)]
    public static bool SendMailOnError
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SENDMAILONERROR] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    [Description("From")]
    [BCaption("From")]
    [Category(K_CATEGORY_LOG)]
    public static string SendMailOnErrorFrom
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAILONERRORFROM] + "";
      }
    }

    [Description("To")]
    [BCaption("To")]
    [Category(K_CATEGORY_LOG)]
    public static string SendMailOnErrorTo
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAILONERRORTO] + "";
      }
    }

    // <!--MAIL CONFIG -->

    [Description("Sender Type")]
    [BCaption("Sender Type")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(0)]
    public static BArts.BMail.BSenderMailConfig.eSenderType SendMail_SenderType
    {
      get
      {
        var switchExpr = (ConfigurationManager.AppSettings[K_WC_SENDMAIL_SENDERTYPE] + "").ToUpper();
        switch (switchExpr)
        {
          case "ECDOMICROSOFT":
            {
              return BArts.BMail.BSenderMailConfig.eSenderType.eCDOMicrosoft;
            }

          case "ESQLSERVER":
            {
              return BArts.BMail.BSenderMailConfig.eSenderType.eSQLSERVER;
            }

          default:
            {
              return BArts.BMail.BSenderMailConfig.eSenderType.eNETMail;
            }
        }
      }
    }


    [Description("SMTP Server")]
    [BCaption("SMTP Server")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(1)]
    public static string SendMail_SMTPServer
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_SMTPSERVER] + "";
      }
    }

    [Description("SMTP Port")]
    [BCaption("SMTP Port")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(2)]
    public static string SendMail_SMTPPort
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_SMTPPORT] + "";
      }
    }

    [Description("SMTP Username")]
    [BCaption("SMTP Username")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(3)]
    public static string SendMail_UserName
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_USERNAME] + "";
      }
    }

    [Description("SMTP Password")]
    [BCaption("SMTP Password")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(4)]
    public static string SendMail_Password
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_PASSWORD] + "";
      }
    }

    [Description("SMTP SSL")]
    [BCaption("SMTP SSL")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(5)]
    public static bool SendMail_SSL
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_SENDMAIL_SSL] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }


    [Description("Nome Profilo")]
    [BCaption("Nome Profilo")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(6)]
    public static string SendMail_NomeProfilo
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_NOMEPROFILO] + "";
      }
    }

    [Description("Nome Account")]
    [BCaption("Nome Account")]
    [Category(K_CATEGORY_MAIL)]
    [BOrder(7)]
    public static string SendMail_NomeAccount
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_SENDMAIL_NOMEACCOUNT] + "";
      }
    }

    [Description("LinkHelpPage")]
    [BCaption("LinkHelpPage")]
    [Category(K_CATEGORY_LINK)]
    [BOrder(0)]
    public static string URLHelpOnline
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_URLHelpOnline];
      }
    }

    // <!--SETTAGGI GRAFICI-->

    [Description("Nome BTema")]
    [BCaption("Nome BTema")]
    [Category(K_CATEGORY_GRAFICA)]
    public static string BTheme
    {
      get
      {
        return ConfigurationManager.AppSettings[K_WC_BTHEME] + "";
      }
    }

    [Description("Web Site usa Side Bar")]
    [BCaption("Web Site usa Side Bar")]
    [Category(K_CATEGORY_GRAFICA)]
    public static bool UseSideBar
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_USESIDEDBAR] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    private const string K_WC_DEFAULT_SIDEBAR_OPEN = "DEFAULT_SIDEBAR_OPEN";
    [Description("Di default la Side Bar è aperta?")]
    [BCaption("Di default la Side Bar è aperta?")]
    [Category(K_CATEGORY_GRAFICA)]
    public static bool DefaultSidebarOpen
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_DEFAULT_SIDEBAR_OPEN] + "").ToUpper() ?? "") == ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    #region public static eTipoApplicazione TipoApplicazione
    // COSTANTI GLOBALI PER IDENTIFICARE IL TIPO APPLICAZIONE
    private const string K_WC_TIPOAPPLICAZIONE = "TipoApplicazione";
    private const string E_TIPOAPPLICAZIONE_POSTERUO = "POSTERUO";
    private const string E_TIPOAPPLICAZIONE_WPCHILDAPP = "WPAPPCHILD";
    private const string E_TIPOAPPLICAZIONE_WPINTERNO = "WPINTERNA";
    public enum eTipoApplicazione : byte
    {
      PosteRUO,
      WPAppChild,
      WPInterna
    }

    [Description("Tipo Applicazione")]
    [BCaption("Tipo Applicazione")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public static eTipoApplicazione TipoApplicazione
    {
      get
      {
        switch ((ConfigurationManager.AppSettings[K_WC_TIPOAPPLICAZIONE] + "").ToUpper() ?? "")
        {
          case E_TIPOAPPLICAZIONE_POSTERUO:
            {
              return eTipoApplicazione.PosteRUO;
            }
          case E_TIPOAPPLICAZIONE_WPCHILDAPP:
            {
              return eTipoApplicazione.WPAppChild;
            }
          case E_TIPOAPPLICAZIONE_WPINTERNO:
            {
              return eTipoApplicazione.WPInterna;
            }
          default:
            return eTipoApplicazione.PosteRUO;
        }
      }
    }
    #endregion


    private const string K_WC_WPAPPCHILDDEBUG = "WPAPPCHILDDEBUG";
    [Description("WP App Child Debug")]
    [BCaption("WP App Child Debug")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public static bool WPAppChildDebug
    {
      get
      {
        if (((ConfigurationManager.AppSettings[K_WC_WPAPPCHILDDEBUG] + "").ToUpper() ?? "") == PosteWebTemplate1.ModConstantList.K_TRUE)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    // DEFINIZIONE METODI 

    public static string ViewState_ConncetionString()
    {
      string cnnstr = "";
      cnnstr = string.Format(CnnStr, Viewstate_Server, Viewstate_DB, Viewstate_User, BArts.BSecurity.BCrypter.Decrypt(Viewstate_PWD));
      return cnnstr;
    }

    public static string DBApp_ConncetionString()
    {
      string cnnstr = "";
      cnnstr = string.Format(CnnStr, DBApp_Server, DBApp_DB, DBApp_User, BArts.BSecurity.BCrypter.Decrypt(DBApp_PWD));
      return cnnstr;
    }

    public static string DBUser_ConncetionString()
    {
      string cnnstr = "";
      cnnstr = string.Format(CnnStr, DBUser_Server, DBUser_DB, DBUser_User, BArts.BSecurity.BCrypter.Decrypt(DBUser_PWD));
      return cnnstr;
    }

  }
}