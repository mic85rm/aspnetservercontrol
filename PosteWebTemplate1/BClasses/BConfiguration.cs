//************************************************
//*** Classe generata con BStudio [Ver. 3.4.7] ***
//************************************************

using BArts;
using BArts.BData;
using BArts.BGlobal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static BArts.BEnumerations;
using static PosteWebTemplate1.ModGenerale;

namespace PosteWebTemplate1
{
  public partial class BConfiguration : BArts.BBaseClass.BBaseObject
  {

    //DEFINIZIONE EVENTI
    public event WriteLogEventHandler WriteLog;
    public delegate void WriteLogEventHandler(string Source, string Metod, Exception Ex, BEnumerations.eSeverity Severity);

    //DEFINIZIONI COSTANTI
    private const string K_TBL = "Configuration";
    private const string K_SP_SELECT = "BSP_" + K_TBL + "_SELECT";
    private const string K_SP_INSERT = "BSP_" + K_TBL + "_INSERT";
    private const string K_SP_UPDATE = "BSP_" + K_TBL + "_UPDATE";
    private const string K_SP_DELETE = "BSP_" + K_TBL + "_DELETE";
    private const string K_SP_SEARCH = "BSP_" + K_TBL + "_SEARCH";


    //DEFINIZIONE COSTRUTTORI
    public BConfiguration() : base()
    {
    }
    public BConfiguration(DataRow dr, BConnection cnn) : base(dr, cnn)
    {
    }
    public BConfiguration(int ID, BConnection cnn) : base(K_SP_SELECT, cnn, new System.Data.SqlClient.SqlParameter("@ID", ID))
    {
    }

    //DEFINIZIONE PROPRIETA'
    public byte[] Logo { get; set; }
    public string MittenteMail { get; set; }
    public string DestinatarioMail { get; set; }
    public string LeggePrivacy { get; set; }
    public int IDSistemaRegistrazione { get; set; }
    public int IDProfiloRegistrazione { get; set; }
    public string EmailSegnalazioni { get; set; }
    public Nullable<DateTime> LastSyncNotifiche { get; set; }
    public int TimerSyncNotify { get; set; }
    public int IDProfiloNotificaRegistrazione { get; set; }
    public int IDAmbiente { get; set; }
    public int IDApplicazione { get; set; }



    //DEFINIZIONE METODI OVERRIEDS
    public override bool MappingData(DataRow dr)
    {
      this.ID = BConvert.ToInt(dr["ID"]);
      this.Descrizione = BConvert.ToString(dr["Descrizione"]);
      this.Logo = BConvert.ToBinary(dr["Logo"]);
      this.MittenteMail = BConvert.ToString(dr["MittenteMail"]);
      this.DestinatarioMail = BConvert.ToString(dr["DestinatarioMail"]);
      this.LeggePrivacy = BConvert.ToString(dr["LeggePrivacy"]);
      this.IDSistemaRegistrazione = BConvert.ToInt(dr["IDSistemaRegistrazione"]);
      this.IDProfiloRegistrazione = BConvert.ToInt(dr["IDProfiloRegistrazione"]);
      this.EmailSegnalazioni = BConvert.ToString(dr["EmailSegnalazioni"]);
      this.LastSyncNotifiche = BConvert.ToDate(dr["LastSyncNotifiche"]);
      this.TimerSyncNotify = BConvert.ToInt(dr["TimerSyncNotify"]);
      this.IDProfiloNotificaRegistrazione = BConvert.ToInt(dr["IDProfiloNotificaRegistrazione"]);
      this.IDAmbiente = BConvert.ToInt(dr["IDAmbiente"]);
      this.IDApplicazione = BConvert.ToInt(dr["IDApplicazione"]);
      return this.PartialMappingData(dr);
    }
    public override void ChangeConnection(BConnection CnnActual)
    {
      BConnection InternalCnn = null;
      if (CnnActual != null && CnnActual.Setting.NomeDatabase != ModGenerale.K_NOMEDATABASE)
      {
        BSettingDatabase BSet = new BSettingDatabase();
        BSet = CnnActual.Setting.Clone();
        BSet.NomeDatabase = ModGenerale.K_NOMEDATABASE;
        InternalCnn = new BConnection(BSet);
      }
      else
      {
        InternalCnn = CnnActual;
      }
      base.ChangeConnection(InternalCnn);
    }

