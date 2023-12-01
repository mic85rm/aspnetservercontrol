//************************************************
//*** Classe generata con BStudio [Ver. 3.5.4] ***
//************************************************

using BArts.BAggiornaDB;
using BArts.BData;
using BArts.BLog;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static BArts.BEnumerations;
using static BArts.BGlobal.BGlobal;
using static BArts.BGlobal.BVisualBasic;

namespace PosteWebTemplate1
{
  public static class ModAggiornaDB_BWebAppTemplate
  {
    //DEFINIZIONE METODI PUBLICI
    #region public static bool CreateDatabase(BConnection dbMaster, string Path, string DBName, BLog.BLogText bLog)
    public static bool CreateDatabase(BConnection dbMaster, string Path, string DBName, BLogText bLog)
    {
      BConnection cnnBStudio = null;
      try
      {
        if (BAggiornaDB.CreateDatabase(dbMaster, Path, DBName, bLog))
        {
          //CHANGE DB AND CONFIGURATION NEW DB
          BSettingDatabase dbset = dbMaster.Setting.Clone();

          dbset.NomeDatabase = DBName;
          cnnBStudio = new BConnection(dbset);
          cnnBStudio.ApriDatabase();

          if (!AggiornaDB(cnnBStudio, bLog))
          {
            bLog?.AppendLog("Aggiornamento Database fallito.");
            cnnBStudio.ChiudiDatabase();
            return false;
          }
          else
          {
            bLog?.AppendLog("Aggiornamento Database completato.");
            cnnBStudio.ChiudiDatabase();
            return true;
          }
        }
        return false;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** " + ex.Message);
        if (cnnBStudio != null)
        {
          cnnBStudio.ChiudiDatabase();
          cnnBStudio = null;
        }
        return false;
      }
    }
    #endregion
    #region public static bool AggiornaDB(BConnection DB, BLogText bLog)
    public static bool AggiornaDB(BConnection DB, BLogText bLog)
    {
      try
      {
        DB.EndTrans();
        DB.BeginTrans();
        //GESTIONE TABELLE

        if (!CreaTabella_Configuration(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<Configuration>>");


        if (!CreaTabella_sysAccessi(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysAccessi>>");


        if (!CreaTabella_sysAccessiOperazioni(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysAccessiOperazioni>>");


        if (!CreaTabella_sysComuni(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysComuni>>");


        if (!CreaTabella_sysComuniQuartieri(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysComuniQuartieri>>");


        if (!CreaTabella_sysFunzioni(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysFunzioni>>");


        if (!CreaTabella_sysImportFiles(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysImportFiles>>");


        if (!CreaTabella_sysLog(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysLog>>");


        if (!CreaTabella_sysModuli(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysModuli>>");


        if (!CreaTabella_sysNotifiche(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysNotifiche>>");


        if (!CreaTabella_sysPassePartout(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysPassePartout>>");


        if (!CreaTabella_sysPersone(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysPersone>>");


        if (!CreaTabella_sysPolicyPwd(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysPolicyPwd>>");


        if (!CreaTabella_sysProfili(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysProfili>>");


        if (!CreaTabella_sysProfiliFunzioni(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysProfiliFunzioni>>");


        if (!CreaTabella_sysProvince(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysProvince>>");


        if (!CreaTabella_sysPwdUtilizzate(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysPwdUtilizzate>>");


        if (!CreaTabella_sysRegioni(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysRegioni>>");


        if (!CreaTabella_sysRegistrazioniRichieste(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysRegistrazioniRichieste>>");


        if (!CreaTabella_sysRuoli(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysRuoli>>");


        if (!CreaTabella_sysSeverity(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysSeverity>>");


        if (!CreaTabella_sysSistemi(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysSistemi>>");


        if (!CreaTabella_sysSistemiAttributi(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysSistemiAttributi>>");


        if (!CreaTabella_sysStati(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysStati>>");


        if (!CreaTabella_sysUtenti(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysUtenti>>");


        if (!CreaTabella_sysUtentiNotifiche(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysUtentiNotifiche>>");


        if (!CreaTabella_sysUtentiProfili(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysUtentiProfili>>");


        if (!CreaTabella_sysViewState(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysViewState>>");


        if (!CreaTabella_sysVisibilita(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysVisibilita>>");


        if (!CreaTabella_sysWiki(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysWiki>>");


        if (!CreaTabella_sysWikiAllegati(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysWikiAllegati>>");


        if (!CreaTabella_sysWikiLinks(DB, bLog))
          throw new System.Exception("Errore in fase di creazione della tabella <<sysWikiLinks>>");


        //GESTIONE VISTE

        if (!BAggiornaDB.CreaVista(DB, "CREATE VIEW BV_Comuni      " + vbNewLine() + "AS      " + vbNewLine() + "      " + vbNewLine() + "	select      " + vbNewLine() + "		r.ID IDRegione      " + vbNewLine() + "		, r.Descrizione DescrizioneRegione      " + vbNewLine() + "		, p.ID IDProvincia      " + vbNewLine() + "		, p.Descrizione DescrizioneProvincia      " + vbNewLine() + "		, c.ID IDComune      " + vbNewLine() + "		, c.Descrizione DescrizioneComune      " + vbNewLine() + "		, c.CAP      " + vbNewLine() + "		, c.Patrono      " + vbNewLine() + "		, c.DataIstituzione      " + vbNewLine() + "		, c.DataCessazione      " + vbNewLine() + "	from sysComuni c      " + vbNewLine() + "		inner join sysProvince p      " + vbNewLine() + "			on c.IDProvincia = p.ID      " + vbNewLine() + "		inner join sysRegioni r      " + vbNewLine() + "			on r.ID = p.IDRegione      " + vbNewLine() + "/*	order by      " + vbNewLine() + "		DescrizioneRegione      " + vbNewLine() + "		,	DescrizioneProvincia      " + vbNewLine() + "		, DescrizioneComune      " + vbNewLine() + "*/     " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<CREATE VIEW BV_Comuni      " + vbNewLine() + "AS      " + vbNewLine() + "      " + vbNewLine() + "	select      " + vbNewLine() + "		r.ID IDRegione      " + vbNewLine() + "		, r.Descrizione DescrizioneRegione      " + vbNewLine() + "		, p.ID IDProvincia      " + vbNewLine() + "		, p.Descrizione DescrizioneProvincia      " + vbNewLine() + "		, c.ID IDComune      " + vbNewLine() + "		, c.Descrizione DescrizioneComune      " + vbNewLine() + "		, c.CAP      " + vbNewLine() + "		, c.Patrono      " + vbNewLine() + "		, c.DataIstituzione      " + vbNewLine() + "		, c.DataCessazione      " + vbNewLine() + "	from sysComuni c      " + vbNewLine() + "		inner join sysProvince p      " + vbNewLine() + "			on c.IDProvincia = p.ID      " + vbNewLine() + "		inner join sysRegioni r      " + vbNewLine() + "			on r.ID = p.IDRegione      " + vbNewLine() + "/*	order by      " + vbNewLine() + "		DescrizioneRegione      " + vbNewLine() + "		,	DescrizioneProvincia      " + vbNewLine() + "		, DescrizioneComune      " + vbNewLine() + "*/     " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaVista(DB, "   " + vbNewLine() + "CREATE VIEW [dbo].[BV_sysNotificheAll]      " + vbNewLine() + "AS      " + vbNewLine() + "	SELECT       " + vbNewLine() + "		N.ID IDSysNotifica      " + vbNewLine() + "		, u.id IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	from sysNotifiche n WITH(NOLOCK)      " + vbNewLine() + "		INNER JOIN sysUtenti u WITH(NOLOCK)      " + vbNewLine() + "			ON n.IDSysUtente = u.ID      " + vbNewLine() + "	WHERE       " + vbNewLine() + "		LimitaVisibilita = 1      " + vbNewLine() + "      " + vbNewLine() + "	UNION      " + vbNewLine() + "      " + vbNewLine() + "	SELECT distinct       " + vbNewLine() + "		n.id 			      " + vbNewLine() + "		, up.IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	FROM sysNotifiche N with(nolock)       " + vbNewLine() + "		LEFT JOIN sysUtentiProfili up WITH(NOLOCK)       " + vbNewLine() + "			ON up.IDSysSistema = n.idsyssistema      " + vbNewLine() + "					AND (up.IDSysProfilo = n.IDSysProfilo or ISNULL(n.IDSysProfilo, -1) = -1)		      " + vbNewLine() + "		INNER JOIN sysUtenti u WITH(NOLOCK)       " + vbNewLine() + "			on u.id = UP.IDSysUtente            " + vbNewLine() + "	where               " + vbNewLine() + "		isnull(Developer,0) = 0              " + vbNewLine() + "		AND LimitaVisibilita = 1      " + vbNewLine() + "      " + vbNewLine() + "	UNION      " + vbNewLine() + "      " + vbNewLine() + "	SELECT       " + vbNewLine() + "		n.id 			      " + vbNewLine() + "		, u.ID IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	FROM sysNotifiche N WITH(NOLOCK)      " + vbNewLine() + "		CROSS JOIN sysUtenti u WITH(NOLOCK)      " + vbNewLine() + "	WHERE       " + vbNewLine() + "		N.LimitaVisibilita = 0      " + vbNewLine() + "			     " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<   " + vbNewLine() + "CREATE VIEW [dbo].[BV_sysNotificheAll]      " + vbNewLine() + "AS      " + vbNewLine() + "	SELECT       " + vbNewLine() + "		N.ID IDSysNotifica      " + vbNewLine() + "		, u.id IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	from sysNotifiche n WITH(NOLOCK)      " + vbNewLine() + "		INNER JOIN sysUtenti u WITH(NOLOCK)      " + vbNewLine() + "			ON n.IDSysUtente = u.ID      " + vbNewLine() + "	WHERE       " + vbNewLine() + "		LimitaVisibilita = 1      " + vbNewLine() + "      " + vbNewLine() + "	UNION      " + vbNewLine() + "      " + vbNewLine() + "	SELECT distinct       " + vbNewLine() + "		n.id 			      " + vbNewLine() + "		, up.IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	FROM sysNotifiche N with(nolock)       " + vbNewLine() + "		LEFT JOIN sysUtentiProfili up WITH(NOLOCK)       " + vbNewLine() + "			ON up.IDSysSistema = n.idsyssistema      " + vbNewLine() + "					AND (up.IDSysProfilo = n.IDSysProfilo or ISNULL(n.IDSysProfilo, -1) = -1)		      " + vbNewLine() + "		INNER JOIN sysUtenti u WITH(NOLOCK)       " + vbNewLine() + "			on u.id = UP.IDSysUtente            " + vbNewLine() + "	where               " + vbNewLine() + "		isnull(Developer,0) = 0              " + vbNewLine() + "		AND LimitaVisibilita = 1      " + vbNewLine() + "      " + vbNewLine() + "	UNION      " + vbNewLine() + "      " + vbNewLine() + "	SELECT       " + vbNewLine() + "		n.id 			      " + vbNewLine() + "		, u.ID IDSysUtente      " + vbNewLine() + "		, N.DataNotifica      " + vbNewLine() + "		--, n.LimitaVisibilita      " + vbNewLine() + "		--, n.IDSysSistema      " + vbNewLine() + "		--, n.IDSysProfilo      " + vbNewLine() + "		--, n.IDSysUtente      " + vbNewLine() + "	FROM sysNotifiche N WITH(NOLOCK)      " + vbNewLine() + "		CROSS JOIN sysUtenti u WITH(NOLOCK)      " + vbNewLine() + "	WHERE       " + vbNewLine() + "		N.LimitaVisibilita = 0      " + vbNewLine() + "			     " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaVista(DB, "        " + vbNewLine() + "        " + vbNewLine() + "CREATE VIEW [dbo].[vSysPersone]	        " + vbNewLine() + "AS        " + vbNewLine() + "        " + vbNewLine() + "	SELECT         " + vbNewLine() + "		ID         " + vbNewLine() + "		, REPLACE(Cognome + ' ' + Nome + ' (' + UPPER(CodiceFiscale) + ')','()','') Descrizione        " + vbNewLine() + "		, Cognome + ' ' + Nome + ' (' + CONVERT (VARCHAR, DataNascita, 103) + ')' DescrizioneDataNascita         " + vbNewLine() + "	FROM sysPersone        " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<        " + vbNewLine() + "        " + vbNewLine() + "CREATE VIEW [dbo].[vSysPersone]	        " + vbNewLine() + "AS        " + vbNewLine() + "        " + vbNewLine() + "	SELECT         " + vbNewLine() + "		ID         " + vbNewLine() + "		, REPLACE(Cognome + ' ' + Nome + ' (' + UPPER(CodiceFiscale) + ')','()','') Descrizione        " + vbNewLine() + "		, Cognome + ' ' + Nome + ' (' + CONVERT (VARCHAR, DataNascita, 103) + ')' DescrizioneDataNascita         " + vbNewLine() + "	FROM sysPersone        " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaVista(DB, "CREATE view vw_DebugApplicazioni " + vbNewLine() + "AS " + vbNewLine() + "	 " + vbNewLine() + " select  distinct " + vbNewLine() + "	a.ID IDApplicazione " + vbNewLine() + "	, CAST(a.ID AS VARCHAR) + '|' + CAST(jr.IDJobRole AS VARCHAR) ID " + vbNewLine() + "	, a.Descrizione + ' JR(' + j.Descrizione + ')' Descrizione " + vbNewLine() + "	, s.ID IDSysUtente " + vbNewLine() + "	, uv.IDVisibilitaTerritoriale " + vbNewLine() + " from  webpers..Applicazioni A " + vbNewLine() + "	left join webpers..JobRolesProfili jr on jr.IDApplicazione = A.ID " + vbNewLine() + "	inner join WebPers..JobRoles j on jr.IDJobRole = j.ID " + vbNewLine() + "	inner join webpers..UtentiVisibilitaJobRoles UJ on UJ.IDJobRole = jr.IDJobRole " + vbNewLine() + "	inner join webpers..UtentiVisibilita UV on UV.IDSysUtente = UJ.IDSysUtente	 " + vbNewLine() + "		and UV.IDVisibilitaTerritoriale = UJ.IDVisibilitaTerritoriale " + vbNewLine() + "	inner join webpers..sysUtenti S on S.ID = UV.IDSysUtente " + vbNewLine() + "  where  " + vbNewLine() + "	a.IDTipoApplicazione IN (2,3) " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<CREATE view vw_DebugApplicazioni " + vbNewLine() + "AS " + vbNewLine() + "	 " + vbNewLine() + " select  distinct " + vbNewLine() + "	a.ID IDApplicazione " + vbNewLine() + "	, CAST(a.ID AS VARCHAR) + '|' + CAST(jr.IDJobRole AS VARCHAR) ID " + vbNewLine() + "	, a.Descrizione + ' JR(' + j.Descrizione + ')' Descrizione " + vbNewLine() + "	, s.ID IDSysUtente " + vbNewLine() + "	, uv.IDVisibilitaTerritoriale " + vbNewLine() + " from  webpers..Applicazioni A " + vbNewLine() + "	left join webpers..JobRolesProfili jr on jr.IDApplicazione = A.ID " + vbNewLine() + "	inner join WebPers..JobRoles j on jr.IDJobRole = j.ID " + vbNewLine() + "	inner join webpers..UtentiVisibilitaJobRoles UJ on UJ.IDJobRole = jr.IDJobRole " + vbNewLine() + "	inner join webpers..UtentiVisibilita UV on UV.IDSysUtente = UJ.IDSysUtente	 " + vbNewLine() + "		and UV.IDVisibilitaTerritoriale = UJ.IDVisibilitaTerritoriale " + vbNewLine() + "	inner join webpers..sysUtenti S on S.ID = UV.IDSysUtente " + vbNewLine() + "  where  " + vbNewLine() + "	a.IDTipoApplicazione IN (2,3) " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaVista(DB, "create view vw_DebugUtenti " + vbNewLine() + "AS " + vbNewLine() + "	select u.ID, p.Cognome + ' ' + p.Nome  Descrizione " + vbNewLine() + "	from WebPers..sysUtenti u " + vbNewLine() + "		inner join BIPoste..Personale p on u.IDPersona = p.ID " + vbNewLine() + "	where Developer = 0 " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<create view vw_DebugUtenti " + vbNewLine() + "AS " + vbNewLine() + "	select u.ID, p.Cognome + ' ' + p.Nome  Descrizione " + vbNewLine() + "	from WebPers..sysUtenti u " + vbNewLine() + "		inner join BIPoste..Personale p on u.IDPersona = p.ID " + vbNewLine() + "	where Developer = 0 " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaVista(DB, "create view vw_DebugVisibilita " + vbNewLine() + "AS " + vbNewLine() + "	select uv.IDSysUtente, IDVisibilitaTerritoriale, v.Descrizione  " + vbNewLine() + "	from WebPers..UtentiVisibilita uv " + vbNewLine() + "		inner join BIPoste..VisibilitaTerritoriali v on uv.IDVisibilitaTerritoriale = v.ID" + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione vista fallita: <<create view vw_DebugVisibilita " + vbNewLine() + "AS " + vbNewLine() + "	select uv.IDSysUtente, IDVisibilitaTerritoriale, v.Descrizione  " + vbNewLine() + "	from WebPers..UtentiVisibilita uv " + vbNewLine() + "		inner join BIPoste..VisibilitaTerritoriali v on uv.IDVisibilitaTerritoriale = v.ID" + vbNewLine() + ">>");

        //GESTIONE STORED PROCEDURE
        if (!BAggiornaDB.CreaStoredProcedure(DB, " " + vbNewLine() + "create PROCEDURE [dbo].[BSP_CambiaPreferito] " + vbNewLine() + "	 " + vbNewLine() + "	@IDSysUtente as varchar(50), " + vbNewLine() + "	@IDVisibilita as int " + vbNewLine() + " " + vbNewLine() + "AS " + vbNewLine() + "BEGIN " + vbNewLine() + "	 " + vbNewLine() + "	update webpers..UtentiVisibilita set Preferito = 0 where IDSysUtente = @IDSysUtente and Preferito = 1 " + vbNewLine() + "	 " + vbNewLine() + "	update webpers..UtentiVisibilita set Preferito = 1 where IDSysUtente = @IDSysUtente and IDVisibilitaTerritoriale = @IDVisibilita " + vbNewLine() + "	 " + vbNewLine() + "END" + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: << " + vbNewLine() + "create PROCEDURE [dbo].[BSP_CambiaPreferito] " + vbNewLine() + "	 " + vbNewLine() + "	@IDSysUtente as varchar(50), " + vbNewLine() + "	@IDVisibilita as int " + vbNewLine() + " " + vbNewLine() + "AS " + vbNewLine() + "BEGIN " + vbNewLine() + "	 " + vbNewLine() + "	update webpers..UtentiVisibilita set Preferito = 0 where IDSysUtente = @IDSysUtente and Preferito = 1 " + vbNewLine() + "	 " + vbNewLine() + "	update webpers..UtentiVisibilita set Preferito = 1 where IDSysUtente = @IDSysUtente and IDVisibilitaTerritoriale = @IDVisibilita " + vbNewLine() + "	 " + vbNewLine() + "END" + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE Procedure [dbo].[BSP_ChildAppToken_INSERT] " + vbNewLine() + "@IdUtente varchar(100), " + vbNewLine() + "@IdApplicazione int, " + vbNewLine() + "@IDpersona int, " + vbNewLine() + "@IdWhere varchar(max), " + vbNewLine() + "@IdJobRole int " + vbNewLine() + " " + vbNewLine() + "as " + vbNewLine() + "--pulisco la tabella dei token vecchi di 90 giorni " + vbNewLine() + "delete  from [ChildAppToken] where datainserimento <  dateadd(dd, -90, getdate()) " + vbNewLine() + " " + vbNewLine() + "declare @id as int = (select isnull(MIN(ID),0) FROM [ChildAppToken]) " + vbNewLine() + "Delete from [ChildAppToken] where Id = @id-1 " + vbNewLine() + " " + vbNewLine() + "INSERT INTO [dbo].[ChildAppToken] " + vbNewLine() + "           ([Id] " + vbNewLine() + "		   ,[IdUtente] " + vbNewLine() + "           ,[IdApplicazione] " + vbNewLine() + "           ,[IDPersona] " + vbNewLine() + "           ,[IdWhere] " + vbNewLine() + "		   ,[IDJobRole] " + vbNewLine() + "		   ,[DataInserimento]) " + vbNewLine() + "     VALUES " + vbNewLine() + "           (@id -1, " + vbNewLine() + "		    @IdUtente, " + vbNewLine() + "            @IdApplicazione, " + vbNewLine() + "            @IDPersona, " + vbNewLine() + "            @IdWhere, " + vbNewLine() + "			@IdJobRole, " + vbNewLine() + "			GETDATE()) " + vbNewLine() + "			 " + vbNewLine() + "	Select @id-1 " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE Procedure [dbo].[BSP_ChildAppToken_INSERT] " + vbNewLine() + "@IdUtente varchar(100), " + vbNewLine() + "@IdApplicazione int, " + vbNewLine() + "@IDpersona int, " + vbNewLine() + "@IdWhere varchar(max), " + vbNewLine() + "@IdJobRole int " + vbNewLine() + " " + vbNewLine() + "as " + vbNewLine() + "--pulisco la tabella dei token vecchi di 90 giorni " + vbNewLine() + "delete  from [ChildAppToken] where datainserimento <  dateadd(dd, -90, getdate()) " + vbNewLine() + " " + vbNewLine() + "declare @id as int = (select isnull(MIN(ID),0) FROM [ChildAppToken]) " + vbNewLine() + "Delete from [ChildAppToken] where Id = @id-1 " + vbNewLine() + " " + vbNewLine() + "INSERT INTO [dbo].[ChildAppToken] " + vbNewLine() + "           ([Id] " + vbNewLine() + "		   ,[IdUtente] " + vbNewLine() + "           ,[IdApplicazione] " + vbNewLine() + "           ,[IDPersona] " + vbNewLine() + "           ,[IdWhere] " + vbNewLine() + "		   ,[IDJobRole] " + vbNewLine() + "		   ,[DataInserimento]) " + vbNewLine() + "     VALUES " + vbNewLine() + "           (@id -1, " + vbNewLine() + "		    @IdUtente, " + vbNewLine() + "            @IdApplicazione, " + vbNewLine() + "            @IDPersona, " + vbNewLine() + "            @IdWhere, " + vbNewLine() + "			@IdJobRole, " + vbNewLine() + "			GETDATE()) " + vbNewLine() + "			 " + vbNewLine() + "	Select @id-1 " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "create Procedure [dbo].[BSP_ChildAppToken_INSERT_App_Interna] " + vbNewLine() + "@IdUtente varchar(100), " + vbNewLine() + "@IdApplicazione int, " + vbNewLine() + "@IDpersona int, " + vbNewLine() + "@IdWhere varchar(max), " + vbNewLine() + "@IdJobRole int, " + vbNewLine() + "@idprofilo int " + vbNewLine() + " " + vbNewLine() + "as " + vbNewLine() + "begin " + vbNewLine() + "--pulisco la tabella dei token vecchi di 90 giorni " + vbNewLine() + "delete  from [ChildAppToken] where datainserimento <  dateadd(dd, -90, getdate()) " + vbNewLine() + " " + vbNewLine() + "declare @id as int = (select isnull(MAX(ID),0) FROM [ChildAppToken]) " + vbNewLine() + " " + vbNewLine() + "INSERT INTO [dbo].[ChildAppToken] " + vbNewLine() + "           ([Id] " + vbNewLine() + "		   ,[IdUtente] " + vbNewLine() + "           ,[IdApplicazione] " + vbNewLine() + "           ,[IDPersona] " + vbNewLine() + "           ,[IdWhere] " + vbNewLine() + "		   ,[IDJobRole] " + vbNewLine() + "		   ,[IDProfilo] " + vbNewLine() + "		   ,[DataInserimento]) " + vbNewLine() + "     VALUES " + vbNewLine() + "           (@id+1, " + vbNewLine() + "		    @IdUtente, " + vbNewLine() + "            @IdApplicazione, " + vbNewLine() + "            @IDPersona, " + vbNewLine() + "            @IdWhere, " + vbNewLine() + "			@IdJobRole, " + vbNewLine() + "			@idprofilo, " + vbNewLine() + "			GETDATE()) " + vbNewLine() + "			 " + vbNewLine() + "	Select @id+1	 " + vbNewLine() + "end" + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<create Procedure [dbo].[BSP_ChildAppToken_INSERT_App_Interna] " + vbNewLine() + "@IdUtente varchar(100), " + vbNewLine() + "@IdApplicazione int, " + vbNewLine() + "@IDpersona int, " + vbNewLine() + "@IdWhere varchar(max), " + vbNewLine() + "@IdJobRole int, " + vbNewLine() + "@idprofilo int " + vbNewLine() + " " + vbNewLine() + "as " + vbNewLine() + "begin " + vbNewLine() + "--pulisco la tabella dei token vecchi di 90 giorni " + vbNewLine() + "delete  from [ChildAppToken] where datainserimento <  dateadd(dd, -90, getdate()) " + vbNewLine() + " " + vbNewLine() + "declare @id as int = (select isnull(MAX(ID),0) FROM [ChildAppToken]) " + vbNewLine() + " " + vbNewLine() + "INSERT INTO [dbo].[ChildAppToken] " + vbNewLine() + "           ([Id] " + vbNewLine() + "		   ,[IdUtente] " + vbNewLine() + "           ,[IdApplicazione] " + vbNewLine() + "           ,[IDPersona] " + vbNewLine() + "           ,[IdWhere] " + vbNewLine() + "		   ,[IDJobRole] " + vbNewLine() + "		   ,[IDProfilo] " + vbNewLine() + "		   ,[DataInserimento]) " + vbNewLine() + "     VALUES " + vbNewLine() + "           (@id+1, " + vbNewLine() + "		    @IdUtente, " + vbNewLine() + "            @IdApplicazione, " + vbNewLine() + "            @IDPersona, " + vbNewLine() + "            @IdWhere, " + vbNewLine() + "			@IdJobRole, " + vbNewLine() + "			@idprofilo, " + vbNewLine() + "			GETDATE()) " + vbNewLine() + "			 " + vbNewLine() + "	Select @id+1	 " + vbNewLine() + "end" + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_Configuration_DELETE  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  DELETE FROM Configuration " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_Configuration_DELETE  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  DELETE FROM Configuration " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_Configuration_INSERT  " + vbNewLine() + "  @ID AS int " + vbNewLine() + "  ,@Descrizione AS nvarchar(250) " + vbNewLine() + "  ,@Logo AS varbinary(MAX) = NULL  " + vbNewLine() + "  ,@MittenteMail AS nvarchar(200) " + vbNewLine() + "  ,@DestinatarioMail AS nvarchar(200) " + vbNewLine() + "  ,@LeggePrivacy AS nvarchar(MAX) " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int " + vbNewLine() + "  ,@EmailSegnalazioni AS nvarchar(200) " + vbNewLine() + "  ,@LastSyncNotifiche AS datetime " + vbNewLine() + "  ,@TimerSyncNotify AS int " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int " + vbNewLine() + "  ,@IDAmbiente AS int " + vbNewLine() + "  ,@IDApplicazione AS int " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  INSERT INTO Configuration (  " + vbNewLine() + "    ID " + vbNewLine() + "    ,Descrizione " + vbNewLine() + "    ,Logo " + vbNewLine() + "    ,MittenteMail " + vbNewLine() + "    ,DestinatarioMail " + vbNewLine() + "    ,LeggePrivacy " + vbNewLine() + "    ,IDSistemaRegistrazione " + vbNewLine() + "    ,IDProfiloRegistrazione " + vbNewLine() + "    ,EmailSegnalazioni " + vbNewLine() + "    ,LastSyncNotifiche " + vbNewLine() + "    ,TimerSyncNotify " + vbNewLine() + "    ,IDProfiloNotificaRegistrazione " + vbNewLine() + "    ,IDAmbiente " + vbNewLine() + "    ,IDApplicazione " + vbNewLine() + "  ) VALUES ( " + vbNewLine() + "    @ID " + vbNewLine() + "    ,@Descrizione " + vbNewLine() + "    ,@Logo " + vbNewLine() + "    ,@MittenteMail " + vbNewLine() + "    ,@DestinatarioMail " + vbNewLine() + "    ,@LeggePrivacy " + vbNewLine() + "    ,@IDSistemaRegistrazione " + vbNewLine() + "    ,@IDProfiloRegistrazione " + vbNewLine() + "    ,@EmailSegnalazioni " + vbNewLine() + "    ,@LastSyncNotifiche " + vbNewLine() + "    ,@TimerSyncNotify " + vbNewLine() + "    ,@IDProfiloNotificaRegistrazione " + vbNewLine() + "    ,@IDAmbiente " + vbNewLine() + "    ,@IDApplicazione " + vbNewLine() + "  )  " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_Configuration_INSERT  " + vbNewLine() + "  @ID AS int " + vbNewLine() + "  ,@Descrizione AS nvarchar(250) " + vbNewLine() + "  ,@Logo AS varbinary(MAX) = NULL  " + vbNewLine() + "  ,@MittenteMail AS nvarchar(200) " + vbNewLine() + "  ,@DestinatarioMail AS nvarchar(200) " + vbNewLine() + "  ,@LeggePrivacy AS nvarchar(MAX) " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int " + vbNewLine() + "  ,@EmailSegnalazioni AS nvarchar(200) " + vbNewLine() + "  ,@LastSyncNotifiche AS datetime " + vbNewLine() + "  ,@TimerSyncNotify AS int " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int " + vbNewLine() + "  ,@IDAmbiente AS int " + vbNewLine() + "  ,@IDApplicazione AS int " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  INSERT INTO Configuration (  " + vbNewLine() + "    ID " + vbNewLine() + "    ,Descrizione " + vbNewLine() + "    ,Logo " + vbNewLine() + "    ,MittenteMail " + vbNewLine() + "    ,DestinatarioMail " + vbNewLine() + "    ,LeggePrivacy " + vbNewLine() + "    ,IDSistemaRegistrazione " + vbNewLine() + "    ,IDProfiloRegistrazione " + vbNewLine() + "    ,EmailSegnalazioni " + vbNewLine() + "    ,LastSyncNotifiche " + vbNewLine() + "    ,TimerSyncNotify " + vbNewLine() + "    ,IDProfiloNotificaRegistrazione " + vbNewLine() + "    ,IDAmbiente " + vbNewLine() + "    ,IDApplicazione " + vbNewLine() + "  ) VALUES ( " + vbNewLine() + "    @ID " + vbNewLine() + "    ,@Descrizione " + vbNewLine() + "    ,@Logo " + vbNewLine() + "    ,@MittenteMail " + vbNewLine() + "    ,@DestinatarioMail " + vbNewLine() + "    ,@LeggePrivacy " + vbNewLine() + "    ,@IDSistemaRegistrazione " + vbNewLine() + "    ,@IDProfiloRegistrazione " + vbNewLine() + "    ,@EmailSegnalazioni " + vbNewLine() + "    ,@LastSyncNotifiche " + vbNewLine() + "    ,@TimerSyncNotify " + vbNewLine() + "    ,@IDProfiloNotificaRegistrazione " + vbNewLine() + "    ,@IDAmbiente " + vbNewLine() + "    ,@IDApplicazione " + vbNewLine() + "  )  " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_Configuration_SEARCH  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL  " + vbNewLine() + "  ,@MittenteMail AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@DestinatarioMail AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@LeggePrivacy AS NVARCHAR(MAX) = NULL  " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int = NULL  " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int = NULL  " + vbNewLine() + "  ,@EmailSegnalazioni AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@LastSyncNotificheDal AS datetime = NULL  " + vbNewLine() + "  ,@LastSyncNotificheAl AS datetime = NULL  " + vbNewLine() + "  ,@TimerSyncNotify AS int = NULL  " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int = NULL  " + vbNewLine() + "  ,@IDAmbiente AS int = NULL  " + vbNewLine() + "  ,@IDApplicazione AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE " + vbNewLine() + "  SELECT Me.*  " + vbNewLine() + "  FROM Configuration Me WITH(NOLOCK)  " + vbNewLine() + "  WHERE  " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)  " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')  " + vbNewLine() + "    AND  (@MittenteMail IS NULL OR Me.MittenteMail LIKE @MittenteMail + '%')  " + vbNewLine() + "    AND  (@DestinatarioMail IS NULL OR Me.DestinatarioMail LIKE @DestinatarioMail + '%')  " + vbNewLine() + "    AND  (@LeggePrivacy IS NULL OR Me.LeggePrivacy LIKE @LeggePrivacy + '%')  " + vbNewLine() + "    AND  (@IDSistemaRegistrazione IS NULL OR Me.IDSistemaRegistrazione = @IDSistemaRegistrazione)  " + vbNewLine() + "    AND  (@IDProfiloRegistrazione IS NULL OR Me.IDProfiloRegistrazione = @IDProfiloRegistrazione)  " + vbNewLine() + "    AND  (@EmailSegnalazioni IS NULL OR Me.EmailSegnalazioni LIKE @EmailSegnalazioni + '%')  " + vbNewLine() + "    AND  (@LastSyncNotificheDal IS NULL OR Me.LastSyncNotifiche >= @LastSyncNotificheDal)  " + vbNewLine() + "    AND  (@LastSyncNotificheAl IS NULL OR Me.LastSyncNotifiche <= @LastSyncNotificheAl)  " + vbNewLine() + "    AND  (@TimerSyncNotify IS NULL OR Me.TimerSyncNotify = @TimerSyncNotify)  " + vbNewLine() + "    AND  (@IDProfiloNotificaRegistrazione IS NULL OR Me.IDProfiloNotificaRegistrazione = @IDProfiloNotificaRegistrazione)  " + vbNewLine() + "    AND  (@IDAmbiente IS NULL OR Me.IDAmbiente = @IDAmbiente)  " + vbNewLine() + "    AND  (@IDApplicazione IS NULL OR Me.IDApplicazione = @IDApplicazione)  " + vbNewLine() + " " + vbNewLine() + "OPTION(RECOMPILE)  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_Configuration_SEARCH  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL  " + vbNewLine() + "  ,@MittenteMail AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@DestinatarioMail AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@LeggePrivacy AS NVARCHAR(MAX) = NULL  " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int = NULL  " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int = NULL  " + vbNewLine() + "  ,@EmailSegnalazioni AS NVARCHAR(200) = NULL  " + vbNewLine() + "  ,@LastSyncNotificheDal AS datetime = NULL  " + vbNewLine() + "  ,@LastSyncNotificheAl AS datetime = NULL  " + vbNewLine() + "  ,@TimerSyncNotify AS int = NULL  " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int = NULL  " + vbNewLine() + "  ,@IDAmbiente AS int = NULL  " + vbNewLine() + "  ,@IDApplicazione AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE " + vbNewLine() + "  SELECT Me.*  " + vbNewLine() + "  FROM Configuration Me WITH(NOLOCK)  " + vbNewLine() + "  WHERE  " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)  " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')  " + vbNewLine() + "    AND  (@MittenteMail IS NULL OR Me.MittenteMail LIKE @MittenteMail + '%')  " + vbNewLine() + "    AND  (@DestinatarioMail IS NULL OR Me.DestinatarioMail LIKE @DestinatarioMail + '%')  " + vbNewLine() + "    AND  (@LeggePrivacy IS NULL OR Me.LeggePrivacy LIKE @LeggePrivacy + '%')  " + vbNewLine() + "    AND  (@IDSistemaRegistrazione IS NULL OR Me.IDSistemaRegistrazione = @IDSistemaRegistrazione)  " + vbNewLine() + "    AND  (@IDProfiloRegistrazione IS NULL OR Me.IDProfiloRegistrazione = @IDProfiloRegistrazione)  " + vbNewLine() + "    AND  (@EmailSegnalazioni IS NULL OR Me.EmailSegnalazioni LIKE @EmailSegnalazioni + '%')  " + vbNewLine() + "    AND  (@LastSyncNotificheDal IS NULL OR Me.LastSyncNotifiche >= @LastSyncNotificheDal)  " + vbNewLine() + "    AND  (@LastSyncNotificheAl IS NULL OR Me.LastSyncNotifiche <= @LastSyncNotificheAl)  " + vbNewLine() + "    AND  (@TimerSyncNotify IS NULL OR Me.TimerSyncNotify = @TimerSyncNotify)  " + vbNewLine() + "    AND  (@IDProfiloNotificaRegistrazione IS NULL OR Me.IDProfiloNotificaRegistrazione = @IDProfiloNotificaRegistrazione)  " + vbNewLine() + "    AND  (@IDAmbiente IS NULL OR Me.IDAmbiente = @IDAmbiente)  " + vbNewLine() + "    AND  (@IDApplicazione IS NULL OR Me.IDApplicazione = @IDApplicazione)  " + vbNewLine() + " " + vbNewLine() + "OPTION(RECOMPILE)  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_Configuration_SELECT  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  SELECT  " + vbNewLine() + "    [ID] " + vbNewLine() + "    , [Descrizione] " + vbNewLine() + "    , [Logo] " + vbNewLine() + "    , [MittenteMail] " + vbNewLine() + "    , [DestinatarioMail] " + vbNewLine() + "    , [LeggePrivacy] " + vbNewLine() + "    , [IDSistemaRegistrazione] " + vbNewLine() + "    , [IDProfiloRegistrazione] " + vbNewLine() + "    , [EmailSegnalazioni] " + vbNewLine() + "    , [LastSyncNotifiche] " + vbNewLine() + "    , [TimerSyncNotify] " + vbNewLine() + "    , [IDProfiloNotificaRegistrazione] " + vbNewLine() + "    , [IDAmbiente] " + vbNewLine() + "    , [IDApplicazione] " + vbNewLine() + "  FROM Configuration WITH(NOLOCK)  " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_Configuration_SELECT  " + vbNewLine() + "  @ID AS int = NULL  " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  SELECT  " + vbNewLine() + "    [ID] " + vbNewLine() + "    , [Descrizione] " + vbNewLine() + "    , [Logo] " + vbNewLine() + "    , [MittenteMail] " + vbNewLine() + "    , [DestinatarioMail] " + vbNewLine() + "    , [LeggePrivacy] " + vbNewLine() + "    , [IDSistemaRegistrazione] " + vbNewLine() + "    , [IDProfiloRegistrazione] " + vbNewLine() + "    , [EmailSegnalazioni] " + vbNewLine() + "    , [LastSyncNotifiche] " + vbNewLine() + "    , [TimerSyncNotify] " + vbNewLine() + "    , [IDProfiloNotificaRegistrazione] " + vbNewLine() + "    , [IDAmbiente] " + vbNewLine() + "    , [IDApplicazione] " + vbNewLine() + "  FROM Configuration WITH(NOLOCK)  " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_Configuration_UPDATE  " + vbNewLine() + "  @ID AS int = NULL " + vbNewLine() + "  ,@Descrizione AS nvarchar(250) " + vbNewLine() + "  ,@Logo AS varbinary(MAX) = NULL " + vbNewLine() + "  ,@MittenteMail AS nvarchar(200) " + vbNewLine() + "  ,@DestinatarioMail AS nvarchar(200) " + vbNewLine() + "  ,@LeggePrivacy AS nvarchar(MAX) " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int " + vbNewLine() + "  ,@EmailSegnalazioni AS nvarchar(200) " + vbNewLine() + "  ,@LastSyncNotifiche AS datetime " + vbNewLine() + "  ,@TimerSyncNotify AS int " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int " + vbNewLine() + "  ,@IDAmbiente AS int " + vbNewLine() + "  ,@IDApplicazione AS int " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  UPDATE Configuration " + vbNewLine() + "    SET  " + vbNewLine() + "      Descrizione =  @Descrizione " + vbNewLine() + "      , Logo =  @Logo " + vbNewLine() + "      , MittenteMail =  @MittenteMail " + vbNewLine() + "      , DestinatarioMail =  @DestinatarioMail " + vbNewLine() + "      , LeggePrivacy =  @LeggePrivacy " + vbNewLine() + "      , IDSistemaRegistrazione =  @IDSistemaRegistrazione " + vbNewLine() + "      , IDProfiloRegistrazione =  @IDProfiloRegistrazione " + vbNewLine() + "      , EmailSegnalazioni =  @EmailSegnalazioni " + vbNewLine() + "      , LastSyncNotifiche =  @LastSyncNotifiche " + vbNewLine() + "      , TimerSyncNotify =  @TimerSyncNotify " + vbNewLine() + "      , IDProfiloNotificaRegistrazione =  @IDProfiloNotificaRegistrazione " + vbNewLine() + "      , IDAmbiente =  @IDAmbiente " + vbNewLine() + "      , IDApplicazione =  @IDApplicazione " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_Configuration_UPDATE  " + vbNewLine() + "  @ID AS int = NULL " + vbNewLine() + "  ,@Descrizione AS nvarchar(250) " + vbNewLine() + "  ,@Logo AS varbinary(MAX) = NULL " + vbNewLine() + "  ,@MittenteMail AS nvarchar(200) " + vbNewLine() + "  ,@DestinatarioMail AS nvarchar(200) " + vbNewLine() + "  ,@LeggePrivacy AS nvarchar(MAX) " + vbNewLine() + "  ,@IDSistemaRegistrazione AS int " + vbNewLine() + "  ,@IDProfiloRegistrazione AS int " + vbNewLine() + "  ,@EmailSegnalazioni AS nvarchar(200) " + vbNewLine() + "  ,@LastSyncNotifiche AS datetime " + vbNewLine() + "  ,@TimerSyncNotify AS int " + vbNewLine() + "  ,@IDProfiloNotificaRegistrazione AS int " + vbNewLine() + "  ,@IDAmbiente AS int " + vbNewLine() + "  ,@IDApplicazione AS int " + vbNewLine() + " AS  " + vbNewLine() + "BEGIN " + vbNewLine() + "  UPDATE Configuration " + vbNewLine() + "    SET  " + vbNewLine() + "      Descrizione =  @Descrizione " + vbNewLine() + "      , Logo =  @Logo " + vbNewLine() + "      , MittenteMail =  @MittenteMail " + vbNewLine() + "      , DestinatarioMail =  @DestinatarioMail " + vbNewLine() + "      , LeggePrivacy =  @LeggePrivacy " + vbNewLine() + "      , IDSistemaRegistrazione =  @IDSistemaRegistrazione " + vbNewLine() + "      , IDProfiloRegistrazione =  @IDProfiloRegistrazione " + vbNewLine() + "      , EmailSegnalazioni =  @EmailSegnalazioni " + vbNewLine() + "      , LastSyncNotifiche =  @LastSyncNotifiche " + vbNewLine() + "      , TimerSyncNotify =  @TimerSyncNotify " + vbNewLine() + "      , IDProfiloNotificaRegistrazione =  @IDProfiloNotificaRegistrazione " + vbNewLine() + "      , IDAmbiente =  @IDAmbiente " + vbNewLine() + "      , IDApplicazione =  @IDApplicazione " + vbNewLine() + "  WHERE  " + vbNewLine() + "    ID = @ID " + vbNewLine() + "  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "               " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_GetCustomProfileForAutoAuth]               " + vbNewLine() + "	@Username as varchar(20) = null               " + vbNewLine() + "	,@Dominio as varchar(50) = null               " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		IDSistemaRegistrazione   IDSysSistema               " + vbNewLine() + "		, IDProfiloRegistrazione IDSysProfilo               " + vbNewLine() + "	FROM Configuration               " + vbNewLine() + "	WHERE ID = 1               " + vbNewLine() + "	               " + vbNewLine() + "               " + vbNewLine() + "END               " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<               " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_GetCustomProfileForAutoAuth]               " + vbNewLine() + "	@Username as varchar(20) = null               " + vbNewLine() + "	,@Dominio as varchar(50) = null               " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		IDSistemaRegistrazione   IDSysSistema               " + vbNewLine() + "		, IDProfiloRegistrazione IDSysProfilo               " + vbNewLine() + "	FROM Configuration               " + vbNewLine() + "	WHERE ID = 1               " + vbNewLine() + "	               " + vbNewLine() + "               " + vbNewLine() + "END               " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccediCome_SEARCH	       	          " + vbNewLine() + "	@IDUtente as nvarchar(20) = null          " + vbNewLine() + "	,	@Nome as nvarchar(50) = null          " + vbNewLine() + "	,	@Cognome as nvarchar(50) = null          " + vbNewLine() + "	,	@IDSysSistema as int = null           " + vbNewLine() + "	, @IDUtenteEntrato as nvarchar(20) = null          " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN	          " + vbNewLine() + "	SELECT 		          " + vbNewLine() + "		sysU.ID as IDUtente          " + vbNewLine() + "		,	sysS.Descrizione as DescrizioneSistema          " + vbNewLine() + "		,	sysP.Nome as NomePersona          " + vbNewLine() + "		,	sysP.Cognome as CognomePersona          " + vbNewLine() + "		,	sysP.CodiceFiscale as CodiceFiscalePersona          " + vbNewLine() + "		,	sysPr.Descrizione as DescrizioneProfilo	          " + vbNewLine() + "	FROM sysUtenti sysU          " + vbNewLine() + "		INNER JOIN sysPersone sysP           " + vbNewLine() + "			ON sysP.ID = sysU.IDPersona	          " + vbNewLine() + "		INNER JOIN sysSistemi sysPr           " + vbNewLine() + "			ON sysPr.ID = sysU.IDSysSistema	          " + vbNewLine() + "		INNER JOIN sysSistemi sysS           " + vbNewLine() + "			ON sysS.ID = sysU.IDSysSistema	          " + vbNewLine() + "	WHERE 		          " + vbNewLine() + "		(@Nome is null or Nome like @Nome + '%')          " + vbNewLine() + "		AND (@Cognome is null or Cognome like @Cognome + '%')	          " + vbNewLine() + "		AND (@IDSysSistema is null or IDSysSistema = @IDSysSistema)		          " + vbNewLine() + "		AND (@IDUtente is null or sysU.ID = @IDUtente)          " + vbNewLine() + "		AND sysU.ID <> @IDUtenteEntrato	          " + vbNewLine() + "	ORDER BY 		          " + vbNewLine() + "		Cognome          " + vbNewLine() + "		, Nome          " + vbNewLine() + "		, CodiceFiscale           " + vbNewLine() + "END           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccediCome_SEARCH	       	          " + vbNewLine() + "	@IDUtente as nvarchar(20) = null          " + vbNewLine() + "	,	@Nome as nvarchar(50) = null          " + vbNewLine() + "	,	@Cognome as nvarchar(50) = null          " + vbNewLine() + "	,	@IDSysSistema as int = null           " + vbNewLine() + "	, @IDUtenteEntrato as nvarchar(20) = null          " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN	          " + vbNewLine() + "	SELECT 		          " + vbNewLine() + "		sysU.ID as IDUtente          " + vbNewLine() + "		,	sysS.Descrizione as DescrizioneSistema          " + vbNewLine() + "		,	sysP.Nome as NomePersona          " + vbNewLine() + "		,	sysP.Cognome as CognomePersona          " + vbNewLine() + "		,	sysP.CodiceFiscale as CodiceFiscalePersona          " + vbNewLine() + "		,	sysPr.Descrizione as DescrizioneProfilo	          " + vbNewLine() + "	FROM sysUtenti sysU          " + vbNewLine() + "		INNER JOIN sysPersone sysP           " + vbNewLine() + "			ON sysP.ID = sysU.IDPersona	          " + vbNewLine() + "		INNER JOIN sysSistemi sysPr           " + vbNewLine() + "			ON sysPr.ID = sysU.IDSysSistema	          " + vbNewLine() + "		INNER JOIN sysSistemi sysS           " + vbNewLine() + "			ON sysS.ID = sysU.IDSysSistema	          " + vbNewLine() + "	WHERE 		          " + vbNewLine() + "		(@Nome is null or Nome like @Nome + '%')          " + vbNewLine() + "		AND (@Cognome is null or Cognome like @Cognome + '%')	          " + vbNewLine() + "		AND (@IDSysSistema is null or IDSysSistema = @IDSysSistema)		          " + vbNewLine() + "		AND (@IDUtente is null or sysU.ID = @IDUtente)          " + vbNewLine() + "		AND sysU.ID <> @IDUtenteEntrato	          " + vbNewLine() + "	ORDER BY 		          " + vbNewLine() + "		Cognome          " + vbNewLine() + "		, Nome          " + vbNewLine() + "		, CodiceFiscale           " + vbNewLine() + "END           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessi_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessi_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                  " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysAccessi_DELETEALL]                   " + vbNewLine() + "AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  DELETE FROM sysAccessi                  " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni                  " + vbNewLine() + "                  " + vbNewLine() + "END                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                  " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysAccessi_DELETEALL]                   " + vbNewLine() + "AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  DELETE FROM sysAccessi                  " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni                  " + vbNewLine() + "                  " + vbNewLine() + "END                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessi_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@DataAccesso AS datetime   " + vbNewLine() + "  ,@NomeComputer AS nvarchar(100)   " + vbNewLine() + "  ,@OraFineLavoro AS datetime   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysAccessi (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,DataAccesso   " + vbNewLine() + "    ,NomeComputer   " + vbNewLine() + "    ,OraFineLavoro   " + vbNewLine() + "    ,IDPadre   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@DataAccesso   " + vbNewLine() + "    ,@NomeComputer   " + vbNewLine() + "    ,@OraFineLavoro   " + vbNewLine() + "    ,@IDPadre   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessi_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@DataAccesso AS datetime   " + vbNewLine() + "  ,@NomeComputer AS nvarchar(100)   " + vbNewLine() + "  ,@OraFineLavoro AS datetime   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysAccessi (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,DataAccesso   " + vbNewLine() + "    ,NomeComputer   " + vbNewLine() + "    ,OraFineLavoro   " + vbNewLine() + "    ,IDPadre   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@DataAccesso   " + vbNewLine() + "    ,@NomeComputer   " + vbNewLine() + "    ,@OraFineLavoro   " + vbNewLine() + "    ,@IDPadre   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessi_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataAccessoDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAccessoAl AS datetime = NULL    " + vbNewLine() + "  ,@NomeComputer AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@OraFineLavoroDal AS datetime = NULL    " + vbNewLine() + "  ,@OraFineLavoroAl AS datetime = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "  FROM sysAccessi Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "    AND  (@DataAccessoDal IS NULL OR Me.DataAccesso >= @DataAccessoDal)    " + vbNewLine() + "    AND  (@DataAccessoAl IS NULL OR Me.DataAccesso <= @DataAccessoAl)    " + vbNewLine() + "    AND  (@NomeComputer IS NULL OR Me.NomeComputer LIKE @NomeComputer + '%')    " + vbNewLine() + "    AND  (@OraFineLavoroDal IS NULL OR Me.OraFineLavoro >= @OraFineLavoroDal)    " + vbNewLine() + "    AND  (@OraFineLavoroAl IS NULL OR Me.OraFineLavoro <= @OraFineLavoroAl)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessi_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataAccessoDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAccessoAl AS datetime = NULL    " + vbNewLine() + "  ,@NomeComputer AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@OraFineLavoroDal AS datetime = NULL    " + vbNewLine() + "  ,@OraFineLavoroAl AS datetime = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "  FROM sysAccessi Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "    AND  (@DataAccessoDal IS NULL OR Me.DataAccesso >= @DataAccessoDal)    " + vbNewLine() + "    AND  (@DataAccessoAl IS NULL OR Me.DataAccesso <= @DataAccessoAl)    " + vbNewLine() + "    AND  (@NomeComputer IS NULL OR Me.NomeComputer LIKE @NomeComputer + '%')    " + vbNewLine() + "    AND  (@OraFineLavoroDal IS NULL OR Me.OraFineLavoro >= @OraFineLavoroDal)    " + vbNewLine() + "    AND  (@OraFineLavoroAl IS NULL OR Me.OraFineLavoro <= @OraFineLavoroAl)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessi_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "    , [DataAccesso]   " + vbNewLine() + "    , [NomeComputer]   " + vbNewLine() + "    , [OraFineLavoro]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "  FROM sysAccessi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessi_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "    , [DataAccesso]   " + vbNewLine() + "    , [NomeComputer]   " + vbNewLine() + "    , [OraFineLavoro]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "  FROM sysAccessi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessi_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@DataAccesso AS datetime   " + vbNewLine() + "  ,@NomeComputer AS nvarchar(100)   " + vbNewLine() + "  ,@OraFineLavoro AS datetime   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysAccessi   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysUtente =  @IDSysUtente   " + vbNewLine() + "      , DataAccesso =  @DataAccesso   " + vbNewLine() + "      , NomeComputer =  @NomeComputer   " + vbNewLine() + "      , OraFineLavoro =  @OraFineLavoro   " + vbNewLine() + "      , IDPadre =  @IDPadre   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessi_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@DataAccesso AS datetime   " + vbNewLine() + "  ,@NomeComputer AS nvarchar(100)   " + vbNewLine() + "  ,@OraFineLavoro AS datetime   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysAccessi   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysUtente =  @IDSysUtente   " + vbNewLine() + "      , DataAccesso =  @DataAccesso   " + vbNewLine() + "      , NomeComputer =  @NomeComputer   " + vbNewLine() + "      , OraFineLavoro =  @OraFineLavoro   " + vbNewLine() + "      , IDPadre =  @IDPadre   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_DELETEALL    " + vbNewLine() + "  @IDSysAccesso AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysAccesso = @IDSysAccesso   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_DELETEALL    " + vbNewLine() + "  @IDSysAccesso AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysAccessiOperazioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysAccesso = @IDSysAccesso   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_INSERT    " + vbNewLine() + "  @IDSysAccesso AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Operazione AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysAccessiOperazioni (    " + vbNewLine() + "    IDSysAccesso   " + vbNewLine() + "    ,IDSysFunzione   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Operazione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysAccesso   " + vbNewLine() + "    ,@IDSysFunzione   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Operazione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_INSERT    " + vbNewLine() + "  @IDSysAccesso AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Operazione AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysAccessiOperazioni (    " + vbNewLine() + "    IDSysAccesso   " + vbNewLine() + "    ,IDSysFunzione   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Operazione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysAccesso   " + vbNewLine() + "    ,@IDSysFunzione   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Operazione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysAccesso AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Operazione AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysFunzioni.Descrizione SysFunzione   " + vbNewLine() + "  FROM sysAccessiOperazioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysFunzioni sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysFunzione = sysFunzioni.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysAccesso IS NULL OR Me.IDSysAccesso = @IDSysAccesso)    " + vbNewLine() + "    AND  (@IDSysFunzione IS NULL OR Me.IDSysFunzione = @IDSysFunzione)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Operazione IS NULL OR Me.Operazione LIKE @Operazione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysAccesso AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Operazione AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysFunzioni.Descrizione SysFunzione   " + vbNewLine() + "  FROM sysAccessiOperazioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysFunzioni sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysFunzione = sysFunzioni.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysAccesso IS NULL OR Me.IDSysAccesso = @IDSysAccesso)    " + vbNewLine() + "    AND  (@IDSysFunzione IS NULL OR Me.IDSysFunzione = @IDSysFunzione)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Operazione IS NULL OR Me.Operazione LIKE @Operazione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Operazione]   " + vbNewLine() + "  FROM sysAccessiOperazioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Operazione]   " + vbNewLine() + "  FROM sysAccessiOperazioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_SELECTALL    " + vbNewLine() + "  @IDSysAccesso AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Operazione]   " + vbNewLine() + "  FROM sysAccessiOperazioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysAccesso = @IDSysAccesso   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_SELECTALL    " + vbNewLine() + "  @IDSysAccesso AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Operazione]   " + vbNewLine() + "  FROM sysAccessiOperazioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysAccesso = @IDSysAccesso   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysAccessiOperazioni_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysAccesso AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Operazione AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysAccessiOperazioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysAccesso =  @IDSysAccesso   " + vbNewLine() + "      , IDSysFunzione =  @IDSysFunzione   " + vbNewLine() + "      , Data =  @Data   " + vbNewLine() + "      , Operazione =  @Operazione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysAccessiOperazioni_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysAccesso AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Operazione AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysAccessiOperazioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysAccesso =  @IDSysAccesso   " + vbNewLine() + "      , IDSysFunzione =  @IDSysFunzione   " + vbNewLine() + "      , Data =  @Data   " + vbNewLine() + "      , Operazione =  @Operazione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "CREATE PROCEDURE [dbo].BSP_sysComuni_AUTOCOMPLETE    " + vbNewLine() + "  @Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT    " + vbNewLine() + "		Me.*    " + vbNewLine() + "  FROM sysComuni Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    Me.ID LIKE  @Descrizione + '%'   " + vbNewLine() + "    OR Me.Descrizione LIKE @Descrizione + '%'    " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		Me.Descrizione   " + vbNewLine() + "		, Me.ID   " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "CREATE PROCEDURE [dbo].BSP_sysComuni_AUTOCOMPLETE    " + vbNewLine() + "  @Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT    " + vbNewLine() + "		Me.*    " + vbNewLine() + "  FROM sysComuni Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    Me.ID LIKE  @Descrizione + '%'   " + vbNewLine() + "    OR Me.Descrizione LIKE @Descrizione + '%'    " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		Me.Descrizione   " + vbNewLine() + "		, Me.ID   " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuni_DELETE    " + vbNewLine() + "  @ID AS nvarchar(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuni_DELETE    " + vbNewLine() + "  @ID AS nvarchar(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuni_INSERT    " + vbNewLine() + "  @ID AS nvarchar(4)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@CodiceIstat AS nvarchar(10)   " + vbNewLine() + "  ,@CodiceIstatAsl AS nvarchar(3)   " + vbNewLine() + "  ,@CAP AS nvarchar(10)   " + vbNewLine() + "  ,@IDProvincia AS nvarchar(2)   " + vbNewLine() + "  ,@DataIstituzione AS datetime   " + vbNewLine() + "  ,@DataCessazione AS datetime   " + vbNewLine() + "  ,@Patrono AS nvarchar(4)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysComuni (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,CodiceIstat   " + vbNewLine() + "    ,CodiceIstatAsl   " + vbNewLine() + "    ,CAP   " + vbNewLine() + "    ,IDProvincia   " + vbNewLine() + "    ,DataIstituzione   " + vbNewLine() + "    ,DataCessazione   " + vbNewLine() + "    ,Patrono   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@CodiceIstat   " + vbNewLine() + "    ,@CodiceIstatAsl   " + vbNewLine() + "    ,@CAP   " + vbNewLine() + "    ,@IDProvincia   " + vbNewLine() + "    ,@DataIstituzione   " + vbNewLine() + "    ,@DataCessazione   " + vbNewLine() + "    ,@Patrono   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuni_INSERT    " + vbNewLine() + "  @ID AS nvarchar(4)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@CodiceIstat AS nvarchar(10)   " + vbNewLine() + "  ,@CodiceIstatAsl AS nvarchar(3)   " + vbNewLine() + "  ,@CAP AS nvarchar(10)   " + vbNewLine() + "  ,@IDProvincia AS nvarchar(2)   " + vbNewLine() + "  ,@DataIstituzione AS datetime   " + vbNewLine() + "  ,@DataCessazione AS datetime   " + vbNewLine() + "  ,@Patrono AS nvarchar(4)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysComuni (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,CodiceIstat   " + vbNewLine() + "    ,CodiceIstatAsl   " + vbNewLine() + "    ,CAP   " + vbNewLine() + "    ,IDProvincia   " + vbNewLine() + "    ,DataIstituzione   " + vbNewLine() + "    ,DataCessazione   " + vbNewLine() + "    ,Patrono   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@CodiceIstat   " + vbNewLine() + "    ,@CodiceIstatAsl   " + vbNewLine() + "    ,@CAP   " + vbNewLine() + "    ,@IDProvincia   " + vbNewLine() + "    ,@DataIstituzione   " + vbNewLine() + "    ,@DataCessazione   " + vbNewLine() + "    ,@Patrono   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuni_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@CodiceIstat AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@CodiceIstatAsl AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@CAP AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@IDProvincia AS NVARCHAR(2) = NULL    " + vbNewLine() + "  ,@DataIstituzioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataIstituzioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataCessazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCessazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@Patrono AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProvince.Descrizione Provincia   " + vbNewLine() + "  FROM sysComuni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProvince sysProvince WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDProvincia = sysProvince.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@CodiceIstat IS NULL OR Me.CodiceIstat LIKE @CodiceIstat + '%')    " + vbNewLine() + "    AND  (@CodiceIstatAsl IS NULL OR Me.CodiceIstatAsl LIKE @CodiceIstatAsl + '%')    " + vbNewLine() + "    AND  (@CAP IS NULL OR Me.CAP LIKE @CAP + '%')    " + vbNewLine() + "    AND  (@IDProvincia IS NULL OR Me.IDProvincia LIKE @IDProvincia + '%')    " + vbNewLine() + "    AND  (@DataIstituzioneDal IS NULL OR Me.DataIstituzione >= @DataIstituzioneDal)    " + vbNewLine() + "    AND  (@DataIstituzioneAl IS NULL OR Me.DataIstituzione <= @DataIstituzioneAl)    " + vbNewLine() + "    AND  (@DataCessazioneDal IS NULL OR Me.DataCessazione >= @DataCessazioneDal)    " + vbNewLine() + "    AND  (@DataCessazioneAl IS NULL OR Me.DataCessazione <= @DataCessazioneAl)    " + vbNewLine() + "    AND  (@Patrono IS NULL OR Me.Patrono LIKE @Patrono + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuni_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@CodiceIstat AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@CodiceIstatAsl AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@CAP AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@IDProvincia AS NVARCHAR(2) = NULL    " + vbNewLine() + "  ,@DataIstituzioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataIstituzioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataCessazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCessazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@Patrono AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProvince.Descrizione Provincia   " + vbNewLine() + "  FROM sysComuni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProvince sysProvince WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDProvincia = sysProvince.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@CodiceIstat IS NULL OR Me.CodiceIstat LIKE @CodiceIstat + '%')    " + vbNewLine() + "    AND  (@CodiceIstatAsl IS NULL OR Me.CodiceIstatAsl LIKE @CodiceIstatAsl + '%')    " + vbNewLine() + "    AND  (@CAP IS NULL OR Me.CAP LIKE @CAP + '%')    " + vbNewLine() + "    AND  (@IDProvincia IS NULL OR Me.IDProvincia LIKE @IDProvincia + '%')    " + vbNewLine() + "    AND  (@DataIstituzioneDal IS NULL OR Me.DataIstituzione >= @DataIstituzioneDal)    " + vbNewLine() + "    AND  (@DataIstituzioneAl IS NULL OR Me.DataIstituzione <= @DataIstituzioneAl)    " + vbNewLine() + "    AND  (@DataCessazioneDal IS NULL OR Me.DataCessazione >= @DataCessazioneDal)    " + vbNewLine() + "    AND  (@DataCessazioneAl IS NULL OR Me.DataCessazione <= @DataCessazioneAl)    " + vbNewLine() + "    AND  (@Patrono IS NULL OR Me.Patrono LIKE @Patrono + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuni_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [CodiceIstat]   " + vbNewLine() + "    , [CodiceIstatAsl]   " + vbNewLine() + "    , [CAP]   " + vbNewLine() + "    , [IDProvincia]   " + vbNewLine() + "    , [DataIstituzione]   " + vbNewLine() + "    , [DataCessazione]   " + vbNewLine() + "    , [Patrono]   " + vbNewLine() + "  FROM sysComuni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuni_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [CodiceIstat]   " + vbNewLine() + "    , [CodiceIstatAsl]   " + vbNewLine() + "    , [CAP]   " + vbNewLine() + "    , [IDProvincia]   " + vbNewLine() + "    , [DataIstituzione]   " + vbNewLine() + "    , [DataCessazione]   " + vbNewLine() + "    , [Patrono]   " + vbNewLine() + "  FROM sysComuni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuni_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(4) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@CodiceIstat AS nvarchar(10)   " + vbNewLine() + "  ,@CodiceIstatAsl AS nvarchar(3)   " + vbNewLine() + "  ,@CAP AS nvarchar(10)   " + vbNewLine() + "  ,@IDProvincia AS nvarchar(2)   " + vbNewLine() + "  ,@DataIstituzione AS datetime   " + vbNewLine() + "  ,@DataCessazione AS datetime   " + vbNewLine() + "  ,@Patrono AS nvarchar(4)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysComuni   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , CodiceIstat =  @CodiceIstat   " + vbNewLine() + "      , CodiceIstatAsl =  @CodiceIstatAsl   " + vbNewLine() + "      , CAP =  @CAP   " + vbNewLine() + "      , IDProvincia =  @IDProvincia   " + vbNewLine() + "      , DataIstituzione =  @DataIstituzione   " + vbNewLine() + "      , DataCessazione =  @DataCessazione   " + vbNewLine() + "      , Patrono =  @Patrono   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuni_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(4) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@CodiceIstat AS nvarchar(10)   " + vbNewLine() + "  ,@CodiceIstatAsl AS nvarchar(3)   " + vbNewLine() + "  ,@CAP AS nvarchar(10)   " + vbNewLine() + "  ,@IDProvincia AS nvarchar(2)   " + vbNewLine() + "  ,@DataIstituzione AS datetime   " + vbNewLine() + "  ,@DataCessazione AS datetime   " + vbNewLine() + "  ,@Patrono AS nvarchar(4)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysComuni   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , CodiceIstat =  @CodiceIstat   " + vbNewLine() + "      , CodiceIstatAsl =  @CodiceIstatAsl   " + vbNewLine() + "      , CAP =  @CAP   " + vbNewLine() + "      , IDProvincia =  @IDProvincia   " + vbNewLine() + "      , DataIstituzione =  @DataIstituzione   " + vbNewLine() + "      , DataCessazione =  @DataCessazione   " + vbNewLine() + "      , Patrono =  @Patrono   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_DELETE    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuniQuartieri   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_DELETE    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuniQuartieri   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_DELETEALL    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuniQuartieri   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_DELETEALL    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysComuniQuartieri   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_INSERT    " + vbNewLine() + "  @IDComune AS nvarchar(4)   " + vbNewLine() + "  ,@IDQuartiere AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysComuniQuartieri (    " + vbNewLine() + "    IDComune   " + vbNewLine() + "    ,IDQuartiere   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDComune   " + vbNewLine() + "    ,@IDQuartiere   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_INSERT    " + vbNewLine() + "  @IDComune AS nvarchar(4)   " + vbNewLine() + "  ,@IDQuartiere AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysComuniQuartieri (    " + vbNewLine() + "    IDComune   " + vbNewLine() + "    ,IDQuartiere   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDComune   " + vbNewLine() + "    ,@IDQuartiere   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_SEARCH    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysComuniQuartieri Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDComune IS NULL OR Me.IDComune = @IDComune)    " + vbNewLine() + "    AND  (@IDQuartiere IS NULL OR Me.IDQuartiere = @IDQuartiere)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_SEARCH    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysComuniQuartieri Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDComune IS NULL OR Me.IDComune = @IDComune)    " + vbNewLine() + "    AND  (@IDQuartiere IS NULL OR Me.IDQuartiere = @IDQuartiere)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_SELECT    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDComune]   " + vbNewLine() + "    , [IDQuartiere]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysComuniQuartieri WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_SELECT    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDQuartiere AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDComune]   " + vbNewLine() + "    , [IDQuartiere]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysComuniQuartieri WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_SELECTALL    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDComune]   " + vbNewLine() + "    , [IDQuartiere]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysComuniQuartieri WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_SELECTALL    " + vbNewLine() + "  @IDComune AS NVARCHAR(4) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDComune]   " + vbNewLine() + "    , [IDQuartiere]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysComuniQuartieri WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysComuniQuartieri_UPDATE    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL   " + vbNewLine() + "  ,@IDQuartiere AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysComuniQuartieri   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysComuniQuartieri_UPDATE    " + vbNewLine() + "  @IDComune AS nvarchar(4) = NULL   " + vbNewLine() + "  ,@IDQuartiere AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysComuniQuartieri   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDComune = @IDComune   " + vbNewLine() + "    AND IDQuartiere = @IDQuartiere   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "--/*                            " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysFunzioni_CambiaOrdine]                            " + vbNewLine() + "	@id as integer,                            " + vbNewLine() + "	@Incremento as int                            " + vbNewLine() + "as                            " + vbNewLine() + "--*/                            " + vbNewLine() + "/*                            " + vbNewLine() + "declare                             " + vbNewLine() + "	@id as integer = 18,                            " + vbNewLine() + "	@Incremento as int = -1                            " + vbNewLine() + "--*/                            " + vbNewLine() + "	declare @Ordine as int                            " + vbNewLine() + "	declare @NewOrdine as int                            " + vbNewLine() + "	declare @IDPadre as int                            " + vbNewLine() + "                            " + vbNewLine() + "	select                             " + vbNewLine() + "		@NewOrdine = Ordine + @Incremento,                             " + vbNewLine() + "		@Ordine = Ordine,                             " + vbNewLine() + "		@IDPadre = IDPadre                            " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni                            " + vbNewLine() + "	where                             " + vbNewLine() + "		ID = @id                            " + vbNewLine() + "	                            " + vbNewLine() + "	                            " + vbNewLine() + "	--/*                            " + vbNewLine() + "	update                             " + vbNewLine() + "		sysFunzioni                             " + vbNewLine() + "	set                             " + vbNewLine() + "		Ordine = @Ordine                            " + vbNewLine() + "	--*/ select * from sysFunzioni                            " + vbNewLine() + "	where                             " + vbNewLine() + "		Ordine = @NewOrdine                            " + vbNewLine() + "		and isnull(IDPadre, -1) = isnull(@IDPadre, -1)                            " + vbNewLine() + "                            " + vbNewLine() + "	if @@ROWCOUNT = 1                            " + vbNewLine() + "	begin                             " + vbNewLine() + "		--/*                            " + vbNewLine() + "		update                             " + vbNewLine() + "			sysFunzioni                             " + vbNewLine() + "		set                            " + vbNewLine() + "			Ordine = @NewOrdine                            " + vbNewLine() + "		--*/ select * from sysFunzioni                            " + vbNewLine() + "		where                             " + vbNewLine() + "			ID = @id                            " + vbNewLine() + "	end                            " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<--/*                            " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysFunzioni_CambiaOrdine]                            " + vbNewLine() + "	@id as integer,                            " + vbNewLine() + "	@Incremento as int                            " + vbNewLine() + "as                            " + vbNewLine() + "--*/                            " + vbNewLine() + "/*                            " + vbNewLine() + "declare                             " + vbNewLine() + "	@id as integer = 18,                            " + vbNewLine() + "	@Incremento as int = -1                            " + vbNewLine() + "--*/                            " + vbNewLine() + "	declare @Ordine as int                            " + vbNewLine() + "	declare @NewOrdine as int                            " + vbNewLine() + "	declare @IDPadre as int                            " + vbNewLine() + "                            " + vbNewLine() + "	select                             " + vbNewLine() + "		@NewOrdine = Ordine + @Incremento,                             " + vbNewLine() + "		@Ordine = Ordine,                             " + vbNewLine() + "		@IDPadre = IDPadre                            " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni                            " + vbNewLine() + "	where                             " + vbNewLine() + "		ID = @id                            " + vbNewLine() + "	                            " + vbNewLine() + "	                            " + vbNewLine() + "	--/*                            " + vbNewLine() + "	update                             " + vbNewLine() + "		sysFunzioni                             " + vbNewLine() + "	set                             " + vbNewLine() + "		Ordine = @Ordine                            " + vbNewLine() + "	--*/ select * from sysFunzioni                            " + vbNewLine() + "	where                             " + vbNewLine() + "		Ordine = @NewOrdine                            " + vbNewLine() + "		and isnull(IDPadre, -1) = isnull(@IDPadre, -1)                            " + vbNewLine() + "                            " + vbNewLine() + "	if @@ROWCOUNT = 1                            " + vbNewLine() + "	begin                             " + vbNewLine() + "		--/*                            " + vbNewLine() + "		update                             " + vbNewLine() + "			sysFunzioni                             " + vbNewLine() + "		set                            " + vbNewLine() + "			Ordine = @NewOrdine                            " + vbNewLine() + "		--*/ select * from sysFunzioni                            " + vbNewLine() + "		where                             " + vbNewLine() + "			ID = @id                            " + vbNewLine() + "	end                            " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysFunzioni_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysFunzioni_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysFunzioni_INSERT    " + vbNewLine() + "  @IDPadre AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@Comando AS nvarchar(200)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Auth AS bit   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@IDSysModulo AS int   " + vbNewLine() + "  ,@Tooltip AS nvarchar(MAX)   " + vbNewLine() + "  ,@ShortCut AS nvarchar(MAX)   " + vbNewLine() + "  ,@Image AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@IDFunzioneWP AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysFunzioni (    " + vbNewLine() + "    IDPadre   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,Comando   " + vbNewLine() + "    ,Ordine   " + vbNewLine() + "    ,Auth   " + vbNewLine() + "    ,Developer   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "    ,IDSysModulo   " + vbNewLine() + "    ,Tooltip   " + vbNewLine() + "    ,ShortCut   " + vbNewLine() + "    ,Image   " + vbNewLine() + "    ,IDFunzioneWP   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDPadre   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@Comando   " + vbNewLine() + "    ,@Ordine   " + vbNewLine() + "    ,@Auth   " + vbNewLine() + "    ,@Developer   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "    ,@IDSysModulo   " + vbNewLine() + "    ,@Tooltip   " + vbNewLine() + "    ,@ShortCut   " + vbNewLine() + "    ,@Image   " + vbNewLine() + "    ,@IDFunzioneWP   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysFunzioni_INSERT    " + vbNewLine() + "  @IDPadre AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@Comando AS nvarchar(200)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Auth AS bit   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@IDSysModulo AS int   " + vbNewLine() + "  ,@Tooltip AS nvarchar(MAX)   " + vbNewLine() + "  ,@ShortCut AS nvarchar(MAX)   " + vbNewLine() + "  ,@Image AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@IDFunzioneWP AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysFunzioni (    " + vbNewLine() + "    IDPadre   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,Comando   " + vbNewLine() + "    ,Ordine   " + vbNewLine() + "    ,Auth   " + vbNewLine() + "    ,Developer   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "    ,IDSysModulo   " + vbNewLine() + "    ,Tooltip   " + vbNewLine() + "    ,ShortCut   " + vbNewLine() + "    ,Image   " + vbNewLine() + "    ,IDFunzioneWP   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDPadre   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@Comando   " + vbNewLine() + "    ,@Ordine   " + vbNewLine() + "    ,@Auth   " + vbNewLine() + "    ,@Developer   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "    ,@IDSysModulo   " + vbNewLine() + "    ,@Tooltip   " + vbNewLine() + "    ,@ShortCut   " + vbNewLine() + "    ,@Image   " + vbNewLine() + "    ,@IDFunzioneWP   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                  " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysFunzioni_LOADTREE]                        " + vbNewLine() + "	@IDSysProfilo as int = null                       " + vbNewLine() + "AS                        " + vbNewLine() + "BEGIN                        " + vbNewLine() + "                       " + vbNewLine() + "	SELECT                       " + vbNewLine() + "    f.*,                       " + vbNewLine() + "    pf.IDSysProfilo,                       " + vbNewLine() + "    r.ID as IDsysRuolo,                       " + vbNewLine() + "    r.Descrizione as IDsysRuoloDescrizione                       " + vbNewLine() + "	FROM sysFunzioni f                       " + vbNewLine() + "		left join sysProfiliFunzioni pf                   " + vbNewLine() + "			on f.ID = pf.IDSysFunzione and pf.IDSysProfilo = @IDSysProfilo                       " + vbNewLine() + "		left join sysRuoli r                   " + vbNewLine() + "			on pf.IDSysRuolo = r.ID                       " + vbNewLine() + "	order by                        " + vbNewLine() + "		Ordine                       " + vbNewLine() + "                  " + vbNewLine() + "END                       " + vbNewLine() + "                       " + vbNewLine() + "                  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                  " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysFunzioni_LOADTREE]                        " + vbNewLine() + "	@IDSysProfilo as int = null                       " + vbNewLine() + "AS                        " + vbNewLine() + "BEGIN                        " + vbNewLine() + "                       " + vbNewLine() + "	SELECT                       " + vbNewLine() + "    f.*,                       " + vbNewLine() + "    pf.IDSysProfilo,                       " + vbNewLine() + "    r.ID as IDsysRuolo,                       " + vbNewLine() + "    r.Descrizione as IDsysRuoloDescrizione                       " + vbNewLine() + "	FROM sysFunzioni f                       " + vbNewLine() + "		left join sysProfiliFunzioni pf                   " + vbNewLine() + "			on f.ID = pf.IDSysFunzione and pf.IDSysProfilo = @IDSysProfilo                       " + vbNewLine() + "		left join sysRuoli r                   " + vbNewLine() + "			on pf.IDSysRuolo = r.ID                       " + vbNewLine() + "	order by                        " + vbNewLine() + "		Ordine                       " + vbNewLine() + "                  " + vbNewLine() + "END                       " + vbNewLine() + "                       " + vbNewLine() + "                  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                            " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysFunzioni_Ordina]                             " + vbNewLine() + "                            " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	--/*                            " + vbNewLine() + "	UPDATE f                            " + vbNewLine() + "	  set                           " + vbNewLine() + "      f.Ordine = fNew.NewOrdine                            " + vbNewLine() + "	--*/select *, NewOrdine                            " + vbNewLine() + "	FROM sysFunzioni f                            " + vbNewLine() + "	  INNER JOIN (	                            " + vbNewLine() + "		  select id, ROW_NUMBER() over (partition by IDPadre order by isnull(Ordine,10000)) - 1 NewOrdine                            " + vbNewLine() + "		  from sysFunzioni                          " + vbNewLine() + "    ) fNew on f.ID = fNew.ID                            " + vbNewLine() + " END                          " + vbNewLine() + "                            " + vbNewLine() + "			                           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                            " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysFunzioni_Ordina]                             " + vbNewLine() + "                            " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	--/*                            " + vbNewLine() + "	UPDATE f                            " + vbNewLine() + "	  set                           " + vbNewLine() + "      f.Ordine = fNew.NewOrdine                            " + vbNewLine() + "	--*/select *, NewOrdine                            " + vbNewLine() + "	FROM sysFunzioni f                            " + vbNewLine() + "	  INNER JOIN (	                            " + vbNewLine() + "		  select id, ROW_NUMBER() over (partition by IDPadre order by isnull(Ordine,10000)) - 1 NewOrdine                            " + vbNewLine() + "		  from sysFunzioni                          " + vbNewLine() + "    ) fNew on f.ID = fNew.ID                            " + vbNewLine() + " END                          " + vbNewLine() + "                            " + vbNewLine() + "			                           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysFunzioni_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@Comando AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@Ordine AS int = NULL    " + vbNewLine() + "  ,@Auth AS bit = NULL    " + vbNewLine() + "  ,@Developer AS bit = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + "  ,@IDSysModulo AS int = NULL    " + vbNewLine() + "  ,@Tooltip AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@ShortCut AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDFunzioneWP AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysModuli.Descrizione SysModulo   " + vbNewLine() + "  FROM sysFunzioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysModuli sysModuli WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysModulo = sysModuli.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Comando IS NULL OR Me.Comando LIKE @Comando + '%')    " + vbNewLine() + "    AND  (@Ordine IS NULL OR Me.Ordine = @Ordine)    " + vbNewLine() + "    AND  (@Auth IS NULL OR Me.Auth = @Auth)    " + vbNewLine() + "    AND  (@Developer IS NULL OR Me.Developer = @Developer)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "    AND  (@IDSysModulo IS NULL OR Me.IDSysModulo = @IDSysModulo)    " + vbNewLine() + "    AND  (@Tooltip IS NULL OR Me.Tooltip LIKE @Tooltip + '%')    " + vbNewLine() + "    AND  (@ShortCut IS NULL OR Me.ShortCut LIKE @ShortCut + '%')    " + vbNewLine() + "    AND  (@IDFunzioneWP IS NULL OR Me.IDFunzioneWP = @IDFunzioneWP)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysFunzioni_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@Comando AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@Ordine AS int = NULL    " + vbNewLine() + "  ,@Auth AS bit = NULL    " + vbNewLine() + "  ,@Developer AS bit = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + "  ,@IDSysModulo AS int = NULL    " + vbNewLine() + "  ,@Tooltip AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@ShortCut AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDFunzioneWP AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysModuli.Descrizione SysModulo   " + vbNewLine() + "  FROM sysFunzioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysModuli sysModuli WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysModulo = sysModuli.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Comando IS NULL OR Me.Comando LIKE @Comando + '%')    " + vbNewLine() + "    AND  (@Ordine IS NULL OR Me.Ordine = @Ordine)    " + vbNewLine() + "    AND  (@Auth IS NULL OR Me.Auth = @Auth)    " + vbNewLine() + "    AND  (@Developer IS NULL OR Me.Developer = @Developer)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "    AND  (@IDSysModulo IS NULL OR Me.IDSysModulo = @IDSysModulo)    " + vbNewLine() + "    AND  (@Tooltip IS NULL OR Me.Tooltip LIKE @Tooltip + '%')    " + vbNewLine() + "    AND  (@ShortCut IS NULL OR Me.ShortCut LIKE @ShortCut + '%')    " + vbNewLine() + "    AND  (@IDFunzioneWP IS NULL OR Me.IDFunzioneWP = @IDFunzioneWP)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysFunzioni_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Comando]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Auth]   " + vbNewLine() + "    , [Developer]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "    , [IDSysModulo]   " + vbNewLine() + "    , [Tooltip]   " + vbNewLine() + "    , [ShortCut]   " + vbNewLine() + "    , [Image]   " + vbNewLine() + "    , [IDFunzioneWP]   " + vbNewLine() + "  FROM sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysFunzioni_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Comando]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Auth]   " + vbNewLine() + "    , [Developer]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "    , [IDSysModulo]   " + vbNewLine() + "    , [Tooltip]   " + vbNewLine() + "    , [ShortCut]   " + vbNewLine() + "    , [Image]   " + vbNewLine() + "    , [IDFunzioneWP]   " + vbNewLine() + "  FROM sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                    " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysFunzioni_SELECT_CMD]                     " + vbNewLine() + "--DECLARE                    " + vbNewLine() + "  @COMANDO AS VARCHAR(200) --= 'BSystem/sysFunzioni.aspx'                     " + vbNewLine() + "AS                     " + vbNewLine() + "BEGIN                    " + vbNewLine() + "  SELECT                     " + vbNewLine() + "    [ID]                    " + vbNewLine() + "    , [IDPadre]                    " + vbNewLine() + "    , [Descrizione]                    " + vbNewLine() + "    , [Comando]                    " + vbNewLine() + "    , [Ordine]                    " + vbNewLine() + "    , [Auth]                    " + vbNewLine() + "    , [Developer]                    " + vbNewLine() + "    , [Attivo]                    " + vbNewLine() + "    , [IDSysModulo]                    " + vbNewLine() + "    , [Tooltip]                    " + vbNewLine() + "    , [ShortCut]                    " + vbNewLine() + "    , [Image]                    " + vbNewLine() + "    , [IDFunzioneWP]                    " + vbNewLine() + "  FROM sysFunzioni                     " + vbNewLine() + "  WHERE                     " + vbNewLine() + "    Comando = @COMANDO                    " + vbNewLine() + "                     " + vbNewLine() + " END                    " + vbNewLine() + "                    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                    " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysFunzioni_SELECT_CMD]                     " + vbNewLine() + "--DECLARE                    " + vbNewLine() + "  @COMANDO AS VARCHAR(200) --= 'BSystem/sysFunzioni.aspx'                     " + vbNewLine() + "AS                     " + vbNewLine() + "BEGIN                    " + vbNewLine() + "  SELECT                     " + vbNewLine() + "    [ID]                    " + vbNewLine() + "    , [IDPadre]                    " + vbNewLine() + "    , [Descrizione]                    " + vbNewLine() + "    , [Comando]                    " + vbNewLine() + "    , [Ordine]                    " + vbNewLine() + "    , [Auth]                    " + vbNewLine() + "    , [Developer]                    " + vbNewLine() + "    , [Attivo]                    " + vbNewLine() + "    , [IDSysModulo]                    " + vbNewLine() + "    , [Tooltip]                    " + vbNewLine() + "    , [ShortCut]                    " + vbNewLine() + "    , [Image]                    " + vbNewLine() + "    , [IDFunzioneWP]                    " + vbNewLine() + "  FROM sysFunzioni                     " + vbNewLine() + "  WHERE                     " + vbNewLine() + "    Comando = @COMANDO                    " + vbNewLine() + "                     " + vbNewLine() + " END                    " + vbNewLine() + "                    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysFunzioni_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@Comando AS nvarchar(200)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Auth AS bit   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@IDSysModulo AS int   " + vbNewLine() + "  ,@Tooltip AS nvarchar(MAX)   " + vbNewLine() + "  ,@ShortCut AS nvarchar(MAX)   " + vbNewLine() + "  ,@Image AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@IDFunzioneWP AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysFunzioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDPadre =  @IDPadre   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , Comando =  @Comando   " + vbNewLine() + "      , Ordine =  @Ordine   " + vbNewLine() + "      , Auth =  @Auth   " + vbNewLine() + "      , Developer =  @Developer   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "      , IDSysModulo =  @IDSysModulo   " + vbNewLine() + "      , Tooltip =  @Tooltip   " + vbNewLine() + "      , ShortCut =  @ShortCut   " + vbNewLine() + "      , Image =  @Image   " + vbNewLine() + "      , IDFunzioneWP =  @IDFunzioneWP   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysFunzioni_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@Comando AS nvarchar(200)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Auth AS bit   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@IDSysModulo AS int   " + vbNewLine() + "  ,@Tooltip AS nvarchar(MAX)   " + vbNewLine() + "  ,@ShortCut AS nvarchar(MAX)   " + vbNewLine() + "  ,@Image AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@IDFunzioneWP AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysFunzioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDPadre =  @IDPadre   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , Comando =  @Comando   " + vbNewLine() + "      , Ordine =  @Ordine   " + vbNewLine() + "      , Auth =  @Auth   " + vbNewLine() + "      , Developer =  @Developer   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "      , IDSysModulo =  @IDSysModulo   " + vbNewLine() + "      , Tooltip =  @Tooltip   " + vbNewLine() + "      , ShortCut =  @ShortCut   " + vbNewLine() + "      , Image =  @Image   " + vbNewLine() + "      , IDFunzioneWP =  @IDFunzioneWP   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE procedure [dbo].[BSP_sysGetAuthFunzioni]                            " + vbNewLine() + "	@IDSysFunzione int, -- = 1,                          " + vbNewLine() + "	@IDSysProfilo int = null,                          " + vbNewLine() + "	@Developer bit = null                          " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                             " + vbNewLine() + "		f.ID IDFunzione,                            " + vbNewLine() + "		isnull(pf.IDSysRuolo, -1) IDRuolo                            " + vbNewLine() + "		--, f.*, pf.*                          " + vbNewLine() + "	FROM sysFunzioni f                            " + vbNewLine() + "		left join sysProfiliFunzioni PF                            " + vbNewLine() + "			on f.ID = pf.IDSysFunzione                             " + vbNewLine() + "				and pf.IDSysProfilo = isnull(@IDSysProfilo,-1)                          " + vbNewLine() + "	WHERE                             " + vbNewLine() + "		f.ID = @IDSysFunzione                          " + vbNewLine() + "		and (pf.IDSysProfilo= @IDSysProfilo or f.Auth = 0 or f.developer = isnull(@developer,0))                          " + vbNewLine() + "		and (not pf.IDSysFunzione is null or f.Developer = isnull(@Developer,0))                          " + vbNewLine() + "  OPTION(RECOMPILE)                          " + vbNewLine() + "END                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE procedure [dbo].[BSP_sysGetAuthFunzioni]                            " + vbNewLine() + "	@IDSysFunzione int, -- = 1,                          " + vbNewLine() + "	@IDSysProfilo int = null,                          " + vbNewLine() + "	@Developer bit = null                          " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                             " + vbNewLine() + "		f.ID IDFunzione,                            " + vbNewLine() + "		isnull(pf.IDSysRuolo, -1) IDRuolo                            " + vbNewLine() + "		--, f.*, pf.*                          " + vbNewLine() + "	FROM sysFunzioni f                            " + vbNewLine() + "		left join sysProfiliFunzioni PF                            " + vbNewLine() + "			on f.ID = pf.IDSysFunzione                             " + vbNewLine() + "				and pf.IDSysProfilo = isnull(@IDSysProfilo,-1)                          " + vbNewLine() + "	WHERE                             " + vbNewLine() + "		f.ID = @IDSysFunzione                          " + vbNewLine() + "		and (pf.IDSysProfilo= @IDSysProfilo or f.Auth = 0 or f.developer = isnull(@developer,0))                          " + vbNewLine() + "		and (not pf.IDSysFunzione is null or f.Developer = isnull(@Developer,0))                          " + vbNewLine() + "  OPTION(RECOMPILE)                          " + vbNewLine() + "END                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                          " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysGetAuthFunzioniWP]                             " + vbNewLine() + "--declare                              " + vbNewLine() + "	@IDSysFunzione int ,-- = 46,                           " + vbNewLine() + "	@IDUtente int = null,                           " + vbNewLine() + "	@Developer bit = null                           " + vbNewLine() + "as                             " + vbNewLine() + "begin                           " + vbNewLine() + "	select                              " + vbNewLine() + "		f.ID IDFunzione,                             " + vbNewLine() + "		-1 IDRuolo                             " + vbNewLine() + "		--, f.*, pf.*                           " + vbNewLine() + "	from sysFunzioni f                             " + vbNewLine() + "			inner join autorizzazioni.dbo.funzioni wpf                            " + vbNewLine() + "				on wpf.IdFunzione = f.IDFunzioneWP	                            " + vbNewLine() + "	where                              " + vbNewLine() + "		f.ID = @IDSysFunzione                           " + vbNewLine() + "    and wpf.IdFunzione in (                            " + vbNewLine() + "					select fr.IdFunzione                             " + vbNewLine() + "					from Autorizzazioni.dbo.UtentiRuoli ur			                            " + vbNewLine() + "						inner join Autorizzazioni.dbo.FunzioniRuoli fr	                             " + vbNewLine() + "							on ur.idRuolo = fr.IdRuolo                            " + vbNewLine() + "					where ur.idUtente = @idutente                            " + vbNewLine() + "		    )		                          " + vbNewLine() + "end                           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                          " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysGetAuthFunzioniWP]                             " + vbNewLine() + "--declare                              " + vbNewLine() + "	@IDSysFunzione int ,-- = 46,                           " + vbNewLine() + "	@IDUtente int = null,                           " + vbNewLine() + "	@Developer bit = null                           " + vbNewLine() + "as                             " + vbNewLine() + "begin                           " + vbNewLine() + "	select                              " + vbNewLine() + "		f.ID IDFunzione,                             " + vbNewLine() + "		-1 IDRuolo                             " + vbNewLine() + "		--, f.*, pf.*                           " + vbNewLine() + "	from sysFunzioni f                             " + vbNewLine() + "			inner join autorizzazioni.dbo.funzioni wpf                            " + vbNewLine() + "				on wpf.IdFunzione = f.IDFunzioneWP	                            " + vbNewLine() + "	where                              " + vbNewLine() + "		f.ID = @IDSysFunzione                           " + vbNewLine() + "    and wpf.IdFunzione in (                            " + vbNewLine() + "					select fr.IdFunzione                             " + vbNewLine() + "					from Autorizzazioni.dbo.UtentiRuoli ur			                            " + vbNewLine() + "						inner join Autorizzazioni.dbo.FunzioniRuoli fr	                             " + vbNewLine() + "							on ur.idRuolo = fr.IdRuolo                            " + vbNewLine() + "					where ur.idUtente = @idutente                            " + vbNewLine() + "		    )		                          " + vbNewLine() + "end                           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE procedure [dbo].[BSP_sysGetDominio]                           " + vbNewLine() + "	@user as varchar(50)                         " + vbNewLine() + "AS                          " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                            " + vbNewLine() + "		ntdomain                            " + vbNewLine() + "	FROM                            " + vbNewLine() + "		PosteDB.dbo.DatiContactPeople                           " + vbNewLine() + "	WHERE                            " + vbNewLine() + "		ntaccount = @user                          " + vbNewLine() + "END                        " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE procedure [dbo].[BSP_sysGetDominio]                           " + vbNewLine() + "	@user as varchar(50)                         " + vbNewLine() + "AS                          " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                            " + vbNewLine() + "		ntdomain                            " + vbNewLine() + "	FROM                            " + vbNewLine() + "		PosteDB.dbo.DatiContactPeople                           " + vbNewLine() + "	WHERE                            " + vbNewLine() + "		ntaccount = @user                          " + vbNewLine() + "END                        " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE procedure [dbo].[BSP_sysGetMenuFunzioni]                            " + vbNewLine() + "--DECLARE            " + vbNewLine() + "	@IDSysProfilo int = null,                            " + vbNewLine() + "	@IDSysModuli varchar(200) = null,                            " + vbNewLine() + "	@Developer bit = 0                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                           " + vbNewLine() + "		F.ID            " + vbNewLine() + "		, F.Descrizione            " + vbNewLine() + "		, ISNULL(F.toolTip,'') ToolTip                            " + vbNewLine() + "		, ISNULL(F.Comando,'') Comando            " + vbNewLine() + "		, F.Image                      " + vbNewLine() + "		, F.IdPadre            " + vbNewLine() + "		, pf.IDSysRuolo            " + vbNewLine() + "		, MIN(pf.idsysprofilo) IDSysprofilo            " + vbNewLine() + "		, f.Ordine                            " + vbNewLine() + "		, f.Auth                   " + vbNewLine() + "		--,*                            " + vbNewLine() + "	FROM sysFunzioni  F                            " + vbNewLine() + "		left join sysProfiliFunzioni PF                            " + vbNewLine() + "			on pf.IDSysFunzione= f.id                             " + vbNewLine() + "				and (pf.IDSysProfilo = @IDSysProfilo or @IDSysProfilo is null)                             " + vbNewLine() + "				and isnull(@Developer,0) = 0                            " + vbNewLine() + "	WHERE                             " + vbNewLine() + "		(f.Auth = 0 or (@Developer = 1 or pf.IDSysProfilo = @IDSysProfilo))                            " + vbNewLine() + "		and f.Attivo = 1                          " + vbNewLine() + "	GROUP BY                           " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ,                            " + vbNewLine() + "		isnull(F.Comando,'') ,                             " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		pf.IDSysRuolo,                            " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth             " + vbNewLine() + "		, F.Image                            " + vbNewLine() + "	ORDER BY                           " + vbNewLine() + "    f.ordine                       " + vbNewLine() + "				                 " + vbNewLine() + "END                         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE procedure [dbo].[BSP_sysGetMenuFunzioni]                            " + vbNewLine() + "--DECLARE            " + vbNewLine() + "	@IDSysProfilo int = null,                            " + vbNewLine() + "	@IDSysModuli varchar(200) = null,                            " + vbNewLine() + "	@Developer bit = 0                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                           " + vbNewLine() + "		F.ID            " + vbNewLine() + "		, F.Descrizione            " + vbNewLine() + "		, ISNULL(F.toolTip,'') ToolTip                            " + vbNewLine() + "		, ISNULL(F.Comando,'') Comando            " + vbNewLine() + "		, F.Image                      " + vbNewLine() + "		, F.IdPadre            " + vbNewLine() + "		, pf.IDSysRuolo            " + vbNewLine() + "		, MIN(pf.idsysprofilo) IDSysprofilo            " + vbNewLine() + "		, f.Ordine                            " + vbNewLine() + "		, f.Auth                   " + vbNewLine() + "		--,*                            " + vbNewLine() + "	FROM sysFunzioni  F                            " + vbNewLine() + "		left join sysProfiliFunzioni PF                            " + vbNewLine() + "			on pf.IDSysFunzione= f.id                             " + vbNewLine() + "				and (pf.IDSysProfilo = @IDSysProfilo or @IDSysProfilo is null)                             " + vbNewLine() + "				and isnull(@Developer,0) = 0                            " + vbNewLine() + "	WHERE                             " + vbNewLine() + "		(f.Auth = 0 or (@Developer = 1 or pf.IDSysProfilo = @IDSysProfilo))                            " + vbNewLine() + "		and f.Attivo = 1                          " + vbNewLine() + "	GROUP BY                           " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ,                            " + vbNewLine() + "		isnull(F.Comando,'') ,                             " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		pf.IDSysRuolo,                            " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth             " + vbNewLine() + "		, F.Image                            " + vbNewLine() + "	ORDER BY                           " + vbNewLine() + "    f.ordine                       " + vbNewLine() + "				                 " + vbNewLine() + "END                         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                          " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysGetMenuFunzioniWP]                            " + vbNewLine() + "--declare                            " + vbNewLine() + "	@idutente int= null                           " + vbNewLine() + "	,@Developer bit = null                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                            " + vbNewLine() + "	select distinct                            " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ToolTip,                            " + vbNewLine() + "		isnull(F.Comando,'') Comando,  " + vbNewLine() + "		F.Image, " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		--NULL AS IDSysRuolo,--pf.IDSysRuolo,                            " + vbNewLine() + "		--NULL AS idsysprofilo,--min(pf.idsysprofilo) idsysprofilo,                            " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth                            " + vbNewLine() + "		--F.IDFunzioneWP                             " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni  F                            " + vbNewLine() + "	inner join autorizzazioni.dbo.funzioni wpf                           " + vbNewLine() + "		on wpf.IdFunzione=f.IDFunzioneWP	                           " + vbNewLine() + "	where                             " + vbNewLine() + "		wpf.Attiva = 'S'                           " + vbNewLine() + "		and wpf.IdFunzione in (                           " + vbNewLine() + "			select fr.IdFunzione                            " + vbNewLine() + "			from Autorizzazioni.dbo.UtentiRuoli ur			                           " + vbNewLine() + "				inner join Autorizzazioni.dbo.FunzioniRuoli fr	                            " + vbNewLine() + "					on ur.idRuolo = fr.IdRuolo                           " + vbNewLine() + "			where ur.idUtente = @idutente                           " + vbNewLine() + "		)                           " + vbNewLine() + "	                           " + vbNewLine() + "	union                           " + vbNewLine() + "                           " + vbNewLine() + "	select distinct                            " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ToolTip,                            " + vbNewLine() + "		isnull(F.Comando,'') Comando,                             " + vbNewLine() + "		F.Image, " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		--NULL AS IDSysRuolo,--pf.IDSysRuolo,             " + vbNewLine() + "		--NULL AS idsysprofilo, --min(pf.idsysprofilo) idsysprofilo,             		                 " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth                            " + vbNewLine() + "		--F.IDFunzioneWP                                 " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni  F                            " + vbNewLine() + "	where f.IdPadre is null                           " + vbNewLine() + "		and f.ID in (                           " + vbNewLine() + "			select f.IdPadre                           " + vbNewLine() + "			from sysFunzioni  F                            " + vbNewLine() + "			inner join autorizzazioni.dbo.funzioni wpf                           " + vbNewLine() + "				on wpf.IdFunzione=f.IDFunzioneWP	                           " + vbNewLine() + "			where                             " + vbNewLine() + "				wpf.Attiva = 'S'                           " + vbNewLine() + "				and wpf.IdFunzione in (                           " + vbNewLine() + "					select fr.IdFunzione                            " + vbNewLine() + "					from Autorizzazioni.dbo.UtentiRuoli ur			                           " + vbNewLine() + "						inner join Autorizzazioni.dbo.FunzioniRuoli fr	                            " + vbNewLine() + "							on ur.idRuolo = fr.IdRuolo                           " + vbNewLine() + "					where ur.idUtente = @idutente                           " + vbNewLine() + "				)						                           " + vbNewLine() + "		)	                           " + vbNewLine() + "	order by ordine ,f.id                            " + vbNewLine() + "END                         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                          " + vbNewLine() + "CREATE procedure [dbo].[BSP_sysGetMenuFunzioniWP]                            " + vbNewLine() + "--declare                            " + vbNewLine() + "	@idutente int= null                           " + vbNewLine() + "	,@Developer bit = null                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                            " + vbNewLine() + "	select distinct                            " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ToolTip,                            " + vbNewLine() + "		isnull(F.Comando,'') Comando,  " + vbNewLine() + "		F.Image, " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		--NULL AS IDSysRuolo,--pf.IDSysRuolo,                            " + vbNewLine() + "		--NULL AS idsysprofilo,--min(pf.idsysprofilo) idsysprofilo,                            " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth                            " + vbNewLine() + "		--F.IDFunzioneWP                             " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni  F                            " + vbNewLine() + "	inner join autorizzazioni.dbo.funzioni wpf                           " + vbNewLine() + "		on wpf.IdFunzione=f.IDFunzioneWP	                           " + vbNewLine() + "	where                             " + vbNewLine() + "		wpf.Attiva = 'S'                           " + vbNewLine() + "		and wpf.IdFunzione in (                           " + vbNewLine() + "			select fr.IdFunzione                            " + vbNewLine() + "			from Autorizzazioni.dbo.UtentiRuoli ur			                           " + vbNewLine() + "				inner join Autorizzazioni.dbo.FunzioniRuoli fr	                            " + vbNewLine() + "					on ur.idRuolo = fr.IdRuolo                           " + vbNewLine() + "			where ur.idUtente = @idutente                           " + vbNewLine() + "		)                           " + vbNewLine() + "	                           " + vbNewLine() + "	union                           " + vbNewLine() + "                           " + vbNewLine() + "	select distinct                            " + vbNewLine() + "		F.ID,                            " + vbNewLine() + "		F.Descrizione,                            " + vbNewLine() + "		isnull(F.toolTip,'') ToolTip,                            " + vbNewLine() + "		isnull(F.Comando,'') Comando,                             " + vbNewLine() + "		F.Image, " + vbNewLine() + "		F.IdPadre,                            " + vbNewLine() + "		--NULL AS IDSysRuolo,--pf.IDSysRuolo,             " + vbNewLine() + "		--NULL AS idsysprofilo, --min(pf.idsysprofilo) idsysprofilo,             		                 " + vbNewLine() + "		f.Ordine,                            " + vbNewLine() + "		f.auth                            " + vbNewLine() + "		--F.IDFunzioneWP                                 " + vbNewLine() + "	from                             " + vbNewLine() + "		sysFunzioni  F                            " + vbNewLine() + "	where f.IdPadre is null                           " + vbNewLine() + "		and f.ID in (                           " + vbNewLine() + "			select f.IdPadre                           " + vbNewLine() + "			from sysFunzioni  F                            " + vbNewLine() + "			inner join autorizzazioni.dbo.funzioni wpf                           " + vbNewLine() + "				on wpf.IdFunzione=f.IDFunzioneWP	                           " + vbNewLine() + "			where                             " + vbNewLine() + "				wpf.Attiva = 'S'                           " + vbNewLine() + "				and wpf.IdFunzione in (                           " + vbNewLine() + "					select fr.IdFunzione                            " + vbNewLine() + "					from Autorizzazioni.dbo.UtentiRuoli ur			                           " + vbNewLine() + "						inner join Autorizzazioni.dbo.FunzioniRuoli fr	                            " + vbNewLine() + "							on ur.idRuolo = fr.IdRuolo                           " + vbNewLine() + "					where ur.idUtente = @idutente                           " + vbNewLine() + "				)						                           " + vbNewLine() + "		)	                           " + vbNewLine() + "	order by ordine ,f.id                            " + vbNewLine() + "END                         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, " " + vbNewLine() + "create procedure [dbo].[BSP_sysGetMnvWP] " + vbNewLine() + "--declare                             " + vbNewLine() + "	@idutente int, " + vbNewLine() + "	@mnvKey as varchar(250)  " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                             " + vbNewLine() + "	select WPF.IdFunzione                    " + vbNewLine() + "	from  	 autorizzazioni.dbo.funzioni wpf                            " + vbNewLine() + "		 inner join Autorizzazioni..FunzioniRuoli fr on fr.IdFunzione = wpf.IdFunzione                            " + vbNewLine() + "		 inner join Autorizzazioni.dbo.UtentiRuoli ur on ur.idRuolo = fr.IdRuolo          " + vbNewLine() + "	where ur.idUtente = @idutente " + vbNewLine() + "		and wpf.DescFunzione = @mnvKey " + vbNewLine() + "		and wpf.Attiva = 'S' " + vbNewLine() + "end " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: << " + vbNewLine() + "create procedure [dbo].[BSP_sysGetMnvWP] " + vbNewLine() + "--declare                             " + vbNewLine() + "	@idutente int, " + vbNewLine() + "	@mnvKey as varchar(250)  " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                             " + vbNewLine() + "	select WPF.IdFunzione                    " + vbNewLine() + "	from  	 autorizzazioni.dbo.funzioni wpf                            " + vbNewLine() + "		 inner join Autorizzazioni..FunzioniRuoli fr on fr.IdFunzione = wpf.IdFunzione                            " + vbNewLine() + "		 inner join Autorizzazioni.dbo.UtentiRuoli ur on ur.idRuolo = fr.IdRuolo          " + vbNewLine() + "	where ur.idUtente = @idutente " + vbNewLine() + "		and wpf.DescFunzione = @mnvKey " + vbNewLine() + "		and wpf.Attiva = 'S' " + vbNewLine() + "end " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysGetToken]                           " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@id as int --= 566                       " + vbNewLine() + "	, @DeleteToken as bit = 1                          " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                           " + vbNewLine() + "		CT.IDUTENTE,                          " + vbNewLine() + "		CT.IDAPPLICAZIONE,                          " + vbNewLine() + "		p.NTAccount,                          " + vbNewLine() + "		p.NTDomain,                      " + vbNewLine() + "		U.idWhereTerr IDWhere,                          " + vbNewLine() + "		U.idWhereArea,                          " + vbNewLine() + "		ta.sqlArea TwhereArea,                          " + vbNewLine() + "		tw.sqlterr TWhere                       " + vbNewLine() + "	    , tw.ID IDVisibilitaTerritoriale                       " + vbNewLine() + "	FROM Autorizzazioni.dbo.ChildAppToken CT                           " + vbNewLine() + "		INNER JOIN Autorizzazioni.dbo.Utenti U                          " + vbNewLine() + "			ON CT.IDUTENTE = U.IDUTENTE                          " + vbNewLine() + "		INNER JOIN Autorizzazioni.dbo.UtentiPadre UP                          " + vbNewLine() + "			ON U.IDUtenteP = UP.IDUtenteP                          " + vbNewLine() + "		INNER JOIN BIPoste.DBO.VISIBILITATERRITORIALI TW                          " + vbNewLine() + "			ON tw.IDTWhere = u.idWhereterr                          " + vbNewLine() + "		INNER JOIN Autorizzazioni.DBO.TWhereAree TA                          " + vbNewLine() + "			ON ta.idWArea = u.idWherearea                          " + vbNewLine() + "		INNER JOIN BIPoste..Personale p                       " + vbNewLine() + "			ON up.Matricola = p.Matricola  --sostituire con idpersonale dopo aver rifatto webpers                       " + vbNewLine() + "	WHERE CT.ID = @id                           " + vbNewLine() + "                           " + vbNewLine() + "	-- ELIMINO RECORD DALLA TABELLA CHILDAPPTOKEN --                           " + vbNewLine() + "	if @DeleteToken = 1 begin                          " + vbNewLine() + "		delete from Autorizzazioni.dbo.ChildAppToken                            " + vbNewLine() + "		where Id=@id                           " + vbNewLine() + "	end                           " + vbNewLine() + "                         " + vbNewLine() + "END		                         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysGetToken]                           " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@id as int --= 566                       " + vbNewLine() + "	, @DeleteToken as bit = 1                          " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SELECT                           " + vbNewLine() + "		CT.IDUTENTE,                          " + vbNewLine() + "		CT.IDAPPLICAZIONE,                          " + vbNewLine() + "		p.NTAccount,                          " + vbNewLine() + "		p.NTDomain,                      " + vbNewLine() + "		U.idWhereTerr IDWhere,                          " + vbNewLine() + "		U.idWhereArea,                          " + vbNewLine() + "		ta.sqlArea TwhereArea,                          " + vbNewLine() + "		tw.sqlterr TWhere                       " + vbNewLine() + "	    , tw.ID IDVisibilitaTerritoriale                       " + vbNewLine() + "	FROM Autorizzazioni.dbo.ChildAppToken CT                           " + vbNewLine() + "		INNER JOIN Autorizzazioni.dbo.Utenti U                          " + vbNewLine() + "			ON CT.IDUTENTE = U.IDUTENTE                          " + vbNewLine() + "		INNER JOIN Autorizzazioni.dbo.UtentiPadre UP                          " + vbNewLine() + "			ON U.IDUtenteP = UP.IDUtenteP                          " + vbNewLine() + "		INNER JOIN BIPoste.DBO.VISIBILITATERRITORIALI TW                          " + vbNewLine() + "			ON tw.IDTWhere = u.idWhereterr                          " + vbNewLine() + "		INNER JOIN Autorizzazioni.DBO.TWhereAree TA                          " + vbNewLine() + "			ON ta.idWArea = u.idWherearea                          " + vbNewLine() + "		INNER JOIN BIPoste..Personale p                       " + vbNewLine() + "			ON up.Matricola = p.Matricola  --sostituire con idpersonale dopo aver rifatto webpers                       " + vbNewLine() + "	WHERE CT.ID = @id                           " + vbNewLine() + "                           " + vbNewLine() + "	-- ELIMINO RECORD DALLA TABELLA CHILDAPPTOKEN --                           " + vbNewLine() + "	if @DeleteToken = 1 begin                          " + vbNewLine() + "		delete from Autorizzazioni.dbo.ChildAppToken                            " + vbNewLine() + "		where Id=@id                           " + vbNewLine() + "	end                           " + vbNewLine() + "                         " + vbNewLine() + "END		                         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysGetToken_NewWP]                          " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@id as int --= 316                       " + vbNewLine() + "	, @DeleteToken as bit = 1                          " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	   select c.IdUtente, " + vbNewLine() + "			c.idapplicazione as [IDApplicazione], " + vbNewLine() + "			p.NTAccount,  " + vbNewLine() + "			c.IdWhere [IDWhere],  " + vbNewLine() + "			-1 [idWhereArea],  " + vbNewLine() + "			'' TwhereArea,  " + vbNewLine() + "			tw.sqlterr TWhere,  " + vbNewLine() + "			tw.ID IDVisibilitaTerritoriale, " + vbNewLine() + "			c.IDJobRole as [IDJobRole], " + vbNewLine() + "			c.IDProfilo as IDSysProfilo, " + vbNewLine() + "			NTDomain " + vbNewLine() + " " + vbNewLine() + "		from WebPers.dbo.ChildAppToken c " + vbNewLine() + "			inner join BIPoste..Personale p on c.IDPersona = p.id " + vbNewLine() + "			inner join BIPoste.DBO.VISIBILITATERRITORIALI TW ON tw.ID = c.idwhere " + vbNewLine() + "		WHERE C.ID = @id    " + vbNewLine() + " " + vbNewLine() + "                           " + vbNewLine() + "	-- ELIMINO RECORD DALLA TABELLA CHILDAPPTOKEN --                           " + vbNewLine() + "	if @DeleteToken = 1 begin                          " + vbNewLine() + "		delete from Autorizzazioni.dbo.ChildAppToken                            " + vbNewLine() + "		where Id=@id                           " + vbNewLine() + "	end                           " + vbNewLine() + "                         " + vbNewLine() + "END		               " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysGetToken_NewWP]                          " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@id as int --= 316                       " + vbNewLine() + "	, @DeleteToken as bit = 1                          " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	   select c.IdUtente, " + vbNewLine() + "			c.idapplicazione as [IDApplicazione], " + vbNewLine() + "			p.NTAccount,  " + vbNewLine() + "			c.IdWhere [IDWhere],  " + vbNewLine() + "			-1 [idWhereArea],  " + vbNewLine() + "			'' TwhereArea,  " + vbNewLine() + "			tw.sqlterr TWhere,  " + vbNewLine() + "			tw.ID IDVisibilitaTerritoriale, " + vbNewLine() + "			c.IDJobRole as [IDJobRole], " + vbNewLine() + "			c.IDProfilo as IDSysProfilo, " + vbNewLine() + "			NTDomain " + vbNewLine() + " " + vbNewLine() + "		from WebPers.dbo.ChildAppToken c " + vbNewLine() + "			inner join BIPoste..Personale p on c.IDPersona = p.id " + vbNewLine() + "			inner join BIPoste.DBO.VISIBILITATERRITORIALI TW ON tw.ID = c.idwhere " + vbNewLine() + "		WHERE C.ID = @id    " + vbNewLine() + " " + vbNewLine() + "                           " + vbNewLine() + "	-- ELIMINO RECORD DALLA TABELLA CHILDAPPTOKEN --                           " + vbNewLine() + "	if @DeleteToken = 1 begin                          " + vbNewLine() + "		delete from Autorizzazioni.dbo.ChildAppToken                            " + vbNewLine() + "		where Id=@id                           " + vbNewLine() + "	end                           " + vbNewLine() + "                         " + vbNewLine() + "END		               " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLine_DELETE         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLine        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLine_DELETE         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLine        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLine_INSERT         " + vbNewLine() + "  @Descrizione AS nvarchar(200)        " + vbNewLine() + "  ,@Body AS nvarchar(MAX)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  INSERT INTO sysHelpOnLine (         " + vbNewLine() + "    Descrizione        " + vbNewLine() + "    ,Body        " + vbNewLine() + "  ) VALUES (        " + vbNewLine() + "    @Descrizione        " + vbNewLine() + "    ,@Body        " + vbNewLine() + "  )         " + vbNewLine() + "        " + vbNewLine() + "SELECT @@IDENTITY        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLine_INSERT         " + vbNewLine() + "  @Descrizione AS nvarchar(200)        " + vbNewLine() + "  ,@Body AS nvarchar(MAX)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  INSERT INTO sysHelpOnLine (         " + vbNewLine() + "    Descrizione        " + vbNewLine() + "    ,Body        " + vbNewLine() + "  ) VALUES (        " + vbNewLine() + "    @Descrizione        " + vbNewLine() + "    ,@Body        " + vbNewLine() + "  )         " + vbNewLine() + "        " + vbNewLine() + "SELECT @@IDENTITY        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLine_SEARCH         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL         " + vbNewLine() + "  ,@Body AS NVARCHAR(MAX) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE        " + vbNewLine() + "  SELECT Me.*         " + vbNewLine() + "  FROM sysHelpOnLine Me WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)         " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')         " + vbNewLine() + "    AND  (@Body IS NULL OR Me.Body LIKE @Body + '%')         " + vbNewLine() + "        " + vbNewLine() + "OPTION(RECOMPILE)         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLine_SEARCH         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL         " + vbNewLine() + "  ,@Body AS NVARCHAR(MAX) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE        " + vbNewLine() + "  SELECT Me.*         " + vbNewLine() + "  FROM sysHelpOnLine Me WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)         " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')         " + vbNewLine() + "    AND  (@Body IS NULL OR Me.Body LIKE @Body + '%')         " + vbNewLine() + "        " + vbNewLine() + "OPTION(RECOMPILE)         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLine_SELECT         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [ID]        " + vbNewLine() + "    , [Descrizione]        " + vbNewLine() + "    , [Body]        " + vbNewLine() + "  FROM sysHelpOnLine WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLine_SELECT         " + vbNewLine() + "  @ID AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [ID]        " + vbNewLine() + "    , [Descrizione]        " + vbNewLine() + "    , [Body]        " + vbNewLine() + "  FROM sysHelpOnLine WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLine_UPDATE         " + vbNewLine() + "  @ID AS int = NULL        " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)        " + vbNewLine() + "  ,@Body AS nvarchar(MAX)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  UPDATE sysHelpOnLine        " + vbNewLine() + "    SET         " + vbNewLine() + "      Descrizione =  @Descrizione        " + vbNewLine() + "      , Body =  @Body        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLine_UPDATE         " + vbNewLine() + "  @ID AS int = NULL        " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)        " + vbNewLine() + "  ,@Body AS nvarchar(MAX)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  UPDATE sysHelpOnLine        " + vbNewLine() + "    SET         " + vbNewLine() + "      Descrizione =  @Descrizione        " + vbNewLine() + "      , Body =  @Body        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    ID = @ID        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_DELETE         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS nvarchar(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLineFunzioni        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "    AND IDsysFunzione = @IDsysFunzione        " + vbNewLine() + "    AND Parametro = @Parametro        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_DELETE         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS nvarchar(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLineFunzioni        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "    AND IDsysFunzione = @IDsysFunzione        " + vbNewLine() + "    AND Parametro = @Parametro        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_DELETEALL         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLineFunzioni        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_DELETEALL         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  DELETE FROM sysHelpOnLineFunzioni        " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_INSERT         " + vbNewLine() + "  @IDsysHelpOnLine AS int        " + vbNewLine() + "  ,@IDsysFunzione AS int        " + vbNewLine() + "  ,@Parametro AS nvarchar(20)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  INSERT INTO sysHelpOnLineFunzioni (         " + vbNewLine() + "    IDsysHelpOnLine        " + vbNewLine() + "    ,IDsysFunzione        " + vbNewLine() + "    ,Parametro        " + vbNewLine() + "  ) VALUES (        " + vbNewLine() + "    @IDsysHelpOnLine        " + vbNewLine() + "    ,@IDsysFunzione        " + vbNewLine() + "    ,@Parametro        " + vbNewLine() + "  )         " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_INSERT         " + vbNewLine() + "  @IDsysHelpOnLine AS int        " + vbNewLine() + "  ,@IDsysFunzione AS int        " + vbNewLine() + "  ,@Parametro AS nvarchar(20)        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  INSERT INTO sysHelpOnLineFunzioni (         " + vbNewLine() + "    IDsysHelpOnLine        " + vbNewLine() + "    ,IDsysFunzione        " + vbNewLine() + "    ,Parametro        " + vbNewLine() + "  ) VALUES (        " + vbNewLine() + "    @IDsysHelpOnLine        " + vbNewLine() + "    ,@IDsysFunzione        " + vbNewLine() + "    ,@Parametro        " + vbNewLine() + "  )         " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SEARCH         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS NVARCHAR(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE        " + vbNewLine() + "  SELECT Me.*         " + vbNewLine() + "  FROM sysHelpOnLineFunzioni Me WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "     (@IDsysHelpOnLine IS NULL OR Me.IDsysHelpOnLine = @IDsysHelpOnLine)         " + vbNewLine() + "    AND  (@IDsysFunzione IS NULL OR Me.IDsysFunzione = @IDsysFunzione)         " + vbNewLine() + "    AND  (@Parametro IS NULL OR Me.Parametro = @Parametro)         " + vbNewLine() + "        " + vbNewLine() + "OPTION(RECOMPILE)         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SEARCH         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS NVARCHAR(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE        " + vbNewLine() + "  SELECT Me.*         " + vbNewLine() + "  FROM sysHelpOnLineFunzioni Me WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "     (@IDsysHelpOnLine IS NULL OR Me.IDsysHelpOnLine = @IDsysHelpOnLine)         " + vbNewLine() + "    AND  (@IDsysFunzione IS NULL OR Me.IDsysFunzione = @IDsysFunzione)         " + vbNewLine() + "    AND  (@Parametro IS NULL OR Me.Parametro = @Parametro)         " + vbNewLine() + "        " + vbNewLine() + "OPTION(RECOMPILE)         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SELECT         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS NVARCHAR(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [IDsysHelpOnLine]        " + vbNewLine() + "    , [IDsysFunzione]        " + vbNewLine() + "    , [Parametro]        " + vbNewLine() + "  FROM sysHelpOnLineFunzioni WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "    AND IDsysFunzione = @IDsysFunzione        " + vbNewLine() + "    AND Parametro = @Parametro        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SELECT         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL         " + vbNewLine() + "  ,@Parametro AS NVARCHAR(20) = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [IDsysHelpOnLine]        " + vbNewLine() + "    , [IDsysFunzione]        " + vbNewLine() + "    , [Parametro]        " + vbNewLine() + "  FROM sysHelpOnLineFunzioni WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "    AND IDsysFunzione = @IDsysFunzione        " + vbNewLine() + "    AND Parametro = @Parametro        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SELECTALL         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [IDsysHelpOnLine]        " + vbNewLine() + "    , [IDsysFunzione]        " + vbNewLine() + "    , [Parametro]        " + vbNewLine() + "  FROM sysHelpOnLineFunzioni WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_SELECTALL         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL         " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "  SELECT         " + vbNewLine() + "    [IDsysHelpOnLine]        " + vbNewLine() + "    , [IDsysFunzione]        " + vbNewLine() + "    , [Parametro]        " + vbNewLine() + "  FROM sysHelpOnLineFunzioni WITH(NOLOCK)         " + vbNewLine() + "  WHERE         " + vbNewLine() + "    IDsysHelpOnLine = @IDsysHelpOnLine        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_UPDATE         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL        " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL        " + vbNewLine() + "  ,@Parametro AS nvarchar(20) = NULL        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.        " + vbNewLine() + "RETURN 0        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysHelpOnLineFunzioni_UPDATE         " + vbNewLine() + "  @IDsysHelpOnLine AS int = NULL        " + vbNewLine() + "  ,@IDsysFunzione AS int = NULL        " + vbNewLine() + "  ,@Parametro AS nvarchar(20) = NULL        " + vbNewLine() + " AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.        " + vbNewLine() + "RETURN 0        " + vbNewLine() + "         " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysImportFiles_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysImportFiles   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysImportFiles_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysImportFiles   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysImportFiles_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@NomeFile AS nvarchar(MAX)   " + vbNewLine() + "  ,@ContentFile AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@RowHeader AS nvarchar(MAX)   " + vbNewLine() + "  ,@NomeTblImport AS nvarchar(50)   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataInizioImport AS datetime   " + vbNewLine() + "  ,@DataFineImport AS datetime   " + vbNewLine() + "  ,@DataChiusura AS datetime   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysImportFiles (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,NomeFile   " + vbNewLine() + "    ,ContentFile   " + vbNewLine() + "    ,RowHeader   " + vbNewLine() + "    ,NomeTblImport   " + vbNewLine() + "    ,DataCreazione   " + vbNewLine() + "    ,DataInizioImport   " + vbNewLine() + "    ,DataFineImport   " + vbNewLine() + "    ,DataChiusura   " + vbNewLine() + "    ,IDSysUtente   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@NomeFile   " + vbNewLine() + "    ,@ContentFile   " + vbNewLine() + "    ,@RowHeader   " + vbNewLine() + "    ,@NomeTblImport   " + vbNewLine() + "    ,@DataCreazione   " + vbNewLine() + "    ,@DataInizioImport   " + vbNewLine() + "    ,@DataFineImport   " + vbNewLine() + "    ,@DataChiusura   " + vbNewLine() + "    ,@IDSysUtente   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysImportFiles_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@NomeFile AS nvarchar(MAX)   " + vbNewLine() + "  ,@ContentFile AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@RowHeader AS nvarchar(MAX)   " + vbNewLine() + "  ,@NomeTblImport AS nvarchar(50)   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataInizioImport AS datetime   " + vbNewLine() + "  ,@DataFineImport AS datetime   " + vbNewLine() + "  ,@DataChiusura AS datetime   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysImportFiles (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,NomeFile   " + vbNewLine() + "    ,ContentFile   " + vbNewLine() + "    ,RowHeader   " + vbNewLine() + "    ,NomeTblImport   " + vbNewLine() + "    ,DataCreazione   " + vbNewLine() + "    ,DataInizioImport   " + vbNewLine() + "    ,DataFineImport   " + vbNewLine() + "    ,DataChiusura   " + vbNewLine() + "    ,IDSysUtente   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@NomeFile   " + vbNewLine() + "    ,@ContentFile   " + vbNewLine() + "    ,@RowHeader   " + vbNewLine() + "    ,@NomeTblImport   " + vbNewLine() + "    ,@DataCreazione   " + vbNewLine() + "    ,@DataInizioImport   " + vbNewLine() + "    ,@DataFineImport   " + vbNewLine() + "    ,@DataChiusura   " + vbNewLine() + "    ,@IDSysUtente   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysImportFiles_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@NomeFile AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@RowHeader AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@NomeTblImport AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@DataCreazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCreazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioImportDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioImportAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineImportDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineImportAl AS datetime = NULL    " + vbNewLine() + "  ,@DataChiusuraDal AS datetime = NULL    " + vbNewLine() + "  ,@DataChiusuraAl AS datetime = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysImportFiles Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@NomeFile IS NULL OR Me.NomeFile LIKE @NomeFile + '%')    " + vbNewLine() + "    AND  (@RowHeader IS NULL OR Me.RowHeader LIKE @RowHeader + '%')    " + vbNewLine() + "    AND  (@NomeTblImport IS NULL OR Me.NomeTblImport LIKE @NomeTblImport + '%')    " + vbNewLine() + "    AND  (@DataCreazioneDal IS NULL OR Me.DataCreazione >= @DataCreazioneDal)    " + vbNewLine() + "    AND  (@DataCreazioneAl IS NULL OR Me.DataCreazione <= @DataCreazioneAl)    " + vbNewLine() + "    AND  (@DataInizioImportDal IS NULL OR Me.DataInizioImport >= @DataInizioImportDal)    " + vbNewLine() + "    AND  (@DataInizioImportAl IS NULL OR Me.DataInizioImport <= @DataInizioImportAl)    " + vbNewLine() + "    AND  (@DataFineImportDal IS NULL OR Me.DataFineImport >= @DataFineImportDal)    " + vbNewLine() + "    AND  (@DataFineImportAl IS NULL OR Me.DataFineImport <= @DataFineImportAl)    " + vbNewLine() + "    AND  (@DataChiusuraDal IS NULL OR Me.DataChiusura >= @DataChiusuraDal)    " + vbNewLine() + "    AND  (@DataChiusuraAl IS NULL OR Me.DataChiusura <= @DataChiusuraAl)    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysImportFiles_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@NomeFile AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@RowHeader AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@NomeTblImport AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@DataCreazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCreazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioImportDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioImportAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineImportDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineImportAl AS datetime = NULL    " + vbNewLine() + "  ,@DataChiusuraDal AS datetime = NULL    " + vbNewLine() + "  ,@DataChiusuraAl AS datetime = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysImportFiles Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@NomeFile IS NULL OR Me.NomeFile LIKE @NomeFile + '%')    " + vbNewLine() + "    AND  (@RowHeader IS NULL OR Me.RowHeader LIKE @RowHeader + '%')    " + vbNewLine() + "    AND  (@NomeTblImport IS NULL OR Me.NomeTblImport LIKE @NomeTblImport + '%')    " + vbNewLine() + "    AND  (@DataCreazioneDal IS NULL OR Me.DataCreazione >= @DataCreazioneDal)    " + vbNewLine() + "    AND  (@DataCreazioneAl IS NULL OR Me.DataCreazione <= @DataCreazioneAl)    " + vbNewLine() + "    AND  (@DataInizioImportDal IS NULL OR Me.DataInizioImport >= @DataInizioImportDal)    " + vbNewLine() + "    AND  (@DataInizioImportAl IS NULL OR Me.DataInizioImport <= @DataInizioImportAl)    " + vbNewLine() + "    AND  (@DataFineImportDal IS NULL OR Me.DataFineImport >= @DataFineImportDal)    " + vbNewLine() + "    AND  (@DataFineImportAl IS NULL OR Me.DataFineImport <= @DataFineImportAl)    " + vbNewLine() + "    AND  (@DataChiusuraDal IS NULL OR Me.DataChiusura >= @DataChiusuraDal)    " + vbNewLine() + "    AND  (@DataChiusuraAl IS NULL OR Me.DataChiusura <= @DataChiusuraAl)    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysImportFiles_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [NomeFile]   " + vbNewLine() + "    , [ContentFile]   " + vbNewLine() + "    , [RowHeader]   " + vbNewLine() + "    , [NomeTblImport]   " + vbNewLine() + "    , [DataCreazione]   " + vbNewLine() + "    , [DataInizioImport]   " + vbNewLine() + "    , [DataFineImport]   " + vbNewLine() + "    , [DataChiusura]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "  FROM sysImportFiles WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysImportFiles_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [NomeFile]   " + vbNewLine() + "    , [ContentFile]   " + vbNewLine() + "    , [RowHeader]   " + vbNewLine() + "    , [NomeTblImport]   " + vbNewLine() + "    , [DataCreazione]   " + vbNewLine() + "    , [DataInizioImport]   " + vbNewLine() + "    , [DataFineImport]   " + vbNewLine() + "    , [DataChiusura]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "  FROM sysImportFiles WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysImportFiles_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@NomeFile AS nvarchar(MAX)   " + vbNewLine() + "  ,@ContentFile AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@RowHeader AS nvarchar(MAX)   " + vbNewLine() + "  ,@NomeTblImport AS nvarchar(50)   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataInizioImport AS datetime   " + vbNewLine() + "  ,@DataFineImport AS datetime   " + vbNewLine() + "  ,@DataChiusura AS datetime   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysImportFiles   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , NomeFile =  @NomeFile   " + vbNewLine() + "      , ContentFile =  @ContentFile   " + vbNewLine() + "      , RowHeader =  @RowHeader   " + vbNewLine() + "      , NomeTblImport =  @NomeTblImport   " + vbNewLine() + "      , DataCreazione =  @DataCreazione   " + vbNewLine() + "      , DataInizioImport =  @DataInizioImport   " + vbNewLine() + "      , DataFineImport =  @DataFineImport   " + vbNewLine() + "      , DataChiusura =  @DataChiusura   " + vbNewLine() + "      , IDSysUtente =  @IDSysUtente   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysImportFiles_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@NomeFile AS nvarchar(MAX)   " + vbNewLine() + "  ,@ContentFile AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@RowHeader AS nvarchar(MAX)   " + vbNewLine() + "  ,@NomeTblImport AS nvarchar(50)   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataInizioImport AS datetime   " + vbNewLine() + "  ,@DataFineImport AS datetime   " + vbNewLine() + "  ,@DataChiusura AS datetime   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysImportFiles   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , NomeFile =  @NomeFile   " + vbNewLine() + "      , ContentFile =  @ContentFile   " + vbNewLine() + "      , RowHeader =  @RowHeader   " + vbNewLine() + "      , NomeTblImport =  @NomeTblImport   " + vbNewLine() + "      , DataCreazione =  @DataCreazione   " + vbNewLine() + "      , DataInizioImport =  @DataInizioImport   " + vbNewLine() + "      , DataFineImport =  @DataFineImport   " + vbNewLine() + "      , DataChiusura =  @DataChiusura   " + vbNewLine() + "      , IDSysUtente =  @IDSysUtente   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysLog_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysLog   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysLog_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysLog   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysLog_DELETEALL]                   " + vbNewLine() + "AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  DELETE FROM sysLog                  " + vbNewLine() + "END                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysLog_DELETEALL]                   " + vbNewLine() + "AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  DELETE FROM sysLog                  " + vbNewLine() + "END                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysLog_INSERT    " + vbNewLine() + "  @IDSysAccesso AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Origine AS nvarchar(MAX)   " + vbNewLine() + "  ,@Messaggio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysSeverity AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysLog (    " + vbNewLine() + "    IDSysAccesso   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Origine   " + vbNewLine() + "    ,Messaggio   " + vbNewLine() + "    ,IDSysSeverity   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysAccesso   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Origine   " + vbNewLine() + "    ,@Messaggio   " + vbNewLine() + "    ,@IDSysSeverity   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysLog_INSERT    " + vbNewLine() + "  @IDSysAccesso AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Origine AS nvarchar(MAX)   " + vbNewLine() + "  ,@Messaggio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysSeverity AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysLog (    " + vbNewLine() + "    IDSysAccesso   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Origine   " + vbNewLine() + "    ,Messaggio   " + vbNewLine() + "    ,IDSysSeverity   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysAccesso   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Origine   " + vbNewLine() + "    ,@Messaggio   " + vbNewLine() + "    ,@IDSysSeverity   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysLog_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysAccesso AS int = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Origine AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@Messaggio AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDSysSeverity AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysAccessi.IDSysUtente SysAccesso   " + vbNewLine() + "    , sysSeverity.Descrizione SysSeverity   " + vbNewLine() + "  FROM sysLog Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysAccessi sysAccessi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysAccesso = sysAccessi.ID   " + vbNewLine() + "    LEFT JOIN sysSeverity sysSeverity WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSeverity = sysSeverity.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysAccesso IS NULL OR Me.IDSysAccesso = @IDSysAccesso)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Origine IS NULL OR Me.Origine LIKE @Origine + '%')    " + vbNewLine() + "    AND  (@Messaggio IS NULL OR Me.Messaggio LIKE @Messaggio + '%')    " + vbNewLine() + "    AND  (@IDSysSeverity IS NULL OR Me.IDSysSeverity = @IDSysSeverity)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysLog_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDSysAccesso AS int = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Origine AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@Messaggio AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDSysSeverity AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysAccessi.IDSysUtente SysAccesso   " + vbNewLine() + "    , sysSeverity.Descrizione SysSeverity   " + vbNewLine() + "  FROM sysLog Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysAccessi sysAccessi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysAccesso = sysAccessi.ID   " + vbNewLine() + "    LEFT JOIN sysSeverity sysSeverity WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSeverity = sysSeverity.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDSysAccesso IS NULL OR Me.IDSysAccesso = @IDSysAccesso)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Origine IS NULL OR Me.Origine LIKE @Origine + '%')    " + vbNewLine() + "    AND  (@Messaggio IS NULL OR Me.Messaggio LIKE @Messaggio + '%')    " + vbNewLine() + "    AND  (@IDSysSeverity IS NULL OR Me.IDSysSeverity = @IDSysSeverity)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysLog_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Origine]   " + vbNewLine() + "    , [Messaggio]   " + vbNewLine() + "    , [IDSysSeverity]   " + vbNewLine() + "  FROM sysLog WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysLog_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDSysAccesso]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Origine]   " + vbNewLine() + "    , [Messaggio]   " + vbNewLine() + "    , [IDSysSeverity]   " + vbNewLine() + "  FROM sysLog WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysLog_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysAccesso AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Origine AS nvarchar(MAX)   " + vbNewLine() + "  ,@Messaggio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysSeverity AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysLog   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysAccesso =  @IDSysAccesso   " + vbNewLine() + "      , Data =  @Data   " + vbNewLine() + "      , Origine =  @Origine   " + vbNewLine() + "      , Messaggio =  @Messaggio   " + vbNewLine() + "      , IDSysSeverity =  @IDSysSeverity   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysLog_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDSysAccesso AS int   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Origine AS nvarchar(MAX)   " + vbNewLine() + "  ,@Messaggio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysSeverity AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysLog   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysAccesso =  @IDSysAccesso   " + vbNewLine() + "      , Data =  @Data   " + vbNewLine() + "      , Origine =  @Origine   " + vbNewLine() + "      , Messaggio =  @Messaggio   " + vbNewLine() + "      , IDSysSeverity =  @IDSysSeverity   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysMail_ACTIVE]                           " + vbNewLine() + "	@ACTIVE BIT = 1,                           " + vbNewLine() + "	@STATE BIT = 0                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	-- ABILITAZIONE SQL                           " + vbNewLine() + "	exec sp_configure 'show advanced options', 1;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	IF (@STATE = 0) BEGIN                           " + vbNewLine() + "		exec sp_configure 'Database Mail XPs', @ACTIVE;                           " + vbNewLine() + "	END ELSE BEGIN                           " + vbNewLine() + "		exec sp_configure 'Database Mail XPs';                           " + vbNewLine() + "	END                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "	exec sp_configure 'show advanced options', 0;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "END                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysMail_ACTIVE]                           " + vbNewLine() + "	@ACTIVE BIT = 1,                           " + vbNewLine() + "	@STATE BIT = 0                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	-- ABILITAZIONE SQL                           " + vbNewLine() + "	exec sp_configure 'show advanced options', 1;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	IF (@STATE = 0) BEGIN                           " + vbNewLine() + "		exec sp_configure 'Database Mail XPs', @ACTIVE;                           " + vbNewLine() + "	END ELSE BEGIN                           " + vbNewLine() + "		exec sp_configure 'Database Mail XPs';                           " + vbNewLine() + "	END                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "	exec sp_configure 'show advanced options', 0;                           " + vbNewLine() + "	--GO                           " + vbNewLine() + "	RECONFIGURE;                           " + vbNewLine() + "END                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysMail_DELETE]                           " + vbNewLine() + "	@NOMEPROFILO varchar(50) = 'BArtsFramework',                           " + vbNewLine() + "	@NomeAccount varchar(50)                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	--RIMOZIONE PROFILO                           " + vbNewLine() + "	exec msdb.dbo.sysmail_delete_account_sp @account_name = @NomeAccount                           " + vbNewLine() + "	exec msdb.dbo.sysmail_delete_profile_sp @profile_name = @NOMEPROFILO                           " + vbNewLine() + "END                           " + vbNewLine() + "                           " + vbNewLine() + "	                           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysMail_DELETE]                           " + vbNewLine() + "	@NOMEPROFILO varchar(50) = 'BArtsFramework',                           " + vbNewLine() + "	@NomeAccount varchar(50)                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	--RIMOZIONE PROFILO                           " + vbNewLine() + "	exec msdb.dbo.sysmail_delete_account_sp @account_name = @NomeAccount                           " + vbNewLine() + "	exec msdb.dbo.sysmail_delete_profile_sp @profile_name = @NOMEPROFILO                           " + vbNewLine() + "END                           " + vbNewLine() + "                           " + vbNewLine() + "	                           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                           " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysMail_INSERT]                           " + vbNewLine() + "	@NOMEPROFILO varchar(50) = 'BArtsFramework',                           " + vbNewLine() + "	@DESCRIZIONEPROFILO varchar(256) = 'Profilo per l''invio delle email tramite SQL',                            " + vbNewLine() + "	@NomeAccount varchar(50),                           " + vbNewLine() + "	@DescrizioneAccount varchar(128),                            " + vbNewLine() + "	@EmailAccount varchar(128),                             " + vbNewLine() + "	@AliasEmailAccount varchar(128),                             " + vbNewLine() + "	@ReplyTo varchar(128),                            " + vbNewLine() + "	@SMTPServer varchar(50),                            " + vbNewLine() + "	@SMTPPort int = 25,                           " + vbNewLine() + "	@SMTPUsername varchar(128),                            " + vbNewLine() + "	@SMTPPassword varchar(128),                            " + vbNewLine() + "	@SMTPSSL bit  = 0                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "                           " + vbNewLine() + "	BEGIN TRAN                           " + vbNewLine() + "	--AGGIUNTA PROFILO                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_profile_sp                           " + vbNewLine() + "		@NOMEPROFILO,                            " + vbNewLine() + "		@DESCRIZIONEPROFILO                           " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_account_sp                               " + vbNewLine() + "		@NomeAccount,                            " + vbNewLine() + "		@EmailAccount,                            " + vbNewLine() + "		@AliasEmailAccount,                             " + vbNewLine() + "		@ReplyTo,                            " + vbNewLine() + "		@DescrizioneAccount,                            " + vbNewLine() + "		@SMTPServer,                            " + vbNewLine() + "		'SMTP',                            " + vbNewLine() + "		@SMTPPort,                            " + vbNewLine() + "		@SMTPUsername,                           " + vbNewLine() + "		@SMTPPassword,                           " + vbNewLine() + "		0,                           " + vbNewLine() + "		@SMTPSSL		                            " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_profileaccount_sp                            " + vbNewLine() + "		@profile_name = @NOMEPROFILO,                             " + vbNewLine() + "		@account_name = @NomeAccount,                            " + vbNewLine() + "		@sequence_number = 1                           " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "                           " + vbNewLine() + "	COMMIT TRAN                           " + vbNewLine() + "END                           " + vbNewLine() + "                           " + vbNewLine() + "	                           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                           " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysMail_INSERT]                           " + vbNewLine() + "	@NOMEPROFILO varchar(50) = 'BArtsFramework',                           " + vbNewLine() + "	@DESCRIZIONEPROFILO varchar(256) = 'Profilo per l''invio delle email tramite SQL',                            " + vbNewLine() + "	@NomeAccount varchar(50),                           " + vbNewLine() + "	@DescrizioneAccount varchar(128),                            " + vbNewLine() + "	@EmailAccount varchar(128),                             " + vbNewLine() + "	@AliasEmailAccount varchar(128),                             " + vbNewLine() + "	@ReplyTo varchar(128),                            " + vbNewLine() + "	@SMTPServer varchar(50),                            " + vbNewLine() + "	@SMTPPort int = 25,                           " + vbNewLine() + "	@SMTPUsername varchar(128),                            " + vbNewLine() + "	@SMTPPassword varchar(128),                            " + vbNewLine() + "	@SMTPSSL bit  = 0                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "                           " + vbNewLine() + "	BEGIN TRAN                           " + vbNewLine() + "	--AGGIUNTA PROFILO                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_profile_sp                           " + vbNewLine() + "		@NOMEPROFILO,                            " + vbNewLine() + "		@DESCRIZIONEPROFILO                           " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_account_sp                               " + vbNewLine() + "		@NomeAccount,                            " + vbNewLine() + "		@EmailAccount,                            " + vbNewLine() + "		@AliasEmailAccount,                             " + vbNewLine() + "		@ReplyTo,                            " + vbNewLine() + "		@DescrizioneAccount,                            " + vbNewLine() + "		@SMTPServer,                            " + vbNewLine() + "		'SMTP',                            " + vbNewLine() + "		@SMTPPort,                            " + vbNewLine() + "		@SMTPUsername,                           " + vbNewLine() + "		@SMTPPassword,                           " + vbNewLine() + "		0,                           " + vbNewLine() + "		@SMTPSSL		                            " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "	exec msdb.dbo.sysmail_add_profileaccount_sp                            " + vbNewLine() + "		@profile_name = @NOMEPROFILO,                             " + vbNewLine() + "		@account_name = @NomeAccount,                            " + vbNewLine() + "		@sequence_number = 1                           " + vbNewLine() + "	IF @@ERROR<> 0 BEGIN                           " + vbNewLine() + "		ROLLBACK TRAN                           " + vbNewLine() + "		RETURN                           " + vbNewLine() + "	END                           " + vbNewLine() + "                           " + vbNewLine() + "	COMMIT TRAN                           " + vbNewLine() + "END                           " + vbNewLine() + "                           " + vbNewLine() + "	                           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysMail_SELECT                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	SELECT                            " + vbNewLine() + "		p.profile_id ID,                           " + vbNewLine() + "		p.name NomeProfilo,                            " + vbNewLine() + "		a.name NomeAccount,                           " + vbNewLine() + "		a.description Descrizione,                           " + vbNewLine() + "		a.email_address Email,                           " + vbNewLine() + "		a.display_name DisplayName,                           " + vbNewLine() + "		a.replyto_address ReplyTo                           " + vbNewLine() + "	FROM msdb.dbo.sysmail_profile p                           " + vbNewLine() + "		inner join msdb.dbo.sysmail_profileaccount pa                           " + vbNewLine() + "			on p.profile_id = pa.profile_id                           " + vbNewLine() + "		inner join msdb.dbo.sysmail_account a                           " + vbNewLine() + "			on pa.account_id= a.account_id                           " + vbNewLine() + "	ORDER BY P.NAME, A.name                           " + vbNewLine() + "END                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysMail_SELECT                           " + vbNewLine() + "AS                           " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	SELECT                            " + vbNewLine() + "		p.profile_id ID,                           " + vbNewLine() + "		p.name NomeProfilo,                            " + vbNewLine() + "		a.name NomeAccount,                           " + vbNewLine() + "		a.description Descrizione,                           " + vbNewLine() + "		a.email_address Email,                           " + vbNewLine() + "		a.display_name DisplayName,                           " + vbNewLine() + "		a.replyto_address ReplyTo                           " + vbNewLine() + "	FROM msdb.dbo.sysmail_profile p                           " + vbNewLine() + "		inner join msdb.dbo.sysmail_profileaccount pa                           " + vbNewLine() + "			on p.profile_id = pa.profile_id                           " + vbNewLine() + "		inner join msdb.dbo.sysmail_account a                           " + vbNewLine() + "			on pa.account_id= a.account_id                           " + vbNewLine() + "	ORDER BY P.NAME, A.name                           " + vbNewLine() + "END                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysModuli_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysModuli   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysModuli_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysModuli   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysModuli_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysModuli (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysModuli_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysModuli (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysModuli_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysModuli Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysModuli_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysModuli Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysModuli_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysModuli WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysModuli_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysModuli WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysModuli_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysModuli   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysModuli_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysModuli   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ByUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	SELECT            " + vbNewLine() + "		N.ID           " + vbNewLine() + "		, n.Titolo           " + vbNewLine() + "		, n.Descrizione           " + vbNewLine() + "		, n.DataNotifica            " + vbNewLine() + "		, UN.DataNotificata           " + vbNewLine() + "		, UN.Letta           " + vbNewLine() + "		, case WHEN isnull(UN.Letta,0) = 0 THEN ' ToRead' end CssLetta           " + vbNewLine() + "		, UN.DataLetta           " + vbNewLine() + "		, UN.Cancellata           " + vbNewLine() + "		, UN.DataCancellata           " + vbNewLine() + "           " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "	ORDER BY            " + vbNewLine() + "		n.DataNotifica DESC           " + vbNewLine() + "		, Titolo            " + vbNewLine() + "           " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ByUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	SELECT            " + vbNewLine() + "		N.ID           " + vbNewLine() + "		, n.Titolo           " + vbNewLine() + "		, n.Descrizione           " + vbNewLine() + "		, n.DataNotifica            " + vbNewLine() + "		, UN.DataNotificata           " + vbNewLine() + "		, UN.Letta           " + vbNewLine() + "		, case WHEN isnull(UN.Letta,0) = 0 THEN ' ToRead' end CssLetta           " + vbNewLine() + "		, UN.DataLetta           " + vbNewLine() + "		, UN.Cancellata           " + vbNewLine() + "		, UN.DataCancellata           " + vbNewLine() + "           " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "	ORDER BY            " + vbNewLine() + "		n.DataNotifica DESC           " + vbNewLine() + "		, Titolo            " + vbNewLine() + "           " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_COUNT]               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20)                " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		COUNT(*) CountNotifiche                " + vbNewLine() + "	FROM sysUtentiNotifiche               " + vbNewLine() + "	WHERE                " + vbNewLine() + "		IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Letta, 0) = 0               " + vbNewLine() + "		AND ISNULL(Cancellata, 0) = 0          " + vbNewLine() + "		AND ISNULL(Notificata, 0) = 1              " + vbNewLine() + "			              " + vbNewLine() + "END               " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_COUNT]               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20)                " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		COUNT(*) CountNotifiche                " + vbNewLine() + "	FROM sysUtentiNotifiche               " + vbNewLine() + "	WHERE                " + vbNewLine() + "		IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Letta, 0) = 0               " + vbNewLine() + "		AND ISNULL(Cancellata, 0) = 0          " + vbNewLine() + "		AND ISNULL(Notificata, 0) = 1              " + vbNewLine() + "			              " + vbNewLine() + "END               " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysNotifiche_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysNotifiche_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_DeleteAllUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	UPDATE UN          " + vbNewLine() + "		set Cancellata = 1, DataCancellata = Getdate()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_DeleteAllUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	UPDATE UN          " + vbNewLine() + "		set Cancellata = 1, DataCancellata = Getdate()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysNotifiche_INSERT    " + vbNewLine() + "  @Titolo AS nvarchar(50)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@DataNotifica AS datetime   " + vbNewLine() + "  ,@LimitaVisibilita AS bit   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@InviaEmail AS bit   " + vbNewLine() + "  ,@DataUltimaModifica AS datetime   " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysNotifiche (    " + vbNewLine() + "    Titolo   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,DataNotifica   " + vbNewLine() + "    ,LimitaVisibilita   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,InviaEmail   " + vbNewLine() + "    ,DataUltimaModifica   " + vbNewLine() + "    ,IDSysUtenteUltimaModifica   " + vbNewLine() + "    ,IDSysUtente   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Titolo   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@DataNotifica   " + vbNewLine() + "    ,@LimitaVisibilita   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@InviaEmail   " + vbNewLine() + "    ,@DataUltimaModifica   " + vbNewLine() + "    ,@IDSysUtenteUltimaModifica   " + vbNewLine() + "    ,@IDSysUtente   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysNotifiche_INSERT    " + vbNewLine() + "  @Titolo AS nvarchar(50)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@DataNotifica AS datetime   " + vbNewLine() + "  ,@LimitaVisibilita AS bit   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@InviaEmail AS bit   " + vbNewLine() + "  ,@DataUltimaModifica AS datetime   " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysNotifiche (    " + vbNewLine() + "    Titolo   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,DataNotifica   " + vbNewLine() + "    ,LimitaVisibilita   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,InviaEmail   " + vbNewLine() + "    ,DataUltimaModifica   " + vbNewLine() + "    ,IDSysUtenteUltimaModifica   " + vbNewLine() + "    ,IDSysUtente   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Titolo   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@DataNotifica   " + vbNewLine() + "    ,@LimitaVisibilita   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@InviaEmail   " + vbNewLine() + "    ,@DataUltimaModifica   " + vbNewLine() + "    ,@IDSysUtenteUltimaModifica   " + vbNewLine() + "    ,@IDSysUtente   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_NotifyAll]               " + vbNewLine() + "--DECLARE               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20) --= 'ADMIN'              " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	UPDATE un          " + vbNewLine() + "		set un.Notificata = 1, DataNotificata = GETDATE()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN              " + vbNewLine() + "		INNER JOIN sysNotifiche n               " + vbNewLine() + "			ON un.IDsysNotifica = n.id              " + vbNewLine() + "	WHERE                " + vbNewLine() + "		UN.IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Notificata,0) = 0              " + vbNewLine() + "			              " + vbNewLine() + "END              " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_NotifyAll]               " + vbNewLine() + "--DECLARE               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20) --= 'ADMIN'              " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	UPDATE un          " + vbNewLine() + "		set un.Notificata = 1, DataNotificata = GETDATE()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN              " + vbNewLine() + "		INNER JOIN sysNotifiche n               " + vbNewLine() + "			ON un.IDsysNotifica = n.id              " + vbNewLine() + "	WHERE                " + vbNewLine() + "		UN.IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Notificata,0) = 0              " + vbNewLine() + "			              " + vbNewLine() + "END              " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ReadAllUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	UPDATE UN          " + vbNewLine() + "		set Letta = 1, DataLetta = Getdate()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ReadAllUser]           " + vbNewLine() + "--DECLARE           " + vbNewLine() + "	@IdSysutente AS nvarchar(20) --= 'Admin'           " + vbNewLine() + "AS           " + vbNewLine() + "BEGIN           " + vbNewLine() + "	UPDATE UN          " + vbNewLine() + "		set Letta = 1, DataLetta = Getdate()          " + vbNewLine() + "	FROM sysUtentiNotifiche UN WITH(NOLOCK)           " + vbNewLine() + "		INNER JOIN sysNotifiche N WITH(NOLOCK)           " + vbNewLine() + "			 ON UN.IDsysNotifica = N.ID           " + vbNewLine() + "	where            " + vbNewLine() + "		UN.IDsysUtente = @IdSysutente           " + vbNewLine() + "		AND Notificata = 1           " + vbNewLine() + "		and ISNULL(Cancellata,0) = 0          " + vbNewLine() + "END           " + vbNewLine() + "           " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysNotifiche_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Titolo AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@DataNotificaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificaAl AS datetime = NULL    " + vbNewLine() + "  ,@LimitaVisibilita AS bit = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@InviaEmail AS bit = NULL    " + vbNewLine() + "  ,@DataUltimaModificaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimaModificaAl AS datetime = NULL    " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "  FROM sysNotifiche Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Titolo IS NULL OR Me.Titolo LIKE @Titolo + '%')    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataNotificaDal IS NULL OR Me.DataNotifica >= @DataNotificaDal)    " + vbNewLine() + "    AND  (@DataNotificaAl IS NULL OR Me.DataNotifica <= @DataNotificaAl)    " + vbNewLine() + "    AND  (@LimitaVisibilita IS NULL OR Me.LimitaVisibilita = @LimitaVisibilita)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@InviaEmail IS NULL OR Me.InviaEmail = @InviaEmail)    " + vbNewLine() + "    AND  (@DataUltimaModificaDal IS NULL OR Me.DataUltimaModifica >= @DataUltimaModificaDal)    " + vbNewLine() + "    AND  (@DataUltimaModificaAl IS NULL OR Me.DataUltimaModifica <= @DataUltimaModificaAl)    " + vbNewLine() + "    AND  (@IDSysUtenteUltimaModifica IS NULL OR Me.IDSysUtenteUltimaModifica LIKE @IDSysUtenteUltimaModifica + '%')    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysNotifiche_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Titolo AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@DataNotificaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificaAl AS datetime = NULL    " + vbNewLine() + "  ,@LimitaVisibilita AS bit = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@InviaEmail AS bit = NULL    " + vbNewLine() + "  ,@DataUltimaModificaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimaModificaAl AS datetime = NULL    " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "  FROM sysNotifiche Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Titolo IS NULL OR Me.Titolo LIKE @Titolo + '%')    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataNotificaDal IS NULL OR Me.DataNotifica >= @DataNotificaDal)    " + vbNewLine() + "    AND  (@DataNotificaAl IS NULL OR Me.DataNotifica <= @DataNotificaAl)    " + vbNewLine() + "    AND  (@LimitaVisibilita IS NULL OR Me.LimitaVisibilita = @LimitaVisibilita)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@InviaEmail IS NULL OR Me.InviaEmail = @InviaEmail)    " + vbNewLine() + "    AND  (@DataUltimaModificaDal IS NULL OR Me.DataUltimaModifica >= @DataUltimaModificaDal)    " + vbNewLine() + "    AND  (@DataUltimaModificaAl IS NULL OR Me.DataUltimaModifica <= @DataUltimaModificaAl)    " + vbNewLine() + "    AND  (@IDSysUtenteUltimaModifica IS NULL OR Me.IDSysUtenteUltimaModifica LIKE @IDSysUtenteUltimaModifica + '%')    " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysNotifiche_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataNotifica]   " + vbNewLine() + "    , [LimitaVisibilita]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [InviaEmail]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [IDSysUtenteUltimaModifica]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "  FROM sysNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysNotifiche_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataNotifica]   " + vbNewLine() + "    , [LimitaVisibilita]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [InviaEmail]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [IDSysUtenteUltimaModifica]   " + vbNewLine() + "    , [IDSysUtente]   " + vbNewLine() + "  FROM sysNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_SYNC]              " + vbNewLine() + "AS      " + vbNewLine() + "BEGIN              " + vbNewLine() + "     " + vbNewLine() + "	--AGGIORNO NOTIFICHE DA NOTIFICARE              " + vbNewLine() + "	INSERT INTO sysUtentiNotifiche              " + vbNewLine() + "	SELECT              " + vbNewLine() + "		N.IDSysUtente               " + vbNewLine() + "		, N.IDSysNotifica               " + vbNewLine() + "		, 0 Letta              " + vbNewLine() + "		, NULL           " + vbNewLine() + "		, 0 Notificata              " + vbNewLine() + "		, NULL           " + vbNewLine() + "		, 0 Cancellata              " + vbNewLine() + "		, NULL           " + vbNewLine() + "	FROM BV_SYSNOTIFICHEALL N       " + vbNewLine() + "		LEFT JOIN sysUtentiNotifiche UN WITH(NOLOCK)      " + vbNewLine() + "			ON n.IDSysNotifica = un.IDsysNotifica AND UN.IDsysUtente = N.IDSysUtente 		     " + vbNewLine() + "	WHERE               " + vbNewLine() + "		N.DataNotifica <= GETDATE()               " + vbNewLine() + "		AND UN.IDsysNotifica IS NULL             " + vbNewLine() + "		              " + vbNewLine() + "END               " + vbNewLine() + "     " + vbNewLine() + "     " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysNotifiche_SYNC]              " + vbNewLine() + "AS      " + vbNewLine() + "BEGIN              " + vbNewLine() + "     " + vbNewLine() + "	--AGGIORNO NOTIFICHE DA NOTIFICARE              " + vbNewLine() + "	INSERT INTO sysUtentiNotifiche              " + vbNewLine() + "	SELECT              " + vbNewLine() + "		N.IDSysUtente               " + vbNewLine() + "		, N.IDSysNotifica               " + vbNewLine() + "		, 0 Letta              " + vbNewLine() + "		, NULL           " + vbNewLine() + "		, 0 Notificata              " + vbNewLine() + "		, NULL           " + vbNewLine() + "		, 0 Cancellata              " + vbNewLine() + "		, NULL           " + vbNewLine() + "	FROM BV_SYSNOTIFICHEALL N       " + vbNewLine() + "		LEFT JOIN sysUtentiNotifiche UN WITH(NOLOCK)      " + vbNewLine() + "			ON n.IDSysNotifica = un.IDsysNotifica AND UN.IDsysUtente = N.IDSysUtente 		     " + vbNewLine() + "	WHERE               " + vbNewLine() + "		N.DataNotifica <= GETDATE()               " + vbNewLine() + "		AND UN.IDsysNotifica IS NULL             " + vbNewLine() + "		              " + vbNewLine() + "END               " + vbNewLine() + "     " + vbNewLine() + "     " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ToNotify]               " + vbNewLine() + "--DECLARE               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20) --= 'ADMIN'              " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		n.*              " + vbNewLine() + "		--,un.*          " + vbNewLine() + "	FROM sysUtentiNotifiche UN              " + vbNewLine() + "		INNER JOIN sysNotifiche n               " + vbNewLine() + "			ON un.IDsysNotifica = n.id              " + vbNewLine() + "	WHERE                " + vbNewLine() + "		un.IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Notificata,0) = 0              " + vbNewLine() + "			              " + vbNewLine() + "END              " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "              " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysNotifiche_ToNotify]               " + vbNewLine() + "--DECLARE               " + vbNewLine() + "	@IDSysUtente AS NVARCHAR(20) --= 'ADMIN'              " + vbNewLine() + "AS               " + vbNewLine() + "BEGIN               " + vbNewLine() + "	SELECT                " + vbNewLine() + "		n.*              " + vbNewLine() + "		--,un.*          " + vbNewLine() + "	FROM sysUtentiNotifiche UN              " + vbNewLine() + "		INNER JOIN sysNotifiche n               " + vbNewLine() + "			ON un.IDsysNotifica = n.id              " + vbNewLine() + "	WHERE                " + vbNewLine() + "		un.IDsysUtente = @IDSysUtente               " + vbNewLine() + "		AND ISNULL(Notificata,0) = 0              " + vbNewLine() + "			              " + vbNewLine() + "END              " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysNotifiche_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Titolo AS nvarchar(50)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@DataNotifica AS datetime   " + vbNewLine() + "  ,@LimitaVisibilita AS bit   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@InviaEmail AS bit   " + vbNewLine() + "  ,@DataUltimaModifica AS datetime   " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysNotifiche   " + vbNewLine() + "    SET    " + vbNewLine() + "      Titolo =  @Titolo   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , DataNotifica =  @DataNotifica   " + vbNewLine() + "      , LimitaVisibilita =  @LimitaVisibilita   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "      , InviaEmail =  @InviaEmail   " + vbNewLine() + "      , DataUltimaModifica =  @DataUltimaModifica   " + vbNewLine() + "      , IDSysUtenteUltimaModifica =  @IDSysUtenteUltimaModifica   " + vbNewLine() + "      , IDSysUtente =  @IDSysUtente   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysNotifiche_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Titolo AS nvarchar(50)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + "  ,@DataNotifica AS datetime   " + vbNewLine() + "  ,@LimitaVisibilita AS bit   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@InviaEmail AS bit   " + vbNewLine() + "  ,@DataUltimaModifica AS datetime   " + vbNewLine() + "  ,@IDSysUtenteUltimaModifica AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysUtente AS nvarchar(20)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysNotifiche   " + vbNewLine() + "    SET    " + vbNewLine() + "      Titolo =  @Titolo   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , DataNotifica =  @DataNotifica   " + vbNewLine() + "      , LimitaVisibilita =  @LimitaVisibilita   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "      , InviaEmail =  @InviaEmail   " + vbNewLine() + "      , DataUltimaModifica =  @DataUltimaModifica   " + vbNewLine() + "      , IDSysUtenteUltimaModifica =  @IDSysUtenteUltimaModifica   " + vbNewLine() + "      , IDSysUtente =  @IDSysUtente   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysPassePartout_DELETE]                      " + vbNewLine() + " AS                      " + vbNewLine() + "BEGIN                     " + vbNewLine() + "  DELETE FROM sysPassePartout                     " + vbNewLine() + "                      " + vbNewLine() + "END                      " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysPassePartout_DELETE]                      " + vbNewLine() + " AS                      " + vbNewLine() + "BEGIN                     " + vbNewLine() + "  DELETE FROM sysPassePartout                     " + vbNewLine() + "                      " + vbNewLine() + "END                      " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysPassepartout_SET]                            " + vbNewLine() + "	@Password as varchar(50)                          " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	TRUNCATE TABLE sysPassepartout                          " + vbNewLine() + "                          " + vbNewLine() + "	INSERT INTO sysPassePartout                          " + vbNewLine() + "	SELECT 1, PWDENCRYPT(@password)                          " + vbNewLine() + "END                          " + vbNewLine() + "                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                          " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysPassepartout_SET]                            " + vbNewLine() + "	@Password as varchar(50)                          " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	TRUNCATE TABLE sysPassepartout                          " + vbNewLine() + "                          " + vbNewLine() + "	INSERT INTO sysPassePartout                          " + vbNewLine() + "	SELECT 1, PWDENCRYPT(@password)                          " + vbNewLine() + "END                          " + vbNewLine() + "                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE procedure [dbo].[BSP_sysPasspartout_CHECK]                            " + vbNewLine() + "	@password as varchar(50)                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "  DECLARE @passcript varbinary(256)                             " + vbNewLine() + "                             " + vbNewLine() + "  SELECT TOP 1                             " + vbNewLine() + "    @passcript = password                             " + vbNewLine() + "  FROM                             " + vbNewLine() + "    syspassepartout   		                            " + vbNewLine() + "                          " + vbNewLine() + "  SELECT PWDCOMPARE(@password, @passcript)  		                          " + vbNewLine() + "END                          " + vbNewLine() + "                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE procedure [dbo].[BSP_sysPasspartout_CHECK]                            " + vbNewLine() + "	@password as varchar(50)                            " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "  DECLARE @passcript varbinary(256)                             " + vbNewLine() + "                             " + vbNewLine() + "  SELECT TOP 1                             " + vbNewLine() + "    @passcript = password                             " + vbNewLine() + "  FROM                             " + vbNewLine() + "    syspassepartout   		                            " + vbNewLine() + "                          " + vbNewLine() + "  SELECT PWDCOMPARE(@password, @passcript)  		                          " + vbNewLine() + "END                          " + vbNewLine() + "                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPersone_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPersone   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPersone_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPersone   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPersone_INSERT    " + vbNewLine() + "  @CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(50)   " + vbNewLine() + "  ,@Cognome AS nvarchar(50)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@Fax AS nvarchar(50)   " + vbNewLine() + "  ,@Telefono AS nvarchar(20)   " + vbNewLine() + "  ,@Celluare AS nvarchar(20)   " + vbNewLine() + "  ,@AltroRecapito AS nvarchar(50)   " + vbNewLine() + "  ,@Email AS nvarchar(200)   " + vbNewLine() + "  ,@CAPResidenza AS nvarchar(10)   " + vbNewLine() + "  ,@CAPDomicilio AS nvarchar(10)   " + vbNewLine() + "  ,@IndirizzoDomicilio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IndirizzoResidenza AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDStatoNascita AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoDomicilio AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoResidenza AS nvarchar(3)   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneDomicilio AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneResidenza AS nvarchar(4)   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@WebSite AS nvarchar(200)   " + vbNewLine() + "  ,@Foto AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@IDQuartiereResidenza AS int   " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPersone (    " + vbNewLine() + "    CodiceFiscale   " + vbNewLine() + "    ,Nome   " + vbNewLine() + "    ,Cognome   " + vbNewLine() + "    ,DataNascita   " + vbNewLine() + "    ,Sesso   " + vbNewLine() + "    ,Fax   " + vbNewLine() + "    ,Telefono   " + vbNewLine() + "    ,Celluare   " + vbNewLine() + "    ,AltroRecapito   " + vbNewLine() + "    ,Email   " + vbNewLine() + "    ,CAPResidenza   " + vbNewLine() + "    ,CAPDomicilio   " + vbNewLine() + "    ,IndirizzoDomicilio   " + vbNewLine() + "    ,IndirizzoResidenza   " + vbNewLine() + "    ,IDStatoNascita   " + vbNewLine() + "    ,IDStatoDomicilio   " + vbNewLine() + "    ,IDStatoResidenza   " + vbNewLine() + "    ,IDComuneNascita   " + vbNewLine() + "    ,IDComuneDomicilio   " + vbNewLine() + "    ,IDComuneResidenza   " + vbNewLine() + "    ,Note   " + vbNewLine() + "    ,WebSite   " + vbNewLine() + "    ,Foto   " + vbNewLine() + "    ,IDQuartiereResidenza   " + vbNewLine() + "    ,IDQuartiereDomicilio   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @CodiceFiscale   " + vbNewLine() + "    ,@Nome   " + vbNewLine() + "    ,@Cognome   " + vbNewLine() + "    ,@DataNascita   " + vbNewLine() + "    ,@Sesso   " + vbNewLine() + "    ,@Fax   " + vbNewLine() + "    ,@Telefono   " + vbNewLine() + "    ,@Celluare   " + vbNewLine() + "    ,@AltroRecapito   " + vbNewLine() + "    ,@Email   " + vbNewLine() + "    ,@CAPResidenza   " + vbNewLine() + "    ,@CAPDomicilio   " + vbNewLine() + "    ,@IndirizzoDomicilio   " + vbNewLine() + "    ,@IndirizzoResidenza   " + vbNewLine() + "    ,@IDStatoNascita   " + vbNewLine() + "    ,@IDStatoDomicilio   " + vbNewLine() + "    ,@IDStatoResidenza   " + vbNewLine() + "    ,@IDComuneNascita   " + vbNewLine() + "    ,@IDComuneDomicilio   " + vbNewLine() + "    ,@IDComuneResidenza   " + vbNewLine() + "    ,@Note   " + vbNewLine() + "    ,@WebSite   " + vbNewLine() + "    ,@Foto   " + vbNewLine() + "    ,@IDQuartiereResidenza   " + vbNewLine() + "    ,@IDQuartiereDomicilio   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPersone_INSERT    " + vbNewLine() + "  @CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(50)   " + vbNewLine() + "  ,@Cognome AS nvarchar(50)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@Fax AS nvarchar(50)   " + vbNewLine() + "  ,@Telefono AS nvarchar(20)   " + vbNewLine() + "  ,@Celluare AS nvarchar(20)   " + vbNewLine() + "  ,@AltroRecapito AS nvarchar(50)   " + vbNewLine() + "  ,@Email AS nvarchar(200)   " + vbNewLine() + "  ,@CAPResidenza AS nvarchar(10)   " + vbNewLine() + "  ,@CAPDomicilio AS nvarchar(10)   " + vbNewLine() + "  ,@IndirizzoDomicilio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IndirizzoResidenza AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDStatoNascita AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoDomicilio AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoResidenza AS nvarchar(3)   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneDomicilio AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneResidenza AS nvarchar(4)   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@WebSite AS nvarchar(200)   " + vbNewLine() + "  ,@Foto AS varbinary(MAX) = NULL    " + vbNewLine() + "  ,@IDQuartiereResidenza AS int   " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPersone (    " + vbNewLine() + "    CodiceFiscale   " + vbNewLine() + "    ,Nome   " + vbNewLine() + "    ,Cognome   " + vbNewLine() + "    ,DataNascita   " + vbNewLine() + "    ,Sesso   " + vbNewLine() + "    ,Fax   " + vbNewLine() + "    ,Telefono   " + vbNewLine() + "    ,Celluare   " + vbNewLine() + "    ,AltroRecapito   " + vbNewLine() + "    ,Email   " + vbNewLine() + "    ,CAPResidenza   " + vbNewLine() + "    ,CAPDomicilio   " + vbNewLine() + "    ,IndirizzoDomicilio   " + vbNewLine() + "    ,IndirizzoResidenza   " + vbNewLine() + "    ,IDStatoNascita   " + vbNewLine() + "    ,IDStatoDomicilio   " + vbNewLine() + "    ,IDStatoResidenza   " + vbNewLine() + "    ,IDComuneNascita   " + vbNewLine() + "    ,IDComuneDomicilio   " + vbNewLine() + "    ,IDComuneResidenza   " + vbNewLine() + "    ,Note   " + vbNewLine() + "    ,WebSite   " + vbNewLine() + "    ,Foto   " + vbNewLine() + "    ,IDQuartiereResidenza   " + vbNewLine() + "    ,IDQuartiereDomicilio   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @CodiceFiscale   " + vbNewLine() + "    ,@Nome   " + vbNewLine() + "    ,@Cognome   " + vbNewLine() + "    ,@DataNascita   " + vbNewLine() + "    ,@Sesso   " + vbNewLine() + "    ,@Fax   " + vbNewLine() + "    ,@Telefono   " + vbNewLine() + "    ,@Celluare   " + vbNewLine() + "    ,@AltroRecapito   " + vbNewLine() + "    ,@Email   " + vbNewLine() + "    ,@CAPResidenza   " + vbNewLine() + "    ,@CAPDomicilio   " + vbNewLine() + "    ,@IndirizzoDomicilio   " + vbNewLine() + "    ,@IndirizzoResidenza   " + vbNewLine() + "    ,@IDStatoNascita   " + vbNewLine() + "    ,@IDStatoDomicilio   " + vbNewLine() + "    ,@IDStatoResidenza   " + vbNewLine() + "    ,@IDComuneNascita   " + vbNewLine() + "    ,@IDComuneDomicilio   " + vbNewLine() + "    ,@IDComuneResidenza   " + vbNewLine() + "    ,@Note   " + vbNewLine() + "    ,@WebSite   " + vbNewLine() + "    ,@Foto   " + vbNewLine() + "    ,@IDQuartiereResidenza   " + vbNewLine() + "    ,@IDQuartiereDomicilio   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPersone_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@CodiceFiscale AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Nome AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Cognome AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@DataNascitaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNascitaAl AS datetime = NULL    " + vbNewLine() + "  ,@Sesso AS bit = NULL    " + vbNewLine() + "  ,@Fax AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Telefono AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Celluare AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@AltroRecapito AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Email AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@CAPResidenza AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@CAPDomicilio AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@IndirizzoDomicilio AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IndirizzoResidenza AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDStatoNascita AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDStatoDomicilio AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDStatoResidenza AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDComuneNascita AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDComuneDomicilio AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDComuneResidenza AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Note AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@WebSite AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@IDQuartiereResidenza AS int = NULL    " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysStati.Descrizione StatoNascita   " + vbNewLine() + "    , sysStati1.Descrizione StatoDomicilio   " + vbNewLine() + "    , sysStati2.Descrizione StatoResidenza   " + vbNewLine() + "    , sysComuni.Descrizione ComuneNascita   " + vbNewLine() + "    , sysComuni1.Descrizione ComuneDomicilio   " + vbNewLine() + "    , sysComuni2.Descrizione ComuneResidenza   " + vbNewLine() + "  FROM sysPersone Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysStati sysStati WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoNascita = sysStati.ID   " + vbNewLine() + "    LEFT JOIN sysStati sysStati1 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoDomicilio = sysStati1.ID   " + vbNewLine() + "    LEFT JOIN sysStati sysStati2 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoResidenza = sysStati2.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneNascita = sysComuni.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni1 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneDomicilio = sysComuni1.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni2 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneResidenza = sysComuni2.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@CodiceFiscale IS NULL OR Me.CodiceFiscale LIKE @CodiceFiscale + '%')    " + vbNewLine() + "    AND  (@Nome IS NULL OR Me.Nome LIKE @Nome + '%')    " + vbNewLine() + "    AND  (@Cognome IS NULL OR Me.Cognome LIKE @Cognome + '%')    " + vbNewLine() + "    AND  (@DataNascitaDal IS NULL OR Me.DataNascita >= @DataNascitaDal)    " + vbNewLine() + "    AND  (@DataNascitaAl IS NULL OR Me.DataNascita <= @DataNascitaAl)    " + vbNewLine() + "    AND  (@Sesso IS NULL OR Me.Sesso = @Sesso)    " + vbNewLine() + "    AND  (@Fax IS NULL OR Me.Fax LIKE @Fax + '%')    " + vbNewLine() + "    AND  (@Telefono IS NULL OR Me.Telefono LIKE @Telefono + '%')    " + vbNewLine() + "    AND  (@Celluare IS NULL OR Me.Celluare LIKE @Celluare + '%')    " + vbNewLine() + "    AND  (@AltroRecapito IS NULL OR Me.AltroRecapito LIKE @AltroRecapito + '%')    " + vbNewLine() + "    AND  (@Email IS NULL OR Me.Email LIKE @Email + '%')    " + vbNewLine() + "    AND  (@CAPResidenza IS NULL OR Me.CAPResidenza LIKE @CAPResidenza + '%')    " + vbNewLine() + "    AND  (@CAPDomicilio IS NULL OR Me.CAPDomicilio LIKE @CAPDomicilio + '%')    " + vbNewLine() + "    AND  (@IndirizzoDomicilio IS NULL OR Me.IndirizzoDomicilio LIKE @IndirizzoDomicilio + '%')    " + vbNewLine() + "    AND  (@IndirizzoResidenza IS NULL OR Me.IndirizzoResidenza LIKE @IndirizzoResidenza + '%')    " + vbNewLine() + "    AND  (@IDStatoNascita IS NULL OR Me.IDStatoNascita LIKE @IDStatoNascita + '%')    " + vbNewLine() + "    AND  (@IDStatoDomicilio IS NULL OR Me.IDStatoDomicilio LIKE @IDStatoDomicilio + '%')    " + vbNewLine() + "    AND  (@IDStatoResidenza IS NULL OR Me.IDStatoResidenza LIKE @IDStatoResidenza + '%')    " + vbNewLine() + "    AND  (@IDComuneNascita IS NULL OR Me.IDComuneNascita LIKE @IDComuneNascita + '%')    " + vbNewLine() + "    AND  (@IDComuneDomicilio IS NULL OR Me.IDComuneDomicilio LIKE @IDComuneDomicilio + '%')    " + vbNewLine() + "    AND  (@IDComuneResidenza IS NULL OR Me.IDComuneResidenza LIKE @IDComuneResidenza + '%')    " + vbNewLine() + "    AND  (@Note IS NULL OR Me.Note LIKE @Note + '%')    " + vbNewLine() + "    AND  (@WebSite IS NULL OR Me.WebSite LIKE @WebSite + '%')    " + vbNewLine() + "    AND  (@IDQuartiereResidenza IS NULL OR Me.IDQuartiereResidenza = @IDQuartiereResidenza)    " + vbNewLine() + "    AND  (@IDQuartiereDomicilio IS NULL OR Me.IDQuartiereDomicilio = @IDQuartiereDomicilio)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPersone_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@CodiceFiscale AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Nome AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Cognome AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@DataNascitaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNascitaAl AS datetime = NULL    " + vbNewLine() + "  ,@Sesso AS bit = NULL    " + vbNewLine() + "  ,@Fax AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Telefono AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Celluare AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@AltroRecapito AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Email AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@CAPResidenza AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@CAPDomicilio AS NVARCHAR(10) = NULL    " + vbNewLine() + "  ,@IndirizzoDomicilio AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IndirizzoResidenza AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDStatoNascita AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDStatoDomicilio AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDStatoResidenza AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@IDComuneNascita AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDComuneDomicilio AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@IDComuneResidenza AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Note AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@WebSite AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@IDQuartiereResidenza AS int = NULL    " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysStati.Descrizione StatoNascita   " + vbNewLine() + "    , sysStati1.Descrizione StatoDomicilio   " + vbNewLine() + "    , sysStati2.Descrizione StatoResidenza   " + vbNewLine() + "    , sysComuni.Descrizione ComuneNascita   " + vbNewLine() + "    , sysComuni1.Descrizione ComuneDomicilio   " + vbNewLine() + "    , sysComuni2.Descrizione ComuneResidenza   " + vbNewLine() + "  FROM sysPersone Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysStati sysStati WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoNascita = sysStati.ID   " + vbNewLine() + "    LEFT JOIN sysStati sysStati1 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoDomicilio = sysStati1.ID   " + vbNewLine() + "    LEFT JOIN sysStati sysStati2 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDStatoResidenza = sysStati2.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneNascita = sysComuni.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni1 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneDomicilio = sysComuni1.ID   " + vbNewLine() + "    LEFT JOIN sysComuni sysComuni2 WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDComuneResidenza = sysComuni2.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@CodiceFiscale IS NULL OR Me.CodiceFiscale LIKE @CodiceFiscale + '%')    " + vbNewLine() + "    AND  (@Nome IS NULL OR Me.Nome LIKE @Nome + '%')    " + vbNewLine() + "    AND  (@Cognome IS NULL OR Me.Cognome LIKE @Cognome + '%')    " + vbNewLine() + "    AND  (@DataNascitaDal IS NULL OR Me.DataNascita >= @DataNascitaDal)    " + vbNewLine() + "    AND  (@DataNascitaAl IS NULL OR Me.DataNascita <= @DataNascitaAl)    " + vbNewLine() + "    AND  (@Sesso IS NULL OR Me.Sesso = @Sesso)    " + vbNewLine() + "    AND  (@Fax IS NULL OR Me.Fax LIKE @Fax + '%')    " + vbNewLine() + "    AND  (@Telefono IS NULL OR Me.Telefono LIKE @Telefono + '%')    " + vbNewLine() + "    AND  (@Celluare IS NULL OR Me.Celluare LIKE @Celluare + '%')    " + vbNewLine() + "    AND  (@AltroRecapito IS NULL OR Me.AltroRecapito LIKE @AltroRecapito + '%')    " + vbNewLine() + "    AND  (@Email IS NULL OR Me.Email LIKE @Email + '%')    " + vbNewLine() + "    AND  (@CAPResidenza IS NULL OR Me.CAPResidenza LIKE @CAPResidenza + '%')    " + vbNewLine() + "    AND  (@CAPDomicilio IS NULL OR Me.CAPDomicilio LIKE @CAPDomicilio + '%')    " + vbNewLine() + "    AND  (@IndirizzoDomicilio IS NULL OR Me.IndirizzoDomicilio LIKE @IndirizzoDomicilio + '%')    " + vbNewLine() + "    AND  (@IndirizzoResidenza IS NULL OR Me.IndirizzoResidenza LIKE @IndirizzoResidenza + '%')    " + vbNewLine() + "    AND  (@IDStatoNascita IS NULL OR Me.IDStatoNascita LIKE @IDStatoNascita + '%')    " + vbNewLine() + "    AND  (@IDStatoDomicilio IS NULL OR Me.IDStatoDomicilio LIKE @IDStatoDomicilio + '%')    " + vbNewLine() + "    AND  (@IDStatoResidenza IS NULL OR Me.IDStatoResidenza LIKE @IDStatoResidenza + '%')    " + vbNewLine() + "    AND  (@IDComuneNascita IS NULL OR Me.IDComuneNascita LIKE @IDComuneNascita + '%')    " + vbNewLine() + "    AND  (@IDComuneDomicilio IS NULL OR Me.IDComuneDomicilio LIKE @IDComuneDomicilio + '%')    " + vbNewLine() + "    AND  (@IDComuneResidenza IS NULL OR Me.IDComuneResidenza LIKE @IDComuneResidenza + '%')    " + vbNewLine() + "    AND  (@Note IS NULL OR Me.Note LIKE @Note + '%')    " + vbNewLine() + "    AND  (@WebSite IS NULL OR Me.WebSite LIKE @WebSite + '%')    " + vbNewLine() + "    AND  (@IDQuartiereResidenza IS NULL OR Me.IDQuartiereResidenza = @IDQuartiereResidenza)    " + vbNewLine() + "    AND  (@IDQuartiereDomicilio IS NULL OR Me.IDQuartiereDomicilio = @IDQuartiereDomicilio)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPersone_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [CodiceFiscale]   " + vbNewLine() + "    , [Nome]   " + vbNewLine() + "    , [Cognome]   " + vbNewLine() + "    , [DataNascita]   " + vbNewLine() + "    , [Sesso]   " + vbNewLine() + "    , [Fax]   " + vbNewLine() + "    , [Telefono]   " + vbNewLine() + "    , [Celluare]   " + vbNewLine() + "    , [AltroRecapito]   " + vbNewLine() + "    , [Email]   " + vbNewLine() + "    , [CAPResidenza]   " + vbNewLine() + "    , [CAPDomicilio]   " + vbNewLine() + "    , [IndirizzoDomicilio]   " + vbNewLine() + "    , [IndirizzoResidenza]   " + vbNewLine() + "    , [IDStatoNascita]   " + vbNewLine() + "    , [IDStatoDomicilio]   " + vbNewLine() + "    , [IDStatoResidenza]   " + vbNewLine() + "    , [IDComuneNascita]   " + vbNewLine() + "    , [IDComuneDomicilio]   " + vbNewLine() + "    , [IDComuneResidenza]   " + vbNewLine() + "    , [Note]   " + vbNewLine() + "    , [WebSite]   " + vbNewLine() + "    , [Foto]   " + vbNewLine() + "    , [IDQuartiereResidenza]   " + vbNewLine() + "    , [IDQuartiereDomicilio]   " + vbNewLine() + "  FROM sysPersone WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPersone_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [CodiceFiscale]   " + vbNewLine() + "    , [Nome]   " + vbNewLine() + "    , [Cognome]   " + vbNewLine() + "    , [DataNascita]   " + vbNewLine() + "    , [Sesso]   " + vbNewLine() + "    , [Fax]   " + vbNewLine() + "    , [Telefono]   " + vbNewLine() + "    , [Celluare]   " + vbNewLine() + "    , [AltroRecapito]   " + vbNewLine() + "    , [Email]   " + vbNewLine() + "    , [CAPResidenza]   " + vbNewLine() + "    , [CAPDomicilio]   " + vbNewLine() + "    , [IndirizzoDomicilio]   " + vbNewLine() + "    , [IndirizzoResidenza]   " + vbNewLine() + "    , [IDStatoNascita]   " + vbNewLine() + "    , [IDStatoDomicilio]   " + vbNewLine() + "    , [IDStatoResidenza]   " + vbNewLine() + "    , [IDComuneNascita]   " + vbNewLine() + "    , [IDComuneDomicilio]   " + vbNewLine() + "    , [IDComuneResidenza]   " + vbNewLine() + "    , [Note]   " + vbNewLine() + "    , [WebSite]   " + vbNewLine() + "    , [Foto]   " + vbNewLine() + "    , [IDQuartiereResidenza]   " + vbNewLine() + "    , [IDQuartiereDomicilio]   " + vbNewLine() + "  FROM sysPersone WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "    " + vbNewLine() + "CREATE PROCEDURE [dbo].BSP_SYSPERSONE_SELECT_BYCODFISCALE       " + vbNewLine() + "  @CodiceFiscale AS VARCHAR(20) = NULL       " + vbNewLine() + " AS       " + vbNewLine() + "BEGIN      " + vbNewLine() + "  SELECT       " + vbNewLine() + "    [ID]      " + vbNewLine() + "    , [CodiceFiscale]      " + vbNewLine() + "    , [Nome]      " + vbNewLine() + "    , [Cognome]      " + vbNewLine() + "    , [DataNascita]      " + vbNewLine() + "    , [Sesso]      " + vbNewLine() + "    , [Fax]      " + vbNewLine() + "    , [Telefono]      " + vbNewLine() + "    , [Celluare]      " + vbNewLine() + "    , [AltroRecapito]      " + vbNewLine() + "    , [Email]      " + vbNewLine() + "    , [CAPResidenza]      " + vbNewLine() + "    , [CAPDomicilio]      " + vbNewLine() + "    , [IndirizzoDomicilio]      " + vbNewLine() + "    , [IndirizzoResidenza]      " + vbNewLine() + "    , [IDStatoNascita]      " + vbNewLine() + "    , [IDStatoDomicilio]      " + vbNewLine() + "    , [IDStatoResidenza]      " + vbNewLine() + "    , [IDComuneNascita]      " + vbNewLine() + "    , [IDComuneDomicilio]      " + vbNewLine() + "    , [IDComuneResidenza]      " + vbNewLine() + "    , [IDQuartiereResidenza]      " + vbNewLine() + "    , [IDQuartiereDomicilio]      " + vbNewLine() + "    , [Note]      " + vbNewLine() + "    , [WebSite]      " + vbNewLine() + "    , [Foto]      " + vbNewLine() + "  FROM sysPersone WITH(NOLOCK)       " + vbNewLine() + "  WHERE       " + vbNewLine() + "    CodiceFiscale = @CodiceFiscale      " + vbNewLine() + "       " + vbNewLine() + "END       " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<    " + vbNewLine() + "CREATE PROCEDURE [dbo].BSP_SYSPERSONE_SELECT_BYCODFISCALE       " + vbNewLine() + "  @CodiceFiscale AS VARCHAR(20) = NULL       " + vbNewLine() + " AS       " + vbNewLine() + "BEGIN      " + vbNewLine() + "  SELECT       " + vbNewLine() + "    [ID]      " + vbNewLine() + "    , [CodiceFiscale]      " + vbNewLine() + "    , [Nome]      " + vbNewLine() + "    , [Cognome]      " + vbNewLine() + "    , [DataNascita]      " + vbNewLine() + "    , [Sesso]      " + vbNewLine() + "    , [Fax]      " + vbNewLine() + "    , [Telefono]      " + vbNewLine() + "    , [Celluare]      " + vbNewLine() + "    , [AltroRecapito]      " + vbNewLine() + "    , [Email]      " + vbNewLine() + "    , [CAPResidenza]      " + vbNewLine() + "    , [CAPDomicilio]      " + vbNewLine() + "    , [IndirizzoDomicilio]      " + vbNewLine() + "    , [IndirizzoResidenza]      " + vbNewLine() + "    , [IDStatoNascita]      " + vbNewLine() + "    , [IDStatoDomicilio]      " + vbNewLine() + "    , [IDStatoResidenza]      " + vbNewLine() + "    , [IDComuneNascita]      " + vbNewLine() + "    , [IDComuneDomicilio]      " + vbNewLine() + "    , [IDComuneResidenza]      " + vbNewLine() + "    , [IDQuartiereResidenza]      " + vbNewLine() + "    , [IDQuartiereDomicilio]      " + vbNewLine() + "    , [Note]      " + vbNewLine() + "    , [WebSite]      " + vbNewLine() + "    , [Foto]      " + vbNewLine() + "  FROM sysPersone WITH(NOLOCK)       " + vbNewLine() + "  WHERE       " + vbNewLine() + "    CodiceFiscale = @CodiceFiscale      " + vbNewLine() + "       " + vbNewLine() + "END       " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPersone_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(50)   " + vbNewLine() + "  ,@Cognome AS nvarchar(50)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@Fax AS nvarchar(50)   " + vbNewLine() + "  ,@Telefono AS nvarchar(20)   " + vbNewLine() + "  ,@Celluare AS nvarchar(20)   " + vbNewLine() + "  ,@AltroRecapito AS nvarchar(50)   " + vbNewLine() + "  ,@Email AS nvarchar(200)   " + vbNewLine() + "  ,@CAPResidenza AS nvarchar(10)   " + vbNewLine() + "  ,@CAPDomicilio AS nvarchar(10)   " + vbNewLine() + "  ,@IndirizzoDomicilio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IndirizzoResidenza AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDStatoNascita AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoDomicilio AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoResidenza AS nvarchar(3)   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneDomicilio AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneResidenza AS nvarchar(4)   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@WebSite AS nvarchar(200)   " + vbNewLine() + "  ,@Foto AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@IDQuartiereResidenza AS int   " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPersone   " + vbNewLine() + "    SET    " + vbNewLine() + "      CodiceFiscale =  @CodiceFiscale   " + vbNewLine() + "      , Nome =  @Nome   " + vbNewLine() + "      , Cognome =  @Cognome   " + vbNewLine() + "      , DataNascita =  @DataNascita   " + vbNewLine() + "      , Sesso =  @Sesso   " + vbNewLine() + "      , Fax =  @Fax   " + vbNewLine() + "      , Telefono =  @Telefono   " + vbNewLine() + "      , Celluare =  @Celluare   " + vbNewLine() + "      , AltroRecapito =  @AltroRecapito   " + vbNewLine() + "      , Email =  @Email   " + vbNewLine() + "      , CAPResidenza =  @CAPResidenza   " + vbNewLine() + "      , CAPDomicilio =  @CAPDomicilio   " + vbNewLine() + "      , IndirizzoDomicilio =  @IndirizzoDomicilio   " + vbNewLine() + "      , IndirizzoResidenza =  @IndirizzoResidenza   " + vbNewLine() + "      , IDStatoNascita =  @IDStatoNascita   " + vbNewLine() + "      , IDStatoDomicilio =  @IDStatoDomicilio   " + vbNewLine() + "      , IDStatoResidenza =  @IDStatoResidenza   " + vbNewLine() + "      , IDComuneNascita =  @IDComuneNascita   " + vbNewLine() + "      , IDComuneDomicilio =  @IDComuneDomicilio   " + vbNewLine() + "      , IDComuneResidenza =  @IDComuneResidenza   " + vbNewLine() + "      , Note =  @Note   " + vbNewLine() + "      , WebSite =  @WebSite   " + vbNewLine() + "      , Foto =  @Foto   " + vbNewLine() + "      , IDQuartiereResidenza =  @IDQuartiereResidenza   " + vbNewLine() + "      , IDQuartiereDomicilio =  @IDQuartiereDomicilio   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPersone_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(50)   " + vbNewLine() + "  ,@Cognome AS nvarchar(50)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@Fax AS nvarchar(50)   " + vbNewLine() + "  ,@Telefono AS nvarchar(20)   " + vbNewLine() + "  ,@Celluare AS nvarchar(20)   " + vbNewLine() + "  ,@AltroRecapito AS nvarchar(50)   " + vbNewLine() + "  ,@Email AS nvarchar(200)   " + vbNewLine() + "  ,@CAPResidenza AS nvarchar(10)   " + vbNewLine() + "  ,@CAPDomicilio AS nvarchar(10)   " + vbNewLine() + "  ,@IndirizzoDomicilio AS nvarchar(MAX)   " + vbNewLine() + "  ,@IndirizzoResidenza AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDStatoNascita AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoDomicilio AS nvarchar(3)   " + vbNewLine() + "  ,@IDStatoResidenza AS nvarchar(3)   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneDomicilio AS nvarchar(4)   " + vbNewLine() + "  ,@IDComuneResidenza AS nvarchar(4)   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@WebSite AS nvarchar(200)   " + vbNewLine() + "  ,@Foto AS varbinary(MAX) = NULL   " + vbNewLine() + "  ,@IDQuartiereResidenza AS int   " + vbNewLine() + "  ,@IDQuartiereDomicilio AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPersone   " + vbNewLine() + "    SET    " + vbNewLine() + "      CodiceFiscale =  @CodiceFiscale   " + vbNewLine() + "      , Nome =  @Nome   " + vbNewLine() + "      , Cognome =  @Cognome   " + vbNewLine() + "      , DataNascita =  @DataNascita   " + vbNewLine() + "      , Sesso =  @Sesso   " + vbNewLine() + "      , Fax =  @Fax   " + vbNewLine() + "      , Telefono =  @Telefono   " + vbNewLine() + "      , Celluare =  @Celluare   " + vbNewLine() + "      , AltroRecapito =  @AltroRecapito   " + vbNewLine() + "      , Email =  @Email   " + vbNewLine() + "      , CAPResidenza =  @CAPResidenza   " + vbNewLine() + "      , CAPDomicilio =  @CAPDomicilio   " + vbNewLine() + "      , IndirizzoDomicilio =  @IndirizzoDomicilio   " + vbNewLine() + "      , IndirizzoResidenza =  @IndirizzoResidenza   " + vbNewLine() + "      , IDStatoNascita =  @IDStatoNascita   " + vbNewLine() + "      , IDStatoDomicilio =  @IDStatoDomicilio   " + vbNewLine() + "      , IDStatoResidenza =  @IDStatoResidenza   " + vbNewLine() + "      , IDComuneNascita =  @IDComuneNascita   " + vbNewLine() + "      , IDComuneDomicilio =  @IDComuneDomicilio   " + vbNewLine() + "      , IDComuneResidenza =  @IDComuneResidenza   " + vbNewLine() + "      , Note =  @Note   " + vbNewLine() + "      , WebSite =  @WebSite   " + vbNewLine() + "      , Foto =  @Foto   " + vbNewLine() + "      , IDQuartiereResidenza =  @IDQuartiereResidenza   " + vbNewLine() + "      , IDQuartiereDomicilio =  @IDQuartiereDomicilio   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPolicyPwd_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPolicyPwd   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPolicyPwd_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPolicyPwd   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPolicyPwd_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@ScadenzaPwd AS bit   " + vbNewLine() + "  ,@NumGiorni AS tinyint   " + vbNewLine() + "  ,@ChkPwdImmessa AS bit   " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint   " + vbNewLine() + "  ,@Sistema AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPolicyPwd (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,ScadenzaPwd   " + vbNewLine() + "    ,NumGiorni   " + vbNewLine() + "    ,ChkPwdImmessa   " + vbNewLine() + "    ,NumMaxChkPwdImmessa   " + vbNewLine() + "    ,Sistema   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@ScadenzaPwd   " + vbNewLine() + "    ,@NumGiorni   " + vbNewLine() + "    ,@ChkPwdImmessa   " + vbNewLine() + "    ,@NumMaxChkPwdImmessa   " + vbNewLine() + "    ,@Sistema   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPolicyPwd_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@ScadenzaPwd AS bit   " + vbNewLine() + "  ,@NumGiorni AS tinyint   " + vbNewLine() + "  ,@ChkPwdImmessa AS bit   " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint   " + vbNewLine() + "  ,@Sistema AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPolicyPwd (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,ScadenzaPwd   " + vbNewLine() + "    ,NumGiorni   " + vbNewLine() + "    ,ChkPwdImmessa   " + vbNewLine() + "    ,NumMaxChkPwdImmessa   " + vbNewLine() + "    ,Sistema   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@ScadenzaPwd   " + vbNewLine() + "    ,@NumGiorni   " + vbNewLine() + "    ,@ChkPwdImmessa   " + vbNewLine() + "    ,@NumMaxChkPwdImmessa   " + vbNewLine() + "    ,@Sistema   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPolicyPwd_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@ScadenzaPwd AS bit = NULL    " + vbNewLine() + "  ,@NumGiorni AS tinyint = NULL    " + vbNewLine() + "  ,@ChkPwdImmessa AS bit = NULL    " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint = NULL    " + vbNewLine() + "  ,@Sistema AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysPolicyPwd Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@ScadenzaPwd IS NULL OR Me.ScadenzaPwd = @ScadenzaPwd)    " + vbNewLine() + "    AND  (@NumGiorni IS NULL OR Me.NumGiorni = @NumGiorni)    " + vbNewLine() + "    AND  (@ChkPwdImmessa IS NULL OR Me.ChkPwdImmessa = @ChkPwdImmessa)    " + vbNewLine() + "    AND  (@NumMaxChkPwdImmessa IS NULL OR Me.NumMaxChkPwdImmessa = @NumMaxChkPwdImmessa)    " + vbNewLine() + "    AND  (@Sistema IS NULL OR Me.Sistema = @Sistema)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPolicyPwd_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@ScadenzaPwd AS bit = NULL    " + vbNewLine() + "  ,@NumGiorni AS tinyint = NULL    " + vbNewLine() + "  ,@ChkPwdImmessa AS bit = NULL    " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint = NULL    " + vbNewLine() + "  ,@Sistema AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysPolicyPwd Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@ScadenzaPwd IS NULL OR Me.ScadenzaPwd = @ScadenzaPwd)    " + vbNewLine() + "    AND  (@NumGiorni IS NULL OR Me.NumGiorni = @NumGiorni)    " + vbNewLine() + "    AND  (@ChkPwdImmessa IS NULL OR Me.ChkPwdImmessa = @ChkPwdImmessa)    " + vbNewLine() + "    AND  (@NumMaxChkPwdImmessa IS NULL OR Me.NumMaxChkPwdImmessa = @NumMaxChkPwdImmessa)    " + vbNewLine() + "    AND  (@Sistema IS NULL OR Me.Sistema = @Sistema)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPolicyPwd_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [ScadenzaPwd]   " + vbNewLine() + "    , [NumGiorni]   " + vbNewLine() + "    , [ChkPwdImmessa]   " + vbNewLine() + "    , [NumMaxChkPwdImmessa]   " + vbNewLine() + "    , [Sistema]   " + vbNewLine() + "  FROM sysPolicyPwd WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPolicyPwd_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [ScadenzaPwd]   " + vbNewLine() + "    , [NumGiorni]   " + vbNewLine() + "    , [ChkPwdImmessa]   " + vbNewLine() + "    , [NumMaxChkPwdImmessa]   " + vbNewLine() + "    , [Sistema]   " + vbNewLine() + "  FROM sysPolicyPwd WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPolicyPwd_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@ScadenzaPwd AS bit   " + vbNewLine() + "  ,@NumGiorni AS tinyint   " + vbNewLine() + "  ,@ChkPwdImmessa AS bit   " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint   " + vbNewLine() + "  ,@Sistema AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPolicyPwd   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , ScadenzaPwd =  @ScadenzaPwd   " + vbNewLine() + "      , NumGiorni =  @NumGiorni   " + vbNewLine() + "      , ChkPwdImmessa =  @ChkPwdImmessa   " + vbNewLine() + "      , NumMaxChkPwdImmessa =  @NumMaxChkPwdImmessa   " + vbNewLine() + "      , Sistema =  @Sistema   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPolicyPwd_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@ScadenzaPwd AS bit   " + vbNewLine() + "  ,@NumGiorni AS tinyint   " + vbNewLine() + "  ,@ChkPwdImmessa AS bit   " + vbNewLine() + "  ,@NumMaxChkPwdImmessa AS smallint   " + vbNewLine() + "  ,@Sistema AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPolicyPwd   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , ScadenzaPwd =  @ScadenzaPwd   " + vbNewLine() + "      , NumGiorni =  @NumGiorni   " + vbNewLine() + "      , ChkPwdImmessa =  @ChkPwdImmessa   " + vbNewLine() + "      , NumMaxChkPwdImmessa =  @NumMaxChkPwdImmessa   " + vbNewLine() + "      , Sistema =  @Sistema   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfili_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfili_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfili_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@Immagine AS varbinary(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProfili (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,DataInizio   " + vbNewLine() + "    ,DataFine   " + vbNewLine() + "    ,Note   " + vbNewLine() + "    ,Immagine   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@DataInizio   " + vbNewLine() + "    ,@DataFine   " + vbNewLine() + "    ,@Note   " + vbNewLine() + "    ,@Immagine   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfili_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@Immagine AS varbinary(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProfili (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,DataInizio   " + vbNewLine() + "    ,DataFine   " + vbNewLine() + "    ,Note   " + vbNewLine() + "    ,Immagine   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@DataInizio   " + vbNewLine() + "    ,@DataFine   " + vbNewLine() + "    ,@Note   " + vbNewLine() + "    ,@Immagine   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfili_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@DataInizioDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineAl AS datetime = NULL    " + vbNewLine() + "  ,@Note AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysProfili Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataInizioDal IS NULL OR Me.DataInizio >= @DataInizioDal)    " + vbNewLine() + "    AND  (@DataInizioAl IS NULL OR Me.DataInizio <= @DataInizioAl)    " + vbNewLine() + "    AND  (@DataFineDal IS NULL OR Me.DataFine >= @DataFineDal)    " + vbNewLine() + "    AND  (@DataFineAl IS NULL OR Me.DataFine <= @DataFineAl)    " + vbNewLine() + "    AND  (@Note IS NULL OR Me.Note LIKE @Note + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfili_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@DataInizioDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineAl AS datetime = NULL    " + vbNewLine() + "  ,@Note AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysProfili Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataInizioDal IS NULL OR Me.DataInizio >= @DataInizioDal)    " + vbNewLine() + "    AND  (@DataInizioAl IS NULL OR Me.DataInizio <= @DataInizioAl)    " + vbNewLine() + "    AND  (@DataFineDal IS NULL OR Me.DataFine >= @DataFineDal)    " + vbNewLine() + "    AND  (@DataFineAl IS NULL OR Me.DataFine <= @DataFineAl)    " + vbNewLine() + "    AND  (@Note IS NULL OR Me.Note LIKE @Note + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfili_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataInizio]   " + vbNewLine() + "    , [DataFine]   " + vbNewLine() + "    , [Note]   " + vbNewLine() + "    , [Immagine]   " + vbNewLine() + "  FROM sysProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfili_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataInizio]   " + vbNewLine() + "    , [DataFine]   " + vbNewLine() + "    , [Note]   " + vbNewLine() + "    , [Immagine]   " + vbNewLine() + "  FROM sysProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysProfili_SYNC] " + vbNewLine() + "  @IDApplicazione AS int  " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN  " + vbNewLine() + " " + vbNewLine() + "	truncate table sysProfili " + vbNewLine() + "	truncate table sysProfiliFunzioni " + vbNewLine() + " " + vbNewLine() + "	SET IDENTITY_INSERT dbo.sysProfili ON;   " + vbNewLine() + " " + vbNewLine() + "	INSERT INTO [dbo].[sysProfili] " + vbNewLine() + "			   (ID,  " + vbNewLine() + "			   [Descrizione] " + vbNewLine() + "			   ,[DataInizio] " + vbNewLine() + "			   ,[DataFine] " + vbNewLine() + "			   ,[Note] " + vbNewLine() + "			   ,[Immagine]) " + vbNewLine() + "	SELECT   " + vbNewLine() + "		IDProfilo as ID " + vbNewLine() + "		,Descrizione " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "    FROM WebPers..ApplicazioniProfili ap " + vbNewLine() + "    WHERE   " + vbNewLine() + "      IDApplicazione = @IDApplicazione " + vbNewLine() + " " + vbNewLine() + "	SET IDENTITY_INSERT dbo.sysProfili Off;   " + vbNewLine() + "   " + vbNewLine() + "END " + vbNewLine() + " " + vbNewLine() + " " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysProfili_SYNC] " + vbNewLine() + "  @IDApplicazione AS int  " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN  " + vbNewLine() + " " + vbNewLine() + "	truncate table sysProfili " + vbNewLine() + "	truncate table sysProfiliFunzioni " + vbNewLine() + " " + vbNewLine() + "	SET IDENTITY_INSERT dbo.sysProfili ON;   " + vbNewLine() + " " + vbNewLine() + "	INSERT INTO [dbo].[sysProfili] " + vbNewLine() + "			   (ID,  " + vbNewLine() + "			   [Descrizione] " + vbNewLine() + "			   ,[DataInizio] " + vbNewLine() + "			   ,[DataFine] " + vbNewLine() + "			   ,[Note] " + vbNewLine() + "			   ,[Immagine]) " + vbNewLine() + "	SELECT   " + vbNewLine() + "		IDProfilo as ID " + vbNewLine() + "		,Descrizione " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "		, null " + vbNewLine() + "    FROM WebPers..ApplicazioniProfili ap " + vbNewLine() + "    WHERE   " + vbNewLine() + "      IDApplicazione = @IDApplicazione " + vbNewLine() + " " + vbNewLine() + "	SET IDENTITY_INSERT dbo.sysProfili Off;   " + vbNewLine() + "   " + vbNewLine() + "END " + vbNewLine() + " " + vbNewLine() + " " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfili_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@Immagine AS varbinary(MAX) = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProfili   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , DataInizio =  @DataInizio   " + vbNewLine() + "      , DataFine =  @DataFine   " + vbNewLine() + "      , Note =  @Note   " + vbNewLine() + "      , Immagine =  @Immagine   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfili_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Note AS nvarchar(MAX)   " + vbNewLine() + "  ,@Immagine AS varbinary(MAX) = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProfili   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , DataInizio =  @DataInizio   " + vbNewLine() + "      , DataFine =  @DataFine   " + vbNewLine() + "      , Note =  @Note   " + vbNewLine() + "      , Immagine =  @Immagine   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_DELETE    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfiliFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_DELETE    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfiliFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_DELETEALL    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfiliFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_DELETEALL    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProfiliFunzioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_INSERT    " + vbNewLine() + "  @IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@IDSysRuolo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProfiliFunzioni (    " + vbNewLine() + "    IDSysProfilo   " + vbNewLine() + "    ,IDSysFunzione   " + vbNewLine() + "    ,IDSysRuolo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysProfilo   " + vbNewLine() + "    ,@IDSysFunzione   " + vbNewLine() + "    ,@IDSysRuolo   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_INSERT    " + vbNewLine() + "  @IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysFunzione AS int   " + vbNewLine() + "  ,@IDSysRuolo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProfiliFunzioni (    " + vbNewLine() + "    IDSysProfilo   " + vbNewLine() + "    ,IDSysFunzione   " + vbNewLine() + "    ,IDSysRuolo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysProfilo   " + vbNewLine() + "    ,@IDSysFunzione   " + vbNewLine() + "    ,@IDSysRuolo   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_SEARCH    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + "  ,@IDSysRuolo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysFunzioni.Descrizione SysFunzione   " + vbNewLine() + "    , sysRuoli.Descrizione SysRuolo   " + vbNewLine() + "  FROM sysProfiliFunzioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysFunzioni sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysFunzione = sysFunzioni.ID   " + vbNewLine() + "    LEFT JOIN sysRuoli sysRuoli WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysRuolo = sysRuoli.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysFunzione IS NULL OR Me.IDSysFunzione = @IDSysFunzione)    " + vbNewLine() + "    AND  (@IDSysRuolo IS NULL OR Me.IDSysRuolo = @IDSysRuolo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_SEARCH    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + "  ,@IDSysRuolo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysFunzioni.Descrizione SysFunzione   " + vbNewLine() + "    , sysRuoli.Descrizione SysRuolo   " + vbNewLine() + "  FROM sysProfiliFunzioni Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysFunzioni sysFunzioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysFunzione = sysFunzioni.ID   " + vbNewLine() + "    LEFT JOIN sysRuoli sysRuoli WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysRuolo = sysRuoli.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysFunzione IS NULL OR Me.IDSysFunzione = @IDSysFunzione)    " + vbNewLine() + "    AND  (@IDSysRuolo IS NULL OR Me.IDSysRuolo = @IDSysRuolo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_SELECT    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysProfilo]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [IDSysRuolo]   " + vbNewLine() + "  FROM sysProfiliFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_SELECT    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysProfilo]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [IDSysRuolo]   " + vbNewLine() + "  FROM sysProfiliFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_SELECTALL    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysProfilo]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [IDSysRuolo]   " + vbNewLine() + "  FROM sysProfiliFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_SELECTALL    " + vbNewLine() + "  @IDSysProfilo AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysProfilo]   " + vbNewLine() + "    , [IDSysFunzione]   " + vbNewLine() + "    , [IDSysRuolo]   " + vbNewLine() + "  FROM sysProfiliFunzioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProfiliFunzioni_UPDATE    " + vbNewLine() + "  @IDSysProfilo AS int = NULL   " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL   " + vbNewLine() + "  ,@IDSysRuolo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProfiliFunzioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysRuolo =  @IDSysRuolo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProfiliFunzioni_UPDATE    " + vbNewLine() + "  @IDSysProfilo AS int = NULL   " + vbNewLine() + "  ,@IDSysFunzione AS int = NULL   " + vbNewLine() + "  ,@IDSysRuolo AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProfiliFunzioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDSysRuolo =  @IDSysRuolo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysFunzione = @IDSysFunzione   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProvince_DELETE    " + vbNewLine() + "  @ID AS nvarchar(2) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProvince   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProvince_DELETE    " + vbNewLine() + "  @ID AS nvarchar(2) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysProvince   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProvince_INSERT    " + vbNewLine() + "  @ID AS nvarchar(2)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@IDRegione AS nvarchar(3)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProvince (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,IDRegione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@IDRegione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProvince_INSERT    " + vbNewLine() + "  @ID AS nvarchar(2)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@IDRegione AS nvarchar(3)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysProvince (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,IDRegione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@IDRegione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProvince_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(2) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@IDRegione AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysRegioni.Descrizione Regione   " + vbNewLine() + "  FROM sysProvince Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysRegioni sysRegioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDRegione = sysRegioni.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@IDRegione IS NULL OR Me.IDRegione LIKE @IDRegione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProvince_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(2) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@IDRegione AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysRegioni.Descrizione Regione   " + vbNewLine() + "  FROM sysProvince Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysRegioni sysRegioni WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDRegione = sysRegioni.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@IDRegione IS NULL OR Me.IDRegione LIKE @IDRegione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProvince_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(2) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [IDRegione]   " + vbNewLine() + "  FROM sysProvince WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProvince_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(2) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [IDRegione]   " + vbNewLine() + "  FROM sysProvince WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysProvince_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(2) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@IDRegione AS nvarchar(3)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProvince   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , IDRegione =  @IDRegione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysProvince_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(2) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@IDRegione AS nvarchar(3)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysProvince   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , IDRegione =  @IDRegione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPwdUtilizzate_DELETE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@Data AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPwdUtilizzate   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPwdUtilizzate_DELETE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@Data AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysPwdUtilizzate   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPwdUtilizzate_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPwdUtilizzate (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Password   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPwdUtilizzate_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Data AS datetime   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysPwdUtilizzate (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,Data   " + vbNewLine() + "    ,Password   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@Data   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPwdUtilizzate_SEARCH    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysPwdUtilizzate Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysUtente IS NULL OR Me.IDSysUtente = @IDSysUtente)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPwdUtilizzate_SEARCH    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataAl AS datetime = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysPwdUtilizzate Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysUtente IS NULL OR Me.IDSysUtente = @IDSysUtente)    " + vbNewLine() + "    AND  (@DataDal IS NULL OR Me.Data >= @DataDal)    " + vbNewLine() + "    AND  (@DataAl IS NULL OR Me.Data <= @DataAl)    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPwdUtilizzate_SELECT    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Data AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "  FROM sysPwdUtilizzate WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPwdUtilizzate_SELECT    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Data AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [Data]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "  FROM sysPwdUtilizzate WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysPwdUtilizzate_UPDATE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@Data AS datetime = NULL   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPwdUtilizzate   " + vbNewLine() + "    SET    " + vbNewLine() + "      Password =  @Password   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysPwdUtilizzate_UPDATE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@Data AS datetime = NULL   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysPwdUtilizzate   " + vbNewLine() + "    SET    " + vbNewLine() + "      Password =  @Password   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND Data = @Data   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegioni_DELETE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRegioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegioni_DELETE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRegioni   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegioni_INSERT    " + vbNewLine() + "  @ID AS nvarchar(3)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRegioni (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegioni_INSERT    " + vbNewLine() + "  @ID AS nvarchar(3)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRegioni (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegioni_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRegioni Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegioni_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRegioni Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegioni_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysRegioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegioni_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysRegioni WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegioni_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRegioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegioni_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRegioni   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegistrazioniRichieste_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRegistrazioniRichieste   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegistrazioniRichieste_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRegistrazioniRichieste   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegistrazioniRichieste_INSERT    " + vbNewLine() + "  @IDUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(20)   " + vbNewLine() + "  ,@Cognome AS nvarchar(20)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@email AS nvarchar(200)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRegistrazioniRichieste (    " + vbNewLine() + "    IDUtente   " + vbNewLine() + "    ,Nome   " + vbNewLine() + "    ,Cognome   " + vbNewLine() + "    ,DataNascita   " + vbNewLine() + "    ,IDComuneNascita   " + vbNewLine() + "    ,Sesso   " + vbNewLine() + "    ,CodiceFiscale   " + vbNewLine() + "    ,email   " + vbNewLine() + "    ,Password   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDUtente   " + vbNewLine() + "    ,@Nome   " + vbNewLine() + "    ,@Cognome   " + vbNewLine() + "    ,@DataNascita   " + vbNewLine() + "    ,@IDComuneNascita   " + vbNewLine() + "    ,@Sesso   " + vbNewLine() + "    ,@CodiceFiscale   " + vbNewLine() + "    ,@email   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegistrazioniRichieste_INSERT    " + vbNewLine() + "  @IDUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(20)   " + vbNewLine() + "  ,@Cognome AS nvarchar(20)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@email AS nvarchar(200)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRegistrazioniRichieste (    " + vbNewLine() + "    IDUtente   " + vbNewLine() + "    ,Nome   " + vbNewLine() + "    ,Cognome   " + vbNewLine() + "    ,DataNascita   " + vbNewLine() + "    ,IDComuneNascita   " + vbNewLine() + "    ,Sesso   " + vbNewLine() + "    ,CodiceFiscale   " + vbNewLine() + "    ,email   " + vbNewLine() + "    ,Password   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDUtente   " + vbNewLine() + "    ,@Nome   " + vbNewLine() + "    ,@Cognome   " + vbNewLine() + "    ,@DataNascita   " + vbNewLine() + "    ,@IDComuneNascita   " + vbNewLine() + "    ,@Sesso   " + vbNewLine() + "    ,@CodiceFiscale   " + vbNewLine() + "    ,@email   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegistrazioniRichieste_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Nome AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Cognome AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataNascitaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNascitaAl AS datetime = NULL    " + vbNewLine() + "  ,@IDComuneNascita AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Sesso AS bit = NULL    " + vbNewLine() + "  ,@CodiceFiscale AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@email AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRegistrazioniRichieste Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDUtente IS NULL OR Me.IDUtente LIKE @IDUtente + '%')    " + vbNewLine() + "    AND  (@Nome IS NULL OR Me.Nome LIKE @Nome + '%')    " + vbNewLine() + "    AND  (@Cognome IS NULL OR Me.Cognome LIKE @Cognome + '%')    " + vbNewLine() + "    AND  (@DataNascitaDal IS NULL OR Me.DataNascita >= @DataNascitaDal)    " + vbNewLine() + "    AND  (@DataNascitaAl IS NULL OR Me.DataNascita <= @DataNascitaAl)    " + vbNewLine() + "    AND  (@IDComuneNascita IS NULL OR Me.IDComuneNascita LIKE @IDComuneNascita + '%')    " + vbNewLine() + "    AND  (@Sesso IS NULL OR Me.Sesso = @Sesso)    " + vbNewLine() + "    AND  (@CodiceFiscale IS NULL OR Me.CodiceFiscale LIKE @CodiceFiscale + '%')    " + vbNewLine() + "    AND  (@email IS NULL OR Me.email LIKE @email + '%')    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegistrazioniRichieste_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Nome AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Cognome AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@DataNascitaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNascitaAl AS datetime = NULL    " + vbNewLine() + "  ,@IDComuneNascita AS NVARCHAR(4) = NULL    " + vbNewLine() + "  ,@Sesso AS bit = NULL    " + vbNewLine() + "  ,@CodiceFiscale AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@email AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRegistrazioniRichieste Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDUtente IS NULL OR Me.IDUtente LIKE @IDUtente + '%')    " + vbNewLine() + "    AND  (@Nome IS NULL OR Me.Nome LIKE @Nome + '%')    " + vbNewLine() + "    AND  (@Cognome IS NULL OR Me.Cognome LIKE @Cognome + '%')    " + vbNewLine() + "    AND  (@DataNascitaDal IS NULL OR Me.DataNascita >= @DataNascitaDal)    " + vbNewLine() + "    AND  (@DataNascitaAl IS NULL OR Me.DataNascita <= @DataNascitaAl)    " + vbNewLine() + "    AND  (@IDComuneNascita IS NULL OR Me.IDComuneNascita LIKE @IDComuneNascita + '%')    " + vbNewLine() + "    AND  (@Sesso IS NULL OR Me.Sesso = @Sesso)    " + vbNewLine() + "    AND  (@CodiceFiscale IS NULL OR Me.CodiceFiscale LIKE @CodiceFiscale + '%')    " + vbNewLine() + "    AND  (@email IS NULL OR Me.email LIKE @email + '%')    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegistrazioniRichieste_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDUtente]   " + vbNewLine() + "    , [Nome]   " + vbNewLine() + "    , [Cognome]   " + vbNewLine() + "    , [DataNascita]   " + vbNewLine() + "    , [IDComuneNascita]   " + vbNewLine() + "    , [Sesso]   " + vbNewLine() + "    , [CodiceFiscale]   " + vbNewLine() + "    , [email]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "  FROM sysRegistrazioniRichieste WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegistrazioniRichieste_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDUtente]   " + vbNewLine() + "    , [Nome]   " + vbNewLine() + "    , [Cognome]   " + vbNewLine() + "    , [DataNascita]   " + vbNewLine() + "    , [IDComuneNascita]   " + vbNewLine() + "    , [Sesso]   " + vbNewLine() + "    , [CodiceFiscale]   " + vbNewLine() + "    , [email]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "  FROM sysRegistrazioniRichieste WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRegistrazioniRichieste_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(20)   " + vbNewLine() + "  ,@Cognome AS nvarchar(20)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@email AS nvarchar(200)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRegistrazioniRichieste   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDUtente =  @IDUtente   " + vbNewLine() + "      , Nome =  @Nome   " + vbNewLine() + "      , Cognome =  @Cognome   " + vbNewLine() + "      , DataNascita =  @DataNascita   " + vbNewLine() + "      , IDComuneNascita =  @IDComuneNascita   " + vbNewLine() + "      , Sesso =  @Sesso   " + vbNewLine() + "      , CodiceFiscale =  @CodiceFiscale   " + vbNewLine() + "      , email =  @email   " + vbNewLine() + "      , Password =  @Password   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRegistrazioniRichieste_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDUtente AS nvarchar(20)   " + vbNewLine() + "  ,@Nome AS nvarchar(20)   " + vbNewLine() + "  ,@Cognome AS nvarchar(20)   " + vbNewLine() + "  ,@DataNascita AS datetime   " + vbNewLine() + "  ,@IDComuneNascita AS nvarchar(4)   " + vbNewLine() + "  ,@Sesso AS bit   " + vbNewLine() + "  ,@CodiceFiscale AS nvarchar(20)   " + vbNewLine() + "  ,@email AS nvarchar(200)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRegistrazioniRichieste   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDUtente =  @IDUtente   " + vbNewLine() + "      , Nome =  @Nome   " + vbNewLine() + "      , Cognome =  @Cognome   " + vbNewLine() + "      , DataNascita =  @DataNascita   " + vbNewLine() + "      , IDComuneNascita =  @IDComuneNascita   " + vbNewLine() + "      , Sesso =  @Sesso   " + vbNewLine() + "      , CodiceFiscale =  @CodiceFiscale   " + vbNewLine() + "      , email =  @email   " + vbNewLine() + "      , Password =  @Password   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRuoli_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRuoli   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRuoli_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysRuoli   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRuoli_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRuoli (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRuoli_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysRuoli (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRuoli_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRuoli Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRuoli_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysRuoli Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRuoli_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysRuoli WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRuoli_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysRuoli WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysRuoli_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRuoli   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysRuoli_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysRuoli   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                        " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysSendMail]                           " + vbNewLine() + "  @NomeProfilo varchar(200) = NULL,                          " + vbNewLine() + "	@Mittente varchar(max) = NULL,                             " + vbNewLine() + "	@Destinatari varchar(max),                             " + vbNewLine() + "	@Destinatari_cc varchar(max) = NULL,                             " + vbNewLine() + "	@Destinatari_bcc varchar(max) = NULL,                             " + vbNewLine() + "	@ReplyTo varchar(max) = NULL,                             " + vbNewLine() + "	@Oggetto nvarchar(255),                             " + vbNewLine() + "	@Testo nvarchar(max) ,                        " + vbNewLine() + "  @Allegati varchar(max) = NULL                            " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                        " + vbNewLine() + "  DECLARE @IDMAIL AS int = NULL                        " + vbNewLine() + "                        " + vbNewLine() + "  EXEC msdb.dbo.sp_send_dbmail                             " + vbNewLine() + "    @profile_name = @NomeProfilo,                             " + vbNewLine() + "    @from_address = @mittente,                             " + vbNewLine() + "    @recipients = @destinatari,                             " + vbNewLine() + "    @copy_recipients = @destinatari_cc,                             " + vbNewLine() + "    @blind_copy_recipients = @destinatari_bcc,                             " + vbNewLine() + "    @reply_to = @ReplyTo,                             " + vbNewLine() + "    @subject = @oggetto,                             " + vbNewLine() + "    @body = @testo,                        " + vbNewLine() + "    @body_format = 'HTML', -- 'TEXT', 'HTML'                        " + vbNewLine() + "    @importance  = 'NORMAL', --'LOW', 'NORMAL', 'HIGH'                        " + vbNewLine() + "    @sensitivity = 'NORMAL', --'NORMAL', 'PERSONAL', 'PRIVATE', 'CONFIDENTIAL'                        " + vbNewLine() + "    @file_attachments = @Allegati,                        " + vbNewLine() + "    @mailitem_id = @IDMAIL OUTPUT                        " + vbNewLine() + "                        " + vbNewLine() + "                        " + vbNewLine() + "  SELECT @IDMAIL                        " + vbNewLine() + "                        " + vbNewLine() + "  /*                        " + vbNewLine() + "  SELECT *                         " + vbNewLine() + "  FROM msdb.dbo.sysmail_allitems m                         " + vbNewLine() + "    LEFT JOIN msdb.dbo.sysmail_log L on m.mailitem_id = l.mailitem_id                        " + vbNewLine() + "  WHERE M.mailitem_id = @IDMAIL                        " + vbNewLine() + " */                        " + vbNewLine() + "  --select * from msdb.dbo.sysmail_sentitems                         " + vbNewLine() + "  --select * from msdb.dbo.sysmail_allitems                        " + vbNewLine() + "  --select * from msdb.dbo.sysmail_log                        " + vbNewLine() + "END                        " + vbNewLine() + "                        " + vbNewLine() + "                          " + vbNewLine() + "                        " + vbNewLine() + "                        " + vbNewLine() + "/*                             " + vbNewLine() + "                        " + vbNewLine() + "Prima dell'utilizzo, è necessario abilitare Posta elettronica database mediante                             " + vbNewLine() + "la Configurazione guidata posta elettronica database o sp_configure                             " + vbNewLine() + "                             " + vbNewLine() + "0) DEV3 -> Management -> Database Mail -> *tasto destro mouse* -> Configure database mail...                             " + vbNewLine() + "1) Manage Database Mail accounts and profiles                             " + vbNewLine() + "2) Create a new account                             " + vbNewLine() + "	Account Name: DEV3 Account                             " + vbNewLine() + "	E-mail address: DEV3_NO_REPLY@posteitaliane.it                             " + vbNewLine() + "	Display name: DEV3 SQL Database Mail                             " + vbNewLine() + "	Server name: smtpinternal.rete.poste                             " + vbNewLine() + "	Port number: 25                             " + vbNewLine() + "	This server requires a secure connection (SSL): No                             " + vbNewLine() + "	SMTP Autentication: Anonymous authentication                             " + vbNewLine() + "3) Create a new profile                             " + vbNewLine() + "	Profile name: DEV3 SQL Database Mail Profile                             " + vbNewLine() + "	SMTP Account: Add... -> DEV3 Account                             " + vbNewLine() + "                             " + vbNewLine() + "                             " + vbNewLine() + "Se @profile viene omesso, sp_send_dbmail utilizza un profilo predefinito.                             " + vbNewLine() + "Se l'utente che invia il messaggio di posta elettronica dispone di un profilo privato                              " + vbNewLine() + "predefinito, Posta elettronica database utilizzerà tale profilo. Se all'utente non è                              " + vbNewLine() + "associato un profilo privato predefinito, per sp_send_dbmail verrà utilizzato                            il profilo pubblico predefinito. Se non è disponibile un profilo privato predefinito                              " + vbNewLine() + "per l'utente oppure un profilo pubblico predefinito, sp_send_dbmail restituisce un errore.                  " + vbNewLine() + "                             " + vbNewLine() + "                             " + vbNewLine() + "sp_send_dbmail non supporta messaggi di posta elettronica senza contenuto.                 " + vbNewLine() + "Per inviare un messaggio di posta elettronica, è necessario specificare almeno                              " + vbNewLine() + "uno dei parametri @subject, @body, @query, @file_attachments.                             " + vbNewLine() + "In caso contrario, sp_send_dbmail restituisce un errore.                             " + vbNewLine() + "*/                            " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                        " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysSendMail]                           " + vbNewLine() + "  @NomeProfilo varchar(200) = NULL,                          " + vbNewLine() + "	@Mittente varchar(max) = NULL,                             " + vbNewLine() + "	@Destinatari varchar(max),                             " + vbNewLine() + "	@Destinatari_cc varchar(max) = NULL,                             " + vbNewLine() + "	@Destinatari_bcc varchar(max) = NULL,                             " + vbNewLine() + "	@ReplyTo varchar(max) = NULL,                             " + vbNewLine() + "	@Oggetto nvarchar(255),                             " + vbNewLine() + "	@Testo nvarchar(max) ,                        " + vbNewLine() + "  @Allegati varchar(max) = NULL                            " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                        " + vbNewLine() + "  DECLARE @IDMAIL AS int = NULL                        " + vbNewLine() + "                        " + vbNewLine() + "  EXEC msdb.dbo.sp_send_dbmail                             " + vbNewLine() + "    @profile_name = @NomeProfilo,                             " + vbNewLine() + "    @from_address = @mittente,                             " + vbNewLine() + "    @recipients = @destinatari,                             " + vbNewLine() + "    @copy_recipients = @destinatari_cc,                             " + vbNewLine() + "    @blind_copy_recipients = @destinatari_bcc,                             " + vbNewLine() + "    @reply_to = @ReplyTo,                             " + vbNewLine() + "    @subject = @oggetto,                             " + vbNewLine() + "    @body = @testo,                        " + vbNewLine() + "    @body_format = 'HTML', -- 'TEXT', 'HTML'                        " + vbNewLine() + "    @importance  = 'NORMAL', --'LOW', 'NORMAL', 'HIGH'                        " + vbNewLine() + "    @sensitivity = 'NORMAL', --'NORMAL', 'PERSONAL', 'PRIVATE', 'CONFIDENTIAL'                        " + vbNewLine() + "    @file_attachments = @Allegati,                        " + vbNewLine() + "    @mailitem_id = @IDMAIL OUTPUT                        " + vbNewLine() + "                        " + vbNewLine() + "                        " + vbNewLine() + "  SELECT @IDMAIL                        " + vbNewLine() + "                        " + vbNewLine() + "  /*                        " + vbNewLine() + "  SELECT *                         " + vbNewLine() + "  FROM msdb.dbo.sysmail_allitems m                         " + vbNewLine() + "    LEFT JOIN msdb.dbo.sysmail_log L on m.mailitem_id = l.mailitem_id                        " + vbNewLine() + "  WHERE M.mailitem_id = @IDMAIL                        " + vbNewLine() + " */                        " + vbNewLine() + "  --select * from msdb.dbo.sysmail_sentitems                         " + vbNewLine() + "  --select * from msdb.dbo.sysmail_allitems                        " + vbNewLine() + "  --select * from msdb.dbo.sysmail_log                        " + vbNewLine() + "END                        " + vbNewLine() + "                        " + vbNewLine() + "                          " + vbNewLine() + "                        " + vbNewLine() + "                        " + vbNewLine() + "/*                             " + vbNewLine() + "                        " + vbNewLine() + "Prima dell'utilizzo, è necessario abilitare Posta elettronica database mediante                             " + vbNewLine() + "la Configurazione guidata posta elettronica database o sp_configure                             " + vbNewLine() + "                             " + vbNewLine() + "0) DEV3 -> Management -> Database Mail -> *tasto destro mouse* -> Configure database mail...                             " + vbNewLine() + "1) Manage Database Mail accounts and profiles                             " + vbNewLine() + "2) Create a new account                             " + vbNewLine() + "	Account Name: DEV3 Account                             " + vbNewLine() + "	E-mail address: DEV3_NO_REPLY@posteitaliane.it                             " + vbNewLine() + "	Display name: DEV3 SQL Database Mail                             " + vbNewLine() + "	Server name: smtpinternal.rete.poste                             " + vbNewLine() + "	Port number: 25                             " + vbNewLine() + "	This server requires a secure connection (SSL): No                             " + vbNewLine() + "	SMTP Autentication: Anonymous authentication                             " + vbNewLine() + "3) Create a new profile                             " + vbNewLine() + "	Profile name: DEV3 SQL Database Mail Profile                             " + vbNewLine() + "	SMTP Account: Add... -> DEV3 Account                             " + vbNewLine() + "                             " + vbNewLine() + "                             " + vbNewLine() + "Se @profile viene omesso, sp_send_dbmail utilizza un profilo predefinito.                             " + vbNewLine() + "Se l'utente che invia il messaggio di posta elettronica dispone di un profilo privato                              " + vbNewLine() + "predefinito, Posta elettronica database utilizzerà tale profilo. Se all'utente non è                              " + vbNewLine() + "associato un profilo privato predefinito, per sp_send_dbmail verrà utilizzato                            il profilo pubblico predefinito. Se non è disponibile un profilo privato predefinito                              " + vbNewLine() + "per l'utente oppure un profilo pubblico predefinito, sp_send_dbmail restituisce un errore.                  " + vbNewLine() + "                             " + vbNewLine() + "                             " + vbNewLine() + "sp_send_dbmail non supporta messaggi di posta elettronica senza contenuto.                 " + vbNewLine() + "Per inviare un messaggio di posta elettronica, è necessario specificare almeno                              " + vbNewLine() + "uno dei parametri @subject, @body, @query, @file_attachments.                             " + vbNewLine() + "In caso contrario, sp_send_dbmail restituisce un errore.                             " + vbNewLine() + "*/                            " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSeverity_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSeverity   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSeverity_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSeverity   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSeverity_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Bloccante AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSeverity (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,Bloccante   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@Bloccante   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSeverity_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Bloccante AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSeverity (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,Bloccante   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@Bloccante   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSeverity_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Bloccante AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSeverity Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Bloccante IS NULL OR Me.Bloccante = @Bloccante)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSeverity_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Bloccante AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSeverity Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Bloccante IS NULL OR Me.Bloccante = @Bloccante)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSeverity_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Bloccante]   " + vbNewLine() + "  FROM sysSeverity WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSeverity_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Bloccante]   " + vbNewLine() + "  FROM sysSeverity WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSeverity_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Bloccante AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSeverity   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , Bloccante =  @Bloccante   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSeverity_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Bloccante AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSeverity   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , Bloccante =  @Bloccante   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemi_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemi_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemi_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSistemi (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,DataInizio   " + vbNewLine() + "    ,DataFine   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@DataInizio   " + vbNewLine() + "    ,@DataFine   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemi_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSistemi (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "    ,DataInizio   " + vbNewLine() + "    ,DataFine   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "    ,@DataInizio   " + vbNewLine() + "    ,@DataFine   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemi_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@DataInizioDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineAl AS datetime = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSistemi Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataInizioDal IS NULL OR Me.DataInizio >= @DataInizioDal)    " + vbNewLine() + "    AND  (@DataInizioAl IS NULL OR Me.DataInizio <= @DataInizioAl)    " + vbNewLine() + "    AND  (@DataFineDal IS NULL OR Me.DataFine >= @DataFineDal)    " + vbNewLine() + "    AND  (@DataFineAl IS NULL OR Me.DataFine <= @DataFineAl)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemi_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(200) = NULL    " + vbNewLine() + "  ,@DataInizioDal AS datetime = NULL    " + vbNewLine() + "  ,@DataInizioAl AS datetime = NULL    " + vbNewLine() + "  ,@DataFineDal AS datetime = NULL    " + vbNewLine() + "  ,@DataFineAl AS datetime = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSistemi Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataInizioDal IS NULL OR Me.DataInizio >= @DataInizioDal)    " + vbNewLine() + "    AND  (@DataInizioAl IS NULL OR Me.DataInizio <= @DataInizioAl)    " + vbNewLine() + "    AND  (@DataFineDal IS NULL OR Me.DataFine >= @DataFineDal)    " + vbNewLine() + "    AND  (@DataFineAl IS NULL OR Me.DataFine <= @DataFineAl)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemi_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataInizio]   " + vbNewLine() + "    , [DataFine]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "  FROM sysSistemi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemi_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataInizio]   " + vbNewLine() + "    , [DataFine]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "  FROM sysSistemi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemi_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSistemi   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , DataInizio =  @DataInizio   " + vbNewLine() + "      , DataFine =  @DataFine   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemi_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(200)   " + vbNewLine() + "  ,@DataInizio AS datetime   " + vbNewLine() + "  ,@DataFine AS datetime   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSistemi   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , DataInizio =  @DataInizio   " + vbNewLine() + "      , DataFine =  @DataFine   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_DELETE    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemiAttributi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_DELETE    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemiAttributi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_DELETEALL    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemiAttributi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_DELETEALL    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysSistemiAttributi   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_INSERT    " + vbNewLine() + "  @IDSysSistema AS int   " + vbNewLine() + "  ,@Chiave AS varchar(250)   " + vbNewLine() + "  ,@Valore AS varchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSistemiAttributi (    " + vbNewLine() + "    IDSysSistema   " + vbNewLine() + "    ,Chiave   " + vbNewLine() + "    ,Valore   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysSistema   " + vbNewLine() + "    ,@Chiave   " + vbNewLine() + "    ,@Valore   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_INSERT    " + vbNewLine() + "  @IDSysSistema AS int   " + vbNewLine() + "  ,@Chiave AS varchar(250)   " + vbNewLine() + "  ,@Valore AS varchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysSistemiAttributi (    " + vbNewLine() + "    IDSysSistema   " + vbNewLine() + "    ,Chiave   " + vbNewLine() + "    ,Valore   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysSistema   " + vbNewLine() + "    ,@Chiave   " + vbNewLine() + "    ,@Valore   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_SEARCH    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + "  ,@Valore AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSistemiAttributi Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@Chiave IS NULL OR Me.Chiave = @Chiave)    " + vbNewLine() + "    AND  (@Valore IS NULL OR Me.Valore LIKE @Valore + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_SEARCH    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + "  ,@Valore AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysSistemiAttributi Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@Chiave IS NULL OR Me.Chiave = @Chiave)    " + vbNewLine() + "    AND  (@Valore IS NULL OR Me.Valore LIKE @Valore + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_SELECT    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysSistema]   " + vbNewLine() + "    , [Chiave]   " + vbNewLine() + "    , [Valore]   " + vbNewLine() + "  FROM sysSistemiAttributi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_SELECT    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysSistema]   " + vbNewLine() + "    , [Chiave]   " + vbNewLine() + "    , [Valore]   " + vbNewLine() + "  FROM sysSistemiAttributi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_SELECTALL    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysSistema]   " + vbNewLine() + "    , [Chiave]   " + vbNewLine() + "    , [Valore]   " + vbNewLine() + "  FROM sysSistemiAttributi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_SELECTALL    " + vbNewLine() + "  @IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysSistema]   " + vbNewLine() + "    , [Chiave]   " + vbNewLine() + "    , [Valore]   " + vbNewLine() + "  FROM sysSistemiAttributi WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysSistemiAttributi_UPDATE    " + vbNewLine() + "  @IDSysSistema AS int = NULL   " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL   " + vbNewLine() + "  ,@Valore AS varchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSistemiAttributi   " + vbNewLine() + "    SET    " + vbNewLine() + "      Valore =  @Valore   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysSistemiAttributi_UPDATE    " + vbNewLine() + "  @IDSysSistema AS int = NULL   " + vbNewLine() + "  ,@Chiave AS varchar(250) = NULL   " + vbNewLine() + "  ,@Valore AS varchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysSistemiAttributi   " + vbNewLine() + "    SET    " + vbNewLine() + "      Valore =  @Valore   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysSistema = @IDSysSistema   " + vbNewLine() + "    AND Chiave = @Chiave   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysStati_DELETE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysStati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysStati_DELETE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysStati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysStati_INSERT    " + vbNewLine() + "  @ID AS nvarchar(3)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Nota AS nvarchar(150)   " + vbNewLine() + "  ,@FlagCEE AS nvarchar(1)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysStati (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,Nota   " + vbNewLine() + "    ,FlagCEE   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@Nota   " + vbNewLine() + "    ,@FlagCEE   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysStati_INSERT    " + vbNewLine() + "  @ID AS nvarchar(3)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Nota AS nvarchar(150)   " + vbNewLine() + "  ,@FlagCEE AS nvarchar(1)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysStati (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,Nota   " + vbNewLine() + "    ,FlagCEE   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@Nota   " + vbNewLine() + "    ,@FlagCEE   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysStati_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Nota AS NVARCHAR(150) = NULL    " + vbNewLine() + "  ,@FlagCEE AS NVARCHAR(1) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysStati Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Nota IS NULL OR Me.Nota LIKE @Nota + '%')    " + vbNewLine() + "    AND  (@FlagCEE IS NULL OR Me.FlagCEE LIKE @FlagCEE + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysStati_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(50) = NULL    " + vbNewLine() + "  ,@Nota AS NVARCHAR(150) = NULL    " + vbNewLine() + "  ,@FlagCEE AS NVARCHAR(1) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysStati Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@Nota IS NULL OR Me.Nota LIKE @Nota + '%')    " + vbNewLine() + "    AND  (@FlagCEE IS NULL OR Me.FlagCEE LIKE @FlagCEE + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysStati_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Nota]   " + vbNewLine() + "    , [FlagCEE]   " + vbNewLine() + "  FROM sysStati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysStati_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(3) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [Nota]   " + vbNewLine() + "    , [FlagCEE]   " + vbNewLine() + "  FROM sysStati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysStati_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Nota AS nvarchar(150)   " + vbNewLine() + "  ,@FlagCEE AS nvarchar(1)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysStati   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , Nota =  @Nota   " + vbNewLine() + "      , FlagCEE =  @FlagCEE   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysStati_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(3) = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(50)   " + vbNewLine() + "  ,@Nota AS nvarchar(150)   " + vbNewLine() + "  ,@FlagCEE AS nvarchar(1)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysStati   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , Nota =  @Nota   " + vbNewLine() + "      , FlagCEE =  @FlagCEE   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "CREATE PROCEDURE BSP_sysUtenti_AUTOCOMPLETE   " + vbNewLine() + "--declare   " + vbNewLine() + "  @Descrizione AS NVARCHAR(MAX) = NULL   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "		Me.ID   " + vbNewLine() + "		, CASE    " + vbNewLine() + "				WHEN p.ID IS NULL THEN Me.Username    " + vbNewLine() + "				ELSE p.Cognome + ' ' + p.Nome + ' [' + Me.ID + ']'   " + vbNewLine() + "			END Descrizione   " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysPersone p WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPersona = p.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "		(p.Nome like @Descrizione + '%'   " + vbNewLine() + "		or p.Cognome like @Descrizione + '%'   " + vbNewLine() + "		or p.CodiceFiscale like @Descrizione + '%'   " + vbNewLine() + "		or Me.ID like @Descrizione + '%'   " + vbNewLine() + "		or Me.Username like @Descrizione + '%')   " + vbNewLine() + "		and isnull(Developer,0) = 0   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		CASE WHEN p.ID IS NULL THEN Me.Username ELSE p.Cognome + ' ' + p.Nome + ' ' + p.CodiceFiscale END   " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "CREATE PROCEDURE BSP_sysUtenti_AUTOCOMPLETE   " + vbNewLine() + "--declare   " + vbNewLine() + "  @Descrizione AS NVARCHAR(MAX) = NULL   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "		Me.ID   " + vbNewLine() + "		, CASE    " + vbNewLine() + "				WHEN p.ID IS NULL THEN Me.Username    " + vbNewLine() + "				ELSE p.Cognome + ' ' + p.Nome + ' [' + Me.ID + ']'   " + vbNewLine() + "			END Descrizione   " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysPersone p WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPersona = p.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "		(p.Nome like @Descrizione + '%'   " + vbNewLine() + "		or p.Cognome like @Descrizione + '%'   " + vbNewLine() + "		or p.CodiceFiscale like @Descrizione + '%'   " + vbNewLine() + "		or Me.ID like @Descrizione + '%'   " + vbNewLine() + "		or Me.Username like @Descrizione + '%')   " + vbNewLine() + "		and isnull(Developer,0) = 0   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		CASE WHEN p.ID IS NULL THEN Me.Username ELSE p.Cognome + ' ' + p.Nome + ' ' + p.CodiceFiscale END   " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysUtenti_CheckDomain]                   " + vbNewLine() + "	@Username as varchar(20)                   " + vbNewLine() + "as                   " + vbNewLine() + "begin                   " + vbNewLine() + "	SELECT                    " + vbNewLine() + "		Dominio                   " + vbNewLine() + "	FROM                   " + vbNewLine() + "		sysUtenti                   " + vbNewLine() + "	WHERE                   " + vbNewLine() + "		Username = @Username                   " + vbNewLine() + "end                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysUtenti_CheckDomain]                   " + vbNewLine() + "	@Username as varchar(20)                   " + vbNewLine() + "as                   " + vbNewLine() + "begin                   " + vbNewLine() + "	SELECT                    " + vbNewLine() + "		Dominio                   " + vbNewLine() + "	FROM                   " + vbNewLine() + "		sysUtenti                   " + vbNewLine() + "	WHERE                   " + vbNewLine() + "		Username = @Username                   " + vbNewLine() + "end                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].BSP_sysUtenti_CheckVirtualDomain                   " + vbNewLine() + "	@Username as varchar(20)                   " + vbNewLine() + "as                   " + vbNewLine() + "begin                   " + vbNewLine() + "	SELECT                    " + vbNewLine() + "		NTDomain Dominio                   " + vbNewLine() + "	FROM                   " + vbNewLine() + "		Biposte.dbo.personale                 " + vbNewLine() + "	WHERE                   " + vbNewLine() + "		NTAccount = @Username                   " + vbNewLine() + "end                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].BSP_sysUtenti_CheckVirtualDomain                   " + vbNewLine() + "	@Username as varchar(20)                   " + vbNewLine() + "as                   " + vbNewLine() + "begin                   " + vbNewLine() + "	SELECT                    " + vbNewLine() + "		NTDomain Dominio                   " + vbNewLine() + "	FROM                   " + vbNewLine() + "		Biposte.dbo.personale                 " + vbNewLine() + "	WHERE                   " + vbNewLine() + "		NTAccount = @Username                   " + vbNewLine() + "end                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_DELETE    " + vbNewLine() + "  @ID AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtenti   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_DELETE    " + vbNewLine() + "  @ID AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtenti   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_INSERT    " + vbNewLine() + "  @ID AS nvarchar(20)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int   " + vbNewLine() + "  ,@IDPersona AS int   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataScadenza AS datetime   " + vbNewLine() + "  ,@DataUltimoCambioPwd AS datetime   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Dominio AS varchar(50)   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@Username AS nvarchar(20)   " + vbNewLine() + "  ,@IDVisibilita AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtenti (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Password   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,IDSysPolicyPwd   " + vbNewLine() + "    ,IDPersona   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "    ,DataCreazione   " + vbNewLine() + "    ,DataScadenza   " + vbNewLine() + "    ,DataUltimoCambioPwd   " + vbNewLine() + "    ,Developer   " + vbNewLine() + "    ,Dominio   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,Username   " + vbNewLine() + "    ,IDVisibilita   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@IDSysPolicyPwd   " + vbNewLine() + "    ,@IDPersona   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "    ,@DataCreazione   " + vbNewLine() + "    ,@DataScadenza   " + vbNewLine() + "    ,@DataUltimoCambioPwd   " + vbNewLine() + "    ,@Developer   " + vbNewLine() + "    ,@Dominio   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@Username   " + vbNewLine() + "    ,@IDVisibilita   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_INSERT    " + vbNewLine() + "  @ID AS nvarchar(20)   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int   " + vbNewLine() + "  ,@IDPersona AS int   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataScadenza AS datetime   " + vbNewLine() + "  ,@DataUltimoCambioPwd AS datetime   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Dominio AS varchar(50)   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@Username AS nvarchar(20)   " + vbNewLine() + "  ,@IDVisibilita AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtenti (    " + vbNewLine() + "    ID   " + vbNewLine() + "    ,Password   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,IDSysPolicyPwd   " + vbNewLine() + "    ,IDPersona   " + vbNewLine() + "    ,Attivo   " + vbNewLine() + "    ,DataCreazione   " + vbNewLine() + "    ,DataScadenza   " + vbNewLine() + "    ,DataUltimoCambioPwd   " + vbNewLine() + "    ,Developer   " + vbNewLine() + "    ,Dominio   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "    ,Username   " + vbNewLine() + "    ,IDVisibilita   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @ID   " + vbNewLine() + "    ,@Password   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@IDSysPolicyPwd   " + vbNewLine() + "    ,@IDPersona   " + vbNewLine() + "    ,@Attivo   " + vbNewLine() + "    ,@DataCreazione   " + vbNewLine() + "    ,@DataScadenza   " + vbNewLine() + "    ,@DataUltimoCambioPwd   " + vbNewLine() + "    ,@Developer   " + vbNewLine() + "    ,@Dominio   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "    ,@Username   " + vbNewLine() + "    ,@IDVisibilita   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL    " + vbNewLine() + "  ,@IDPersona AS int = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + "  ,@DataCreazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCreazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataScadenzaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataScadenzaAl AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimoCambioPwdDal AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimoCambioPwdAl AS datetime = NULL    " + vbNewLine() + "  ,@Developer AS bit = NULL    " + vbNewLine() + "  ,@Dominio AS varchar(50) = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDVisibilita AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "    , sysPolicyPwd.Descrizione SysPolicyPwd   " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "    LEFT JOIN sysPolicyPwd sysPolicyPwd WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysPolicyPwd = sysPolicyPwd.ID   " + vbNewLine() + "    LEFT JOIN sysPersone sysPersone WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)    " + vbNewLine() + "    AND  (@IDPersona IS NULL OR Me.IDPersona = @IDPersona)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "    AND  (@DataCreazioneDal IS NULL OR Me.DataCreazione >= @DataCreazioneDal)    " + vbNewLine() + "    AND  (@DataCreazioneAl IS NULL OR Me.DataCreazione <= @DataCreazioneAl)    " + vbNewLine() + "    AND  (@DataScadenzaDal IS NULL OR Me.DataScadenza >= @DataScadenzaDal)    " + vbNewLine() + "    AND  (@DataScadenzaAl IS NULL OR Me.DataScadenza <= @DataScadenzaAl)    " + vbNewLine() + "    AND  (@DataUltimoCambioPwdDal IS NULL OR Me.DataUltimoCambioPwd >= @DataUltimoCambioPwdDal)    " + vbNewLine() + "    AND  (@DataUltimoCambioPwdAl IS NULL OR Me.DataUltimoCambioPwd <= @DataUltimoCambioPwdAl)    " + vbNewLine() + "    AND  (@Developer IS NULL OR Me.Developer = @Developer)    " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')    " + vbNewLine() + "    AND  (@IDVisibilita IS NULL OR Me.IDVisibilita = @IDVisibilita)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_SEARCH    " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@Password AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL    " + vbNewLine() + "  ,@IDPersona AS int = NULL    " + vbNewLine() + "  ,@Attivo AS bit = NULL    " + vbNewLine() + "  ,@DataCreazioneDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCreazioneAl AS datetime = NULL    " + vbNewLine() + "  ,@DataScadenzaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataScadenzaAl AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimoCambioPwdDal AS datetime = NULL    " + vbNewLine() + "  ,@DataUltimoCambioPwdAl AS datetime = NULL    " + vbNewLine() + "  ,@Developer AS bit = NULL    " + vbNewLine() + "  ,@Dominio AS varchar(50) = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDVisibilita AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "    , sysPolicyPwd.Descrizione SysPolicyPwd   " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "    LEFT JOIN sysPolicyPwd sysPolicyPwd WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysPolicyPwd = sysPolicyPwd.ID   " + vbNewLine() + "    LEFT JOIN sysPersone sysPersone WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Password IS NULL OR Me.Password LIKE @Password + '%')    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)    " + vbNewLine() + "    AND  (@IDPersona IS NULL OR Me.IDPersona = @IDPersona)    " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)    " + vbNewLine() + "    AND  (@DataCreazioneDal IS NULL OR Me.DataCreazione >= @DataCreazioneDal)    " + vbNewLine() + "    AND  (@DataCreazioneAl IS NULL OR Me.DataCreazione <= @DataCreazioneAl)    " + vbNewLine() + "    AND  (@DataScadenzaDal IS NULL OR Me.DataScadenza >= @DataScadenzaDal)    " + vbNewLine() + "    AND  (@DataScadenzaAl IS NULL OR Me.DataScadenza <= @DataScadenzaAl)    " + vbNewLine() + "    AND  (@DataUltimoCambioPwdDal IS NULL OR Me.DataUltimoCambioPwd >= @DataUltimoCambioPwdDal)    " + vbNewLine() + "    AND  (@DataUltimoCambioPwdAl IS NULL OR Me.DataUltimoCambioPwd <= @DataUltimoCambioPwdAl)    " + vbNewLine() + "    AND  (@Developer IS NULL OR Me.Developer = @Developer)    " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')    " + vbNewLine() + "    AND  (@IDVisibilita IS NULL OR Me.IDVisibilita = @IDVisibilita)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysPolicyPwd]   " + vbNewLine() + "    , [IDPersona]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "    , [DataCreazione]   " + vbNewLine() + "    , [DataScadenza]   " + vbNewLine() + "    , [DataUltimoCambioPwd]   " + vbNewLine() + "    , [Developer]   " + vbNewLine() + "    , [Dominio]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [Username]   " + vbNewLine() + "    , [IDVisibilita]   " + vbNewLine() + "  FROM sysUtenti WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_SELECT    " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Password]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysPolicyPwd]   " + vbNewLine() + "    , [IDPersona]   " + vbNewLine() + "    , [Attivo]   " + vbNewLine() + "    , [DataCreazione]   " + vbNewLine() + "    , [DataScadenza]   " + vbNewLine() + "    , [DataUltimoCambioPwd]   " + vbNewLine() + "    , [Developer]   " + vbNewLine() + "    , [Dominio]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "    , [Username]   " + vbNewLine() + "    , [IDVisibilita]   " + vbNewLine() + "  FROM sysUtenti WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_SELECT_ByEmail  " + vbNewLine() + "--DECLARE   " + vbNewLine() + "	@Email nvarchar(400)  " + vbNewLine() + "AS  " + vbNewLine() + "BEGIN  " + vbNewLine() + "	select u.*  " + vbNewLine() + "	from sysUtenti u   " + vbNewLine() + "		inner join sysPersone p on u.IDPersona = p.ID  " + vbNewLine() + "	where   " + vbNewLine() + "		p.Email = @Email  " + vbNewLine() + "END " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_SELECT_ByEmail  " + vbNewLine() + "--DECLARE   " + vbNewLine() + "	@Email nvarchar(400)  " + vbNewLine() + "AS  " + vbNewLine() + "BEGIN  " + vbNewLine() + "	select u.*  " + vbNewLine() + "	from sysUtenti u   " + vbNewLine() + "		inner join sysPersone p on u.IDPersona = p.ID  " + vbNewLine() + "	where   " + vbNewLine() + "		p.Email = @Email  " + vbNewLine() + "END " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysUtenti_SELECT_ByUserName]                     " + vbNewLine() + "--declare                " + vbNewLine() + "  @USERNAME AS VARCHAR(20) = ''                    " + vbNewLine() + "  , @DOMINIO AS VARCHAR(50) = ''                " + vbNewLine() + "AS                     " + vbNewLine() + "BEGIN                    " + vbNewLine() + "	SELECT                     " + vbNewLine() + "		[ID]                    " + vbNewLine() + "		, [IDSysSistema]                    " + vbNewLine() + "		, [IDSysProfilo]                    " + vbNewLine() + "		, [IDSysPolicyPwd]                    " + vbNewLine() + "		, [IDPersona]                    " + vbNewLine() + "		, [IDVisibilita]                   " + vbNewLine() + "		, [Attivo]                    " + vbNewLine() + "		, [DataCreazione]                    " + vbNewLine() + "		, [DataScadenza]                    " + vbNewLine() + "		, [DataUltimoCambioPwd]                    " + vbNewLine() + "		, [Developer]                    " + vbNewLine() + "		, [Username]                    " + vbNewLine() + "		, [Dominio]                    " + vbNewLine() + "		, [Password]                    " + vbNewLine() + "	FROM sysUtenti WITH(NOLOCK)                     " + vbNewLine() + "	WHERE                     " + vbNewLine() + "		Username= @USERNAME                    " + vbNewLine() + "		AND ISNULL(Dominio,'') = @DOMINIO                    " + vbNewLine() + "END                     " + vbNewLine() + "            " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysUtenti_SELECT_ByUserName]                     " + vbNewLine() + "--declare                " + vbNewLine() + "  @USERNAME AS VARCHAR(20) = ''                    " + vbNewLine() + "  , @DOMINIO AS VARCHAR(50) = ''                " + vbNewLine() + "AS                     " + vbNewLine() + "BEGIN                    " + vbNewLine() + "	SELECT                     " + vbNewLine() + "		[ID]                    " + vbNewLine() + "		, [IDSysSistema]                    " + vbNewLine() + "		, [IDSysProfilo]                    " + vbNewLine() + "		, [IDSysPolicyPwd]                    " + vbNewLine() + "		, [IDPersona]                    " + vbNewLine() + "		, [IDVisibilita]                   " + vbNewLine() + "		, [Attivo]                    " + vbNewLine() + "		, [DataCreazione]                    " + vbNewLine() + "		, [DataScadenza]                    " + vbNewLine() + "		, [DataUltimoCambioPwd]                    " + vbNewLine() + "		, [Developer]                    " + vbNewLine() + "		, [Username]                    " + vbNewLine() + "		, [Dominio]                    " + vbNewLine() + "		, [Password]                    " + vbNewLine() + "	FROM sysUtenti WITH(NOLOCK)                     " + vbNewLine() + "	WHERE                     " + vbNewLine() + "		Username= @USERNAME                    " + vbNewLine() + "		AND ISNULL(Dominio,'') = @DOMINIO                    " + vbNewLine() + "END                     " + vbNewLine() + "            " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtenti_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int   " + vbNewLine() + "  ,@IDPersona AS int   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataScadenza AS datetime   " + vbNewLine() + "  ,@DataUltimoCambioPwd AS datetime   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Dominio AS varchar(50)   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@Username AS nvarchar(20)   " + vbNewLine() + "  ,@IDVisibilita AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysUtenti   " + vbNewLine() + "    SET    " + vbNewLine() + "      Password =  @Password   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "      , IDSysPolicyPwd =  @IDSysPolicyPwd   " + vbNewLine() + "      , IDPersona =  @IDPersona   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "      , DataCreazione =  @DataCreazione   " + vbNewLine() + "      , DataScadenza =  @DataScadenza   " + vbNewLine() + "      , DataUltimoCambioPwd =  @DataUltimoCambioPwd   " + vbNewLine() + "      , Developer =  @Developer   " + vbNewLine() + "      , Dominio =  @Dominio   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , Username =  @Username   " + vbNewLine() + "      , IDVisibilita =  @IDVisibilita   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtenti_UPDATE    " + vbNewLine() + "  @ID AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@Password AS nvarchar(MAX)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int   " + vbNewLine() + "  ,@IDPersona AS int   " + vbNewLine() + "  ,@Attivo AS bit   " + vbNewLine() + "  ,@DataCreazione AS datetime   " + vbNewLine() + "  ,@DataScadenza AS datetime   " + vbNewLine() + "  ,@DataUltimoCambioPwd AS datetime   " + vbNewLine() + "  ,@Developer AS bit   " + vbNewLine() + "  ,@Dominio AS varchar(50)   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + "  ,@Username AS nvarchar(20)   " + vbNewLine() + "  ,@IDVisibilita AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysUtenti   " + vbNewLine() + "    SET    " + vbNewLine() + "      Password =  @Password   " + vbNewLine() + "      , IDSysProfilo =  @IDSysProfilo   " + vbNewLine() + "      , IDSysPolicyPwd =  @IDSysPolicyPwd   " + vbNewLine() + "      , IDPersona =  @IDPersona   " + vbNewLine() + "      , Attivo =  @Attivo   " + vbNewLine() + "      , DataCreazione =  @DataCreazione   " + vbNewLine() + "      , DataScadenza =  @DataScadenza   " + vbNewLine() + "      , DataUltimoCambioPwd =  @DataUltimoCambioPwd   " + vbNewLine() + "      , Developer =  @Developer   " + vbNewLine() + "      , Dominio =  @Dominio   " + vbNewLine() + "      , IDSysSistema =  @IDSysSistema   " + vbNewLine() + "      , Username =  @Username   " + vbNewLine() + "      , IDVisibilita =  @IDVisibilita   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_DELETE    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_DELETE    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_DELETEALL    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_DELETEALL    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiNotifiche   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_INSERT    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@IDsysNotifica AS int   " + vbNewLine() + "  ,@Letta AS bit   " + vbNewLine() + "  ,@Notificata AS bit   " + vbNewLine() + "  ,@Cancellata AS bit   " + vbNewLine() + "  ,@DataLetta AS datetime   " + vbNewLine() + "  ,@DataNotificata AS datetime   " + vbNewLine() + "  ,@DataCancellata AS datetime   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtentiNotifiche (    " + vbNewLine() + "    IDsysUtente   " + vbNewLine() + "    ,IDsysNotifica   " + vbNewLine() + "    ,Letta   " + vbNewLine() + "    ,Notificata   " + vbNewLine() + "    ,Cancellata   " + vbNewLine() + "    ,DataLetta   " + vbNewLine() + "    ,DataNotificata   " + vbNewLine() + "    ,DataCancellata   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDsysUtente   " + vbNewLine() + "    ,@IDsysNotifica   " + vbNewLine() + "    ,@Letta   " + vbNewLine() + "    ,@Notificata   " + vbNewLine() + "    ,@Cancellata   " + vbNewLine() + "    ,@DataLetta   " + vbNewLine() + "    ,@DataNotificata   " + vbNewLine() + "    ,@DataCancellata   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_INSERT    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@IDsysNotifica AS int   " + vbNewLine() + "  ,@Letta AS bit   " + vbNewLine() + "  ,@Notificata AS bit   " + vbNewLine() + "  ,@Cancellata AS bit   " + vbNewLine() + "  ,@DataLetta AS datetime   " + vbNewLine() + "  ,@DataNotificata AS datetime   " + vbNewLine() + "  ,@DataCancellata AS datetime   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtentiNotifiche (    " + vbNewLine() + "    IDsysUtente   " + vbNewLine() + "    ,IDsysNotifica   " + vbNewLine() + "    ,Letta   " + vbNewLine() + "    ,Notificata   " + vbNewLine() + "    ,Cancellata   " + vbNewLine() + "    ,DataLetta   " + vbNewLine() + "    ,DataNotificata   " + vbNewLine() + "    ,DataCancellata   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDsysUtente   " + vbNewLine() + "    ,@IDsysNotifica   " + vbNewLine() + "    ,@Letta   " + vbNewLine() + "    ,@Notificata   " + vbNewLine() + "    ,@Cancellata   " + vbNewLine() + "    ,@DataLetta   " + vbNewLine() + "    ,@DataNotificata   " + vbNewLine() + "    ,@DataCancellata   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_SEARCH    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + "  ,@Letta AS bit = NULL    " + vbNewLine() + "  ,@Notificata AS bit = NULL    " + vbNewLine() + "  ,@Cancellata AS bit = NULL    " + vbNewLine() + "  ,@DataLettaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataLettaAl AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificataAl AS datetime = NULL    " + vbNewLine() + "  ,@DataCancellataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCancellataAl AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysUtentiNotifiche Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDsysUtente IS NULL OR Me.IDsysUtente = @IDsysUtente)    " + vbNewLine() + "    AND  (@IDsysNotifica IS NULL OR Me.IDsysNotifica = @IDsysNotifica)    " + vbNewLine() + "    AND  (@Letta IS NULL OR Me.Letta = @Letta)    " + vbNewLine() + "    AND  (@Notificata IS NULL OR Me.Notificata = @Notificata)    " + vbNewLine() + "    AND  (@Cancellata IS NULL OR Me.Cancellata = @Cancellata)    " + vbNewLine() + "    AND  (@DataLettaDal IS NULL OR Me.DataLetta >= @DataLettaDal)    " + vbNewLine() + "    AND  (@DataLettaAl IS NULL OR Me.DataLetta <= @DataLettaAl)    " + vbNewLine() + "    AND  (@DataNotificataDal IS NULL OR Me.DataNotificata >= @DataNotificataDal)    " + vbNewLine() + "    AND  (@DataNotificataAl IS NULL OR Me.DataNotificata <= @DataNotificataAl)    " + vbNewLine() + "    AND  (@DataCancellataDal IS NULL OR Me.DataCancellata >= @DataCancellataDal)    " + vbNewLine() + "    AND  (@DataCancellataAl IS NULL OR Me.DataCancellata <= @DataCancellataAl)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_SEARCH    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + "  ,@Letta AS bit = NULL    " + vbNewLine() + "  ,@Notificata AS bit = NULL    " + vbNewLine() + "  ,@Cancellata AS bit = NULL    " + vbNewLine() + "  ,@DataLettaDal AS datetime = NULL    " + vbNewLine() + "  ,@DataLettaAl AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataNotificataAl AS datetime = NULL    " + vbNewLine() + "  ,@DataCancellataDal AS datetime = NULL    " + vbNewLine() + "  ,@DataCancellataAl AS datetime = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysUtentiNotifiche Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDsysUtente IS NULL OR Me.IDsysUtente = @IDsysUtente)    " + vbNewLine() + "    AND  (@IDsysNotifica IS NULL OR Me.IDsysNotifica = @IDsysNotifica)    " + vbNewLine() + "    AND  (@Letta IS NULL OR Me.Letta = @Letta)    " + vbNewLine() + "    AND  (@Notificata IS NULL OR Me.Notificata = @Notificata)    " + vbNewLine() + "    AND  (@Cancellata IS NULL OR Me.Cancellata = @Cancellata)    " + vbNewLine() + "    AND  (@DataLettaDal IS NULL OR Me.DataLetta >= @DataLettaDal)    " + vbNewLine() + "    AND  (@DataLettaAl IS NULL OR Me.DataLetta <= @DataLettaAl)    " + vbNewLine() + "    AND  (@DataNotificataDal IS NULL OR Me.DataNotificata >= @DataNotificataDal)    " + vbNewLine() + "    AND  (@DataNotificataAl IS NULL OR Me.DataNotificata <= @DataNotificataAl)    " + vbNewLine() + "    AND  (@DataCancellataDal IS NULL OR Me.DataCancellata >= @DataCancellataDal)    " + vbNewLine() + "    AND  (@DataCancellataAl IS NULL OR Me.DataCancellata <= @DataCancellataAl)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_SELECT    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDsysUtente]   " + vbNewLine() + "    , [IDsysNotifica]   " + vbNewLine() + "    , [Letta]   " + vbNewLine() + "    , [Notificata]   " + vbNewLine() + "    , [Cancellata]   " + vbNewLine() + "    , [DataLetta]   " + vbNewLine() + "    , [DataNotificata]   " + vbNewLine() + "    , [DataCancellata]   " + vbNewLine() + "  FROM sysUtentiNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_SELECT    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDsysUtente]   " + vbNewLine() + "    , [IDsysNotifica]   " + vbNewLine() + "    , [Letta]   " + vbNewLine() + "    , [Notificata]   " + vbNewLine() + "    , [Cancellata]   " + vbNewLine() + "    , [DataLetta]   " + vbNewLine() + "    , [DataNotificata]   " + vbNewLine() + "    , [DataCancellata]   " + vbNewLine() + "  FROM sysUtentiNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_SELECTALL    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDsysUtente]   " + vbNewLine() + "    , [IDsysNotifica]   " + vbNewLine() + "    , [Letta]   " + vbNewLine() + "    , [Notificata]   " + vbNewLine() + "    , [Cancellata]   " + vbNewLine() + "    , [DataLetta]   " + vbNewLine() + "    , [DataNotificata]   " + vbNewLine() + "    , [DataCancellata]   " + vbNewLine() + "  FROM sysUtentiNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_SELECTALL    " + vbNewLine() + "  @IDsysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDsysUtente]   " + vbNewLine() + "    , [IDsysNotifica]   " + vbNewLine() + "    , [Letta]   " + vbNewLine() + "    , [Notificata]   " + vbNewLine() + "    , [Cancellata]   " + vbNewLine() + "    , [DataLetta]   " + vbNewLine() + "    , [DataNotificata]   " + vbNewLine() + "    , [DataCancellata]   " + vbNewLine() + "  FROM sysUtentiNotifiche WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiNotifiche_UPDATE    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL   " + vbNewLine() + "  ,@Letta AS bit   " + vbNewLine() + "  ,@Notificata AS bit   " + vbNewLine() + "  ,@Cancellata AS bit   " + vbNewLine() + "  ,@DataLetta AS datetime   " + vbNewLine() + "  ,@DataNotificata AS datetime   " + vbNewLine() + "  ,@DataCancellata AS datetime   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysUtentiNotifiche   " + vbNewLine() + "    SET    " + vbNewLine() + "      Letta =  @Letta   " + vbNewLine() + "      , Notificata =  @Notificata   " + vbNewLine() + "      , Cancellata =  @Cancellata   " + vbNewLine() + "      , DataLetta =  @DataLetta   " + vbNewLine() + "      , DataNotificata =  @DataNotificata   " + vbNewLine() + "      , DataCancellata =  @DataCancellata   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiNotifiche_UPDATE    " + vbNewLine() + "  @IDsysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@IDsysNotifica AS int = NULL   " + vbNewLine() + "  ,@Letta AS bit   " + vbNewLine() + "  ,@Notificata AS bit   " + vbNewLine() + "  ,@Cancellata AS bit   " + vbNewLine() + "  ,@DataLetta AS datetime   " + vbNewLine() + "  ,@DataNotificata AS datetime   " + vbNewLine() + "  ,@DataCancellata AS datetime   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysUtentiNotifiche   " + vbNewLine() + "    SET    " + vbNewLine() + "      Letta =  @Letta   " + vbNewLine() + "      , Notificata =  @Notificata   " + vbNewLine() + "      , Cancellata =  @Cancellata   " + vbNewLine() + "      , DataLetta =  @DataLetta   " + vbNewLine() + "      , DataNotificata =  @DataNotificata   " + vbNewLine() + "      , DataCancellata =  @DataCancellata   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDsysUtente = @IDsysUtente   " + vbNewLine() + "    AND IDsysNotifica = @IDsysNotifica   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysUtentiPersonale_SEARCH]                   " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL                   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL                   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL                   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL                   " + vbNewLine() + "  ,@Persona AS varchar(max) = NULL                   " + vbNewLine() + "  ,@Attivo AS bit = NULL                   " + vbNewLine() + "  ,@Dominio AS NVARCHAR(50) = NULL                   " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL                   " + vbNewLine() + "	,@IDUtenteEntrato AS NVARCHAR(20) = NULL                   " + vbNewLine() + " AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE                  " + vbNewLine() + "  SELECT Me.*                   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema                  " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo                  " + vbNewLine() + "    , SysPolicyPwd.Descrizione SysPolicyPwd                  " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona                  " + vbNewLine() + "		, sysPersone.Nome + ' ' + sysPersone.Cognome Nominativo                  " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)                   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID                  " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID                  " + vbNewLine() + "    LEFT JOIN SysPolicyPwd SysPolicyPwd WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysPolicyPwd = SysPolicyPwd.ID                  " + vbNewLine() + "    LEFT JOIN BIPoste..PersonaleAll sysPersone WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID                  " + vbNewLine() + "  WHERE                   " + vbNewLine() + "    (@ID IS NULL OR Me.ID = @ID)                   " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)                   " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)                   " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)                   " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)                   " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')                   " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')                   " + vbNewLine() + "    AND  (@Persona IS NULL OR (sysPersone.Cognome + ' ' + sysPersone.Nome) like '%' + @Persona + '%')                   " + vbNewLine() + "		AND ISNULL(Developer,0) = 0                  " + vbNewLine() + "		AND Me.IDSysSistema IN (SELECT IDSysSistema                   " + vbNewLine() + "														FROM sysUtentiProfili                   " + vbNewLine() + "														WHERE IDSysUtente = @IDUtenteEntrato OR @IDUtenteEntrato IS NULL)                  " + vbNewLine() + "	ORDER BY                  " + vbNewLine() + "		SysSistema                  " + vbNewLine() + "		, SysProfilo                  " + vbNewLine() + "		, Nominativo                  " + vbNewLine() + "                  " + vbNewLine() + "                  " + vbNewLine() + "OPTION(RECOMPILE)                   " + vbNewLine() + "END                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysUtentiPersonale_SEARCH]                   " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL                   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL                   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL                   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL                   " + vbNewLine() + "  ,@Persona AS varchar(max) = NULL                   " + vbNewLine() + "  ,@Attivo AS bit = NULL                   " + vbNewLine() + "  ,@Dominio AS NVARCHAR(50) = NULL                   " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL                   " + vbNewLine() + "	,@IDUtenteEntrato AS NVARCHAR(20) = NULL                   " + vbNewLine() + " AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE                  " + vbNewLine() + "  SELECT Me.*                   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema                  " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo                  " + vbNewLine() + "    , SysPolicyPwd.Descrizione SysPolicyPwd                  " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona                  " + vbNewLine() + "		, sysPersone.Nome + ' ' + sysPersone.Cognome Nominativo                  " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)                   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID                  " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID                  " + vbNewLine() + "    LEFT JOIN SysPolicyPwd SysPolicyPwd WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysPolicyPwd = SysPolicyPwd.ID                  " + vbNewLine() + "    LEFT JOIN BIPoste..PersonaleAll sysPersone WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID                  " + vbNewLine() + "  WHERE                   " + vbNewLine() + "    (@ID IS NULL OR Me.ID = @ID)                   " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)                   " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)                   " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)                   " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)                   " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')                   " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')                   " + vbNewLine() + "    AND  (@Persona IS NULL OR (sysPersone.Cognome + ' ' + sysPersone.Nome) like '%' + @Persona + '%')                   " + vbNewLine() + "		AND ISNULL(Developer,0) = 0                  " + vbNewLine() + "		AND Me.IDSysSistema IN (SELECT IDSysSistema                   " + vbNewLine() + "														FROM sysUtentiProfili                   " + vbNewLine() + "														WHERE IDSysUtente = @IDUtenteEntrato OR @IDUtenteEntrato IS NULL)                  " + vbNewLine() + "	ORDER BY                  " + vbNewLine() + "		SysSistema                  " + vbNewLine() + "		, SysProfilo                  " + vbNewLine() + "		, Nominativo                  " + vbNewLine() + "                  " + vbNewLine() + "                  " + vbNewLine() + "OPTION(RECOMPILE)                   " + vbNewLine() + "END                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysUtentiPersone_SEARCH]                   " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL                   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL                   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL                   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL                   " + vbNewLine() + "  ,@Persona AS varchar(max) = NULL                   " + vbNewLine() + "  ,@Attivo AS bit = NULL                   " + vbNewLine() + "  ,@Dominio AS NVARCHAR(50) = NULL                   " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL                   " + vbNewLine() + "	,@IDUtenteEntrato AS NVARCHAR(20) = NULL                   " + vbNewLine() + " AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE                  " + vbNewLine() + "  SELECT Me.*                   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema                  " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo                  " + vbNewLine() + "    , SysPolicyPwd.Descrizione SysPolicyPwd                  " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona                  " + vbNewLine() + "		, sysPersone.Nome + ' ' + sysPersone.Cognome Nominativo                  " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)                   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID                  " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID                  " + vbNewLine() + "    LEFT JOIN SysPolicyPwd SysPolicyPwd WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysPolicyPwd = SysPolicyPwd.ID                  " + vbNewLine() + "    LEFT JOIN sysPersone sysPersone WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID                  " + vbNewLine() + "  WHERE                   " + vbNewLine() + "    (@ID IS NULL OR Me.ID = @ID)                   " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)                   " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)                   " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)                   " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)                   " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')                   " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')                   " + vbNewLine() + "    AND  (@Persona IS NULL OR (sysPersone.Cognome + ' ' + sysPersone.Nome) like '%' + @Persona + '%')                   " + vbNewLine() + "		AND ISNULL(Developer,0) = 0                  " + vbNewLine() + "		AND Me.IDSysSistema IN (SELECT IDSysSistema                   " + vbNewLine() + "														FROM sysUtentiProfili                   " + vbNewLine() + "														WHERE IDSysUtente = @IDUtenteEntrato OR @IDUtenteEntrato IS NULL)                  " + vbNewLine() + "	ORDER BY                  " + vbNewLine() + "		SysSistema                  " + vbNewLine() + "		, SysProfilo                  " + vbNewLine() + "		, Nominativo                  " + vbNewLine() + "                  " + vbNewLine() + "OPTION(RECOMPILE)                   " + vbNewLine() + "END                   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysUtentiPersone_SEARCH]                   " + vbNewLine() + "  @ID AS NVARCHAR(20) = NULL                   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL                   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL                   " + vbNewLine() + "  ,@IDSysPolicyPwd AS int = NULL                   " + vbNewLine() + "  ,@Persona AS varchar(max) = NULL                   " + vbNewLine() + "  ,@Attivo AS bit = NULL                   " + vbNewLine() + "  ,@Dominio AS NVARCHAR(50) = NULL                   " + vbNewLine() + "  ,@Username AS NVARCHAR(20) = NULL                   " + vbNewLine() + "	,@IDUtenteEntrato AS NVARCHAR(20) = NULL                   " + vbNewLine() + " AS                   " + vbNewLine() + "BEGIN                  " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE                  " + vbNewLine() + "  SELECT Me.*                   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema                  " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo                  " + vbNewLine() + "    , SysPolicyPwd.Descrizione SysPolicyPwd                  " + vbNewLine() + "    , sysPersone.CodiceFiscale Persona                  " + vbNewLine() + "		, sysPersone.Nome + ' ' + sysPersone.Cognome Nominativo                  " + vbNewLine() + "  FROM sysUtenti Me WITH(NOLOCK)                   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID                  " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID                  " + vbNewLine() + "    LEFT JOIN SysPolicyPwd SysPolicyPwd WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDSysPolicyPwd = SysPolicyPwd.ID                  " + vbNewLine() + "    LEFT JOIN sysPersone sysPersone WITH(NOLOCK)                   " + vbNewLine() + "      ON Me.IDPersona = sysPersone.ID                  " + vbNewLine() + "  WHERE                   " + vbNewLine() + "    (@ID IS NULL OR Me.ID = @ID)                   " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)                   " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)                   " + vbNewLine() + "    AND  (@IDSysPolicyPwd IS NULL OR Me.IDSysPolicyPwd = @IDSysPolicyPwd)                   " + vbNewLine() + "    AND  (@Attivo IS NULL OR Me.Attivo = @Attivo)                   " + vbNewLine() + "    AND  (@Dominio IS NULL OR Me.Dominio LIKE @Dominio + '%')                   " + vbNewLine() + "    AND  (@Username IS NULL OR Me.Username LIKE @Username + '%')                   " + vbNewLine() + "    AND  (@Persona IS NULL OR (sysPersone.Cognome + ' ' + sysPersone.Nome) like '%' + @Persona + '%')                   " + vbNewLine() + "		AND ISNULL(Developer,0) = 0                  " + vbNewLine() + "		AND Me.IDSysSistema IN (SELECT IDSysSistema                   " + vbNewLine() + "														FROM sysUtentiProfili                   " + vbNewLine() + "														WHERE IDSysUtente = @IDUtenteEntrato OR @IDUtenteEntrato IS NULL)                  " + vbNewLine() + "	ORDER BY                  " + vbNewLine() + "		SysSistema                  " + vbNewLine() + "		, SysProfilo                  " + vbNewLine() + "		, Nominativo                  " + vbNewLine() + "                  " + vbNewLine() + "OPTION(RECOMPILE)                   " + vbNewLine() + "END                   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_DELETE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_DELETE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_DELETEALL    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_DELETEALL    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysUtentiProfili   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtentiProfili (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_INSERT    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20)   " + vbNewLine() + "  ,@IDSysProfilo AS int   " + vbNewLine() + "  ,@IDSysSistema AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysUtentiProfili (    " + vbNewLine() + "    IDSysUtente   " + vbNewLine() + "    ,IDSysProfilo   " + vbNewLine() + "    ,IDSysSistema   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysUtente   " + vbNewLine() + "    ,@IDSysProfilo   " + vbNewLine() + "    ,@IDSysSistema   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_SEARCH    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "  FROM sysUtentiProfili Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysUtente IS NULL OR Me.IDSysUtente = @IDSysUtente)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_SEARCH    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo   " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema   " + vbNewLine() + "  FROM sysUtentiProfili Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID   " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysUtente IS NULL OR Me.IDSysUtente = @IDSysUtente)    " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)    " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_SELECT    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "  FROM sysUtentiProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_SELECT    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL    " + vbNewLine() + "  ,@IDSysSistema AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "  FROM sysUtentiProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    AND IDSysProfilo = @IDSysProfilo   " + vbNewLine() + "    AND IDSysSistema = @IDSysSistema   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_SELECTALL    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "  FROM sysUtentiProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_SELECTALL    " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysUtente]   " + vbNewLine() + "    , [IDSysProfilo]   " + vbNewLine() + "    , [IDSysSistema]   " + vbNewLine() + "  FROM sysUtentiProfili WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysUtente = @IDSysUtente   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysUtentiProfili_UPDATE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.   " + vbNewLine() + "RETURN 0   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysUtentiProfili_UPDATE    " + vbNewLine() + "  @IDSysUtente AS nvarchar(20) = NULL   " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL   " + vbNewLine() + "  ,@IDSysSistema AS int = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.   " + vbNewLine() + "RETURN 0   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysUtentiSistemi_SELECT]                          " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL                          " + vbNewLine() + " AS                          " + vbNewLine() + "BEGIN                         " + vbNewLine() + "  SELECT DISTINCT                          " + vbNewLine() + "    IDSysSistema,                          " + vbNewLine() + "    s.Descrizione                         " + vbNewLine() + "  FROM sysUtentiProfili up                         " + vbNewLine() + "    INNER JOIN dbo.sysSistemi s ON up.IDSysSistema = s.ID                         " + vbNewLine() + "  WHERE                          " + vbNewLine() + "     IDSysUtente = @IDSysUtente                         " + vbNewLine() + "END                          " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysUtentiSistemi_SELECT]                          " + vbNewLine() + "  @IDSysUtente AS NVARCHAR(20) = NULL                          " + vbNewLine() + " AS                          " + vbNewLine() + "BEGIN                         " + vbNewLine() + "  SELECT DISTINCT                          " + vbNewLine() + "    IDSysSistema,                          " + vbNewLine() + "    s.Descrizione                         " + vbNewLine() + "  FROM sysUtentiProfili up                         " + vbNewLine() + "    INNER JOIN dbo.sysSistemi s ON up.IDSysSistema = s.ID                         " + vbNewLine() + "  WHERE                          " + vbNewLine() + "     IDSysUtente = @IDSysUtente                         " + vbNewLine() + "END                          " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE procedure [dbo].[BSP_sysUtentiWP_SELECT]                             " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@ID varchar(50)   --= 'BALSAM43'                          " + vbNewLine() + "	, @DOMINIO varchar(50)                  " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	SELECT                              " + vbNewLine() + "		P.ntaccount ID                          " + vbNewLine() + "		, '' [Password]                       " + vbNewLine() + "		, -1 IDSysSistema                     " + vbNewLine() + "		, -1 IDSysProfilo                          " + vbNewLine() + "		, -1 IDSysPolicyPwd                          " + vbNewLine() + "		, -1 IDPersona                          " + vbNewLine() + "		, -1 IDVisibilita              " + vbNewLine() + "		, 1 Attivo                          " + vbNewLine() + "		, null DataCreazione                          " + vbNewLine() + "		, null DataScadenza                          " + vbNewLine() + "		, null DataUltimoCambioPwd                          " + vbNewLine() + "		, 0 Developer                            " + vbNewLine() + "		, '' DescrizioneProfilo                            " + vbNewLine() + "		, '' DescrizionePolicyPwd                        " + vbNewLine() + "		, P.NTAccount Username                 " + vbNewLine() + "		, P.NTDomain Dominio                        " + vbNewLine() + "		, P.Matricola                             " + vbNewLine() + "		, P.Nome                             " + vbNewLine() + "		, P.Cognome		                           " + vbNewLine() + "		, p.IDUfficioApplicato IDUfficio                       " + vbNewLine() + "		, P.ID IDPersonale                       " + vbNewLine() + "	FROM BIPoste..Personale P                       " + vbNewLine() + "	WHERE                              " + vbNewLine() + "		p.NTAccount= @ID                             " + vbNewLine() + "		AND p.NTDomain = @DOMINIO                 " + vbNewLine() + "END                         " + vbNewLine() + "                       " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE procedure [dbo].[BSP_sysUtentiWP_SELECT]                             " + vbNewLine() + "--DECLARE                       " + vbNewLine() + "	@ID varchar(50)   --= 'BALSAM43'                          " + vbNewLine() + "	, @DOMINIO varchar(50)                  " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                           " + vbNewLine() + "	SELECT                              " + vbNewLine() + "		P.ntaccount ID                          " + vbNewLine() + "		, '' [Password]                       " + vbNewLine() + "		, -1 IDSysSistema                     " + vbNewLine() + "		, -1 IDSysProfilo                          " + vbNewLine() + "		, -1 IDSysPolicyPwd                          " + vbNewLine() + "		, -1 IDPersona                          " + vbNewLine() + "		, -1 IDVisibilita              " + vbNewLine() + "		, 1 Attivo                          " + vbNewLine() + "		, null DataCreazione                          " + vbNewLine() + "		, null DataScadenza                          " + vbNewLine() + "		, null DataUltimoCambioPwd                          " + vbNewLine() + "		, 0 Developer                            " + vbNewLine() + "		, '' DescrizioneProfilo                            " + vbNewLine() + "		, '' DescrizionePolicyPwd                        " + vbNewLine() + "		, P.NTAccount Username                 " + vbNewLine() + "		, P.NTDomain Dominio                        " + vbNewLine() + "		, P.Matricola                             " + vbNewLine() + "		, P.Nome                             " + vbNewLine() + "		, P.Cognome		                           " + vbNewLine() + "		, p.IDUfficioApplicato IDUfficio                       " + vbNewLine() + "		, P.ID IDPersonale                       " + vbNewLine() + "	FROM BIPoste..Personale P                       " + vbNewLine() + "	WHERE                              " + vbNewLine() + "		p.NTAccount= @ID                             " + vbNewLine() + "		AND p.NTDomain = @DOMINIO                 " + vbNewLine() + "END                         " + vbNewLine() + "                       " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                            " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_EXPIRE]                             " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SET NOCOUNT ON                            " + vbNewLine() + "	DELETE                            " + vbNewLine() + "	FROM sysViewState                            " + vbNewLine() + "	WHERE GETUTCDATE() > DATEADD(minute, Timeout, LastAccessed)                            " + vbNewLine() + "                            " + vbNewLine() + "END                         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                            " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_EXPIRE]                             " + vbNewLine() + "AS                            " + vbNewLine() + "BEGIN                          " + vbNewLine() + "	SET NOCOUNT ON                            " + vbNewLine() + "	DELETE                            " + vbNewLine() + "	FROM sysViewState                            " + vbNewLine() + "	WHERE GETUTCDATE() > DATEADD(minute, Timeout, LastAccessed)                            " + vbNewLine() + "                            " + vbNewLine() + "END                         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                            " + vbNewLine() + "                                      " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_GET]                                       " + vbNewLine() + "	@viewStateId UNIQUEIDENTIFIER                                      " + vbNewLine() + "AS                              " + vbNewLine() + "BEGIN                                  " + vbNewLine() + "	SET NOCOUNT ON                                      " + vbNewLine() + "	DECLARE @textPtr VARBINARY(16)                                      " + vbNewLine() + "	DECLARE @length INT                                      " + vbNewLine() + "                                      " + vbNewLine() + "	UPDATE sysViewState                                      " + vbNewLine() + "	  SET LastAccessed = GETUTCDATE(),                                      " + vbNewLine() + "		  @textPtr = TEXTPTR(Value),                                      " + vbNewLine() + "		  @length = DATALENGTH(Value)                                      " + vbNewLine() + "	WHERE ViewStateId = @viewStateId                                      " + vbNewLine() + "                                      " + vbNewLine() + "	IF @length IS NOT NULL BEGIN                                      " + vbNewLine() + "		SELECT @length AS Length                                      " + vbNewLine() + "		READTEXT sysViewState.Value @textPtr 0 @length                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	RETURN 0                                      " + vbNewLine() + "END                         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                            " + vbNewLine() + "                                      " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_GET]                                       " + vbNewLine() + "	@viewStateId UNIQUEIDENTIFIER                                      " + vbNewLine() + "AS                              " + vbNewLine() + "BEGIN                                  " + vbNewLine() + "	SET NOCOUNT ON                                      " + vbNewLine() + "	DECLARE @textPtr VARBINARY(16)                                      " + vbNewLine() + "	DECLARE @length INT                                      " + vbNewLine() + "                                      " + vbNewLine() + "	UPDATE sysViewState                                      " + vbNewLine() + "	  SET LastAccessed = GETUTCDATE(),                                      " + vbNewLine() + "		  @textPtr = TEXTPTR(Value),                                      " + vbNewLine() + "		  @length = DATALENGTH(Value)                                      " + vbNewLine() + "	WHERE ViewStateId = @viewStateId                                      " + vbNewLine() + "                                      " + vbNewLine() + "	IF @length IS NOT NULL BEGIN                                      " + vbNewLine() + "		SELECT @length AS Length                                      " + vbNewLine() + "		READTEXT sysViewState.Value @textPtr 0 @length                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	RETURN 0                                      " + vbNewLine() + "END                         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "                            " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_SET]                                       " + vbNewLine() + "	@viewStateId UNIQUEIDENTIFIER,                                       " + vbNewLine() + "	@value image, --varbinary(max),                                       " + vbNewLine() + "	@timeout INT = 20                                       " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                                   " + vbNewLine() + "	SET NOCOUNT ON                                      " + vbNewLine() + "	IF @viewStateId IS NULL BEGIN                                      " + vbNewLine() + "		RETURN -1                                      " + vbNewLine() + "	END ELSE IF @timeout < 1 BEGIN                                      " + vbNewLine() + "		RETURN -2                                      " + vbNewLine() + "	END ELSE IF @value IS NULL BEGIN                                      " + vbNewLine() + "		RETURN -3                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	IF EXISTS(SELECT * FROM sysViewState WHERE ViewStateId = @viewStateID) BEGIN                                        " + vbNewLine() + "		UPDATE sysViewState                                      " + vbNewLine() + "			SET LastAccessed = GETUTCDATE()                                      " + vbNewLine() + "				,Value = @value                                      " + vbNewLine() + "		WHERE ViewStateID = @viewStateId                                      " + vbNewLine() + "	END ELSE BEGIN                                      " + vbNewLine() + "		INSERT INTO sysViewState                                       " + vbNewLine() + "			(ViewStateId, Value, LastAccessed, Timeout)                                       " + vbNewLine() + "		VALUES                                       " + vbNewLine() + "			(@viewStateId, @value, GETUTCDATE(), @timeout)                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	RETURN 0                                      " + vbNewLine() + "                            " + vbNewLine() + "END                          " + vbNewLine() + "                            " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<                            " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysViewState_SET]                                       " + vbNewLine() + "	@viewStateId UNIQUEIDENTIFIER,                                       " + vbNewLine() + "	@value image, --varbinary(max),                                       " + vbNewLine() + "	@timeout INT = 20                                       " + vbNewLine() + "AS                             " + vbNewLine() + "BEGIN                                   " + vbNewLine() + "	SET NOCOUNT ON                                      " + vbNewLine() + "	IF @viewStateId IS NULL BEGIN                                      " + vbNewLine() + "		RETURN -1                                      " + vbNewLine() + "	END ELSE IF @timeout < 1 BEGIN                                      " + vbNewLine() + "		RETURN -2                                      " + vbNewLine() + "	END ELSE IF @value IS NULL BEGIN                                      " + vbNewLine() + "		RETURN -3                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	IF EXISTS(SELECT * FROM sysViewState WHERE ViewStateId = @viewStateID) BEGIN                                        " + vbNewLine() + "		UPDATE sysViewState                                      " + vbNewLine() + "			SET LastAccessed = GETUTCDATE()                                      " + vbNewLine() + "				,Value = @value                                      " + vbNewLine() + "		WHERE ViewStateID = @viewStateId                                      " + vbNewLine() + "	END ELSE BEGIN                                      " + vbNewLine() + "		INSERT INTO sysViewState                                       " + vbNewLine() + "			(ViewStateId, Value, LastAccessed, Timeout)                                       " + vbNewLine() + "		VALUES                                       " + vbNewLine() + "			(@viewStateId, @value, GETUTCDATE(), @timeout)                                      " + vbNewLine() + "	END                                      " + vbNewLine() + "	RETURN 0                                      " + vbNewLine() + "                            " + vbNewLine() + "END                          " + vbNewLine() + "                            " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysVisibilita_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysVisibilita   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysVisibilita_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysVisibilita   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysVisibilita_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysVisibilita (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysVisibilita_INSERT    " + vbNewLine() + "  @Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysVisibilita (    " + vbNewLine() + "    Descrizione   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @Descrizione   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysVisibilita_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysVisibilita Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysVisibilita_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(250) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysVisibilita Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysVisibilita_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysVisibilita WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysVisibilita_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "  FROM sysVisibilita WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysVisibilita_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysVisibilita   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysVisibilita_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(250)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysVisibilita   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "   " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysWiki_AUTOCOMPLETE]   " + vbNewLine() + "--declare   " + vbNewLine() + "  @Descrizione AS NVARCHAR(MAX) = NULL   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "	SELECT    " + vbNewLine() + "		ID   " + vbNewLine() + "		, isnull(Titolo,'') as Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Tags like '%' + @Descrizione + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<   " + vbNewLine() + "CREATE PROCEDURE [dbo].[BSP_sysWiki_AUTOCOMPLETE]   " + vbNewLine() + "--declare   " + vbNewLine() + "  @Descrizione AS NVARCHAR(MAX) = NULL   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "	SELECT    " + vbNewLine() + "		ID   " + vbNewLine() + "		, isnull(Titolo,'') as Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Tags like '%' + @Descrizione + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysWiki_CambiaOrdine]   " + vbNewLine() + "  @id as integer,   " + vbNewLine() + "  @Incremento as int   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DECLARE @Ordine AS INT   " + vbNewLine() + "  DECLARE @NewOrdine AS INT   " + vbNewLine() + "  DECLARE @IDPadre AS INT   " + vbNewLine() + "   " + vbNewLine() + "  SELECT   " + vbNewLine() + "		@NewOrdine = Ordine + @Incremento,   " + vbNewLine() + "		@Ordine = Ordine,   " + vbNewLine() + "		@IDPadre = IDPadre   " + vbNewLine() + "  FROM sysWiki   " + vbNewLine() + "  WHERE   " + vbNewLine() + "		ID = @id   " + vbNewLine() + "	                      " + vbNewLine() + "  UPDATE sysWiki                   " + vbNewLine() + "		SET   " + vbNewLine() + "			Ordine = @Ordine   " + vbNewLine() + "  WHERE   " + vbNewLine() + "		Ordine = @NewOrdine   " + vbNewLine() + "		and isnull(IDPadre, -1) = isnull(@IDPadre, -1)   " + vbNewLine() + "		                  " + vbNewLine() + "  IF @@ROWCOUNT = 1 BEGIN   " + vbNewLine() + "    UPDATE sysWiki                   " + vbNewLine() + "			SET   " + vbNewLine() + "        Ordine = @NewOrdine   " + vbNewLine() + "    WHERE      " + vbNewLine() + "			ID = @id   " + vbNewLine() + "  END   " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysWiki_CambiaOrdine]   " + vbNewLine() + "  @id as integer,   " + vbNewLine() + "  @Incremento as int   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DECLARE @Ordine AS INT   " + vbNewLine() + "  DECLARE @NewOrdine AS INT   " + vbNewLine() + "  DECLARE @IDPadre AS INT   " + vbNewLine() + "   " + vbNewLine() + "  SELECT   " + vbNewLine() + "		@NewOrdine = Ordine + @Incremento,   " + vbNewLine() + "		@Ordine = Ordine,   " + vbNewLine() + "		@IDPadre = IDPadre   " + vbNewLine() + "  FROM sysWiki   " + vbNewLine() + "  WHERE   " + vbNewLine() + "		ID = @id   " + vbNewLine() + "	                      " + vbNewLine() + "  UPDATE sysWiki                   " + vbNewLine() + "		SET   " + vbNewLine() + "			Ordine = @Ordine   " + vbNewLine() + "  WHERE   " + vbNewLine() + "		Ordine = @NewOrdine   " + vbNewLine() + "		and isnull(IDPadre, -1) = isnull(@IDPadre, -1)   " + vbNewLine() + "		                  " + vbNewLine() + "  IF @@ROWCOUNT = 1 BEGIN   " + vbNewLine() + "    UPDATE sysWiki                   " + vbNewLine() + "			SET   " + vbNewLine() + "        Ordine = @NewOrdine   " + vbNewLine() + "    WHERE      " + vbNewLine() + "			ID = @id   " + vbNewLine() + "  END   " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWiki   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_DELETE    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWiki   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_DELETEALL    " + vbNewLine() + "  @IDPadre AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWiki   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDPadre = @IDPadre   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_DELETEALL    " + vbNewLine() + "  @IDPadre AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWiki   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDPadre = @IDPadre   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_INSERT    " + vbNewLine() + "  @IDPadre AS int   " + vbNewLine() + "  ,@Titolo AS nvarchar(250)   " + vbNewLine() + "  ,@Sottotitolo AS nvarchar(500)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(MAX)   " + vbNewLine() + "  ,@DataUltimaModifica AS smalldatetime   " + vbNewLine() + "  ,@Tags AS varchar(250)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Pubblica AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWiki (    " + vbNewLine() + "    IDPadre   " + vbNewLine() + "    ,Titolo   " + vbNewLine() + "    ,Sottotitolo   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,DataUltimaModifica   " + vbNewLine() + "    ,Tags   " + vbNewLine() + "    ,Ordine   " + vbNewLine() + "    ,Pubblica   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDPadre   " + vbNewLine() + "    ,@Titolo   " + vbNewLine() + "    ,@Sottotitolo   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@DataUltimaModifica   " + vbNewLine() + "    ,@Tags   " + vbNewLine() + "    ,@Ordine   " + vbNewLine() + "    ,@Pubblica   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_INSERT    " + vbNewLine() + "  @IDPadre AS int   " + vbNewLine() + "  ,@Titolo AS nvarchar(250)   " + vbNewLine() + "  ,@Sottotitolo AS nvarchar(500)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(MAX)   " + vbNewLine() + "  ,@DataUltimaModifica AS smalldatetime   " + vbNewLine() + "  ,@Tags AS varchar(250)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Pubblica AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWiki (    " + vbNewLine() + "    IDPadre   " + vbNewLine() + "    ,Titolo   " + vbNewLine() + "    ,Sottotitolo   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,DataUltimaModifica   " + vbNewLine() + "    ,Tags   " + vbNewLine() + "    ,Ordine   " + vbNewLine() + "    ,Pubblica   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDPadre   " + vbNewLine() + "    ,@Titolo   " + vbNewLine() + "    ,@Sottotitolo   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@DataUltimaModifica   " + vbNewLine() + "    ,@Tags   " + vbNewLine() + "    ,@Ordine   " + vbNewLine() + "    ,@Pubblica   " + vbNewLine() + "  )    " + vbNewLine() + "   " + vbNewLine() + "SELECT @@IDENTITY   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysWiki_Ordina]   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE f   " + vbNewLine() + "    SET   " + vbNewLine() + "			f.Ordine = fNew.NewOrdine   " + vbNewLine() + "  FROM sysWiki f   " + vbNewLine() + "    INNER JOIN (   " + vbNewLine() + "        SELECT id, ROW_NUMBER() OVER (PARTITION BY IDPadre ORDER BY ISNULL(Ordine,10000)) - 1 NewOrdine   " + vbNewLine() + "        FROM sysWiki   " + vbNewLine() + "  ) fNew on f.ID = fNew.ID                  " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysWiki_Ordina]   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE f   " + vbNewLine() + "    SET   " + vbNewLine() + "			f.Ordine = fNew.NewOrdine   " + vbNewLine() + "  FROM sysWiki f   " + vbNewLine() + "    INNER JOIN (   " + vbNewLine() + "        SELECT id, ROW_NUMBER() OVER (PARTITION BY IDPadre ORDER BY ISNULL(Ordine,10000)) - 1 NewOrdine   " + vbNewLine() + "        FROM sysWiki   " + vbNewLine() + "  ) fNew on f.ID = fNew.ID                  " + vbNewLine() + "END  " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@Titolo AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@Sottotitolo AS NVARCHAR(500) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@DataUltimaModificaDal AS smalldatetime = NULL    " + vbNewLine() + "  ,@DataUltimaModificaAl AS smalldatetime = NULL    " + vbNewLine() + "  ,@Tags AS varchar(250) = NULL    " + vbNewLine() + "  ,@Ordine AS int = NULL    " + vbNewLine() + "  ,@Pubblica AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysWiki.Descrizione Padre   " + vbNewLine() + "  FROM sysWiki Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysWiki sysWiki WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPadre = sysWiki.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@Titolo IS NULL OR Me.Titolo LIKE @Titolo + '%')    " + vbNewLine() + "    AND  (@Sottotitolo IS NULL OR Me.Sottotitolo LIKE @Sottotitolo + '%')    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataUltimaModificaDal IS NULL OR Me.DataUltimaModifica >= @DataUltimaModificaDal)    " + vbNewLine() + "    AND  (@DataUltimaModificaAl IS NULL OR Me.DataUltimaModifica <= @DataUltimaModificaAl)    " + vbNewLine() + "    AND  (@Tags IS NULL OR Me.Tags LIKE @Tags + '%')    " + vbNewLine() + "    AND  (@Ordine IS NULL OR Me.Ordine = @Ordine)    " + vbNewLine() + "    AND  (@Pubblica IS NULL OR Me.Pubblica = @Pubblica)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_SEARCH    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + "  ,@IDPadre AS int = NULL    " + vbNewLine() + "  ,@Titolo AS NVARCHAR(250) = NULL    " + vbNewLine() + "  ,@Sottotitolo AS NVARCHAR(500) = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(MAX) = NULL    " + vbNewLine() + "  ,@DataUltimaModificaDal AS smalldatetime = NULL    " + vbNewLine() + "  ,@DataUltimaModificaAl AS smalldatetime = NULL    " + vbNewLine() + "  ,@Tags AS varchar(250) = NULL    " + vbNewLine() + "  ,@Ordine AS int = NULL    " + vbNewLine() + "  ,@Pubblica AS bit = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "    , sysWiki.Descrizione Padre   " + vbNewLine() + "  FROM sysWiki Me WITH(NOLOCK)    " + vbNewLine() + "    LEFT JOIN sysWiki sysWiki WITH(NOLOCK)    " + vbNewLine() + "      ON Me.IDPadre = sysWiki.ID   " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)    " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)    " + vbNewLine() + "    AND  (@Titolo IS NULL OR Me.Titolo LIKE @Titolo + '%')    " + vbNewLine() + "    AND  (@Sottotitolo IS NULL OR Me.Sottotitolo LIKE @Sottotitolo + '%')    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@DataUltimaModificaDal IS NULL OR Me.DataUltimaModifica >= @DataUltimaModificaDal)    " + vbNewLine() + "    AND  (@DataUltimaModificaAl IS NULL OR Me.DataUltimaModifica <= @DataUltimaModificaAl)    " + vbNewLine() + "    AND  (@Tags IS NULL OR Me.Tags LIKE @Tags + '%')    " + vbNewLine() + "    AND  (@Ordine IS NULL OR Me.Ordine = @Ordine)    " + vbNewLine() + "    AND  (@Pubblica IS NULL OR Me.Pubblica = @Pubblica)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Sottotitolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [Tags]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Pubblica]   " + vbNewLine() + "  FROM sysWiki WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_SELECT    " + vbNewLine() + "  @ID AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Sottotitolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [Tags]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Pubblica]   " + vbNewLine() + "  FROM sysWiki WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_SELECTALL    " + vbNewLine() + "  @IDPadre AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Sottotitolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [Tags]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Pubblica]   " + vbNewLine() + "  FROM sysWiki WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDPadre = @IDPadre   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_SELECTALL    " + vbNewLine() + "  @IDPadre AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [ID]   " + vbNewLine() + "    , [IDPadre]   " + vbNewLine() + "    , [Titolo]   " + vbNewLine() + "    , [Sottotitolo]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [DataUltimaModifica]   " + vbNewLine() + "    , [Tags]   " + vbNewLine() + "    , [Ordine]   " + vbNewLine() + "    , [Pubblica]   " + vbNewLine() + "  FROM sysWiki WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDPadre = @IDPadre   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_sysWiki_SORT]   " + vbNewLine() + "	@IDPadre as int = null   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	   " + vbNewLine() + "	SELECT MAX(Ordine) as Ordine   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		(@IDPadre is null and IDPadre is null)   " + vbNewLine() + "		or (@IDPadre is not null and IDPadre = @IDPadre)   " + vbNewLine() + "   " + vbNewLine() + "END   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_sysWiki_SORT]   " + vbNewLine() + "	@IDPadre as int = null   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	   " + vbNewLine() + "	SELECT MAX(Ordine) as Ordine   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		(@IDPadre is null and IDPadre is null)   " + vbNewLine() + "		or (@IDPadre is not null and IDPadre = @IDPadre)   " + vbNewLine() + "   " + vbNewLine() + "END   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWiki_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@Titolo AS nvarchar(250)   " + vbNewLine() + "  ,@Sottotitolo AS nvarchar(500)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(MAX)   " + vbNewLine() + "  ,@DataUltimaModifica AS smalldatetime   " + vbNewLine() + "  ,@Tags AS varchar(250)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Pubblica AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysWiki   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDPadre =  @IDPadre   " + vbNewLine() + "      , Titolo =  @Titolo   " + vbNewLine() + "      , Sottotitolo =  @Sottotitolo   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , DataUltimaModifica =  @DataUltimaModifica   " + vbNewLine() + "      , Tags =  @Tags   " + vbNewLine() + "      , Ordine =  @Ordine   " + vbNewLine() + "      , Pubblica =  @Pubblica   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWiki_UPDATE    " + vbNewLine() + "  @ID AS int = NULL   " + vbNewLine() + "  ,@IDPadre AS int   " + vbNewLine() + "  ,@Titolo AS nvarchar(250)   " + vbNewLine() + "  ,@Sottotitolo AS nvarchar(500)   " + vbNewLine() + "  ,@Descrizione AS nvarchar(MAX)   " + vbNewLine() + "  ,@DataUltimaModifica AS smalldatetime   " + vbNewLine() + "  ,@Tags AS varchar(250)   " + vbNewLine() + "  ,@Ordine AS int   " + vbNewLine() + "  ,@Pubblica AS bit   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysWiki   " + vbNewLine() + "    SET    " + vbNewLine() + "      IDPadre =  @IDPadre   " + vbNewLine() + "      , Titolo =  @Titolo   " + vbNewLine() + "      , Sottotitolo =  @Sottotitolo   " + vbNewLine() + "      , Descrizione =  @Descrizione   " + vbNewLine() + "      , DataUltimaModifica =  @DataUltimaModifica   " + vbNewLine() + "      , Tags =  @Tags   " + vbNewLine() + "      , Ordine =  @Ordine   " + vbNewLine() + "      , Pubblica =  @Pubblica   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    ID = @ID   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_DELETE    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiAllegati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_DELETE    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiAllegati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_DELETEALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiAllegati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_DELETEALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiAllegati   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_INSERT    " + vbNewLine() + "  @IDSysWiki AS int   " + vbNewLine() + "  ,@IDAllegato AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@PathAllegato AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWikiAllegati (    " + vbNewLine() + "    IDSysWiki   " + vbNewLine() + "    ,IDAllegato   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,PathAllegato   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysWiki   " + vbNewLine() + "    ,@IDAllegato   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@PathAllegato   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_INSERT    " + vbNewLine() + "  @IDSysWiki AS int   " + vbNewLine() + "  ,@IDAllegato AS int   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@PathAllegato AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWikiAllegati (    " + vbNewLine() + "    IDSysWiki   " + vbNewLine() + "    ,IDAllegato   " + vbNewLine() + "    ,Descrizione   " + vbNewLine() + "    ,PathAllegato   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysWiki   " + vbNewLine() + "    ,@IDAllegato   " + vbNewLine() + "    ,@Descrizione   " + vbNewLine() + "    ,@PathAllegato   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_SEARCH    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@PathAllegato AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysWikiAllegati Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysWiki IS NULL OR Me.IDSysWiki = @IDSysWiki)    " + vbNewLine() + "    AND  (@IDAllegato IS NULL OR Me.IDAllegato = @IDAllegato)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@PathAllegato IS NULL OR Me.PathAllegato LIKE @PathAllegato + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_SEARCH    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + "  ,@Descrizione AS NVARCHAR(100) = NULL    " + vbNewLine() + "  ,@PathAllegato AS NVARCHAR(MAX) = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysWikiAllegati Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysWiki IS NULL OR Me.IDSysWiki = @IDSysWiki)    " + vbNewLine() + "    AND  (@IDAllegato IS NULL OR Me.IDAllegato = @IDAllegato)    " + vbNewLine() + "    AND  (@Descrizione IS NULL OR Me.Descrizione LIKE @Descrizione + '%')    " + vbNewLine() + "    AND  (@PathAllegato IS NULL OR Me.PathAllegato LIKE @PathAllegato + '%')    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_SELECT    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDAllegato]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [PathAllegato]   " + vbNewLine() + "  FROM sysWikiAllegati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_SELECT    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDAllegato AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDAllegato]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [PathAllegato]   " + vbNewLine() + "  FROM sysWikiAllegati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_SELECTALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDAllegato]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [PathAllegato]   " + vbNewLine() + "  FROM sysWikiAllegati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_SELECTALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDAllegato]   " + vbNewLine() + "    , [Descrizione]   " + vbNewLine() + "    , [PathAllegato]   " + vbNewLine() + "  FROM sysWikiAllegati WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiAllegati_UPDATE    " + vbNewLine() + "  @IDSysWiki AS int = NULL   " + vbNewLine() + "  ,@IDAllegato AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@PathAllegato AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysWikiAllegati   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , PathAllegato =  @PathAllegato   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiAllegati_UPDATE    " + vbNewLine() + "  @IDSysWiki AS int = NULL   " + vbNewLine() + "  ,@IDAllegato AS int = NULL   " + vbNewLine() + "  ,@Descrizione AS nvarchar(100)   " + vbNewLine() + "  ,@PathAllegato AS nvarchar(MAX)   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  UPDATE sysWikiAllegati   " + vbNewLine() + "    SET    " + vbNewLine() + "      Descrizione =  @Descrizione   " + vbNewLine() + "      , PathAllegato =  @PathAllegato   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDAllegato = @IDAllegato   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_DELETE    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiLinks   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDSysWikiRef = @IDSysWikiRef   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_DELETE    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiLinks   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDSysWikiRef = @IDSysWikiRef   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_DELETEALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiLinks   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_DELETEALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  DELETE FROM sysWikiLinks   " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_INSERT    " + vbNewLine() + "  @IDSysWiki AS int   " + vbNewLine() + "  ,@IDSysWikiRef AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWikiLinks (    " + vbNewLine() + "    IDSysWiki   " + vbNewLine() + "    ,IDSysWikiRef   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysWiki   " + vbNewLine() + "    ,@IDSysWikiRef   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_INSERT    " + vbNewLine() + "  @IDSysWiki AS int   " + vbNewLine() + "  ,@IDSysWikiRef AS int   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  INSERT INTO sysWikiLinks (    " + vbNewLine() + "    IDSysWiki   " + vbNewLine() + "    ,IDSysWikiRef   " + vbNewLine() + "  ) VALUES (   " + vbNewLine() + "    @IDSysWiki   " + vbNewLine() + "    ,@IDSysWikiRef   " + vbNewLine() + "  )    " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_SEARCH    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysWikiLinks Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysWiki IS NULL OR Me.IDSysWiki = @IDSysWiki)    " + vbNewLine() + "    AND  (@IDSysWikiRef IS NULL OR Me.IDSysWikiRef = @IDSysWikiRef)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_SEARCH    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE   " + vbNewLine() + "  SELECT Me.*    " + vbNewLine() + "  FROM sysWikiLinks Me WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "     (@IDSysWiki IS NULL OR Me.IDSysWiki = @IDSysWiki)    " + vbNewLine() + "    AND  (@IDSysWikiRef IS NULL OR Me.IDSysWikiRef = @IDSysWikiRef)    " + vbNewLine() + "   " + vbNewLine() + "OPTION(RECOMPILE)    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_SELECT    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDSysWikiRef]   " + vbNewLine() + "  FROM sysWikiLinks WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDSysWikiRef = @IDSysWikiRef   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_SELECT    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDSysWikiRef]   " + vbNewLine() + "  FROM sysWikiLinks WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    AND IDSysWikiRef = @IDSysWikiRef   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_SELECTALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDSysWikiRef]   " + vbNewLine() + "  FROM sysWikiLinks WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_SELECTALL    " + vbNewLine() + "  @IDSysWiki AS int = NULL    " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "  SELECT    " + vbNewLine() + "    [IDSysWiki]   " + vbNewLine() + "    , [IDSysWikiRef]   " + vbNewLine() + "  FROM sysWikiLinks WITH(NOLOCK)    " + vbNewLine() + "  WHERE    " + vbNewLine() + "    IDSysWiki = @IDSysWiki   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE BSP_sysWikiLinks_UPDATE    " + vbNewLine() + "  @IDSysWiki AS int = NULL   " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.   " + vbNewLine() + "RETURN 0   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE BSP_sysWikiLinks_UPDATE    " + vbNewLine() + "  @IDSysWiki AS int = NULL   " + vbNewLine() + "  ,@IDSysWikiRef AS int = NULL   " + vbNewLine() + " AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "--LA TABELLA CONTIENE TUTTI CAMPI CHIAVE.   " + vbNewLine() + "RETURN 0   " + vbNewLine() + "    " + vbNewLine() + "END    " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[BSP_UtentiVisibilita_SEARCH]  " + vbNewLine() + "--declare " + vbNewLine() + "  @IDSysUtente AS varchar(20) --= 'rete@balsam43'  " + vbNewLine() + "  , @IDVisibilitaSelezionata as int = -1 " + vbNewLine() + "AS  " + vbNewLine() + "BEGIN " + vbNewLine() + " " + vbNewLine() + "  SELECT  " + vbNewLine() + "	Me.IDVisibilitaTerritoriale " + vbNewLine() + "	, vt.Descrizione " + vbNewLine() + "	, isnull(me.Preferito,0) as Preferito " + vbNewLine() + "	, case when isnull(me.Preferito,0) = 0 then 'SceltaVisibilitaPreferito' else 'SceltaVisibilitaPreferitoSelezionato' end CssPreferito " + vbNewLine() + "	, case when me.IDVisibilitaTerritoriale <> @IDVisibilitaSelezionata then 'SceltaVisibilitaLink' else 'SceltaVisibilitaLinkSelezionato' end CssLink " + vbNewLine() + "  FROM webpers..UtentiVisibilita Me WITH(NOLOCK) " + vbNewLine() + "	INNER JOIN Biposte..VisibilitaTerritoriali vt on me.IDVisibilitaTerritoriale = vt.ID " + vbNewLine() + "  WHERE  " + vbNewLine() + "     Me.IDSysUtente = @IDSysUtente " + vbNewLine() + " " + vbNewLine() + " " + vbNewLine() + "END  " + vbNewLine() + " " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[BSP_UtentiVisibilita_SEARCH]  " + vbNewLine() + "--declare " + vbNewLine() + "  @IDSysUtente AS varchar(20) --= 'rete@balsam43'  " + vbNewLine() + "  , @IDVisibilitaSelezionata as int = -1 " + vbNewLine() + "AS  " + vbNewLine() + "BEGIN " + vbNewLine() + " " + vbNewLine() + "  SELECT  " + vbNewLine() + "	Me.IDVisibilitaTerritoriale " + vbNewLine() + "	, vt.Descrizione " + vbNewLine() + "	, isnull(me.Preferito,0) as Preferito " + vbNewLine() + "	, case when isnull(me.Preferito,0) = 0 then 'SceltaVisibilitaPreferito' else 'SceltaVisibilitaPreferitoSelezionato' end CssPreferito " + vbNewLine() + "	, case when me.IDVisibilitaTerritoriale <> @IDVisibilitaSelezionata then 'SceltaVisibilitaLink' else 'SceltaVisibilitaLinkSelezionato' end CssLink " + vbNewLine() + "  FROM webpers..UtentiVisibilita Me WITH(NOLOCK) " + vbNewLine() + "	INNER JOIN Biposte..VisibilitaTerritoriali vt on me.IDVisibilitaTerritoriale = vt.ID " + vbNewLine() + "  WHERE  " + vbNewLine() + "     Me.IDSysUtente = @IDSysUtente " + vbNewLine() + " " + vbNewLine() + " " + vbNewLine() + "END  " + vbNewLine() + " " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[SSP_Gloabl_SEARCH]          " + vbNewLine() + "--DECLARE   " + vbNewLine() + "	@IDSysProfilo AS int						-- = 1   " + vbNewLine() + "	, @Descrizione AS VARCHAR(250)  -- = 'UT'      " + vbNewLine() + "AS          " + vbNewLine() + "BEGIN          " + vbNewLine() + "	DECLARE @TBLRET AS TABLE (Descrizione varchar(max), comando varchar(200), Tipo tinyint, Args nvarchar(max))   " + vbNewLine() + "	DECLARE @eTipo_Menu tinyint = 0   " + vbNewLine() + "	DECLARE @eTipo_Wiki tinyint = 1   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	--FIND INTO sysFunzioni          " + vbNewLine() + "	INSERT INTO @TBLRET   " + vbNewLine() + "	SELECT           " + vbNewLine() + "		'Funzione Applicativa - ' + ISNULL(Tooltip, Descrizione) Descrizione          " + vbNewLine() + "		, COMANDO    " + vbNewLine() + "		, @eTipo_Menu   " + vbNewLine() + "		, NULL   " + vbNewLine() + "	FROM sysFunzioni F          " + vbNewLine() + "		inner join sysProfiliFunzioni pf           " + vbNewLine() + "			on pf.IDSysFunzione = f.ID          " + vbNewLine() + "	WHERE           " + vbNewLine() + "		(Descrizione LIKE '%' + @Descrizione + '%'          " + vbNewLine() + "			OR Tooltip LIKE '%' + @Descrizione + '%'   " + vbNewLine() + "			OR ShortCut LIKE '%' + @Descrizione + '%')          " + vbNewLine() + "		AND pf.IDSysProfilo = @IDSysProfilo          " + vbNewLine() + "		AND ISNULL(COMANDO,'') <> ''           " + vbNewLine() + "		AND ISNULL(COMANDO,'') <> '#'           " + vbNewLine() + "	ORDER BY           " + vbNewLine() + "		Descrizione          " + vbNewLine() + "   " + vbNewLine() + "	--FIND INTO sysWiki   " + vbNewLine() + "	INSERT INTO @TBLRET   " + vbNewLine() + "	SELECT           " + vbNewLine() + "		'Help online - ' + isnull(Titolo,'') as Descrizione   " + vbNewLine() + "		, 'SYSWIKI'   " + vbNewLine() + "		, @eTipo_Wiki   " + vbNewLine() + "		, @Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Tags like '%' + @Descrizione + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "   " + vbNewLine() + "	--OUTPUT   " + vbNewLine() + "	SELECT * FROM @TBLRET   " + vbNewLine() + "END          " + vbNewLine() + "   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[SSP_Gloabl_SEARCH]          " + vbNewLine() + "--DECLARE   " + vbNewLine() + "	@IDSysProfilo AS int						-- = 1   " + vbNewLine() + "	, @Descrizione AS VARCHAR(250)  -- = 'UT'      " + vbNewLine() + "AS          " + vbNewLine() + "BEGIN          " + vbNewLine() + "	DECLARE @TBLRET AS TABLE (Descrizione varchar(max), comando varchar(200), Tipo tinyint, Args nvarchar(max))   " + vbNewLine() + "	DECLARE @eTipo_Menu tinyint = 0   " + vbNewLine() + "	DECLARE @eTipo_Wiki tinyint = 1   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	--FIND INTO sysFunzioni          " + vbNewLine() + "	INSERT INTO @TBLRET   " + vbNewLine() + "	SELECT           " + vbNewLine() + "		'Funzione Applicativa - ' + ISNULL(Tooltip, Descrizione) Descrizione          " + vbNewLine() + "		, COMANDO    " + vbNewLine() + "		, @eTipo_Menu   " + vbNewLine() + "		, NULL   " + vbNewLine() + "	FROM sysFunzioni F          " + vbNewLine() + "		inner join sysProfiliFunzioni pf           " + vbNewLine() + "			on pf.IDSysFunzione = f.ID          " + vbNewLine() + "	WHERE           " + vbNewLine() + "		(Descrizione LIKE '%' + @Descrizione + '%'          " + vbNewLine() + "			OR Tooltip LIKE '%' + @Descrizione + '%'   " + vbNewLine() + "			OR ShortCut LIKE '%' + @Descrizione + '%')          " + vbNewLine() + "		AND pf.IDSysProfilo = @IDSysProfilo          " + vbNewLine() + "		AND ISNULL(COMANDO,'') <> ''           " + vbNewLine() + "		AND ISNULL(COMANDO,'') <> '#'           " + vbNewLine() + "	ORDER BY           " + vbNewLine() + "		Descrizione          " + vbNewLine() + "   " + vbNewLine() + "	--FIND INTO sysWiki   " + vbNewLine() + "	INSERT INTO @TBLRET   " + vbNewLine() + "	SELECT           " + vbNewLine() + "		'Help online - ' + isnull(Titolo,'') as Descrizione   " + vbNewLine() + "		, 'SYSWIKI'   " + vbNewLine() + "		, @eTipo_Wiki   " + vbNewLine() + "		, @Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Descrizione + '%'   " + vbNewLine() + "				OR Tags like '%' + @Descrizione + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "   " + vbNewLine() + "	--OUTPUT   " + vbNewLine() + "	SELECT * FROM @TBLRET   " + vbNewLine() + "END          " + vbNewLine() + "   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[SSP_sysAccessi_SEARCH]     " + vbNewLine() + "  @ID AS int = NULL     " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL     " + vbNewLine() + "  ,@DataAccessoDal AS datetime = NULL     " + vbNewLine() + "  ,@DataAccessoAl AS datetime = NULL     " + vbNewLine() + "  ,@NomeComputer AS NVARCHAR(100) = NULL     " + vbNewLine() + "  ,@OraFineLavoroDal AS datetime = NULL     " + vbNewLine() + "  ,@OraFineLavoroAl AS datetime = NULL     " + vbNewLine() + "  ,@IDPadre AS int = NULL     " + vbNewLine() + "  ,@IDSysSistema AS int = NULL     " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL     " + vbNewLine() + " AS     " + vbNewLine() + "BEGIN    " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE    " + vbNewLine() + "  SELECT Me.*     " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo    " + vbNewLine() + "  FROM sysAccessi Me WITH(NOLOCK)     " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)     " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)     " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID    " + vbNewLine() + "  WHERE     " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)     " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')     " + vbNewLine() + "    AND  (@DataAccessoDal IS NULL OR Me.DataAccesso >= @DataAccessoDal)     " + vbNewLine() + "    AND  (@DataAccessoAl IS NULL OR Me.DataAccesso <= @DataAccessoAl)     " + vbNewLine() + "    AND  (@NomeComputer IS NULL OR Me.NomeComputer LIKE @NomeComputer + '%')     " + vbNewLine() + "    AND  (@OraFineLavoroDal IS NULL OR Me.OraFineLavoro >= @OraFineLavoroDal)     " + vbNewLine() + "    AND  (@OraFineLavoroAl IS NULL OR Me.OraFineLavoro <= @OraFineLavoroAl)     " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)     " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)     " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)     " + vbNewLine() + "	ORDER BY     " + vbNewLine() + "		ME.DataAccesso DESC    " + vbNewLine() + "    " + vbNewLine() + "OPTION(RECOMPILE)     " + vbNewLine() + "END     " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[SSP_sysAccessi_SEARCH]     " + vbNewLine() + "  @ID AS int = NULL     " + vbNewLine() + "  ,@IDSysUtente AS NVARCHAR(20) = NULL     " + vbNewLine() + "  ,@DataAccessoDal AS datetime = NULL     " + vbNewLine() + "  ,@DataAccessoAl AS datetime = NULL     " + vbNewLine() + "  ,@NomeComputer AS NVARCHAR(100) = NULL     " + vbNewLine() + "  ,@OraFineLavoroDal AS datetime = NULL     " + vbNewLine() + "  ,@OraFineLavoroAl AS datetime = NULL     " + vbNewLine() + "  ,@IDPadre AS int = NULL     " + vbNewLine() + "  ,@IDSysSistema AS int = NULL     " + vbNewLine() + "  ,@IDSysProfilo AS int = NULL     " + vbNewLine() + " AS     " + vbNewLine() + "BEGIN    " + vbNewLine() + "  --ATTENZIONE... LA SEGUENTE QUERY NON PERFORMANTE PERTANTO LIMITARNE L'USO O CUSTOMIZZARLA ALL'OCCASIONE    " + vbNewLine() + "  SELECT Me.*     " + vbNewLine() + "    , sysSistemi.Descrizione SysSistema    " + vbNewLine() + "    , sysProfili.Descrizione SysProfilo    " + vbNewLine() + "  FROM sysAccessi Me WITH(NOLOCK)     " + vbNewLine() + "    LEFT JOIN sysSistemi sysSistemi WITH(NOLOCK)     " + vbNewLine() + "      ON Me.IDSysSistema = sysSistemi.ID    " + vbNewLine() + "    LEFT JOIN sysProfili sysProfili WITH(NOLOCK)     " + vbNewLine() + "      ON Me.IDSysProfilo = sysProfili.ID    " + vbNewLine() + "  WHERE     " + vbNewLine() + "     (@ID IS NULL OR Me.ID = @ID)     " + vbNewLine() + "    AND  (@IDSysUtente IS NULL OR Me.IDSysUtente LIKE @IDSysUtente + '%')     " + vbNewLine() + "    AND  (@DataAccessoDal IS NULL OR Me.DataAccesso >= @DataAccessoDal)     " + vbNewLine() + "    AND  (@DataAccessoAl IS NULL OR Me.DataAccesso <= @DataAccessoAl)     " + vbNewLine() + "    AND  (@NomeComputer IS NULL OR Me.NomeComputer LIKE @NomeComputer + '%')     " + vbNewLine() + "    AND  (@OraFineLavoroDal IS NULL OR Me.OraFineLavoro >= @OraFineLavoroDal)     " + vbNewLine() + "    AND  (@OraFineLavoroAl IS NULL OR Me.OraFineLavoro <= @OraFineLavoroAl)     " + vbNewLine() + "    AND  (@IDPadre IS NULL OR Me.IDPadre = @IDPadre)     " + vbNewLine() + "    AND  (@IDSysSistema IS NULL OR Me.IDSysSistema = @IDSysSistema)     " + vbNewLine() + "    AND  (@IDSysProfilo IS NULL OR Me.IDSysProfilo = @IDSysProfilo)     " + vbNewLine() + "	ORDER BY     " + vbNewLine() + "		ME.DataAccesso DESC    " + vbNewLine() + "    " + vbNewLine() + "OPTION(RECOMPILE)     " + vbNewLine() + "END     " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[WSP_sysPersone_SEARCH]         " + vbNewLine() + "--declare        " + vbNewLine() + "  @Descrizione AS VARCHAR(100) = null        " + vbNewLine() + "AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "        " + vbNewLine() + "  SELECT         " + vbNewLine() + "		v.ID         " + vbNewLine() + "		, v.Descrizione        " + vbNewLine() + "        " + vbNewLine() + "  FROM vSysPersone v WITH(NOLOCK)               " + vbNewLine() + "  WHERE         " + vbNewLine() + "		(@Descrizione is null or v.Descrizione like @Descrizione + '%')        " + vbNewLine() + "	ORDER BY         " + vbNewLine() + "		Descrizione        " + vbNewLine() + "        " + vbNewLine() + "END         " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[WSP_sysPersone_SEARCH]         " + vbNewLine() + "--declare        " + vbNewLine() + "  @Descrizione AS VARCHAR(100) = null        " + vbNewLine() + "AS         " + vbNewLine() + "BEGIN        " + vbNewLine() + "        " + vbNewLine() + "  SELECT         " + vbNewLine() + "		v.ID         " + vbNewLine() + "		, v.Descrizione        " + vbNewLine() + "        " + vbNewLine() + "  FROM vSysPersone v WITH(NOLOCK)               " + vbNewLine() + "  WHERE         " + vbNewLine() + "		(@Descrizione is null or v.Descrizione like @Descrizione + '%')        " + vbNewLine() + "	ORDER BY         " + vbNewLine() + "		Descrizione        " + vbNewLine() + "        " + vbNewLine() + "END         " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaStoredProcedure(DB, "CREATE PROCEDURE [dbo].[WSP_sysWiki_SEARCH]   " + vbNewLine() + "	@Testo nvarchar(50) = ''   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	SELECT    " + vbNewLine() + "		ID   " + vbNewLine() + "		, isnull(Titolo,'') as Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Testo + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Testo + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Testo + '%'   " + vbNewLine() + "				OR Tags like '%' + @Testo + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "END  " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Stored Procedure fallita: <<CREATE PROCEDURE [dbo].[WSP_sysWiki_SEARCH]   " + vbNewLine() + "	@Testo nvarchar(50) = ''   " + vbNewLine() + "AS   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	SELECT    " + vbNewLine() + "		ID   " + vbNewLine() + "		, isnull(Titolo,'') as Descrizione   " + vbNewLine() + "	FROM sysWiki   " + vbNewLine() + "	WHERE    " + vbNewLine() + "		Pubblica = 1   " + vbNewLine() + "		AND (Titolo like '%' + @Testo + '%'   " + vbNewLine() + "				OR Sottotitolo like '%' + @Testo + '%'   " + vbNewLine() + "				OR Descrizione like '%' + @Testo + '%'   " + vbNewLine() + "				OR Tags like '%' + @Testo + '%')   " + vbNewLine() + "	ORDER BY    " + vbNewLine() + "		isnull(Titolo,'')    " + vbNewLine() + "END  " + vbNewLine() + ">>");

        //GESTIONE FUNCTION
        if (!BAggiornaDB.CreaFunction(DB, "CREATE FUNCTION [dbo].[BFn_PrendiData]   " + vbNewLine() + "(   " + vbNewLine() + "	@sData varchar(30)    " + vbNewLine() + ")   " + vbNewLine() + "RETURNS DATE   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "   " + vbNewLine() + "	DECLARE    " + vbNewLine() + "		@RET DATE = NULL   " + vbNewLine() + "		, @ANNO VARCHAR(4) = ''   " + vbNewLine() + "		, @MESE VARCHAR(2) = ''   " + vbNewLine() + "		, @GIORNO VARCHAR(2) = ''   " + vbNewLine() + "		, @cSEP VARCHAR(1)   " + vbNewLine() + "		, @iSEP INT = 0   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	SET @sData = CASE WHEN @sData = '' THEN NULL ELSE @sData END   " + vbNewLine() + "	SET @sData = CASE WHEN LEN(@sData) > 10 THEN SUBSTRING(@sData, 1,10) ELSE @sData END   " + vbNewLine() + "	SET @sData = CASE WHEN LEN(@sData) < 8 THEN NULL ELSE @sData END   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	IF LEN(@sData) > 8 BEGIN   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('.', @sData) > 0 THEN '.' ELSE @cSEP END   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('-', @sData) > 0 THEN '-' ELSE @cSEP END   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('/', @sData) > 0 THEN '/' ELSE @cSEP END   " + vbNewLine() + "		IF @cSEP = '' SET @sData = NULL   " + vbNewLine() + "	END   " + vbNewLine() + "	SET @cSEP = ISNULL(@cSEP, '')   " + vbNewLine() + "	SET @iSEP = ISNULL(CHARINDEX(@cSEP, @sData),0)   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	IF @iSEP > 3 BEGIN --FORMATO AAAA-MM-GG   " + vbNewLine() + "		IF ISDATE(@sData) = 0	SET @sData = NULL   " + vbNewLine() + "	END ELSE BEGIN -- CHECK FORMATO ITALIANO   " + vbNewLine() + "		SET @sData = REPLACE(@sData, @cSEP, '')   " + vbNewLine() + "		SET @GIORNO = SUBSTRING(@sData, 1, 2)   " + vbNewLine() + "		SET @MESE = SUBSTRING(@sData, 3, 2)   " + vbNewLine() + "		SET @ANNO = SUBSTRING(@sData, 5, 4)   " + vbNewLine() + "		SET @sData = @ANNO + '-' + @MESE + '-' + @GIORNO   " + vbNewLine() + "	END   " + vbNewLine() + "	   " + vbNewLine() + "	IF ISDATE(@sData) = 0	SET @sData = NULL   " + vbNewLine() + "   " + vbNewLine() + "	SET @RET = CAST(@sData AS date)   " + vbNewLine() + "   " + vbNewLine() + "	RETURN @RET   " + vbNewLine() + "END   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Function fallita: <<CREATE FUNCTION [dbo].[BFn_PrendiData]   " + vbNewLine() + "(   " + vbNewLine() + "	@sData varchar(30)    " + vbNewLine() + ")   " + vbNewLine() + "RETURNS DATE   " + vbNewLine() + "AS    " + vbNewLine() + "BEGIN   " + vbNewLine() + "   " + vbNewLine() + "	DECLARE    " + vbNewLine() + "		@RET DATE = NULL   " + vbNewLine() + "		, @ANNO VARCHAR(4) = ''   " + vbNewLine() + "		, @MESE VARCHAR(2) = ''   " + vbNewLine() + "		, @GIORNO VARCHAR(2) = ''   " + vbNewLine() + "		, @cSEP VARCHAR(1)   " + vbNewLine() + "		, @iSEP INT = 0   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	SET @sData = CASE WHEN @sData = '' THEN NULL ELSE @sData END   " + vbNewLine() + "	SET @sData = CASE WHEN LEN(@sData) > 10 THEN SUBSTRING(@sData, 1,10) ELSE @sData END   " + vbNewLine() + "	SET @sData = CASE WHEN LEN(@sData) < 8 THEN NULL ELSE @sData END   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	IF LEN(@sData) > 8 BEGIN   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('.', @sData) > 0 THEN '.' ELSE @cSEP END   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('-', @sData) > 0 THEN '-' ELSE @cSEP END   " + vbNewLine() + "		SET @cSEP = CASE WHEN CHARINDEX('/', @sData) > 0 THEN '/' ELSE @cSEP END   " + vbNewLine() + "		IF @cSEP = '' SET @sData = NULL   " + vbNewLine() + "	END   " + vbNewLine() + "	SET @cSEP = ISNULL(@cSEP, '')   " + vbNewLine() + "	SET @iSEP = ISNULL(CHARINDEX(@cSEP, @sData),0)   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "	IF @iSEP > 3 BEGIN --FORMATO AAAA-MM-GG   " + vbNewLine() + "		IF ISDATE(@sData) = 0	SET @sData = NULL   " + vbNewLine() + "	END ELSE BEGIN -- CHECK FORMATO ITALIANO   " + vbNewLine() + "		SET @sData = REPLACE(@sData, @cSEP, '')   " + vbNewLine() + "		SET @GIORNO = SUBSTRING(@sData, 1, 2)   " + vbNewLine() + "		SET @MESE = SUBSTRING(@sData, 3, 2)   " + vbNewLine() + "		SET @ANNO = SUBSTRING(@sData, 5, 4)   " + vbNewLine() + "		SET @sData = @ANNO + '-' + @MESE + '-' + @GIORNO   " + vbNewLine() + "	END   " + vbNewLine() + "	   " + vbNewLine() + "	IF ISDATE(@sData) = 0	SET @sData = NULL   " + vbNewLine() + "   " + vbNewLine() + "	SET @RET = CAST(@sData AS date)   " + vbNewLine() + "   " + vbNewLine() + "	RETURN @RET   " + vbNewLine() + "END   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaFunction(DB, "CREATE FUNCTION BFn_PrendiNumero   " + vbNewLine() + "(   " + vbNewLine() + "--declare   " + vbNewLine() + "	@sNumero as varchar(30) = null   " + vbNewLine() + "--	@sNumero as varchar(30) = '1.231.321'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1,231,321.12'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1.200.025,12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1200025,12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1200025.12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = ''   " + vbNewLine() + "--/*   " + vbNewLine() + ")   " + vbNewLine() + "RETURNS float   " + vbNewLine() + "AS --*/   " + vbNewLine() + "BEGIN   " + vbNewLine() + "   " + vbNewLine() + "	DECLARE    " + vbNewLine() + "		@ret float = 0   " + vbNewLine() + "		, @iPoint int = 0   " + vbNewLine() + "		, @iVirgola int = 0   " + vbNewLine() + "   " + vbNewLine() + "	SET @sNumero = ISNULL(@sNumero, '0')   " + vbNewLine() + "	SET @sNumero = CASE WHEN @sNumero = '' THEN '0' ELSE @sNumero END   " + vbNewLine() + "   " + vbNewLine() + "	--CORREGGO STRINGA INPUT   " + vbNewLine() + "	SELECT @iPoint = CHARINDEX('.', @sNumero);     " + vbNewLine() + "	SELECT @iVirgola = CHARINDEX(',', @sNumero);     " + vbNewLine() + "	--select @iPoint, @iVirgola   " + vbNewLine() + "	if @iPoint <> 0 and @iVirgola <> 0 begin   " + vbNewLine() + "		set @sNumero = REPLACE(@sNumero, '.','')   " + vbNewLine() + "		set @sNumero = REPLACE(@sNumero, ',','.')   " + vbNewLine() + "	end ELSE BEGIN   " + vbNewLine() + "		if @iPoint <> 0 begin   " + vbNewLine() + "			set @iPoint = CHARINDEX('.', @sNumero, @iPoint + 1);    " + vbNewLine() + "			if @iPoint <> 0 begin   " + vbNewLine() + "				set @sNumero = REPLACE(@sNumero, '.','')   " + vbNewLine() + "			end    " + vbNewLine() + "		end   " + vbNewLine() + "		if @iVirgola <> 0 begin   " + vbNewLine() + "			set @iVirgola = CHARINDEX(',', @sNumero, @iVirgola + 1);    " + vbNewLine() + "			if @iVirgola <> 0 begin   " + vbNewLine() + "				set @sNumero = NULL -- ERRORE DOPPIA VIRGOLA   " + vbNewLine() + "			end ELSE BEGIN   " + vbNewLine() + "				set @sNumero = REPLACE(@sNumero, ',','.')   " + vbNewLine() + "			END   " + vbNewLine() + "		end   " + vbNewLine() + "	END   " + vbNewLine() + "	-- CHECK IS NUMERIC   " + vbNewLine() + "	if @sNumero is null OR ISNUMERIC(@sNumero)=0 begin   " + vbNewLine() + "		--select NULL   " + vbNewLine() + "		return NULL   " + vbNewLine() + "	end   " + vbNewLine() + "   " + vbNewLine() + "	--SELECT @sNumero	   " + vbNewLine() + "	--CAST TO FLOAT   " + vbNewLine() + "	SELECT @ret = CAST(@sNumero as float)   " + vbNewLine() + "   " + vbNewLine() + "	RETURN @ret   " + vbNewLine() + "	--select @ret   " + vbNewLine() + "   " + vbNewLine() + "END   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Function fallita: <<CREATE FUNCTION BFn_PrendiNumero   " + vbNewLine() + "(   " + vbNewLine() + "--declare   " + vbNewLine() + "	@sNumero as varchar(30) = null   " + vbNewLine() + "--	@sNumero as varchar(30) = '1.231.321'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1,231,321.12'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1.200.025,12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1200025,12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = '1200025.12645'   " + vbNewLine() + "--	@sNumero as varchar(30) = ''   " + vbNewLine() + "--/*   " + vbNewLine() + ")   " + vbNewLine() + "RETURNS float   " + vbNewLine() + "AS --*/   " + vbNewLine() + "BEGIN   " + vbNewLine() + "   " + vbNewLine() + "	DECLARE    " + vbNewLine() + "		@ret float = 0   " + vbNewLine() + "		, @iPoint int = 0   " + vbNewLine() + "		, @iVirgola int = 0   " + vbNewLine() + "   " + vbNewLine() + "	SET @sNumero = ISNULL(@sNumero, '0')   " + vbNewLine() + "	SET @sNumero = CASE WHEN @sNumero = '' THEN '0' ELSE @sNumero END   " + vbNewLine() + "   " + vbNewLine() + "	--CORREGGO STRINGA INPUT   " + vbNewLine() + "	SELECT @iPoint = CHARINDEX('.', @sNumero);     " + vbNewLine() + "	SELECT @iVirgola = CHARINDEX(',', @sNumero);     " + vbNewLine() + "	--select @iPoint, @iVirgola   " + vbNewLine() + "	if @iPoint <> 0 and @iVirgola <> 0 begin   " + vbNewLine() + "		set @sNumero = REPLACE(@sNumero, '.','')   " + vbNewLine() + "		set @sNumero = REPLACE(@sNumero, ',','.')   " + vbNewLine() + "	end ELSE BEGIN   " + vbNewLine() + "		if @iPoint <> 0 begin   " + vbNewLine() + "			set @iPoint = CHARINDEX('.', @sNumero, @iPoint + 1);    " + vbNewLine() + "			if @iPoint <> 0 begin   " + vbNewLine() + "				set @sNumero = REPLACE(@sNumero, '.','')   " + vbNewLine() + "			end    " + vbNewLine() + "		end   " + vbNewLine() + "		if @iVirgola <> 0 begin   " + vbNewLine() + "			set @iVirgola = CHARINDEX(',', @sNumero, @iVirgola + 1);    " + vbNewLine() + "			if @iVirgola <> 0 begin   " + vbNewLine() + "				set @sNumero = NULL -- ERRORE DOPPIA VIRGOLA   " + vbNewLine() + "			end ELSE BEGIN   " + vbNewLine() + "				set @sNumero = REPLACE(@sNumero, ',','.')   " + vbNewLine() + "			END   " + vbNewLine() + "		end   " + vbNewLine() + "	END   " + vbNewLine() + "	-- CHECK IS NUMERIC   " + vbNewLine() + "	if @sNumero is null OR ISNUMERIC(@sNumero)=0 begin   " + vbNewLine() + "		--select NULL   " + vbNewLine() + "		return NULL   " + vbNewLine() + "	end   " + vbNewLine() + "   " + vbNewLine() + "	--SELECT @sNumero	   " + vbNewLine() + "	--CAST TO FLOAT   " + vbNewLine() + "	SELECT @ret = CAST(@sNumero as float)   " + vbNewLine() + "   " + vbNewLine() + "	RETURN @ret   " + vbNewLine() + "	--select @ret   " + vbNewLine() + "   " + vbNewLine() + "END   " + vbNewLine() + ">>");
        if (!BAggiornaDB.CreaFunction(DB, "CREATE FUNCTION [dbo].[BFn_Split](   " + vbNewLine() + "    @sInputList VARCHAR(max)   " + vbNewLine() + "  , @sDelimiter VARCHAR(3)   " + vbNewLine() + ") RETURNS @List TABLE (item VARCHAR(MAX))   " + vbNewLine() + "   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	DECLARE @sItem VARCHAR(300)   " + vbNewLine() + "	WHILE CHARINDEX(@sDelimiter,@sInputList,0) <> 0   " + vbNewLine() + " 	BEGIN   " + vbNewLine() + " 		SELECT   " + vbNewLine() + "  			@sItem=RTRIM(LTRIM(SUBSTRING(@sInputList,1,CHARINDEX(@sDelimiter,@sInputList,0)-1))),   " + vbNewLine() + "  			@sInputList=RTRIM(LTRIM(SUBSTRING(@sInputList,CHARINDEX(@sDelimiter,@sInputList,0)+LEN(@sDelimiter),LEN(@sInputList))))   " + vbNewLine() + "    " + vbNewLine() + " 		IF LEN(@sItem) > 0   " + vbNewLine() + "  			INSERT INTO @List SELECT @sItem   " + vbNewLine() + " 	END   " + vbNewLine() + "   " + vbNewLine() + "	IF LEN(@sInputList) > 0   " + vbNewLine() + " 		INSERT INTO @List SELECT @sInputList   " + vbNewLine() + "	RETURN   " + vbNewLine() + "END   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + "", bLog))
          throw new System.Exception("Creazione Function fallita: <<CREATE FUNCTION [dbo].[BFn_Split](   " + vbNewLine() + "    @sInputList VARCHAR(max)   " + vbNewLine() + "  , @sDelimiter VARCHAR(3)   " + vbNewLine() + ") RETURNS @List TABLE (item VARCHAR(MAX))   " + vbNewLine() + "   " + vbNewLine() + "BEGIN   " + vbNewLine() + "	DECLARE @sItem VARCHAR(300)   " + vbNewLine() + "	WHILE CHARINDEX(@sDelimiter,@sInputList,0) <> 0   " + vbNewLine() + " 	BEGIN   " + vbNewLine() + " 		SELECT   " + vbNewLine() + "  			@sItem=RTRIM(LTRIM(SUBSTRING(@sInputList,1,CHARINDEX(@sDelimiter,@sInputList,0)-1))),   " + vbNewLine() + "  			@sInputList=RTRIM(LTRIM(SUBSTRING(@sInputList,CHARINDEX(@sDelimiter,@sInputList,0)+LEN(@sDelimiter),LEN(@sInputList))))   " + vbNewLine() + "    " + vbNewLine() + " 		IF LEN(@sItem) > 0   " + vbNewLine() + "  			INSERT INTO @List SELECT @sItem   " + vbNewLine() + " 	END   " + vbNewLine() + "   " + vbNewLine() + "	IF LEN(@sInputList) > 0   " + vbNewLine() + " 		INSERT INTO @List SELECT @sInputList   " + vbNewLine() + "	RETURN   " + vbNewLine() + "END   " + vbNewLine() + "   " + vbNewLine() + "   " + vbNewLine() + ">>");

        //GESTIONE INDICI


        DB.CommitTrans();
        DB.EndTrans();
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** " + ex.Message);
        DB.RollBackTrans();
        DB.EndTrans();
        return false;
      }
    }
    #endregion


    //DEFINIZIONE FUNZIONI PER AGGIORNAMENTO TABELLE
    #region public static bool CreaTabella_Configuration
    public static bool CreaTabella_Configuration(BConnection DB, BLogText bLog)
    {
      string Nome = "Configuration";
      string Comando = "CREATE TABLE Configuration([ID] int NOT NULL , [Descrizione] nvarchar(500), [Logo] varbinary(MAX), [MittenteMail] nvarchar(400), [DestinatarioMail] nvarchar(400), [LeggePrivacy] nvarchar(MAX), [IDSistemaRegistrazione] int, [IDProfiloRegistrazione] int, [EmailSegnalazioni] nvarchar(400), [LastSyncNotifiche] datetime, [TimerSyncNotify] int, [IDProfiloNotificaRegistrazione] int, [IDAmbiente] int, [IDApplicazione] int, CONSTRAINT PK_Configuration PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
            }


            //Logo
            dc = dt.Columns["Logo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Logo varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Logo varbinary(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Logo varbinary(MAX) NULL");
              }
            }


            //MittenteMail
            dc = dt.Columns["MittenteMail"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD MittenteMail nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN MittenteMail nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN MittenteMail nvarchar(200) NULL");
              }
            }


            //DestinatarioMail
            dc = dt.Columns["DestinatarioMail"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DestinatarioMail nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DestinatarioMail nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DestinatarioMail nvarchar(200) NULL");
              }
            }


            //LeggePrivacy
            dc = dt.Columns["LeggePrivacy"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD LeggePrivacy nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LeggePrivacy nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LeggePrivacy nvarchar(MAX) NULL");
              }
            }


            //IDSistemaRegistrazione
            dc = dt.Columns["IDSistemaRegistrazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSistemaRegistrazione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSistemaRegistrazione int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSistemaRegistrazione int NULL");
              }
            }


            //IDProfiloRegistrazione
            dc = dt.Columns["IDProfiloRegistrazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDProfiloRegistrazione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProfiloRegistrazione int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProfiloRegistrazione int NULL");
              }
            }


            //EmailSegnalazioni
            dc = dt.Columns["EmailSegnalazioni"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD EmailSegnalazioni nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN EmailSegnalazioni nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN EmailSegnalazioni nvarchar(200) NULL");
              }
            }


            //LastSyncNotifiche
            dc = dt.Columns["LastSyncNotifiche"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD LastSyncNotifiche datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LastSyncNotifiche datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LastSyncNotifiche datetime NULL");
              }
            }


            //TimerSyncNotify
            dc = dt.Columns["TimerSyncNotify"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD TimerSyncNotify int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN TimerSyncNotify int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN TimerSyncNotify int NULL");
              }
            }


            //IDProfiloNotificaRegistrazione
            dc = dt.Columns["IDProfiloNotificaRegistrazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDProfiloNotificaRegistrazione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProfiloNotificaRegistrazione int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProfiloNotificaRegistrazione int NULL");
              }
            }


            //IDAmbiente
            dc = dt.Columns["IDAmbiente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDAmbiente int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDAmbiente int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDAmbiente int NULL");
              }
            }


            //IDApplicazione
            dc = dt.Columns["IDApplicazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDApplicazione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDApplicazione int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDApplicazione int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysAccessi
    public static bool CreaTabella_sysAccessi(BConnection DB, BLogText bLog)
    {
      string Nome = "sysAccessi";
      string Comando = "CREATE TABLE sysAccessi([ID] int IDENTITY (0,1)  NOT NULL , [IDSysUtente] nvarchar(40), [DataAccesso] datetime, [NomeComputer] nvarchar(200), [OraFineLavoro] datetime, [IDPadre] int, [IDSysSistema] int, [IDSysProfilo] int, CONSTRAINT PK_sysAccessi PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDSysUtente
            dc = dt.Columns["IDSysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtente nvarchar(20)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(20)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(20) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(20) NULL");
              }
            }


            //DataAccesso
            dc = dt.Columns["DataAccesso"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataAccesso datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataAccesso datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataAccesso datetime NULL");
              }
            }


            //NomeComputer
            dc = dt.Columns["NomeComputer"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD NomeComputer nvarchar(100)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(100)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeComputer nvarchar(100) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeComputer nvarchar(100) NULL");
              }
            }


            //OraFineLavoro
            dc = dt.Columns["OraFineLavoro"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD OraFineLavoro datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN OraFineLavoro datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN OraFineLavoro datetime NULL");
              }
            }


            //IDPadre
            dc = dt.Columns["IDPadre"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDPadre int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
            }


            //IDSysSistema
            dc = dt.Columns["IDSysSistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSistema int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
            }


            //IDSysProfilo
            dc = dt.Columns["IDSysProfilo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysProfilo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysAccessiOperazioni
    public static bool CreaTabella_sysAccessiOperazioni(BConnection DB, BLogText bLog)
    {
      string Nome = "sysAccessiOperazioni";
      string Comando = "CREATE TABLE sysAccessiOperazioni([ID] int IDENTITY (0,1)  NOT NULL , [IDSysAccesso] int, [IDSysFunzione] int, [Data] datetime, [Operazione] nvarchar(MAX), CONSTRAINT PK_sysAccessiOperazioni PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDSysAccesso
            dc = dt.Columns["IDSysAccesso"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysAccesso int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysAccesso int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysAccesso int NULL");
              }
            }


            //IDSysFunzione
            dc = dt.Columns["IDSysFunzione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysFunzione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysFunzione int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysFunzione int NULL");
              }
            }


            //Data
            dc = dt.Columns["Data"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Data datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NULL");
              }
            }


            //Operazione
            dc = dt.Columns["Operazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Operazione nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Operazione nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Operazione nvarchar(MAX) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysComuni
    public static bool CreaTabella_sysComuni(BConnection DB, BLogText bLog)
    {
      string Nome = "sysComuni";
      string Comando = "CREATE TABLE sysComuni([ID] nvarchar(16) NOT NULL , [Descrizione] nvarchar(200), [CodiceIstat] nvarchar(40), [CodiceIstatAsl] nvarchar(12), [CAP] nvarchar(40), [IDProvincia] nvarchar(8), [DataIstituzione] datetime, [DataCessazione] datetime, [Patrono] nvarchar(16), CONSTRAINT PK_sysComuni PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID nvarchar(8)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(8)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(8) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(8) NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(100)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(100)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(100) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(100) NULL");
              }
            }


            //CodiceIstat
            dc = dt.Columns["CodiceIstat"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CodiceIstat nvarchar(20)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(20)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceIstat nvarchar(20) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceIstat nvarchar(20) NULL");
              }
            }


            //CodiceIstatAsl
            dc = dt.Columns["CodiceIstatAsl"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CodiceIstatAsl nvarchar(6)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(6)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceIstatAsl nvarchar(6) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceIstatAsl nvarchar(6) NULL");
              }
            }


            //CAP
            dc = dt.Columns["CAP"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CAP nvarchar(20)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(20)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAP nvarchar(20) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAP nvarchar(20) NULL");
              }
            }


            //IDProvincia
            dc = dt.Columns["IDProvincia"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDProvincia nvarchar(4)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(4)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProvincia nvarchar(4) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDProvincia nvarchar(4) NULL");
              }
            }


            //DataIstituzione
            dc = dt.Columns["DataIstituzione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataIstituzione datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataIstituzione datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataIstituzione datetime NULL");
              }
            }


            //DataCessazione
            dc = dt.Columns["DataCessazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataCessazione datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCessazione datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCessazione datetime NULL");
              }
            }


            //Patrono
            dc = dt.Columns["Patrono"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Patrono nvarchar(8)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(8)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Patrono nvarchar(8) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Patrono nvarchar(8) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysComuniQuartieri
    public static bool CreaTabella_sysComuniQuartieri(BConnection DB, BLogText bLog)
    {
      string Nome = "sysComuniQuartieri";
      string Comando = "CREATE TABLE sysComuniQuartieri([IDComune] nvarchar(32) NOT NULL , [IDQuartiere] int NOT NULL , [Descrizione] nvarchar(800), CONSTRAINT PK_sysComuniQuartieri PRIMARY KEY ([IDComune], [IDQuartiere]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDComune
            dc = dt.Columns["IDComune"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDComune nvarchar(16)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(16)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComune nvarchar(16) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComune nvarchar(16) NOT NULL");
              }
            }


            //IDQuartiere
            dc = dt.Columns["IDQuartiere"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDQuartiere int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiere int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiere int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(400)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(400)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(400) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(400) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDComune,IDQuartiere)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysFunzioni
    public static bool CreaTabella_sysFunzioni(BConnection DB, BLogText bLog)
    {
      string Nome = "sysFunzioni";
      string Comando = "CREATE TABLE sysFunzioni([ID] int IDENTITY (0,1)  NOT NULL , [IDPadre] int, [Descrizione] nvarchar(500), [Comando] nvarchar(400), [Ordine] int, [Auth] bit, [Developer] bit, [Attivo] bit, [IDSysModulo] int, [Tooltip] nvarchar(MAX), [ShortCut] nvarchar(MAX), [Image] varbinary(MAX), [IDFunzioneWP] int, CONSTRAINT PK_sysFunzioni PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDPadre
            dc = dt.Columns["IDPadre"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDPadre int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
            }


            //Comando
            dc = dt.Columns["Comando"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Comando nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Comando nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Comando nvarchar(200) NULL");
              }
            }


            //Ordine
            dc = dt.Columns["Ordine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Ordine int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Ordine int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Ordine int NULL");
              }
            }


            //Auth
            dc = dt.Columns["Auth"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Auth bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Auth bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Auth bit NULL");
              }
            }


            //Developer
            dc = dt.Columns["Developer"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Developer bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Developer bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Developer bit NULL");
              }
            }


            //Attivo
            dc = dt.Columns["Attivo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Attivo bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
            }


            //IDSysModulo
            dc = dt.Columns["IDSysModulo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysModulo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysModulo int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysModulo int NULL");
              }
            }


            //Tooltip
            dc = dt.Columns["Tooltip"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Tooltip nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Tooltip nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Tooltip nvarchar(MAX) NULL");
              }
            }


            //ShortCut
            dc = dt.Columns["ShortCut"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ShortCut nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ShortCut nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ShortCut nvarchar(MAX) NULL");
              }
            }


            //Image
            dc = dt.Columns["Image"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Image varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Image varbinary(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Image varbinary(MAX) NULL");
              }
            }


            //IDFunzioneWP
            dc = dt.Columns["IDFunzioneWP"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDFunzioneWP int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDFunzioneWP int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDFunzioneWP int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysImportFiles
    public static bool CreaTabella_sysImportFiles(BConnection DB, BLogText bLog)
    {
      string Nome = "sysImportFiles";
      string Comando = "CREATE TABLE sysImportFiles([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(400), [NomeFile] nvarchar(MAX), [ContentFile] varbinary(MAX), [RowHeader] nvarchar(MAX), [NomeTblImport] nvarchar(400), [DataCreazione] datetime, [DataInizioImport] datetime, [DataFineImport] datetime, [DataChiusura] datetime, [IDSysUtente] nvarchar(160), CONSTRAINT PK_sysImportFiles PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }


            //NomeFile
            dc = dt.Columns["NomeFile"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD NomeFile nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeFile nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeFile nvarchar(MAX) NULL");
              }
            }


            //ContentFile
            dc = dt.Columns["ContentFile"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ContentFile varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ContentFile varbinary(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ContentFile varbinary(MAX) NULL");
              }
            }


            //RowHeader
            dc = dt.Columns["RowHeader"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD RowHeader nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN RowHeader nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN RowHeader nvarchar(MAX) NULL");
              }
            }


            //NomeTblImport
            dc = dt.Columns["NomeTblImport"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD NomeTblImport nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeTblImport nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NomeTblImport nvarchar(200) NULL");
              }
            }


            //DataCreazione
            dc = dt.Columns["DataCreazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataCreazione datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCreazione datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCreazione datetime NULL");
              }
            }


            //DataInizioImport
            dc = dt.Columns["DataInizioImport"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataInizioImport datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizioImport datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizioImport datetime NULL");
              }
            }


            //DataFineImport
            dc = dt.Columns["DataFineImport"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataFineImport datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFineImport datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFineImport datetime NULL");
              }
            }


            //DataChiusura
            dc = dt.Columns["DataChiusura"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataChiusura datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataChiusura datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataChiusura datetime NULL");
              }
            }


            //IDSysUtente
            dc = dt.Columns["IDSysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysLog
    public static bool CreaTabella_sysLog(BConnection DB, BLogText bLog)
    {
      string Nome = "sysLog";
      string Comando = "CREATE TABLE sysLog([ID] int IDENTITY (0,1)  NOT NULL , [IDSysAccesso] int, [Data] datetime, [Origine] nvarchar(MAX), [Messaggio] nvarchar(MAX), [IDSysSeverity] int, CONSTRAINT PK_sysLog PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDSysAccesso
            dc = dt.Columns["IDSysAccesso"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysAccesso int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysAccesso int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysAccesso int NULL");
              }
            }


            //Data
            dc = dt.Columns["Data"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Data datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NULL");
              }
            }


            //Origine
            dc = dt.Columns["Origine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Origine nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Origine nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Origine nvarchar(MAX) NULL");
              }
            }


            //Messaggio
            dc = dt.Columns["Messaggio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Messaggio nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Messaggio nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Messaggio nvarchar(MAX) NULL");
              }
            }


            //IDSysSeverity
            dc = dt.Columns["IDSysSeverity"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSeverity int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSeverity int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSeverity int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysModuli
    public static bool CreaTabella_sysModuli(BConnection DB, BLogText bLog)
    {
      string Nome = "sysModuli";
      string Comando = "CREATE TABLE sysModuli([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(100), CONSTRAINT PK_sysModuli PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(50)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(50)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(50) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(50) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysNotifiche
    public static bool CreaTabella_sysNotifiche(BConnection DB, BLogText bLog)
    {
      string Nome = "sysNotifiche";
      string Comando = "CREATE TABLE sysNotifiche([ID] int IDENTITY (0,1)  NOT NULL , [Titolo] nvarchar(400), [Descrizione] nvarchar(2000), [DataNotifica] datetime, [LimitaVisibilita] bit, [IDSysSistema] int, [IDSysProfilo] int, [InviaEmail] bit, [DataUltimaModifica] datetime, [IDSysUtenteUltimaModifica] nvarchar(160), [IDSysUtente] nvarchar(160), CONSTRAINT PK_sysNotifiche PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Titolo
            dc = dt.Columns["Titolo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Titolo nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Titolo nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Titolo nvarchar(200) NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(1000)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(1000)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(1000) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(1000) NULL");
              }
            }


            //DataNotifica
            dc = dt.Columns["DataNotifica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataNotifica datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNotifica datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNotifica datetime NULL");
              }
            }


            //LimitaVisibilita
            dc = dt.Columns["LimitaVisibilita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD LimitaVisibilita bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LimitaVisibilita bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LimitaVisibilita bit NULL");
              }
            }


            //IDSysSistema
            dc = dt.Columns["IDSysSistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSistema int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
            }


            //IDSysProfilo
            dc = dt.Columns["IDSysProfilo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysProfilo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
            }


            //InviaEmail
            dc = dt.Columns["InviaEmail"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD InviaEmail bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN InviaEmail bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN InviaEmail bit NULL");
              }
            }


            //DataUltimaModifica
            dc = dt.Columns["DataUltimaModifica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataUltimaModifica datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimaModifica datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimaModifica datetime NULL");
              }
            }


            //IDSysUtenteUltimaModifica
            dc = dt.Columns["IDSysUtenteUltimaModifica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtenteUltimaModifica nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtenteUltimaModifica nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtenteUltimaModifica nvarchar(80) NULL");
              }
            }


            //IDSysUtente
            dc = dt.Columns["IDSysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysPassePartout
    public static bool CreaTabella_sysPassePartout(BConnection DB, BLogText bLog)
    {
      string Nome = "sysPassePartout";
      string Comando = "CREATE TABLE sysPassePartout([ID] int NOT NULL , [Password] varbinary(MAX) NOT NULL , CONSTRAINT PK_sysPassePartout PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Password
            dc = dt.Columns["Password"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Password varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password varbinary(MAX) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password varbinary(MAX) NOT NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysPersone
    public static bool CreaTabella_sysPersone(BConnection DB, BLogText bLog)
    {
      string Nome = "sysPersone";
      string Comando = "CREATE TABLE sysPersone([ID] int IDENTITY (0,1)  NOT NULL , [CodiceFiscale] nvarchar(160), [Nome] nvarchar(400), [Cognome] nvarchar(400), [DataNascita] datetime, [Sesso] bit, [Fax] nvarchar(400), [Telefono] nvarchar(160), [Celluare] nvarchar(160), [AltroRecapito] nvarchar(400), [Email] nvarchar(1600), [CAPResidenza] nvarchar(80), [CAPDomicilio] nvarchar(80), [IndirizzoDomicilio] nvarchar(MAX), [IndirizzoResidenza] nvarchar(MAX), [IDStatoNascita] nvarchar(24), [IDStatoDomicilio] nvarchar(24), [IDStatoResidenza] nvarchar(24), [IDComuneNascita] nvarchar(32), [IDComuneDomicilio] nvarchar(32), [IDComuneResidenza] nvarchar(32), [Note] nvarchar(MAX), [WebSite] nvarchar(1600), [Foto] varbinary(MAX), [IDQuartiereResidenza] int, [IDQuartiereDomicilio] int, CONSTRAINT PK_sysPersone PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //CodiceFiscale
            dc = dt.Columns["CodiceFiscale"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CodiceFiscale nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceFiscale nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceFiscale nvarchar(80) NULL");
              }
            }


            //Nome
            dc = dt.Columns["Nome"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Nome nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nome nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nome nvarchar(200) NULL");
              }
            }


            //Cognome
            dc = dt.Columns["Cognome"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Cognome nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cognome nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cognome nvarchar(200) NULL");
              }
            }


            //DataNascita
            dc = dt.Columns["DataNascita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataNascita datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNascita datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNascita datetime NULL");
              }
            }


            //Sesso
            dc = dt.Columns["Sesso"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Sesso bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sesso bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sesso bit NULL");
              }
            }


            //Fax
            dc = dt.Columns["Fax"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Fax nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Fax nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Fax nvarchar(200) NULL");
              }
            }


            //Telefono
            dc = dt.Columns["Telefono"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Telefono nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Telefono nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Telefono nvarchar(80) NULL");
              }
            }


            //Celluare
            dc = dt.Columns["Celluare"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Celluare nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Celluare nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Celluare nvarchar(80) NULL");
              }
            }


            //AltroRecapito
            dc = dt.Columns["AltroRecapito"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD AltroRecapito nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN AltroRecapito nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN AltroRecapito nvarchar(200) NULL");
              }
            }


            //Email
            dc = dt.Columns["Email"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Email nvarchar(800)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(800)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Email nvarchar(800) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Email nvarchar(800) NULL");
              }
            }


            //CAPResidenza
            dc = dt.Columns["CAPResidenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CAPResidenza nvarchar(40)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(40)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAPResidenza nvarchar(40) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAPResidenza nvarchar(40) NULL");
              }
            }


            //CAPDomicilio
            dc = dt.Columns["CAPDomicilio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CAPDomicilio nvarchar(40)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(40)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAPDomicilio nvarchar(40) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CAPDomicilio nvarchar(40) NULL");
              }
            }


            //IndirizzoDomicilio
            dc = dt.Columns["IndirizzoDomicilio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IndirizzoDomicilio nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IndirizzoDomicilio nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IndirizzoDomicilio nvarchar(MAX) NULL");
              }
            }


            //IndirizzoResidenza
            dc = dt.Columns["IndirizzoResidenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IndirizzoResidenza nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IndirizzoResidenza nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IndirizzoResidenza nvarchar(MAX) NULL");
              }
            }


            //IDStatoNascita
            dc = dt.Columns["IDStatoNascita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDStatoNascita nvarchar(12)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(12)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoNascita nvarchar(12) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoNascita nvarchar(12) NULL");
              }
            }


            //IDStatoDomicilio
            dc = dt.Columns["IDStatoDomicilio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDStatoDomicilio nvarchar(12)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(12)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoDomicilio nvarchar(12) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoDomicilio nvarchar(12) NULL");
              }
            }


            //IDStatoResidenza
            dc = dt.Columns["IDStatoResidenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDStatoResidenza nvarchar(12)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(12)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoResidenza nvarchar(12) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDStatoResidenza nvarchar(12) NULL");
              }
            }


            //IDComuneNascita
            dc = dt.Columns["IDComuneNascita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDComuneNascita nvarchar(16)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(16)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneNascita nvarchar(16) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneNascita nvarchar(16) NULL");
              }
            }


            //IDComuneDomicilio
            dc = dt.Columns["IDComuneDomicilio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDComuneDomicilio nvarchar(16)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(16)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneDomicilio nvarchar(16) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneDomicilio nvarchar(16) NULL");
              }
            }


            //IDComuneResidenza
            dc = dt.Columns["IDComuneResidenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDComuneResidenza nvarchar(16)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(16)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneResidenza nvarchar(16) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneResidenza nvarchar(16) NULL");
              }
            }


            //Note
            dc = dt.Columns["Note"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Note nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Note nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Note nvarchar(MAX) NULL");
              }
            }


            //WebSite
            dc = dt.Columns["WebSite"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD WebSite nvarchar(800)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(800)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN WebSite nvarchar(800) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN WebSite nvarchar(800) NULL");
              }
            }


            //Foto
            dc = dt.Columns["Foto"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Foto varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Foto varbinary(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Foto varbinary(MAX) NULL");
              }
            }


            //IDQuartiereResidenza
            dc = dt.Columns["IDQuartiereResidenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDQuartiereResidenza int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiereResidenza int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiereResidenza int NULL");
              }
            }


            //IDQuartiereDomicilio
            dc = dt.Columns["IDQuartiereDomicilio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDQuartiereDomicilio int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiereDomicilio int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDQuartiereDomicilio int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysPolicyPwd
    public static bool CreaTabella_sysPolicyPwd(BConnection DB, BLogText bLog)
    {
      string Nome = "sysPolicyPwd";
      string Comando = "CREATE TABLE sysPolicyPwd([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(400), [ScadenzaPwd] bit, [NumGiorni] tinyint, [ChkPwdImmessa] bit, [NumMaxChkPwdImmessa] smallint, [Sistema] bit, CONSTRAINT PK_sysPolicyPwd PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }


            //ScadenzaPwd
            dc = dt.Columns["ScadenzaPwd"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ScadenzaPwd bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ScadenzaPwd bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ScadenzaPwd bit NULL");
              }
            }


            //NumGiorni
            dc = dt.Columns["NumGiorni"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD NumGiorni tinyint");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("tinyint").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NumGiorni tinyint NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NumGiorni tinyint NULL");
              }
            }


            //ChkPwdImmessa
            dc = dt.Columns["ChkPwdImmessa"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ChkPwdImmessa bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ChkPwdImmessa bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ChkPwdImmessa bit NULL");
              }
            }


            //NumMaxChkPwdImmessa
            dc = dt.Columns["NumMaxChkPwdImmessa"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD NumMaxChkPwdImmessa smallint");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("smallint").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NumMaxChkPwdImmessa smallint NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN NumMaxChkPwdImmessa smallint NULL");
              }
            }


            //Sistema
            dc = dt.Columns["Sistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Sistema bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sistema bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sistema bit NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysProfili
    public static bool CreaTabella_sysProfili(BConnection DB, BLogText bLog)
    {
      string Nome = "sysProfili";
      string Comando = "CREATE TABLE sysProfili([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(400), [DataInizio] datetime, [DataFine] datetime, [Note] nvarchar(MAX), [Immagine] varbinary(MAX), CONSTRAINT PK_sysProfili PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }


            //DataInizio
            dc = dt.Columns["DataInizio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataInizio datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizio datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizio datetime NULL");
              }
            }


            //DataFine
            dc = dt.Columns["DataFine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataFine datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFine datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFine datetime NULL");
              }
            }


            //Note
            dc = dt.Columns["Note"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Note nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Note nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Note nvarchar(MAX) NULL");
              }
            }


            //Immagine
            dc = dt.Columns["Immagine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Immagine varbinary(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varbinary(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Immagine varbinary(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Immagine varbinary(MAX) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysProfiliFunzioni
    public static bool CreaTabella_sysProfiliFunzioni(BConnection DB, BLogText bLog)
    {
      string Nome = "sysProfiliFunzioni";
      string Comando = "CREATE TABLE sysProfiliFunzioni([IDSysProfilo] int NOT NULL , [IDSysFunzione] int NOT NULL , [IDSysRuolo] int, CONSTRAINT PK_sysProfiliFunzioni PRIMARY KEY ([IDSysProfilo], [IDSysFunzione]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysProfilo
            dc = dt.Columns["IDSysProfilo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysProfilo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NOT NULL");
              }
            }


            //IDSysFunzione
            dc = dt.Columns["IDSysFunzione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysFunzione int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysFunzione int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysFunzione int NOT NULL");
              }
            }


            //IDSysRuolo
            dc = dt.Columns["IDSysRuolo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysRuolo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysRuolo int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysRuolo int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysProfilo,IDSysFunzione)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysProvince
    public static bool CreaTabella_sysProvince(BConnection DB, BLogText bLog)
    {
      string Nome = "sysProvince";
      string Comando = "CREATE TABLE sysProvince([ID] nvarchar(8) NOT NULL , [Descrizione] nvarchar(400), [IDRegione] nvarchar(12), CONSTRAINT PK_sysProvince PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID nvarchar(4)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(4)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(4) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(4) NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }


            //IDRegione
            dc = dt.Columns["IDRegione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDRegione nvarchar(6)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(6)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDRegione nvarchar(6) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDRegione nvarchar(6) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysPwdUtilizzate
    public static bool CreaTabella_sysPwdUtilizzate(BConnection DB, BLogText bLog)
    {
      string Nome = "sysPwdUtilizzate";
      string Comando = "CREATE TABLE sysPwdUtilizzate([IDSysUtente] nvarchar(160) NOT NULL , [Data] datetime NOT NULL , [Password] nvarchar(MAX), CONSTRAINT PK_PwdUtilizzate PRIMARY KEY ([IDSysUtente], [Data]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysUtente
            dc = dt.Columns["IDSysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NOT NULL");
              }
            }


            //Data
            dc = dt.Columns["Data"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Data datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Data datetime NOT NULL");
              }
            }


            //Password
            dc = dt.Columns["Password"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Password nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysUtente,Data)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysRegioni
    public static bool CreaTabella_sysRegioni(BConnection DB, BLogText bLog)
    {
      string Nome = "sysRegioni";
      string Comando = "CREATE TABLE sysRegioni([ID] nvarchar(12) NOT NULL , [Descrizione] nvarchar(400), CONSTRAINT PK_sysRegioni PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID nvarchar(6)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(6)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(6) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(6) NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysRegistrazioniRichieste
    public static bool CreaTabella_sysRegistrazioniRichieste(BConnection DB, BLogText bLog)
    {
      string Nome = "sysRegistrazioniRichieste";
      string Comando = "CREATE TABLE sysRegistrazioniRichieste([ID] int IDENTITY (0,1)  NOT NULL , [IDUtente] nvarchar(160), [Nome] nvarchar(160), [Cognome] nvarchar(160), [DataNascita] datetime, [IDComuneNascita] nvarchar(32), [Sesso] bit, [CodiceFiscale] nvarchar(160), [email] nvarchar(1600), [Password] nvarchar(MAX), CONSTRAINT PK_sysRegistrazioniRichieste PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDUtente
            dc = dt.Columns["IDUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDUtente nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDUtente nvarchar(80) NULL");
              }
            }


            //Nome
            dc = dt.Columns["Nome"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Nome nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nome nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nome nvarchar(80) NULL");
              }
            }


            //Cognome
            dc = dt.Columns["Cognome"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Cognome nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cognome nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cognome nvarchar(80) NULL");
              }
            }


            //DataNascita
            dc = dt.Columns["DataNascita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataNascita datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNascita datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNascita datetime NULL");
              }
            }


            //IDComuneNascita
            dc = dt.Columns["IDComuneNascita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDComuneNascita nvarchar(16)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(16)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneNascita nvarchar(16) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDComuneNascita nvarchar(16) NULL");
              }
            }


            //Sesso
            dc = dt.Columns["Sesso"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Sesso bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sesso bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sesso bit NULL");
              }
            }


            //CodiceFiscale
            dc = dt.Columns["CodiceFiscale"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CodiceFiscale nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceFiscale nvarchar(80) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN CodiceFiscale nvarchar(80) NULL");
              }
            }


            //email
            dc = dt.Columns["email"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD email nvarchar(800)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(800)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN email nvarchar(800) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN email nvarchar(800) NULL");
              }
            }


            //Password
            dc = dt.Columns["Password"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Password nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysRuoli
    public static bool CreaTabella_sysRuoli(BConnection DB, BLogText bLog)
    {
      string Nome = "sysRuoli";
      string Comando = "CREATE TABLE sysRuoli([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(500), CONSTRAINT PK_sysRuoli PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(250) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysSeverity
    public static bool CreaTabella_sysSeverity(BConnection DB, BLogText bLog)
    {
      string Nome = "sysSeverity";
      string Comando = "CREATE TABLE sysSeverity([ID] int IDENTITY (1,1)  NOT NULL , [Descrizione] nvarchar(100), [Bloccante] bit, CONSTRAINT PK_sysSeverity PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(50)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(50)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(50) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(50) NULL");
              }
            }


            //Bloccante
            dc = dt.Columns["Bloccante"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Bloccante bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Bloccante bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Bloccante bit NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysSistemi
    public static bool CreaTabella_sysSistemi(BConnection DB, BLogText bLog)
    {
      string Nome = "sysSistemi";
      string Comando = "CREATE TABLE sysSistemi([ID] int IDENTITY (0,1)  NOT NULL , [Descrizione] nvarchar(400), [DataInizio] datetime, [DataFine] datetime, [Attivo] bit, CONSTRAINT PK_sysSistemi PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(200)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(200)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(200) NULL");
              }
            }


            //DataInizio
            dc = dt.Columns["DataInizio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataInizio datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizio datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataInizio datetime NULL");
              }
            }


            //DataFine
            dc = dt.Columns["DataFine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataFine datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFine datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataFine datetime NULL");
              }
            }


            //Attivo
            dc = dt.Columns["Attivo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Attivo bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysSistemiAttributi
    public static bool CreaTabella_sysSistemiAttributi(BConnection DB, BLogText bLog)
    {
      string Nome = "sysSistemiAttributi";
      string Comando = "CREATE TABLE sysSistemiAttributi([IDSysSistema] int NOT NULL , [Chiave] varchar(250) NOT NULL , [Valore] varchar(250), CONSTRAINT PK_sysSistemiAttributi PRIMARY KEY ([IDSysSistema], [Chiave]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysSistema
            dc = dt.Columns["IDSysSistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSistema int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NOT NULL");
              }
            }


            //Chiave
            dc = dt.Columns["Chiave"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Chiave varchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Chiave varchar(250) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Chiave varchar(250) NOT NULL");
              }
            }


            //Valore
            dc = dt.Columns["Valore"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Valore varchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Valore varchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Valore varchar(250) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysSistema,Chiave)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysStati
    public static bool CreaTabella_sysStati(BConnection DB, BLogText bLog)
    {
      string Nome = "sysStati";
      string Comando = "CREATE TABLE sysStati([ID] nvarchar(12) NOT NULL , [Descrizione] nvarchar(200), [Nota] nvarchar(600), [FlagCEE] nvarchar(4), CONSTRAINT PK_sysStati PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID nvarchar(6)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(6)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(6) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(6) NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(100)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(100)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(100) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(100) NULL");
              }
            }


            //Nota
            dc = dt.Columns["Nota"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Nota nvarchar(300)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(300)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nota nvarchar(300) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Nota nvarchar(300) NULL");
              }
            }


            //FlagCEE
            dc = dt.Columns["FlagCEE"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD FlagCEE nvarchar(2)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(2)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN FlagCEE nvarchar(2) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN FlagCEE nvarchar(2) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysUtenti
    public static bool CreaTabella_sysUtenti(BConnection DB, BLogText bLog)
    {
      string Nome = "sysUtenti";
      string Comando = "CREATE TABLE sysUtenti([ID] nvarchar(40) NOT NULL , [Password] nvarchar(MAX), [IDSysProfilo] int, [IDSysPolicyPwd] int, [IDPersona] int, [Attivo] bit, [DataCreazione] datetime, [DataScadenza] datetime, [DataUltimoCambioPwd] datetime, [Developer] bit, [Dominio] varchar(50), [IDSysSistema] int, [Username] nvarchar(40), [IDVisibilita] int, CONSTRAINT PK_sysUtenti PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID nvarchar(20)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(20)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(20) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID nvarchar(20) NOT NULL");
              }
            }


            //Password
            dc = dt.Columns["Password"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Password nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Password nvarchar(MAX) NULL");
              }
            }


            //IDSysProfilo
            dc = dt.Columns["IDSysProfilo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysProfilo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NULL");
              }
            }


            //IDSysPolicyPwd
            dc = dt.Columns["IDSysPolicyPwd"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysPolicyPwd int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysPolicyPwd int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysPolicyPwd int NULL");
              }
            }


            //IDPersona
            dc = dt.Columns["IDPersona"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDPersona int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPersona int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPersona int NULL");
              }
            }


            //Attivo
            dc = dt.Columns["Attivo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Attivo bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Attivo bit NULL");
              }
            }


            //DataCreazione
            dc = dt.Columns["DataCreazione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataCreazione datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCreazione datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCreazione datetime NULL");
              }
            }


            //DataScadenza
            dc = dt.Columns["DataScadenza"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataScadenza datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataScadenza datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataScadenza datetime NULL");
              }
            }


            //DataUltimoCambioPwd
            dc = dt.Columns["DataUltimoCambioPwd"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataUltimoCambioPwd datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimoCambioPwd datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimoCambioPwd datetime NULL");
              }
            }


            //Developer
            dc = dt.Columns["Developer"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Developer bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Developer bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Developer bit NULL");
              }
            }


            //Dominio
            dc = dt.Columns["Dominio"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Dominio varchar(50)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varchar(50)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Dominio varchar(50) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Dominio varchar(50) NULL");
              }
            }


            //IDSysSistema
            dc = dt.Columns["IDSysSistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSistema int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NULL");
              }
            }


            //Username
            dc = dt.Columns["Username"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Username nvarchar(20)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(20)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Username nvarchar(20) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Username nvarchar(20) NULL");
              }
            }


            //IDVisibilita
            dc = dt.Columns["IDVisibilita"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDVisibilita int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDVisibilita int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDVisibilita int NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysUtentiNotifiche
    public static bool CreaTabella_sysUtentiNotifiche(BConnection DB, BLogText bLog)
    {
      string Nome = "sysUtentiNotifiche";
      string Comando = "CREATE TABLE sysUtentiNotifiche([IDsysUtente] nvarchar(160) NOT NULL , [IDsysNotifica] int NOT NULL , [Letta] bit, [Notificata] bit, [Cancellata] bit, [DataLetta] datetime, [DataNotificata] datetime, [DataCancellata] datetime, CONSTRAINT PK_sysUtentiNotifiche PRIMARY KEY ([IDsysUtente], [IDsysNotifica]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDsysUtente
            dc = dt.Columns["IDsysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDsysUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDsysUtente nvarchar(80) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDsysUtente nvarchar(80) NOT NULL");
              }
            }


            //IDsysNotifica
            dc = dt.Columns["IDsysNotifica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDsysNotifica int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDsysNotifica int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDsysNotifica int NOT NULL");
              }
            }


            //Letta
            dc = dt.Columns["Letta"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Letta bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Letta bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Letta bit NULL");
              }
            }


            //Notificata
            dc = dt.Columns["Notificata"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Notificata bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Notificata bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Notificata bit NULL");
              }
            }


            //Cancellata
            dc = dt.Columns["Cancellata"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Cancellata bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cancellata bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Cancellata bit NULL");
              }
            }


            //DataLetta
            dc = dt.Columns["DataLetta"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataLetta datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataLetta datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataLetta datetime NULL");
              }
            }


            //DataNotificata
            dc = dt.Columns["DataNotificata"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataNotificata datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNotificata datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataNotificata datetime NULL");
              }
            }


            //DataCancellata
            dc = dt.Columns["DataCancellata"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataCancellata datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCancellata datetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataCancellata datetime NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDsysUtente,IDsysNotifica)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysUtentiProfili
    public static bool CreaTabella_sysUtentiProfili(BConnection DB, BLogText bLog)
    {
      string Nome = "sysUtentiProfili";
      string Comando = "CREATE TABLE sysUtentiProfili([IDSysUtente] nvarchar(160) NOT NULL , [IDSysProfilo] int NOT NULL , [IDSysSistema] int NOT NULL , CONSTRAINT PK_sysUtentiProfili PRIMARY KEY ([IDSysUtente], [IDSysProfilo], [IDSysSistema]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysUtente
            dc = dt.Columns["IDSysUtente"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysUtente nvarchar(80)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(80)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysUtente nvarchar(80) NOT NULL");
              }
            }


            //IDSysProfilo
            dc = dt.Columns["IDSysProfilo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysProfilo int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysProfilo int NOT NULL");
              }
            }


            //IDSysSistema
            dc = dt.Columns["IDSysSistema"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysSistema int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysSistema int NOT NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysUtente,IDSysProfilo,IDSysSistema)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysViewState
    public static bool CreaTabella_sysViewState(BConnection DB, BLogText bLog)
    {
      string Nome = "sysViewState";
      string Comando = "CREATE TABLE sysViewState([ViewStateId] nvarchar(800) NOT NULL , [Value] image NOT NULL , [LastAccessed] datetime NOT NULL , [Timeout] int NOT NULL , CONSTRAINT PK_sysViewState PRIMARY KEY ([ViewStateId]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ViewStateId
            dc = dt.Columns["ViewStateId"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ViewStateId nvarchar(400)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(400)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ViewStateId nvarchar(400) NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ViewStateId nvarchar(400) NOT NULL");
              }
            }


            //Value
            dc = dt.Columns["Value"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Value image");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("image").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Value image NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Value image NOT NULL");
              }
            }


            //LastAccessed
            dc = dt.Columns["LastAccessed"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD LastAccessed datetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("datetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LastAccessed datetime NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN LastAccessed datetime NOT NULL");
              }
            }


            //Timeout
            dc = dt.Columns["Timeout"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Timeout int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Timeout int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Timeout int NOT NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ViewStateId)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysVisibilita
    public static bool CreaTabella_sysVisibilita(BConnection DB, BLogText bLog)
    {
      string Nome = "sysVisibilita";
      string Comando = "CREATE TABLE sysVisibilita([ID] int IDENTITY (1,1)  NOT NULL , [Descrizione] nvarchar(2000), CONSTRAINT PK_sysVisibilita PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(1000)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(1000)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(1000) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(1000) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysWiki
    public static bool CreaTabella_sysWiki(BConnection DB, BLogText bLog)
    {
      string Nome = "sysWiki";
      string Comando = "CREATE TABLE sysWiki([ID] int IDENTITY (1,1)  NOT NULL , [IDPadre] int, [Titolo] nvarchar(500), [Sottotitolo] nvarchar(1000), [Descrizione] nvarchar(MAX), [DataUltimaModifica] smalldatetime, [Tags] varchar(250), [Ordine] int, [Pubblica] bit, CONSTRAINT PK_Wiki PRIMARY KEY ([ID]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //ID
            dc = dt.Columns["ID"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD ID int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN ID int NOT NULL");
              }
            }


            //IDPadre
            dc = dt.Columns["IDPadre"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDPadre int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDPadre int NULL");
              }
            }


            //Titolo
            dc = dt.Columns["Titolo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Titolo nvarchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Titolo nvarchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Titolo nvarchar(250) NULL");
              }
            }


            //Sottotitolo
            dc = dt.Columns["Sottotitolo"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Sottotitolo nvarchar(500)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(500)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sottotitolo nvarchar(500) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Sottotitolo nvarchar(500) NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(MAX) NULL");
              }
            }


            //DataUltimaModifica
            dc = dt.Columns["DataUltimaModifica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD DataUltimaModifica smalldatetime");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("smalldatetime").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimaModifica smalldatetime NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN DataUltimaModifica smalldatetime NULL");
              }
            }


            //Tags
            dc = dt.Columns["Tags"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Tags varchar(250)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("varchar(250)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Tags varchar(250) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Tags varchar(250) NULL");
              }
            }


            //Ordine
            dc = dt.Columns["Ordine"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Ordine int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Ordine int NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Ordine int NULL");
              }
            }


            //Pubblica
            dc = dt.Columns["Pubblica"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Pubblica bit");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("bit").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Pubblica bit NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Pubblica bit NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(ID)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysWikiAllegati
    public static bool CreaTabella_sysWikiAllegati(BConnection DB, BLogText bLog)
    {
      string Nome = "sysWikiAllegati";
      string Comando = "CREATE TABLE sysWikiAllegati([IDSysWiki] int NOT NULL , [IDAllegato] int NOT NULL , [Descrizione] nvarchar(800), [PathAllegato] nvarchar(MAX), CONSTRAINT PK_WikiAllegati PRIMARY KEY ([IDSysWiki], [IDAllegato]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysWiki
            dc = dt.Columns["IDSysWiki"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysWiki int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWiki int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWiki int NOT NULL");
              }
            }


            //IDAllegato
            dc = dt.Columns["IDAllegato"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDAllegato int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDAllegato int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDAllegato int NOT NULL");
              }
            }


            //Descrizione
            dc = dt.Columns["Descrizione"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD Descrizione nvarchar(400)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(400)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(400) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN Descrizione nvarchar(400) NULL");
              }
            }


            //PathAllegato
            dc = dt.Columns["PathAllegato"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD PathAllegato nvarchar(MAX)");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("nvarchar(MAX)").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN PathAllegato nvarchar(MAX) NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NULL" == "NOT NULL") || (!dc.AllowDBNull && "NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN PathAllegato nvarchar(MAX) NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysWiki,IDAllegato)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion
    #region public static bool CreaTabella_sysWikiLinks
    public static bool CreaTabella_sysWikiLinks(BConnection DB, BLogText bLog)
    {
      string Nome = "sysWikiLinks";
      string Comando = "CREATE TABLE sysWikiLinks([IDSysWiki] int NOT NULL , [IDSysWikiRef] int NOT NULL , CONSTRAINT PK_WikiLinks PRIMARY KEY ([IDSysWiki], [IDSysWikiRef]))";
      BDataTable dt = null;
      DataColumn dc = null;
      string sType;
      bool TabConRighe = true;
      try
      {
        if (!BAggiornaDB.EsisteTabella(DB, Nome, ref TabConRighe, bLog))
        {
          DB.ExecuteNonQuery(Comando);
        }
        else
        {
          if (!TabConRighe)
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("IF OBJECT_ID('" + Nome + "') IS NOT NULL DROP TABLE " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
            return true;
          }
          dt = DB.ApriDT("Select TOP 1 * from " + Nome, true, 30, true);
          if (dt != null && dt.Rows.Count > 0)
          {
            string PKName = BAggiornaDB.GetPKName(DB, Nome, bLog);
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " DROP CONSTRAINT " + PKName);

            //IDSysWiki
            dc = dt.Columns["IDSysWiki"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysWiki int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWiki int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWiki int NOT NULL");
              }
            }


            //IDSysWikiRef
            dc = dt.Columns["IDSysWikiRef"];
            if (dc == null) //SE NON ESISTE AGGIUNGO IL CAMPO MANCANTE
            {
              DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD IDSysWikiRef int");
            }
            else
            {
              sType = BAggiornaDB.GetStrType(dc, bLog);
              if (sType.ToUpper() != ("int").ToString().ToUpper()) //MODIFICO IL CAMPO MANCANTE
              {
                DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWikiRef int NOT NULL");
              }
              else
              {
                if ((dc.AllowDBNull && "NOT NULL" == "NOT NULL") || (!dc.AllowDBNull && "NOT NULL" == "NULL"))
                  DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ALTER COLUMN IDSysWikiRef int NOT NULL");
              }
            }

            //PRIMARY KEY
            if (PKName != "") DB.ExecuteNonQuery("ALTER TABLE " + Nome + " ADD CONSTRAINT " + PKName + " PRIMARY KEY CLUSTERED(IDSysWiki,IDSysWikiRef)");
          }
          else
          {
            //RIMOZIONE TABELLA
            DB.ExecuteNonQuery("DROP TABLE IF EXISTS " + Nome);
            //CREAZIONE NUOVA TABELLA
            DB.ExecuteNonQuery(Comando);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        bLog?.AppendLog("***EXCEPTION*** <<" + dc?.ColumnName + ">> " + ex.Message);
        return false;
      }
    }
    #endregion

  } //END CLASS
} //END NAMESPACE