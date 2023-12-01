using BArts.BSecurity;
using BArts.BWeb.BControls;

namespace PosteWebTemplate1
{
  public partial class CtlCambiaPassword : BWebControlsBase
  {

    // DEFINIZIONE PROPRIETA'
    public BTesto mbtOldPwd
    {
      get
      {
        return this.Internal_mbtOldPwd;
      }

      set
      {
        this.Internal_mbtOldPwd = value;
      }
    }
    public BTesto mbtNewPwd
    {
      get
      {
        return this.Internal_mbtNewPwd;
      }

      set
      {
        this.Internal_mbtNewPwd = value;
      }
    }
    public BTesto mbtCommitPwd
    {
      get
      {
        return this.Internal_mbtCommitPwd;
      }

      set
      {
        this.Internal_mbtCommitPwd = value;
      }
    }

    #region public bool RequiredOldPwd
    private bool K_DEF_REQUIREDOLDPWD = true;
    private const string K_VS_REQUIREDOLDPWD = ".RequiredOldPwd";
    public bool RequiredOldPwd
    {
      get
      {
        if (base.ViewState[K_VS_REQUIREDOLDPWD] == null)
          return K_DEF_REQUIREDOLDPWD;
        return (bool)(base.ViewState[K_VS_REQUIREDOLDPWD]);
      }
      set
      {
        base.ViewState[K_VS_REQUIREDOLDPWD] = value;
      }
    }
    #endregion
    #region public BUtenti Utente
    private const string K_SE_UTENTE = ".Utente";
    public BUtenti Utente
    {
      get
      {
        return (BUtenti)base.Session[K_SE_UTENTE];
      }
      set
      {
        base.Session[K_SE_UTENTE] = value;
      }
    }
    #endregion

    // DEFINIZIONE METODI
    public void SetAttributes_Invio()
    {
      // DETTAGLIO
      mbtOldPwd.CtlNextFocus = mbtNewPwd.ClientID;
      mbtOldPwd.INVIO = true;
      mbtNewPwd.CtlNextFocus = mbtCommitPwd.ClientID;
      mbtNewPwd.INVIO = true;
      mbtCommitPwd.CtlNextFocus = mbtCommitPwd.ClientID;
      mbtCommitPwd.INVIO = true;
    }
    public void InitControl(BUtenti Utente = null)
    {
      if (Utente != null) this.Utente = Utente;
      this.SetAttributes_Invio();
      //NUOVO REC
      this.Internal_mbtOldPwd.Text = "";
      this.Internal_mbtNewPwd.Text = "";
      this.Internal_mbtCommitPwd.Text = "";
      // VISIBILITY
      this.divOldPwd.Visible = RequiredOldPwd;
      this.divLblOldPwd.Visible = RequiredOldPwd;
      if (RequiredOldPwd)
      {
        this.Internal_mbtOldPwd.Focus();
      }
      else
      {
        this.Internal_mbtNewPwd.Focus();
      }
    }
    public bool ChangePassword()
    {
      if (Utente == null || Utente.IsNothing)
      {
        this.lblMessage.Text = "Utente non individuato.";
        return false;
      }

      if (RequiredOldPwd && Utente.Password != BCrypter.Encrypt(mbtOldPwd.Text))
      {
        this.lblMessage.Text = "La password inserita non è corretta.";
        return false;
      }

      if (mbtNewPwd.Text != mbtCommitPwd.Text)
      {
        this.lblMessage.Text = "Le password inserite non corrispondono.";
        return false;
      }

      Utente.Password = BCrypter.Encrypt(mbtNewPwd.Text);
      if (Utente.Update(false))
      {
        this.lblMessage.Text = "Le password è stata modificata.";
        return true;
      }
      else
      {
        this.lblMessage.Text = "Non è stato possibile modificare la password per un problema tecnico.";
        return false;
      }
    }

  } //END CLASS
} //END NAMESPACE