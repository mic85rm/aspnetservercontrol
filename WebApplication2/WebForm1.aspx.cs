﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
  public partial class WebForm1 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    if(!IsPostBack) { 
      michele.Text = "prova";
      }
      else
      {
        michele.Text = "azz";
      }

    }

    protected void michele2_Click(object sender, EventArgs e)
    {
      string ciao = michele.Text;
      michele.Text = "grande";
    }
  }
}