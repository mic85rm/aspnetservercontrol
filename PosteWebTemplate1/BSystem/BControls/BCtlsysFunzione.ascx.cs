using BArts.BWeb.BControls;
using System;

namespace PosteWebTemplate1
{
  public partial class BCtlsysFunzione : BWebControlsBase
  {

    // DEFINIZIONE METODI OVERRIDES
    public override void SetAttributes_AddEvents()
    {
      btnCancellaIcona.Click += btnCancellaIcona_Click;
    }

    // DEFINIZIONE PROPRIETA'
    public bool Enabled
    {
      get
      {
        return this.PnlDettaglio.Enabled;
      }

      set
      {
        this.PnlDettaglio.Enabled = value;
        imgImage.AbilitaUpload = value;
      }
    }

    public BTesto mbtID
    {
      get
      {
        return this.Internal_mbtID;
      }

      set
      {
        this.Internal_mbtID = value;
      }
    }
    public BCombo mbcIDPadre
    {
      get
      {
        return this.Internal_mbcIDPadre;
      }

      set
      {
        this.Internal_mbcIDPadre = value;
      }
    }
    public BCombo mbcIDsysModulo
    {
      get
      {
        return this.Internal_mbcIDSysModulo;
      }

      set
      {
        this.Internal_mbcIDSysModulo = value;
      }
    }
    public BTesto mbtDescrizione
    {
      get
      {
        return this.Internal_mbtDescrizione;
      }

      set
      {
        this.Internal_mbtDescrizione = value;
      }
    }
    public BTesto mbtComando
    {
      get
      {
        return this.Internal_mbtComando;
      }

      set
      {
        this.Internal_mbtComando = value;
      }
    }
    public BTesto mbtOrdine
    {
      get
      {
        return this.Internal_mbtOrdine;
      }

      set
      {
        this.Internal_mbtOrdine = value;
      }
    }
    public BTesto mbtShortCut
    {
      get
      {
        return this.Internal_mbtShortCut;
      }

      set
      {
        this.Internal_mbtShortCut = value;
      }
    }
    public BTesto mbtToolTip
    {
      get
      {
        return this.Internal_mbtTooltip;
      }

      set
      {
        this.Internal_mbtTooltip = value;
      }
    }
    public BTesto mbtIDFunzioneWP
    {
      get
      {
        return this.Internal_mbtIDFunzioneWP;
      }

      set
      {
        this.Internal_mbtIDFunzioneWP = value;
      }
    }
    public BSwitch chkAuth
    {
      get
      {
        return this.Internal_chkAuth;
      }

      set
      {
        this.Internal_chkAuth = value;
      }
    }
    public BSwitch chkDeveloper
    {
      get
      {
        return this.Internal_chkDeveloper;
      }

      set
      {
        this.Internal_chkDeveloper = value;
      }
    }
    public BSwitch chkAttivo
    {
      get
      {
        return this.Internal_chkAttivo;
      }

      set
      {
        this.Internal_chkAttivo = value;
      }
    }
    public BImage imgImage
    {
      get
      {
        return this.Internal_imgImage;
      }

      set
      {
        this.Internal_imgImage = value;
      }
    }

    //DEFINIZIONE FUNZIONI PRIVATE
    private void btnCancellaIcona_Click(object sender, EventArgs e)
    {
      imgImage.ImageByte = null;
      imgImage.ImageUrl = "";
    }

  } //END CLASS
} //END NAMESPACE