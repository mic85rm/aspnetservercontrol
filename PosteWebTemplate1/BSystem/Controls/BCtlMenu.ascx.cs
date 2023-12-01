using BArts;
using BArts.BData;
using System;
using System.Data;

namespace PosteWebTemplate1
{
  // ********************************************************************
  // ***QUESTO CONTROLLO PUO' ESSERE UTILIZZATO SOLO SULLE MASTER PAGE***
  // ********************************************************************
  public partial class BCtlMenu : BWebControlsBase
  {

    // DEFINIZIONE METODI
    public bool InitControl()
    {
      DataTable Dt = null;
      try
      {
        DB.ClearParameter();
        if (this.UtenteEntrato != null)
        {
          if (BWebConfig.TipoApplicazione == BWebConfig.eTipoApplicazione.WPAppChild)
          {
            DB.AddParameter("@IDUtente", BSysUtenteEntrato.IDUtenteWP);
            if (UtenteEntrato.Developer)
            {
              DB.AddParameter("@Developer", true);
            }
            Dt = DB.ApriDT("BSP_sysGetMenuFunzioniWP", CommandType.StoredProcedure);
          }
          else
          {
            if (BSysUtenteEntrato.Accesso != null && BSysUtenteEntrato.IDSysSistema != -1)
            {
              base.DB.AddParameter("@IDSysProfilo", this.UtenteEntrato.IDProfilo);
              if (this.UtenteEntrato.Developer)
              {
                base.DB.AddParameter("@Developer", true);
              }

              Dt = base.DB.ApriDT("BSP_sysGetMenuFunzioni", CommandType.StoredProcedure);
            }
            else
            {
              if (this.UtenteEntrato.Developer)
              {
                base.DB.AddParameter("@Developer", true);
              }

              Dt = base.DB.ApriDT("BSP_sysGetMenuFunzioni", CommandType.StoredProcedure);
            }
          }
        }
        else
        {
          Dt = base.DB.ApriDT("BSP_sysGetMenuFunzioni", CommandType.StoredProcedure);
        }

        LoadBMenu(Dt);
        return true;
      }
      catch (Exception exp)
      {
        this.WriteLog("BCtlMenu.InitControl", "", exp, BEnumerations.eSeverity.ERROR);
        return false;
      }
      finally
      {
        if (Dt != null)
        {
          Dt.Dispose();
          Dt = null;
        }
      }
    }

    // DEFINIZIONE FUNZIONI PRIVATE
    private void LoadBMenu(DataTable dt)
    {
      this.BMenuFunzioni.CampoID = "ID";
      this.BMenuFunzioni.CampoIDPadre = "IDPadre";
      this.BMenuFunzioni.CampoDescrizione = "Descrizione";
      this.BMenuFunzioni.CampoToolTip = "ToolTip";
      this.BMenuFunzioni.CampoImage = "Image";
      this.BMenuFunzioni.CampoComando = "Comando";
      this.BMenuFunzioni.CampoOrdine = "Ordine";
      this.BMenuFunzioni.TipoDatoCampoKey = BArts.BWeb.BControls.BMenu.eTipoDatoKey.NUMERICO;
      this.BMenuFunzioni.ImageIsByteArray = true;
      this.BMenuFunzioni.DataSource = (BDataTable)dt;
    }

  } //END CLASS
} //END NAMESPACE