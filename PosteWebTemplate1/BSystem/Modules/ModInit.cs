using BArts;
using BArts.BData;
using System;

namespace PosteWebTemplate1
{
  public static class ModInit
  {

    // DATABASE
    public static ModEnumeration.eTipoDB TipoDB = mbcTipoDB;

    // OGGETTI GLOBALI DI SETTING
    public static BSettingDatabase SetDB;
    public static BSettingDatabase SetDBUser;

    public const ModEnumeration.eVersione mbcVersione = ModEnumeration.eVersione.bRelease;
    public const ModEnumeration.eTipoDB mbcTipoDB = ModEnumeration.eTipoDB.bMSSQL;
    public static DateTime mbcScadenza = new DateTime(2021, 12, 31);

    public const string mbcStrConnectMSAccess97 = "Provider=Microsoft.jet.OLEDB.4.0;" + "Persist Security Info=False;Data source={0}{1};User ID={2};jet OLEDB:Database password={3}";
    public const string mbcStrConnectMSAccess = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Persist Security Info=False;Data source={0}{1};User ID={2};jet OLEDB:Database password={3}";
    public static string mbcStrConnectMSSQL = BWebConfig.CnnStr;

    public const string mbcNomeFileLic = "SupportKey.FxK";

    // FUNZIONI DI INIZIALIZZAZIONE
    public static void InitVersion(ref BSettingDatabase objSetting, ModEnumeration.eTipoDB TipoDB)
    {
      switch (TipoDB)
      {
        case ModEnumeration.eTipoDB.bMSAccess:
          {
            objSetting = new BSettingDatabase("MSAccess", BEnumerations.eDataProvider.OLEDB_PROVIDER);
            {
              var withBlock = objSetting;
              withBlock.C_S = "'";
              withBlock.C_D = "#";
              withBlock.C_Like = "%";
              withBlock.F_Data = "MM/dd/yyyy";
              withBlock.F_Ora = "HH:mm:ss";
              withBlock.m_C_TrueBool = "TRUE";
              withBlock.m_C_FalseBool = "FALSE";
              withBlock.ConnectionString = mbcStrConnectMSAccess97;
            }
            break;
          }
        case ModEnumeration.eTipoDB.bMSSQL:
          {
            objSetting = new BSettingDatabase("MSSQL", BEnumerations.eDataProvider.SQL_OLEDB_PROVIDER);
            {
              var withBlock1 = objSetting;
              withBlock1.C_S = "'";
              withBlock1.C_D = "'";
              withBlock1.C_Like = "%";
              withBlock1.F_Data = "MM/dd/yyyy";
              withBlock1.F_Ora = "HH:mm:ss";
              withBlock1.m_C_TrueBool = "1";
              withBlock1.m_C_FalseBool = "0";
              withBlock1.ConnectionString = mbcStrConnectMSSQL;
            }
            break;
          }
        case ModEnumeration.eTipoDB.bMSAccess2007:
          {
            objSetting = new BSettingDatabase("MSAccess", BEnumerations.eDataProvider.OLEDB_PROVIDER);
            objSetting.C_S = "'";
            objSetting.C_D = "#";
            objSetting.C_Like = "%";
            objSetting.F_Data = "MM/dd/yyyy";
            objSetting.F_Ora = "HH:mm:ss";
            objSetting.m_C_TrueBool = "TRUE";
            objSetting.m_C_FalseBool = "FALSE";
            objSetting.ConnectionString = mbcStrConnectMSAccess;
            break;
          }
      }
    }
    public static void SetConnectionString(BSettingDatabase objSetting, string NomeDB, string Server, string User, string Pwd)
    {
      if (objSetting != null)
      {
        objSetting.NomeDatabase = NomeDB;
        objSetting.NomeServer = Server;
        objSetting.Utente = User;
        objSetting.Password = BArts.BSecurity.BCrypter.Decrypt(Pwd);
        objSetting.SetConnectionString();
      }
      else
      {
        throw new Exception("Function InitVersion Failed!!");
      }
    }

  } //END CLASS
} //END NAMESPACE