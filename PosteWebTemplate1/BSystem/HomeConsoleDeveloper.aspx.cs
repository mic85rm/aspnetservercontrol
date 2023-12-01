using System;

namespace PosteWebTemplate1
{
  public partial class HomeConsoleDeveloper : BPageBase
  {

    // DEFINIZIONE EVENTI INTERCETTATI
    protected void btnGoRole_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysRuoli.aspx");
    }
    protected void btnGoFunzioni_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysFunzioni.aspx");
    }
    protected void btnGoProfili_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysProfili.aspx");
    }
    protected void btnGoModuli_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysModuli.aspx");
    }
    protected void btnGoSeverity_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysSeverity.aspx");
    }
    protected void btnGoLog_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysLog.aspx");
    }
    protected void btnGoInitDB_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysInitDB.aspx");
    }
    protected void btnGoPolicyPWD_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysPolicyPwd.aspx");
    }
    private void BtnGoWebConfig_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysWebConfig.aspx");
    }
    protected void BtnGoConfigMail_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysConfigMailDB.aspx");
    }
    private void BtnGoConfigReport_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysConfigReportingServices.aspx");
    }
    protected void btnGoGestioneUtenti_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysUtenti.aspx");
    }
    protected void btnGoAccessi_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysAccessi.aspx");
    }
    protected void BtnGoSistemi_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysSistemi.aspx");
    }
    protected void BtnGoPasspartout_Click(object sender, EventArgs e)
    {
      this.BRedirect("~/BSystem/sysPassePartout.aspx");
    }


    // DEFINIZIONE EVENTI 
    private void BtnTest_Click(object sender, EventArgs e)
    {
      //base.BRedirect("~/BSystem/testimportmassivo.aspx");
    }

    //DEFINIZIONE METODI OVERRIDES
    protected override void SetAttributes_AddEvents()
    {
      btnGoRuoli.Click += btnGoRole_Click;
      btnGoFunzioni.Click += btnGoFunzioni_Click;
      btnGoProfili.Click += btnGoProfili_Click;
      btnGoModuli.Click += btnGoModuli_Click;
      btnGoSeverity.Click += btnGoSeverity_Click;
      btnGoLog.Click += btnGoLog_Click;
      btnGoInitDB.Click += btnGoInitDB_Click;
      btnGoPolicyPWD.Click += btnGoPolicyPWD_Click;
      BtnGoWebConfig.Click += BtnGoWebConfig_Click;
      BtnGoConfigMail.Click += BtnGoConfigMail_Click;
      BtnGoConfigReport.Click += BtnGoConfigReport_Click;
      btnGoGestioneUtenti.Click += btnGoGestioneUtenti_Click;
      btnGoAccessi.Click += btnGoAccessi_Click;
      BtnGoSistemi.Click += BtnGoSistemi_Click;
      BtnGoPasspartout.Click += BtnGoPasspartout_Click;
      BtnTest.Click += BtnTest_Click;

      this.btnGoBrowserDetection.Attributes["onclick"] = "javascript:return BrowserDetection();";

      base.SetAttributes_AddEvents();
    }

  } //END CLASS
} //END NAMESPACE