    //DEFINIZIONE METODI 
    public bool Update(bool SaveCollections = true, bool ForceInsert = false, bool WithnewTransaction = true)
    {
      bool ret = false;
      try
      {
        if (WithnewTransaction)
        {
          this.Connection.ApriDatabase();
          this.Connection.BeginTrans();
        }
        this.Connection.ClearParameter();
        if (this.ID != -1)
          this.Connection.AddParameter("@ID", this.ID);
        else
          this.Connection.AddParameter("@ID", DBNull.Value);
        this.Connection.AddParameter("@Descrizione", BConvert.ToString(this.Descrizione));
        if (this.Logo != null) this.Connection.AddParameter("@Logo", this.Logo);
        this.Connection.AddParameter("@MittenteMail", BConvert.ToString(this.MittenteMail));
        this.Connection.AddParameter("@DestinatarioMail", BConvert.ToString(this.DestinatarioMail));
        this.Connection.AddParameter("@LeggePrivacy", BConvert.ToString(this.LeggePrivacy));
        if (this.IDSistemaRegistrazione != -1)
          this.Connection.AddParameter("@IDSistemaRegistrazione", this.IDSistemaRegistrazione);
        else
          this.Connection.AddParameter("@IDSistemaRegistrazione", DBNull.Value);
        if (this.IDProfiloRegistrazione != -1)
          this.Connection.AddParameter("@IDProfiloRegistrazione", this.IDProfiloRegistrazione);
        else
          this.Connection.AddParameter("@IDProfiloRegistrazione", DBNull.Value);
        this.Connection.AddParameter("@EmailSegnalazioni", BConvert.ToString(this.EmailSegnalazioni));
        if (this.LastSyncNotifiche.HasValue)
          this.Connection.AddParameter("@LastSyncNotifiche", this.LastSyncNotifiche.Value);
        else
          this.Connection.AddParameter("@LastSyncNotifiche", DBNull.Value);
        this.Connection.AddParameter("@TimerSyncNotify", this.TimerSyncNotify);
        if (this.IDProfiloNotificaRegistrazione != -1)
          this.Connection.AddParameter("@IDProfiloNotificaRegistrazione", this.IDProfiloNotificaRegistrazione);
        else
          this.Connection.AddParameter("@IDProfiloNotificaRegistrazione", DBNull.Value);
        if (this.IDAmbiente != -1)
          this.Connection.AddParameter("@IDAmbiente", this.IDAmbiente);
        else
          this.Connection.AddParameter("@IDAmbiente", DBNull.Value);
        if (this.IDApplicazione != -1)
          this.Connection.AddParameter("@IDApplicazione", this.IDApplicazione);
        else
          this.Connection.AddParameter("@IDApplicazione", DBNull.Value);
        this.PartialUpdate();
        if (this.IsNothing || ForceInsert)
        {
          if (this.Connection.ExecuteNonQuery(K_SP_INSERT, CommandType.StoredProcedure) > 0)
            ret = true;
          else
            ret = false;
        }
        else
        {
          if (this.Connection.ExecuteNonQuery(K_SP_UPDATE, CommandType.StoredProcedure) > 0)
            ret = true;
          else
            ret = false;
        }

        if (ret)
        {
          if (WithnewTransaction) this.Connection.CommitTrans();
          base.m_IsNothing = false;
          this.UpdatePlus();
        }
        else
        {
          if (WithnewTransaction) this.Connection.RollBackTrans();
        }
        return ret;
      }
      catch (Exception ex)
      {
        WriteLog?.Invoke("BCLASS", "BConfiguration.Update()", ex, eSeverity.ERROR);
        if (WithnewTransaction) this.Connection.RollBackTrans();
        throw ex;
      }
      finally
      {
        if (WithnewTransaction)
        {
          this.Connection.EndTrans();
          this.Connection.ChiudiDatabase();
        }
      }
    }
    public bool Delete(bool WithnewTransaction = false)
    {
      try
      {
        if (this.IsNothing) return false;
        if (WithnewTransaction)
        {
          this.Connection.ApriDatabase();
          this.Connection.BeginTrans();
        }
        this.Connection.ClearParameter();
        this.Connection.AddParameter("@ID", this.ID);
        if (this.Connection.ExecuteNonQuery(K_SP_DELETE, CommandType.StoredProcedure) > 0)
        {
          if (WithnewTransaction) this.Connection.CommitTrans();
          return true;
        }
        else
        {
          if (WithnewTransaction) this.Connection.RollBackTrans();
          return false;
        }
      }
      catch (Exception ex)
      {
        WriteLog?.Invoke("BCLASS", "BConfiguration.Delete()", ex, eSeverity.ERROR);
        throw ex;
      }
      finally
      {
        if (WithnewTransaction)
        {
          this.Connection.EndTrans();
          this.Connection.ChiudiDatabase();
        }
      }
    }


    //DEFINIZIONE METODI SHARED
    public static DataTable GetElenco(BConnection DB, params System.Data.SqlClient.SqlParameter[] Params)
    {
      DataTable dt = null;
      BConnection myCnn = null;
      BSettingDatabase BSet = null;
      try
      {
        BSet = DB.Setting.Clone();
        BSet.NomeDatabase = ModGenerale.K_NOMEDATABASE;
        myCnn = new BConnection(BSet);
        myCnn.ClearParameter();
        myCnn.AddParameter(Params);

        dt = myCnn.ApriDT(K_SP_SEARCH, CommandType.StoredProcedure);
        return dt;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dt != null)
        {
          dt.Dispose();
          dt = null;
        }
      }
    }
  } //END CLASS
} //END NAMESPACE