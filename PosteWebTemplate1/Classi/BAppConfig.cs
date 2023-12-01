using BArts.BAttributes;
using BArts.BBaseClass;
using BArts.BGlobal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PosteWebTemplate1.Classi
{
  public class BAppConfig : BBaseSetting
  {
    public BAppConfig(string Filename, Assembly ass) : base(Filename, ass)
    {
    }

    //DEFINIZIONE COSTRUTTORE STATICO
    public static BAppConfig NewConfig(Page p)
    {
      string folder = p.Server.MapPath("/");
      string path = BGlobal.CreatePathFile(folder, "AppSettings.Config");

      BAppConfig set = new BAppConfig(path, Assembly.GetExecutingAssembly());
      BBaseSetting Obj = set; //solo con c# si deve fare sta merdata
      return (BAppConfig)BBaseSetting.Initzialize(ref Obj);
    }


    //DEFINIZIONE DATI

    public enum eTipoApplicazione : byte
    {
      WPAPPCHILD,
      POSTERUO,
      WPINTERNA
    }
    public enum eAuthType : byte
    {
      NONE,
      WINDOWS
    }



    //DEFINIZIONE COSTANTI PER CATEGORIE
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



    //DEFINIZIONE PROPRIETA
    [BFieldSetting(true)]
    [Description("Password di Cifratura")]
    [BCaption("Password di Cifratura")]
    [Category(K_CATEGORY_CONFIGURAZIONE)]
    public string PwdCrypter { get; set; } = "";

    [BFieldSetting(true)]
    [Description("Password di Cifratura")]
    [BCaption("Password di Cifratura")]
    [Category(K_CATEGORY_CONFIGURAZIONE)]
    public string CnnStr { get; set; } = "";

    [BFieldSetting(true)]
    [Description("Auto Minificazione")]
    [BCaption("Auto Minificazione")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public bool AutoMinify { get; set; } = false;


    [BFieldSetting(true)]
    [Description("Tipo Applicazione")]
    [BCaption("Tipo Applicazione")]
    [Category(K_CATEGORY_APPLICAZIONE)]
    public eTipoApplicazione TipoApplicazione { get; set; } = eTipoApplicazione.POSTERUO;


    [BFieldSetting(true)]
    [Description("WPAppChild Debug")]
    [BCaption("WPAppChild Debug")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public bool WPAppChildDebug { get; set; } = false;

    [BFieldSetting(true)]
    [Description("WebPers Url")]
    [BCaption("WebPers Url")]
    [Category(K_CATEGORY_LINK)]
    public string WebPersUrl { get; set; } = "";

    [BFieldSetting(true)]
    [Description("Gestione Utenti")]
    [BCaption("Gestione Utenti")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool GestioneUtenti { get; set; } = true;

    [BFieldSetting(true)]
    [Description("Autenticazione Iniziale")]
    [BCaption("Autenticazione Iniziale")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool AutenticazioneIniziale { get; set; } = true;

    [BFieldSetting(true)]
    [Description("ShowNTAccount")]
    [BCaption("ShowNTAccount")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool ShowNTAccount { get; set; } = false;

    [BFieldSetting(true)]
    [Description("AuthType")]
    [BCaption("AuthType")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public eAuthType AuthType { get; set; } = eAuthType.WINDOWS;

    [BFieldSetting(true)]
    [Description("AutoLoginWindows")]
    [BCaption("AutoLoginWindows")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool AutoLoginWindows { get; set; } = true;

    [BFieldSetting(true)]
    [Description("ActiveVirtualLogin")]
    [BCaption("ActiveVirtualLogin")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool ActiveVirtualLogin { get; set; } = false;

    [BFieldSetting(true)]
    [Description("AutoCreateUserWithConfigurationProfile")]
    [BCaption("AutoCreateUserWithConfigurationProfile")]
    [Category(K_CATEGORY_AUTENTICAZIONE)]
    public bool AutoCreateUserWithConfigurationProfile { get; set; } = false;

    [BFieldSetting(true)]
    [Description("AutoLogin_URLOnLogOut")]
    [BCaption("AutoLogin_URLOnLogOut")]
    [Category(K_CATEGORY_LINK)]
    public string AutoLogin_URLOnLogOut { get; set; } = "";

    [BFieldSetting(true)]
    [Description("URLHelpOnline")]
    [BCaption("URLHelpOnline")]
    [Category(K_CATEGORY_LINK)]
    public string URLHelpOnline { get; set; } = "~/Help.aspx";

    [BFieldSetting(true)]
    [Description("WEBSITEUSEDB")]
    [BCaption("WEBSITEUSEDB")]
    [Category(K_CATEGORY_CONFIGURAZIONE)]
    public bool WEBSITEUSEDB { get; set; } = true;

    [BFieldSetting(true)]
    [Description("DBAPP_DB")]
    [BCaption("DBAPP_DB")]
    [Category(K_CATEGORY_DBAPP)]
    public string DBAPP_DB { get; set; } = "PosteWebTemplate1";

    [BFieldSetting(true)]
    [Description("DBAPP_SERVER")]
    [BCaption("DBAPP_SERVER")]
    [Category(K_CATEGORY_DBAPP)]
    public string DBAPP_SERVER { get; set; } = "SWPERDB02C.rete.testposte\\IST01, 56871";

    [BFieldSetting(true)]
    [Description("DBAPP_USER")]
    [BCaption("DBAPP_USER")]
    [Category(K_CATEGORY_DBAPP)]
    public string DBAPP_USER { get; set; } = "dcru";

    [BFieldSetting(true)]
    [Description("DBAPP_USER")]
    [BCaption("DBAPP_USER")]
    [Category(K_CATEGORY_DBAPP)]
    public string DBAPP_PWD { get; set; } = "GAZo8MicFlhiu5rX7iUdjw==";

    [BFieldSetting(true)]
    [Description("DBUSER_DB")]
    [BCaption("DBUSER_DB")]
    [Category(K_CATEGORY_DBUSER)]
    public string DBUSER_DB { get; set; } = "WebPers";

    [BFieldSetting(true)]
    [Description("DBUSER_SERVER")]
    [BCaption("DBUSER_SERVER")]
    [Category(K_CATEGORY_DBUSER)]
    public string DBUSER_SERVER { get; set; } = "SWPERDB02C.rete.testposte\\IST01, 56871";

    [BFieldSetting(true)]
    [Description("DBUSER_USER")]
    [BCaption("DBUSER_USER")]
    [Category(K_CATEGORY_DBUSER)]
    public string DBUSER_USER { get; set; } = "dcru";

    [BFieldSetting(true)]
    [Description("DBUSER_USER")]
    [BCaption("DBUSER_USER")]
    [Category(K_CATEGORY_DBUSER)]
    public string DBUSER_PWD { get; set; } = "GAZo8MicFlhiu5rX7iUdjw==";

    [BFieldSetting(true)]
    [Description("VIEWSTATE_ONDB")]
    [BCaption("VIEWSTATE_ONDB")]
    [Category(K_CATEGORY_MAINTNANCE)]
    public bool VIEWSTATE_ONDB { get; set; } = false;

    [BFieldSetting(true)]
    [Description("VIEWSTATE_DB")]
    [BCaption("VIEWSTATE_DB")]
    [Category(K_CATEGORY_DBUSER)]
    public string VIEWSTATE_DB { get; set; } = "";

    [BFieldSetting(true)]
    [Description("VIEWSTATE_SERVER")]
    [BCaption("VIEWSTATE_SERVER")]
    [Category(K_CATEGORY_DBUSER)]
    public string VIEWSTATE_SERVER { get; set; } = "";

    [BFieldSetting(true)]
    [Description("VIEWSTATE_USER")]
    [BCaption("VIEWSTATE_USER")]
    [Category(K_CATEGORY_DBUSER)]
    public string VIEWSTATE_USER { get; set; } = "";

    [BFieldSetting(true)]
    [Description("VIEWSTATE_USER")]
    [BCaption("VIEWSTATE_USER")]
    [Category(K_CATEGORY_DBUSER)]
    public string VIEWSTATE_PWD { get; set; } = "";

    [BFieldSetting(true)]
    [Description("VIEWSTATE_TIMEOUT")]
    [BCaption("VIEWSTATE_TIMEOUT")]
    [Category(K_CATEGORY_DBUSER)]
    public int VIEWSTATE_TIMEOUT { get; set; } = 90;

    /*
    <add key = "GoogleAuth" value="FALSE"/>
    <add key = "GoogleAuth_ClientID" value="202716487687-ve2djhnp7vin67tn0585k3r4qhhqhiqv.apps.googleusercontent.com"/>
    <add key = "GoogleAuth_ClientSecret" value="jEM_83wkHs6EXgU-dPW3Y3bY"/>
    <add key = "AppleAuth" value="false"/>
    <add key = "AppleAuth_ClientID" value="202716487687-ve2djhnp7vin67tn0585k3r4qhhqhiqv.apps.googleusercontent.com"/>
    <add key = "AppleAuth_ClientSecret" value="jEM_83wkHs6EXgU-dPW3Y3bY"/>
    <add key = "MicrosoftAuth" value="FALSE"/>
    <add key = "MicrosoftAuth_ClientID" value="11316add-f336-4d69-85f0-6a95439524cf"/>
    <add key = "MicrosoftAuth_ClientSecret" value="iIIuh~9f24Cs_29v6mQWUO.aa3cX7Lh_N9"/>
    <add key = "MicrosoftAuth_TenantID" value="b20d0a99-667f-4c66-849b-36535bb8f3a9"/>
    */
    /*
    <!--IMPOSTAZIONE DI CONNESSIONE DB VIEWSTATE-->
    <!--REPORTING SERVICES-->
    <add key = "SERVERREPORT_NAME" value=""/>
    <add key = "SERVERREPORT_DOMAIN" value=""/>
    <add key = "SERVERREPORT_USER" value=""/>
    <add key = "SERVERREPORT_PWD" value=""/>
    <add key = "SERVERREPORT_FOLDER" value="Reports"/>
    <add key = "SERVERREPORT_VERSION" value="4"/>
    <!--SERVER VERSION
    [REPORTING SERVICE 2000] = 0
    [REPORTING SERVICE 2008] = 1
    [REPORTING SERVICE 2012] = 2
    [REPORTING SERVICE 2012 INTEGRATO IN SHARE POINT] = 3
    [REPORT VIEWER] = 4-- >
    < add key="SERVERREPORT_SSL" value="TRUE"/>
    <!--SERVER FTP / FILESHARE-->
    <add key = "SERVERFILESHARE_FTP" value="FALSE"/>
    <add key = "SERVERFILESHARE_PATHRELATIVE" value="TRUE"/>
    <add key = "SERVERFILESHARE_AUTHREQUIRED" value="FALSE"/>
    <add key = "SERVERFILESHARE_NAME" value=""/>
    <add key = "SERVERFILESHARE_DOMAIN" value=""/>
    <add key = "SERVERFILESHARE_USER" value=""/>
    <add key = "SERVERFILESHARE_PWD" value=""/>
    <add key = "SERVERFILESHARE_FOLDER" value="public"/>
    <!--LOG -->
    <add key = "LEVELLOG" value="0"/>
    <add key = "WRITEERRORONEVENTLOG" value="FALSE"/>
    <add key = "WRITEERRORONDB" value="TRUE"/>
    <add key = "WRITEERRORONFILE" value="TRUE"/>
    <add key = "WRITEERRORONFILE_PATHREL" value="TRUE"/>
    <add key = "WRITEERRORONFILE_PATH" value="public/log"/>
    <add key = "WRITEERRORONFILE_WRITEONLYEVENTS" value="FALSE"/>
    <add key = "WRITEERRORONFILE_FILEEVENTS" value="BTEMPLATE_EVENTS.LOG"/>
    <add key = "WRITEERRORONFILE_FILEERRORS" value="BTEMPLATE_ERRORS.LOG"/>
    <add key = "SENDMAILONERROR" value="TRUE"/>
    <add key = "SENDMAILONERRORFrom" value="m.balsamo@posteitaliane.it"/>
    <add key = "SENDMAILONERRORTo" value="m.balsamo@posteitaliane.it"/>
    <!--SEND MAIL-->
    <add key = "SENDMAIL_SenderType" value="eSQLSERVER"/>
    <!--eCDOMicrosoft eSQLSERVER    eNETMail-->
    <add key = "SENDMAIL_SMTPServer" value=""/>
    <add key = "SENDMAIL_SMTPPort" value="25"/>
    <add key = "SENDMAIL_UserName" value=""/>
    <add key = "SENDMAIL_Password" value=""/>
    <add key = "SENDMAIL_SSL" value="FALSE"/>
    <add key = "SENDMAIL_NomeProfilo" value="BArtsFramework"/>
    <add key = "SENDMAIL_NomeAccount" value="BArtsSoftware"/>
    <!--SETTAGGI GRAFICI-->
    <add key = "B_THEME" value="tmPt"/>
    <add key = "USE_SIDEBAR" value="TRUE"/>
    <add key = "DEFAULT_SIDEBAR_OPEN" value="FALSE"/>
    <!-- SETTAGGI DI MANUTENZIONE-->
    <add key = "OFFLINE" value="FALSE"/>
    <add key = "OFFLINE_MSG" value="Sito in aggiornamento... a breve saremo di nuovo in linea."/>
    <add key = "INITDB" value="FALSE"/>
    <add key = "INITDB_BIFFolder" value="BIF"/>
    <add key = "MESSAGE_OLD_BROWSER" value="Per l’utilizzo della procedura è richiesto il browser Internet Explorer (versione 9 o superiore) o Chrome.  Per richiedere l’aggiornamento del browser Internet Explorer è necessario rivolgersi al Polo Tecnologico o al numero verde 800 000 006."/>
    <add key = "VERSION_OLD_BROWSER" value="8"/>
    <!-- SETTAGGI DI AUTENTICAZIONE-->
    <add key = "SHOWREGISTRATI" value="false"/>
    <add key = "SHOWUSECOOKIE" value="false"/>
    <add key = "SHOWPWDSMARRITA" value="false"/>
    <!--SETTAGGI CLASS LIBRARY LOCALE-->
    <add key = "DB_LIBRARY" value="PosteWebTemplate1"/>
    <add key = "DB_LIBRARY_WP" value="WebPers"/>
    <add key = "DB_LIBRARY_BIPOSTE" value="BIPoste"/>
    <!-- ARUBA-->
    <!--<add key = "DB_LIBRARY" value="MSSql172809" />-->
    <!--**************************************************CHIUSURA APPSETTINGS DI SISTEMA**********************************************-->
    <!-- AGGIUNGERE DI SEGUITO EVENTUALI CHIAVI DEDICATE ALL'APPLICAZIONE CHE SI STA SVILUPPANDO.-->
    <!-- PER OGNI CHIAVE AGGIUNTA IMPLEMENTARE LA PROPRIETA' NELLA CLASSE BWEBCONFIG PRESENTE NELLA CARTELLA CLASSI-->
    <!--<add key = "CHIAVE_DEDICATA" value="VALORE_CHIAVEDEDICATA" />-->
    <!--<add key = "CHIAVE_DEDICATA_BOOL" value="TRUE" />-->
    <add key = "LinkExternalApp" value="https://pwepws07v.rete.poste/"/>
    <add key = "LinkExternalApp_Internet" value="https://webperscoll.posteitaliane.it/"/>







    */


    //DEFINIZIONE METODI OVERRIDE
    public override void MappingDataDefault()
    {
      this.DBAPP_DB = "BQuestMaster";
      this.DBAPP_SERVER = "BSTATION";
      this.DBAPP_USER = "sa";
      this.DBAPP_PWD = "cGB1fSNdeFJUC9W1SeimMVYql7Dqt2NIQKpgpsLN8H4=";
    }

    public override object ToObjType(JObject Obj)
    {
      return Obj.ToObject(typeof(BAppConfig));
    }
  }
}