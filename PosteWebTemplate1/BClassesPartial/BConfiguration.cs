using BArts.BData;

namespace PosteWebTemplate1
{
  public partial class BConfiguration : BArts.BInterface.IBConfiguration
  {
    private const int K_ID_ONERECORD = 1;

    // DEFINIZIONE COSTRUTTORI

    public BConfiguration(BConnection cnn) : base(BConfiguration.K_SP_SELECT, cnn, new System.Data.SqlClient.SqlParameter("@ID", K_ID_ONERECORD))
    {
    }

    // DEFINIZIONE PROPRIETA' PER GESTIONE LOG
    public int LevelLog { get; set; } = BWebConfig.LevelLog;
    public bool SendMailOnError { get; set; } = BWebConfig.SendMailOnError;
    public string SendMailOnErrorFrom { get; set; } = BWebConfig.SendMailOnErrorFrom;
    public string SendMailOnErrorTo { get; set; } = BWebConfig.SendMailOnErrorTo;
    public string SendMail_SMTPServer { get; set; } = BWebConfig.SendMail_SMTPServer;
    public string SendMail_SMTPPort { get; set; } = BWebConfig.SendMail_SMTPPort;
    public string SendMail_UserName { get; set; } = BWebConfig.SendMail_UserName;
    public string SendMail_Password { get; set; } = BWebConfig.SendMail_Password;
    public BArts.BMail.BSenderMailConfig.eSenderType SendMail_SenderType { get; set; } = BWebConfig.SendMail_SenderType;
    public string SendMail_NomeProfilo { get; set; } = BWebConfig.SendMail_NomeProfilo;
    public string SendMail_NomeAccount { get; set; } = BWebConfig.SendMail_NomeAccount;
    public bool WriteErrorOnDB { get; set; } = BWebConfig.WriteErrorOnDB;
    public bool WriteErrorOnEventLog { get; set; } = BWebConfig.WriteErrorOnEventLog;
    public bool WriteErrorOnFile { get; set; } = BWebConfig.WriteErrorOnFile;
    public bool WriteErrorOnFile_WriteOnlyEvents { get; set; } = BWebConfig.WriteErrorOnFile_WriteOnlyEvents;
    public string WriteErrorOnFile_FileErrors { get; set; } = BWebConfig.WriteErrorOnFile_FileErrors;
    public string WriteErrorOnFile_FileEvents { get; set; } = BWebConfig.WriteErrorOnFile_FileEvents;
    public string WriteErrorOnFile_Path { get; set; } = BWebConfig.WriteErrorOnFile_Path;
    public bool WriteErrorOnFile_PathRel { get; set; } = BWebConfig.WriteErrorOnFile_PathRel;


    //PROPRIETA GLOBALI


  }
}